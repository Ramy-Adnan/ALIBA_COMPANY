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

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_Save_Traval_create : DevExpress.XtraEditors.XtraForm
    {
        AlibaRamyEntities db;
        Note note;
        string EmploName;
        public int ID_City;
        public int ID_Car;
        public int ID_Driver;
        public AddTraval Addd;
        public FRM_Save_Traval_create()
        {
            InitializeComponent();
        }
       
   
        private void LoadCity()
        {
             try
             {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var city = dbbb.TB_city.Select(x => x.city_name).ToList();
                    city.Insert(0, "");
                    Combo_city.DataSource = city;
                }
             }
            catch (Exception ex)
             {

                MessageBox.Show(" حدث خطأ أثناء تحميل المحافظات: " + ex.Message);
             }
        }
        private void Set_ID_City()
        {
            try
            {
                db = new AlibaRamyEntities();
                var Idd = db.TB_city.Where(x => x.city_name == Combo_city.SelectedItem.ToString()).Select(x => x.city_id).FirstOrDefault();
                ID_City = Idd;

            }
            catch { }
          
        }
        private void Combo_city_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Set_ID_City();
        }
        private void LoadCars()
        {
            try
            {
                using (var dbbb = new AlibaRamyEntities())
                {

                    var car = dbbb.TB_cars.Where(x => x.car_activity == true && x.car_traval_active == false).Select(x => x.car_name).ToList();
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
                var Idd = db.TB_cars.Where(x => x.car_name == Combo_car.SelectedItem.ToString()&& x.car_activity == true && x.car_traval_active == false).Select(x => x.car_id).FirstOrDefault();
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

                    var emplo = dbbb.TB_emplo.Where(x => x.emplo_activity == true && x.emplo_traval_active == false && x.emplo_dis == true).Select(x => x.emplo_name).ToList();
                    emplo.Insert(0, "");
                    Combo_emplo.DataSource = emplo;
                   
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
                var Idd = db.TB_emplo.Where(x => x.emplo_name == Combo_emplo.SelectedItem.ToString()&& x.emplo_activity == true && x.emplo_traval_active == false && x.emplo_dis == true).Select(x => x.emplo_id).FirstOrDefault();
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

            if (
                string.IsNullOrWhiteSpace(Txt_number.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Txt_pacess.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Combo_city.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Combo_car.Text.Trim()) ||
                string.IsNullOrWhiteSpace(Combo_emplo.Text.Trim())
                
            )
            {
                MessageBox.Show("الرجاء ملء جميع الحقول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        public DateTime GetDate()
        {
            return dateTimePicker1.Value.Date;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
               
                Btn_add.Enabled = false;
                if (!IsFormDataValid())
                {
                    Btn_add.Enabled = true;
                    return;
                }
                db = new AlibaRamyEntities();
                TB_travel newItem = new TB_travel
                {
                    user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                    tr_date = dateTimePicker1.Value,
                    tr_items = Convert.ToDecimal(Txt_number.Text),
                    tr_unit = Convert.ToDecimal(Txt_pacess.Text),
                    emplo_id = ID_Driver,
                    car_id = ID_Car,
                    tr_nots = Txt_info.Text,
                    tr_st_id = 1,
                    tr_st_staus = "قيد التوزيع",
                    city_id = ID_City,
                    action_id = 3,
                    tr_loading = 1,
                    tr_sending = false
                };

                //اضافة الى قاعدة البيانات بشكل صريح حيث تساعد هذه الحالة في التحقق من صحة البيانات قبل حفظها
                db.Entry(newItem).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                Addd.SaveData(dateTimePicker1.Value);
                UpdateEmplo();
                UpdateCar();

                // Add new notification
                note = new Note();
                pages.Notifications notifications = new pages.Notifications();
                var Note = "تسجيل سفرة " + Addd.lastOrderId + " للسائق "+ EmploName;
                note.AddNote(Note, notifications, "اضافة" , 3);

                MessageBox.Show("تم انشاء السفرة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Btn_add.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("AddTravalBtn() حدث خطأ في الاتصال بقاعدة البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void UpdateEmplo()
        {
            using (db = new AlibaRamyEntities())
            {

                var emplo = db.TB_emplo.FirstOrDefault(x => x.emplo_id == ID_Driver);
                emplo.emplo_traval_active = true;
                EmploName = emplo.emplo_name;
                db.Entry(emplo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
             
              
            }
        }
        private void UpdateCar()
        {
            using (db = new AlibaRamyEntities())
            {

                var car = db.TB_cars.FirstOrDefault(x => x.car_id == ID_Car);
                car.car_traval_active = true;
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
              
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FRM_Save_Traval_create_Load(object sender, EventArgs e)
        {
            LoadCity();
            Set_ID_City();
            LoadCars();
            Set_ID_Cars();
            LoadDrivers();
            Set_ID_Driver();
        }
    }

}



        

    
