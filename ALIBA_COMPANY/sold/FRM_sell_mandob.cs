using ALIBA_COMPANY.classes;
using ALIBA_COMPANY.report;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.sold
{
    public partial class FRM_sell_mandob : DevExpress.XtraEditors.XtraForm
    {
        public int sellOrPage=0 ;
        public int ID_travel;
        public FRM_sell_mandob()
        {
            InitializeComponent();
        
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
           
            gridView1.Columns["T"].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.Columns["T"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["T"].OptionsColumn.ReadOnly = true;
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && e.Column.FieldName == "T")
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("هل تريد طباعة وصل ", "تأكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                try
                {
                    // إعداد التقرير
                    XtraReport_Retern report = new XtraReport_Retern
                    {

                        // تعيين dataList كمصدر بيانات للتقرير
                        DataSource = dataList
                    };

                    report.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ في الاتصال - Btn_print_Click: {ex.Message}");
                }
            }

        }
        private List<DataRet> dataList;
        private async void LoadDataInBackground()
        {
            try
            {
                if (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                }
                loading.Visible = true;

                dataList = await Task.Run(async () =>
                {
                    using (var db = new AlibaRamyEntities())
                    {
                        IQueryable<DataRet> query;

                        if (sellOrPage == 1)
                        {
                            query = db.TB_temp
                                .Where(x => x.user_id == AddPage.Users.Idd)
                                .AsNoTracking()
                                .Select(x => new DataRet
                                {
                                    Name = x.TB_items.items_name,
                                    Num = -(x.temp_num) - (x.temp_renum)
                                });
                        }
                        else if (sellOrPage == 2)
                        {
                            query = db.TB_details
                                .Where(x => x.order_id == ID_travel && x.action_id == 3)
                                .AsNoTracking()
                                .Select(x => new DataRet
                                {
                                    Name = x.TB_items.items_name,
                                    Num = x.details_num-x.sell_num
                                });
                        }
                        else
                        {
                            return new List<DataRet>();
                        }

                        // تنفيذ الاستعلام وتحويله إلى قائمة بشكل غير متزامن
                        return await query.ToListAsync();
                    }
                });


                this.Invoke((MethodInvoker)delegate
                {
                    gridControl1.DataSource = dataList;
                });

                loading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في تحديد المواد الراجعة: " + ex.Message);
            }
        }
        private void FRM_sell_mandob_Load(object sender, EventArgs e)
        {
            LoadDataInBackground();
        }
     
    }
}