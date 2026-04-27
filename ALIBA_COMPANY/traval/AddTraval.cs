using ALIBA_COMPANY.classes;
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

namespace ALIBA_COMPANY.traval

{
    public partial class AddTraval : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        public FRM_Save_Traval_create date;
        public int ID_travel { get; set; }
        public decimal NumberSet;
        public decimal SetNumberItems;
        public AddTraval ClearGrid;
        public int lastOrderId ; 

        private List<TravelItem> travelItems = new List<TravelItem>();
        public AddTraval()
        {
            InitializeComponent();
           
        }
     
        private void DataGridView2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < travelItems.Count)
            {
                var item = travelItems[e.RowIndex];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = item.ID;
                        break;
                    case 1:
                        e.Value = item.Name;
                        break;
                    case 2:
                        e.Value = item.Number;
                        break;
                    case 3:
                        e.Value = item.Category;
                        break;
                    case 4:
                        e.Value = item.Formm;
                        break;
                }
            }
        }

        private void DataGridView2_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < travelItems.Count)
            {
                var item = travelItems[e.RowIndex];
                switch (e.ColumnIndex)
                {
                    case 0:
                        item.ID = (int?)e.Value;
                        break;
                    case 1:
                        item.Name = (string)e.Value;
                        break;
                    case 2:
                        item.Number = (decimal?)e.Value;
                        break;
                    case 3:
                        item.Category = (string)e.Value;
                        break;
                    case 4:
                        item.Formm = (string)e.Value;
                        break;
                }
            }
        }
        private void LoadGrid()
        {
            if (ID_travel > 0)
            {
                using (var context = new AlibaRamyEntities())
                {
                   
                    var items = context.TB_details.Where(v=>v.order_id== ID_travel && v.action_id == 3).ToList();
                    /*var totalDetailsRenum = context.TB_details
                                                     .Where(v => v.order_id == ID_travel && v.action_id == 3)
                                                     .Sum(v => v.details_renum);*/

                    var items1 = context.TB_list.Where(v => v.tr_id == ID_travel && v.sending == true).ToList();
                    if ( items1.Count>0)
                    {
                        MessageBox.Show("تاكد ان السفرة غير مرسلة اذا كانت مرسلة يجب حذف الوصولات \n اولا ثم التعديل لطفاً", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else {
                        foreach (var item in items)
                        {
                            travelItems.Add(new TravelItem
                            {
                                ID = item.items_id,
                                Name = item.TB_items.items_name,
                                Number = item.details_num,
                                Category = item.TB_items.TB_groups.groups_name,
                                Formm = item.TB_items.items_form
                            });

                        }
                    }
                    
                  
                    dataGridView2.RowCount = travelItems.Count;
                   
                }

                Count();
            }
        }
        private void AddRowToGrid()
        {
            if (ID_travel == 0)
            {
               
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Columns.Add("ColumnID", "رقم المادة");
                dataGridView2.Columns["ColumnID"].Width = 100;
                dataGridView2.Columns["ColumnID"].Visible = true;
                dataGridView2.Columns.Add("ColumnName", "الاسم");
                dataGridView2.Columns["ColumnName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns["ColumnName"].Width = 500;
                dataGridView2.RowTemplate.Height = 30;
                dataGridView2.Columns.Add("ColumnNum", "العدد");
                dataGridView2.Columns["ColumnNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns["ColumnNum"].Width = 300;
                dataGridView2.Columns.Add("ColumnGat", "الصنف");
                dataGridView2.Columns["ColumnGat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns["ColumnGat"].Width = 200;
                dataGridView2.Columns.Add("ColumnForm", "التجزئة");
                dataGridView2.Columns["ColumnForm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns["ColumnForm"].Width = 200;
            }
            else
            {
                dataGridView2.AutoGenerateColumns = false;

                // إنشاء الأعمدة
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    Visible = true,
                    HeaderText = "رقم المادة",
                    Width = 100
                };
                idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(idColumn);

                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "الاسم",
                    Width = 1000
                };
                nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(nameColumn);

                DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Number",
                    HeaderText = "العدد",
                    Width = 300
                };
                numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(numberColumn);

                DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Category",
                    HeaderText = "الصنف",
                    Width = 100
                };
                categoryColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(categoryColumn);

                DataGridViewTextBoxColumn formmColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Formm",
                    HeaderText = "التجزئة",
                    Width = 100
                };
                formmColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(formmColumn);

                // تعيين DataPropertyName بعد إضافة الأعمدة
                dataGridView2.Columns["ID"].DataPropertyName = "ID";
                dataGridView2.Columns["Name"].DataPropertyName = "Name";
                dataGridView2.Columns["Number"].DataPropertyName = "Number";
                dataGridView2.Columns["Category"].DataPropertyName = "Category";
                dataGridView2.Columns["Formm"].DataPropertyName = "Formm";


                // إضافة عمود زر الحذف
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "DeleteButtonColumn",
                    HeaderText = "",
                    Text = "حذف",
                    Width = 75,
                    UseColumnTextForButtonValue = true
                };
                deleteButtonColumn.DefaultCellStyle.BackColor = Color.LightCoral;
                deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
                deleteButtonColumn.FlatStyle = FlatStyle.Popup; // نمط الزر
                dataGridView2.Columns.Add(deleteButtonColumn);
               
            }
        }
            
        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
          
            MessageBox.Show("الخاصية غير مفعلة في هذه النسخة", "مهندس رامي", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
        private int GetOrderId()
        {
            int lastOrderId = 0;
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    lastOrderId = context.TB_travel
                        .Where(o => o.user_id2 == null )
                        .OrderByDescending(o => o.tr_id)                      
                        .Select(o => o.tr_id)                                
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error connection or lastOrderId is null" + ex.Message);
            }
            this.lastOrderId = lastOrderId;
            return lastOrderId;
        }
        public decimal Number_of_grid(int id)
        {
            try
            {
                decimal total = 0;

                if (ID_travel==0)
                {
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
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {

                        if (row.Cells["ID"].Value != null &&
                            int.TryParse(row.Cells["ID"].Value.ToString(), out int existingID) &&
                            existingID == id &&
                            row.Cells["Number"].Value != null &&
                            decimal.TryParse(row.Cells["Number"].Value.ToString(), out decimal num))
                        {

                            total += num;
                        }
                    }
                }
               


                return total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" في هذه الدالة او الاتصال Number_of_grid: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void Btn_add_Click(object sender, EventArgs e)
        {
           
            using (FRM_AddNumber childForm = new FRM_AddNumber())
            {
                childForm.Addd = this;
                if (childForm.ShowDialog() == DialogResult.OK)
                {
                    
                    int id = childForm.IDValue;
                    string name = childForm.NameValue;
                    decimal number = childForm.numberValue;
                    string gatgory = childForm.gatgoryValue;
                    string formm = childForm.formmValue;

                    
                    if (IsItemAlreadyAdded(id))
                    {
                        MessageBox.Show("المادة موجودة بالقائمة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ID_travel == 0)
                        {
                            dataGridView2.Rows.Add(id, name, number, gatgory, formm);
                        }
                        else
                        {
                            travelItems.Add(new TravelItem { ID = id, Name = name, Number = number, Category = gatgory, Formm = formm });
                            dataGridView2.RowCount = travelItems.Count;
                        }
                    }
                    Count();
                }
            }
        }
        private bool IsItemAlreadyAdded(int id)
        {
            if (ID_travel==0)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["ColumnID"].Value != null &&
                        int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int existingID) &&
                        existingID == id)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return travelItems.Any(item => item.ID == id);
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
                if (ID_travel == 0)
                {
                    FRM_Save_Traval_create Add = new FRM_Save_Traval_create();
                    Add.Txt_number.Text = SetNumberItems.ToString();
                    Add.Txt_pacess.Text = NumberSet.ToString();
                    Add.Addd = this;
                    Add.FormClosed += (s, args) =>
                    {
                        if (Add.DialogResult == DialogResult.OK)
                        {
                            ClearDataGridView(); 
                            lblcount.Text = "0";
                            lblPaces.Text = "0";
                        }
                    };
                    Add.ShowDialog();
                }
                // Edit
                else
                {
                  
                    var confirmationResult = MessageBox.Show("هل تريد التعديل؟", "تأكيد التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmationResult == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (var context = new AlibaRamyEntities())
                        {
                           
                            var existingStrRecords = context.TB_str.Where(o => o.order_id == ID_travel).ToList();
                            var existingDetailsRecords = context.TB_details.Where(o => o.order_id == ID_travel).ToList();

                           
                            foreach (var existingStr in existingStrRecords)
                            {
                                if (!travelItems.Any(item => item.ID == existingStr.items_id))
                                {
                                    context.TB_str.Remove(existingStr);
                                }
                            }

                            foreach (var existingDetails in existingDetailsRecords)
                            {
                                if (!travelItems.Any(item => item.ID == existingDetails.items_id))
                                {
                                    context.TB_details.Remove(existingDetails);
                                }
                            }

                            foreach (var item in travelItems)
                            {
                                //تحديث
                                var existingStr = context.TB_str.FirstOrDefault(o => o.order_id == ID_travel && o.items_id == item.ID);

                                var CallSameDateOfTraver = context.TB_travel.FirstOrDefault(o => o.tr_id == ID_travel);

                                if (existingStr != null)
                                {
                                   
                                    existingStr.str_num = item.Number * -1;
                                    existingStr.str_renum = 0;
                                    existingStr.action_id = 3;
                                }
                                else
                                {
                                    // اضافة
                                    context.TB_str.Add(new TB_str
                                    {
                                        order_id = ID_travel,
                                        items_id = (int)item.ID,
                                        str_date = (DateTime)CallSameDateOfTraver.tr_date,
                                        str_num = item.Number * -1,
                                        str_renum = 0,
                                        action_id = 3
                                    });
                                }

                                //تحديث
                                var existingDetails = context.TB_details.FirstOrDefault(o => o.order_id == ID_travel && o.items_id == item.ID);
                                if (existingDetails != null)
                                {
                                    existingDetails.details_num = item.Number;
                                    existingDetails.details_renum = 0;
                                    existingDetails.action_id = 3;
                                    existingDetails.sending = false;
                                }
                                else
                                {
                                    //اضافة
                                    context.TB_details.Add(new TB_details
                                    {
                                        order_id = ID_travel,
                                        items_id = item.ID,
                                        details_num = item.Number,
                                        details_renum = 0,
                                        action_id = 3,
                                        sending = false
                                    });
                                }
                            }

                            // تحديث السجل في TB_travel
                            var Travel_items = context.TB_travel.FirstOrDefault(o => o.tr_id == ID_travel);
                            if (Travel_items != null)
                            {
                                Travel_items.tr_items = decimal.Parse(lblcount.Text);
                                Travel_items.tr_unit = decimal.Parse(lblPaces.Text);
                                context.Entry(Travel_items).State = System.Data.Entity.EntityState.Modified;
                            }

                            context.SaveChanges();

                            // إضافة إشعار جديد
                            note = new Note();
                            pages.Notifications notifications = new pages.Notifications();
                            var Note = " تعديل السفرة " + ID_travel;
                            note.AddNote(Note, notifications, "تعديل", 4);

                            MessageBox.Show("تم تعديل السفرة بنجاح");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }

                    Cursor.Current = Cursors.Default;
                    }

                
            }
           
        }
        public void SaveData(DateTime selectedDate)
        {
            using (var context = new AlibaRamyEntities())
            {
                   
                var orderId = GetOrderId();
                MessageBox.Show( "رقم السفرة  الجديدة =" + orderId );
                if (orderId == 0)
                {
                    MessageBox.Show("حدثت مشكلة لم يتم انشاء السفره \n السفره لم تكتمل  \n يجب حذف السفره اذا قد ضهرت مع السفرات \n ثم المحاوله مره اخرى", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            // التحقق من عدم وجود خلية فارغة في الصف
                            if (row.Cells["ColumnID"].Value != null &&
                                row.Cells["ColumnNum"].Value != null &&
                                int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int IDitems) &&
                                int.TryParse(row.Cells["ColumnNum"].Value.ToString(), out int numberOfitems))
                            {
                                if (Number_of_itemStored(IDitems) < numberOfitems)
                                {
                                    MessageBox.Show("للاسف حدث خطا ما \n المواد لم تصعد في السفره \n يرجى حذف السفره والمحاولة من جديد ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                           

                                context.TB_str.Add(new TB_str
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    str_date = selectedDate.Date,
                                    str_num = numberOfitems * -1,
                                    str_renum = 0,
                                    action_id = 3
                                });
                                context.TB_details.Add(new TB_details
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    details_num = numberOfitems,
                                    details_renum = 0,
                                    action_id = 3,
                                    sending = false
                                });
                            }
                        }
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطا في تققيد مواد السفره " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                   

                }
                   
            }
          
        }
        private decimal Number_of_itemStored(int ID_items)
        {
           

            using (var dbRamy = new AlibaRamyEntities())
            {
                try
                {
                   
                    var result = dbRamy.Database.SqlQuery<decimal>("EXEC dbo.GetItemStored @ItemId", new SqlParameter("@ItemId", ID_items)).FirstOrDefault();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error at (Number_of_itemStored) " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }

        }
        private void ClearDataGridView()
        {
            if (ID_travel == 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
            }
            else
            {
                travelItems.Clear();
                dataGridView2.RowCount = 0;
                dataGridView2.Refresh();
            }
           
        }

        private void Btn_delete_row_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (ID_travel == 0)
                    {
                        dataGridView2.Rows.Remove(row);
                       
                    }
                    else
                    {
                        travelItems.RemoveAt(row.Index);
                        dataGridView2.RowCount = travelItems.Count;
                       
                    }
                   
                }
                Count();
            }
        }
        private void Count()
        {
            if (ID_travel == 0)
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    decimal rowCount = dataGridView2.RowCount;
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
                }
                else
                {
                    lblcount.Text = "0";
                    lblPaces.Text = "0";

                    SetNumberItems = 0;
                    NumberSet = 0;

                }
            }
            else
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    decimal rowCount = dataGridView2.RowCount;
                    SetNumberItems = rowCount;
                    lblcount.Text = rowCount.ToString();

                    decimal totalNumber = 0;
                    foreach (var item in travelItems)
                    {
                        totalNumber += item.Number ?? 0;
                    }
                    lblPaces.Text = totalNumber.ToString();
                    NumberSet = totalNumber;
                }
                else
                {
                    lblcount.Text = "0";
                    lblPaces.Text = "0";

                    SetNumberItems = 0;
                    NumberSet = 0;
                }
            }
        }
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ID_travel > 0)
            {
                // التأكد من أن الفعالية تحدث في عمود زر الحذف
                if (e.ColumnIndex == dataGridView2.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
                {
                    // الحصول على مؤشر على الصف المحدد
                    DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                    // قم بإزالة الصف من DataGridView ومن القائمة travelItems إذا كان متوفراً
                    if (ID_travel == 0)
                    {
                        dataGridView2.Rows.Remove(selectedRow);
                    }
                    else
                    {
                        int rowIndex = e.RowIndex;
                        travelItems.RemoveAt(rowIndex);
                        dataGridView2.Rows.RemoveAt(rowIndex);
                    }

                
                    Count();
                }
            }
        }
        private void AddTraval_Load(object sender, EventArgs e)
        {
            if (ID_travel == 0)
            {
                dataGridView2.VirtualMode = false;
                dataGridView2.CellValueNeeded -= DataGridView2_CellValueNeeded;
                dataGridView2.CellValuePushed -= DataGridView2_CellValuePushed;
            }
            else
            {
                dataGridView2.VirtualMode = true;
                dataGridView2.CellValueNeeded += DataGridView2_CellValueNeeded;
                dataGridView2.CellValuePushed += DataGridView2_CellValuePushed;
            }
           
            AddRowToGrid();
            LoadGrid();
            dataGridView2.CellContentClick += DataGridView2_CellContentClick;
        }

        private void AddTraval_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
    public class TravelItem
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public decimal? Number { get; set; }
        public string Category { get; set; }
        public string Formm { get; set; }
    }
}


