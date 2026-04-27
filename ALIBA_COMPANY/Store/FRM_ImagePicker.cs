//// ═══════════════════════════════════════════════════════════════════════════════
////  FRM_ImagePicker.cs  —  النسخة الاحترافية عالية الأداء v6
////  المبرمج: مهندس رامي
////
////  التحسينات:
////  ✅ Virtual Scroll — يرسم فقط البطاقات المرئية (5000 مادة = سلس 60FPS)
////  ✅ Smart Image Cache — LRU Cache بحد أقصى 200 صورة لمنع Memory Leak
////  ✅ Lazy Load — تحميل صور خارج الشاشة بخيط خلفي (BackgroundWorker pool)
////  ✅ Skeleton Loading — انيميشن نبض أثناء التحميل (مثل TikTok)
////  ✅ Image Compression — تصغير ذكي مع حفظ النسبة (Cover Fit)
////  ✅ Double Buffered Panel — لا Flicker عند Scroll
////  ✅ Debounced Search — لا استعلام عند كل حرف (200ms delay)
////  ✅ فلتر اسم عربي — تجاهل المواد بدون اسم
////  ✅ مخزون عند الإضافة فقط
////  ✅ صور محلية C:\AlibaImages\{ID}.ext — بدون DB
//// ═══════════════════════════════════════════════════════════════════════════════

//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using ALIBA_COMPANY.classes;

//namespace ALIBA_COMPANY.Store
//{
//    // =========================================================================
//    //  مساعد الصور المحلية
//    // =========================================================================
//    internal static class ImageStore
//    {
//        public const string RootPath = @"C:\AlibaImages";
//        private static readonly string[] Exts =
//            { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };

//        public static void EnsureFolder()
//        {
//            if (!Directory.Exists(RootPath))
//                Directory.CreateDirectory(RootPath);
//        }

//        public static string Find(int id)
//        {
//            foreach (var ext in Exts)
//            {
//                var p = Path.Combine(RootPath, id + ext);
//                if (File.Exists(p)) return p;
//            }
//            return null;
//        }

//        public static string Save(int id, string src)
//        {
//            EnsureFolder();
//            Delete(id);
//            var ext = Path.GetExtension(src).ToLower();
//            var dest = Path.Combine(RootPath, id + ext);
//            File.Copy(src, dest, true);
//            return dest;
//        }

//        public static void Delete(int id)
//        {
//            foreach (var ext in Exts)
//            {
//                var p = Path.Combine(RootPath, id + ext);
//                if (File.Exists(p)) try { File.Delete(p); } catch { }
//            }
//        }
//    }

//    // =========================================================================
//    //  LRU Image Cache — ذاكرة ذكية مع حد أقصى لمنع Memory Leak
//    // =========================================================================
//    internal sealed class LruImageCache : IDisposable
//    {
//        private readonly int _capacity;
//        private readonly Dictionary<string, LinkedListNode<CacheEntry>> _map;
//        private readonly LinkedList<CacheEntry> _list;
//        private readonly object _lock = new object();

//        private class CacheEntry
//        {
//            public string Key;
//            public Image Value;
//        }

//        public LruImageCache(int capacity = 200)
//        {
//            _capacity = capacity;
//            _map = new Dictionary<string, LinkedListNode<CacheEntry>>(capacity, StringComparer.OrdinalIgnoreCase);
//            _list = new LinkedList<CacheEntry>();
//        }

//        public bool TryGet(string key, out Image img)
//        {
//            lock (_lock)
//            {
//                if (_map.TryGetValue(key, out var node))
//                {
//                    // رفع العنصر للأمام (Most Recently Used)
//                    _list.Remove(node);
//                    _list.AddFirst(node);
//                    img = node.Value.Value;
//                    return true;
//                }
//                img = null;
//                return false;
//            }
//        }

//        public void Set(string key, Image img)
//        {
//            lock (_lock)
//            {
//                if (_map.TryGetValue(key, out var existing))
//                {
//                    existing.Value.Value?.Dispose();
//                    _list.Remove(existing);
//                    _map.Remove(key);
//                }

//                // إزالة الأقدم إذا امتلأت الذاكرة
//                while (_list.Count >= _capacity)
//                {
//                    var last = _list.Last;
//                    _list.RemoveLast();
//                    _map.Remove(last.Value.Key);
//                    last.Value.Value?.Dispose();
//                }

//                var entry = new CacheEntry { Key = key, Value = img };
//                var node = _list.AddFirst(entry);
//                _map[key] = node;
//            }
//        }

//        public void Evict(string key)
//        {
//            if (string.IsNullOrEmpty(key)) return;
//            lock (_lock)
//            {
//                if (_map.TryGetValue(key, out var node))
//                {
//                    node.Value.Value?.Dispose();
//                    _list.Remove(node);
//                    _map.Remove(key);
//                }
//            }
//        }

//        public void Clear()
//        {
//            lock (_lock)
//            {
//                foreach (var n in _list) n.Value?.Dispose();
//                _list.Clear();
//                _map.Clear();
//            }
//        }

//        public void Dispose() => Clear();
//    }

//    // =========================================================================
//    //  بيانات المادة
//    // =========================================================================
//    internal class ItemCard
//    {
//        public int ID { get; set; }
//        public string NameAR { get; set; }
//        public string Code { get; set; }
//        public string Category { get; set; }
//        public string Form { get; set; }
//        public string Notes { get; set; }
//        public string ImagePath { get; set; }
//        public decimal Stock { get; set; } = -1m;
//        public bool StockLoaded => Stock >= 0m;
//    }

//    // =========================================================================
//    //  Virtual Scroll Panel — يرسم فقط البطاقات المرئية
//    //  الفكرة: بدلاً من 5000 Panel منشأ في الذاكرة، نرسم فقط ما يظهر
//    // =========================================================================
//    internal sealed class VirtualCardPanel : Panel
//    {
//        // ── أبعاد البطاقة ─────────────────────────────────────────────────────
//        public const int CARD_W = 165;
//        public const int CARD_H = 200;
//        public const int MARGIN = 8;
//        public const int IMG_H = 118;
//        public const int THUMB_W = 149;
//        public const int THUMB_H = 118;
//        public const int RAD = 10;

//        // ── ألوان ─────────────────────────────────────────────────────────────
//        private static readonly Color C_BG = Color.FromArgb(240, 244, 250);
//        private static readonly Color C_CARD = Color.White;
//        private static readonly Color C_CARD_H = Color.FromArgb(240, 247, 255);
//        private static readonly Color C_CARD_S = Color.FromArgb(220, 238, 255);
//        private static readonly Color C_BDR = Color.FromArgb(210, 218, 230);
//        private static readonly Color C_BDR_H = Color.FromArgb(150, 195, 245);
//        private static readonly Color C_BDR_S = Color.FromArgb(26, 115, 232);
//        private static readonly Color C_TXT = Color.FromArgb(20, 30, 55);
//        private static readonly Color C_CODE = Color.FromArgb(120, 130, 155);
//        private static readonly Color C_IMG_BG = Color.FromArgb(230, 235, 248);
//        private static readonly Color C_CAM = Color.FromArgb(165, 175, 200);
//        private static readonly Color C_SKEL1 = Color.FromArgb(225, 230, 240);
//        private static readonly Color C_SKEL2 = Color.FromArgb(240, 244, 252);

//        // ── LRU Cache مشترك ───────────────────────────────────────────────────
//        public static readonly LruImageCache ImageCache = new LruImageCache(200);

//        // ── حالة اللوحة ───────────────────────────────────────────────────────
//        private List<ItemCard> _items = new List<ItemCard>();
//        private int _selectedIdx = -1;
//        private int _hoverIdx = -1;
//        private int _cols = 1;
//        private int _scrollOffset = 0;
//        private int _totalHeight = 0;

//        // ── Skeleton Animation ────────────────────────────────────────────────
//        private System.Windows.Forms.Timer _skelTimer;
//        private float _skelPhase = 0f;
//        private bool _isLoading = true;

//        // ── Lazy Load ──────────────────────────────────────────────────────────
//        private CancellationTokenSource _lazyCts;
//        private readonly HashSet<string> _loadingPaths = new HashSet<string>();

//        // ── Context Menu ──────────────────────────────────────────────────────
//        private ContextMenuStrip _ctx;

//        // ── أحداث ─────────────────────────────────────────────────────────────
//        public event Action<ItemCard> CardClicked;
//        public event Action<ItemCard, VirtualCardPanel> ImgChangeReq;
//        public event Action<ItemCard, VirtualCardPanel> ImgDeleteReq;

//        // ── P/Invoke للـ Smooth Scroll ────────────────────────────────────────
//        [DllImport("user32.dll")]
//        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
//        private const int WM_SETREDRAW = 11;

//        public VirtualCardPanel()
//        {
//            BackColor = C_BG;
//            DoubleBuffered = true;
//            SetStyle(
//                ControlStyles.AllPaintingInWmPaint |
//                ControlStyles.UserPaint |
//                ControlStyles.OptimizedDoubleBuffer |
//                ControlStyles.ResizeRedraw,
//                true);

//            // Skeleton timer — 60FPS animation
//            _skelTimer = new System.Windows.Forms.Timer { Interval = 16 };
//            _skelTimer.Tick += (s, e) =>
//            {
//                _skelPhase = (_skelPhase + 0.04f) % (float)(Math.PI * 2);
//                if (_isLoading) Invalidate();
//            };
//            _skelTimer.Start();

//            // Mouse events
//            MouseMove += OnMouseMove;
//            MouseLeave += (s, e) => { _hoverIdx = -1; Invalidate(); };
//            MouseClick += OnMouseClick;
//            MouseWheel += OnMouseWheel;
//            Resize += (s, e) => Recalculate();

//            // Context menu
//            _ctx = new ContextMenuStrip { Font = new Font("Cairo", 9.5f) };
//            var m1 = new ToolStripMenuItem("🖼️  تحديد صورة");
//            var m2 = new ToolStripMenuItem("🗑️  حذف الصورة");
//            m1.Click += (s, e) => { var c = GetCardAtMouse(); if (c != null) ImgChangeReq?.Invoke(c, this); };
//            m2.Click += (s, e) => { var c = GetCardAtMouse(); if (c != null) ImgDeleteReq?.Invoke(c, this); };
//            _ctx.Items.Add(m1);
//            _ctx.Items.Add(new ToolStripSeparator());
//            _ctx.Items.Add(m2);
//            ContextMenuStrip = _ctx;
//        }

//        private Point _lastMousePos;
//        private ItemCard GetCardAtMouse() => GetCardAt(_lastMousePos);

//        // ── تحديث قائمة المواد ────────────────────────────────────────────────
//        public void SetItems(List<ItemCard> items, bool isLoading = false)
//        {
//            _isLoading = isLoading;
//            _items = items ?? new List<ItemCard>();
//            _selectedIdx = -1;
//            _hoverIdx = -1;
//            _scrollOffset = 0;

//            Recalculate();
//            StartLazyLoad();
//            Invalidate();
//        }

//        public void SetLoadingDone()
//        {
//            _isLoading = false;
//            Invalidate();
//        }

//        public void SelectCard(ItemCard card)
//        {
//            var idx = _items.IndexOf(card);
//            if (idx >= 0)
//            {
//                _selectedIdx = idx;
//                ScrollToCard(idx);
//                Invalidate();
//            }
//        }

//        public void RefreshCard(ItemCard card)
//        {
//            ImageCache.Evict(card.ImagePath);
//            _loadingPaths.Remove(card.ImagePath);
//            StartLazyLoad();
//            Invalidate();
//        }

//        // ── حساب الأبعاد ──────────────────────────────────────────────────────
//        private void Recalculate()
//        {
//            _cols = Math.Max(1, (Width - MARGIN) / (CARD_W + MARGIN));
//            int rows = (_items.Count + _cols - 1) / _cols;
//            _totalHeight = rows * (CARD_H + MARGIN) + MARGIN;
//            AutoScrollMinSize = new Size(0, _totalHeight);
//            Invalidate();
//        }

//        private void ScrollToCard(int idx)
//        {
//            int row = idx / Math.Max(1, _cols);
//            int y = row * (CARD_H + MARGIN) + MARGIN;
//            _scrollOffset = Math.Max(0, Math.Min(y - Height / 3, _totalHeight - Height));
//            AutoScrollPosition = new Point(0, _scrollOffset);
//        }

//        // ── Lazy Image Load ────────────────────────────────────────────────────
//        private void StartLazyLoad()
//        {
//            _lazyCts?.Cancel();
//            _lazyCts = new CancellationTokenSource();
//            var token = _lazyCts.Token;
//            var visible = GetVisibleRange();

//            // تحميل الصور المرئية أولاً ثم المجاورة
//            var toLoad = _items
//                .Skip(Math.Max(0, visible.from - _cols * 2))
//                .Take(visible.count + _cols * 4)
//                .Where(c => !string.IsNullOrEmpty(c.ImagePath)
//                         && File.Exists(c.ImagePath)
//                         && !ImageCache.TryGet(c.ImagePath, out _)
//                         && !_loadingPaths.Contains(c.ImagePath))
//                .Select(c => c.ImagePath)
//                .ToList();

//            foreach (var path in toLoad)
//            {
//                _loadingPaths.Add(path);
//                var p = path;
//                Task.Run(() =>
//                {
//                    if (token.IsCancellationRequested) return;
//                    var img = LoadAndCompress(p, THUMB_W, THUMB_H);
//                    if (img != null)
//                        ImageCache.Set(p, img);
//                    _loadingPaths.Remove(p);

//                    if (!token.IsCancellationRequested && !IsDisposed)
//                        BeginInvoke(new Action(Invalidate));
//                }, token);
//            }
//        }

//        /// <summary>تحميل وضغط الصورة مع Cover Fit — يعمل في Thread خلفي</summary>
//        public static Image LoadAndCompress(string path, int tw, int th)
//        {
//            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
//            try
//            {
//                using (var src = Image.FromFile(path))
//                {
//                    float r = Math.Max((float)tw / src.Width, (float)th / src.Height);
//                    int nw = (int)(src.Width * r);
//                    int nh = (int)(src.Height * r);
//                    var bmp = new Bitmap(tw, th, PixelFormat.Format32bppArgb);
//                    using (var g = Graphics.FromImage(bmp))
//                    {
//                        g.CompositingQuality = CompositingQuality.HighSpeed;
//                        g.InterpolationMode = InterpolationMode.Bilinear;
//                        g.SmoothingMode = SmoothingMode.HighSpeed;
//                        g.DrawImage(src, (tw - nw) / 2, (th - nh) / 2, nw, nh);
//                    }
//                    return bmp;
//                }
//            }
//            catch { return null; }
//        }

//        // ── حساب النطاق المرئي ────────────────────────────────────────────────
//        private (int from, int count) GetVisibleRange()
//        {
//            int scroll = -AutoScrollPosition.Y;
//            int cols = Math.Max(1, _cols);
//            int from = Math.Max(0, (scroll / (CARD_H + MARGIN)) * cols);
//            int rows = (Height / (CARD_H + MARGIN)) + 2;
//            int count = Math.Min(_items.Count - from, rows * cols);
//            return (from, Math.Max(0, count));
//        }

//        // ── رسم البطاقات (Virtual) ────────────────────────────────────────────
//        protected override void OnPaint(PaintEventArgs e)
//        {
//            var g = e.Graphics;
//            g.SmoothingMode = SmoothingMode.AntiAlias;
//            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
//            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
//            g.Clear(C_BG);

//            if (_isLoading)
//            {
//                DrawSkeletons(g);
//                return;
//            }

//            if (_items.Count == 0)
//            {
//                DrawEmpty(g);
//                return;
//            }

//            int scroll = -AutoScrollPosition.Y;
//            var (from, count) = GetVisibleRange();

//            for (int i = from; i < from + count && i < _items.Count; i++)
//            {
//                int col = i % Math.Max(1, _cols);
//                int row = i / Math.Max(1, _cols);

//                int x = MARGIN + col * (CARD_W + MARGIN);
//                int y = MARGIN + row * (CARD_H + MARGIN) - scroll;

//                if (y + CARD_H < 0 || y > Height) continue;

//                DrawCard(g, _items[i], x, y, i == _selectedIdx, i == _hoverIdx);
//            }
//        }

//        // ── رسم بطاقة واحدة ───────────────────────────────────────────────────
//        private void DrawCard(Graphics g, ItemCard card, int x, int y,
//                              bool selected, bool hover)
//        {
//            var rc = new Rectangle(x + 2, y + 2, CARD_W - 4, CARD_H - 4);

//            // ── ظل (Shadow Effect) ────────────────────────────────────────────
//            if (selected || hover)
//            {
//                using (var shd = new SolidBrush(Color.FromArgb(20, 26, 115, 232)))
//                    FillRR(g, shd, new Rectangle(rc.X + 3, rc.Y + 4, rc.Width, rc.Height), RAD);
//            }

//            // ── خلفية ─────────────────────────────────────────────────────────
//            var bg = selected ? C_CARD_S : (hover ? C_CARD_H : C_CARD);
//            FillRR(g, new SolidBrush(bg), rc, RAD);

//            // ── حدود ──────────────────────────────────────────────────────────
//            if (selected)
//            {
//                DrawRR(g, new Pen(Color.FromArgb(100, 160, 230), 5f), rc, RAD);
//                DrawRR(g, new Pen(C_BDR_S, 2f), rc, RAD);
//            }
//            else
//                DrawRR(g, new Pen(hover ? C_BDR_H : C_BDR, 1f), rc, RAD);

//            // ── صورة ──────────────────────────────────────────────────────────
//            var imgRc = new Rectangle(rc.X + 8, rc.Y + 8, rc.Width - 16, IMG_H);
//            DrawImage(g, card, imgRc, hover);

//            // ── الاسم ─────────────────────────────────────────────────────────
//            var nameRc = new RectangleF(rc.X + 5, rc.Y + IMG_H + 12, rc.Width - 10, 36);
//            using (var f = new Font("Cairo", 8.5f, FontStyle.Bold))
//            using (var sf = new StringFormat
//            {
//                Alignment = StringAlignment.Center,
//                Trimming = StringTrimming.EllipsisWord,
//                FormatFlags = StringFormatFlags.LineLimit
//            })
//                g.DrawString(card.NameAR, f, new SolidBrush(C_TXT), nameRc, sf);

