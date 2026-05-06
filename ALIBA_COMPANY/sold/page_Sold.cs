using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.other;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ALIBA_COMPANY.sold
{
    public partial class page_Sold : DevExpress.XtraEditors.XtraUserControl
    {
        private AlibaRamyEntities context;
        public int? ID_traval=0;
        public string EmploName;
        public int EmploId;
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

                    
                    GetIDandName_emplo();

                }
                
            }
        }
        private void GetIDandName_emplo()
        {
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    var orderId = context.TB_temp
                        .FirstOrDefault(e => e.user_id == AddPage.Users.Idd);

                    if (orderId != null)
                    {
                        var employeeName = context.TB_travel
                            .Where(u => u.tr_id == orderId.order_id)
                            .Select(u => new { u.TB_emplo.emplo_name, u.TB_emplo.emplo_id })
                            .FirstOrDefault();
                        lbl_status.ForeColor = Color.Green;
                        lbl_status.Text = $"الان سفرة الموزع ({employeeName.emplo_name}) رقم ({orderId.order_id}) متاحة للعمل";
                        EmploName = employeeName.emplo_name;
                        EmploId= employeeName.emplo_id;
                        ID_traval=orderId.order_id;

                    }
                    else
                    {
                        lbl_status.Text = "لا توجد أي سفرة الآن ... ابدأ بإستيراد سفرتك";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }

        private void Btn_add_export_Click(object sender, EventArgs e)
        {
            using (var context = new AlibaRamyEntities())
            {
                // ✅ التحقق من وجود سفرة
                var ID_t = context.TB_temp.FirstOrDefault(x => x.user_id == AddPage.Users.Idd);
                if (ID_t == null)
                {
                    try { Notifications.ShowToast("خطأ", "لا تـوجد بيانـات لارسالـهـا"); } catch { }
                    return;
                }

                ID_traval = ID_t.order_id;

                // ✅ التحقق من البيانات
                bool hasPending = context.TB_list.Any(x => x.tr_id == ID_traval && x.sending == false);
                bool hasSent = context.TB_list.Any(x => x.tr_id == ID_traval && x.sending == true);

                if (!hasPending)
                {
                    try { Notifications.ShowToast("خطأ", "لا تـوجد بيانـات لارسالـهـا"); } catch { }
                    return;
                }

                if (hasSent)
                {
                    MessageBox.Show("يوجد وصولات سابقة تمت اضافتها من قبل الحسابات\nيجب حذف تلك الوصولات ثم المحاولة مرة اخرى",
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ سؤال الطباعة
                var result = MessageBox.Show("اذا نسيت طباعة الراجع\nNo اضغط\nواذا كملت طباعة\nYes اضغط",
                    "انتبه رجاءاً", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    try
                    {
                        FRM_sell_mandob add = new FRM_sell_mandob
                        {
                            ID_travel = (int)ID_traval,
                            sellOrPage = 1
                        };
                        add.ShowDialog();
                    }
                    catch { MessageBox.Show("خطأ غير متوقع - FRM_sell_mandob"); }
                    return;
                }

                // ✅ الإرسال بـ SQL مباشر (سريع جداً)
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    // تحديث السفرة
                    context.Database.ExecuteSqlCommand(
                        "UPDATE TB_travel SET tr_loading=0, tr_sending=1 WHERE tr_id=@p0", ID_traval);

                    // تحديث التفاصيل
                    context.Database.ExecuteSqlCommand(@"
                UPDATE TB_details 
                SET sending=1, sell_num=ISNULL(sell_num, 0.000)
                WHERE order_id=@p0", ID_traval);

                    // تحديث القائمة
                    context.Database.ExecuteSqlCommand(
                        "UPDATE TB_list SET sending=1 WHERE tr_id=@p0", ID_traval);

                    // تحديث وصولات التحصيل (إذا وجدت)
                    context.Database.ExecuteSqlCommand(@"
                         UPDATE TB_cridet SET sending=1 
                         WHERE user_id=@p0 AND tr_id=@p1 AND sending=0",
                        AddPage.Users.Idd, ID_traval);

                    // حذف السفرة المؤقتة
                    context.Database.ExecuteSqlCommand(
                        "DELETE FROM TB_temp WHERE order_id=@p0", ID_traval);

                    // ✅ تحديث الواجهة
                    lbl_status.ForeColor = Color.Gray;
                    lbl_status.Text = "لا توجد أي سفرة الآن ... ابدأ بإستيراد سفرتك";
                    try { Notifications.ShowToast("نـجاح", "تــم ارســال البيانــات بـنجاح"); } catch { }
                    ID_traval = 0;
                    EmploId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الإرسال:\n" + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    ID_traval = 0;
                }
            }
        }


        private void BtnS_Sell_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == BtnS_Sell.Buttons[0])
            {
                try
                {
                    ERM_cash Add = new ERM_cash();

                    Add.AccountsOrMandob = 2;
                    Add.ID_traval_MandobForm = (int)ID_traval;
                    Add.emplo_id_fromPage_soldorAccount = EmploId;

                    Add.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error ERM_cash" + ex.Message);
                }

            }
            else if (e.Button == BtnS_Sell.Buttons[2])
            {
                try
                {
                    FRM_sell_mandob add = new FRM_sell_mandob();
                    add.sellOrPage = 1;
                    add.ShowDialog();
                }
                catch { MessageBox.Show(" - FRM_sell_mandob خطأ غير متوقع  "); }

            }
            else if (e.Button == BtnS_Sell.Buttons[4])
            {
                try
                {
                    FRM_wasl add = new FRM_wasl();

                    add.ShowDialog();
                }
                catch { MessageBox.Show(" - FRM_wasl خطأ غير متوقع  "); }
            }
            else if (e.Button == BtnS_Sell.Buttons[6])
            {
                

                try
                {
                    AddItemsToSell add = new AddItemsToSell();
                    add.AccORMandob = 0;

                    add.ShowDialog();
                }
                catch { MessageBox.Show("خطأ غير متوقع - AddItemsToSell"); }
            }

        }

        private void Btn_delete_import_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("هل تريد حذف بيانات الاستيراد؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var context = new AlibaRamyEntities())
            {
                var ID_t = context.TB_temp.FirstOrDefault(x => x.user_id == AddPage.Users.Idd);
                if (ID_t == null)
                {
                    try { Notifications.ShowToast("تنبيه", "لا تـوجد بيانـات مستوردة"); } catch { }
                    return;
                }

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ID_traval = ID_t.order_id;

                    // ✅ تصفير sell_num
                    context.Database.ExecuteSqlCommand(
                        "UPDATE TB_details SET sell_num=0 WHERE order_id=@p0", ID_traval);

                    // ✅ إعادة tr_loading إلى 1
                    context.Database.ExecuteSqlCommand(
                        "UPDATE TB_travel SET tr_loading=1 WHERE tr_id=@p0 AND user_id2 IS NULL", ID_traval);

                    // ✅ حذف القائمة
                    context.Database.ExecuteSqlCommand(
                        "DELETE FROM TB_list WHERE tr_id=@p0", ID_traval);

                    // ✅ حذف وصولات التحصيل غير المرسلة
                    context.Database.ExecuteSqlCommand(
                        "DELETE FROM TB_cridet WHERE user_id=@p0 AND  tr_id=@p1 AND sending=0",
                        AddPage.Users.Idd,ID_traval);

                    // ✅ حذف السفرة المؤقتة
                    context.Database.ExecuteSqlCommand(
                        "DELETE FROM TB_temp WHERE user_id=@p0", AddPage.Users.Idd);

                    lbl_status.ForeColor = Color.Gray;
                    lbl_status.Text = "لا توجد أي سفرة الآن ... ابدأ بإستيراد سفرتك";
                    try { Notifications.ShowToast("نجاح", "تم حذف البيانات المستوردة بنجاح"); } catch { }
                    ID_traval = 0;
                    EmploId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف:\n" + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ID_traval = 0;
                    Cursor.Current = Cursors.Default;
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
                    var ID_t = sourceContext.TB_temp
                        .FirstOrDefault(x => x.user_id == AddPage.Users.Idd);

                    if (ID_t == null)
                    {
                        MessageBox.Show("لا يمكن التحديث", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var specificData = sourceContext.TB_str
                        .Where(s => s.order_id == ID_t.order_id && s.action_id == 3)
                        .ToList();

                    if (!specificData.Any())
                    {
                        MessageBox.Show("ربما خطأ في التاريخ أو اسم الموزع",
                            "لا توجد بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var itemIds = specificData.Select(s => s.items_id).ToList();

                    // ✅ جلب كل temp الخاص بهذه السفرة
                    var allExistingTemps = sourceContext.TB_temp
                        .Where(t => t.order_id == ID_t.order_id && t.user_id == AddPage.Users.Idd)
                        .ToList();

                    // ✅ تصحيح: التحقق من null قبل التحويل
                    var tempsToProcess = allExistingTemps
                        .Where(t => t.items_id.HasValue && !itemIds.Contains(t.items_id.Value))
                        .ToList();

                    foreach (var temp in tempsToProcess)
                    {
                        if (temp.temp_renum > 0)
                        {
                            // ✅ لها وصل بيع - احذف الوصل تلقائياً
                            sourceContext.Database.ExecuteSqlCommand(@"
                        DELETE FROM TB_det 
                        WHERE items_id=@p0 
                        AND list_id IN (
                            SELECT list_id FROM TB_list 
                            WHERE tr_id=@p1 AND sending=0
                        )", temp.items_id.Value, ID_t.order_id);

                            // ✅ احذف الوصل إذا أصبح فارغاً
                            sourceContext.Database.ExecuteSqlCommand(@"
                        DELETE FROM TB_list 
                        WHERE tr_id=@p0 AND sending=0
                        AND list_id NOT IN (
                            SELECT DISTINCT list_id FROM TB_det
                        )", ID_t.order_id);

                            sourceContext.TB_temp.Remove(temp);

                            MessageBox.Show(
                                $"تنبيه: المادة رقم {temp.items_id} تم حذفها من السفرة\n" +
                                "وتم حذف وصل البيع المرتبط بها تلقائياً",
                                "تم الحذف التلقائي", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // ✅ لا يوجد وصل بيع - احذف مباشرة
                            sourceContext.TB_temp.Remove(temp);
                        }
                    }

                    // ✅ التحقق من المواد المفقودة في TB_items
                    var existingItems = sourceContext.TB_items
                        .Where(i => itemIds.Contains(i.items_id))
                        .Select(i => i.items_id)
                        .ToHashSet();

                    var missingItems = itemIds.Where(id => !existingItems.Contains(id)).ToList();
                    if (missingItems.Any())
                    {
                        MessageBox.Show(
                            "المواد المفقودة:\n" + string.Join("\n", missingItems),
                            "يوجد مواد مفقودة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ تحديث أو إضافة المواد
                    var existingTemps = allExistingTemps
                        .Where(t => t.items_id.HasValue && itemIds.Contains(t.items_id.Value))
                        .ToList();

                    foreach (var item in specificData)
                    {
                        var existingTemp = existingTemps
                            .FirstOrDefault(t => t.items_id == item.items_id);

                        if (existingTemp != null)
                        {
                            existingTemp.temp_num = item.str_num;
                        }
                        else
                        {
                            sourceContext.TB_temp.Add(new TB_temp
                            {
                                temp_id = item.str_id,
                                temp_num = item.str_num,
                                temp_renum = item.str_renum,
                                order_id = item.order_id,
                                action_id = item.action_id,
                                items_id = item.items_id,
                                temp_date = item.str_date,
                                user_id = AddPage.Users.Idd,
                            });
                        }
                    }

                    sourceContext.SaveChanges();
                    try { Notifications.ShowToast("نجاح", "تم تحديث البيانات بنجاح"); } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحديث:\n" + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void page_Sold_Load(object sender, EventArgs e)
        {
            GetIDandName_emplo();
        }
    }
}
