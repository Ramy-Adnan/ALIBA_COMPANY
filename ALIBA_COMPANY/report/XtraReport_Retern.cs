using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraReports.Parameters;

namespace ALIBA_COMPANY.report
{
    public partial class XtraReport_Retern : DevExpress.XtraReports.UI.XtraReport
    {
     
        
        public XtraReport_Retern()
        {
            InitializeComponent();
          //  LoadDataForReport();
        }
      /*  private void Parameter()
        {
            // إنشاء معامل
            var parameter1 = new DevExpress.XtraReports.Parameters.Parameter();
            parameter1.Name = "Parameter1";
            parameter1.Type = typeof(int); // يمكن تعديل نوع المعامل حسب نوع البيانات

            // تعيين قيمة للمعامل
            parameter1.Value = 10; // يمكن تعيين قيمة بناءً على متغير أو قيمة ديناميكية

            // إضافة المعامل إلى تقرير DevExpress
            report.Parameters.Add(parameter1);
            MyReport.Parameters["Name"].Value = "ff";
        }*/
        /* private void LoadDataForReport()
         {
             try
             {
                 db = new AlibaRamyEntities();

                 var singleRecord = db.TB_temp
                 .Where(x => x.user_id == ALIBA_COMPANY.AddPage.Users.Idd)
                  .Select(x => new TempData
                  {
                   ItemsName = x.TB_items.items_name,
                    TempNum = x.temp_num,
                    TempNum1 = x.temp_renum,
                      TempSum = Math.Abs(x.temp_num ?? 0) - (x.temp_renum ?? 0)
                  })
                     .FirstOrDefault(); // جلب السجل الوحيد بناءً على الشرط

                 if (singleRecord != null)
                 {
                     List<TempData> dataList = new List<TempData>();
                     dataList.Add(singleRecord); // إضافة السجل الوحيد إلى القائمة

                     SetDataToTable(table2, dataList); // عرض السجل الوحيد في الجدول دون تكرار
                 }

             }
             catch (Exception ex)
             {
                 // يمكنك إضافة رسالة تنبيه أو معالجة للخطأ هنا
                 Console.WriteLine(ex.Message);
             }
         }

         private void SetDataToTable(XRTable table, List<TempData> data)
         {
             int rowNumber = 0;

             foreach (XRTableRow row in table.Rows)
             {
                 if (rowNumber < data.Count)
                 {
                     // تحديد الصف الحالي في الجدول
                     TempData rowData = data[rowNumber];

                     // قم بتعيين قيمة العنصر من البيانات إلى الخلية الأولى في الصف
                     XRTableCell cell = row.Cells[0];
                     cell.Text = rowData.ItemsName;

                     // قم بتعيين قيمة الرقم المؤقت إلى الخلية الثانية في الصف
                     XRTableCell cell2 = row.Cells[1];
                     cell2.Text = rowData.TempSum.ToString();

                     rowNumber++;
                 }
                 else
                 {
                     // قم بإخفاء الصف إذا لم يكن هناك بيانات لعرضها
                     row.Visible = false;
                 }
             }
         }

         public class TempData
         {
             public string ItemsName { get; set; }
             public decimal? TempNum { get; set; }
             public decimal? TempNum1 { get; set; }
             public decimal? TempSum { get; set; }
         }*/

    }
}
