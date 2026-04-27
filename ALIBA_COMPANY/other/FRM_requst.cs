using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
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

namespace ALIBA_COMPANY.other
{
    public partial class FRM_requst : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        AlibaRamyEntities dbContext;
       
        int ID_emr;
        public FRM_requst()
        {
            InitializeComponent();
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            if (AddPage.Users.userRole=="مدير")
            {
                Btn_Agg.Visible = true;
            }
        }

        private void Btn_add_requst_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_Add_requst ADD = new FRM_Add_requst();
                if (ADD.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error Btn_add_requst_Click" + ex.Message);
            }
        }
        public void LoadData()
        {
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            
                var data = dbContext.TB_emr.AsQueryable().AsNoTracking().ToList();
                gridControl1.DataSource = data;
                
                lblNum.Text = gridView1.RowCount.ToString();
        }

        private void FRM_requst_Load(object sender, EventArgs e)
        {
            LoadData();
        }

      
        private string GetFocusedRowCellValue(string columnName)
        {
            object cellValue = gridView1.GetFocusedRowCellValue(columnName);
            return cellValue?.ToString();
        }
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                try
                {
                    string st = GetFocusedRowCellValue("emr_id");
                    string na = GetFocusedRowCellValue("TB_emplo.emplo_name");
                    if (int.TryParse(st, out int intg) && intg != 0)
                    {
                        ID_emr = intg;
                    }

                    if(ID_emr > 0)
                    {

                        using (var context = new AlibaRamyEntities())
                        {
                            var de = context.TB_emr.FirstOrDefault(o => o.emr_id == ID_emr);

                            if (de == null)
                            {
                                MessageBox.Show("لم يتم العثور على الطلب stockItem return", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (de.user_id == AddPage.Users.Idd || AddPage.Users.userRole == "مدير")
                            {
                                context.Entry(de).State = System.Data.Entity.EntityState.Deleted;
                                context.SaveChanges();

                                // Add new notification
                                note = new Note();
                                pages.Notifications notifications = new pages.Notifications();
                                var Note = " حذف الطلب لـ " + na;
                                note.AddNote(Note, notifications, "حذف", 5);

                                MessageBox.Show("تم حذف الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("ليس من صلاحيتك الحذف", "لا يمكن اجراء الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" حدد البيانات  التي تريد حذفها");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FRM_requst_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clear data source
            gridControl1.DataSource = null;

            // Dispose of disposable objects
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

            // Additional cleanup for other controls or resources
            CleanUpControls(this);

            // Force garbage collection
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

        private void Btn_Agg_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("اذا تريد الموافقة اضغط (Yes)\nاذا لم تريد الموافقة اضغط (NO)\n لالغاء العملية اضغط (Cancel) ", "تأكيد المصادقه ", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                try
                {
                    string st = GetFocusedRowCellValue("emr_id");
                    string na = GetFocusedRowCellValue("TB_emplo.emplo_name");
                    if (int.TryParse(st, out int intg) && intg != 0)
                    {
                        ID_emr = intg;
                    }

                    if (ID_emr > 0)
                    {
                        using (var context = new AlibaRamyEntities())
                        {
                            var de = context.TB_emr.FirstOrDefault(o => o.emr_id == ID_emr);

                            if (de != null)
                            {
                                de.action_id = 21;
                                context.Entry(de).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();

                                // Add new notification
                                note = new Note();
                                pages.Notifications notifications = new pages.Notifications();
                                var Note = " مصادقة الطلب لـ " + na;
                                note.AddNote(Note, notifications, "مصادقة", 10);

                                MessageBox.Show("تم مصادقة الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        } 
                    }
                    else
                    {
                        MessageBox.Show(" حدد البيانات  التي تريد مصادقتها");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(Result == DialogResult.No)
            {
                try
                {
                    string st = GetFocusedRowCellValue("emr_id");
                    string na = GetFocusedRowCellValue("TB_emplo.emplo_name");
                    if (int.TryParse(st, out int intg) && intg != 0)
                    {
                        ID_emr = intg;
                    }

                    if (ID_emr > 0)
                    {
                        using (var context = new AlibaRamyEntities())
                        {
                            var de = context.TB_emr.FirstOrDefault(o => o.emr_id == ID_emr);

                            if (de != null)
                            {
                                de.action_id = 22;
                                context.Entry(de).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();

                                // Add new notification
                                note = new Note();
                                pages.Notifications notifications = new pages.Notifications();
                                var Note = " الغاء مصادقة الطلب لـ " + na;
                                note.AddNote(Note, notifications, "مصادقة", 10);

                                MessageBox.Show("تم مصادقة الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" حدد البيانات  التي تريد مصادقتها");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في العملية او الاتصال", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد طباعة الطلب ", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                int Action = int.Parse(GetFocusedRowCellValue("action_id"));
                if (Action == 21)
                {
                    try
                    {
                        string Days = GetFocusedRowCellValue("emr_num");
                        string Emplo = GetFocusedRowCellValue("TB_emplo.emplo_name");
                        DateTime FromD = Convert.ToDateTime(GetFocusedRowCellValue("emr__dateFrom")).Date;
                        DateTime ToD = Convert.ToDateTime(GetFocusedRowCellValue("emr__dateTo")).Date;
                        string Num = GetFocusedRowCellValue("emr_id");
                        DateTime Date = Convert.ToDateTime(GetFocusedRowCellValue("emr_date")).Date;
                        string Type = GetFocusedRowCellValue("TB_emst.emst_name");

                        if (int.TryParse(Num, out int intg) && intg != 0)
                        {
                            ID_emr = intg;
                        }

                        if (ID_emr > 0)
                        {
                            XtraReport_requst report = new XtraReport_requst();
                            report.Parameters["Days"].Value = Days;
                            report.Parameters["Emplo"].Value = Emplo;
                            report.Parameters["Date"].Value = Date;
                            report.Parameters["Num"].Value = Num;
                            report.Parameters["FromD"].Value = FromD;
                            report.Parameters["ToD"].Value = ToD;
                            report.Parameters["Type"].Value = Type;
                            report.ShowPreview();


                            note = new Note();
                            pages.Notifications notifications = new pages.Notifications();
                            var Note = " طباعة طلب " + Emplo;
                            note.AddNote(Note, notifications, "طباعة", 6);

                        }
                        else
                        {
                            MessageBox.Show(" حدد البيانات  التي تريد طباعتها");
                        }
                    }
                    catch { MessageBox.Show("خطأ في الاتصال- Btn_print_Click"); }


                }
                else
                {
                    MessageBox.Show("يمكن طباعة الطلبات المقبولة فقط");
                }

            }
           
        }
    }
}