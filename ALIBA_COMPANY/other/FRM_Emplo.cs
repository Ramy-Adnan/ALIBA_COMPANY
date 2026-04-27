using ALIBA_COMPANY.classes;
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

namespace ALIBA_COMPANY.other
{
    public partial class FRM_Emplo : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        private AlibaRamyEntities db;
        private bool isEditing;
        private int emploID;
        string emploName;
        public FRM_Emplo()
        {
            InitializeComponent();
            UpdateSuggestions();
           
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
                    string inputText = Ser_emplo.Text;
                    var suggestions = db.TB_emplo
                        .Where(x => x.emplo_name.Contains(inputText) || x.emplo_phone.Contains(inputText))
                        .Select(x => x.emplo_name)
                        .ToList();

                    listbox_suggestions.DataSource = suggestions;
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ غير متوقع: " + ex.Message);
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
                        var emplo = db.TB_emplo.FirstOrDefault(x => x.emplo_name == itemName);
                        if (emplo != null)
                        {
                            emploID = emplo.emplo_id;
                            emploName = emplo.emplo_name;
                            PopulateEmploData(emplo);
                        }
                    }
                }
                else
                {
                    ShowError("يرجى اختيار موظف");
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
                PrepareForNewEmplo();
            }
            else
            {
                if (ValidateEmploData())
                {
                    if (emploID == 0)
                    {
                        SaveEmplo();
                    }
                    else
                    {
                        UpdateEmplo();
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

        private void SaveEmplo()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var validator = new Validator(db);

                    // الحصول على الاسم من TextBox
                    var emploName = Txt_name.Text.Trim();

                    // تحقق من وجود العميل بناءً على الاسم المدخل في TextBox
                    if (validator.EmploExists(emploName))
                    {
                        ShowError("الموظف موجودة اختر اسم ثاني \n لا يمكن ادخال اسم الموظف موجود سابقا");
                        return; // إيقاف العملية إذا كان العميل موجودًا بالفعل
                    }
                    var newEmplo = CreateEmploFromInputs();
                    db.TB_emplo.Add(newEmplo);
                    db.SaveChanges();
                    ShowInfo("تمت اضافة الموظف بنجاح");
                    ResetForm();

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " تسجيل موظف جديد  " + Txt_name.Text;
                    note.AddNote(Note, notifications, "اضافة", 3);
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void UpdateEmplo()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var emplo = db.TB_emplo.Find(emploID);
                    if (emplo != null)
                    {
                        UpdateEmploFromInputs(emplo);
                        db.SaveChanges();
                        ShowInfo("تم تعديل بيانات الموظف");
                        ResetForm();

                        // Add new notification
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " تعديل على بيانات الموظف " + emploName;
                        note.AddNote(Note, notifications, "تعديل", 4);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void PopulateEmploData(TB_emplo emplo)
        {
            Txt_name.Text = emplo.emplo_name;
            dateTimePicker1.Text = emplo.emplo_pirth;
            Txt_jop.Text = emplo.emplo_job;
            Txt_phone.Text = emplo.emplo_phone;
            Txt_salary.Text = emplo.emplo_sel.ToString();
            Txt_week.Text = emplo.emplo_wek.ToString();
            Check_ava.Checked = emplo.emplo_activity ?? false;
            Check_dis.Checked = emplo.emplo_dis ?? false;
            Txt_adress.Text = emplo.emplo_address;
            Txt_info.Text = emplo.emplo_inf;
        }

        private TB_emplo CreateEmploFromInputs()
        {
            return new TB_emplo
            {

            emplo_name= Txt_name.Text.Trim(),
            emplo_pirth = dateTimePicker1.Text,
            emplo_job = Txt_jop.Text.Trim() ,
            emplo_phone=Txt_phone.Text.Trim(),
            emplo_sel=decimal.Parse( Txt_salary.Text.Trim()),
            emplo_wek=decimal.Parse(Txt_week.Text.Trim()),
            emplo_activity = Check_ava.Checked,
            emplo_dis = Check_dis.Checked,
            emplo_address= Txt_adress.Text.Trim(),
            emplo_inf= Txt_info.Text.Trim(),
          
            };
        }

        private void UpdateEmploFromInputs(TB_emplo emplo)
        {
            emplo.emplo_name = Txt_name.Text.Trim();
            emplo.emplo_pirth = dateTimePicker1.Text;
            emplo.emplo_job = Txt_jop.Text.Trim();
            emplo.emplo_phone = Txt_phone.Text.Trim();
            emplo.emplo_sel = decimal.Parse(Txt_salary.Text.Trim());
            emplo.emplo_wek = decimal.Parse(Txt_week.Text.Trim());
            emplo.emplo_activity = Check_ava.Checked;
            emplo.emplo_dis = Check_dis.Checked;
            emplo.emplo_address = Txt_adress.Text.Trim();
            emplo.emplo_inf = Txt_info.Text.Trim();
        }

        private bool ValidateEmploData()
        {
            if (string.IsNullOrWhiteSpace(Txt_name.Text) ||
                string.IsNullOrWhiteSpace(Txt_jop.Text))
            {
                ShowError("*يرجى ملء الحقول التي امامها ");
                return false;
            }
            return true;
        }

        private void PrepareForNewEmplo()
        {
            ClearInputs();
            EnableInputs();
            isEditing = true;
            emploID = 0;
            Btn_1.Text = "حفظ";
            Btn_1.BackColor = Color.DarkGreen;
            Btn_2.Text = "الغاء";
            Btn_2.BackColor = Color.Red;
            listbox_suggestions.Visible = false;
            Ser_emplo.Enabled = false;
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
            Txt_jop.Text = string.Empty;
            Txt_phone.Text = string.Empty;
            Txt_salary.Text = "0.00";
            Txt_week.Text = "0.00";
            Txt_adress.Text = string.Empty;
            Check_dis.Checked = false;
            Txt_info.Text = string.Empty;
        }

        private void EnableInputs()
        {
            Txt_name.Enabled = true;
            Txt_jop.Enabled = true;
            Txt_phone.Enabled = true;
            Txt_salary.Enabled = true;
            Txt_week.Enabled = true;
            Txt_adress.Enabled = true;
            Txt_info.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void DisableInputs()
        {
            Txt_name.Enabled = false;
            Txt_jop.Enabled = false;
            Txt_phone.Enabled = false;
            Txt_salary.Enabled = false;
            Txt_week.Enabled = false;
            Txt_adress.Enabled = false;
            Txt_info.Enabled = false;
            dateTimePicker1.Enabled = false;
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
            Ser_emplo.Enabled = true;
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