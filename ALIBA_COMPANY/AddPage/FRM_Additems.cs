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
using ALIBA_COMPANY.pages;
using System.Globalization;
using System.Media;
using System.IO;
using ALIBA_COMPANY.classes;

namespace ALIBA_COMPANY.AddPage
{
    public partial class FRM_Additems : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        AlibaRamyEntities db;
        public int ID_Category;
        public int nID_Category;
        private int? _buyId; // متغير اختياري لتخزين BuyId
        int itemID; // متغير لاستيعاب المفتاح الرئيسي
        public static int addoredit_combo { get; set; }
        public static string addoredit { get; set; }



        public FRM_Additems(int? buyId = null)
        {
            InitializeComponent();
            db = new AlibaRamyEntities();

            // تهيئة مشغل الصوت لتشغيل موسيقى
            _buyId = buyId;

           
           
            LoadCategories();            
            if (_buyId > 0)
            {
                itemID = (int)_buyId;
                LoadData(); 
            }
            // pic_editImage.MouseClick += pic_editImage_MouseClick;

            txt_UpriceUs.KeyPress += (sender, e) => RAMY.HandleTextBoxKeyPress(sender, e, 20);
            txt_LpriceUs.KeyPress += (sender, e) => RAMY.HandleTextBoxKeyPress(sender, e, 20);
            txt_LpriceIQ.KeyPress += (sender, e) => RAMY.HandleTextBoxKeyPress(sender, e, 20);
            txt_UpriceIQ.KeyPress += (sender, e) => RAMY.HandleTextBoxKeyPress(sender, e, 20);
            txt_exchangPrice.KeyPress += (sender, e) => RAMY.HandleTextBoxKeyPress(sender, e, 20);

            txt_UpriceUs.Leave += (sender, e) => RAMY.HandleTextLeave(sender, txt_UpriceUs);
            txt_LpriceUs.Leave += (sender, e) => RAMY.HandleTextLeave(sender, txt_LpriceUs);
            txt_LpriceIQ.Leave += (sender, e) => RAMY.HandleTextLeave(sender, txt_LpriceIQ);
            txt_UpriceIQ.Leave += (sender, e) => RAMY.HandleTextLeave(sender, txt_UpriceIQ);
            txt_exchangPrice.Leave += (sender, e) => RAMY.HandleTextLeave(sender, txt_exchangPrice);
        }
        

