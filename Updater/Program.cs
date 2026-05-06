// Program.cs في مشروع Updater
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // args[0] = مسار الملف الجديد
        // args[1] = مسار البرنامج الأصلي

        if (args.Length < 2) return;

        string newExe = args[0];
        string targetExe = args[1];
        string appName = Path.GetFileNameWithoutExtension(targetExe);

        // 1. انتظر حتى يُغلق البرنامج الرئيسي
        Thread.Sleep(1500);

        // تأكد إنه أُغلق فعلاً
        foreach (var p in Process.GetProcessesByName(appName))
        {
            p.WaitForExit(5000);
        }

        // 2. استبدل الملف القديم بالجديد
        File.Copy(newExe, targetExe, overwrite: true);

        // 3. احذف مجلد التحديث
        string updateFolder = Path.GetDirectoryName(newExe);
        Directory.Delete(updateFolder, recursive: true);

        // 4. شغّل البرنامج الجديد
        Process.Start(targetExe);
    }
}