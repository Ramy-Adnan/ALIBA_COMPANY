using DevExpress.XtraBars.ToastNotifications;
using System;

namespace ALIBA_COMPANY.classes
{
    public static class Notifications
    {
        private static ToastNotificationsManager toastNotificationsManager;

        // Static Constructor to Initialize ToastNotificationsManager
        static Notifications()
        {
            // إعداد ToastNotificationsManager
            toastNotificationsManager = new ToastNotificationsManager();
            toastNotificationsManager.ApplicationId = "ALIBA_COMPANY"; // معرف التطبيق
        }

        // Method to Show Toast Notification
        public static void ShowToast(string title, string description)
        {
            // إنشاء ToastNotification باستخدام DevExpress
            ToastNotification toast = new ToastNotification
            {
                
               
            };

         
            // عرض الإشعار
            toastNotificationsManager.ShowNotification(toast);
        }
    }
}