//            // ── الكود ─────────────────────────────────────────────────────────
//            if (!string.IsNullOrEmpty(card.Code))
//            {
//                var codeRc = new RectangleF(rc.X + 5, nameRc.Bottom + 2, rc.Width - 10, 16);
//                using (var f = new Font("Consolas", 7f))
//                using (var sf = new StringFormat { Alignment = StringAlignment.Center })
//                    g.DrawString(card.Code, f, new SolidBrush(C_CODE), codeRc, sf);
//            }

//            // ── علامة التحديد ✔ ───────────────────────────────────────────────
//            if (selected)
//            {
//                var ck = new Rectangle(rc.Right - 22, rc.Y + 6, 17, 17);
//                FillRR(g, new SolidBrush(C_BDR_S), ck, 9);
//                using (var f = new Font("Arial", 8f, FontStyle.Bold))
//                using (var sf = new StringFormat
//                {
//                    Alignment = StringAlignment.Center,
//                    LineAlignment = StringAlignment.Center
//                })
//                    g.DrawString("✔", f, Brushes.White, ck, sf);
//            }
//        }

//        private void DrawImage(Graphics g, ItemCard card, Rectangle imgRc, bool hover)
//        {
//            using (var clip = RRect(imgRc, 7))
//            {
//                g.SetClip(clip);

//                bool hasImg = !string.IsNullOrEmpty(card.ImagePath);
//                Image thumb = null;
//                if (hasImg) ImageCache.TryGet(card.ImagePath, out thumb);

//                if (thumb != null)
//                {
//                    g.DrawImage(thumb, imgRc);
//                }
//                else if (hasImg && _loadingPaths.Contains(card.ImagePath))
//                {
//                    // Skeleton shimmer أثناء تحميل الصورة
//                    DrawShimmer(g, imgRc);
//                }
//                else
//                {
//                    // Placeholder
//                    g.FillPath(new SolidBrush(C_IMG_BG), clip);
//                    using (var f = new Font("Segoe UI Emoji", 22f))
//                    using (var sf = new StringFormat
//                    {
//                        Alignment = StringAlignment.Center,
//                        LineAlignment = StringAlignment.Center
//                    })
//                        g.DrawString("📷", f, new SolidBrush(C_CAM), imgRc, sf);

//                    if (hover)
//                    {
//                        var hint = new RectangleF(imgRc.X, imgRc.Bottom - 22, imgRc.Width, 20);
//                        g.FillRectangle(new SolidBrush(Color.FromArgb(175, 26, 115, 232)), hint);
//                        using (var f = new Font("Cairo", 7f, FontStyle.Bold))
//                        using (var sf = new StringFormat
//                        {
//                            Alignment = StringAlignment.Center,
//                            LineAlignment = StringAlignment.Center
//                        })
//                            g.DrawString("كليك يمين ← إضافة صورة", f, Brushes.White, hint, sf);
//                    }
//                }

//                g.ResetClip();
//            }
//            // إطار الصورة
//            DrawRR(g, new Pen(Color.FromArgb(18, 0, 0, 0), 1f), imgRc, 7);
//        }

//        // ── Skeleton Loading ──────────────────────────────────────────────────
//        private void DrawSkeletons(Graphics g)
//        {
//            int visibleCols = Math.Max(1, (Width - MARGIN) / (CARD_W + MARGIN));
//            int visibleRows = Math.Max(1, (Height - MARGIN) / (CARD_H + MARGIN)) + 1;

//            for (int row = 0; row < visibleRows; row++)
//                for (int col = 0; col < visibleCols; col++)
//                {
//                    int x = MARGIN + col * (CARD_W + MARGIN);
//                    int y = MARGIN + row * (CARD_H + MARGIN);
//                    var rc = new Rectangle(x + 2, y + 2, CARD_W - 4, CARD_H - 4);

//                    FillRR(g, new SolidBrush(Color.White), rc, RAD);
//                    DrawRR(g, new Pen(C_BDR, 1f), rc, RAD);
//                    DrawShimmer(g, new Rectangle(rc.X + 8, rc.Y + 8, rc.Width - 16, IMG_H));

//                    // خطوط النص skeleton
//                    DrawSkeletonLine(g, rc.X + 20, rc.Y + IMG_H + 14, rc.Width - 40, 12);
//                    DrawSkeletonLine(g, rc.X + 40, rc.Y + IMG_H + 32, rc.Width - 80, 8);
//                }
//        }

//        private void DrawShimmer(Graphics g, Rectangle rc)
//        {
//            float p = (float)((Math.Sin(_skelPhase) + 1) / 2.0);
//            var c = Color.FromArgb(
//                (int)(C_SKEL1.R + (C_SKEL2.R - C_SKEL1.R) * p),
//                (int)(C_SKEL1.G + (C_SKEL2.G - C_SKEL1.G) * p),
//                (int)(C_SKEL1.B + (C_SKEL2.B - C_SKEL1.B) * p));
//            g.FillRectangle(new SolidBrush(c), rc);

//            // خط shimmer متحرك
//            int shimX = rc.X + (int)((rc.Width + 100) * ((float)(Math.Sin(_skelPhase * 0.5f) + 1) / 2.0)) - 50;
//            using (var brush = new LinearGradientBrush(
//                new Rectangle(shimX, rc.Y, 60, rc.Height),
//                Color.FromArgb(0, 255, 255, 255),
//                Color.FromArgb(80, 255, 255, 255),
//                LinearGradientMode.Horizontal))
//                g.FillRectangle(brush, shimX, rc.Y, 60, rc.Height);
//        }

//        private void DrawSkeletonLine(Graphics g, int x, int y, int w, int h)
//        {
//            float p = (float)((Math.Sin(_skelPhase) + 1) / 2.0);
//            var c = Color.FromArgb(
//                (int)(C_SKEL1.R + (C_SKEL2.R - C_SKEL1.R) * p),
//                (int)(C_SKEL1.G + (C_SKEL2.G - C_SKEL1.G) * p),
//                (int)(C_SKEL1.B + (C_SKEL2.B - C_SKEL1.B) * p));
//            FillRR(g, new SolidBrush(c), new Rectangle(x, y, w, h), h / 2);
//        }

//        private void DrawEmpty(Graphics g)
//        {
//            using (var f = new Font("Cairo", 14f, FontStyle.Bold))
//            using (var sf = new StringFormat
//            {
//                Alignment = StringAlignment.Center,
//                LineAlignment = StringAlignment.Center
//            })
//                g.DrawString("لا توجد نتائج 🔍", f,
//                    new SolidBrush(Color.FromArgb(180, 190, 210)),
//                    ClientRectangle, sf);
//        }

//        // ── Mouse Events ──────────────────────────────────────────────────────
//        private void OnMouseMove(object sender, MouseEventArgs e)
//        {
//            _lastMousePos = e.Location;
//            var card = GetCardAt(e.Location);
//            int idx = card != null ? _items.IndexOf(card) : -1;
//            if (idx != _hoverIdx) { _hoverIdx = idx; Invalidate(); }
//        }

//        private void OnMouseClick(object sender, MouseEventArgs e)
//        {
//            if (e.Button != MouseButtons.Left) return;
//            var card = GetCardAt(e.Location);
//            if (card == null) return;
//            _selectedIdx = _items.IndexOf(card);
//            Invalidate();
//            CardClicked?.Invoke(card);
//        }

//        private void OnMouseWheel(object sender, MouseEventArgs e)
//        {
//            // Smooth scroll
//            int delta = e.Delta > 0 ? -60 : 60;
//            var pos = AutoScrollPosition;
//            AutoScrollPosition = new Point(0, Math.Max(0, -pos.Y + delta));
//            StartLazyLoad();   // تحميل الصور الجديدة بعد الـ scroll
//        }

//        private ItemCard GetCardAt(Point pt)
//        {
//            int scroll = -AutoScrollPosition.Y;
//            for (int i = 0; i < _items.Count; i++)
//            {
//                int col = i % Math.Max(1, _cols);
//                int row = i / Math.Max(1, _cols);
//                int x = MARGIN + col * (CARD_W + MARGIN);
//                int y = MARGIN + row * (CARD_H + MARGIN) - scroll;
//                if (new Rectangle(x, y, CARD_W, CARD_H).Contains(pt))
//                    return _items[i];
//            }
//            return null;
//        }

//        // ── مساعدات الرسم ─────────────────────────────────────────────────────
//        private static GraphicsPath RRect(Rectangle r, int rad)
//        {
//            int d = rad * 2;
//            var p = new GraphicsPath();
//            p.AddArc(r.X, r.Y, d, d, 180, 90);
//            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
//            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
//            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
//            p.CloseFigure();
//            return p;
//        }

//        private static void FillRR(Graphics g, Brush b, Rectangle r, int rad)
//        { using (var p = RRect(r, rad)) g.FillPath(b, p); }

//        private static void DrawRR(Graphics g, Pen pen, Rectangle r, int rad)
//        { using (var p = RRect(r, rad)) g.DrawPath(pen, p); }

//        // ── تنظيف ─────────────────────────────────────────────────────────────
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                _lazyCts?.Cancel();
//                _skelTimer?.Stop();
//                _skelTimer?.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        // ── Override scroll لمنع الـ Flicker ─────────────────────────────────
//        protected override void OnScroll(ScrollEventArgs se)
//        {
//            base.OnScroll(se);
//            StartLazyLoad();
//            Invalidate();
//        }
//    }

//    // =========================================================================
//    //  الفورم الرئيسي
//    // =========================================================================
//    public class FRM_ImagePicker : Form
//    {
//        // ── خصائص النتيجة ─────────────────────────────────────────────────────
//        public int IN_OUT_STOCK = 0;
//        public int IDValue { get; private set; }
//        public string NameValue { get; private set; }
//        public decimal numberValue { get; private set; }
//        public string gatgoryValue { get; private set; }
//        public string formmValue { get; private set; }

//        // ── ألوان ─────────────────────────────────────────────────────────────
//        private static readonly Color C_BG = Color.FromArgb(240, 244, 250);
//        private static readonly Color C_DARK = Color.FromArgb(18, 28, 50);
//        private static readonly Color C_BLUE = Color.FromArgb(26, 115, 232);
//        private static readonly Color C_GREEN = Color.FromArgb(34, 154, 60);
//        private static readonly Color C_RED = Color.FromArgb(210, 48, 65);
//        private static readonly Color C_WHITE = Color.White;
//        private static readonly Color C_SEP = Color.FromArgb(215, 222, 235);
//        private static readonly Color C_HDR = Color.FromArgb(228, 236, 252);

//        // ── كونترولات ─────────────────────────────────────────────────────────
//        private Panel pnlTop, pnlSearch, pnlMain, pnlDetail, pnlBottom;
//        private VirtualCardPanel virtualPanel;
//        private Label lblTitle, lblCount, lblLoading, lblSelected;
//        private TextBox txtSearch, txtQty;
//        private ComboBox cmbCat;
//        private PictureBox picDetail;
//        private Label lblDName, lblDCode, lblDCat, lblDForm, lblDStock;
//        private RichTextBox rtbNotes;
//        private Button btnAdd, btnClose;
//        private ProgressBar progressBar;
//        private BackgroundWorker bgw;

//        // ── بيانات ────────────────────────────────────────────────────────────
//        private List<ItemCard> _all = new List<ItemCard>();
//        private ItemCard _selected;

//        // ── Debounce للبحث ────────────────────────────────────────────────────
//        private System.Windows.Forms.Timer _searchTimer;

//        // ─────────────────────────────────────────────────────────────────────
//        public FRM_ImagePicker()
//        {
//            ImageStore.EnsureFolder();
//            BuildUI();
//            InitWorker();
//        }

//        // =========================================================================
//        //  بناء الواجهة
//        // =========================================================================
//        private void BuildUI()
//        {
//            Text = "اختيار المواد بالصور  —  مهندس رامي";
//            Size = new Size(1200, 740);
//            MinimumSize = new Size(980, 600);
//            StartPosition = FormStartPosition.CenterScreen;
//            BackColor = C_BG;
//            Font = new Font("Cairo", 10f);
//            RightToLeft = RightToLeft.Yes;
//            RightToLeftLayout = true;
//            FormBorderStyle = FormBorderStyle.Sizable;

//            // Debounce timer للبحث
//            _searchTimer = new System.Windows.Forms.Timer { Interval = 200 };
//            _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); ApplyFilter(); };

//            BuildHeader();
//            BuildSearchBar();
//            BuildMainArea();
//            BuildBottomBar();

//            Controls.Add(pnlMain);
//            Controls.Add(pnlBottom);
//            Controls.Add(pnlSearch);
//            Controls.Add(pnlTop);

//            Load += (s, e) =>
//            {
//                lblLoading.Visible = true;
//                progressBar.Visible = true;
//                virtualPanel.SetItems(new List<ItemCard>(), isLoading: true);
//                bgw.RunWorkerAsync();
//            };
//        }

//        // ── Header ────────────────────────────────────────────────────────────
//        private void BuildHeader()
//        {
//            pnlTop = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = C_DARK };
//            pnlTop.Controls.Add(new Label
//            {
//                Text = "🖼️   اختيار المواد بالصور",
//                ForeColor = Color.White,
//                Font = new Font("Cairo", 14f, FontStyle.Bold),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter
//            });
//        }

//        // ── Search Bar ────────────────────────────────────────────────────────
//        private void BuildSearchBar()
//        {
//            pnlSearch = new Panel
//            {
//                Dock = DockStyle.Top,
//                Height = 50,
//                BackColor = C_WHITE
//            };
//            pnlSearch.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, pnlSearch.Height - 1, pnlSearch.Width, pnlSearch.Height - 1);

//            var tbl = new TableLayoutPanel
//            {
//                Dock = DockStyle.Fill,
//                ColumnCount = 5,
//                RowCount = 1,
//                BackColor = C_WHITE,
//                Padding = new Padding(10, 0, 10, 0)
//            };
//            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28f));

//            tbl.Controls.Add(new Label
//            {
//                Text = "🔍",
//                Font = new Font("Segoe UI Emoji", 13f),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            }, 0, 0);

//            txtSearch = new TextBox
//            {
//                Font = new Font("Cairo", 10.5f),
//                BorderStyle = BorderStyle.FixedSingle,
//                Anchor = AnchorStyles.Left | AnchorStyles.Right,
//                Height = 28,
//                Margin = new Padding(2, 11, 2, 11)
//            };
//            // Debounced search
//            txtSearch.TextChanged += (s, e) => { _searchTimer.Stop(); _searchTimer.Start(); };
//            tbl.Controls.Add(txtSearch, 1, 0);

//            tbl.Controls.Add(new Label
//            {
//                Text = "الصنف:",
//                Font = new Font("Cairo", 10f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(70, 85, 115),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            }, 2, 0);

//            cmbCat = new ComboBox
//            {
//                Font = new Font("Cairo", 9.5f),
//                DropDownStyle = ComboBoxStyle.DropDownList,
//                Anchor = AnchorStyles.Left | AnchorStyles.Right,
//                Height = 28,
//                Margin = new Padding(2, 11, 2, 11)
//            };
//            cmbCat.Items.Add("جميع الأصناف");
//            cmbCat.SelectedIndex = 0;
//            cmbCat.SelectedIndexChanged += (s, e) => ApplyFilter();
//            tbl.Controls.Add(cmbCat, 3, 0);

//            var pnlRight = new Panel { Dock = DockStyle.Fill, BackColor = C_WHITE, Margin = Padding.Empty };

//            lblCount = new Label
//            {
//                Text = "",
//                Font = new Font("Cairo", 10f, FontStyle.Bold),
//                ForeColor = C_BLUE,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            };
//            lblLoading = new Label
//            {
//                Text = "⏳  جاري التحميل...",
//                Font = new Font("Cairo", 9.5f, FontStyle.Bold),
//                ForeColor = C_BLUE,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Visible = false,
//                Margin = Padding.Empty
//            };
//            pnlRight.Controls.Add(lblCount);
//            pnlRight.Controls.Add(lblLoading);
//            tbl.Controls.Add(pnlRight, 4, 0);

//            progressBar = new ProgressBar
//            {
//                Style = ProgressBarStyle.Marquee,
//                Height = 3,
//                Dock = DockStyle.Bottom,
//                Visible = false
//            };

//            pnlSearch.Controls.Add(tbl);
//            pnlSearch.Controls.Add(progressBar);
//        }

//        // ── Main Area ─────────────────────────────────────────────────────────
//        private void BuildMainArea()
//        {
//            pnlMain = new Panel { Dock = DockStyle.Fill, BackColor = C_BG };

//            // لوحة التفاصيل — يمين
//            pnlDetail = new Panel
//            {
//                Dock = DockStyle.Right,
//                Width = 300,
//                BackColor = C_WHITE
//            };
//            pnlDetail.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, 0, 0, pnlDetail.Height);

//            BuildDetailPanel();

//            // Virtual Card Panel
//            virtualPanel = new VirtualCardPanel { Dock = DockStyle.Fill };
//            virtualPanel.CardClicked += OnCardClick;
//            virtualPanel.ImgChangeReq += OnImgChange;
//            virtualPanel.ImgDeleteReq += OnImgDelete;

//            pnlMain.Controls.Add(virtualPanel);  // Fill أولاً
//            pnlMain.Controls.Add(pnlDetail);     // Right ثانياً
//        }

//        // ── Detail Panel ──────────────────────────────────────────────────────
//        private void BuildDetailPanel()
//        {
//            var hdr = new Panel { Dock = DockStyle.Top, Height = 38, BackColor = C_HDR };
//            hdr.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, hdr.Height - 1, hdr.Width, hdr.Height - 1);
//            hdr.Controls.Add(new Label
//            {
//                Text = "📋   تفاصيل المادة",
//                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
//                ForeColor = C_DARK,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter
//            });
//            pnlDetail.Controls.Add(hdr);

//            var tbl = new TableLayoutPanel
//            {
//                Dock = DockStyle.Fill,
//                ColumnCount = 1,
//                RowCount = 6,
//                BackColor = C_WHITE,
//                Padding = new Padding(10, 8, 10, 8)
//            };
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 172f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 38f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 2f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 120f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

//            picDetail = new PictureBox
//            {
//                Dock = DockStyle.Fill,
//                SizeMode = PictureBoxSizeMode.Zoom,
//                BackColor = Color.FromArgb(230, 234, 247),
//                BorderStyle = BorderStyle.FixedSingle,
//                Margin = new Padding(0, 0, 0, 6)
//            };
//            tbl.Controls.Add(picDetail, 0, 0);

//            lblDName = new Label
//            {
//                Text = "اختر مادة من القائمة",
//                Font = new Font("Cairo", 11.5f, FontStyle.Bold),
//                ForeColor = C_DARK,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            };
//            tbl.Controls.Add(lblDName, 0, 1);

