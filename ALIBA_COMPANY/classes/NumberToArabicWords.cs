using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIBA_COMPANY.classes
{
    internal class NumberToArabicWords
    {
        private static readonly string[] ones = {
        "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة",
        "ستة", "سبعة", "ثمانية", "تسعة", "عشرة",
        "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر",
        "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر"
    };

        private static readonly string[] tens = {
        "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون",
        "ستون", "سبعون", "ثمانون", "تسعون"
    };

        private static readonly string[] hundreds = {
        "", "مئة", "مئتان", "ثلاثمئة", "أربعمئة", "خمسمئة",
        "ستمئة", "سبعمئة", "ثمانمئة", "تسعمئة"
    };

        public static string Convert(decimal number)
        {
            if (number == 0) return "صفر دينار";

            long intPart = (long)Math.Floor(number);
            int decPart = (int)Math.Round((number - intPart) * 100);

            string result = ConvertIntToWords(intPart);

            if (intPart > 0)
                result += " دينار";

            if (decPart > 0)
                result += " و" + ConvertIntToWords(decPart) + " فلس";

            return result;
        }

        private static string ConvertIntToWords(long number)
        {
            if (number == 0) return "صفر";
            if (number < 0) return "سالب " + ConvertIntToWords(-number);

            List<string> parts = new List<string>();

            // ✅ المليارات
            if (number >= 1000000000)
            {
                long billions = number / 1000000000;
                number %= 1000000000;

                if (billions == 1) parts.Add("مليار");
                else if (billions == 2) parts.Add("ملياران");
                else if (billions <= 10) parts.Add(ConvertIntToWords(billions) + " مليارات");
                else parts.Add(ConvertIntToWords(billions) + " مليار");
            }

            // ✅ الملايين
            if (number >= 1000000)
            {
                long millions = number / 1000000;
                number %= 1000000;

                if (millions == 1) parts.Add("مليون");
                else if (millions == 2) parts.Add("مليونان");
                else if (millions <= 10) parts.Add(ConvertIntToWords(millions) + " ملايين");
                else parts.Add(ConvertIntToWords(millions) + " مليون");
            }

            // ✅ الآلاف
            if (number >= 1000)
            {
                long thousands = number / 1000;
                number %= 1000;

                if (thousands == 1) parts.Add("ألف");
                else if (thousands == 2) parts.Add("ألفان");
                else if (thousands <= 10) parts.Add(ConvertIntToWords(thousands) + " آلاف");
                else parts.Add(ConvertIntToWords(thousands) + " ألف");
            }

            // ✅ المئات والعشرات والآحاد
            if (number >= 100)
            {
                parts.Add(hundreds[number / 100]);
                number %= 100;
            }

            if (number >= 20)
            {
                long digit = number % 10;
                long ten = number / 10;

                // ✅ الآحاد أولاً ثم العشرات
                if (digit > 0)
                    parts.Add(ones[digit] + " و" + tens[ten]);
                else
                    parts.Add(tens[ten]);
            }
            else if (number > 0)
            {
                parts.Add(ones[number]);
            }

            // ✅ دمج الأجزاء بـ "و"
            return string.Join(" و", parts);
        }
    }
}