//using ALIBA_COMPANY.classes;
//using System.Data.Common;
//using DevExpress.XtraEditors;
//using DevExpress.XtraGrid.Views.Base;
//using DevExpress.XtraGrid.Views.Grid;
//using OfficeOpenXml;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.Entity;
//using System.Diagnostics;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using LicenseContext = OfficeOpenXml.LicenseContext;

//namespace ALIBA_COMPANY.other
//{
//    public partial class FRM_balance : DevExpress.XtraEditors.XtraForm
//    {

//        public FRM_balance()
//        {
//            InitializeComponent();
//            gridView1.CustomColumnDisplayText += OnCustomColumnDisplayText;
//            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
//            //gridView1.Columns.AddVisible("SequenceColumn", "تسلسل");
//            gridView1.Columns["T"].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
//            gridView1.Columns["T"].OptionsColumn.AllowEdit = false;
//            gridView1.Columns["T"].OptionsColumn.ReadOnly = true;




//        }
//        private void OnCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
//        {
//            GridView view = sender as GridView;
//            if (e.Column.FieldName == "PaymentsTotal00")
//            {
//                int? id = GetItemId(view, e.ListSourceRowIndex);
//                e.DisplayText = GetItemName(id).ToString();
//            }
//            else if (e.Column.FieldName == "Difference")
//            {
//                decimal num1 = GetValid1(view, e.ListSourceRowIndex);
//                decimal num2 = GetValid2(view, e.ListSourceRowIndex);

//                e.DisplayText = GetValid(num1, num2);
//            }
//        }
//        private string GetValid(decimal n1, decimal n2)
//        {
//            var result = n1 - n2;
//            return result.ToString();
//        }
//        private decimal GetValid1(GridView view, int rowIndex)
//        {
//            object value = view.GetRowCellValue(rowIndex, "PurchasesTotal");
//            return value != null ? Convert.ToDecimal(value) : 0;
//        }
//        private decimal GetValid2(GridView view, int rowIndex)
//        {
//            object value = view.GetRowCellValue(rowIndex, "PaymentsTotal");
//            return value != null ? Convert.ToDecimal(value) : 11111111111111111111;
//        }
//        private int GetItemId(GridView view, int rowIndex)
//        {
//            object value = view.GetRowCellValue(rowIndex, "ID");
//            return value != null ? Convert.ToInt32(value) : -1000000000;
//        }

//        private decimal? GetItemName(int? id)
//        {
//            using (var context = new AlibaRamyEntities())
//            {
//                var sum = context.TB_cridet
//                                 .Where(i => i.cust_id == id && (i.action_id == 6 || i.action_id == 7))
//                                 .Sum(i => i.cridet_s);
//                return sum != null ? sum : 0;
//            }
//        }
//        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
//        {
//            if (e.IsGetData && e.Column.FieldName == "T")
//            {
//                e.Value = e.ListSourceRowIndex + 1;
//            }
//        }





//        public class PurchaseResult
//        {

//            public decimal? Balance_us { get; set; }
//            public decimal? Balance_iq { get; set; }
//            public decimal? PaymentsTotal_us { get; set; }
//            public decimal? PaymentsTotal_iq { get; set; }
//            public string Name { get; set; }
//            public decimal? PurchasesTotal_us { get; set; }
//            public decimal? PurchasesTotal_iq { get; set; }
//            public decimal? Net_us { get; set; }
//            public decimal? Net_iq { get; set; }
//            public string Emplo { get; set; }
//            public decimal? Exch { get; set; }

//        }
//        private async void Serch()
//        {
//            try
//            {
//                SystemUtilities.SetProcessPriority();
//                loading.Visible = true;
//                bool ifZero = Check_zero.Checked; // تحقق من حالة الـ CheckBox
//                string selectedcust = null;
//                string selectedemplo = null;

//                List<string> selectedListNames = clbListNames1.CheckedItems.Cast<string>().ToList(); // الحصول على القوائم المختارة

//                this.Invoke((MethodInvoker)delegate
//                {
//                    selectedcust = Txt_cust.Text.Trim();
//                    selectedemplo = Combo_emplo.SelectedItem?.ToString();
//                });

//                List<PurchaseResult> results = new List<PurchaseResult>();
//                int pageSize = 1000000; // تأكد من تعيين حجم صفحة معقول
//                int pageNumber = 0; // تأكد من تعيين رقم الصفحة المناسب

//                var pageOfResults = await Task.Run(() =>
//                {
//                    using (var dbContext = new AlibaRamyEntities())
//                    {
//                        IEnumerable<PurchaseResult> queryResult;

//                        if (!string.IsNullOrEmpty(selectedemplo) && selectedemplo != "كل الموزعيين")
//                        {
//                            var queryForAll = from purchase in dbContext.TB_list.AsNoTracking()
//                                              where purchase.cust_id != 0
//                                              select new
//                                              {
//                                                  purchase.cust_id,
//                                                  purchase.TB_emplo.emplo_name,
//                                                  purchase.list_name,
//                                                  purchase.list_cridetUsd,
//                                                  purchase.list_cridetIQ,
//                                              };


//                            if (!string.IsNullOrEmpty(selectedemplo))
//                            {
//                                queryForAll = queryForAll.Where(x => x.emplo_name == selectedemplo);
//                            }
//                            if (!string.IsNullOrEmpty(selectedcust))
//                            {
//                                queryForAll = queryForAll.Where(x => x.list_name == selectedcust);
//                            }
//                            else
//                            {
//                                if (selectedListNames.Any())
//                                {
//                                    queryForAll = queryForAll.Where(x => selectedListNames.Contains(x.list_name));
//                                }
//                            }


//                            var queryResultBase = queryForAll
//                                .GroupBy(x => x.list_name)
//                                .Select(g => new
//                                {
//                                    Name = g.Key,
//                                    Emplo = g.Select(x => x.emplo_name).FirstOrDefault(),
//                                    PurchasesTotal_us = g.Sum(x => x.list_cridetUsd ?? 0.00m),
//                                    PurchasesTotal_iq = g.Sum(x => x.list_cridetIQ ?? 0.00m),
//                                    Exch = g.Sum(x => x.list_cridetIQ ?? 0.00m) / (g.Sum(x => x.list_cridetUsd ?? 0.00m) != 0 ? g.Sum(x => x.list_cridetUsd ?? 0.00m) : 1),
//                                })
//                                .OrderBy(x => x.Name)
//                                .Skip(pageNumber * pageSize)
//                                .Take(pageSize)
//                                .AsEnumerable()
//                                .Select(x => new PurchaseResult
//                                {
//                                    Emplo = x.Emplo,
//                                    Name = x.Name,
//                                    PurchasesTotal_us = x.PurchasesTotal_us,
//                                    PurchasesTotal_iq = x.PurchasesTotal_iq,
//                                    Exch = x.Exch,
//                                });




//                            var cridetSums = from cridet in dbContext.TB_cridet.AsNoTracking()
//                                             where (cridet.action_id == 6 || cridet.action_id == 7 || cridet.action_id == 8 || cridet.action_id == 9 || cridet.action_id == 23 || cridet.action_id == 25) && cridet.TB_emplo.emplo_name == selectedemplo
//                                             group cridet by cridet.list_name into g

//                                             let actionUS_Sum6723 = g.Where(c => c.action_id == 6 || c.action_id == 7 || c.action_id == 23).Sum(c => (decimal?)c.cridet_s) ?? 0.00m
//                                             let actionUS_Sum25 = g.Where(c => c.action_id == 25).Sum(c => (decimal?)c.cridet_s) ?? 0.00m

