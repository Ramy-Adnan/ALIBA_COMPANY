using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ALIBA_COMPANY
{
    public partial class FRM_Share : XtraForm
    {
        AlibaRamyEntities db;
        public int ID_User = 0;
        string imgPath = "";

        public FRM_Share()
        {
            InitializeComponent();
            db = new AlibaRamyEntities();
        }

        private void FRM_Share_Load(object sender, EventArgs e)
        {
            LoadDrivers();
            SetAdsType();

        }

        // تحميل الموزعين
        private void LoadDrivers()
        {
            // بدل Anonymous Type، استخدم KeyValuePair
            var list = db.TB_users
                .Where(x => x.user_activity && x.user_role == "موزع")
                .Select(x => new { Name = x.user_FullName, Id = x.user_id })
                .ToList();

            Combo_User.DataSource = list;
            Combo_User.DisplayMember = "Name";
            Combo_User.ValueMember = "Id";
            Combo_User.EndUpdate();
            XtraMessageBox.Show("عدد الموزعين: " + list.Count.ToString());
        }
        // تحديد ID
        private void Combo_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_User.SelectedValue != null)
            {
                // استخدم int.Parse بدل Convert.ToInt32
                if (int.TryParse(Combo_User.SelectedValue.ToString(), out int id))
                {
                    ID_User = id;
                }
            }
        }
        // تغيير نوع الإعلان
        private void SetAdsType()
        {
            bool isPrivate = rdoPrivate.Checked;

            Combo_User.Visible = isPrivate;
            lblUser.Visible = isPrivate;

            if (!isPrivate)
                ID_User = 0;
        }

        private void rdoPublic_CheckedChanged(object sender, EventArgs e) => SetAdsType();
        private void rdoPrivate_CheckedChanged(object sender, EventArgs e) => SetAdsType();

        // اختيار صورة
        private void pic_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic.Image = Image.FromFile(ofd.FileName);
                imgPath = ofd.FileName;
            }
        }

        // حفظ
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    XtraMessageBox.Show("أدخل العنوان");
                    return;
                }

                if (rdoPrivate.Checked && ID_User == 0)
                {
                    XtraMessageBox.Show("اختر موزع");
                    return;
                }

                if (string.IsNullOrEmpty(imgPath))
                {
                    XtraMessageBox.Show("اختر صورة");
                    return;
                }

                string dir = @"E:\flutter\AlibaCompany\backendsql\public\images";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string ext = Path.GetExtension(imgPath);
                string fileName = "ad_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string fullPath = Path.Combine(dir, fileName);

                File.Copy(imgPath, fullPath, true);

                TB_ads ad = new TB_ads
                {
                    title = txtTitle.Text,
                    subtitle = txtDesc.Text,
                    ad_type = rdoPrivate.Checked ? "موزع" : "عام",
                    user_id = rdoPrivate.Checked ? (int?)ID_User : null,
                    image_url = "https://api.alliba.uk/images/"+fileName,
                    created_at = DateTime.Now,
                    sort_order = 0,
                    is_active = true,
                };

                db.TB_ads.Add(ad);
                db.SaveChanges();

                XtraMessageBox.Show("تم الحفظ بنجاح ✅");
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ: " + ex.Message);
            }
        }
    }
}