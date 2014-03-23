namespace BKI_HRM.HeThong
{
    partial class f996_ht_nhom_nguoi_su_dung_de
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
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_save = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_lbl_ten_nhom = new System.Windows.Forms.Label();
            this.m_txt_ten_nhom = new System.Windows.Forms.TextBox();
            this.m_txt_mo_ta = new System.Windows.Forms.TextBox();
            this.m_lbl_mo_ta = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lbl_mess = new System.Windows.Forms.Label();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_save);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 157);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(391, 36);
            this.m_pnl_out_place_dm.TabIndex = 2;
            // 
            // m_cmd_save
            // 
            this.m_cmd_save.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_save.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_save.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_save.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_save.ImageIndex = 10;
            this.m_cmd_save.Location = new System.Drawing.Point(211, 4);
            this.m_cmd_save.Name = "m_cmd_save";
            this.m_cmd_save.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_save.TabIndex = 0;
            this.m_cmd_save.Text = "&Lưu";
            this.m_cmd_save.Click += new System.EventHandler(this.m_cmd_save_Click);
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 11;
            this.m_cmd_exit.Location = new System.Drawing.Point(299, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 1;
            this.m_cmd_exit.Text = "Trở về (Esc)";
            this.m_cmd_exit.Click += new System.EventHandler(this.m_cmd_exit_Click);
            // 
            // m_lbl_ten_nhom
            // 
            this.m_lbl_ten_nhom.AutoSize = true;
            this.m_lbl_ten_nhom.Location = new System.Drawing.Point(27, 23);
            this.m_lbl_ten_nhom.Name = "m_lbl_ten_nhom";
            this.m_lbl_ten_nhom.Size = new System.Drawing.Size(55, 13);
            this.m_lbl_ten_nhom.TabIndex = 3;
            this.m_lbl_ten_nhom.Text = "Tên nhóm";
            // 
            // m_txt_ten_nhom
            // 
            this.m_txt_ten_nhom.Location = new System.Drawing.Point(112, 20);
            this.m_txt_ten_nhom.Name = "m_txt_ten_nhom";
            this.m_txt_ten_nhom.Size = new System.Drawing.Size(245, 20);
            this.m_txt_ten_nhom.TabIndex = 4;
            this.m_txt_ten_nhom.Click += new System.EventHandler(this.m_txt_ten_nhom_Click);
            // 
            // m_txt_mo_ta
            // 
            this.m_txt_mo_ta.Location = new System.Drawing.Point(112, 57);
            this.m_txt_mo_ta.Multiline = true;
            this.m_txt_mo_ta.Name = "m_txt_mo_ta";
            this.m_txt_mo_ta.Size = new System.Drawing.Size(245, 71);
            this.m_txt_mo_ta.TabIndex = 6;
            this.m_txt_mo_ta.Click += new System.EventHandler(this.m_txt_mo_ta_Click);
            // 
            // m_lbl_mo_ta
            // 
            this.m_lbl_mo_ta.AutoSize = true;
            this.m_lbl_mo_ta.Location = new System.Drawing.Point(27, 60);
            this.m_lbl_mo_ta.Name = "m_lbl_mo_ta";
            this.m_lbl_mo_ta.Size = new System.Drawing.Size(34, 13);
            this.m_lbl_mo_ta.TabIndex = 5;
            this.m_lbl_mo_ta.Text = "Mô tả";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(88, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "(*)";
            // 
            // m_lbl_mess
            // 
            this.m_lbl_mess.AutoSize = true;
            this.m_lbl_mess.ForeColor = System.Drawing.Color.Red;
            this.m_lbl_mess.Location = new System.Drawing.Point(27, 131);
            this.m_lbl_mess.Name = "m_lbl_mess";
            this.m_lbl_mess.Size = new System.Drawing.Size(0, 13);
            this.m_lbl_mess.TabIndex = 8;
            // 
            // f996_ht_nhom_nguoi_su_dung_de
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 193);
            this.Controls.Add(this.m_lbl_mess);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txt_mo_ta);
            this.Controls.Add(this.m_lbl_mo_ta);
            this.Controls.Add(this.m_txt_ten_nhom);
            this.Controls.Add(this.m_lbl_ten_nhom);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Name = "f996_ht_nhom_nguoi_su_dung_de";
            this.Text = "f996_ht_nhom_nguoi_su_dung_de";
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_save;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        private System.Windows.Forms.Label m_lbl_ten_nhom;
        private System.Windows.Forms.TextBox m_txt_ten_nhom;
        private System.Windows.Forms.TextBox m_txt_mo_ta;
        private System.Windows.Forms.Label m_lbl_mo_ta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label m_lbl_mess;
    }
}