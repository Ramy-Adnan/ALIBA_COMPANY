
namespace ALIBA_COMPANY.other
{
    partial class FRM_Add_requst
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
            this.Txt_num = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_note = new System.Windows.Forms.RichTextBox();
            this.Btn_close = new System.Windows.Forms.Button();
            this.Btn_add = new System.Windows.Forms.Button();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.Date2 = new System.Windows.Forms.DateTimePicker();
            this.Combo_type = new System.Windows.Forms.ComboBox();
            this.Compo_emplo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Txt_num
            // 
            this.Txt_num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_num.Enabled = false;
            this.Txt_num.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.Txt_num.Location = new System.Drawing.Point(142, 261);
            this.Txt_num.Multiline = true;
            this.Txt_num.Name = "Txt_num";
            this.Txt_num.ReadOnly = true;
            this.Txt_num.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_num.Size = new System.Drawing.Size(139, 44);
            this.Txt_num.TabIndex = 83;
            this.Txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 37);
            this.label1.TabIndex = 84;
            this.label1.Text = "نوع الطلب :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(33, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 37);
            this.label2.TabIndex = 85;
            this.label2.Text = "ملاحظات :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(26, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 37);
            this.label3.TabIndex = 86;
            this.label3.Text = "عدد الايام :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(40, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 37);
            this.label4.TabIndex = 87;
            this.label4.Text = "لغايـــــة :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(39, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 37);
            this.label5.TabIndex = 88;
            this.label5.Text = "من تاريخ :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(34, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 37);
            this.label6.TabIndex = 89;
            this.label6.Text = "الموظف :";
            // 
            // Txt_note
            // 
            this.Txt_note.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_note.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_note.Font = new System.Drawing.Font("LBC", 9F, System.Drawing.FontStyle.Bold);
            this.Txt_note.Location = new System.Drawing.Point(142, 313);
            this.Txt_note.Name = "Txt_note";
            this.Txt_note.Size = new System.Drawing.Size(366, 131);
            this.Txt_note.TabIndex = 90;
            this.Txt_note.Text = "";
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_close.BackColor = System.Drawing.Color.Gray;
            this.Btn_close.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_close.ForeColor = System.Drawing.Color.White;
            this.Btn_close.Location = new System.Drawing.Point(411, 475);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(106, 49);
            this.Btn_close.TabIndex = 92;
            this.Btn_close.Text = "خروج";
            this.Btn_close.UseVisualStyleBackColor = false;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_add
            // 
            this.Btn_add.BackColor = System.Drawing.Color.DimGray;
            this.Btn_add.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_add.ForeColor = System.Drawing.Color.White;
            this.Btn_add.Location = new System.Drawing.Point(36, 475);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(106, 49);
            this.Btn_add.TabIndex = 91;
            this.Btn_add.Text = "موافق";
            this.Btn_add.UseVisualStyleBackColor = false;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // Date1
            // 
            this.Date1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date1.Location = new System.Drawing.Point(142, 143);
            this.Date1.Name = "Date1";
            this.Date1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Date1.Size = new System.Drawing.Size(198, 51);
            this.Date1.TabIndex = 105;
            this.Date1.ValueChanged += new System.EventHandler(this.Date1_ValueChanged);
            // 
            // Date2
            // 
            this.Date2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date2.Location = new System.Drawing.Point(142, 202);
            this.Date2.Name = "Date2";
            this.Date2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Date2.Size = new System.Drawing.Size(198, 51);
            this.Date2.TabIndex = 106;
            this.Date2.ValueChanged += new System.EventHandler(this.Date2_ValueChanged);
            // 
            // Combo_type
            // 
            this.Combo_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Combo_type.BackColor = System.Drawing.SystemColors.Window;
            this.Combo_type.DropDownHeight = 820;
            this.Combo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_type.FormattingEnabled = true;
            this.Combo_type.IntegralHeight = false;
            this.Combo_type.Location = new System.Drawing.Point(142, 37);
            this.Combo_type.Name = "Combo_type";
            this.Combo_type.Size = new System.Drawing.Size(340, 45);
            this.Combo_type.TabIndex = 107;
            this.Combo_type.TextChanged += new System.EventHandler(this.Combo_type_TextChanged);
            // 
            // Compo_emplo
            // 
            this.Compo_emplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Compo_emplo.BackColor = System.Drawing.SystemColors.Window;
            this.Compo_emplo.DropDownHeight = 820;
            this.Compo_emplo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Compo_emplo.FormattingEnabled = true;
            this.Compo_emplo.IntegralHeight = false;
            this.Compo_emplo.Location = new System.Drawing.Point(142, 90);
            this.Compo_emplo.Name = "Compo_emplo";
            this.Compo_emplo.Size = new System.Drawing.Size(340, 45);
            this.Compo_emplo.TabIndex = 108;
            this.Compo_emplo.TextChanged += new System.EventHandler(this.Compo_emplo_TextChanged);
            // 
            // FRM_Add_requst
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 536);
            this.Controls.Add(this.Compo_emplo);
            this.Controls.Add(this.Combo_type);
            this.Controls.Add(this.Date2);
            this.Controls.Add(this.Date1);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.Btn_add);
            this.Controls.Add(this.Txt_note);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_num);
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Add_requst";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "انشاء الطلبات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_Add_requst_FormClosing);
            this.Load += new System.EventHandler(this.FRM_Add_requst_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Txt_num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Btn_close;
        private System.Windows.Forms.Button Btn_add;
        private System.Windows.Forms.DateTimePicker Date1;
        private System.Windows.Forms.DateTimePicker Date2;
        private System.Windows.Forms.ComboBox Combo_type;
        private System.Windows.Forms.ComboBox Compo_emplo;
        private System.Windows.Forms.RichTextBox Txt_note;
    }
}