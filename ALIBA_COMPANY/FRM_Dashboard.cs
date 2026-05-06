using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_Dashboard : XtraForm
    {
        // ✅ منع تعدد الطلبات المتزامنة
        private bool _isLoading = false;
        private GridView gridView_debt;
        private readonly GridView gridView_dist;

        public FRM_Dashboard()
        {
            InitializeComponent();

            gridView_dist = GV_dist; // استبدل gridView1 بالاسم الحقيقي للـ View لديك
            gridView_debt = GV_debt;
        }

        private void FRM_Dashboard_Load(object sender, EventArgs e)
        {
            ArrangeKpis();
            Dt_from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Dt_to.Value = DateTime.Now;
            LoadDistributors();
            // LoadDashboard تُستدعى تلقائياً من Combo_emplo_SelectedIndexChanged
        }

        // ════════════════════════════════════════════════════════════
        // تحميل الموزعين
        // ════════════════════════════════════════════════════════════
        private void LoadDistributors()
        {
            try
            {
                using (var db = new AlibaRamyEntities())
                {
                    var list = db.TB_emplo
                        .AsNoTracking()
                        .Where(x => x.emplo_dis == true && x.emplo_activity == true)
                        .OrderBy(x => x.emplo_name)
                        .Select(x => x.emplo_name)
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

        // ════════════════════════════════════════════════════════════
        // أحداث التحديث
        // ════════════════════════════════════════════════════════════
        private void Btn_refresh_Click(object sender, EventArgs e) => LoadDashboard();
        private void Dt_from_EditValueChanged(object sender, EventArgs e) => LoadDashboard();
        private void Dt_to_EditValueChanged(object sender, EventArgs e) => LoadDashboard();
        private void Combo_emplo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            LoadDashboard();
        }

        // ════════════════════════════════════════════════════════════
        // LoadDashboard — async مع منع التكرار
        // ════════════════════════════════════════════════════════════
        private async void LoadDashboard()
        {
            // ✅ منع استدعاء متزامن
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                Btn_refresh.Enabled = false;
                Lbl_loading.Visible = true;

                string emplo = Combo_emplo.SelectedItem?.ToString() ?? "كل الموزعيين";
                DateTime from = Dt_from.Value.Date;
                DateTime to = Dt_to.Value.Date.AddDays(1).AddSeconds(-1);

                // ✅ التحقق من صحة التاريخ
                if (from > to)
                {
                    XtraMessageBox.Show("تاريخ البداية يجب أن يكون قبل تاريخ النهاية");
                    return;
                }

                var data = await Task.Run(() => FetchData(emplo, from, to));

                // ✅ تحديث KPI Cards
                UpdateKpis(data);

                // ✅ تحديث الرسوم البيانية
                BuildBarChart(data);
                BuildPieChart(data);
                BuildLineChart(data);

                // ✅ تحديث الجداول
                Grid_top_dist.DataSource = data.TopDistributors;
                Grid_top_debt.DataSource = data.TopDebtors;

                // افترضنا أن gridView1 هو الخاص بالموزعين و gridView2 هو الخاص بالديون
                StyleGrid(GV_dist);
                StyleGrid(GV_debt);

                Lbl_status.Text = $"آخر تحديث: {DateTime.Now:hh:mm tt  dd/MM/yyyy}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في تحميل البيانات:\n" + ex.Message);
            }
            finally
            {
                Btn_refresh.Enabled = true;
                Lbl_loading.Visible = false;
                _isLoading = false;
            }
        }

        // ════════════════════════════════════════════════════════════
        // تحديث KPI Cards
        // ════════════════════════════════════════════════════════════
        private void UpdateKpis(DashboardData data)
        {
            Lbl_total_sales.Text = $"$ {data.TotalSales:N2}";
            Lbl_total_pay.Text = $"$ {data.TotalPayments:N2}";
            Lbl_net_debt.Text = $"$ {data.NetDebt:N2}";
            Lbl_inv_count.Text = data.InvoiceCount.ToString("N0");
            Lbl_cust_count.Text = data.CustomerCount.ToString("N0");
            Lbl_avg_inv.Text = $"$ {data.AvgInvoice:N2}";
            Lbl_collect_rate.Text = $"{data.CollectionRate:N1}%";

            // ✅ تلوين الدين حسب القيمة
            Lbl_net_debt.ForeColor = data.NetDebt > 0 ? Color.DarkRed : Color.DarkGreen;

            // ✅ تلوين نسبة التحصيل
            Lbl_collect_rate.ForeColor = data.CollectionRate >= 80 ? Color.DarkGreen
                                       : data.CollectionRate >= 50 ? Color.DarkOrange
                                       : Color.DarkRed;
        }

        // ════════════════════════════════════════════════════════════
        // FetchData — استعلام واحد سريع
        // ════════════════════════════════════════════════════════════
        private DashboardData FetchData(string emplo, DateTime from, DateTime to)
        {
            var data = new DashboardData();

            using (var db = new AlibaRamyEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

                // ══════════════════════════════════════════
                // ✅ 1. كل المبيعات (نقدي + آجل)
                // ══════════════════════════════════════════
                var salesQ = db.TB_list
                    .AsNoTracking()
                    .Where(l => 
                              l.list_date >= from && l.list_date <= to && l.sending==true);

                if (emplo != "كل الموزعيين")
                    salesQ = salesQ.Where(l => l.TB_emplo.emplo_name == emplo);

                var salesList = salesQ.Select(l => new
                {
                    Date = l.list_date,
                    Amount = l.list_amountUsd ?? 0m,
                    Credit = l.list_cridetUsd ?? 0m,
                    Client = l.list_name,
                    Emplo = l.TB_emplo.emplo_name
                }).ToList();

                // ══════════════════════════════════════════
                // ✅ 2. التحصيلات
                // ══════════════════════════════════════════
                var payQ = db.TB_cridet
                    .AsNoTracking()
                    .Where(c => (c.action_id == 6 || c.action_id == 7)
                             && c.cridet_date >= from && c.cridet_date <= to
                             && c.cridet_s > 0&&c.sending==true);

                if (emplo != "كل الموزعيين")
                    payQ = payQ.Where(c => c.TB_emplo.emplo_name == emplo);

                var payList = payQ.Select(c => new
                {
                    Date = c.cridet_date,
                    Amount = c.cridet_s ?? 0m,
                    Client = c.list_name,
                    Emplo = c.TB_emplo.emplo_name
                }).ToList();

                // ══════════════════════════════════════════
                // ✅ 3. KPI Cards
                // ══════════════════════════════════════════
                data.TotalSales = salesList.Sum(s => s.Amount);
                data.InvoiceCount = salesList.Count;
                data.CustomerCount = salesList.Select(s => s.Client).Distinct().Count();
                data.AvgInvoice = data.InvoiceCount > 0
                                      ? data.TotalSales / data.InvoiceCount : 0;
                data.TotalPayments = payList.Sum(p => p.Amount);
                data.NetDebt = data.TotalSales - data.TotalPayments;
                data.CollectionRate = data.TotalSales > 0
                                      ? data.TotalPayments / data.TotalSales * 100 : 0;

                // ══════════════════════════════════════════
                // ✅ 4. أفضل الموزعين (نقدي + آجل)
                // ══════════════════════════════════════════
                data.TopDistributors = salesList
                    .GroupBy(s => s.Emplo)
                    .Select(g => new DistributorRow
                    {
                        Name = g.Key ?? "غير محدد",
                        Sales = g.Sum(x => x.Amount),
                        Count = g.Count()
                    })
                    .OrderByDescending(x => x.Sales)
                    .Take(8).ToList();

                // ══════════════════════════════════════════
                // ✅ 5. أكثر العملاء ديناً (آجل - تحصيلات)
                // ══════════════════════════════════════════
                var clientDebts = salesList
                    .Where(s => s.Credit > 0)
                    .GroupBy(s => s.Client)
                    .ToDictionary(g => g.Key ?? "", g => g.Sum(x => x.Credit));

                var clientPays = payList
                    .GroupBy(p => p.Client)
                    .ToDictionary(g => g.Key ?? "", g => g.Sum(x => x.Amount));

                data.TopDebtors = clientDebts
                    .Select(cs => new DebtorRow
                    {
                        Client = cs.Key,
                        Sales = cs.Value,
                        Payments = clientPays.ContainsKey(cs.Key) ? clientPays[cs.Key] : 0,
                        Debt = cs.Value - (clientPays.ContainsKey(cs.Key) ? clientPays[cs.Key] : 0)
                    })
                    .Where(x => x.Debt > 0)
                    .OrderByDescending(x => x.Debt)
                    .Take(8).ToList();

                // ══════════════════════════════════════════
                // ✅ 6. البيانات اليومية للـ BarChart
                // ══════════════════════════════════════════
                int totalDays = (int)(to.Date - from.Date).TotalDays + 1;
                data.DailySales = Enumerable.Range(0, totalDays).Select(d =>
                {
                    var day = from.Date.AddDays(d);
                    return new DayPoint
                    {
                        Day = day.Day,
                        DayLabel = day.Day.ToString(),
                        Sales = salesList
                            .Where(s => s.Date.HasValue && s.Date.Value.Date == day)
                            .Sum(s => s.Amount),
                        Payments = payList
                            .Where(p => p.Date.HasValue && p.Date.Value.Date == day)
                            .Sum(p => p.Amount)
                    };
                }).ToList();

                // ══════════════════════════════════════════
                // ✅ 7. البيانات الشهرية — استعلام واحد بدل 24
                // ══════════════════════════════════════════
                int selectedYear = from.Year;

                var monthlySalesRaw = db.TB_list
                    .AsNoTracking()
                    .Where(l => l.cust_id != null && l.cust_id != 0
                             && l.list_amountUsd > 0
                             && l.list_date.HasValue
                             && l.list_date.Value.Year == selectedYear)
                    .GroupBy(l => l.list_date.Value.Month)
                    .Select(g => new { Month = g.Key, Total = g.Sum(l => l.list_amountUsd ?? 0m) })
                    .ToDictionary(x => x.Month, x => x.Total);

                var monthlyPaysRaw = db.TB_cridet
                    .AsNoTracking()
                    .Where(c => (c.action_id == 6 || c.action_id == 7)
                             && c.cridet_s > 0
                             && c.cridet_date.HasValue
                             && c.cridet_date.Value.Year == selectedYear)
                    .GroupBy(c => c.cridet_date.Value.Month)
                    .Select(g => new { Month = g.Key, Total = g.Sum(c => c.cridet_s ?? 0m) })
                    .ToDictionary(x => x.Month, x => x.Total);

                data.MonthlySales = Enumerable.Range(1, 12).Select(m => new MonthPoint
                {
                    Month = m,
                    MonthLabel = GetMonthAr(m),
                    Sales = monthlySalesRaw.ContainsKey(m) ? monthlySalesRaw[m] : 0m,
                    Payments = monthlyPaysRaw.ContainsKey(m) ? monthlyPaysRaw[m] : 0m
                }).ToList();
            }

            return data;
        }

        // ════════════════════════════════════════════════════════════
        // StyleGrid
        // ════════════════════════════════════════════════════════════
        private void StyleGrid(GridView gv)
        {
            if (gv == null) return; // حماية ضد الـ Null
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowFooter = false;
            gv.OptionsBehavior.Editable = false;
            gv.OptionsView.ColumnAutoWidth = true;
            gv.Appearance.HeaderPanel.Font = new Font("Cairo", 9.5f, FontStyle.Bold);
            gv.Appearance.HeaderPanel.BackColor = Color.FromArgb(15, 39, 68);
            gv.Appearance.HeaderPanel.ForeColor = Color.Black ;
            gv.Appearance.Row.Font = new Font("Cairo", 10f);
            gv.Appearance.FocusedRow.BackColor = Color.FromArgb(200, 220, 255);
            gv.Appearance.EvenRow.BackColor = Color.FromArgb(245, 248, 255);
        }

        // ════════════════════════════════════════════════════════════
        // BuildBarChart
        // ════════════════════════════════════════════════════════════
        private void BuildBarChart(DashboardData data)
        {
            Chart_main.DataSource = null;
            Chart_main.Series.Clear();
            Chart_main.Titles.Clear();

            var serSales = CreateBarSeries("المبيعات", data.DailySales, "Sales",
                                           Color.FromArgb(55, 138, 221));
            var serPay = CreateBarSeries("المدفوعات", data.DailySales, "Payments",
                                           Color.FromArgb(29, 158, 117));

            var debtPoints = data.DailySales.Select(d => new DayPoint
            {
                DayLabel = d.DayLabel,
                Sales = Math.Max(0, d.Sales - d.Payments)
            }).ToList();

            var serDebt = CreateBarSeries("الديون", debtPoints, "Sales",
                                          Color.FromArgb(226, 75, 74));

            Chart_main.Series.AddRange(new[] { serSales, serPay, serDebt });

            if (Chart_main.Diagram is XYDiagram diagram)
            {
                diagram.AxisX.Label.Font = new Font("Cairo", 7.5f);
                diagram.AxisY.Label.Font = new Font("Cairo", 7.5f);
                diagram.AxisY.Label.TextPattern = "${V:N0}";
                diagram.DefaultPane.BackColor = Color.White;
            }

            Chart_main.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            Chart_main.Legend.Font = new Font("Cairo", 8.5f);
            Chart_main.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            Chart_main.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
            Chart_main.BackColor = Color.White;

            var title = new ChartTitle
            {
                Text = $"المبيعات مقابل المدفوعات — {GetMonthAr(Dt_from.Value.Month)} {Dt_from.Value.Year}",
                Font = new Font("Cairo SemiBold", 9f, FontStyle.Bold),
                Alignment = StringAlignment.Far
            };
            Chart_main.Titles.Add(title);
        }

        // ✅ دالة مساعدة لإنشاء Bar Series
        private Series CreateBarSeries(string name, object dataSource,
                                       string valueMember, Color color)
        {
            var ser = new Series(name, ViewType.Bar)
            {
                DataSource = dataSource,
                ArgumentDataMember = "DayLabel",
            };
            ser.ValueDataMembers.AddRange(valueMember);
            ser.Label.Visible = false;

            ((BarSeriesView)ser.View).Color = color;
            ((BarSeriesView)ser.View).BarWidth = 0.3;

            return ser;
        }

        // ════════════════════════════════════════════════════════════
        // BuildPieChart — بنسب حقيقية من البيانات
        // ════════════════════════════════════════════════════════════
        private void BuildPieChart(DashboardData data)
        {
            Chart_pie.Series.Clear();
            Chart_pie.Titles.Clear();

            var ser = new Series("التوزيع", ViewType.Doughnut);
            var view = (DoughnutSeriesView)ser.View;
            view.HoleRadiusPercent = 55;
            view.ExplodeMode = PieExplodeMode.None;
            ser.Label.Visible = false;

            // ✅ نسب حقيقية من البيانات
            double totalSales = (double)data.TotalSales;
            double totalPay = (double)data.TotalPayments;
            double netDebt = (double)Math.Max(0, data.NetDebt);

            if (totalSales > 0)
            {
                AddPiePoint(ser, "إجمالي المبيعات", totalSales, Color.FromArgb(55, 138, 221));
                AddPiePoint(ser, "المدفوعات", totalPay, Color.FromArgb(29, 158, 117));
                AddPiePoint(ser, "الديون المستحقة", netDebt, Color.FromArgb(226, 75, 74));
            }

            Chart_pie.Series.Add(ser);
            Chart_pie.BackColor = Color.White;
            Chart_pie.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            Chart_pie.Legend.Font = new Font("Cairo", 7.5f);
            Chart_pie.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            Chart_pie.Legend.AlignmentVertical = LegendAlignmentVertical.Bottom;
            Chart_pie.Legend.Direction = LegendDirection.TopToBottom;

            Chart_pie.Titles.Add(new ChartTitle
            {
                Text = "توزيع الإيرادات",
                Font = new Font("Cairo SemiBold", 8.5f, FontStyle.Bold),
                Alignment = StringAlignment.Far
            });
        }

        private void AddPiePoint(Series ser, string label, double value, Color color)
        {
            if (value <= 0) return;
            var pt = new SeriesPoint(label, value) { Color = color };
            ser.Points.Add(pt);
        }

        // ════════════════════════════════════════════════════════════
        // BuildLineChart — معدل التحصيل اليومي
        // ════════════════════════════════════════════════════════════
        private void BuildLineChart(DashboardData data)
        {
            Chart_line.DataSource = null;
            Chart_line.Series.Clear();
            Chart_line.Titles.Clear();

            var lineData = data.DailySales.Select(d => new DayPoint
            {
                DayLabel = d.DayLabel,
                Sales = d.Sales > 0 ? Math.Round(d.Payments / d.Sales * 100, 1) : 0
            }).ToList();

            var ser = new Series("نسبة التحصيل %", ViewType.Spline)
            {
                DataSource = lineData,
                ArgumentDataMember = "DayLabel",
            };
            ser.ValueDataMembers.AddRange("Sales");
            ser.Label.Visible = false;

            ((SplineSeriesView)ser.View).Color = Color.FromArgb(127, 119, 221);
            ((SplineSeriesView)ser.View).LineStyle.Thickness = 2;

            Chart_line.Series.Add(ser);
            Chart_line.BackColor = Color.White;
            Chart_line.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            if (Chart_line.Diagram is XYDiagram diagram)
            {
                diagram.AxisY.Label.TextPattern = "{V:N0}%";
                diagram.AxisY.Label.Font = new Font("Cairo", 7.5f);
                diagram.AxisX.Label.Font = new Font("Cairo", 7.5f);
                diagram.DefaultPane.BackColor = Color.White;
            }

            Chart_line.Titles.Add(new ChartTitle
            {
                Text = "معدل التحصيل اليومي %",
                Font = new Font("Cairo SemiBold", 8.5f, FontStyle.Bold),
                Alignment = StringAlignment.Far
            });
        }

        // ════════════════════════════════════════════════════════════
        // ArrangeKpis
        // ════════════════════════════════════════════════════════════
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
    // Data Classes
    // ══════════════════════════════════════════════════════════════════
    public class DashboardData
    {
        public decimal TotalSales { get; set; }
        public decimal TotalPayments { get; set; }
        public decimal NetDebt { get; set; }
        public int InvoiceCount { get; set; }
        public int CustomerCount { get; set; }
        public decimal AvgInvoice { get; set; }
        public decimal CollectionRate { get; set; }
        public List<DayPoint> DailySales { get; set; } = new List<DayPoint>();
        public List<MonthPoint> MonthlySales { get; set; } = new List<MonthPoint>();
        public List<DistributorRow> TopDistributors { get; set; } = new List<DistributorRow>();
        public List<DebtorRow> TopDebtors { get; set; } = new List<DebtorRow>();
    }

    public class DayPoint
    {
        public int Day { get; set; }
        public string DayLabel { get; set; }
        public decimal Sales { get; set; }
        public decimal Payments { get; set; }
    }

    public class MonthPoint
    {
        public int Month { get; set; }
        public string MonthLabel { get; set; }
        public decimal Sales { get; set; }
        public decimal Payments { get; set; }
    }

    public class DistributorRow
    {
        [DisplayName("الموزع")]
        public string Name { get; set; }

        [DisplayName("المبيعات $")]
        public decimal Sales { get; set; }

        [DisplayName("الفواتير")]
        public int Count { get; set; }
    }

    public class DebtorRow
    {
        [DisplayName("العميل")]
        public string Client { get; set; }

        [DisplayName("الديون $")]
        public decimal Sales { get; set; }

        [DisplayName("المدفوعات $")]
        public decimal Payments { get; set; }

        [DisplayName("المتبقي $")]
        public decimal Debt { get; set; }
    }
}