//            tbl.Controls.Add(
//                new Panel { Dock = DockStyle.Fill, BackColor = C_SEP, Margin = new Padding(0, 2, 0, 4) }
//                , 0, 2);

//            var pnlInfo = new Panel { Dock = DockStyle.Fill, BackColor = C_WHITE, Margin = Padding.Empty };
//            int iy = 0;
//            MkRow(pnlInfo, ref iy, "الكود:", out lblDCode);
//            MkRow(pnlInfo, ref iy, "الصنف:", out lblDCat);
//            MkRow(pnlInfo, ref iy, "التجزئة:", out lblDForm);
//            // مخزون مميّز
//            var pnlStk = new Panel
//            {
//                Left = 0,
//                Top = iy,
//                Height = 27,
//                BackColor = Color.FromArgb(240, 246, 255),
//                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
//            };
//            pnlStk.Resize += (s, e) => pnlStk.Width = pnlInfo.Width;
//            pnlInfo.Resize += (s, e) => pnlStk.Width = pnlInfo.Width;
//            pnlStk.Controls.Add(new Label
//            {
//                Text = "المخزون:",
//                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(85, 100, 135),
//                Left = 0,
//                Top = 0,
//                Width = 72,
//                Height = 27,
//                TextAlign = ContentAlignment.MiddleRight
//            });
//            lblDStock = new Label
//            {
//                Text = "—",
//                Font = new Font("Cairo", 9.5f, FontStyle.Bold),
//                ForeColor = C_DARK,
//                Left = 76,
//                Top = 0,
//                Width = 200,
//                Height = 27,
//                TextAlign = ContentAlignment.MiddleLeft
//            };
//            pnlStk.Controls.Add(lblDStock);
//            pnlInfo.Controls.Add(pnlStk);
//            tbl.Controls.Add(pnlInfo, 0, 3);

//            tbl.Controls.Add(new Label
//            {
//                Text = "ملاحظات:",
//                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(120, 130, 155),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.BottomRight,
//                Margin = new Padding(0, 4, 0, 0)
//            }, 0, 4);

//            rtbNotes = new RichTextBox
//            {
//                Dock = DockStyle.Fill,
//                ReadOnly = true,
//                BackColor = Color.FromArgb(246, 249, 254),
//                Font = new Font("Cairo", 8.5f),
//                BorderStyle = BorderStyle.FixedSingle,
//                ScrollBars = RichTextBoxScrollBars.Vertical,
//                Margin = new Padding(0, 0, 0, 4)
//            };
//            tbl.Controls.Add(rtbNotes, 0, 5);

//            pnlDetail.Controls.Add(tbl);
//            ResetDetail();
//        }

//        private void MkRow(Panel p, ref int y, string lbl, out Label val)
//        {
//            const int H = 26;
//            p.Controls.Add(new Label
//            {
//                Text = lbl,
//                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(105, 118, 148),
//                Left = 0,
//                Top = y,
//                Width = 72,
//                Height = H,
//                TextAlign = ContentAlignment.MiddleRight
//            });
//            val = new Label
//            {
//                Text = "—",
//                Font = new Font("Cairo", 9f),
//                ForeColor = C_DARK,
//                Left = 76,
//                Top = y,
//                Width = 200,
//                Height = H,
//                TextAlign = ContentAlignment.MiddleLeft
//            };
//            p.Controls.Add(val);
//            y += H + 2;
//        }

//        // ── Bottom Bar ────────────────────────────────────────────────────────
//        private void BuildBottomBar()
//        {
//            pnlBottom = new Panel
//            {
//                Dock = DockStyle.Bottom,
//                Height = 60,
//                BackColor = C_WHITE
//            };
//            pnlBottom.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, 0, pnlBottom.Width, 0);

//            var tbl = new TableLayoutPanel
//            {
//                Dock = DockStyle.Fill,
//                ColumnCount = 5,
//                RowCount = 1,
//                BackColor = C_WHITE,
//                Padding = new Padding(12, 0, 12, 0)
//            };
//            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115f));

//            lblSelected = new Label
//            {
//                Text = "لم يتم اختيار مادة",
//                ForeColor = Color.FromArgb(160, 168, 185),
//                Font = new Font("Cairo", 9.5f, FontStyle.Italic),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleRight,
//                Margin = Padding.Empty
//            };
//            tbl.Controls.Add(lblSelected, 0, 0);

//            tbl.Controls.Add(new Label
//            {
//                Text = "الكمية:",
//                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
//                ForeColor = C_BLUE,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            }, 1, 0);

//            txtQty = new TextBox
//            {
//                Text = "1",
//                Font = new Font("Cairo", 13f, FontStyle.Bold),
//                TextAlign = HorizontalAlignment.Center,
//                BorderStyle = BorderStyle.FixedSingle,
//                Anchor = AnchorStyles.Left | AnchorStyles.Right,
//                Height = 34,
//                Margin = new Padding(3, 13, 3, 13)
//            };
//            txtQty.Click += (s, e) => txtQty.SelectAll();
//            txtQty.KeyPress += ValidateQty;
//            txtQty.KeyDown += (s, e) =>
//            {
//                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnAdd_Click(null, null); }
//            };
//            tbl.Controls.Add(txtQty, 2, 0);

//            btnAdd = MkBtn("✔  إضافة المادة", C_GREEN, new Padding(6, 12, 6, 12));
//            btnClose = MkBtn("✖  إغلاق", C_RED, new Padding(4, 12, 4, 12));
//            btnAdd.Click += BtnAdd_Click;
//            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

//            tbl.Controls.Add(btnAdd, 3, 0);
//            tbl.Controls.Add(btnClose, 4, 0);
//            pnlBottom.Controls.Add(tbl);
//        }

//        private Button MkBtn(string text, Color bg, Padding margin)
//        {
//            var b = new Button
//            {
//                Text = text,
//                BackColor = bg,
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
//                Cursor = Cursors.Hand,
//                Dock = DockStyle.Fill,
//                Margin = margin
//            };
//            b.FlatAppearance.BorderSize = 0;
//            return b;
//        }

//        // =========================================================================
//        //  BackgroundWorker
//        // =========================================================================
//        private void InitWorker()
//        {
//            bgw = new BackgroundWorker();
//            bgw.DoWork += Bgw_DoWork;
//            bgw.RunWorkerCompleted += Bgw_Done;
//        }

//        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
//        {
//            var list = new List<ItemCard>();
//            try
//            {
//                using (var db = new AlibaRamyEntities())
//                {
//                    var groups = db.TB_groups
//                        .ToDictionary(g => g.groups_id, g => g.groups_name ?? "");

//                    foreach (var it in db.TB_items.ToList())
//                    {
//                        // ★ فقط المواد ذات الاسم العربي
//                        if (string.IsNullOrWhiteSpace(it.items_name)) continue;

//                        string cat = it.groups_id.HasValue &&
//                                     groups.ContainsKey(it.groups_id.Value)
//                                     ? groups[it.groups_id.Value] : "";

//                        list.Add(new ItemCard
//                        {
//                            ID = it.items_id,
//                            NameAR = it.items_name.Trim(),
//                            Code = it.items_code ?? "",
//                            Category = cat,
//                            Form = it.items_form ?? "",
//                            Notes = it.items_nots ?? "",
//                            ImagePath = ImageStore.Find(it.items_id) ?? "",
//                            Stock = -1m
//                        });
//                    }
//                }
//            }
//            catch (Exception ex) { e.Result = ex; return; }
//            e.Result = list;
//        }

//        private void Bgw_Done(object sender, RunWorkerCompletedEventArgs e)
//        {
//            progressBar.Visible = false;
//            lblLoading.Visible = false;
//            lblCount.Visible = true;

//            if (e.Result is Exception ex)
//            {
//                MessageBox.Show("خطأ في تحميل البيانات:\n" + ex.Message,
//                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            _all = e.Result as List<ItemCard> ?? new List<ItemCard>();

//            cmbCat.Items.Clear();
//            cmbCat.Items.Add("جميع الأصناف");
//            foreach (var c in _all.Select(x => x.Category)
//                .Where(x => !string.IsNullOrEmpty(x))
//                .Distinct().OrderBy(x => x))
//                cmbCat.Items.Add(c);
//            cmbCat.SelectedIndex = 0;

//            virtualPanel.SetLoadingDone();
//            ShowCards(_all);
//        }

//        // =========================================================================
//        //  عرض البطاقات
//        // =========================================================================
//        private void ShowCards(List<ItemCard> items)
//        {
//            virtualPanel.SetItems(items);
//            lblCount.Text = $"({items.Count} مادة)";
//        }

//        private void ApplyFilter()
//        {
//            if (_all.Count == 0) return;
//            var q = txtSearch.Text.Trim().ToLower();
//            var cat = cmbCat.SelectedItem?.ToString() ?? "جميع الأصناف";
//            var res = _all.Where(x =>
//                (string.IsNullOrEmpty(q) ||
//                 x.NameAR.ToLower().Contains(q) ||
//                 x.Code.ToLower().Contains(q)) &&
//                (cat == "جميع الأصناف" || x.Category == cat)
//            ).ToList();
//            ShowCards(res);
//        }

//        // =========================================================================
//        //  اختيار بطاقة
//        // =========================================================================
//        private void OnCardClick(ItemCard data)
//        {
//            _selected = data;
//            lblSelected.Text = $"✔  {data.NameAR}";
//            lblSelected.ForeColor = C_BLUE;
//            ShowDetail(data);
//            txtQty.Text = "1";
//            txtQty.Focus();
//            txtQty.SelectAll();
//        }

//        // =========================================================================
//        //  إدارة الصور
//        // =========================================================================
//        private void OnImgChange(ItemCard data, VirtualCardPanel panel)
//        {
//            using (var dlg = new OpenFileDialog())
//            {
//                dlg.Title = $"اختر صورة للمادة: {data.NameAR}";
//                dlg.Filter = "صور|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";
//                if (dlg.ShowDialog() != DialogResult.OK) return;
//                try
//                {
//                    var newPath = ImageStore.Save(data.ID, dlg.FileName);
//                    data.ImagePath = newPath;
//                    panel.RefreshCard(data);
//                    if (_selected?.ID == data.ID)
//                        picDetail.Image = LoadForDetail(newPath);

//                    MessageBox.Show($"✔  تم حفظ صورة المادة:\n{data.NameAR}",
//                        "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("خطأ:\n" + ex.Message,
//                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        private void OnImgDelete(ItemCard data, VirtualCardPanel panel)
//        {
//            if (string.IsNullOrEmpty(data.ImagePath))
//            {
//                MessageBox.Show("لا توجد صورة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }
//            if (MessageBox.Show($"حذف صورة:\n{data.NameAR}؟",
//                    "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
//            try
//            {
//                VirtualCardPanel.ImageCache.Evict(data.ImagePath);
//                ImageStore.Delete(data.ID);
//                data.ImagePath = "";
//                panel.RefreshCard(data);
//                if (_selected?.ID == data.ID) picDetail.Image = null;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("خطأ:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // =========================================================================
//        //  التفاصيل
//        // =========================================================================
//        private void ShowDetail(ItemCard d)
//        {
//            picDetail.Image = LoadForDetail(d.ImagePath);
//            lblDName.Text = d.NameAR;
//            lblDCode.Text = D(d.Code);
//            lblDCat.Text = D(d.Category);
//            lblDForm.Text = D(d.Form);
//            rtbNotes.Text = d.Notes;
//            if (!d.StockLoaded)
//            {
//                lblDStock.Text = "سيُتحقق عند الإضافة";
//                lblDStock.ForeColor = Color.FromArgb(148, 158, 178);
//            }
//            else
//            {
//                lblDStock.Text = d.Stock > 0 ? $"{d.Stock:N2}  ✔" : "نفذ المخزون  ✖";
//                lblDStock.ForeColor = d.Stock > 0 ? C_GREEN : C_RED;
//            }
//        }

//        private void ResetDetail()
//        {
//            if (picDetail != null) picDetail.Image = null;
//            if (lblDName != null) lblDName.Text = "اختر مادة من القائمة";
//            if (lblDCode != null) lblDCode.Text = "—";
//            if (lblDCat != null) lblDCat.Text = "—";
//            if (lblDForm != null) lblDForm.Text = "—";
//            if (lblDStock != null) { lblDStock.Text = "—"; lblDStock.ForeColor = Color.Gray; }
//            if (rtbNotes != null) rtbNotes.Text = "";
//        }

//        private static string D(string v) => string.IsNullOrEmpty(v) ? "—" : v;

//        private static Image LoadForDetail(string path)
//        {
//            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
//            try { return Image.FromFile(path); } catch { return null; }
//        }

//        // =========================================================================
//        //  جلب المخزون عند "إضافة" فقط
//        // =========================================================================
//        private decimal FetchStock(ItemCard card)
//        {
//            if (card.StockLoaded) return card.Stock;
//            decimal s = 0m;
//            try
//            {
//                using (var db = new AlibaRamyEntities())
//                    s = db.TB_str
//                        .Where(x => x.items_id == card.ID)
//                        .Sum(x => (decimal?)x.str_num + (decimal?)x.str_renum) ?? 0m;
//            }
//            catch { s = 0m; }
//            card.Stock = s;
//            return s;
//        }

//        private void BtnAdd_Click(object sender, EventArgs e)
//        {
//            if (_selected == null)
//            {
//                MessageBox.Show("الرجاء اختيار مادة أولاً.",
//                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }
//            if (!decimal.TryParse(txtQty.Text, out decimal qty) || qty <= 0)
//            {
//                MessageBox.Show("الرجاء إدخال كمية صحيحة.",
//                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtQty.Focus(); txtQty.SelectAll();
//                return;
//            }

//            // ★ جلب المخزون هنا فقط
//            FetchStock(_selected);
//            ShowDetail(_selected);

//            if ((IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11) && _selected.Stock < qty)
//            {
//                MessageBox.Show(
//                    $"الكمية ({qty:N2}) أكبر من المخزون ({_selected.Stock:N2}).",
//                    "مخزون غير كافٍ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            IDValue = _selected.ID; NameValue = _selected.NameAR;
//            numberValue = qty; gatgoryValue = _selected.Category; formmValue = _selected.Form;
//            DialogResult = DialogResult.OK;
//            Close();
//        }

//        private void ValidateQty(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
//                e.Handled = true;
//            if (e.KeyChar == '.' && txtQty.Text.Contains('.'))
//                e.Handled = true;
//        }

//        protected override void OnFormClosed(FormClosedEventArgs e)
//        {
//            _searchTimer?.Dispose();
//            VirtualCardPanel.ImageCache.Clear();
//            base.OnFormClosed(e);
//        }
//    }
//}





















////يعرض المخزن
//// ═══════════════════════════════════════════════════════════════════════════════
////  FRM_ImagePicker.cs  —  النسخة الاحترافية v7
////  ✅ عرض المخزون تحت كل بطاقة مع لون دلالي
////  ✅ جلب المخزون مسبقاً مع تحميل البيانات (لا تأخير)
////  ✅ التحقق من الكمية مقابل المخزون عند الإضافة
////  ✅ Virtual Scroll / LRU Cache / Skeleton / Lazy Load
//// ═══════════════════════════════════════════════════════════════════════════════

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using ALIBA_COMPANY.classes;

//namespace ALIBA_COMPANY.Store
//{
//    // =========================================================================
//    //  مساعد الصور المحلية
//    // =========================================================================
//    internal static class ImageStore
//    {
//        public const string RootPath = @"C:\AlibaImages";
//        private static readonly string[] Exts =
//            { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };

//        public static void EnsureFolder()
//        {
//            if (!Directory.Exists(RootPath))
//                Directory.CreateDirectory(RootPath);
//        }

//        public static string Find(int id)
//        {
//            foreach (var ext in Exts)
//            {
//                var p = Path.Combine(RootPath, id + ext);
//                if (File.Exists(p)) return p;
//            }
//            return null;
//        }

//        public static string Save(int id, string src)
//        {
//            EnsureFolder();
//            Delete(id);
//            var ext = Path.GetExtension(src).ToLower();
//            var dest = Path.Combine(RootPath, id + ext);
//            File.Copy(src, dest, true);
//            return dest;
//        }

//        public static void Delete(int id)
//        {
//            foreach (var ext in Exts)
//            {
//                var p = Path.Combine(RootPath, id + ext);
//                if (File.Exists(p)) try { File.Delete(p); } catch { }
//            }
//        }
//    }

//    // =========================================================================
//    //  LRU Image Cache
//    // =========================================================================
//    internal sealed class LruImageCache : IDisposable
//    {
//        private readonly int _cap;
//        private readonly Dictionary<string, LinkedListNode<(string k, Image v)>> _map;
//        private readonly LinkedList<(string k, Image v)> _list;
//        private readonly object _lock = new object();

//        public LruImageCache(int cap = 200)
//        {
//            _cap = cap;
//            _map = new Dictionary<string, LinkedListNode<(string, Image)>>(cap, StringComparer.OrdinalIgnoreCase);
//            _list = new LinkedList<(string, Image)>();
//        }

//        public bool TryGet(string key, out Image img)
//        {
//            lock (_lock)
//            {
//                if (_map.TryGetValue(key, out var n))
//                {
//                    _list.Remove(n);
//                    _list.AddFirst(n);
//                    img = n.Value.v;
//                    return true;
//                }
//                img = null;
//                return false;
//            }
//        }

//        public void Set(string key, Image img)
//        {
//            lock (_lock)
//            {
//                if (_map.TryGetValue(key, out var ex))
//                {
//                    ex.Value.v?.Dispose();
//                    _list.Remove(ex);
//                    _map.Remove(key);
//                }
//                while (_list.Count >= _cap)
//                {
//                    var last = _list.Last;
//                    _list.RemoveLast();
//                    _map.Remove(last.Value.k);
//                    last.Value.v?.Dispose();
//                }
//                var node = _list.AddFirst((key, img));
//                _map[key] = node;
//            }
//        }

//        public void Evict(string key)
//        {
//            if (string.IsNullOrEmpty(key)) return;
//            lock (_lock)
//            {
//                if (_map.TryGetValue(key, out var n))
//                {
//                    n.Value.v?.Dispose();
//                    _list.Remove(n);
//                    _map.Remove(key);
//                }
//            }
//        }

//        public void Clear()
//        {
//            lock (_lock)
//            {
//                foreach (var n in _list) n.v?.Dispose();
//                _list.Clear();
//                _map.Clear();
//            }
//        }

//        public void Dispose() => Clear();
//    }

