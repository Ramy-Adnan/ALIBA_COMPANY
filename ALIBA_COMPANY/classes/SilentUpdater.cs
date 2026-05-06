using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALIBA_COMPANY.classes;
using Newtonsoft.Json;

public class UpdateInfo
{
    public string Version { get; set; }
    public string DownloadUrl { get; set; }
}

public class SilentUpdater
{
    private const string VERSION_URL = "https://api.alliba.uk/dev/ramy/apps/Alliba/version.json";
    private const string CURRENT_VERSION = "3.0.0";

    // المسار اللي سيتحمل فيه الملف الجديد
    private static string UpdateFolder =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update_ready");
    private static string UpdatedExePath =>
        Path.Combine(UpdateFolder, "ALIBA_COMPANY.exe");

    // الزر اللي سيظهر في الفورم الرئيسي
    private static Button _updateButton;

    public static void Initialize(Button updateBtn)
    {
        _updateButton = updateBtn;
        _updateButton.Visible = false; // مخفي في البداية

        // ابدأ الفحص في الخلفية بعد 5 ثواني من فتح البرنامج
        Task.Run(async () =>
        {
            await Task.Delay(1000);
            await CheckAndDownloadSilently();
        });
    }

   

    private static async Task CheckAndDownloadSilently()
    {
        try
        {
            string json;
            using (var client = new WebClient())
                json = await client.DownloadStringTaskAsync(VERSION_URL);

            var info = JsonConvert.DeserializeObject<UpdateInfo>(json);

            if (new Version(info.Version) <= new Version(CURRENT_VERSION))
                return;

            // ✅ أرسل إشعار Toast فور اكتشاف التحديث
            Notifications.ShowToast("🔄 تحديث جديد متاح", $"الإصدار {info.Version} جاهز");

            // أظهر الزر أصفر
            _updateButton.Invoke((Action)(() =>
            {
                _updateButton.Visible = true;
                _updateButton.Text = "⏳ جاري تحضير التحديث...";
                _updateButton.BackColor = System.Drawing.Color.FromArgb(234, 179, 8);
                _updateButton.ForeColor = System.Drawing.Color.White;
                _updateButton.Enabled = false;
            }));

            // حمّل في الخلفية
            Directory.CreateDirectory(UpdateFolder);
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(info.DownloadUrl, UpdatedExePath);
            }

            // ✅ إشعار ثاني عند اكتمال التحميل
            Notifications.ShowToast(
                "✅ التحديث جاهز",
                "اضغط على زر التحديث لتطبيقه الآن"
            );

            // فعّل الزر
            _updateButton.Invoke((Action)(() =>
            {
                _updateButton.Text = "🔄 تحديث جاهز";
                _updateButton.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
                _updateButton.Enabled = true;
            }));
        }
        catch { }
    }

    public static void ApplyUpdate()
    {
        // شغّل Updater.exe اللي سيستبدل الملف ويعيد التشغيل
        string updaterPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Updater.exe");

        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            FileName = updaterPath,
            Arguments = $"\"{UpdatedExePath}\" \"{Application.ExecutablePath}\"",
            UseShellExecute = true,
        };
        System.Diagnostics.Process.Start(startInfo);

        Application.Exit();
    }
}