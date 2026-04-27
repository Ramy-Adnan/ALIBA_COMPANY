using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid;

namespace ALIBA_COMPANY.other
{
    partial class FRM_Dashboard
    {
        // ── فلاتر ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmplo;
        private System.Windows.Forms.ComboBox Combo_emplo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker Dt_from;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker Dt_to;
        private DevExpress.XtraEditors.SimpleButton Btn_refresh;
        private System.Windows.Forms.Label Lbl_loading;
        private System.Windows.Forms.Label Lbl_status;

        // ── KPI Cards ─────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlKpi;
        private System.Windows.Forms.Panel Kpi_sales;
        private System.Windows.Forms.Panel Kpi_pay;
        private System.Windows.Forms.Panel Kpi_debt;
        private System.Windows.Forms.Panel Kpi_inv;
        private System.Windows.Forms.Panel Kpi_cust;
        private System.Windows.Forms.Panel Kpi_avg;
        private System.Windows.Forms.Panel Kpi_rate;

        private System.Windows.Forms.Label Lbl_total_sales;
        private System.Windows.Forms.Label Lbl_total_pay;
        private System.Windows.Forms.Label Lbl_net_debt;
        private System.Windows.Forms.Label Lbl_inv_count;
        private System.Windows.Forms.Label Lbl_cust_count;
        private System.Windows.Forms.Label Lbl_avg_inv;
        private System.Windows.Forms.Label Lbl_collect_rate;

        // ✅ تم التصحيح: استخدام DevExpress.XtraCharts.ChartControl بشكل صريح
        private System.Windows.Forms.Panel pnlCharts;
        private DevExpress.XtraCharts.ChartControl Chart_main;
        private DevExpress.XtraCharts.ChartControl Chart_pie;
        private DevExpress.XtraCharts.ChartControl Chart_line;

        // ── جداول ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlGrids;
        private DevExpress.XtraGrid.GridControl Grid_top_dist;
        private DevExpress.XtraGrid.GridControl Grid_top_debt;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_dist;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_debt;

