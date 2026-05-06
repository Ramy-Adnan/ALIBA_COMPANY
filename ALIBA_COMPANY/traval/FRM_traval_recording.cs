using ALIBA_COMPANY.classes;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_traval_recording : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        private ALIBA_COMPANY.AlibaRamyEntities db;
        public int ID_traval = 0;
        int? ID_driver;
        public FRM_traval_recording()
        {
            InitializeComponent();
            db = new ALIBA_COMPANY.AlibaRamyEntities();
           

            gridView1.IndicatorWidth = 50;
            

            gridView1.RowCellStyle += OnRowCellStyle;
            gridView1.CustomColumnDisplayText += OnCustomColumnDisplayText;
        }
        private void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "col_Valid")
            {
                decimal? mark = view.GetRowCellValue(e.RowHandle, "details_renum") as decimal?;
                decimal? mark1 = view.GetRowCellValue(e.RowHandle, "details_num") as decimal?;
                decimal? mark2 = view.GetRowCellValue(e.RowHandle, "sell_num") as decimal?;

                if (mark.HasValue && mark1.HasValue && mark2.HasValue)
                {
                    if (mark > (mark1 - mark2) || mark < (mark1 - mark2))
                    {
                        e.Appearance.BackColor = Color.Brown;
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    }
                    else if (mark == (mark1 - mark2))
                    {
                        e.Appearance.BackColor = Color.DarkGreen;
                        e.Appearance.BackColor2 = Color.LightGreen;
                        e.Appearance.ForeColor = Color.White;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

                    }
                    else if (mark < 0)
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor2 = Color.White;
                        e.Appearance.BackColor = Color.Black;
                    }
                }
                else
                {
                    e.Appearance.BackColor = Color.BurlyWood;
                }
            }

        }

        private void OnCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "Col_items")
            {
                int id = GetItemId(view, e.ListSourceRowIndex);
                e.DisplayText = GetItemName(id);
            }
            else if (e.Column.FieldName == "col_Valid")
            {
                decimal num1 = GetValid1(view, e.ListSourceRowIndex);
                decimal num2 = GetValid2(view, e.ListSourceRowIndex);
                decimal num3 = GetValid3(view, e.ListSourceRowIndex);
                e.DisplayText = GetValid(num1, num2, num3);
            }
        }
        private int GetItemId(GridView view, int rowIndex)
        {
            object value = view.GetRowCellValue(rowIndex, "items_id");
            return value != null ? Convert.ToInt32(value) : -1000000000;
        }

        private string GetItemName(int id)
        {
            using (var context = new AlibaRamyEntities())
            {
                var item = context.TB_items.FirstOrDefault(i => i.items_id == id);
                return item != null ? item.items_name : "لا يوجد اسم لا توجد بيانات متطابقه";
            }
        }
        private string GetValid(decimal n1, decimal n2, decimal n3)
        {
            var result = n1 - n2 - n3;
            return result.ToString();
        }
        private decimal GetValid1(GridView view, int rowIndex)
        {
            object value = view.GetRowCellValue(rowIndex, "details_num");
            return value != null ? Convert.ToDecimal(value) : -1;
        }
        private decimal GetValid2(GridView view, int rowIndex)
        {
            object value = view.GetRowCellValue(rowIndex, "details_renum");
            return value != null ? Convert.ToDecimal(value) : 0;
        }
        private decimal GetValid3(GridView view, int rowIndex)
        {
            object value = view.GetRowCellValue(rowIndex, "sell_num");
            return value != null ? Convert.ToDecimal(value) : 0;
        }
        /// <summary>
        /// تمت برمجة هذا الكود بواسطة المهندس رامي خصيصا لشركة اللبه
        /// </summary>
        private async Task Load_Combo_Traval()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var TT = db.TB_travel
                    .Where(x => x.tr_sending == true && x.user_id2 == null).AsNoTracking()
                    .Select(x => x.TB_emplo.emplo_name)
                    .ToList();
                    TT.Insert(0, "");
                    Combo_Traval.DataSource = TT;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Combo_Traval: {ex.Message}");
            }
        }
        private void Set_ID_Traval()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {

                    var Idd = db.TB_travel
                    .Where(x => x.TB_emplo.emplo_name == Combo_Traval.SelectedItem.ToString() && x.tr_sending == true && x.user_id2 == null)
                    // .Select(x => x.tr_id)
                    .FirstOrDefault();
                    if (Idd != null)
                    {
                        ID_traval = Idd.tr_id;
                        ID_driver = Idd.emplo_id;
                    }
                    else
                    {
                        ID_traval = 0;
                        ID_driver = 0;
                    }
                }
            }
            catch { }
        }
        //private async void Load_GridView()
        //{//تحديث يجب اخذ بيانات المبيع من جدول ليت وليس ديتلز لتطابق المبيع مع الصاعد كونه يحدث خطا عند حذف ماده معينه من المخزن 
        //    try
        //    {
        //        if (!this.IsHandleCreated)
        //        {
        //            this.CreateHandle();
        //        }
        //        loading.Visible = true;

        //        var data = await Task.Run(() =>
        //        {
        //            var db = new AlibaRamyEntities();

        //                return db.TB_details
        //                    .Where(x => x.order_id == ID_traval)
        //                    .AsNoTracking()
        //                    .ToList();

        //        });

        //        this.Invoke((MethodInvoker)delegate
        //        {
        //            gridControl1.DataSource = data;
        //            loading.Visible = false;
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("حدث خطأ في الاتصال Load_GridView(): " + ex.Message);
        //        loading.Visible = false;
        //    }
        //}

        private async void Load_GridView()
        {
            try
            {
                if (!this.IsHandleCreated)
                    this.CreateHandle();

                loading.Visible = true;

                var data = await Task.Run(() =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        // الصاعد والراجع من TB_details
                        var details = db.TB_details
                            .Where(x => x.order_id == ID_traval)
                            .AsNoTracking()
                            .Select(d => new
                            {
                                d.items_id,
                                d.order_id,
                                details_num = d.details_num ?? 0,  // الصاعد
                                details_renum = d.details_renum ?? 0, // الراجع
                            })
                            .ToList();

                        // المبيوع الحقيقي من TB_det عبر TB_list
                        var sellFromDet = db.TB_det
                            .Where(x => x.TB_list.tr_id == ID_traval)
                            .GroupBy(x => x.items_id)
                            .Select(g => new
                            {
                                items_id = g.Key,
                                total_sell = g.Sum(x => x.de_num) ?? 0
                            })
                            .ToList();

                        // دمج كل items_id من المصدرين
                        var allItemIds = details.Select(d => d.items_id)
                            .Union(sellFromDet.Select(s => s.items_id))
                            .Distinct()
                            .ToList();

                        var result = allItemIds.Select(itemId => new
                        {
                            items_id = itemId,
                            order_id = ID_traval,

                            // الصاعد - من TB_details
                            details_num = details
                                .FirstOrDefault(d => d.items_id == itemId)
                                ?.details_num ?? 0,

                            // الراجع - من TB_details
                            details_renum = details
                                .FirstOrDefault(d => d.items_id == itemId)
                                ?.details_renum ?? 0,

                            // المبيوع - من TB_det + TB_list
                            sell_num = sellFromDet
                                .FirstOrDefault(s => s.items_id == itemId)
                                ?.total_sell ?? 0

                        }).ToList();

                        return result;
                    }
                });

                this.Invoke((MethodInvoker)delegate
                {
                    gridControl1.DataSource = data;
                    loading.Visible = false;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في Load_GridView(): " + ex.Message);
                loading.Visible = false;
            }
        }

        private async void FRM_traval_recording_Load(object sender, EventArgs e)
        {
           await Load_Combo_Traval();
        }
        private void Combo_Traval_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_Traval();
            Load_GridView();
            Set_values();
        }

        private void Set_values()
        {
            try
            {

                Lbl_Traval.Text = ID_traval.ToString("0");
                using (var context = new AlibaRamyEntities())
                {
                    var ItemClose1 = context.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);
                    if (ItemClose1 != null)
                    {
                        Lbl_car.Text = ItemClose1.TB_cars.car_name;
                    }
                    else
                    {
                        Lbl_car.Text = "0";
                    }
                    ////////////////////////////////////////////////credit
                    var credit1 = context.TB_cridet
                        .Where(x => x.tr_id == ID_traval&&x.emplo_id== ID_driver).AsQueryable().AsNoTracking()
                        .GroupBy(x => x.tr_id)
                        .Select(g => new
                        {
                            cridUSD = g.Sum(x => x.cridet_amount),
                            cridIQD = g.Sum(x => x.cridet_d),
                        })
                        .ToList();
                    if (credit1.Count > 0)
                    {
                        foreach (var result1 in credit1)
                        {
                            Lbl_criditYou_us.Text = result1.cridUSD.ToString();
                            Lbl_criditYou_iq.Text = result1.cridIQD.ToString();
                        }
                    }
                    else
                    {
                        Lbl_criditYou_us.Text = "0.00";
                        Lbl_criditYou_iq.Text = "0.00";
                    }
                    //-----------------------------------------------------
                    var credit2 = context.TB_cridet
                       .Where(x => x.tr_id == ID_traval && x.emplo_id != ID_driver).AsQueryable().AsNoTracking()
                       .GroupBy(x => x.tr_id)
                       .Select(g => new
                       {
                           cridUSD = g.Sum(x => x.cridet_amount),
                           cridIQD = g.Sum(x => x.cridet_d),
                       })
                       .ToList();
                    if (credit2.Count > 0)
                    {
                        foreach (var result2 in credit2)
                        {
                            Lbl_criditHim_us.Text = result2.cridUSD.ToString();
                            Lbl_criditHim_iq.Text = result2.cridIQD.ToString();
                        }
                    }
                    else
                    {
                        Lbl_criditHim_us.Text = "0.00";
                        Lbl_criditHim_iq.Text = "0.00";
                    }
                    //////////////////////////////////////////////////////////////////
                    var ItemClose3 = context.TB_list.Where(x => x.tr_id == ID_traval).Count();
                    if (ItemClose3 != 0)
                    {
                        Lbl_Wasel_num.Text = ItemClose3.ToString();
                    }
                    else
                    {
                        Lbl_Wasel_num.Text = 0.ToString();
                    }
                    var results = context.TB_list
                        .Where(x => x.tr_id == ID_traval).AsQueryable().AsNoTracking()
                        .GroupBy(x => 1)
                        .Select(g => new
                        {
                            TotalAmountUsd = g.Sum(x => x.list_amountUsd),
                            TotalAmountIq = g.Sum(x => x.list_amountIQ),
                            TotalcriditUsd = g.Sum(x => x.list_cridetUsd),
                            TotalcriditIq = g.Sum(x => x.list_cridetIQ),
                            TotalScashUsd = g.Sum(x => x.list_scashUsd),
                            TotalScashIQ = g.Sum(x => x.list_dcash),
                            Total_units = g.Sum(x => x.list_unit),
                        })
                        .ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            Lbl_AmuntUSD.Text = result.TotalAmountUsd.ToString();
                            Lbl_AmuntIRQ.Text = result.TotalAmountIq.ToString();
                            Lbl_criditUSD.Text = result.TotalcriditUsd.ToString();
                            Lbl_criditIRQ.Text = result.TotalcriditIq.ToString();
                            Lbl_CashUSD.Text = result.TotalScashUsd.ToString();
                            Lbl_CashIRQ.Text = result.TotalScashIQ.ToString();
                            Lbl_units.Text = result.Total_units.ToString();
                        }
                    }
                    else
                    {

                        Lbl_AmuntUSD.Text = "0.00";
                        Lbl_AmuntIRQ.Text = "0.00";
                        Lbl_criditUSD.Text = "0.00";
                        Lbl_criditIRQ.Text = "0.00";
                        Lbl_CashUSD.Text = "0.00";
                        Lbl_CashIRQ.Text = "0.00";
                        Lbl_fUSD.Text = "0.00";
                        Lbl_fIRQ.Text = "0.00";
                        Lbl_units.Text = "0";

                    }


                    //int totalItems = context.TB_details
                    //                        .Count(x => x.order_id == ID_traval && x.sell_num != 0);

                    // ✅ جديد - صحيح
                    int totalItems = context.TB_det
                        .Where(x => x.TB_list.tr_id == ID_traval)
                        .Select(x => x.items_id)
                        .Distinct()
                        .Count();
                    if (totalItems != 0)
                    {
                        Lbl_items.Text = totalItems.ToString("0");
                    }
                    else
                    {
                        Lbl_items.Text = 0.ToString("0");
                    }
                }
                  Lbl_fUSD.Text =(decimal.Parse(Lbl_CashUSD.Text) + decimal.Parse(Lbl_criditYou_us.Text)).ToString();
                  Lbl_fIRQ.Text = (decimal.Parse(Lbl_CashIRQ.Text) + decimal.Parse(Lbl_criditYou_iq.Text)).ToString();
 
                  Lbl_SCashUSD.Text = (decimal.Parse(Lbl_criditHim_us.Text)).ToString();
                  Lbl_SCashIRQ.Text = (decimal.Parse(Lbl_criditHim_iq.Text)).ToString();

                Lbl_Total_USD.Text = (decimal.Parse(Lbl_fUSD.Text) + decimal.Parse(Lbl_SCashUSD.Text)).ToString();
                Lbl_Total_IRQ.Text = (decimal.Parse(Lbl_fIRQ.Text) + decimal.Parse(Lbl_SCashIRQ.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Set_values()= حدث خطأ + : " + ex.Message);
            }
        }

        //private void Btn_SaveRecord_Click(object sender, EventArgs e)
        //{
        //    if (Combo_Traval.Text!="")
        //    {
        //        if (HascellZero())
        //        {
        //        try
        //        {
        //            var rs = MessageBox.Show(" هل تريد اغلاق السفرة؟", "تاكييد", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
        //            if (rs == DialogResult.Yes)
        //            {
        //                using (var context = new AlibaRamyEntities())
        //                {
        //                    var traval_add = context.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);

        //                    if (traval_add != null)
        //                    {
        //                        if (traval_add.tr_st_id==2)
        //                        {
        //                            var amount = decimal.Parse(Lbl_AmuntUSD.Text);
        //                            traval_add.tr_amount = amount;
        //                            traval_add.tr_amount_d = decimal.Parse(Lbl_AmuntIRQ.Text); ;
        //                            traval_add.tr_cash = decimal.Parse(Lbl_CashUSD.Text);
        //                            traval_add.tr_cash_d = decimal.Parse(Lbl_CashIRQ.Text);
        //                            traval_add.tr_cridet = decimal.Parse(Lbl_criditUSD.Text);
        //                            traval_add.tr_cridet_d = decimal.Parse(Lbl_criditIRQ.Text);

        //                            traval_add.tr_Scash = decimal.Parse(Lbl_fUSD.Text);
        //                            traval_add.tr_dcash = decimal.Parse(Lbl_fIRQ.Text);

        //                            traval_add.tr_recridetu = decimal.Parse(Lbl_criditYou_us.Text);
        //                            traval_add.tr_recridetu_d = decimal.Parse(Lbl_criditYou_iq.Text);
        //                            traval_add.tr_recrideth = decimal.Parse(Lbl_criditHim_us.Text);
        //                            traval_add.tr_recrideth_d = decimal.Parse(Lbl_criditHim_iq.Text);

        //                            traval_add.tr_dcashh = decimal.Parse(Lbl_SCashUSD.Text);
        //                            traval_add.tr_scashh = decimal.Parse(Lbl_SCashIRQ.Text);
        //                            traval_add.tr_sfinal = decimal.Parse(Lbl_Total_USD.Text);
        //                            traval_add.tr_dfinal = decimal.Parse(Lbl_Total_IRQ.Text);

        //                            traval_add.tr_p_it = decimal.Parse(Lbl_items.Text);
        //                            traval_add.tr_p_un = decimal.Parse(Lbl_units.Text);
        //                            traval_add.tr_luck = "نعم";
        //                            traval_add.tr_lists = int.Parse(Lbl_Wasel_num.Text);
        //                            traval_add.user_id2 = AddPage.Users.Idd;

        //                                if (amount <= 599)
        //                                {
        //                                    traval_add.tr_rate = 0;
        //                                }
        //                                else if (amount <= 1499 && amount > 599)
        //                                {
        //                                    traval_add.tr_rate = 50;
        //                                }
        //                                else if (amount <= 1999 && amount > 1499)
        //                                {
        //                                    traval_add.tr_rate = 75;
        //                                }
        //                                else if (amount > 1999)
        //                                {
        //                                    traval_add.tr_rate = 100;
        //                                }

        //                            traval_add.TB_emplo.emplo_traval_active = false;
        //                            traval_add.TB_cars.car_traval_active = false;

        //                            context.Entry(traval_add).State = System.Data.Entity.EntityState.Modified;
        //                            context.SaveChanges();
        //                            UpdateEmplo();
        //                            UpdateCar();
        //                            MessageBox.Show("تم اغلاق السفرة ", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                            // Add new notification
        //                            note = new Note();
        //                            pages.Notifications notifications = new pages.Notifications();
        //                            var Note = " تقييد حساب الموزع  " + Combo_Traval.Text;
        //                            note.AddNote(Note, notifications, "تقييد", 11);
        //                                _ = Load_Combo_Traval();
        //                            }
        //                        else
        //                        {
        //                            MessageBox.Show("يجب ادخال الراجع من قبل المخزن او الموافقه علية ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        }

        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show(" خطا في تحديد السفره : Btn_Record -traval_add", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    } 
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("حدث خطأ:Btn_SaveRecord_Click - connection " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        }
        //        else
        //        {
        //        MessageBox.Show("يوجد خطا في الراجع او المبيع ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("يرجى اختيار اسم الموزع", "لا توجد بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}


        // ✅ الكود الجديد
        private void Btn_SaveRecord_Click(object sender, EventArgs e)
        {
            if (Combo_Traval.Text == "")
            {
                MessageBox.Show("يرجى اختيار اسم الموزع", "لا توجد بيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!HascellZero())
            {
                MessageBox.Show("البيانات غير متطابقة الجرد غير صحيح", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rs = MessageBox.Show("هل تريد اغلاق السفرة؟", "تاكييد",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs != DialogResult.Yes) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (var context = new AlibaRamyEntities())
                {
                    var result = context.Database.SqlQuery<CloseResult>(
                        @"EXEC close_travel 
                  @tid, @user_id, 
                  @amount, @amount_d, 
                  @cash, @cash_d, 
                  @cridet, @cridet_d,
                  @scash, @dcash, 
                  @recridetu, @recridetu_d,
                  @recrideth, @recrideth_d, 
                  @dcashh, @scashh,
                  @sfinal, @dfinal, 
                  @items, @units, @lists",

                        new SqlParameter("@tid", ID_traval),
                        new SqlParameter("@user_id", AddPage.Users.Idd),
                        new SqlParameter("@amount", decimal.Parse(Lbl_AmuntUSD.Text)),
                        new SqlParameter("@amount_d", decimal.Parse(Lbl_AmuntIRQ.Text)),
                        new SqlParameter("@cash", decimal.Parse(Lbl_CashUSD.Text)),
                        new SqlParameter("@cash_d", decimal.Parse(Lbl_CashIRQ.Text)),
                        new SqlParameter("@cridet", decimal.Parse(Lbl_criditUSD.Text)),
                        new SqlParameter("@cridet_d", decimal.Parse(Lbl_criditIRQ.Text)),
                        new SqlParameter("@scash", decimal.Parse(Lbl_fUSD.Text)),
                        new SqlParameter("@dcash", decimal.Parse(Lbl_fIRQ.Text)),
                        new SqlParameter("@recridetu", decimal.Parse(Lbl_criditYou_us.Text)),
                        new SqlParameter("@recridetu_d", decimal.Parse(Lbl_criditYou_iq.Text)),
                        new SqlParameter("@recrideth", decimal.Parse(Lbl_criditHim_us.Text)),
                        new SqlParameter("@recrideth_d", decimal.Parse(Lbl_criditHim_iq.Text)),
                        new SqlParameter("@dcashh", decimal.Parse(Lbl_SCashUSD.Text)),
                        new SqlParameter("@scashh", decimal.Parse(Lbl_SCashIRQ.Text)),
                        new SqlParameter("@sfinal", decimal.Parse(Lbl_Total_USD.Text)),
                        new SqlParameter("@dfinal", decimal.Parse(Lbl_Total_IRQ.Text)),
                        new SqlParameter("@items", decimal.Parse(Lbl_items.Text)),
                        new SqlParameter("@units", decimal.Parse(Lbl_units.Text)),
                        new SqlParameter("@lists", int.Parse(Lbl_Wasel_num.Text))
                    ).FirstOrDefault();

                    if (result?.success == 1)
                    {
                        // إضافة الإشعار
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var noteText = "تقييد حساب الموزع " + Combo_Traval.Text;
                        note.AddNote(noteText, notifications, "تقييد", 11);

                        MessageBox.Show("تم اغلاق السفرة", "نجاح",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _ = Load_Combo_Traval();
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
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

       
        private bool allRowsEqualZero = true;
        private bool HascellZero()
        {
            allRowsEqualZero = true;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var Above_num = gridView1.GetRowCellValue(i, "details_num");
                var sell_back = gridView1.GetRowCellValue(i, "details_renum");
                var Sell_Num = gridView1.GetRowCellValue(i, "sell_num");

                if (Above_num != null && sell_back != null && Sell_Num != null)
                {
                    if (decimal.TryParse(Above_num.ToString(), out decimal aboveNumValue) &&
                        decimal.TryParse(sell_back.ToString(), out decimal sellBackValue) &&
                        decimal.TryParse(Sell_Num.ToString(), out decimal sellNumValue) &&
                        aboveNumValue - sellBackValue - sellNumValue != 0)
                    {
                        allRowsEqualZero = false;
                    }
                }
            }

            return allRowsEqualZero;
        }

        private void FRM_traval_recording_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            gridView1.RowCellStyle += OnRowCellStyle;
            gridView1.CustomColumnDisplayText += OnCustomColumnDisplayText;
            gridControl1.DataSource = null;

            if (db != null)
            {
                db.Dispose();
                db = null;
            }

            if (gridControl1 != null)
            {
                gridControl1.Dispose();
                gridControl1 = null;
            }
            CleanUpControls(this);
            GC.Collect();

        }
        private void CleanUpControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is IDisposable)
                {
                    (control as IDisposable).Dispose();
                }
                if (control.HasChildren)
                {
                    CleanUpControls(control);
                }
            }
        }
        //private void UpdateEmplo()
        //{
        //    using (db = new AlibaRamyEntities())
        //    {
        //        var emplo = db.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);

        //        if (emplo != null) 
        //        {

        //            emplo.TB_emplo.emplo_traval_active = false;
        //            db.Entry(emplo).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
                  
        //        }
        //        else
        //        {
                   
        //            MessageBox.Show("لم يتم العثور على السائق", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
        //private void UpdateCar()
        //{
        //    using (db = new AlibaRamyEntities())
        //    {
        //        var car = db.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);
        //        if (car != null)
        //        {
        //            car.TB_cars.car_traval_active = false;
        //            db.Entry(car).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            MessageBox.Show("لم يتم العثور على السياره", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
               
        //    }

        //}

       
    }
    // كلاس النتيجة - أضفه خارج الكلاس الرئيسي
    public class CloseResult
    {
        public int success { get; set; }
        public string message { get; set; }
    }

}

