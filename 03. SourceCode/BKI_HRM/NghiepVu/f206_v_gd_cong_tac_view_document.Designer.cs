namespace BKI_HRM
{
    partial class f206_v_gd_cong_tac_view_document
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
            this.m_wb_xem_file = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // m_wb_xem_file
            // 
            this.m_wb_xem_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wb_xem_file.Location = new System.Drawing.Point(0, 0);
            this.m_wb_xem_file.MinimumSize = new System.Drawing.Size(20, 20);
            this.m_wb_xem_file.Name = "m_wb_xem_file";
            this.m_wb_xem_file.Size = new System.Drawing.Size(284, 261);
            this.m_wb_xem_file.TabIndex = 0;
            // 
            // f206_v_gd_cong_tac_view_document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.m_wb_xem_file);
            this.Name = "f206_v_gd_cong_tac_view_document";
            this.Text = "F206 - Xem tài liệu";
            this.Load += new System.EventHandler(this.f206_v_gd_cong_tac_view_document_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser m_wb_xem_file;
    }
}