        private void LoadData()
        {
            try
            {
               

                var selectedItem = db.TB_items.FirstOrDefault(x => x.items_id == itemID);

                if (selectedItem != null)
                {
                    txt_nameAR.Text = selectedItem.items_name;
                    txt_nameEn.Text = selectedItem.items_enname;
                    txt_parcode.Text = selectedItem.items_code;
                    txt_form.Text = selectedItem.items_form;
                    txt_quart.Text = selectedItem.items_quart.ToString();
                    txt_info.Text = selectedItem.items_nots;
                    txt_UpriceUs.Text = selectedItem.Usd_upper.ToString();
                    txt_LpriceUs.Text = selectedItem.Usd_lower.ToString();
                    txt_exchangPrice.Text = selectedItem.exchang.ToString();
                    txt_UpriceIQ.Text = selectedItem.IQD_upper.ToString();
                    txt_LpriceIQ.Text = selectedItem.IQD_lower.ToString();
                    combo_CAT.SelectedValue = selectedItem.groups_id;

                    if (!string.IsNullOrEmpty(selectedItem.items_pic) && File.Exists(selectedItem.items_pic))
                    {
                        pic_editImage.Image = Image.FromFile(selectedItem.items_pic);
                    }
                    else
                    {
                        pic_editImage.Image = Properties.Resources.aliba;
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على العنصر المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsFormDataValid()
        {
            if (string.IsNullOrWhiteSpace(txt_nameAR.Text) ||
                string.IsNullOrWhiteSpace(txt_nameEn.Text) ||
                string.IsNullOrWhiteSpace(txt_parcode.Text) ||
                string.IsNullOrWhiteSpace(txt_form.Text) ||
                string.IsNullOrWhiteSpace(txt_quart.Text) ||
                string.IsNullOrWhiteSpace(txt_UpriceUs.Text) ||
                string.IsNullOrWhiteSpace(txt_LpriceUs.Text) ||
                string.IsNullOrWhiteSpace(txt_exchangPrice.Text) ||
                string.IsNullOrWhiteSpace(txt_UpriceIQ.Text) ||
                string.IsNullOrWhiteSpace(txt_LpriceIQ.Text))
            {
                MessageBox.Show("الرجاء ملء جميع الحقول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void UpdateDataInMainForm()
        {
            try
            {
                if (!IsFormDataValid())
                {
                    return;
                }

                var selectedItem = db.TB_items.FirstOrDefault(x => x.items_id == itemID);

                if (selectedItem != null)
                {
                    selectedItem.items_name = txt_nameAR.Text.Trim();
                    selectedItem.items_enname = txt_nameEn.Text.Trim();
                    selectedItem.items_code = txt_parcode.Text.Trim();
                    selectedItem.items_form = txt_form.Text.Trim();
                    selectedItem.items_quart = Convert.ToByte(txt_quart.Text.Trim());
                    selectedItem.items_nots = txt_info.Text.Trim();
                    selectedItem.Usd_upper = Convert.ToDecimal(txt_UpriceUs.Text.Trim());
                    selectedItem.Usd_lower = Convert.ToDecimal(txt_LpriceUs.Text.Trim());
                    selectedItem.exchang = Convert.ToDecimal(txt_exchangPrice.Text.Trim());
                    selectedItem.IQD_upper = Convert.ToDecimal(txt_UpriceIQ.Text.Trim());
                    selectedItem.IQD_lower = Convert.ToDecimal(txt_LpriceIQ.Text.Trim());
                    selectedItem.groups_id = Convert.ToByte(combo_CAT.SelectedValue);

                    addoredit = txt_nameAR.Text.Trim();

                    db.Entry(selectedItem).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;

                    MessageBox.Show("تم التعديل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على العنصر المحدث.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التعديل: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    private void btn_edit_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("هل تريد التعديل", "تاكييد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs==DialogResult.Yes)
            {
                UpdateDataInMainForm();
            }
        }
        private void txt_exchangPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '$')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
        }

        private void txt_LpriceUs_KeyPress(object sender, KeyPressEventArgs e)
        {
            // تحقق مما إذا كان الحرف المدخل هو رقم أو رمز عملة الدولار أو فاصلة عشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '$' && e.KeyChar != '.')
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }

            // تحقق من وجود فاصلة عشرية والسماح بإدخالها لمرة واحدة فقط
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // تجاهل الفاصلة العشرية إذا تم إدخالها مرتين أو أكثر
            }
        }

        private void LoadCategories()
        {
            try
            {
               
                var categories = db.TB_groups.Select(x => new { x.groups_id, x.groups_name }).ToList();
                combo_CAT.DataSource = categories;
                combo_CAT.DisplayMember = "groups_name";
                combo_CAT.ValueMember = "groups_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل الفئات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateProduct1()
        {
            // التأكد من أن القيم في التيكست بوكسين هي قيم رقمية صحيحة
            if (decimal.TryParse(txt_UpriceUs.Text, out decimal value1) && decimal.TryParse(txt_exchangPrice.Text, out decimal value2))
            {
                // ضرب القيمتين ووضع الناتج في التيكست بوكس الثالث
                decimal result = value1 * value2;

                // تقريب الناتج إلى أقرب 250
                decimal roundedResult = Math.Round(result / 250) * 250;

                // وضع النتيجة النهائية في تيكست بوكس 3
                txt_UpriceIQ.Text = roundedResult.ToString();

            }
            else
            {
                // إذا لم يكن الإدخال صحيحًا، قم بتفريغ التيكست بوكس الثالث
                txt_UpriceIQ.Text = string.Empty;
            }
        }

        private void CalculateProduct2()
        {
            // التأكد من أن القيم في التيكست بوكسين هي قيم رقمية صحيحة
            if (decimal.TryParse(txt_LpriceUs.Text, out decimal value1) && decimal.TryParse(txt_exchangPrice.Text, out decimal value2))
            {
                // ضرب القيمتين ووضع الناتج في التيكست بوكس الثالث
                decimal result = value1 * value2;

                // تقريب الناتج إلى أقرب 250
                decimal roundedResult = Math.Round(result / 250) * 250;

                // وضع النتيجة النهائية في تيكست بوكس 3
                txt_LpriceIQ.Text = roundedResult.ToString();

            }
            else
            {
                // إذا لم يكن الإدخال صحيحًا، قم بتفريغ التيكست بوكس الثالث
                txt_LpriceIQ.Text = string.Empty;
            }
        }

        private void txt_UpriceUs_TextChanged(object sender, EventArgs e)
        {
            CalculateProduct1();
        }

        private void txt_exchangPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateProduct1();
            CalculateProduct2();
        }

        private void txt_LpriceUs_TextChanged(object sender, EventArgs e)
        {
            CalculateProduct2();
        }
        public string selectedImagePath;
        private SoundPlayer player;

       
        private void SaveImagePathToDatabase(string imagePath)
        {
            try
            {
               
                var selectedItem = db.TB_items.FirstOrDefault(x => x.items_id == itemID);

                if (selectedItem != null)
                {
                   
                    selectedItem.items_pic = imagePath;

                   
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على العنصر المحدث", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsItemExists(string itemNameAr, string itemCode, string itemNameEn)
        {

            var existingItem = db.TB_items.FirstOrDefault(x => x.items_name == itemNameAr || x.items_code == itemCode || x.items_enname == itemNameEn);
            return existingItem != null;
        }
        //متغيير عام
        public static int AddedItemId { get; set; }
        private void btn_save_Click(object sender, EventArgs e)
        {
            
                var validator = new Validator(db);

                // الحصول على الاسم من TextBox
                var itemName = txt_nameAR.Text.Trim();

                // تحقق من وجود العميل بناءً على الاسم المدخل في TextBox
                if (validator.ItemExists(itemName))
                {
                    MessageBox.Show("لا يمكن ادخال اسم مادة موجود سابقا \n اختر اسم ثاني", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // إيقاف العملية إذا كان العميل موجودًا بالفعل
                }

                if (!IsFormDataValid())
                {
                    return;
                }
                string itemNameAr1 = txt_nameAR.Text.Trim();
                string itemCode2 = txt_parcode.Text.Trim();
                string itemNameEn3 = txt_nameEn.Text.Trim();
                // التحقق مما إذا كانت المادة موجودة سابقًا
                if (IsItemExists(itemNameAr1, itemCode2, itemNameEn3))
                {
                    MessageBox.Show("الاسم العربي او الاسم الانكليزي او كود المادة موجود سابقا", "تكرار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // لا تقم بإضافة المادة إلى قاعدة البيانات
            }
            // التحقق من تحديد صنف
            if (combo_CAT.SelectedValue == null)
            {
                MessageBox.Show("الرجاء تحديد صنف من القائمة.");
                return;
            }
            // التحقق من صحة القيمة المحددة
            int selectedGroupId;
            if (!int.TryParse(combo_CAT.SelectedValue.ToString(), out selectedGroupId))
            {
                MessageBox.Show("قيمة الصنف غير صالحة.");
                return;
            }
            // قراءة القيمة المحددة من combo_CAT
            string selectedCategory = combo_CAT.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    // الحصول على cat_id المحدد من combo_CAT
                   // int catId = db.TB_groups.Where(x => x.groups_name == selectedCategory).Select(x => x.groups_id).FirstOrDefault();

                  
                    string itemnamear = txt_nameAR.Text.Trim();
                    string itemnameen = txt_nameEn.Text.Trim();
                    string itemparcode = txt_parcode.Text.Trim();
                    string itemform = txt_form.Text.Trim();
                    string itemquart = txt_quart.Text.Trim();
                    string iteminfo = txt_info.Text.Trim();
                    string itemupriceus = txt_UpriceUs.Text.Trim();
                    string itemlpriceus = txt_LpriceUs.Text.Trim();
                    string itemexchang = txt_exchangPrice.Text.Trim();
                    string itemupriceiqd = txt_UpriceIQ.Text.Trim();
                    string itemlpriceiqd = txt_LpriceIQ.Text.Trim();
                    string imgpath = selectedImagePath;

                    // إنشاء مادة جديدة في قاعدة البيانات مع الـ cat_id المحدد
                    // إنشاء مادة جديدة في قاعدة البيانات
                    db = new AlibaRamyEntities();
                    TB_items newItem = new TB_items
                    {
                        items_name = itemnamear,
                        items_enname = itemnameen,
                        items_code = itemparcode,
                        items_form = itemform,
                        items_quart = Convert.ToByte(itemquart),
                        items_nots = iteminfo,
                        Usd_upper = Convert.ToDecimal(itemupriceus),
                        Usd_lower = Convert.ToDecimal(itemlpriceus),
                        exchang = Convert.ToDecimal(itemexchang),
                        IQD_upper = Convert.ToDecimal(itemupriceiqd),
                        IQD_lower = Convert.ToDecimal(itemlpriceiqd),
                        groups_id = Convert.ToByte(selectedGroupId), // إضافة cat_id
                        items_pic = imgpath
                    };

                    //اضافة الى قاعدة البيانات بشكل صريح حيث تساعد هذه الحالة في التحقق من صحة البيانات قبل حفظها
                    db.Entry(newItem).State = System.Data.Entity.EntityState.Added;

                    AddedItemId = newItem.items_id;
                    addoredit = newItem.items_name;
                    //  بشكل اعتياديي إضافة المادة الجديدة إلى قاعدة البيانات
                    // db.TB_items.Add(newItem);
                    db.SaveChanges();
                   
                    MessageBox.Show("تمت إضافة المادة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " اضافة المادة " + addoredit;
                    note.AddNote(Note, notifications, "اضافة", 3);
                }
                else
                {
                    MessageBox.Show("الرجاء تحديد الصنف ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            
         


        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txt_quart_KeyPress(object sender, KeyPressEventArgs e)
        {
            // التحقق من أن الحرف المدخل هو رقم صحيح أو مفتاح تحكم
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // تجاهل الحرف المدخل
            }
        }

        private void FRM_Additems_FormClosed(object sender, FormClosedEventArgs e)
        {
            // إيقاف تشغيل الموسيقى قبل إغلاق الفورم
            if (player != null)
            {
                player.Stop();
                player.Dispose();
            }
        }

        private void pic_editImage_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "اختر صورة";
                openFileDialog.Filter = "صور|*.jpg;*.png;*.bmp|جميع الملفات|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    try
                    {
                        // محاولة تحميل الصورة
                        Image image = Image.FromFile(selectedImagePath);

                        // إذا كانت الصورة صالحة، قم بتعيينها إلى pic_editImage
                        pic_editImage.Image = image;

                        if (addoredit_combo == 2)
                        {
                            DialogResult result = MessageBox.Show("هل ترغب في حفظ الصورة المحددة؟", "تأكيد الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            // التحقق من إجابة المستخدم
                            if (result == DialogResult.Yes)
                            {
                                player = new SoundPlayer(@"C:\Users\AL-BURAQ\Music\ww.wav");
                                // تشغيل الموسيقى
                                player.Play();
                                pic_editImage.Image = image;
                                // حفظ مسار الصورة المحدثة في قاعدة البيانات
                                SaveImagePathToDatabase(selectedImagePath);

                                // احصل على المسار الذي يتم تشغيل التطبيق منه وأضف إليه اسم ملف الصوت
                                /* string soundFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ww.wav");

                                 // تحقق إذا كان ملف الصوت موجودًا في المسار المحدد
                                 if (System.IO.File.Exists(soundFilePath))
                                 {
                                     player = new SoundPlayer(soundFilePath);
                                     // تشغيل الموسيقى
                                     player.Play();
                                 }
                                 else
                                 {
                                     MessageBox.Show("ملف الصوت غير موجود في دليل التطبيق.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }*/
                            }
                            // لا حاجة لتحميل الصورة في حالة الإجابة "لا"
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        // عرض رسالة خطأ إذا كان الملف ليس صورة صالحة
                        MessageBox.Show("الملف المحدد ليس صورة صالحة. يرجى اختيار صورة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // التعامل مع أي استثناءات أخرى قد تحدث
                        MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txt_UpriceUs_MouseDown(object sender, MouseEventArgs e)
        {
            txt_UpriceUs.SelectAll();
        }

        private void txt_LpriceUs_MouseDown(object sender, MouseEventArgs e)
        {
            txt_LpriceUs.SelectAll();
        }

        private void txt_exchangPrice_MouseDown(object sender, MouseEventArgs e)
        {
            txt_exchangPrice.SelectAll();
        }

        private void txt_UpriceIQ_MouseDown(object sender, MouseEventArgs e)
        {
            txt_UpriceIQ.SelectAll();
        }

        private void txt_LpriceIQ_MouseDown(object sender, MouseEventArgs e)
        {
            txt_LpriceIQ.SelectAll();
        }

        private void txt_quart_TextChanged(object sender, EventArgs e)
        {
            if (!byte.TryParse(txt_quart.Text, out byte value) || value > 255)
            {
                MessageBox.Show("القيمة يجب أن تكون بين 0 و 255");
            }
           
        }
    }


    
}
