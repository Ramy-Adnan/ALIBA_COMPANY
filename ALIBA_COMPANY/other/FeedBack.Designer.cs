
namespace ALIBA_COMPANY.other
{
    partial class FeedBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedBack));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_state = new System.Windows.Forms.Label();
            this.pic_key = new System.Windows.Forms.PictureBox();
            this.txt_info = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_key)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txt_state);
            this.panel1.Controls.Add(this.pic_key);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("LBC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1406, 187);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Teal;
            this.pictureBox1.Image = global::ALIBA_COMPANY.Properties.Resources.RAMY121212;
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txt_state
            // 
            this.txt_state.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_state.Font = new System.Drawing.Font("LBC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_state.ForeColor = System.Drawing.Color.White;
            this.txt_state.Location = new System.Drawing.Point(308, 42);
            this.txt_state.Name = "txt_state";
            this.txt_state.Size = new System.Drawing.Size(801, 134);
            this.txt_state.TabIndex = 0;
            this.txt_state.Text = "تعليمات النظام\r\nيسعدنا كثيرا لتكون احد المساهمين معنا في تطوير وتحسين النظام\r\n\r\n\r" +
    "\n";
            this.txt_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic_key
            // 
            this.pic_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_key.Image = global::ALIBA_COMPANY.Properties.Resources.aliba;
            this.pic_key.Location = new System.Drawing.Point(1115, 13);
            this.pic_key.Name = "pic_key";
            this.pic_key.Size = new System.Drawing.Size(279, 160);
            this.pic_key.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_key.TabIndex = 1;
            this.pic_key.TabStop = false;
            // 
            // txt_info
            // 
            this.txt_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_info.BackColor = System.Drawing.Color.White;
            this.txt_info.Font = new System.Drawing.Font("GE SS Two Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_info.Location = new System.Drawing.Point(3, 192);
            this.txt_info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_info.Name = "txt_info";
            this.txt_info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_info.Size = new System.Drawing.Size(1400, 568);
            this.txt_info.TabIndex = 10;
            this.txt_info.Text = resources.GetString("txt_info.Text");
            // 
            // FeedBack
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 765);
            this.Controls.Add(this.txt_info);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.Name = "FeedBack";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Help";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_key)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txt_state;
        private System.Windows.Forms.PictureBox pic_key;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.RichTextBox txt_info;
    }
}