
namespace ALIBA_COMPANY.other
{
    partial class FRM_requst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_requst));
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstr_renum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_items = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Agg = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_add_requst = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.lblNum = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
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
            this.loading.Location = new System.Drawing.Point(605, 326);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(231, 54);
            this.loading.TabIndex = 29;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "الموظف";
            this.gridColumn4.FieldName = "TB_emplo.emplo_name";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 355;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "عدد الايام";
            this.colstr_renum.FieldName = "emr_num";
            this.colstr_renum.MinWidth = 25;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.OptionsColumn.AllowEdit = false;
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 3;
            this.colstr_renum.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "نوع الطلب";
            this.gridColumn3.FieldName = "TB_emst.emst_name";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 153;
            // 
            // Col_items
            // 
            this.Col_items.Caption = "الى تاريخ";
            this.Col_items.DisplayFormat.FormatString = "d";
            this.Col_items.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Col_items.FieldName = "emr__dateTo";
            this.Col_items.MinWidth = 25;
            this.Col_items.Name = "Col_items";
            this.Col_items.OptionsColumn.AllowEdit = false;
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 0;
            this.Col_items.Width = 281;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "رقم الطلب";
            this.gridColumn1.FieldName = "emr_id";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 119;
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
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn5,
            this.colstr_renum,
            this.gridColumn2,
            this.Col_items});
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
            // gridColumn5
            // 
            this.gridColumn5.Caption = "المصادقة";
            this.gridColumn5.FieldName = "TB_action.action_name";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 117;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "من تاريخ";
            this.gridColumn2.DisplayFormat.FormatString = "d";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "emr__dateFrom";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 252;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1408, 595);
            this.gridControl1.TabIndex = 28;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.Btn_Agg);
            this.panelControl3.Controls.Add(this.Btn_close);
            this.panelControl3.Controls.Add(this.Btn_add_requst);
            this.panelControl3.Controls.Add(this.Btn_print);
            this.panelControl3.Controls.Add(this.Btn_delete);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 643);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1408, 97);
            this.panelControl3.TabIndex = 26;
            // 
            // Btn_Agg
            // 
            this.Btn_Agg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Agg.Appearance.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Agg.Appearance.Options.UseFont = true;
            this.Btn_Agg.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Agg.ImageOptions.Image")));
            this.Btn_Agg.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_Agg.Location = new System.Drawing.Point(615, 13);
            this.Btn_Agg.Name = "Btn_Agg";
            this.Btn_Agg.Size = new System.Drawing.Size(205, 74);
            this.Btn_Agg.TabIndex = 16;
            this.Btn_Agg.Text = "مصادقة الطلب";
            this.Btn_Agg.Visible = false;
            this.Btn_Agg.Click += new System.EventHandler(this.Btn_Agg_Click);
            // 
            // Btn_close
            // 
            this.Btn_close.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_close.ImageOptions.SvgImage")));
            this.Btn_close.Location = new System.Drawing.Point(12, 13);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(94, 74);
            this.Btn_close.TabIndex = 15;
            this.Btn_close.Text = "خروج";
            // 
            // Btn_add_requst
            // 
            this.Btn_add_requst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_add_requst.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_add_requst.Appearance.Options.UseFont = true;
            this.Btn_add_requst.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_add_requst.ImageOptions.Image")));
            this.Btn_add_requst.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_add_requst.Location = new System.Drawing.Point(1295, 13);
            this.Btn_add_requst.Name = "Btn_add_requst";
            this.Btn_add_requst.Size = new System.Drawing.Size(92, 74);
            this.Btn_add_requst.TabIndex = 14;
            this.Btn_add_requst.Text = "جديد";
            this.Btn_add_requst.Click += new System.EventHandler(this.Btn_add_requst_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_print.ImageOptions.Image")));
            this.Btn_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_print.Location = new System.Drawing.Point(1099, 13);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(92, 74);
            this.Btn_print.TabIndex = 13;
            this.Btn_print.Text = "طباعة";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // Btn_delete
            // 
            this.Btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_delete.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_delete.Appearance.Options.UseFont = true;
            this.Btn_delete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_delete.ImageOptions.SvgImage")));
            this.Btn_delete.Location = new System.Drawing.Point(1197, 13);
            this.Btn_delete.Name = "Btn_delete";
            this.Btn_delete.Size = new System.Drawing.Size(92, 74);
            this.Btn_delete.TabIndex = 12;
            this.Btn_delete.Text = "حذف";
            this.Btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // lblNum
            // 
            this.lblNum.BackColor = System.Drawing.Color.White;
            this.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNum.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(1014, 7);
            this.lblNum.Name = "lblNum";
            this.lblNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNum.Size = new System.Drawing.Size(239, 35);
            this.lblNum.TabIndex = 19;
            this.lblNum.Text = "0";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.lblNum);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1408, 48);
            this.panelControl2.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(1264, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "عدد الطلبات :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FRM_requst
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 740);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_requst";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الطلبات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_requst_FormClosing);
            this.Load += new System.EventHandler(this.FRM_requst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colstr_renum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn Col_items;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label lblNum;
        private DevExpress.XtraEditors.SimpleButton Btn_add_requst;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private DevExpress.XtraEditors.SimpleButton Btn_delete;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton Btn_close;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton Btn_Agg;
    }
}