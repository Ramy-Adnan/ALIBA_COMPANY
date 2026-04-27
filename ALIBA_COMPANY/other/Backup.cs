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
    public partial class Backup : DevExpress.XtraEditors.XtraForm
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog folder = new OpenFileDialog();
                var rs = folder.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        string dbname = db.Database.Connection.Database;
                        string dbBackUp = "EPSback" + DateTime.Now.ToString("yyyyMMddHHmm");
                        string sqlCommand = @"Use master;Restore DATABASE [{0}] From  DISK = '" + folder.FileName + "'";
                        int path = db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname));
                        MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لا يمكن استعادة النسخة الاحتياطية, يرجى التأكد من الملف المختار" + ex.Message.ToString());
            }
        }
    }
}