//    // =========================================================================
//    //  بيانات المادة — المخزون مُحمَّل مسبقاً
//    // =========================================================================
//    internal class ItemCard
//    {
//        public int ID { get; set; }
//        public string NameAR { get; set; }
//        public string Code { get; set; }
//        public string Category { get; set; }
//        public string Form { get; set; }
//        public string Notes { get; set; }
//        public string ImagePath { get; set; }

//        /// <summary>المخزون — يُحمَّل دائماً مع البيانات الأولية</summary>
//        public decimal Stock { get; set; } = 0m;
//    }

//    // =========================================================================
//    //  Virtual Card Panel — يرسم المخزون ضمن كل بطاقة
//    // =========================================================================
//    internal sealed class VirtualCardPanel : Panel
//    {
//        // ── أبعاد البطاقة ─────────────────────────────────────────────────────
//        public const int CARD_W = 168;
//        public const int CARD_H = 215;   // أعلى بـ 15 لاستيعاب سطر المخزون
//        public const int MARGIN = 9;
//        public const int IMG_H = 112;
//        public const int THUMB_W = 150;
//        public const int THUMB_H = 112;
//        public const int RAD = 10;

//        // ── ألوان ─────────────────────────────────────────────────────────────
//        private static readonly Color C_BG = Color.FromArgb(238, 243, 250);
//        private static readonly Color C_CARD = Color.White;
//        private static readonly Color C_CARD_H = Color.FromArgb(240, 247, 255);
//        private static readonly Color C_CARD_S = Color.FromArgb(218, 236, 255);
//        private static readonly Color C_BDR = Color.FromArgb(208, 218, 232);
//        private static readonly Color C_BDR_H = Color.FromArgb(145, 192, 245);
//        private static readonly Color C_BDR_S = Color.FromArgb(26, 115, 232);
//        private static readonly Color C_TXT = Color.FromArgb(20, 30, 55);
//        private static readonly Color C_CODE = Color.FromArgb(115, 128, 155);
//        private static readonly Color C_IMG_BG = Color.FromArgb(228, 234, 248);
//        private static readonly Color C_CAM = Color.FromArgb(162, 174, 200);
//        private static readonly Color C_SKEL1 = Color.FromArgb(225, 230, 240);
//        private static readonly Color C_SKEL2 = Color.FromArgb(240, 244, 252);

//        // ── ألوان المخزون ─────────────────────────────────────────────────────
//        private static readonly Color C_STK_OK = Color.FromArgb(34, 154, 60);   // أخضر
//        private static readonly Color C_STK_LOW = Color.FromArgb(220, 140, 0);   // برتقالي
//        private static readonly Color C_STK_ZERO = Color.FromArgb(210, 48, 65);   // أحمر
//        private static readonly Color C_STK_BG_OK = Color.FromArgb(230, 248, 235);
//        private static readonly Color C_STK_BG_LOW = Color.FromArgb(255, 245, 220);
//        private static readonly Color C_STK_BG_ZERO = Color.FromArgb(255, 232, 235);

//        // ── Cache مشترك ───────────────────────────────────────────────────────
//        public static readonly LruImageCache ImageCache = new LruImageCache(200);

//        // ── حالة اللوحة ───────────────────────────────────────────────────────
//        private List<ItemCard> _items = new List<ItemCard>();
//        private int _selectedIdx = -1;
//        private int _hoverIdx = -1;
//        private int _cols = 1;
//        private int _totalHeight = 0;
//        private bool _isLoading = true;

//        // ── Skeleton ──────────────────────────────────────────────────────────
//        private System.Windows.Forms.Timer _skelTimer;
//        private float _skelPhase = 0f;

//        // ── Lazy Load ──────────────────────────────────────────────────────────
//        private CancellationTokenSource _lazyCts;
//        private readonly HashSet<string> _loadingPaths = new HashSet<string>();

//        // ── Context Menu ──────────────────────────────────────────────────────
//        private ContextMenuStrip _ctx;
//        private Point _lastMouse;

//        // ── أحداث ─────────────────────────────────────────────────────────────
//        public event Action<ItemCard> CardClicked;
//        public event Action<ItemCard, VirtualCardPanel> ImgChangeReq;
//        public event Action<ItemCard, VirtualCardPanel> ImgDeleteReq;

//        // ──────────────────────────────────────────────────────────────────────
//        public VirtualCardPanel()
//        {
//            BackColor = C_BG;
//            DoubleBuffered = true;
//            SetStyle(
//                ControlStyles.AllPaintingInWmPaint |
//                ControlStyles.UserPaint |
//                ControlStyles.OptimizedDoubleBuffer |
//                ControlStyles.ResizeRedraw, true);

//            _skelTimer = new System.Windows.Forms.Timer { Interval = 16 };
//            _skelTimer.Tick += (s, e) =>
//            {
//                _skelPhase = (_skelPhase + 0.04f) % (float)(Math.PI * 2);
//                if (_isLoading) Invalidate();
//            };
//            _skelTimer.Start();

//            MouseMove += OnMouseMove;
//            MouseLeave += (s, e) => { _hoverIdx = -1; Invalidate(); };
//            MouseClick += OnMouseClick;
//            MouseWheel += OnMouseWheel;
//            Resize += (s, e) => Recalculate();

//            _ctx = new ContextMenuStrip { Font = new Font("Cairo", 9.5f) };
//            var m1 = new ToolStripMenuItem("🖼️  تحديد صورة");
//            var m2 = new ToolStripMenuItem("🗑️  حذف الصورة");
//            m1.Click += (s, e) => { var c = GetCardAt(_lastMouse); if (c != null) ImgChangeReq?.Invoke(c, this); };
//            m2.Click += (s, e) => { var c = GetCardAt(_lastMouse); if (c != null) ImgDeleteReq?.Invoke(c, this); };
//            _ctx.Items.Add(m1);
//            _ctx.Items.Add(new ToolStripSeparator());
//            _ctx.Items.Add(m2);
//            ContextMenuStrip = _ctx;
//        }

//        // ── API عام ───────────────────────────────────────────────────────────
//        public void SetItems(List<ItemCard> items, bool isLoading = false)
//        {
//            _isLoading = isLoading;
//            _items = items ?? new List<ItemCard>();
//            _selectedIdx = -1;
//            _hoverIdx = -1;
//            AutoScrollPosition = Point.Empty;
//            Recalculate();
//            StartLazyLoad();
//            Invalidate();
//        }

//        public void SetLoadingDone() { _isLoading = false; Invalidate(); }

//        public void SelectCard(ItemCard card)
//        {
//            var idx = _items.IndexOf(card);
//            if (idx < 0) return;
//            _selectedIdx = idx;
//            ScrollToCard(idx);
//            Invalidate();
//        }

//        public void RefreshCard(ItemCard card)
//        {
//            ImageCache.Evict(card.ImagePath);
//            _loadingPaths.Remove(card.ImagePath ?? "");
//            StartLazyLoad();
//            Invalidate();
//        }

//        // ── حساب الأبعاد ──────────────────────────────────────────────────────
//        private void Recalculate()
//        {
//            _cols = Math.Max(1, (Width - MARGIN) / (CARD_W + MARGIN));
//            int rows = (_items.Count + _cols - 1) / Math.Max(1, _cols);
//            _totalHeight = rows * (CARD_H + MARGIN) + MARGIN;
//            AutoScrollMinSize = new Size(0, _totalHeight);
//            Invalidate();
//        }

//        private void ScrollToCard(int idx)
//        {
//            int row = idx / Math.Max(1, _cols);
//            int y = row * (CARD_H + MARGIN) + MARGIN;
//            AutoScrollPosition = new Point(0, Math.Max(0,
//                Math.Min(y - Height / 3, _totalHeight - Height)));
//        }

//        // ── Lazy Load ──────────────────────────────────────────────────────────
//        private void StartLazyLoad()
//        {
//            _lazyCts?.Cancel();
//            _lazyCts = new CancellationTokenSource();
//            var token = _lazyCts.Token;
//            var (from, count) = GetVisibleRange();

//            var toLoad = _items
//                .Skip(Math.Max(0, from - _cols * 2))
//                .Take(count + _cols * 4)
//                .Where(c => !string.IsNullOrEmpty(c.ImagePath)
//                         && File.Exists(c.ImagePath)
//                         && !ImageCache.TryGet(c.ImagePath, out _)
//                         && !_loadingPaths.Contains(c.ImagePath))
//                .Select(c => c.ImagePath)
//                .ToList();

//            foreach (var path in toLoad)
//            {
//                _loadingPaths.Add(path);
//                var p = path;
//                Task.Run(() =>
//                {
//                    if (token.IsCancellationRequested) return;
//                    var img = LoadAndCompress(p, THUMB_W, THUMB_H);
//                    if (img != null) ImageCache.Set(p, img);
//                    _loadingPaths.Remove(p);
//                    if (!token.IsCancellationRequested && !IsDisposed)
//                        BeginInvoke(new Action(Invalidate));
//                }, token);
//            }
//        }

//        public static Image LoadAndCompress(string path, int tw, int th)
//        {
//            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
//            try
//            {
//                using (var src = Image.FromFile(path))
//                {
//                    float r = Math.Max((float)tw / src.Width, (float)th / src.Height);
//                    int nw = (int)(src.Width * r);
//                    int nh = (int)(src.Height * r);
//                    var bmp = new Bitmap(tw, th, PixelFormat.Format32bppArgb);
//                    using (var g = Graphics.FromImage(bmp))
//                    {
//                        g.CompositingQuality = CompositingQuality.HighSpeed;
//                        g.InterpolationMode = InterpolationMode.Bilinear;
//                        g.SmoothingMode = SmoothingMode.HighSpeed;
//                        g.DrawImage(src, (tw - nw) / 2, (th - nh) / 2, nw, nh);
//                    }
//                    return bmp;
//                }
//            }
//            catch { return null; }
//        }

//        // ── نطاق مرئي ─────────────────────────────────────────────────────────
//        private (int from, int count) GetVisibleRange()
//        {
//            int scroll = -AutoScrollPosition.Y;
//            int cols = Math.Max(1, _cols);
//            int from = Math.Max(0, (scroll / (CARD_H + MARGIN)) * cols);
//            int rows = (Height / (CARD_H + MARGIN)) + 2;
//            int count = Math.Min(_items.Count - from, rows * cols);
//            return (from, Math.Max(0, count));
//        }

//        // ── رسم البطاقات ──────────────────────────────────────────────────────
//        protected override void OnPaint(PaintEventArgs e)
//        {
//            var g = e.Graphics;
//            g.SmoothingMode = SmoothingMode.AntiAlias;
//            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
//            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
//            g.Clear(C_BG);

//            if (_isLoading) { DrawSkeletons(g); return; }
//            if (_items.Count == 0) { DrawEmpty(g); return; }

//            int scroll = -AutoScrollPosition.Y;
//            var (from, count) = GetVisibleRange();

//            for (int i = from; i < from + count && i < _items.Count; i++)
//            {
//                int col = i % Math.Max(1, _cols);
//                int row = i / Math.Max(1, _cols);
//                int x = MARGIN + col * (CARD_W + MARGIN);
//                int y = MARGIN + row * (CARD_H + MARGIN) - scroll;
//                if (y + CARD_H < 0 || y > Height) continue;
//                DrawCard(g, _items[i], x, y, i == _selectedIdx, i == _hoverIdx);
//            }
//        }

//        // ── رسم بطاقة واحدة ───────────────────────────────────────────────────
//        private void DrawCard(Graphics g, ItemCard card, int x, int y, bool sel, bool hov)
//        {
//            var rc = new Rectangle(x + 2, y + 2, CARD_W - 4, CARD_H - 4);

//            // ظل
//            if (sel || hov)
//                using (var shd = new SolidBrush(Color.FromArgb(22, 26, 115, 232)))
//                    FillRR(g, shd, new Rectangle(rc.X + 3, rc.Y + 5, rc.Width, rc.Height), RAD);

//            // خلفية
//            var bg = sel ? C_CARD_S : (hov ? C_CARD_H : C_CARD);
//            FillRR(g, new SolidBrush(bg), rc, RAD);

//            // حدود
//            if (sel)
//            {
//                DrawRR(g, new Pen(Color.FromArgb(90, 155, 228), 5f), rc, RAD);
//                DrawRR(g, new Pen(C_BDR_S, 2f), rc, RAD);
//            }
//            else
//                DrawRR(g, new Pen(hov ? C_BDR_H : C_BDR, 1f), rc, RAD);

//            // الصورة
//            var imgRc = new Rectangle(rc.X + 8, rc.Y + 8, rc.Width - 16, IMG_H);
//            DrawImage(g, card, imgRc, hov);

//            // الاسم
//            var nameRc = new RectangleF(rc.X + 4, rc.Y + IMG_H + 12, rc.Width - 8, 34);
//            using (var f = new Font("Cairo", 8.5f, FontStyle.Bold))
//            using (var sf = new StringFormat
//            {
//                Alignment = StringAlignment.Center,
//                Trimming = StringTrimming.EllipsisWord,
//                FormatFlags = StringFormatFlags.LineLimit
//            })
//                g.DrawString(card.NameAR, f, new SolidBrush(C_TXT), nameRc, sf);

//            // الكود
//            if (!string.IsNullOrEmpty(card.Code))
//            {
//                var codeRc = new RectangleF(rc.X + 4, nameRc.Bottom + 1, rc.Width - 8, 14);
//                using (var f = new Font("Consolas", 7f))
//                using (var sf = new StringFormat { Alignment = StringAlignment.Center })
//                    g.DrawString(card.Code, f, new SolidBrush(C_CODE), codeRc, sf);
//            }

//            // ── شريط المخزون ──────────────────────────────────────────────────
//            DrawStockBar(g, card, rc);

//            // علامة التحديد ✔
//            if (sel)
//            {
//                var ck = new Rectangle(rc.Right - 22, rc.Y + 6, 17, 17);
//                FillRR(g, new SolidBrush(C_BDR_S), ck, 9);
//                using (var f = new Font("Arial", 8f, FontStyle.Bold))
//                using (var sf = new StringFormat
//                {
//                    Alignment = StringAlignment.Center,
//                    LineAlignment = StringAlignment.Center
//                })
//                    g.DrawString("✔", f, Brushes.White, ck, sf);
//            }
//        }

//        /// <summary>رسم شريط المخزون في أسفل البطاقة</summary>
//        private void DrawStockBar(Graphics g, ItemCard card, Rectangle rc)
//        {
//            const int barH = 18;
//            const int barMrg = 5;

//            var barRc = new Rectangle(
//                rc.X + barMrg,
//                rc.Bottom - barH - barMrg,
//                rc.Width - barMrg * 2,
//                barH);

//            // اختيار اللون حسب الكمية
//            Color bgColor, txtColor;
//            string label;

//            if (card.Stock <= 0m)
//            {
//                bgColor = C_STK_BG_ZERO;
//                txtColor = C_STK_ZERO;
//                label = "نفذ المخزون  ✖";
//            }
//            else if (card.Stock < 5m)
//            {
//                bgColor = C_STK_BG_LOW;
//                txtColor = C_STK_LOW;
//                label = $"مخزون: {card.Stock:N0}  ⚠";
//            }
//            else
//            {
//                bgColor = C_STK_BG_OK;
//                txtColor = C_STK_OK;
//                label = $"مخزون: {card.Stock:N0}  ✔";
//            }

//            FillRR(g, new SolidBrush(bgColor), barRc, 5);
//            DrawRR(g, new Pen(Color.FromArgb(30, txtColor), 1f), barRc, 5);

//            using (var f = new Font("Cairo", 7.5f, FontStyle.Bold))
//            using (var sf = new StringFormat
//            {
//                Alignment = StringAlignment.Center,
//                LineAlignment = StringAlignment.Center
//            })
//                g.DrawString(label, f, new SolidBrush(txtColor), barRc, sf);
//        }

//        private void DrawImage(Graphics g, ItemCard card, Rectangle imgRc, bool hover)
//        {
//            using (var clip = RRect(imgRc, 7))
//            {
//                g.SetClip(clip);
//                bool hasImg = !string.IsNullOrEmpty(card.ImagePath);
//                Image thumb = null;
//                if (hasImg) ImageCache.TryGet(card.ImagePath, out thumb);

//                if (thumb != null)
//                {
//                    g.DrawImage(thumb, imgRc);
//                }
//                else if (hasImg && _loadingPaths.Contains(card.ImagePath))
//                {
//                    DrawShimmer(g, imgRc);
//                }
//                else
//                {
//                    g.FillPath(new SolidBrush(C_IMG_BG), clip);
//                    using (var f = new Font("Segoe UI Emoji", 22f))
//                    using (var sf = new StringFormat
//                    {
//                        Alignment = StringAlignment.Center,
//                        LineAlignment = StringAlignment.Center
//                    })
//                        g.DrawString("📷", f, new SolidBrush(C_CAM), imgRc, sf);

//                    if (hover)
//                    {
//                        var hint = new RectangleF(imgRc.X, imgRc.Bottom - 20, imgRc.Width, 20);
//                        g.FillRectangle(new SolidBrush(Color.FromArgb(175, 26, 115, 232)), hint);
//                        using (var f = new Font("Cairo", 7f, FontStyle.Bold))
//                        using (var sf = new StringFormat
//                        {
//                            Alignment = StringAlignment.Center,
//                            LineAlignment = StringAlignment.Center
//                        })
//                            g.DrawString("كليك يمين ← إضافة صورة", f, Brushes.White, hint, sf);
//                    }
//                }
//                g.ResetClip();
//            }
//            DrawRR(g, new Pen(Color.FromArgb(18, 0, 0, 0), 1f), imgRc, 7);
//        }

//        // ── Skeleton ──────────────────────────────────────────────────────────
//        private void DrawSkeletons(Graphics g)
//        {
//            int vc = Math.Max(1, (Width - MARGIN) / (CARD_W + MARGIN));
//            int vr = Math.Max(1, (Height - MARGIN) / (CARD_H + MARGIN)) + 1;

//            for (int row = 0; row < vr; row++)
//                for (int col = 0; col < vc; col++)
//                {
//                    int x = MARGIN + col * (CARD_W + MARGIN);
//                    int y = MARGIN + row * (CARD_H + MARGIN);
//                    var rc = new Rectangle(x + 2, y + 2, CARD_W - 4, CARD_H - 4);
//                    FillRR(g, new SolidBrush(Color.White), rc, RAD);
//                    DrawRR(g, new Pen(C_BDR, 1f), rc, RAD);
//                    DrawShimmer(g, new Rectangle(rc.X + 8, rc.Y + 8, rc.Width - 16, IMG_H));
//                    DrawSkeletonLine(g, rc.X + 20, rc.Y + IMG_H + 14, rc.Width - 40, 11);
//                    DrawSkeletonLine(g, rc.X + 40, rc.Y + IMG_H + 32, rc.Width - 80, 7);
//                    DrawSkeletonLine(g, rc.X + 8, rc.Bottom - 22, rc.Width - 16, 14);
//                }
//        }

