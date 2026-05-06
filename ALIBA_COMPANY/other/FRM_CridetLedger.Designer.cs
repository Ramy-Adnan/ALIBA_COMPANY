using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace ALIBA_COMPANY.other
{
    partial class FRM_CridetLedger
    {
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Label lblEmplo;
        private System.Windows.Forms.ComboBox Combo_emplo;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.TextBox Txt_cust;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker Dt_from;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker Dt_to;
        private DevExpress.XtraEditors.SimpleButton Btn_search;
        private DevExpress.XtraEditors.SimpleButton Btn_xls;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label Lbl_total_debit;
        private System.Windows.Forms.Label Lbl_total_credit;
        private System.Windows.Forms.Label Lbl_net;
        private System.Windows.Forms.Label loading;

        private void InitializeComponent()
        {
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblEmplo = new System.Windows.Forms.Label();
            this.Combo_emplo = new System.Windows.Forms.ComboBox();
            this.lblCust = new System.Windows.Forms.Label();
            this.Txt_cust = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.Dt_from = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.Dt_to = new System.Windows.Forms.DateTimePicker();
            this.Btn_search = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_xls = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.Lbl_total_debit = new System.Windows.Forms.Label();
            this.Lbl_total_credit = new System.Windows.Forms.Label();
            this.Lbl_net = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.lblEmplo);
            this.pnlFilter.Controls.Add(this.Combo_emplo);
            this.pnlFilter.Controls.Add(this.lblCust);
            this.pnlFilter.Controls.Add(this.Txt_cust);
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.Dt_from);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.Dt_to);
            this.pnlFilter.Controls.Add(this.Btn_search);
            this.pnlFilter.Controls.Add(this.Btn_xls);
            this.pnlFilter.Controls.Add(this.Btn_print);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.pnlFilter.Size = new System.Drawing.Size(1727, 82);
            this.pnlFilter.TabIndex = 1;
            this.pnlFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilter_Paint);
            // 
            // lblEmplo
            // 
            this.lblEmplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmplo.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmplo.Location = new System.Drawing.Point(1652, 13);
            this.lblEmplo.Name = "lblEmplo";
            this.lblEmplo.Size = new System.Drawing.Size(67, 51);
            this.lblEmplo.TabIndex = 0;
            this.lblEmplo.Text = "الموزع:";
            this.lblEmplo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Combo_emplo
            // 
            this.Combo_emplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_emplo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_emplo.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_emplo.Location = new System.Drawing.Point(1335, 16);
            this.Combo_emplo.Name = "Combo_emplo";
            this.Combo_emplo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Combo_emplo.Size = new System.Drawing.Size(320, 45);
            this.Combo_emplo.TabIndex = 1;
            this.Combo_emplo.SelectedIndexChanged += new System.EventHandler(this.Combo_emplo_SelectedIndexChanged);
            // 
            // lblCust
            // 
            this.lblCust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCust.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCust.Location = new System.Drawing.Point(1261, 13);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(73, 51);
            this.lblCust.TabIndex = 2;
            this.lblCust.Text = "العميل:";
            this.lblCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_cust
            // 
            this.Txt_cust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_cust.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_cust.Location = new System.Drawing.Point(950, 16);
            this.Txt_cust.Name = "Txt_cust";
            this.Txt_cust.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_cust.Size = new System.Drawing.Size(311, 45);
            this.Txt_cust.TabIndex = 3;
            this.Txt_cust.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_cust_KeyDown);
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(908, 13);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 51);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "من:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dt_from
            // 
            this.Dt_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dt_from.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_from.Location = new System.Drawing.Point(739, 16);
            this.Dt_from.Name = "Dt_from";
            this.Dt_from.Size = new System.Drawing.Size(163, 45);
            this.Dt_from.TabIndex = 5;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(690, 13);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(47, 51);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "إلى:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dt_to
            // 
            this.Dt_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dt_to.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_to.Location = new System.Drawing.Point(521, 16);
            this.Dt_to.Name = "Dt_to";
            this.Dt_to.Size = new System.Drawing.Size(163, 45);
            this.Dt_to.TabIndex = 7;
            // 
            // Btn_search
            // 
            this.Btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_search.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_search.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_search.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_search.Appearance.Options.UseBackColor = true;
            this.Btn_search.Appearance.Options.UseFont = true;
            this.Btn_search.Appearance.Options.UseForeColor = true;
            this.Btn_search.Location = new System.Drawing.Point(410, 10);
            this.Btn_search.Name = "Btn_search";
            this.Btn_search.Size = new System.Drawing.Size(79, 55);
            this.Btn_search.TabIndex = 8;
            this.Btn_search.Text = "🔍 بحث";
            this.Btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // Btn_xls
            // 
            this.Btn_xls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_xls.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_xls.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_xls.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_xls.Appearance.Options.UseBackColor = true;
            this.Btn_xls.Appearance.Options.UseFont = true;
            this.Btn_xls.Appearance.Options.UseForeColor = true;
            this.Btn_xls.Location = new System.Drawing.Point(253, 10);
            this.Btn_xls.Name = "Btn_xls";
            this.Btn_xls.Size = new System.Drawing.Size(72, 55);
            this.Btn_xls.TabIndex = 9;
            this.Btn_xls.Text = "📊 XLS";
            this.Btn_xls.Click += new System.EventHandler(this.Btn_xls_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.Btn_print.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_print.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_print.Appearance.Options.UseBackColor = true;
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.Appearance.Options.UseForeColor = true;
            this.Btn_print.Location = new System.Drawing.Point(331, 10);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(73, 55);
            this.Btn_print.TabIndex = 10;
            this.Btn_print.Text = "🖨";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 82);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1727, 500);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.pnlTotals);
            this.pnlFooter.Controls.Add(this.loading);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 582);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1727, 148);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlTotals
            // 
            this.pnlTotals.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotals.Controls.Add(this.Lbl_total_debit);
            this.pnlTotals.Controls.Add(this.Lbl_total_credit);
            this.pnlTotals.Controls.Add(this.Lbl_net);
            this.pnlTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotals.Location = new System.Drawing.Point(180, 0);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Size = new System.Drawing.Size(1545, 146);
            this.pnlTotals.TabIndex = 0;
            // 
            // Lbl_total_debit
            // 
            this.Lbl_total_debit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_total_debit.Font = new System.Drawing.Font("Cairo SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.Lbl_total_debit.ForeColor = System.Drawing.Color.DarkRed;
            this.Lbl_total_debit.Location = new System.Drawing.Point(13, 0);
            this.Lbl_total_debit.Name = "Lbl_total_debit";
            this.Lbl_total_debit.Size = new System.Drawing.Size(471, 146);
            this.Lbl_total_debit.TabIndex = 0;
            this.Lbl_total_debit.Text = "إجمالي المبيعات: 0.00 $";
            this.Lbl_total_debit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_total_credit
            // 
            this.Lbl_total_credit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_total_credit.Font = new System.Drawing.Font("Cairo SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.Lbl_total_credit.ForeColor = System.Drawing.Color.DarkGreen;
            this.Lbl_total_credit.Location = new System.Drawing.Point(484, 0);
            this.Lbl_total_credit.Name = "Lbl_total_credit";
            this.Lbl_total_credit.Size = new System.Drawing.Size(491, 146);
            this.Lbl_total_credit.TabIndex = 1;
            this.Lbl_total_credit.Text = "إجمالي المدفوعات: 0.00 $";
            this.Lbl_total_credit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_net
            // 
            this.Lbl_net.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_net.Font = new System.Drawing.Font("Cairo SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.Lbl_net.ForeColor = System.Drawing.Color.DarkRed;
            this.Lbl_net.Location = new System.Drawing.Point(975, 0);
            this.Lbl_net.Name = "Lbl_net";
            this.Lbl_net.Size = new System.Drawing.Size(570, 146);
            this.Lbl_net.TabIndex = 2;
            this.Lbl_net.Text = "صافي الدين: 0.00 $";
            this.Lbl_net.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loading
            // 
            this.loading.Dock = System.Windows.Forms.DockStyle.Left;
            this.loading.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Italic);
            this.loading.ForeColor = System.Drawing.Color.SteelBlue;
            this.loading.Location = new System.Drawing.Point(0, 0);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(180, 146);
            this.loading.TabIndex = 1;
            this.loading.Text = "⏳ جاري التحميل...";
            this.loading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loading.Visible = false;
            // 
            // FRM_CridetLedger
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1727, 730);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "FRM_CridetLedger";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📋 كشف أرصدة الموزعيــــــن";
            this.Load += new System.EventHandler(this.FRM_CridetLedger_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlTotals.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}