using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_dis_sold : DevExpress.XtraEditors.XtraForm
    {
        public FRM_dis_sold()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
            //gridView1.Columns.AddVisible("SequenceColumn", "تسلسل");
            gridView1.Columns["SequenceColumn"].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.Columns["SequenceColumn"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["SequenceColumn"].OptionsColumn.ReadOnly = true;

        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && e.Column.FieldName == "SequenceColumn")
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }
        public class ItemSaleResult
        {
            public int ItemsId { get; set; }
            public string ItemName { get; set; }
            public string ItemEName { get; set; }
            public string Group { get; set; }
            public decimal TotalSold { get; set; }
            public string Emplo { get; set; } // تغيير الاسم ليتوافق مع تسمية C#
        }

        private List<ItemSaleResult> dataDetails;

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {
                SystemUtilities.SetProcessPriority();
                loading.Visible = true;

               // string selectedItemsName = Txt_items_name.Text.ToString();
                List<string> selectedListNames = clbListNames1.CheckedItems.Cast<string>().ToList(); // الحصول على القوائم المختارة
                string selectedCatg = Combo_Catg.SelectedItem?.ToString();
                string selectedemplo = Combo_emplo.SelectedItem?.ToString();
                DateTime FromDate = dateTimePicker1.Value.Date;
                DateTime ToDate = dateTimePicker2.Value.Date;

                dataDetails = await Task.Run(() =>
                {
                    using (var dbContext = new AlibaRamyEntities())
                    {
                        var query = from inventory in dbContext.TB_str
                                    join item in dbContext.TB_items.AsNoTracking() on inventory.items_id equals item.items_id
                                    join travel in dbContext.TB_travel.AsNoTracking() on inventory.order_id equals travel.tr_id
                                    where inventory.str_date >= FromDate && inventory.str_date <= ToDate && inventory.action_id == 3
                                    group new { inventory, item, travel } by new
                                    {
                                        inventory.items_id,
                                        item.items_name,
                                        item.items_enname,
                                        item.TB_groups.groups_name,
                                        travel.TB_emplo.emplo_name
                                    } into g
                                    select new
                                    {
                                        g.Key.items_id,
                                        g.Key.items_name,
                                        g.Key.items_enname,
                                        g.Key.groups_name,
                                        g.Key.emplo_name,
                                        TotalSold = (decimal)g.Sum(x => Math.Abs((decimal)x.inventory.str_num) - x.inventory.str_renum)
                                    };

                        if (selectedCatg != null && selectedCatg != "كل الأصناف")
                        {
                            query = query.Where(x => x.groups_name == selectedCatg);
                        }

                       /* if (!string.IsNullOrEmpty(selectedItemsName))
                        {
                            query = query.Where(x => x.items_name == selectedItemsName);
                        }*/
                        if (selectedListNames.Any())
                        {
                            query = query.Where(x => selectedListNames.Contains(x.items_name));
                        }
                        if (!string.IsNullOrEmpty(selectedemplo) && selectedemplo != "كل الموزعيين")
                        {
                            query = query.Where(x => x.emplo_name == selectedemplo);
                        }

                        var results = !string.IsNullOrEmpty(selectedemplo) && selectedemplo != "كل الموزعيين"
                            ? query.OrderBy(x => x.items_id)
                                    .Skip(0 * 100000000) // Assuming pageNumber = 0
                                    .Take(100000000)
                                    .ToList()
                                    .Select(x => new ItemSaleResult
                                    {
                                        ItemsId = x.items_id,
                                        ItemName = x.items_name,
                                        ItemEName = x.items_enname,
                                        Group = x.groups_name,
                                        TotalSold = x.TotalSold,
                                        Emplo = x.emplo_name
                                    }).ToList()
                            : query.GroupBy(x => new
                            {
                                x.items_id,
                                x.items_name,
                                x.items_enname,
                                x.groups_name
                            })
                                .Select(g => new
                                {
                                    g.Key.items_id,
                                    g.Key.items_name,
                                    g.Key.items_enname,
                                    g.Key.groups_name,
                                    TotalSold = g.Sum(x => x.TotalSold),
                                    emplo_name = "كل الموزعيين" // Placeholder value
                            })
                                .OrderBy(x => x.items_id)
                                .Skip(0 * 100000000) // Assuming pageNumber = 0
                                .Take(100000000)
                                .ToList()
                                .Select(x => new ItemSaleResult
                                {
                                    ItemsId = x.items_id,
                                    ItemName = x.items_name,
                                    ItemEName = x.items_enname,
                                    Group = x.groups_name,
                                    TotalSold = x.TotalSold,
                                    Emplo = x.emplo_name
                                }).ToList();

                        return results;
                    }

                       
                    
                });

                this.Invoke((MethodInvoker)delegate
                {
                    if (dataDetails == null || !dataDetails.Any())
                    {
                        gridControl1.DataSource = null;
                        MessageBox.Show("لا توجد نتائج للمعلومات المختاره");
                    }
                    else
                    {
                        gridControl1.DataSource = dataDetails;
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ في تحديد المواد الراجعة: {ex.Message}");
            }
            finally
            {
                loading.Visible = false;
                Cursor.Current = Cursors.Default;
            }
        }



        private void LoadCatg()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                   
                    var categories = dbbb.TB_groups.Select(x => x.groups_name).AsQueryable().ToList();
                    categories.Insert(0, "كل الأصناف");
                    Combo_Catg.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(" حدث خطأ أثناء تحميل الاصناف: " + ex.Message);
            }
        }
        private void LoadEmplo()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                   
                    var emloies = dbbb.TB_emplo.Where(x=>x.emplo_dis==true).Select(x => x.emplo_name).AsQueryable().ToList();
                    emloies.Insert(0, "كل الموزعيين");
                    Combo_emplo.DataSource = emloies;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء تحميل الموزعيين: " + ex.Message);
                
            }
        }

      /*  private void GetItemsName()
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
      /*  private void Txt_items_name_TextChanged(object sender, EventArgs e)
        {
            GetItemsName();
        }*/

        private void FRM_dis_sold_Load(object sender, EventArgs e)
        {
            LoadCatg();
            LoadEmplo();
        }

        private void Btn_excel_Click(object sender, EventArgs e)
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
                        saveFileDialog.FileName = ("تقرير بيع" + "-" + d); // الاسم الافتراضي للملف

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
       
        private void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
               
                DateTime fDate = Convert.ToDateTime(dateTimePicker1.Value).Date;
                DateTime tDate = Convert.ToDateTime(dateTimePicker2.Value).Date;
                string Cat = Combo_Catg.Text;
                string Driver = Combo_emplo.Text;
             //   string Items = clbListNames1.CheckedItems.ToString();
               /* if (Items=="")
                {
                    Items = "كل المواد";
                }*/
                    DialogResult result = MessageBox.Show("هل تريد طباعة وصل ؟", "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                    XtraReport_sold report = new XtraReport_sold
                    {

                        // تعيين dataList كمصدر بيانات للتقرير

                        DataSource = dataDetails
                    };
                    var parameters = new Dictionary<string, object>
                    {

                        { "fDate", fDate },
                        { "tDate", tDate },
                        { "Cat", Cat },
                        { "Driver", Driver },
                     //   { "Items", Items },
                        
                    };

                        SetReportParameters(report, parameters);
                        report.ShowPreview();
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
        private void SetReportParameters(XtraReport_sold report, Dictionary<string, object> parameters)
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
            this.Dispose();
            this.Close();
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






