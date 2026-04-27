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

namespace ALIBA_COMPANY.Store
{
    public partial class AddItemsToStore : DevExpress.XtraEditors.XtraForm
    {
        public int IN_OUT_STOCK = 0;
        public decimal NumberSet;
        public decimal SetNumberItems;
        public AddItemsToStore ClearGrid;
        public AddItemsToStore()
        {
            InitializeComponent();
            
            AddRowToGrid();
            SetupDragDrop();   //< --أضف هذا السطر    //استدعِ SetupDragDrop() داخل constructor AddItemsToStore بعد AddRowToGrid()
        }
        private void AddRowToGrid()
        {
            // إضافة الأعمدة إلى DataGridView
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.Columns.Add("ColumnID", "رقم المادة");
            dataGridView2.Columns["ColumnID"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
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
       
        public int GetOrderId()
        {
            int lastOrderId = 0;
            try
            {
                if (IN_OUT_STOCK==1|| IN_OUT_STOCK==2)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        lastOrderId = context.TB_order.OrderByDescending(o => o.order_id).Select(o => o.order_id).FirstOrDefault();
                    }
                }
                else if (IN_OUT_STOCK==11)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        lastOrderId = context.TB_stock.OrderByDescending(o => o.sto_id).Select(o => o.sto_id).FirstOrDefault();
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا بجلب الايدي الايدي صفر: " + ex.Message);
            }
            return lastOrderId;
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
           
            using (FRM_AddNumber childForm = new FRM_AddNumber())
            {
                childForm.IN_OUT_STOCK = IN_OUT_STOCK;

                if (childForm.ShowDialog() == DialogResult.OK)
                {
                    // تحصل على البيانات المدخلة من الفورم الفرعي
                    int id = childForm.IDValue;
                    string name = childForm.NameValue;
                    decimal number = childForm.numberValue;
                    string gatgory = childForm.gatgoryValue;
                    string formm = childForm.formmValue;

                    // إضافة البيانات إلى DataGridView في الفورم الرئيسي
                    if (IsItemAlreadyAdded(id))
                    {
                        MessageBox.Show("المادة موجودة  بالقائمة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dataGridView2.Rows.Add(id, name, number, gatgory, formm);  
                    }

                    Count();

                }
            }
        }
        private bool IsItemAlreadyAdded(int id)
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
        private void Btn_Agg_Click(object sender, EventArgs e)
        {
            if (SetNumberItems == 0)
            {
                MessageBox.Show("لا توجد مواد", "اشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (IN_OUT_STOCK == 1 || IN_OUT_STOCK == 2)
                {
                    FRM_Save_Store Add = new FRM_Save_Store();
                    Add.Txt_number.Text = SetNumberItems.ToString();
                    Add.Txt_pacess.Text = NumberSet.ToString();
                    Add.Addd = this;
                    Add.IN_OUT_STOCK = IN_OUT_STOCK;
                    Add.FormClosed += (s, args) =>
                    {
                        if (Add.DialogResult == DialogResult.OK)
                        {
                            ClearDataGridView(); // تحديث البيانات في الفورم الأول بعد الإضافة
                            lblcount.Text = "0";
                            lblPaces.Text = "0";
                        }
                    };
                    Add.ShowDialog();
                }
                else if (IN_OUT_STOCK == 11)
                {
                    FRM_Save_stock Add = new FRM_Save_stock();
                    Add.Txt_number.Text = SetNumberItems.ToString();
                    Add.Txt_pacess.Text = NumberSet.ToString();
                    Add.Addd = this;
                    
                    Add.FormClosed += (s, args) =>
                    {
                        if (Add.DialogResult == DialogResult.OK)
                        {
                            ClearDataGridView(); // تحديث البيانات في الفورم الأول بعد الإضافة
                            lblcount.Text = "0";
                            lblPaces.Text = "0";
                        }
                    };
                    Add.ShowDialog();
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
        public void SaveData()
        {
            try
            {
                if (IN_OUT_STOCK == 1)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        // استخراج قيمة الـ ID الثابتة للطلب
                        var orderId = GetOrderId();

                        // تمرير عبر كل صف في DataGridView
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {

                            if (row.Cells["ColumnID"].Value != null &&
                                row.Cells["ColumnNum"].Value != null &&
                                int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int IDitems) &&
                                int.TryParse(row.Cells["ColumnNum"].Value.ToString(), out int numberOfitems))
                            {

                                context.TB_str.Add(new TB_str
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    str_date = DateTime.Today,
                                    str_num = numberOfitems,
                                    str_renum = 0.00m,
                                    action_id = 1
                                });
                                context.TB_details.Add(new TB_details
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    details_num = numberOfitems,
                                    action_id = 1
                                });
                            }
                        }

                        // حفظ التغييرات في قاعدة البيانات
                        context.SaveChanges();
                    }
                }
                else if (IN_OUT_STOCK == 2)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        // استخراج قيمة الـ ID الثابتة للطلب
                        var orderId = GetOrderId();

                        // تمرير عبر كل صف في DataGridView
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {

                            if (row.Cells["ColumnID"].Value != null &&
                                row.Cells["ColumnNum"].Value != null &&
                                int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int IDitems) &&
                                int.TryParse(row.Cells["ColumnNum"].Value.ToString(), out int numberOfitems))
                            {
                                if (Number_of_itemStored(IDitems) < numberOfitems)
                                {
                                    MessageBox.Show("للاسف لم تكتمل العميله بسبب \n لم يتم اخراج جميع المواد \n يجب حذف عملية الاخراج هذه \n ثم المحاولة مرة اخرى");
                                    return;
                                }

                                context.TB_str.Add(new TB_str
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    str_date = DateTime.Today,
                                    str_num = numberOfitems * -1,
                                    str_renum = 0.00m,
                                    action_id = 2
                                });
                                context.TB_details.Add(new TB_details
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    details_num = numberOfitems,
                                    action_id = 2
                                });
                            }
                        }

