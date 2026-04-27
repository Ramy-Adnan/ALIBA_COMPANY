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

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_Save_Sell : DevExpress.XtraEditors.XtraForm
    {
        
        Note note;
        AlibaRamyEntities db;
        public int Cus_Id;
        public string Cus_Name;
        public int Traval_Id = 0;
        public int AccORMandob { get; set; }
        public int EmploForAccountsForm_ID;
        public AddItemsToSell Addd;
        public FRM_Save_Sell()
        {
            InitializeComponent();
           
        }

      
        private void empity()
        {
            if (string.IsNullOrEmpty(Ser_item.Text.Trim()))
            {
                listbox_suggestions.Visible = true; // يكون غير مرئي في البداية
                listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
                listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
              
            }
        }
        private void Ser_item_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                UpdateSuggestions();
            }
            else
            {
                Cus_Id = 0;
                Cus_Name = Ser_item.Text;
            }
             
            //empity();


        }

        private void UpdateSuggestions()
        {
            try
            {
                string inputText = Ser_item.Text;

                using (db = new AlibaRamyEntities())
                {

                    var suggestions = db.TB_cust
                        .Where(x => x.cust_name.Contains(inputText))
                        .Select(x => x.cust_name)
                        .ToList();


                    // تحديث عناصر الليست بوكس بالاقتراحات المطابقة
                    listbox_suggestions.DataSource = suggestions;
                    if (suggestions.Count > 0)
                    {
                        listbox_suggestions.Visible = true;
                    }

                    else
                    {
                        listbox_suggestions.Visible = false;
                        listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
                        listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" UpdateSuggestions() حدث خطأ غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_suggestions.SelectedItem != null)
            {

                // ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();

            }
        }

        private void listbox_suggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listbox_suggestions.SelectedItem != null)
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;

                Ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;
            }
        }

        private void GetMaterialsData()
        {
            try
            {
                if(listbox_suggestions.Items.Count > 0)
                {

                
                    string itemName = listbox_suggestions.SelectedItem.ToString().Trim();
                    if (!string.IsNullOrEmpty(itemName))
                    {

                        using (db = new AlibaRamyEntities())
                        {

                        TB_cust Ramy = db.TB_cust.FirstOrDefault(x => x.cust_name == itemName);

                        if (Ramy != null)
                        {
                            Cus_Id = Ramy.cust_id;
                            Cus_Name = Ramy.cust_name;
                        }
                        }
                    }
                    else
                    {
                      // ClearResults(
                       MessageBox.Show("يرجى إدخال اسم الزبون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("لم يتم جلب البيانات حدث غير متوقع GET(): " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      

        private bool IsFormDataValid()
        {
            decimal.TryParse(Txt_IQrecive.Text.Trim(), out decimal reciveIrq);
            decimal.TryParse(Txt_Usdrecive.Text.Trim(), out decimal reciveUSD);
            decimal.TryParse(Txt_AmountUsd.Text.Trim(), out decimal qusd);
            decimal.TryParse(Txt_AmountIRQ.Text.Trim(), out decimal qirq);
            decimal.TryParse(Txt_usd_late.Text.Trim(), out decimal late1);
            decimal.TryParse(Txt_IQ_late.Text.Trim(), out decimal late2);
            if (qusd == 0 && qirq == 0)
            {
                if (reciveIrq > 0 || reciveUSD > 0)
                {
                    MessageBox.Show("لا تدخل قيمه للبيع المبلغ يكون عبارة عن هديه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if ( string.IsNullOrWhiteSpace(Txt_number.Text) || string.IsNullOrWhiteSpace(Txt_pacess.Text))
            {
                MessageBox.Show("لا توجد مواد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (qusd > 0 && qirq > 0)
            {
                if (string.IsNullOrWhiteSpace(Txt_Usdrecive.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Txt_IQrecive.Text.Trim()) ||
                Cus_Name == null ||
                Cus_Name == "" ||
                string.IsNullOrWhiteSpace(Txt_pacess.Text))
                {
                    MessageBox.Show("يجب اختيار زبون او ادخل زبون جديد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (reciveIrq == 0 && reciveUSD > 0 || reciveIrq > 0 && reciveUSD == 0)
                {
                    MessageBox.Show("لا يمكن  ترك احد الحقول بقيمه 0", "ادخال خاطىء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                else if (late1 > 0 || late2 > 0)
                {
                    var result = MessageBox.Show(" هل تريد البيع باللآجل؟", "بيع بالدين", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (checkBox1.Checked == true)
                        {
                            MessageBox.Show("لا يمكن البيع بالاجل الى عميل خارجي\n يجب اولا ادراج العميل ضمن العملاء ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void Txt_Usdrecive_MouseDown(object sender, MouseEventArgs e)
        {
            Txt_Usdrecive.SelectAll();
        }

        private void Txt_IQrecive_MouseDown(object sender, MouseEventArgs e)
        {
            Txt_IQrecive.SelectAll();
        }

        private void Txt_Usdrecive_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text.Trim();

            // التحقق من أن النص يبدأ أو ينتهي بفاصلة عشرية
            if (text.StartsWith(".") || text.EndsWith("."))
            {
                MessageBox.Show("الرجاء تصحيح القيمة. لا يمكن أن تبدأ أو تنتهي بفاصلة عشرية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus(); // عودة التركيز للتيكست بوكس
            }
        }

        private void Txt_IQrecive_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text.Trim();

            // التحقق من أن النص يبدأ أو ينتهي بفاصلة عشرية
            if (text.StartsWith(".") || text.EndsWith("."))
            {
                MessageBox.Show("الرجاء تصحيح القيمة. لا يمكن أن تبدأ أو تنتهي بفاصلة عشرية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus(); // عودة التركيز للتيكست بوكس
            }
        }

        private void CalculateUsdLate1()
        {
            if (decimal.TryParse(Txt_AmountUsd.Text, out decimal amountUsd) &&
                decimal.TryParse(Txt_Usdrecive.Text, out decimal usdRecive))
            {
                decimal usdLate = amountUsd - usdRecive;
                if (usdLate < 0)
                {
                        Txt_Usdrecive.Text = amountUsd.ToString("N2");
                        usdLate = 0; // تعيين قيمة صفر لـ usdLate لأننا غيّرنا قيمة UsdRecive
                }
                Txt_usd_late.Text = usdLate.ToString("N2");
            }
            else
            {
                Txt_usd_late.Text = "N2";
            }
        }
        private void CalculateUsdLate2()
        {
            if (decimal.TryParse(Txt_AmountIRQ.Text, out decimal amountIrq) && decimal.TryParse(Txt_ex.Text, out decimal ex) && 
                decimal.TryParse(Txt_IQrecive.Text, out decimal irqRecive))
            {
               
                decimal irqLate = amountIrq - irqRecive;
                if (irqLate < 0)
                {
                    DialogResult result = MessageBox.Show("لا يمكن ان تكون قيمة المستلم اكبر من مبلغ القائمة \n هل تريد وضع نفس المبلغ ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        Txt_IQrecive.Text = amountIrq.ToString("N0");

                        irqLate = 0; // تعيين قيمة صفر لـ usdLate لأننا غيّرنا قيمة UsdRecive
                    }
                    else
                    {
                        Txt_IQ_late.Text = amountIrq.ToString("N0"); // عرض صفر إذا تم الضغط على Cancel
                        Txt_IQrecive.Text = "N2";
                     
                        return;
                    }
                }
                Txt_IQ_late.Text = irqLate.ToString("N2");
                if (ex>0)
                {
                    Txt_Usdrecive.Text = (irqRecive / ex).ToString("N2");
                }
                else
                {
                    Txt_Usdrecive.Text = "0.00";
                }
               
            }
            else
            {
                Txt_IQ_late.Text = "0.00";
            }
        }

       
        private void Txt_Usdrecive_TextChanged(object sender, EventArgs e)
        {
            CalculateUsdLate1();
        }

        private void Txt_IQrecive_TextChanged(object sender, EventArgs e)
        {
            CalculateUsdLate2();
           
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                listbox_suggestions.Visible = false;
                Cus_Id = 0;
                Cus_Name = Ser_item.Text;
            }
            else
            {
                listbox_suggestions.Visible = true;
                GetMaterialsData();
            }
        }
        private async void Btn_add_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Btn_add.Enabled = false;

                if (!IsFormDataValid())
                {
                    Btn_add.Enabled = true;

                    return;
                }
                loading.Visible = true;

                using (var db = new AlibaRamyEntities())
                {



                    if (AccORMandob == 0)//This for Mandob  اختيار المندوب 
                    {

                        
                        var Traval_Id_temp = await db.TB_temp.AsNoTracking()
                               .Where(c => c.user_id == ALIBA_COMPANY.AddPage.Users.Idd)
                               .Select(c => c.order_id)
                               .FirstOrDefaultAsync();

                        var check = db.TB_list.AsNoTracking().FirstOrDefault(x => x.tr_id == Traval_Id_temp && x.pr_id == 1);

                        if (check == null || check.tr_id == null)
                        {
                            int? listCode;

                            var emplo_id = db.TB_travel.AsNoTracking()
                               .Where(x => x.tr_id == Traval_Id_temp)
                               .Select(x => x.emplo_id)
                               .FirstOrDefault();

                            //توليد كود الوصل

                            int? prId = emplo_id;
                            var oldCodes = db.TB_list
                                .Where(x => x.emplo_id== emplo_id)
                                .Select(x => x.list_code)
                                .DefaultIfEmpty(0)
                                .Max()
                                .GetValueOrDefault();

                              
                            listCode = oldCodes + 1;

                            TB_list newItem = new TB_list
                            {
                                tr_id = Traval_Id_temp,
                                list_date = DateTime.Now,
                                user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                                list_items = Convert.ToDecimal(Txt_number.Text),
                                list_unit = Convert.ToDecimal(Txt_pacess.Text),
                                cust_id = Cus_Id,
                                list_name = Cus_Name,
                                list_nots = Txt_info.Text.Trim(),
                                list_amountUsd = Convert.ToDecimal(Txt_AmountUsd.Text),
                                list_cridetUsd = Convert.ToDecimal(Txt_usd_late.Text),
                                list_scashUsd = Convert.ToDecimal(Txt_Usdrecive.Text),
                                list_amountIQ = Convert.ToDecimal(Txt_AmountIRQ.Text),
                                list_cridetIQ = Convert.ToDecimal(Txt_IQ_late.Text),
                                list_dcash = Convert.ToDecimal(Txt_IQrecive.Text),
                                action_id = 5,
                                list_exch = Convert.ToDecimal(Txt_ex.Text),
                                sending = false,
                                list_code = listCode,
                                pr_id = prId,
                                emplo_id = prId,
                                type_id = Convert.ToDecimal(Txt_usd_late.Text) == 0 || Convert.ToDecimal(Txt_IQ_late.Text) == 0 ? 2 : 1
                            };
                            db.Entry(newItem).State = System.Data.Entity.EntityState.Added;
                            await db.SaveChangesAsync();

                            Addd.SaveData();

                            loading.Visible = false;
                            MessageBox.Show("تمت الاضافة الى الوصولات", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("السفرة تحتوي وصولات تمت اضافتها من قبل الحسابات\n يجب حذف تلك الوصولات اولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    
                    //////////////////////////
                    else if (AccORMandob == 1)  // this for Acc اختيار المحاسب او من الرئيسي
                    {
                        var check1 = await db.TB_list.Where(x => x.tr_id == Traval_Id && x.list_code == null).ToListAsync();
                        if (check1.Any())
                        {
                            db.TB_list.RemoveRange(check1);
                        }

                        var check2 = await db.TB_details.Where(x => x.order_id == Traval_Id && x.action_id == 3 && x.sending == false).ToListAsync();
                        if (check2.Any())
                        {
                            foreach (var cc in check2)
                            {
                                cc.sell_num = 0;
                            }
                            foreach (var entity in check2)
                            {
                                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        var check3 = await db.TB_temp.Where(x => x.order_id == Traval_Id && x.action_id == 3 && x.temp_renum > 0).ToListAsync();
                        if (check3.Any())
                        {
                            foreach (var cc in check3)
                            {
                                cc.temp_renum = 0;
                            }
                            foreach (var entity in check3)
                            {
                                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                        await db.SaveChangesAsync();


                        //توليد كود الوصل
                        int? listCode;
                        int? prId = 1;

                        var oldCodes = db.TB_list
                                 .Where(x => x.emplo_id == EmploForAccountsForm_ID)
                                 .Select(x => x.list_code)
                                 .DefaultIfEmpty(0)
                                 .Max()
                                 .GetValueOrDefault();


                        listCode = oldCodes + 1;

                        TB_list newItem = new TB_list
                        {
                            tr_id = Traval_Id,
                            list_date = DateTime.Now,
                            user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                            list_items = Convert.ToDecimal(Txt_number.Text),
                            list_unit = Convert.ToDecimal(Txt_pacess.Text),
                            cust_id = Cus_Id,
                            list_name = Cus_Name,
                            list_nots = Txt_info.Text.Trim(),
                            list_amountUsd = Convert.ToDecimal(Txt_AmountUsd.Text),
                            list_cridetUsd = Convert.ToDecimal(Txt_usd_late.Text),
                            list_scashUsd = Convert.ToDecimal(Txt_Usdrecive.Text),
                            list_amountIQ = Convert.ToDecimal(Txt_AmountIRQ.Text),
                            list_cridetIQ = Convert.ToDecimal(Txt_IQ_late.Text),
                            list_dcash = Convert.ToDecimal(Txt_IQrecive.Text),
                            action_id = 5,
                            list_exch = Convert.ToDecimal(Txt_ex.Text),
                            sending = true,
                            list_code = listCode,
                            pr_id = prId,
                            emplo_id = EmploForAccountsForm_ID,
                            type_id = Convert.ToDecimal(Txt_usd_late.Text) == 0 || Convert.ToDecimal(Txt_IQ_late.Text) == 0 ? 2 : 1
                        };
                        db.Entry(newItem).State = System.Data.Entity.EntityState.Added;

                        var sending = await db.TB_travel.FirstOrDefaultAsync(x => x.tr_id == Traval_Id);
                        sending.tr_sending = true;
                        db.Entry(sending).State = System.Data.Entity.EntityState.Modified;
                        await db.SaveChangesAsync();

                        Addd.SaveData();
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var username = AddPage.Users.FullName;
                        var Note = " تم اضافة وصل بيع  " + listCode;
                        note.AddNote(Note, notifications, "اضافة", 3);
                        loading.Visible = false;
                        MessageBox.Show("تمت الاضافة الى الوصولات", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    this.DialogResult = DialogResult.OK;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عملية الإضافة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Btn_add.Enabled = true;
            Cursor.Current = Cursors.Default;
        }



        private void FRM_Save_Sell_Load(object sender, EventArgs e)
        {
            UpdateSuggestions();
            empity();
            decimal.TryParse(Txt_AmountUsd.Text.Trim(), out decimal amountUSD);
            decimal.TryParse(Txt_AmountIRQ.Text.Trim(), out decimal amountDenar);
            Txt_usd_late.Text = amountUSD.ToString("N2");
            Txt_IQ_late.Text = amountDenar.ToString("N0");
            if (amountUSD>0&& amountDenar>0)
            {
                Txt_ex.Text = (decimal.Parse(Txt_AmountIRQ.Text) / decimal.Parse(Txt_AmountUsd.Text)).ToString("N2");
            }
           
        }

        private void Txt_Usdrecive_KeyPress(object sender, KeyPressEventArgs e)
        {
            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
            if (Txt_Usdrecive.Text.Length >= 30 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //
            }

            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
            }
        }

        private void Txt_IQrecive_KeyPress(object sender, KeyPressEventArgs e)
        {
            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
            if (Txt_IQrecive.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //
            }

            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
            }
        }

      

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}