//                                             let actionIQ_Sum6723 = g.Where(c => c.action_id == 6 || c.action_id == 7 || c.action_id == 23).Sum(c => (decimal?)c.cridet_d) ?? 0.00m
//                                             let actionIQ_Sum25 = g.Where(c => c.action_id == 25).Sum(c => (decimal?)c.cridet_d) ?? 0.00m

//                                             select new
//                                             {

//                                                 Name = g.Key,
//                                                 TotalCridetS_us = actionUS_Sum6723,
//                                                 Balanc_us = actionUS_Sum25,

//                                                 TotalCridetS_iq = actionIQ_Sum6723,
//                                                 Balanc_iq = actionIQ_Sum25,

//                                             };




//                            var detailsQuery = from result in queryResultBase
//                                               join sum in cridetSums on result.Name equals sum.Name into rs
//                                               from sum in rs.DefaultIfEmpty()
//                                               select new
//                                               {
//                                                   result.Exch,
//                                                   result.Emplo,
//                                                   result.Name,
//                                                   result.PurchasesTotal_us,
//                                                   result.PurchasesTotal_iq,
//                                                   Balance_us = sum?.Balanc_us ?? 0.00m,
//                                                   Balance_iq = sum?.Balanc_iq ?? 0.00m,
//                                                   PaymentsTotal_us = sum != null ? sum.TotalCridetS_us : 0.00m, // إذا كانت sum null، تعيين 0
//                                                   PaymentsTotal_iq = sum != null ? sum.TotalCridetS_iq : 0.00m // إذا كانت sum null، تعيين 0
//                                               };

//                            var finalResult = detailsQuery.ToList();

//                            queryResult = finalResult.Select(x => new PurchaseResult
//                            {
//                                Emplo = x.Emplo,
//                                Name = x.Name,
//                                PurchasesTotal_us = x.PurchasesTotal_us,
//                                PurchasesTotal_iq = x.PurchasesTotal_iq,
//                                PaymentsTotal_us = x.PaymentsTotal_us,
//                                PaymentsTotal_iq = x.PaymentsTotal_iq,
//                                Net_us = (x.PurchasesTotal_us - x.PaymentsTotal_us),
//                                Net_iq = (x.PurchasesTotal_iq - x.PaymentsTotal_iq),
//                                Balance_us = x.Balance_us,
//                                Balance_iq = x.Balance_iq,
//                                Exch = x.Exch

//                            });

//                            if (ifZero)
//                            {
//                                queryResult = queryResult.Where(x => x.Net_us > 0 || x.Net_us < 0);
//                            }
//                            return queryResult.ToList();


//                        }


//                        else
//                        {
//                            // الاستعلام الأساسي لجميع البيانات بدون تصفية للموزع
//                            var queryForAll = from purchase in dbContext.TB_list.AsNoTracking()
//                                              where purchase.cust_id != 0
//                                              select new
//                                              {
//                                                  purchase.cust_id,
//                                                  purchase.TB_emplo.emplo_name,
//                                                  purchase.list_name,
//                                                  purchase.list_cridetUsd,
//                                                  purchase.list_cridetIQ,
//                                              };

//                            if (!string.IsNullOrEmpty(selectedcust))
//                            {
//                                queryForAll = queryForAll.Where(x => x.list_name == selectedcust);
//                            }
//                            else
//                            {
//                                if (selectedListNames.Any())
//                                {
//                                    queryForAll = queryForAll.Where(x => selectedListNames.Contains(x.list_name));
//                                }
//                            }


//                            var queryResultBase = queryForAll
//                                .GroupBy(x => new { x.emplo_name, x.list_name })

//                                .Select(g => new
//                                {
//                                    Exch = g.Sum(x => x.list_cridetIQ ?? 0.00m) / (g.Sum(x => x.list_cridetUsd ?? 0.00m) != 0 ? g.Sum(x => x.list_cridetUsd ?? 0.00m) : 1),
//                                    Name = g.Key.list_name,
//                                    Emplo = g.Key.emplo_name,
//                                    PurchasesTotal_us = g.Sum(x => x.list_cridetUsd ?? 0m),
//                                    PurchasesTotal_iq = g.Sum(x => x.list_cridetIQ ?? 0m),
//                                })
//                                .OrderBy(x => x.Name)
//                                .ThenBy(x => x.Emplo)
//                                .Skip(pageNumber * pageSize)
//                                .Take(pageSize)
//                                .AsEnumerable()
//                                .Select(x => new PurchaseResult
//                                {
//                                    Exch = x.Exch,
//                                    Name = x.Name,
//                                    Emplo = x.Emplo,
//                                    PurchasesTotal_us = x.PurchasesTotal_us,
//                                    PurchasesTotal_iq = x.PurchasesTotal_iq
//                                });


//                            // استعلام للحصول على مجموع القيم من TB_cridet
//                            var cridetSums = from cridet in dbContext.TB_cridet.AsNoTracking()
//                                             where (cridet.action_id == 6 || cridet.action_id == 7 || cridet.action_id == 8 || cridet.action_id == 9 || cridet.action_id == 23 || cridet.action_id == 25)
//                                             group cridet by new { cridet.TB_emplo.emplo_name, cridet.list_name } into g

//                                             let actionUS_Sum6723 = g.Where(c => c.action_id == 6 || c.action_id == 7 || c.action_id == 23).Sum(c => (decimal?)c.cridet_s) ?? 0.00m
//                                             let actionUS_Sum25 = g.Where(c => c.action_id == 25).Sum(c => (decimal?)c.cridet_s) ?? 0.00m

//                                             let actionIQ_Sum6723 = g.Where(c => c.action_id == 6 || c.action_id == 7 || c.action_id == 23).Sum(c => (decimal?)c.cridet_d) ?? 0.00m
//                                             let actionIQ_Sum25 = g.Where(c => c.action_id == 25).Sum(c => (decimal?)c.cridet_d) ?? 0.00m
//                                             select new
//                                             {
//                                                 Emplo = g.Key.emplo_name,
//                                                 Name = g.Key.list_name,

//                                                 TotalCridetS_us = actionUS_Sum6723,
//                                                 TotalCridetS_iq = actionIQ_Sum6723,

//                                                 Balanc_us = actionUS_Sum25,
//                                                 Balanc_iq = actionIQ_Sum25,
//                                             };


//                            var detailsQuery = from result in queryResultBase
//                                               join sum in cridetSums on new { result.Emplo, result.Name } equals new { sum.Emplo, sum.Name } into rs

//                                               from sum in rs.DefaultIfEmpty()
//                                               select new
//                                               {
//                                                   result.Exch,
//                                                   result.Name,
//                                                   result.Emplo,
//                                                   result.PurchasesTotal_us,
//                                                   result.PurchasesTotal_iq,
//                                                   Balance_us = sum?.Balanc_us ?? 0.00m,
//                                                   Balance_iq = sum?.Balanc_iq ?? 0.00m,
//                                                   PaymentsTotal_us = sum?.TotalCridetS_us ?? 0.00m, // إذا كانت sum null، تعيين 0
//                                                   PaymentsTotal_iq = sum?.TotalCridetS_iq ?? 0.00m // إذا كانت sum null، تعيين 0
//                                               };

//                            var finalResult = detailsQuery.ToList();


//                            queryResult = finalResult.Select(x => new PurchaseResult
//                            {

//                                Name = x.Name,
//                                Emplo = x.Emplo,
//                                PurchasesTotal_us = x.PurchasesTotal_us,
//                                PurchasesTotal_iq = x.PurchasesTotal_iq,
//                                PaymentsTotal_us = x.PaymentsTotal_us,
//                                PaymentsTotal_iq = x.PaymentsTotal_iq,
//                                Net_us = (x.PurchasesTotal_us - x.PaymentsTotal_us),
//                                Net_iq = (x.PurchasesTotal_iq - x.PaymentsTotal_iq),
//                                Balance_us = x.Balance_us,
//                                Balance_iq = x.Balance_iq,
//                                Exch = x.Exch,


