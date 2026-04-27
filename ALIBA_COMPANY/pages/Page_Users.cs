using ALIBA_COMPANY.AddPage;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.pages
{
    public partial class Page_Users : DevExpress.XtraEditors.XtraUserControl
    {
        private ALIBA_COMPANY.AlibaRamyEntities db;
        private RepositoryItemComboBox repositoryItemComboBox;
        public Page_Users()
        {
            InitializeComponent();
            db = new ALIBA_COMPANY.AlibaRamyEntities();

            // تكوين RepositoryItemComboBox
            repositoryItemComboBox = new RepositoryItemComboBox();
            repositoryItemComboBox.Items.AddRange(new string[] { "مدير", "مدير الحسابات", "حسابات", "امين مخزن", "اداري", "مسؤول الموزعيين", "موزع" });
            repositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // ربط RepositoryItemComboBox بالعمود المناسب
            gridView1.Columns["user_role"].ColumnEdit = repositoryItemComboBox;
            gridView1.RowUpdated += gridView1_RowUpdated;
        }

        private async void LoadDataIntoGrid()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;

                await Task.Run(() =>
                {
                    var data = db.TB_users.ToList();

                  
                    this.Invoke((MethodInvoker)delegate
                    {
                        gridControl1.DataSource = data;
                    });
                });
                loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في LoadDataIntoGrid(): " + ex.Message);
            }
        }

        private void Page_Users_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ البيانات: " + ex.Message);
            }
        }

        private void Btn_details_Click(object sender, EventArgs e)
        {
            FRM_AddUser AddForm = new FRM_AddUser(); 
           
           
            AddForm.FormClosed += (s, args) =>
            {
                if (AddForm.DialogResult == DialogResult.OK)
                {
                    LoadDataIntoGrid();
                }
            };

            AddForm.ShowDialog();
        }
    }
}