        private void InitializeComponent()
        {
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmplo = new System.Windows.Forms.Label();
            this.Combo_emplo = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.Dt_from = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.Dt_to = new System.Windows.Forms.DateTimePicker();
            this.Btn_refresh = new DevExpress.XtraEditors.SimpleButton();
            this.Lbl_loading = new System.Windows.Forms.Label();
            this.Lbl_status = new System.Windows.Forms.Label();
            this.pnlKpi = new System.Windows.Forms.Panel();
            this.Kpi_sales = new System.Windows.Forms.Panel();
            this.Kpi_pay = new System.Windows.Forms.Panel();
            this.Kpi_debt = new System.Windows.Forms.Panel();
            this.Kpi_inv = new System.Windows.Forms.Panel();
            this.Kpi_cust = new System.Windows.Forms.Panel();
            this.Kpi_avg = new System.Windows.Forms.Panel();
            this.Kpi_rate = new System.Windows.Forms.Panel();
            this.Lbl_total_sales = new System.Windows.Forms.Label();
            this.Lbl_total_pay = new System.Windows.Forms.Label();
            this.Lbl_net_debt = new System.Windows.Forms.Label();
            this.Lbl_inv_count = new System.Windows.Forms.Label();
            this.Lbl_cust_count = new System.Windows.Forms.Label();
            this.Lbl_avg_inv = new System.Windows.Forms.Label();
            this.Lbl_collect_rate = new System.Windows.Forms.Label();
            this.pnlCharts = new System.Windows.Forms.Panel();
            this.Chart_main = new DevExpress.XtraCharts.ChartControl();
            this.Chart_pie = new DevExpress.XtraCharts.ChartControl();
            this.Chart_line = new DevExpress.XtraCharts.ChartControl();
            this.pnlGrids = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Grid_top_dist = new DevExpress.XtraGrid.GridControl();
            this.GV_dist = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Grid_top_debt = new DevExpress.XtraGrid.GridControl();
            this.GV_debt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlFilter.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_pie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_line)).BeginInit();
            this.pnlGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_top_dist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_dist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_top_debt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_debt)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(68)))));
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.lblTitle);
            this.pnlFilter.Controls.Add(this.lblEmplo);
            this.pnlFilter.Controls.Add(this.Combo_emplo);
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.Dt_from);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.Dt_to);
            this.pnlFilter.Controls.Add(this.Btn_refresh);
            this.pnlFilter.Controls.Add(this.Lbl_loading);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlFilter.Size = new System.Drawing.Size(1642, 62);
            this.pnlFilter.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(451, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 42);
            this.label3.TabIndex = 11;
            this.label3.Text = "الى:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(671, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 42);
            this.label2.TabIndex = 10;
            this.label2.Text = "من:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1066, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 42);
            this.label1.TabIndex = 9;
            this.label1.Text = "المزوع:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cairo SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(1161, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(475, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊  لوحة الأداء المالي — Aliba Company System";
            // 
            // lblEmplo
            // 
            this.lblEmplo.Location = new System.Drawing.Point(0, 0);
            this.lblEmplo.Name = "lblEmplo";
            this.lblEmplo.Size = new System.Drawing.Size(100, 23);
            this.lblEmplo.TabIndex = 1;
            this.lblEmplo.Text = "الموزع:";
            // 
            // Combo_emplo
            // 
            this.Combo_emplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_emplo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_emplo.Font = new System.Drawing.Font("Cairo", 11F);
            this.Combo_emplo.Location = new System.Drawing.Point(731, 12);
            this.Combo_emplo.Name = "Combo_emplo";
            this.Combo_emplo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Combo_emplo.Size = new System.Drawing.Size(329, 42);
            this.Combo_emplo.TabIndex = 2;
            this.Combo_emplo.SelectedIndexChanged += new System.EventHandler(this.Combo_emplo_SelectedIndexChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(0, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(100, 23);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "من:";
            // 
            // Dt_from
            // 
            this.Dt_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dt_from.Font = new System.Drawing.Font("Cairo", 11F);
            this.Dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_from.Location = new System.Drawing.Point(515, 12);
            this.Dt_from.Name = "Dt_from";
            this.Dt_from.Size = new System.Drawing.Size(150, 42);
            this.Dt_from.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(0, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(100, 23);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "إلى:";
            // 
            // Dt_to
            // 
            this.Dt_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dt_to.Font = new System.Drawing.Font("Cairo", 11F);
            this.Dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_to.Location = new System.Drawing.Point(295, 12);
            this.Dt_to.Name = "Dt_to";
            this.Dt_to.Size = new System.Drawing.Size(150, 42);
            this.Dt_to.TabIndex = 6;
            // 
            // Btn_refresh
            // 
            this.Btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_refresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(138)))), ((int)(((byte)(221)))));
            this.Btn_refresh.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_refresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_refresh.Appearance.Options.UseBackColor = true;
            this.Btn_refresh.Appearance.Options.UseFont = true;
            this.Btn_refresh.Appearance.Options.UseForeColor = true;
            this.Btn_refresh.Location = new System.Drawing.Point(179, 15);
            this.Btn_refresh.Name = "Btn_refresh";
            this.Btn_refresh.Size = new System.Drawing.Size(110, 36);
            this.Btn_refresh.TabIndex = 7;
            this.Btn_refresh.Text = "🔄  تحديث";
            this.Btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // Lbl_loading
            // 
            this.Lbl_loading.AutoSize = true;
            this.Lbl_loading.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Italic);
            this.Lbl_loading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.Lbl_loading.Location = new System.Drawing.Point(10, 20);
            this.Lbl_loading.Name = "Lbl_loading";
            this.Lbl_loading.Size = new System.Drawing.Size(128, 29);
            this.Lbl_loading.TabIndex = 8;
            this.Lbl_loading.Text = "⏳ جاري التحميل...";
            this.Lbl_loading.Visible = false;
            // 
            // Lbl_status
            // 
            this.Lbl_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.Lbl_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Lbl_status.Font = new System.Drawing.Font("Cairo", 8.5F);
            this.Lbl_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Lbl_status.Location = new System.Drawing.Point(0, 746);
            this.Lbl_status.Name = "Lbl_status";
            this.Lbl_status.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Lbl_status.Size = new System.Drawing.Size(1642, 22);
            this.Lbl_status.TabIndex = 4;
            this.Lbl_status.Text = "جاهز";
            this.Lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlKpi
            // 
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnlKpi.Controls.Add(this.Kpi_sales);
            this.pnlKpi.Controls.Add(this.Kpi_pay);
            this.pnlKpi.Controls.Add(this.Kpi_debt);
            this.pnlKpi.Controls.Add(this.Kpi_inv);
            this.pnlKpi.Controls.Add(this.Kpi_cust);
            this.pnlKpi.Controls.Add(this.Kpi_avg);
            this.pnlKpi.Controls.Add(this.Kpi_rate);
            this.pnlKpi.Location = new System.Drawing.Point(0, 62);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.pnlKpi.Size = new System.Drawing.Size(1642, 115);
            this.pnlKpi.TabIndex = 2;
            // 
            // Kpi_sales
            // 
            this.Kpi_sales.Location = new System.Drawing.Point(42, 0);
            this.Kpi_sales.Name = "Kpi_sales";
            this.Kpi_sales.Size = new System.Drawing.Size(200, 100);
            this.Kpi_sales.TabIndex = 0;
            // 
            // Kpi_pay
            // 
            this.Kpi_pay.Location = new System.Drawing.Point(0, 0);
            this.Kpi_pay.Name = "Kpi_pay";
            this.Kpi_pay.Size = new System.Drawing.Size(200, 100);
            this.Kpi_pay.TabIndex = 1;
            // 
            // Kpi_debt
            // 
            this.Kpi_debt.Location = new System.Drawing.Point(0, 0);
            this.Kpi_debt.Name = "Kpi_debt";
            this.Kpi_debt.Size = new System.Drawing.Size(200, 100);
            this.Kpi_debt.TabIndex = 2;
            // 
            // Kpi_inv
            // 
            this.Kpi_inv.Location = new System.Drawing.Point(0, 0);
            this.Kpi_inv.Name = "Kpi_inv";
            this.Kpi_inv.Size = new System.Drawing.Size(200, 100);
            this.Kpi_inv.TabIndex = 3;
            // 
            // Kpi_cust
            // 
            this.Kpi_cust.Location = new System.Drawing.Point(0, 0);
            this.Kpi_cust.Name = "Kpi_cust";
            this.Kpi_cust.Size = new System.Drawing.Size(200, 100);
            this.Kpi_cust.TabIndex = 4;
            // 
            // Kpi_avg
            // 
            this.Kpi_avg.Location = new System.Drawing.Point(0, 0);
            this.Kpi_avg.Name = "Kpi_avg";
            this.Kpi_avg.Size = new System.Drawing.Size(200, 100);
            this.Kpi_avg.TabIndex = 5;
            // 
            // Kpi_rate
            // 
            this.Kpi_rate.Location = new System.Drawing.Point(0, 0);
            this.Kpi_rate.Name = "Kpi_rate";
            this.Kpi_rate.Size = new System.Drawing.Size(200, 100);
            this.Kpi_rate.TabIndex = 6;
            // 
            // Lbl_total_sales
            // 
            this.Lbl_total_sales.Location = new System.Drawing.Point(0, 0);
            this.Lbl_total_sales.Name = "Lbl_total_sales";
            this.Lbl_total_sales.Size = new System.Drawing.Size(100, 23);
            this.Lbl_total_sales.TabIndex = 0;
            // 
            // Lbl_total_pay
            // 
            this.Lbl_total_pay.Location = new System.Drawing.Point(0, 0);
            this.Lbl_total_pay.Name = "Lbl_total_pay";
            this.Lbl_total_pay.Size = new System.Drawing.Size(100, 23);
            this.Lbl_total_pay.TabIndex = 0;
            // 
            // Lbl_net_debt
            // 
            this.Lbl_net_debt.Location = new System.Drawing.Point(0, 0);
            this.Lbl_net_debt.Name = "Lbl_net_debt";
            this.Lbl_net_debt.Size = new System.Drawing.Size(100, 23);
            this.Lbl_net_debt.TabIndex = 0;
            // 
            // Lbl_inv_count
            // 
            this.Lbl_inv_count.Location = new System.Drawing.Point(0, 0);
            this.Lbl_inv_count.Name = "Lbl_inv_count";
            this.Lbl_inv_count.Size = new System.Drawing.Size(100, 23);
            this.Lbl_inv_count.TabIndex = 0;
            // 
            // Lbl_cust_count
            // 
            this.Lbl_cust_count.Location = new System.Drawing.Point(0, 0);
            this.Lbl_cust_count.Name = "Lbl_cust_count";
            this.Lbl_cust_count.Size = new System.Drawing.Size(100, 23);
            this.Lbl_cust_count.TabIndex = 0;
            // 
            // Lbl_avg_inv
            // 
            this.Lbl_avg_inv.Location = new System.Drawing.Point(0, 0);
            this.Lbl_avg_inv.Name = "Lbl_avg_inv";
            this.Lbl_avg_inv.Size = new System.Drawing.Size(100, 23);
            this.Lbl_avg_inv.TabIndex = 0;
            // 
            // Lbl_collect_rate
            // 
            this.Lbl_collect_rate.Location = new System.Drawing.Point(0, 0);
            this.Lbl_collect_rate.Name = "Lbl_collect_rate";
            this.Lbl_collect_rate.Size = new System.Drawing.Size(100, 23);
            this.Lbl_collect_rate.TabIndex = 0;
            // 
            // pnlCharts
            // 
            this.pnlCharts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnlCharts.Controls.Add(this.Chart_main);
            this.pnlCharts.Controls.Add(this.Chart_pie);
            this.pnlCharts.Controls.Add(this.Chart_line);
            this.pnlCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCharts.Location = new System.Drawing.Point(0, 62);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlCharts.Size = new System.Drawing.Size(1642, 330);
            this.pnlCharts.TabIndex = 1;
            // 
            // Chart_main
            // 
            this.Chart_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart_main.BackColor = System.Drawing.Color.White;
            this.Chart_main.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.Chart_main.Location = new System.Drawing.Point(578, 5);
            this.Chart_main.Name = "Chart_main";
            this.Chart_main.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.Chart_main.Size = new System.Drawing.Size(1055, 315);
            this.Chart_main.TabIndex = 0;
            // 
            // Chart_pie
            // 
            this.Chart_pie.BackColor = System.Drawing.Color.White;
            this.Chart_pie.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.Chart_pie.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.Chart_pie.Location = new System.Drawing.Point(275, 5);
            this.Chart_pie.Name = "Chart_pie";
            this.Chart_pie.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.Chart_pie.Size = new System.Drawing.Size(297, 315);
            this.Chart_pie.TabIndex = 1;
            // 
            // Chart_line
            // 
            this.Chart_line.BackColor = System.Drawing.Color.White;
            this.Chart_line.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.Chart_line.Location = new System.Drawing.Point(10, 5);
            this.Chart_line.Name = "Chart_line";
            this.Chart_line.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.Chart_line.Size = new System.Drawing.Size(255, 210);
            this.Chart_line.TabIndex = 2;
            // 
            // pnlGrids
            // 
            this.pnlGrids.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(68)))));
            this.pnlGrids.Controls.Add(this.label5);
            this.pnlGrids.Controls.Add(this.label4);
            this.pnlGrids.Controls.Add(this.Grid_top_dist);
            this.pnlGrids.Controls.Add(this.Grid_top_debt);
            this.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrids.Location = new System.Drawing.Point(0, 392);
            this.pnlGrids.Name = "pnlGrids";
            this.pnlGrids.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.pnlGrids.Size = new System.Drawing.Size(1642, 354);
            this.pnlGrids.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(263, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 42);
            this.label5.TabIndex = 3;
            this.label5.Text = "💵  أكثر العملاء ديناً";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1096, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 42);
            this.label4.TabIndex = 2;
            this.label4.Text = "🧑‍💼  أفضل الموزعين مبيعاً";
            // 
            // Grid_top_dist
            // 
            this.Grid_top_dist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_top_dist.Location = new System.Drawing.Point(823, 63);
            this.Grid_top_dist.MainView = this.GV_dist;
            this.Grid_top_dist.Name = "Grid_top_dist";
            this.Grid_top_dist.Size = new System.Drawing.Size(810, 278);
            this.Grid_top_dist.TabIndex = 0;
            this.Grid_top_dist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_dist});
            // 
            // GV_dist
            // 
            this.GV_dist.GridControl = this.Grid_top_dist;
            this.GV_dist.Name = "GV_dist";
            this.GV_dist.OptionsView.ShowGroupPanel = false;
            // 
            // Grid_top_debt
            // 
            this.Grid_top_debt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Grid_top_debt.Location = new System.Drawing.Point(10, 63);
            this.Grid_top_debt.MainView = this.GV_debt;
            this.Grid_top_debt.Name = "Grid_top_debt";
            this.Grid_top_debt.Size = new System.Drawing.Size(807, 278);
            this.Grid_top_debt.TabIndex = 1;
            this.Grid_top_debt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_debt});
            // 
            // GV_debt
            // 
            this.GV_debt.GridControl = this.Grid_top_debt;
            this.GV_debt.Name = "GV_debt";
            this.GV_debt.OptionsView.ShowGroupPanel = false;
            // 
            // FRM_Dashboard
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1642, 768);
            this.Controls.Add(this.pnlGrids);
            this.Controls.Add(this.pnlCharts);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.Lbl_status);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_Dashboard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📊 لوحة الأداء المالي";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FRM_Dashboard_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlKpi.ResumeLayout(false);
            this.pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_pie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_line)).EndInit();
            this.pnlGrids.ResumeLayout(false);
            this.pnlGrids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_top_dist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_dist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_top_debt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_debt)).EndInit();
            this.ResumeLayout(false);

        }

        private Label label1;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
    }
}