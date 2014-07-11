namespace BKI_HRM
{
    partial class f202_v_gd_qua_trinh_lam_viec_view
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
            this.m_wbr_xem_quyet_dinh = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // m_wbr_xem_quyet_dinh
            // 
            this.m_wbr_xem_quyet_dinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wbr_xem_quyet_dinh.Location = new System.Drawing.Point(0, 0);
            this.m_wbr_xem_quyet_dinh.MinimumSize = new System.Drawing.Size(20, 20);
            this.m_wbr_xem_quyet_dinh.Name = "m_wbr_xem_quyet_dinh";
            this.m_wbr_xem_quyet_dinh.Size = new System.Drawing.Size(284, 261);
            this.m_wbr_xem_quyet_dinh.TabIndex = 1;
            // 
            // f202_v_gd_qua_trinh_lam_viec_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.m_wbr_xem_quyet_dinh);
            this.Name = "f202_v_gd_qua_trinh_lam_viec_view";
            this.Text = "f202_v_gd_qua_trinh_lam_viec_view";
            this.Load += new System.EventHandler(this.f202_v_gd_qua_trinh_lam_viec_view_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser m_wbr_xem_quyet_dinh;
    }
}