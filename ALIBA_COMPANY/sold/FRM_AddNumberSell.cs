using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALIBA_COMPANY.AddPage;
using System.IO;
using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.sold;

namespace ALIBA_COMPANY.Sold
{
    public partial class FRM_AddNumberSell : DevExpress.XtraEditors.XtraForm
    {
        public AddItemsToSell Addd;
        public int ID_traval2 { get;  set; }
        public int AccORMandob { get; set; }
        int ID_items;
   

        //public List<Product> EnteredDataList { get; private set; } = new List<Product>();
        // private AddItemsToStore parentForm;

        public int IDValue { get; private set; }
        public string NameValue { get; private set; }
        public decimal numberValue { get; private set; }
        public decimal priceUSD { get; private set; }
        public decimal priceIRD { get; private set; }
        public decimal amuntUSD { get; private set; }
        public decimal amuntIRD { get; private set; }
        public FRM_AddNumberSell()
        {
            InitializeComponent();
            Txt_Number.TextChanged += Txt_Number_TextChanged;
        }

        /*private void empity()
        {
            if (string.IsNullOrEmpty(ser_item.Text.Trim()))
            {
                listbox_suggestions.Visible = false; 
                listbox_suggestions.SelectedIndexChanged += Listbox_suggestions_SelectedIndexChanged;
                listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                ClearResults();
            }
        }*/
        private void ser_item_TextChanged(object sender, EventArgs e)
        {

            UpdateSuggestions(); // تحديث الاقتراحات
            //empity();
        }

        private void UpdateSuggestions()
        {
            try
            {
                string inputText = ser_item.Text;
                if (AccORMandob == 1)
                {
                    using (var db = new AlibaRamyEntities())
                    {

                        var suggestions2 = db.TB_items
                            .Where(x => (x.items_name.Contains(inputText) || x.items_code.Contains(inputText) || x.items_enname.Contains(inputText))
                                        && db.TB_str.Any(temp => temp.items_id == x.items_id && temp.order_id == ID_traval2))
                            .Select(x => x.items_name)
                            .ToList();
                        // عرض الاقتراحات في الـ ListBox
                        listbox_suggestions.DataSource = suggestions2;
                        if (suggestions2.Count > 0)
                        {
                            listbox_suggestions.Visible = true;// جعل الليست بوكس مرئيًا إذا كانت هناك اقتراحات
                        }

                        else
                        {
                            listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
                            listbox_suggestions.SelectedIndexChanged += Listbox_suggestions_SelectedIndexChanged;
                            listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                            ClearResults();
                        }
                    }
                }
                else if (AccORMandob == 0)
                {
                    using (var db = new AlibaRamyEntities())
                    {

                        var suggestions1 = db.TB_items
                            .Where(x => (x.items_name.Contains(inputText) || x.items_code.Contains(inputText) || x.items_enname.Contains(inputText))
                                        && db.TB_temp.Any(temp => temp.items_id == x.items_id && temp.user_id == ALIBA_COMPANY.AddPage.Users.Idd))
                            .Select(x => x.items_name)
                            .ToList();

                        // عرض الاقتراحات في الـ ListBox
                        listbox_suggestions.DataSource = suggestions1;
                        if (suggestions1.Count > 0)
                        {
                            listbox_suggestions.Visible = true;// جعل الليست بوكس مرئيًا إذا كانت هناك اقتراحات
                        }

                        else
                        {
                            listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
                            listbox_suggestions.SelectedIndexChanged += Listbox_suggestions_SelectedIndexChanged;
                            listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                            ClearResults();
                        }
                    }
                }
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_suggestions.SelectedItem != null)
            {
                // عرض العنصر المحدد من الليست بوكس في التيكست بوكس
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
                // عند الضغط على Enter، اختر العنصر المحدد وجلب البيانات
                ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;
            }
        }