//        private void DrawShimmer(Graphics g, Rectangle rc)
//        {
//            float p = (float)((Math.Sin(_skelPhase) + 1) / 2.0);
//            var c = Color.FromArgb(
//                (int)(C_SKEL1.R + (C_SKEL2.R - C_SKEL1.R) * p),
//                (int)(C_SKEL1.G + (C_SKEL2.G - C_SKEL1.G) * p),
//                (int)(C_SKEL1.B + (C_SKEL2.B - C_SKEL1.B) * p));
//            g.FillRectangle(new SolidBrush(c), rc);
//            int sx = rc.X + (int)((rc.Width + 100) * ((float)(Math.Sin(_skelPhase * 0.5f) + 1) / 2.0)) - 50;
//            using (var br = new LinearGradientBrush(
//                new Rectangle(sx, rc.Y, 60, Math.Max(1, rc.Height)),
//                Color.FromArgb(0, 255, 255, 255),
//                Color.FromArgb(80, 255, 255, 255),
//                LinearGradientMode.Horizontal))
//                g.FillRectangle(br, sx, rc.Y, 60, rc.Height);
//        }

//        private void DrawSkeletonLine(Graphics g, int x, int y, int w, int h)
//        {
//            float p = (float)((Math.Sin(_skelPhase) + 1) / 2.0);
//            var c = Color.FromArgb(
//                (int)(C_SKEL1.R + (C_SKEL2.R - C_SKEL1.R) * p),
//                (int)(C_SKEL1.G + (C_SKEL2.G - C_SKEL1.G) * p),
//                (int)(C_SKEL1.B + (C_SKEL2.B - C_SKEL1.B) * p));
//            FillRR(g, new SolidBrush(c), new Rectangle(x, y, Math.Max(1, w), Math.Max(1, h)), h / 2);
//        }

//        private void DrawEmpty(Graphics g)
//        {
//            using (var f = new Font("Cairo", 14f, FontStyle.Bold))
//            using (var sf = new StringFormat
//            {
//                Alignment = StringAlignment.Center,
//                LineAlignment = StringAlignment.Center
//            })
//                g.DrawString("لا توجد نتائج 🔍", f,
//                    new SolidBrush(Color.FromArgb(178, 188, 210)), ClientRectangle, sf);
//        }

//        // ── Mouse ─────────────────────────────────────────────────────────────
//        private void OnMouseMove(object sender, MouseEventArgs e)
//        {
//            _lastMouse = e.Location;
//            int idx = IndexAt(e.Location);
//            if (idx != _hoverIdx) { _hoverIdx = idx; Invalidate(); }
//        }

//        private void OnMouseClick(object sender, MouseEventArgs e)
//        {
//            if (e.Button != MouseButtons.Left) return;
//            var card = GetCardAt(e.Location);
//            if (card == null) return;
//            _selectedIdx = _items.IndexOf(card);
//            Invalidate();
//            CardClicked?.Invoke(card);
//        }

//        private void OnMouseWheel(object sender, MouseEventArgs e)
//        {
//            int delta = e.Delta > 0 ? -70 : 70;
//            var pos = AutoScrollPosition;
//            AutoScrollPosition = new Point(0, Math.Max(0, -pos.Y + delta));
//            StartLazyLoad();
//        }

//        private int IndexAt(Point pt)
//        {
//            int scroll = -AutoScrollPosition.Y;
//            for (int i = 0; i < _items.Count; i++)
//            {
//                int col = i % Math.Max(1, _cols);
//                int row = i / Math.Max(1, _cols);
//                int x = MARGIN + col * (CARD_W + MARGIN);
//                int y = MARGIN + row * (CARD_H + MARGIN) - scroll;
//                if (new Rectangle(x, y, CARD_W, CARD_H).Contains(pt)) return i;
//            }
//            return -1;
//        }

//        private ItemCard GetCardAt(Point pt)
//        {
//            int i = IndexAt(pt);
//            return i >= 0 ? _items[i] : null;
//        }

//        // ── Override Scroll ───────────────────────────────────────────────────
//        protected override void OnScroll(ScrollEventArgs se)
//        {
//            base.OnScroll(se);
//            StartLazyLoad();
//            Invalidate();
//        }

//        // ── GDI+ helpers ─────────────────────────────────────────────────────
//        private static GraphicsPath RRect(Rectangle r, int rad)
//        {
//            int d = rad * 2;
//            var p = new GraphicsPath();
//            p.AddArc(r.X, r.Y, d, d, 180, 90);
//            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
//            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
//            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
//            p.CloseFigure();
//            return p;
//        }

//        private static void FillRR(Graphics g, Brush b, Rectangle r, int rad)
//        { using (var p = RRect(r, rad)) g.FillPath(b, p); }

//        private static void DrawRR(Graphics g, Pen pen, Rectangle r, int rad)
//        { using (var p = RRect(r, rad)) g.DrawPath(pen, p); }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                _lazyCts?.Cancel();
//                _skelTimer?.Stop();
//                _skelTimer?.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }

//    // =========================================================================
//    //  الفورم الرئيسي
//    // =========================================================================
//    public class FRM_ImagePicker : Form
//    {
//        // ── خصائص النتيجة ─────────────────────────────────────────────────────
//        public int IN_OUT_STOCK = 0;
//        public int IDValue { get; private set; }
//        public string NameValue { get; private set; }
//        public decimal numberValue { get; private set; }
//        public string gatgoryValue { get; private set; }
//        public string formmValue { get; private set; }

//        // ── ألوان ─────────────────────────────────────────────────────────────
//        private static readonly Color C_BG = Color.FromArgb(238, 243, 250);
//        private static readonly Color C_DARK = Color.FromArgb(18, 28, 50);
//        private static readonly Color C_BLUE = Color.FromArgb(26, 115, 232);
//        private static readonly Color C_GREEN = Color.FromArgb(34, 154, 60);
//        private static readonly Color C_RED = Color.FromArgb(210, 48, 65);
//        private static readonly Color C_WHITE = Color.White;
//        private static readonly Color C_SEP = Color.FromArgb(213, 221, 234);
//        private static readonly Color C_HDR = Color.FromArgb(226, 235, 252);

//        // ── كونترولات ─────────────────────────────────────────────────────────
//        private Panel pnlTop, pnlSearch, pnlMain, pnlDetail, pnlBottom;
//        private VirtualCardPanel virtualPanel;
//        private Label lblTitle, lblCount, lblLoading, lblSelected;
//        private TextBox txtSearch, txtQty;
//        private ComboBox cmbCat;
//        private PictureBox picDetail;
//        private Label lblDName, lblDCode, lblDCat, lblDForm, lblDStock;
//        private RichTextBox rtbNotes;
//        private Button btnAdd, btnClose;
//        private ProgressBar progressBar;
//        private BackgroundWorker bgw;

//        // ── بيانات ────────────────────────────────────────────────────────────
//        private List<ItemCard> _all = new List<ItemCard>();
//        private ItemCard _selected;

//        // ── Debounce للبحث ────────────────────────────────────────────────────
//        private System.Windows.Forms.Timer _searchTimer;

//        // ─────────────────────────────────────────────────────────────────────
//        public FRM_ImagePicker()
//        {
//            ImageStore.EnsureFolder();
//            BuildUI();
//            InitWorker();
//        }

//        // =========================================================================
//        //  بناء الواجهة
//        // =========================================================================
//        private void BuildUI()
//        {
//            Text = "اختيار المواد بالصور";
//            Size = new Size(1200, 740);
//            MinimumSize = new Size(980, 600);
//            StartPosition = FormStartPosition.CenterScreen;
//            BackColor = C_BG;
//            Font = new Font("Cairo", 10f);
//            RightToLeft = RightToLeft.Yes;
//            RightToLeftLayout = true;
//            FormBorderStyle = FormBorderStyle.Sizable;

//            _searchTimer = new System.Windows.Forms.Timer { Interval = 200 };
//            _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); ApplyFilter(); };

//            BuildHeader();
//            BuildSearchBar();
//            BuildMainArea();
//            BuildBottomBar();

//            Controls.Add(pnlMain);
//            Controls.Add(pnlBottom);
//            Controls.Add(pnlSearch);
//            Controls.Add(pnlTop);

//            Load += (s, e) =>
//            {
//                lblLoading.Visible = true;
//                progressBar.Visible = true;
//                virtualPanel.SetItems(new List<ItemCard>(), isLoading: true);
//                bgw.RunWorkerAsync();
//            };
//        }

//        // ── Header ────────────────────────────────────────────────────────────
//        private void BuildHeader()
//        {
//            pnlTop = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = C_DARK };
//            pnlTop.Controls.Add(new Label
//            {
//                Text = "🖼️   اختيار المواد بالصور",
//                ForeColor = Color.White,
//                Font = new Font("Cairo", 14f, FontStyle.Bold),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter
//            });
//        }

//        // ── Search Bar ────────────────────────────────────────────────────────
//        private void BuildSearchBar()
//        {
//            pnlSearch = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = C_WHITE };
//            pnlSearch.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, pnlSearch.Height - 1, pnlSearch.Width, pnlSearch.Height - 1);

//            var tbl = new TableLayoutPanel
//            {
//                Dock = DockStyle.Fill,
//                ColumnCount = 5,
//                RowCount = 1,
//                BackColor = C_WHITE,
//                Padding = new Padding(10, 0, 10, 0)
//            };
//            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28f));

//            tbl.Controls.Add(new Label
//            {
//                Text = "🔍",
//                Font = new Font("Segoe UI Emoji", 13f),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            }, 0, 0);

//            txtSearch = new TextBox
//            {
//                Font = new Font("Cairo", 10.5f),
//                BorderStyle = BorderStyle.FixedSingle,
//                Anchor = AnchorStyles.Left | AnchorStyles.Right,
//                Height = 28,
//                Margin = new Padding(2, 11, 2, 11)
//            };
//            txtSearch.TextChanged += (s, e) => { _searchTimer.Stop(); _searchTimer.Start(); };
//            tbl.Controls.Add(txtSearch, 1, 0);

//            tbl.Controls.Add(new Label
//            {
//                Text = "الصنف:",
//                Font = new Font("Cairo", 10f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(70, 85, 115),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            }, 2, 0);

//            cmbCat = new ComboBox
//            {
//                Font = new Font("Cairo", 9.5f),
//                DropDownStyle = ComboBoxStyle.DropDownList,
//                Anchor = AnchorStyles.Left | AnchorStyles.Right,
//                Height = 28,
//                Margin = new Padding(2, 11, 2, 11)
//            };
//            cmbCat.Items.Add("جميع الأصناف");
//            cmbCat.SelectedIndex = 0;
//            cmbCat.SelectedIndexChanged += (s, e) => ApplyFilter();
//            tbl.Controls.Add(cmbCat, 3, 0);

//            var pnlInfo = new Panel { Dock = DockStyle.Fill, BackColor = C_WHITE, Margin = Padding.Empty };
//            lblCount = new Label
//            {
//                Text = "",
//                Font = new Font("Cairo", 10f, FontStyle.Bold),
//                ForeColor = C_BLUE,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Visible = false
//            };
//            lblLoading = new Label
//            {
//                Text = "⏳  جاري التحميل...",
//                Font = new Font("Cairo", 9.5f, FontStyle.Bold),
//                ForeColor = C_BLUE,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Visible = false
//            };
//            pnlInfo.Controls.Add(lblCount);
//            pnlInfo.Controls.Add(lblLoading);
//            tbl.Controls.Add(pnlInfo, 4, 0);

//            progressBar = new ProgressBar
//            {
//                Style = ProgressBarStyle.Marquee,
//                Height = 3,
//                Dock = DockStyle.Bottom,
//                Visible = false
//            };

//            pnlSearch.Controls.Add(tbl);
//            pnlSearch.Controls.Add(progressBar);
//        }

//        // ── Main Area ─────────────────────────────────────────────────────────
//        private void BuildMainArea()
//        {
//            pnlMain = new Panel { Dock = DockStyle.Fill, BackColor = C_BG };

//            pnlDetail = new Panel { Dock = DockStyle.Right, Width = 300, BackColor = C_WHITE };
//            pnlDetail.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, 0, 0, pnlDetail.Height);

//            BuildDetailPanel();

//            virtualPanel = new VirtualCardPanel { Dock = DockStyle.Fill };
//            virtualPanel.CardClicked += OnCardClick;
//            virtualPanel.ImgChangeReq += OnImgChange;
//            virtualPanel.ImgDeleteReq += OnImgDelete;

//            pnlMain.Controls.Add(virtualPanel);
//            pnlMain.Controls.Add(pnlDetail);
//        }

//        // ── Detail Panel ──────────────────────────────────────────────────────
//        private void BuildDetailPanel()
//        {
//            var hdr = new Panel { Dock = DockStyle.Top, Height = 38, BackColor = C_HDR };
//            hdr.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, hdr.Height - 1, hdr.Width, hdr.Height - 1);
//            hdr.Controls.Add(new Label
//            {
//                Text = "📋   تفاصيل المادة",
//                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
//                ForeColor = C_DARK,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter
//            });
//            pnlDetail.Controls.Add(hdr);

//            var tbl = new TableLayoutPanel
//            {
//                Dock = DockStyle.Fill,
//                ColumnCount = 1,
//                RowCount = 6,
//                BackColor = C_WHITE,
//                Padding = new Padding(10, 8, 10, 8)
//            };
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 172f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 38f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 2f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 130f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
//            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

//            picDetail = new PictureBox
//            {
//                Dock = DockStyle.Fill,
//                SizeMode = PictureBoxSizeMode.Zoom,
//                BackColor = Color.FromArgb(228, 234, 248),
//                BorderStyle = BorderStyle.FixedSingle,
//                Margin = new Padding(0, 0, 0, 6)
//            };
//            tbl.Controls.Add(picDetail, 0, 0);

//            lblDName = new Label
//            {
//                Text = "اختر مادة من القائمة",
//                Font = new Font("Cairo", 11.5f, FontStyle.Bold),
//                ForeColor = C_DARK,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            };
//            tbl.Controls.Add(lblDName, 0, 1);

//            tbl.Controls.Add(
//                new Panel { Dock = DockStyle.Fill, BackColor = C_SEP, Margin = new Padding(0, 2, 0, 4) }
//                , 0, 2);

//            var pnlInfo = new Panel { Dock = DockStyle.Fill, BackColor = C_WHITE, Margin = Padding.Empty };
//            int iy = 0;
//            MkRow(pnlInfo, ref iy, "الكود:", out lblDCode);
//            MkRow(pnlInfo, ref iy, "الصنف:", out lblDCat);
//            MkRow(pnlInfo, ref iy, "التجزئة:", out lblDForm);

//            // شريط المخزون مميّز
//            var pnlStk = new Panel
//            {
//                Left = 0,
//                Top = iy,
//                Height = 30,
//                BackColor = Color.FromArgb(238, 246, 255),
//                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
//            };
//            pnlStk.Resize += (s, e) => pnlStk.Width = pnlInfo.Width;
//            pnlInfo.Resize += (s, e) => pnlStk.Width = pnlInfo.Width;
//            pnlStk.Controls.Add(new Label
//            {
//                Text = "المخزون:",
//                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(80, 96, 130),
//                Left = 0,
//                Top = 0,
//                Width = 72,
//                Height = 30,
//                TextAlign = ContentAlignment.MiddleRight
//            });
//            lblDStock = new Label
//            {
//                Text = "—",
//                Font = new Font("Cairo", 9.5f, FontStyle.Bold),
//                ForeColor = C_DARK,
//                Left = 76,
//                Top = 0,
//                Width = 200,
//                Height = 30,
//                TextAlign = ContentAlignment.MiddleLeft
//            };
//            pnlStk.Controls.Add(lblDStock);
//            pnlInfo.Controls.Add(pnlStk);
//            tbl.Controls.Add(pnlInfo, 0, 3);

//            tbl.Controls.Add(new Label
//            {
//                Text = "ملاحظات:",
//                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(118, 130, 158),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.BottomRight,
//                Margin = new Padding(0, 4, 0, 0)
//            }, 0, 4);

//            rtbNotes = new RichTextBox
//            {
//                Dock = DockStyle.Fill,
//                ReadOnly = true,
//                BackColor = Color.FromArgb(246, 249, 255),
//                Font = new Font("Cairo", 8.5f),
//                BorderStyle = BorderStyle.FixedSingle,
//                ScrollBars = RichTextBoxScrollBars.Vertical,
//                Margin = new Padding(0, 0, 0, 4)
//            };
//            tbl.Controls.Add(rtbNotes, 0, 5);
//            pnlDetail.Controls.Add(tbl);
//            ResetDetail();
//        }

//        private void MkRow(Panel p, ref int y, string lbl, out Label val)
//        {
//            const int H = 27;
//            p.Controls.Add(new Label
//            {
//                Text = lbl,
//                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
//                ForeColor = Color.FromArgb(102, 116, 148),
//                Left = 0,
//                Top = y,
//                Width = 72,
//                Height = H,
//                TextAlign = ContentAlignment.MiddleRight
//            });
//            val = new Label
//            {
//                Text = "—",
//                Font = new Font("Cairo", 9f),
//                ForeColor = C_DARK,
//                Left = 76,
//                Top = y,
//                Width = 200,
//                Height = H,
//                TextAlign = ContentAlignment.MiddleLeft
//            };
//            p.Controls.Add(val);
//            y += H + 2;
//        }

//        // ── Bottom Bar ────────────────────────────────────────────────────────
//        private void BuildBottomBar()
//        {
//            pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = C_WHITE };
//            pnlBottom.Paint += (s, e) =>
//                e.Graphics.DrawLine(new Pen(C_SEP), 0, 0, pnlBottom.Width, 0);

//            var tbl = new TableLayoutPanel
//            {
//                Dock = DockStyle.Fill,
//                ColumnCount = 5,
//                RowCount = 1,
//                BackColor = C_WHITE,
//                Padding = new Padding(12, 0, 12, 0)
//            };
//            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
//            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115f));

//            lblSelected = new Label
//            {
//                Text = "لم يتم اختيار مادة",
//                ForeColor = Color.FromArgb(158, 168, 188),
//                Font = new Font("Cairo", 9.5f, FontStyle.Italic),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleRight,
//                Margin = Padding.Empty
//            };
//            tbl.Controls.Add(lblSelected, 0, 0);

