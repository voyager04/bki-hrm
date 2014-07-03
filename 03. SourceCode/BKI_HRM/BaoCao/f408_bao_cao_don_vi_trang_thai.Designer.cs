namespace BKI_HRM
{
    partial class f408_bao_cao_don_vi_trang_thai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f408_bao_cao_don_vi_trang_thai));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_dat_thoidiem = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_lbl_phim_tat = new System.Windows.Forms.Label();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "");
            this.ImageList.Images.SetKeyName(14, "");
            this.ImageList.Images.SetKeyName(15, "");
            this.ImageList.Images.SetKeyName(16, "");
            this.ImageList.Images.SetKeyName(17, "");
            this.ImageList.Images.SetKeyName(18, "");
            this.ImageList.Images.SetKeyName(19, "");
            this.ImageList.Images.SetKeyName(20, "");
            this.ImageList.Images.SetKeyName(21, "");
            // 
            // m_dat_thoidiem
            // 
            this.m_dat_thoidiem.CustomFormat = "dd/MM/yyyy";
            this.m_dat_thoidiem.Enabled = false;
            this.m_dat_thoidiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_thoidiem.Location = new System.Drawing.Point(297, 4);
            this.m_dat_thoidiem.Name = "m_dat_thoidiem";
            this.m_dat_thoidiem.Size = new System.Drawing.Size(200, 20);
            this.m_dat_thoidiem.TabIndex = 39;
            this.m_dat_thoidiem.ValueChanged += new System.EventHandler(this.m_dat_thoidiem_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Thời điểm:";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.ImageList = this.ImageList;
            this.m_cmd_exit.Location = new System.Drawing.Point(769, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 7;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            this.m_cmd_exit.Click += new System.EventHandler(this.m_cmd_exit_Click);
            // 
            // m_cmd_xuat_excel
            // 
            this.m_cmd_xuat_excel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_xuat_excel.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_xuat_excel.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_xuat_excel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_xuat_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.m_cmd_xuat_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_xuat_excel.ImageIndex = 19;
            this.m_cmd_xuat_excel.ImageList = this.ImageList;
            this.m_cmd_xuat_excel.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_xuat_excel.Name = "m_cmd_xuat_excel";
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(93, 28);
            this.m_cmd_xuat_excel.TabIndex = 6;
            this.m_cmd_xuat_excel.Text = "Xuất Excel";
            this.m_cmd_xuat_excel.Click += new System.EventHandler(this.m_cmd_xuat_excel_Click);
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_lbl_phim_tat);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 376);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(861, 36);
            this.m_pnl_out_place_dm.TabIndex = 41;
            // 
            // m_lbl_phim_tat
            // 
            this.m_lbl_phim_tat.AutoSize = true;
            this.m_lbl_phim_tat.Location = new System.Drawing.Point(154, 12);
            this.m_lbl_phim_tat.Name = "m_lbl_phim_tat";
            this.m_lbl_phim_tat.Size = new System.Drawing.Size(206, 13);
            this.m_lbl_phim_tat.TabIndex = 1001;
            this.m_lbl_phim_tat.Text = "Phím tắt: F6_Mở rộng-Thu gọn danh sách";
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = "1,1,0,0,0,85,Columns:0{Width:13;}\t";
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_fg.Location = new System.Drawing.Point(0, 41);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(861, 335);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 42;
            // 
            // f408_bao_cao_don_vi_trang_thai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmd_exit;
            this.ClientSize = new System.Drawing.Size(861, 412);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dat_thoidiem);
            this.MaximumSize = new System.Drawing.Size(877, 451);
            this.MinimumSize = new System.Drawing.Size(877, 451);
            this.Name = "f408_bao_cao_don_vi_trang_thai";
            this.Text = "F408 - Báo cáo đơn vị trạng thái";
            this.Load += new System.EventHandler(this.f408_bao_cao_don_vi_trang_thai_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.m_pnl_out_place_dm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.DateTimePicker m_dat_thoidiem;
        private System.Windows.Forms.Label label1;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        private System.Windows.Forms.Label m_lbl_phim_tat;

    }
}