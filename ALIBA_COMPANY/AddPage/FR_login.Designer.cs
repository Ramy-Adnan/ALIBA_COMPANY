
namespace ALIBA_COMPANY.AddPage
{
    partial class FR_login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_login = new Bunifu.Framework.UI.BunifuThinButton2();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblcopy = new DevExpress.XtraEditors.LabelControl();
            this.edt_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.edt_username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loading);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Btn_login);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.edt_password);
            this.panel1.Controls.Add(this.edt_username);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 655);
            this.panel1.TabIndex = 0;
            // 
            // loading
            // 
            this.loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loading.AnimationSpeed = 7.7F;
            this.loading.AppearanceCaption.Options.UseTextOptions = true;
            this.loading.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.loading.AppearanceDescription.Options.UseTextOptions = true;
            this.loading.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loading.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loading.BarAnimationElementThickness = 5;
            this.loading.BarAnimationMotionType = DevExpress.Utils.Animation.MotionType.WithAcceleration;
            this.loading.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.loading.Caption = "";
            this.loading.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.loading.Description = "";
            this.loading.FrameInterval = 2000;
            this.loading.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Rectangle;
            this.loading.Location = new System.Drawing.Point(208, 537);
            this.loading.Name = "loading";
            this.loading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loading.ShowCaption = false;
            this.loading.ShowDescription = false;
            this.loading.Size = new System.Drawing.Size(36, 35);
            this.loading.TabIndex = 14;
            this.loading.Text = "انتظر";
            this.loading.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::ALIBA_COMPANY.Properties.Resources.aliba;
            this.pictureBox1.Location = new System.Drawing.Point(63, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Btn_login
            // 
            this.Btn_login.ActiveBorderThickness = 1;
            this.Btn_login.ActiveCornerRadius = 20;
            this.Btn_login.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.Btn_login.ActiveForecolor = System.Drawing.Color.White;
            this.Btn_login.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.Btn_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_login.BackColor = System.Drawing.Color.White;
            this.Btn_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_login.BackgroundImage")));
            this.Btn_login.ButtonText = "تسجيل الدخول";
            this.Btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_login.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_login.ForeColor = System.Drawing.Color.SeaGreen;
            this.Btn_login.IdleBorderThickness = 1;
            this.Btn_login.IdleCornerRadius = 20;
            this.Btn_login.IdleFillColor = System.Drawing.Color.White;
            this.Btn_login.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.Btn_login.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(68)))));
            this.Btn_login.Location = new System.Drawing.Point(94, 460);
            this.Btn_login.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(270, 68);
            this.Btn_login.TabIndex = 11;
            this.Btn_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Cairo", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(68)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(465, 73);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "شركة اللبة";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.lblcopy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 609);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 46);
            this.panel2.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.labelControl2.AppearanceHovered.Options.UseBackColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl2.ImageOptions.SvgImage")));
            this.labelControl2.Location = new System.Drawing.Point(0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 40);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Click += new System.EventHandler(this.pictureEdit_Click);
            // 
            // lblcopy
            // 
            this.lblcopy.Appearance.Font = new System.Drawing.Font("Cairo SemiBold", 9F);
            this.lblcopy.Appearance.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblcopy.Appearance.Options.UseFont = true;
            this.lblcopy.Appearance.Options.UseForeColor = true;
            this.lblcopy.Appearance.Options.UseTextOptions = true;
            this.lblcopy.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblcopy.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblcopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblcopy.Location = new System.Drawing.Point(379, 0);
            this.lblcopy.Name = "lblcopy";
            this.lblcopy.Size = new System.Drawing.Size(86, 29);
            this.lblcopy.TabIndex = 3;
            this.lblcopy.Text = "labelControl1";
            // 
            // edt_password
            // 
            this.edt_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_password.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.edt_password.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.edt_password.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.edt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.edt_password.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.edt_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.edt_password.HintForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.edt_password.HintText = "كلمة السر";
            this.edt_password.isPassword = true;
            this.edt_password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.edt_password.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(181)))), ((int)(((byte)(73)))));
            this.edt_password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.edt_password.LineThickness = 8;
            this.edt_password.Location = new System.Drawing.Point(63, 371);
            this.edt_password.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edt_password.MaxLength = 32767;
            this.edt_password.Name = "edt_password";
            this.edt_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_password.Size = new System.Drawing.Size(332, 66);
            this.edt_password.TabIndex = 10;
            this.edt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edt_password_KeyDown);
            this.edt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edt_password_KeyPress);
            // 
            // edt_username
            // 
            this.edt_username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_username.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.edt_username.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.edt_username.AutoSize = true;
            this.edt_username.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.edt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.edt_username.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.edt_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.edt_username.HintForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.edt_username.HintText = "اسم المستخدم";
            this.edt_username.isPassword = false;
            this.edt_username.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.edt_username.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(181)))), ((int)(((byte)(73)))));
            this.edt_username.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.edt_username.LineThickness = 8;
            this.edt_username.Location = new System.Drawing.Point(63, 281);
            this.edt_username.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.edt_username.MaxLength = 32767;
            this.edt_username.Name = "edt_username";
            this.edt_username.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_username.Size = new System.Drawing.Size(332, 78);
            this.edt_username.TabIndex = 8;
            this.edt_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edt_username_KeyDown);
            this.edt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edt_username_KeyPress);
            // 
            // FR_login
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 655);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::ALIBA_COMPANY.Properties.Resources.Icon5;
            this.Location = new System.Drawing.Point(484, 888);
            this.MaximizeBox = false;
            this.Name = "FR_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginFrom_FormClosed);
            this.Load += new System.EventHandler(this.FR_login_Load);
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.FR_login_DpiChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraWaitForm.ProgressPanel loading;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 Btn_login;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblcopy;
        private Bunifu.Framework.UI.BunifuMaterialTextbox edt_password;
        private Bunifu.Framework.UI.BunifuMaterialTextbox edt_username;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}