//                            });
//                        }
//                        if (ifZero)
//                        {
//                            queryResult = queryResult.Where(x => x.Net_us > 0 || x.Net_us < 0);
//                        }
//                        return queryResult.ToList();
//                    }
//                });

//                results.AddRange(pageOfResults);

//                this.Invoke((MethodInvoker)delegate
//                {
//                    if (results.Count == 0)
//                    {
//                        gridControl1.DataSource = null;
//                        MessageBox.Show("لا توجد نتائج للمعلومات المختاره");
//                    }
//                    else
//                    {
//                        gridControl1.DataSource = results;
//                    }
//                });
//            }
//            catch (Exception ex)
//            {
//                this.Invoke((MethodInvoker)delegate
//                {
//                    MessageBox.Show("حدث خطأ في تحديد البيانات : " + ex.Message);
//                });
//            }
//            finally
//            {
//                loading.Visible = false;
//                GC.Collect();
//                GC.WaitForPendingFinalizers();
//            }
//        }
//        private void Btn_serch_Click(object sender, EventArgs e)
//        {
//            Serch();
//        }





//        private void Btn_group1_Click(object sender, EventArgs e)
//        {
//            clbListNames1.Visible = !clbListNames1.Visible;
//            clbListNames1.Visible = true; // عرض CheckedListBox
//            txtSearch1.Visible = true; // عرض TextBox للبحث
//            Btn_clear.Visible = true;
//            Btn_ok.Visible = true;
//        }

//        // متغير لتخزين حالة التحديد
//        private Dictionary<string, bool> savedCheckedItems = new Dictionary<string, bool>();

//        private void TxtSearch1_TextChanged(object sender, EventArgs e)
//        {
//            string searchText = txtSearch1.Text.Trim().ToLower();

//            // الاحتفاظ بحالة التحديد الحالية للعناصر المعروضة فقط
//            var currentCheckedItems = new Dictionary<string, bool>();
//            foreach (var item in clbListNames1.Items.Cast<string>())
//            {
//                if (clbListNames1.GetItemChecked(clbListNames1.Items.IndexOf(item)))
//                {
//                    currentCheckedItems[item.ToLower()] = true;
//                }
//            }

//            // تحديث البيانات من قاعدة البيانات
//            using (var dbContext = new AlibaRamyEntities())
//            {
//                // الحصول على العناصر المطابقة والنصوص غير المطابقة
//                var allItems = dbContext.TB_list
//                    .AsNoTracking()
//                    .Where(x => x.cust_id > 0)
//                    .Select(p => p.list_name)
//                    .Distinct()
//                    .ToList();

//                // فصل العناصر المطابقة عن غير المطابقة
//                var matchedItems = allItems.Where(name => name.ToLower().Contains(searchText)).ToList();
//                var nonMatchedItems = allItems.Where(name => !name.ToLower().Contains(searchText)).ToList();

//                // مسح العناصر القديمة وتحديث القائمة
//                clbListNames1.Items.Clear();

//                // إضافة العناصر المطابقة أولاً
//                foreach (var name in matchedItems)
//                {
//                    clbListNames1.Items.Add(name, currentCheckedItems.ContainsKey(name.ToLower()) && currentCheckedItems[name.ToLower()]);
//                }

//                // إضافة العناصر غير المطابقة بعد العناصر المطابقة
//                foreach (var name in nonMatchedItems)
//                {
//                    clbListNames1.Items.Add(name, currentCheckedItems.ContainsKey(name.ToLower()) && currentCheckedItems[name.ToLower()]);
//                }
//            }
//        }
//        private void CheckedListBox_VisibleChanged(object sender, EventArgs e)
//        {
//            // عند تغيير الرؤية لـ CheckedListBox، يمكنك استرجاع حالة التحديد إذا كان مرئيًا
//            if (clbListNames1.Visible)
//            {
//                foreach (var item in savedCheckedItems)
//                {
//                    for (int i = 0; i < clbListNames1.Items.Count; i++)
//                    {
//                        if (clbListNames1.Items[i].ToString().ToLower() == item.Key)
//                        {
//                            clbListNames1.SetItemChecked(i, item.Value);
//                        }
//                    }
//                }
//            }
//        }

//        private void Btn_ok_Click(object sender, EventArgs e)
//        {
//            // تحقق مما إذا كان هناك عناصر محددة في CheckedListBox
//            if (clbListNames1.CheckedItems.Count > 0)
//            {
//                // إذا كان هناك عناصر محددة، قم بمسح نص Txt_cust
//                Txt_cust.Text = "";
//                Btn_group1.BackColor = Color.Red;
//                Btn_group1.Text = "الغاء اختيار المجموعة";

//                Btn_group1.Refresh();
//            }
//            clbListNames1.Visible = false;
//            txtSearch1.Visible = false;
//            Btn_clear.Visible = false;
//            Btn_ok.Visible = false;
//        }

//        private void Btn_clear_Click(object sender, EventArgs e)
//        {
//            foreach (int index in clbListNames1.CheckedIndices)
//            {
//                clbListNames1.SetItemChecked(index, false);
//                Btn_group1.Text = "اختيار مجموعة";
//            }

//        }
//        public async Task LoadItemsAsync()
//        {
//            try
//            {
//                using (var dbContext = new AlibaRamyEntities())
//                {
//                    // استخدام await مع ToListAsync لجعل الاستعلام غير متزامن
//                    var listNames = await dbContext.TB_list
//                        .AsNoTracking()
//                        .Where(x => x.cust_id > 0)
//                        .Select(p => p.list_name)
//                        .Distinct()
//                        .ToListAsync()
//                        .ConfigureAwait(false);

//                    // تحديث واجهة المستخدم يجب أن يكون على خيط الواجهة (UI thread)
//                    // تأكد من أنك تقوم بذلك من خيط الواجهة
//                    clbListNames1.Invoke(new Action(() =>
//                    {
//                        clbListNames1.Items.Clear();
//                        foreach (var name in listNames)
//                        {
//                            clbListNames1.Items.Add(name, false); // False تعني أن كل العناصر غير محددة بشكل افتراضي
//                        }
//                    }));
//                }
//            }
//            catch (Exception ex)
//            {
//                // قم بإدارة الاستثناء بشكل أكثر تحديداً مثل تسجيل الأخطاء أو عرض رسالة للمستخدم
//                MessageBox.Show($"Error loading items: {ex.Message}");
//            }
//        }

//        private void Btn_print_Click(object sender, EventArgs e)
//        {
//            var Result = MessageBox.Show("هل تريد الطباعة؟", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            //
//            if (Result == DialogResult.Yes)
//            {
//                try
//                {// على سبيل المثال، إخفاء عمود بإسم "Age" من DataGridView
//                    gridView1.Columns["Balance_us"].Visible = false;
//                    gridView1.Columns["Balance_iq"].Visible = false;
//                    // عرض عنصر التحميل
//                    Cursor.Current = Cursors.WaitCursor;

//                    // إنشاء كائن من PrintingSystem
//                    var printingSystem = new DevExpress.XtraPrinting.PrintingSystem();

//                    // إنشاء كائن من PrintableComponentLink وتعيين GridControl كمكون للطباعة
//                    var printableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink(printingSystem)
//                    {
//                        Component = gridControl1
//                    };

//                    // تعيين الهوامش
//                    printableComponentLink.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);

//                    // تعيين اتجاه الصفحة (عمودي أو أفقي)
//                    printableComponentLink.Landscape = true; // True: أفقي، False: عمودي

//                    // إنشاء الوثيقة
//                    printableComponentLink.CreateDocument();

