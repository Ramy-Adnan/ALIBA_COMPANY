
namespace ALIBA_COMPANY.other
{
    partial class FRM_setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_setting));
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edt_password = new DevExpress.XtraEditors.TextEdit();
            this.edt_username = new DevExpress.XtraEditors.TextEdit();
            this.edt_port = new DevExpress.XtraEditors.TextEdit();
            this.edt_database = new DevExpress.XtraEditors.TextEdit();
            this.edt_servername = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_saveconstring = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_database.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_servername.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Cairo", 14.2F);
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(508, 187);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 49);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "شبكي";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Cairo", 14.2F);
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(512, 104);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 49);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "محلي";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.edt_password);
            this.groupBox3.Controls.Add(this.edt_username);
            this.groupBox3.Controls.Add(this.edt_port);
            this.groupBox3.Controls.Add(this.edt_database);
            this.groupBox3.Controls.Add(this.edt_servername);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(17, 37);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(489, 406);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(335, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 37);
            this.label8.TabIndex = 7;
            this.label8.Text = "كلمة السر";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(335, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 37);
            this.label7.TabIndex = 7;
            this.label7.Text = "اسم المستخدم";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(335, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 37);
            this.label5.TabIndex = 7;
            this.label5.Text = "رقم المنفذ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(335, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "قاعدة البيانات";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(335, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 37);
            this.label6.TabIndex = 7;
            this.label6.Text = "اسم السيرفر";
            // 
            // edt_password
            // 
            this.edt_password.EditValue = "1995";
            this.edt_password.Location = new System.Drawing.Point(27, 338);
            this.edt_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edt_password.Name = "edt_password";
            this.edt_password.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_password.Properties.Appearance.Options.UseFont = true;
            this.edt_password.Properties.PasswordChar = '*';
            this.edt_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_password.Size = new System.Drawing.Size(307, 38);
            this.edt_password.TabIndex = 8;
            // 
            // edt_username
            // 
            this.edt_username.EditValue = "sa";
            this.edt_username.Location = new System.Drawing.Point(27, 266);
            this.edt_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edt_username.Name = "edt_username";
            this.edt_username.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_username.Properties.Appearance.Options.UseFont = true;
            this.edt_username.Properties.PasswordChar = '*';
            this.edt_username.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_username.Size = new System.Drawing.Size(307, 38);
            this.edt_username.TabIndex = 8;
            // 
            // edt_port
            // 
            this.edt_port.EditValue = "1433";
            this.edt_port.Location = new System.Drawing.Point(27, 194);
            this.edt_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edt_port.Name = "edt_port";
            this.edt_port.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_port.Properties.Appearance.Options.UseFont = true;
            this.edt_port.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_port.Size = new System.Drawing.Size(307, 38);
            this.edt_port.TabIndex = 8;
            // 
            // edt_database
            // 
            this.edt_database.EditValue = "AlibaRamy";
            this.edt_database.Location = new System.Drawing.Point(27, 125);
            this.edt_database.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edt_database.Name = "edt_database";
            this.edt_database.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_database.Properties.Appearance.Options.UseFont = true;
            this.edt_database.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_database.Size = new System.Drawing.Size(307, 38);
            this.edt_database.TabIndex = 8;
            // 
            // edt_servername
            // 
            this.edt_servername.EditValue = ".\\Aliba";
            this.edt_servername.Location = new System.Drawing.Point(27, 51);
            this.edt_servername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edt_servername.Name = "edt_servername";
            this.edt_servername.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_servername.Properties.Appearance.Options.UseFont = true;
            this.edt_servername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_servername.Size = new System.Drawing.Size(307, 38);
            this.edt_servername.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.groupBox2.Controls.Add(this.Btn_saveconstring);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Cairo", 14.2F);
            this.groupBox2.Location = new System.Drawing.Point(26, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(669, 543);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اختر نوع الاتصال";
            // 
            // Btn_saveconstring
            // 
            this.Btn_saveconstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_saveconstring.Appearance.Font = new System.Drawing.Font("Cairo", 14F);
            this.Btn_saveconstring.Appearance.Options.UseFont = true;
            this.Btn_saveconstring.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_saveconstring.ImageOptions.SvgImage")));
            this.Btn_saveconstring.Location = new System.Drawing.Point(29, 457);
            this.Btn_saveconstring.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_saveconstring.Name = "Btn_saveconstring";
            this.Btn_saveconstring.Size = new System.Drawing.Size(445, 60);
            this.Btn_saveconstring.TabIndex = 6;
            this.Btn_saveconstring.Text = "حفظ اعدادات الاتصال";
            this.Btn_saveconstring.Click += new System.EventHandler(this.Btn_saveconstring_Click);
            // 
            // FRM_setting
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 571);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Cairo SemiBold", 12F);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FRM_setting.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_setting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الاتصال";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_database.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_servername.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton Btn_saveconstring;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public DevExpress.XtraEditors.TextEdit edt_password;
        public DevExpress.XtraEditors.TextEdit edt_username;
        public DevExpress.XtraEditors.TextEdit edt_port;
        public DevExpress.XtraEditors.TextEdit edt_database;
        public DevExpress.XtraEditors.TextEdit edt_servername;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}