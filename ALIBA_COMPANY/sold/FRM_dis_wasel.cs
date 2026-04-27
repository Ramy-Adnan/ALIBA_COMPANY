using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_dis_wasel : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        public class ListResultModel
        {
            public int? list_id { get; set; }
            public int? list_code { get; set; }
            public DateTime? list_date { get; set; }
            public string list_name { get; set; }
            public decimal? list_amountUsd { get; set; }
            public decimal? list_amountIQ { get; set; }
            public decimal? list_cridetUsd { get; set; }
            public decimal? list_cridetIQ { get; set; }
            public decimal? list_scashUsd { get; set; }
            public decimal? list_dcash { get; set; }
            public decimal? list_items { get; set; }
            public decimal? list_unit { get; set; }
            public string list_nots { get; set; }
            public string action_name { get; set; }
            public int tr_id { get; set; }
            public string emplo_name { get; set; }
            public string car_name { get; set; }
            public string city_name { get; set; }
            public string user_name { get; set; }
            public string type_name { get; set; }
        }

        public FRM_dis_wasel()
        {
            InitializeComponent();
            Txt_Num.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_Wasel.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_travel.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_NumItem.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_NumPacies.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            // قد تحتاج إلى إضافة المزيد من الـ TextBox حسب الحاجة والقيمة القصوى للطول

        }

      
        private List<ListResultModel> results = new List<ListResultModel>(); // قائمة لتخزين النتائج
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Refresh();
                // إلغاء العملية السابقة إذا كانت جارية
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                var token = _cancellationTokenSource.Token; 

               loading.Visible = true;

                string selectedItemsName = null;
               
                string selectedType = null;
                string selectedCity = null;
                string selectedMotion = null;
                string selectedDriver = null;
                string selectedCar = null;
                decimal quantity = 0;
                string selectedcompare = null;
                DateTime FromDate = DateTime.Today;
                DateTime ToDate = DateTime.Today;

                decimal wasel = 0;
                decimal travel = 0;
                decimal NumItem = 0;
                decimal NumPacies = 0;

                if (Txt_Wasel.Text == "")
                {
                    Txt_Wasel.Text = "0";
                }
                if (Txt_travel.Text == "")
                {
                    Txt_travel.Text = "0";
                }
                if (Txt_NumItem.Text == "")
                {
                    Txt_NumItem.Text = "0";
                }
                if (Txt_NumPacies.Text == "")
                {
                    Txt_NumPacies.Text = "0";
                }
                if (Txt_Num.Text == "")
                {
                    Txt_Num.Text = "0";
                }
                List<string> selectedListNames = clbListNames1.CheckedItems.Cast<string>().ToList(); // الحصول على القوائم المختارة
                this.Invoke((MethodInvoker)delegate
                {
                    selectedItemsName = Txt_items_name.Text.Trim();
                  //  selectedCust = Txt_cust.Text.Trim();
                    selectedType = Combo_type_sell.SelectedItem?.ToString();
                    selectedCity = Combo_city.SelectedItem?.ToString();
                    selectedMotion = Combo_motion.SelectedItem?.ToString();
                    selectedDriver = Combo_emplo.SelectedItem?.ToString();
                    selectedCar = Combo_car.SelectedItem?.ToString();
                    quantity = decimal.Parse(Txt_Num.Text);
                    selectedcompare = Combo_compare.SelectedItem?.ToString();
                    FromDate = dateTimePicker1.Value.Date;
                    ToDate = dateTimePicker2.Value.Date.AddDays(1);
                    results.Clear();
                    wasel = decimal.Parse(Txt_Wasel.Text);
                    travel = decimal.Parse(Txt_travel.Text);
                    NumItem = decimal.Parse(Txt_NumItem.Text);
                    NumPacies = decimal.Parse(Txt_NumPacies.Text);
                });

                //    List<dynamic> results = new List<dynamic>(); // قائمة لتخزين النتائج
               
                int pageSize = 9000000; // حجم كل دفعة من البيانات
                int pageNumber = 0; // رقم الصفحة الحالية للنتائج

                var pageOfResults = await Task.Run(() =>
                {
                    using (var dbContext = new AlibaRamyEntities())
                    {
                        var query = (from inventory in dbContext.TB_list
                                     join Travel in dbContext.TB_travel.AsNoTracking() on inventory.tr_id equals Travel.tr_id
                                     join action in dbContext.TB_action.AsNoTracking() on inventory.action_id equals action.action_id
                                     join user in dbContext.TB_users.AsNoTracking() on inventory.user_id equals user.user_id
                                     join type in dbContext.TB_type.AsNoTracking() on inventory.type_id equals type.type_id
                                     join car in dbContext.TB_cars.AsNoTracking() on Travel.car_id equals car.car_id
                                     join emplo in dbContext.TB_emplo.AsNoTracking() on Travel.emplo_id equals emplo.emplo_id
                                     join city in dbContext.TB_city.AsNoTracking() on Travel.city_id equals city.city_id
                                     where inventory.list_date >= FromDate && inventory.list_date <= ToDate
                                     select new ListResultModel
                                     {
                                         list_id = inventory.list_id,
                                         list_code = inventory.list_code,
                                         list_date = inventory.list_date,
                                         list_name = inventory.list_name,
                                         list_amountUsd = inventory.list_amountUsd,
                                         list_amountIQ = inventory.list_amountIQ,
                                         list_cridetUsd = inventory.list_cridetUsd,
                                         list_cridetIQ = inventory.list_cridetIQ,
                                         list_scashUsd = inventory.list_scashUsd,
                                         list_dcash = inventory.list_dcash,
                                         list_items = inventory.list_items,
                                         list_unit = inventory.list_unit,
                                         list_nots = inventory.list_nots,
                                         action_name = action.action_name,
                                         tr_id = Travel.tr_id,
                                         emplo_name = emplo.emplo_name,
                                         car_name = car.car_name,
                                         city_name = city.city_name,
                                         user_name = user.user_FullName,
                                         type_name = type.type_name
                                     });


                        // Apply dynamic filters
                        if (selectedcompare == "اكبر من")
                        {
                            query = query.Where(x => x.list_amountUsd > quantity);
                        }
                        else if (selectedcompare == "اصغر من")
                        {
                            query = query.Where(x => x.list_amountUsd < quantity);
                        }
                        else if (selectedcompare == "يساوي")
                        {
                            query = query.Where(x => x.list_amountUsd == quantity);
                        }
                        if (NumItem != 0)
                        {
                            query = query.Where(x => x.list_items == NumItem);
                        }
                        if (NumPacies != 0)
                        {
                            query = query.Where(x => x.list_unit == NumPacies);
                        }
                        if (wasel != 0)
                        {
                            query = query.Where(x => x.list_code == wasel);
                        }
                        if (travel != 0)
                        {
                            query = query.Where(x => x.tr_id == travel);
                        }
                        if (selectedCar != null && selectedCar != "كل السيارات")
                        {
                            query = query.Where(x => x.car_name == selectedCar);
                        }
                        if (selectedDriver != null && selectedDriver != "كل الموزعيين")
                        {
                            query = query.Where(x => x.emplo_name == selectedDriver);
                        }
                        if (selectedType != null && selectedType != "")
                        {
                            query = query.Where(x => x.type_name == selectedType);
                        }
                        if (selectedCity != null && selectedCity != "كل المحافظات")
                        {
                            query = query.Where(x => x.city_name == selectedCity);
                        }
                        if (selectedMotion != null && selectedMotion != "")
                        {
                            query = query.Where(x => x.action_name == selectedMotion);
                        }
                        
                        // Filter by item name if specified
                        if (!string.IsNullOrEmpty(selectedItemsName))
                        {
                            query = query.Where(x => dbContext.TB_det.Any(d => d.list_id == x.list_id && d.TB_items.items_name == selectedItemsName));
                        }
                      /*  if (!string.IsNullOrEmpty(selectedCust))
                        {
                            query = query.Where(x => x.list_name == selectedCust);
                        }*/
                        if (selectedListNames.Any())
                        {
                            query = query.Where(x => selectedListNames.Contains(x.list_name));
                        }
                        return query.OrderBy(x => x.list_date)
                                        .Skip(pageNumber * pageSize)
                                        .Take(pageSize)
                                        .ToList();
                    }
                });

                results.AddRange(pageOfResults);
                this.Invoke((MethodInvoker)delegate
                {
                    if (results.Count == 0)
                    {
                        gridControl1.DataSource = null;
                        MessageBox.Show(" لا توجد نتائج للمعلومات المختاره");
                    }
                    else
                    {

                        gridControl1.BeginUpdate(); // تعطيل التحديثات البصرية
                        gridControl1.DataSource = results;
                        gridControl1.EndUpdate(); // إعادة تفعيل التحديثات البصرية

                        gridControl1.Refresh(); // استدعاء Refresh لإعادة رسم الواجهة
                        lblcount.Text = gridView1.RowCount.ToString();

                        decimal sum1 = 0;
                        decimal sum2 = 0;
                        decimal total1 = 0;
                        decimal total2 = 0;
                        for (int i = 0; i < gridView1.DataRowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "list_items") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_items").ToString(), out decimal value1))
                            {
                                sum1 += value1;
                            }

                            if (gridView1.GetRowCellValue(i, "list_unit") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_unit").ToString(), out decimal value2))
                            {
                                sum2 += value2;
                            }
                            if (gridView1.GetRowCellValue(i, "list_amountUsd") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_amountUsd").ToString(), out decimal usd))
                            {
                                total1 += usd;
                            }

                            if (gridView1.GetRowCellValue(i, "list_amountIQ") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "list_amountIQ").ToString(), out decimal iq))
                            {
                                total2 += iq;
                            }
                        }

                        CultureInfo usdCulture1 = new CultureInfo("en-US");
                        CultureInfo dinarCulture1 = new CultureInfo("en-US");
                        CultureInfo usdCulture2 = new CultureInfo("en-US");
                        CultureInfo dinarCulture2 = new CultureInfo("ar-IQ");
                        usdCulture1.NumberFormat.CurrencySymbol = "📦";
                        dinarCulture1.NumberFormat.CurrencySymbol = "🍕";
                        usdCulture2.NumberFormat.CurrencySymbol = " $";
                        dinarCulture2.NumberFormat.CurrencySymbol = " د.ع";
                        // Customize the format to place the currency symbol after the number
                        usdCulture2.NumberFormat.CurrencyPositivePattern = 1;
                        lbl_items.Text = sum1.ToString("C1", usdCulture1);
                        lbl_units.Text = sum2.ToString("C1", dinarCulture1);
                        lbl_usd.Text = total1.ToString("C1", usdCulture2);
                        lbl_iq.Text = total2.ToString("C1", dinarCulture2);
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("حدث خطا بالاتصال او تجاوز المهله الزمنية: " + ex.Message);
                });
            }
            finally
            {
                 loading.Visible = false;

              /*  // Trigger garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();*/
            }
        }


        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 


      /*  private async void Btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                loading.Visible = true;

                string selectedItemsName = null;
                string selectedType = null;
                string selectedCity = null;
                string selectedMotion = null;
                string selectedDriver = null;
                string selectedCar = null;
                decimal quantity = 0;
                string selectedcompare = null;
                DateTime FromDate = DateTime.Today;
                DateTime ToDate = DateTime.Today;

                decimal wasel = 0;
                decimal travel = 0;
                decimal NumItem = 0;
                decimal NumPacies = 0;
                if (Txt_Wasel.Text == "")
                {
                    Txt_Wasel.Text = "0";
                }
                if (Txt_travel.Text == "")
                {
                    Txt_travel.Text = "0";
                }
                if (Txt_NumItem.Text == "")
                {
                    Txt_NumItem.Text = "0";
                }
                if (Txt_NumPacies.Text == "")
                {
                    Txt_NumPacies.Text = "0";
                }
                if (Txt_Num.Text == "")
                {
                    Txt_Num.Text = "0";
                }
                this.Invoke((MethodInvoker)delegate
                {
                    selectedItemsName = Txt_items_name.Text.ToString();
                    selectedType = Combo_type_sell.SelectedItem?.ToString();
                    selectedCity = Combo_city.SelectedItem?.ToString();
                    selectedMotion = Combo_motion.SelectedItem?.ToString();
                    selectedDriver = Combo_emplo.SelectedItem?.ToString();
                    selectedCar = Combo_car.SelectedItem?.ToString();
                    quantity = decimal.Parse(Txt_Num.Text);
                    selectedcompare = Combo_compare.SelectedItem?.ToString();
                    FromDate = dateTimePicker1.Value.Date;
                    ToDate = dateTimePicker2.Value.Date;

                    wasel = decimal.Parse(Txt_Wasel.Text);
                    travel = decimal.Parse(Txt_travel.Text);
                    NumItem = decimal.Parse(Txt_NumItem.Text);
                    NumPacies = decimal.Parse(Txt_NumPacies.Text);
                });

                int pageNumber = 0; // الصفحة الأولى
                int pageSize = 100; // حجم الصفحة: عدد النتائج التي تريد تحميلها في كل صفحة

                var results = await Task.Run(() =>
                {
                    using (var dbContext = new AlibaRamyEntities())
                    {
                        var mainQuery = (from inventory in dbContext.TB_list
                                         join Travel in dbContext.TB_travel.AsNoTracking() on inventory.tr_id equals Travel.tr_id
                                         join action in dbContext.TB_action.AsNoTracking() on inventory.action_id equals action.action_id
                                         join user in dbContext.TB_users.AsNoTracking() on inventory.user_id equals user.user_id
                                         join type in dbContext.TB_type.AsNoTracking() on inventory.type_id equals type.type_id
                                         join car in dbContext.TB_cars.AsNoTracking() on Travel.car_id equals car.car_id
                                         join emplo in dbContext.TB_emplo.AsNoTracking() on Travel.emplo_id equals emplo.emplo_id
                                         join city in dbContext.TB_city.AsNoTracking() on Travel.city_id equals city.city_id
                                         where inventory.list_date >= FromDate && inventory.list_date <= ToDate
                                         select new
                                         {
                                             inventory.list_id,
                                             inventory.list_date,
                                             inventory.list_name,
                                             inventory.list_amountUsd,
                                             inventory.list_amountIQ,
                                             inventory.list_cridetUsd,
                                             inventory.list_cridetIQ,
                                             inventory.list_scashUsd,
                                             inventory.list_dcash,
                                             inventory.list_items,
                                             inventory.list_unit,
                                             inventory.list_nots,
                                             action.action_name,
                                             Travel.tr_id,
                                             emplo.emplo_name,
                                             car.car_name,
                                             city.city_name,
                                             user.user_name,
                                             type.type_name
                                         }).Distinct();

                        // Apply dynamic filters
                        if (selectedcompare == "اكبر من")
                        {
                            mainQuery = mainQuery.Where(x => x.list_amountUsd > quantity);
                        }
                        else if (selectedcompare == "اصغر من")
                        {
                            mainQuery = mainQuery.Where(x => x.list_amountUsd < quantity);
                        }
                        else if (selectedcompare == "يساوي")
                        {
                            mainQuery = mainQuery.Where(x => x.list_amountUsd == quantity);
                        }
                        if (NumItem != 0)
                        {
                            mainQuery = mainQuery.Where(x => x.list_items == NumItem);
                        }
                        if (NumPacies != 0)
                        {
                            mainQuery = mainQuery.Where(x => x.list_unit == NumPacies);
                        }
                        if (wasel != 0)
                        {
                            mainQuery = mainQuery.Where(x => x.list_id == wasel);
                        }
                        if (travel != 0)
                        {
                            mainQuery = mainQuery.Where(x => x.tr_id == travel);
                        }
                        if (selectedCar != null && selectedCar != "كل السيارات")
                        {
                            mainQuery = mainQuery.Where(x => x.car_name == selectedCar);
                        }
                        if (selectedDriver != null && selectedDriver != "كل الموزعيين")
                        {
                            mainQuery = mainQuery.Where(x => x.emplo_name == selectedDriver);
                        }
                        if (selectedType != null && selectedType != "")
                        {
                            mainQuery = mainQuery.Where(x => x.type_name == selectedType);
                        }
                        if (selectedCity != null && selectedCity != "كل المحافظات")
                        {
                            mainQuery = mainQuery.Where(x => x.city_name == selectedCity);
                        }
                        if (selectedMotion != null && selectedMotion != "")
                        {
                            mainQuery = mainQuery.Where(x => x.action_name == selectedMotion);
                        }

                        // Pagination: Skip and Take
                        var mainResults = mainQuery.OrderBy(x => x.list_id)  // ترتيب بناءً على list_id كمثال
                             .Skip(pageNumber * pageSize)
                             .Take(pageSize)
                             .ToList();

                        // Fetch item details for each list_id
                        var listIds = mainResults.Select(r => r.list_id).ToList();
                        var itemDetails = (from det in dbContext.TB_det.AsNoTracking()
                                           join item in dbContext.TB_items.AsNoTracking() on det.items_id equals item.items_id
                                           where listIds.Contains(det.list_id ?? 0)
                                           select new
                                           {
                                               det.list_id,
                                               item.items_name
                                           }).ToList();

                        // Combine main results with item details
                        var combinedResults = mainResults.GroupJoin(itemDetails,
                            m => m.list_id,
                            i => i.list_id,
                            (m, i) => new
                            {
                                m.list_id,
                                m.list_date,
                                m.list_name,
                                m.list_amountUsd,
                                m.list_amountIQ,
                                m.list_cridetUsd,
                                m.list_cridetIQ,
                                m.list_scashUsd,
                                m.list_dcash,
                                m.list_items,
                                m.list_unit,
                                m.list_nots,
                                m.action_name,
                                m.tr_id,
                                m.emplo_name,
                                m.car_name,
                                m.city_name,
                                m.user_name,
                                m.type_name,
                                Items = i.Select(x => x.items_name).ToList()
                            }).ToList();

                        // Filter by item name if specified
                        if (!string.IsNullOrEmpty(selectedItemsName))
                        {
                            combinedResults = combinedResults.Where(cr => cr.Items.Contains(selectedItemsName)).ToList();
                        }

                        return combinedResults;
                    }
                });

                pageNumber++;
                this.Invoke((MethodInvoker)delegate
                {
                    if (results.Count == 0)
                    {
                        gridControl1.DataSource = null;
                        MessageBox.Show(" لا توجد نتائج للمعلومات المختاره");
                    }
                    else
                    {
                        gridControl1.DataSource = results;
                        lblcount.Text = gridView1.RowCount.ToString();
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("حدث خطا بالاتصال او تجاوز المهله الزمنية: " + ex.Message);
                });
            }
            finally
            {
                loading.Visible = false;

                // Trigger garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }*/


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoadCity()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                    var city = dbbb.TB_city.Select(x => x.city_name).AsQueryable().ToList();
                    city.Insert(0, "كل المحافظات");
                    Combo_city.DataSource = city;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء تحميل المحافظات no connection: " + ex.Message);
            }
        }
        private void LoadDriver()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                    var driver = dbbb.TB_emplo.Where(x => x.emplo_activity==true&&x.emplo_dis==true).Select(x => x.emplo_name).AsQueryable().ToList();
                    driver.Insert(0, "كل الموزعيين");
                    Combo_emplo.DataSource = driver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء تحميل الموزعيين no connection: " + ex.Message);
            }
        }
        private void LoadCar()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var car = dbbb.TB_cars.Select(x => x.car_name).AsQueryable().ToList();
                    car.Insert(0, "كل السيارات");
                    Combo_car.DataSource = car;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء تحميل السيارات no connection: " + ex.Message);
            }
        }
        private void GetItemsName()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var listData = dbbb.TB_items.Select(X => X.items_name).AsQueryable().ToList();
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(listData.ToArray());
                    Txt_items_name.AutoCompleteCustomSource = collection;
                }
            }
            catch { }
        }
        private void Txt_items_name_TextChanged(object sender, EventArgs e)
        {
            
            // التحقق إذا كان النص فارغاً
            if (string.IsNullOrWhiteSpace(Txt_items_name.Text))
            {
                // إذا كان النص فارغًا، لا تقم بتحديث AutoCompleteCustomSource
                Txt_items_name.AutoCompleteCustomSource = new AutoCompleteStringCollection(); // قائمة فارغة
            }
            else
            {
              
                GetItemsName();
            }
        }
       /* private void GetCustName()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var inputText = Txt_cust.Text.ToLower();
                    var listData = db.TB_cust
                      .Where(x => x.cust_name.ToLower().Contains(inputText))
                      .Select(x => x.cust_name).AsQueryable()
                      .ToList();

                  
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(listData.ToArray());
                    Txt_cust.AutoCompleteCustomSource = collection;

                  
                }
            }
            catch { }
        }*/
        private void FRM_dis_wasel_Load(object sender, EventArgs e)
        {
            SystemUtilities.SetProcessPriority();
            SystemUtilities.AllocateMoreMemory();
            LoadCar();
            LoadDriver();
            LoadCity();

        }

      /*  private void Txt_cust_TextChanged(object sender, EventArgs e)
        {
            // التحقق إذا كان النص فارغاً
            if (string.IsNullOrWhiteSpace(Txt_cust.Text))
            {
                // إذا كان النص فارغًا، لا تقم بتحديث AutoCompleteCustomSource
                Txt_cust.AutoCompleteCustomSource = new AutoCompleteStringCollection(); // قائمة فارغة
            }
            else
            {
                GetCustName();
            }
        }*/
      
        private void FRM_dis_wasel_FormClosing(object sender, FormClosingEventArgs e)
        {
     
            // Clear data source
            gridControl1.DataSource = null;

           /* // Dispose of disposable objects
            if (db != null)
            {
                db.Dispose();
                db = null;
            }*/

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
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void ShowDetailsForm(int id)
        {
            FRM_details page = new FRM_details
            {
                ID_Wasel = id
            };
            page.ShowDialog();
        }
        private void Btn_details_Click(object sender, EventArgs e)
        {
            try
            {
                string cellValue = GetFocusedRowCellValue("list_id");
                if (int.TryParse(cellValue, out int wasell) && wasell != 0)
                {
                    ShowDetailsForm(wasell);
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات, اختر صفًا لعرضه", "لا يمكن اجراء العملية");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الاتصال بقاعدة البيانات Btn_datials", "خطأ في الاتصال" + ex.Message);
            }
           
        }
        private List<DataRecord> dataList;

        private async Task LoadDataInBackground(int id)
        {
            try
            {
                
                dataList = await Task.Run(() =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var data = db.TB_det
                           .Where(x => x.list_id == id).AsNoTracking()
                           .Select(x => new DataRecord
                           {
                               Code = x.TB_list.list_code,
                               Name = x.TB_items.items_name,
                               Num = x.de_num,
                               CostUsd = x.de_costUsd,
                               TcostUsd = x.de_totalUsd,
                               Costiq = x.de_costIQ,
                               Tcostiq = x.de_totalIQ,
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
            Cursor.Current = Cursors.WaitCursor;
            string id = GetFocusedRowCellValue("list_id");
            if (int.TryParse(id, out int wasell) && wasell != 0)
            {
                string cust = GetFocusedRowCellValue("list_name");
                DateTime date = Convert.ToDateTime(GetFocusedRowCellValue("list_date")).Date;
                string code = GetFocusedRowCellValue("list_code");
                string items = GetFocusedRowCellValue("list_items");
                string units = GetFocusedRowCellValue("list_units");
                string driver = GetFocusedRowCellValue("emplo_name");
                string Wus = GetFocusedRowCellValue("list_scashUsd");
                string Total = GetFocusedRowCellValue("list_amountUsd");
                string Crus = GetFocusedRowCellValue("list_cridetUsd");

                var Result = MessageBox.Show("هل تريد طباعة وصل ", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {

                    try
                    {
                        await LoadDataInBackground(wasell);
                        // إعداد التقرير
                        XtraReport_sell report = new XtraReport_sell
                        {

                            // تعيين dataList كمصدر بيانات للتقرير
                            DataSource = dataList
                        };

                        // إنشاء قاموس يحتوي على المعلمات وقيمها
                        var parameters = new Dictionary<string, object>
                    {
                        { "cust", cust },
                        { "date", date },
                        { "code", code },
                        { "items", items },
                        { "units", units },
                        { "emplo", driver },
                        { "Wus", Wus },
                        { "Total", Total },
                        { "Crus", Crus }
                    };

                       
                        SetReportParameters(report, parameters);
                       
                        report.ShowPreview();


                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " طباعة وصل بيع " + Wus;
                        note.AddNote(Note, notifications, "طباعة", 6);
                        //  DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("cridet_date")).Date;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"خطأ في الاتصال - Btn_print_Click: {ex.Message}");
                    }
                }

            }
            else
            {
                MessageBox.Show("لا توجد بيانات");
            }
        }
        private void SetReportParameters(XtraReport_sell report, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {

                if (report.Parameters[param.Key] != null)
                {
                    report.Parameters[param.Key].Value = param.Value;
                }
            }
        }

        /* private async void Btn_Exel_Click(object sender, EventArgs e)
         {
             try
             {
                 // Create and configure SaveFileDialog
                 SaveFileDialog saveDialog = new SaveFileDialog();
                 string fileName = $"list.xlsx"; // Generate the filename
                 saveDialog.FileName = fileName;
                 saveDialog.Filter = "Excel Files|*.xlsx";
                 saveDialog.Title = "حفظ التقرير كملف Excel";

                 if (saveDialog.ShowDialog() == DialogResult.OK)
                 {
                     Cursor.Current = Cursors.WaitCursor; // تعيين مؤشر الماوس إلى دوران انتظار

                             var queryResults = results.OrderBy(x => x.list_date)

                                           .ToList();
                             // Create a new Excel workbook
                             using (var workbook = new XLWorkbook())
                             {
                                 var worksheet = workbook.Worksheets.Add();

                                 // Add column headers
                                 // Add column headers
                                 worksheet.Cell(1, 1).Value = "رقم الوصل"; // Replace with actual column names
                                 worksheet.Cell(1, 2).Value = "التاريخ";
                                 worksheet.Cell(1, 3).Value = "الحركه";
                                 worksheet.Cell(1, 4).Value = "اسم العميل";
                                 worksheet.Cell(1, 5).Value = "مبلغ القائمة";
                                 worksheet.Cell(1, 6).Value = "الدين بالدولار";
                                 worksheet.Cell(1, 7).Value = "الدين بالدينار";
                                 worksheet.Cell(1, 8).Value = "الدولار المدفوع";
                                 worksheet.Cell(1, 9).Value = "الدينار المدفوع";
                                 worksheet.Cell(1, 10).Value = "التكسير";
                                 worksheet.Cell(1, 11).Value = "عدد المواد";
                                 worksheet.Cell(1, 12).Value = "عدد القطع";
                                 worksheet.Cell(1, 13).Value = "اسم الموزع";
                                 worksheet.Cell(1, 14).Value = "اسم السيارة";
                                 worksheet.Cell(1, 15).Value = "رقم السفره";
                                 worksheet.Cell(1, 16).Value = "اسم المدينة";
                                 worksheet.Cell(1, 17).Value = "نوع الدفع";
                                 worksheet.Cell(1, 18).Value = "اسم المستخدم";
                                 // تعيين الخلفية للورقة
                                 worksheet.TabColor = XLColor.White;
                                 worksheet.ShowGridLines = false;
                                 worksheet.Range(1, 1, 1, 18).Style.Border.OutsideBorder = XLBorderStyleValues.Thin; // حدود خارجية
                                 worksheet.Range(1, 1, 1, 18).Style.Border.InsideBorder = XLBorderStyleValues.Thin; // حدود داخلية
                                 worksheet.Range(1, 1, 1, 18).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                 worksheet.Range(1, 1, 1, 18).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                 worksheet.Range(1, 1, 1, 18).Style.Font.FontSize = 12; // حجم الخط بالنقاط
                                 worksheet.Range(1, 1, 1, 18).Style.Font.FontName = "Arial"; // اسم الخط
                                 worksheet.Range(1, 1, 1, 18).Style.Font.Bold = true;
                                 worksheet.Range(1, 1, 1, 18).Style.Fill.BackgroundColor = XLColor.Yellow;

                                 for (int i = 0; i < queryResults.Count; i++)
                                 {
                                     worksheet.Cell(i + 2, 1).Value = queryResults[i].list_code; // Replace with actual properties
                                     worksheet.Cell(i + 2, 2).Value = queryResults[i].list_date;
                                     worksheet.Cell(i + 2, 3).Value = queryResults[i].action_name;
                                     worksheet.Cell(i + 2, 4).Value = queryResults[i].action_name;
                                     worksheet.Cell(i + 2, 5).Value = queryResults[i].list_name;
                                     worksheet.Cell(i + 2, 6).Value = queryResults[i].list_amountUsd;
                                     worksheet.Cell(i + 2, 7).Value = queryResults[i].list_cridetUsd;
                                     worksheet.Cell(i + 2, 8).Value = queryResults[i].list_scashUsd;
                                     worksheet.Cell(i + 2, 9).Value = queryResults[i].list_dcash;
                                     worksheet.Cell(i + 2, 10).Value = "0";
                                     worksheet.Cell(i + 2, 11).Value = queryResults[i].list_items;
                                     worksheet.Cell(i + 2, 12).Value = queryResults[i].list_unit;
                                     worksheet.Cell(i + 2, 13).Value = queryResults[i].emplo_name;
                                     worksheet.Cell(i + 2, 14).Value = queryResults[i].car_name;
                                     worksheet.Cell(i + 2, 15).Value = queryResults[i].tr_id;
                                     worksheet.Cell(i + 2, 16).Value = queryResults[i].city_name;
                                     worksheet.Cell(i + 2, 17).Value = queryResults[i].type_name;
                                     worksheet.Cell(i + 2, 18).Value = queryResults[i].user_name;

                                     worksheet.Range(i + 2, 1, i + 2, 18).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                     worksheet.Range(i + 2, 1, i + 2, 18).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                                     worksheet.Range(i + 2, 1, i + 2, 18).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                     worksheet.Range(i + 2, 1, i + 2, 18).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                     worksheet.Range(i + 2, 1, i + 2, 18).Style.Font.FontSize = 12;
                                     worksheet.Range(i + 2, 1, i + 2, 18).Style.Font.FontName = "Arial";
                                 }
                                 worksheet.Columns().AdjustToContents();
                                 // Save the workbook to the specified file
                                 workbook.SaveAs(saveDialog.FileName);
                             }
                     // Add new notification
                     note = new Note();
                     pages.Notifications notifications = new pages.Notifications();
                     var Note = " تصدير كشف البيع للعملاء ";
                     note.AddNote(Note, notifications, "تصدير", 7);

                     MessageBox.Show("تم تصدير و حفظ الملف سنقوم الان بفتحه لك", "نجاح عملية");
                     Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("حدث خطأ أثناء تصدير البيانات إلى Excel: " + ex.Message);
             }
             finally
             {
                 Cursor.Current = Cursors.Default; // إعادة مؤشر الماوس إلى المؤشر الافتراضي
                 GC.Collect();
                 GC.WaitForPendingFinalizers();
             }
         }*/

        private void Btn_Exel_Click(object sender, EventArgs e)
        {
            try
            {
                // تحديد سياق الترخيص لمكتبة EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // استخدم LicenseContext.Commercial إذا كنت تستخدمه تجاريًا
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    string fileName = "list.xlsx"; // Generate the filename
                    saveDialog.FileName = fileName;
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    saveDialog.Title = "حفظ التقرير كملف Excel";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor; // Set cursor to waiting

                        var queryResults = results.OrderBy(x => x.list_date).ToList();

                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Data");

                            // Add column headers
                            string[] headers = new[]
                            {
                        "رقم الوصل", "التاريخ", "الحركه", "اسم العميل", "مبلغ القائمة(usd)","مبلغ القائمة(irq)",
                        "الدين بالدولار", "الدين بالدينار", "الدولار المدفوع", "الدينار المدفوع",
                        "عدد المواد", "عدد القطع", "اسم الموزع", "اسم السيارة",
                        "رقم السفره", "اسم المدينة", "نوع الدفع", "اسم المستخدم"
                    };

                            for (int col = 0; col < headers.Length; col++)
                            {
                                var cell = worksheet.Cells[1, col + 1];
                                cell.Value = headers[col];
                                cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                cell.Style.Font.Size = 12;
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            }

                            // Add data rows
                            for (int i = 0; i < queryResults.Count; i++)
                            {
                                var result = queryResults[i];
                                worksheet.Cells[i + 2, 1].Value = result.list_code;

                                // Format the date cell with time
                                var dateCell = worksheet.Cells[i + 2, 2];
                                dateCell.Value = result.list_date;
                                dateCell.Style.Numberformat.Format = "yyyy-mm-dd HH:mm:ss"; // Set the date and time format

                                worksheet.Cells[i + 2, 3].Value = result.action_name;
                                worksheet.Cells[i + 2, 4].Value = result.list_name;
                                worksheet.Cells[i + 2, 5].Value = result.list_amountUsd;
                                worksheet.Cells[i + 2, 6].Value = result.list_amountIQ;
                                worksheet.Cells[i + 2, 7].Value = result.list_cridetUsd;
                                worksheet.Cells[i + 2, 8].Value = result.list_cridetIQ;
                                worksheet.Cells[i + 2, 9].Value = result.list_scashUsd;
                                worksheet.Cells[i + 2, 10].Value = result.list_dcash;
                                worksheet.Cells[i + 2, 11].Value = result.list_items;
                                worksheet.Cells[i + 2, 12].Value = result.list_unit;
                                worksheet.Cells[i + 2, 13].Value = result.emplo_name;
                                worksheet.Cells[i + 2, 14].Value = result.car_name;
                                worksheet.Cells[i + 2, 15].Value = result.tr_id;
                                worksheet.Cells[i + 2, 16].Value = result.city_name;
                                worksheet.Cells[i + 2, 17].Value = result.type_name;
                                worksheet.Cells[i + 2, 18].Value = result.user_name;

                                for (int col = 1; col <= headers.Length; col++)
                                {
                                    var cell = worksheet.Cells[i + 2, col];
                                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    cell.Style.Font.Size = 12;
                                }
                            }

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                            // Save the workbook to the specified file
                            FileInfo fi = new FileInfo(saveDialog.FileName);
                            package.SaveAs(fi);
                        }

                        // Add new notification
                        var note = new Note();
                        var notifications = new pages.Notifications();
                        var NoteText = "تصدير كشف البيع للعملاء";
                        note.AddNote(NoteText, notifications, "تصدير", 7);

                        MessageBox.Show("تم تصدير و حفظ الملف. سنقوم الآن بفتحه لك.", "نجاح عملية");
                        Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات إلى Excel: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Reset cursor to default
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void Btn_group1_Click(object sender, EventArgs e)
        {
            //  clbListNames1.Visible = !clbListNames1.Visible;
            //   clbListNames1.Visible = true; // عرض CheckedListBox
            //   txtSearch1.Visible = true; // عرض TextBox للبحث
            //   Btn_clear.Visible = true;
            //   Btn_ok.Visible = true;
            Ramy.Visible = true;
            txtSearch1.Focus();
            txtSearch1.Select();


        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch1.Text.Trim().ToLower();

           
            var currentCheckedItems = new Dictionary<string, bool>();
            foreach (var item in clbListNames1.Items.Cast<string>())
            {
                if (clbListNames1.GetItemChecked(clbListNames1.Items.IndexOf(item)))
                {
                    currentCheckedItems[item.ToLower()] = true;
                }
            }

          
            using (var dbContext = new AlibaRamyEntities())
            {
               
                var allItems = dbContext.TB_list
                    .AsNoTracking()
                    .Where(x => x.cust_id > 0)
                    .Select(p => p.list_name)
                    .Distinct()
                    .ToList();

               
                var matchedItems = allItems.Where(name => name.ToLower().Contains(searchText)).ToList();
                var nonMatchedItems = allItems.Where(name => !name.ToLower().Contains(searchText)).ToList();

               
                clbListNames1.Items.Clear();

              
                foreach (var name in matchedItems)
                {
                    clbListNames1.Items.Add(name, currentCheckedItems.ContainsKey(name.ToLower()) && currentCheckedItems[name.ToLower()]);
                }

                // إضافة العناصر غير المطابقة بعد العناصر المطابقة
                foreach (var name in nonMatchedItems)
                {
                    clbListNames1.Items.Add(name, currentCheckedItems.ContainsKey(name.ToLower()) && currentCheckedItems[name.ToLower()]);
                }
            }
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
           
            if (clbListNames1.CheckedItems.Count > 0)
            {
               
          //      Txt_cust.Text = "";
                Btn_group1.BackColor = Color.Red;
                Btn_group1.Text = "الغاء اختيار العملاء";

                Btn_group1.Refresh();
            }
            //  clbListNames1.Visible = false;
            //  txtSearch1.Visible = false;
            //  Btn_clear.Visible = false;
            //  Btn_ok.Visible = false;
            Ramy.Visible = false;
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            foreach (int index in clbListNames1.CheckedIndices)
            {
                clbListNames1.SetItemChecked(index, false);
                Btn_group1.Text = "اختيار عملاء";
            }
        }
    }
}