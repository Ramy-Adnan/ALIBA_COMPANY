using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_stock : DevExpress.XtraEditors.XtraForm
    {
        int ID_stock;
        int rowCount;
        public FRM_stock()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            using (var dbContext = new ALIBA_COMPANY.AlibaRamyEntities())
            {

                var data = dbContext.TB_stock.AsQueryable().AsNoTracking().ToList();
                gridControl1.DataSource = data; 

                rowCount = gridView1.RowCount;
                lblNum.Text = rowCount.ToString();

            }
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            AddItemsToStore Add = new AddItemsToStore();
            Add.ShowDialog();
        }
        private List<DataTalef> dataDetails;
        private async Task LoadDataInBackground(int id)
        {
            try
            {
                dataDetails = await Task.Run(() =>
                {
                    using (var dbContext = new ALIBA_COMPANY.AlibaRamyEntities())
                    {
                        var data = dbContext.TB_details

                            .Where(x => x.order_id == id && x.action_id == 11).AsNoTracking()
                            .Select(x => new DataTalef
                            {

                                Name = x.TB_items.items_name,
                                Group = x.TB_items.TB_groups.groups_name,
                                Form = x.TB_items.items_form,
                                Num = x.details_num,

                            })
                               .ToList();

                        return data;

                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }
        private async void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string Wasel = GetFocusedRowCellValue("sto_id");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("sto_date")).Date;
                string Items = GetFocusedRowCellValue("sto_items");
                string Units = GetFocusedRowCellValue("sto_unit");


                if (int.TryParse(Wasel, out int wasell) && wasell != 0)
                {
                    DialogResult result = MessageBox.Show("هل تريد طباعة وصل ؟", "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await LoadDataInBackground(wasell);
                        // إعداد التقرير
                        XtraReport_Talef report = new XtraReport_Talef
                        {

                            // تعيين dataList كمصدر بيانات للتقرير

                            DataSource = dataDetails
                        };
                        var parameters = new Dictionary<string, object>
                        {

                        { "Wasel", Wasel },
                        { "Date", Date },
                        { "Items", Items },
                        { "Units", Units }
                        };

                        SetReportParameters(report, parameters);
                        report.ShowPreview();

                    }
                }
                else
                {
                    MessageBox.Show("اختر صفًا", "لا يمكن اجراء العملية");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
        private void SetReportParameters(XtraReport_Talef report, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {

                if (report.Parameters[param.Key] != null)
                {
                    report.Parameters[param.Key].Value = param.Value;
                }
            }
        }

        private void Btn_new_Click_1(object sender, EventArgs e)
        {
            try
            {
                AddItemsToStore Add = new AddItemsToStore
                {
                    IN_OUT_STOCK = 11,
                    Text = "اخراج التالف من المخزن"
                };

                if (Add.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في العملية Btn_new_Click_1", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                try
                {
                    string st = GetFocusedRowCellValue("sto_id");

                    if (int.TryParse(st, out int intg) && intg != 0)
                    {
                        ID_stock = intg;
                    }

                    if (ID_stock > 0)
                    {

                        using (var context = new AlibaRamyEntities())
                        {
                            var stockItem = context.TB_stock.Include("TB_users").FirstOrDefault(o => o.sto_id == ID_stock);

                            if (stockItem == null)
                            {
                                MessageBox.Show("لم يتم العثور على العتاصر التالفه stockItem return", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (stockItem.user_id == AddPage.Users.Idd || AddPage.Users.userRole =="مدير")
                            {
                                var recordsToDeleteTBStr = context.TB_str.Where(o => o.order_id == ID_stock&&o.action_id==11).ToList();
                                if (recordsToDeleteTBStr == null)
                                {
                                    MessageBox.Show("لم يتم العثور على str", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                var recordsToDeleteTBDetails = context.TB_details.Where(o => o.order_id == ID_stock && o.action_id == 11).ToList();
                                if (recordsToDeleteTBDetails == null)
                                {
                                    MessageBox.Show("لم يتم العثور على details", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                context.TB_str.RemoveRange(recordsToDeleteTBStr);
                                context.TB_details.RemoveRange(recordsToDeleteTBDetails);
                                context.Entry(stockItem).State = System.Data.Entity.EntityState.Deleted;
                                context.SaveChanges();
                                MessageBox.Show("تم حذف التالف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("ليس من صلاحيتك الحذف", "لا يمكن اجراء الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" حدد البيانات  التي تريد حذفها");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FRM_stock_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
