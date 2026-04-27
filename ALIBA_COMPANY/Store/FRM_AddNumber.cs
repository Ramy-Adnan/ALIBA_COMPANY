//using DevExpress.XtraEditors;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using ALIBA_COMPANY.AddPage;
//using System.IO;
//using ALIBA_COMPANY.classes;

//namespace ALIBA_COMPANY.Store
//{
//    public partial class FRM_AddNumber : DevExpress.XtraEditors.XtraForm
//    {
//        public int IN_OUT_STOCK = 0;
//        AlibaRamyEntities db;
//        int ID_items;
//        public AddItemsToStore st;

//        //public List<Product> EnteredDataList { get; private set; } = new List<Product>();
//        // private AddItemsToStore parentForm;

//        public int IDValue { get; private set; }
//        public string NameValue { get; private set; }
//        public decimal numberValue { get; private set; }
//        public string gatgoryValue { get; private set; }
//        public string formmValue { get; private set; }

//        public FRM_AddNumber()
//        {
//            InitializeComponent();
//        }

//        private void empity()
//        {
//            if (string.IsNullOrEmpty(ser_item.Text.Trim()))
//            {
//                listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
//                listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
//                listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
//                ClearResults();
//            }
//        }
//        private void ser_item_TextChanged(object sender, EventArgs e)
//        {

//            UpdateSuggestions(); // تحديث الاقتراحات
//            empity();
//        }

//        private void UpdateSuggestions()
//        {
//            try
//            {
//                string inputText = ser_item.Text; // التأكد من عدم وجود فراغات في النص

//                using (db = new AlibaRamyEntities())
//                {
//                    // استعلام LINQ للحصول على الاقتراحات مع البحث بالاسم العربي والاسم الإنجليزي
//                    var suggestions = db.TB_items
//                        .Where(x => x.items_name.StartsWith(inputText) || x.items_code.StartsWith(inputText) || x.items_enname.StartsWith(inputText))
//                        .Select(x => x.items_name)
//                        .ToList();


//                    // تحديث عناصر الليست بوكس بالاقتراحات المطابقة
//                    listbox_suggestions.DataSource = suggestions;
//                    if (suggestions.Count > 0)
//                    {
//                        listbox_suggestions.Visible = true;// جعل الليست بوكس مرئيًا إذا كانت هناك اقتراحات
//                    }

//                    else
//                    {
//                        listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
//                        listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
//                        listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
//                        ClearResults();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (listbox_suggestions.SelectedItem != null) // تحقق مما إذا كانت القيمة مخصصة
//            {
//                // عرض العنصر المحدد من الليست بوكس في التيكست بوكس
//                // ser_item.Text = listbox_suggestions.SelectedItem.ToString();
//                GetMaterialsData();
//            }
//        }

//        private void listbox_suggestions_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter && listbox_suggestions.SelectedItem != null) // تحقق مما إذا كانت القيمة مخصصة
//            {
//                SendKeys.Send("{tab}");
//                e.SuppressKeyPress = true;
//                // عند الضغط على Enter، اختر العنصر المحدد وجلب البيانات
//                ser_item.Text = listbox_suggestions.SelectedItem.ToString();
//                GetMaterialsData();
//                SendKeys.Send("{tab}");
//                e.SuppressKeyPress = true;
//            }
//        }

//        public void GetMaterialsData()
//        {
//            try
//            {

//                string itemName = listbox_suggestions.SelectedItem.ToString().Trim(); // التأكد من عدم وجود فراغات في النص
//                if (!string.IsNullOrEmpty(itemName))
//                {
//                    using (db = new AlibaRamyEntities())
//                    {

//                        TB_items story = db.TB_items.FirstOrDefault(x => x.items_name == itemName);

//                        if (story != null)
//                        {
//                            ID_items = story.items_id;

//                            txt_nameAR.Text = story.items_name;
//                            txt_nameEn.Text = story.items_enname;

//                            txt_parcode.Text = story.items_code;

//                            txt_form.Text = story.items_form;
//                            txt_info.Text = story.items_nots;