        public void GetMaterialsData()
        {
            try
            {
                string itemName = listbox_suggestions.SelectedItem.ToString(); // التأكد من عدم وجود فراغات في النص
                if (!string.IsNullOrEmpty(itemName))
                {
                    using (var db  = new AlibaRamyEntities())
                    {
                        TB_items story = db.TB_items.FirstOrDefault(x => x.items_name == itemName);

                        if (story != null)
                        {
                            ID_items = story.items_id;
                            Txt_unit_price.Text = story.exchang.ToString();
                            txt_nameAR.Text = story.items_name;
                            txt_nameEn.Text = story.items_enname;
                           
                            txt_form.Text = story.items_form;
                            txt_info.Text = story.items_nots;
                          
                            Txt_Uusd.Text = story.Usd_upper.ToString() + " $"; // يعرض القيمة بالدولار واثنين من الأرقام العشرية
                            Txt_Lusd.Text = story.Usd_lower.ToString() + " $";
                            Txt_Uiqr.Text = story.IQD_upper.ToString() + " D";
                          
                            Txt_Liqr.Text = story.IQD_lower.ToString() + " D";
                          

                            string imagePath = story.items_pic;
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pictureEdit1.Image = Image.FromFile(imagePath);
                            }
                            else
                            {
                                // إعادة تعيين الصورة في حال عدم وجود مسار صحيح للصورة
                                pictureEdit1.Image = Properties.Resources.aliba;
                            }

                            TB_groups buy2 = db.TB_groups.FirstOrDefault(m => m.groups_id == story.groups_id);
                            txt_gat.Text = buy2.groups_name;
                        }
                    }
                }
                else
                {
                    // ClearResults();
                    MessageBox.Show("يرجى اختيار عنصر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("(GetMaterialsData)    لم يتم جلب البيانات حدث غير متوقع خطا في سعر المادة :" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearResults()
        {

            txt_nameAR.Text = string.Empty;
            txt_nameEn.Text = string.Empty;
            // txt_parcode.Text = string.Empty;
            txt_gat.Text = string.Empty;
            txt_form.Text = string.Empty;
            txt_info.Text = string.Empty;
            pictureEdit1.Image = null;
          
            Txt_Lusd.Text = "";
            Txt_Uusd.Text = "";
            Txt_Uiqr.Text = "";
            Txt_Liqr.Text = "";


        }

        private void Txt_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
            if (Txt_Number.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //
            }

            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
            }
        }

        private void ser_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;

            }
        }

