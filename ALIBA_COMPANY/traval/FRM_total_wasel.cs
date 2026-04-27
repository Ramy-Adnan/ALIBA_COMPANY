using ALIBA_COMPANY.classes;

using DevExpress.XtraEditors;
using OfficeOpenXml;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_total_wasel : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        private ALIBA_COMPANY.AlibaRamyEntities db;
        public int ID_Wasel;
        public string Name_wasel;
        public FRM_total_wasel()
        {
            InitializeComponent();
            db = new ALIBA_COMPANY.AlibaRamyEntities();
            LoadDataInBackground();
        }
        private async void LoadDataInBackground()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;

                await Task.Run(() =>
                {
                    var data = db.TB_det
                        .AsNoTracking().AsQueryable().Where(x => x.TB_list.tr_id == ID_Wasel).ToList();

                    // تحديث واجهة المستخدم بالبيانات المحملة
                    this.Invoke((MethodInvoker)delegate
                    {
                        gridControl1.DataSource = data;
                        lbl_count.Text = gridView1.RowCount.ToString();
                    });
                }); loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }


        /*    private async void Btn_wasel_Click(object sender, EventArgs e)
            {
                try
                {
                    // تحديد سياق الترخيص لمكتبة EPPlus
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    // Create and configure SaveFileDialog
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    string fileName = $" وصل موحد لسفرة {Name_wasel}_{ID_Wasel}.xlsx";
                    saveDialog.FileName = fileName;
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    saveDialog.Title = "حفظ التقرير كملف Excel";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        await Task.Run(() =>
                        {
                            using (var context = new ALIBA_COMPANY.AlibaRamyEntities())
                            {
                                var data = context.TB_det.AsNoTracking()
                                    .Where(x => x.TB_list.tr_id == ID_Wasel)
                                    .ToList();

                                // Group data by items_enname, de_costUsd, and de_costIQ
                                var groupedData = data
                                    .GroupBy(x => new { x.TB_items.items_enname, x.de_costUsd, x.de_costIQ })
                                    .Select(g => new
                                    {
                                        g.Key.items_enname,
                                        g.Key.de_costUsd,
                                        g.Key.de_costIQ,
                                        de_num = g.Sum(x => x.de_num),
                                        de_totalUsd = g.Sum(x => x.de_totalUsd),
                                        de_totalIQ = g.Sum(x => x.de_totalIQ),
                                        items_code = g.First().TB_items.items_code
                                    }).OrderBy(g => g.items_code)
                                    .ThenByDescending(g => g.de_costIQ)
                                    .ToList();

                                using (var package = new ExcelPackage())
                                {
                                    var worksheet = package.Workbook.Worksheets.Add("" + Name_wasel + "");

                                    // Add column headers
                                    worksheet.Cells[3, 1].Value = "Code";
                                    worksheet.Cells[3, 2].Value = "Item";
                                    worksheet.Cells[3, 3].Value = "Num";
                                    worksheet.Cells[3, 4].Value = "Price(USD)";
                                    worksheet.Cells[3, 5].Value = "Total(USD)";
                                    worksheet.Cells[3, 6].Value = "Price(IQD)";
                                    worksheet.Cells[3, 7].Value = "Total(IQD)";

                                    worksheet.Cells[1, 4].Value = Name_wasel;
                                    worksheet.Cells[1, 5].Value = "اسم السائق :";
                                    worksheet.Cells[2, 4].Value = ID_Wasel;
                                    worksheet.Cells[2, 5].Value = "رقم السفرة :";

                                    // Apply styles to headers
                                    worksheet.Cells[1, 4, 1, 5].Style.Font.Size = 12;
                                    worksheet.Cells[1, 4, 1, 5].Style.Font.Name = "Cairo";
                                    worksheet.Cells[1, 4, 1, 5].Style.Font.Bold = true;
                                    worksheet.Cells[1, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                    worksheet.Cells[1, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                                    worksheet.Cells[2, 4, 2, 5].Style.Font.Size = 12;
                                    worksheet.Cells[2, 4, 2, 5].Style.Font.Name = "Cairo";
                                    worksheet.Cells[2, 4, 2, 5].Style.Font.Bold = true;
                                    worksheet.Cells[2, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                    worksheet.Cells[2, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                                    worksheet.Cells[3, 1, 3, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                    worksheet.Cells[3, 1, 3, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    worksheet.Cells[3, 1, 3, 7].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    worksheet.Cells[3, 1, 3, 7].Style.Font.Size = 12;
                                    worksheet.Cells[3, 1, 3, 7].Style.Font.Name = "Arial";
                                    worksheet.Cells[3, 1, 3, 7].Style.Font.Bold = true;
                                    worksheet.Cells[3, 1, 3, 7].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    worksheet.Cells[3, 1, 3, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);

                                    for (int i = 0; i < groupedData.Count; i++)
                                    {
                                        worksheet.Cells[i + 4, 1].Value = groupedData[i].items_code;
                                        worksheet.Cells[i + 4, 2].Value = groupedData[i].items_enname;
                                        worksheet.Cells[i + 4, 3].Value = groupedData[i].de_num;
                                        worksheet.Cells[i + 4, 4].Value = groupedData[i].de_costUsd;
                                        worksheet.Cells[i + 4, 5].Value = groupedData[i].de_totalUsd;
                                        worksheet.Cells[i + 4, 6].Value = groupedData[i].de_costIQ;
                                        worksheet.Cells[i + 4, 7].Value = groupedData[i].de_totalIQ;

                                        worksheet.Cells[i + 4, 1, i + 4, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                        worksheet.Cells[i + 4, 1, i + 4, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        worksheet.Cells[i + 4, 1, i + 4, 7].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                        worksheet.Cells[i + 4, 1, i + 4, 7].Style.Font.Size = 12;
                                        worksheet.Cells[i + 4, 1, i + 4, 7].Style.Font.Name = "Arial";


                                    }

                                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                                    // Save the workbook
                                    FileInfo fileInfo = new FileInfo(saveDialog.FileName);
                                    package.SaveAs(fileInfo);
                                }
                            }
                        });

                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " تصدير وصل موحد " + ID_Wasel;
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
                    Cursor.Current = Cursors.Default;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
    */
        private async void Btn_wasel_Click(object sender, EventArgs e)
        {
            try
            {
                // تحديد سياق الترخيص لمكتبة EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Create and configure SaveFileDialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                string fileName = $"وصل موحد لسفرة {Name_wasel}_{ID_Wasel}.xlsx";
                saveDialog.FileName = fileName;
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "حفظ التقرير كملف Excel";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    await Task.Run(() =>
                    {
                        using (var context = new ALIBA_COMPANY.AlibaRamyEntities())
                        {
                            var data = context.TB_det.AsNoTracking()
                                .Where(x => x.TB_list.tr_id == ID_Wasel)
                                .ToList();

                            // Group data by items_id, de_costUsd, and de_costIQ
                            var groupedData = data
                                .GroupBy(x => new { x.TB_items.items_id, x.de_costUsd, x.de_costIQ })
                                .Select(g => new
                                {
                                    items_id = g.Key.items_id,
                                    g.First().TB_items.items_enname,
                                    g.Key.de_costUsd,
                                    g.Key.de_costIQ,
                                    de_num = g.Sum(x => x.de_num),
                                    de_totalUsd = g.Sum(x => x.de_totalUsd),
                                    de_totalIQ = g.Sum(x => x.de_totalIQ),
                                    items_code = g.First().TB_items.items_code // الاحتفاظ بـ items_code إذا كنت بحاجة إليه
                        })
                                .OrderBy(g => g.items_code)
                                .ThenByDescending(g => g.de_costIQ)
                                .ToList();

                            // إنشاء قاموس بالأسعار الفعلية باستخدام items_id
                            var itemPrices = context.TB_items.ToDictionary(item => item.items_id, item => item.Usd_upper);

                            using (var package = new ExcelPackage())
                            {
                                var worksheet = package.Workbook.Worksheets.Add(Name_wasel);

                                // Add column headers
                                worksheet.Cells[3, 1].Value = "Code";
                                worksheet.Cells[3, 2].Value = "Item";
                                worksheet.Cells[3, 3].Value = "Num";
                                worksheet.Cells[3, 4].Value = "Price(USD)";
                                worksheet.Cells[3, 5].Value = "Total(USD)";
                                worksheet.Cells[3, 6].Value = "Price(IQD)";
                                worksheet.Cells[3, 7].Value = "Total(IQD)";

                                worksheet.Cells[1, 4].Value = Name_wasel;
                                worksheet.Cells[1, 5].Value = "اسم السائق :";
                                worksheet.Cells[2, 4].Value = ID_Wasel;
                                worksheet.Cells[2, 5].Value = "رقم السفرة :";

                                // Apply styles to headers
                                worksheet.Cells[1, 4, 1, 5].Style.Font.Size = 12;
                                worksheet.Cells[1, 4, 1, 5].Style.Font.Name = "Cairo";
                                worksheet.Cells[1, 4, 1, 5].Style.Font.Bold = true;
                                worksheet.Cells[1, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                worksheet.Cells[1, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                                worksheet.Cells[2, 4, 2, 5].Style.Font.Size = 12;
                                worksheet.Cells[2, 4, 2, 5].Style.Font.Name = "Cairo";
                                worksheet.Cells[2, 4, 2, 5].Style.Font.Bold = true;
                                worksheet.Cells[2, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                worksheet.Cells[2, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                                worksheet.Cells[3, 1, 3, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[3, 1, 3, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                worksheet.Cells[3, 1, 3, 7].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                worksheet.Cells[3, 1, 3, 7].Style.Font.Size = 12;
                                worksheet.Cells[3, 1, 3, 7].Style.Font.Name = "Arial";
                                worksheet.Cells[3, 1, 3, 7].Style.Font.Bold = true;
                                worksheet.Cells[3, 1, 3, 7].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[3, 1, 3, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);

                                for (int i = 0; i < groupedData.Count; i++)
                                {
                                    worksheet.Cells[i + 4, 1].Value = groupedData[i].items_code;
                                    worksheet.Cells[i + 4, 2].Value = groupedData[i].items_enname;
                                    worksheet.Cells[i + 4, 3].Value = groupedData[i].de_num;
                                    worksheet.Cells[i + 4, 4].Value = groupedData[i].de_costUsd;
                                    worksheet.Cells[i + 4, 5].Value = groupedData[i].de_totalUsd;
                                    worksheet.Cells[i + 4, 6].Value = groupedData[i].de_costIQ;
                                    worksheet.Cells[i + 4, 7].Value = groupedData[i].de_totalIQ;

                                    // تحقق من السعر الفعلي باستخدام items_id
                                    if (itemPrices.TryGetValue(groupedData[i].items_id, out decimal? actualPrice))
                                    {
                                        // تحقق من السعر
                                        if (groupedData[i].de_costUsd == actualPrice)
                                        {
                                            // اللون الافتراضي إذا كان السعر متطابقاً
                                            worksheet.Cells[i + 4, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; // تعيين نمط التعبئة
                                            worksheet.Cells[i + 4, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                                        }
                                        else
                                        {
                                            // اللون الأحمر إذا كان السعر مختلفاً
                                            worksheet.Cells[i + 4, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; // تعيين نمط التعبئة
                                            worksheet.Cells[i + 4, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                                        }
                                    }
                                    else
                                    {
                                        // إذا لم يتم العثور على السعر، يمكن تعيين لون افتراضي أو اتخاذ إجراء آخر
                                        worksheet.Cells[i + 4, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; // تعيين نمط التعبئة
                                        worksheet.Cells[i + 4, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                                    }

                                    worksheet.Cells[i + 4, 1, i + 4, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                    worksheet.Cells[i + 4, 1, i + 4, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    worksheet.Cells[i + 4, 1, i + 4, 7].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    worksheet.Cells[i + 4, 1, i + 4, 7].Style.Font.Size = 12;
                                    worksheet.Cells[i + 4, 1, i + 4, 7].Style.Font.Name = "Arial";
                                }

                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                                // Save the workbook
                                FileInfo fileInfo = new FileInfo(saveDialog.FileName);
                                package.SaveAs(fileInfo);
                            }
                        }
                    });

                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = "تصدير وصل موحد " + ID_Wasel;
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
                Cursor.Current = Cursors.Default;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
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
        private void FRM_total_wasel_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* // Unsubscribe from events
            gridView1.RowCellStyle -= OnRowCellStyle;
            gridView1.RowStyle -= OnRowStyle;*/

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

         
            GC.Collect();
        }
    }
}
