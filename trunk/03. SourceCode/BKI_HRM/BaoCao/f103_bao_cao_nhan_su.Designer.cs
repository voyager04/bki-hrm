namespace BKI_HRM.BaoCao {
    partial class f103_bao_cao_nhan_su {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f103_bao_cao_nhan_su));
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cbo_gioi_tinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lbl_so_nhan_vien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Location = new System.Drawing.Point(0, 101);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1282, 417);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 21;
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 520);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1226, 36);
            this.m_pnl_out_place_dm.TabIndex = 22;
            // 
            // m_cmd_xuat_excel
            // 
            this.m_cmd_xuat_excel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_xuat_excel.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_xuat_excel.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_xuat_excel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_xuat_excel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_xuat_excel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_xuat_excel.ForeColor = System.Drawing.Color.Maroon;
            this.m_cmd_xuat_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_xuat_excel.ImageIndex = 19;
            this.m_cmd_xuat_excel.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_xuat_excel.Name = "m_cmd_xuat_excel";
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(113, 28);
            this.m_cmd_xuat_excel.TabIndex = 38;
            this.m_cmd_xuat_excel.Text = "Xuất Excel";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.Location = new System.Drawing.Point(1134, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lbl_so_nhan_vien);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_cbo_gioi_tinh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cmd_search);
            this.panel1.Controls.Add(this.m_txt_tim_kiem);
            this.panel1.Controls.Add(this.m_lbl_tim_kiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 95);
            this.panel1.TabIndex = 23;
            // 
            // m_cbo_gioi_tinh
            // 
            this.m_cbo_gioi_tinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbo_gioi_tinh.FormattingEnabled = true;
            this.m_cbo_gioi_tinh.Items.AddRange(new object[] {
            "Tất cả",
            "Nam",
            "Nữ"});
            this.m_cbo_gioi_tinh.Location = new System.Drawing.Point(333, 9);
            this.m_cbo_gioi_tinh.Name = "m_cbo_gioi_tinh";
            this.m_cbo_gioi_tinh.Size = new System.Drawing.Size(69, 22);
            this.m_cbo_gioi_tinh.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Giới tính";
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.Location = new System.Drawing.Point(874, 42);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 2;
            this.m_cmd_search.Text = "Tìm kiếm";
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(333, 46);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(513, 20);
            this.m_txt_tim_kiem.TabIndex = 1;
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(204, 49);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(87, 14);
            this.m_lbl_tim_kiem.TabIndex = 24;
            this.m_lbl_tim_kiem.Text = "Từ khoá tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số nhân viên:";
            // 
            // m_lbl_so_nhan_vien
            // 
            this.m_lbl_so_nhan_vien.AutoSize = true;
            this.m_lbl_so_nhan_vien.Location = new System.Drawing.Point(111, 77);
            this.m_lbl_so_nhan_vien.Name = "m_lbl_so_nhan_vien";
            this.m_lbl_so_nhan_vien.Size = new System.Drawing.Size(0, 14);
            this.m_lbl_so_nhan_vien.TabIndex = 28;
            // 
            // f103_bao_cao_nhan_su
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Controls.Add(this.m_fg);
            this.Name = "f103_bao_cao_nhan_su";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f103 Báo cáo nhân sự";
            this.Load += new System.EventHandler(this.f103_bao_cao_nhan_su_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        private System.Windows.Forms.Panel panel1;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private System.Windows.Forms.TextBox m_txt_tim_kiem;
        private System.Windows.Forms.Label m_lbl_tim_kiem;
        private System.Windows.Forms.ComboBox m_cbo_gioi_tinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lbl_so_nhan_vien;
        private System.Windows.Forms.Label label2;
    }
}