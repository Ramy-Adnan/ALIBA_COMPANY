using ALIBA_COMPANY.classes;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_SendCash : DevExpress.XtraEditors.XtraForm
    {
        public string selectedItem;
       
        public int ExAmount;
      
        public int? emplo_id;
        public int? cust_id;
      
    

        // ✅ فلاق لمنع تشغيل الأحداث أثناء التحميل
        private bool _isLoading = false;

        public FRM_SendCash()
        {
            InitializeComponent();
            Txt_iq.KeyPress += (sender, e) => RAMY.HandleTextBoxKeyPress(sender, e, 20);
            Txt_iq.Leave += (sender, e) => RAMY.HandleTextLeave(sender, Txt_iq);
        }

        // ============================================================
        // تحميل الفورم
        // ============================================================
        private void FRM_cash_record_Load(object sender, EventArgs e)
        {
            // الكمبو تبقى فارغة حتى يختار المستخدم عميلاً
            Combo_dis.Enabled = false;
        }


        // ============================================================
        // البحث عن العملاء
        // ============================================================
        private void UpdateSuggestions()
        {
            try
            {
                string inputText = ser_item.Text.Trim();

                if (string.IsNullOrEmpty(inputText))
                {
                    listbox_suggestions.Visible = false;
                    return;
                }

                using (var db = new AlibaRamyEntities())
                {
                    var suggestions = db.TB_cust
                        .Where(x => x.cust_name.StartsWith(inputText))
                        .AsNoTracking()
                        .ToList();



                    listbox_suggestions.DataSource = suggestions;
                    listbox_suggestions.DisplayMember = "cust_name";
                    listbox_suggestions.Visible = suggestions.Count > 0;

                    if (suggestions.Count == 0)
                    {
                        ClearResults();
                        return;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ غير متوقع: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetMaterialsData()
        {
            try
            {
                var selected = listbox_suggestions.SelectedItem as TB_cust;
                if (selected == null) return;

                Txt_xx.Text = selected.cust_name;
                cust_id = selected.cust_id;
                selectedItem = selected.cust_name;

                // إظهار اللست بوكس وإخفاؤها
                listbox_suggestions.Visible = false;

                // ✅ جلب الموزعين الخاصين بهذا العميل فقط
                Load_Combo_driver_ByCust(selected.cust_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في جلب بيانات العميل: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ============================================================
        // أحداث القوائم
        // ============================================================
        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_suggestions.SelectedItem == null) return;

            ClearResults();
            Txt_iq.Enabled = false;
            GetMaterialsData();
        }

        private void listbox_suggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || listbox_suggestions.SelectedItem == null) return;

            e.SuppressKeyPress = true;
            GetMaterialsData();
            SendKeys.Send("{tab}");
        }

        private void ser_item_TextChanged(object sender, EventArgs e)
        {
            UpdateSuggestions();
        }

        // ✅ الحدث الرئيسي — محمي بـ _isLoading
        private void Combo_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_us.Enabled = false;
            Txt_ex.Enabled = true;
            
            Txt_iq.Text = "0";
           ;   // ✅ لا تفعل شيئاً أثناء التحميل

            if (string.IsNullOrWhiteSpace(Combo_dis.Text)) return;

            Set_ID_driver();


        }

        // ============================================================
        // جلب ID الموزع
        // ============================================================
        private void Set_ID_driver()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Combo_dis.Text)) return;

                using (var db = new AlibaRamyEntities())
                {
                    var id = db.TB_emplo
                        .Where(x => x.emplo_name == Combo_dis.Text)
                        .Select(x => x.emplo_id)
                        .FirstOrDefault();

                    emplo_id = id != 0 ? id : (int?)null;
                }
            }
            catch { emplo_id = null; }
        }




     

        // ============================================================
        // الحفظ
        // ============================================================
        private void Btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsFormDataValid()) return;

                using (var db = new AlibaRamyEntities())
                {
                    // ✅ تحقق من وجود وصول معلقة عند المندوب
                    var pendingCount = db.TB_cridet
                        .Where(x => x.cust_id == cust_id
                                 && x.emplo_id == emplo_id
                                 && x.sending == false
                                 && x.action_id == 9)
                        .Count();

                    if (pendingCount > 0)
                    {
                        MessageBox.Show(
                            "يوجد وصل غير مُرسل لهذا العميل عند المندوب\n" +
                            "يرجى انتظار إرسال المندوب أولاً",
                            "تحذير",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    db.TB_cridet.Add(CreateRecordFromInputs());
                    db.SaveChanges();
                    Notifications.ShowToast("تمت العملية بنجاح ✅", "نجاح");
                    ClearResults();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الحفظ: " + ex.Message);
            }


        }

        private TB_cridet CreateRecordFromInputs()
        {

            return new TB_cridet
            {
                cridet_date = DateTime.Now,
                cridet_amount = decimal.Parse(Txt_us.Text.Replace(",", "")),
                cridet_s = decimal.Parse(Txt_us.Text.Replace(",", "")),
                cridet_d = decimal.Parse(Txt_iq.Text.Replace(",", "")),
                cridet_ex = decimal.Parse(Txt_ex.Text.Replace(",", "")),
                cridet_nots = txt_not.Text,
                user_id = AddPage.Users.Idd,
                emplo_id = emplo_id,
                tr_id = null,
                action_id = 9,
                pr_id = 1,
                cridet_code = GetLastCode() + 1,
                cust_id = cust_id,
                list_name = selectedItem,
                sending = true
            };
        }

        private int GetLastCode()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    return db.TB_cridet
                        .Where(x => x.emplo_id == emplo_id)  // ✅ فلتر بـ emplo_id فقط
                        .Select(x => x.cridet_code)
                        .DefaultIfEmpty(0)
                        .Max()
                        .GetValueOrDefault();
                }
            }
            catch { return 0; }
        }

        private bool IsFormDataValid()
        {
            if (string.IsNullOrWhiteSpace(Combo_dis.Text) || Combo_dis.Text == "")
            {
                MessageBox.Show("الرجاء اختيار الموزع", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           

            if (string.IsNullOrWhiteSpace(Txt_xx.Text))
            {
                MessageBox.Show("الرجاء اختيار العميل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(Txt_iq.Text) ||
              string.IsNullOrWhiteSpace(Txt_us.Text) ||
              !decimal.TryParse(Txt_iq.Text, out decimal iqValue) ||
              iqValue == 0 ||
              iqValue % 250 != 0) // التأكد من أن المبلغ من مضاعفات 250
            {
                string message = "الرجاء إدخال مبلغ صحيح";

                // إضافة تنبيه مخصص إذا كان السبب هو مضاعفات الـ 250
                if (decimal.TryParse(Txt_iq.Text, out decimal val) && val % 250 != 0)
                {
                    message = "يجب أن يكون المبلغ بالدينار من مضاعفات الـ 250 (مثلاً: 250، 500، 750...)";
                }

                MessageBox.Show(message, "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(Txt_ex.Text, out _))
            {
                MessageBox.Show("لا يوجد دين لهذا العميل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(Txt_iq.Text) ||
                 string.IsNullOrWhiteSpace(Txt_us.Text) ||
                 !decimal.TryParse(Txt_iq.Text, out decimal usValue) ||
                 usValue == 0)
            {
                MessageBox.Show("الرجاء إدخال مبلغ بالدولار", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ============================================================
        // مساعدة
        // ============================================================
        private void ClearResults()
        {
            _isLoading = true;
            Combo_dis.DataSource = null;
            Combo_dis.Text = "";
            Combo_dis.Enabled = false;
            _isLoading = false;

            Txt_iq.Text = 0.ToString();
            Txt_us.Text = string.Empty;
            Txt_ex.Text = string.Empty;
            txt_not.Text = string.Empty;
            Txt_xx.Text = string.Empty;
            cust_id = null;
            emplo_id = null;
            selectedItem = "";
        }



        private void Load_Combo_driver_ByCust(int custId)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    // جلب الـ emplo_id المرتبطين بهذا العميل من TB_list
                    var emploIds = db.TB_list
                        .Where(x => x.cust_id == custId && x.emplo_id != null)
                        .Select(x => x.emplo_id)
                        .Distinct()
                        .ToList();

                    // جلب أسماء الموزعين النشطين من هذه الـ IDs
                    var drivers = db.TB_emplo
                        .Where(x => emploIds.Contains(x.emplo_id)
                                 && x.emplo_dis == true
                                 && x.emplo_activity == true)
                        .Select(x => x.emplo_name)
                        .ToList();

                    drivers.Insert(0, ""); // عنصر فارغ بالبداية

                    _isLoading = true;
                    Combo_dis.DataSource = drivers;
                    Combo_dis.SelectedIndex = 0;
                    _isLoading = false;

                    // إذا كان موزع واحد فقط، اختره تلقائياً
                    if (drivers.Count == 2) // فارغ + موزع واحد
                    {
                        Combo_dis.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الموزعين: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Txt_xx_TextChanged(object sender, EventArgs e)
        {
            Combo_dis.Enabled = !string.IsNullOrWhiteSpace(Txt_xx.Text);
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ser_item_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ser_item.Text))
            {
                Txt_xx.Text = "";
                Txt_iq.Enabled = false;
            }
        }
        // ============================================================
        // الحسابات
        // ============================================================

        private void Txt_iq_TextChanged(object sender, EventArgs e)
        {
            string cleanText = Txt_iq.Text.Replace(",", "");

            if (!decimal.TryParse(cleanText, out decimal amount) || amount == 0)
            {
                Txt_us.Text = "";
                Lbl_words.Text = ""; // ✅ الليبل فوق التيكست
                return;
            }
            try { Txt_us.Text = (amount / ExAmount).ToString("N2"); } catch { }


            // ✅ عرض المبلغ كتابةً في الليبل
            Lbl_words.Text = NumberToArabicWords.Convert(amount);
        }

        private void Txt_iq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;

            if (e.KeyChar == '.' && Txt_iq.Text.Contains('.'))
                e.Handled = true;
        }

        private void Txt_iq_Leave(object sender, EventArgs e)
        {
            // 1. تنظيف النص من الفواصل
            string cleanText = Txt_iq.Text.Replace(",", "");

            // 2. محاولة تحويل النص إلى رقم عشري (Decimal)
            if (decimal.TryParse(cleanText, out decimal value))
            {
                // 3. التحقق مما إذا كان المبلغ من مضاعفات الـ 250
                // نستخدم عامل باقي القسمة % 
                if (value % 250 == 0)
                {
                    // إذا كان صحيحاً، ننسق النص مع الفواصل وخانتين عشريتين
                    Txt_iq.Text = value.ToString("N2");
                }
                else
                {
                    // 4. إذا كان المبلغ لا يقبل القسمة على 250
                    MessageBox.Show("عذراً، يجب أن يكون المبلغ من مضاعفات الـ 250 دينار (مثلاً: 250, 500, 750, 1000...)",
                                    "خطأ في العملة", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Txt_iq.Text = "0.00"; // صفر الحقل أو أعده للقيمة السابقة
                    Txt_iq.Focus();      // أعد التركيز للحقل لتصحيح القيمة
                }
            }
        }

        private void Txt_iq_Enter(object sender, EventArgs e)
        {
            Txt_iq.SelectAll(); // تحديد كل النص تلقائياً
            // ✅ احذف الفواصل عند التعديل حتى لا تتكرر
            Txt_iq.Text = Txt_iq.Text.Replace(",", "");

        }

        private void Txt_iq_MouseDown(object sender, MouseEventArgs e)
        {
            Txt_iq.SelectAll();
        }

      



        private void Txt_ex_TextChanged(object sender, EventArgs e)
        {

            if (decimal.TryParse(Txt_ex.Text, out decimal exRate) && exRate > 0)
            {
                ExAmount = (int)exRate; // تحديث القيمة الحسابية
                Txt_iq.Enabled = true; // تفعيل التيكست العراقي
            }
            else
            {
                Txt_iq.Enabled = false;
            }

            if (decimal.TryParse(Txt_iq.Text, out decimal iq) && iq > 0) { }
            try { Txt_us.Text = (iq / ExAmount).ToString("N2"); } catch { }
        }

        private void Txt_ex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;

            if (e.KeyChar == '.' && Txt_iq.Text.Contains('.'))
                e.Handled = true;
        }
    }
}