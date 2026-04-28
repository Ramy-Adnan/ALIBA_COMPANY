using DevExpress.XtraSplashScreen;
using System;

using System.Data;

using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using ALIBA_COMPANY.classes;

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


           
            //// إنشاء مثيل من الكلاس ImageSlider
            //ImageSlider imageSlider = new ImageSlider(panelImageDisplay, button1, button2);

            //// روابط الصور التي تريد تحميلها
            //string[] imageUrls = new string[]
            //{
            //   "https://raw.githubusercontent.com/Ramy-Adnan/Updater/refs/heads/master/AlibaPic1.png",
            //"https://raw.githubusercontent.com/Ramy-Adnan/Updater/refs/heads/master/AlibaPic2.png",
            //"https://raw.githubusercontent.com/Ramy-Adnan/Updater/refs/heads/master/AlibaPic3.png",
           
            //// أضف المزيد من الروابط هنا
            //};

            //// استدعاء الدالة لتحميل وعرض الصور
            //imageSlider.LoadImages(imageUrls);

        }
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
        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
      

        //internal class Updater
        //{
        //    private string exeUrl = "https://drive.google.com/uc?export=download&id=1beqGJxxKQBpgLmcS_4zX_0TzR6F-5Llw\r\n"; // رابط مباشر لـ Aliba.exe
        //    private string versionUrl = "https://drive.google.com/uc?export=download&id=1b_5MBu3DdBn8zV2x-1oU3kMPSfeLWyNQ\r\n"; // رابط مباشر لـ version.txt
        //    private string exePath = Path.Combine(Path.GetTempPath(), "Aliba.txt");
        //    private string currentVersion = "1.1.0"; // إصدار التطبيق الحالي

        //    public async Task CheckForUpdates(Bunifu.Framework.UI.BunifuCircleProgressbar progressBar, Label labelDownload, Label labelSpeed, Label LblUpdate)
        //    {
        //        if (!IsInternetAvailable())
        //        {
        //            LblUpdate.Text = "لا يوجد اتصال بالإنترنت. يرجى التحقق من الاتصال.";
        //            return;
        //        }

        //        try
        //        {
        //            using (HttpClient client = new HttpClient())
        //            {
        //                client.Timeout = TimeSpan.FromSeconds(10);

        //                HttpResponseMessage response = await client.GetAsync(versionUrl);
        //                response.EnsureSuccessStatusCode();

        //                string latestVersion = await response.Content.ReadAsStringAsync();
        //                latestVersion = latestVersion.Trim(); // إزالة أي مسافات زائدة

        //                Console.WriteLine($"الإصدار الحالي: {currentVersion}, الإصدار الجديد: {latestVersion}");

        //                if (latestVersion != currentVersion)
        //                {
        //                    DialogResult result = MessageBox.Show($"إصدار جديد متاح ({latestVersion}). هل ترغب في تنزيله؟",
        //                                                          "تحديث متاح", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //                    if (result == DialogResult.Yes)
        //                    {
        //                        await DownloadAndInstallUpdate(progressBar, labelDownload, labelSpeed, LblUpdate);
        //                    }
        //                    else
        //                    {
        //                        LblUpdate.Text = "تم إلغاء التحديث.";
        //                    }
        //                }
        //                else
        //                {
        //                    LblUpdate.Text = "النظام محدث بالكامل، لا توجد تحديثات متاحة.";
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //          //  MessageBox.Show("فشل في التحقق من التحديث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    private async Task DownloadAndInstallUpdate(Bunifu.Framework.UI.BunifuCircleProgressbar progressBar, Label labelDownload, Label labelSpeed, Label LblUpdate)
        //    {
        //        LblUpdate.Text = "جارٍ تحميل التحديث...";
        //        try
        //        {
        //            using (HttpClient client = new HttpClient())
        //            {
        //                client.Timeout = TimeSpan.FromMinutes(5);
        //                HttpResponseMessage response = await client.GetAsync(exeUrl, HttpCompletionOption.ResponseHeadersRead);
        //                response.EnsureSuccessStatusCode();

        //                using (var fs = new FileStream(exePath, FileMode.Create, FileAccess.Write, FileShare.None))
        //                using (var stream = await response.Content.ReadAsStreamAsync())
        //                {
        //                    await stream.CopyToAsync(fs);
        //                }
        //            }

        //            Process.Start(new ProcessStartInfo
        //            {
        //                FileName = exePath,
        //                Verb = "runas",
        //                UseShellExecute = true
        //            });

        //            Application.Exit();
        //        }
        //        catch (Exception ex)
        //        {
        //          //  MessageBox.Show("فشل تنزيل التحديث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    private bool IsInternetAvailable()
        //    {
        //        try
        //        {
        //            using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
        //            {
        //                System.Net.NetworkInformation.PingReply reply = ping.Send("8.8.8.8", 3000);
        //                return reply.Status == System.Net.NetworkInformation.IPStatus.Success;
        //            }
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}

      
    }
}