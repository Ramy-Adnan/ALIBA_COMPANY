using DevExpress.XtraBars;
using System;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

using ALIBA_COMPANY.pages;

using ALIBA_COMPANY.traval;
using ALIBA_COMPANY.other;
using ALIBA_COMPANY.Store;
using ALIBA_COMPANY.sold;

using Timer = DevExpress.XtraEditors.Timer;

namespace ALIBA_COMPANY
{
    public partial class FRM_main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        bool PageStageClose;
        XtraTabPage XtraPage;
        public FRM_main()
        {
            InitializeComponent();
            LoadHomePage();
            InitializeTimer();
            accordionControl1.Appearance.Item.Normal.BackColor = Color.FromArgb(62, 91, 135);
            AddMouseClickHandlers(this.Controls);

        }
        private void AddMouseClickHandlers(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseClick += new MouseEventHandler(Form_MouseClick);
                if (control.HasChildren)
                {
                    AddMouseClickHandlers(control.Controls);
                }
            }
        }
        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = this.PointToClient(Control.MousePosition);
            if (!pn_notification.Bounds.Contains(mousePosition))
            {
                CloseNotification();

            }
            /*FRM_main main = new FRM_main();
            main.CloseNotification();*/
        }
        public void CloseNotification()
        {
            transitionManager1.StartTransition(pn_notification);
            pn_notification.Visible = false;
            transitionManager1.EndTransition();
            GetNoteNumber();
            //  dbContext.TB_Note.Local.Clear();
        }
        //load pages
        private void SelectPage(DevExpress.XtraEditors.XtraUserControl control, string PageTitle)
        {
            try
            {
                foreach (XtraTabPage pageindex in xtraTabControl1.TabPages)
                {
                    if (pageindex.Text == PageTitle)
                    {
                        PageStageClose = false;
                        XtraPage = pageindex;
                        break;

                    }
                    else
                    {
                        PageStageClose = true;
                    }
                }
                if (PageStageClose == true)
                {
                    control.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add();
                    var CurrentPage = xtraTabControl1.TabPages.Last();
                    xtraTabControl1.SelectedTabPage = CurrentPage;
                    CurrentPage.Text = PageTitle;
                    CurrentPage.Controls.Add(control);
                }
                else
                {
                    xtraTabControl1.SelectedTabPage = XtraPage;
                }
            }
            catch { }

        }

        private void LoadHomePage()
        {
            try
            {
                page_home page = new page_home
                {
                    Dock = DockStyle.Fill
                };
                xtrahomepage.Controls.Clear();
                xtrahomepage.Controls.Add(page);
                xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.First();
            }
            catch { }
        }
        private void btn_about_ItemClick(object sender, ItemClickEventArgs e)
        {
            other.FRM_about g = new other.FRM_about();
            g.Show();
        }



        private void btn_home_Click_1(object sender, EventArgs e)
        {
            LoadHomePage();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            var xtrapage = arg.Page as XtraTabPage;
            xtraTabControl1.TabPages.Remove(xtrapage);
        }




        private void FRM_main_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                UpdateUserStatus(e);
            }
        }
        private void UpdateUserStatus(FormClosingEventArgs e)
        {
            using (var context = new AlibaRamyEntities())
            {
                DialogResult result = MessageBox.Show("هل تريد اغلاق النظام؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var selectedUser = context.TB_users.FirstOrDefault(x => x.user_id == ALIBA_COMPANY.AddPage.Users.Idd);
                    selectedUser.user_state = false;
                    context.Entry(selectedUser).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Btn_Close_traval_Click(object sender, EventArgs e)
        {
            try
            {

                FRM_traval_recording newItemForm = new FRM_traval_recording();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_Close_traval " + ex.Message);
            }
        }

        private void Btn_Dis_traval_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_Dis_traval newItemForm = new FRM_Dis_traval();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_Did_traval " + ex.Message);
            }

        }

        private void Btn_update_password_Click(object sender, EventArgs e)
        {
            try
            {

                FRM_password newItemForm = new FRM_password();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_update_password " + ex.Message);
            }
        }



        private void Btn_cars_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_cars newItemForm = new FRM_cars();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_cars " + ex.Message);
            }
        }

        private void Btn_branch_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_branch newItemForm = new FRM_branch();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_branch " + ex.Message);
            }
        }

        private void Btn_custmer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_custemmer newItemForm = new FRM_custemmer();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_custmer " + ex.Message);
            }
        }

        private void Btn_emplo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_Emplo newItemForm = new FRM_Emplo();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_emplo " + ex.Message);
            }
        }

        private void Btn_in_Click(object sender, EventArgs e)
        {
            try
            {
                Store.page_inside newItemForm = new Store.page_inside();

                SelectPage(newItemForm, "نقل داخل");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_btn_in_click " + ex.Message);
            }
        }

        private void Btn_items_Click(object sender, EventArgs e)
        {
            try
            {

                pages.page_items newItemForm = new pages.page_items();

                SelectPage(newItemForm, "المواد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening item form: " + ex.Message);
            }
        }

        private void Btn_Mandob_Click(object sender, EventArgs e)
        {
            try
            {
                sold.page_Sold newItemForm = new sold.page_Sold();

                SelectPage(newItemForm, "البيع");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_btn_click " + ex.Message);
            }
        }

        private void Btn_traval_Click(object sender, EventArgs e)
        {
            try
            {
                // تحقق مما إذا كانت نافذة FRM_travel مفتوحة بالفعل
                var openForm = Application.OpenForms.OfType<FRM_travel>().FirstOrDefault();

                // إذا كانت النافذة مفتوحة، أغلقها
                if (openForm != null)
                {
                    openForm.Close();
                    openForm.Dispose();
                }

                FRM_travel newItemForm = new FRM_travel();
                newItemForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error_btn_click " + ex.Message);
            }
        }


        private void Btn_dis_sold_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_dis_sold newItemForm = new FRM_dis_sold();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_dis_sold " + ex.Message);
            }
        }

        private void Btn_Out_Click(object sender, EventArgs e)
        {
            try
            {
                Store.page_outside newItemForm = new Store.page_outside();

                SelectPage(newItemForm, "نقل خارج");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_btn_Out_click " + ex.Message);
            }
        }

        private void Btn_stock_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_stock newItemForm = new FRM_stock();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_stock " + ex.Message);
            }
        }

        private void Btn_wsolat_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                FRM_dis_wasel newItemForm = new FRM_dis_wasel();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorBtn_wsolat " + ex.Message);
            }
        }

        private void Btn_sell_Click(object sender, EventArgs e)
        {
            try
            {
                var openForm = Application.OpenForms.OfType<FRM_sell>().FirstOrDefault();

                // إذا كانت النافذة مفتوحة، أغلقها
                if (openForm != null)
                {
                    openForm.Close();
                    openForm.Dispose();
                }

                FRM_sell newItemForm = new FRM_sell();

                newItemForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("errorBtn_sell " + ex.Message);
            }
        }


        private void Btn_note_ItemClick(object sender, ItemClickEventArgs e)
        {

            pages.Notifications note = new pages.Notifications
            {
                Dock = DockStyle.Fill
            };
            pn_notification.Controls.Clear();
            pn_notification.Controls.Add(note);
            if (pn_notification.Visible == true)
            {
                transitionManager1.StartTransition(pn_notification);
                pn_notification.Visible = false;
                transitionManager1.EndTransition();

            }
            else
            {
                transitionManager1.StartTransition(pn_notification);
                pn_notification.Visible = true;
                transitionManager1.EndTransition();

            }
            GetNoteNumber();
        }

        bool connect = true;
        bool isMessageShown = false;

        public void GetNoteNumber()
        {
            if (connect)
            {
                try
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        if (IsDatabaseConnected(db))
                        {
                            if (isMessageShown)
                            {
                                MessageBox.Show("تم استعادة الاتصال", "اتصال مستعاد");
                                isMessageShown = false;
                            }

                            var today = DateTime.Today;
                            var tomorrow = today.AddDays(1);

                            var list = db.TB_Note
                                         .Where(x => x.NoteDate >= today && x.NoteDate < tomorrow)
                                         .ToList();

                            if (list.Count == 0)
                            {
                                txt_notnumber.Caption = "";
                                Btn_note.Caption = "";

                                db.TB_Note.RemoveRange(db.TB_Note);
                                db.SaveChanges();
                            }
                            else
                            {
                                txt_notnumber.Caption = list.Count.ToString();
                                Btn_note.Caption = list.Count.ToString();
                            }
                        }
                        else
                        {
                            connect = false;
                            if (!isMessageShown)
                            {
                                MessageBox.Show("تم قطع الاتصال", "لا يوجد اتصال");
                                isMessageShown = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connect = false;
                    if (!isMessageShown)
                    {
                        MessageBox.Show("GotNumber: " + ex.Message, "خطأ");
                        isMessageShown = true;
                    }
                }
            }
        }

        private bool IsDatabaseConnected(AlibaRamyEntities db)
        {
            try
            {
                return db.Database.Exists();
            }
            catch
            {
                return false;
            }
        }



        private void Btn_dis_users_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_system_log newItemForm = new FRM_system_log();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorBtn_dis_users" + ex.Message);
            }
        }

        private void FRM_main_Activated(object sender, EventArgs e)
        {
            CloseNotification();
        }

        private void InitializeTimer()
        {
            timer1 = new Timer
            {
                Interval = 2000 // 60000 milliseconds = 1 minute
            };
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetNoteNumber();
        }

        private void Btn_requst_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_requst newItemForm = new FRM_requst();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_requst" + ex.Message);
            }
        }

        private void Btn_dis_balance_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_balance newItemForm = new FRM_balance();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_balance" + ex.Message);
            }
        }

        private void About_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_about newItemForm = new FRM_about();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_about " + ex.Message);
            }
        }

        private void Btn_dis_requst_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_dis_requst newItemForm = new FRM_dis_requst();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_dis_requst" + ex.Message);
            }
        }

        private void Btn_cash_recive_Click(object sender, EventArgs e)
        {
            try
            {
                ERM_cash newItemForm = new ERM_cash();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error ERM_cash" + ex.Message);
            }
        }

        private void Btn_incentive_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_incentive newItemForm = new FRM_incentive();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error FRM_incentive" + ex.Message);
            }
        }

        private void Btn_connection_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_setting newItemForm = new FRM_setting();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error FRM_setting" + ex.Message);
            }
        }


        bool isDarkTheme;
        private void onDarkThem_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            var palette = (isDarkTheme) ?
                DevExpress.LookAndFeel.SkinSvgPalette.Bezier.ArtHouse :
                DevExpress.LookAndFeel.SkinSvgPalette.Bezier.Default;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Bezier, palette);

        }

        private void Btn_user_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                pages.Page_Users newItemForm = new pages.Page_Users();

                SelectPage(newItemForm, "المستخدمين");
            }
            catch (Exception ex)
            {
                MessageBox.Show("btn_users_click " + ex.Message);
            }
        }

        private void Btn_restor_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                Check newItemForm = new Check();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error FRM_setting" + ex.Message);
            }
        }

        private void Btn_backup_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Frm_backup newItemForm = new Frm_backup();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error FRM_setting" + ex.Message);
            }
        }

        private void FRM_main_Load(object sender, EventArgs e)
        {
            if (AddPage.Users.userRole == "مدير" || AddPage.Users.userRole == "مدير حسابات")
            {
                toastNotificationsManager1.ShowNotification("مرحبا بك");
            }

        }

        private void Btn_help_Click(object sender, EventArgs e)
        {
            try
            {
                FeedBack newItemForm = new FeedBack();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error FRM_setting" + ex.Message);
            }
        }

        private void Btn_dis_InOrOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_dis_InAndOut newItemForm = new FRM_dis_InAndOut();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_Btn_dis_InAndOut_connection" + ex.Message);
            }
        }

        private void Btn_dis_stor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                FRM_Dis_store newItemForm = new FRM_Dis_store();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open Btn_dis_store " + ex.Message);
            }
        }

        private void Btn_dis_stock1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_dis_stock newItemForm = new FRM_dis_stock();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error Btn_dis_stock " + ex.Message);
            }
        }

        private void Btn_in1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Store.page_inside newItemForm = new Store.page_inside();

                SelectPage(newItemForm, "نقل داخل");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_btn_in_click " + ex.Message);
            }
        }

        private void Btn_Out1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Store.page_outside newItemForm = new Store.page_outside();

                SelectPage(newItemForm, "نقل خارج");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error_btn_Out_click " + ex.Message);
            }
        }

        private void Share_Post_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_Share newItemForm = new FRM_Share();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_Share" + ex.Message);
            }
        }

        private void Mandob_dis_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_CridetLedger newItemForm = new FRM_CridetLedger();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_CridetLedger" + ex.Message);
            }
        }

        private void Btn_dis_on_emplo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FRM_DistributorLedger newItemForm = new FRM_DistributorLedger();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_DistributorLedger" + ex.Message);
            }
        }

        private void Btn_sarf_ItemClick(object sender, ItemClickEventArgs e)
        {
            


        }
    }
}
