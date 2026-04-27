using System.Drawing;
using System.Windows.Forms;

namespace ALIBA_COMPANY
{
    partial class FRM_Share
    {
        private Label lblHeader;
        private GroupBox grpType;
        private RadioButton rdoPublic;
        private RadioButton rdoPrivate;
        private PictureBox pic;
        private Label lblImage;
        private TextBox txtTitle;
        private Label lblTitle;
        private RichTextBox txtDesc;
        private Label lblDesc;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private Label lblFrom;
        private Label lblTo;
        private Button btnSave;
        private ComboBox Combo_User;
        private Label lblUser;

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.rdoPublic = new System.Windows.Forms.RadioButton();
            this.rdoPrivate = new System.Windows.Forms.RadioButton();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.Combo_User = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(748, 60);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "📢 نشر إعلان جديد";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.rdoPublic);
            this.grpType.Controls.Add(this.rdoPrivate);
            this.grpType.Location = new System.Drawing.Point(30, 70);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(680, 88);
            this.grpType.TabIndex = 1;
            this.grpType.TabStop = false;
            this.grpType.Text = "نوع الإعلان";
            // 
            // rdoPublic
            // 
            this.rdoPublic.Checked = true;
            this.rdoPublic.Location = new System.Drawing.Point(400, 30);
            this.rdoPublic.Name = "rdoPublic";
            this.rdoPublic.Size = new System.Drawing.Size(104, 40);
            this.rdoPublic.TabIndex = 0;
            this.rdoPublic.TabStop = true;
            this.rdoPublic.Text = "عام";
            this.rdoPublic.CheckedChanged += new System.EventHandler(this.rdoPublic_CheckedChanged);
            // 
            // rdoPrivate
            // 
            this.rdoPrivate.Location = new System.Drawing.Point(250, 30);
            this.rdoPrivate.Name = "rdoPrivate";
            this.rdoPrivate.Size = new System.Drawing.Size(104, 34);
            this.rdoPrivate.TabIndex = 1;
            this.rdoPrivate.Text = "خاص";
            this.rdoPrivate.CheckedChanged += new System.EventHandler(this.rdoPrivate_CheckedChanged);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.LightGray;
            this.pic.Location = new System.Drawing.Point(270, 164);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(200, 150);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 2;
            this.pic.TabStop = false;
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // lblImage
            // 
            this.lblImage.Location = new System.Drawing.Point(164, 218);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(100, 35);
            this.lblImage.TabIndex = 3;
            this.lblImage.Text = "صورة الإعلان";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 320);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(450, 45);
            this.txtTitle.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(44, 323);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 40);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "عنوان الإعلان";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(150, 371);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(450, 120);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.Text = "";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(44, 371);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 40);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "نص الإعلان";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(150, 497);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 45);
            this.dtFrom.TabIndex = 8;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(44, 497);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(100, 45);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "من";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(400, 502);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 45);
            this.dtTo.TabIndex = 10;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(350, 500);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(44, 45);
            this.lblTo.TabIndex = 11;
            this.lblTo.Text = "إلى";
            // 
            // Combo_User
            // 
            this.Combo_User.Location = new System.Drawing.Point(150, 550);
            this.Combo_User.Name = "Combo_User";
            this.Combo_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Combo_User.Size = new System.Drawing.Size(300, 45);
            this.Combo_User.TabIndex = 12;
            this.Combo_User.SelectedIndexChanged += new System.EventHandler(this.Combo_User_SelectedIndexChanged);
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(44, 550);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 45);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "الموزع";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 50);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "💾 حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRM_Share
            // 
            this.ClientSize = new System.Drawing.Size(748, 660);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.Combo_User);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnSave);
            this.Name = "FRM_Share";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نشر إعلان";
            this.Load += new System.EventHandler(this.FRM_Share_Load);
            this.grpType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}