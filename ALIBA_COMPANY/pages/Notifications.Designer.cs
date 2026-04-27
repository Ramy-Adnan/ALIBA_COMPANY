
namespace ALIBA_COMPANY.pages
{
    partial class Notifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifications));
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colNoteDes = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colNoteDate = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colNoteUser = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_state = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Btn_clearall = new DevExpress.XtraEditors.SimpleButton();
            this.btn_showlog = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Combo_filter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colNoteDes
            // 
            this.colNoteDes.FieldName = "NoteDes";
            this.colNoteDes.MinWidth = 25;
            this.colNoteDes.Name = "colNoteDes";
            this.colNoteDes.Visible = true;
            this.colNoteDes.VisibleIndex = 0;
            this.colNoteDes.Width = 94;
            // 
            // colNoteDate
            // 
            this.colNoteDate.Caption = "التاريخ : ";
            this.colNoteDate.DisplayFormat.FormatString = "{c,0}";
            this.colNoteDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNoteDate.FieldName = "NoteDate";
            this.colNoteDate.MinWidth = 25;
            this.colNoteDate.Name = "colNoteDate";
            this.colNoteDate.Visible = true;
            this.colNoteDate.VisibleIndex = 2;
            this.colNoteDate.Width = 94;
            // 
            // colNoteUser
            // 
            this.colNoteUser.Caption = "المستخدم";
            this.colNoteUser.FieldName = "NoteUser";
            this.colNoteUser.MinWidth = 25;
            this.colNoteUser.Name = "colNoteUser";
            this.colNoteUser.Visible = true;
            this.colNoteUser.VisibleIndex = 1;
            this.colNoteUser.Width = 94;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_state);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 649);
            this.panel1.TabIndex = 1;
            // 
            // lb_state
            // 
            this.lb_state.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_state.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lb_state.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_state.ForeColor = System.Drawing.Color.Black;
            this.lb_state.Location = new System.Drawing.Point(67, 115);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(398, 389);
            this.lb_state.TabIndex = 2;
            this.lb_state.Text = resources.GetString("lb_state.Text");
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_state.Visible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.tileView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(528, 591);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1,
            this.gridView2,
            this.gridView1});
            // 
            // tileView1
            // 
            this.tileView1.Appearance.EmptySpace.BackColor = System.Drawing.SystemColors.Control;
            this.tileView1.Appearance.EmptySpace.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tileView1.Appearance.ItemNormal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tileView1.Appearance.ItemNormal.ForeColor = System.Drawing.Color.DimGray;
            this.tileView1.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseBorderColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseForeColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseTextOptions = true;
            this.tileView1.Appearance.ItemNormal.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNoteDes,
            this.colNoteDate,
            this.colNoteUser});
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.tileView1.OptionsTiles.IndentBetweenGroups = 0;
            this.tileView1.OptionsTiles.IndentBetweenItems = 0;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(188, 87);
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.RowCount = 0;
            tableColumnDefinition2.Length.Value = 218D;
            this.tileView1.TileColumns.Add(tableColumnDefinition2);
            tableRowDefinition3.AutoHeight = true;
            tableRowDefinition3.Length.Value = 28D;
            tableRowDefinition4.AutoHeight = true;
            tableRowDefinition4.Length.Value = 39D;
            this.tileView1.TileRows.Add(tableRowDefinition3);
            this.tileView1.TileRows.Add(tableRowDefinition4);
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement4.Appearance.Normal.Options.UseBorderColor = true;
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Column = this.colNoteDes;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.Text = "colNoteDes";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.Column = this.colNoteDate;
            tileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement5.RowIndex = 1;
            tileViewItemElement5.Text = "colNoteDate";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            tileViewItemElement6.Column = this.colNoteUser;
            tileViewItemElement6.RowIndex = 1;
            tileViewItemElement6.Text = "colNoteUser";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.TileTemplate.Add(tileViewItemElement6);
            this.tileView1.ItemDoubleClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tileView1_ItemDoubleClick);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.Btn_clearall);
            this.panel2.Controls.Add(this.Combo_filter);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_showlog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 591);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 58);
            this.panel2.TabIndex = 1;
            // 
            // Btn_clearall
            // 
            this.Btn_clearall.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_clearall.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_clearall.ImageOptions.SvgImage")));
            this.Btn_clearall.Location = new System.Drawing.Point(0, 0);
            this.Btn_clearall.Name = "Btn_clearall";
            this.Btn_clearall.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_clearall.Size = new System.Drawing.Size(42, 58);
            this.Btn_clearall.TabIndex = 4;
            this.Btn_clearall.ToolTip = "تنضيف كافة الاشعارات و ليس مسح";
            this.Btn_clearall.Click += new System.EventHandler(this.Btn_clearall_Click_1);
            // 
            // btn_showlog
            // 
            this.btn_showlog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_showlog.AutoSize = true;
            this.btn_showlog.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_showlog.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_showlog.Location = new System.Drawing.Point(39, 15);
            this.btn_showlog.Name = "btn_showlog";
            this.btn_showlog.Size = new System.Drawing.Size(166, 26);
            this.btn_showlog.TabIndex = 3;
            this.btn_showlog.TabStop = true;
            this.btn_showlog.Text = "كشف جميع الحركات";
            this.btn_showlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_showlog_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("LBC", 12F);
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.linkLabel1.Location = new System.Drawing.Point(220, 15);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(99, 26);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "حذف الفلتر";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Combo_filter
            // 
            this.Combo_filter.AllowDrop = true;
            this.Combo_filter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Combo_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_filter.Font = new System.Drawing.Font("LBC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_filter.FormattingEnabled = true;
            this.Combo_filter.Items.AddRange(new object[] {
            "اضافة",
            "تعديل",
            "حذف",
            "تقييد",
            "طباعة",
            "تصدير",
            "تقييد راجع",
            "حذف راجع"});
            this.Combo_filter.Location = new System.Drawing.Point(334, 9);
            this.Combo_filter.Name = "Combo_filter";
            this.Combo_filter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Combo_filter.Size = new System.Drawing.Size(137, 38);
            this.Combo_filter.TabIndex = 2;
            this.Combo_filter.SelectedIndexChanged += new System.EventHandler(this.Combo_filter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("LBC", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(475, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "فلترة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 39;
            this.bunifuElipse1.TargetControl = this.gridControl1;
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(528, 649);
            this.Load += new System.EventHandler(this.Notifications_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel btn_showlog;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox Combo_filter;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton Btn_clearall;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colNoteDes;
        private DevExpress.XtraGrid.Columns.TileViewColumn colNoteDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colNoteUser;
    }
}