//                    // إعداد نافذة معاينة الطباعة
//                    var printPreviewForm = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx
//                    {
//                        PrintingSystem = printingSystem
//                    };

//                    // ضبط إعدادات الطباعة في نافذة المعاينة
//                    printPreviewForm.PrintingSystem.PageSettings.Landscape = true; // True: أفقي، False: عمودي
//                    printPreviewForm.PrintingSystem.PageSettings.PaperKind = (DevExpress.Drawing.Printing.DXPaperKind)System.Drawing.Printing.PaperKind.A4; // تحديد نوع الورق

//                    // عرض نافذة معاينة الطباعة
//                    printPreviewForm.ShowDialog();
//                }
//                catch (Exception ex)
//                {
//                    // التعامل مع الأخطاء
//                    MessageBox.Show("خطأ في الطباعة: " + ex.Message);
//                }
//                finally
//                {
//                    // إخفاء عنصر التحميل
//                    Cursor.Current = Cursors.Default;
//                    gridView1.Columns["Balance_us"].Visible = true;
//                    gridView1.Columns["Balance_iq"].Visible = true;
//                }
//            }


//        }
//        private string GetFocusedRowCellValue(string columnName)
//        {
//            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
//            return cellValue?.ToString();
//        }




//        private void LoadEmplo()
//        {
//            try
//            {
//                using (var dbbb = new AlibaRamyEntities())
//                {

//                    var emloies = dbbb.TB_emplo.Where(x => x.emplo_dis == true).Select(x => x.emplo_name).AsNoTracking().AsQueryable().ToList();
//                    emloies.Insert(0, "كل الموزعيين");
//                    Combo_emplo.DataSource = emloies;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(" حدث خطأ أثناء تحميل الموزعيين: " + ex.Message);
//            }
//        }

//        private async void FRM_balance_Load(object sender, EventArgs e)
//        {
//            LoadEmplo();
//            await LoadItemsAsync();
//        }
//        private void GetItemsName()
//        {
//            try
//            {
//                using (var dbbb = new AlibaRamyEntities())
//                {

//                    var listData = dbbb.TB_list.Where(x => x.cust_id != 0).Select(X => X.list_name).AsQueryable().ToList();
//                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
//                    collection.AddRange(listData.ToArray());
//                    Txt_cust.AutoCompleteCustomSource = collection;
//                }
//            }
//            catch { }
//        }

//        private void Txt_cust_TextChanged(object sender, EventArgs e)
//        {
//            GetItemsName();
//        }

//        private void Btn_xls_Click(object sender, EventArgs e)
//        {
//            var Result = MessageBox.Show("هل تريد التصدير الى اكسل؟", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            //
//            if (Result == DialogResult.Yes)
//            {
//                try
//                {
//                    // تحديد سياق الترخيص لمكتبة EPPlus
//                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // استخدم LicenseContext.Commercial إذا كنت تستخدمه تجاريًا
//                    List<PurchaseResult> filteredResults = gridControl1.DataSource as List<PurchaseResult>;

//                    if (filteredResults == null || !filteredResults.Any())
//                    {
//                        MessageBox.Show("لا توجد بيانات لتصديرها.");
//                        return;
//                    }

//                    using (var saveDialog = new SaveFileDialog
//                    {
//                        FileName = $"تقرير ديون-{DateTime.Now:yyyy-MM-dd___HH.mm.ss}.xlsx",
//                        Filter = "Excel Files|*.xlsx",
//                        Title = "حفظ التقرير كملف Excel"
//                    })
//                    {
//                        if (saveDialog.ShowDialog() == DialogResult.OK)
//                        {
//                            Cursor.Current = Cursors.WaitCursor; // Set cursor to waiting
//                            FileInfo fileInfo = new FileInfo(saveDialog.FileName);

//                            using (var package = new ExcelPackage(fileInfo))
//                            {
//                                var worksheet = package.Workbook.Worksheets.Add("تقرير الديون");

//                                // Define header colors and styles
//                                var headerCells = worksheet.Cells[1, 1, 1, 11];
//                                headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                                headerCells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
//                                headerCells.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, System.Drawing.Color.Black);

//                                // Add column headers
//                                worksheet.Cells[1, 1].Value = "ت";
//                                worksheet.Cells[1, 2].Value = "الاسم";
//                                worksheet.Cells[1, 3].Value = "الموظف";
//                                worksheet.Cells[1, 4].Value = "إجمالي المشتريات (دولار)";
//                                worksheet.Cells[1, 5].Value = "إجمالي المشتريات (دينار)";
//                                worksheet.Cells[1, 6].Value = "إجمالي المدفوعات (دولار)";
//                                worksheet.Cells[1, 7].Value = "إجمالي المدفوعات (دينار)";
//                                worksheet.Cells[1, 8].Value = "الديون (دولار)";
//                                worksheet.Cells[1, 9].Value = "الديون (دينار)";
//                                worksheet.Cells[1, 10].Value = "الرصيد (دولار)";
//                                worksheet.Cells[1, 11].Value = "الرصيد (دينار)";

//                                // Apply border to the header cells
//                                headerCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                                headerCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                                headerCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                                headerCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

//                                int row = 2;
//                                int sequence = 1; // Variable to keep track of sequence numbers
//                                foreach (var result in filteredResults)
//                                {
//                                    worksheet.Cells[row, 1].Value = sequence; // Add sequence number
//                                    worksheet.Cells[row, 2].Value = result.Name;
//                                    worksheet.Cells[row, 3].Value = result.Emplo;
//                                    worksheet.Cells[row, 4].Value = result.PurchasesTotal_us ?? 0;
//                                    worksheet.Cells[row, 5].Value = result.PurchasesTotal_iq ?? 0;
//                                    worksheet.Cells[row, 6].Value = result.PaymentsTotal_us ?? 0;
//                                    worksheet.Cells[row, 7].Value = result.PaymentsTotal_iq ?? 0;
//                                    worksheet.Cells[row, 8].Value = result.Net_us ?? 0;
//                                    worksheet.Cells[row, 9].Value = result.Net_iq ?? 0;
//                                    worksheet.Cells[row, 10].Value = result.Balance_us ?? 0;
//                                    worksheet.Cells[row, 11].Value = result.Balance_iq ?? 0;

//                                    // Apply border to the data cells
//                                    var dataCells = worksheet.Cells[row, 1, row, 11];
//                                    dataCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                                    dataCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                                    dataCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                                    dataCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

//                                    row++;
//                                    sequence++; // Increment sequence number
//                                }

//                                worksheet.Cells.AutoFitColumns();

//                                // Save the workbook to the specified file
//                                package.Save();
//                            }

//                            MessageBox.Show("تم تصدير البيانات بنجاح.");
//                            Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
//                        }
//                    }
//                    Cursor.Current = Cursors.Default; // Set cursor to waiting
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("حدث خطأ أثناء تصدير البيانات إلى Excel: " + ex.Message);
//                }
//            }
//        }

//        private void Btn_close_Click(object sender, EventArgs e)
//        {
//            this.Dispose();
//            this.Close();
//        }
//    }
//}

























//using ALIBA_COMPANY.classes;
//using DevExpress.XtraGrid.Views.Grid;
//using OfficeOpenXml;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using LicenseContext = OfficeOpenXml.LicenseContext;

//namespace ALIBA_COMPANY.other
//{
//    public partial class FRM_balance : DevExpress.XtraEditors.XtraForm
//    {
//        public FRM_balance()
//        {
//            InitializeComponent();
//            gridView1.CustomUnboundColumnData += (s, e) =>
//            {
//                if (e.IsGetData && e.Column.FieldName == "T")
//                    e.Value = e.ListSourceRowIndex + 1;
//            };
//            gridView1.Columns["T"].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
//            gridView1.Columns["T"].OptionsColumn.AllowEdit = false;
//            gridView1.Columns["T"].OptionsColumn.ReadOnly = true;
//        }

