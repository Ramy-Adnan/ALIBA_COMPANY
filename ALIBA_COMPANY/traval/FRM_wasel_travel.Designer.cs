
namespace ALIBA_COMPANY.traval
{
    partial class FRM_wasel_travel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_wasel_travel));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_detials = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_irq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_usd = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_count = new System.Windows.Forms.TextBox();
            this.lbl_amount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cridit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_items = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstr_renum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.Btn_detials);
            this.panelControl1.Controls.Add(this.lbl_irq);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lbl_usd);
            this.panelControl1.Controls.Add(this.label19);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 631);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1480, 124);
            this.panelControl1.TabIndex = 30;
            // 
            // Btn_detials
            // 
            this.Btn_detials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_detials.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_detials.Appearance.Options.UseFont = true;
            this.Btn_detials.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Btn_detials.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_detials.ImageOptions.SvgImage")));
            this.Btn_detials.Location = new System.Drawing.Point(1344, 14);
            this.Btn_detials.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_detials.Name = "Btn_detials";
            this.Btn_detials.Size = new System.Drawing.Size(123, 97);
            this.Btn_detials.TabIndex = 131;
            this.Btn_detials.Text = "التفاصيل";
            this.Btn_detials.Click += new System.EventHandler(this.Btn_detials_Click);
            // 
            // lbl_irq
            // 
            this.lbl_irq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_irq.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_irq.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_irq.Location = new System.Drawing.Point(26, 64);
            this.lbl_irq.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_irq.Multiline = true;
            this.lbl_irq.Name = "lbl_irq";
            this.lbl_irq.ReadOnly = true;
            this.lbl_irq.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_irq.Size = new System.Drawing.Size(359, 49);
            this.lbl_irq.TabIndex = 125;
            this.lbl_irq.Text = "0.00";
            this.lbl_irq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("LBC", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(394, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 36);
            this.label1.TabIndex = 124;
            this.label1.Text = "الدينار :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_usd
            // 
            this.lbl_usd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_usd.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_usd.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_usd.Location = new System.Drawing.Point(26, 6);
            this.lbl_usd.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_usd.Multiline = true;
            this.lbl_usd.Name = "lbl_usd";
            this.lbl_usd.ReadOnly = true;
            this.lbl_usd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_usd.Size = new System.Drawing.Size(359, 49);
            this.lbl_usd.TabIndex = 123;
            this.lbl_usd.Text = "0.00";
            this.lbl_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("LBC", 10F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label19.Location = new System.Drawing.Point(394, 16);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(151, 36);
            this.label19.TabIndex = 122;
            this.label19.Text = "الدولار :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.lbl_count);
            this.panelControl2.Controls.Add(this.lbl_amount);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.lbl_cridit);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label10);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1480, 80);
            this.panelControl2.TabIndex = 31;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_count.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_count.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_count.Location = new System.Drawing.Point(1116, 19);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_count.Multiline = true;
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.ReadOnly = true;
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_count.Size = new System.Drawing.Size(196, 50);
            this.lbl_count.TabIndex = 134;
            this.lbl_count.Text = "0";
            this.lbl_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_amount
            // 
            this.lbl_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_amount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_amount.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_amount.Location = new System.Drawing.Point(671, 19);
            this.lbl_amount.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_amount.Multiline = true;
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.ReadOnly = true;
            this.lbl_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_amount.Size = new System.Drawing.Size(314, 50);
            this.lbl_amount.TabIndex = 133;
            this.lbl_amount.Text = "0.00";
            this.lbl_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(552, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 46);
            this.label2.TabIndex = 132;
            this.label2.Text = "الديون :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_cridit
            // 
            this.lbl_cridit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cridit.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_cridit.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_cridit.Location = new System.Drawing.Point(327, 19);
            this.lbl_cridit.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_cridit.Multiline = true;
            this.lbl_cridit.Name = "lbl_cridit";
            this.lbl_cridit.ReadOnly = true;
            this.lbl_cridit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_cridit.Size = new System.Drawing.Size(226, 50);
            this.lbl_cridit.TabIndex = 131;
            this.lbl_cridit.Text = "0.00";
            this.lbl_cridit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(1321, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 44);
            this.label4.TabIndex = 110;
            this.label4.Text = "الوصولات :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label10.Location = new System.Drawing.Point(994, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 46);
            this.label10.TabIndex = 10;
            this.label10.Text = "القوائم :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 80);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1480, 551);
            this.gridControl1.TabIndex = 35;
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
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("LBC", 13.8F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.Col_items,
            this.colstr_renum,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.DetailHeight = 437;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 1000;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 37;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الوصل";
            this.gridColumn1.FieldName = "list_code";
            this.gridColumn1.MinWidth = 31;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 157;
            // 
            // Col_items
            // 
            this.Col_items.Caption = "العميل";
            this.Col_items.FieldName = "list_name";
            this.Col_items.MinWidth = 31;
            this.Col_items.Name = "Col_items";
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 1;
            this.Col_items.Width = 335;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "المواد";
            this.colstr_renum.FieldName = "list_items";
            this.colstr_renum.MinWidth = 31;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 2;
            this.colstr_renum.Width = 122;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "القطع";
            this.gridColumn2.FieldName = "list_unit";
            this.gridColumn2.MinWidth = 31;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 122;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "(USD)مبلغ القائمة";
            this.gridColumn3.FieldName = "list_amountUsd";
            this.gridColumn3.MinWidth = 31;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 212;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "(IRQ)مبلغ القائمة";
            this.gridColumn4.FieldName = "list_amountIQ";
            this.gridColumn4.MinWidth = 31;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 211;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "(USD)مبلغ الاجل";
            this.gridColumn6.FieldName = "list_cridetUsd";
            this.gridColumn6.MinWidth = 31;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 186;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "(IRQ)مبلغ الاجل";
            this.gridColumn5.FieldName = "list_cridetIQ";
            this.gridColumn5.MinWidth = 31;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 189;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "الدولار المدفوع";
            this.gridColumn10.FieldName = "list_scashUsd";
            this.gridColumn10.MinWidth = 31;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 187;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "الدينار المدفوع";
            this.gridColumn7.FieldName = "list_dcash";
            this.gridColumn7.MinWidth = 31;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 165;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "الملاحظات";
            this.gridColumn8.FieldName = "list_nots";
            this.gridColumn8.MinWidth = 31;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 456;
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
            this.loading.Location = new System.Drawing.Point(770, 434);
            this.loading.Margin = new System.Windows.Forms.Padding(4);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(289, 79);
            this.loading.TabIndex = 36;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // FRM_wasel_travel
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 755);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_wasel_travel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "وصولات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_sell_FormClosing);
            this.Load += new System.EventHandler(this.FRM_wasel_travel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox lbl_irq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lbl_usd;
        private System.Windows.Forms.Label label19;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TextBox lbl_count;
        private System.Windows.Forms.TextBox lbl_amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbl_cridit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Col_items;
        private DevExpress.XtraGrid.Columns.GridColumn colstr_renum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private DevExpress.XtraEditors.SimpleButton Btn_detials;
    }
}