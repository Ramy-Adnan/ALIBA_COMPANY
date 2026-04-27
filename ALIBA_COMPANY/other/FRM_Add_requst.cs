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
    public partial class FRM_Add_requst : DevExpress.XtraEditors.XtraForm
    {
       
        Note note;
        int? ID_type;
        int ID_emplo;
        public FRM_Add_requst()
        {
            InitializeComponent();
        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            // الحصول على التاريخين من DateTimePicker
            DateTime x = Date2.Value.Date;
            DateTime y = Date1.Value.Date;

            // حساب الفرق بين التاريخين
            TimeSpan diff = x - y;

            // إظهار عدد الأيام في TextBox
            Txt_num.Text = diff.Days.ToString();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
           
            DateTime x = Date2.Value.Date;
            DateTime y = Date1.Value.Date;
            TimeSpan diff = x - y;
            Txt_num.Text = diff.Days.ToString();
        }

        private void FRM_Add_requst_Load(object sender, EventArgs e)
        {
            Load_type();
            Load_emplo();
        }
        private bool IsFormDataValid()
        {
            if (string.IsNullOrWhiteSpace(Combo_type.Text) ||
                string.IsNullOrWhiteSpace(Compo_emplo.Text))
            {
                MessageBox.Show("الرجاء ملء الحقول المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void ResetForm()
        {
            Combo_type.Text ="";
            Compo_emplo.Text = "";
            Txt_num.Text = "" ;
            Txt_note.Text = "";
        }
        private void Btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsFormDataValid())
                {
                    return;
                }
                using (var dbbb = new AlibaRamyEntities())
                {
                    if(Txt_num.Text==""|| Txt_num.Text == "0"|| int.Parse(Txt_num.Text) < 0 )
                    {
                        MessageBox.Show("لا يمكن ان يكون عدد الايام يساوي صفر او سالب \nقم بتغيير التاريخ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var newBranch = CreateBranchFromInputs();
                    dbbb.TB_emr.Add(newBranch);
                    dbbb.SaveChanges();
                    MessageBox.Show("تمت اضافة الطلب", "نجاح عملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " طلب جديد لـ " + Compo_emplo.Text;
                    note.AddNote(Note, notifications, "اضافة", 3);
                    ResetForm();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل النوع: " + ex.Message);
            }
        }
        private TB_emr  CreateBranchFromInputs()
        {
            return new TB_emr
            {
                emr_date = DateTime.Now,
                emr__dateFrom = Date1.Value,
                emr__dateTo = Date2.Value,
                emst_id = ID_type,
                emr_num = int.Parse(Txt_num.Text),
                user_id = AddPage.Users.Idd,
                emplo_id = ID_emplo,
                emr_note = Txt_note.Text,
                action_id = 20,

            };
        }
        private void Load_type()
        {

            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var type = dbbb.TB_emst.Select(x => x.emst_name).ToList();
                    type.Insert(0, "");
                    Combo_type.DataSource = type;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل النوع: " + ex.Message);
            }
        }
        private void Set_ID_type()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var Idd = dbbb.TB_emst.Where(x => x.emst_name == Combo_type.SelectedItem.ToString()).Select(x => x.emst_id).FirstOrDefault();
                    ID_type = Idd;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ Set_ID_type: " + ex.Message);
            }
        }
        private void Combo_type_TextChanged(object sender, EventArgs e)
        {
            Set_ID_type();

        }
        private void Load_emplo()
        {

            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var emplo = dbbb.TB_emplo.Where(x => x.emplo_activity == true).Select(x => x.emplo_name).ToList();
                    emplo.Insert(0, "");
                    Compo_emplo.DataSource = emplo;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل الموظفين: " + ex.Message);
            }
        }
        private void Set_ID_emplo()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {
                    var Idd = dbbb.TB_emplo.Where(x => x.emplo_name == Compo_emplo.SelectedItem.ToString()).Select(x => x.emplo_id).FirstOrDefault();
                    ID_emplo = Idd;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ Set_ID_emplo(): " + ex.Message);
            }
        }
        private void Compo_emplo_TextChanged(object sender, EventArgs e)
        {
            Set_ID_emplo();
          
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FRM_Add_requst_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}