using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_Dashboard : XtraForm
    {
        public FRM_Dashboard()
        {
            InitializeComponent();
         


        }


        // ════════════════════════════════════════════════════════════
        // مساعدات UI
        // ════════════════════════════════════════════════════════════
        private void MkLabel(Label lbl, string text, Point loc)
        {
            lbl.Text = text;
            lbl.Font = new Font("Cairo SemiBold", 10f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(200, 220, 255);
            lbl.Location = loc;
            lbl.AutoSize = true;
            lbl.TextAlign = ContentAlignment.MiddleRight;
            this.pnlFilter.Controls.Add(lbl);
        }

        private void MkKpiCard(Panel panel, Label valLabel,
            string title, string defVal,
            Color accentColor, Color bgColor, int x, int y)
        {
            panel.BackColor = bgColor;
            panel.BorderStyle = BorderStyle.None;
            panel.Size = new Size(195, 88);
            panel.Location = new Point(x, y);

            var accent = new Panel
            {
                BackColor = accentColor,
                Dock = DockStyle.Top,
                Height = 3
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Cairo", 9f),
                ForeColor = Color.FromArgb(80, 80, 90),
                Location = new Point(8, 10),
                AutoSize = true
            };

            valLabel.Text = defVal;
            valLabel.Font = new Font("Cairo SemiBold", 15f, FontStyle.Bold);
            valLabel.ForeColor = accentColor;
            valLabel.Location = new Point(8, 32);
            valLabel.AutoSize = true;

            panel.Controls.Add(accent);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(valLabel);
        }

        private void StyleGrid(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowFooter = false;
            gv.OptionsBehavior.Editable = false;
            gv.Appearance.HeaderPanel.Font = new Font("Cairo SemiBold", 9.5f, FontStyle.Bold);
            gv.Appearance.HeaderPanel.BackColor = Color.FromArgb(15, 39, 68);
            gv.Appearance.HeaderPanel.ForeColor = Color.White;
            gv.Appearance.Row.Font = new Font("Cairo", 10f);
            gv.Appearance.FocusedRow.BackColor = Color.FromArgb(200, 220, 255);
            gv.OptionsView.ColumnAutoWidth = true;
        }

        //_________________________________________________________________

        private void ArrangeKpis()
        {
            int kpiW = 195, kpiGap = 10;
            int startX = this.Width - kpiW - 20;

            Kpi_sales.Location = new Point(startX - 0 * (kpiW + kpiGap), 10);
            Kpi_pay.Location = new Point(startX - 1 * (kpiW + kpiGap), 10);
            Kpi_debt.Location = new Point(startX - 2 * (kpiW + kpiGap), 10);
            Kpi_inv.Location = new Point(startX - 3 * (kpiW + kpiGap), 10);
            Kpi_cust.Location = new Point(startX - 4 * (kpiW + kpiGap), 10);
            Kpi_avg.Location = new Point(startX - 5 * (kpiW + kpiGap), 10);
            Kpi_rate.Location = new Point(startX - 6 * (kpiW + kpiGap), 10);
        }

        private void FRM_Dashboard_Load(object sender, EventArgs e)
        {
            ArrangeKpis();
            Dt_from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Dt_to.Value = DateTime.Now;
            LoadDistributors();
        }

        private void LoadDistributors()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var list = db.TB_emplo
                        .Where(x => x.emplo_dis == true && x.emplo_activity == true)
                        .Select(x => x.emplo_name)
                        .OrderBy(x => x)
                        .ToList();

                    list.Insert(0, "كل الموزعيين");
                    Combo_emplo.DataSource = list;
                    Combo_emplo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في تحميل الموزعين:\n" + ex.Message);
            }
        }

        private void Btn_refresh_Click(object sender, EventArgs e) => LoadDashboard();

        private void Combo_emplo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            LoadDashboard();
        }

        private async void LoadDashboard()
        {
            try
            {
               


                Btn_refresh.Enabled = false;
                Lbl_loading.Visible = true;

                string emplo = Combo_emplo.SelectedItem?.ToString();
                DateTime from = Dt_from.Value.Date;
                DateTime to = Dt_to.Value.Date.AddDays(1).AddSeconds(-1);

                var data = await Task.Run(() => FetchData(emplo, from, to));

                Lbl_total_sales.Text  = $"$ {data.TotalSales:N2}";
                Lbl_total_pay.Text    = $"$ {data.TotalPayments:N2}";
                Lbl_net_debt.Text     = $"$ {data.NetDebt:N2}";
                Lbl_inv_count.Text    = data.InvoiceCount.ToString("N0");
                Lbl_cust_count.Text   = data.CustomerCount.ToString("N0");
                Lbl_avg_inv.Text      = $"$ {data.AvgInvoice:N2}";
                Lbl_collect_rate.Text = $"{data.CollectionRate:N1}%";

                Lbl_net_debt.ForeColor = data.NetDebt > 0 ? Color.DarkRed : Color.DarkGreen;

                BuildBarChart(data);
                BuildPieChart(data);
                BuildLineChart(data);

                Grid_top_dist.DataSource = data.TopDistributors;
                Grid_top_debt.DataSource = data.TopDebtors;

                Lbl_status.Text = $"آخر تحديث: {DateTime.Now:hh:mm tt dd/MM/yyyy}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في تحميل البيانات:\n" + ex.Message +
                                    "\n\nالتفاصيل:\n" + ex.StackTrace);
            }
            finally
            {
                Btn_refresh.Enabled = true;
                Lbl_loading.Visible = false;
            }
        }

        // ════════════════════════════════════════════════════════════
        // FetchData
        // ════════════════════════════════════════════════════════════
        private DashboardData FetchData(string emplo, DateTime from, DateTime to)
        {
            var data = new DashboardData();

            using (var db = new AlibaRamyEntities())
            {
                var salesQ = db.TB_list
                    .Where(l => l.cust_id != null && l.cust_id != 0)
                    .Where(l => l.list_date >= from && l.list_date <= to)
                    .Where(l => l.list_cridetUsd > 0);

                if (emplo != "كل الموزعيين")
                    salesQ = salesQ.Where(l => l.TB_emplo.emplo_name == emplo);

                var salesList = salesQ.Select(l => new
                {
                    Date   = l.list_date,
                    Amount = l.list_cridetUsd ?? 0m,
                    Client = l.list_name,
                    Emplo  = l.TB_emplo.emplo_name
                }).ToList();

                data.TotalSales    = salesList.Sum(s => s.Amount);
                data.InvoiceCount  = salesList.Count;
                data.CustomerCount = salesList.Select(s => s.Client).Distinct().Count();
                data.AvgInvoice    = data.InvoiceCount > 0 ? data.TotalSales / data.InvoiceCount : 0;

                var payQ = db.TB_cridet
                    .Where(c => c.action_id == 6 || c.action_id == 7)
                    .Where(c => c.cridet_date >= from && c.cridet_date <= to)
                    .Where(c => c.cridet_s > 0);

                if (emplo != "كل الموزعيين")
                    payQ = payQ.Where(c => c.TB_emplo.emplo_name == emplo);

                var payList = payQ.Select(c => new
                {
                    Date   = c.cridet_date,
                    Amount = c.cridet_s ?? 0m,
                    Client = c.list_name,
                    Emplo  = c.TB_emplo.emplo_name
                }).ToList();

                data.TotalPayments  = payList.Sum(p => p.Amount);
                data.NetDebt        = data.TotalSales - data.TotalPayments;
                data.CollectionRate = data.TotalSales > 0 ? (data.TotalPayments / data.TotalSales * 100) : 0;

                // ── بيانات يومية ─────────────────────────────────────
                int totalDays = (int)(to.Date - from.Date).TotalDays + 1;
                data.DailySales = Enumerable.Range(0, totalDays).Select(d =>
                {
                    var day = from.AddDays(d);
                    return new DayPoint
                    {
                        Day      = day.Day,
                        DayLabel = day.Day.ToString(),
                        Sales = salesList
                            .Where(s => s.Date.HasValue && s.Date.Value.Date == day)
                            .Sum(s => s.Amount),
                        Payments = payList
                            .Where(p => p.Date.HasValue && p.Date.Value.Date == day)
                            .Sum(p => p.Amount)
                    };
                }).ToList();

                // ── بيانات شهرية للـ Line ────────────────────────────
                data.MonthlySales = Enumerable.Range(1, 12).Select(m => new MonthPoint
                {
                    Month      = m,
                    MonthLabel = GetMonthAr(m),
                    Sales = db.TB_list
                        .Where(l => l.cust_id != null && l.cust_id != 0
                               && l.list_cridetUsd > 0
                               && l.list_date.HasValue
                               && l.list_date.Value.Year == from.Year
                               && l.list_date.Value.Month == m)
                        .Sum(l => (decimal?)l.list_cridetUsd) ?? 0m,
                    Payments = db.TB_cridet
                        .Where(c => (c.action_id == 6 || c.action_id == 7)
                               && c.cridet_s > 0
                               && c.cridet_date.HasValue
                               && c.cridet_date.Value.Year == from.Year
                               && c.cridet_date.Value.Month == m)
                        .Sum(c => (decimal?)c.cridet_s) ?? 0m,
                }).ToList();

                data.TopDistributors = salesList
                    .GroupBy(s => s.Emplo)
                    .Select(g => new DistributorRow
                    {
                        Name  = g.Key ?? "غير محدد",
                        Sales = g.Sum(x => x.Amount),
                        Count = g.Count()
                    })
                    .OrderByDescending(x => x.Sales)
                    .Take(8).ToList();

                var clientSales = salesList.GroupBy(s => s.Client)
                    .ToDictionary(g => g.Key ?? "", g => g.Sum(x => x.Amount));
                var clientPays  = payList.GroupBy(p => p.Client)
                    .ToDictionary(g => g.Key ?? "", g => g.Sum(x => x.Amount));

                data.TopDebtors = clientSales.Select(cs => new DebtorRow
                {
                    Client   = cs.Key,
                    Sales    = cs.Value,
                    Payments = clientPays.ContainsKey(cs.Key) ? clientPays[cs.Key] : 0,
                    Debt     = cs.Value - (clientPays.ContainsKey(cs.Key) ? clientPays[cs.Key] : 0)
                })
                .Where(x => x.Debt > 0)
                .OrderByDescending(x => x.Debt)
                .Take(8).ToList();
            }

            return data;
        }

        // ════════════════════════════════════════════════════════════
        // BuildBarChart — يومي (مثل الصورة)
        // ════════════════════════════════════════════════════════════
        private void BuildBarChart(DashboardData data)
        {
            Chart_main.DataSource = null;
            Chart_main.Series.Clear();
            Chart_main.Titles.Clear();

            var serSales = new Series("المبيعات", ViewType.Bar);
            serSales.Label.Visible      = false;
            serSales.ArgumentDataMember = "DayLabel";
            serSales.ValueDataMembers.AddRange("Sales");
            serSales.DataSource         = data.DailySales;

            var serPay = new Series("المدفوعات", ViewType.Bar);
            serPay.Label.Visible      = false;
            serPay.ArgumentDataMember = "DayLabel";
            serPay.ValueDataMembers.AddRange("Payments");
            serPay.DataSource         = data.DailySales;

            var debtPoints = data.DailySales.Select(d => new DayPoint
            {
                DayLabel = d.DayLabel,
                Sales    = Math.Max(0, d.Sales - d.Payments)
            }).ToList();

            var serDebt = new Series("الديون", ViewType.Bar);
            serDebt.Label.Visible      = false;
            serDebt.ArgumentDataMember = "DayLabel";
            serDebt.ValueDataMembers.AddRange("Sales");
            serDebt.DataSource         = debtPoints;

            Chart_main.Series.Add(serSales);
            Chart_main.Series.Add(serPay);
            Chart_main.Series.Add(serDebt);

            ((BarSeriesView)serSales.View).Color    = Color.FromArgb(55, 138, 221);
            ((BarSeriesView)serSales.View).BarWidth = 0.3;
            ((BarSeriesView)serPay.View).Color      = Color.FromArgb(29, 158, 117);
            ((BarSeriesView)serPay.View).BarWidth   = 0.3;
            ((BarSeriesView)serDebt.View).Color     = Color.FromArgb(226, 75, 74);
            ((BarSeriesView)serDebt.View).BarWidth  = 0.3;

            if (Chart_main.Diagram is XYDiagram diagram)
            {
                diagram.AxisX.Label.Font        = new Font("Cairo", 7.5f);
                diagram.AxisY.Label.Font        = new Font("Cairo", 7.5f);
                diagram.AxisY.Label.TextPattern = "${V:N0}";
                diagram.DefaultPane.BackColor   = Color.White;
            }

            Chart_main.Legend.Visibility          = DevExpress.Utils.DefaultBoolean.True;
            Chart_main.Legend.Font                = new Font("Cairo", 8.5f);
            Chart_main.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            Chart_main.Legend.AlignmentVertical   = LegendAlignmentVertical.Top;
            Chart_main.BackColor                  = Color.White;

            string monthName = GetMonthAr(Dt_from.Value.Month);
            var title = new ChartTitle { Text = $"المبيعات مقابل المدفوعات — المقارنة الشهرية لـ {monthName}" };
            title.Font      = new Font("Cairo SemiBold", 9f, FontStyle.Bold);
            title.Alignment = StringAlignment.Far;
            Chart_main.Titles.Add(title);
        }

        // ════════════════════════════════════════════════════════════
        // BuildPieChart
        // ════════════════════════════════════════════════════════════
        private void BuildPieChart(DashboardData data)
        {
            Chart_pie.Series.Clear();
            Chart_pie.Titles.Clear();

            var ser = new Series("التوزيع", ViewType.Doughnut);

            var pt0 = new SeriesPoint("مبيعات آجلة %50", (double)data.TotalSales);
            pt0.Color = Color.FromArgb(55, 138, 221);

            var pt1 = new SeriesPoint("مدفوعات %30", (double)data.TotalPayments);
            pt1.Color = Color.FromArgb(29, 158, 117);

            var pt2 = new SeriesPoint("ديون مستحقة %20", (double)Math.Max(0, data.NetDebt));
            pt2.Color = Color.FromArgb(226, 75, 74);

            ser.Points.Add(pt0);
            ser.Points.Add(pt1);
            ser.Points.Add(pt2);

            var view = (DoughnutSeriesView)ser.View;
            view.HoleRadiusPercent = 55;
            view.ExplodeMode       = PieExplodeMode.None;
            ser.Label.Visible      = false;

            Chart_pie.Series.Add(ser);
            Chart_pie.BackColor = Color.White;

            Chart_pie.Legend.Visibility          = DevExpress.Utils.DefaultBoolean.True;
            Chart_pie.Legend.Font                = new Font("Cairo", 7.5f);
            Chart_pie.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            Chart_pie.Legend.AlignmentVertical   = LegendAlignmentVertical.Bottom;
            Chart_pie.Legend.Direction           = LegendDirection.TopToBottom;

            var title = new ChartTitle { Text = "توزيع الإيرادات\nحسب نوع الحركة" };
            title.Font      = new Font("Cairo SemiBold", 8.5f, FontStyle.Bold);
            title.Alignment = StringAlignment.Far;
            Chart_pie.Titles.Add(title);
        }

        // ════════════════════════════════════════════════════════════
        // BuildLineChart — معدل التحصيل يومي (مثل الصورة)
        // ════════════════════════════════════════════════════════════
        private void BuildLineChart(DashboardData data)
        {
            Chart_line.DataSource = null;
            Chart_line.Series.Clear();
            Chart_line.Titles.Clear();

            var lineData = data.DailySales.Select(d => new DayPoint
            {
                DayLabel = d.DayLabel,
                Sales    = d.Sales > 0 ? Math.Round(d.Payments / d.Sales * 100, 1) : 0
            }).ToList();

            var ser = new Series("نسبة التحصيل %", ViewType.Spline);
            ser.DataSource           = lineData;
            ser.ArgumentDataMember   = "DayLabel";
            ser.ValueDataMembers.AddRange("Sales");
            ser.Label.Visible        = false;

            Chart_line.Series.Add(ser);

            ((SplineSeriesView)ser.View).Color               = Color.FromArgb(127, 119, 221);
            ((SplineSeriesView)ser.View).LineStyle.Thickness = 2;

            Chart_line.BackColor = Color.White;

            if (Chart_line.Diagram is XYDiagram diagram)
            {
                diagram.AxisY.Label.TextPattern = "{V:N0}%";
                diagram.AxisY.Label.Font        = new Font("Cairo", 7.5f);
                diagram.AxisX.Label.Font        = new Font("Cairo", 7.5f);
                diagram.DefaultPane.BackColor   = Color.White;
            }

            Chart_line.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            var title = new ChartTitle { Text = "معدل التحصيل اليومي\nنسبة ما تم تحصيله من الديون" };
            title.Font      = new Font("Cairo SemiBold", 8.5f, FontStyle.Bold);
            title.Alignment = StringAlignment.Far;
            Chart_line.Titles.Add(title);
        }

        private string GetMonthAr(int m)
        {
            string[] months = {
                "يناير","فبراير","مارس","أبريل","مايو","يونيو",
                "يوليو","أغسطس","سبتمبر","أكتوبر","نوفمبر","ديسمبر"
            };
            return months[m - 1];
        }

       
    }

    // ══════════════════════════════════════════════════════════════════
    public class DashboardData
    {
        public decimal TotalSales      { get; set; }
        public decimal TotalPayments   { get; set; }
        public decimal NetDebt         { get; set; }
        public int     InvoiceCount    { get; set; }
        public int     CustomerCount   { get; set; }
        public decimal AvgInvoice      { get; set; }
        public decimal CollectionRate  { get; set; }
        public List<DayPoint>       DailySales      { get; set; } = new List<DayPoint>();
        public List<MonthPoint>     MonthlySales    { get; set; } = new List<MonthPoint>();
        public List<DistributorRow> TopDistributors { get; set; } = new List<DistributorRow>();
        public List<DebtorRow>      TopDebtors      { get; set; } = new List<DebtorRow>();
    }

    public class DayPoint
    {
        public int     Day      { get; set; }
        public string  DayLabel { get; set; }
        public decimal Sales    { get; set; }
        public decimal Payments { get; set; }
    }

    public class MonthPoint
    {
        public int     Month      { get; set; }
        public string  MonthLabel { get; set; }
        public decimal Sales      { get; set; }
        public decimal Payments   { get; set; }
    }

    public class PiePoint
    {
        public string Label { get; set; }
        public double Value { get; set; }
    }

    public class DistributorRow
    {
        public string  Name  { get; set; }
        public decimal Sales { get; set; }
        public int     Count { get; set; }
    }

    public class DebtorRow
    {
        public string  Client   { get; set; }
        public decimal Sales    { get; set; }
        public decimal Payments { get; set; }
        public decimal Debt     { get; set; }
    }
}