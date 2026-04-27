
namespace ALIBA_COMPANY.Store
{
    partial class FRM_stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_stock));
            this.label1 = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.Btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_new = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_items = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstr_renum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(141, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "عدد الوصولات :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNum.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblNum.Location = new System.Drawing.Point(2, 2);
            this.lblNum.Name = "lblNum";
            this.lblNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNum.Size = new System.Drawing.Size(0, 37);
            this.lblNum.TabIndex = 1;
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_delete
            // 
            this.Btn_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_delete.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_delete.Appearance.Options.UseFont = true;
            this.Btn_delete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_delete.ImageOptions.SvgImage")));
            this.Btn_delete.Location = new System.Drawing.Point(891, 8);
            this.Btn_delete.Name = "Btn_delete";
            this.Btn_delete.Size = new System.Drawing.Size(115, 84);
            this.Btn_delete.TabIndex = 3;
            this.Btn_delete.Text = "حذف";
            this.Btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // Btn_new
            // 
            this.Btn_new.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_new.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_new.Appearance.Options.UseFont = true;
            this.Btn_new.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_new.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_new.ImageOptions.SvgImage")));
            this.Btn_new.Location = new System.Drawing.Point(1133, 8);
            this.Btn_new.Name = "Btn_new";
            this.Btn_new.Size = new System.Drawing.Size(115, 84);
            this.Btn_new.TabIndex = 2;
            this.Btn_new.Text = "جديد";
            this.Btn_new.Click += new System.EventHandler(this.Btn_new_Click_1);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.lblNum);
            this.panelControl3.Controls.Add(this.Btn_delete);
            this.panelControl3.Controls.Add(this.Btn_Print);
            this.panelControl3.Controls.Add(this.Btn_new);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 634);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1272, 102);
            this.panelControl3.TabIndex = 5;
            // 
            // Btn_Print
            // 
            this.Btn_Print.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Print.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Print.Appearance.Options.UseFont = true;
            this.Btn_Print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_Print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Print.ImageOptions.SvgImage")));
            this.Btn_Print.Location = new System.Drawing.Point(1012, 8);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(115, 84);
            this.Btn_Print.TabIndex = 1;
            this.Btn_Print.Text = "طباعة";
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.panelControl3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 736);
            this.panel1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1272, 634);
            this.gridControl1.TabIndex = 23;
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
            this.gridColumn1,
            this.Col_items,
            this.gridColumn3,
            this.colstr_renum,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الوصل";
            this.gridColumn1.FieldName = "sto_id";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 130;
            // 
            // Col_items
            // 
            this.Col_items.Caption = "التاريخ";
            this.Col_items.FieldName = "sto_date";
            this.Col_items.MinWidth = 25;
            this.Col_items.Name = "Col_items";
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 3;
            this.Col_items.Width = 232;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "المواد";
            this.gridColumn3.FieldName = "sto_items";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 118;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "القطع";
            this.colstr_renum.FieldName = "sto_unit";
            this.colstr_renum.MinWidth = 25;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 1;
            this.colstr_renum.Width = 133;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "الملاحظات";
            this.gridColumn2.FieldName = "sto_nots";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 629;
            // 
            // FRM_stock
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 736);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_stock";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التالف";
            this.Load += new System.EventHandler(this.FRM_stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNum;
        private DevExpress.XtraEditors.SimpleButton Btn_delete;
        private DevExpress.XtraEditors.SimpleButton Btn_new;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton Btn_Print;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Col_items;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colstr_renum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}