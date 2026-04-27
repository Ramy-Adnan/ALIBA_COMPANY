using DevExpress.Charts.Native;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_dis_requst : DevExpress.XtraEditors.XtraForm
    {
       
        public FRM_dis_requst()
        {
            InitializeComponent();
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد الطباعة؟", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //
            if (Result == DialogResult.Yes)
            {
                try
                {
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
                    printableComponentLink.Landscape = true; // True: أفقي، False: عمودي

                    // إنشاء الوثيقة
                    printableComponentLink.CreateDocument();

                    // إعداد نافذة معاينة الطباعة
                    var printPreviewForm = new DevExpress.XtraPrinting.Preview.PrintPreviewFormEx
                    {
                        PrintingSystem = printingSystem
                    };

                    // ضبط إعدادات الطباعة في نافذة المعاينة
                    printPreviewForm.PrintingSystem.PageSettings.Landscape = true; // True: أفقي، False: عمودي
                    printPreviewForm.PrintingSystem.PageSettings.PaperKind = (DevExpress.Drawing.Printing.DXPaperKind)System.Drawing.Printing.PaperKind.A4; // تحديد نوع الورق

                    // عرض نافذة معاينة الطباعة
                    printPreviewForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    // التعامل مع الأخطاء
                    MessageBox.Show("خطأ في الطباعة: " + ex.Message);
                }
                finally
                {
                    // إخفاء عنصر التحميل
                    Cursor.Current = Cursors.Default;

                }
            }
        }

        public class PurchaseResult
        {

            public string Emplo { get; set; }
            public int? Number { get; set; }
            public DateTime? Date { get; set; }
            public DateTime? From { get; set; }
            public DateTime? To { get; set; }
            public string Type { get; set; }
            public string Agg { get; set; }
            public string User { get; set; }
            public string Note { get; set; }
          
           
        }
        private async void Serch()
        {
            try
            {
                SystemUtilities.SetProcessPriority();
                loading.Visible = true;

                string selectedtype = null;
                string selectedemplo = null;

                this.Invoke((MethodInvoker)delegate
                {
                    selectedtype = Combo_type.SelectedItem?.ToString();
                    selectedemplo = Combo_emplo.SelectedItem?.ToString();
                });

                DateTime FromDate = dateTimePicker1.Value.Date;
                DateTime ToDate = dateTimePicker2.Value.Date;
                List<PurchaseResult> results = new List<PurchaseResult>();
                int pageSize = 1000000;
                int pageNumber = 0; 

                var pageOfResults = await Task.Run(() =>
                {
                    using (var dbContext = new AlibaRamyEntities())
                    {
                        var queryForAll = from purchase in dbContext.TB_emr.AsNoTracking()
                                          where purchase.emr_date >= FromDate && purchase.emr_date <= ToDate
                                          select new
                                          {
                                              purchase.emr_date,
                                              purchase.emr_num,
                                              purchase.TB_emplo.emplo_name,
                                              purchase.emr__dateFrom,
                                              purchase.emr__dateTo,
                                              purchase.TB_users.user_FullName,
                                              purchase.emr_note,
                                              purchase.TB_action.action_name,
                                              purchase.TB_emst.emst_name,
                                          };

                        if (!string.IsNullOrEmpty(selectedemplo) && selectedemplo != "كل الموظفين")
                        {
                            queryForAll = queryForAll.Where(x => x.emplo_name == selectedemplo);
                        }

                        if (!string.IsNullOrEmpty(selectedtype) && selectedtype != "كل الطلبات")
                        {
                            queryForAll = queryForAll.Where(x => x.emst_name == selectedtype);
                        }

                        var queryResultBase = queryForAll
                            .GroupBy(x => x.emr_date)
                            .Select(g => new
                            {
                                Date = g.Key,
                                Emplo = g.Select(x => x.emplo_name).FirstOrDefault(),
                                Number = g.Select(x => x.emr_num).FirstOrDefault(),
                                From = g.Select(x => x.emr__dateFrom).FirstOrDefault(),
                                To = g.Select(x => x.emr__dateTo).FirstOrDefault(),
                                Type = g.Select(x => x.emst_name).FirstOrDefault(),
                                Agg = g.Select(x => x.action_name).FirstOrDefault(),
                                User = g.Select(x => x.user_FullName).FirstOrDefault(),
                                Note = g.Select(x => x.emr_note).FirstOrDefault(),
                            })
                            .OrderBy(x => x.Date)
                            .Skip(pageNumber * pageSize)
                            .Take(pageSize)
                            .AsEnumerable()
                            .Select(x => new PurchaseResult
                            {
                                Date = x.Date,
                                Emplo = x.Emplo,
                                Number = x.Number,
                                From = x.From,
                                To = x.To,
                                Type = x.Type,
                                Agg = x.Agg,
                                Note = x.Note,
                                User = x.User,
                            });

                        return queryResultBase.ToList();
                    }
                });

                results.AddRange(pageOfResults);

                this.Invoke((MethodInvoker)delegate
                {
                    if (results.Count == 0)
                    {
                        gridControl1.DataSource = null;
                        MessageBox.Show("لا توجد نتائج للمعلومات المختاره");
                    }
                    else
                    {
                        gridControl1.DataSource = results;

                        lbl_result.Text= gridView1.RowCount.ToString();
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("حدث خطأ في تحديد البيانات : " + ex.Message);
                });
            }
            finally
            {
                loading.Visible = false;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }


        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private  void Btn_serch_Click(object sender, EventArgs e)
        {
            Serch();
        }
        private void LoadEmplo()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var emloies = dbbb.TB_emplo.Select(x => x.emplo_name).AsNoTracking().AsQueryable().ToList();
                    emloies.Insert(0, "كل الموظفين");
                    Combo_emplo.DataSource = emloies;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء تحميل الموزعيين: " + ex.Message);

            }
        }
        private void LoadType()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var Type = dbbb.TB_emst.Select(x => x.emst_name).AsNoTracking().AsQueryable().ToList();
                    Type.Insert(0, "كل الطلبات");
                    Combo_type.DataSource = Type;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء تحميل الموزعيين: " + ex.Message);

            }
        }

        private void FRM_dis_requst_Load(object sender, EventArgs e)
        {
            LoadType();
            LoadEmplo();
        }
        private void Btn_Exel_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد التصدير؟", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //
            if (Result == DialogResult.Yes)
            {
                try
                {
                    // تعيين سياق الترخيص لمكتبة EPPlus
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // استخدم LicenseContext.Commercial إذا كنت تستخدمه تجاريًا

                    // الحصول على بيانات من GridControl (أو مصدر البيانات الآخر)
                    List<PurchaseResult> results = gridControl1.DataSource as List<PurchaseResult>;

                    if (results == null || !results.Any())
                    {
                        MessageBox.Show("لا توجد بيانات لتصديرها.");
                        return;
                    }

                    // فتح مربع حوار حفظ الملف
                    using (var saveDialog = new SaveFileDialog
                    {
                        FileName = $"تقرير النتائج-{DateTime.Now:yyyy-MM-dd___HH.mm.ss}.xlsx",
                        Filter = "Excel Files|*.xlsx",
                        Title = "حفظ التقرير كملف Excel"
                    })
                    {
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor; // تعيين شكل المؤشر إلى الانتظار
                            FileInfo fileInfo = new FileInfo(saveDialog.FileName);

                            using (var package = new ExcelPackage(fileInfo))
                            {
                                var worksheet = package.Workbook.Worksheets.Add("تقرير النتائج");

                                // تحديد رؤوس الأعمدة باللون الأصفر
                                var headerCells = worksheet.Cells[1, 1, 1, 9];
                                headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                headerCells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                headerCells.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                                // إضافة رؤوس الأعمدة
                                worksheet.Cells[1, 1].Value = "التاريخ";
                                worksheet.Cells[1, 2].Value = "الموظف";
                                worksheet.Cells[1, 3].Value = "عدد الايام";
                                worksheet.Cells[1, 4].Value = "من";
                                worksheet.Cells[1, 5].Value = "إلى";
                                worksheet.Cells[1, 6].Value = "الطلب";
                                worksheet.Cells[1, 7].Value = "المصادقة";
                                worksheet.Cells[1, 8].Value = "المستخدم";
                                worksheet.Cells[1, 9].Value = "الملاحظات";

                                // تطبيق الحدود على خلايا رؤوس الأعمدة
                                headerCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                headerCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                headerCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                headerCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                                int row = 2;
                                foreach (var result in results)
                                {
                                    worksheet.Cells[row, 1].Value = result.Date;
                                    worksheet.Cells[row, 2].Value = result.Emplo;
                                    worksheet.Cells[row, 3].Value = result.Number;
                                    worksheet.Cells[row, 4].Value = result.From;
                                    worksheet.Cells[row, 5].Value = result.To;
                                    worksheet.Cells[row, 6].Value = result.Type;
                                    worksheet.Cells[row, 7].Value = result.Agg;
                                    worksheet.Cells[row, 8].Value = result.User;
                                    worksheet.Cells[row, 9].Value = result.Note;

                                    // تعيين تنسيق التاريخ والوقت
                                    worksheet.Cells[row, 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss"; // تنسيق التاريخ والوقت
                                    worksheet.Cells[row, 4].Style.Numberformat.Format = "yyyy-MM-dd"; // تنسيق التاريخ فقط
                                    worksheet.Cells[row, 5].Style.Numberformat.Format = "yyyy-MM-dd"; // تنسيق التاريخ فقط

                                    // تطبيق الحدود على خلايا البيانات
                                    var dataCells = worksheet.Cells[row, 1, row, 9];
                                    dataCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    dataCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    dataCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    dataCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                                    row++;
                                }

                                worksheet.Cells.AutoFitColumns();


                                // حفظ الملف إلى المسار المحدد
                                package.Save();
                            }

                            MessageBox.Show("تم تصدير البيانات بنجاح.");
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
                    Cursor.Current = Cursors.Default; // إعادة مؤشر الماوس إلى الوضع الطبيعي
                }
            }
        }
       
    }
}