using ALIBA_COMPANY.classes;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_cash_record : DevExpress.XtraEditors.XtraForm
    {
        public string selectedItem;
        public int ID_traval;
        public int? emplo_id;
        public int? cust_id;
        public decimal ExAmount;
        public other.ERM_cash page;

        // ✅ فلاق لمنع تشغيل الأحداث أثناء التحميل
        private bool _isLoading = false;

        public FRM_cash_record()
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
                        .ToList();

                    listbox_suggestions.DataSource = suggestions;
                    listbox_suggestions.DisplayMember = "cust_name";
                    listbox_suggestions.Visible = suggestions.Count > 0;

                    if (suggestions.Count == 0)
                    {
                        ClearResults();
                        return;
                    }

                    // ✅ ابحث عن سعر الصرف فقط إذا تم اختيار موزع
                    if (!string.IsNullOrWhiteSpace(Combo_dis.Text)
                        && Combo_dis.Text != "")
                    {
                        SearchExch();
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
            Txt_iq.Enabled=false;
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
            if (_isLoading) return;   // ✅ لا تفعل شيئاً أثناء التحميل

            if (string.IsNullOrWhiteSpace(Combo_dis.Text)) return;

            Set_ID_driver();

            // ابحث فقط إذا تم اختيار عميل أيضاً
            if (!string.IsNullOrWhiteSpace(Txt_xx.Text))
                SearchExch();
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
        // الحسابات
        // ============================================================
        private void Txt_iq_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Txt_iq.Text, out decimal amount)) { Txt_us.Text = ""; return; }
            

            Txt_us.Text = (amount / ExAmount).ToString("N2");
        }

        // ============================================================
        // البحث عن سعر الصرف (Stored Procedure)
        // ============================================================
        private async void SearchExch()
        {
            try
            {
                string selectedCust = Txt_xx.Text.Trim();
                string selectedEmplo = Combo_dis.SelectedItem?.ToString()?.Trim();

                // ✅ تحقق صارم قبل الاستدعاء
                if (string.IsNullOrEmpty(selectedCust)
                    || string.IsNullOrEmpty(selectedEmplo)
                    || selectedEmplo == ""
                    || selectedEmplo == "كل الموزعيين")
                    return;  // ✅ لا رسالة خطأ — فقط توقف

                loading.Visible = true;

                decimal exchValue = await System.Threading.Tasks.Task.Run(() =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var conn = db.Database.Connection;
                        conn.Open();

                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SP_GetCustomerExch";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 60;
                            cmd.Parameters.Add(new SqlParameter("@emplo_name", selectedEmplo));
                            cmd.Parameters.Add(new SqlParameter("@list_name", selectedCust));

                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("Exch")))
                                    return Convert.ToDecimal(reader["Exch"]);
                            }
                        }
                        return 0m;
                    }
                });

                this.Invoke((MethodInvoker)(() =>
                {
                    if (exchValue > 0)
                    {
                        Txt_ex.Text = exchValue.ToString("F2"); //  // ✅ عرض فقط بخانتين
                        ExAmount = exchValue;               //// ✅ القيمة الكاملة للحساب
                    }
                    else
                    {
                        Txt_ex.Text = "لا يوجد دين لهذا العميل او الموزع";
                        ExAmount = 0;                       // ✅ صفّر ExAmount إذا لا يوجد دين
                    }
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)(() =>
                    MessageBox.Show("خطأ في جلب سعر الصرف: " + ex.Message)));
            }
            finally
            {
                this.Invoke((MethodInvoker)(() => loading.Visible = false));
            }
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
                    db.TB_cridet.Add(CreateRecordFromInputs());
                    db.SaveChanges();

                    MessageBox.Show("تمت عملية القبض النقدي بنجاح ✅", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearResults();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الحفظ: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TB_cridet CreateRecordFromInputs()
        {
            return new TB_cridet
            {
                cridet_date = DateTime.Now,
                cridet_amount = decimal.Parse(Txt_us.Text),
                cridet_s = decimal.Parse(Txt_us.Text),
                cridet_d = decimal.Parse(Txt_iq.Text),
                cridet_ex = ExAmount,
                cridet_nots = txt_not.Text,
                user_id = AddPage.Users.Idd,
                emplo_id = emplo_id,
                tr_id = ID_traval,
                action_id = 6,
                pr_id = emplo_id,
                cridet_code = GetLastCode() + 1,
                cust_id = cust_id,
                list_name = selectedItem,
                sending=true
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

            if (string.IsNullOrWhiteSpace(Txt_iq.Text) || string.IsNullOrWhiteSpace(Txt_us.Text))
            {
                MessageBox.Show("الرجاء إدخال المبلغ", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(Txt_ex.Text, out _))
            {
                MessageBox.Show("لا يوجد دين لهذا العميل", "تنبيه",
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

            Txt_iq.Text = string.Empty;
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
      
       
        private void Combo_dis_Leave(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
            Txt_iq.Enabled = true;
        }
    }
}