//            tbl.Controls.Add(new Label
//            {
//                Text = "الكمية:",
//                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
//                ForeColor = C_BLUE,
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Margin = Padding.Empty
//            }, 1, 0);

//            txtQty = new TextBox
//            {
//                Text = "1",
//                Font = new Font("Cairo", 13f, FontStyle.Bold),
//                TextAlign = HorizontalAlignment.Center,
//                BorderStyle = BorderStyle.FixedSingle,
//                Anchor = AnchorStyles.Left | AnchorStyles.Right,
//                Height = 34,
//                Margin = new Padding(3, 13, 3, 13)
//            };
//            txtQty.Click += (s, e) => txtQty.SelectAll();
//            txtQty.KeyPress += ValidateQty;
//            txtQty.KeyDown += (s, e) =>
//            {
//                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnAdd_Click(null, null); }
//            };
//            tbl.Controls.Add(txtQty, 2, 0);

//            btnAdd = MkBtn("✔  إضافة المادة", C_GREEN, new Padding(6, 12, 6, 12));
//            btnClose = MkBtn("✖  إغلاق", C_RED, new Padding(4, 12, 4, 12));
//            btnAdd.Click += BtnAdd_Click;
//            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

//            tbl.Controls.Add(btnAdd, 3, 0);
//            tbl.Controls.Add(btnClose, 4, 0);
//            pnlBottom.Controls.Add(tbl);
//        }

//        private Button MkBtn(string text, Color bg, Padding margin)
//        {
//            var b = new Button
//            {
//                Text = text,
//                BackColor = bg,
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
//                Cursor = Cursors.Hand,
//                Dock = DockStyle.Fill,
//                Margin = margin
//            };
//            b.FlatAppearance.BorderSize = 0;
//            return b;
//        }

//        // =========================================================================
//        //  BackgroundWorker — يجلب المواد والمخزون معاً في خيط واحد
//        // =========================================================================
//        private void InitWorker()
//        {
//            bgw = new BackgroundWorker();
//            bgw.DoWork += Bgw_DoWork;
//            bgw.RunWorkerCompleted += Bgw_Done;
//        }

//        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
//        {
//            var list = new List<ItemCard>();
//            try
//            {
//                using (var db = new AlibaRamyEntities())
//                {
//                    // ── جلب جميع المواد ───────────────────────────────────────
//                    var groups = db.TB_groups
//                        .ToDictionary(g => g.groups_id, g => g.groups_name ?? "");

//                    // ── جلب المخزون لجميع المواد دفعةً واحدة (أسرع من N+1) ──
//                    // sum = str_num + str_renum لكل item_id
//                    var stockDict = db.TB_str
//                        .GroupBy(s => s.items_id)
//                        .Select(g => new
//                        {
//                            ID = g.Key,
//                            Qty = g.Sum(s => (decimal?)s.str_num ?? 0m)
//                                + g.Sum(s => (decimal?)s.str_renum ?? 0m)
//                        })
//                        .ToDictionary(x => x.ID, x => x.Qty);

//                    foreach (var it in db.TB_items.ToList())
//                    {
//                        if (string.IsNullOrWhiteSpace(it.items_name)) continue;

//                        string cat = it.groups_id.HasValue &&
//                                     groups.ContainsKey(it.groups_id.Value)
//                                     ? groups[it.groups_id.Value] : "";

//                        decimal stk = stockDict.ContainsKey(it.items_id)
//                                      ? stockDict[it.items_id] : 0m;

//                        list.Add(new ItemCard
//                        {
//                            ID = it.items_id,
//                            NameAR = it.items_name.Trim(),
//                            Code = it.items_code ?? "",
//                            Category = cat,
//                            Form = it.items_form ?? "",
//                            Notes = it.items_nots ?? "",
//                            ImagePath = ImageStore.Find(it.items_id) ?? "",
//                            Stock = stk
//                        });
//                    }
//                }
//            }
//            catch (Exception ex) { e.Result = ex; return; }
//            e.Result = list;
//        }

//        private void Bgw_Done(object sender, RunWorkerCompletedEventArgs e)
//        {
//            progressBar.Visible = false;
//            lblLoading.Visible = false;
//            lblCount.Visible = true;

//            if (e.Result is Exception ex)
//            {
//                MessageBox.Show("خطأ في تحميل البيانات:\n" + ex.Message,
//                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            _all = e.Result as List<ItemCard> ?? new List<ItemCard>();

//            cmbCat.Items.Clear();
//            cmbCat.Items.Add("جميع الأصناف");
//            foreach (var c in _all.Select(x => x.Category)
//                .Where(x => !string.IsNullOrEmpty(x))
//                .Distinct().OrderBy(x => x))
//                cmbCat.Items.Add(c);
//            cmbCat.SelectedIndex = 0;

//            virtualPanel.SetLoadingDone();
//            ShowCards(_all);
//        }

//        // =========================================================================
//        //  عرض البطاقات
//        // =========================================================================
//        private void ShowCards(List<ItemCard> items)
//        {
//            virtualPanel.SetItems(items);
//            lblCount.Text = $"({items.Count} مادة)";
//        }

//        private void ApplyFilter()
//        {
//            if (_all.Count == 0) return;
//            var q = txtSearch.Text.Trim().ToLower();
//            var cat = cmbCat.SelectedItem?.ToString() ?? "جميع الأصناف";
//            var res = _all.Where(x =>
//                (string.IsNullOrEmpty(q) ||
//                 x.NameAR.ToLower().Contains(q) ||
//                 x.Code.ToLower().Contains(q)) &&
//                (cat == "جميع الأصناف" || x.Category == cat)
//            ).ToList();
//            ShowCards(res);
//        }

//        // =========================================================================
//        //  اختيار بطاقة
//        // =========================================================================
//        private void OnCardClick(ItemCard data)
//        {
//            _selected = data;
//            lblSelected.Text = $"✔  {data.NameAR}";
//            lblSelected.ForeColor = C_BLUE;
//            ShowDetail(data);
//            txtQty.Text = "1";
//            txtQty.Focus();
//            txtQty.SelectAll();
//        }

//        // =========================================================================
//        //  إدارة الصور
//        // =========================================================================
//        private void OnImgChange(ItemCard data, VirtualCardPanel panel)
//        {
//            using (var dlg = new OpenFileDialog())
//            {
//                dlg.Title = $"اختر صورة للمادة: {data.NameAR}";
//                dlg.Filter = "صور|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";
//                if (dlg.ShowDialog() != DialogResult.OK) return;
//                try
//                {
//                    var newPath = ImageStore.Save(data.ID, dlg.FileName);
//                    data.ImagePath = newPath;
//                    panel.RefreshCard(data);
//                    if (_selected?.ID == data.ID)
//                        picDetail.Image = LoadForDetail(newPath);
//                    MessageBox.Show($"✔  تم حفظ صورة المادة:\n{data.NameAR}",
//                        "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("خطأ:\n" + ex.Message,
//                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        private void OnImgDelete(ItemCard data, VirtualCardPanel panel)
//        {
//            if (string.IsNullOrEmpty(data.ImagePath))
//            {
//                MessageBox.Show("لا توجد صورة للمادة.", "تنبيه",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }
//            if (MessageBox.Show($"حذف صورة:\n{data.NameAR}؟",
//                    "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
//            try
//            {
//                VirtualCardPanel.ImageCache.Evict(data.ImagePath);
//                ImageStore.Delete(data.ID);
//                data.ImagePath = "";
//                panel.RefreshCard(data);
//                if (_selected?.ID == data.ID) picDetail.Image = null;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("خطأ:\n" + ex.Message, "خطأ",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // =========================================================================
//        //  التفاصيل
//        // =========================================================================
//        private void ShowDetail(ItemCard d)
//        {
//            picDetail.Image = LoadForDetail(d.ImagePath);
//            lblDName.Text = d.NameAR;
//            lblDCode.Text = Dash(d.Code);
//            lblDCat.Text = Dash(d.Category);
//            lblDForm.Text = Dash(d.Form);
//            rtbNotes.Text = d.Notes;

//            // عرض المخزون بلون دلالي
//            if (d.Stock <= 0m)
//            {
//                lblDStock.Text = "نفذ المخزون  ✖";
//                lblDStock.ForeColor = C_RED;
//            }
//            else if (d.Stock < 5m)
//            {
//                lblDStock.Text = $"{d.Stock:N2}  ⚠  (كمية منخفضة)";
//                lblDStock.ForeColor = Color.FromArgb(200, 120, 0);
//            }
//            else
//            {
//                lblDStock.Text = $"{d.Stock:N2}  ✔";
//                lblDStock.ForeColor = C_GREEN;
//            }
//        }

//        private void ResetDetail()
//        {
//            if (picDetail != null) picDetail.Image = null;
//            if (lblDName != null) lblDName.Text = "اختر مادة من القائمة";
//            if (lblDCode != null) lblDCode.Text = "—";
//            if (lblDCat != null) lblDCat.Text = "—";
//            if (lblDForm != null) lblDForm.Text = "—";
//            if (lblDStock != null) { lblDStock.Text = "—"; lblDStock.ForeColor = Color.Gray; }
//            if (rtbNotes != null) rtbNotes.Text = "";
//        }

//        private static string Dash(string v) => string.IsNullOrEmpty(v) ? "—" : v;

//        private static Image LoadForDetail(string path)
//        {
//            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
//            try { return Image.FromFile(path); } catch { return null; }
//        }

//        // =========================================================================
//        //  زر الإضافة — التحقق من المخزون قبل الإغلاق
//        // =========================================================================
//        private void BtnAdd_Click(object sender, EventArgs e)
//        {
//            if (_selected == null)
//            {
//                MessageBox.Show("الرجاء اختيار مادة أولاً.",
//                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (!decimal.TryParse(txtQty.Text, out decimal qty) || qty <= 0)
//            {
//                MessageBox.Show("الرجاء إدخال كمية صحيحة (أكبر من صفر).",
//                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtQty.Focus();
//                txtQty.SelectAll();
//                return;
//            }

//            // ★ التحقق من المخزون (للصادر والإتلاف فقط)
//            if (IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11)
//            {
//                if (_selected.Stock <= 0m)
//                {
//                    MessageBox.Show(
//                        $"المادة ({_selected.NameAR}) غير متوفرة في المخزون.",
//                        "مخزون فارغ ✖", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }
//                if (_selected.Stock < qty)
//                {
//                    MessageBox.Show(
//                        $"الكمية المطلوبة ({qty:N2}) أكبر من المخزون المتاح ({_selected.Stock:N2}).\n\n" +
//                        $"المادة: {_selected.NameAR}",
//                        "مخزون غير كافٍ ⚠", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }
//            }

//            IDValue = _selected.ID;
//            NameValue = _selected.NameAR;
//            numberValue = qty;
//            gatgoryValue = _selected.Category;
//            formmValue = _selected.Form;
//            DialogResult = DialogResult.OK;
//            Close();
//        }

//        private void ValidateQty(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
//                e.Handled = true;
//            if (e.KeyChar == '.' && txtQty.Text.Contains('.'))
//                e.Handled = true;
//        }

//        protected override void OnFormClosed(FormClosedEventArgs e)
//        {
//            _searchTimer?.Dispose();
//            VirtualCardPanel.ImageCache.Clear();
//            base.OnFormClosed(e);
//        }
//    }
//}













// ═══════════════════════════════════════════════════════════════════════════════
//  FRM_ImagePicker.cs  —  النسخة الاحترافية v7
//  ✅ عرض المخزون تحت كل بطاقة مع لون دلالي
//  ✅ جلب المخزون مسبقاً مع تحميل البيانات (لا تأخير)
//  ✅ التحقق من الكمية مقابل المخزون عند الإضافة
//  ✅ Virtual Scroll / LRU Cache / Skeleton / Lazy Load
// ═══════════════════════════════════════════════════════════════════════════════

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALIBA_COMPANY.classes;
using DevExpress.Utils.Html.Internal;

namespace ALIBA_COMPANY.Store
{
    // =========================================================================
    //  مساعد الصور المحلية
    // =========================================================================
    internal static class ImageStore
    {
        public const string RootPath = @"C:\AlibaImages";
        private static readonly string[] Exts =
            { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };

        public static void EnsureFolder()
        {
            if (!Directory.Exists(RootPath))
                Directory.CreateDirectory(RootPath);
        }

        public static string Find(int id)
        {
            foreach (var ext in Exts)
            {
                var p = Path.Combine(RootPath, id + ext);
                if (File.Exists(p)) return p;
            }
            return null;
        }

        public static string Save(int id, string src)
        {
            EnsureFolder();
            Delete(id);
            var ext = Path.GetExtension(src).ToLower();
            var dest = Path.Combine(RootPath, id + ext);
            File.Copy(src, dest, true);
            return dest;
        }

        public static void Delete(int id)
        {
            foreach (var ext in Exts)
            {
                var p = Path.Combine(RootPath, id + ext);
                if (File.Exists(p)) try { File.Delete(p); } catch { }
            }
        }
    }

    // =========================================================================
    //  LRU Image Cache
    // =========================================================================
    internal sealed class LruImageCache : IDisposable
    {
        private readonly int _cap;
        private readonly Dictionary<string, LinkedListNode<(string k, Image v)>> _map;
        private readonly LinkedList<(string k, Image v)> _list;
        private readonly object _lock = new object();

        public LruImageCache(int cap = 200)
        {
            _cap = cap;
            _map = new Dictionary<string, LinkedListNode<(string, Image)>>(cap, StringComparer.OrdinalIgnoreCase);
            _list = new LinkedList<(string, Image)>();
        }

        public bool TryGet(string key, out Image img)
        {
            lock (_lock)
            {
                if (_map.TryGetValue(key, out var n))
                {
                    _list.Remove(n);
                    _list.AddFirst(n);
                    img = n.Value.v;
                    return true;
                }
                img = null;
                return false;
            }
        }

        public void Set(string key, Image img)
        {
            lock (_lock)
            {
                if (_map.TryGetValue(key, out var ex))
                {
                    ex.Value.v?.Dispose();
                    _list.Remove(ex);
                    _map.Remove(key);
                }
                while (_list.Count >= _cap)
                {
                    var last = _list.Last;
                    _list.RemoveLast();
                    _map.Remove(last.Value.k);
                    last.Value.v?.Dispose();
                }
                var node = _list.AddFirst((key, img));
                _map[key] = node;
            }
        }

        public void Evict(string key)
        {
            if (string.IsNullOrEmpty(key)) return;
            lock (_lock)
            {
                if (_map.TryGetValue(key, out var n))
                {
                    n.Value.v?.Dispose();
                    _list.Remove(n);
                    _map.Remove(key);
                }
            }
        }

        public void Clear()
        {
            lock (_lock)
            {
                foreach (var n in _list) n.v?.Dispose();
                _list.Clear();
                _map.Clear();
            }
        }

        public void Dispose() => Clear();
    }

    // =========================================================================
    //  بيانات المادة — المخزون مُحمَّل مسبقاً
    // =========================================================================
    internal class ItemCard
    {
        public int ID { get; set; }
        public string NameAR { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Form { get; set; }
        public string Notes { get; set; }
        public string ImagePath { get; set; }

        /// <summary>المخزون — يُحمَّل دائماً مع البيانات الأولية</summary>
        public decimal Stock { get; set; } = -1m;
        public bool StockLoaded => Stock >= 0m;
    }

    // =========================================================================
    //  Virtual Card Panel — يرسم المخزون ضمن كل بطاقة
    // =========================================================================
    internal sealed class VirtualCardPanel : Panel
    {
        // ── أبعاد البطاقة ─────────────────────────────────────────────────────
        public const int CARD_W = 168;
        public const int CARD_H = 215;   // أعلى بـ 15 لاستيعاب سطر المخزون
        public const int MARGIN = 9;
        public const int IMG_H = 112;
        public const int THUMB_W = 150;
        public const int THUMB_H = 112;
        public const int RAD = 10;

        // ── ألوان ─────────────────────────────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(238, 243, 250);
        private static readonly Color C_CARD = Color.White;
        private static readonly Color C_CARD_H = Color.FromArgb(240, 247, 255);
        private static readonly Color C_CARD_S = Color.FromArgb(218, 236, 255);
        private static readonly Color C_BDR = Color.FromArgb(208, 218, 232);
        private static readonly Color C_BDR_H = Color.FromArgb(145, 192, 245);
        private static readonly Color C_BDR_S = Color.FromArgb(26, 115, 232);
        private static readonly Color C_TXT = Color.FromArgb(20, 30, 55);
        private static readonly Color C_CODE = Color.FromArgb(115, 128, 155);
        private static readonly Color C_IMG_BG = Color.FromArgb(228, 234, 248);
        private static readonly Color C_CAM = Color.FromArgb(162, 174, 200);
        private static readonly Color C_SKEL1 = Color.FromArgb(225, 230, 240);
        private static readonly Color C_SKEL2 = Color.FromArgb(240, 244, 252);

        // ── ألوان المخزون ─────────────────────────────────────────────────────
        private static readonly Color C_STK_OK = Color.FromArgb(34, 154, 60);   // أخضر
        private static readonly Color C_STK_LOW = Color.FromArgb(220, 140, 0);   // برتقالي
        private static readonly Color C_STK_ZERO = Color.FromArgb(210, 48, 65);   // أحمر
        private static readonly Color C_STK_BG_OK = Color.FromArgb(230, 248, 235);
        private static readonly Color C_STK_BG_LOW = Color.FromArgb(255, 245, 220);
        private static readonly Color C_STK_BG_ZERO = Color.FromArgb(255, 232, 235);

        // ── Cache مشترك ───────────────────────────────────────────────────────
        public static readonly LruImageCache ImageCache = new LruImageCache(200);

        // ── حالة اللوحة ───────────────────────────────────────────────────────
        private List<ItemCard> _items = new List<ItemCard>();
        private int _selectedIdx = -1;
        private int _hoverIdx = -1;
        private int _cols = 1;
        private int _totalHeight = 0;
        private bool _isLoading = true;

        // ── Skeleton ──────────────────────────────────────────────────────────
        private System.Windows.Forms.Timer _skelTimer;
        private float _skelPhase = 0f;

        // ── Lazy Load ──────────────────────────────────────────────────────────
        private CancellationTokenSource _lazyCts;
        private readonly HashSet<string> _loadingPaths = new HashSet<string>();

        // ── Context Menu ──────────────────────────────────────────────────────
        private ContextMenuStrip _ctx;
        private Point _lastMouse;