                        // حفظ التغييرات في قاعدة البيانات
                        context.SaveChanges();
                    }
                }
                else if (IN_OUT_STOCK == 11)
                {
                    using (var context = new AlibaRamyEntities())
                    {
                        // استخراج قيمة الـ ID الثابتة للطلب
                        var orderId = GetOrderId();

                        // تمرير عبر كل صف في DataGridView
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {

                            if (row.Cells["ColumnID"].Value != null &&
                                row.Cells["ColumnNum"].Value != null &&
                                int.TryParse(row.Cells["ColumnID"].Value.ToString(), out int IDitems) &&
                                int.TryParse(row.Cells["ColumnNum"].Value.ToString(), out int numberOfitems))
                            {
                                if (Number_of_itemStored(IDitems) < numberOfitems)
                                {
                                    MessageBox.Show("للاسف لم تكتمل العميله بسبب \n لم يتم اتلاف جميع المواد \n يجب حذف عملية الاتلاف هذه \n ثم المحاولة مرة اخرى");
                                    return;
                                }

                                context.TB_str.Add(new TB_str
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    str_date = DateTime.Today,
                                    str_num = numberOfitems * -1,
                                    str_renum = 0.00m,
                                    action_id = 11
                                });
                                context.TB_details.Add(new TB_details
                                {
                                    order_id = orderId,
                                    items_id = IDitems,
                                    details_num = numberOfitems,
                                    action_id = 11
                                });
                            }
                        }
                        // حفظ التغييرات في قاعدة البيانات
                        context.SaveChanges();
                    }
                } 
            }
            catch (Exception ex)
            {
                // يتم التعامل مع الأخطاء هنا، يمكنك طباعة رسالة الخطأ أو اتخاذ إجراءات أخرى
                MessageBox.Show("حدث خطأ في ادخال المواد: " + ex.Message);
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
        private void Count()
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

        private void AddItemsToStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }







        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (FRM_ImagePicker pickerForm = new FRM_ImagePicker())
            {
                pickerForm.IN_OUT_STOCK = IN_OUT_STOCK;

                if (pickerForm.ShowDialog() == DialogResult.OK)
                {
                    int id = pickerForm.IDValue;
                    string name = pickerForm.NameValue;
                    decimal number = pickerForm.numberValue;
                    string cat = pickerForm.gatgoryValue;
                    string form = pickerForm.formmValue;

                    if (IsItemAlreadyAdded(id))
                    {
                        MessageBox.Show("المادة موجودة بالقائمة بالفعل.", "تنبيه",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dataGridView2.Rows.Add(id, name, number, cat, form);
                        Count();
                    }
                }
            }
        }



        // ═══════════════════════════════════════════════════════════════════════════════
        //  إذا أردت دعم السحب والإفلات (Drag & Drop) من بطاقات الصور إلى الجريد
        //  أضف هذا الكود في constructor أو Load event الخاص بـ AddItemsToStore
        // ═══════════════════════════════════════════════════════════════════════════════


        private void SetupDragDrop()
        {
            dataGridView2.AllowDrop = true;

            dataGridView2.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(typeof(ItemCard)))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };

            dataGridView2.DragDrop += (s, e) =>
            {
                if (e.Data.GetDataPresent(typeof(ItemCard)))
                {
                    var item = (ItemCard)e.Data.GetData(typeof(ItemCard));

                    if (IsItemAlreadyAdded(item.ID))
                    {
                        MessageBox.Show("المادة موجودة بالقائمة بالفعل.", "تنبيه",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ── فورم صغير لإدخال الكمية بدون Microsoft.VisualBasic ──────────
                    decimal qty = ShowQuantityDialog(item.NameAR, item.Stock);
                    if (qty <= 0) return;

                    // التحقق من المخزون عند الصرف أو الإتلاف
                    if ((IN_OUT_STOCK == 2 || IN_OUT_STOCK == 11) && item.Stock < qty)
                    {
                        MessageBox.Show(
                            $"الكمية ({qty}) أكبر من المخزون المتاح ({item.Stock:N2})",
                            "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataGridView2.Rows.Add(item.ID, item.NameAR, qty, item.Category, item.Form);
                    Count();
                }
            };
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  فورم صغير لإدخال الكمية (بديل InputBox بدون مكتبة VB)
        // ═══════════════════════════════════════════════════════════════════════════════
        private decimal ShowQuantityDialog(string itemName, decimal stock)
        {
            using (var dlg = new Form())
            {
                dlg.Text = "أدخل الكمية";
                dlg.Size = new Size(360, 180);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.BackColor = Color.White;
                dlg.Font = new Font("Cairo", 10f);
                dlg.RightToLeft = RightToLeft.Yes;
                dlg.RightToLeftLayout = true;

                var lbl = new Label
                {
                    Text = $"المادة: {itemName}\nالمخزون: {stock:N2}",
                    Left = 12,
                    Top = 12,
                    Width = 320,
                    Height = 40,
                    Font = new Font("Cairo", 10f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 30, 45)
                };

                var txt = new TextBox
                {
                    Text = "1",
                    Left = 12,
                    Top = 60,
                    Width = 200,
                    Height = 30,
                    Font = new Font("Cairo", 13f, FontStyle.Bold),
                    TextAlign = HorizontalAlignment.Center,
                    BorderStyle = BorderStyle.FixedSingle
                };
                txt.Click += (s2, e2) => txt.SelectAll();
                txt.KeyPress += (s2, e2) =>
                {
                    if (!char.IsControl(e2.KeyChar) && !char.IsDigit(e2.KeyChar) && e2.KeyChar != '.')
                        e2.Handled = true;
                    if (e2.KeyChar == '.' && txt.Text.Contains('.'))
                        e2.Handled = true;
                };
                txt.KeyDown += (s2, e2) =>
                {
                    if (e2.KeyCode == Keys.Enter)
                    {
                        e2.SuppressKeyPress = true;
                        dlg.DialogResult = DialogResult.OK;
                        dlg.Close();
                    }
                };

                var btnOk = new Button
                {
                    Text = "✔ تأكيد",
                    Left = 220,
                    Top = 58,
                    Width = 110,
                    Height = 32,
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Cairo", 10f, FontStyle.Bold),
                    DialogResult = DialogResult.OK
                };
                btnOk.FlatAppearance.BorderSize = 0;

                dlg.Controls.AddRange(new Control[] { lbl, txt, btnOk });
                dlg.AcceptButton = btnOk;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    decimal.TryParse(txt.Text, out decimal result);
                    return result;
                }
                return 0;
            }
        }


    }
}
  
