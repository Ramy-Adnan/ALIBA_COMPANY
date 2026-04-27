using ALIBA_COMPANY.classes;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_system_log : DevExpress.XtraEditors.XtraForm
    {
        Note EngRamy;
        public FRM_system_log()
        {
            InitializeComponent();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void LoadMotion()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var NoteListCategory = dbbb.TB_amov.Select(x => x.amov_name).ToList();
                    NoteListCategory.Insert(0, "كل الحركات");
                    Combo_motion.DataSource = NoteListCategory;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل الحركات: " + ex.Message);
            }

        }
        public void LoadUser()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var NoteListCategory = dbbb.TB_users.Select(x => x.user_name).ToList();
                    NoteListCategory.Insert(0, "كل المستخدمين");
                    Combo_user.DataSource = NoteListCategory;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل المستخدمين: " + ex.Message);
            }

        }
        private void FRM_system_log_Load(object sender, EventArgs e)
        {
            LoadMotion();
            LoadUser();
        }

        private async void Btn_serch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                loading.Visible = true;

                string selectedMotion = null;
                string selectedUser = null;
                DateTime FromDate = DateTime.Now;
                DateTime ToDate = DateTime.Now;

                this.Invoke((MethodInvoker)delegate
                {
                  
                    selectedMotion = Combo_motion.SelectedItem?.ToString();
                    selectedUser = Combo_user.SelectedItem?.ToString();
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
                        var query = (from inventory in dbContext.TB_mov
                                     where inventory.mov_date <= ToDate && inventory.mov_date >= FromDate
                                     select new
                                     {
                                         A= inventory.mov_date,
                                         B= inventory.TB_users.user_FullName,
                                         C= inventory.TB_amov.amov_name,
                                         D= inventory.mov_dis,
                                       
                                     });
                        dbContext.Database.CommandTimeout = 120; // وقت الاستعلام اني اححده

                        if (selectedMotion != null && selectedMotion != "كل الحركات")
                            {
                                query = query.Where(x => x.C == selectedMotion);
                            }
                            if (selectedUser != null && selectedUser != "كل المستخدمين")
                            {
                                query = query.Where(x => x.B == selectedUser);
                            }

                        return query.OrderBy(x => x.A)
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
                        MessageBox.Show("لا توجد نتائج للمعلومات المختارة");
                    }
                    else
                    {
                        gridControl1.DataSource = results;
                        lbl_count.Text = gridView1.RowCount.ToString();
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("حدث خطأ في كشف المستخدمين: " + ex.Message);
                });
            }
            finally
            {
                loading.Visible = false;
                Cursor.Current = Cursors.Default;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
           // gridControl1.ShowPrintPreview();

            // Add new notification
            EngRamy = new Note();
            pages.Notifications notifications = new pages.Notifications();
            var username = AddPage.Users.FullName;
            var Note = " تم طباعة حركات المستخدمين من قبل " + username;
            EngRamy.AddNote(Note, notifications, "طباعة", 6);

        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}