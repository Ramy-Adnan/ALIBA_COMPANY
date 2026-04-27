using ALIBA_COMPANY.classes;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_dis_stock : DevExpress.XtraEditors.XtraForm
    {
        public FRM_dis_stock()
        {
            InitializeComponent();
            Txt_Wasel.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 20);
            Txt_NumItem.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 20);
            Txt_NumPacies.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 20);
        }

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {

                SystemUtilities.SetProcessPriority();
                loading.Visible = true;
                // Extract variables to reduce code duplication
                string selectedItemsName = null;
                int selectedwasel = 0;
                decimal items = 0;
                decimal units = 0;
                DateTime FromDate = dateTimePicker1.Value.Date;
                DateTime ToDate = dateTimePicker2.Value.Date;
                if (Txt_Wasel.Text == "")
                {
                    Txt_Wasel.Text = "0";
                }
                if (Txt_NumItem.Text == "")
                {
                    Txt_NumItem.Text = "0";
                }
                if (Txt_NumPacies.Text == "")
                {
                    Txt_NumPacies.Text = "0";
                }
                this.Invoke((MethodInvoker)delegate
                {
                    selectedItemsName = Txt_items_name.Text.ToString();
                    selectedwasel = int.Parse(Txt_Wasel.Text);
                    items = decimal.Parse(Txt_NumItem.Text);
                    units = decimal.Parse(Txt_NumPacies.Text);
                    FromDate = dateTimePicker1.Value.Date;
                    ToDate = dateTimePicker2.Value.Date.AddDays(1);
                });
                List<dynamic> results = new List<dynamic>();
                int pageSize = 100000000;
                int pageNumber = 0;
                var pageOfResults = await Task.Run(() =>
                {

                    using (var dbContext = new AlibaRamyEntities())
                    {
                        // Create the base query
                        var query = (from inventory in dbContext.TB_stock
                                     where inventory.sto_date <= ToDate && inventory.sto_date >= FromDate 
                                     select new
                                     {
                                         inventory.sto_id,
                                         inventory.sto_date,
                                         inventory.sto_items,
                                         inventory.sto_unit,
                                         ss=inventory.TB_users.user_FullName,
                                         inventory.sto_nots
                                     });
                        dbContext.Database.CommandTimeout = 120; // وقت الاستعلام اني اححده
                        if (!string.IsNullOrEmpty(selectedItemsName))
                        {
                            query = query.Where(x => dbContext.TB_str.Any(d => d.order_id == x.sto_id && d.action_id==11 && d.TB_items.items_name == selectedItemsName));
                           
                        }
                        if (selectedwasel != 0)
                        {
                            query = query.Where(x => x.sto_id == selectedwasel);
                        }
                        if (items != 0)
                        {
                            query = query.Where(x => x.sto_items == items);
                        }
                        if (units != 0)
                        {
                            query = query.Where(x => x.sto_unit == units);
                        }

                        return query.OrderBy(x => x.sto_id)
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
                        lbl_count.Text = gridView1.RowCount.ToString();

                        decimal sum1 = 0;
                        decimal sum2 = 0;
                       
                        for (int i = 0; i < gridView1.DataRowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "sto_items") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "sto_items").ToString(), out decimal value1))
                            {
                                sum1 += value1;
                            }

                            if (gridView1.GetRowCellValue(i, "sto_unit") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "sto_unit").ToString(), out decimal value2))
                            {
                                sum2 += value2;
                            }

                        }

                        CultureInfo usdCulture = new CultureInfo("en-US");
                        CultureInfo dinarCulture = new CultureInfo("en-US");
                       
                        usdCulture.NumberFormat.CurrencySymbol = "📦";
                        dinarCulture.NumberFormat.CurrencySymbol = "🍕";
                      
                        // Customize the format to place the currency symbol after the number
                       // usdCulture.NumberFormat.CurrencyPositivePattern = 1;
                        lbl_items.Text = sum1.ToString("C1", usdCulture);
                        lbl_pices.Text = sum2.ToString("C1", dinarCulture);
                        

                    }

                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("حدث خطأ في كشف التالف: " + ex.Message);
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
            GetItemsName();
        }

        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void ShowDetailsForm(int id, string date,string items, string unit)
        {
            FRM_detailss page = new FRM_detailss
            {
                ID_Wasel = id,
                date = date,
                items = items,
                unit = unit
            };
            page.ShowDialog();
        }
        private void Btn_detials_Click(object sender, EventArgs e)
        {
            try
            {
                string cellValue = GetFocusedRowCellValue("sto_id");
                string cellValue2 = GetFocusedRowCellValue("sto_date");
                string cellValue3 = GetFocusedRowCellValue("sto_items");
                string cellValue4 = GetFocusedRowCellValue("sto_unit");
                if (int.TryParse(cellValue, out int wasell) && wasell != 0)
                {
                    ShowDetailsForm(wasell, cellValue2, cellValue3, cellValue4);
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات, اختر صفًا لعرضه", "لا يمكن اجراء العملية");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الاتصال بقاعدة البيانات Btn_datials", "خطأ في الاتصال"+ ex);
            }
        }

        private void excel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                // إنشاء نافذة حوار حفظ الملف
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    string d = DateTime.Now.ToString("yyyy-MM-dd");
                    // إعداد خصائص نافذة الحوار
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = ("كشف التالف"+"-"+d); // الاسم الافتراضي للملف

                    // عرض نافذة الحوار
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
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
            catch (Exception ex)
            {
                // التعامل مع أي استثناء يحدث أثناء عملية التصدير
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات إلى Excel: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}