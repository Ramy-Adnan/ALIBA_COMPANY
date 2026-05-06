using DevExpress.XtraSplashScreen;
using System;

using System.Data;

using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using ALIBA_COMPANY.classes;
using Squirrel;

//using System.IO;
//using System.Net.Http;
//using System.Net.NetworkInformation;
//using static ALIBA_COMPANY.other.Start;


//using ALIBA_COMPANY;
//using System.Net;
namespace ALIBA_COMPANY.other
{
    public partial class Start : SplashScreen
    {
        AlibaRamyEntities db;
        int state;
        public Start()
        {
            InitializeComponent();
            this.Copyright.Text = "Programming By Eng Ramy® 2024 - " + DateTime.Now.Year.ToString();

            // داخل الدالة  
            // Marking the constructor as async is not allowed, so we need to move the async code to a separate method.  
            //InitializeUpdateManagerAsync();


           
        }

        //private async void InitializeUpdateManagerAsync()
        //{
        //    using (var mgr = new UpdateManager(@"http://your-server.com/releases"))
        //    {
        //        // فحص وتحميل التحديث وتثبيته تلقائياً  
        //        await mgr.UpdateApp();
        //    }
        //}

        private void CheckState()
        {
            try
            {
                using (db = new AlibaRamyEntities())
                {
                    var userid = db.TB_users.Select(x => x.user_id).FirstOrDefault();
                    // Login in  
                    if (userid > 0)
                    {
                        state = 1;
                    }
                    else
                    {
                        state = 2;
                    }
                }
            }
            catch
            {
                state = 3;
            }
        }

        private async void Start_Load(object sender, EventArgs e)
        {
            await Task.Run(() => CheckState());
            if (state == 1)
            {
                //  Updater updater = new Updater();  

                //  await updater.CheckForUpdates(bunifuCircleProgressbar1, labelDownload, labelSpeed, LblUpdate);  
                LblUpdate.Text = "جاري بدأ النظام...";

                timer1.Start();
            }
            if (state == 2)
            {
                AddPage.FRM_AddUser DepPage = new AddPage.FRM_AddUser();
                DepPage.Start = 1;
                MessageBox.Show("مرحبا بك , الصفحة القادمة تتيح لك اضافة يوزر جديد للنظام او ادمن ");
                DepPage.Show();
                Hide();
            }
            if (state == 3)
            {
                var rs = MessageBox.Show("اختر نعم لاعادة الاتصال, لا لضبط الاتصال, الغاء الامر لغلق البرنامج", "خطأ اتصال", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (rs == DialogResult.No)
                {
                    FRM_setting setting = new FRM_setting();
                    setting.Start = 1;
                    setting.Show();
                    Hide();
                }
                else if (rs == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }

        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            bunifuCircleProgressbar1.Value = startpoint;
            if (bunifuCircleProgressbar1.Value == 10)
            {
                bunifuCircleProgressbar1.Value = 0;
                timer1.Stop();
                this.Hide();
                AddPage.FR_login loginFrom = new AddPage.FR_login();
                loginFrom.Show();
            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com/Eng.Ramy.Elafluki");
        }
        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            Process.Start("www.t.me/R95l6");
        }
        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            Process.Start("www.youtube.com");
        }
    }
}