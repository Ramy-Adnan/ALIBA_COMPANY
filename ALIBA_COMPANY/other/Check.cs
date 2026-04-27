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
    public partial class Check : DevExpress.XtraEditors.XtraForm
    {
        public Check()
        {
            InitializeComponent();
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                const string correctCode = "19951995";


                if (Txt.Text == correctCode)
                {

                    Backup F = new Backup();
                    F.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("عذرا هذا الامر للمطورين فقط", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}