using ALIBA_COMPANY.report;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.sold
{
    public partial class page_Sold : DevExpress.XtraEditors.XtraUserControl
    {
        private AlibaRamyEntities context;
        public int? ID_traval=0;
        public page_Sold()
        {
            InitializeComponent();
            context = new AlibaRamyEntities();
        }

        private void Btn_add_import_Click(object sender, EventArgs e)
        {
           
                    using (FRM_import childForm = new FRM_import())
                    {

                        if (childForm.ShowDialog() == DialogResult.OK)
                        {
                           
                            ID_traval = childForm.ID_traval;

                        }
                    }
             
           
        }

        private void Btn_add_export_Click(object sender, EventArgs e)
        {
            using (var context = new AlibaRamyEntities())
            {
                var ID_t = context.TB_temp.FirstOrDefault(x => x.user_id == AddPage.Users.Idd);
                if (ID_t != null)
                {
                    ID_traval = ID_t.order_id;
                }
                else
                {
                    MessageBox.Show("لا تـوجد بيانـات لارسالـهـا ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var ID_list = context.TB_list.Where(x => x.tr_id== ID_traval&&x.sending==true).Count();
                var ID_list1 = context.TB_list.Where(x => x.tr_id == ID_traval && x.sending == false).Count();
                if (ID_list1 <=0)
                {
                    MessageBox.Show("لا تـوجد بيانـات لارسالـهـا ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ID_list > 0)
                    {
                        MessageBox.Show("يوجد وصولات سابقة تمت اضافتها من قبل الحسابات\n يجب حذف تلك الوصولات ثم المحاولة مرة اخرى ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DialogResult result = MessageBox.Show(" اذا نسيت طباعة الراجع\n No اضغط \n واذا كملت طباعة  \n  Yes اضغط ", "انتبة رجاءا انتبه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                     Cursor.Current = Cursors.WaitCursor;
                    string sqlQuery1 = "UPDATE TB_travel SET tr_loading = @tr_loading, tr_sending = @tr_sending WHERE tr_id = @trId";
                        context.Database.ExecuteSqlCommand(sqlQuery1,
                            new SqlParameter("@tr_loading", SqlDbType.TinyInt) { Value = 0 },
                            new SqlParameter("@tr_sending", SqlDbType.Bit) { Value = 1 },
                            new SqlParameter("@trId", SqlDbType.Int) { Value = ID_traval });


                        string sqlQuery2 = @"
                                            UPDATE TB_details 
                                            SET sending = @sending,
                                                sell_num = CASE WHEN sell_num IS NULL THEN 0.000 ELSE sell_num END
                                            WHERE 
                                                order_id = @orderId";
                        context.Database.ExecuteSqlCommand(sqlQuery2,
                            new SqlParameter("@sending", true),
                            new SqlParameter("@orderId", ID_traval));


                        string sqlQuery3 = "UPDATE TB_list SET sending = @sending WHERE tr_id = @orderId";
                        context.Database.ExecuteSqlCommand(sqlQuery3,
                            new SqlParameter("@sending", true),
                            new SqlParameter("@orderId", ID_traval));

                        string sqlQuery4 = "DELETE FROM TB_temp WHERE order_id = @orderId";
                        context.Database.ExecuteSqlCommand(sqlQuery4, new SqlParameter("@orderId", ID_traval));

                        context.SaveChanges();
                        MessageBox.Show("تــم ارســال البيانــات بـنجاح", "نـجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
                    else
                    {
                        try
                        {
                        FRM_sell_mandob add = new FRM_sell_mandob();
                        add.ID_travel = (int)ID_traval;
                        add.sellOrPage = 1;
                        add.ShowDialog();
                       
                        }
                        catch { MessageBox.Show(" - FRM_sell_mandob خطأ غير متوقع  "); }

                    }
              
                ID_traval = 0;
            }
        }
       

        private void BtnS_Sell_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == BtnS_Sell.Buttons[4])
            {
                try
                {
                    AddItemsToSell add = new AddItemsToSell();
                    add.AccORMandob = 0;
                   
                    add.ShowDialog();
                }
                catch { MessageBox.Show("خطأ غير متوقع - AddItemsToSell"); }

            }
            else if (e.Button == BtnS_Sell.Buttons[2])
            {
                try
                {
                    FRM_wasl add = new FRM_wasl();

                    add.ShowDialog();
                }
                catch { MessageBox.Show(" - FRM_wasl خطأ غير متوقع  "); }
            }
            else if (e.Button == BtnS_Sell.Buttons[0])
            {
                try
                {
                    FRM_sell_mandob add = new FRM_sell_mandob();
                    add.sellOrPage = 1;
                    add.ShowDialog();
                }
                catch { MessageBox.Show(" - FRM_sell_mandob خطأ غير متوقع  "); }
               
                /*try
                {
                    XtraReport_Retern report = new XtraReport_Retern();
                    report.Parameters["parameter1"].Value = ALIBA_COMPANY.AddPage.Users.Idd;
                    report.ShowPreview();
                }
                catch { MessageBox.Show("خطأ غير متوقع- BtnS_Sell"); }*/
            }
        }

        private void Btn_delete_import_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show(" هل تريد حذف بيانات الاستيراد؟", "تاكييد", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (rs == DialogResult.Yes)
            {
                
                using (var context = new AlibaRamyEntities())
                {
                    var ID_t = context.TB_temp.FirstOrDefault(x => x.user_id == AddPage.Users.Idd);
                    if (ID_t != null)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        ID_traval = ID_t.order_id;
                        var query = context.TB_details.Where(list => list.order_id == ID_traval).Select(list => new{ list.items_id,});

                        foreach (var listItem in query)
                        {
                            var UpdateSell_num = context.TB_details.FirstOrDefault(item => item.order_id == ID_traval && item.items_id == listItem.items_id);
                            if (UpdateSell_num != null)
                            {
                                UpdateSell_num.sell_num = 0;
                                context.Entry(UpdateSell_num).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                        var UpdateLoading = context.TB_travel.Where(item => item.tr_id == ID_traval&& item.user_id2==null).FirstOrDefault();
                        if (UpdateLoading != null)
                        {
                            UpdateLoading.tr_loading = 1;
                            context.Entry(UpdateLoading).State = System.Data.Entity.EntityState.Modified;
                        }
                        var listToDelete = context.TB_list.Where(item => item.tr_id == ID_traval).ToList();
                        if (listToDelete != null && listToDelete.Any())
                        {
                            context.TB_list.RemoveRange(listToDelete);
                        }

                        var listToDelete2 = context.TB_temp.Where(x => x.user_id == AddPage.Users.Idd).ToList();
                        if (listToDelete2 != null && listToDelete2.Any())
                        {
                            context.TB_temp.RemoveRange(listToDelete2);
                        }

                        context.SaveChanges();
                        MessageBox.Show("تم حذف البيانات المستوردة بنجاح ", "نجاح عملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ID_traval = 0;
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("لا تـوجد بيانـات مستوردة ", "لا توجد بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   

                }
            }
        }

        private void Btn_add_update_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show(" هل تريد تحديث بيانات الاستيراد؟", "تاكييد", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (rs == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Update_Data();
                Cursor.Current = Cursors.Default;
            }
        }
        private void Update_Data()
        {
            try
            { 
                using (var sourceContext = new AlibaRamyEntities())
                {
                    var ID_t = context.TB_temp.FirstOrDefault(x => x.user_id == AddPage.Users.Idd);
                    if (ID_t == null)
                    {

                        MessageBox.Show("لا يمكن التحديث", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var specificData = sourceContext.TB_str.Where(s => s.order_id == ID_t.order_id && s.action_id == 3 ).ToList();
                    if (specificData.Count == 0)
                    {
                        MessageBox.Show("ربما خطأ في التاريخ أو اسم الموزع", "لا توجد بيانات " + ID_traval, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                       

                        foreach (var item in specificData)
                        {
                            // التحقق من وجود القيمة في جدول TB_items
                            var existingItem = sourceContext.TB_items.FirstOrDefault(i => i.items_id == item.items_id);
                            if (existingItem != null)
                            {

                                var existingTemp = sourceContext.TB_temp.FirstOrDefault(t => t.items_id == item.items_id);

                                if (existingTemp != null)
                                {

                                    existingTemp.temp_num = item.str_num;
                                }
                                else
                                {

                                    var newItem = new TB_temp
                                    {
                                        temp_id = item.str_id,
                                        temp_num = item.str_num,
                                        temp_renum = item.str_renum,
                                        order_id = item.order_id,
                                        action_id = item.action_id,
                                        items_id = item.items_id,
                                        temp_date = item.str_date,
                                        user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                                    };
                                    sourceContext.TB_temp.Add(newItem);
                                }
                            }
                            else
                            {
                                // إشعار بأن القيمة غير موجودة في TB_items
                                MessageBox.Show($"القيمة {item.items_id} غير موجودة في جدول TB_items.", "خطأ يوجد مادة مفقودة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        sourceContext.SaveChanges();
                      
                        MessageBox.Show("تم تحديث البيانات بنجاح.", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطأ أثناء التحميل:Import_Data " + ex.Message);
            }
        }

    }
}
