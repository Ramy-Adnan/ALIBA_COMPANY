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
    public partial class FRM_Save_Store : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        AlibaRamyEntities db;
        public int ID_Branch;
        public int ID_Car;
        public int ID_Driver;
        public AddItemsToStore Addd;
        public int IN_OUT_STOCK = 0;
        public FRM_Save_Store()
        {
            InitializeComponent();
        }
       
        private void FRM_Save_Store_Activated(object sender, EventArgs e)
        {
            LoadBranch();
            Set_ID_Branch();
            LoadCars();
            Set_ID_Cars();
            LoadDrivers();
            Set_ID_Driver();
            Combo_driver.SelectedIndex = -1;
            Combo_car.SelectedIndex = -1;
            Combo_branch.SelectedIndex = -1;

            // GetEmploListName();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
                if (checkBox1.Checked)
                {
                  Combo_car.DropDownStyle = ComboBoxStyle.Simple; // تعيين نمط القائمة المنسدلة للعرض الكامل
                  Combo_car.Enabled = true;
                  Combo_car.SelectedIndex = -1; // إزالة القيمة المحددة
                  ID_Car = 0;
                }
                else
                {
                  Combo_car.DropDownStyle = ComboBoxStyle.DropDownList; // تعيين نمط القائمة المنسدلة للعرض فقط
                  Combo_car.Enabled = true;
                  Combo_car.SelectedIndex = -1; // تعيين القيمة الافتراضية
                  
                }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Combo_driver.DropDownStyle = ComboBoxStyle.Simple; // تعيين نمط القائمة المنسدلة للعرض الكامل
                Combo_driver.Enabled = true;
                Combo_driver.SelectedIndex = -1; // إزالة القيمة المحددة
                ID_Driver =0 ;
            }
            else
            {
                Combo_driver.DropDownStyle = ComboBoxStyle.DropDownList; // تعيين نمط القائمة المنسدلة للعرض فقط
                Combo_driver.Enabled = true;
                Combo_driver.SelectedIndex = -1; // تعيين القيمة الافتراضية

            }
        }
        private void LoadBranch()
        {
            
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var Branch = dbbb.TB_branchs.Where(x => x.br_activity == true).Select(x => x.br_name).ToList();
                    Branch.Insert(0, "");
                    Combo_branch.DataSource = Branch;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل الفروع: " + ex.Message);
            }
        }
        private void Set_ID_Branch()
        {
            try
            {
                db = new AlibaRamyEntities();
                var Idd = db.TB_branchs.Where(x => x.br_name == Combo_branch.SelectedItem.ToString()&& x.br_activity == true).Select(x => x.br_id).FirstOrDefault();
                ID_Branch = Idd;

            }
            catch { }
        }
        private void Combo_branch_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Set_ID_Branch();
        }
        private void LoadCars()
        {
           
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var car = dbbb.TB_cars.Where(x => x.car_activity == true).Select(x => x.car_name).ToList();
                    car.Insert(0, "");
                    Combo_car.DataSource = car;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل السيارات: " + ex.Message);
            }
        }
        private void Set_ID_Cars()
        {
            try
            {
                db = new AlibaRamyEntities();
                var Idd = db.TB_cars.Where(x => x.car_name == Combo_car.SelectedItem.ToString()&& x.car_activity == true).Select(x => x.car_id).FirstOrDefault();
                ID_Car = Idd;

            }
            catch { }
        }
        private void Combo_car_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_Cars();
        }
        private void LoadDrivers()
        {
          
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var driver = db.TB_emplo.Where(x => x.emplo_activity == true).Select(x => x.emplo_name).ToList();
                    driver.Insert(0, "");
                    Combo_driver.DataSource = driver;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" حدث خطأ أثناء تحميل السواق: " + ex.Message);
            }
        }
        private void Set_ID_Driver()
        {
            try
            {
                db = new AlibaRamyEntities();
                var Idd = db.TB_emplo.Where(x => x.emplo_name == Combo_driver.SelectedItem.ToString()&& x.emplo_activity == true).Select(x => x.emplo_id).FirstOrDefault();
                ID_Driver = Idd;

            }
            catch { }
        }
        private void Combo_driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_ID_Driver();
        }
        private bool IsFormDataValid()
        {
            // التحقق من صحة تاريخ dateTimePicker1
            if (!DateTime.TryParse(dateTimePicker1.Text, out _))
            {
                MessageBox.Show("الرجاء إدخال تاريخ صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(Txt_numWasel.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Txt_number.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Txt_pacess.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Combo_branch.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Combo_car.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Combo_driver.Text.Trim())
                
            )
            {
                MessageBox.Show("الرجاء ملء جميع الحقول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private int GetOrderCodeFromDatabase()
        {
            using (var db = new AlibaRamyEntities())
            {
                var orderCode = db.Database.SqlQuery<int>("SELECT dbo.getordercode()").FirstOrDefault();
                return orderCode;
            }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var OrderCode = GetOrderCodeFromDatabase();
                Btn_add.Enabled = false;

                if (!IsFormDataValid())
                {
                    Btn_add.Enabled = true;
                    return;
                }
                if (IN_OUT_STOCK == 1)
                {
                    db = new AlibaRamyEntities();
                    TB_order newItem = new TB_order
                    {
                        user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                        order_date = DateTime.Now,
                        order_items = Convert.ToDecimal(Txt_number.Text),
                        order_unit = Convert.ToDecimal(Txt_pacess.Text),
                        emplo_id = ID_Driver,
                        car_id = ID_Car,
                        driver_name = Combo_driver.Text,
                        car_name = Combo_car.Text,
                        order_nots = Txt_info.Text,
                        order_code = OrderCode,
                        br_id = ID_Branch,
                        action_id = 1,
                        order_status = "مسجل",
                        order_ncode = Txt_numWasel.Text.Trim(),
                        order_ndate = dateTimePicker1.Value,
                    };

                    //اضافة الى قاعدة البيانات بشكل صريح حيث تساعد هذه الحالة في التحقق من صحة البيانات قبل حفظها
                    db.Entry(newItem).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    Addd.SaveData();
                    MessageBox.Show("تمت عملية ادخال المواد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                   
                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " تسجيل نقل داخل " + Addd.GetOrderId();
                    note.AddNote(Note, notifications, "اضافة", 3);

                    Txt_numWasel.Text = "";
                  
                }
                else if (IN_OUT_STOCK == 2)
                {
                    db = new AlibaRamyEntities();
                    TB_order newItem = new TB_order
                    {
                        user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                        order_date = DateTime.Now,
                        order_items = Convert.ToDecimal(Txt_number.Text),
                        order_unit = Convert.ToDecimal(Txt_pacess.Text),
                        emplo_id = ID_Driver,
                        car_id = ID_Car,
                        driver_name = Combo_driver.Text,
                        car_name = Combo_car.Text,
                        order_nots = Txt_info.Text,
                        order_code = OrderCode,
                        br_id = ID_Branch,
                        action_id = 2,
                        order_status = "مسجل",
                        order_ncode = Txt_numWasel.Text.Trim(),
                        order_ndate = dateTimePicker1.Value,
                    };

                  
                    db.Entry(newItem).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    Addd.SaveData();
                    MessageBox.Show("تمت عملية الاخراج بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;

                    
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " تسجيل نقل خارج " + Addd.GetOrderId();
                    note.AddNote(Note, notifications, "اضافة", 3);

                    Txt_numWasel.Text = "";
                }
            }
            catch (Exception ex)
            {
              MessageBox.Show("حدث خطأ في الاتصال بقاعدة البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Btn_add.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }

}



        

    
