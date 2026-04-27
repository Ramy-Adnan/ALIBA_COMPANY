using DevExpress.XtraGrid.Views.Grid;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_Dis_store : DevExpress.XtraEditors.XtraForm
    {
     
        public FRM_Dis_store()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
            //gridView1.Columns.AddVisible("Ramy", "تسلسل");
            gridView1.Columns["Ramy"].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.Columns["Ramy"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Ramy"].OptionsColumn.ReadOnly = true;
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && e.Column.FieldName == "Ramy")
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {

                SystemUtilities.SetProcessPriority();
                loading.Visible = true;
           
                string selectedCatg = null;
                decimal quantity = 0;
                string selectedcompare = null;
                DateTime selectDate = dateTimePicker1.Value.Date;
                if (Txt_Num.Text == "")
                {
                    Txt_Num.Text = "0";
                }
                this.Invoke((MethodInvoker)delegate
                {
                   
                    selectedCatg = Combo_Catg.SelectedItem?.ToString();
                    quantity = decimal.Parse(Txt_Num.Text);
                    selectedcompare = Combo_compare.SelectedItem?.ToString();
                    selectDate = dateTimePicker1.Value.Date;
                });
                List<string> selectedListNames = clbListNames1.CheckedItems.Cast<string>().ToList(); // الحصول على القوائم المختارة
                List<dynamic> results = new List<dynamic>();
                int pageSize = 100000000;
                int pageNumber = 0;
                var pageOfResults = await Task.Run(() =>
                {

                    using (var dbContext = new AlibaRamyEntities())
                    {
                                // Create the base query
                                var query = (from inventory in dbContext.TB_str
                                     join item in dbContext.TB_items on inventory.items_id equals item.items_id
                                     where inventory.str_date <= selectDate
                                     group new { inventory } by new { inventory.items_id, item.items_name, item.TB_groups.groups_name, item.items_form } into g
                                     select new
                                     {

                                         itemsId = g.Key.items_id,
                                         ItemName = g.Key.items_name,
                                         GroupName = g.Key.groups_name,
                                         itemQuart = g.Key.items_form,
                                         TotalQuantity = g.Sum(i => i.inventory.str_num) + g.Sum(i => i.inventory.str_renum)
                                     });

                                // Apply filters dynamically
                                if (selectedcompare == "اكبر من")
                        {
                            query = query.Where(x => x.TotalQuantity > quantity);
                        }
                        else if (selectedcompare == "اصغر من")
                        {
                            query = query.Where(x => x.TotalQuantity < quantity);
                        }
                        else if (selectedcompare == "يساوي")
                        {
                            query = query.Where(x => x.TotalQuantity == quantity);
                        }

                        if (selectedCatg != null && selectedCatg != "كل الأصناف")
                        {
                            query = query.Where(x => x.GroupName == selectedCatg);
                        }
                       /* if (!string.IsNullOrEmpty(selectedItemsName))
                        {
                            query = query.Where(x => x.ItemName == selectedItemsName);
                        }*/
                        if (selectedListNames.Any())
                        {
                            query = query.Where(x => selectedListNames.Contains(x.ItemName));
                        }
                        return query.OrderBy(x => x.itemsId)
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
                        gridControl1.DataSource = results;
                    }

                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
                });
            }
            finally
            {
                loading.Visible = false;

                // Trigger garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        /*   private async void Btn_serch_Click(object sender, EventArgs e)
           {
               try
               {
                   SystemUtilities.SetProcessPriority();
                   loading.Visible = true;

                   string selectedItemsName = "";
                   string selectedCatg = null;
                   decimal quantity = 0;
                   string selectedcompare = "";
                   DateTime selectDate = dateTimePicker1.Value.Date;

                   if (Txt_Num.Text == "")
                   {
                       Txt_Num.Text = "0";
                   }

                   this.Invoke((MethodInvoker)delegate
                   {
                       selectedItemsName = Txt_items_name.Text.ToString();
                       selectedCatg = Combo_Catg.SelectedItem?.ToString() ?? "كل الأصناف";  
                       quantity = decimal.Parse(Txt_Num.Text);
                       selectedcompare = Combo_compare.SelectedItem?.ToString()??"";
                       selectDate = dateTimePicker1.Value.Date;
                   });

                   List<InventoryViewModel> results = new List<InventoryViewModel>();
                   int pageSize = 100000000;
                   int pageNumber = 0;

                   var pageOfResults = await Task.Run(() =>
                   {
                       using (var dbContext = new AlibaRamyEntities())
                       {
                           // استدعاء الإجراء المخزن باستخدام Entity Framework وربط النتيجة بـ InventoryViewModel
                           var result = dbContext.Database.SqlQuery<InventoryViewModel>(
                               "EXEC dbo.SearchInventory @selectedItemsName, @selectedCatg, @quantity, @selectedcompare, @selectDate",
                               new SqlParameter("@selectedItemsName", (object)selectedItemsName ?? DBNull.Value),
                               new SqlParameter("@selectedCatg", (object)selectedCatg ?? DBNull.Value),
                               new SqlParameter("@quantity", quantity),
                               new SqlParameter("@selectedcompare", (object)selectedcompare ?? DBNull.Value),
                               new SqlParameter("@selectDate", selectDate)
                           ).ToList();

                           return result;
                       }
                   });

                   results.AddRange(pageOfResults);

                   this.Invoke((MethodInvoker)delegate
                   {
                       if (results.Count == 0)
                       {
                           gridControl1.DataSource = null;
                           MessageBox.Show("لا توجد نتائج للمعلومات المختارة");
                       }
                       else
                       {
                           gridControl1.DataSource = results;
                       }
                   });
               }
               catch (Exception ex)
               {
                   this.Invoke((MethodInvoker)delegate
                   {
                       MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
                   });
               }
               finally
               {
                   loading.Visible = false;
                   GC.Collect();
                   GC.WaitForPendingFinalizers();
               }
           }*/
        public class InventoryViewModel
        {
            public int ItemsId { get; set; }
            public string ItemName { get; set; }
            public string GroupName { get; set; }
            public string ItemQuart { get; set; }
            public decimal TotalQuantity { get; set; }
        }


        private void LoadCatg()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                    // الحصول على قائمة التصنيفات من قاعدة البيانات
                    var categories = dbbb.TB_groups.Select(x => x.groups_name).AsQueryable().ToList();

                    // إضافة عنصر فارغ في البداية
                    categories.Insert(0, "كل الأصناف");

                    Combo_Catg.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
          
                MessageBox.Show(" حدث خطأ أثناء تحميل الاصناف: " + ex.Message);
            }
        }

        private void FRM_Dis_store_Activated(object sender, EventArgs e)
        {
            LoadCatg();  
        }
       /* private void GetItemsName()
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
        }*/
        private void Txt_items_name_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Txt_Num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else if (Txt_Num.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Btn_details_Click(object sender, EventArgs e)
        {
            
            var Result = MessageBox.Show("هل تريد الطباعة؟", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //
            if (Result == DialogResult.Yes)
            {
                try
                {
                    var gridView = gridControl1.MainView as GridView;

                    if (gridView != null)
                    {
                        // إخفاء العمود
                        var columnToHide = gridView.Columns["itemsId"]; // استبدل "اسم_العمود" باسم العمود الذي تريد إخفاءه
                        if (columnToHide != null)
                        {
                            columnToHide.Visible = false;
                        }
                        // عرض عنصر التحميل
                        Cursor.Current = Cursors.WaitCursor;

                        // إنشاء كائن من PrintingSystem
                        var printingSystem = new DevExpress.XtraPrinting.PrintingSystem();

                        // إنشاء كائن من PrintableComponentLink وتعيين GridControl كمكون للطباعة
                        var printableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink(printingSystem)
                        {
                            Component = gridControl1
                        };

                        // تعيين الهوامش
                        printableComponentLink.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);

                        // تعيين اتجاه الصفحة (عمودي أو أفقي)
                        //  printableComponentLink.Landscape = true; // True: أفقي، False: عمودي

                        // إنشاء الوثيقة
                        printableComponentLink.CreateDocument();

                        // إعداد نافذة معاينة الطباعة
                        var printPreviewForm = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx
                        {
                            PrintingSystem = printingSystem
                        };

                        // ضبط إعدادات الطباعة في نافذة المعاينة
                        printPreviewForm.PrintingSystem.PageSettings.Landscape = false; // True: أفقي، False: عمودي
                        printPreviewForm.PrintingSystem.PageSettings.PaperKind = (DevExpress.Drawing.Printing.DXPaperKind)System.Drawing.Printing.PaperKind.A4; // تحديد نوع الورق

                        // عرض نافذة معاينة الطباعة
                        printPreviewForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show( "لا توجد بيانات");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    // التعامل مع الأخطاء
                    MessageBox.Show("خطأ في الطباعة: " + ex.Message);
                }
                finally
                {
                    // إظهار العمود مرة أخرى
                    var gridView = gridControl1.MainView as GridView;
                    if (gridView != null)
                    {
                        var columnToShow = gridView.Columns["itemsId"]; // استبدل "اسم_العمود" باسم العمود الذي تريد إظهاره
                        if (columnToShow != null)
                        {
                            columnToShow.Visible = true;
                        }
                    }
                    // إخفاء عنصر التحميل
                    Cursor.Current = Cursors.Default;

                }
            }
        }

        private void Btn_wasel_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridControl1.MainView as GridView;

                if (gridView != null)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    // إنشاء نافذة حوار حفظ الملف
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        string d = DateTime.Now.ToString("yyyy-MM-dd");
                        // إعداد خصائص نافذة الحوار
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = ("كشف المخزن" + "-" + d); // الاسم الافتراضي للملف

                        // عرض نافذة الحوار
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            // إخفاء العمود
                            var columnToHide = gridView.Columns["itemsId"]; // استبدل "اسم_العمود" باسم العمود الذي تريد إخفاءه
                            if (columnToHide != null)
                            {
                                columnToHide.Visible = false;
                            }

                            // الحصول على مسار الملف من النافذة
                            string filePath = saveFileDialog.FileName;

                            // استخدام ExportToXlsx لتصدير البيانات إلى الملف المحدد
                            gridControl1.ExportToXlsx(filePath);

                            // فتح ملف Excel باستخدام EPPlus لتعديل التنسيق
                            FileInfo fileInfo = new FileInfo(filePath);
                            using (var package = new ExcelPackage(fileInfo))
                            {
                                var worksheet = package.Workbook.Worksheets[0]; // الحصول على الورقة الأولى في الملف

                                // تحديد رأس الأعمدة (الصف الأول)
                                var headerRow = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];

                                // تغيير لون خلفية رأس الأعمدة إلى اللون الأصفر
                                headerRow.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                headerRow.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);

                                // توسيط النصوص في رأس الأعمدة
                                headerRow.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                headerRow.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                // توسيط النصوص في جميع الخلايا
                                var dataRange = worksheet.Cells[worksheet.Dimension.Address];
                                dataRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                dataRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                // توسيع عرض الأعمدة تلقائيًا
                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                                // حفظ التعديلات إلى الملف
                                package.Save();
                            }

                            // إخطار المستخدم بنجاح العملية
                            MessageBox.Show("تم تصدير البيانات إلى Excel", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // التعامل مع أي استثناء يحدث أثناء عملية التصدير
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات إلى Excel: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // إظهار العمود مرة أخرى
                var gridView = gridControl1.MainView as GridView;
                if (gridView != null)
                {
                    var columnToShow = gridView.Columns["itemsId"]; // استبدل "اسم_العمود" باسم العمود الذي تريد إظهاره
                    if (columnToShow != null)
                    {
                        columnToShow.Visible = true;
                    }
                }
                

            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Btn_group1_Click(object sender, EventArgs e)
        {
            Ramy.Visible = true;
            txtSearch1.Focus();
            txtSearch1.Select();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {

            if (clbListNames1.CheckedItems.Count > 0)
            {

                //      Txt_cust.Text = "";
                Btn_group1.BackColor = Color.Red;
                Btn_group1.Text = "الغاء اختيار المواد";

              //  Btn_group1.Refresh();
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
                Btn_group1.Text = "اختيار مواد";
                Btn_group1.BackColor = Color.White;
            }
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

                var allItems = dbContext.TB_items
                    .AsNoTracking()
                    .Where(x => x.items_id > 0)
                    .Select(p => p.items_name)
                    .Distinct()
                    .ToList();


                var matchedItems = allItems.Where(name => name.ToLower().Contains(searchText)).ToList();
                var nonMatchedItems = allItems.Where(name => !name.ToLower().Contains(searchText)).ToList();


                clbListNames1.Items.Clear();


                foreach (var name in matchedItems)
                {
                    clbListNames1.Items.Add(name, currentCheckedItems.ContainsKey(name.ToLower()) && currentCheckedItems[name.ToLower()]);
                }

               
                foreach (var name in nonMatchedItems)
                {
                    clbListNames1.Items.Add(name, currentCheckedItems.ContainsKey(name.ToLower()) && currentCheckedItems[name.ToLower()]);
                }
            }
        }
    }
}