using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALIBA_COMPANY.AddPage;
using System.IO;
using ALIBA_COMPANY.classes;
using System.Data.SqlClient;

namespace ALIBA_COMPANY.traval

{
    public partial class FRM_AddNumber : DevExpress.XtraEditors.XtraForm
    {
        AlibaRamyEntities db;
        int ID_items;
        public AddTraval Addd;
        //public List<Product> EnteredDataList { get; private set; } = new List<Product>();
        // private AddItemsToStore parentForm;

        public int IDValue { get; private set; }
        public string NameValue { get; private set; }
        public decimal numberValue { get; private set; }
        public string gatgoryValue { get; private set; }
        public string formmValue { get; private set; }

        public FRM_AddNumber()
        {
            InitializeComponent();
        }

        private void empity()
        {
            if (string.IsNullOrEmpty(Ser_item.Text.Trim()))
            {
                listbox_suggestions.Visible = false; // يكون غير مرئي في البداية
                listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
                listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                ClearResults();
            }
        }
        private void Ser_item_TextChanged(object sender, EventArgs e)
        {

            UpdateSuggestions(); // تحديث الاقتراحات
            empity();


        }

        private void UpdateSuggestions()
        {
            try
            {
                string inputText = Ser_item.Text; 

                using (db = new AlibaRamyEntities())
                {
                   
                    var suggestions = db.TB_items.AsNoTracking()
                        .Where(x => x.items_name.Contains(inputText) || x.items_code.Contains(inputText) || x.items_enname.Contains(inputText))
                        .Select(x => x.items_name)
                        .ToList();


                    // تحديث عناصر الليست بوكس بالاقتراحات المطابقة
                    listbox_suggestions.DataSource = suggestions;
                    if (suggestions.Count > 0)
                    {
                        listbox_suggestions.Visible = true;
                    }

                    else
                    {
                        listbox_suggestions.Visible = false; 
                        listbox_suggestions.SelectedIndexChanged += listbox_suggestions_SelectedIndexChanged;
                        listbox_suggestions.KeyDown += listbox_suggestions_KeyDown;
                        ClearResults();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_suggestions.SelectedItem != null) 
            {
                // ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();
                Update_num();
            }
        }

        private void listbox_suggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listbox_suggestions.SelectedItem != null) 
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;
               
                Ser_item.Text = listbox_suggestions.SelectedItem.ToString();
                GetMaterialsData();
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;
            }
        }

        private void GetMaterialsData()
        {
            try
            {

                string itemName = listbox_suggestions.SelectedItem.ToString().Trim(); // التأكد من عدم وجود فراغات في النص
                if (!string.IsNullOrEmpty(itemName))
                {
                    using (db = new AlibaRamyEntities())
                    {

                        TB_items buy = db.TB_items.FirstOrDefault(x => x.items_name == itemName);

                        if (buy != null)
                        {
                            ID_items = buy.items_id;

                            txt_nameAR.Text = buy.items_name;
                            txt_nameEn.Text = buy.items_enname;

                            txt_parcode.Text = buy.items_code;

                            txt_form.Text = buy.items_form;
                            txt_info.Text = buy.items_nots;
                         
                            string imagePath = buy.items_pic;
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pictureEdit1.Image = Image.FromFile(imagePath);
                            }
                            else
                            {
                                // إعادة تعيين الصورة في حال عدم وجود مسار صحيح للصورة
                                pictureEdit1.Image = Properties.Resources.aliba;
                            }

                            TB_groups buy2 = db.TB_groups.FirstOrDefault(m => m.groups_id == buy.groups_id);
                            txt_gat.Text = buy2.groups_name;

                        }
                    }
                }
                else
                {
                    // ClearResults();
                    MessageBox.Show("يرجى إدخال اسم العنصر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txt_Number.Text = "0";
            }

            catch (Exception ex)
            {
                MessageBox.Show("لم يتم جلب البيانات حدث غير متوقع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearResults()
        {  
            txt_nameAR.Text = string.Empty;
            txt_nameEn.Text = string.Empty;
            txt_parcode.Text = string.Empty;
            txt_gat.Text = string.Empty;
            txt_form.Text = string.Empty;
            txt_info.Text = string.Empty;
            pictureEdit1.Image = null;
            txt_Number.Text = "0";

        }

        private void txt_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
            else if (txt_Number.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // 
            }
        }

        private void ser_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;

            }
        }

        private void txt_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_Click(null, null);
            }
        }


        private void txt_Number_MouseDown(object sender, MouseEventArgs e)
        {
            txt_Number.SelectAll();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (txt_Number.Text==""|| txt_Number.Text=="0"|| txt_nameAR.Text==""||txt_nameEn.Text==""||txt_parcode.Text=="")
            {
              
                MessageBox.Show(" حقل المادة او العدد فارغ", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              //  decimal numStored = Number_of_itemStored();


                if (Convert.ToDecimal(Lbl_stay.Text) < 0)
                {
                    MessageBox.Show(" عدد المادة بالمخزن اقل من المطلوب", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    IDValue = ID_items;
                    NameValue = txt_nameAR.Text;
                    numberValue = Convert.ToDecimal(txt_Number.Text);
                    gatgoryValue = txt_gat.Text;
                    formmValue = txt_form.Text;
                  //  numStored -= Convert.ToDecimal(txt_Number.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private decimal Number_of_itemStored()
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

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Update_num()
        {
            decimal numStored;
            decimal numgrid;
            if (!string.IsNullOrWhiteSpace(txt_Number.Text) && decimal.TryParse(txt_Number.Text, out decimal enteredValue))
            {
                numStored = Number_of_itemStored();
                numgrid = Addd.Number_of_grid(ID_items);
                Lbl_stay.Text = (numStored - numgrid - enteredValue).ToString("N0");
            }
            else
            {
                Lbl_stay.Text = "";
            }
        }

        private void txt_Number_TextChanged(object sender, EventArgs e)
        {
            Update_num();
        }

        private void FRM_AddNumber_Load(object sender, EventArgs e)
        {
            Ser_item.Select();
           // UpdateSuggestions();
           // UpdateSuggestions();
        }
    }
}
