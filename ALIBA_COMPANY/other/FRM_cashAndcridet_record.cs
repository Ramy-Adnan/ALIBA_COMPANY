using ALIBA_COMPANY.classes;

using System;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_cashAndcridet_record : DevExpress.XtraEditors.XtraForm
    {
        int ID_emplo;

        public FRM_cashAndcridet_record()
        {
            InitializeComponent();

        }
        private void Load_GridView()
        {
            if (ID_emplo != 0)
            {

                try
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        loading.Visible = true;

                        var data = db.TB_cridet
                            .Where(x => x.emplo_id == ID_emplo || x.pr_id == ID_emplo && x.sending == true)
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
            else
            {
                gridControl1.DataSource = null;
                lbl_count.Text = "0";
                lbl_cridit.Text = "0 $";
                lbl_irq.Text = "0 د.ع";
                lbl_usd.Text = "0 $";
                lbl_cridit_him.Text = "0 $";
            }

        }
        private void Load_Combo_driver()
        {
            try
            {
                // 1. حفظ الاسم المختار حالياً قبل التحديث
                string selectedName = Combo_driver.SelectedItem?.ToString();

                using (var db = new AlibaRamyEntities())
                {
                    var TT = db.TB_emplo
                        .Where(x => x.emplo_activity == true&&x.emplo_dis==true)
                        .AsNoTracking()
                        .Select(x => x.emplo_name)
                        .Distinct()
                        .ToList();

                    TT.Insert(0, "");

                    // 2. تحديث مصدر البيانات
                    Combo_driver.DataSource = TT;

                    // 3. إعادة الاختيار إذا كان الاسم لا يزال موجوداً في القائمة الجديدة
                    if (!string.IsNullOrEmpty(selectedName) && TT.Contains(selectedName))
                    {
                        Combo_driver.SelectedItem = selectedName;
                    }
                    else
                    {
                        Combo_driver.SelectedIndex = 0; // العودة للفراغ إذا لم يعثر عليه
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Combo_driver: {ex.Message}");
            }
        }
        private void Set_ID_driver()
        {
           
                try
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var selectedDriver = Combo_driver.SelectedItem.ToString();
                        var Idd = db.TB_emplo
                            .Where(x => x.emplo_name == selectedDriver).AsNoTracking()
                            .Select(x => x.emplo_id)
                            .FirstOrDefault();
                        ID_emplo = Idd > 0 ? Idd : 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error setting ID_driver: " + ex.Message);
                }
            
        }


        private void Btn_new_Click(object sender, EventArgs e)
        {
            
                try
                {
                    if (ID_emplo > 0)
                    {
                        FRM_cashAndcridet_Add Add = new FRM_cashAndcridet_Add();
                        Add.ID_emplo = ID_emplo;
                        Add.page = this;

                        if (Add.ShowDialog() == DialogResult.OK)
                        {
                           Load_Combo_driver();
                        }
                    }
                    else
                    {
                        MessageBox.Show("اختر موزع");
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
                                Notifications.ShowToast("تم الحذف", "تم حذف الوصل بنجاح");
                            }
                            else
                            {
                                MessageBox.Show("خطا في تحديد البيانات");
                            }
                        }
                    }
                    else
                    {
                        try { Notifications.ShowToast("لا تـوجد بيانـات لحذفها ", " "); } catch { }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ: " + ex.Message);
                }
            }


        }

        private void FRM_cashAndcridet_record_Load(object sender, EventArgs e)
        {
            Load_Combo_driver();
        }

        private void Combo_driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_driver();
            Load_GridView();
        }

        
    }
}