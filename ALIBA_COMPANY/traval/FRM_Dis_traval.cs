using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using ALIBA_COMPANY.sold;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_Dis_traval : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        public int ID_City;
        public int ID_Car;
        public int ID_Driver;
        private ALIBA_COMPANY.AlibaRamyEntities db;
        public FRM_Dis_traval()
        {
            InitializeComponent();
            db = new ALIBA_COMPANY.AlibaRamyEntities();
            Init();
        }
        void Init()
        {

            gridView1.RowCellStyle += OnRowCellStyle;
            gridView1.RowStyle += OnRowStyle;

            Txt_Wasel.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 20);
            Txt_items.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_units.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 20);
         

        }
        private void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "tr_st_staus")
            {
                if (view.GetRowCellValue(e.RowHandle, "tr_st_staus") is string mark)
                {
                    if (mark == "قيد التوزيع")
                    {
                        e.Appearance.BackColor = Color.OrangeRed;
                        e.Appearance.BackColor2 = Color.BlueViolet;
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                    else if (mark == "راجع")
                    {
                        e.Appearance.BackColor = Color.DarkGreen;
                        e.Appearance.BackColor2 = Color.LightGreen;
                        e.Appearance.ForeColor = Color.White;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

                    }


                }
                else
                {
                    e.Appearance.BackColor = Color.BurlyWood;
                }
            }

        }
        private void OnRowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string mark = view.GetRowCellValue(e.RowHandle, "tr_luck") as string;

                if (mark != null)
                {
                    if (mark == "")
                    {

                    }
                }
                else
                {
                    //   e.Appearance.BackColor = Color.BurlyWood;
                    e.Appearance.BackColor = Color.LightCyan;
                    e.Appearance.BackColor2 = Color.AntiqueWhite;
                    //    e.Appearance.ForeColor = Color.Yellow;
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                }
            }
         //   gridView1.Columns[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(60, 0, 0, 240);

            gridView1.OptionsSelection.EnableAppearanceHideSelection = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.YellowGreen;
            gridView1.Appearance.FocusedCell.BackColor = Color.FromArgb(60, 15, 0, 255);
        }

        private void LoadCity()
        {
            try
            {
                var ff= db.TB_city.Select(x => x.city_name).AsQueryable().ToList();
                ff.Insert(0, "");
                Combo_city.DataSource = ff;
            }
            catch { }
        }
       
        private void LoadCars()
        {
            try
            {
                var cc = db.TB_cars.Select(x => x.car_name).AsQueryable().ToList();
                cc.Insert(0, "");
                Combo_car.DataSource = cc;
            }
            catch { }
        }
       
        private void LoadDrivers()
        {
            try
            {
                var ff = db.TB_emplo.Where(x => x.emplo_dis == true).Select(x => x.emplo_name).AsQueryable().ToList();
                ff.Insert(0, "");
                Combo_emplo.DataSource = ff;
            }
            catch { }
        }

     
        private void FRM_Dis_traval_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe from events
            gridView1.RowCellStyle -= OnRowCellStyle;
            gridView1.RowStyle -= OnRowStyle;

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

            // Additional cleanup for other controls or resources
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

        /*  private async void Btn_serch_Click(object sender, EventArgs e)
          {
              try
              {
                  if (!this.IsHandleCreated)
                  {
                      this.CreateHandle();
                  }

                  loading.Visible = true;
                  Cursor.Current = Cursors.WaitCursor; // تعيين مؤشر الماوس إلى دوران انتظار

                  await Task.Run(() =>
                  {
                      this.Invoke((MethodInvoker)delegate
                      {
                          // Extract variables to reduce code duplication
                          var selectedStatus = Combo_stauts.SelectedItem?.ToString();
                          var selectedCity = Combo_city.SelectedItem?.ToString();
                          var selectedCar = Combo_car.SelectedItem?.ToString();
                          var selectedDriver = Combo_emplo.SelectedItem?.ToString();
                          var fromDate = dateTimePicker1.Value.Date;
                          var toDate = dateTimePicker2.Value.Date;

                          // Create the base query
                          var query = db.TB_travel.AsQueryable();

                          // Apply filters dynamically
                          if (!string.IsNullOrEmpty(Txt_Wasel.Text) && decimal.TryParse(Txt_Wasel.Text, out decimal waselValue))
                          {
                              query = query.Where(x => x.tr_id == waselValue);
                          }

                          if (!string.IsNullOrEmpty(Txt_items.Text) && decimal.TryParse(Txt_items.Text, out decimal itemsValue))
                          {
                              query = query.Where(x => x.tr_items == itemsValue);
                          }

                          if (!string.IsNullOrEmpty(Txt_units.Text) && decimal.TryParse(Txt_units.Text, out decimal unitsValue))
                          {
                              query = query.Where(x => x.tr_unit == unitsValue);
                          }

                          if (!string.IsNullOrEmpty(selectedDriver))
                          {
                              query = query.Where(x => x.TB_emplo.emplo_name == selectedDriver);
                          }

                          if (!string.IsNullOrEmpty(selectedCity))
                          {
                              query = query.Where(x => x.TB_city.city_name == selectedCity);
                          }

                          if (!string.IsNullOrEmpty(selectedCar))
                          {
                              query = query.Where(x => x.TB_cars.car_name == selectedCar);
                          }

                          if (!string.IsNullOrEmpty(selectedStatus))
                          {
                              query = query.Where(x => x.tr_st_staus == selectedStatus);
                          }

                          // Filter by date range
                          query = query.Where(x => x.tr_date >= fromDate && x.tr_date <= toDate);

                          // Execute the query and update the data source
                          var data = query.ToList();
                          gridControl1.DataSource = data;
                          lblcount.Text = gridView1.RowCount.ToString();

                          decimal sum1 = 0;
                          decimal sum2 = 0;
                          for (int i = 0; i < gridView1.DataRowCount; i++)
                          {
                              if (gridView1.GetRowCellValue(i, "tr_amount") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "tr_amount").ToString(), out decimal value1))
                              {
                                  sum1 += value1;
                              }

                              if (gridView1.GetRowCellValue(i, "tr_amount_d") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "tr_amount_d").ToString(), out decimal value2))
                              {
                                  sum2 += value2;
                              }
                          }

                          CultureInfo usdCulture = new CultureInfo("en-US");
                          CultureInfo dinarCulture = new CultureInfo("ar-IQ");
                          usdCulture.NumberFormat.CurrencySymbol = "$";
                          dinarCulture.NumberFormat.CurrencySymbol = "د.ع";
                          // Customize the format to place the currency symbol after the number
                          dinarCulture.NumberFormat.CurrencyPositivePattern = 1;
                          lblTotal_usd.Text = sum1.ToString("C2", usdCulture);
                          lblTotal_d.Text = sum2.ToString("C2", dinarCulture);
                      });
                  });
              }
              catch (Exception ex)
              {
                  MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
              }
              finally
              {
                  // Ensure UI updates and resource cleanup
                  Cursor.Current = Cursors.Default; // إعادة مؤشر الماوس إلى المؤشر الافتراضي
                  loading.Visible = false;

                  // Trigger garbage collection
                  GC.Collect();
                  GC.WaitForPendingFinalizers();
              }
          }*/
        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }

                loading.Visible = true;
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        var selectedStatus = Combo_stauts.SelectedItem?.ToString();
                        var selectedCity = Combo_city.SelectedItem?.ToString();
                        var selectedCar = Combo_car.SelectedItem?.ToString();
                        var selectedDriver = Combo_emplo.SelectedItem?.ToString();
                        var fromDate = dateTimePicker1.Value.Date;
                        var toDate = dateTimePicker2.Value.Date;

                        decimal? waselValue = null;
                        decimal? itemsValue = null;
                        decimal? unitsValue = null;

                        if (decimal.TryParse(Txt_Wasel.Text, out decimal wValue))
                        {
                            waselValue = wValue;
                        }

                        if (decimal.TryParse(Txt_items.Text, out decimal iValue))
                        {
                            itemsValue = iValue;
                        }

                        if (decimal.TryParse(Txt_units.Text, out decimal uValue))
                        {
                            unitsValue = uValue;
                        }

                        var data = db.Database.SqlQuery<TravelRecord>(
                                 "EXEC FilteredTravelRecords @WaselValue, @ItemsValue, @UnitsValue, @DriverName, @CityName, @CarName, @Status, @FromDate, @ToDate",
                                 new SqlParameter("@WaselValue", (object)waselValue ?? DBNull.Value),
                                 new SqlParameter("@ItemsValue", (object)itemsValue ?? DBNull.Value),
                                 new SqlParameter("@UnitsValue", (object)unitsValue ?? DBNull.Value),
                                 new SqlParameter("@DriverName", string.IsNullOrEmpty(selectedDriver) ? (object)DBNull.Value : selectedDriver),
                                 new SqlParameter("@CityName", string.IsNullOrEmpty(selectedCity) ? (object)DBNull.Value : selectedCity),
                                 new SqlParameter("@CarName", string.IsNullOrEmpty(selectedCar) ? (object)DBNull.Value : selectedCar),
                                 new SqlParameter("@Status", string.IsNullOrEmpty(selectedStatus) ? (object)DBNull.Value : selectedStatus),
                                 new SqlParameter("@FromDate", fromDate),
                                 new SqlParameter("@ToDate", toDate)
                                ).ToList();



                        // تحديث بيانات الـ DataGridView
                        gridControl1.DataSource = data;
                        lblcount.Text = gridView1.RowCount.ToString();

                        decimal sum1 = 0;
                        decimal sum2 = 0;
                        for (int i = 0; i < gridView1.DataRowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "tr_amount") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "tr_amount").ToString(), out decimal value1))
                            {
                                sum1 += value1;
                            }

                            if (gridView1.GetRowCellValue(i, "tr_amount_d") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "tr_amount_d").ToString(), out decimal value2))
                            {
                                sum2 += value2;
                            }
                        }

                        CultureInfo usdCulture = new CultureInfo("en-US");
                        CultureInfo dinarCulture = new CultureInfo("ar-IQ");
                        usdCulture.NumberFormat.CurrencySymbol = "$";
                        dinarCulture.NumberFormat.CurrencySymbol = "د.ع";
                        dinarCulture.NumberFormat.CurrencyPositivePattern = 1;
                        lblTotal_usd.Text = sum1.ToString("C2", usdCulture);
                        lblTotal_d.Text = sum2.ToString("C2", dinarCulture);
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                loading.Visible = false;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public class TravelRecord
        {
            public DateTime tr_date { get; set; }
            public string tr_st_staus { get; set; }
            public string tr_nots { get; set; }
            public decimal? tr_items { get; set; }
            public decimal? tr_unit { get; set; }
          
            public int? action_id { get; set; }
            public decimal? tr_reitems { get; set; }
            public decimal? tr_reunit { get; set; }
            public int? tr_id { get; set; }
            public decimal? tr_amount { get; set; }
            public decimal? tr_amount_d { get; set; }
            public decimal? tr_cash { get; set; }
            public decimal? tr_cash_d { get; set; }
            public decimal? tr_cridet { get; set; }
            public decimal? tr_cridet_d { get; set; }
            public decimal? tr_Scash { get; set; }
            public decimal? tr_dcash { get; set; }
            public decimal? tr_recridetu { get; set; }
            public decimal? tr_recridetu_d { get; set; }
            public decimal? tr_recrideth { get; set; }
            public decimal? tr_recrideth_d { get; set; }
            public decimal? tr_p_it { get; set; }
            public decimal? tr_p_un { get; set; }
            public string tr_luck { get; set; }
            public decimal? tr_dcashh { get; set; }
            public decimal? tr_scashh { get; set; }
            public decimal? tr_sfinal { get; set; }
            public decimal? tr_dfinal { get; set; }
            public int?  tr_lists { get; set; }
            public string user_FullName1 { get; set; }
            public string user_FullName2 { get; set; }
            public string emplo_name { get; set; }    // اسم الموظف
            public string city_name { get; set; }     // اسم المدينة
            public string car_name { get; set; }      // اسم السيارة
        }



        private void Combo_stauts_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (Combo_stauts.Text == "")
            {
                dateTimePicker1.Value = DateTime.Today;
            }
            else
            {
                DateTime dt = new DateTime(2011, 1, 1);
                dateTimePicker1.Value = dt;
            }*/

        }
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void Showtotal_wasel(int id, string name)
        {
            FRM_total_wasel page = new FRM_total_wasel
            {
                ID_Wasel = id,
                Name_wasel = name
            };
            page.ShowDialog();
        }
        private void Btn_wasel_Click(object sender, EventArgs e)
        {
            if (AddPage.Users.userRole=="امين مخزن")
            {
                return;
            }
      /*      else if (GetFocusedRowCellValue("tr_st_staus") == "قيد التوزيع")
            {
                ShowErrorMessage("السفرة قيد التوزيع يجب تثبيت راجع", "خطأ ");

            }*/
            else
            {
                try
                {
                    string cellValue = GetFocusedRowCellValue("tr_id");
                    string cellValue2 = GetFocusedRowCellValue("emplo_name");
                    if (int.TryParse(cellValue, out int wasell) && wasell != 0)
                    {
                        Showtotal_wasel(wasell, cellValue2);
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

        }


        private void ShowErrorMessage(string message, string caption, Exception ex = null)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (ex != null)
            {
                // Log the exception or perform additional error handling
            }
        }
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
                using (var db = new AlibaRamyEntities())
                    {
                        var data = db.TB_details
                              .Where(x => x.order_id == id && x.action_id == 3).AsNoTracking()
                        .Select(x => new DataSellTravel
                        {

                            Name = x.TB_items.items_name,
                            Price = x.TB_items.Usd_upper,
                            Recived = x.details_num,
                            Return = x.details_renum,
                            Sold = x.sell_num,

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
                string Tr = GetFocusedRowCellValue("tr_id");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("tr_date")).Date;
                string City = GetFocusedRowCellValue("city_name");
                string Emplo = GetFocusedRowCellValue("emplo_name");
                string Status = GetFocusedRowCellValue("tr_st_staus");
                string Car = GetFocusedRowCellValue("car_name");
                string Items = GetFocusedRowCellValue("tr_items");
                string Units = GetFocusedRowCellValue("tr_unit");


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
                       // MessageBox.Show("تم التصدير الى الطابعه", "طباعة");

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

      
        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void ShowDetailsForm(int id, string driver)
        {
            FRM_wasel_travel page = new FRM_wasel_travel
            {
                ID_traval = id,
                ID_driver = driver
            };

            page.ShowDialog();

          
        }
        private void Btn_detials_Click(object sender, EventArgs e)
        {
           /* if (AddPage.Users.userRole == "امين مخزن")
            {
                return;
            }*/
           /* else if(GetFocusedRowCellValue("tr_st_staus") == "قيد التوزيع")
            {
                ShowErrorMessage("السفرة قيد التوزيع", "خطأ ");
            }
            else
            {*/
                try
                {
                    string cellValue = GetFocusedRowCellValue("tr_id");
                    string driver = GetFocusedRowCellValue("TB_emplo.emplo_name");

                    if (int.TryParse(cellValue, out int wasell) && wasell != 0)
                    {
                        ShowDetailsForm(wasell, driver);
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

      

        private void FRM_Dis_traval_Load(object sender, EventArgs e)
        {
            LoadCity();
            LoadCars();
            LoadDrivers();
        }
    }
}