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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_incentive : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        int emplo_tr;
        public FRM_incentive()
        {
            InitializeComponent();
        }
        private List<DataIncentive> dataDetails;

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {
                /*System.Globalization.CultureInfo usCulture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = usCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = usCulture;*/
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                SystemUtilities.SetProcessPriority();
               
                loading.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
               
                
                string selectedDriver = null;
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dateTimePicker2.Value.Date;
                this.Invoke((MethodInvoker)delegate
                {
                    selectedDriver = Combo_emplo.SelectedItem?.ToString();
                    fromDate = dateTimePicker1.Value.Date;
                    toDate = dateTimePicker2.Value.Date;
                });
               
                dataDetails = await Task.Run(() =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        var query = db.TB_travel.Where(x =>
                                               x.user_id2 != null
                                            && x.tr_date >= fromDate
                                            && x.tr_date <= toDate).AsQueryable();

                        if (!string.IsNullOrEmpty(selectedDriver)&& selectedDriver !="الكل")
                        {
                            query = query.Where(x => x.TB_emplo.emplo_name == selectedDriver);
                        }
                        if (Check.Checked==false)
                        {
                            var result1 = query
                                       .AsNoTracking()
                                       .Select(x => new DataIncentive
                                       {
                                           Id = x.tr_id,
                                           Emplo = x.TB_emplo.emplo_name,
                                           Date = (DateTime)x.tr_date,

                                           Emony = (x.tr_rate == 0) ? 0 : ((x.tr_amount * (x.tr_rate / 10000m)) * 0.9m),

                                           Mmony = (x.tr_rate == 0) ? 0 : ((x.tr_amount * (x.tr_rate / 10000m)) * 0.1m),

                                           Sold = x.tr_amount,
                                           Units = x.tr_p_un,

                                       })
                                       .ToList();
                            return result1;
                        }
                        else
                        {
                            var result2 = query
                                       .AsNoTracking()
                                       .GroupBy(x => x.TB_emplo.emplo_name)
                                       .Select(g => new DataIncentive
                                       {
                                           Id = g.Max(x => x.tr_id),
                                           Emplo =g.Key,
                                           Date = (DateTime)g.Max(x => x.tr_date),

                                           Emony = g.Sum(x=>(x.tr_rate == 0) ? 0 : ((x.tr_amount * (x.tr_rate / 10000m)) * 0.9m)),

                                           Mmony = g.Sum(x => (x.tr_rate == 0) ? 0 : ((x.tr_amount * (x.tr_rate / 10000m)) * 0.1m)),

                                           Sold = g.Sum(x=>x.tr_amount),
                                           Units =g.Sum(x =>x.tr_p_un),

                                       })
                                       .ToList();
                            return result2;
                        }

                    }
                   
                });
                this.Invoke((MethodInvoker)delegate
                {
                    if (dataDetails.Count == 0 )
                    {
                        gridControl1.DataSource = null;
                        MessageBox.Show(" لا توجد نتائج للمعلومات المختاره");
                    }
                    else
                    {
                        gridControl1.DataSource = dataDetails;
                        lbl_count.Text = gridView1.RowCount.ToString();

                        decimal sum1 = 0;
                        decimal sum2 = 0;
                        decimal sum3 = 0;
                        decimal sum4 = 0;
                        decimal sum5 = 0;

                        for (int i = 0; i < gridView1.DataRowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Emony") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "Emony").ToString(), out decimal value1))
                            {
                                sum1 += value1;
                            }

                            if (gridView1.GetRowCellValue(i, "Mmony") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "Mmony").ToString(), out decimal value2))
                            {
                                sum2 += value2;
                            }
                            if (gridView1.GetRowCellValue(i, "Sold") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "Sold").ToString(), out decimal value3))
                            {
                                sum3 += value3;
                            }
                            if (gridView1.GetRowCellValue(i, "Units") != null && decimal.TryParse(gridView1.GetRowCellValue(i, "Units").ToString(), out decimal value4))
                            {
                                sum4 += value4;
                            }
                        }
                        sum5 = sum1 + sum2;
                        CultureInfo usdCulture = new CultureInfo("en-US");
                        usdCulture.NumberFormat.CurrencySymbol = "$";
                        // Customize the format to place the currency symbol after the number
                        // dinarCulture.NumberFormat.CurrencyPositivePattern = 1;
                        lbl_emplo.Text = sum1.ToString("C2", usdCulture);
                        lbl_mang.Text = sum2.ToString("C2", usdCulture);
                        lbl_sum.Text = sum5.ToString("C2", usdCulture);
                        lbl_sold.Text = sum3.ToString("C2", usdCulture);
                        lbl_unit.Text = sum4.ToString("N0");
                    }

                });

               
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"حدث خطأ : {ex.Message}");
            }
            finally
            {
               
                loading.Visible = false;
                Cursor.Current = Cursors.Default;
            }
        }
        private void LoadDrivers()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var ff = db.TB_emplo.Where(x => x.emplo_dis == true&&x.emplo_activity==true).Select(x => x.emplo_name).AsQueryable().ToList();
                    ff.Insert(0,"الكل");
                    Combo_emplo.DataSource = ff;
                }
            }
            catch { }
        }
        private void Set_ID_driver()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {

                    var Iddd = db.TB_travel
                    .Where(x => x.TB_emplo.emplo_name == Combo_emplo.SelectedItem.ToString() && x.user_id2 != null)
                    .Select(x => x.emplo_id)
                    .FirstOrDefault();
                    if (Iddd != 0)
                    {
                        emplo_tr = (int)Iddd;
                    }
                
                    else
                    {
                        emplo_tr = 0;
                    }

                }
            }
            catch { }
        }

        private void Combo_emplo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_driver();
        }

        private void FRM_incentive_Load(object sender, EventArgs e)
        {
            LoadDrivers();
          
        }

        private void Btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                if (dataDetails == null || dataDetails.Count == 0)
                {
                    MessageBox.Show("لاتوجد بيانات");
                    return;
                }
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FilterIndex = 1,
                    FileName = " الحوافز من " + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + " الى " + dateTimePicker2.Value.ToString("yyyy-MM-dd"),
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(saveFileDialog.FileName);
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                      
                        var worksheet = package.Workbook.Worksheets.Add(" الحوافز من " + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + " الى " + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd"));
                        worksheet.View.RightToLeft = true;

                      
                        var reportTitle = "الحوافز من " + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + " الى " + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
                        worksheet.Cells[1, 1].Value = reportTitle;

                        
                        worksheet.Cells[1, 1, 1, 7].Merge = true;

                       
                        worksheet.Cells[1, 1].Style.Font.Bold = true;
                        worksheet.Cells[1, 1].Style.Font.Size = 14;
                        worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                       
                        worksheet.Cells[2, 1].Value = "رقم السفره";
                        worksheet.Cells[2, 2].Value = "اسم الموزع";
                        worksheet.Cells[2, 3].Value = "التاريخ";
                        worksheet.Cells[2, 4].Value = "الحوافز";
                        worksheet.Cells[2, 5].Value = "الحوافز الادارية";
                        worksheet.Cells[2, 6].Value = "المبيع";
                        worksheet.Cells[2, 7].Value = "القطع";

                        using (var headerRange = worksheet.Cells[2, 1, 2, 7])
                        {
                            headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            headerRange.Style.Font.Bold = true;
                        }

                      
                        int row = 3;
                        foreach (var item in dataDetails)
                        {
                            worksheet.Cells[row, 1].Value = item.Id;
                            worksheet.Cells[row, 2].Value = item.Emplo;
                            worksheet.Cells[row, 3].Value = item.Date.ToString("yyyy-MM-dd");
                            worksheet.Cells[row, 4].Value = item.Emony;
                            worksheet.Cells[row, 5].Value = item.Mmony;
                            worksheet.Cells[row, 6].Value = item.Sold;
                            worksheet.Cells[row, 7].Value = item.Units;

                            row++;
                        }

                        // إضافة حدود للجدول
                        using (var allCells = worksheet.Cells[2, 1, dataDetails.Count + 2, 7])
                        {
                            allCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            allCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            allCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            allCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        // ضبط عرض الأعمدة تلقائياً
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // حفظ الملف إلى القرص
                        package.SaveAs(fileInfo);
                        MessageBox.Show("تم تصدير البيانات بنجاح");

                        // تسجيل التصدير في الملاحظات
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " تصدير الحوافز من " + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + " الى " + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
                        note.AddNote(Note, notifications, "تصدير", 7);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في الاتصال - Btn_excel_Click: {ex.Message}");
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد طباعة الحوافز ", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                try
                {
                    string fDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string tDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    XtraReport_incentive report = new XtraReport_incentive
                    {
                        DataSource = dataDetails
                    };

                   
                    var parameters = new Dictionary<string, object>
                    {
                        { "fDate", fDate },
                        { "tDate", tDate }
                    };

                    
                    SetReportParameters(report, parameters);
                    report.ShowPreview();


                   
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " طباعة الحوافز من" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + " الى " + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
                    note.AddNote(Note, notifications, "طباعة", 6);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ في الاتصال - Btn_print_Click: {ex.Message}");
                }
            }
        }
        private void SetReportParameters(XtraReport_incentive report, Dictionary<string, object> parameters)
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
    }
}