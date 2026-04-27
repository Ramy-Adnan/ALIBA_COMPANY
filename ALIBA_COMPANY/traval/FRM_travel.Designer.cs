
namespace ALIBA_COMPANY.traval
{
    partial class FRM_travel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_travel));
            this.lblNum = new System.Windows.Forms.Label();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.Btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_delete_back = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_edit_back = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_add_back = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_refrsh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
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
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading.AnimationSpeed = 7.7F;
            this.loading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.loading.Appearance.Options.UseBackColor = true;
            this.loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loading.BarAnimationElementThickness = 5;
            this.loading.BarAnimationMotionType = DevExpress.Utils.Animation.MotionType.WithAcceleration;
            this.loading.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.loading.Caption = "";
            this.loading.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.loading.Description = "";
            this.loading.FrameInterval = 2000;
            this.loading.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Rectangle;
            this.loading.Location = new System.Drawing.Point(731, 338);
            this.loading.Name = "loading";
            this.loading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loading.ShowCaption = false;
            this.loading.ShowDescription = false;
            this.loading.Size = new System.Drawing.Size(54, 50);
            this.loading.TabIndex = 15;
            this.loading.Text = "انتظر";
            this.loading.Visible = false;
            // 
            // Btn_delete
            // 
            this.Btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_delete.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_delete.Appearance.Options.UseFont = true;
            this.Btn_delete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_delete.ImageOptions.SvgImage")));
            this.Btn_delete.Location = new System.Drawing.Point(874, 9);
            this.Btn_delete.Name = "Btn_delete";
            this.Btn_delete.Size = new System.Drawing.Size(126, 84);
            this.Btn_delete.TabIndex = 9;
            this.Btn_delete.Text = "حذف سفرة";
            this.Btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_print.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_print.Appearance.Options.UseFont = true;
            this.Btn_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_print.ImageOptions.SvgImage")));
            this.Btn_print.Location = new System.Drawing.Point(1001, 9);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(126, 84);
            this.Btn_print.TabIndex = 7;
            this.Btn_print.Text = "طباعة وصل";
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // Btn_edit
            // 
            this.Btn_edit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_edit.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_edit.Appearance.Options.UseFont = true;
            this.Btn_edit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_edit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_edit.ImageOptions.SvgImage")));
            this.Btn_edit.Location = new System.Drawing.Point(1128, 9);
            this.Btn_edit.Name = "Btn_edit";
            this.Btn_edit.Size = new System.Drawing.Size(126, 84);
            this.Btn_edit.TabIndex = 1;
            this.Btn_edit.Text = "تعديل سفرة";
            this.Btn_edit.Click += new System.EventHandler(this.Btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_add.ImageOptions.SvgImage")));
            this.btn_add.Location = new System.Drawing.Point(1255, 9);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(126, 84);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "اضافة سفرة";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // Btn_delete_back
            // 
            this.Btn_delete_back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_delete_back.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_delete_back.Appearance.Options.UseFont = true;
            this.Btn_delete_back.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_delete_back.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_delete_back.ImageOptions.SvgImage")));
            this.Btn_delete_back.Location = new System.Drawing.Point(344, 9);
            this.Btn_delete_back.Name = "Btn_delete_back";
            this.Btn_delete_back.Size = new System.Drawing.Size(126, 84);
            this.Btn_delete_back.TabIndex = 8;
            this.Btn_delete_back.Text = "حذف الراجع";
            this.Btn_delete_back.Click += new System.EventHandler(this.Btn_delete_back_Click);
            // 
            // Btn_edit_back
            // 
            this.Btn_edit_back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_edit_back.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_edit_back.Appearance.Options.UseFont = true;
            this.Btn_edit_back.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_edit_back.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_edit_back.ImageOptions.SvgImage")));
            this.Btn_edit_back.Location = new System.Drawing.Point(471, 9);
            this.Btn_edit_back.Name = "Btn_edit_back";
            this.Btn_edit_back.Size = new System.Drawing.Size(126, 84);
            this.Btn_edit_back.TabIndex = 6;
            this.Btn_edit_back.Text = "تعديل الراجع";
            this.Btn_edit_back.Click += new System.EventHandler(this.Btn_edit_back_Click);
            // 
            // Btn_add_back
            // 
            this.Btn_add_back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_add_back.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_add_back.Appearance.Options.UseFont = true;
            this.Btn_add_back.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_add_back.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_add_back.ImageOptions.SvgImage")));
            this.Btn_add_back.Location = new System.Drawing.Point(598, 9);
            this.Btn_add_back.Name = "Btn_add_back";
            this.Btn_add_back.Size = new System.Drawing.Size(126, 84);
            this.Btn_add_back.TabIndex = 5;
            this.Btn_add_back.Text = "تقييد الراجع";
            this.Btn_add_back.Click += new System.EventHandler(this.Btn_add_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(134, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "عدد السفرات :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(1517, 646);
            this.gridControl1.TabIndex = 6;
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
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الوصل";
            this.gridColumn1.FieldName = "Tr";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 106;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "التاريخ";
            this.gridColumn2.FieldName = "Date";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 106;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "المواد";
            this.gridColumn7.FieldName = "Items";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 76;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "القطع";
            this.gridColumn4.FieldName = "Units";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 104;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "السياره";
            this.gridColumn3.FieldName = "Car";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 212;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "السائق";
            this.gridColumn5.FieldName = "Emplo";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 212;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "الملاحظات";
            this.gridColumn6.FieldName = "Note";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 250;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loading);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.panelControl3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1517, 748);
            this.panel1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.Btn_delete);
            this.panelControl3.Controls.Add(this.Btn_print);
            this.panelControl3.Controls.Add(this.Btn_edit);
            this.panelControl3.Controls.Add(this.btn_add);
            this.panelControl3.Controls.Add(this.Btn_delete_back);
            this.panelControl3.Controls.Add(this.Btn_edit_back);
            this.panelControl3.Controls.Add(this.Btn_add_back);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.lblNum);
            this.panelControl3.Controls.Add(this.Btn_refrsh);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 646);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1517, 102);
            this.panelControl3.TabIndex = 5;
            // 
            // Btn_refrsh
            // 
            this.Btn_refrsh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_refrsh.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_refrsh.Appearance.Options.UseFont = true;
            this.Btn_refrsh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_refrsh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_refrsh.ImageOptions.SvgImage")));
            this.Btn_refrsh.Location = new System.Drawing.Point(740, 9);
            this.Btn_refrsh.Name = "Btn_refrsh";
            this.Btn_refrsh.Size = new System.Drawing.Size(126, 84);
            this.Btn_refrsh.TabIndex = 3;
            this.Btn_refrsh.Text = "تحديث";
            this.Btn_refrsh.Click += new System.EventHandler(this.Btn_refrsh_Click);
            // 
            // FRM_travel
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 748);
            this.Controls.Add(this.panel1);
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_travel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "السفرات";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNum;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.XtraEditors.SimpleButton Btn_delete;
        private DevExpress.XtraEditors.SimpleButton Btn_print;
        private DevExpress.XtraEditors.SimpleButton Btn_edit;
        private DevExpress.XtraEditors.SimpleButton btn_add;
        private DevExpress.XtraEditors.SimpleButton Btn_delete_back;
        private DevExpress.XtraEditors.SimpleButton Btn_edit_back;
        private DevExpress.XtraEditors.SimpleButton Btn_add_back;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton Btn_refrsh;
    }
}