using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_detailss : DevExpress.XtraEditors.XtraForm
    {
        private ALIBA_COMPANY.AlibaRamyEntities dbContext;
        public int ID_Wasel;
        public string date;
        public string items;
        public string unit;
        public FRM_detailss()
        {
            InitializeComponent();
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            LoadDataInBackground();
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
        private List<DataTalef> dataDetails;
        private async void LoadDataInBackground()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;

                dataDetails =  await Task.Run(() =>
                {
                    var data = dbContext.TB_details
                         
                        .Where(x => x.order_id == ID_Wasel&& x.action_id==11).AsNoTracking()
                        .Select(x => new DataTalef
                        {

                            Name = x.TB_items.items_name,
                            Group = x.TB_items.TB_groups.groups_name,
                            Form = x.TB_items.items_form,
                            Num = x.details_num,
                           
                        })
                           .ToList();

                    return data;

                   
                });
                this.Invoke((MethodInvoker)delegate
                {
                    gridControl1.DataSource = dataDetails;
                    lbl_date.Text = date;
                    lbl_wasel.Text = ID_Wasel.ToString();
                    lbl_items.Text = items;
                    lbl_pices.Text = unit;
                }); loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }



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

        private void Btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
               
                string Wasel = lbl_wasel.Text;
                DateTime Date = Convert.ToDateTime(lbl_date.Text).Date;
                string Items = lbl_items.Text;
                string Units = lbl_pices.Text;

               
                    DialogResult result = MessageBox.Show("هل تريد طباعة وصل ؟", "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                    // إعداد التقرير
                    XtraReport_Talef report = new XtraReport_Talef
                    {

                        // تعيين dataList كمصدر بيانات للتقرير

                        DataSource = dataDetails
                    };
                    var parameters = new Dictionary<string, object>
                        {

                        { "Wasel", Wasel },
                        { "Date", Date },
                        { "Items", Items },
                        { "Units", Units }
                        };

                        SetReportParameters(report, parameters);
                        report.ShowPreview();

                    }
                
                else
                {
                    MessageBox.Show("اختر صفًا", "لا يمكن اجراء العملية");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void SetReportParameters(XtraReport_Talef report, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {

                if (report.Parameters[param.Key] != null)
                {
                    report.Parameters[param.Key].Value = param.Value;
                }
            }
        }

        private void Btn_exel_Click(object sender, EventArgs e)
        {
            try
            {
                // إنشاء نافذة حوار حفظ الملف
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // إعداد خصائص نافذة الحوار
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "وصل تالف.xlsx"; // الاسم الافتراضي للملف

                    // عرض نافذة الحوار
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // الحصول على مسار الملف من النافذة
                        string filePath = saveFileDialog.FileName;

                        // استخدام ExportToXlsx لتصدير البيانات إلى الملف المحدد
                        gridControl1.ExportToXlsx(filePath);

                        // إخطار المستخدم بنجاح العملية
                        MessageBox.Show("تم تصدير البيانات إلى Excel بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // التعامل مع أي استثناء يحدث أثناء عملية التصدير
                MessageBox.Show("حدث خطأ أثناء تصدير البيانات إلى Excel: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}