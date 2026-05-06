namespace ALIBA_COMPANY.other
{
    partial class FRM_SendCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SendCash));
            this.Lbl_words = new System.Windows.Forms.Label();
            this.Txt_iq = new System.Windows.Forms.TextBox();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.Txt_ex = new System.Windows.Forms.TextBox();
            this.Combo_dis = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_xx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_us = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_not = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listbox_suggestions = new System.Windows.Forms.ListBox();
            this.ser_item = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_words
            // 
            this.Lbl_words.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Lbl_words.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Lbl_words.Location = new System.Drawing.Point(552, 242);
            this.Lbl_words.Name = "Lbl_words";
            this.Lbl_words.Size = new System.Drawing.Size(510, 73);
            this.Lbl_words.TabIndex = 148;
            this.Lbl_words.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_iq
            // 
            this.Txt_iq.BackColor = System.Drawing.Color.White;
            this.Txt_iq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_iq.Enabled = false;
            this.Txt_iq.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.Txt_iq.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Txt_iq.Location = new System.Drawing.Point(552, 319);
            this.Txt_iq.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_iq.Name = "Txt_iq";
            this.Txt_iq.Size = new System.Drawing.Size(510, 57);
            this.Txt_iq.TabIndex = 147;
            this.Txt_iq.Text = "0";
            this.Txt_iq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_iq.TextChanged += new System.EventHandler(this.Txt_iq_TextChanged);
            this.Txt_iq.Enter += new System.EventHandler(this.Txt_iq_Enter);
            this.Txt_iq.Leave += new System.EventHandler(this.Txt_iq_Leave);
            // 
            // loading
            // 
            this.loading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.loading.Appearance.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.Appearance.Options.UseBackColor = true;
            this.loading.Appearance.Options.UseFont = true;
            this.loading.AppearanceCaption.Font = new System.Drawing.Font("Droid Arabic Kufi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.loading.AppearanceCaption.Options.UseFont = true;
            this.loading.AppearanceCaption.Options.UseForeColor = true;
            this.loading.AppearanceCaption.Options.UseTextOptions = true;
            this.loading.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.Caption = "...لطفاً انتضر";
            this.loading.Description = "";
            this.loading.Location = new System.Drawing.Point(13, 556);
            this.loading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(369, 46);
            this.loading.TabIndex = 146;
            this.loading.Text = "progressPanel1";
            this.loading.Visible = false;
            // 
            // Txt_ex
            // 
            this.Txt_ex.Enabled = false;
            this.Txt_ex.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ex.ForeColor = System.Drawing.Color.Red;
            this.Txt_ex.HideSelection = false;
            this.Txt_ex.Location = new System.Drawing.Point(552, 194);
            this.Txt_ex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_ex.MaxLength = 20;
            this.Txt_ex.Name = "Txt_ex";
            this.Txt_ex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_ex.Size = new System.Drawing.Size(433, 42);
            this.Txt_ex.TabIndex = 145;
            this.Txt_ex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_ex.TextChanged += new System.EventHandler(this.Txt_ex_TextChanged);
            this.Txt_ex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_ex_KeyPress);
            // 
            // Combo_dis
            // 
            this.Combo_dis.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_dis.DisplayMember = "0";
            this.Combo_dis.DropDownHeight = 420;
            this.Combo_dis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_dis.Enabled = false;
            this.Combo_dis.Font = new System.Drawing.Font("GE SS Two Bold", 18F, System.Drawing.FontStyle.Bold);
            this.Combo_dis.FormattingEnabled = true;
            this.Combo_dis.IntegralHeight = false;
            this.Combo_dis.Location = new System.Drawing.Point(552, 71);
            this.Combo_dis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Combo_dis.Name = "Combo_dis";
            this.Combo_dis.Size = new System.Drawing.Size(433, 48);
            this.Combo_dis.TabIndex = 144;
            this.Combo_dis.ValueMember = "0";
            this.Combo_dis.SelectedIndexChanged += new System.EventHandler(this.Combo_dis_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(434, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 26);
            this.label5.TabIndex = 143;
            this.label5.Text = "العميـــــــل:";
            // 
            // Txt_xx
            // 
            this.Txt_xx.BackColor = System.Drawing.Color.SkyBlue;
            this.Txt_xx.Enabled = false;
            this.Txt_xx.Font = new System.Drawing.Font("GE SS Two Bold", 16F, System.Drawing.FontStyle.Bold);
            this.Txt_xx.ForeColor = System.Drawing.Color.Red;
            this.Txt_xx.HideSelection = false;
            this.Txt_xx.Location = new System.Drawing.Point(552, 11);
            this.Txt_xx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_xx.MaxLength = 20;
            this.Txt_xx.Name = "Txt_xx";
            this.Txt_xx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_xx.Size = new System.Drawing.Size(433, 43);
            this.Txt_xx.TabIndex = 142;
            this.Txt_xx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_xx.TextChanged += new System.EventHandler(this.Txt_xx_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(427, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 26);
            this.label4.TabIndex = 141;
            this.label4.Text = "التصريــــــف:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(7, 604);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 26);
            this.label3.TabIndex = 140;
            this.label3.Text = "ملاحظة / يجب اختيار زبون في بداية الامر";
            // 
            // Btn_close
            // 
            this.Btn_close.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Btn_close.Appearance.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.Btn_close.Appearance.ForeColor = System.Drawing.Color.Beige;
            this.Btn_close.Appearance.Options.UseBackColor = true;
            this.Btn_close.Appearance.Options.UseFont = true;
            this.Btn_close.Appearance.Options.UseForeColor = true;
            this.Btn_close.Appearance.Options.UseTextOptions = true;
            this.Btn_close.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Btn_close.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_close.AppearanceHovered.Options.UseBackColor = true;
            this.Btn_close.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.Btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_close.ImageOptions.SvgImage")));
            this.Btn_close.Location = new System.Drawing.Point(799, 584);
            this.Btn_close.Margin = new System.Windows.Forms.Padding(6);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_close.Size = new System.Drawing.Size(186, 56);
            this.Btn_close.TabIndex = 139;
            this.Btn_close.Text = "خروج";
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_add
            // 
            this.Btn_add.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 14.2F, System.Drawing.FontStyle.Bold);
            this.Btn_add.Appearance.ForeColor = System.Drawing.Color.Beige;
            this.Btn_add.Appearance.Options.UseBackColor = true;
            this.Btn_add.Appearance.Options.UseFont = true;
            this.Btn_add.Appearance.Options.UseForeColor = true;
            this.Btn_add.Appearance.Options.UseTextOptions = true;
            this.Btn_add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Btn_add.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_add.AppearanceHovered.Options.UseBackColor = true;
            this.Btn_add.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.Btn_add.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Btn_add.Location = new System.Drawing.Point(553, 583);
            this.Btn_add.Margin = new System.Windows.Forms.Padding(6);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_add.Size = new System.Drawing.Size(190, 56);
            this.Btn_add.TabIndex = 138;
            this.Btn_add.Text = "موافق";
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(444, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 26);
            this.label2.TabIndex = 137;
            this.label2.Text = "المـــــــوزع:";
            // 
            // Txt_us
            // 
            this.Txt_us.Enabled = false;
            this.Txt_us.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_us.ForeColor = System.Drawing.Color.Red;
            this.Txt_us.HideSelection = false;
            this.Txt_us.Location = new System.Drawing.Point(552, 134);
            this.Txt_us.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_us.MaxLength = 20;
            this.Txt_us.Name = "Txt_us";
            this.Txt_us.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_us.Size = new System.Drawing.Size(433, 42);
            this.Txt_us.TabIndex = 135;
            this.Txt_us.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(395, 342);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 26);
            this.label15.TabIndex = 134;
            this.label15.Text = "المبلغ العراقي:";
            // 
            // txt_not
            // 
            this.txt_not.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_not.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold);
            this.txt_not.Location = new System.Drawing.Point(552, 389);
            this.txt_not.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_not.Name = "txt_not";
            this.txt_not.Size = new System.Drawing.Size(511, 187);
            this.txt_not.TabIndex = 132;
            this.txt_not.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(413, 411);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 26);
            this.label18.TabIndex = 133;
            this.label18.Text = "الملاحظـــات :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(859, 457);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 26);
            this.label8.TabIndex = 131;
            // 
            // listbox_suggestions
            // 
            this.listbox_suggestions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listbox_suggestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.listbox_suggestions.Font = new System.Drawing.Font("GE SS Two Bold", 14F, System.Drawing.FontStyle.Bold);
            this.listbox_suggestions.FormattingEnabled = true;
            this.listbox_suggestions.ItemHeight = 31;
            this.listbox_suggestions.Location = new System.Drawing.Point(3, 70);
            this.listbox_suggestions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listbox_suggestions.Name = "listbox_suggestions";
            this.listbox_suggestions.Size = new System.Drawing.Size(368, 467);
            this.listbox_suggestions.TabIndex = 0;
            this.listbox_suggestions.SelectedIndexChanged += new System.EventHandler(this.listbox_suggestions_SelectedIndexChanged);
            // 
            // ser_item
            // 
            this.ser_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ser_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.ser_item.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ser_item.Location = new System.Drawing.Point(3, 28);
            this.ser_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ser_item.Name = "ser_item";
            this.ser_item.Size = new System.Drawing.Size(368, 42);
            this.ser_item.TabIndex = 1;
            this.ser_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ser_item.TextChanged += new System.EventHandler(this.ser_item_TextChanged);
            this.ser_item.MouseLeave += new System.EventHandler(this.ser_item_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("GE SS Two Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(403, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 26);
            this.label1.TabIndex = 136;
            this.label1.Text = "المبلغ بالدولار:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.listbox_suggestions);
            this.groupBox2.Controls.Add(this.ser_item);
            this.groupBox2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Brown;
            this.groupBox2.Location = new System.Drawing.Point(7, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(374, 560);
            this.groupBox2.TabIndex = 130;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "البحث عن الزبائن";
            // 
            // FRM_SendCash
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 658);
            this.Controls.Add(this.Lbl_words);
            this.Controls.Add(this.Txt_iq);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.Txt_ex);
            this.Controls.Add(this.Combo_dis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_xx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.Btn_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_us);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_not);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRM_SendCash";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صرف اجل";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_words;
        public System.Windows.Forms.TextBox Txt_iq;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        public System.Windows.Forms.TextBox Txt_ex;
        private System.Windows.Forms.ComboBox Combo_dis;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox Txt_xx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.SimpleButton Btn_close;
        public DevExpress.XtraEditors.SimpleButton Btn_add;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox Txt_us;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.RichTextBox txt_not;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listbox_suggestions;
        public System.Windows.Forms.TextBox ser_item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}