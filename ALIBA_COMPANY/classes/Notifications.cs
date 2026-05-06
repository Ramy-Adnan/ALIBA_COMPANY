using DevExpress.XtraBars.ToastNotifications;
using System;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;
using System.Reflection;

namespace ALIBA_COMPANY.classes
{
    public static class Notifications
    {
        // ✅ مسار ثابت من الكمبيوتر مباشرة
        private static readonly string logoPath = @"C:\AlibaImages\20262026.png";
        private static readonly string soundPath = @"C:\AlibaImages\NS.mp3";


        public static void ShowToast(string title, string description)
        {
            try
            {
                // ✅ هذا السطر يحل مشكلة التحزيم
                if (!ToastNotificationManagerCompat.WasCurrentProcessToastActivated())
                {
                    // تسجيل التطبيق
                }

                var builder = new ToastContentBuilder()
                    .AddText(title)
                    .AddText(description)
                    .AddAttributionText("شركة اللبـة للتجارة العامة");

                if (File.Exists(logoPath))
                {
                    string logoUri = "file:///" + logoPath.Replace("\\", "/");
                    builder.AddAppLogoOverride(
                        new Uri(logoUri),
                        ToastGenericAppLogoCrop.Circle
                    );
                }
                else
                {
                    //// ✅ رسالة تخبرك إذا لم يجد الملف
                    //MessageBox.Show($"الأيقونة غير موجودة في:\n{logoPath}",
                    //    "تنبيه", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (File.Exists(soundPath))
                {
                    string soundUri = "file:///" + soundPath.Replace("\\", "/");
                    builder.AddAudio(new Uri(soundUri));
                }

                builder.Show(toast =>
                {
                    toast.ExpirationTime = DateTimeOffset.Now.AddSeconds(10);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void ShowBasicToast(string title, string description)
        {
            MessageBox.Show($"{description}", title,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}