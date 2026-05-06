using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ALIBA_COMPANY.AddPage;

namespace ALIBA_COMPANY
{
    public partial class FRM_Permissions : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<string> _roles = new List<string>
        {
            "موزع", "مسؤول الموزعيين", "امين مخزن",
            "مدير حسابات", "حسابات", "اداري", "مدير"
        };

        private readonly Dictionary<string, string> _permissionLabels = new Dictionary<string, string>
        {
            ["استيراد_سفرة"] = "📥 استيراد سفرة",
            ["تحديث_بيانات"] = "🔄 تحديث البيانات",
            ["حذف_استيراد"] = "🗑 حذف بيانات الاستيراد",
            ["ارسال_سفرة"] = "📤 إرسال السفرة",
            ["اضافة_وصل_بيع"] = "🧾 إضافة وصل بيع",
            ["عرض_وصولات"] = "📋 عرض الوصولات",
            ["عرض_مرتجعات"] = "↩ عرض المرتجعات",
            ["تحصيل_نقدي"] = "💰 تحصيل نقدي",
            ["عرض_مواد"] = "📦 عرض المواد",
            ["ادارة_مستخدمين"] = "👤 إدارة المستخدمين",
            ["تقارير_مبيعات"] = "📊 تقارير المبيعات",
            ["ادارة_سفرات"] = "🚗 إدارة السفرات",
            ["حركة_مخزن"] = "🏭 حركة المخزن",
            ["اعداد_النظام"] = "⚙ إعدادات النظام",
            ["ادارة_حسابات"] = "💳 إدارة الحسابات",
            ["ادارة_مواد"] = "🗂 إدارة المواد",
        };

        // الصلاحيات الافتراضية (للـ Reset)
        private Dictionary<string, bool> _defaultPermissions = new Dictionary<string, bool>();
        private Dictionary<string, bool> _currentPermissions = new Dictionary<string, bool>();
        private string _selectedRole = "";

        // ===== UI Controls =====
        private Panel _panelLeft, _panelRight, _panelHeader, _panelFooter, _panelPermissions;
        private ListBox _lstRoles;
        private Label _lblRoleTitle;
        private SimpleButton _btnSave, _btnClose, _btnSelectAll, _btnClearAll, _btnReset;

