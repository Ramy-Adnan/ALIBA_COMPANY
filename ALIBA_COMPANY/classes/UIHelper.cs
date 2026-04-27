using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.classes
{
    public static class UIHelper
    {//بدون فاصلة
        public static void HandleTextBoxKeyPress(object sender, KeyPressEventArgs e, int maxLength)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else if (textBox.Text.Length >= maxLength && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
    public static class RAMY
    {//بوجود فاصلة
        public static void HandleTextBoxKeyPress(object sender, KeyPressEventArgs e, int maxLength)
        {
            TextBox textBox = sender as TextBox;
          
            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
            else if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
            }
            else if (textBox.Text.Length >= maxLength && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
         
        }
        public static void HandleTextLeave(object sender , TextBox textBox)
        {
            string text = textBox.Text.Trim();
            if (text.StartsWith(".") || text.EndsWith("."))
            {
                MessageBox.Show("الرجاء تصحيح القيمة. لا يمكن أن تبدأ أو تنتهي بفاصلة عشرية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
            }
        }


    }
}
