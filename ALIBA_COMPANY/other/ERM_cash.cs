using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class ERM_cash : DevExpress.XtraEditors.XtraForm
    {
        int ID_traval;
        int ID_traval2;
        public ERM_cash()
        {
            InitializeComponent();
        }
        private void Load_GridView()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    loading.Visible = true;

                    var data = db.TB_cridet
                        .Where(x => x.tr_id == ID_traval && x.action_id == 6)
                        .AsNoTracking()
                        .ToList();

                    this.Invoke((MethodInvoker)delegate
                    {
                        gridControl1.DataSource = data;
                        lbl_count.Text = gridView1.RowCount.ToString();

                        decimal sum = 0;
                        decimal sum2 = 0;
                        decimal cridit = 0;
                        decimal cridit_him = 0;

                        string selectedDriver = Combo_driver.Text.Trim().ToLower();

                        foreach (var item in data)
                        {
                            decimal cridetS = item.cridet_s ?? 0;
                            decimal cridetD = item.cridet_d ?? 0;
                            string empName = item.TB_emplo?.emplo_name?.Trim().ToLower();
                          
                            if (decimal.TryParse(cridetS.ToString(), out decimal value1))
                            {
                                sum += value1;
                                if (empName == selectedDriver)
                                {
                                    cridit += value1;
                                }
                                else if (empName != selectedDriver)
                                {
                                    cridit_him += value1;
                                }
                            }

                            if (decimal.TryParse(cridetD.ToString(), out decimal value2))
                            {
                                sum2 += value2;

                            }
                        }


                        

                        CultureInfo usdCulture = new CultureInfo("en-US");
                        CultureInfo dinarCulture = new CultureInfo("ar-IQ");

                        usdCulture.NumberFormat.CurrencySymbol = " $";
                        dinarCulture.NumberFormat.CurrencySymbol = " د.ع";
                        usdCulture.NumberFormat.CurrencyPositivePattern = 1;

                        lbl_cridit.Text = cridit.ToString("C2", usdCulture);
                        lbl_irq.Text = sum2.ToString("C2", dinarCulture);
                        lbl_usd.Text = sum.ToString("C2", usdCulture);
                        lbl_cridit_him.Text = cridit_him.ToString("C2", usdCulture);

                        loading.Visible = false;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة Load_GridView(): " + ex.Message);
                loading.Visible = false; // Ensure loading is hidden on error
            }
        }
        private void Load_Combo_driver()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {

                    var TT = db.TB_travel
                    .Where(x => x.tr_st_id == 1 && x.user_id2 == null).AsNoTracking()
                    .Select(x => x.TB_emplo.emplo_name)
                    .ToList();
                    TT.Insert(0, "");
                    Combo_driver.DataSource = TT;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Combo_Traval: {ex.Message}");
            }
        }
        private void Set_ID_driver()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var selectedDriver = Combo_driver.SelectedItem.ToString();
                    var Idd = db.TB_travel
                        .Where(x => x.TB_emplo.emplo_name == selectedDriver && x.tr_st_id == 1 && x.user_id2 == null)
                        .Select(x => x.tr_id)
                        .FirstOrDefault();
                    ID_traval = Idd > 0 ? Idd : 0; // Ensure ID_traval is set correctly
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting ID_driver: " + ex.Message);
            }
        }

        private void Load_Combo_Traval()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var TT = db.TB_travel
                   .Where(x => x.user_id2 == null && x.tr_st_id == 1).AsNoTracking()
                   .Select(x => x.TB_emplo.emplo_name)
                   .ToList();
                    TT.Insert(0, "");
                    Combo_travel.DataSource = TT;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Combo_Traval2: {ex.Message}");
            }
        }
        private void Set_ID_Traval()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {

                    var Iddd = db.TB_travel
                    .Where(x => x.TB_emplo.emplo_name == Combo_travel.SelectedItem.ToString() && x.tr_st_id == 1 && x.user_id2 == null)
                    .Select(x => x.tr_id)
                    .FirstOrDefault();
                    if (Iddd != 0)
                    {
                        ID_traval2 = Iddd;
                    }
                    else
                    {
                        ID_traval2 = 0;
                    }

                }
            }
            catch { }
        }
        private void ERM_cash_Load(object sender, EventArgs e)
        {
            Load_Combo_driver();
            Load_Combo_Traval();

        }

        private void Combo_driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_driver();
            Load_GridView();
        }

        private void Combo_travel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_Traval();
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID_traval2 > 0)
                {
                    FRM_cash_record Add = new FRM_cash_record();
                    Add.ID_traval = ID_traval2;
                    Add.page = this;
                   
                    if (Add.ShowDialog() == DialogResult.OK)
                    {
                        Load_GridView();
                    }
                }
                else
                {
                    MessageBox.Show("اختر سائق للسفره من الحقل المجاور");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في العملية Btn_sell_Click", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string id = GetFocusedRowCellValue("cridet_id");

                    if (int.TryParse(id, out int cridetId) && cridetId != 0)
                    {
                        using (var db = new AlibaRamyEntities())
                        {
                           
                           
                            var entity = db.TB_cridet.FirstOrDefault(item => item.cridet_id == cridetId);
                            if (entity != null)
                            {
                                db.TB_cridet.Remove(entity);
                                db.SaveChanges();
                                Load_GridView();
                                MessageBox.Show("تم حذف البيانات");
                            }
                            else
                            {
                                MessageBox.Show("خطا في تحديد البيانات");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات لحذفها");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ: " + ex.Message);
                }
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            string Num = GetFocusedRowCellValue("cridet_code");
            if (int.TryParse(Num, out int intg) && intg != 0)
            {

                var Result = MessageBox.Show("هل تريد طباعة وصل ", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {

                    try
                    {
                        string Cust = GetFocusedRowCellValue("list_name");
                        string Driver = GetFocusedRowCellValue("TB_emplo.emplo_name");


                        decimal cridet_s = decimal.Parse(GetFocusedRowCellValue("cridet_s"));

                        DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("cridet_date")).Date;
                        string User = AddPage.Users.FullName;



                        XtraReport_q report = new XtraReport_q();

                        report.Parameters["Cust"].Value = Cust;
                        report.Parameters["Date"].Value = Date;
                        report.Parameters["driver"].Value = Driver;
                        report.Parameters["Num"].Value = Num;
                        report.Parameters["cridit_s"].Value = cridet_s;
                        report.Parameters["word"].Value = ConvertToWords(cridet_s);
                        report.Parameters["emplo"].Value = User;
                        report.ShowPreview();


                        /*note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " طباعة طلب " + Emplo;
                        note.AddNote(Note, notifications, "طباعة", 6);*/


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"خطأ في الاتصال - Btn_print_Click: {ex.Message}");
                    }

                }
            }
        }
        public static string ConvertToWords(decimal amount)
        {
            if (amount == 0)
            {
                return "صفر دولار";
            }

            string words = "";

           
            int dollars = (int)amount;
            int cents = (int)((amount - dollars) * 100);

            if (dollars > 0)
            {
                words += NumberToWords(dollars) + " دولار";
            }

            if (cents > 0)
            {
                if (!string.IsNullOrEmpty(words))
                {
                    words += " و ";
                }
                words += NumberToWords(cents) + " سنت";
            }

            return words;
        }

        private static string NumberToWords(int number)
        {
            if (number == 0)
            {
                return "صفر";
            }

            string[] units = { "صفر", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
            string[] teens = { "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
            string[] tens = { "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
            string[] thousands = { "", "ألف", "مليون", "مليار" };

            if (number < 10)
            {
                return units[number];
            }

            if (number < 20)
            {
                return teens[number - 10];
            }

            if (number < 100)
            {
                return tens[number / 10] + (number % 10 != 0 ? " و " + units[number % 10] : "");
            }

            if (number < 1000)
            {
                return units[number / 100] + " مئة" + (number % 100 != 0 ? " و " + NumberToWords(number % 100) : "");
            }

            for (int i = 0; i < thousands.Length; i++)
            {
                int divisor = (int)Math.Pow(1000, i);
                if (number < divisor * 1000)
                {
                    return NumberToWords(number / divisor) + " " + thousands[i] + (number % divisor != 0 ? " و " + NumberToWords(number % divisor) : "");
                }
            }

            return null;
        }
    }
}