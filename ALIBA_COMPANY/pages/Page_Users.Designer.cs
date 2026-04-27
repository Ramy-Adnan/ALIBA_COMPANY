
namespace ALIBA_COMPANY.pages
{
    partial class Page_Users
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page_Users));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_details = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.Btn_details);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 606);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 113);
            this.panel1.TabIndex = 0;
            // 
            // Btn_details
            // 
            this.Btn_details.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_details.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_details.Appearance.Options.UseFont = true;
            this.Btn_details.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_details.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_details.ImageOptions.SvgImage")));
            this.Btn_details.Location = new System.Drawing.Point(562, 16);
            this.Btn_details.Name = "Btn_details";
            this.Btn_details.Size = new System.Drawing.Size(167, 84);
            this.Btn_details.TabIndex = 18;
            this.Btn_details.Text = "اضاقة";
            this.Btn_details.Click += new System.EventHandler(this.Btn_details_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Font = new System.Drawing.Font("GE SS Two Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1282, 606);
            this.gridControl1.TabIndex = 9;
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "الاسم الكامل";
            this.gridColumn9.FieldName = "user_FullName";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 383;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "اسم المستخدم";
            this.gridColumn8.FieldName = "user_name";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 256;
            // 
            // fgt
            // 
            this.fgt.Caption = "كلمة السر";
            this.fgt.FieldName = "user_passward";
            this.fgt.MinWidth = 25;
            this.fgt.Name = "fgt";
            this.fgt.Visible = true;
            this.fgt.VisibleIndex = 3;
            this.fgt.Width = 251;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "تاريخ الاضافة";
            this.gridColumn10.DisplayFormat.FormatString = "d";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "user_addDate";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.UnboundDataType = typeof(decimal);
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 253;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "الصلاحية";
            this.gridColumn6.DisplayFormat.FormatString = "{c,0}";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "user_role";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 214;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "التفعيل";
            this.gridColumn11.DisplayFormat.FormatString = "{c,0}";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "user_activity";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 149;
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
            this.loading.Location = new System.Drawing.Point(611, 328);
            this.loading.Name = "loading";
            this.loading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loading.ShowCaption = false;
            this.loading.ShowDescription = false;
            this.loading.Size = new System.Drawing.Size(60, 63);
            this.loading.TabIndex = 17;
            this.loading.Text = "انتظر";
            this.loading.Visible = false;
            // 
            // Page_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Page_Users";
            this.Size = new System.Drawing.Size(1282, 719);
            this.Load += new System.EventHandler(this.Page_Users_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.XtraEditors.SimpleButton Btn_details;
    }
}
