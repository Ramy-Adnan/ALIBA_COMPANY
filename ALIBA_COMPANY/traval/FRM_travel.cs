using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
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

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_travel : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        int ID_travel = 0;
        readonly ALIBA_COMPANY.AlibaRamyEntities dbContext;
        public FRM_travel()
        {
            InitializeComponent();
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            LoadDataInBackground();
            SetupGridView();
        }
        private List<DataTravel> dataList;
        private async void LoadDataInBackground()
        {
            try
            {
                //dbContext.TB_travel.Local.Clear();
              
                gridControl1.DataSource = null;
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;

                dataList = await Task.Run(() =>
                {
                    var data = dbContext.TB_travel
                        .Where(x => x.user_id2 == null).AsNoTracking()
                        .Select(x => new DataTravel
                        {
                            Tr = x.tr_id,
                            Date = (DateTime)x.tr_date,
                            Items = x.tr_items,
                            Units = x.tr_unit,
                            Emplo = x.TB_emplo.emplo_name,
                            Car = x.TB_cars.car_name,
                            Note = x.tr_nots,
                            City = x.TB_city.city_name,
                            Status = x.tr_st_staus,
                        })
                        .ToList();

                    return data;
                });
               /* var data = await Task.Run(() =>
                {
                    return dbContext.TB_travel
                         .Where(x => x.user_id2 == null).AsNoTracking()
                        .ToList();
                });*/

                gridControl1.BeginInvoke((MethodInvoker)delegate
                {
                    // إفراغ مصدر البيانات
                    gridControl1.DataSource = dataList; // إعادة تحميل البيانات
                    gridView1.RefreshData(); // تحديث عرض البيانات
                    gridControl1.RefreshDataSource();
                    lblNum.Text = gridView1.RowCount.ToString();
                });

                loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }

        private void SetupGridView()
        {
            gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddTraval Add = new AddTraval
            {
                ID_travel = 0
            };
            //  Add.page = this;
            if (Add.ShowDialog() == DialogResult.OK)
            {

                LoadDataInBackground();
            }
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                string st = GetFocusedRowCellValue("Tr");

                if (int.TryParse(st, out int intg) && intg != 0)
                {
                    ID_travel = intg;
                }
                else
                {
                    ID_travel = 0;
                }

                if (ID_travel > 0)
                {
                    AddTraval Add = new AddTraval
                    {
                        ID_travel = ID_travel
                    };
                    //   Add.page = this;

                    if (Add.ShowDialog() == DialogResult.OK)
                    {

                        var openForm = Application.OpenForms.OfType<FRM_travel>().FirstOrDefault();

                        // إذا كانت النافذة مفتوحة، أغلقها
                        if (openForm != null)
                        {
                            openForm.Close();
                            openForm.Dispose();
                        }

                        FRM_travel newItemForm = new FRM_travel();

                        newItemForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("لا بيانات لتعديلها");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في العملية", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_add_back_Click(object sender, EventArgs e)
        {
            try
            {
                string cellValue1 = GetFocusedRowCellValue("Tr");

                if (int.TryParse(cellValue1, out int ID_traval) && ID_traval != 0)
                {
                    Showback_add(ID_traval);
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات, اختر صفًا لعرضه", "لا يمكن اجراء العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("خطأ في الاتصال بقاعدة البيانات Btn_add_back", "خطأ في الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Btn_edit_back_Click(object sender, EventArgs e)
        {
            try
            {
                string cellValue1 = GetFocusedRowCellValue("Tr");

                if (int.TryParse(cellValue1, out int ID_traval) && ID_traval != 0)
                {
                    Showback_edit(ID_traval);
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات, اختر صفًا لعرضه", "لا يمكن اجراء العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("خطأ في الاتصال بقاعدة البيانات Btn_add_back", "خطأ في الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Showback_add(int id)
        {
            string cellValue2 = GetFocusedRowCellValue("tr_items");
            string cellValue3 = GetFocusedRowCellValue("tr_unit");
            string cellValue4 = GetFocusedRowCellValue("TB_cars.car_name");
            string cellValue5 = GetFocusedRowCellValue("TB_emplo.emplo_name");
            FRM_back_add page = new FRM_back_add();
            page.ID_traval = id;
            page.NewOrEdit = 0;
            page.LblWasel.Text = id.ToString();
            page.LblNum.Text = cellValue2;
            page.LblUnit.Text = cellValue3;
            page.LblCar.Text = cellValue4;
            page.LblDriver.Text = cellValue5;
            page.ShowDialog();
        }
        private void Showback_edit(int id)
        {
            string cellValue2 = GetFocusedRowCellValue("tr_items");
            string cellValue3 = GetFocusedRowCellValue("tr_unit");
            string cellValue4 = GetFocusedRowCellValue("TB_cars.car_name");
            string cellValue5 = GetFocusedRowCellValue("TB_emplo.emplo_name");
            FRM_back_add page = new FRM_back_add
            {
                ID_traval = id,
                NewOrEdit = 1
            };
            page.LblWasel.Text = id.ToString();
            page.LblNum.Text = cellValue2;
            page.LblUnit.Text = cellValue3;
            page.LblCar.Text = cellValue4;
            page.LblDriver.Text = cellValue5;
            page.ShowDialog();
        }
        private void Btn_delete_back_Click(object sender, EventArgs e)
        {

            try
            {
                string st = GetFocusedRowCellValue("Tr");

                if (int.TryParse(st, out int intg) && intg != 0)
                {
                    ID_travel = intg;
                }

                if (ID_travel > 0)
                {
                    var confirmationResult = MessageBox.Show("هل تريد الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmationResult == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        using (var context = new AlibaRamyEntities())
                        {
                            var Traval_back = context.TB_travel.FirstOrDefault(x => x.tr_id == ID_travel);
                            if (Traval_back != null && Traval_back.tr_st_id == 2)
                            {
                                Traval_back.tr_st_id = 1;
                                Traval_back.tr_st_staus = "قيد التوزيع";
                                Traval_back.tr_reitems = null;
                                Traval_back.tr_reunit = null;
                                context.Entry(Traval_back).State = System.Data.Entity.EntityState.Modified;

                                var ItemSell = context.TB_details.Where(x => x.order_id == ID_travel && x.action_id == 3).ToList();
                                if (ItemSell.Any())
                                {
                                    foreach (var item1 in ItemSell)
                                    {
                                        item1.details_renum = 0;
                                        context.Entry(item1).State = System.Data.Entity.EntityState.Modified;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("جلب الراجع من المخزن غير متوفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                var Back_add = context.TB_str.Where(x => x.order_id == ID_travel && x.action_id == 3).ToList();
                                if (Back_add.Any())
                                {
                                    foreach (var item in Back_add)
                                    {
                                        item.str_renum = 0;
                                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("جلب الراجع من المخزن غير متوفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Null of Traval_back لا يوجد راجع او السفرة لم تكتمل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            context.SaveChanges();

                            // Add new notification
                            note = new Note();
                            pages.Notifications notifications = new pages.Notifications();
                            var Note = " حذف راجع السفرة  " + ID_travel;
                            note.AddNote(Note, notifications, "حذف راجع", 2);

                            MessageBox.Show("تم حذف الراجع بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Cursor.Current = Cursors.Default;
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


        private void Btn_refrsh_Click(object sender, EventArgs e)
        {
            gridView1.ClearColumnsFilter();
            gridView1.ClearSorting();
            gridView1.ClearGrouping();
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterEnabled = false;

            // dbContext.TB_travel.Local.Clear();
            gridControl1.DataSource = null;
            LoadDataInBackground();
            gridView1.RefreshData();
            
        }


        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }

       
        //private Lazy<XtraReport_wasel_total> _report = new Lazy<XtraReport_wasel_total>(() => new XtraReport_wasel_total());

        private List<DataSellTravel> dataDetails;

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
                    var data = dbContext.TB_details
                        .Where(x => x.order_id == id&& x.action_id==3).AsNoTracking()
                        .Select(x => new DataSellTravel
                        {
                           
                            Name = x.TB_items.items_name,
                            Price = x.TB_items.IQD_upper,
                            Recived = x.details_num,
                            Return = x.details_renum,
                            Sold = x.sell_num,
                           
                        })
                        .ToList();

                    return data;
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
                string Tr = GetFocusedRowCellValue("Tr");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("Date")).Date;
                string City = GetFocusedRowCellValue("City");
                string Emplo = GetFocusedRowCellValue("Emplo");
                string Status = GetFocusedRowCellValue("Status");
                string Car = GetFocusedRowCellValue("Car");
                string Items = GetFocusedRowCellValue("Items");
                string Units = GetFocusedRowCellValue("Units");


                if (int.TryParse(Tr, out int wasell) && wasell != 0)
                {
                    DialogResult result = MessageBox.Show("هل تريد طباعة وصل ؟", "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await LoadDetailsAsync(wasell);
                        // إعداد التقرير
                        XtraReport_wasel_total report = new XtraReport_wasel_total
                        {

                            // تعيين dataList كمصدر بيانات للتقرير

                            DataSource = dataDetails
                        };
                        var parameters = new Dictionary<string, object>
                        {

                        { "Tr", Tr },
                        { "Date", Date },
                        { "City", City },
                        { "Emplo", Emplo },
                        { "Status", Status },
                        { "Car", Car },
                        { "Items", Items },
                        { "Units", Units }
                        };

                        SetReportParameters(report, parameters);
                        report.ShowPreview();
                        // Add new notification
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " طباعة وصل صفرة  " + Tr;
                        note.AddNote(Note, notifications, "طباعة", 6);
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
        private void SetReportParameters(XtraReport_wasel_total report, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {

                if (report.Parameters[param.Key] != null)
                {
                    report.Parameters[param.Key].Value = param.Value;
                }
            }
        }
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            var reslt = MessageBox.Show("هل تريد الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reslt == DialogResult.Yes)
            {
                try
                {
                    string st = GetFocusedRowCellValue("Tr");

                    if (int.TryParse(st, out int intg) && intg != 0)
                    {
                        ID_travel = intg;
                    }

                    if (ID_travel > 0)
                    {

                        using (var context = new AlibaRamyEntities())
                        {
                            var travelItem = context.TB_travel.Include("TB_emplo").Include("TB_cars").FirstOrDefault(o => o.tr_id == ID_travel);

                            if (travelItem == null)
                            {
                                MessageBox.Show("لم يتم العثور على السفره", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (travelItem.user_id2 == null && travelItem.tr_sending == false)
                            {
                                if (travelItem.user_id == AddPage.Users.Idd || AddPage.Users.userRole == "مدير")
                                {
                                    var recordsToDeleteTBStr = context.TB_str.Where(o => o.order_id == ID_travel && o.action_id == 3).ToList();
                                    if (recordsToDeleteTBStr == null)
                                    {
                                        MessageBox.Show("لم يتم العثور على str", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    var recordsToDeleteTBDetails = context.TB_details.Where(o => o.order_id == ID_travel && o.action_id == 3).ToList();
                                    if (recordsToDeleteTBDetails == null)
                                    {
                                        MessageBox.Show("لم يتم العثور على details", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    var recordsToDeleteTBTemp = context.TB_temp.Where(o => o.order_id == ID_travel && o.action_id == 3).ToList();
                                    if (recordsToDeleteTBTemp == null)
                                    {
                                        MessageBox.Show("لم يتم العثور على temp", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    context.TB_str.RemoveRange(recordsToDeleteTBStr);
                                    context.TB_details.RemoveRange(recordsToDeleteTBDetails);
                                    context.TB_temp.RemoveRange(recordsToDeleteTBTemp);

                                    if (travelItem.TB_emplo != null)
                                    {
                                        travelItem.TB_emplo.emplo_traval_active = false;
                                        context.Entry(travelItem.TB_emplo).State = System.Data.Entity.EntityState.Modified;
                                    }
                                    else
                                    {
                                        MessageBox.Show("لم يتم العثور على السائق المرتبط بالسفره", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    if (travelItem.TB_cars != null)
                                    {
                                        travelItem.TB_cars.car_traval_active = false;
                                        context.Entry(travelItem.TB_cars).State = System.Data.Entity.EntityState.Modified;
                                    }
                                    else
                                    {
                                        MessageBox.Show("لم يتم العثور على السيارة المرتبطة بالسفره", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    context.Entry(travelItem).State = System.Data.Entity.EntityState.Deleted;
                                    context.SaveChanges();

                                    // Add new notification
                                    note = new Note();
                                    pages.Notifications notifications = new pages.Notifications();
                                    var Note = " حذف سفرة " + ID_travel;
                                    note.AddNote(Note, notifications, "حذف", 5);

                                    LoadDataInBackground();
                                    MessageBox.Show("تم حذف السفره بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("ليس من صلاحيتك", "لا يمكن اجراء الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("السفره تحتوي على وصولات", "لا يمكن اجراء الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /*  private void UpdateDriver()
          {
              using (var db = new AlibaRamyEntities())
              {

                  var driver = db.TB_travel.FirstOrDefault(x => x.tr_id == ID_travel);
                  driver.TB_emplo.emplo_traval_active = false;
                  db.Entry(driver).State = System.Data.Entity.EntityState.Modified;
                  db.SaveChanges();

              }

          }
          private void UpdateCar()
          {
              using (var db = new AlibaRamyEntities())
              {

                  var car = db.TB_travel.FirstOrDefault(x => x.tr_id == ID_travel);
                  car.TB_cars.car_traval_active = false;
                  db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                  db.SaveChanges();

              }

          }*/

    }
}