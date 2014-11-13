///************************************************
/// Generated by: DucVT
/// Date: 11/11/2014 05:37:52
/// Goal: Create Form for RPT_LUONG_DON_VI_THEO_KY
///************************************************


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM
{



    public class f304_RPT_LUONG_DON_VI_THEO_KY : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_delete;
        internal SIS.Controls.Button.SiSButton m_cmd_update;
        internal SIS.Controls.Button.SiSButton m_cmd_insert;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_view;
        private Panel panel1;
        private C1FlexGrid m_fg;
        private Label m_lbl_header;
        private Label label1;
        private ComboBox m_cbo_ma_ky;
        private System.ComponentModel.IContainer components;
        private bool is_form_loaded;

        public delegate void close_tab(bool ip_y_n);
        public close_tab close_tab_B;

        public f304_RPT_LUONG_DON_VI_THEO_KY()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            format_controls();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f304_RPT_LUONG_DON_VI_THEO_KY));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_insert = new SIS.Controls.Button.SiSButton();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_view = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cbo_ma_ky = new System.Windows.Forms.ComboBox();
            this.m_lbl_header = new System.Windows.Forms.Label();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_insert);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_view);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 455);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(970, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_cmd_insert
            // 
            this.m_cmd_insert.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_insert.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_insert.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_insert.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_insert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_insert.ImageIndex = 2;
            this.m_cmd_insert.ImageList = this.ImageList;
            this.m_cmd_insert.Location = new System.Drawing.Point(614, 4);
            this.m_cmd_insert.Name = "m_cmd_insert";
            this.m_cmd_insert.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_insert.TabIndex = 12;
            this.m_cmd_insert.Text = "&Thêm";
            // 
            // m_cmd_update
            // 
            this.m_cmd_update.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_update.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_update.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_update.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_update.ImageIndex = 3;
            this.m_cmd_update.ImageList = this.ImageList;
            this.m_cmd_update.Location = new System.Drawing.Point(702, 4);
            this.m_cmd_update.Name = "m_cmd_update";
            this.m_cmd_update.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_update.TabIndex = 13;
            this.m_cmd_update.Text = "&Sửa";
            // 
            // m_cmd_view
            // 
            this.m_cmd_view.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_view.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_view.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_view.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_view.ImageIndex = 18;
            this.m_cmd_view.ImageList = this.ImageList;
            this.m_cmd_view.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_view.Name = "m_cmd_view";
            this.m_cmd_view.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_view.TabIndex = 21;
            this.m_cmd_view.Text = "Xem";
            // 
            // m_cmd_delete
            // 
            this.m_cmd_delete.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_delete.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_delete.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_delete.ImageIndex = 4;
            this.m_cmd_delete.ImageList = this.ImageList;
            this.m_cmd_delete.Location = new System.Drawing.Point(790, 4);
            this.m_cmd_delete.Name = "m_cmd_delete";
            this.m_cmd_delete.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_delete.TabIndex = 14;
            this.m_cmd_delete.Text = "&Xoá";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.ImageList = this.ImageList;
            this.m_cmd_exit.Location = new System.Drawing.Point(878, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cbo_ma_ky);
            this.panel1.Controls.Add(this.m_lbl_header);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 118);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Kỳ";
            // 
            // m_cbo_ma_ky
            // 
            this.m_cbo_ma_ky.FormattingEnabled = true;
            this.m_cbo_ma_ky.Location = new System.Drawing.Point(383, 63);
            this.m_cbo_ma_ky.Name = "m_cbo_ma_ky";
            this.m_cbo_ma_ky.Size = new System.Drawing.Size(190, 21);
            this.m_cbo_ma_ky.TabIndex = 26;
            // 
            // m_lbl_header
            // 
            this.m_lbl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lbl_header.Location = new System.Drawing.Point(0, 0);
            this.m_lbl_header.Name = "m_lbl_header";
            this.m_lbl_header.Size = new System.Drawing.Size(970, 33);
            this.m_lbl_header.TabIndex = 25;
            this.m_lbl_header.Text = "BÁO CÁO LƯƠNG ĐƠN VỊ THEO KỲ";
            this.m_lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg.Location = new System.Drawing.Point(0, 118);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(970, 337);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 21;
            // 
            // f304_RPT_LUONG_DON_VI_THEO_KY
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(970, 491);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f304_RPT_LUONG_DON_VI_THEO_KY";
            this.Text = "F304 - Báo cáo lương đơn vị theo kỳ";
            this.Load += new System.EventHandler(this.f304_RPT_LUONG_DON_VI_THEO_KY_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }
        #endregion

        #region Data Structure
        private enum e_col_Number
        {
            LUONG_KY_HIEN_TAI = 4
                ,
            LUONG_KY_TRUOC = 3
                ,
            ID = 1
                ,
            TY_LE_TANG = 5
                , MA_DON_VI = 2

        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_RPT_LUONG_DON_VI_THEO_KY m_ds = new DS_RPT_LUONG_DON_VI_THEO_KY();
        US_RPT_LUONG_DON_VI_THEO_KY m_us = new US_RPT_LUONG_DON_VI_THEO_KY();
        #endregion

        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            set_define_events();
            this.KeyPreview = true;
        }
        private void set_initial_form_load()
        {
            m_obj_trans = get_trans_object(m_fg);

            HelperDucVT.CUtils.load_datasrc_ma_ky(m_cbo_ma_ky);

            load_data_2_grid();
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(RPT_LUONG_DON_VI_THEO_KY.LUONG_KY_HIEN_TAI, e_col_Number.LUONG_KY_HIEN_TAI);
            v_htb.Add(RPT_LUONG_DON_VI_THEO_KY.LUONG_KY_TRUOC, e_col_Number.LUONG_KY_TRUOC);
            v_htb.Add(RPT_LUONG_DON_VI_THEO_KY.ID, e_col_Number.ID);
            v_htb.Add(RPT_LUONG_DON_VI_THEO_KY.TY_LE_TANG, e_col_Number.TY_LE_TANG);
            v_htb.Add(RPT_LUONG_DON_VI_THEO_KY.MA_DON_VI, e_col_Number.MA_DON_VI);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.RPT_LUONG_DON_VI_THEO_KY.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid()
        {
            m_ds = new DS_RPT_LUONG_DON_VI_THEO_KY();
            m_us.FillDatasetByMaKy(m_ds, m_cbo_ma_ky.Text, CAppContext_201.getCurrentIDPhapnhan());
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);

            // ComboBox được load có thứ tự index y như DataTable
            update_captions(m_fg, (DataTable)m_cbo_ma_ky.DataSource, m_cbo_ma_ky.SelectedIndex);

            m_fg.Redraw = true;
        }
        private void grid2us_object(US_RPT_LUONG_DON_VI_THEO_KY i_us
            , int i_grid_row)
        {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }


        private void us_object2grid(US_RPT_LUONG_DON_VI_THEO_KY i_us
            , int i_grid_row)
        {
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }

        private void insert_rpt_luong_don_vi_theo_ky()
        {
            //	f304_RPT_LUONG_DON_VI_THEO_KY_DE v_fDE = new  f304_RPT_LUONG_DON_VI_THEO_KY_DE();								
            //	v_fDE.display();
            load_data_2_grid();
        }

        private void update_rpt_luong_don_vi_theo_ky()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            grid2us_object(m_us, m_fg.Row);
            //	f304_RPT_LUONG_DON_VI_THEO_KY_DE v_fDE = new f304_RPT_LUONG_DON_VI_THEO_KY_DE();
            //	v_fDE.display(m_us);
            load_data_2_grid();
        }

        private void delete_rpt_luong_don_vi_theo_ky()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            US_RPT_LUONG_DON_VI_THEO_KY v_us = new US_RPT_LUONG_DON_VI_THEO_KY();
            grid2us_object(v_us, m_fg.Row);
            try
            {
                v_us.BeginTransaction();
                v_us.Delete();
                v_us.CommitTransaction();
                m_fg.Rows.Remove(m_fg.Row);
            }
            catch (Exception v_e)
            {
                v_us.Rollback();
                CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
                    new CDBClientDBExceptionInterpret());
                v_objErrHandler.showErrorMessage();
            }
        }

        private void view_rpt_luong_don_vi_theo_ky()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            grid2us_object(m_us, m_fg.Row);
            //	f304_RPT_LUONG_DON_VI_THEO_KY_DE v_fDE = new f304_RPT_LUONG_DON_VI_THEO_KY_DE();			
            //	v_fDE.display(m_us);
        }
        private void set_define_events()
        {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_insert.Click += new EventHandler(m_cmd_insert_Click);
            m_cmd_update.Click += new EventHandler(m_cmd_update_Click);
            m_cmd_delete.Click += new EventHandler(m_cmd_delete_Click);
            m_cmd_view.Click += new EventHandler(m_cmd_view_Click);

            m_cbo_ma_ky.SelectedIndexChanged += new EventHandler(m_cbo_ma_ky_SelectedIndexChanged);
        }

        /// <summary>
        /// Đặt tên cột "Lương kỳ hiện tại" = Tên mã của kỳ hiện tại và "Lương kỳ trước" = Tên mã của kỳ trước của FlexGrid.
        /// </summary>
        /// <param name="ip_fg">FlexGrid cần đặt tên cột</param>
        /// <param name="ip_dt_ky">DataTable Kỳ - Yêu cầu Mã kỳ được xếp theo thứ tự tăng dần</param>
        /// <param name="ip_index">Index kỳ hiện tại</param>
        private void update_captions(C1FlexGrid ip_fg, DataTable ip_dt_ky, int ip_index)
        {
            ip_fg.Cols[(int)e_col_Number.LUONG_KY_HIEN_TAI].Caption = (String)ip_dt_ky.Rows[ip_index][DM_KY.MA_KY];

            if (ip_index > 0)
                ip_fg.Cols[(int)e_col_Number.LUONG_KY_TRUOC].Caption = (String)ip_dt_ky.Rows[ip_index - 1][DM_KY.MA_KY];
            else
                ip_fg.Cols[(int)e_col_Number.LUONG_KY_TRUOC].Caption = "Không có kỳ trước";
        }
        #endregion

        #region	EVENT HANLDERS
        private void f304_RPT_LUONG_DON_VI_THEO_KY_Load(object sender, System.EventArgs e)
        {
            try
            {
                set_initial_form_load();

                is_form_loaded = true;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cbo_ma_ky_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_form_loaded)
                load_data_2_grid();
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Close();
                close_tab_B(true);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_insert_Click(object sender, EventArgs e)
        {
            try
            {
                insert_rpt_luong_don_vi_theo_ky();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_update_Click(object sender, EventArgs e)
        {
            try
            {
                update_rpt_luong_don_vi_theo_ky();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_delete_Click(object sender, EventArgs e)
        {
            try
            {
                delete_rpt_luong_don_vi_theo_ky();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_view_Click(object sender, EventArgs e)
        {
            try
            {
                view_rpt_luong_don_vi_theo_ky();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}

