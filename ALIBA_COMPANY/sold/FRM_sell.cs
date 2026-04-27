using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_sell : DevExpress.XtraEditors.XtraForm
    {
        public int ID_traval = 0;
        public int ID_traval2 = 0;
        public int EmploForAccountsForm_ID = 0;
        private ALIBA_COMPANY.AlibaRamyEntities db;
        public FRM_sell()
        {
            InitializeComponent();
            try
            {
                db = new ALIBA_COMPANY.AlibaRamyEntities();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database connection: {ex.Message}");
            }
        }

        private void Load_Combo_driver()
        {
            try
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }

                db.Database.Connection.Open();

                var TT = db.TB_travel
                .Where(x => x.tr_sending == true && x.user_id2 == null).AsNoTracking()
                .Select(x => x.TB_emplo.emplo_name)
                .ToList();
                TT.Insert(0, "");
                Combo_driver.DataSource = TT;

                db.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Combo_Traval: {ex.Message}");
            }
        }

        private void Set_ID_Traval()
        {
            try
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }

                db.Database.Connection.Open();

                var Idd = db.TB_travel
                    .Where(x => x.TB_emplo.emplo_name == Combo_driver.SelectedItem.ToString() && x.tr_sending == true && x.user_id2 == null)
                    .Select(x => x.tr_id)
                    .FirstOrDefault();
                    if (Idd != 0)
                    {
                        ID_traval = Idd;
                    }
                    else
                    {
                        ID_traval = 0;
                    }
                
            }
            catch { }
        }
        private void Load_Combo_Traval2()
        {
            try
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }

                db.Database.Connection.Open();
                var TT = db.TB_travel
                .Where(x => x.user_id2 == null ).AsNoTracking()
                .Select(x => x.TB_emplo.emplo_name)
                .ToList();
                TT.Insert(0, "");
                Combo_travel.DataSource = TT;

                db.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Combo_Traval2: {ex.Message}");
            }
        }
        private void Set_ID_Traval2()
        {
            try
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }

                db.Database.Connection.Open();

                var travelData = db.TB_travel
                                    .Where(x => x.TB_emplo.emplo_name == Combo_travel.SelectedItem.ToString() && x.user_id2 == null)
                                    .Select(x => new { x.tr_id, x.emplo_id }) // جلب القيمتين معاً
                                    .FirstOrDefault();

                if (travelData != null)
                {
                    ID_traval2 = travelData.tr_id;
                    EmploForAccountsForm_ID = (int)travelData.emplo_id;
                }
                else
                {
                    ID_traval2 = 0;
                    EmploForAccountsForm_ID = 0; // يفضل تصفير القيمة الأخرى أيضاً
                }


            }
            catch { }
        }
        private void Load_GridView()
        {
            try
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }

                db.Database.Connection.Open();

                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;
                /*await Task.Run(() =>
                {*/

                    var data = db.TB_list
                            .Where(x => x.tr_id == ID_traval&&x.sending==true ).AsNoTracking()
                            .ToList();

                    this.Invoke((MethodInvoker)delegate
                    {
                        gridControl1.DataSource = data;
                        lbl_count.Text = gridView1.RowCount.ToString();

                        decimal sum = 0;
                        decimal sum2 = 0;
                        decimal cridit = 0;
                        for (int i = 0; i < gridView1.DataRowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "list_amountUsd") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_amountUsd").ToString(), out decimal value1))
                            {
                                sum += value1;
                            }

                            if (gridView1.GetRowCellValue(i, "list_amountIQ") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_amountIQ").ToString(), out decimal value2))
                            {
                                sum2 += value2;
                            }

                            if (gridView1.GetRowCellValue(i, "list_cridetUsd") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_cridetUsd").ToString(), out decimal usd))
                            {
                                cridit += usd;
                            }
                        }

                        CultureInfo usdCulture = new CultureInfo("en-US");
                        CultureInfo dinarCulture = new CultureInfo("ar-IQ");
                        usdCulture.NumberFormat.CurrencySymbol = " $";
                        dinarCulture.NumberFormat.CurrencySymbol = " د.ع";
                        // Customize the format to place the currency symbol after the number
                        usdCulture.NumberFormat.CurrencyPositivePattern = 1;
                        lbl_amount.Text = sum.ToString("C2", usdCulture);
                        lbl_irq.Text = sum2.ToString("C2", dinarCulture);
                        lbl_usd.Text = sum.ToString("C2", usdCulture);
                        lbl_cridit.Text = cridit.ToString("C2", usdCulture);
                    });

             
                loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة Load_GridView(): " + ex.Message);
            }
        }
        private void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_sell_mandob add = new FRM_sell_mandob();
                add.ID_travel = ID_traval;
                add.sellOrPage = 2;
                add.ShowDialog();
            }
            catch { MessageBox.Show(" - FRM_sell_mandob خطأ غير متوقع  "); }
        }
        private void Combo_driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_Traval();
            Load_GridView();
        }

        
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void ShowDetailsForm(int id,string units,string items,DateTime Date, string driver,string cust,string code,string Wus,string Crus,string Total)
        {
            FRM_details page = new FRM_details();
            page.ID_Wasel = id;
            page.items = items;
            page.units = units;
            page.date = Date;
            page.driver = driver;
            page.cust = cust;
            page.code = code;
            page.Wus = Wus;
            page.Total = Total;
            page.state = 1;
            page.Crus = Crus;
            page.ShowDialog();
        }
        private void Btn_detials_Click(object sender, EventArgs e)
        {
            try
            {
                string code = GetFocusedRowCellValue("list_code");
                string Wus = GetFocusedRowCellValue("list_scashUsd");
                string Total = GetFocusedRowCellValue("list_amountUsd");
                string Crus = GetFocusedRowCellValue("list_cridetUsd");
                string cellValue = GetFocusedRowCellValue("list_id");
                string items = GetFocusedRowCellValue("list_items");
                string units = GetFocusedRowCellValue("list_unit");
                string cust = GetFocusedRowCellValue("list_name");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("list_date")).Date;
                string driver = Combo_driver.Text;
                if (int.TryParse(cellValue, out int wasell) && wasell != 0)
                {
                    ShowDetailsForm(wasell,units,items, Date, driver,cust,code, Wus,Crus, Total);
                }
                else
                {
                    ShowErrorMessage("لا يوجد بيانات, اختر صفًا لعرضه", "لا يمكن اجراء العملية");
                }
            }
            catch (NullReferenceException ex)
            {
                ShowErrorMessage("خطأ في الاتصال بقاعدة البيانات Btn_datials", "خطأ في الاتصال", ex);
            }
            catch (FormatException ex)
            {
                ShowErrorMessage("خطأ في تنسيق البيانات", "خطأ في التنسيق", ex);
            }

        }
        private void ShowErrorMessage(string message, string caption, Exception ex = null)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (ex != null)
            {
                // Log the exception or perform additional error handling
            }
        }

        private void FRM_sell_Load(object sender, EventArgs e)
        {
            Load_Combo_driver();
            Load_Combo_Traval2();
        }

        private  void Btn_delete_Click(object sender, EventArgs e)
        {
            string cellValue = GetFocusedRowCellValue("list_id");
            if (int.TryParse(cellValue, out int wasell) && wasell != 0)
            {
                var rs = MessageBox.Show(" هل تريد حذف الوصل؟", "تاكييد", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                if (rs == DialogResult.Yes)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        var query = context.TB_det
                            .Where(det => det.TB_list.tr_id == ID_traval && det.list_id == wasell)
                            .Select(det => new
                            {
                                det.de_num,
                                det.items_id
                            });

                        foreach (var detItem in query)
                        {
                            var correspondingItem = context.TB_details.FirstOrDefault(item => item.order_id == ID_traval && item.items_id == detItem.items_id);
                            if (correspondingItem != null)
                            {
                                correspondingItem.sell_num = (correspondingItem.sell_num ?? 0) - detItem.de_num;
                                correspondingItem.sending = true;
                                context.Entry(correspondingItem).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        foreach (var detItem2 in query)
                        {
                            var rr = context.TB_temp.FirstOrDefault(r => r.order_id == ID_traval && r.items_id == detItem2.items_id);
                            if (rr != null)
                            {
                                rr.temp_renum = 0;
                                context.Entry(rr).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                       
                        var listToDelete = context.TB_list.FirstOrDefault(item => item.list_id == wasell);
                        if (listToDelete != null)
                        {
                            context.TB_list.Remove(listToDelete);
                        }

                        context.SaveChanges();

                        var check = context.TB_list.FirstOrDefault(x => x.tr_id == ID_traval&&x.sending==true);
                        if (check == null)
                        {
                            var update = context.TB_travel.FirstOrDefault(item => item.tr_id == ID_traval);
                            update.tr_sending = false;
                            update.tr_loading = 1;
                            context.Entry(update).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                        }
                    }
                   
                    Load_GridView();
                    Load_Combo_driver();
                }
            }
            else
            {
                ShowErrorMessage("لا يوجد بيانات، اختر صفًا لعرضه", "لا يمكن إجراء العملية");
            }
        }

        private void Btn_sell_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID_traval2 > 0)
                {
                    AddItemsToSell Add = new AddItemsToSell();
                    Add.AccORMandob = 1;
                    Add.Traval_Id = ID_traval2;
                    Add.EmploForAccountsForm_ID = EmploForAccountsForm_ID;
                    Add.page = this;
                   
                    if (Add.ShowDialog() == DialogResult.OK)
                    {
                       

                        var openForm = Application.OpenForms.OfType<FRM_sell>().FirstOrDefault();

                        // إذا كانت النافذة مفتوحة، أغلقها
                        if (openForm != null)
                        {
                            openForm.Close();
                            openForm.Dispose();
                        }

                        FRM_sell newItemForm = new FRM_sell();

                        newItemForm.Show();

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

        private void Combo_travel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_Traval2();
        }

       

        private void Btn_amanah_Click(object sender, EventArgs e)
        {
            MessageBox.Show("غير مفعل في هذه النسخة ", "مهندس رامي -_-", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FRM_sell_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Clear data source
            gridControl1.DataSource = null;

            // Dispose of disposable objects
            if (db != null)
            {
                db.Dispose();
                db = null;
            }

            if (gridControl1 != null)
            {
                gridControl1.Dispose();

                gridControl1 = null;
            }


            CleanUpControls(this);

            // Force garbage collection
            GC.Collect();
        }

        private void CleanUpControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is IDisposable)
                {
                    (control as IDisposable).Dispose();
                }
                if (control.HasChildren)
                {
                    CleanUpControls(control);
                }
            }
        }
    
    }
 
}