namespace BKI_HRM.BaoCao {
    partial class f104_bao_cao_nhan_su_theo_phong_ban {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f104_bao_cao_nhan_su_theo_phong_ban));
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lbl_so_luong_truong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dat_tu_ngay = new System.Windows.Forms.DateTimePicker();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Location = new System.Drawing.Point(-61, 139);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1020, 345);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lbl_so_luong_truong);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dat_tu_ngay);
            this.panel1.Controls.Add(this.m_cmd_search);
            this.panel1.Controls.Add(this.m_txt_tim_kiem);
            this.panel1.Controls.Add(this.m_lbl_tim_kiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 102);
            this.panel1.TabIndex = 22;
            // 
            // m_lbl_so_luong_truong
            // 
            this.m_lbl_so_luong_truong.AutoSize = true;
            this.m_lbl_so_luong_truong.Location = new System.Drawing.Point(142, 88);
            this.m_lbl_so_luong_truong.Name = "m_lbl_so_luong_truong";
            this.m_lbl_so_luong_truong.Size = new System.Drawing.Size(35, 14);
            this.m_lbl_so_luong_truong.TabIndex = 28;
            this.m_lbl_so_luong_truong.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số lượng phòng ban:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "Từ ngày";
            // 
            // m_dat_tu_ngay
            // 
            this.m_dat_tu_ngay.Checked = false;
            this.m_dat_tu_ngay.CustomFormat = "dd/MM/yyyy";
            this.m_dat_tu_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dat_tu_ngay.Location = new System.Drawing.Point(318, 48);
            this.m_dat_tu_ngay.Name = "m_dat_tu_ngay";
            this.m_dat_tu_ngay.ShowCheckBox = true;
            this.m_dat_tu_ngay.Size = new System.Drawing.Size(200, 20);
            this.m_dat_tu_ngay.TabIndex = 3;
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.Location = new System.Drawing.Point(739, 17);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 2;
            this.m_cmd_search.Text = "Tìm kiếm";
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(242, 22);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(445, 20);
            this.m_txt_tim_kiem.TabIndex = 1;
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(183, 25);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(48, 14);
            this.m_lbl_tim_kiem.TabIndex = 24;
            this.m_lbl_tim_kiem.Text = "Tìm kiếm";
            // 
            // f104_bao_cao_nhan_su_theo_phong_ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_fg);
            this.Name = "f104_bao_cao_nhan_su_theo_phong_ban";
            this.Text = "f104 - Báo cáo nhân sự theo phòng ban";
            this.Load += new System.EventHandler(this.f104_bao_cao_nhan_su_theo_phong_ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lbl_so_luong_truong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker m_dat_tu_ngay;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private System.Windows.Forms.TextBox m_txt_tim_kiem;
        private System.Windows.Forms.Label m_lbl_tim_kiem;
    }
}