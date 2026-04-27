using ALIBA_COMPANY.classes;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.traval
{
    public partial class FRM_back_add : DevExpress.XtraEditors.XtraForm
    {
        Note note;
        public int NewOrEdit { get; set; }
        public int ID_traval { get; set; }
        private ALIBA_COMPANY.AlibaRamyEntities dbContext;
        public FRM_back_add()
        {
            InitializeComponent();
            dbContext = new ALIBA_COMPANY.AlibaRamyEntities();
            InitializeGridView();
        }

        private void InitializeGridView()
        {

            gridView1.RowCellStyle += OnRowCellStyle;
            gridView1.CustomColumnDisplayText += OnCustomColumnDisplayText;
        }

        private void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "details_renum")
            {
                decimal? mark = view.GetRowCellValue(e.RowHandle, "details_renum") as decimal?;
                decimal? mark1 = view.GetRowCellValue(e.RowHandle, "details_num") as decimal?;
                decimal? mark2 = view.GetRowCellValue(e.RowHandle, "sell_num") as decimal?;

                if (mark.HasValue && mark1.HasValue && mark2.HasValue)
                {
                    if (mark > (mark1 - mark2) || mark < (mark1 - mark2))
                    {
                        e.Appearance.BackColor = Color.Brown;
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    }
                    else if (mark == (mark1 - mark2))
                    {
                        e.Appearance.BackColor = Color.DarkGreen;
                        e.Appearance.BackColor2 = Color.LightGreen;
                        e.Appearance.ForeColor = Color.White;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                    else if (mark < 0)
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor2 = Color.White;
                        e.Appearance.BackColor = Color.Black;
                    }
                }
                else
                {
                    e.Appearance.BackColor = Color.BurlyWood;
                }
            }
        }

        private void OnCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "colName")
            {
                int id = GetItemId(view, e.ListSourceRowIndex);
                e.DisplayText = GetItemName(id);
            }
            else if (e.Column.FieldName == "colCuart")
            {
                int id = GetItemId(view, e.ListSourceRowIndex);
                e.DisplayText = GetItemCuart(id);
            }
           /* else if (e.Column.FieldName == "colSell")
            {
                int id = GetItemId(view, e.ListSourceRowIndex);
                e.DisplayText = GetItemSell(id);
            }*/
        }

        private int GetItemId(GridView view, int rowIndex)
        {
            object value = view.GetRowCellValue(rowIndex, "items_id");
            return value != null ? Convert.ToInt32(value) : -1000000000;
        }

        private string GetItemName(int id)
        {
            using (var context = new AlibaRamyEntities())
            {
                var item = context.TB_items.FirstOrDefault(i => i.items_id == id);
                return item != null ? item.items_name : "لا يوجد اسم لا توجد بيانات متطابقه";

            }
        }

        private string GetItemCuart(int id)
        {
            using (var context = new AlibaRamyEntities())
            {
                var item = context.TB_items.FirstOrDefault(i => i.items_id == id);
                return item != null ? item.items_form : "لا توجد بيانات متطابقه";
            }
        }

        /* private string GetItemSell(int id)
         {
             using (var context = new AlibaRamyEntities())
             {
                 var item = context.TB_det.Where(i => i.items_id == id && i.TB_list.tr_id == ID_traval).Sum(i => i.de_num);
                 return item != null ? item.ToString() : "لا يوجد اسم لا توجد بيانات متطابقه";
             }
         }*/
       
        private async void LoadDataIntoMemory()
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

                    var data = dbContext.TB_details
                      .Where(x =>  x.order_id == ID_traval)
                      .ToList();
                   

                    // تحديث واجهة المستخدم بالبيانات المحملة
                    this.Invoke((MethodInvoker)delegate
                    {
                        gridControl1.DataSource = data;
                    });
                }); loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة LoadDataIntoMemory(): " + ex.Message);
            }
        }

        private void FRM_back_add_Load(object sender, EventArgs e)
        {
            LoadDataIntoMemory();
        }

        private void Btn_add_Back_Click(object sender, EventArgs e)
        {
            if (HasEmptyCells())
            {
                MessageBox.Show(" البيانات فارغة", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                if (NewOrEdit==0)
                {
                    SaveDataNew();
                }
                else
                {
                    SaveDataEdit();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private bool HasEmptyCells()
        {
            if (gridView1.RowCount>0)
            {
                /*for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var ID_items = gridView1.GetRowCellValue(i, "items_id");
                    var sell_back = gridView1.GetRowCellValue(i, "sell_num");
                    var Number_back = gridView1.GetRowCellValue(i, "details_renum");

                    if (ID_items == null && sell_back == null && Number_back == null)
                    {
                        return true;
                    }
                }*/
                return false;
            }
            else
            {
                return true;
            }
            
        //    return false;
        }

        public void SaveDataNew()
        {
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    var Traval_TR_ST_ID = context.TB_travel.Where(x => x.tr_id == ID_traval).Select(x => x.tr_st_id).FirstOrDefault();
                    if (Traval_TR_ST_ID == 1)
                    {
                        decimal reitem = 0;
                        decimal reunit = 0;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            var ID_items = gridView1.GetRowCellValue(i, "items_id");
                            var Number_back = gridView1.GetRowCellValue(i, "details_renum");
                            var Number_sell = gridView1.GetRowCellValue(i, "sell_num");
                            var Number_above = gridView1.GetRowCellValue(i, "details_num");

                            if (ID_items != null && Number_back != null && Number_sell != null && Number_above != null &&
                                int.TryParse(ID_items.ToString(), out int itemsID) &&
                                decimal.TryParse(Number_back.ToString(), out decimal strRenNum) &&
                                 decimal.TryParse(Number_sell.ToString(), out decimal Num_sell) &&
                                decimal.TryParse(Number_above.ToString(), out decimal Num_above))
                            {
                                reunit += Num_above - Num_sell;
                                if (Num_above - Num_sell > 0)
                                {
                                    reitem += 1;
                                }
                                var ItemSell = context.TB_details.FirstOrDefault(x => x.order_id == ID_traval && x.items_id == itemsID && x.action_id == 3);
                                if (ItemSell != null)
                                {
                                    ItemSell.details_renum = (ItemSell.details_renum ?? 0) + strRenNum;
                                    context.Entry(ItemSell).State = System.Data.Entity.EntityState.Modified;
                                }
                               
                                var Back_add = context.TB_str.FirstOrDefault(x => x.order_id == ID_traval && x.items_id == itemsID && x.action_id == 3);
                                if (ItemSell != null)
                                {
                                    Back_add.str_renum = (Back_add.str_renum ?? 0) + strRenNum;
                                    context.Entry(Back_add).State = System.Data.Entity.EntityState.Modified;
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("بعض المربعات فارغة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        var Traval_back = context.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);
                        if (Traval_back != null)
                        {
                            Traval_back.tr_st_id = 2;
                            Traval_back.tr_st_staus = "راجع";
                            Traval_back.tr_reitems = reitem;
                            Traval_back.tr_reunit = reunit;
                            context.Entry(Traval_back).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            MessageBox.Show("استرجاع القيمةnull هذا يعني السفرة لم تكتمل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        context.SaveChanges();

                        // Add new notification
                        note = new Note();
                        pages.Notifications notifications = new pages.Notifications();
                        var Note = " تثبيت راجع السفرة " + ID_traval + " للموزع " + LblDriver.Text;
                        note.AddNote(Note, notifications, "تقييد راجع", 1);

                        MessageBox.Show("تم ادخال الراجع بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                    MessageBox.Show("لا يمكن ادخال الراجع مرتين", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveData()_sell  حدث خطأ في ادخال المواد: " + ex.Message);
            }
        }
        public void SaveDataEdit()
        {
            try
            {
                using (var context = new AlibaRamyEntities())
                {
                    
                    decimal reitem = 0;
                    decimal reunit = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        var ID_items = gridView1.GetRowCellValue(i, "items_id");
                        var Number_back = gridView1.GetRowCellValue(i, "details_renum");
                        var Number_sell = gridView1.GetRowCellValue(i, "sell_num");
                        var Number_above = gridView1.GetRowCellValue(i, "details_num");

                        if (ID_items != null && Number_back != null && Number_sell != null && Number_above != null &&
                            int.TryParse(ID_items.ToString(), out int itemsID) &&
                            decimal.TryParse(Number_back.ToString(), out decimal strRenNum) &&
                             decimal.TryParse(Number_sell.ToString(), out decimal Num_sell) &&
                            decimal.TryParse(Number_above.ToString(), out decimal Num_above))
                        {
                            reunit += Num_above - Num_sell;
                            if (Num_above - Num_sell > 0)
                            {
                                reitem += 1;
                            }
                            var ItemSell = context.TB_details.FirstOrDefault(x => x.order_id == ID_traval && x.items_id == itemsID && x.action_id == 3);
                            if (ItemSell != null)
                            {
                                ItemSell.details_renum = strRenNum;
                                context.Entry(ItemSell).State = System.Data.Entity.EntityState.Modified;
                            }

                            var Back_add = context.TB_str.FirstOrDefault(x => x.order_id == ID_traval && x.items_id == itemsID && x.action_id == 3);
                            if (ItemSell != null)
                            {
                                Back_add.str_renum = strRenNum;
                                context.Entry(Back_add).State = System.Data.Entity.EntityState.Modified;
                            }

                        }
                        else
                        {
                            MessageBox.Show("بعض المربعات فارغة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    var Traval_back = context.TB_travel.FirstOrDefault(x => x.tr_id == ID_traval);
                    if (Traval_back != null)
                    {
                        Traval_back.tr_st_id = 2;
                        Traval_back.tr_st_staus = "راجع";
                        Traval_back.tr_reitems = reitem;
                        Traval_back.tr_reunit = reunit;
                        context.Entry(Traval_back).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("استرجاع القيمةnull هذا يعني السفرة لم تكتمل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    context.SaveChanges();

                    // Add new notification
                    note = new Note();
                    pages.Notifications notifications = new pages.Notifications();
                    var Note = " تعديل السفرة " + ID_traval;
                    note.AddNote(Note, notifications, "تعديل", 4);

                    MessageBox.Show("تم تعديل الراجع بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveData()_sell  حدث خطأ في ادخال المواد: " + ex.Message);
            }
        }

        private void FRM_back_add_FormClosing(object sender, FormClosingEventArgs e)
        {
           
              
            gridView1.RowCellStyle -= OnRowCellStyle;
            gridView1.CustomColumnDisplayText += OnCustomColumnDisplayText;

          
            gridControl1.DataSource = null;

                
            if (dbContext != null)
            {
            dbContext.Dispose();
            dbContext = null;
            }

            if (gridControl1 != null)
            {
                gridControl1.Dispose();
                gridControl1 = null;
            }
            CleanUpControls(this);
            GC.Collect();
            
        }
        private void CleanUpControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is IDisposable)
                {
                    (control as IDisposable).Dispose();
                }
                if (control.HasChildren)
                {
                    CleanUpControls(control);
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
/* public class MultiSelectionEditingHelper
 {
     private GridView _View;

     public MultiSelectionEditingHelper(GridView view)
     {
         _View = view;
         //_View.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDownFocused;
         _View.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(_View_CellValueChanged);
     }



     void _View_CellValueChanged(object sender, CellValueChangedEventArgs e)
     {
         // We only want to do this if cell has been changed manually.
         try
         {
             foreach (GridView view in _View.GridControl.Views)
             {
                 if ((view.FocusedColumn.AbsoluteIndex == e.Column.AbsoluteIndex)
                     && (view.FocusedColumn.Name == e.Column.Name)
                     && (view.FocusedRowHandle == e.RowHandle))
                 {
                     OnCellValueChanged(view, e);
                     break;
                 }
             }
         }
         finally
         {
         }
     }

     private void OnCellValueChanged(GridView view, CellValueChangedEventArgs e)
     {
         SetSelectedCellsValues(view, e.Value);
     }

     private void SetSelectedCellsValues(GridView view, object value)
     {
         try
         {

             //Getting focused cells custom editor:
             GridViewInfo vi = view.GetViewInfo() as GridViewInfo;
             GridDataRowInfo ri = vi.RowsInfo.FindRow(view.FocusedRowHandle) as GridDataRowInfo;
             RepositoryItem desiredEditor = ri.Cells[view.FocusedColumn].Editor;

             GridCell[] cells = view.GetSelectedCells();

             view.ClearSelection();

             foreach (GridCell cell in cells)
             {
                 if (view.FocusedColumn.AbsoluteIndex == cell.Column.AbsoluteIndex)
                 {
                     view.FocusedRowHandle = cell.RowHandle;
                     view.FocusedColumn = cell.Column;
                     // view.ShowEditor();
                     view.SetRowCellValue(cell.RowHandle, cell.Column, value);
                     // view.EditingValue = value;
                     view.ValidateEditor();
                     view.CloseEditor();
                     // view.FocusedRowHandle = view.FocusedRowHandle + 1;
                 }
             }
         }
         catch (Exception e)
         {
         }
         finally
         {
             //view.EndUpdate();
         }
     }

     private bool GetInSelectedCell(MouseEventArgs e)
     {
         DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = _View.CalcHitInfo(e.Location);
         return hi.InRowCell && _View.IsCellSelected(hi.RowHandle, hi.Column);
     }

 }*/

