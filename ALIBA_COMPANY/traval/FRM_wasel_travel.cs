using ALIBA_COMPANY.sold;
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

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_wasel_travel : DevExpress.XtraEditors.XtraForm
    {
        public string ID_driver;
        public int ID_traval;
        private ALIBA_COMPANY.AlibaRamyEntities db;
        public FRM_wasel_travel()
        {
            InitializeComponent();
             
            db = new ALIBA_COMPANY.AlibaRamyEntities();
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
                            .Where(x => x.tr_id == ID_traval).AsNoTracking()
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

        private void FRM_wasel_travel_Load(object sender, EventArgs e)
        {
            Load_GridView();
        }
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void ShowDetailsForm(int id, string units, string items, DateTime Date, string driver, string cust, string code, string Wus, string Crus, string Total)
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
                string cellValue = GetFocusedRowCellValue("list_id");

                string code = GetFocusedRowCellValue("list_code");
                string Wus = GetFocusedRowCellValue("list_scashUsd");
                string Total = GetFocusedRowCellValue("list_amountUsd");
                string Crus = GetFocusedRowCellValue("list_cridetUsd");
                string items = GetFocusedRowCellValue("list_items");
                string units = GetFocusedRowCellValue("list_unit");
                string cust = GetFocusedRowCellValue("list_name");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("list_date")).Date;
                string driver = ID_driver;
                if (int.TryParse(cellValue, out int wasell) && wasell != 0)
                {
                    ShowDetailsForm(wasell, units, items, Date, driver, cust, code, Wus, Crus, Total);
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات, اختر صفًا لعرضه", "لا يمكن اجراء العملية");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("خطأ في الاتصال بقاعدة البيانات Btn_datials", "خطأ في الاتصال"+ ex);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("خطأ في تنسيق البيانات", "خطأ في التنسيق"+ ex);
            }
        }
    }
}