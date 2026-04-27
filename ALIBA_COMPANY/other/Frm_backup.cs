using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class Frm_backup : DevExpress.XtraEditors.XtraForm
    {
        private string msg;
        public Frm_backup()
        {
            InitializeComponent();
        }
        private void GetSettings()
        {
            try
            {
                Edt_comp.Text = Properties.Settings.Default.CompanyName;
                Edt_compdes.Text = Properties.Settings.Default.CompanyDes;
                if (Properties.Settings.Default.CompanyLogo!=null)
                { // Set Logo
                    var Bytimage = Convert.FromBase64String(Properties.Settings.Default.CompanyLogo);
                    if (Bytimage != null)
                    {
                        var ma = new MemoryStream(Bytimage);
                        pic_logo.Image = Image.FromStream(ma);
                    }
                }

            }
            catch
            {
            }
        }
        private void SaveSetting()
        {
            try
            {
                Properties.Settings.Default.CompanyName = Edt_comp.Text;
                Properties.Settings.Default.CompanyDes = Edt_compdes.Text;
                if (pic_logo.Image != null)
                {
                    // Set Logo
                    var ma = new MemoryStream();
                    pic_logo.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                    Properties.Settings.Default.CompanyLogo = Convert.ToBase64String(ma.ToArray());
                    Properties.Settings.Default.Save();
                    MessageBox.Show("سيتم تطبيق الاعدادات عند اعادة تشغيل البرنامج");
                }
                else
                {
                    MessageBox.Show("يجب اختيار لوكو لحفظ الاعدادات");
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Btn_backup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var rs = fbd.ShowDialog();
            if (rs == DialogResult.OK)
            {
                loading.Visible = true;
                var state = await Task.Run(() => BackUp(fbd));

                if (state == true)
                {
                    MessageBox.Show("تمت عملية النسخ الاحتياطي بنجاح");
                }
                else
                {
                    MessageBox.Show(msg);
                }

                loading.Visible = false;
            }

        }

        private bool BackUp(FolderBrowserDialog folder)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    string dbname = db.Database.Connection.Database;
                    string dbBackUp = "AlibaRamy" + DateTime.Now.ToString("yyyyMMddHHmm");
                    var fullpath = folder.SelectedPath.ToString() + dbBackUp + ".bak";
                    string sqlCommand = @"BACKUP DATABASE [{0}] TO  DISK = '" + fullpath + "' WITH NOFORMAT, NOINIT,  NAME = N'AlibaRamy', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                    int path = db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname, dbBackUp));
                    return true;
                }


            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;

            }
        }

        private void btn_savegen_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void Frm_backup_Load(object sender, EventArgs e)
        {
            GetSettings();
        }
    }
}