        public FRM_Permissions()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.Text = "إدارة الصلاحيات";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 1000);
            this.MinimumSize = new Size(800, 550);
            BuildUI();
        }

        // ===== بناء الواجهة =====
        private void BuildUI()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);

            // Header
            _panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(30, 60, 114),
                Padding = new Padding(15, 0, 15, 0)
            };
            _panelHeader.Controls.Add(new Label
            {
                Text = "إدارة صلاحيات الأدوار",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 18)
            });
            _panelHeader.Controls.Add(new Label
            {
                Text = $"المستخدم: {Users.FullName}  |  الدور: {Users.userRole}",
                ForeColor = Color.FromArgb(180, 210, 255),
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(15, 48)
            });

            // Footer
            _panelFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            _btnSave = new SimpleButton
            {
                Text = "💾 حفظ الصلاحيات",
                Width = 160,
                Height = 38,
                Location = new Point(15, 11),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Appearance = { BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White }
            };
            _btnSave.Click += BtnSave_Click;

            _btnClose = new SimpleButton
            {
                Text = "✖ إغلاق",
                Width = 110,
                Height = 38,
                Location = new Point(185, 11),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Appearance = { BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White }
            };
            _btnClose.Click += (s, e) => this.Close();

            _panelFooter.Controls.Add(_btnSave);
            _panelFooter.Controls.Add(_btnClose);

            // Left Panel
            _panelLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 230,
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            _panelLeft.Controls.Add(new Label
            {
                Text = "الأدوار",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 114),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            });

            _lstRoles = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ItemHeight = 38,
                RightToLeft = RightToLeft.Yes
            };
            foreach (var r in _roles) _lstRoles.Items.Add(r);
            _lstRoles.SelectedIndexChanged += LstRoles_SelectedIndexChanged;
            _panelLeft.Controls.Add(_lstRoles);

            // Right Panel
            _panelRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 242, 245),
                Padding = new Padding(15)
            };

            _lblRoleTitle = new Label
            {
                Text = "اختر دوراً من القائمة",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 114),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 10, 0)
            };

            var panelActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.Transparent
            };

            _btnSelectAll = new SimpleButton
            {
                Text = "✔ تحديد الكل",
                Width = 120,
                Height = 34,
                Location = new Point(10, 8),
                Font = new Font("Segoe UI", 9),
                Appearance = { BackColor = Color.FromArgb(0, 123, 255), ForeColor = Color.White }
            };
            _btnSelectAll.Click += (s, e) => SetAllPermissions(true);

            _btnClearAll = new SimpleButton
            {
                Text = "✖ إلغاء الكل",
                Width = 110,
                Height = 34,
                Location = new Point(140, 8),
                Font = new Font("Segoe UI", 9),
                Appearance = { BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White }
            };
            _btnClearAll.Click += (s, e) => SetAllPermissions(false);

            _btnReset = new SimpleButton
            {
                Text = "🔁 إعادة الضبط",
                Width = 130,
                Height = 34,
                Location = new Point(260, 8),
                Font = new Font("Segoe UI", 9),
                Appearance = { BackColor = Color.FromArgb(255, 193, 7), ForeColor = Color.Black }
            };
            _btnReset.Click += BtnReset_Click;

            panelActions.Controls.Add(_btnSelectAll);
            panelActions.Controls.Add(_btnClearAll);
            panelActions.Controls.Add(_btnReset);

            _panelPermissions = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent
            };

            _panelRight.Controls.Add(_panelPermissions);
            _panelRight.Controls.Add(panelActions);
            _panelRight.Controls.Add(_lblRoleTitle);

            var splitter = new Splitter
            {
                Dock = DockStyle.Left,
                Width = 3,
                BackColor = Color.FromArgb(200, 210, 230)
            };

            this.Controls.Add(_panelRight);
            this.Controls.Add(splitter);
            this.Controls.Add(_panelLeft);
            this.Controls.Add(_panelFooter);
            this.Controls.Add(_panelHeader);

            if (_lstRoles.Items.Count > 0)
                _lstRoles.SelectedIndex = 0;
        }

        // ===== تحميل صلاحيات الدور من DB =====
        private void LoadPermissionsFromDB(string role)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var perms = db.TB_permissions
                        .AsNoTracking()
                        .Where(x => x.perm_role == role)
                        .ToList();

                    _currentPermissions.Clear();
                    _defaultPermissions.Clear();

                    // إذا لا يوجد في DB، استخدم false كافتراضي
                    foreach (var key in _permissionLabels.Keys)
                    {
                        var p = perms.FirstOrDefault(x => x.perm_key == key);
                        bool val = p != null && p.perm_allowed == true;
                        _currentPermissions[key] = val;
                        _defaultPermissions[key] = val; // للـ Reset
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في تحميل الصلاحيات: " + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== حفظ في DB =====
        private void SavePermissionsToDB(string role)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    // حذف القديمة
                    var old = db.TB_permissions.Where(x => x.perm_role == role).ToList();
                    db.TB_permissions.RemoveRange(old);

                    // إضافة الجديدة
                    foreach (var kv in _currentPermissions)
                    {
                        db.TB_permissions.Add(new TB_permissions
                        {
                            perm_role = role,
                            perm_key = kv.Key,
                            perm_allowed = kv.Value,
                        });
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("فشل الحفظ: " + ex.Message);
            }
        }

        // ===== اختيار دور =====
        private void LstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstRoles.SelectedItem == null) return;
            _selectedRole = _lstRoles.SelectedItem.ToString();
            _lblRoleTitle.Text = $"صلاحيات دور: {_selectedRole}";
            LoadPermissionsFromDB(_selectedRole);
            RenderPermissions();
        }

        // ===== رسم بطاقات الصلاحيات =====
        private void RenderPermissions()
        {
            if (_panelPermissions == null) return;
            _panelPermissions.Controls.Clear();
            if (string.IsNullOrEmpty(_selectedRole)) return;

            int yPos = 10;
            int cardWidth = Math.Max(_panelPermissions.ClientSize.Width - 30, 200);

            foreach (var key in _permissionLabels.Keys)
            {
                bool allowed = _currentPermissions.ContainsKey(key) && _currentPermissions[key];
                string label = _permissionLabels[key];
                var card = CreatePermissionCard(key, label, allowed, cardWidth, yPos);
                _panelPermissions.Controls.Add(card);
                yPos += card.Height + 8;
            }
        }

        private Panel CreatePermissionCard(string key, string label, bool allowed, int width, int yPos)
        {
            var card = new Panel
            {
                Location = new Point(10, yPos),
                Size = new Size(width, 50),
                BackColor = allowed ? Color.FromArgb(232, 245, 233) : Color.FromArgb(255, 243, 243),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = key
            };

            card.Controls.Add(new Label
            {
                Text = allowed ? "✔" : "✖",
                ForeColor = allowed ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(40, 40),
                Location = new Point(8, 5),
                TextAlign = ContentAlignment.MiddleCenter
            });

            card.Controls.Add(new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(40, 40, 40),
                Size = new Size(width - 150, 40),
                Location = new Point(55, 5),
                TextAlign = ContentAlignment.MiddleRight,
                RightToLeft = RightToLeft.Yes
            });

            var btn = new SimpleButton
            {
                Text = allowed ? "إلغاء الصلاحية" : "منح الصلاحية",
                Size = new Size(130, 32),
                Location = new Point(width - 145, 9),
                Font = new Font("Segoe UI", 9),
                Tag = key,
                Appearance =
                {
                    BackColor = allowed ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White
                }
            };
            btn.Click += (s, e) =>
            {
                string k = btn.Tag.ToString();
                _currentPermissions[k] = !(_currentPermissions.ContainsKey(k) && _currentPermissions[k]);
                RenderPermissions();
            };

            card.Controls.Add(btn);
            return card;
        }

        private void SetAllPermissions(bool value)
        {
            if (string.IsNullOrEmpty(_selectedRole)) return;
            foreach (var key in _permissionLabels.Keys.ToList())
                _currentPermissions[key] = value;
            RenderPermissions();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedRole)) return;
            _currentPermissions = new Dictionary<string, bool>(_defaultPermissions);
            RenderPermissions();
            XtraMessageBox.Show("تم إعادة الضبط للقيم المحفوظة",
                "إعادة الضبط", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedRole))
            {
                XtraMessageBox.Show("الرجاء اختيار دور أولاً", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SavePermissionsToDB(_selectedRole);

                // تحديث AuthService فوراً
                AuthService.ReloadFromDB();

                int allowed = _currentPermissions.Values.Count(v => v);
                int denied = _currentPermissions.Values.Count(v => !v);

                XtraMessageBox.Show(
                    $"تم حفظ صلاحيات ({_selectedRole}) بنجاح\n✔ مسموح: {allowed}  |  ✖ ممنوع: {denied}",
                    "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RenderPermissions();
        }

        // ===== AuthService - يُستخدم في كل البرنامج =====
        public static class AuthService
        {
            // ✅ استدعِ هذه الدالة مرة واحدة عند تسجيل الدخول
            public static void ReloadFromDB()
            {
                try
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var all = db.TB_permissions.AsNoTracking().ToList();
                        _cache = all
                            .GroupBy(x => x.perm_role)
                            .ToDictionary(
                                g => g.Key,
                                g => g.ToDictionary(x => x.perm_key, x => x.perm_allowed == true)
                            );
                    }
                }
                catch { _cache = new Dictionary<string, Dictionary<string, bool>>(); }
            }

            private static Dictionary<string, Dictionary<string, bool>> _cache
                = new Dictionary<string, Dictionary<string, bool>>();

            // ✅ استخدمها في أي مكان: AuthService.Check("استيراد_سفرة")
            public static bool Check(string permission)
            {
                string role = Users.userRole;
                if (_cache.ContainsKey(role) && _cache[role].ContainsKey(permission))
                    return _cache[role][permission];
                return false;
            }
        }
    }
}