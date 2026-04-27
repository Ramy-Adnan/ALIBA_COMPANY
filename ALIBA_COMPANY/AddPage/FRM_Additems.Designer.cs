
namespace ALIBA_COMPANY.AddPage
{
    partial class FRM_Additems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Additems));
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.combo_CAT = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_LpriceIQ = new System.Windows.Forms.TextBox();
            this.txt_form = new System.Windows.Forms.TextBox();
            this.txt_nameAR = new System.Windows.Forms.TextBox();
            this.txt_nameEn = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_parcode = new System.Windows.Forms.TextBox();
            this.txt_quart = new System.Windows.Forms.TextBox();
            this.txt_LpriceUs = new System.Windows.Forms.TextBox();
            this.txt_UpriceIQ = new System.Windows.Forms.TextBox();
            this.txt_exchangPrice = new System.Windows.Forms.TextBox();
            this.txt_UpriceUs = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_info = new System.Windows.Forms.RichTextBox();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pic_editImage = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cobo_gat = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_editImage)).BeginInit();
            this.cobo_gat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.btn_edit.Appearance.Options.UseBackColor = true;
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_edit.ImageOptions.SvgImage")));
            this.btn_edit.Location = new System.Drawing.Point(7, 553);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(273, 54);
            this.btn_edit.TabIndex = 12;
            this.btn_edit.Text = "حفظ واغلاق";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseBackColor = true;
            this.btn_add.Appearance.Options.UseBorderColor = true;
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_add.ImageOptions.SvgImage")));
            this.btn_add.Location = new System.Drawing.Point(7, 550);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(273, 57);
            this.btn_add.TabIndex = 14;
            this.btn_add.Text = "حفظ";
            this.btn_add.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // combo_CAT
            // 
            this.combo_CAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_CAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_CAT.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_CAT.FormattingEnabled = true;
            this.combo_CAT.Items.AddRange(new object[] {
            "",
            "تجميد",
            "جاف",
            "تبريد",
            "امانات"});
            this.combo_CAT.Location = new System.Drawing.Point(294, 193);
            this.combo_CAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combo_CAT.Name = "combo_CAT";
            this.combo_CAT.Size = new System.Drawing.Size(164, 38);
            this.combo_CAT.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(119, 623);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 37);
            this.label15.TabIndex = 78;
            this.label15.Text = "دينار عراقي";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(119, 574);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 37);
            this.label5.TabIndex = 77;
            this.label5.Text = "دينار عراقي";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(179, 479);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 37);
            this.label16.TabIndex = 76;
            this.label16.Text = "دولار";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(179, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 37);
            this.label14.TabIndex = 75;
            this.label14.Text = "دولار";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(470, 476);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 37);
            this.label12.TabIndex = 74;
            this.label12.Text = "سعر التخفيض";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(470, 430);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 37);
            this.label20.TabIndex = 73;
            this.label20.Text = "سعر البيع";
            // 
            // txt_LpriceIQ
            // 
            this.txt_LpriceIQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_LpriceIQ.BackColor = System.Drawing.Color.White;
            this.txt_LpriceIQ.Font = new System.Drawing.Font("LBC", 14F, System.Drawing.FontStyle.Bold);
            this.txt_LpriceIQ.ForeColor = System.Drawing.Color.SeaGreen;
            this.txt_LpriceIQ.Location = new System.Drawing.Point(245, 620);
            this.txt_LpriceIQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_LpriceIQ.Name = "txt_LpriceIQ";
            this.txt_LpriceIQ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_LpriceIQ.Size = new System.Drawing.Size(218, 37);
            this.txt_LpriceIQ.TabIndex = 11;
            this.txt_LpriceIQ.Text = "0.00";
            this.txt_LpriceIQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_LpriceIQ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_LpriceIQ_MouseDown);
            // 
            // txt_form
            // 
            this.txt_form.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_form.BackColor = System.Drawing.Color.White;
            this.txt_form.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_form.Location = new System.Drawing.Point(297, 240);
            this.txt_form.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_form.Name = "txt_form";
            this.txt_form.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_form.Size = new System.Drawing.Size(164, 37);
            this.txt_form.TabIndex = 4;
            this.txt_form.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_nameAR
            // 
            this.txt_nameAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nameAR.BackColor = System.Drawing.Color.White;
            this.txt_nameAR.Font = new System.Drawing.Font("GE SS Two Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_nameAR.Location = new System.Drawing.Point(8, 54);
            this.txt_nameAR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_nameAR.Name = "txt_nameAR";
            this.txt_nameAR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_nameAR.Size = new System.Drawing.Size(451, 38);
            this.txt_nameAR.TabIndex = 0;
            this.txt_nameAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_nameEn
            // 
            this.txt_nameEn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nameEn.BackColor = System.Drawing.Color.White;
            this.txt_nameEn.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nameEn.Location = new System.Drawing.Point(8, 101);
            this.txt_nameEn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_nameEn.Name = "txt_nameEn";
            this.txt_nameEn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_nameEn.Size = new System.Drawing.Size(451, 37);
            this.txt_nameEn.TabIndex = 1;
            this.txt_nameEn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.combo_CAT);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txt_LpriceIQ);
            this.groupBox3.Controls.Add(this.txt_form);
            this.groupBox3.Controls.Add(this.txt_nameAR);
            this.groupBox3.Controls.Add(this.txt_nameEn);
            this.groupBox3.Controls.Add(this.txt_parcode);
            this.groupBox3.Controls.Add(this.txt_quart);
            this.groupBox3.Controls.Add(this.txt_LpriceUs);
            this.groupBox3.Controls.Add(this.txt_UpriceIQ);
            this.groupBox3.Controls.Add(this.txt_exchangPrice);
            this.groupBox3.Controls.Add(this.txt_UpriceUs);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt_info);
            this.groupBox3.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(286, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(642, 669);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "معلومات المادة";
            // 
            // txt_parcode
            // 
            this.txt_parcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_parcode.BackColor = System.Drawing.Color.White;
            this.txt_parcode.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_parcode.Location = new System.Drawing.Point(8, 147);
            this.txt_parcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_parcode.Name = "txt_parcode";
            this.txt_parcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_parcode.Size = new System.Drawing.Size(451, 37);
            this.txt_parcode.TabIndex = 2;
            this.txt_parcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_quart
            // 
            this.txt_quart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_quart.BackColor = System.Drawing.Color.White;
            this.txt_quart.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_quart.Location = new System.Drawing.Point(297, 286);
            this.txt_quart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_quart.Name = "txt_quart";
            this.txt_quart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_quart.Size = new System.Drawing.Size(164, 37);
            this.txt_quart.TabIndex = 5;
            this.txt_quart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_quart.TextChanged += new System.EventHandler(this.txt_quart_TextChanged);
            this.txt_quart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_quart_KeyPress);
            // 
            // txt_LpriceUs
            // 
            this.txt_LpriceUs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_LpriceUs.BackColor = System.Drawing.Color.White;
            this.txt_LpriceUs.Font = new System.Drawing.Font("LBC", 14F, System.Drawing.FontStyle.Bold);
            this.txt_LpriceUs.ForeColor = System.Drawing.Color.SeaGreen;
            this.txt_LpriceUs.Location = new System.Drawing.Point(245, 479);
            this.txt_LpriceUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_LpriceUs.Name = "txt_LpriceUs";
            this.txt_LpriceUs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_LpriceUs.Size = new System.Drawing.Size(218, 37);
            this.txt_LpriceUs.TabIndex = 8;
            this.txt_LpriceUs.Text = "0.00";
            this.txt_LpriceUs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_LpriceUs.TextChanged += new System.EventHandler(this.txt_LpriceUs_TextChanged);
            this.txt_LpriceUs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_LpriceUs_MouseDown);
            // 
            // txt_UpriceIQ
            // 
            this.txt_UpriceIQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UpriceIQ.BackColor = System.Drawing.Color.White;
            this.txt_UpriceIQ.Font = new System.Drawing.Font("LBC", 14F, System.Drawing.FontStyle.Bold);
            this.txt_UpriceIQ.ForeColor = System.Drawing.Color.Red;
            this.txt_UpriceIQ.Location = new System.Drawing.Point(245, 574);
            this.txt_UpriceIQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_UpriceIQ.Name = "txt_UpriceIQ";
            this.txt_UpriceIQ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UpriceIQ.Size = new System.Drawing.Size(218, 37);
            this.txt_UpriceIQ.TabIndex = 10;
            this.txt_UpriceIQ.Text = "0.00";
            this.txt_UpriceIQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_UpriceIQ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_UpriceIQ_MouseDown);
            // 
            // txt_exchangPrice
            // 
            this.txt_exchangPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_exchangPrice.BackColor = System.Drawing.Color.White;
            this.txt_exchangPrice.Font = new System.Drawing.Font("LBC", 14F, System.Drawing.FontStyle.Bold);
            this.txt_exchangPrice.ForeColor = System.Drawing.Color.DimGray;
            this.txt_exchangPrice.Location = new System.Drawing.Point(245, 525);
            this.txt_exchangPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_exchangPrice.Name = "txt_exchangPrice";
            this.txt_exchangPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_exchangPrice.Size = new System.Drawing.Size(218, 37);
            this.txt_exchangPrice.TabIndex = 9;
            this.txt_exchangPrice.Text = "0";
            this.txt_exchangPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_exchangPrice.TextChanged += new System.EventHandler(this.txt_exchangPrice_TextChanged);
            this.txt_exchangPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_exchangPrice_MouseDown);
            // 
            // txt_UpriceUs
            // 
            this.txt_UpriceUs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UpriceUs.BackColor = System.Drawing.Color.White;
            this.txt_UpriceUs.Font = new System.Drawing.Font("LBC", 14F, System.Drawing.FontStyle.Bold);
            this.txt_UpriceUs.ForeColor = System.Drawing.Color.Red;
            this.txt_UpriceUs.Location = new System.Drawing.Point(245, 430);
            this.txt_UpriceUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_UpriceUs.Name = "txt_UpriceUs";
            this.txt_UpriceUs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UpriceUs.Size = new System.Drawing.Size(218, 37);
            this.txt_UpriceUs.TabIndex = 7;
            this.txt_UpriceUs.Text = "0.00";
            this.txt_UpriceUs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_UpriceUs.TextChanged += new System.EventHandler(this.txt_UpriceUs_TextChanged);
            this.txt_UpriceUs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_UpriceUs_MouseDown);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(470, 522);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 37);
            this.label18.TabIndex = 39;
            this.label18.Text = "سعر الصرف";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(473, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 37);
            this.label11.TabIndex = 21;
            this.label11.Text = "البـــاركـود";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(470, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 37);
            this.label1.TabIndex = 42;
            this.label1.Text = "سعر التخفيض";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(473, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 37);
            this.label10.TabIndex = 19;
            this.label10.Text = "الملاحظــات";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(470, 569);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 37);
            this.label19.TabIndex = 40;
            this.label19.Text = "سعر البيع";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(473, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 37);
            this.label9.TabIndex = 14;
            this.label9.Text = "عدد التجزئـة";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(473, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 37);
            this.label8.TabIndex = 13;
            this.label8.Text = "التـجزئـــة";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(473, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 37);
            this.label7.TabIndex = 12;
            this.label7.Text = "الصنــــف";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(473, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 37);
            this.label4.TabIndex = 11;
            this.label4.Text = "الاسم التجاري";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(473, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "الاسم المتداول";
            // 
            // txt_info
            // 
            this.txt_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_info.BackColor = System.Drawing.Color.White;
            this.txt_info.Font = new System.Drawing.Font("GE SS Two Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_info.Location = new System.Drawing.Point(8, 335);
            this.txt_info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_info.Name = "txt_info";
            this.txt_info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_info.Size = new System.Drawing.Size(451, 85);
            this.txt_info.TabIndex = 6;
            this.txt_info.Text = "";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_cancel.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Appearance.Options.UseBackColor = true;
            this.btn_cancel.Appearance.Options.UseFont = true;
            this.btn_cancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_cancel.ImageOptions.SvgImage")));
            this.btn_cancel.Location = new System.Drawing.Point(7, 618);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(273, 57);
            this.btn_cancel.TabIndex = 15;
            this.btn_cancel.Text = "الغاء";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.pic_editImage);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(17, 29);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(263, 256);
            this.groupBox4.TabIndex = 66;
            this.groupBox4.TabStop = false;
            // 
            // pic_editImage
            // 
            this.pic_editImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_editImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_editImage.Location = new System.Drawing.Point(25, 60);
            this.pic_editImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_editImage.Name = "pic_editImage";
            this.pic_editImage.Size = new System.Drawing.Size(199, 150);
            this.pic_editImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_editImage.TabIndex = 55;
            this.pic_editImage.TabStop = false;
            this.pic_editImage.DoubleClick += new System.EventHandler(this.pic_editImage_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(66, 664);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "انقر زر الايمن على الصورة لتغييرها";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(10, 219);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 17);
            this.label13.TabIndex = 54;
            this.label13.Text = "انقر زر الماوس مرتين لتغيير الصور";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(55, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 30);
            this.label3.TabIndex = 53;
            this.label3.Text = "صورة المادة";
            // 
            // cobo_gat
            // 
            this.cobo_gat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cobo_gat.Controls.Add(this.label17);
            this.cobo_gat.Controls.Add(this.btn_cancel);
            this.cobo_gat.Controls.Add(this.groupBox4);
            this.cobo_gat.Controls.Add(this.groupBox3);
            this.cobo_gat.Controls.Add(this.btn_edit);
            this.cobo_gat.Controls.Add(this.btn_add);
            this.cobo_gat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobo_gat.Location = new System.Drawing.Point(0, 0);
            this.cobo_gat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cobo_gat.Name = "cobo_gat";
            this.cobo_gat.Size = new System.Drawing.Size(931, 691);
            this.cobo_gat.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("LBC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(7, 295);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(273, 72);
            this.label17.TabIndex = 68;
            this.label17.Text = "ملاحظة/عند تغيير الصورة يجب حفظ الصورة في المجلد الخاص بالصور ليتم عرضها لباقي ال" +
    "مستخدمين";
            // 
            // FRM_Additems
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 691);
            this.Controls.Add(this.cobo_gat);
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Additems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المواد";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Additems_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_editImage)).EndInit();
            this.cobo_gat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btn_edit;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.ComboBox combo_CAT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txt_LpriceIQ;
        public System.Windows.Forms.TextBox txt_form;
        public System.Windows.Forms.TextBox txt_nameAR;
        public System.Windows.Forms.TextBox txt_nameEn;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox txt_parcode;
        public System.Windows.Forms.TextBox txt_quart;
        public System.Windows.Forms.TextBox txt_LpriceUs;
        public System.Windows.Forms.TextBox txt_UpriceIQ;
        public System.Windows.Forms.TextBox txt_exchangPrice;
        public System.Windows.Forms.TextBox txt_UpriceUs;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox txt_info;
        public DevExpress.XtraEditors.SimpleButton btn_cancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel cobo_gat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pic_editImage;
    }
}