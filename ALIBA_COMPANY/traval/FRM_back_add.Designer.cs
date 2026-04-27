
namespace ALIBA_COMPANY.traval
{
    partial class FRM_back_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_back_add));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LblDriver = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Btn_add_Back = new DevExpress.XtraEditors.SimpleButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblCar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblUnit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblWasel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_close);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.Btn_add_Back);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 737);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 166);
            this.panel1.TabIndex = 0;
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_close.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Btn_close.Appearance.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.Btn_close.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.Btn_close.Appearance.Options.UseBackColor = true;
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.Appearance.Options.UseForeColor = true;
            this.Btn_close.Appearance.Options.UseTextOptions = true;
            this.Btn_close.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Btn_close.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_close.AppearanceHovered.Options.UseBackColor = true;
            this.Btn_close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_close.ImageOptions.Image")));
            this.Btn_close.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Btn_close.Location = new System.Drawing.Point(15, 92);
            this.Btn_close.Margin = new System.Windows.Forms.Padding(6);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_close.Size = new System.Drawing.Size(222, 62);
            this.Btn_close.TabIndex = 15;
            this.Btn_close.Text = "خروج";
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LblDriver);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(314, 103);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(576, 49);
            this.panel6.TabIndex = 13;
            // 
            // LblDriver
            // 
            this.LblDriver.AutoSize = true;
            this.LblDriver.BackColor = System.Drawing.Color.Transparent;
            this.LblDriver.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblDriver.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.LblDriver.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.LblDriver.Location = new System.Drawing.Point(425, 0);
            this.LblDriver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDriver.Name = "LblDriver";
            this.LblDriver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDriver.Size = new System.Drawing.Size(33, 45);
            this.LblDriver.TabIndex = 8;
            this.LblDriver.Text = "0";
            this.LblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label9.Location = new System.Drawing.Point(458, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 45);
            this.label9.TabIndex = 8;
            this.label9.Text = "المـــوزع :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_add_Back
            // 
            this.Btn_add_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_add_Back.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Btn_add_Back.Appearance.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.Btn_add_Back.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.Btn_add_Back.Appearance.Options.UseBackColor = true;
            this.Btn_add_Back.Appearance.Options.UseFont = true;
            this.Btn_add_Back.Appearance.Options.UseForeColor = true;
            this.Btn_add_Back.Appearance.Options.UseTextOptions = true;
            this.Btn_add_Back.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Btn_add_Back.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_add_Back.AppearanceHovered.Options.UseBackColor = true;
            this.Btn_add_Back.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_add_Back.ImageOptions.Image")));
            this.Btn_add_Back.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.Btn_add_Back.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Btn_add_Back.Location = new System.Drawing.Point(15, 22);
            this.Btn_add_Back.Margin = new System.Windows.Forms.Padding(6);
            this.Btn_add_Back.Name = "Btn_add_Back";
            this.Btn_add_Back.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_add_Back.Size = new System.Drawing.Size(222, 58);
            this.Btn_add_Back.TabIndex = 14;
            this.Btn_add_Back.Text = "موافق";
            this.Btn_add_Back.Click += new System.EventHandler(this.Btn_add_Back_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.LblCar);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(314, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(576, 49);
            this.panel5.TabIndex = 12;
            // 
            // LblCar
            // 
            this.LblCar.AutoSize = true;
            this.LblCar.BackColor = System.Drawing.Color.Transparent;
            this.LblCar.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblCar.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.LblCar.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.LblCar.Location = new System.Drawing.Point(425, 0);
            this.LblCar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCar.Name = "LblCar";
            this.LblCar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCar.Size = new System.Drawing.Size(33, 45);
            this.LblCar.TabIndex = 8;
            this.LblCar.Text = "0";
            this.LblCar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label7.Location = new System.Drawing.Point(458, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 45);
            this.label7.TabIndex = 8;
            this.label7.Text = "السيـارة  :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LblUnit);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(935, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 49);
            this.panel4.TabIndex = 12;
            // 
            // LblUnit
            // 
            this.LblUnit.AutoSize = true;
            this.LblUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblUnit.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblUnit.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.LblUnit.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.LblUnit.Location = new System.Drawing.Point(204, 0);
            this.LblUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUnit.Name = "LblUnit";
            this.LblUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblUnit.Size = new System.Drawing.Size(33, 45);
            this.LblUnit.TabIndex = 8;
            this.LblUnit.Text = "0";
            this.LblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(237, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 45);
            this.label5.TabIndex = 8;
            this.label5.Text = "عدد القطع  :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblNum);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(935, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 49);
            this.panel3.TabIndex = 12;
            // 
            // LblNum
            // 
            this.LblNum.AutoSize = true;
            this.LblNum.BackColor = System.Drawing.Color.Transparent;
            this.LblNum.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblNum.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.LblNum.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.LblNum.Location = new System.Drawing.Point(205, 0);
            this.LblNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNum.Name = "LblNum";
            this.LblNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblNum.Size = new System.Drawing.Size(33, 45);
            this.LblNum.TabIndex = 8;
            this.LblNum.Text = "0";
            this.LblNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(238, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "عدد المواد  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblWasel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(975, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 49);
            this.panel2.TabIndex = 11;
            // 
            // LblWasel
            // 
            this.LblWasel.AutoSize = true;
            this.LblWasel.BackColor = System.Drawing.Color.Transparent;
            this.LblWasel.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblWasel.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.LblWasel.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.LblWasel.Location = new System.Drawing.Point(166, 0);
            this.LblWasel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblWasel.Name = "LblWasel";
            this.LblWasel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblWasel.Size = new System.Drawing.Size(33, 45);
            this.LblWasel.TabIndex = 8;
            this.LblWasel.Text = "0";
            this.LblWasel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(199, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 45);
            this.label4.TabIndex = 8;
            this.label4.Text = "رقم الوصل  :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1323, 737);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn8,
            this.fgt,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn11});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 933;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "رقم المادة";
            this.gridColumn9.FieldName = "items_id";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 171;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "المادة";
            this.gridColumn8.FieldName = "colName";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 544;
            // 
            // fgt
            // 
            this.fgt.Caption = "التجزئه";
            this.fgt.FieldName = "colCuart";
            this.fgt.MinWidth = 25;
            this.fgt.Name = "fgt";
            this.fgt.OptionsColumn.AllowEdit = false;
            this.fgt.Visible = true;
            this.fgt.VisibleIndex = 3;
            this.fgt.Width = 210;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "الصاعد";
            this.gridColumn10.DisplayFormat.FormatString = "{c,0}";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "details_num";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.UnboundDataType = typeof(decimal);
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 154;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "النازل";
            this.gridColumn6.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn6.DisplayFormat.FormatString = "{c,0}";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "details_renum";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 151;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "المبيع";
            this.gridColumn11.DisplayFormat.FormatString = "{c,0}";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "sell_num";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 158;
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading.AnimationSpeed = 7.7F;
            this.loading.Appearance.BackColor = System.Drawing.Color.White;
            this.loading.Appearance.Options.UseBackColor = true;
            this.loading.AppearanceCaption.Options.UseTextOptions = true;
            this.loading.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.loading.AppearanceDescription.Options.UseTextOptions = true;
            this.loading.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loading.BarAnimationElementThickness = 5;
            this.loading.BarAnimationMotionType = DevExpress.Utils.Animation.MotionType.WithAcceleration;
            this.loading.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.loading.Caption = "";
            this.loading.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.loading.Description = "";
            this.loading.FrameInterval = 2000;
            this.loading.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Rectangle;
            this.loading.Location = new System.Drawing.Point(619, 383);
            this.loading.Name = "loading";
            this.loading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loading.ShowCaption = false;
            this.loading.ShowDescription = false;
            this.loading.Size = new System.Drawing.Size(60, 63);
            this.loading.TabIndex = 16;
            this.loading.Text = "انتظر";
            this.loading.Visible = false;
            // 
            // FRM_back_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 903);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_back_add";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الراجع";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_back_add_FormClosing);
            this.Load += new System.EventHandler(this.FRM_back_add_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn fgt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        public DevExpress.XtraEditors.SimpleButton Btn_close;
        public DevExpress.XtraEditors.SimpleButton Btn_add_Back;
        public System.Windows.Forms.Label LblDriver;
        public System.Windows.Forms.Label LblCar;
        public System.Windows.Forms.Label LblUnit;
        public System.Windows.Forms.Label LblNum;
        public System.Windows.Forms.Label LblWasel;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
    }
}