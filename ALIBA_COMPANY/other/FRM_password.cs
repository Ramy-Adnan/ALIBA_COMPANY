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
    public partial class FRM_password : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        public FRM_password()
        {
            InitializeComponent();
        }
        private bool ValidateBranchData()
        {
            if (string.IsNullOrWhiteSpace(Txt_Password1.Text) ||
                string.IsNullOrWhiteSpace(Txt_Password2.Text) ||
                string.IsNullOrWhiteSpace(Txt_Password3.Text))
            {
                MessageBox.Show("يرجى ملء الحقول", "اشعار ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (ValidateBranchData()) {
                try
                {
                    using (var db = new AlibaRamyEntities())
                    {

                        var user = db.TB_users
                                    .Where(x => x.user_id == AddPage.Users.Idd).AsQueryable()
                                    .FirstOrDefault();

                        if (user != null)
                        {

                            if (user.user_passward == Txt_Password1.Text)
                            {
                                if (Txt_Password2.Text == Txt_Password3.Text)
                                {
                                    user.user_passward = Txt_Password2.Text;


                                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();

                                    MessageBox.Show("تم تغيير كلمة السر بنجاح", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearResult();

                                    // Add new notification
                                    note = new Note();
                                    pages.Notifications notifications = new pages.Notifications();
                                   
                                    var Note = "  تم تغيير كلمة المرور الخاصه به  ";
                                    note.AddNote(Note, notifications, "تعديل", 4);
                                }
                                else
                                {
                                    MessageBox.Show("خطا في اعادة كلمة السر الجديدة", "عملية خاطئة ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("خطأ في كلمة السر القديمة", "عملية خاطئة ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("المستخدم غير موجود", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error_Btn_Update " + ex.Message);
                }
            }
            
        }
        private void ClearResult()
        {
            Txt_Password1.Text = "";
            Txt_Password2.Text = "";
            Txt_Password3.Text = "";
        }
    }
}
    
