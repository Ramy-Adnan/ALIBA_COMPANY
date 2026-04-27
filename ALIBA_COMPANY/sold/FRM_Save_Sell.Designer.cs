
namespace ALIBA_COMPANY.sold
{
    partial class FRM_Save_Sell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Save_Sell));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Txt_ex = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listbox_suggestions = new System.Windows.Forms.ListBox();
            this.Ser_item = new System.Windows.Forms.TextBox();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.Btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Txt_IQrecive = new System.Windows.Forms.TextBox();
            this.Txt_Usdrecive = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_AmountUsd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Txt_AmountIRQ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_IQ_late = new System.Windows.Forms.TextBox();
            this.Txt_usd_late = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_number = new System.Windows.Forms.TextBox();
            this.Txt_pacess = new System.Windows.Forms.TextBox();
            this.Txt_info = new System.Windows.Forms.TextBox();
            this.Btn_add = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Txt_ex);
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.loading);
            this.panelControl1.Controls.Add(this.Btn_cancel);
            this.panelControl1.Controls.Add(this.groupBox5);
            this.panelControl1.Controls.Add(this.Btn_add);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1029, 804);
            this.panelControl1.TabIndex = 0;
            // 
            // Txt_ex
            // 
            this.Txt_ex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_ex.BackColor = System.Drawing.Color.White;
            this.Txt_ex.Enabled = false;
            this.Txt_ex.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold);
            this.Txt_ex.ForeColor = System.Drawing.Color.Red;
            this.Txt_ex.Location = new System.Drawing.Point(618, 655);
            this.Txt_ex.Multiline = true;
            this.Txt_ex.Name = "Txt_ex";
            this.Txt_ex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_ex.Size = new System.Drawing.Size(312, 41);
            this.Txt_ex.TabIndex = 109;
            this.Txt_ex.Text = "0.00";
            this.Txt_ex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_ex.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.listbox_suggestions);
            this.groupBox2.Controls.Add(this.Ser_item);
            this.groupBox2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(618, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 648);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بحث عن زبائن";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Gray;
            this.checkBox1.Location = new System.Drawing.Point(19, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 41);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "زبون خارجي؟";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listbox_suggestions
            // 
            this.listbox_suggestions.FormattingEnabled = true;
            this.listbox_suggestions.ItemHeight = 26;
            this.listbox_suggestions.Location = new System.Drawing.Point(5, 118);
            this.listbox_suggestions.Name = "listbox_suggestions";
            this.listbox_suggestions.Size = new System.Drawing.Size(397, 524);
            this.listbox_suggestions.TabIndex = 0;
            this.listbox_suggestions.SelectedIndexChanged += new System.EventHandler(this.listbox_suggestions_SelectedIndexChanged);
            // 
            // Ser_item
            // 
            this.Ser_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ser_item.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ser_item.Location = new System.Drawing.Point(5, 70);
            this.Ser_item.Multiline = true;
            this.Ser_item.Name = "Ser_item";
            this.Ser_item.Size = new System.Drawing.Size(397, 49);
            this.Ser_item.TabIndex = 1;
            this.Ser_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ser_item.TextChanged += new System.EventHandler(this.Ser_item_TextChanged);
            this.Ser_item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listbox_suggestions_KeyDown);
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.loading.Appearance.ForeColor = System.Drawing.Color.Black;
            this.loading.Appearance.Options.UseBackColor = true;
            this.loading.Appearance.Options.UseForeColor = true;
            this.loading.AppearanceCaption.Options.UseTextOptions = true;
            this.loading.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.loading.AppearanceDescription.Options.UseTextOptions = true;
            this.loading.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.loading.Location = new System.Drawing.Point(176, 621);
            this.loading.Name = "loading";
            this.loading.ShowCaption = false;
            this.loading.ShowDescription = false;
            this.loading.Size = new System.Drawing.Size(125, 69);
            this.loading.TabIndex = 99;
            this.loading.Text = "انتظر";
            this.loading.Visible = false;
            // 
            // Btn_cancel
            // 
            this.Btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_cancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Btn_cancel.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cancel.Appearance.Options.UseBackColor = true;
            this.Btn_cancel.Appearance.Options.UseFont = true;
            this.Btn_cancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_cancel.ImageOptions.SvgImage")));
            this.Btn_cancel.Location = new System.Drawing.Point(23, 721);
            this.Btn_cancel.Name = "Btn_cancel";
            this.Btn_cancel.Size = new System.Drawing.Size(201, 71);
            this.Btn_cancel.TabIndex = 97;
            this.Btn_cancel.Text = "اغلاق";
            this.Btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.Txt_IQrecive);
            this.groupBox5.Controls.Add(this.Txt_Usdrecive);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.Txt_AmountUsd);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.Txt_AmountIRQ);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.Txt_IQ_late);
            this.groupBox5.Controls.Add(this.Txt_usd_late);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.Txt_number);
            this.groupBox5.Controls.Add(this.Txt_pacess);
            this.groupBox5.Controls.Add(this.Txt_info);
            this.groupBox5.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox5.Location = new System.Drawing.Point(15, 1);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox5.Size = new System.Drawing.Size(601, 613);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "معلومات الوصل";
            // 
            // Txt_IQrecive
            // 
            this.Txt_IQrecive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_IQrecive.BackColor = System.Drawing.Color.White;
            this.Txt_IQrecive.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold);
            this.Txt_IQrecive.ForeColor = System.Drawing.Color.Red;
            this.Txt_IQrecive.Location = new System.Drawing.Point(107, 338);
            this.Txt_IQrecive.Multiline = true;
            this.Txt_IQrecive.Name = "Txt_IQrecive";
            this.Txt_IQrecive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_IQrecive.Size = new System.Drawing.Size(271, 39);
            this.Txt_IQrecive.TabIndex = 107;
            this.Txt_IQrecive.Text = "0.00";
            this.Txt_IQrecive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_IQrecive.TextChanged += new System.EventHandler(this.Txt_IQrecive_TextChanged);
            this.Txt_IQrecive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_IQrecive_KeyPress);
            this.Txt_IQrecive.Leave += new System.EventHandler(this.Txt_IQrecive_Leave);
            this.Txt_IQrecive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Txt_IQrecive_MouseDown);
            // 
            // Txt_Usdrecive
            // 
            this.Txt_Usdrecive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Usdrecive.BackColor = System.Drawing.Color.White;
            this.Txt_Usdrecive.Enabled = false;
            this.Txt_Usdrecive.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold);
            this.Txt_Usdrecive.ForeColor = System.Drawing.Color.Red;
            this.Txt_Usdrecive.Location = new System.Drawing.Point(107, 285);
            this.Txt_Usdrecive.Multiline = true;
            this.Txt_Usdrecive.Name = "Txt_Usdrecive";
            this.Txt_Usdrecive.ReadOnly = true;
            this.Txt_Usdrecive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Usdrecive.Size = new System.Drawing.Size(271, 41);
            this.Txt_Usdrecive.TabIndex = 106;
            this.Txt_Usdrecive.Text = "0.00";
            this.Txt_Usdrecive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Usdrecive.TextChanged += new System.EventHandler(this.Txt_Usdrecive_TextChanged);
            this.Txt_Usdrecive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Usdrecive_KeyPress);
            this.Txt_Usdrecive.Leave += new System.EventHandler(this.Txt_Usdrecive_Leave);
            this.Txt_Usdrecive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Txt_Usdrecive_MouseDown);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(387, 166);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(201, 40);
            this.label14.TabIndex = 105;
            this.label14.Text = "مبلغ القائـــــــمة :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(387, 218);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(205, 48);
            this.label1.TabIndex = 104;
            this.label1.Text = "المبلغ الاجــــــــل :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_AmountUsd
            // 
            this.Txt_AmountUsd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_AmountUsd.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_AmountUsd.ForeColor = System.Drawing.Color.Red;
            this.Txt_AmountUsd.HideSelection = false;
            this.Txt_AmountUsd.Location = new System.Drawing.Point(107, 52);
            this.Txt_AmountUsd.Name = "Txt_AmountUsd";
            this.Txt_AmountUsd.ReadOnly = true;
            this.Txt_AmountUsd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_AmountUsd.Size = new System.Drawing.Size(271, 42);
            this.Txt_AmountUsd.TabIndex = 103;
            this.Txt_AmountUsd.Text = "0";
            this.Txt_AmountUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(8, 226);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(93, 40);
            this.label13.TabIndex = 101;
            this.label13.Text = "عراقي";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(7, 169);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(93, 40);
            this.label12.TabIndex = 99;
            this.label12.Text = "عراقي";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(20, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(80, 40);
            this.label11.TabIndex = 98;
            this.label11.Text = "دولار";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(20, 52);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(80, 40);
            this.label10.TabIndex = 97;
            this.label10.Text = "دولار";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txt_AmountIRQ
            // 
            this.Txt_AmountIRQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_AmountIRQ.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_AmountIRQ.ForeColor = System.Drawing.Color.Red;
            this.Txt_AmountIRQ.HideSelection = false;
            this.Txt_AmountIRQ.Location = new System.Drawing.Point(107, 166);
            this.Txt_AmountIRQ.Name = "Txt_AmountIRQ";
            this.Txt_AmountIRQ.ReadOnly = true;
            this.Txt_AmountIRQ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_AmountIRQ.Size = new System.Drawing.Size(271, 42);
            this.Txt_AmountIRQ.TabIndex = 96;
            this.Txt_AmountIRQ.Text = "0";
            this.Txt_AmountIRQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(387, 105);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(195, 48);
            this.label9.TabIndex = 95;
            this.label9.Text = "المبلغ الاجــــــــل :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_IQ_late
            // 
            this.Txt_IQ_late.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_IQ_late.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_IQ_late.ForeColor = System.Drawing.Color.Red;
            this.Txt_IQ_late.HideSelection = false;
            this.Txt_IQ_late.Location = new System.Drawing.Point(107, 223);
            this.Txt_IQ_late.Name = "Txt_IQ_late";
            this.Txt_IQ_late.ReadOnly = true;
            this.Txt_IQ_late.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_IQ_late.Size = new System.Drawing.Size(271, 42);
            this.Txt_IQ_late.TabIndex = 94;
            this.Txt_IQ_late.Text = "0";
            this.Txt_IQ_late.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_usd_late
            // 
            this.Txt_usd_late.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_usd_late.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_usd_late.ForeColor = System.Drawing.Color.Red;
            this.Txt_usd_late.HideSelection = false;
            this.Txt_usd_late.Location = new System.Drawing.Point(107, 109);
            this.Txt_usd_late.Name = "Txt_usd_late";
            this.Txt_usd_late.ReadOnly = true;
            this.Txt_usd_late.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_usd_late.Size = new System.Drawing.Size(271, 42);
            this.Txt_usd_late.TabIndex = 92;
            this.Txt_usd_late.Text = "0";
            this.Txt_usd_late.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(387, 517);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(205, 66);
            this.label7.TabIndex = 91;
            this.label7.Text = "الملاحظــــــــــــات:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(387, 454);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(205, 44);
            this.label6.TabIndex = 90;
            this.label6.Text = "عدد القطـــــــــــع :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(387, 389);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(206, 50);
            this.label5.TabIndex = 89;
            this.label5.Text = "عدد المـــــــــــواد :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(387, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(201, 40);
            this.label4.TabIndex = 88;
            this.label4.Text = "مبلغ القائـــــــمة :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(387, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(205, 50);
            this.label3.TabIndex = 87;
            this.label3.Text = "المستلم بالعراقي :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Cairo", 12.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(387, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(205, 48);
            this.label2.TabIndex = 86;
            this.label2.Text = "المستلم بـالــدولار :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_number
            // 
            this.Txt_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_number.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_number.ForeColor = System.Drawing.Color.Red;
            this.Txt_number.HideSelection = false;
            this.Txt_number.Location = new System.Drawing.Point(107, 396);
            this.Txt_number.Name = "Txt_number";
            this.Txt_number.ReadOnly = true;
            this.Txt_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_number.Size = new System.Drawing.Size(271, 42);
            this.Txt_number.TabIndex = 14;
            this.Txt_number.Text = "0";
            this.Txt_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_pacess
            // 
            this.Txt_pacess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_pacess.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_pacess.ForeColor = System.Drawing.Color.Red;
            this.Txt_pacess.HideSelection = false;
            this.Txt_pacess.Location = new System.Drawing.Point(107, 457);
            this.Txt_pacess.Name = "Txt_pacess";
            this.Txt_pacess.ReadOnly = true;
            this.Txt_pacess.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_pacess.Size = new System.Drawing.Size(271, 42);
            this.Txt_pacess.TabIndex = 13;
            this.Txt_pacess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_info
            // 
            this.Txt_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_info.Font = new System.Drawing.Font("LBC", 12.2F, System.Drawing.FontStyle.Bold);
            this.Txt_info.Location = new System.Drawing.Point(8, 505);
            this.Txt_info.Multiline = true;
            this.Txt_info.Name = "Txt_info";
            this.Txt_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_info.Size = new System.Drawing.Size(371, 81);
            this.Txt_info.TabIndex = 12;
            this.Txt_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Btn_add
            // 
            this.Btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_add.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Btn_add.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_add.Appearance.Options.UseBackColor = true;
            this.Btn_add.Appearance.Options.UseBorderColor = true;
            this.Btn_add.Appearance.Options.UseFont = true;
            this.Btn_add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_add.ImageOptions.SvgImage")));
            this.Btn_add.Location = new System.Drawing.Point(230, 721);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(199, 71);
            this.Btn_add.TabIndex = 96;
            this.Btn_add.Text = "حفظ";
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // FRM_Save_Sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1029, 804);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Save_Sell";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "وصل الزبون";
            this.Load += new System.EventHandler(this.FRM_Save_Sell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.TextBox Txt_info;
        public System.Windows.Forms.TextBox Txt_number;
        public System.Windows.Forms.TextBox Txt_pacess;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.SimpleButton Btn_add;
        public DevExpress.XtraEditors.SimpleButton Btn_cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listbox_suggestions;
        public System.Windows.Forms.TextBox Ser_item;
        public System.Windows.Forms.TextBox Txt_usd_late;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox Txt_AmountUsd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox Txt_AmountIRQ;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox Txt_IQ_late;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox Txt_Usdrecive;
        public System.Windows.Forms.TextBox Txt_IQrecive;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        public System.Windows.Forms.TextBox Txt_ex;
    }
}