//        public class PurchaseResult
//        {
//            public string Name { get; set; }
//            public string Emplo { get; set; }
//            public decimal? Exch { get; set; }
//            public decimal? PurchasesTotal_us { get; set; }
//            public decimal? PurchasesTotal_iq { get; set; }
//            public decimal? PaymentsTotal_us { get; set; }
//            public decimal? PaymentsTotal_iq { get; set; }
//            public decimal? Net_us { get; set; }
//            public decimal? Net_iq { get; set; }
//            public decimal? Balance_us { get; set; }
//            public decimal? Balance_iq { get; set; }
//        }

//        private async void Serch()
//        {
//            try
//            {
//                SystemUtilities.SetProcessPriority();
//                loading.Visible = true;

//                bool ifZero = Check_zero.Checked;
//                string selectedcust = Txt_cust.Text.Trim();
//                string selectedemplo = Combo_emplo.SelectedItem?.ToString();
//                List<string> selectedListNames = clbListNames1.CheckedItems.Cast<string>().ToList();

//                var results = await Task.Run(() =>
//                {
//                    using (var db = new AlibaRamyEntities())
//                    {
//                        db.Database.CommandTimeout = 300;

//                        bool filterByEmplo = !string.IsNullOrEmpty(selectedemplo)
//                                             && selectedemplo != "كل الموزعيين";

//                        // ===== استعلام TB_list =====
//                        var listQuery = db.TB_list.AsNoTracking()
//                            .Where(x => x.cust_id != 0)
//                            .Select(x => new
//                            {
//                                x.cust_id,
//                                x.TB_emplo.emplo_name,
//                                x.list_name,
//                                x.list_cridetUsd,
//                                x.list_cridetIQ,
//                            });

//                        if (filterByEmplo)
//                            listQuery = listQuery.Where(x => x.emplo_name == selectedemplo);

//                        if (!string.IsNullOrEmpty(selectedcust))
//                            listQuery = listQuery.Where(x => x.list_name == selectedcust);
//                        else if (selectedListNames.Any())
//                            listQuery = listQuery.Where(x => selectedListNames.Contains(x.list_name));

//                        var baseList = listQuery
//                            .GroupBy(x => new { x.cust_id, x.emplo_name, x.list_name })
//                            .Select(g => new
//                            {
//                                CustId = g.Key.cust_id,
//                                Name = g.Key.list_name,
//                                Emplo = g.Key.emplo_name,
//                                PurchasesTotal_us = g.Sum(x => x.list_cridetUsd ?? 0m),
//                                PurchasesTotal_iq = g.Sum(x => x.list_cridetIQ ?? 0m),
//                                Exch = g.Sum(x => x.list_cridetIQ ?? 0m) /
//                                       (g.Sum(x => x.list_cridetUsd ?? 0m) != 0
//                                           ? g.Sum(x => x.list_cridetUsd ?? 0m) : 1),
//                            })
//                            .OrderBy(x => x.Name)
//                            .ThenBy(x => x.Emplo)
//                            .ToList();

//                        if (!baseList.Any()) return new List<PurchaseResult>();

//                        // ===== فلتر بـ cust_id =====
//                        var custIdList = baseList.Select(x => x.CustId).Distinct().ToList();

//                        // ===== استعلام TB_cridet =====
//                        var cridetQuery = db.TB_cridet.AsNoTracking()
//                            .Where(x => (x.action_id == 6 || x.action_id == 7 || x.action_id == 9)
//                                      && custIdList.Contains(x.cust_id));

//                        if (filterByEmplo)
//                            cridetQuery = cridetQuery.Where(x => x.TB_emplo.emplo_name == selectedemplo);

//                        var cridetSums = cridetQuery
//     .GroupBy(x => x.cust_id)
//     .Select(g => new
//     {
//         CustId = g.Key,
//         // مدفوعات = قبض نقدي + قبض اجل
//         PayUS = g.Where(c => c.action_id == 6 || c.action_id == 7)
//                  .Sum(c => (decimal?)c.cridet_s) ?? 0m,
//         PayIQ = g.Where(c => c.action_id == 6 || c.action_id == 7)
//                  .Sum(c => (decimal?)c.cridet_d) ?? 0m,
//         // مشتريات آجلة = صرف اجل
//         SalesUS = g.Where(c => c.action_id == 9)
//                    .Sum(c => (decimal?)c.cridet_s) ?? 0m,
//         SalesIQ = g.Where(c => c.action_id == 9)
//                    .Sum(c => (decimal?)c.cridet_d) ?? 0m,
//     })
//     .ToList();

//                        var query = from b in baseList
//                                    join c in cridetSums on b.CustId equals c.CustId into cs
//                                    from c in cs.DefaultIfEmpty()
//                                    select new PurchaseResult
//                                    {
//                                        Name = b.Name,
//                                        Emplo = b.Emplo,
//                                        Exch = b.Exch,

//                                        // إجمالي المشتريات = من TB_list (نقدي) + صرف اجل من TB_cridet
//                                        PurchasesTotal_us = b.PurchasesTotal_us + (c?.SalesUS ?? 0m),
//                                        PurchasesTotal_iq = b.PurchasesTotal_iq + (c?.SalesIQ ?? 0m),

//                                        // إجمالي المدفوعات = قبض نقدي + قبض اجل
//                                        PaymentsTotal_us = c?.PayUS ?? 0m,
//                                        PaymentsTotal_iq = c?.PayIQ ?? 0m,

//                                        // الديون = مشتريات - مدفوعات
//                                        Net_us = (b.PurchasesTotal_us + (c?.SalesUS ?? 0m)) - (c?.PayUS ?? 0m),
//                                        Net_iq = (b.PurchasesTotal_iq + (c?.SalesIQ ?? 0m)) - (c?.PayIQ ?? 0m),

//                                        // الرصيد = لا يوجد مصدر واضح له، نتجاهله مؤقتاً
//                                        Balance_us = 0m,
//                                        Balance_iq = 0m,
//                                    };

//                        if (ifZero)
//                            query = query.Where(x => x.Net_us != 0);

//                        return query.ToList();
//                    }
//                });

//                if (results.Count == 0)
//                {
//                    gridControl1.DataSource = null;
//                    MessageBox.Show("لا توجد نتائج للمعلومات المختاره");
//                }
//                else
//                {
//                    gridControl1.DataSource = results;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("حدث خطأ في تحديد البيانات : " + ex.Message);
//            }
//            finally
//            {
//                loading.Visible = false;
//                GC.Collect();
//                GC.WaitForPendingFinalizers();
//            }
//        }
//        private void Btn_serch_Click(object sender, EventArgs e) => Serch();

//        private void Btn_group1_Click(object sender, EventArgs e)
//        {
//            clbListNames1.Visible = true;
//            txtSearch1.Visible = true;
//            Btn_clear.Visible = true;
//            Btn_ok.Visible = true;
//        }

//        private Dictionary<string, bool> savedCheckedItems = new Dictionary<string, bool>();

//        private void TxtSearch1_TextChanged(object sender, EventArgs e)
//        {
//            string searchText = txtSearch1.Text.Trim().ToLower();

//            var currentChecked = clbListNames1.Items.Cast<string>()
//                .Where(item => clbListNames1.GetItemChecked(clbListNames1.Items.IndexOf(item)))
//                .ToDictionary(item => item.ToLower(), _ => true);

//            using (var db = new AlibaRamyEntities())
//            {
//                var allItems = db.TB_list.AsNoTracking()
//                    .Where(x => x.cust_id > 0)
//                    .Select(p => p.list_name)
//                    .Distinct().ToList();