        private void Txt_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_add_Click(null, null);
            }
        }
        private void Txt_Number_MouseDown(object sender, MouseEventArgs e)
        {
            Txt_Number.SelectAll();
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (Txt_Number.Text == "" || Txt_Number.Text == "0" || txt_nameAR.Text == "" || txt_nameEn.Text == "" || Txt_Dsell.Text == ""||Txt_AmountIraq.Text=="")
            {

                MessageBox.Show("  خطأ في حقل المادة أو العدد أو السعر ", "خطأ في الحقول", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal.TryParse(Txt_Uusd.Text.Replace(" $", ""), out decimal value100);
                decimal.TryParse(Txt_Uiqr.Text.Replace(" D", ""), out decimal value101);
                decimal.TryParse(Txt_Ssell.Text.Replace(" $", ""), out decimal value1);
                decimal.TryParse(Txt_Lusd.Text.Replace(" $", ""), out decimal value2);
                decimal.TryParse(Txt_Dsell.Text.Replace(" D", ""), out decimal value11);
                decimal.TryParse(Txt_Liqr.Text.Replace(" D", ""), out decimal value22);

                if (value101 == 0 || value100 == 0)
                {
                    MessageBox.Show("لا يمكن ان يكون اعلى سعر يساوي صفر يجب تعديل  سعر المادة", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                //    decimal numStored = Number_of_itemStored();
                    if (Convert.ToDecimal(Lbl_stay.Text) < 0)
                    {
                        MessageBox.Show("المادة الصاعدة اقل من العدد", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        IDValue = ID_items;
                        NameValue = txt_nameAR.Text;
                        numberValue = Convert.ToDecimal(Txt_Number.Text);
                        if (checkBox1.Checked == true)
                        {

                            priceUSD = value2;
                            priceIRD = value22;
                        }
                        else
                        {
                            priceUSD = value1;
                            priceIRD = value11;
                        }
                        decimal.TryParse(Txt_AmountUsd.Text.Replace(" $", ""), out decimal value55);
                        decimal.TryParse(Txt_AmountIraq.Text.Replace(" D", ""), out decimal value66);
                        amuntUSD = value55;
                        amuntIRD = value66;
                     //   numStored -= Convert.ToDecimal(Txt_Number.Text);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
       
        private decimal Number_of_itemStored()
        {
            try
            {
                if (AccORMandob == 0)
                {
                    using (var dbRamy = new AlibaRamyEntities())
                    {
                        var idFromForm = ID_items;
                        var numbers1 = dbRamy.TB_temp.FirstOrDefault(x => x.items_id == idFromForm && x.user_id == ALIBA_COMPANY.AddPage.Users.Idd)?.temp_num ?? 0;
                        var numbers2 = dbRamy.TB_temp.FirstOrDefault(x => x.items_id == idFromForm && x.user_id == ALIBA_COMPANY.AddPage.Users.Idd)?.temp_renum ?? 0;

                        var Num_stored1 = Math.Abs(numbers1);
                        var numStor = Num_stored1 - numbers2;
                        return numStor;
                    }
                }
                else
                {
                    using (var dbRamy = new AlibaRamyEntities())
                    {
                        var idFromForm = ID_items;
                        var numbers1 = dbRamy.TB_details.FirstOrDefault(x => x.items_id == idFromForm && x.order_id== ID_traval2)?.details_num ?? 0;
                        var numbers2 = dbRamy.TB_details.FirstOrDefault(x => x.items_id == idFromForm && x.order_id == ID_traval2&&x.sending == true)?.sell_num ?? 0;

                        //var Num_stored1 = Math.Abs(numbers1);
                        var numStor = numbers1 - numbers2;
                        return numStor;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Number_of_itemStored حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
           
        }

        private void UpdateCalculations()
        {
            if (decimal.TryParse(Txt_Number.Text, out decimal value))
            {
                if (checkBox1.Checked)
                {
                    Calculate(Txt_Lusd, Txt_AmountUsd, value);
                    Calculate(Txt_Liqr, Txt_AmountIraq, value);
                }
                else
                {
                    Calculate(Txt_Ssell, Txt_AmountUsd, value);
                    Calculate(Txt_Dsell, Txt_AmountIraq, value);
                }
            }
            else
            {
                Txt_AmountUsd.Text = string.Empty;
                Txt_AmountIraq.Text = string.Empty;
            }
        }

        private void Calculate(TextBox currencyTextBox, TextBox resultTextBox, decimal value)
        {
            if (decimal.TryParse(currencyTextBox.Text.Replace(" $", "").Replace(" D", ""), out decimal currencyValue))
            {
                decimal result = currencyValue * value;
                resultTextBox.Text = result.ToString("#,##0.00") + (currencyTextBox == Txt_Lusd || currencyTextBox == Txt_Ssell ? " $" : " D");
            }
            else
            {
                resultTextBox.Text = string.Empty;
            }
        }

        private void Txt_Number_TextChanged(object sender, EventArgs e)
        {
            decimal numStored;
            decimal numgrid;
            if (!string.IsNullOrWhiteSpace(Txt_Number.Text) && decimal.TryParse(Txt_Number.Text, out decimal enteredValue))
            {
                numStored = Number_of_itemStored();
                numgrid = Addd.Number_of_grid(ID_items);
                Lbl_stay.Text = (numStored- numgrid - enteredValue).ToString("N0");
            }
            else
            {
                Lbl_stay.Text = "";
            }

            UpdateCalculations();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateCalculations();
            if (sender is CheckBox checkBox)
            {
                // checkBox.BackColor = checkBox.Checked ? checkBox.FlatAppearance.CheckedBackColor : checkBox.FlatAppearance.MouseOverBackColor;
                // في جزء تصميم النموذج أو في تهيئة النموذج
                checkBox.ForeColor = checkBox.Checked ? Color.Orange : Color.Black;


            }
        }

        private void Txt_Lusd_TextChanged(object sender, EventArgs e)
        {
            //UpdateCalculations();
            decimal.TryParse(Txt_Lusd.Text.Replace(" $", ""), out decimal value1);
            decimal.TryParse(Txt_Liqr.Text.Replace(" $", ""), out decimal value2);
            if (value1 == 0 && value2 == 0)
            {
                checkBox1.Visible = true;
            }
            else
            {
                checkBox1.Visible = false;
            }
        }

       

        private void Txt_Uiqr_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(Txt_Uiqr.Text.Replace(" D", ""), out decimal value1);
            Txt_Dsell.Text = value1.ToString();
            UpdateCalculations();
        }

        private void Txt_Liqr_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculations();
        }

        private void txt_nameAR_TextChanged(object sender, EventArgs e)
        {
            Txt_Number.Text = "";
            Txt_Number.Text = "0";
        }

      
        private void Txt_Dsell_Validating(object sender, CancelEventArgs e)
        {
            // استبدال "$" لتحويل النص إلى قيمة عددية
            decimal.TryParse(Txt_Uiqr.Text.Replace(" D", ""), out decimal value1);
            decimal.TryParse(Txt_Liqr.Text.Replace(" D", ""), out decimal value2);
            decimal.TryParse(Txt_Dsell.Text.Replace(" D", ""), out decimal value3);
            if (Txt_Dsell.Text != "")
            {
                // التحقق إذا كانت القيمة المدخلة ضمن النطاق
                if (value3 > value1 || value3 < value2)
                {
                    // عرض رسالة توضيحية للمستخدم
                    MessageBox.Show("سعر البيع يجب تعديله ليكون بين اعلى سعر و اقل سعر اما اذا كنت تريد الخروج من الحقل يجب مسح جميع الارقام","انتبه",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    // منع مغادرة الحقل
                    e.Cancel = true;
                }
                else if (value3 != RoundToNearest(value3))
                {
                    MessageBox.Show("خطا في العملة العراقية يجب ان تكون بالصيغة-250-500-750-1000 ","انتباه");
                    // منع مغادرة الحقل
                    e.Cancel = true;
                }

            }

        }
        static decimal RoundToNearest(decimal number)
        {
            // قم بتقسيم الرقم على 250 وإلقاء الباقي
            decimal remainder = number % 250;

            // إذا كان الباقي أقل من 125، قم بتقريب الرقم إلى الأقرب من 000
            if (remainder < 125)
            {
                return number - remainder;
            }
            // إذا كان الباقي بين 125 و 375، قم بتقريب الرقم إلى الأقرب من 250
            else if (remainder < 375)
            {
                return number - remainder + 250;
            }
            // إذا كان الباقي بين 375 و 625، قم بتقريب الرقم إلى الأقرب من 500
            else if (remainder < 625)
            {
                return number - remainder + 500;
            }
            // إذا كان الباقي بين 625 و 875، قم بتقريب الرقم إلى الأقرب من 750
            else if (remainder < 875)
            {
                return number - remainder + 750;
            }
            // في حالة أخرى، قم بتقريب الرقم إلى الأقرب من 000
            else
            {
                return number - remainder + 1000;
            }
        }
        private void Txt_Uusd_TextChanged(object sender, EventArgs e)
        {
           /* decimal.TryParse(Txt_Uusd.Text.Replace(" $", ""), out decimal value1);
           
            UpdateCalculations();*/

        }
        private void Txt_Dsell_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(Txt_unit_price.Text, out decimal value1);
            decimal.TryParse(Txt_Dsell.Text, out decimal value2);
            decimal.TryParse(Txt_Uiqr.Text.Replace(" D", ""), out decimal value3);
            decimal.TryParse(Txt_Liqr.Text.Replace(" D", ""), out decimal value4);
            decimal.TryParse(Txt_Uusd.Text.Replace(" $", ""), out decimal value5);
            decimal.TryParse(Txt_Lusd.Text.Replace(" $", ""), out decimal value6);
            if (value2 == value3)
            {
                Txt_Ssell.Text = value5.ToString();
            }
            else if (value2 == value4)
            {
                Txt_Ssell.Text = value6.ToString();
            }
            else
            {
                decimal num = value2 / value1;
                Txt_Ssell.Text = num.ToString("0.00");
            }

            UpdateCalculations();

        }
       

        private void Txt_Ssell_TextChanged(object sender, EventArgs e)
        {
            // استبدال "$" لتحويل النص إلى قيمة عددية
            decimal.TryParse(Txt_Uusd.Text.Replace(" $", ""), out decimal value1);
            decimal.TryParse(Txt_Lusd.Text.Replace(" $", ""), out decimal value2);
            decimal.TryParse(Txt_Ssell.Text.Replace(" $", ""), out decimal value3);

           
            if (!string.IsNullOrEmpty(Txt_Ssell.Text))
            {
               
                if (value3 > value1)
                {
                    UpdateTxt_Ssell(value1);
                }
                else if (value3 < value2)
                {
                    UpdateTxt_Ssell(value2);
                }
                else
                {
                    // التأكد من تضمين رمز "$" في النص
                    UpdateTxt_Ssell(value3);
                }
            }
            UpdateCalculations();
        }

        private void UpdateTxt_Ssell(decimal value)
        {
            Txt_Ssell.TextChanged -= Txt_Ssell_TextChanged; // فصل معالج الحدث مؤقتًا
            Txt_Ssell.Text = value.ToString(); // تحديث النص بالقيمة ورمز "$"
            Txt_Ssell.TextChanged += Txt_Ssell_TextChanged; // إعادة ربط معالج الحدث
        }

        private void Txt_Dsell_KeyPress(object sender, KeyPressEventArgs e)
        {
            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
            if (Txt_Dsell.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //
            }

            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
            }
        }

     

        private void FRM_AddNumberSell_Load(object sender, EventArgs e)
        {
           
            ser_item.Select();
            UpdateSuggestions();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }

}

