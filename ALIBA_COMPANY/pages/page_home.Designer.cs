
namespace ALIBA_COMPANY.pages
{
    partial class page_home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(page_home));
            this.lblDate = new System.Windows.Forms.Panel();
            this.Chart_Show = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rgrg = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbldata = new DevExpress.XtraEditors.LabelControl();
            this.lblClock = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Show)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Controls.Add(this.Chart_Show);
            this.lblDate.Controls.Add(this.panel2);
            this.lblDate.Controls.Add(this.pictureBox3);
            this.lblDate.Controls.Add(this.pictureBox2);
            this.lblDate.Controls.Add(this.pictureBox1);
            this.lblDate.Controls.Add(this.labelControl1);
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(1296, 743);
            this.lblDate.TabIndex = 0;
            // 
            // Chart_Show
            // 
            this.Chart_Show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart_Show.BackColor = System.Drawing.Color.Transparent;
            this.Chart_Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Chart_Show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chart_Show.Image = global::ALIBA_COMPANY.Properties.Resources.FinancialCard;
            this.Chart_Show.Location = new System.Drawing.Point(995, 571);
            this.Chart_Show.Margin = new System.Windows.Forms.Padding(0);
            this.Chart_Show.Name = "Chart_Show";
            this.Chart_Show.Size = new System.Drawing.Size(301, 113);
            this.Chart_Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chart_Show.TabIndex = 5;
            this.Chart_Show.TabStop = false;
            this.Chart_Show.Click += new System.EventHandler(this.Chart_Show_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel2.Controls.Add(this.rgrg);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("GE SS Two Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panel2.Location = new System.Drawing.Point(0, 684);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 59);
            this.panel2.TabIndex = 0;
            // 
            // rgrg
            // 
            this.rgrg.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rgrg.Appearance.Font = new System.Drawing.Font("Ebrima", 17.2F, System.Drawing.FontStyle.Bold);
            this.rgrg.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.rgrg.Appearance.Options.UseFont = true;
            this.rgrg.Appearance.Options.UseForeColor = true;
            this.rgrg.Location = new System.Drawing.Point(501, 3);
            this.rgrg.Name = "rgrg";
            this.rgrg.Size = new System.Drawing.Size(316, 40);
            this.rgrg.TabIndex = 3;
            this.rgrg.Text = "Aliba Company System";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbldata);
            this.panel1.Controls.Add(this.lblClock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1137, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 59);
            this.panel1.TabIndex = 2;
            // 
            // lbldata
            // 
            this.lbldata.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbldata.Appearance.Font = new System.Drawing.Font("GE SS Two Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbldata.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lbldata.Appearance.Options.UseBackColor = true;
            this.lbldata.Appearance.Options.UseFont = true;
            this.lbldata.Appearance.Options.UseForeColor = true;
            this.lbldata.Appearance.Options.UseTextOptions = true;
            this.lbldata.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbldata.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbldata.Location = new System.Drawing.Point(0, 23);
            this.lbldata.Name = "lbldata";
            this.lbldata.Size = new System.Drawing.Size(159, 32);
            this.lbldata.TabIndex = 1;
            this.lbldata.Text = "labelControl1";
            // 
            // lblClock
            // 
            this.lblClock.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblClock.Appearance.Font = new System.Drawing.Font("GE SS Two Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblClock.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblClock.Appearance.Options.UseBackColor = true;
            this.lblClock.Appearance.Options.UseFont = true;
            this.lblClock.Appearance.Options.UseForeColor = true;
            this.lblClock.Appearance.Options.UseTextOptions = true;
            this.lblClock.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblClock.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClock.Location = new System.Drawing.Point(0, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(159, 23);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "labelControl1";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 571);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(301, 113);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::ALIBA_COMPANY.Properties.Resources.logo4;
            this.pictureBox2.Location = new System.Drawing.Point(665, 207);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(471, 324);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::ALIBA_COMPANY.Properties.Resources.aliba;
            this.pictureBox1.Location = new System.Drawing.Point(157, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("GE SS Two Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1296, 142);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "نظام شركة اللبة للتجارة العامة المحدودة";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // page_home
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDate);
            this.Name = "page_home";
            this.Size = new System.Drawing.Size(1296, 743);
            this.Load += new System.EventHandler(this.page_home_Load);
            this.lblDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Show)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lblDate;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblClock;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl lbldata;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraEditors.LabelControl rgrg;
        public System.Windows.Forms.PictureBox Chart_Show;
    }
}
