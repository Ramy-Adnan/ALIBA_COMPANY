using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.AddPage
{
    public partial class FR_login : DevExpress.XtraEditors.XtraForm
    {// DataBase and Tables
        AlibaRamyEntities db;
        TB_users tbadd;
        // Other var
        public int id;
        public int depid;

        bool state;
        private bool isLoginInProgress = false;
        public FR_login()
        {
            InitializeComponent();
            this.lblcopy.Text = "جميع الحقوق محفوظة © 2011-" + DateTime.Now.Year.ToString();

            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

       
       
        // Add or Edit
        private bool LoginCheck(string UserName, string Password)
        {
            try
            {
                db = new AlibaRamyEntities();
                tbadd = db.TB_users.FirstOrDefault(X => X.user_name == UserName && X.user_passward == Password && X.user_activity == true);
                if (tbadd != null)
                {
                    if (tbadd.user_state==true)
                    {
                        MessageBox.Show("المستخدم نشط", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        state = false; // يمنع الدخول
                    }
                    else
                    {
                        state = true; // يسمح بالدخول
                        Users.Name = tbadd.user_name;
                        Users.FullName = tbadd.user_FullName;
                        Users.Idd = tbadd.user_id;
                        Users.userRole = tbadd.user_role;
                    }
                }
                else
                {
                    state = false; // يمنع الدخول
                }
            }
            catch
            {
                state = false; // يمنع الدخول
            }
            return state;
        }
        private void LoginFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void pictureEdit_Click(object sender, EventArgs e)
        {
            Process.Start("https://wa.link/1mgtn6");
        }
        private void edt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;

            }
        }

        private void edt_password_KeyDown(object sender, KeyEventArgs ke)
        {
            if (ke.KeyCode == Keys.Enter)
            {
                Btn_login_Click(null, null);
       
            }
        }
        private bool ValidateBranchData()
        {
            if (string.IsNullOrWhiteSpace(edt_password.Text) ||
                string.IsNullOrWhiteSpace(edt_username.Text))
            {
                MessageBox.Show("يرجى ملء جميع الحقول", "اشعار ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private async void Btn_login_Click(object sender, EventArgs e)
        {
            if (isLoginInProgress) return; // Prevent multiple login attempts
            if (ValidateBranchData())
            {

                // loading
                loading.Visible = true;
                isLoginInProgress = true; // Reset flag
                // Add or Edit
                var username = edt_username.Text;
                var pasword = edt_password.Text;
                var result = await Task.Run(() => LoginCheck(username, pasword));
                if (result == true)
                {
                    // Sign in 
                    FRM_main main1 = new FRM_main();
                    // Set User Data
                    Properties.Settings.Default.UserID = tbadd.user_id;
                    Properties.Settings.Default.FullName = tbadd.user_FullName;
                    Properties.Settings.Default.UserName = tbadd.user_name;
                    Properties.Settings.Default.UserRole = tbadd.user_role;

                    db.TB_users.Attach(tbadd);
                    var entry = db.Entry(tbadd);
                    entry.Property(e1 => e1.user_state).IsModified = true;
                    db.SaveChanges();

                    Properties.Settings.Default.Save();

                    // Role 
                    if (tbadd.user_role == "موزع" || tbadd.user_role == "مسؤول الموزعيين")
                    {
                        //صلاحيات
                        main1.Btn_sell.Visible = false;
                        main1.Btn_in.Visible = false;
                        main1.Btn_Out.Visible = false;
                        main1.Btn_sell.Visible = false;

                        main1.Btn_cash_recive.Visible = false;
                        main1.Btn_Close_traval.Visible = false;
                        main1.Btn_traval.Visible = false;
                        main1.Btn_cash_sell.Visible = false;

                        main1.Btn_note.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_mangment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_account.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_discavary.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_store.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_mangment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_seting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                        main1.s12.Visible = false;
                        main1.s11.Visible = false;

                        main1.s8.Visible = false;
                        main1.s7.Visible = false;
                        main1.s6.Visible = false;
                        main1.s5.Visible = false;
                        main1.s3.Visible = false;

                        main1.lblName.Caption = tbadd.user_FullName;
                        main1.lblRol.Caption = tbadd.user_role;
                        main1.Show();
                    }
                    else if (tbadd.user_role == "امين مخزن")
                    {
                        //صلاحيات
                        main1.Btn_sell.Visible = false;
                        main1.Btn_in.Visible = true;
                        main1.Btn_Out.Visible = true;
                        main1.Btn_sell.Visible = false;

                        main1.Btn_cash_recive.Visible = false;
                        main1.Btn_Close_traval.Visible = false;
                        main1.Btn_traval.Visible = true;
                        main1.Btn_cash_sell.Visible = false;
                        main1.Btn_Mandob.Visible = false;

                        main1.Btn_wsolat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_motion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_sold.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        main1.Btn_dis_requst.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_pyments.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_exchang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_sellWeek.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_users.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        main1.Btn_note.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_mangment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_account.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_discavary.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        main1.Btn_store.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        main1.Btn_mangment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_seting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                        main1.s12.Visible = false;
                        main1.s11.Visible = false;

                        main1.s8.Visible = false;
                        main1.s7.Visible = false;
                        main1.s6.Visible = false;
                        main1.s5.Visible = false;
                        main1.s3.Visible = false;

                        main1.lblName.Caption = tbadd.user_FullName;
                        main1.lblRol.Caption = tbadd.user_role;
                        main1.Show();
                    }
                    else if (tbadd.user_role == "مدير حسابات"|| tbadd.user_role == "حسابات")
                    {
                        main1.Btn_seting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        main1.lblName.Caption = tbadd.user_FullName;
                        main1.lblRol.Caption = tbadd.user_role;
                        main1.Show();
                    }
                    else if (tbadd.user_role == "اداري")
                    {
                        //صلاحيات
                        main1.Btn_sell.Visible = false;
                        main1.Btn_in.Visible = false;
                        main1.Btn_Out.Visible = false;
                        main1.Btn_sell.Visible = false;

                        main1.Btn_cash_recive.Visible = false;
                        main1.Btn_Close_traval.Visible = false;
                        main1.Btn_traval.Visible = true;
                        main1.Btn_cash_sell.Visible = false;
                        main1.Btn_Mandob.Visible = false;

                        main1.Btn_cash_recive.Visible = false;
                        main1.Btn_Close_traval.Visible = false;
                        main1.Btn_traval.Visible = false;
                        main1.Btn_cash_sell.Visible = false;

                        main1.Btn_note.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_account.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_store.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_mangment.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        main1.Btn_seting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                        main1.Btn_wsolat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_Dis_traval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_stor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_InOrOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_stock1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        main1.Btn_dis_motion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_sold.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_requst.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        main1.Btn_dis_pyments.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_exchang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_sellWeek.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        main1.Btn_dis_users.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        main1.s12.Visible = false;
                        main1.s11.Visible = false;

                        main1.s8.Visible = false;
                        main1.s7.Visible = false;
                        main1.s6.Visible = false;
                        main1.s5.Visible = false;
                        main1.s3.Visible = false;

                        main1.lblName.Caption = tbadd.user_FullName;
                        main1.lblRol.Caption = tbadd.user_role;
                        main1.Show();
                    }
                    else
                    {

                        main1.lblName.Caption = tbadd.user_FullName;
                        main1.lblRol.Caption = tbadd.user_role;
                        main1.Show();

                    }
                    Hide();
                }
                else
                {
                    MessageBox.Show("خطأ في تسجل الدخول", "خطأ في معلومات تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                loading.Visible = false;
                isLoginInProgress = false; // Reset flag
            }
        }

        private void edt_username_KeyPress(object sender, KeyPressEventArgs eP)
        {

            if (edt_username.Text.Length >= 20 && eP.KeyChar != (char)Keys.Back)
            {
                eP.Handled = true; //
            }
        }

        private void edt_password_KeyPress(object sender, KeyPressEventArgs keyEvent)
        {
            if (edt_password.Text.Length >= 20 && keyEvent.KeyChar != (char)Keys.Back)
            {
                keyEvent.Handled = true; // منع إضا
            }
        }

        private void FR_login_Load(object sender, EventArgs e)
        {

        }

        private void FR_login_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
        }
    }
    public static class Users
    {
        static public string Name { get; set; }
        static public string userRole { get; set; }
        static public int Idd { get; set; }
        static public string FullName { get; set; }
    }
}

