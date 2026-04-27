
namespace ALIBA_COMPANY.Store
{
    partial class FRM_dis_sold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_dis_sold));
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.colstr_renum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_items = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.Btn_serch = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_excel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Combo_Catg = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_group1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Combo_emplo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ramy = new DevExpress.XtraEditors.GroupControl();
            this.Btn_clear = new System.Windows.Forms.Button();
            this.Btn_ok = new System.Windows.Forms.Button();
            this.clbListNames1 = new System.Windows.Forms.CheckedListBox();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ramy)).BeginInit();
            this.Ramy.SuspendLayout();
            this.SuspendLayout();
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
            this.loading.Location = new System.Drawing.Point(435, 422);
            this.loading.Margin = new System.Windows.Forms.Padding(8);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(198, 46);
            this.loading.TabIndex = 23;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "العدد";
            this.colstr_renum.DisplayFormat.FormatString = "N0";
            this.colstr_renum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colstr_renum.FieldName = "TotalSold";
            this.colstr_renum.MinWidth = 61;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 2;
            this.colstr_renum.Width = 165;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Name";
            this.gridColumn3.FieldName = "ItemEName";
            this.gridColumn3.MinWidth = 61;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 557;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ت";
            this.gridColumn1.FieldName = "SequenceColumn";
            this.gridColumn1.MinWidth = 61;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 118;
            // 
            // Col_items
            // 
            this.Col_items.Caption = " المادة";
            this.Col_items.FieldName = "ItemName";
            this.Col_items.MinWidth = 61;
            this.Col_items.Name = "Col_items";
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 1;
            this.Col_items.Width = 531;
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
            this.gridColumn2,
            this.gridColumn1,
            this.Col_items,
            this.gridColumn3,
            this.colstr_renum});
            this.gridView1.DetailHeight = 850;
            this.gridView1.FooterPanelHeight = 0;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 0;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 1952;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 50;
            this.gridView1.ViewCaptionHeight = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "رقم المادة";
            this.gridColumn2.FieldName = "ItemsId";
            this.gridColumn2.MinWidth = 61;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 113;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 127);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(8);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1025, 491);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // Btn_serch
            // 
            this.Btn_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_serch.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_serch.Appearance.Options.UseFont = true;
            this.Btn_serch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_serch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_serch.ImageOptions.SvgImage")));
            this.Btn_serch.Location = new System.Drawing.Point(905, 10);
            this.Btn_serch.Margin = new System.Windows.Forms.Padding(8);
            this.Btn_serch.Name = "Btn_serch";
            this.Btn_serch.Size = new System.Drawing.Size(115, 91);
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
            this.Btn_excel.Location = new System.Drawing.Point(653, 10);
            this.Btn_excel.Margin = new System.Windows.Forms.Padding(8);
            this.Btn_excel.Name = "Btn_excel";
            this.Btn_excel.Size = new System.Drawing.Size(115, 91);
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
            this.Btn_print.Location = new System.Drawing.Point(779, 10);
            this.Btn_print.Margin = new System.Windows.Forms.Padding(8);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(115, 91);
            this.Btn_print.TabIndex = 7;
            this.Btn_print.Text = "طباعة";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.Btn_close);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.Btn_serch);
            this.panelControl1.Controls.Add(this.Btn_excel);
            this.panelControl1.Controls.Add(this.Btn_print);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 618);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1025, 109);
            this.panelControl1.TabIndex = 21;
            // 
            // Btn_close
            // 
            this.Btn_close.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_close.ImageOptions.SvgImage")));
            this.Btn_close.Location = new System.Drawing.Point(19, 10);
            this.Btn_close.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(115, 91);
            this.Btn_close.TabIndex = 11;
            this.Btn_close.Text = "خروج";
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(-793, 15);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(139, 111);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "خروج";
            // 
            // Combo_Catg
            // 
            this.Combo_Catg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_Catg.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_Catg.DisplayMember = "كل الاصناف";
            this.Combo_Catg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Catg.FormattingEnabled = true;
            this.Combo_Catg.IntegralHeight = false;
            this.Combo_Catg.Location = new System.Drawing.Point(611, 14);
            this.Combo_Catg.Margin = new System.Windows.Forms.Padding(8);
            this.Combo_Catg.Name = "Combo_Catg";
            this.Combo_Catg.Size = new System.Drawing.Size(278, 45);
            this.Combo_Catg.TabIndex = 16;
            this.Combo_Catg.ValueMember = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(890, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 56);
            this.label3.TabIndex = 5;
            this.label3.Text = "الصنــف :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.Btn_group1);
            this.panelControl2.Controls.Add(this.dateTimePicker2);
            this.panelControl2.Controls.Add(this.dateTimePicker1);
            this.panelControl2.Controls.Add(this.Combo_emplo);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.Combo_Catg);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1025, 127);
            this.panelControl2.TabIndex = 20;
            // 
            // Btn_group1
            // 
            this.Btn_group1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_group1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Btn_group1.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_group1.Appearance.Options.UseBackColor = true;
            this.Btn_group1.Appearance.Options.UseFont = true;
            this.Btn_group1.Location = new System.Drawing.Point(611, 76);
            this.Btn_group1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_group1.Name = "Btn_group1";
            this.Btn_group1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_group1.Size = new System.Drawing.Size(278, 45);
            this.Btn_group1.TabIndex = 115;
            this.Btn_group1.Text = "اختيار مواد";
            this.Btn_group1.Click += new System.EventHandler(this.Btn_group1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(6, 8);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(8);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker2.Size = new System.Drawing.Size(181, 51);
            this.dateTimePicker2.TabIndex = 113;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(251, 7);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 51);
            this.dateTimePicker1.TabIndex = 112;
            // 
            // Combo_emplo
            // 
            this.Combo_emplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_emplo.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_emplo.DisplayMember = "كل الاصناف";
            this.Combo_emplo.DropDownHeight = 820;
            this.Combo_emplo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_emplo.FormattingEnabled = true;
            this.Combo_emplo.IntegralHeight = false;
            this.Combo_emplo.Location = new System.Drawing.Point(182, 76);
            this.Combo_emplo.Margin = new System.Windows.Forms.Padding(8);
            this.Combo_emplo.Name = "Combo_emplo";
            this.Combo_emplo.Size = new System.Drawing.Size(244, 45);
            this.Combo_emplo.TabIndex = 111;
            this.Combo_emplo.ValueMember = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(434, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 45);
            this.label4.TabIndex = 110;
            this.label4.Text = "المـوزع :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(434, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 47);
            this.label1.TabIndex = 107;
            this.label1.Text = "من :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(191, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 44);
            this.label2.TabIndex = 109;
            this.label2.Text = "الى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Ramy
            // 
            this.Ramy.Controls.Add(this.Btn_clear);
            this.Ramy.Controls.Add(this.Btn_ok);
            this.Ramy.Controls.Add(this.clbListNames1);
            this.Ramy.Controls.Add(this.txtSearch1);
            this.Ramy.Location = new System.Drawing.Point(29, 127);
            this.Ramy.Name = "Ramy";
            this.Ramy.Size = new System.Drawing.Size(472, 592);
            this.Ramy.TabIndex = 117;
            this.Ramy.Text = "بحث المواد";
            this.Ramy.Visible = false;
            // 
            // Btn_clear
            // 
            this.Btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_clear.Location = new System.Drawing.Point(5, 516);
            this.Btn_clear.Name = "Btn_clear";
            this.Btn_clear.Size = new System.Drawing.Size(213, 48);
            this.Btn_clear.TabIndex = 117;
            this.Btn_clear.Text = "الغاء تحديد الكل";
            this.Btn_clear.UseVisualStyleBackColor = false;
            this.Btn_clear.Click += new System.EventHandler(this.Btn_clear_Click);
            // 
            // Btn_ok
            // 
            this.Btn_ok.BackColor = System.Drawing.Color.Lime;
            this.Btn_ok.Location = new System.Drawing.Point(254, 516);
            this.Btn_ok.Name = "Btn_ok";
            this.Btn_ok.Size = new System.Drawing.Size(213, 48);
            this.Btn_ok.TabIndex = 116;
            this.Btn_ok.Text = "موافق";
            this.Btn_ok.UseVisualStyleBackColor = false;
            this.Btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // clbListNames1
            // 
            this.clbListNames1.CheckOnClick = true;
            this.clbListNames1.Font = new System.Drawing.Font("GE SS Two Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.clbListNames1.FormattingEnabled = true;
            this.clbListNames1.Location = new System.Drawing.Point(5, 89);
            this.clbListNames1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbListNames1.Name = "clbListNames1";
            this.clbListNames1.Size = new System.Drawing.Size(462, 400);
            this.clbListNames1.TabIndex = 110;
            // 
            // txtSearch1
            // 
            this.txtSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtSearch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch1.Font = new System.Drawing.Font("GE SS Two Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearch1.ForeColor = System.Drawing.Color.Black;
            this.txtSearch1.Location = new System.Drawing.Point(5, 40);
            this.txtSearch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(462, 43);
            this.txtSearch1.TabIndex = 112;
            this.txtSearch1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch1.TextChanged += new System.EventHandler(this.txtSearch1_TextChanged);
            // 
            // FRM_dis_sold
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 727);
            this.Controls.Add(this.Ramy);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_dis_sold";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف المبيع";
            this.Load += new System.EventHandler(this.FRM_dis_sold_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ramy)).EndInit();
            this.Ramy.ResumeLayout(false);
            this.Ramy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.XtraGrid.Columns.GridColumn colstr_renum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Col_items;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_serch;
        private DevExpress.XtraEditors.SimpleButton Btn_excel;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox Combo_Catg;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ComboBox Combo_emplo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton Btn_close;
        private DevExpress.XtraEditors.GroupControl Ramy;
        private System.Windows.Forms.Button Btn_clear;
        private System.Windows.Forms.Button Btn_ok;
        private System.Windows.Forms.CheckedListBox clbListNames1;
        private System.Windows.Forms.TextBox txtSearch1;
        private DevExpress.XtraEditors.SimpleButton Btn_group1;
    }
}