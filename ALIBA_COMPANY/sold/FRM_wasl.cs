using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_wasl : DevExpress.XtraEditors.XtraForm
    {
        private ALIBA_COMPANY.AlibaRamyEntities dbContext;
        public int Wasell;
        public int Travel_ID;
        public FRM_wasl()
        {
            InitializeComponent();
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            
        }
        private bool isFormClosing = false;
        private object lockObject = new object();

        private async Task LoadDataInBackground()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }

                loading.Visible = true;

                List<TB_list> data = null;
                await Task.Run(() =>
                {
                    lock (lockObject)
                    {
                        if (isFormClosing)
                        {
                            return; // لا تقم بتحميل البيانات إذا كان النموذج يتم إغلاقه
                        }

                        try
                        {
                            data = dbContext.TB_list
                                .Where(x =>x.tr_id== Travel_ID && x.user_id == AddPage.Users.Idd && x.sending == false)
                                .AsNoTracking()
                                .ToList();
                        }
                        catch (Exception ex)
                        {
                            LogException(ex); // تسجيل الاستثناء إذا حدث أثناء تحميل البيانات
                            throw; // إعادة رمي الاستثناء ليتم التقاطه في الجزء الخارجي
                        }
                    }
                }).ConfigureAwait(false);

                // التحقق من الحاجة لاستخدام Invoke لتحديث واجهة المستخدم
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (!isFormClosing) // التحقق إذا كان النموذج لا يزال مفتوحًا
                        {
                            UpdateUI(data);
                        }
                    });
                }
                else
                {
                    if (!isFormClosing) // التحقق إذا كان النموذج لا يزال مفتوحًا
                    {
                        UpdateUI(data);
                    }
                }
            }
            catch (Exception ex)
            {
                // تسجيل الاستثناءات واستخدام Invoke لإظهار رسالة الخطأ
                LogException(ex);

                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (!isFormClosing) // التحقق إذا كان النموذج لا يزال مفتوحًا
                        {
                            MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
                            loading.Visible = false;
                        }
                    });
                }
                else
                {
                    if (!isFormClosing) // التحقق إذا كان النموذج لا يزال مفتوحًا
                    {
                        MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
                        loading.Visible = false;
                    }
                }
            }
        }

        private void UpdateUI(List<TB_list> data)
        {
            if (data != null && data.Any())
            {
                gridControl1.DataSource = data;
            }
            else
            {
                MessageBox.Show("لا توجد بيانات", "بيانات فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loading.Visible = false; // تأكد من إخفاء علامة التحميل بعد تحديث واجهة المستخدم
        }

        private void LogException(Exception ex)
        {
            // تسجيل الاستثناء في ملف نصي أو أي نظام تسجيل آخر
            try
            {
                System.IO.File.AppendAllText("log.txt", DateTime.Now + ": " + ex.ToString() + Environment.NewLine);
            }
            catch
            {
                // تجاهل أي استثناءات تحدث أثناء عملية التسجيل
            }
        }

        private void FRM_wasl_FormClosing(object sender, FormClosingEventArgs e)
        {
            lock (lockObject)
            {
                isFormClosing = true;

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
        }

        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void ShowDetailsForm(int id)
        {
            FRM_details page = new FRM_details();
            page.ID_Wasel = id;
            page.state = 2;
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
                    ShowErrorMessage("رجاءا اختار صف", "لا يمكن اجراء العملية");
                }
            }
            catch (NullReferenceException ex)
            {
                ShowErrorMessage("خطأ في الاتصال بقاعدة البيانات Btn_datials", "خطأ في الاتصال", ex);
            }
            catch (FormatException ex)
            {
                ShowErrorMessage("خطأ في تنسيق البيانات", "خطأ في التنسيق", ex);
            }
        }

       

        private void ShowErrorMessage(string message, string caption, Exception ex = null)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (ex != null)
            {
                // Log the exception or perform additional error handling
            }
        }
        private async void Btn_delete_Click(object sender, EventArgs e)
        {
           
            string cellValue = GetFocusedRowCellValue("list_id");
            if (int.TryParse(cellValue, out int wasell) && wasell != 0)
            {
                var rs = MessageBox.Show(" هل تريد حذف الوصل؟", "تاكييد", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                if (rs == DialogResult.Yes)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        var query = context.TB_det
                            .Where(det => det.TB_list.tr_id == Travel_ID && det.list_id == wasell)
                            .Select(det => new
                            {
                                det.de_num,
                                det.items_id
                            });

                        foreach (var detItem in query)
                        {
                            var correspondingItem = context.TB_details.FirstOrDefault(item => item.order_id == Travel_ID && item.items_id == detItem.items_id);
                            if (correspondingItem != null)
                            {
                                correspondingItem.sell_num = (correspondingItem.sell_num ?? 0) - detItem.de_num;
                                context.Entry(correspondingItem).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        foreach (var detItem2 in query)
                        {
                            var rr = context.TB_temp.FirstOrDefault(r => r.order_id == Travel_ID && r.items_id == detItem2.items_id);
                            if (rr != null)
                            {
                                rr.temp_renum = (rr.temp_renum ?? 0) - detItem2.de_num;
                                context.Entry(rr).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        var listToDelete = context.TB_list.FirstOrDefault(item => item.list_id == wasell);
                        if (listToDelete != null)
                        {
                            context.TB_list.Remove(listToDelete);
                        }

                        context.SaveChanges();
                    }

                    // إعادة تحميل البيانات وتحديث واجهة المستخدم
                    await ReloadDataAndRefreshUI();
                }
            }
            else
            {
                ShowErrorMessage("لا يوجد بيانات، اختر صفًا لعرضه", "لا يمكن إجراء العملية");
            }
        }

        private async Task ReloadDataAndRefreshUI()
        {
            gridControl1.DataSource = null; // إعادة ضبط مصدر البيانات
            await LoadDataInBackground();
            gridControl1.RefreshDataSource(); // تحديث مصدر البيانات
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

        private void FRM_wasl_Load(object sender, EventArgs e)
        {
            using (var context = new AlibaRamyEntities())
            {
                var eee = context.TB_temp.Where(x => x.user_id == AddPage.Users.Idd).Select(x => x.order_id).FirstOrDefault();
                if (eee != null)
                {
                    Travel_ID = (int)eee;
                }
            }
            _ = LoadDataInBackground();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
        
    