        // ── أحداث ─────────────────────────────────────────────────────────────
        public event Action<ItemCard> CardClicked;
        public event Action<ItemCard, VirtualCardPanel> ImgChangeReq;
        public event Action<ItemCard, VirtualCardPanel> ImgDeleteReq;

        // ──────────────────────────────────────────────────────────────────────
        public VirtualCardPanel()
        {
            BackColor = C_BG;
            DoubleBuffered = true;
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);

            _skelTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _skelTimer.Tick += (s, e) =>
            {
                _skelPhase = (_skelPhase + 0.04f) % (float)(Math.PI * 2);
                if (_isLoading) Invalidate();
            };
            _skelTimer.Start();

            MouseMove += OnMouseMove;
            MouseLeave += (s, e) => { _hoverIdx = -1; Invalidate(); };
            MouseClick += OnMouseClick;
            MouseWheel += OnMouseWheel;
            Resize += (s, e) => Recalculate();

            _ctx = new ContextMenuStrip { Font = new Font("Cairo", 9.5f) };
            var m1 = new ToolStripMenuItem("🖼️  تحديد صورة");
            var m2 = new ToolStripMenuItem("🗑️  حذف الصورة");
            m1.Click += (s, e) => { var c = GetCardAt(_lastMouse); if (c != null) ImgChangeReq?.Invoke(c, this); };
            m2.Click += (s, e) => { var c = GetCardAt(_lastMouse); if (c != null) ImgDeleteReq?.Invoke(c, this); };
            _ctx.Items.Add(m1);
            _ctx.Items.Add(new ToolStripSeparator());
            _ctx.Items.Add(m2);
            ContextMenuStrip = _ctx;
        }

        // ── API عام ───────────────────────────────────────────────────────────
        public void SetItems(List<ItemCard> items, bool isLoading = false)
        {
            _isLoading = isLoading;
            _items = items ?? new List<ItemCard>();
            _selectedIdx = -1;
            _hoverIdx = -1;
            AutoScrollPosition = Point.Empty;
            Recalculate();
            StartLazyLoad();
            Invalidate();
        }

        public void SetLoadingDone() { _isLoading = false; Invalidate(); }

        public void SelectCard(ItemCard card)
        {
            var idx = _items.IndexOf(card);
            if (idx < 0) return;
            _selectedIdx = idx;
            ScrollToCard(idx);
            Invalidate();
        }

        public void RefreshCard(ItemCard card)
        {
            ImageCache.Evict(card.ImagePath);
            _loadingPaths.Remove(card.ImagePath ?? "");
            StartLazyLoad();
            Invalidate();
        }

        // ── حساب الأبعاد ──────────────────────────────────────────────────────
        private void Recalculate()
        {
            _cols = Math.Max(1, (Width - MARGIN) / (CARD_W + MARGIN));
            int rows = (_items.Count + _cols - 1) / Math.Max(1, _cols);
            _totalHeight = rows * (CARD_H + MARGIN) + MARGIN;
            AutoScrollMinSize = new Size(0, _totalHeight);
            Invalidate();
        }

        private void ScrollToCard(int idx)
        {
            int row = idx / Math.Max(1, _cols);
            int y = row * (CARD_H + MARGIN) + MARGIN;
            AutoScrollPosition = new Point(0, Math.Max(0,
                Math.Min(y - Height / 3, _totalHeight - Height)));
        }

        // ── Lazy Load ──────────────────────────────────────────────────────────
        private void StartLazyLoad()
        {
            _lazyCts?.Cancel();
            _lazyCts = new CancellationTokenSource();
            var token = _lazyCts.Token;
            var (from, count) = GetVisibleRange();

            var toLoad = _items
                .Skip(Math.Max(0, from - _cols * 2))
                .Take(count + _cols * 4)
                .Where(c => !string.IsNullOrEmpty(c.ImagePath)
                         && File.Exists(c.ImagePath)
                         && !ImageCache.TryGet(c.ImagePath, out _)
                         && !_loadingPaths.Contains(c.ImagePath))
                .Select(c => c.ImagePath)
                .ToList();

            foreach (var path in toLoad)
            {
                _loadingPaths.Add(path);
                var p = path;
                Task.Run(() =>
                {
                    if (token.IsCancellationRequested) return;
                    var img = LoadAndCompress(p, THUMB_W, THUMB_H);
                    if (img != null) ImageCache.Set(p, img);
                    _loadingPaths.Remove(p);
                    if (!token.IsCancellationRequested && !IsDisposed)
                        BeginInvoke(new Action(Invalidate));
                }, token);
            }
        }

