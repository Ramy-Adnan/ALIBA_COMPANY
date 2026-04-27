
namespace ALIBA_COMPANY.other
{
    partial class Check
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txt = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 14F);
            this.label1.Location = new System.Drawing.Point(47, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "من فضلك ادخل رمز الدخول واضغط Enter";
            // 
            // Txt
            // 
            this.Txt.EditValue = "00000000";
            this.Txt.Location = new System.Drawing.Point(145, 106);
            this.Txt.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Txt.Name = "Txt";
            this.Txt.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt.Properties.Appearance.Options.UseFont = true;
            this.Txt.Properties.Appearance.Options.UseTextOptions = true;
            this.Txt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Txt.Properties.PasswordChar = '*';
            this.Txt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt.Size = new System.Drawing.Size(220, 38);
            this.Txt.TabIndex = 9;
            this.Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // Check
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 186);
            this.Controls.Add(this.Txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Check";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.Txt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit Txt;
    }
}