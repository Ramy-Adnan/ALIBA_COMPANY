
namespace ALIBA_COMPANY.traval
{
    partial class FRM_total_wasel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_total_wasel));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitems_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colde_costUsd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colde_totalUsd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colde_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colde_costIQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colde_totalIQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.Btn_wasel = new DevExpress.XtraEditors.SimpleButton();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1212, 840);
            this.gridControl1.TabIndex = 0;
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
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.colitems_id,
            this.colde_costUsd,
            this.colde_totalUsd,
            this.colde_num,
            this.colde_costIQ,
            this.colde_totalIQ});
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
            this.gridColumn2.Caption = "No.";
            this.gridColumn2.FieldName = "TB_items.items_id";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Code";
            this.gridColumn1.FieldName = "TB_items.items_code";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 276;
            // 
            // colitems_id
            // 
            this.colitems_id.Caption = "Item";
            this.colitems_id.FieldName = "TB_items.items_enname";
            this.colitems_id.MinWidth = 25;
            this.colitems_id.Name = "colitems_id";
            this.colitems_id.Visible = true;
            this.colitems_id.VisibleIndex = 2;
            this.colitems_id.Width = 477;
            // 
            // colde_costUsd
            // 
            this.colde_costUsd.Caption = "Price(USD)";
            this.colde_costUsd.FieldName = "de_costUsd";
            this.colde_costUsd.MinWidth = 25;
            this.colde_costUsd.Name = "colde_costUsd";
            this.colde_costUsd.Visible = true;
            this.colde_costUsd.VisibleIndex = 4;
            this.colde_costUsd.Width = 205;
            // 
            // colde_totalUsd
            // 
            this.colde_totalUsd.Caption = "Total(USD)";
            this.colde_totalUsd.FieldName = "de_totalUsd";
            this.colde_totalUsd.MinWidth = 25;
            this.colde_totalUsd.Name = "colde_totalUsd";
            this.colde_totalUsd.Visible = true;
            this.colde_totalUsd.VisibleIndex = 5;
            this.colde_totalUsd.Width = 218;
            // 
            // colde_num
            // 
            this.colde_num.Caption = "Num";
            this.colde_num.FieldName = "de_num";
            this.colde_num.MinWidth = 25;
            this.colde_num.Name = "colde_num";
            this.colde_num.Visible = true;
            this.colde_num.VisibleIndex = 3;
            this.colde_num.Width = 150;
            // 
            // colde_costIQ
            // 
            this.colde_costIQ.Caption = "Price(IQ)";
            this.colde_costIQ.DisplayFormat.FormatString = "N2";
            this.colde_costIQ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colde_costIQ.FieldName = "de_costIQ";
            this.colde_costIQ.MinWidth = 25;
            this.colde_costIQ.Name = "colde_costIQ";
            this.colde_costIQ.Visible = true;
            this.colde_costIQ.VisibleIndex = 6;
            this.colde_costIQ.Width = 229;
            // 
            // colde_totalIQ
            // 
            this.colde_totalIQ.Caption = "Total(IQ)";
            this.colde_totalIQ.DisplayFormat.FormatString = "N2";
            this.colde_totalIQ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colde_totalIQ.FieldName = "de_totalIQ";
            this.colde_totalIQ.MinWidth = 25;
            this.colde_totalIQ.Name = "colde_totalIQ";
            this.colde_totalIQ.Visible = true;
            this.colde_totalIQ.VisibleIndex = 7;
            this.colde_totalIQ.Width = 238;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.lbl_count);
            this.panelControl1.Controls.Add(this.Btn_wasel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 840);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1212, 89);
            this.panelControl1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("GE SS Two Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(159, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 56);
            this.label2.TabIndex = 8;
            this.label2.Text = "عدد مرات بيع المواد :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_count.BackColor = System.Drawing.Color.Transparent;
            this.lbl_count.Font = new System.Drawing.Font("LBC", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_count.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_count.Location = new System.Drawing.Point(13, 19);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_count.Size = new System.Drawing.Size(149, 56);
            this.lbl_count.TabIndex = 9;
            this.lbl_count.Text = "0";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_wasel
            // 
            this.Btn_wasel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_wasel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_wasel.Appearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_wasel.Appearance.Font = new System.Drawing.Font("LBC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_wasel.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.Btn_wasel.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.Btn_wasel.Appearance.Options.UseBackColor = true;
            this.Btn_wasel.Appearance.Options.UseBorderColor = true;
            this.Btn_wasel.Appearance.Options.UseFont = true;
            this.Btn_wasel.Appearance.Options.UseForeColor = true;
            this.Btn_wasel.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Btn_wasel.AppearanceDisabled.Options.UseForeColor = true;
            this.Btn_wasel.AppearanceHovered.Font = new System.Drawing.Font("LBC", 18.2F, System.Drawing.FontStyle.Bold);
            this.Btn_wasel.AppearanceHovered.Options.UseFont = true;
            this.Btn_wasel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.Btn_wasel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_wasel.ImageOptions.SvgImage")));
            this.Btn_wasel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.Btn_wasel.Location = new System.Drawing.Point(926, 18);
            this.Btn_wasel.Name = "Btn_wasel";
            this.Btn_wasel.Padding = new System.Windows.Forms.Padding(2);
            this.Btn_wasel.Size = new System.Drawing.Size(274, 50);
            this.Btn_wasel.TabIndex = 1;
            this.Btn_wasel.Text = "Excel ";
            this.Btn_wasel.Click += new System.EventHandler(this.Btn_wasel_Click);
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading.AnimationSpeed = 7.7F;
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
            this.loading.Location = new System.Drawing.Point(589, 354);
            this.loading.Name = "loading";
            this.loading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loading.ShowCaption = false;
            this.loading.ShowDescription = false;
            this.loading.Size = new System.Drawing.Size(55, 36);
            this.loading.TabIndex = 19;
            this.loading.Text = "انتظر";
            this.loading.Visible = false;
            // 
            // FRM_total_wasel
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 929);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_total_wasel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "وصل موحد";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_total_wasel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colitems_id;
        private DevExpress.XtraGrid.Columns.GridColumn colde_costUsd;
        private DevExpress.XtraGrid.Columns.GridColumn colde_totalUsd;
        private DevExpress.XtraGrid.Columns.GridColumn colde_num;
        private DevExpress.XtraGrid.Columns.GridColumn colde_costIQ;
        private DevExpress.XtraGrid.Columns.GridColumn colde_totalIQ;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_wasel;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_count;
    }
}