using ALIBA_COMPANY.other;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.pages
{
    public partial class Notifications : DevExpress.XtraEditors.XtraUserControl
    {
        TB_Note add;
        int? id;
        public Notifications()
        {
            InitializeComponent();
        }

        public async void LoadData()
        {
            try
            {
                using (var dbContext = new ALIBA_COMPANY.AlibaRamyEntities())
                {
                    var today = DateTime.Today;

                  
                    var notes = await dbContext.TB_Note
                        .Where(mov => DbFunctions.TruncateTime(mov.NoteDate) == today)
                        .ToListAsync();

                    gridControl1.DataSource = notes;
                    lb_state.Visible = !notes.Any();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorloadData" + ex.Message);
            }
        }



        private async void Combo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new ALIBA_COMPANY.AlibaRamyEntities())
                {
                    var today = DateTime.Today;

                    if (Combo_filter.SelectedIndex > -1)
                    {
                        var selectedNoteType = Combo_filter.SelectedItem.ToString();

                      
                        var filteredNotes = await dbContext.TB_Note
                            .Where(mov => DbFunctions.TruncateTime(mov.NoteDate) == today && mov.NoteType == selectedNoteType)
                            .ToListAsync();

                       
                        gridControl1.DataSource = filteredNotes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Combo_filter: خطا في الاتصال حاول مرة ثانية  " + ex.Message);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadData();
            Combo_filter.SelectedIndex = -1;
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    add = new TB_Note();
                    id = Convert.ToInt16(tileView1.GetFocusedRowCellValue("ID"));
                    if (id != 0)
                    {

                        add = db.TB_Note.Where(x => x.ID == id).FirstOrDefault();
                        db.Entry(add).State = EntityState.Deleted;
                        db.SaveChanges();
                        LoadData();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("errortileView1_ItemDoubleClick" + ex.Message);
            }
        }

        private void btn_showlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FRM_system_log newItemForm = new FRM_system_log();

                newItemForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorBtn_dis_users" + ex.Message);
            }
        }

        private void Btn_clearall_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var rs = MessageBox.Show("سيتم حذف كافة الاشعارات , هل تريد المتابعة", "اجراء حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        db.TB_Note.RemoveRange(db.TB_Note);
                        db.SaveChanges();
                        LoadData();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("errorbtn_clearall" + ex.Message);
            }
        }

        /* protected override void Dispose(bool disposing)
{
    if (disposing && (components != null))
    {
        components.Dispose();
    }
    base.Dispose(disposing);
}*/
    }
}