//                clbListNames1.Items.Clear();

//                foreach (var name in allItems.OrderByDescending(n => n.ToLower().Contains(searchText)))
//                    clbListNames1.Items.Add(name, currentChecked.ContainsKey(name.ToLower()));
//            }
//        }

//        private void Btn_ok_Click(object sender, EventArgs e)
//        {
//            if (clbListNames1.CheckedItems.Count > 0)
//            {
//                Txt_cust.Text = "";
//                Btn_group1.BackColor = Color.Red;
//                Btn_group1.Text = "الغاء اختيار المجموعة";
//            }
//            clbListNames1.Visible = txtSearch1.Visible = Btn_clear.Visible = Btn_ok.Visible = false;
//        }

//        private void Btn_clear_Click(object sender, EventArgs e)
//        {
//            foreach (int i in clbListNames1.CheckedIndices.Cast<int>().ToList())
//                clbListNames1.SetItemChecked(i, false);
//            Btn_group1.Text = "اختيار مجموعة";
//        }

//        public async Task LoadItemsAsync()
//        {
//            try
//            {
//                using (var db = new AlibaRamyEntities())
//                {
//                    var names = await db.TB_list.AsNoTracking()
//                        .Where(x => x.cust_id > 0)
//                        .Select(p => p.list_name)
//                        .Distinct()
//                        .ToListAsync().ConfigureAwait(false);

//                    clbListNames1.Invoke(new Action(() =>
//                    {
//                        clbListNames1.Items.Clear();
//                        names.ForEach(n => clbListNames1.Items.Add(n, false));
//                    }));
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading items: {ex.Message}");
//            }
//        }

//        private void LoadEmplo()
//        {
//            try
//            {
//                using (var db = new AlibaRamyEntities())
//                {
//                    var list = db.TB_emplo.AsNoTracking()
//                        .Where(x => x.emplo_dis == true)
//                        .Select(x => x.emplo_name).ToList();
//                    list.Insert(0, "كل الموزعيين");
//                    Combo_emplo.DataSource = list;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("حدث خطأ أثناء تحميل الموزعيين: " + ex.Message);
//            }
//        }

//        private async void FRM_balance_Load(object sender, EventArgs e)
//        {
//            LoadEmplo();
//            await LoadItemsAsync();
//        }

//        private void Txt_cust_TextChanged(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var db = new AlibaRamyEntities())
//                {
//                    var names = db.TB_list.Where(x => x.cust_id != 0).Select(x => x.list_name).ToList();
//                    var col = new AutoCompleteStringCollection();
//                    col.AddRange(names.ToArray());
//                    Txt_cust.AutoCompleteCustomSource = col;
//                }
//            }
//            catch { }
//        }

//        private void Btn_print_Click(object sender, EventArgs e)
//        {
//            if (MessageBox.Show("هل تريد الطباعة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//                return;
//            try
//            {
//                gridView1.Columns["Balance_us"].Visible = false;
//                gridView1.Columns["Balance_iq"].Visible = false;
//                Cursor.Current = Cursors.WaitCursor;

//                var ps = new DevExpress.XtraPrinting.PrintingSystem();
//                var link = new DevExpress.XtraPrinting.PrintableComponentLink(ps)
//                {
//                    Component = gridControl1,
//                    Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10),
//                    Landscape = true
//                };
//                link.CreateDocument();

//                var preview = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx { PrintingSystem = ps };
//                preview.PrintingSystem.PageSettings.Landscape = true;
//                preview.PrintingSystem.PageSettings.PaperKind = (DevExpress.Drawing.Printing.DXPaperKind)System.Drawing.Printing.PaperKind.A4;
//                preview.ShowDialog();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("خطأ في الطباعة: " + ex.Message);
//            }
//            finally
//            {
//                Cursor.Current = Cursors.Default;
//                gridView1.Columns["Balance_us"].Visible = true;
//                gridView1.Columns["Balance_iq"].Visible = true;
//            }
//        }

//        private void Btn_xls_Click(object sender, EventArgs e)
//        {
//            if (MessageBox.Show("هل تريد التصدير الى اكسل؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//                return;
//            try
//            {
//                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//                var data = gridControl1.DataSource as List<PurchaseResult>;

//                if (data == null || !data.Any()) { MessageBox.Show("لا توجد بيانات لتصديرها."); return; }

//                using (var dlg = new SaveFileDialog
//                {
//                    FileName = $"تقرير ديون-{DateTime.Now:yyyy-MM-dd___HH.mm.ss}.xlsx",
//                    Filter = "Excel Files|*.xlsx"
//                })
//                {
//                    if (dlg.ShowDialog() != DialogResult.OK) return;

//                    Cursor.Current = Cursors.WaitCursor;
//                    using (var pkg = new ExcelPackage(new FileInfo(dlg.FileName)))
//                    {
//                        var ws = pkg.Workbook.Worksheets.Add("تقرير الديون");
//                        string[] headers = { "ت", "الاسم", "الموظف", "مشتريات $", "مشتريات د.ع", "مدفوعات $", "مدفوعات د.ع", "ديون $", "ديون د.ع", "رصيد $", "رصيد د.ع" };

//                        for (int i = 0; i < headers.Length; i++)
//                        {
//                            ws.Cells[1, i + 1].Value = headers[i];
//                            ws.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                            ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
//                        }

//                        int row = 2, seq = 1;
//                        foreach (var r in data)
//                        {
//                            ws.Cells[row, 1].Value = seq++;
//                            ws.Cells[row, 2].Value = r.Name;
//                            ws.Cells[row, 3].Value = r.Emplo;
//                            ws.Cells[row, 4].Value = r.PurchasesTotal_us ?? 0;
//                            ws.Cells[row, 5].Value = r.PurchasesTotal_iq ?? 0;
//                            ws.Cells[row, 6].Value = r.PaymentsTotal_us ?? 0;
//                            ws.Cells[row, 7].Value = r.PaymentsTotal_iq ?? 0;
//                            ws.Cells[row, 8].Value = r.Net_us ?? 0;
//                            ws.Cells[row, 9].Value = r.Net_iq ?? 0;
//                            ws.Cells[row, 10].Value = r.Balance_us ?? 0;
//                            ws.Cells[row, 11].Value = r.Balance_iq ?? 0;

//                            var cell = ws.Cells[row, 1, row, 11];
//                            cell.Style.Border.Top.Style = cell.Style.Border.Bottom.Style =
//                            cell.Style.Border.Left.Style = cell.Style.Border.Right.Style =
//                                OfficeOpenXml.Style.ExcelBorderStyle.Thin;
//                            row++;
//                        }

//                        ws.Cells.AutoFitColumns();
//                        pkg.Save();
//                    }

//                    MessageBox.Show("تم تصدير البيانات بنجاح.");
//                    Process.Start(new ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("حدث خطأ أثناء التصدير: " + ex.Message);
//            }
//            finally
//            {
//                Cursor.Current = Cursors.Default;
//            }
//        }

//        private void Btn_close_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//}



















