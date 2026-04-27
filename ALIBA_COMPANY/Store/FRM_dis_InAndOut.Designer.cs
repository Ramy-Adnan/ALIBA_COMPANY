
namespace ALIBA_COMPANY.Store
{
    partial class FRM_dis_InAndOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_dis_InAndOut));
            this.label1 = new System.Windows.Forms.Label();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.Combo_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_items = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstr_renum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Txt_items_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_detail = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_serch = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_excel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Txt_NumPacies = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Combo_type = new System.Windows.Forms.ComboBox();
            this.Txt_car = new System.Windows.Forms.TextBox();
            this.Txt_NumItem = new System.Windows.Forms.TextBox();
            this.Txt_emplo = new System.Windows.Forms.TextBox();
            this.Combo_branch = new System.Windows.Forms.ComboBox();
            this.Txt_Num = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(427, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 45);
            this.label1.TabIndex = 107;
            this.label1.Text = "من :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading.Appearance.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.Appearance.Options.UseFont = true;
            this.loading.AppearanceCaption.Font = new System.Drawing.Font("Droid Arabic Kufi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.loading.AppearanceCaption.Options.UseFont = true;
            this.loading.AppearanceCaption.Options.UseForeColor = true;
            this.loading.AppearanceCaption.Options.UseTextOptions = true;
            this.loading.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.Caption = "...لطفاً انتضر";
            this.loading.Description = "";
            this.loading.Location = new System.Drawing.Point(579, 480);
            this.loading.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(216, 54);
            this.loading.TabIndex = 27;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // Combo_status
            // 
            this.Combo_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_status.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_status.DisplayMember = "كل الاصناف";
            this.Combo_status.DropDownHeight = 820;
            this.Combo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_status.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Combo_status.FormattingEnabled = true;
            this.Combo_status.IntegralHeight = false;
            this.Combo_status.Items.AddRange(new object[] {
            "",
            "مسجل",
            "مقيد"});
            this.Combo_status.Location = new System.Drawing.Point(949, 126);
            this.Combo_status.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Combo_status.Name = "Combo_status";
            this.Combo_status.Size = new System.Drawing.Size(234, 51);
            this.Combo_status.TabIndex = 111;
            this.Combo_status.ValueMember = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(427, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 45);
            this.label4.TabIndex = 110;
            this.label4.Text = "المـادة :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(427, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 42);
            this.label2.TabIndex = 109;
            this.label2.Text = "الى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(1186, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "الوصل :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.gridControl1.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 184);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1272, 551);
            this.gridControl1.TabIndex = 26;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Load += new System.EventHandler(this.gridControl1_Load);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.ColumnPanelRowHeight = 0;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.Col_items,
            this.gridColumn3,
            this.colstr_renum,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.DetailHeight = 542;
            this.gridView1.FooterPanelHeight = 0;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 0;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 1250;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 44;
            this.gridView1.ViewCaptionHeight = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الوصل";
            this.gridColumn1.FieldName = "WaselNum";
            this.gridColumn1.MinWidth = 39;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 196;
            // 
            // Col_items
            // 
            this.Col_items.Caption = "التاريخ";
            this.Col_items.FieldName = "order_date";
            this.Col_items.MinWidth = 39;
            this.Col_items.Name = "Col_items";
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 1;
            this.Col_items.Width = 300;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "نوع النقل";
            this.gridColumn3.FieldName = "action_name";
            this.gridColumn3.MinWidth = 39;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 181;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "المواد";
            this.colstr_renum.FieldName = "order_items";
            this.colstr_renum.MinWidth = 39;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 2;
            this.colstr_renum.Width = 151;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "القطع";
            this.gridColumn2.FieldName = "order_unit";
            this.gridColumn2.MinWidth = 39;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 151;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "الفرع";
            this.gridColumn4.FieldName = "br_name";
            this.gridColumn4.MinWidth = 39;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 164;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "السائق";
            this.gridColumn5.FieldName = "driver_name";
            this.gridColumn5.MinWidth = 39;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 317;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "السيارة";
            this.gridColumn6.FieldName = "car_name";
            this.gridColumn6.MinWidth = 39;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 331;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "الحالة";
            this.gridColumn8.FieldName = "order_status";
            this.gridColumn8.MinWidth = 39;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 130;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "كود الفرع الاخر";
            this.gridColumn7.FieldName = "br_code";
            this.gridColumn7.MinWidth = 39;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 206;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "المستخدم";
            this.gridColumn9.FieldName = "user_name";
            this.gridColumn9.MinWidth = 39;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 206;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "الملاحظات";
            this.gridColumn10.FieldName = "order_note";
            this.gridColumn10.MinWidth = 39;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            this.gridColumn10.Width = 312;
            // 
            // Txt_items_name
            // 
            this.Txt_items_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_items_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Txt_items_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Txt_items_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_items_name.Font = new System.Drawing.Font("Cairo", 14F);
            this.Txt_items_name.Location = new System.Drawing.Point(53, 130);
            this.Txt_items_name.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt_items_name.Name = "Txt_items_name";
            this.Txt_items_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_items_name.Size = new System.Drawing.Size(367, 51);
            this.Txt_items_name.TabIndex = 106;
            this.Txt_items_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_items_name.TextChanged += new System.EventHandler(this.Txt_items_name_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label8.Location = new System.Drawing.Point(1191, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 33);
            this.label8.TabIndex = 12;
            this.label8.Text = "النوع :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.Btn_detail);
            this.panelControl1.Controls.Add(this.Btn_close);
            this.panelControl1.Controls.Add(this.Btn_serch);
            this.panelControl1.Controls.Add(this.Btn_excel);
            this.panelControl1.Controls.Add(this.Btn_print);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 735);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1272, 105);
            this.panelControl1.TabIndex = 25;
            // 
            // Btn_detail
            // 
            this.Btn_detail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_detail.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_detail.Appearance.Options.UseFont = true;
            this.Btn_detail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_detail.ImageOptions.Image")));
            this.Btn_detail.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_detail.Location = new System.Drawing.Point(1009, 7);
            this.Btn_detail.Name = "Btn_detail";
            this.Btn_detail.Size = new System.Drawing.Size(117, 93);
            this.Btn_detail.TabIndex = 11;
            this.Btn_detail.Text = "التفاصيل";
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_close.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_close.ImageOptions.SvgImage")));
            this.Btn_close.Location = new System.Drawing.Point(8, 4);
            this.Btn_close.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(122, 93);
            this.Btn_close.TabIndex = 10;
            this.Btn_close.Text = "خروج";
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_serch
            // 
            this.Btn_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_serch.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_serch.Appearance.Options.UseFont = true;
            this.Btn_serch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_serch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_serch.ImageOptions.SvgImage")));
            this.Btn_serch.Location = new System.Drawing.Point(1142, 7);
            this.Btn_serch.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Btn_serch.Name = "Btn_serch";
            this.Btn_serch.Size = new System.Drawing.Size(122, 93);
            this.Btn_serch.TabIndex = 9;
            this.Btn_serch.Text = "بحث";
            this.Btn_serch.Click += new System.EventHandler(this.Btn_serch_Click);
            // 
            // Btn_excel
            // 
            this.Btn_excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_excel.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_excel.Appearance.Options.UseFont = true;
            this.Btn_excel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_excel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_excel.ImageOptions.SvgImage")));
            this.Btn_excel.Location = new System.Drawing.Point(733, 7);
            this.Btn_excel.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Btn_excel.Name = "Btn_excel";
            this.Btn_excel.Size = new System.Drawing.Size(122, 93);
            this.Btn_excel.TabIndex = 8;
            this.Btn_excel.Text = "تصدير";
            this.Btn_excel.Click += new System.EventHandler(this.Btn_excel_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_print.ImageOptions.SvgImage")));
            this.Btn_print.Location = new System.Drawing.Point(871, 7);
            this.Btn_print.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(122, 93);
            this.Btn_print.TabIndex = 7;
            this.Btn_print.Text = "طباعة";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.Txt_NumPacies);
            this.panelControl2.Controls.Add(this.dateTimePicker2);
            this.panelControl2.Controls.Add(this.dateTimePicker1);
            this.panelControl2.Controls.Add(this.Combo_type);
            this.panelControl2.Controls.Add(this.Txt_car);
            this.panelControl2.Controls.Add(this.Txt_NumItem);
            this.panelControl2.Controls.Add(this.Txt_emplo);
            this.panelControl2.Controls.Add(this.Combo_branch);
            this.panelControl2.Controls.Add(this.Txt_Num);
            this.panelControl2.Controls.Add(this.Combo_status);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.Txt_items_name);
            this.panelControl2.Controls.Add(this.label9);
            this.panelControl2.Controls.Add(this.label7);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Controls.Add(this.label11);
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.label8);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(8);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1272, 184);
            this.panelControl2.TabIndex = 24;
            // 
            // Txt_NumPacies
            // 
            this.Txt_NumPacies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_NumPacies.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_NumPacies.Location = new System.Drawing.Point(520, 127);
            this.Txt_NumPacies.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt_NumPacies.Multiline = true;
            this.Txt_NumPacies.Name = "Txt_NumPacies";
            this.Txt_NumPacies.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_NumPacies.Size = new System.Drawing.Size(128, 49);
            this.Txt_NumPacies.TabIndex = 117;
            this.Txt_NumPacies.Text = "0";
            this.Txt_NumPacies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(242, 75);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker2.Size = new System.Drawing.Size(178, 51);
            this.dateTimePicker2.TabIndex = 126;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(242, 19);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 51);
            this.dateTimePicker1.TabIndex = 125;
            // 
            // Combo_type
            // 
            this.Combo_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_type.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_type.DisplayMember = "كل الاصناف";
            this.Combo_type.DropDownHeight = 820;
            this.Combo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_type.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Combo_type.FormattingEnabled = true;
            this.Combo_type.IntegralHeight = false;
            this.Combo_type.Location = new System.Drawing.Point(949, 69);
            this.Combo_type.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Combo_type.Name = "Combo_type";
            this.Combo_type.Size = new System.Drawing.Size(234, 51);
            this.Combo_type.TabIndex = 120;
            this.Combo_type.ValueMember = "0";
            // 
            // Txt_car
            // 
            this.Txt_car.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_car.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Txt_car.Location = new System.Drawing.Point(520, 69);
            this.Txt_car.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt_car.Multiline = true;
            this.Txt_car.Name = "Txt_car";
            this.Txt_car.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_car.Size = new System.Drawing.Size(321, 51);
            this.Txt_car.TabIndex = 119;
            this.Txt_car.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_NumItem
            // 
            this.Txt_NumItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_NumItem.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_NumItem.Location = new System.Drawing.Point(748, 125);
            this.Txt_NumItem.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt_NumItem.Multiline = true;
            this.Txt_NumItem.Name = "Txt_NumItem";
            this.Txt_NumItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_NumItem.Size = new System.Drawing.Size(93, 52);
            this.Txt_NumItem.TabIndex = 118;
            this.Txt_NumItem.Text = "0";
            this.Txt_NumItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_emplo
            // 
            this.Txt_emplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_emplo.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Txt_emplo.Location = new System.Drawing.Point(520, 10);
            this.Txt_emplo.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt_emplo.Multiline = true;
            this.Txt_emplo.Name = "Txt_emplo";
            this.Txt_emplo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_emplo.Size = new System.Drawing.Size(321, 52);
            this.Txt_emplo.TabIndex = 116;
            // 
            // Combo_branch
            // 
            this.Combo_branch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_branch.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_branch.DisplayMember = "كل الاصناف";
            this.Combo_branch.DropDownHeight = 820;
            this.Combo_branch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_branch.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Combo_branch.FormattingEnabled = true;
            this.Combo_branch.IntegralHeight = false;
            this.Combo_branch.Location = new System.Drawing.Point(949, 10);
            this.Combo_branch.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Combo_branch.Name = "Combo_branch";
            this.Combo_branch.Size = new System.Drawing.Size(101, 51);
            this.Combo_branch.TabIndex = 113;
            this.Combo_branch.ValueMember = "0";
            // 
            // Txt_Num
            // 
            this.Txt_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Num.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold);
            this.Txt_Num.Location = new System.Drawing.Point(1053, 11);
            this.Txt_Num.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt_Num.Multiline = true;
            this.Txt_Num.Name = "Txt_Num";
            this.Txt_Num.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Num.Size = new System.Drawing.Size(130, 51);
            this.Txt_Num.TabIndex = 112;
            this.Txt_Num.Text = "0";
            this.Txt_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label9.Location = new System.Drawing.Point(843, 129);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 44);
            this.label9.TabIndex = 123;
            this.label9.Text = "المواد :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label7.Location = new System.Drawing.Point(843, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 38);
            this.label7.TabIndex = 122;
            this.label7.Text = "السيارة :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Location = new System.Drawing.Point(843, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 44);
            this.label6.TabIndex = 121;
            this.label6.Text = "السائق :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label11.Location = new System.Drawing.Point(653, 131);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 45);
            this.label11.TabIndex = 124;
            this.label11.Text = "القطع :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(1186, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 27);
            this.label5.TabIndex = 114;
            this.label5.Text = "الحالة :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FRM_dis_InAndOut
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 840);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_dis_InAndOut";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف النقل";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_dis_InAndOut_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private System.Windows.Forms.ComboBox Combo_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Col_items;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colstr_renum;
        private System.Windows.Forms.TextBox Txt_items_name;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_serch;
        private DevExpress.XtraEditors.SimpleButton Btn_excel;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public System.Windows.Forms.TextBox Txt_emplo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Combo_branch;
        public System.Windows.Forms.TextBox Txt_Num;
        public System.Windows.Forms.TextBox Txt_NumItem;
        public System.Windows.Forms.TextBox Txt_NumPacies;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Combo_type;
        public System.Windows.Forms.TextBox Txt_car;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.SimpleButton Btn_close;
        private DevExpress.XtraEditors.SimpleButton Btn_detail;
    }
}