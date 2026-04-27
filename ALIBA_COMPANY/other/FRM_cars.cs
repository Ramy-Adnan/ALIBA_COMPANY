using ALIBA_COMPANY.classes;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_cars : XtraForm
    {
        Note note;
        private AlibaRamyEntities db;
        private bool isEditing;
        private int carId;
        string carName;
        public FRM_cars()
        {
            InitializeComponent();
            UpdateSuggestions();
        }

        private void Ser_car_TextChanged(object sender, EventArgs e)
        {
            UpdateSuggestions();
        }

        private void UpdateSuggestions()
        {
            try
            {
                using (db = new AlibaRamyEntities())
                {
                    string inputText = Ser_car.Text;
                    var suggestions = db.TB_cars
                        .Where(x => x.car_name.Contains(inputText) || x.car_num.Contains(inputText) || x.car_type.Contains(inputText))
                        .Select(x => x.car_name)
                        .ToList();

                    listbox_suggestions.DataSource = suggestions;
                }
            }
            catch (Exception ex)
            {
                ShowError("No connection:لا يوجد اتصال ربما السيرفر طافي " + ex.Message);
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
                        var car = db.TB_cars.FirstOrDefault(x => x.car_name == itemName);
                        if (car != null)
                        {
                            carId = car.car_id;
                            carName = car.car_name;
                            PopulateCarData(car);
                        }
                    }
                }
                else
                {
                    ShowError("يرجى اختيار سيارة");
                }
            }
            catch (Exception ex)
            {
                ShowError("لا يوجد اتصال : " + ex.Message);
            }
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                PrepareForNewCar();
            }
            else
            {
                if (ValidateCarData())
                {
                    if (carId == 0)
                    {
                        SaveCar();
                    }
                    else
                    {
                        UpdateCar();
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

        private void SaveCar()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var validator = new Validator(db);

                    // الحصول على الاسم من TextBox
                    var carName = Txt_name.Text.Trim();

                    // تحقق من وجود العميل بناءً على الاسم المدخل في TextBox
                    if (validator.CarExists(carName))
                    {
                        ShowError("السيارة موجودة اختر اسم ثاني \n لا يمكن ادخال اسم سيارة موجود سابقا");
                        return; // إيقاف العملية إذا كان العميل موجودًا بالفعل
                    }
                    var newCar = CreateCarFromInputs();
                    db.TB_cars.Add(newCar);
                    db.SaveChanges();
                    ShowInfo("تمت اضافة السيارة بنجاح");
                    ResetForm();

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " اضافة سيارة جديده  " + Txt_name.Text;
                    note.AddNote(Note, notifications, "اضافة", 3);
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void UpdateCar()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var car = db.TB_cars.Find(carId);
                    if (car != null)
                    {
                        UpdateCarFromInputs(car);
                        db.SaveChanges();
                        ShowInfo("تم تعديل بيانات السيارة");
                        ResetForm();

                        // Add new notification
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                       
                        var Note = " تعديل بيانات السياره " + carName;
                        note.AddNote(Note, notifications, "تعديل", 4);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void PopulateCarData(TB_cars car)
        {
            Txt_name.Text = car.car_name;
            Txt_num.Text = car.car_num;
            Txt_type.Text = car.car_type;
            Check_ava.Checked = car.car_activity ?? false;
            Txt_infoo.Text = car.car_inf;
        }

        private TB_cars CreateCarFromInputs()
        {
            return new TB_cars
            {
                car_name = Txt_name.Text.Trim(),
                car_num = Txt_num.Text.Trim(),
                car_type = Txt_type.Text.Trim(),
                car_inf = Txt_infoo.Text.Trim(),
                car_activity = Check_ava.Checked,
                car_traval_active = false
            };
        }

        private void UpdateCarFromInputs(TB_cars car)
        {
            car.car_name = Txt_name.Text.Trim();
            car.car_num = Txt_num.Text.Trim();
            car.car_type = Txt_type.Text.Trim();
            car.car_inf = Txt_infoo.Text.Trim();
            car.car_activity = Check_ava.Checked;
        }

        private bool ValidateCarData()
        {
            if (string.IsNullOrWhiteSpace(Txt_name.Text) ||
                string.IsNullOrWhiteSpace(Txt_num.Text) ||
                string.IsNullOrWhiteSpace(Txt_type.Text))
            {
                ShowError("*يرجى ملء الحقول التي امامها ");
                return false;
            }
            return true;
        }

        private void PrepareForNewCar()
        {
            ClearInputs();
            EnableInputs();
            isEditing = true;
            carId = 0;
            Btn_1.Text = "حفظ";
            Btn_1.BackColor = Color.DarkGreen;
            Btn_2.Text = "الغاء";
            Btn_2.BackColor = Color.Red;
            listbox_suggestions.Visible = false;
            Ser_car.Enabled = false;
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
            Txt_num.Text = string.Empty;
            Txt_type.Text = string.Empty;
            Txt_infoo.Text = string.Empty;
           
        }

        private void EnableInputs()
        {
            Txt_name.Enabled = true;
            Txt_num.Enabled = true;
            Txt_type.Enabled = true;
            Txt_infoo.Enabled = true;
        }

        private void DisableInputs()
        {
            Txt_name.Enabled = false;
            Txt_num.Enabled = false;
            Txt_type.Enabled = false;
            Txt_infoo.Enabled = false;
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
            Ser_car.Enabled = true;
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
    }
}
