using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.Sold;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.sold
{
    public partial class AddItemsToSell : DevExpress.XtraEditors.XtraForm
    {
        public int Traval_Id = 0;
        public decimal NumberSet;
        public decimal AmontSetUSD;
        public decimal AmontSetIRQ;
        public decimal SetNumberItems;
        public AddItemsToSell ClearGrid;

        public int AccORMandob { get; set; }
        public int EmploForAccountsForm_ID;
        public sold.FRM_sell page;

        public AddItemsToSell()
        {
            InitializeComponent();

            AddRowToGrid();
            BtnDeleteRow.Click += BtnDeleteRow_Click;
        }
        public decimal Number_of_grid(int id)
        {
            try
            {
                decimal total = 0;

              
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                   
                    if (row.Cells["ColumnID"].Value != null &&
                        int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int existingID) &&
                        existingID == id &&
                        row.Cells["ColumnNum"].Value != null &&
                        decimal.TryParse(row.Cells["ColumnNum"].Value.ToString(), out decimal num))
                    {
                       
                        total += num;
                    }
                }

              
                return total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" حدث خطا في الاتصال Number_of_grid: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private int Unique_ID_Count()
        {
            try
            {
                HashSet<int> uniqueIDs = new HashSet<int>();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    
                    if (row.Cells["ColumnID"].Value != null &&
                        int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int existingID))
                    {
                        uniqueIDs.Add(existingID); 
                    }
                }

                return uniqueIDs.Count; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في Unique_ID_Count: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void UpdateRowSequence()
        {
          
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells["ColumnSeq"].Value = (i + 1).ToString(); // (i + 1) لتسلسل يبدأ من 1
            }
        }


        private void AddRowToGrid()
        {
            // إضافة الأعمدة إلى DataGridView
            dataGridView2.AutoGenerateColumns = true;

            dataGridView2.RowTemplate.Height = 40;

            //  dataGridView2.Columns["ColumnNum"].Width = 300;

            // dataGridView2.Columns["ColumnPriceUsd"].Width = 200;

            // dataGridView2.Columns["ColumnAmountUsd"].Width = 200;

            // dataGridView2.Columns["ColumnPriceIR"].Width = 200;

            //  dataGridView2.Columns["ColumnAmountIRQ"].Width = 200;

            dataGridView2.Columns.Add("ColumnAmountIRQ", "المبلغ العراقي");
            dataGridView2.Columns["ColumnAmountIRQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Add("ColumnPriceIR", "السعر العراقي");
            dataGridView2.Columns["ColumnPriceIR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Add("ColumnAmountUsd", "المبلغ بالدولار");
            dataGridView2.Columns["ColumnAmountUsd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Add("ColumnPriceUsd", "السعر بالدولار");
            dataGridView2.Columns["ColumnPriceUsd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Add("ColumnNum", "العدد");
            dataGridView2.Columns["ColumnNum"].Width = 130;
            dataGridView2.Columns["ColumnNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Add("ColumnName", "الاســـم المتداول");
            dataGridView2.Columns["ColumnName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["ColumnName"].Width = 500;
            dataGridView2.Columns.Add("ColumnID", "رقم المادة");
         //   dataGridView2.Columns["ColumnID"].Width = 130;
            dataGridView2.Columns["ColumnID"].Visible = false;
            dataGridView2.Columns.Add("ColumnSeq", "ت");
            dataGridView2.Columns["ColumnSeq"].Width = 130;
            dataGridView2.Columns["ColumnSeq"].Visible = true;
            dataGridView2.AllowUserToAddRows = false;

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("الخاصية غير مفعلة في هذه النسخة", "مهندس رامي", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private int GetTraval_Id()
        {
            int lastTraval_Id = 0;
            try
            {
               
                if (AccORMandob == 0)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                       var w1 = (int)context.TB_temp.Where(x => x.user_id == AddPage.Users.Idd).Select(x => x.order_id).FirstOrDefault();
                        lastTraval_Id = w1;
                    }
                }
                else
                {
                     lastTraval_Id = Traval_Id;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا بجلب الايدي الايدي lastTraval_Id-Sell : " + ex.Message);
            }
            return lastTraval_Id;
        }
        private int GetList_Id()
        {
            int lastList_Id = 0;
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    lastList_Id = context.TB_list.OrderByDescending(o => o.list_id).Select(o => o.list_id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا بجلب الايدي الايدي lastList_Id-sell : " + ex.Message);
            }
            return lastList_Id;
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            
            using (FRM_AddNumberSell childForm = new FRM_AddNumberSell())
            {
                childForm.ID_traval2 = Traval_Id;
                childForm.AccORMandob = AccORMandob;
                childForm.Addd = this;
                if (childForm.ShowDialog() == DialogResult.OK)
                {
                    // تحصل على البيانات المدخلة من الفورم الفرعي
                    int id = childForm.IDValue;
                    string name = childForm.NameValue;
                    decimal number = childForm.numberValue;
                    decimal priceUSD = childForm.priceUSD;
                    decimal priceIRD = childForm.priceIRD;
                    decimal amuntUSD = childForm.amuntUSD;
                    decimal amuntIRD = childForm.amuntIRD;

                    // إضافة البيانات إلى DataGridView في الفورم الرئيسي
                    if (IsItemAlreadyAdded(id, priceUSD))
                    {
                        MessageBox.Show("المادة موجودة بالقائمة و بنفس السعر \n  لا يمكن بيعها مره ثانيه بنفس الوصل \n الا بغير سعر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        dataGridView2.Rows.Add(amuntIRD, priceIRD, amuntUSD, priceUSD,number ,name , id);
                    }
                    Count();
                }
            }
        }
        private void Count()
        {
           
            if (dataGridView2.Rows.Count > 0)
            {
                UpdateRowSequence();
                decimal rowCount = Unique_ID_Count();
                SetNumberItems = rowCount;
                lblcount.Text = rowCount.ToString();

                decimal totalNumber = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    object cellValue = row.Cells["ColumnNum"].Value;
                    if (cellValue != null)
                    {
                        if (decimal.TryParse(cellValue.ToString(), out decimal value))
                        {
                            totalNumber += value;
                        }
                    }
                }
                lblPaces.Text = totalNumber.ToString();
                NumberSet = totalNumber;

                decimal totalAmountUsd = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    object cellValue = row.Cells["ColumnAmountUsd"].Value;
                    if (cellValue != null)
                    {
                        if (decimal.TryParse(cellValue.ToString(), out decimal value))
                        {
                            totalAmountUsd += value;
                        }
                    }
                }
                LblAmountUsd.Text = totalAmountUsd.ToString();
                AmontSetUSD = totalAmountUsd;

                decimal totalAmountIRQ = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    object cellValue = row.Cells["ColumnAmountIRQ"].Value;
                    if (cellValue != null)
                    {
                        if (decimal.TryParse(cellValue.ToString(), out decimal value))
                        {
                            totalAmountIRQ += value;
                        }
                    }
                }
                LblAmountIRQ.Text = totalAmountIRQ.ToString("N0");
                AmontSetIRQ = totalAmountIRQ;
            }
            else
            {
               
                lblcount.Text = "0";
                lblPaces.Text = "0";
                LblAmountUsd.Text = "0";
                LblAmountIRQ.Text = "0";
                SetNumberItems = 0;
                NumberSet = 0;
                AmontSetUSD = 0;
                AmontSetIRQ = 0;
            }
        }

        private bool IsItemAlreadyAdded(int id, decimal usd)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ColumnID"].Value != null &&
                    int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int existingID) &&
                    existingID == id &&
                    row.Cells["ColumnPriceUsd"].Value != null &&
                    decimal.TryParse(row.Cells["ColumnPriceUsd"].Value.ToString(), out decimal existingUsd) &&
                    existingUsd == usd)
                {
                    return true;
                }
            }
            return false;
        }
        public void SaveData()
        {
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    var Traval_Id = GetTraval_Id();
                    var list_Id = GetList_Id();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        // التحقق من عدم وجود خلية فارغة في الصف
                        if (row.Cells["ColumnID"].Value != null &&
                            row.Cells["ColumnNum"].Value != null &&
                            row.Cells["ColumnPriceUsd"].Value != null &&
                            row.Cells["ColumnPriceIR"].Value != null &&
                            row.Cells["ColumnAmountUsd"].Value != null &&
                            row.Cells["ColumnAmountIRQ"].Value != null &&
                            int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int IDitems) &&
                            decimal.TryParse(row.Cells["ColumnNum"].Value.ToString(), out decimal numberOfitems) &&
                            decimal.TryParse(row.Cells["ColumnPriceUsd"].Value.ToString(), out decimal PriceUsd) &&
                            decimal.TryParse(row.Cells["ColumnPriceIR"].Value.ToString(), out decimal PriceIR) &&
                            decimal.TryParse(row.Cells["ColumnAmountUsd"].Value.ToString(), out decimal AmountUsd) &&
                            decimal.TryParse(row.Cells["ColumnAmountIRQ"].Value.ToString(), out decimal AmountIRQ))
                        {
                           
                            context.TB_det.Add(new TB_det
                            {
                                list_id = list_Id,
                                items_id = IDitems,
                                de_costUsd = PriceUsd,
                                de_totalUsd = AmountUsd,
                                de_num = numberOfitems,
                                de_costIQ = PriceIR,
                                de_totalIQ = AmountIRQ,
                                sending = false
                            });

                            if (AccORMandob == 0)
                            {
                                var selectedItem = context.TB_temp.FirstOrDefault(x => x.items_id == IDitems && x.order_id == Traval_Id);
                                if (selectedItem != null)
                                {
                                    selectedItem.temp_renum += numberOfitems;
                                    context.Entry(selectedItem).State = System.Data.Entity.EntityState.Modified;
                                }
                                else
                                {
                                    MessageBox.Show("خطا في البيع Save()TB_temp", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                var ItemSell1 = context.TB_details.FirstOrDefault(x => x.order_id == Traval_Id && x.items_id == IDitems);
                                if (ItemSell1 != null)
                                {
                                    ItemSell1.sell_num = (ItemSell1.sell_num ?? 0) + numberOfitems;
                                    ItemSell1.sending = false;
                                    context.Entry(ItemSell1).State = System.Data.Entity.EntityState.Modified;
                                }
                                else
                                {
                                    MessageBox.Show("خطا في البيانات المباعة للمندوب Save()TB_details", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else if (AccORMandob == 1)
                            {
                                string sqlQuery4 = "DELETE FROM TB_temp WHERE order_id = @orderId";
                                context.Database.ExecuteSqlCommand(sqlQuery4, new SqlParameter("@orderId", Traval_Id));
                                string sqlQuery5 = "DELETE FROM TB_list WHERE tr_id = @orderId and sending = 0";
                                context.Database.ExecuteSqlCommand(sqlQuery5, new SqlParameter("@orderId", Traval_Id));


                                var ItemSell = context.TB_details.FirstOrDefault(x => x.order_id == Traval_Id && x.items_id == IDitems);
                                if (ItemSell != null)
                                {
                                    ItemSell.sell_num = (ItemSell.sell_num ?? 0) + numberOfitems;
                                    ItemSell.sending = true;
                                    context.Entry(ItemSell).State = System.Data.Entity.EntityState.Modified;
                                }
                                else
                                {
                                    MessageBox.Show("خطا في البيانات المباعة Save()TB_details", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                        {
                           
                            MessageBox.Show("Invalid row data. Please check the inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveData()_sell  حدث خطأ في ادخال المواد: " + ex.Message + "\nالتفاصيل: " + ex.StackTrace, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearDataGridView()
        {
           
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
           
        }

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView2.Rows.Remove(row);
                    Count();
                }
            }
        }

        private void Btn_Agg_Click(object sender, EventArgs e)
        {
            if (SetNumberItems == 0)
            {
                MessageBox.Show("لا توجد مواد", "اشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FRM_Save_Sell Add = new FRM_Save_Sell();
                Add.Txt_number.Text = SetNumberItems.ToString();
                Add.Txt_pacess.Text = NumberSet.ToString();
                Add.Txt_AmountUsd.Text = AmontSetUSD.ToString();
                Add.Txt_AmountIRQ.Text = AmontSetIRQ.ToString("N0");
                Add.AccORMandob = AccORMandob;
                Add.Traval_Id = Traval_Id;
                Add.EmploForAccountsForm_ID = EmploForAccountsForm_ID;
                Add.Addd = this;
                Add.FormClosed += (s, args) =>
                {
                    if (Add.DialogResult == DialogResult.OK)
                    {
                        ClearDataGridView(); // تحديث البيانات في الفورم الأول بعد الإضافة
                        lblcount.Text = "0";
                        lblPaces.Text = "0";
                        LblAmountUsd.Text = "0";
                        LblAmountIRQ.Text = "0";
                        SetNumberItems = 0;
                        NumberSet = 0;
                        AmontSetUSD = 0;
                        AmontSetIRQ = 0;
                    }
                };
                Add.ShowDialog();
            }
        }

        private void AddItemsToSell_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
          
           
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
  
