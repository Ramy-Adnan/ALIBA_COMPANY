using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIBA_COMPANY
{
    public class RandomOrderCodeGenerator
    {
        private static Random random = new Random();
        private static string CurrentYearRandomCode { get; set; } = "";
        private static int TimesUsedInYear { get; set; } = 0;
        private const int MaxTimesPerYear = 3;

        public static string GenerateRandomOrderCode()
        {
            int currentYear = DateTime.Now.Year;

            // تحديث قيمة المتغير
            if (string.IsNullOrEmpty(CurrentYearRandomCode) || !CurrentYearRandomCode.StartsWith(currentYear.ToString()) || TimesUsedInYear >= MaxTimesPerYear)
            {
                CurrentYearRandomCode = $"{currentYear:D4}{random.Next(1, 199):D2}";
                TimesUsedInYear = 1;
            }
            else
            {
                TimesUsedInYear++;
                if (TimesUsedInYear % MaxTimesPerYear == 0)
                {
                    CurrentYearRandomCode = "";
                }
            }

            // تأكد من أن المتغير ليس فCurrentYearRandomCodeارغاً قبل استخدامه
            if (!string.IsNullOrEmpty(CurrentYearRandomCode))
            {
                return CurrentYearRandomCode.Substring(4, 2);
            }
            else
            {
                return "1995";
            }
        }

        //الاسدعاء
        // استدعاء الدالة للحصول على رمز عشوائي
       /* string randomCode = RandomOrderCodeGenerator.GenerateRandomOrderCode();

        // استخدام الرمز العشوائي في التطبيق الخاص بك
        Console.WriteLine($"Random Order Code: {randomCode}");
*/
    }
}
