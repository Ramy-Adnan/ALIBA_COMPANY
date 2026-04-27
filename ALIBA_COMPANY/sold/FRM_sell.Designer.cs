
namespace ALIBA_COMPANY.sold
{
    partial class FRM_sell
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
            this.Combo_driver = new System.Windows.Forms.ComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_amanah = new System.Windows.Forms.Button();
            this.Btn_sell = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Combo_travel = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_delete = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.Btn_print = new System.Windows.Forms.Button();
            this.Btn_detials = new System.Windows.Forms.Button();
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
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Combo_driver
            // 
            this.Combo_driver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_driver.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_driver.DisplayMember = "كل الاصناف";
            this.Combo_driver.DropDownHeight = 820;
            this.Combo_driver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_driver.FormattingEnabled = true;
            this.Combo_driver.IntegralHeight = false;
            this.Combo_driver.Location = new System.Drawing.Point(1064, 13);
            this.Combo_driver.Name = "Combo_driver";
            this.Combo_driver.Size = new System.Drawing.Size(240, 45);
            this.Combo_driver.TabIndex = 120;
            this.Combo_driver.ValueMember = "0";
            this.Combo_driver.SelectedIndexChanged += new System.EventHandler(this.Combo_driver_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.groupBox4);
            this.panelControl1.Controls.Add(this.lbl_irq);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lbl_usd);
            this.panelControl1.Controls.Add(this.label19);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 634);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1393, 99);
            this.panelControl1.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Btn_amanah);
            this.groupBox1.Controls.Add(this.Btn_sell);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Combo_travel);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(939, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(449, 78);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(66, 663);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 17);
            this.label5.TabIndex = 51;
            this.label5.Text = "انقر زر الايمن على الصورة لتغييرها";
            // 
            // Btn_amanah
            // 
            this.Btn_amanah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_amanah.BackColor = System.Drawing.Color.DimGray;
            this.Btn_amanah.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_amanah.ForeColor = System.Drawing.Color.White;
            this.Btn_amanah.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_amanah.Location = new System.Drawing.Point(8, 23);
            this.Btn_amanah.Name = "Btn_amanah";
            this.Btn_amanah.Size = new System.Drawing.Size(106, 49);
            this.Btn_amanah.TabIndex = 129;
            this.Btn_amanah.Text = "امانة";
            this.Btn_amanah.UseVisualStyleBackColor = false;
            this.Btn_amanah.Click += new System.EventHandler(this.Btn_amanah_Click);
            // 
            // Btn_sell
            // 
            this.Btn_sell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_sell.BackColor = System.Drawing.Color.DimGray;
            this.Btn_sell.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_sell.ForeColor = System.Drawing.Color.White;
            this.Btn_sell.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_sell.Location = new System.Drawing.Point(336, 23);
            this.Btn_sell.Name = "Btn_sell";
            this.Btn_sell.Size = new System.Drawing.Size(106, 49);
            this.Btn_sell.TabIndex = 126;
            this.Btn_sell.Text = "بيع";
            this.Btn_sell.UseVisualStyleBackColor = false;
            this.Btn_sell.Click += new System.EventHandler(this.Btn_sell_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(121, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 17);
            this.label7.TabIndex = 54;
            this.label7.Text = "انقر زر الماوس مرتين لتغيير الصور";
            // 
            // Combo_travel
            // 
            this.Combo_travel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_travel.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_travel.DisplayMember = "كل الاصناف";
            this.Combo_travel.DropDownHeight = 820;
            this.Combo_travel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_travel.FormattingEnabled = true;
            this.Combo_travel.IntegralHeight = false;
            this.Combo_travel.Location = new System.Drawing.Point(120, 27);
            this.Combo_travel.Name = "Combo_travel";
            this.Combo_travel.Size = new System.Drawing.Size(210, 40);
            this.Combo_travel.TabIndex = 121;
            this.Combo_travel.ValueMember = "0";
            this.Combo_travel.SelectedIndexChanged += new System.EventHandler(this.Combo_travel_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.Btn_delete);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.Btn_print);
            this.groupBox4.Controls.Add(this.Btn_detials);
            this.groupBox4.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(527, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(406, 78);
            this.groupBox4.TabIndex = 130;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(66, 663);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "انقر زر الايمن على الصورة لتغييرها";
            // 
            // Btn_delete
            // 
            this.Btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_delete.BackColor = System.Drawing.Color.DimGray;
            this.Btn_delete.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_delete.ForeColor = System.Drawing.Color.White;
            this.Btn_delete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_delete.Location = new System.Drawing.Point(8, 29);
            this.Btn_delete.Name = "Btn_delete";
            this.Btn_delete.Size = new System.Drawing.Size(106, 49);
            this.Btn_delete.TabIndex = 129;
            this.Btn_delete.Text = "حذف";
            this.Btn_delete.UseVisualStyleBackColor = false;
            this.Btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(78, 314);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(217, 17);
            this.label13.TabIndex = 54;
            this.label13.Text = "انقر زر الماوس مرتين لتغيير الصور";
            // 
            // Btn_print
            // 
            this.Btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_print.BackColor = System.Drawing.Color.DimGray;
            this.Btn_print.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_print.ForeColor = System.Drawing.Color.White;
            this.Btn_print.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_print.Location = new System.Drawing.Point(120, 27);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(165, 49);
            this.Btn_print.TabIndex = 128;
            this.Btn_print.Text = "طباعة وصل راجع";
            this.Btn_print.UseVisualStyleBackColor = false;
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // Btn_detials
            // 
            this.Btn_detials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_detials.BackColor = System.Drawing.Color.DimGray;
            this.Btn_detials.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_detials.ForeColor = System.Drawing.Color.White;
            this.Btn_detials.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_detials.Location = new System.Drawing.Point(288, 27);
            this.Btn_detials.Name = "Btn_detials";
            this.Btn_detials.Size = new System.Drawing.Size(106, 49);
            this.Btn_detials.TabIndex = 127;
            this.Btn_detials.Text = "تفاصيل";
            this.Btn_detials.UseVisualStyleBackColor = false;
            this.Btn_detials.Click += new System.EventHandler(this.Btn_detials_Click);
            // 
            // lbl_irq
            // 
            this.lbl_irq.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_irq.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_irq.Location = new System.Drawing.Point(6, 50);
            this.lbl_irq.Multiline = true;
            this.lbl_irq.Name = "lbl_irq";
            this.lbl_irq.ReadOnly = true;
            this.lbl_irq.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_irq.Size = new System.Drawing.Size(288, 40);
            this.lbl_irq.TabIndex = 125;
            this.lbl_irq.Text = "0.00";
            this.lbl_irq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("LBC", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(301, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 124;
            this.label1.Text = "الدينار :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_usd
            // 
            this.lbl_usd.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_usd.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_usd.Location = new System.Drawing.Point(6, 4);
            this.lbl_usd.Multiline = true;
            this.lbl_usd.Name = "lbl_usd";
            this.lbl_usd.ReadOnly = true;
            this.lbl_usd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_usd.Size = new System.Drawing.Size(288, 40);
            this.lbl_usd.TabIndex = 123;
            this.lbl_usd.Text = "0.00";
            this.lbl_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("LBC", 10F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label19.Location = new System.Drawing.Point(301, 12);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(121, 29);
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
            this.panelControl2.Controls.Add(this.Combo_driver);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label10);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(1393, 64);
            this.panelControl2.TabIndex = 28;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_count.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_count.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_count.Location = new System.Drawing.Point(800, 14);
            this.lbl_count.Multiline = true;
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.ReadOnly = true;
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_count.Size = new System.Drawing.Size(110, 41);
            this.lbl_count.TabIndex = 134;
            this.lbl_count.Text = "0";
            this.lbl_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_amount
            // 
            this.lbl_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_amount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_amount.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_amount.Location = new System.Drawing.Point(520, 16);
            this.lbl_amount.Multiline = true;
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.ReadOnly = true;
            this.lbl_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_amount.Size = new System.Drawing.Size(161, 41);
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
            this.label2.Location = new System.Drawing.Point(429, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 37);
            this.label2.TabIndex = 132;
            this.label2.Text = "الديون :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_cridit
            // 
            this.lbl_cridit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cridit.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_cridit.Font = new System.Drawing.Font("Cairo SemiBold", 12.2F, System.Drawing.FontStyle.Bold);
            this.lbl_cridit.Location = new System.Drawing.Point(269, 15);
            this.lbl_cridit.Multiline = true;
            this.lbl_cridit.Name = "lbl_cridit";
            this.lbl_cridit.ReadOnly = true;
            this.lbl_cridit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_cridit.Size = new System.Drawing.Size(153, 41);
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
            this.label4.Location = new System.Drawing.Point(917, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 35);
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
            this.label10.Location = new System.Drawing.Point(688, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 37);
            this.label10.TabIndex = 10;
            this.label10.Text = "القوائم :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(1308, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 43);
            this.label3.TabIndex = 5;
            this.label3.Text = "الموزع :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 64);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1393, 570);
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
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الوصل";
            this.gridColumn1.FieldName = "list_code";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 126;
            // 
            // Col_items
            // 
            this.Col_items.Caption = "العميل";
            this.Col_items.FieldName = "list_name";
            this.Col_items.MinWidth = 25;
            this.Col_items.Name = "Col_items";
            this.Col_items.Visible = true;
            this.Col_items.VisibleIndex = 1;
            this.Col_items.Width = 268;
            // 
            // colstr_renum
            // 
            this.colstr_renum.Caption = "المواد";
            this.colstr_renum.FieldName = "list_items";
            this.colstr_renum.MinWidth = 25;
            this.colstr_renum.Name = "colstr_renum";
            this.colstr_renum.Visible = true;
            this.colstr_renum.VisibleIndex = 2;
            this.colstr_renum.Width = 98;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "القطع";
            this.gridColumn2.FieldName = "list_unit";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 98;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "(USD)مبلغ القائمة";
            this.gridColumn3.FieldName = "list_amountUsd";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 170;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "(IRQ)مبلغ القائمة";
            this.gridColumn4.FieldName = "list_amountIQ";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 169;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "(USD)مبلغ الاجل";
            this.gridColumn6.FieldName = "list_cridetUsd";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 149;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "(IRQ)مبلغ الاجل";
            this.gridColumn5.FieldName = "list_cridetIQ";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 151;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "الدولار المدفوع";
            this.gridColumn10.FieldName = "list_scashUsd";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "الدينار المدفوع";
            this.gridColumn7.FieldName = "list_dcash";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 132;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "الملاحظات";
            this.gridColumn8.FieldName = "list_nots";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 365;
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.loading.Location = new System.Drawing.Point(643, 346);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(223, 42);
            this.loading.TabIndex = 35;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // FRM_sell
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 733);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_sell";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الوصولات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_sell_FormClosing);
            this.Load += new System.EventHandler(this.FRM_sell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Combo_driver;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_delete;
        private System.Windows.Forms.Button Btn_print;
        private System.Windows.Forms.TextBox lbl_irq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lbl_usd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox lbl_count;
        private System.Windows.Forms.TextBox lbl_amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbl_cridit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_sell;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Combo_travel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Btn_amanah;
        private System.Windows.Forms.Button Btn_detials;
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
    }
}