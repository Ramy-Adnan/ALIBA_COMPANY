
using ALIBA_COMPANY.classes;
using System;

using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_import : DevExpress.XtraEditors.XtraForm
    {
       
        public int ID_traval;
       
        public FRM_import()
        {
            InitializeComponent();
        }

        private void Btn_import_traval_Click(object sender, EventArgs e)
        {
            using (var context = new AlibaRamyEntities())
            {
                var ID_t = context.TB_temp.FirstOrDefault(x => x.user_id == AddPage.Users.Idd);
                if (ID_t != null)
                {
                    MessageBox.Show("يجب حذف بيانات  الاستيراد اولا \n ثم يمكنك الاستيراد  مرة اخرى ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Import_Data();
                    Cursor.Current = Cursors.Default;
                }
            }
        }
      
        private void Set_Import_data()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                    var TT = dbbb.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);
                    if (TT != null)
                    {
                        TT.tr_loading = 0;
                        dbbb.Entry(TT).State = System.Data.Entity.EntityState.Modified;
                        dbbb.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء التحميل:Load_Combo_Traval " + ex.Message);
            }
        }
        //private void Import_Data()
        //{
        //    try
        //    {
        //        using (var sourceContext = new AlibaRamyEntities())
        //        {
        //            var specificData = sourceContext.TB_str.Where(s => s.order_id == ID_traval && s.action_id == 3 && s.str_date == dateTimePicker1.Value.Date).ToList();
        //            if (specificData.Count == 0)
        //            {
        //                MessageBox.Show("ربما خطأ في التاريخ أو اسم الموزع", "لا توجد بيانات "+ ID_traval, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                // أضف هذا مؤقتاً في بداية Import_Data للتشخيص
        //                MessageBox.Show($"ID_traval = {ID_traval}\nالتاريخ = {dateTimePicker1.Value.Date}");
        //            }
        //            else
        //            {


        //                foreach (var item in specificData)
        //                {
        //                    // التحقق من وجود القيمة في جدول TB_items
        //                    var existingItem = sourceContext.TB_items.FirstOrDefault(i => i.items_id == item.items_id);
        //                    if (existingItem != null)
        //                    {
        //                        // القيام بعملية الإضافة إلى TB_temp
        //                        var newItem = new TB_temp
        //                        {
        //                            temp_id = item.str_id,
        //                            temp_num = item.str_num,
        //                            temp_renum = item.str_renum,
        //                            order_id = item.order_id,
        //                            action_id = item.action_id,
        //                            items_id = item.items_id,
        //                            temp_date = item.str_date,
        //                            user_id = ALIBA_COMPANY.AddPage.Users.Idd,
        //                        };
        //                        sourceContext.TB_temp.Add(newItem);
        //                    }
        //                    else
        //                    {
        //                        // إشعار بأن القيمة غير موجودة في TB_items
        //                        MessageBox.Show($"القيمة {item.items_id} غير موجودة في جدول TB_items.", "خطأ يوجد مادة مفقودة", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                       // return;
        //                    }
        //                }
        //                sourceContext.SaveChanges();
        //                Set_Import_data();
        //                MessageBox.Show("تم اسيراد البيانات بنجاح.", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                this.DialogResult = DialogResult.OK;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // إظهار الخطأ الحقيقي من قاعدة البيانات
        //        var message = ex.InnerException?.InnerException?.Message ?? ex.Message;
        //        MessageBox.Show(" حدث خطأ أثناء الحفظ: ربما البيانات مستورده سابقا " + message);
        //    }
        //}

        private void Import_Data()
        {
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    // استدعاء الـ Procedure
                    var result = context.Database.SqlQuery<ImportResult>(
                        "EXEC import_travel_data @travel_id, @user_id, @str_date",
                        new SqlParameter("@travel_id", ID_traval),
                        new SqlParameter("@user_id", AddPage.Users.Idd),
                        new SqlParameter("@str_date", dateTimePicker1.Value.Date)
                    ).FirstOrDefault();

                    if (result != null && result.success == 1)
                    {
                       
                        try { Notifications.ShowToast("عملية ناجحة", "تــم استيراد السفرة بـنجاح"); } catch { }
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(
                            result?.message ?? "حدث خطأ غير متوقع",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }

        // كلاس لاستقبال نتيجة الـ Procedure
        public class ImportResult
        {
            public int success { get; set; }
            public string message { get; set; }
            public int imported_count { get; set; }
        }


        private void Load_Combo_Traval()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                    var T = dbbb.TB_travel.Where(x => x.tr_loading == 1 &&x.tr_sending==false).Select(x => x.TB_emplo.emplo_name).AsNoTracking().ToList();
                    T.Insert(0, "");
                    Combo_Traval.DataSource = T;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء التحميل:Load_Combo_Traval " + ex.Message);
            }
           
        }
        // ✅ عند تغيير التاريخ أيضاً
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Set_ID_Traval();
        }

        private void Combo_Traval_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Set_ID_Traval();
        }

        private void Set_ID_Traval()
        {
            try
            {
                if (Combo_Traval.SelectedItem == null ||
                    string.IsNullOrEmpty(Combo_Traval.SelectedItem.ToString()))
                    return;

                using (var dbbb = new AlibaRamyEntities())
                {
                    var selectedDate = dateTimePicker1.Value.Date;
                    var selectedName = Combo_Traval.SelectedItem.ToString();

                    var Idd = dbbb.TB_travel
                        .Where(x => x.TB_emplo.emplo_name == selectedName
                                 && x.tr_loading == 1
                                 && DbFunctions.TruncateTime(x.tr_date) == selectedDate)
                        .Select(x => x.tr_id)
                        .FirstOrDefault();

                    ID_traval = Idd;

                    // ✅ تنبيه إذا لم يجد نتيجة
                    if (ID_traval == 0 && !string.IsNullOrEmpty(selectedName))
                    {
                         page_Sold pageSoldInstance = new page_Sold(); // Create an instance of page_Sold  
                        pageSoldInstance.lbl_status.Text = "لا توجد سفرة بهذا التاريخ";
                        pageSoldInstance.lbl_status.ForeColor = Color.Red;
                    }
                    
                    else if (ID_traval > 0)
                    {
                        page_Sold pageSoldInstance = new page_Sold();
                        pageSoldInstance.lbl_status.Text = $"تم تحديد السفرة رقم {ID_traval}";
                        pageSoldInstance.lbl_status.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في الاتصال " + ex.Message);
            }
        }
        private void FRM_import_Activated(object sender, EventArgs e)
        {
            Load_Combo_Traval();
            Set_ID_Traval();
          
        }

     

        

       
    }
   
}