        public static Image LoadAndCompress(string path, int tw, int th)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
            try
            {
                using (var src = Image.FromFile(path))
                {
                    float r = Math.Max((float)tw / src.Width, (float)th / src.Height);
                    int nw = (int)(src.Width * r);
                    int nh = (int)(src.Height * r);
                    var bmp = new Bitmap(tw, th, PixelFormat.Format32bppArgb);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.CompositingQuality = CompositingQuality.HighSpeed;
                        g.InterpolationMode = InterpolationMode.Bilinear;
                        g.SmoothingMode = SmoothingMode.HighSpeed;
                        g.DrawImage(src, (tw - nw) / 2, (th - nh) / 2, nw, nh);
                    }
                    return bmp;
                }
            }
            catch { return null; }
        }

        // ── نطاق مرئي ─────────────────────────────────────────────────────────
        private (int from, int count) GetVisibleRange()
        {
            int scroll = -AutoScrollPosition.Y;
            int cols = Math.Max(1, _cols);
            int from = Math.Max(0, (scroll / (CARD_H + MARGIN)) * cols);
            int rows = (Height / (CARD_H + MARGIN)) + 2;
            int count = Math.Min(_items.Count - from, rows * cols);
            return (from, Math.Max(0, count));
        }

        // ── رسم البطاقات ──────────────────────────────────────────────────────
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(C_BG);

            if (_isLoading) { DrawSkeletons(g); return; }
            if (_items.Count == 0) { DrawEmpty(g); return; }

            int scroll = -AutoScrollPosition.Y;
            var (from, count) = GetVisibleRange();

            for (int i = from; i < from + count && i < _items.Count; i++)
            {
                int col = i % Math.Max(1, _cols);
                int row = i / Math.Max(1, _cols);
                int x = MARGIN + col * (CARD_W + MARGIN);
                int y = MARGIN + row * (CARD_H + MARGIN) - scroll;
                if (y + CARD_H < 0 || y > Height) continue;
                DrawCard(g, _items[i], x, y, i == _selectedIdx, i == _hoverIdx);
            }
        }

        // ── رسم بطاقة واحدة ───────────────────────────────────────────────────
        private void DrawCard(Graphics g, ItemCard card, int x, int y, bool sel, bool hov)
        {
            var rc = new Rectangle(x + 2, y + 2, CARD_W - 4, CARD_H - 4);

            // ظل
            if (sel || hov)
                using (var shd = new SolidBrush(Color.FromArgb(22, 26, 115, 232)))
                    FillRR(g, shd, new Rectangle(rc.X + 3, rc.Y + 5, rc.Width, rc.Height), RAD);

            // خلفية
            var bg = sel ? C_CARD_S : (hov ? C_CARD_H : C_CARD);
            FillRR(g, new SolidBrush(bg), rc, RAD);

            // حدود
            if (sel)
            {
                DrawRR(g, new Pen(Color.FromArgb(90, 155, 228), 5f), rc, RAD);
                DrawRR(g, new Pen(C_BDR_S, 2f), rc, RAD);
            }
            else
                DrawRR(g, new Pen(hov ? C_BDR_H : C_BDR, 1f), rc, RAD);

            // الصورة
            var imgRc = new Rectangle(rc.X + 8, rc.Y + 8, rc.Width - 16, IMG_H);
            DrawImage(g, card, imgRc, hov);

            // الاسم
            var nameRc = new RectangleF(rc.X + 4, rc.Y + IMG_H + 12, rc.Width - 8, 34);
            using (var f = new Font("Cairo", 10f, FontStyle.Bold))
            using (var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisWord,
                FormatFlags = StringFormatFlags.LineLimit
            })
                g.DrawString(card.NameAR, f, new SolidBrush(C_TXT), nameRc, sf);

            // الكود
            if (!string.IsNullOrEmpty(card.Code))
            {
                var codeRc = new RectangleF(rc.X + 4, nameRc.Bottom + 1, rc.Width - 8, 14);
                using (var f = new Font("Consolas", 7f))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                    g.DrawString(card.Code, f, new SolidBrush(C_CODE), codeRc, sf);
            }

            // ── شريط المخزون ──────────────────────────────────────────────────
            DrawStockBar(g, card, rc);

            // علامة التحديد ✔
            if (sel)
            {
                var ck = new Rectangle(rc.Right - 22, rc.Y + 6, 17, 17);
                FillRR(g, new SolidBrush(C_BDR_S), ck, 9);
                using (var f = new Font("Arial", 8f, FontStyle.Bold))
                using (var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                    g.DrawString("✔", f, Brushes.White, ck, sf);
            }
        }

        /// <summary>رسم شريط المخزون في أسفل البطاقة</summary>
        private void DrawStockBar(Graphics g, ItemCard card, Rectangle rc)
        {
            const int barH = 18;
            const int barMrg = 5;

            var barRc = new Rectangle(
                rc.X + barMrg,
                rc.Bottom - barH - barMrg,
                rc.Width - barMrg * 2,
                barH);

            // اختيار اللون حسب الكمية
            Color bgColor, txtColor;
            string label;

            if (!card.StockLoaded)
            {
                // لم يُجلب بعد — رمادي خفيف
                bgColor = Color.FromArgb(235, 237, 242);
                txtColor = Color.FromArgb(160, 170, 190);
                label = "";
            }
            else if (card.Stock <= 0m)
            {
                bgColor = C_STK_BG_ZERO;
                txtColor = C_STK_ZERO;
                label = "نفذ المخزون  ✖";
            }
            else if (card.Stock < 5m)
            {
                bgColor = C_STK_BG_LOW;
                txtColor = C_STK_LOW;
                label = $"مخزون: {card.Stock:N0}  ⚠";
            }
            else
            {
                bgColor = C_STK_BG_OK;
                txtColor = C_STK_OK;
                label = $"مخزون: {card.Stock:N0}  ✔";
            }

            FillRR(g, new SolidBrush(bgColor), barRc, 5);
            DrawRR(g, new Pen(Color.FromArgb(30, txtColor), 1f), barRc, 5);

            using (var f = new Font("Cairo", 7.5f, FontStyle.Bold))
            using (var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
                g.DrawString(label, f, new SolidBrush(txtColor), barRc, sf);
        }

        private void DrawImage(Graphics g, ItemCard card, Rectangle imgRc, bool hover)
        {
            using (var clip = RRect(imgRc, 7))
            {
                g.SetClip(clip);
                bool hasImg = !string.IsNullOrEmpty(card.ImagePath);
                Image thumb = null;
                if (hasImg) ImageCache.TryGet(card.ImagePath, out thumb);

                if (thumb != null)
                {
                    g.DrawImage(thumb, imgRc);
                }
                else if (hasImg && _loadingPaths.Contains(card.ImagePath))
                {
                    DrawShimmer(g, imgRc);
                }
                else
                {
                    g.FillPath(new SolidBrush(C_IMG_BG), clip);
                    using (var f = new Font("Segoe UI Emoji", 22f))
                    using (var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                        g.DrawString("📷", f, new SolidBrush(C_CAM), imgRc, sf);

                    if (hover)
                    {
                        var hint = new RectangleF(imgRc.X, imgRc.Bottom - 20, imgRc.Width, 20);
                        g.FillRectangle(new SolidBrush(Color.FromArgb(175, 26, 115, 232)), hint);
                        using (var f = new Font("Cairo", 7f, FontStyle.Bold))
                        using (var sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        })
                            g.DrawString("كليك يمين ← إضافة صورة", f, Brushes.White, hint, sf);
                    }
                }
                g.ResetClip();
            }
            DrawRR(g, new Pen(Color.FromArgb(18, 0, 0, 0), 1f), imgRc, 7);
        }

        // ── Skeleton ──────────────────────────────────────────────────────────
        private void DrawSkeletons(Graphics g)
        {
            int vc = Math.Max(1, (Width - MARGIN) / (CARD_W + MARGIN));
            int vr = Math.Max(1, (Height - MARGIN) / (CARD_H + MARGIN)) + 1;

            for (int row = 0; row < vr; row++)
                for (int col = 0; col < vc; col++)
                {
                    int x = MARGIN + col * (CARD_W + MARGIN);
                    int y = MARGIN + row * (CARD_H + MARGIN);
                    var rc = new Rectangle(x + 2, y + 2, CARD_W - 4, CARD_H - 4);
                    FillRR(g, new SolidBrush(Color.White), rc, RAD);
                    DrawRR(g, new Pen(C_BDR, 1f), rc, RAD);
                    DrawShimmer(g, new Rectangle(rc.X + 8, rc.Y + 8, rc.Width - 16, IMG_H));
                    DrawSkeletonLine(g, rc.X + 20, rc.Y + IMG_H + 14, rc.Width - 40, 11);
                    DrawSkeletonLine(g, rc.X + 40, rc.Y + IMG_H + 32, rc.Width - 80, 7);
                    DrawSkeletonLine(g, rc.X + 8, rc.Bottom - 22, rc.Width - 16, 14);
                }
        }

        private void DrawShimmer(Graphics g, Rectangle rc)
        {
            float p = (float)((Math.Sin(_skelPhase) + 1) / 2.0);
            var c = Color.FromArgb(
                (int)(C_SKEL1.R + (C_SKEL2.R - C_SKEL1.R) * p),
                (int)(C_SKEL1.G + (C_SKEL2.G - C_SKEL1.G) * p),
                (int)(C_SKEL1.B + (C_SKEL2.B - C_SKEL1.B) * p));
            g.FillRectangle(new SolidBrush(c), rc);
            int sx = rc.X + (int)((rc.Width + 100) * ((float)(Math.Sin(_skelPhase * 0.5f) + 1) / 2.0)) - 50;
            using (var br = new LinearGradientBrush(
                new Rectangle(sx, rc.Y, 60, Math.Max(1, rc.Height)),
                Color.FromArgb(0, 255, 255, 255),
                Color.FromArgb(80, 255, 255, 255),
                LinearGradientMode.Horizontal))
                g.FillRectangle(br, sx, rc.Y, 60, rc.Height);
        }

        private void DrawSkeletonLine(Graphics g, int x, int y, int w, int h)
        {
            float p = (float)((Math.Sin(_skelPhase) + 1) / 2.0);
            var c = Color.FromArgb(
                (int)(C_SKEL1.R + (C_SKEL2.R - C_SKEL1.R) * p),
                (int)(C_SKEL1.G + (C_SKEL2.G - C_SKEL1.G) * p),
                (int)(C_SKEL1.B + (C_SKEL2.B - C_SKEL1.B) * p));
            FillRR(g, new SolidBrush(c), new Rectangle(x, y, Math.Max(1, w), Math.Max(1, h)), h / 2);
        }

        private void DrawEmpty(Graphics g)
        {
            using (var f = new Font("Cairo", 14f, FontStyle.Bold))
            using (var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
                g.DrawString("لا توجد نتائج 🔍", f,
                    new SolidBrush(Color.FromArgb(178, 188, 210)), ClientRectangle, sf);
        }

        // ── Mouse ─────────────────────────────────────────────────────────────
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            _lastMouse = e.Location;
            int idx = IndexAt(e.Location);
            if (idx != _hoverIdx) { _hoverIdx = idx; Invalidate(); }
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var card = GetCardAt(e.Location);
            if (card == null) return;
            _selectedIdx = _items.IndexOf(card);
            Invalidate();
            CardClicked?.Invoke(card);
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta > 0 ? -70 : 70;
            var pos = AutoScrollPosition;
            AutoScrollPosition = new Point(0, Math.Max(0, -pos.Y + delta));
            StartLazyLoad();
        }

        private int IndexAt(Point pt)
        {
            int scroll = -AutoScrollPosition.Y;
            for (int i = 0; i < _items.Count; i++)
            {
                int col = i % Math.Max(1, _cols);
                int row = i / Math.Max(1, _cols);
                int x = MARGIN + col * (CARD_W + MARGIN);
                int y = MARGIN + row * (CARD_H + MARGIN) - scroll;
                if (new Rectangle(x, y, CARD_W, CARD_H).Contains(pt)) return i;
            }
            return -1;
        }

        private ItemCard GetCardAt(Point pt)
        {
            int i = IndexAt(pt);
            return i >= 0 ? _items[i] : null;
        }

        // ── Override Scroll ───────────────────────────────────────────────────
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            StartLazyLoad();
            Invalidate();
        }

        // ── GDI+ helpers ─────────────────────────────────────────────────────
        private static GraphicsPath RRect(Rectangle r, int rad)
        {
            int d = rad * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        private static void FillRR(Graphics g, Brush b, Rectangle r, int rad)
        { using (var p = RRect(r, rad)) g.FillPath(b, p); }

        private static void DrawRR(Graphics g, Pen pen, Rectangle r, int rad)
        { using (var p = RRect(r, rad)) g.DrawPath(pen, p); }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _lazyCts?.Cancel();
                _skelTimer?.Stop();
                _skelTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    // =========================================================================
    //  الفورم الرئيسي
    // =========================================================================
    public class FRM_ImagePicker : Form
    {
        // ── خصائص النتيجة ─────────────────────────────────────────────────────
        public int IN_OUT_STOCK = 0;
        public int IDValue { get; private set; }
        public string NameValue { get; private set; }
        public decimal numberValue { get; private set; }
        public string gatgoryValue { get; private set; }
        public string formmValue { get; private set; }

        // ── ألوان ─────────────────────────────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(238, 243, 250);
        private static readonly Color C_DARK = Color.FromArgb(18, 28, 50);
        private static readonly Color C_BLUE = Color.FromArgb(26, 115, 232);
        private static readonly Color C_GREEN = Color.FromArgb(34, 154, 60);
        private static readonly Color C_RED = Color.FromArgb(210, 48, 65);
        private static readonly Color C_WHITE = Color.White;
        private static readonly Color C_SEP = Color.FromArgb(213, 221, 234);
        private static readonly Color C_HDR = Color.FromArgb(226, 235, 252);

        // ── كونترولات ─────────────────────────────────────────────────────────
        private Panel pnlTop, pnlSearch, pnlMain, pnlDetail, pnlBottom;
        private VirtualCardPanel virtualPanel;
        private Label lblTitle, lblCount, lblLoading, lblSelected;
        private TextBox txtSearch, txtQty;
        private ComboBox cmbCat;
        private PictureBox picDetail;
        private Label lblDName, lblDCode, lblDCat, lblDForm, lblDStock;
        private RichTextBox rtbNotes;
        private Button btnAdd, btnClose;
        private ProgressBar progressBar;
        private BackgroundWorker bgw;

        // ── بيانات ────────────────────────────────────────────────────────────
        private List<ItemCard> _all = new List<ItemCard>();
        private ItemCard _selected;

        // ── Debounce للبحث ────────────────────────────────────────────────────
        private System.Windows.Forms.Timer _searchTimer;

        // ─────────────────────────────────────────────────────────────────────
        public FRM_ImagePicker()
        {
            ImageStore.EnsureFolder();
            BuildUI();
            InitWorker();
        }

        // =========================================================================
        //  بناء الواجهة
        // =========================================================================
        private void BuildUI()
        {
            Text = "اختيار المواد بالصور";
            Size = new Size(1230, 900);
            MinimumSize = new Size(1230, 900);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = C_BG;
            Font = new Font("Cairo", 10f);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            FormBorderStyle = FormBorderStyle.Sizable;
  

            _searchTimer = new System.Windows.Forms.Timer { Interval = 200 };
            _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); ApplyFilter(); };

            BuildHeader();
            BuildSearchBar();
            BuildMainArea();
            BuildBottomBar();

            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlSearch);
            Controls.Add(pnlTop);

            Load += (s, e) =>
            {

                lblLoading.Visible = true;
                progressBar.Visible = true;
                virtualPanel.SetItems(new List<ItemCard>(), isLoading: true);
                bgw.RunWorkerAsync();
            };
        }

        // ── Header ────────────────────────────────────────────────────────────
        private void BuildHeader()
        {
            pnlTop = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = C_DARK };
            pnlTop.Controls.Add(new Label
            {
                Text = "🖼️   اختيار المواد بالصور",
                ForeColor = Color.White,
                Font = new Font("Cairo", 14f, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        // ── Search Bar ────────────────────────────────────────────────────────
        private void BuildSearchBar()
        {
            pnlSearch = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = C_WHITE };
            pnlSearch.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(C_SEP), 0, pnlSearch.Height - 1, pnlSearch.Width, pnlSearch.Height - 1);

            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                RowCount = 1,
                BackColor = C_WHITE,
                Padding = new Padding(10, 0, 10, 0)
            };
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28f));

            tbl.Controls.Add(new Label
            {
                Text = "🔍",
                Font = new Font("Segoe UI Emoji", 13f),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = Padding.Empty
            }, 0, 0);

            txtSearch = new TextBox
            {
                Font = new Font("Cairo", 13f, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Height = 28,
                Margin = new Padding(2, 11, 2, 11)
            };
            txtSearch.TextChanged += (s, e) => { _searchTimer.Stop(); _searchTimer.Start(); };
            tbl.Controls.Add(txtSearch, 1, 0);

            tbl.Controls.Add(new Label
            {
                Text = "الصنف:",
                Font = new Font("Cairo", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 85, 115),
                
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = Padding.Empty
            }, 2, 0);

            cmbCat = new ComboBox
            {
                Font = new Font("Cairo", 13f, FontStyle.Bold),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Height = 28,
                Margin = new Padding(2, 11, 2, 11)
            };
            cmbCat.Items.Add("جميع الأصناف");
            cmbCat.SelectedIndex = 0;
            cmbCat.SelectedIndexChanged += (s, e) => ApplyFilter();
            tbl.Controls.Add(cmbCat, 3, 0);

            var pnlInfo = new Panel { Dock = DockStyle.Fill, BackColor = C_WHITE, Margin = Padding.Empty };
            lblCount = new Label
            {
                Text = "",
                Font = new Font("Cairo", 12f, FontStyle.Bold),
                ForeColor = C_BLUE,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            lblLoading = new Label
            {
                Text = "⏳  جاري التحميل...",
                Font = new Font("Cairo", 9.5f, FontStyle.Bold),
                ForeColor = C_BLUE,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            pnlInfo.Controls.Add(lblCount);
            pnlInfo.Controls.Add(lblLoading);
            tbl.Controls.Add(pnlInfo, 4, 0);

            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Height = 3,
                Dock = DockStyle.Bottom,
                Visible = false
            };

            pnlSearch.Controls.Add(tbl);
            pnlSearch.Controls.Add(progressBar);
        }

        // ── Main Area ─────────────────────────────────────────────────────────
        private void BuildMainArea()
        {
            pnlMain = new Panel { Dock = DockStyle.Fill, BackColor = C_BG };

            pnlDetail = new Panel { Dock = DockStyle.Right, Width = 300, BackColor = C_WHITE };
            pnlDetail.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(C_SEP), 0, 0, 0, pnlDetail.Height);

            BuildDetailPanel();

            virtualPanel = new VirtualCardPanel { Dock = DockStyle.Fill };
            virtualPanel.CardClicked += OnCardClick;
            virtualPanel.ImgChangeReq += OnImgChange;
            virtualPanel.ImgDeleteReq += OnImgDelete;

            pnlMain.Controls.Add(virtualPanel);
            pnlMain.Controls.Add(pnlDetail);
        }

        // ── Detail Panel ──────────────────────────────────────────────────────
        private void BuildDetailPanel()
        {
            var hdr = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = C_HDR };
            hdr.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(C_SEP), 0, hdr.Height - 1, hdr.Width, hdr.Height - 1);

            hdr.Controls.Add(new Label
            {
                Text = "📋   تفاصيل المادة",
                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
                ForeColor = C_DARK,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
            });

            pnlDetail.Controls.Add(hdr);

            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 6,
                BackColor = C_WHITE,
                Padding = new Padding(5, 65, 5, 11)
            };

            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 172f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 38f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 2f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 130f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            // الصورة
            picDetail = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(228, 234, 248),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 6)
            };
            tbl.Controls.Add(picDetail, 0, 0);

            // الاسم
            lblDName = new Label
            {
                Text = "اختر مادة من القائمة",
                Font = new Font("Cairo", 11.5f, FontStyle.Bold),
                ForeColor = C_DARK,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = Padding.Empty
            };
            tbl.Controls.Add(lblDName, 0, 1);

            // خط فاصل
            tbl.Controls.Add(new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = C_SEP,
                Margin = new Padding(0, 2, 0, 4)
            }, 0, 2);

            // 📌 لوحة المعلومات (يمين عنوان - يسار قيمة)
            var infoTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                RightToLeft = RightToLeft.Yes,
                BackColor = C_WHITE
            };

            infoTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f)); // العنوان
            infoTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f)); // القيمة

            for (int i = 0; i < 4; i++)
                infoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));

            // الصفوف
            AddInfoRow(infoTable, 0, "الكود:", out lblDCode);
            AddInfoRow(infoTable, 1, "الصنف:", out lblDCat);
            AddInfoRow(infoTable, 2, "التجزئة:", out lblDForm);
            AddInfoRow(infoTable, 3, "المخزون:", out lblDStock, true);

            tbl.Controls.Add(infoTable, 0, 3);

            // ملاحظات
            tbl.Controls.Add(new Label
            {
                Text = "ملاحظات:",
                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(118, 130, 158),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0)
            }, 0, 4);

            rtbNotes = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.FromArgb(246, 249, 255),
                Font = new Font("Cairo", 8.5f),
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Margin = new Padding(0, 0, 0, 4)
            };
            tbl.Controls.Add(rtbNotes, 0, 5);

            pnlDetail.Controls.Add(tbl);

            ResetDetail();
        }

        private void AddInfoRow(TableLayoutPanel tbl, int rowIndex, string title, out Label valueLabel, bool highlight = false)
        {
            var lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Fill,
                Font = new Font("Cairo", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 96, 130),
                TextAlign = ContentAlignment.MiddleLeft
            };

            valueLabel = new Label
            {
                Text = "—",
                Dock = DockStyle.Fill,
                Font = new Font("Cairo", 9.5f, FontStyle.Bold),
                ForeColor = C_DARK,
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = highlight ? Color.FromArgb(238, 246, 255) : Color.Transparent
            };

            tbl.Controls.Add(lblTitle, 0, rowIndex);  // يمين
            tbl.Controls.Add(valueLabel, 1, rowIndex); // يسار
        }

      

        // ── Bottom Bar ────────────────────────────────────────────────────────
        private void BuildBottomBar()
        {
            pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 70, BackColor = C_WHITE };
            pnlBottom.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(C_SEP), 0, 0, pnlBottom.Width, 0);

            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                RowCount = 1,
                BackColor = C_WHITE,
                Padding = new Padding(12, 0, 12, 0)
            };
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115f));

            lblSelected = new Label
            {
                Text = "لم يتم اختيار مادة",
                ForeColor = Color.FromArgb(158, 168, 188),
                Font = new Font("Cairo", 9.5f, FontStyle.Italic),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = Padding.Empty
            };
            tbl.Controls.Add(lblSelected, 0, 0);

            tbl.Controls.Add(new Label
            {
                Text = "الكمية:",
                Font = new Font("Cairo", 12f, FontStyle.Bold),
                ForeColor = C_BLUE,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = Padding.Empty
            }, 1, 0);

            txtQty = new TextBox
            {
                Text = "0",
                Font = new Font("Cairo", 13f, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Height = 34,
                
                Margin = new Padding(3, 13, 3, 13)
            };
            txtQty.Click += (s, e) => txtQty.SelectAll();
            txtQty.KeyPress += ValidateQty;
            txtQty.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnAdd_Click(null, null); }
            };
            tbl.Controls.Add(txtQty, 2, 0);

            btnAdd = MkBtn("✔  إضافة", C_GREEN, new Padding(6, 12, 6, 12));
            btnClose = MkBtn("✖  إغلاق", C_RED, new Padding(4, 12, 4, 12));
            btnAdd.Click += BtnAdd_Click;
            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            tbl.Controls.Add(btnAdd, 3, 0);
            tbl.Controls.Add(btnClose, 4, 0);
            pnlBottom.Controls.Add(tbl);
        }

        private Button MkBtn(string text, Color bg, Padding margin)
        {
            var b = new Button
            {
                Text = text,
                BackColor = bg,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cairo", 10.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                
                Margin = margin,
                
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        // =========================================================================
        //  BackgroundWorker — يجلب المواد والمخزون معاً في خيط واحد
        // =========================================================================
        private void InitWorker()
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerCompleted += Bgw_Done;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = new List<ItemCard>();
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    // ── جلب جميع المواد ───────────────────────────────────────
                    var groups = db.TB_groups
                        .ToDictionary(g => g.groups_id, g => g.groups_name ?? "");

                    foreach (var it in db.TB_items.ToList())
                    {
                        if (string.IsNullOrWhiteSpace(it.items_name)) continue;

                        string cat = it.groups_id.HasValue &&
                                     groups.ContainsKey(it.groups_id.Value)
                                     ? groups[it.groups_id.Value] : "";

                        list.Add(new ItemCard
                        {
                            ID = it.items_id,
                            NameAR = it.items_name.Trim(),
                            Code = it.items_code ?? "",
                            Category = cat,
                            Form = it.items_form ?? "",
                            Notes = it.items_nots ?? "",
                            ImagePath = ImageStore.Find(it.items_id) ?? "",
                            Stock = -1m   // لم يُجلب بعد
                        });
                    }
                }
            }
            catch (Exception ex) { e.Result = ex; return; }
            e.Result = list;
        }

        private void Bgw_Done(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            lblLoading.Visible = false;
            lblCount.Visible = true;

            if (e.Result is Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات:\n" + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _all = e.Result as List<ItemCard> ?? new List<ItemCard>();

            cmbCat.Items.Clear();
            cmbCat.Items.Add("جميع الأصناف");
            foreach (var c in _all.Select(x => x.Category)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct().OrderBy(x => x))
                cmbCat.Items.Add(c);
            cmbCat.SelectedIndex = 0;

            virtualPanel.SetLoadingDone();
            ShowCards(_all);
        }

        // =========================================================================
        //  عرض البطاقات
        // =========================================================================
        private void ShowCards(List<ItemCard> items)
        {
            virtualPanel.SetItems(items);
            lblCount.Text = $"({items.Count} مادة)";
        }

        private void ApplyFilter()
        {
            if (_all.Count == 0) return;
            var q = txtSearch.Text.Trim().ToLower();
            var cat = cmbCat.SelectedItem?.ToString() ?? "جميع الأصناف";
            var res = _all.Where(x =>
                (string.IsNullOrEmpty(q) ||
                 x.NameAR.ToLower().Contains(q) ||
                 x.Code.ToLower().Contains(q)) &&
                (cat == "جميع الأصناف" || x.Category == cat)
            ).ToList();
            ShowCards(res);
        }

        // =========================================================================
        //  اختيار بطاقة
        // =========================================================================
        private void OnCardClick(ItemCard data)
        {
            _selected = data;
            lblSelected.Text = $"✔  {data.NameAR}";
            lblSelected.ForeColor = C_BLUE;

            // ★ جلب المخزون من DB عند اختيار المادة
            // ★ إعادة جلب المخزون لحظة الإضافة (تأكد من أحدث قيمة)
            if (IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11)
                FetchStock(data);

            // تحديث البطاقة في اللوحة لإظهار المخزون فوراً
            virtualPanel.Invalidate();

            ShowDetail(data);
            txtQty.Text = "1";
            txtQty.Focus();
            txtQty.SelectAll();
        }

        // =========================================================================
        //  إدارة الصور
        // =========================================================================
        private void OnImgChange(ItemCard data, VirtualCardPanel panel)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = $"اختر صورة للمادة: {data.NameAR}";
                dlg.Filter = "صور|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                try
                {
                    var newPath = ImageStore.Save(data.ID, dlg.FileName);
                    data.ImagePath = newPath;
                    panel.RefreshCard(data);
                    if (_selected?.ID == data.ID)
                        picDetail.Image = LoadForDetail(newPath);
                    MessageBox.Show($"✔  تم حفظ صورة المادة:\n{data.NameAR}",
                        "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ:\n" + ex.Message,
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnImgDelete(ItemCard data, VirtualCardPanel panel)
        {
            if (string.IsNullOrEmpty(data.ImagePath))
            {
                MessageBox.Show("لا توجد صورة للمادة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"حذف صورة:\n{data.NameAR}؟",
                    "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                VirtualCardPanel.ImageCache.Evict(data.ImagePath);
                ImageStore.Delete(data.ID);
                data.ImagePath = "";
                panel.RefreshCard(data);
                if (_selected?.ID == data.ID) picDetail.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ:\n" + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        //  التفاصيل
        // =========================================================================
        private void ShowDetail(ItemCard d)
        {
            picDetail.Image = LoadForDetail(d.ImagePath);
            lblDName.Text = d.NameAR;
            lblDCode.Text = Dash(d.Code);
            lblDCat.Text = Dash(d.Category);
            lblDForm.Text = Dash(d.Form);
            rtbNotes.Text = d.Notes;

            // عرض المخزون بلون دلالي
            if (!d.StockLoaded)
            {
                lblDStock.Text = "⏳  جارٍ التحميل...";
                lblDStock.ForeColor = Color.FromArgb(140, 155, 180);
            }
            else if (d.Stock <= 0m)
            {
                lblDStock.Text = "نفذ المخزون  ✖";
                lblDStock.ForeColor = C_RED;
            }
            else if (d.Stock < 5m)
            {
                lblDStock.Text = $"{d.Stock:N2}  ⚠  (كمية منخفضة)";
                lblDStock.ForeColor = Color.FromArgb(200, 120, 0);
            }
            else
            {
                lblDStock.Text = $"{d.Stock:N2}  ✔";
                lblDStock.ForeColor = C_GREEN;
            }
        }

        private void ResetDetail()
        {
            if (picDetail != null) picDetail.Image = null;
            if (lblDName != null) lblDName.Text = "اختر مادة من القائمة";
            if (lblDCode != null) lblDCode.Text = "—";
            if (lblDCat != null) lblDCat.Text = "—";
            if (lblDForm != null) lblDForm.Text = "—";
            if (lblDStock != null) { lblDStock.Text = "—"; lblDStock.ForeColor = Color.Gray; }
            if (rtbNotes != null) rtbNotes.Text = "";
        }

        private static string Dash(string v) => string.IsNullOrEmpty(v) ? "—" : v;

        private static Image LoadForDetail(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
            try { return Image.FromFile(path); } catch { return null; }
        }

        // =========================================================================
        //  جلب المخزون من DB لمادة واحدة
        // =========================================================================
        

        private void FetchStock(ItemCard card)
        {
            if (card == null) return;
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    // استدعاء الـ Stored Procedure مباشرةً
                    var result = db.Database.SqlQuery<decimal>("EXEC dbo.GetItemStored @ItemId", new SqlParameter("@ItemId", card.ID)).FirstOrDefault();
                    card.Stock = result;
                }
            }
            catch
            {
                card.Stock = 0m;
            }
        }



        // =========================================================================
        //  زر الإضافة — التحقق من المخزون قبل الإغلاق
        // =========================================================================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("الرجاء اختيار مادة أولاً.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtQty.Text, out decimal qty) || qty <= 0)
            {
                MessageBox.Show("الرجاء إدخال كمية صحيحة (أكبر من صفر).",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                txtQty.SelectAll();
                return;
            }

            // ★ إعادة جلب المخزون لحظة الإضافة (تأكد من أحدث قيمة)
            if (IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11)
                FetchStock(_selected);


            // التحقق من المخزون (للصادر والإتلاف فقط)
            if (IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11)
            {
                if (_selected.Stock <= 0m)
                {
                    MessageBox.Show(
                        $"المادة ({_selected.NameAR}) غير متوفرة في المخزون.",
                        "مخزون فارغ ✖", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_selected.Stock < qty)
                {
                    MessageBox.Show(
                        $"الكمية المطلوبة ({qty:N2}) أكبر من المخزون المتاح ({_selected.Stock:N2}).\n\n" +
                        $"المادة: {_selected.NameAR}",
                        "مخزون غير كافٍ ⚠", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            IDValue = _selected.ID;
            NameValue = _selected.NameAR;
            numberValue = qty;
            gatgoryValue = _selected.Category;
            formmValue = _selected.Form;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ValidateQty(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && txtQty.Text.Contains('.'))
                e.Handled = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _searchTimer?.Dispose();
            VirtualCardPanel.ImageCache.Clear();
            base.OnFormClosed(e);
        }
    }
}