using System;
using System.Diagnostics;
using System.Windows.Forms;

public static class SystemUtilities
{
    public static void SetProcessPriority()
    {
        Process currentProcess = Process.GetCurrentProcess();
        currentProcess.PriorityClass = ProcessPriorityClass.High;
    }

    public static void AllocateMoreMemory()
    {
        try
        {
            // تخصيص 1 جيجابايت من الذاكرة
            byte[] buffer = new byte[1024 * 1024 * 1024];
        }
        catch (OutOfMemoryException ex)
        {
            MessageBox.Show("لا يوجد ذاكرة كافية: " + ex.Message);
        }
    }
}
