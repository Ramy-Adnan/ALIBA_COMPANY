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

namespace ALIBA_COMPANY.Store
{
    public partial class FRM_Save_stock : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        public AddItemsToStore Addd;
        public FRM_Save_stock()
        {
            InitializeComponent();
        }

        private void Btn_add_stock_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var db = new AlibaRamyEntities())
                {

                    TB_stock newItem = new TB_stock
                    {
                        user_id = ALIBA_COMPANY.AddPage.Users.Idd,
                        sto_date = DateTime.Now,
                        sto_nots = Txt_info.Text,
                        sto_unit = Convert.ToDecimal(Txt_pacess.Text),
                        sto_items = Convert.ToDecimal(Txt_number.Text),
                    };
                    db.Entry(newItem).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    Addd.SaveData();

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var username = AddPage.Users.FullName;
                    var Note = " تم اتلاف مواد جديدة من قبل " + username ;
                    note.AddNote(Note, notifications, "اضافة", 3);

                    MessageBox.Show("تمت عملية اتلاف المواد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في الاتصال بقاعدة البيانات:Btn_add_stock_Click " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}