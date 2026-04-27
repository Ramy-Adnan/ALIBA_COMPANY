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
    public partial class FRM_branch : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        private AlibaRamyEntities db;
        private bool isEditing;
        private int branchID;
        string branchName;
        public FRM_branch()
        {
            InitializeComponent();
            UpdateSuggestions();
        }

        private void Ser_branch_TextChanged(object sender, EventArgs e)
        {
            UpdateSuggestions();
        }

        private void UpdateSuggestions()
        {
            try
            {
                using (db = new AlibaRamyEntities())
                {
                    string inputText = Ser_branch.Text;
                    var suggestions = db.TB_branchs
                        .Where(x => x.br_name.Contains(inputText) || x.br_code.Contains(inputText) || x.br_phone.StartsWith(inputText))
                        .Select(x => x.br_name)
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
                        var branch = db.TB_branchs.FirstOrDefault(x => x.br_name == itemName);
                        if (branch != null)
                        {
                            branchID = branch.br_id;
                            branchName = branch.br_name;
                            PopulateBranchData(branch);
                        }
                    }
                }
                else
                {
                    ShowError("يرجى اختيار فرع");
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
                PrepareForNewBranch();
            }
            else
            {
                if (ValidateBranchData())
                {
                    if (branchID == 0)
                    {
                        SaveBranch();
                    }
                    else
                    {
                        UpdateBranch();
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

        private void SaveBranch()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var validator = new Validator(db);

                    // الحصول على الاسم من TextBox
                    var branchName = Txt_name.Text.Trim();

                    // تحقق من وجود العميل بناءً على الاسم المدخل في TextBox
                    if (validator.BranchExists(branchName))
                    {
                        ShowError("الفرع موجود اختر اسم ثاني \n لا يمكن ادخال اسم الفرع موجود سابقا");
                        return; // إيقاف العملية إذا كان العميل موجودًا بالفعل
                    }
                    var newBranch = CreateBranchFromInputs();
                    db.TB_branchs.Add(newBranch);
                    db.SaveChanges();
                    ShowInfo("تمت اضافة الفرع بنجاح");
                    ResetForm();

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " اضافة فرع جديد  " + Txt_name.Text;
                    note.AddNote(Note, notifications, "اضافة", 3);
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void UpdateBranch()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var branch = db.TB_branchs.Find(branchID);
                    if (branch != null)
                    {
                        UpdateBranchFromInputs(branch);
                        db.SaveChanges();
                        ShowInfo("تم تعديل بيانات الفرع");
                        ResetForm();

                        // Add new notification
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                       
                        var Note = " تم تعديل بيانات الفرع " + branchName;
                        note.AddNote(Note, notifications, "تعديل", 4);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ في الاتصال: " + ex.Message);
            }
        }

        private void PopulateBranchData(TB_branchs branch)
        {
                Txt_name.Text = branch.br_name;
                Txt_code.Text = branch.br_code;
                Txt_phone.Text = branch.br_phone;       
                Check_ava.Checked = branch.br_activity ?? false;
                Txt_adress.Text = branch.br_address;
                Txt_info.Text = branch.br_nots;
        }

        private TB_branchs CreateBranchFromInputs()
        {
            return new TB_branchs
            {
                br_name = Txt_name.Text.Trim(),
                br_code = Txt_code.Text.Trim(),
                br_phone = Txt_phone.Text.Trim(),
                br_activity = Check_ava.Checked,
                br_address = Txt_adress.Text,
                br_nots = Txt_info.Text
            };
        }

        private void UpdateBranchFromInputs(TB_branchs branch)
        {
            branch.br_name = Txt_name.Text.Trim();
            branch.br_code = Txt_code.Text.Trim();
            branch.br_phone = Txt_phone.Text.Trim();
            branch.br_activity = Check_ava.Checked;
            branch.br_address = Txt_adress.Text;
            branch.br_nots = Txt_info.Text;
        }

        private bool ValidateBranchData()
        {
            if (string.IsNullOrWhiteSpace(Txt_name.Text) ||
                string.IsNullOrWhiteSpace(Txt_code.Text))
            {
                ShowError("*يرجى ملء الحقول التي امامها ");
                return false;
            }
            return true;
        }

        private void PrepareForNewBranch()
        {
            ClearInputs();
            EnableInputs();
            isEditing = true;
            branchID = 0;
            Btn_1.Text = "حفظ";
            Btn_1.BackColor = Color.DarkGreen;
            Btn_2.Text = "الغاء";
            Btn_2.BackColor = Color.Red;
            listbox_suggestions.Visible = false;
            Ser_branch.Enabled = false;
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
            Txt_code.Text = string.Empty;
            Txt_phone.Text = string.Empty;
            Txt_adress.Text = string.Empty;
           
            Txt_info.Text = string.Empty;
        }

        private void EnableInputs()
        {
            Txt_name.Enabled = true;
            Txt_code.Enabled = true;
            Txt_phone.Enabled = true;
            Txt_adress.Enabled = true;
            Txt_info.Enabled = true;
        }

        private void DisableInputs()
        {
            Txt_name.Enabled = false;
            Txt_code.Enabled = false;
            Txt_phone.Enabled = false;
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
            Ser_branch.Enabled = true;
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