//                            string imagePath = story.items_pic;
//                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
//                            {
//                                pictureEdit1.Image = Image.FromFile(imagePath);
//                            }
//                            else
//                            {
//                                // إعادة تعيين الصورة في حال عدم وجود مسار صحيح للصورة
//                                pictureEdit1.Image = Properties.Resources.aliba;
//                            }

//                            TB_groups buy2 = db.TB_groups.FirstOrDefault(m => m.groups_id == story.groups_id);
//                            txt_gat.Text = buy2.groups_name;

//                        }
//                    }
//                }
//                else
//                {
//                    // ClearResults();
//                    MessageBox.Show("يرجى إدخال اسم العنصر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }

//            }

//            catch (Exception ex)
//            {
//                MessageBox.Show("(GetMaterialsData)لم يتم جلب البيانات حدث غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }


//        private void ClearResults()
//        {

//            txt_nameAR.Text = string.Empty;
//            txt_nameEn.Text = string.Empty;
//            txt_parcode.Text = string.Empty;
//            txt_gat.Text = string.Empty;
//            txt_form.Text = string.Empty;
//            txt_info.Text = string.Empty;
//            pictureEdit1.Image = null;
//            txt_Number.Text = "0";

//        }

//        private void txt_Number_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '$' && e.KeyChar != '.')
//            {
//                e.Handled = true; // تجاهل الحرف المدخل
//            }
//            if (txt_Number.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
//            {
//                e.Handled = true; //
//            }

//            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
//            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
//            {
//                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
//            }
//        }

//        private void ser_item_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                SendKeys.Send("{tab}");
//                e.SuppressKeyPress = true;

//            }
//        }

//        private void txt_Number_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                btn_add_Click(null, null);
//            }
//        }
//        private void txt_Number_MouseDown(object sender, MouseEventArgs e)
//        {
//            txt_Number.SelectAll();
//        }

//        private void btn_add_Click(object sender, EventArgs e)
//        {
//            if (IN_OUT_STOCK==1)
//            {
//                if (txt_Number.Text == "" || txt_Number.Text == "0" || txt_nameAR.Text == "" || txt_nameEn.Text == "" || txt_parcode.Text == "")
//                {

//                    MessageBox.Show(" حقل المادة او العدد فارغ", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                else
//                {
//                    IDValue = ID_items;
//                    NameValue = txt_nameAR.Text;
//                    numberValue = Convert.ToDecimal(txt_Number.Text);
//                    gatgoryValue = txt_gat.Text;
//                    formmValue = txt_form.Text;


//                    this.DialogResult = DialogResult.OK;
//                    this.Close();
//                }
//            }
//            else if (IN_OUT_STOCK==2|| IN_OUT_STOCK == 11)
//            {
//                if (txt_Number.Text == "" || txt_Number.Text == "0" || txt_nameAR.Text == "" || txt_nameEn.Text == "" || txt_parcode.Text == "")
//                {

//                    MessageBox.Show(" حقل المادة او العدد فارغ", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                else
//                {
//                    decimal numStored = Number_of_itemStored();


//                    if (numStored < Convert.ToDecimal(txt_Number.Text))
//                    {

//                        MessageBox.Show("المخزون اقل من العدد المطلوب", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    }
//                    else
//                    {
//                        IDValue = ID_items;
//                        NameValue = txt_nameAR.Text;
//                        numberValue = Convert.ToDecimal(txt_Number.Text);
//                        gatgoryValue = txt_gat.Text;
//                        formmValue = txt_form.Text;
//                        numStored -= Convert.ToDecimal(txt_Number.Text);
//                        this.DialogResult = DialogResult.OK;
//                        this.Close();
//                    }
//                }
//            }

//        }
//        private decimal Number_of_itemStored()
//        {

//            using (var dbRamy = new AlibaRamyEntities())
//            {
//                try
//                {
//                    var idFromForm = ID_items;

//                    var numbers = dbRamy.TB_str.Where(x => x.items_id == idFromForm).Select(x => x.str_num);
//                    var numbers2 = dbRamy.TB_str.Where(x => x.items_id == idFromForm).Select(x => x.str_renum);

