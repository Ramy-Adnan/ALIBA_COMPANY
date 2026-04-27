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
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using DevExpress.XtraReports.UI;

namespace ALIBA_COMPANY.Store
{
    public partial class page_inside : DevExpress.XtraEditors.XtraUserControl
    {
        Note note; 
        int rowCount;
        int OrderId;
        public page_inside()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            using (var dbContext = new ALIBA_COMPANY.AlibaRamyEntities())
            {

                var data = from order in dbContext.TB_order.AsQueryable().AsNoTracking().Where(item => item.action_id == 1)

                           group order by new { order.order_id, order.order_code, order.TB_branchs.br_code, order.TB_branchs.br_name, order.order_date, order.driver_name, order.car_name, order.order_items, order.order_unit, order.order_nots, order.order_status } into g
                           select new
                           {
                               Branchcode = g.Key.br_code,
                               Date = g.Key.order_date,
                               Driver = g.Key.driver_name,
                               Car = g.Key.car_name,
                               Items = g.Key.order_items,
                               Unit = g.Key.order_unit,
                               Note = g.Key.order_nots,
                               Status = g.Key.order_status,
                               order_code = g.Key.order_code,
                               order_id = g.Key.order_id,
                               B = g.Key.br_name
                           };

                var resultList = data.ToList();


                var formattedResults = resultList.Select(g => new
                {
                    g.B,
                    g.order_id,
                    g.Branchcode,
                    g.Car,
                    g.Date,
                    g.Driver,
                    g.Status,
                    g.Items,
                    g.Note,
                    g.Unit,
                    WaselNum = g.Branchcode + "-" + g.order_code.ToString().PadLeft(4, '0')
              
                }).ToList();





                gridControl1.DataSource = formattedResults;

                rowCount = gridView1.RowCount;
                lblNum.Text = rowCount.ToString();
            }
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemsToStore Add = new AddItemsToStore();
                Add.IN_OUT_STOCK = 1;
                Add.Text = "نقل المواد الى المخزن";
                Add.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في العملية Btn_new_Click", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            var reslt = MessageBox.Show("هل تريد الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reslt == DialogResult.Yes)
            {
                try
                {
                    string st = GetFocusedRowCellValue("order_id");

                    if (int.TryParse(st, out int intg) && intg != 0)
                    {
                        OrderId = intg;
                    }
                    string Wasel = GetFocusedRowCellValue("WaselNum");
                    if (OrderId > 0)
                    {

                        using (var context = new AlibaRamyEntities())
                        {
                            var travelItem = context.TB_order.FirstOrDefault(o => o.order_id == OrderId && o.action_id == 1);

                            if (travelItem == null)
                            {
                                MessageBox.Show("خطا في الاتصال TBorder", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (travelItem.user_id == AddPage.Users.Idd || AddPage.Users.userRole == "مدير")
                            {
                                var recordsToDeleteTBStr = context.TB_str.Where(o => o.order_id == OrderId && o.action_id == 1).ToList();
                                if (recordsToDeleteTBStr == null)
                                {
                                    MessageBox.Show("خطا في الاتصال TBstr", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                var recordsToDeleteTBDetails = context.TB_details.Where(o => o.order_id == OrderId && o.action_id == 1).ToList();
                                if (recordsToDeleteTBDetails == null)
                                {
                                    MessageBox.Show("خطا في الاتصال TBdetails", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                context.TB_str.RemoveRange(recordsToDeleteTBStr);
                                context.TB_details.RemoveRange(recordsToDeleteTBDetails);

                                context.Entry(travelItem).State = System.Data.Entity.EntityState.Deleted;
                                context.SaveChanges();

                                // Add new notification
                                note = new Note();
                                pages.Notifications notifications = new pages.Notifications();
                                var Note = " حذف النقل الداخل " + Wasel;
                                note.AddNote(Note, notifications, "حذف", 5);

                                LoadData();
                                MessageBox.Show("تم حذف الداخل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("ليس من صلاحيتك", "لا يمكن اجراء الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("لاتوجد بيانات ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void page_inside_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private List<DataInside> dataDetails;

        private async Task LoadDetailsAsync(int id)
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                dataDetails = await Task.Run(() =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var data = db.TB_str
                           .Where(x => x.order_id == id && x.action_id == 1).AsNoTracking()
                           .Select(x => new DataInside
                           {

                               Name = x.TB_items.items_name,
                               Num = x.str_num,
                               Form = x.TB_items.items_form,
                               Price = x.TB_items.Usd_upper,
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
        private async void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string Id = GetFocusedRowCellValue("order_id");
                string Code = GetFocusedRowCellValue("WaselNum");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("Date")).Date;
                string Car = GetFocusedRowCellValue("Car");
                string City = GetFocusedRowCellValue("B");
                string Driver = GetFocusedRowCellValue("Driver");
               
                string Items = GetFocusedRowCellValue("Items");
                string Units = GetFocusedRowCellValue("Unit");
                string Action = "داخل";

                if (int.TryParse(Id, out int wasell) && wasell != 0)
                {
                    DialogResult result = MessageBox.Show("هل تريد طباعة وصل ؟", "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await LoadDetailsAsync(wasell);
                        XtraReport_inside report = new XtraReport_inside();

                        // تعيين dataList كمصدر بيانات للتقرير

                        report.DataSource = dataDetails;
                        var parameters = new Dictionary<string, object>
                    {
                        { "action", Action },
                        { "Code", Code },
                        { "Date", Date },
                        { "City", City },
                        { "Driver", Driver },
                        { "Car", Car },
                        { "Items", Items },
                        { "Units", Units }
                    };

                        SetReportParameters(report, parameters);
                        report.ShowPreview();

                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " طباعة وصل نقل داخل " + Id;
                        note.AddNote(Note, notifications, "طباعة", 6);
                    }
                    else
                    {
                        MessageBox.Show("اختر صفًا", "لا يمكن اجراء العملية");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ غير متوقع: " + ex.Message, "خطأ");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void SetReportParameters(XtraReport_inside report, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {

                if (report.Parameters[param.Key] != null)
                {
                    report.Parameters[param.Key].Value = param.Value;
                }
            }
        }
    }
}