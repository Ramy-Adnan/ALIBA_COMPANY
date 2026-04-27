using ALIBA_COMPANY.classes;
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

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_details : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        private ALIBA_COMPANY.AlibaRamyEntities dbContext;
        public int ID_Wasel;
        public string items;
        public string units;
        public string code;
        public DateTime date;
        public string cust;
        public string driver;
        public string Wus;
        public string Total;
        public int state;
        public string Crus;
        public FRM_details()
        {
            InitializeComponent();
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            LoadDataInBackground();
          //  gridView1.CustomColumnDisplayText += OnCustomColumnDisplayText;
        }
       

        private List<DataRecord> dataList;

        private async void LoadDataInBackground()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;

                dataList = await Task.Run(() =>
                {
                    var data = dbContext.TB_det
                        .Where(x => x.list_id == ID_Wasel).AsNoTracking()
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
                });

               
                this.Invoke((MethodInvoker)delegate
                {
                    gridControl1.DataSource = dataList;
                });

                loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }

        /* private string GetItemNameFromTBItems(int id)
         {
             using (var context = new AlibaRamyEntities())
             {

                 var item = context.TB_items.FirstOrDefault(i => i.items_id == id);

                 if (item != null)
                 {
                     return item.items_name;
                 }
             }

             return "لا يوجد اسم";
         }

         private void OnCustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
         {
             GridView view = sender as GridView;
             if (e.Column.FieldName == "rara")
             {
                 int rowIndex = e.ListSourceRowIndex;
                 int id = -1;

                 object value = view.GetRowCellValue(rowIndex, "items_id");
                 if (value != null && value != DBNull.Value && !(value is DevExpress.Data.NotLoadedObject))
                 {
                     // استخراج الـ ID من العمود "ItemsID"
                     if (view.IsDataRow(rowIndex))
                     {
                         id = Convert.ToInt32(value);
                     }
                 }
                 // جلب الاسم من جدول "TB_items" باستخدام الـ ID
                 string itemName = GetItemNameFromTBItems(id);

                 e.DisplayText = itemName;
             }
         }
 */
        private void FRM_details_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            gridControl1.DataSource = null;

            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            if (gridControl1 != null)
            {
                gridControl1.Dispose();
                gridControl1 = null;
            }
            CleanUpControls(this);
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
        private void FRM_details_Load(object sender, EventArgs e)
        {
            if (state == 1)
            {
                lbl_wasel.Text = code;
                lbl_cust.Text = cust;
                dateTimePicker1.Value = date;
                lbl_driver.Text = driver;
                lbl_items.Text = items;
                lbl_units.Text = units;
            }
            else
            {
                lbl_cust.Visible = false;
                lbl_driver.Visible = false;
                lbl_items.Visible = false;
                lbl_units.Visible = false;
                lbl_wasel.Visible = false;
                Btn_print.Visible = false;
                Btn_excel.Visible = false;
                dateTimePicker1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label9.Visible = false;
                
                    
            }
        }
      
        private void Btn_print_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد طباعة وصل ", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                try
                {
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

                    // تعيين قيم المعلمات للتقرير
                    SetReportParameters(report, parameters);
                    // عرض معاينة التقرير
                    report.ShowPreview();


                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " طباعة وصل بيع " + driver;
                    note.AddNote(Note, notifications, "طباعة", 6);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ في الاتصال - Btn_print_Click: {ex.Message}");
                }
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
        private void ExportToExcel()
        {
            try
            {
               
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    
                    var worksheet = package.Workbook.Worksheets.Add("وصل بيع" + "-" + cust + "-" + driver + "-" + code);

                   
                    var headers = new[] { "الوصل", "الاسم", "العدد", "السعر بالدولار", "المبلغ بالدولار", "السعر بالدينار", "المبلغ بالدينار" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                    }

                    // إضافة البيانات
                    int row = 2;
                    foreach (var record in dataList)
                    {
                        worksheet.Cells[row, 1].Value = record.Code;
                        worksheet.Cells[row, 2].Value = record.Name;
                        worksheet.Cells[row, 3].Value = record.Num;
                        worksheet.Cells[row, 4].Value = record.CostUsd;
                        worksheet.Cells[row, 5].Value = record.TcostUsd;
                        worksheet.Cells[row, 6].Value = record.Costiq;
                        worksheet.Cells[row, 7].Value = record.Tcostiq;
                        row++;
                    }

                    // تنسيق رأس الأعمدة
                    using (var headerRange = worksheet.Cells[1, 1, 1, headers.Length])
                    {
                        headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    // إضافة حدود لجميع الخلايا
                    using (var allCellsRange = worksheet.Cells[1, 1, row - 1, headers.Length])
                    {
                        allCellsRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        allCellsRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        allCellsRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        allCellsRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }

                    // ضبط حجم الأعمدة تلقائيًا
                    worksheet.Cells.AutoFitColumns();

                    // إعداد نافذة حفظ الملف
                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Workbook|*.xlsx",
                        Title = "Save an Excel File",
                        FileName = "وصل بيع"+"-"+ cust +"-"+ driver+"-"+ code,
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(fileInfo);
                        MessageBox.Show("تم التصدير بنجاح!");

                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " تصدير وصل بيع " + driver;
                        note.AddNote(Note, notifications, "تصدير", 7);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات: " + ex.Message);
            }
        }
       
        private void Btn_excel_Click(object sender, EventArgs e)
        {
            if (dataList == null || !dataList.Any())
            {
                MessageBox.Show("لا توجد بيانات لتصديرها.");
                return;
            }

            ExportToExcel();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}