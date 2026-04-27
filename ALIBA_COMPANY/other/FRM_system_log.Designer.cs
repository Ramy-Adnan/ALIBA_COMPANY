
namespace ALIBA_COMPANY.other
{
    partial class FRM_system_log
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_system_log));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Combo_user = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Combo_motion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_count = new System.Windows.Forms.TextBox();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.edt_secondryunit = new System.Windows.Forms.Label();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_serch = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_exel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluser_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltr_nots = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.dateTimePicker1);
            this.panelControl2.Controls.Add(this.dateTimePicker2);
            this.panelControl2.Controls.Add(this.label11);
            this.panelControl2.Controls.Add(this.label9);
            this.panelControl2.Controls.Add(this.label10);
            this.panelControl2.Controls.Add(this.Combo_user);
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.Combo_motion);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1389, 70);
            this.panelControl2.TabIndex = 11;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(312, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(170, 51);
            this.dateTimePicker1.TabIndex = 115;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(75, 7);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker2.Size = new System.Drawing.Size(178, 51);
            this.dateTimePicker2.TabIndex = 114;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label11.Location = new System.Drawing.Point(489, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 47);
            this.label11.TabIndex = 113;
            this.label11.Text = "من";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label9.Location = new System.Drawing.Point(260, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 50);
            this.label9.TabIndex = 112;
            this.label9.Text = "الى";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label10.Location = new System.Drawing.Point(523, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 51);
            this.label10.TabIndex = 111;
            this.label10.Text = "التاريخ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Combo_user
            // 
            this.Combo_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_user.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_user.DropDownHeight = 820;
            this.Combo_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_user.FormattingEnabled = true;
            this.Combo_user.IntegralHeight = false;
            this.Combo_user.Location = new System.Drawing.Point(664, 11);
            this.Combo_user.Name = "Combo_user";
            this.Combo_user.Size = new System.Drawing.Size(295, 45);
            this.Combo_user.TabIndex = 110;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(966, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 35);
            this.label5.TabIndex = 109;
            this.label5.Text = "المستخدم :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Combo_motion
            // 
            this.Combo_motion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_motion.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_motion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_motion.FormattingEnabled = true;
            this.Combo_motion.Items.AddRange(new object[] {
            "",
            "بيع",
            "راجع بيع",
            "امانه"});
            this.Combo_motion.Location = new System.Drawing.Point(1092, 10);
            this.Combo_motion.Name = "Combo_motion";
            this.Combo_motion.Size = new System.Drawing.Size(204, 45);
            this.Combo_motion.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(1303, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 35);
            this.label4.TabIndex = 107;
            this.label4.Text = "الحركة :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lbl_count);
            this.panelControl1.Controls.Add(this.Btn_print);
            this.panelControl1.Controls.Add(this.edt_secondryunit);
            this.panelControl1.Controls.Add(this.Btn_close);
            this.panelControl1.Controls.Add(this.Btn_serch);
            this.panelControl1.Controls.Add(this.Btn_exel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 679);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1389, 95);
            this.panelControl1.TabIndex = 12;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_count.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_count.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_count.Location = new System.Drawing.Point(583, 27);
            this.lbl_count.Multiline = true;
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.ReadOnly = true;
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_count.Size = new System.Drawing.Size(208, 40);
            this.lbl_count.TabIndex = 20;
            this.lbl_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_print.ImageOptions.SvgImage")));
            this.Btn_print.Location = new System.Drawing.Point(1189, 11);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(92, 74);
            this.Btn_print.TabIndex = 11;
            this.Btn_print.Text = "طباعة ";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // edt_secondryunit
            // 
            this.edt_secondryunit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.edt_secondryunit.BackColor = System.Drawing.Color.Transparent;
            this.edt_secondryunit.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_secondryunit.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.edt_secondryunit.Location = new System.Drawing.Point(798, 31);
            this.edt_secondryunit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.edt_secondryunit.Name = "edt_secondryunit";
            this.edt_secondryunit.Size = new System.Drawing.Size(75, 32);
            this.edt_secondryunit.TabIndex = 1;
            this.edt_secondryunit.Text = "النتائج :";
            this.edt_secondryunit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_close.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_close.ImageOptions.SvgImage")));
            this.Btn_close.Location = new System.Drawing.Point(21, 10);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(95, 73);
            this.Btn_close.TabIndex = 10;
            this.Btn_close.Text = "خروج";
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_serch
            // 
            this.Btn_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_serch.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_serch.Appearance.Options.UseFont = true;
            this.Btn_serch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_serch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_serch.ImageOptions.SvgImage")));
            this.Btn_serch.Location = new System.Drawing.Point(1286, 11);
            this.Btn_serch.Name = "Btn_serch";
            this.Btn_serch.Size = new System.Drawing.Size(92, 74);
            this.Btn_serch.TabIndex = 9;
            this.Btn_serch.Text = "بحث";
            this.Btn_serch.Click += new System.EventHandler(this.Btn_serch_Click);
            // 
            // Btn_exel
            // 
            this.Btn_exel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_exel.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_exel.Appearance.Options.UseFont = true;
            this.Btn_exel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_exel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_exel.ImageOptions.SvgImage")));
            this.Btn_exel.Location = new System.Drawing.Point(1092, 11);
            this.Btn_exel.Name = "Btn_exel";
            this.Btn_exel.Size = new System.Drawing.Size(92, 74);
            this.Btn_exel.TabIndex = 8;
            this.Btn_exel.Text = "XLS";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1389, 609);
            this.gridControl1.TabIndex = 13;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo", 13.8F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.coluser_id,
            this.gridColumn1,
            this.coltr_nots});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "التاريخ";
            this.gridColumn2.DisplayFormat.FormatString = "{c,0}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "A";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 332;
            // 
            // coluser_id
            // 
            this.coluser_id.Caption = "المستخدم";
            this.coluser_id.FieldName = "B";
            this.coluser_id.MinWidth = 25;
            this.coluser_id.Name = "coluser_id";
            this.coluser_id.OptionsColumn.AllowEdit = false;
            this.coluser_id.Visible = true;
            this.coluser_id.VisibleIndex = 2;
            this.coluser_id.Width = 256;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الحركة";
            this.gridColumn1.FieldName = "C";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 164;
            // 
            // coltr_nots
            // 
            this.coltr_nots.Caption = "الملاحظات";
            this.coltr_nots.FieldName = "D";
            this.coltr_nots.MinWidth = 25;
            this.coltr_nots.Name = "coltr_nots";
            this.coltr_nots.OptionsColumn.AllowEdit = false;
            this.coltr_nots.Visible = true;
            this.coltr_nots.VisibleIndex = 0;
            this.coltr_nots.Width = 597;
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.loading.Appearance.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.Appearance.Options.UseBackColor = true;
            this.loading.Appearance.Options.UseFont = true;
            this.loading.AppearanceCaption.Font = new System.Drawing.Font("Droid Arabic Kufi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.loading.AppearanceCaption.Options.UseFont = true;
            this.loading.AppearanceCaption.Options.UseForeColor = true;
            this.loading.AppearanceCaption.Options.UseTextOptions = true;
            this.loading.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.Caption = "...لطفاً انتضر";
            this.loading.Description = "";
            this.loading.Location = new System.Drawing.Point(579, 349);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(231, 77);
            this.loading.TabIndex = 22;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // FRM_system_log
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 774);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FRM_system_log.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_system_log";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "كشف حركات المستخدمين";
            this.Load += new System.EventHandler(this.FRM_system_log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ComboBox Combo_motion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Combo_user;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox lbl_count;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private System.Windows.Forms.Label edt_secondryunit;
        private DevExpress.XtraEditors.SimpleButton Btn_close;
        private DevExpress.XtraEditors.SimpleButton Btn_serch;
        private DevExpress.XtraEditors.SimpleButton Btn_exel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn coluser_id;
        private DevExpress.XtraGrid.Columns.GridColumn coltr_nots;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}