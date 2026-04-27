using ALIBA_COMPANY.AddPage;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace ALIBA_COMPANY
{
    static class Program
    {
              
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
      

            static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureGraphicsSettings();
            Application.Run(new other.Start());
            // Application.Run(new FRM_main());
        }
      

        static void ConfigureGraphicsSettings()
        {
            // تفعيل دعم DPI متعدد الشاشات إذا كانت الجلسة ليست جلسة خادم طرفي
            if (!SystemInformation.TerminalServerSession && Screen.AllScreens.Length > 1)
                WindowsFormsSettings.SetPerMonitorDpiAware();
            else
                WindowsFormsSettings.SetDPIAware();

            // تفعيل الأنماط المخصصة للنماذج
            WindowsFormsSettings.EnableFormSkins();

            // فرض استخدام DirectX للرسم
            WindowsFormsSettings.ForceDirectXPaint();

            // تعيين وضع التمرير إلى Fluent
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Desktop;

            // تعيين سلوك الخطوط إلى استخدام خط Segoe UI بشكل دائم
            WindowsFormsSettings.FontBehavior = WindowsFormsFontBehavior.ForceSegoeUI;
        }
       
    }
}