using ALIBA_COMPANY.classes;
using DevExpress.XtraGrid.Views.Grid;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_balance : DevExpress.XtraEditors.XtraForm
    {
        public FRM_balance()
        {
            InitializeComponent();
            InitializeGridColumns();
        }

        private void InitializeGridColumns()
        {
            gridView1.CustomUnboundColumnData += (s, e) =>
            {
                if (e.IsGetData && e.Column.FieldName == "T")
                    e.Value = e.ListSourceRowIndex + 1;
            };
            gridView1.Columns["T"].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.Columns["T"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["T"].OptionsColumn.ReadOnly = true;

            gridView1.RowCellStyle += (s, e) =>
            {
                if (e.Column.FieldName == "Status")
                {
                    var row = gridView1.GetRow(e.RowHandle) as PurchaseResult;
                    if (row == null) return;

                    e.Appearance.ForeColor = row.Status == "دائن" ? Color.Green
                                           : row.Status == "لا توجد ديون" ? Color.YellowGreen
                                           : Color.DarkRed;

                    e.Appearance.Font = new Font("Segoe UI", 12f,
                     row.Status == "لا توجد ديون" ? FontStyle.Strikeout : FontStyle.Bold);
                }
            };

            gridControl1.DataSourceChanged += (s, e) =>
            {
                if (gridControl1.DataSource == null) return;

                string moneyFormat = "#,##0.00";

                foreach (var col in new[] { "PurchasesTotal_us", "PurchasesTotal_iq",
                                 "PaymentsTotal_us",  "PaymentsTotal_iq",
                                 "Net_us",            "Net_iq" })
                {
                    if (gridView1.Columns[col] == null) continue;
                    gridView1.Columns[col].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[col].DisplayFormat.FormatString = moneyFormat;
                }
            };


            // ═══════════════════════════════════════
            // تصميم الجريد
            // ═══════════════════════════════════════

            // ═══════════════════════════════════════
            // تصميم الجريد
            // ═══════════════════════════════════════

            // الخط العام
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 14f);
            gridView1.Appearance.Row.Options.UseFont = true;

            // لون صفوف متناوبة
            gridView1.Appearance.Row.BackColor = Color.White;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(235, 245, 251);
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;

            // هيدر الأعمدة
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(41, 128, 185);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;

            // الصف المحدد
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(174, 214, 241);
            gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;

            // خط الشبكة
            gridView1.Appearance.VertLine.BackColor = Color.FromArgb(210, 210, 210);
            gridView1.Appearance.HorzLine.BackColor = Color.FromArgb(210, 210, 210);
            gridView1.Appearance.VertLine.Options.UseBackColor = true;
            gridView1.Appearance.HorzLine.Options.UseBackColor = true;

            // إخفاء مؤشر التجميع
            gridView1.OptionsView.ShowGroupPanel = false;

            // ارتفاع الصفوف
            gridView1.RowHeight = 32;

            // محاذاة النص يمين
            gridView1.OptionsView.ColumnAutoWidth = true;
        }

        public class PurchaseResult
        {
            public int CustId { get; set; }
            public string Name { get; set; }
            public string Emplo { get; set; }
            public decimal? Exch { get; set; }

            public decimal? PurchasesTotal_us { get; set; }
            public decimal? PurchasesTotal_iq { get; set; }

            public decimal? PaymentsTotal_us { get; set; }
            public decimal? PaymentsTotal_iq { get; set; }

            public decimal? Net_us { get; set; }
            public decimal? Net_iq { get; set; }

            public string Status { get; set; }
        }

        private async void Search()
        {
            try
            {
                SystemUtilities.SetProcessPriority();
                loading.Visible = true;

                bool hideZero = Check_zero.Checked;
                string selectedCust = Txt_cust.Text.Trim();
                string selectedEmplo = Combo_emplo.SelectedItem?.ToString();
                var selectedListNames = clbListNames1.CheckedItems.Cast<string>().ToList();

                var results = await Task.Run(() =>
                    BuildResults(hideZero, selectedCust, selectedEmplo, selectedListNames));

                if (results.Count == 0)
                {
                    gridControl1.DataSource = null;
                    MessageBox.Show("لا توجد نتائج للمعلومات المختارة");
                }
                else
                {
                    gridControl1.DataSource = results;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد البيانات : " + ex.Message);
            }
            finally
            {
                loading.Visible = false;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private List<PurchaseResult> BuildResults(
            bool hideZero,
            string selectedCust,
            string selectedEmplo,
            List<string> selectedListNames)
        {
            using (var db = new AlibaRamyEntities())
            {
                db.Database.CommandTimeout = 300;

                bool filterByEmplo = !string.IsNullOrEmpty(selectedEmplo)
                                     && selectedEmplo != "كل الموزعيين";

                var listQuery = db.TB_list.AsNoTracking()
                    .Where(x => x.cust_id != 0 && x.sending == true)
                    .Select(x => new
                    {
                        x.cust_id,
                        EmploId = (int?)x.TB_emplo.emplo_id,
                        EmploName = x.TB_emplo.emplo_name,
                        x.list_name,
                        x.list_cridetUsd,
                        x.list_cridetIQ,
                    });

                if (filterByEmplo)
                    listQuery = listQuery.Where(x => x.EmploName == selectedEmplo);

                if (!string.IsNullOrEmpty(selectedCust))
                    listQuery = listQuery.Where(x => x.list_name == selectedCust);
                else if (selectedListNames.Any())
                    listQuery = listQuery.Where(x => selectedListNames.Contains(x.list_name));

                var baseList = listQuery
                    .GroupBy(x => new { x.cust_id, x.EmploId, x.EmploName, x.list_name })
                    .Select(g => new
                    {
                        CustId = g.Key.cust_id,
                        EmploId = g.Key.EmploId,
                        Name = g.Key.list_name,
                        Emplo = g.Key.EmploName,
                        CridetTotal_us = g.Sum(x => x.list_cridetUsd ?? 0m),
                        CridetTotal_iq = g.Sum(x => x.list_cridetIQ ?? 0m),
                        Exch = g.Sum(x => x.list_cridetIQ ?? 0m) /
                                         (g.Sum(x => x.list_cridetUsd ?? 0m) != 0
                                             ? g.Sum(x => x.list_cridetUsd ?? 0m) : 1m),
                    })
                    .OrderBy(x => x.Name)
                    .ThenBy(x => x.Emplo)
                    .ToList();

                if (!baseList.Any())
                    return new List<PurchaseResult>();

                var custIdList = baseList.Where(x => x.CustId.HasValue)
                                          .Select(x => x.CustId.Value).Distinct().ToList();

                var emploIdList = baseList.Where(x => x.EmploId.HasValue)
                                          .Select(x => x.EmploId.Value).Distinct().ToList();

                var cridetSums = db.TB_cridet.AsNoTracking()
                    .Where(x => (x.action_id == 6 || x.action_id == 7 ||
                                 x.action_id == 8 || x.action_id == 9)
                              && x.cust_id.HasValue
                              && x.emplo_id.HasValue
                              && x.sending == true
                              && custIdList.Contains(x.cust_id.Value)
                              && emploIdList.Contains(x.emplo_id.Value))
                    .GroupBy(x => new { CustId = x.cust_id.Value, EmploId = x.emplo_id.Value })
                    .Select(g => new
                    {
                        g.Key.CustId,
                        g.Key.EmploId,
                        PayUS = g.Where(c => c.action_id == 6 || c.action_id == 7)
                                    .Sum(c => (decimal?)c.cridet_s) ?? 0m,
                        PayIQ = g.Where(c => c.action_id == 6 || c.action_id == 7)
                                    .Sum(c => (decimal?)c.cridet_d) ?? 0m,
                        RefundUS = g.Where(c => c.action_id == 8 || c.action_id == 9)
                                    .Sum(c => (decimal?)c.cridet_s) ?? 0m,
                        RefundIQ = g.Where(c => c.action_id == 8 || c.action_id == 9)
                                    .Sum(c => (decimal?)c.cridet_d) ?? 0m,
                    })
                    .ToList();

                var query = from b in baseList
                            join c in cridetSums
                                on new
                                {
                                    CustId = b.CustId.GetValueOrDefault(),
                                    EmploId = b.EmploId.GetValueOrDefault()
                                }
                               equals new { c.CustId, c.EmploId }
                                into cs
                            from c in cs.DefaultIfEmpty()
                            let netUs = (b.CridetTotal_us + (c?.RefundUS ?? 0m)) - (c?.PayUS ?? 0m)
                            select new PurchaseResult
                            {
                                CustId = b.CustId.GetValueOrDefault(),
                                Name = b.Name,
                                Emplo = b.Emplo,
                                Exch = b.Exch,

                                PurchasesTotal_us = b.CridetTotal_us + (c?.RefundUS ?? 0m),
                                PurchasesTotal_iq = b.CridetTotal_iq + (c?.RefundIQ ?? 0m),

                                PaymentsTotal_us = c?.PayUS ?? 0m,
                                PaymentsTotal_iq = c?.PayIQ ?? 0m,

                                Net_us = netUs,
                                Net_iq = (b.CridetTotal_iq + (c?.RefundIQ ?? 0m)) - (c?.PayIQ ?? 0m),

                                Status = netUs < 0 ? "دائن"
                                       : netUs > 0 ? "مدين"
                                       : "لا توجد ديون",
                            };

                if (hideZero)
                    query = query.Where(x => x.Net_us != 0);

                return query.ToList();
            }
        }

        private void Btn_serch_Click(object sender, EventArgs e) => Search();

        private void Btn_group1_Click(object sender, EventArgs e)
        {
            clbListNames1.Visible = true;
            txtSearch1.Visible = true;
            Btn_clear.Visible = true;
            Btn_ok.Visible = true;
        }

        private void TxtSearch1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch1.Text.Trim().ToLower();

            var currentChecked = clbListNames1.Items.Cast<string>()
                .Where(item => clbListNames1.GetItemChecked(clbListNames1.Items.IndexOf(item)))
                .ToDictionary(item => item.ToLower(), _ => true);

            using (var db = new AlibaRamyEntities())
            {
                var allItems = db.TB_list.AsNoTracking()
                    .Where(x => x.cust_id > 0 && x.sending == true)
                    .Select(p => p.list_name)
                    .Distinct()
                    .ToList();

                clbListNames1.Items.Clear();

                foreach (var name in allItems.OrderByDescending(n => n.ToLower().Contains(searchText)))
                    clbListNames1.Items.Add(name, currentChecked.ContainsKey(name.ToLower()));
            }
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (clbListNames1.CheckedItems.Count > 0)
            {
                Txt_cust.Text = "";
                Btn_group1.BackColor = Color.Red;
                Btn_group1.Text = "الغاء اختيار المجموعة";
                Btn_group1.Refresh();
            }
            clbListNames1.Visible = txtSearch1.Visible = Btn_clear.Visible = Btn_ok.Visible = false;
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            foreach (int i in clbListNames1.CheckedIndices.Cast<int>().ToList())
                clbListNames1.SetItemChecked(i, false);
            Btn_group1.Text = "اختيار مجموعة";
        }

        public async Task LoadItemsAsync()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var names = await db.TB_list.AsNoTracking()
                        .Where(x => x.cust_id > 0 && x.sending == true)
                        .Select(p => p.list_name)
                        .Distinct()
                        .ToListAsync()
                        .ConfigureAwait(false);

                    clbListNames1.Invoke(new Action(() =>
                    {
                        clbListNames1.Items.Clear();
                        names.ForEach(n => clbListNames1.Items.Add(n, false));
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}");
            }
        }

        private void LoadEmplo()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var list = db.TB_emplo.AsNoTracking()
                        .Where(x => x.emplo_dis == true)
                        .Select(x => x.emplo_name)
                        .ToList();

                    list.Insert(0, "كل الموزعيين");
                    Combo_emplo.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل الموزعين: " + ex.Message);
            }
        }

        private async void FRM_balance_Load(object sender, EventArgs e)
        {
            LoadEmplo();
            await LoadItemsAsync();
        }

        private void Txt_cust_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var names = db.TB_list
                        .Where(x => x.cust_id != 0 && x.sending == true)
                        .Select(x => x.list_name)
                        .ToList();

                    var col = new AutoCompleteStringCollection();
                    col.AddRange(names.ToArray());
                    Txt_cust.AutoCompleteCustomSource = col;
                }
            }
            catch { }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الطباعة؟", "تأكيد",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var ps = new DevExpress.XtraPrinting.PrintingSystem();
                var link = new DevExpress.XtraPrinting.PrintableComponentLink(ps)
                {
                    Component = gridControl1,
                    Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10),
                    Landscape = true
                };
                link.CreateDocument();

                var preview = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx
                {
                    PrintingSystem = ps
                };
                preview.PrintingSystem.PageSettings.Landscape = true;
                preview.PrintingSystem.PageSettings.PaperKind =
                    (DevExpress.Drawing.Printing.DXPaperKind)System.Drawing.Printing.PaperKind.A4;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الطباعة: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void Btn_xls_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد التصدير إلى إكسل؟", "تأكيد",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var data = gridControl1.DataSource as List<PurchaseResult>;

                if (data == null || !data.Any())
                {
                    MessageBox.Show("لا توجد بيانات لتصديرها.");
                    return;
                }

                using (var dlg = new SaveFileDialog
                {
                    FileName = $"تقرير ديون-{DateTime.Now:yyyy-MM-dd___HH.mm.ss}.xlsx",
                    Filter = "Excel Files|*.xlsx"
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    Cursor.Current = Cursors.WaitCursor;

                    using (var pkg = new ExcelPackage(new FileInfo(dlg.FileName)))
                    {
                        var ws = pkg.Workbook.Worksheets.Add("تقرير الديون");
                        ws.View.RightToLeft = true;

                        string[] headers =
                        {
                            "ت", "الاسم", "الموظف",
                            "مشتريات $", "مشتريات د.ع",
                            "مدفوعات $", "مدفوعات د.ع",
                            "ديون $",    "ديون د.ع",
                            "الحالة $"
                        };

                        for (int i = 0; i < headers.Length; i++)
                        {
                            var cell = ws.Cells[1, i + 1];
                            cell.Value = headers[i];
                            cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                        }
                        ApplyBorder(ws.Cells[1, 1, 1, headers.Length]);

                        int row = 2, seq = 1;
                        foreach (var r in data)
                        {
                            ws.Cells[row, 1].Value = seq++;
                            ws.Cells[row, 2].Value = r.Name;
                            ws.Cells[row, 3].Value = r.Emplo;
                            ws.Cells[row, 4].Value = r.PurchasesTotal_us ?? 0;
                            ws.Cells[row, 5].Value = r.PurchasesTotal_iq ?? 0;
                            ws.Cells[row, 6].Value = r.PaymentsTotal_us ?? 0;
                            ws.Cells[row, 7].Value = r.PaymentsTotal_iq ?? 0;
                            ws.Cells[row, 8].Value = r.Net_us ?? 0;
                            ws.Cells[row, 9].Value = r.Net_iq ?? 0;
                            ws.Cells[row, 10].Value = r.Status;

                            ws.Cells[row, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, 10].Style.Fill.BackgroundColor.SetColor(
                                r.Status == "دائن" ? Color.LightGreen
                              : r.Status == "لا توجد ديون" ? Color.LightYellow
                              : Color.LightCoral);

                            ApplyBorder(ws.Cells[row, 1, row, headers.Length]);
                            row++;
                        }

                        ws.Cells.AutoFitColumns();
                        pkg.Save();
                    }

                    MessageBox.Show("تم تصدير البيانات بنجاح.");
                    Process.Start(new ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التصدير: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private static void ApplyBorder(OfficeOpenXml.ExcelRange range)
        {
            range.Style.Border.Top.Style =
            range.Style.Border.Bottom.Style =
            range.Style.Border.Left.Style =
            range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}