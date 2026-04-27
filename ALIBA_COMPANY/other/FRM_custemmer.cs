using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using ALIBA_COMPANY.classes;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_custemmer : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        private AlibaRamyEntities db;
        private bool isEditing;
        private int custID;
        private int cityID;
        string custName;
        public FRM_custemmer()
        {
            InitializeComponent();
            LoadCities();
            UpdateSuggestions();
        }

        private void LoadCities()
        {
            try
            {
                using (db = new AlibaRamyEntities())
                {
                    var cities = db.TB_city.Select(x => x.city_name).ToList();
                    Txt_city.DataSource = cities;
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في تحميل المدن: " + ex.Message);
            }
        }

        private void Ser_emplo_TextChanged(object sender, EventArgs e)
        {
            UpdateSuggestions();
        }

        private void UpdateSuggestions()
        {
            try
            {
                using (db = new AlibaRamyEntities())
                {
                    string inputText = Ser_custmer.Text;
                    var suggestions = db.TB_cust
                        .Where(x => x.cust_name.Contains(inputText) || x.cust_phone.Contains(inputText))
                        .Select(x => x.cust_name)
                        .ToList();

                    listbox_suggestions.DataSource = suggestions;
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void listbox_suggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_suggestions.SelectedItem != null)
            {
                GetMaterialsData();
            }
        }

        private void GetMaterialsData()
        {
            try
            {
                string itemName = listbox_suggestions.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(itemName))
                {
                    using (db = new AlibaRamyEntities())
                    {
                        var cust = db.TB_cust.FirstOrDefault(x => x.cust_name == itemName);
                        if (cust != null)
                        {
                            custID = cust.cust_id;
                            custName= cust.cust_name;
                            PopulateCustData(cust);
                        }
                    }
                }
                else
                {
                    ShowError("يرجى اختيار عميل");
                }
            }
            catch (Exception ex)
            {
                ShowError("no connection: " + ex.Message);
            }
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                PrepareForNewCust();
            }
            else
            {
                if (ValidateCustData())
                {
                    if (custID == 0)
                    {
                        SaveCust();
                    }
                    else
                    {
                        UpdateCust();
                    }
                }
            }
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                PrepareForEditing();
            }
            else
            {
                CancelEditing();
            }
        }

        private void SaveCust()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var validator = new Validator(db);

                    // الحصول على الاسم من TextBox
                    var customerName = Txt_name.Text.Trim();

                    // تحقق من وجود العميل بناءً على الاسم المدخل في TextBox
                    if (validator.CustomerExists(customerName))
                    {
                        ShowError("العميل موجود اختر اسم ثاني \n لا يمكن ادخال اسم عميل موجود سابقا");
                        return; // إيقاف العملية إذا كان العميل موجودًا بالفعل
                    }

                    // إذا لم يكن العميل موجودًا، أضف العميل الجديد
                    var newCust = CreateCustFromInputs();
                    db.TB_cust.Add(newCust);
                    db.SaveChanges();

                    ShowInfo("تمت اضافة العميل بنجاح");
                    ResetForm();

                    // إضافة إشعار جديد
                    var note = new Note();
                    var notifications = new pages.Notifications();
                    var noteText = " تسجيل عميل جديد  " + newCust.cust_name;
                    note.AddNote(noteText, notifications, "اضافة", 3);
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }
        private TB_cust CreateCustFromInputs()
        {
            return new TB_cust
            {
                cust_name = Txt_name.Text.Trim(),
                cust_phone = Txt_phone.Text,
                city_id = cityID,
                cust_max = decimal.Parse(Txt_max.Text.Trim()),
                cust_min = decimal.Parse(Txt_min.Text.Trim()),
                cust_activity = Check_ava.Checked,
                cust_address = Txt_adress.Text.Trim(),
                cus_nots = Txt_info.Text.Trim(),
            };
        }

        private void UpdateCust()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var cust = db.TB_cust.Find(custID);
                    if (cust != null)
                    {
                       
                        UpdateCustFromInputs(cust);
                        db.SaveChanges();
                        ShowInfo("تم تعديل بيانات العميل");
                        ResetForm();

                        // Add new notification
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " تعديل على بيانات العميل " + custName;
                        note.AddNote(Note, notifications, "تعديل", 4);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void PopulateCustData(TB_cust cust)
        {
            Txt_name.Text = cust.cust_name;
            Txt_phone.Text = cust.cust_phone;
            Txt_city.SelectedItem = cust.TB_city.city_name;
            Txt_max.Text = cust.cust_max.ToString();
            Txt_min.Text = cust.cust_min.ToString();
            Check_ava.Checked = cust.cust_activity ?? false;
            Txt_adress.Text = cust.cust_address;
            Txt_info.Text = cust.cus_nots;
        }

        private void SetIdCust()
        {
            try
            {
                using (db = new AlibaRamyEntities())
                {
                    var idd = db.TB_city
                        .Where(x => x.city_name == Txt_city.Text)
                        .Select(x => x.city_id)
                        .FirstOrDefault();
                    cityID = idd;
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطا في الاتصال: " + ex.Message);
            }
        }

        

        private void UpdateCustFromInputs(TB_cust cust)
        {
            cust.cust_name = Txt_name.Text.Trim();
            cust.cust_phone = Txt_phone.Text;
            cust.city_id = cityID;
            cust.cust_max = decimal.Parse(Txt_max.Text.Trim());
            cust.cust_min = decimal.Parse(Txt_min.Text.Trim());
            cust.cust_activity = Check_ava.Checked;
            cust.cust_address = Txt_adress.Text.Trim();
            cust.cus_nots = Txt_info.Text.Trim();
        }

        private bool ValidateCustData()
        {
            if (string.IsNullOrWhiteSpace(Txt_name.Text) ||
                string.IsNullOrWhiteSpace(Txt_city.Text))
            {
                ShowError("*يرجى ملء الحقول التي امامها ");
                return false;
            }
            return true;
        }

        private void PrepareForNewCust()
        {
            ClearInputs();
            EnableInputs();
            isEditing = true;
            custID = 0;
            Btn_1.Text = "حفظ";
            Btn_1.BackColor = Color.DarkGreen;
            Btn_2.Text = "الغاء";
            Btn_2.BackColor = Color.Red;
            listbox_suggestions.Visible = false;
            Ser_custmer.Enabled = false;
        }

        private void PrepareForEditing()
        {
            EnableInputs();
            isEditing = true;
            Btn_1.Text = "حفظ";
            Btn_1.BackColor = Color.DarkGreen;
            Btn_2.Text = "الغاء";
            Btn_2.BackColor = Color.Red;
        }

        private void CancelEditing()
        {
            DisableInputs();
            ResetForm();
        }

        private void ClearInputs()
        {
            Txt_name.Text = string.Empty;
            Txt_phone.Text = string.Empty;
            Txt_city.SelectedIndex = -1;
            Txt_max.Text = "0.00";
            Txt_min.Text = "0.00";
            Txt_adress.Text = string.Empty;
            Txt_info.Text = string.Empty;
        }

        private void EnableInputs()
        {
            Txt_name.Enabled = true;
            Txt_phone.Enabled = true;
            Txt_city.Enabled = true;
            Txt_max.Enabled = true;
            Txt_min.Enabled = true;
            Txt_adress.Enabled = true;
            Txt_info.Enabled = true;
        }

        private void DisableInputs()
        {
            Txt_name.Enabled = false;
            Txt_phone.Enabled = false;
            Txt_city.Enabled = false;
            Txt_max.Enabled = false;
            Txt_min.Enabled = false;
            Txt_adress.Enabled = false;
            Txt_info.Enabled = false;
        }

        private void ResetForm()
        {
            ClearInputs();
            DisableInputs();
            isEditing = false;
            Btn_1.Text = "جديد";
            Btn_1.BackColor = Color.Silver;
            Btn_2.Text = "تعديل";
            Btn_2.BackColor = Color.Silver;
            listbox_suggestions.Visible = true;
            Ser_custmer.Enabled = true;
            UpdateSuggestions();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "نجاح عملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Txt_city_TextChanged(object sender, EventArgs e)
        {
            SetIdCust();
        }
    }
}
