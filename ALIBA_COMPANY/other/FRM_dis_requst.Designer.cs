
namespace ALIBA_COMPANY.other
{
    partial class FRM_dis_requst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_dis_requst));
            this.lbl_result = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_serch = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Exel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Combo_emplo = new System.Windows.Forms.ComboBox();
            this.Combo_type = new System.Windows.Forms.ComboBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstr_renum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_items = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_result
            // 
            this.lbl_result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_result.BackColor = System.Drawing.Color.White;
            this.lbl_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_result.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.Location = new System.Drawing.Point(782, 25);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_result.Size = new System.Drawing.Size(227, 40);
            this.lbl_result.TabIndex = 19;
            this.lbl_result.Text = "0";
            this.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(1016, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "النتائج :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_close.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_close.ImageOptions.SvgImage")));
            this.Btn_close.Location = new System.Drawing.Point(12, 13);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(94, 74);
            this.Btn_close.TabIndex = 15;
            this.Btn_close.Text = "خروج";
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Controls.Add(this.lbl_result);
            this.panelControl3.Controls.Add(this.Btn_print);
            this.panelControl3.Controls.Add(this.Btn_serch);
            this.panelControl3.Controls.Add(this.Btn_Exel);
            this.panelControl3.Controls.Add(this.Btn_close);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 653);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1632, 97);
            this.panelControl3.TabIndex = 30;
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_print.ImageOptions.SvgImage")));
            this.Btn_print.Location = new System.Drawing.Point(1329, 13);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(92, 74);
            this.Btn_print.TabIndex = 18;
            this.Btn_print.Text = "طباعة ";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // Btn_serch
            // 
            this.Btn_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_serch.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_serch.Appearance.Options.UseFont = true;
            this.Btn_serch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_serch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_serch.ImageOptions.SvgImage")));
            this.Btn_serch.Location = new System.Drawing.Point(1525, 13);
            this.Btn_serch.Name = "Btn_serch";
            this.Btn_serch.Size = new System.Drawing.Size(92, 74);
            this.Btn_serch.TabIndex = 17;
            this.Btn_serch.Text = "بحث";
            this.Btn_serch.Click += new System.EventHandler(this.Btn_serch_Click);
            // 
            // Btn_Exel
            // 
            this.Btn_Exel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Exel.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Exel.Appearance.Options.UseFont = true;
            this.Btn_Exel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_Exel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Exel.ImageOptions.SvgImage")));
            this.Btn_Exel.Location = new System.Drawing.Point(1427, 13);
            this.Btn_Exel.Name = "Btn_Exel";
            this.Btn_Exel.Size = new System.Drawing.Size(92, 74);
            this.Btn_Exel.TabIndex = 16;
            this.Btn_Exel.Text = "XLS";
            this.Btn_Exel.Click += new System.EventHandler(this.Btn_Exel_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.label16);
            this.panelControl2.Controls.Add(this.dateTimePicker2);
            this.panelControl2.Controls.Add(this.dateTimePicker1);
            this.panelControl2.Controls.Add(this.Combo_emplo);
            this.panelControl2.Controls.Add(this.Combo_type);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1632, 73);
            this.panelControl2.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(475, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 35);
            this.label5.TabIndex = 116;
            this.label5.Text = "الى";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(736, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 35);
            this.label4.TabIndex = 115;
            this.label4.Text = "من";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(782, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 35);
            this.label3.TabIndex = 114;
            this.label3.Text = "التاريخ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(1171, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 35);
            this.label1.TabIndex = 113;
            this.label1.Text = "الموظف :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label16.Location = new System.Drawing.Point(1500, 18);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 35);
            this.label16.TabIndex = 112;
            this.label16.Text = "نوع الطلب :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(261, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker2.Size = new System.Drawing.Size(198, 51);
            this.dateTimePicker2.TabIndex = 111;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(531, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(198, 51);
            this.dateTimePicker1.TabIndex = 110;
            // 
            // Combo_emplo
            // 
            this.Combo_emplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_emplo.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_emplo.DropDownHeight = 820;
            this.Combo_emplo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_emplo.FormattingEnabled = true;
            this.Combo_emplo.IntegralHeight = false;
            this.Combo_emplo.Location = new System.Drawing.Point(927, 13);
            this.Combo_emplo.Name = "Combo_emplo";
            this.Combo_emplo.Size = new System.Drawing.Size(237, 45);
            this.Combo_emplo.TabIndex = 109;
            // 
            // Combo_type
            // 
            this.Combo_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_type.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_type.DropDownHeight = 820;
            this.Combo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_type.FormattingEnabled = true;
            this.Combo_type.IntegralHeight = false;
            this.Combo_type.Location = new System.Drawing.Point(1276, 13);
            this.Combo_type.Name = "Combo_type";
            this.Combo_type.Size = new System.Drawing.Size(217, 45);
            this.Combo_type.TabIndex = 108;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 73);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1632, 580);
            this.gridControl1.TabIndex = 34;
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
            this.gridView1.AppearancePrint.EvenRow.Options.UseTextOptions = true;
            this.gridView1.AppearancePrint.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.AppearancePrint.EvenRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.AppearancePrint.EvenRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.AppearancePrint.Row.Options.UseTextOptions = true;
            this.gridView1.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn3,
            this.colstr_renum,
            this.gridColumn2,
            this.Col_items,
            this.gridColumn6,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsPrint.PrintFooter = false;
            this.gridView1.OptionsPrint.PrintGroupFooter = false;
            this.gridView1.OptionsView.AllowGlyphSkinning = true;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "المصادقة";
            this.gridColumn7.FieldName = "Agg";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 99;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "تاريح الطلب";
            this.gridColumn1.FieldName = "Date";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 142;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "الموظف";
            this.gridColumn4.FieldName = "Emplo";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 374;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "نوع الطلب";
            this.gridColumn3.FieldName = "Type";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 163;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "عدد الايام";
            this.colstr_renum.FieldName = "Number";
            this.colstr_renum.MinWidth = 25;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 5;
            this.colstr_renum.Width = 86;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "من تاريخ";
            this.gridColumn2.FieldName = "From";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 151;
            // 
            // Col_items
            // 
            this.Col_items.Caption = "الى تاريخ";
            this.Col_items.DisplayFormat.FormatString = "d";
            this.Col_items.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Col_items.FieldName = "To";
            this.Col_items.MinWidth = 25;
            this.Col_items.Name = "Col_items";
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 3;
            this.Col_items.Width = 156;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "المستخدم";
            this.gridColumn6.FieldName = "User";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 167;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "الملاحظات";
            this.gridColumn5.FieldName = "Note";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 261;
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
            this.loading.Location = new System.Drawing.Point(629, 369);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(231, 54);
            this.loading.TabIndex = 35;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // FRM_dis_requst
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 750);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_dis_requst";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف الطلبات";
            this.Load += new System.EventHandler(this.FRM_dis_requst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton Btn_close;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private DevExpress.XtraEditors.SimpleButton Btn_serch;
        private DevExpress.XtraEditors.SimpleButton Btn_Exel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colstr_renum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Col_items;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private System.Windows.Forms.ComboBox Combo_emplo;
        private System.Windows.Forms.ComboBox Combo_type;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}