//                    var sum = numbers.Sum(x => (decimal?)x) ?? 0;
//                    var sum2 = numbers2.Sum(x => (decimal?)x) ?? 0;
//                    var Num_stored = sum + sum2;
//                    return Num_stored;
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("error at (Number_of_itemStored) " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return 0;
//                }
//            }
//        }

//        private void Btn_close_Click(object sender, EventArgs e)
//        {
//            this.Close();
//            this.Dispose();
//        }

//        private void FRM_AddNumber_Load(object sender, EventArgs e)
//        {
//            ser_item.Select();
//           // UpdateSuggestions();
//        }
//    }
//}








using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ALIBA_COMPANY.classes;
using DevExpress.Office.Drawing;
using TheArtOfDev.HtmlRenderer.Adapters;
using System.Data.SqlClient;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_AddNumber : DevExpress.XtraEditors.XtraForm
    {
        // ─── ثوابت الألوان والتصميم ───────────────────────────────────────────
        private static readonly Color COLOR_PRIMARY = Color.FromArgb(26, 115, 232);
        private static readonly Color COLOR_DANGER = Color.FromArgb(220, 53, 69);
        private static readonly Color COLOR_SUCCESS = Color.FromArgb(40, 167, 69);
        private static readonly Color COLOR_BG = Color.FromArgb(245, 247, 250);
        private static readonly Color COLOR_CARD = Color.White;
        private static readonly Color COLOR_BORDER = Color.FromArgb(210, 215, 225);
        private static readonly Color COLOR_TEXT_MAIN = Color.FromArgb(30, 30, 45);
        private static readonly Color COLOR_TEXT_HINT = Color.FromArgb(130, 140, 160);
        private static readonly Color COLOR_HIGHLIGHT = Color.FromArgb(232, 240, 254);

        // ─── خصائص عامة ───────────────────────────────────────────────────────
        public int IN_OUT_STOCK = 0;
        public AddItemsToStore st;

        public int IDValue { get; private set; }
        public string NameValue { get; private set; }
        public decimal numberValue { get; private set; }
        public string gatgoryValue { get; private set; }
        public string formmValue { get; private set; }

        // ─── حقول داخلية ──────────────────────────────────────────────────────
        private AlibaRamyEntities db;
        private int _ID_items;
        private bool _suppressTextChanged;

        // ─── الأيقونات الرموز التعبيرية الافتراضية (حسب الصنف) ───────────────
        private static readonly Dictionary<string, string> _categoryEmojis = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "تجميد",       "🍎" }, { "امانات","🥗" },
            { "تبريد",   "⚗️"  }, { "سائل",      "🔬" },
            { "جاف",   "📦" }, { "صيانة",      "🔧" },
            
        };

        // ════════════════════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ════════════════════════════════════════════════════════════════════════
        public FRM_AddNumber()
        {
            InitializeComponent();
            ApplyProfessionalTheme();
            SetDefaultImage();
        }

        // ════════════════════════════════════════════════════════════════════════
        //  THEME
        // ════════════════════════════════════════════════════════════════════════
        private void ApplyProfessionalTheme()
        {
            // ─ النموذج نفسه ─
            this.BackColor = COLOR_BG;
            this.Font = new Font("Cairo", 10f, FontStyle.Regular);
            this.Text = GetFormTitle();

            // ─ بطاقة البحث ─
            StyleGroupBox(grpSearch, "🔍  بحث عن المادة", COLOR_PRIMARY);
            ser_item.BackColor = Color.White;
            ser_item.ForeColor = COLOR_TEXT_MAIN;
            ser_item.Font = new Font("Cairo", 13f, FontStyle.Bold);
            ser_item.BorderStyle = BorderStyle.FixedSingle;

            StyleListBox(listbox_suggestions);

            // ─ بطاقة التفاصيل ─
            StyleGroupBox(grpDetails, "📋  تفاصيل المادة", Color.FromArgb(80, 140, 80));
            foreach (Control c in grpDetails.Controls)
            {
                if (c is TextBox tb) StyleTextBox(tb);
                if (c is RichTextBox r) StyleRichTextBox(r);
                if (c is Label lbl) StyleLabel(lbl);
            }

            // ─ بطاقة الصورة ─
            StyleGroupBox(grpImage, "🖼️  صورة المادة", Color.FromArgb(160, 100, 200));
            pictureEdit1.BackColor = COLOR_BG;
            pictureEdit1.BorderStyle = BorderStyle.None;
            pictureEdit1.SizeMode = PictureBoxSizeMode.Zoom;

            // ─ حقل الكمية ─
            txt_Number.BackColor = Color.White;
            txt_Number.ForeColor = COLOR_PRIMARY;
            txt_Number.Font = new Font("Cairo", 18f, FontStyle.Bold);
            txt_Number.TextAlign = HorizontalAlignment.Center;
            txt_Number.BorderStyle = BorderStyle.FixedSingle;

            // ─ أزرار ─
            StyleButton(btn_add, GetAddButtonText(), COLOR_SUCCESS, Color.White);
            StyleButton(Btn_close, "✖  خروج", COLOR_DANGER, Color.White);

            // ─ لوحة المعلومات السفلية ─
            if (pnlInfo != null) pnlInfo.BackColor = COLOR_HIGHLIGHT;
        }

        private string GetFormTitle()
        {
            switch (IN_OUT_STOCK)
            {
                case 1: return "📥  إدراج داخل  —  إضافة مادة";
                case 2: return "📤  إدراج خارج  —  إضافة مادة";
                case 11: return "🗑️  إتلاف مخزون —  إضافة مادة";
                default: return "📦  إدراج مادة";
            }
        }

        private string GetAddButtonText()
        {
            switch (IN_OUT_STOCK)
            {
                case 1: return "✔  إضافة داخل";
                case 2: return "✔  إضافة خارج";
                case 11: return "✔  تأكيد الإتلاف";
                default: return "✔  إضافة";
            }
        }

        // ─── مساعدات تنسيق ────────────────────────────────────────────────────
        private static void StyleGroupBox(GroupBox gb, string title, Color accent)
        {
            if (gb == null) return;
            gb.Text = title;
            gb.ForeColor = accent;
            gb.Font = new Font("Cairo", 10.5f, FontStyle.Bold);
            gb.BackColor = COLOR_CARD;
            gb.Paint += (s, e) => DrawGroupBoxBorder(e.Graphics, gb, accent);
        }

        private static void DrawGroupBoxBorder(Graphics g, GroupBox gb, Color accent)
        {
            using (var pen = new Pen(accent, 1.5f))
            {
                var rect = new Rectangle(1, 14, gb.Width - 2, gb.Height - 15);
                g.DrawRoundedRectangle(pen, rect, 8);
            }
        }

        private static void StyleTextBox(TextBox tb)
        {
            tb.BackColor = Color.White;
            tb.ForeColor = COLOR_TEXT_MAIN;
            tb.Font = new Font("Cairo", 10.5f);
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.ReadOnly = true;
            tb.TabStop = false;
        }

        private static void StyleRichTextBox(RichTextBox rtb)
        {
            rtb.BackColor = Color.White;
            rtb.ForeColor = COLOR_TEXT_MAIN;
            rtb.Font = new Font("Cairo", 10f);
            rtb.BorderStyle = BorderStyle.FixedSingle;
            rtb.ReadOnly = true;
            rtb.TabStop = false;
        }

        private static void StyleLabel(Label lbl)
        {
            lbl.ForeColor = COLOR_TEXT_HINT;
            lbl.Font = new Font("Cairo", 9.5f, FontStyle.Bold);
        }

        private static void StyleListBox(ListBox lb)
        {
            lb.Font = new Font("Cairo", 11f);
            lb.BackColor = Color.White;
            lb.ForeColor = COLOR_TEXT_MAIN;
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.ItemHeight = 32;
            lb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lb.DrawItem += ListBox_DrawItem;
        }

        private static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var lb = (ListBox)sender;
            bool sel = (e.State & DrawItemState.Selected) != 0;

            using (var brush = new SolidBrush(sel ? COLOR_HIGHLIGHT : Color.White))
                e.Graphics.FillRectangle(brush, e.Bounds);

            if (sel)
                using (var pen = new Pen(COLOR_PRIMARY, 1))
                    e.Graphics.DrawRectangle(pen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);

            var text = lb.Items[e.Index]?.ToString() ?? "";
            using (var sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
            using (var textBrush = new SolidBrush(sel ? COLOR_PRIMARY : COLOR_TEXT_MAIN))
                e.Graphics.DrawString(text, lb.Font, textBrush, e.Bounds, sf);
        }

        private static void StyleButton(SimpleButton btn, string text, Color back, Color fore)
        {
            btn.Text = text;
            btn.Appearance.BackColor = back;
            btn.Appearance.ForeColor = fore;
            btn.Appearance.Font = new Font("Cairo", 13f, FontStyle.Bold);
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;
            btn.AppearanceHovered.BackColor = ControlPaint.Dark(back, 0.1f);
            btn.AppearanceHovered.Options.UseBackColor = true;
            btn.AppearancePressed.BackColor = ControlPaint.Dark(back, 0.2f);
            btn.AppearancePressed.Options.UseBackColor = true;
            btn.LookAndFeel.UseDefaultLookAndFeel = false;
            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  EVENTS — LOAD
        // ════════════════════════════════════════════════════════════════════════
        private void FRM_AddNumber_Load(object sender, EventArgs e)
        {
            // تحديث عنوان الفورم بعد تعيين IN_OUT_STOCK
            this.Text = GetFormTitle();
            btn_add.Text = GetAddButtonText();

            ser_item.Select();
            SetDefaultImage();
            ClearResults();
        }

        // ════════════════════════════════════════════════════════════════════════
        //  SEARCH BOX
        // ════════════════════════════════════════════════════════════════════════
        private void ser_item_TextChanged(object sender, EventArgs e)
        {
            if (_suppressTextChanged) return;

            if (string.IsNullOrWhiteSpace(ser_item.Text))
            {
                HideList();
                ClearResults();
                return;
            }
            UpdateSuggestions();
        }

        private void ser_item_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    if (listbox_suggestions.Visible && listbox_suggestions.Items.Count > 0)
                    {
                        if (listbox_suggestions.SelectedIndex < 0)
                            listbox_suggestions.SelectedIndex = 0;
                        ConfirmSelection();
                    }
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Down:
                    if (listbox_suggestions.Visible && listbox_suggestions.Items.Count > 0)
                    {
                        listbox_suggestions.Focus();
                        if (listbox_suggestions.SelectedIndex < listbox_suggestions.Items.Count - 1)
                            listbox_suggestions.SelectedIndex++;
                    }
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Escape:
                    HideList();
                    break;
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  LISTBOX
        // ════════════════════════════════════════════════════════════════════════
        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // لا نجلب البيانات عند مجرد التحريك — فقط عند التأكيد
        }

        private void listbox_suggestions_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ConfirmSelection();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Escape:
                    HideList();
                    ser_item.Focus();
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void listbox_suggestions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listbox_suggestions.SelectedItem != null)
                ConfirmSelection();
        }

        private void ConfirmSelection()
        {
            if (listbox_suggestions.SelectedItem == null) return;

            _suppressTextChanged = true;
            ser_item.Text = listbox_suggestions.SelectedItem.ToString();
            _suppressTextChanged = false;

            HideList();
            GetMaterialsData();
            txt_Number.Focus();
            txt_Number.SelectAll();
        }

        private void HideList()
        {
            listbox_suggestions.Visible = false;
            listbox_suggestions.DataSource = null;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  DATA FETCH
        // ════════════════════════════════════════════════════════════════════════
        private void UpdateSuggestions()
        {
            try
            {
                string input = ser_item.Text.Trim();
                using (db = new AlibaRamyEntities())
                {
                    var suggestions = db.TB_items
                        .Where(x => x.items_name.StartsWith(input)
                                 || x.items_code.StartsWith(input)
                                 || x.items_enname.StartsWith(input))
                        .OrderBy(x => x.items_name)
                        .Select(x => x.items_name)
                        .Take(50)
                        .ToList();

                    if (suggestions.Count > 0)
                    {
                        listbox_suggestions.DataSource = suggestions;
                        listbox_suggestions.Visible = true;
                    }
                    else
                    {
                        HideList();
                        ClearResults();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("UpdateSuggestions", ex);
            }
        }

        public void GetMaterialsData()
        {
            try
            {
                string itemName = ser_item.Text.Trim();
                if (string.IsNullOrEmpty(itemName))
                {
                    MessageBox.Show("يرجى إدخال اسم المادة أولاً.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (db = new AlibaRamyEntities())
                {
                    var item = db.TB_items.FirstOrDefault(x => x.items_name == itemName);
                    if (item == null)
                    {
                        MessageBox.Show("لم يتم العثور على المادة.", "تنبيه",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _ID_items = item.items_id;

                    txt_nameAR.Text = item.items_name ?? "";
                    txt_nameEn.Text = item.items_enname ?? "";
                    txt_parcode.Text = item.items_code ?? "";
                    txt_form.Text = item.items_form ?? "";
                    txt_info.Text = item.items_nots ?? "";

                    // ─ الصنف ─
                    var group = db.TB_groups.FirstOrDefault(m => m.groups_id == item.groups_id);
                    txt_gat.Text = group?.groups_name ?? "";

                    // ─ الصورة ─
                    LoadItemImage(item.items_pic, txt_gat.Text);

                    // ─ إظهار المخزون المتاح إن وجد ─
                    if (IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11)
                        ShowStockInfo();
                }
            }
            catch (Exception ex)
            {
                ShowError("GetMaterialsData", ex);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  IMAGE HANDLING
        // ════════════════════════════════════════════════════════════════════════
        private void LoadItemImage(string imagePath, string categoryName)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    pictureEdit1.Image = Image.FromFile(imagePath);
                    return;
                }

                // لا توجد صورة → رسم أيقونة افتراضية ذكية
                pictureEdit1.Image = CreateDefaultImage(categoryName);
            }
            catch
            {
                pictureEdit1.Image = CreateDefaultImage(categoryName);
            }
        }

        private static void SetDefaultImage()
        {
            // تُستدعى عند الفتح فقط — يتم رسم لوحة ترحيب خفيفة
        }

        /// <summary>
        /// يرسم صورة GDI+ افتراضية تحمل إيموجي الصنف داخل دائرة ملوّنة.
        /// </summary>
        private static Image CreateDefaultImage(string categoryName)
        {
            // اختيار الإيموجي المناسب
            string emoji = "📦";
            if (!string.IsNullOrEmpty(categoryName))
            {
                foreach (var kv in _categoryEmojis)
                {
                    if (categoryName.Contains(kv.Key))
                    {
                        emoji = kv.Value;
                        break;
                    }
                }
            }

            int size = 160;
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                // خلفية متدرجة
                using (var bg = new LinearGradientBrush(
                    new Rectangle(0, 0, size, size),
                    Color.FromArgb(235, 242, 255),
                    Color.FromArgb(210, 225, 255),
                    LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(bg, 0, 0, size, size);
                }

                // دائرة مركزية
                int margin = 20;
                using (var circleBrush = new SolidBrush(Color.FromArgb(180, COLOR_PRIMARY)))
                    g.FillEllipse(circleBrush, margin, margin, size - 2 * margin, size - 2 * margin);

                // الإيموجي
                using (var emojiFont = new Font("Segoe UI Emoji", 38f, FontStyle.Regular, GraphicsUnit.Point))
                using (var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString(emoji, emojiFont, Brushes.White,
                        new RectangleF(0, 0, size, size), sf);
                }

                // نص "لا توجد صورة" تحت الدائرة
                using (var smallFont = new Font("Cairo", 7.5f, FontStyle.Regular, GraphicsUnit.Point))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                {
                    g.DrawString("لا توجد صورة", smallFont,
                        new SolidBrush(Color.FromArgb(120, 120, 150)),
                        new RectangleF(0, size - 18, size, 18), sf);
                }
            }
            return bmp;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  STOCK INFO
        // ════════════════════════════════════════════════════════════════════════
        private void ShowStockInfo()
        {
            decimal stored = Number_of_itemStored();
            if (lblStockInfo != null)
            {
                lblStockInfo.Text = $"المخزون الحالي: {stored:N2}";
                lblStockInfo.ForeColor = stored > 0 ? COLOR_SUCCESS : COLOR_DANGER;
                lblStockInfo.Visible = true;
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  CLEAR
        // ════════════════════════════════════════════════════════════════════════
        private void ClearResults()
        {
            _ID_items = 0;
            txt_nameAR.Text = string.Empty;
            txt_nameEn.Text = string.Empty;
            txt_parcode.Text = string.Empty;
            txt_gat.Text = string.Empty;
            txt_form.Text = string.Empty;
            txt_info.Text = string.Empty;
            txt_Number.Text = "0";

            pictureEdit1.Image = CreateDefaultImage(null);

            if (lblStockInfo != null) lblStockInfo.Visible = false;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  QUANTITY TEXTBOX
        // ════════════════════════════════════════════════════════════════════════
        private void txt_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (txt_Number.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (e.KeyChar == '.' && txt_Number.Text.Contains('.'))
                e.Handled = true;
        }

        private void txt_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_add_Click(null, null);
            }
        }

        private void txt_Number_MouseDown(object sender, MouseEventArgs e)
            => txt_Number.SelectAll();

        private void txt_Number_Enter(object sender, EventArgs e)
            => txt_Number.SelectAll();

        // ════════════════════════════════════════════════════════════════════════
        //  ADD BUTTON
        // ════════════════════════════════════════════════════════════════════════
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (IN_OUT_STOCK == 1)
            {
                CommitAndClose();
            }
            else if (IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11)
            {
                decimal stored = Number_of_itemStored();
                decimal entered = ParseQuantity();

                if (stored < entered)
                {
                    MessageBox.Show(
                        $"الكمية المطلوبة ({entered:N2}) أكبر من المخزون المتاح ({stored:N2}).",
                        "تحذير — مخزون غير كافٍ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommitAndClose();
            }
        }

        private bool ValidateInput()
        {
            if (_ID_items == 0 || string.IsNullOrWhiteSpace(txt_nameAR.Text))
            {
                MessageBox.Show("الرجاء اختيار مادة أولاً من قائمة البحث.",
                    "حقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ser_item.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Number.Text) ||
                txt_Number.Text == "0" || ParseQuantity() <= 0)
            {
                MessageBox.Show("الرجاء إدخال كمية أكبر من الصفر.",
                    "حقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Number.Focus();
                txt_Number.SelectAll();
                return false;
            }
            return true;
        }

        private decimal ParseQuantity()
        {
            decimal.TryParse(txt_Number.Text, out decimal val);
            return val;
        }

        private void CommitAndClose()
        {
            IDValue = _ID_items;
            NameValue = txt_nameAR.Text;
            numberValue = ParseQuantity();
            gatgoryValue = txt_gat.Text;
            formmValue = txt_form.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ════════════════════════════════════════════════════════════════════════
        //  STOCK CALCULATION
        // ════════════════════════════════════════════════════════════════════════
        //private decimal Number_of_itemStored()
        //{
        //    try
        //    {
        //        using (var dbRamy = new AlibaRamyEntities())
        //        {
        //            var sum = dbRamy.TB_str.Where(x => x.items_id == _ID_items)
        //                                   .Sum(x => (decimal?)x.str_num) ?? 0;
        //            var sum2 = dbRamy.TB_str.Where(x => x.items_id == _ID_items)
        //                                   .Sum(x => (decimal?)x.str_renum) ?? 0;
        //            return sum + sum2;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError("Number_of_itemStored", ex);
        //        return 0;
        //    }
        //}

        private decimal Number_of_itemStored()
        {


            using (var dbRamy = new AlibaRamyEntities())
            {
                try
                {
                    
                    var result = dbRamy.Database.SqlQuery<decimal>("EXEC dbo.GetItemStored @ItemId", new SqlParameter("@ItemId", _ID_items)).FirstOrDefault();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error at (Number_of_itemStored) " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }

        }

        // ════════════════════════════════════════════════════════════════════════
        //  CLOSE
        // ════════════════════════════════════════════════════════════════════════
        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ════════════════════════════════════════════════════════════════════════
        //  HELPER
        // ════════════════════════════════════════════════════════════════════════
        private static void ShowError(string context, Exception ex)
        {
            MessageBox.Show($"خطأ في ({context}):\n{ex.Message}",
                "خطأ غير متوقع", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }

    // ── امتداد GDI+ لرسم مستطيل دائري الزوايا ─────────────────────────────────
    internal static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle rect, int radius)
        {
            int d = radius * 2;
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                g.DrawPath(pen, path);
            }
        }
    }
}






