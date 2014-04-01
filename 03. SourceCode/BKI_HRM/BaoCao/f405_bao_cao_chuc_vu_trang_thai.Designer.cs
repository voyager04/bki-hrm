namespace BKI_HRM
{
    partial class f405_bao_cao_chuc_vu_trang_thai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f405_bao_cao_chuc_vu_trang_thai));
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_dat_thoidiem = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.SuspendLayout();
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = "1,1,0,0,0,85,Columns:0{Width:13;}\t";
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_fg.Location = new System.Drawing.Point(0, 34);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(656, 264);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 33;
            // 
            // m_dat_thoidiem
            // 
            this.m_dat_thoidiem.CustomFormat = "dd/MM/yyyy";
            this.m_dat_thoidiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_thoidiem.Location = new System.Drawing.Point(297, 8);
            this.m_dat_thoidiem.Name = "m_dat_thoidiem";
            this.m_dat_thoidiem.Size = new System.Drawing.Size(200, 20);
            this.m_dat_thoidiem.TabIndex = 34;
            // 
            // f405_bao_cao_chuc_vu_trang_thai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 298);
            this.Controls.Add(this.m_dat_thoidiem);
            this.Controls.Add(this.m_fg);
            this.Name = "f405_bao_cao_chuc_vu_trang_thai";
            this.Text = "f405_bao_cao_chuc_vu_trang_thai";
            this.Load += new System.EventHandler(this.f405_bao_cao_chuc_vu_trang_thai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        private System.Windows.Forms.DateTimePicker m_dat_thoidiem;


    }
}