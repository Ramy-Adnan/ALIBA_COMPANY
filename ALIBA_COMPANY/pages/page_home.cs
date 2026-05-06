using ALIBA_COMPANY.other;
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

namespace ALIBA_COMPANY.pages
{
    public partial class page_home : DevExpress.XtraEditors.XtraUserControl
    {
        public page_home()
        {
            InitializeComponent();
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbldata.Text = DateTime.Now.ToString("yyyy/MM/dd");
            timer1.Start();
          
            
           
           
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            try
            {
                FRM_about newItemForm = new FRM_about();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error FRM_about " + ex.Message);
            }
        }

        private void Chart_Show_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_Dashboard newItemForm = new FRM_Dashboard();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error to open FRM_Dashboard" + ex.Message);
            }
        }

        private void page_home_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserRole == "موزع" || Properties.Settings.Default.UserRole == "امين مخزن" || Properties.Settings.Default.UserRole == "مسؤول الموزعيين")
            {
                Chart_Show.Visible = false;
            }
        }
    }
}


