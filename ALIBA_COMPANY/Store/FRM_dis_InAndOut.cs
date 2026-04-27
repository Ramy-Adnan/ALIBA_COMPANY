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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_dis_InAndOut : DevExpress.XtraEditors.XtraForm
    {
        public FRM_dis_InAndOut()
        {
            InitializeComponent();
            Txt_Num.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_NumItem.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
            Txt_NumPacies.KeyPress += (sender, e) => UIHelper.HandleTextBoxKeyPress(sender, e, 10);
        }

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {
                // عرض رمز المؤشر على انتظار التحميل
                Cursor.Current = Cursors.WaitCursor;
                loading.Visible = true;

                // استخراج القيم المحددة من عناصر واجهة المستخدم
                string selectedItemsName = Txt_items_name.Text.Trim();
                string selectedEmplo = Txt_emplo.Text.Trim();
                string selectedCar = Txt_car.Text.Trim();
                string selectedBranch = Combo_branch.SelectedItem?.ToString()?.Trim();
                string selectedType = Combo_type.SelectedItem?.ToString()?.Trim();
                string selectedStatus = Combo_status.SelectedItem?.ToString()?.Trim();

                // تحويل النصوص إلى أرقام عشرية
                decimal wasel = decimal.TryParse(Txt_Num.Text, out decimal waselValue) ? waselValue : 0;
                decimal NumItem = decimal.TryParse(Txt_NumItem.Text, out decimal numItemValue) ? numItemValue : 0;
                decimal NumPacies = decimal.TryParse(Txt_NumPacies.Text, out decimal numPaciesValue) ? numPaciesValue : 0;

                // تحديد تواريخ البحث
                DateTime FromDate = dateTimePicker1.Value.Date;
                DateTime ToDate = dateTimePicker2.Value.Date;

                List<dynamic> results = new List<dynamic>(); // قائمة لتخزين النتائج

                int pageSize = 9000000; // حجم كل دفعة من البيانات
                int pageNumber = 0; // رقم الصفحة الحالية للنتائج

                var pageOfResults = await Task.Run(() =>
                {
                using (var dbContext = new AlibaRamyEntities())
                {
                    var query = (from inventory in dbContext.TB_order.AsNoTracking()
                                
                                 join action in dbContext.TB_action.AsNoTracking() on inventory.action_id equals action.action_id
                                 join user in dbContext.TB_users.AsNoTracking() on inventory.user_id equals user.user_id
                               
                                 join branch in dbContext.TB_branchs.AsNoTracking() on inventory.br_id equals branch.br_id
                                 where inventory.order_date >= FromDate && inventory.order_date <= ToDate
                                 select new
                                 {
                                  
                                         inventory.order_code,
                                         inventory.order_date,
                                         inventory.order_id,
                                     // item.items_name,
                                         action.action_name,
                                         branch.br_code,
                                         branch.br_name,
                                         inventory.order_nots,
                                         inventory.order_status,
                                         inventory.order_items,
                                         inventory.order_unit,
                                         inventory.car_name,
                                         inventory.driver_name,
                                         user.user_name
                                     });

                        
                        if (!string.IsNullOrEmpty(selectedBranch))
                        {
                            query = query.Where(x => x.br_code == selectedBranch);
                        }
                        if (!string.IsNullOrEmpty(selectedType))
                        {
                            query = query.Where(x => x.action_name == selectedType);
                        }
                        if (!string.IsNullOrEmpty(selectedStatus))
                        {
                            query = query.Where(x => x.order_status == selectedStatus);
                        }
                        if (!string.IsNullOrEmpty(selectedItemsName))
                        {
                            query = query.Where(x => dbContext.TB_str.Any(d => d.order_id == x.order_id && d.TB_items.items_name==selectedItemsName));
                        }
                        if (!string.IsNullOrEmpty(selectedEmplo))
                        {
                            query = query.Where(x => x.driver_name==selectedEmplo);
                        }
                        if (!string.IsNullOrEmpty(selectedCar))
                        {
                            query = query.Where(x => x.car_name==selectedCar);
                        }
                        if (NumItem != 0)
                        {
                            query = query.Where(x => x.order_items == NumItem);
                        }
                        if (NumPacies != 0)
                        {
                            query = query.Where(x => x.order_unit == NumPacies);
                        }
                        if (wasel != 0)
                        {
                            query = query.Where(x => x.order_code == wasel);
                        }

                      

                        return query.OrderBy(x => x.order_id)
                                          .Skip(pageNumber * pageSize)
                                          .Take(pageSize)
                                           .ToList()
                                          .Select(x => new
                                          {
                                              x.order_code,
                                              x.order_date,
                                              x.order_id,
                                              //  x.items_name,
                                              x.action_name,
                                              x.br_code,
                                              x.br_name,
                                              x.order_nots,
                                              x.order_status,
                                              x.order_items,
                                              x.order_unit,
                                              x.car_name,
                                              x.driver_name,
                                              x.user_name,
                                              WaselNum = $"{x.br_code}-{x.order_code.ToString().PadLeft(4, '0')}"
                                          })
                                          .ToList();
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
                    MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message);
                });
            }
            finally
            {
                // إعادة ضبط حالة المؤشر والعناصر البصرية الأخرى
                loading.Visible = false;
                Cursor.Current = Cursors.Default;

                // تنظيف الموارد غير الضرورية
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void LoadType()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var Branch = dbbb.TB_action.Where(x => x.action_id ==1 || x.action_id == 2).Select(x => x.action_name).ToList();
                    Branch.Insert(0, "");
                    Combo_type.DataSource = Branch;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("LoadType حدث خطأ أثناء تحميل النوع: " + ex.Message);
            }
        }
        private void LoadBranch()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var Branch = dbbb.TB_branchs.Select(x => x.br_code).AsQueryable().ToList();
                    Branch.Insert(0, "");
                    Combo_branch.DataSource = Branch;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("LoadBranch حدث خطأ أثناء تحميل الفروع: " + ex.Message);
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

        private void gridControl1_Load(object sender, EventArgs e)
        {
            LoadBranch();
            LoadType();
        }

        private void FRM_dis_InAndOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            // التأكد من إغلاق الاتصال بقاعدة البيانات والتخلص من البيانات بشكل صحيح
            try
            {
                gridControl1.DataSource = null;
                using (var db = new AlibaRamyEntities())
                {
                    if (db != null)
                    {
                        db.Dispose();
                       
                    }
                }
                if (gridControl1 != null)
                {
                    gridControl1.Dispose();
                    gridControl1 = null;
                }
               
                CleanUpControls(this);

               
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تخلص البرنامج من البيانات: " + ex.Message);
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
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private List<DataInside> dataDetails;

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
                        var data = db.TB_str
                           .Where(x => x.order_id == id && (x.action_id == 2|| x.action_id == 1)).AsNoTracking()
                           .Select(x => new DataInside
                           {

                               Name = x.TB_items.items_name,
                               Code = x.TB_items.items_code,
                               NameEn =  x.TB_items.items_enname,
                               Num = Math.Abs(x.str_num ?? 0),
                               Form = x.TB_items.items_form,
                               Price = x.TB_items.Usd_upper,
                               LowerPrice = x.TB_items.Usd_lower,
                               Ex = x.TB_items.exchang,
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
        Note note;
        private async void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string Id = GetFocusedRowCellValue("order_id");
                string Code = GetFocusedRowCellValue("WaselNum");
                DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("order_date")).Date;
                string Car = GetFocusedRowCellValue("car_name");
                string City = GetFocusedRowCellValue("br_name");
                string Driver = GetFocusedRowCellValue("driver_name");
                
                string Items = GetFocusedRowCellValue("order_items");
                string Units = GetFocusedRowCellValue("order_unit");
                string Action = GetFocusedRowCellValue("action_name");

                if (int.TryParse(Id, out int wasell) && wasell != 0)
                {
                    DialogResult result = MessageBox.Show("هل تريد طباعة وصل ؟", "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                          await LoadDetailsAsync(wasell);
                        XtraReport_inside report = new XtraReport_inside
                        {

                            // تعيين dataList كمصدر بيانات للتقرير

                            DataSource = dataDetails
                        };
                        var parameters = new Dictionary<string, object>
                    {
                        { "action", Action },
                        { "Code", Code },
                        { "Date", Date },
                        { "City", City },
                        { "Driver", Driver },
                        { "Car", Car },
                        { "Items", Items },
                        { "Units", Units }
                    };

                        SetReportParameters(report, parameters);
                        report.ShowPreview();

                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = "  طباعة وصل نقل  "+ Action + "" + Code;
                        note.AddNote(Note, notifications, "طباعة", 6);
                    }
                    else
                    {
                        MessageBox.Show("اختر صف", "لا يمكن اجراء العملية");
                    }
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
        private void SetReportParameters(XtraReport_inside report, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {

                if (report.Parameters[param.Key] != null)
                {
                    report.Parameters[param.Key].Value = param.Value;
                }
            }
        }

        private async void Btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                string Id = GetFocusedRowCellValue("order_id");
                string w = GetFocusedRowCellValue("WaselNum");
                string Action = GetFocusedRowCellValue("action_name");
                if (int.TryParse(Id, out int wasell) && wasell != 0)
                {

                    await LoadDetailsAsync(wasell);


                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = $"نقل المواد {DateTime.Now:yyyy-MM-dd}{w}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);

                        using (var package = new ExcelPackage(fileInfo))
                        {
                            var worksheet = package.Workbook.Worksheets.Add("وصل نقل-" + w);


                            worksheet.Cells[1, 1].Value = "اسم المادة";
                            worksheet.Cells[1, 2].Value = "الكود";
                            worksheet.Cells[1, 3].Value = "الاسم التجاري";
                            worksheet.Cells[1, 4].Value = "العدد";
                            worksheet.Cells[1, 5].Value = "التجزئه";
                            worksheet.Cells[1, 6].Value = "اعلى سعر";
                            worksheet.Cells[1, 7].Value = "اقل سعر";
                            worksheet.Cells[1, 8].Value = "التصريف بعد التقريب";


                            using (var headerRange = worksheet.Cells[1, 1, 1, 8])
                            {
                                headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                headerRange.Style.Font.Bold = true;
                            }


                            for (int i = 0; i < dataDetails.Count; i++)
                            {
                                worksheet.Cells[i + 2, 1].Value = dataDetails[i].Name;
                                worksheet.Cells[i + 2, 2].Value = dataDetails[i].Code;
                                worksheet.Cells[i + 2, 3].Value = dataDetails[i].NameEn;
                                worksheet.Cells[i + 2, 4].Value = dataDetails[i].Num;
                                worksheet.Cells[i + 2, 5].Value = dataDetails[i].Form;
                                worksheet.Cells[i + 2, 6].Value = dataDetails[i].Price;
                                worksheet.Cells[i + 2, 7].Value = dataDetails[i].LowerPrice;
                                worksheet.Cells[i + 2, 8].Value = dataDetails[i].Ex;
                            }


                            using (var allCells = worksheet.Cells[1, 1, dataDetails.Count + 1, 8])
                            {
                                allCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                allCells.Style.Font.Size = 14;
                                allCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                allCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                allCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                            package.Save();
                            MessageBox.Show("تم التصدير بنجاح");

                            note = new Note();
                            pages.Notifications notifications = new pages.Notifications();
                            var Note = " تصدير وصل نقل" + Action + "" + w;
                            note.AddNote(Note, notifications, "تصدير", 7);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("اختر صف");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات: " + ex.Message);
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
           
            this.Close();
            this.Dispose();
        }
    }
}