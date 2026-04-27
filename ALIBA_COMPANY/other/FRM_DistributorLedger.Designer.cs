using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace ALIBA_COMPANY.other
{
    partial class FRM_DistributorLedger
    {
        private void InitializeComponent()
        {
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblDistributor = new System.Windows.Forms.Label();
            this.Combo_distributor = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.Dt_from = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.Dt_to = new System.Windows.Forms.DateTimePicker();
            this.Btn_search = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_xls = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.Lst_cust = new System.Windows.Forms.ListBox();
            this.Txt_search_cust = new System.Windows.Forms.TextBox();
            this.lblCustList = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.Chk_credit = new System.Windows.Forms.CheckBox();
            this.Chk_debit = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.Lbl_total_debit = new System.Windows.Forms.Label();
            this.Lbl_total_credit = new System.Windows.Forms.Label();
            this.Lbl_net = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.lblDistributor);
            this.pnlFilter.Controls.Add(this.Combo_distributor);
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
            this.pnlFilter.Size = new System.Drawing.Size(1632, 82);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblDistributor
            // 
            this.lblDistributor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDistributor.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblDistributor.Location = new System.Drawing.Point(1452, 12);
            this.lblDistributor.Name = "lblDistributor";
            this.lblDistributor.Size = new System.Drawing.Size(67, 51);
            this.lblDistributor.TabIndex = 0;
            this.lblDistributor.Text = "الموزع:";
            this.lblDistributor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Combo_distributor
            // 
            this.Combo_distributor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_distributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_distributor.Font = new System.Drawing.Font("Cairo", 12F);
            this.Combo_distributor.Location = new System.Drawing.Point(1162, 15);
            this.Combo_distributor.Name = "Combo_distributor";
            this.Combo_distributor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Combo_distributor.Size = new System.Drawing.Size(290, 45);
            this.Combo_distributor.TabIndex = 1;
            this.Combo_distributor.SelectedIndexChanged += new System.EventHandler(this.Combo_distributor_SelectedIndexChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(1099, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 51);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "من:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dt_from
            // 
            this.Dt_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dt_from.Font = new System.Drawing.Font("Cairo", 12F);
            this.Dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_from.Location = new System.Drawing.Point(922, 15);
            this.Dt_from.Name = "Dt_from";
            this.Dt_from.Size = new System.Drawing.Size(172, 45);
            this.Dt_from.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(865, 12);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(54, 51);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "إلى:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dt_to
            // 
            this.Dt_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dt_to.Font = new System.Drawing.Font("Cairo", 12F);
            this.Dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_to.Location = new System.Drawing.Point(687, 15);
            this.Dt_to.Name = "Dt_to";
            this.Dt_to.Size = new System.Drawing.Size(172, 45);
            this.Dt_to.TabIndex = 3;
            // 
            // Btn_search
            // 
            this.Btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_search.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_search.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.Btn_search.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_search.Appearance.Options.UseBackColor = true;
            this.Btn_search.Appearance.Options.UseFont = true;
            this.Btn_search.Appearance.Options.UseForeColor = true;
            this.Btn_search.Location = new System.Drawing.Point(572, 10);
            this.Btn_search.Name = "Btn_search";
            this.Btn_search.Size = new System.Drawing.Size(100, 55);
            this.Btn_search.TabIndex = 4;
            this.Btn_search.Text = "🔍 بحث";
            this.Btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // Btn_xls
            // 
            this.Btn_xls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_xls.Appearance.BackColor = System.Drawing.Color.DarkGreen;
            this.Btn_xls.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.Btn_xls.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_xls.Appearance.Options.UseBackColor = true;
            this.Btn_xls.Appearance.Options.UseFont = true;
            this.Btn_xls.Appearance.Options.UseForeColor = true;
            this.Btn_xls.Location = new System.Drawing.Point(481, 10);
            this.Btn_xls.Name = "Btn_xls";
            this.Btn_xls.Size = new System.Drawing.Size(85, 55);
            this.Btn_xls.TabIndex = 5;
            this.Btn_xls.Text = "📊 XLS";
            this.Btn_xls.Click += new System.EventHandler(this.Btn_xls_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.Btn_print.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.Btn_print.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_print.Appearance.Options.UseBackColor = true;
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.Appearance.Options.UseForeColor = true;
            this.Btn_print.Location = new System.Drawing.Point(400, 10);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(73, 55);
            this.Btn_print.TabIndex = 6;
            this.Btn_print.Text = "🖨";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl1);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 82);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1632, 558);
            this.pnlMain.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1375, 558);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.Lst_cust);
            this.pnlRight.Controls.Add(this.Txt_search_cust);
            this.pnlRight.Controls.Add(this.lblCustList);
            this.pnlRight.Controls.Add(this.lblFilter);
            this.pnlRight.Controls.Add(this.Chk_credit);
            this.pnlRight.Controls.Add(this.Chk_debit);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1375, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(257, 558);
            this.pnlRight.TabIndex = 1;
            // 
            // Lst_cust
            // 
            this.Lst_cust.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lst_cust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lst_cust.Font = new System.Drawing.Font("Cairo SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.Lst_cust.ItemHeight = 34;
            this.Lst_cust.Location = new System.Drawing.Point(0, 78);
            this.Lst_cust.Name = "Lst_cust";
            this.Lst_cust.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lst_cust.Size = new System.Drawing.Size(252, 384);
            this.Lst_cust.TabIndex = 1;
            this.Lst_cust.SelectedIndexChanged += new System.EventHandler(this.Lst_cust_SelectedIndexChanged);
            // 
            // Txt_search_cust
            // 
            this.Txt_search_cust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_search_cust.Dock = System.Windows.Forms.DockStyle.Top;
            this.Txt_search_cust.Font = new System.Drawing.Font("Cairo", 11F);
            this.Txt_search_cust.Location = new System.Drawing.Point(0, 36);
            this.Txt_search_cust.Name = "Txt_search_cust";
            this.Txt_search_cust.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_search_cust.Size = new System.Drawing.Size(252, 42);
            this.Txt_search_cust.TabIndex = 0;
            this.Txt_search_cust.TextChanged += new System.EventHandler(this.Txt_search_cust_TextChanged);
            // 
            // lblCustList
            // 
            this.lblCustList.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCustList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustList.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblCustList.ForeColor = System.Drawing.Color.White;
            this.lblCustList.Location = new System.Drawing.Point(0, 0);
            this.lblCustList.Name = "lblCustList";
            this.lblCustList.Size = new System.Drawing.Size(252, 36);
            this.lblCustList.TabIndex = 2;
            this.lblCustList.Text = "قائمة العملاء";
            this.lblCustList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilter
            // 
            this.lblFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFilter.Font = new System.Drawing.Font("Cairo SemiBold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.lblFilter.Location = new System.Drawing.Point(0, 462);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(252, 26);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "البحث عن الحالة";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chk_credit
            // 
            this.Chk_credit.Checked = true;
            this.Chk_credit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_credit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chk_credit.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.Chk_credit.ForeColor = System.Drawing.Color.DarkGreen;
            this.Chk_credit.Location = new System.Drawing.Point(0, 488);
            this.Chk_credit.Name = "Chk_credit";
            this.Chk_credit.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.Chk_credit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chk_credit.Size = new System.Drawing.Size(252, 34);
            this.Chk_credit.TabIndex = 4;
            this.Chk_credit.Text = "دائن";
            this.Chk_credit.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // Chk_debit
            // 
            this.Chk_debit.Checked = true;
            this.Chk_debit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_debit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chk_debit.Font = new System.Drawing.Font("Cairo SemiBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.Chk_debit.ForeColor = System.Drawing.Color.DarkRed;
            this.Chk_debit.Location = new System.Drawing.Point(0, 522);
            this.Chk_debit.Name = "Chk_debit";
            this.Chk_debit.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.Chk_debit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chk_debit.Size = new System.Drawing.Size(252, 34);
            this.Chk_debit.TabIndex = 5;
            this.Chk_debit.Text = "مدين";
            this.Chk_debit.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.pnlTotals);
            this.pnlFooter.Controls.Add(this.loading);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 640);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1632, 42);
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
            this.pnlTotals.Size = new System.Drawing.Size(1450, 40);
            this.pnlTotals.TabIndex = 0;
            // 
            // Lbl_total_debit
            // 
            this.Lbl_total_debit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_total_debit.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Lbl_total_debit.ForeColor = System.Drawing.Color.DarkRed;
            this.Lbl_total_debit.Location = new System.Drawing.Point(180, 0);
            this.Lbl_total_debit.Name = "Lbl_total_debit";
            this.Lbl_total_debit.Size = new System.Drawing.Size(440, 40);
            this.Lbl_total_debit.TabIndex = 0;
            this.Lbl_total_debit.Text = "إجمالي المبيعات: 0.00 $";
            this.Lbl_total_debit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_total_credit
            // 
            this.Lbl_total_credit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_total_credit.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Lbl_total_credit.ForeColor = System.Drawing.Color.DarkGreen;
            this.Lbl_total_credit.Location = new System.Drawing.Point(620, 0);
            this.Lbl_total_credit.Name = "Lbl_total_credit";
            this.Lbl_total_credit.Size = new System.Drawing.Size(430, 40);
            this.Lbl_total_credit.TabIndex = 1;
            this.Lbl_total_credit.Text = "إجمالي المدفوعات: 0.00 $";
            this.Lbl_total_credit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_net
            // 
            this.Lbl_net.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_net.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Lbl_net.ForeColor = System.Drawing.Color.DarkRed;
            this.Lbl_net.Location = new System.Drawing.Point(1050, 0);
            this.Lbl_net.Name = "Lbl_net";
            this.Lbl_net.Size = new System.Drawing.Size(400, 40);
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
            this.loading.Size = new System.Drawing.Size(180, 40);
            this.loading.TabIndex = 1;
            this.loading.Text = "⏳ جاري التحميل...";
            this.loading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loading.Visible = false;
            // 
            // FRM_DistributorLedger
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1632, 682);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "FRM_DistributorLedger";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📋 كشف أرصدة الموزعيـــن";
            this.Load += new System.EventHandler(this.FRM_DistributorLedger_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlTotals.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // ── تعريف جميع الحقول
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Label lblDistributor;
        private System.Windows.Forms.ComboBox Combo_distributor;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker Dt_from;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker Dt_to;
        private DevExpress.XtraEditors.SimpleButton Btn_search;
        private DevExpress.XtraEditors.SimpleButton Btn_xls;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private System.Windows.Forms.Label lblCustList;
        private System.Windows.Forms.TextBox Txt_search_cust;
        private System.Windows.Forms.ListBox Lst_cust;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox Chk_debit;
        private System.Windows.Forms.CheckBox Chk_credit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label Lbl_total_debit;
        private System.Windows.Forms.Label Lbl_total_credit;
        private System.Windows.Forms.Label Lbl_net;
        private System.Windows.Forms.Label loading;
    }
}