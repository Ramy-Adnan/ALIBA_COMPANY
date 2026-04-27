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

namespace ALIBA_COMPANY.AddPage
{
    public partial class FRM_AddUser : DevExpress.XtraEditors.XtraForm
    {
        public int Start=0;
        Note note;
        public FRM_AddUser()
        {
            InitializeComponent();

        }
        private bool IsItemExists(string UserName)
        {
            using (var db = new ALIBA_COMPANY.AlibaRamyEntities())
            {
                var existingItem = db.TB_users.FirstOrDefault(x => x.user_name == UserName);
                return existingItem != null;
            }
        }
        private bool IsFormDataValid()
        {
            if (string.IsNullOrWhiteSpace(Txt_User.Text) ||
                string.IsNullOrWhiteSpace(Txt_FullName.Text) ||
                string.IsNullOrWhiteSpace(Combo_role.Text) ||
                string.IsNullOrWhiteSpace(Txt_Password.Text))
            {
                MessageBox.Show("الرجاء ملء جميع الحقول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsFormDataValid())
                {
                    return;
                }
                string UserName = Txt_User.Text.Trim();


                if (IsItemExists(UserName))
                {
                    MessageBox.Show("اسم المستخدم محجوز يرجى اختيار اسم مستخدم اخر", "تكرار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var db = new ALIBA_COMPANY.AlibaRamyEntities())
                {
                    var newUser = Inputs();
                    db.TB_users.Add(newUser);
                    db.SaveChanges();
                    MessageBox.Show("تمت إضافة المستخدم بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;


                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var username = AddPage.Users.Name;
                    var Note = " تم اضافة مستخدم جديد من قبل " + username;
                    note.AddNote(Note, notifications, "اضافة", 3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في الاتصال بقاعدة البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private TB_users Inputs()
        {
            return new TB_users
            {
                user_name = Txt_User.Text,
                user_passward = Txt_Password.Text,
                user_FullName = Txt_FullName.Text,
                user_addDate = dateTimePicker1.Value.Date,
                user_role = Combo_role.Text,
                user_activity = Ckeck_Active.Checked,
                user_state = false,
            };
        }

        private void FRM_AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Start == 1)
            {
                Application.Exit();
            }
        }
    }
}