///************************************************
/// Generated by: AnhHT
/// Date: 05/03/2014 05:28:41
/// Goal: Create Form for V_GD_HOP_DONG_LAO_DONG
///************************************************


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
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



    public class f702_bao_cao_hdld : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        internal SIS.Controls.Button.SiSButton m_cmd_tim_kiem;
        private TextBox m_txt_tim_kiem;
        private Label label1;
        private Label m_lbl_count_record;
        private Label m_lbl_nhom;
        private ComboBox m_cbo_nhom_theo_cot;
        private System.ComponentModel.IContainer components;

        public f702_bao_cao_hdld()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f702_bao_cao_hdld));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_cmd_tim_kiem = new SIS.Controls.Button.SiSButton();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lbl_count_record = new System.Windows.Forms.Label();
            this.m_lbl_nhom = new System.Windows.Forms.Label();
            this.m_cbo_nhom_theo_cot = new System.Windows.Forms.ComboBox();
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
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 575);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1354, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
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
            this.m_cmd_xuat_excel.ImageList = this.ImageList;
            this.m_cmd_xuat_excel.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_xuat_excel.Name = "m_cmd_xuat_excel";
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(113, 28);
            this.m_cmd_xuat_excel.TabIndex = 40;
            this.m_cmd_xuat_excel.Text = "Xuất Excel";
            this.m_cmd_xuat_excel.Click += new System.EventHandler(this.m_cmd_xuat_excel_Click);
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
            this.m_cmd_exit.Location = new System.Drawing.Point(1262, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Location = new System.Drawing.Point(0, 97);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1357, 472);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 20;
            // 
            // m_cmd_tim_kiem
            // 
            this.m_cmd_tim_kiem.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_tim_kiem.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_tim_kiem.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_tim_kiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_tim_kiem.ImageIndex = 5;
            this.m_cmd_tim_kiem.ImageList = this.ImageList;
            this.m_cmd_tim_kiem.Location = new System.Drawing.Point(1120, 24);
            this.m_cmd_tim_kiem.Name = "m_cmd_tim_kiem";
            this.m_cmd_tim_kiem.Size = new System.Drawing.Size(101, 28);
            this.m_cmd_tim_kiem.TabIndex = 32;
            this.m_cmd_tim_kiem.Text = "&Tìm kiếm";
            this.m_cmd_tim_kiem.Click += new System.EventHandler(this.m_cmd_tim_kiem_Click);
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.ForeColor = System.Drawing.Color.Gray;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(186, 29);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(928, 20);
            this.m_txt_tim_kiem.TabIndex = 31;
            this.m_txt_tim_kiem.Text = "Nhập Mã nhân viên, Họ đệm, Tên, Mã hợp đồng, Loại hợp đồng, Ngày tháng, Trạng thá" +
                "i";
            this.m_txt_tim_kiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_txt_tim_kiem_MouseClick);
            this.m_txt_tim_kiem.Leave += new System.EventHandler(this.m_txt_tim_kiem_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Từ khoá tìm kiếm";
            // 
            // m_lbl_count_record
            // 
            this.m_lbl_count_record.AutoSize = true;
            this.m_lbl_count_record.Location = new System.Drawing.Point(32, 68);
            this.m_lbl_count_record.Name = "m_lbl_count_record";
            this.m_lbl_count_record.Size = new System.Drawing.Size(0, 13);
            this.m_lbl_count_record.TabIndex = 33;
            // 
            // m_lbl_nhom
            // 
            this.m_lbl_nhom.AutoSize = true;
            this.m_lbl_nhom.Location = new System.Drawing.Point(279, 73);
            this.m_lbl_nhom.Name = "m_lbl_nhom";
            this.m_lbl_nhom.Size = new System.Drawing.Size(77, 13);
            this.m_lbl_nhom.TabIndex = 38;
            this.m_lbl_nhom.Text = "Nhóm theo cột";
            // 
            // m_cbo_nhom_theo_cot
            // 
            this.m_cbo_nhom_theo_cot.FormattingEnabled = true;
            this.m_cbo_nhom_theo_cot.Location = new System.Drawing.Point(383, 70);
            this.m_cbo_nhom_theo_cot.Name = "m_cbo_nhom_theo_cot";
            this.m_cbo_nhom_theo_cot.Size = new System.Drawing.Size(233, 21);
            this.m_cbo_nhom_theo_cot.TabIndex = 37;
            this.m_cbo_nhom_theo_cot.SelectedIndexChanged += new System.EventHandler(this.m_cbo_nhom_theo_cot_SelectedIndexChanged);
            // 
            // f702_bao_cao_hdld
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1354, 611);
            this.Controls.Add(this.m_lbl_nhom);
            this.Controls.Add(this.m_cbo_nhom_theo_cot);
            this.Controls.Add(this.m_lbl_count_record);
            this.Controls.Add(this.m_cmd_tim_kiem);
            this.Controls.Add(this.m_txt_tim_kiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Name = "f702_bao_cao_hdld";
            this.Text = "f702 Báo cáo Hợp Đồng Lao Động";
            this.Load += new System.EventHandler(this.f702_bao_cao_hdld_het_han_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }

        public void set_form_mode_for_report(int ip_i_form_mode)
        {
            if (ip_i_form_mode == 1)
            {
                m_i_form_mode = 1;
            }
            if (ip_i_form_mode == 2)
            {
                m_i_form_mode = 2;
            }
            if (ip_i_form_mode == 3)
            {
                m_i_form_mode = 3;
            }
        }
        #endregion

        #region Data Structure
        private enum e_col_Number
        {
            COLS1 = 1,
            MA_NV = 2,
            HO_DEM = 3,
            TEN = 4,
            MA_HOP_DONG = 5,
            LOAI_HOP_DONG = 6,
            NGAY_KY_HOP_DONG = 7,
            NGAY_CO_HIEU_LUC = 8,
            NGAY_HET_HAN = 9,
            TEN_PHAP_NHAN = 10,
            TRANG_THAI_HOP_DONG = 11,
            LINK = 12,
            NGUOI_KY = 13,
            CHUC_VU_NGUOI_KY = 14
        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_V_GD_HOP_DONG_LAO_DONG m_ds = new DS_V_GD_HOP_DONG_LAO_DONG();
        US_V_GD_HOP_DONG_LAO_DONG m_us = new US_V_GD_HOP_DONG_LAO_DONG();
        private int m_i_form_mode;
        private const string M_STR_SUGGESTION = "Nhập Mã nhân viên, Họ đệm, Tên, Mã hợp đồng, Loại hợp đồng, Ngày tháng, Trạng thái";
        #endregion

        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = (int)e_col_Number.HO_DEM;
            m_fg.Cols[(int)e_col_Number.MA_NV].Visible = false;
            m_fg.Cols[(int)e_col_Number.COLS1].Visible = false;
            m_fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            set_define_events();
            this.KeyPreview = true;
        }

        private void load_data_2_cbo_group()
        {

            DataTable v_dt = new DataTable();
            v_dt.Columns.Add("SO_COT");
            v_dt.Columns.Add("TEN_COT");


            v_dt.Rows.Add(-1, "-- Không nhóm --");
            v_dt.Rows.Add((int)e_col_Number.MA_NV, "Mã nhân viên");
            v_dt.Rows.Add((int)e_col_Number.LOAI_HOP_DONG, "Loại hợp đồng");
            v_dt.Rows.Add((int)e_col_Number.NGAY_KY_HOP_DONG, "Ngày ký hợp đồng");
            v_dt.Rows.Add((int)e_col_Number.NGAY_CO_HIEU_LUC, "Ngày có hiệu lực");
            v_dt.Rows.Add((int)e_col_Number.NGAY_HET_HAN, "Ngày hết hạn");
            v_dt.Rows.Add((int)e_col_Number.TEN_PHAP_NHAN, "Tên pháp nhân");
            v_dt.Rows.Add((int)e_col_Number.NGUOI_KY, "Người ký");
            v_dt.Rows.Add((int)e_col_Number.TRANG_THAI_HOP_DONG, "Trạng thái");
            v_dt.Rows.Add((int)e_col_Number.CHUC_VU_NGUOI_KY, "Chức vụ người ký");

            m_cbo_nhom_theo_cot.DisplayMember = "TEN_COT";
            m_cbo_nhom_theo_cot.ValueMember = "SO_COT";
            m_cbo_nhom_theo_cot.DataSource = v_dt;
        }

        private void set_initial_form_load()
        {
            m_obj_trans = get_trans_object(m_fg);
            load_data_2_cbo_group();
            load_data_2_grid();
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.COLS1, e_col_Number.COLS1);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.TRANG_THAI_HOP_DONG, e_col_Number.TRANG_THAI_HOP_DONG);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.CHUC_VU_NGUOI_KY, e_col_Number.CHUC_VU_NGUOI_KY);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.NGAY_HET_HAN, e_col_Number.NGAY_HET_HAN);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.NGUOI_KY, e_col_Number.NGUOI_KY);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.NGAY_KY_HOP_DONG, e_col_Number.NGAY_KY_HOP_DONG);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.LOAI_HOP_DONG, e_col_Number.LOAI_HOP_DONG);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.TEN, e_col_Number.TEN);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.MA_HOP_DONG, e_col_Number.MA_HOP_DONG);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.LINK, e_col_Number.LINK);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_GD_HOP_DONG_LAO_DONG.TEN_PHAP_NHAN, e_col_Number.TEN_PHAP_NHAN);
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_GD_HOP_DONG_LAO_DONG.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid()
        {
            var v_str_search = m_txt_tim_kiem.Text.Trim();
            if (v_str_search == M_STR_SUGGESTION)
                v_str_search = "";
            var v_str_month = Regex.Match(v_str_search, @"\d+").Value;
            if (!v_str_month.Equals(""))
                v_str_search = v_str_month;

            m_ds = new DS_V_GD_HOP_DONG_LAO_DONG();

            if (v_str_search == M_STR_SUGGESTION)
            {
                if (m_i_form_mode == 1)
                {
                    m_us.FIllDataset_By_Hop_Dong_Da_Het_Han(m_ds, "");
                    m_lbl_count_record.Text = string.Format("Có {0} Hợp Đồng Lao Động còn hiệu lực.", m_ds.Tables[0].Rows.Count);
                }
                if (m_i_form_mode == 2)
                {
                    m_us.FIllDataset_By_Hop_Dong_Sap_Het_Han(m_ds, "");
                    m_lbl_count_record.Text = string.Format("Có {0} Hợp Đồng Lao Động sắp hết hạn (dưới 30 ngày).", m_ds.Tables[0].Rows.Count);
                }
                if (m_i_form_mode == 3)
                {
                    m_us.FillDataSet_Search_HDLD_da_het_han_nhung_chua_ky(m_ds, "");
                    m_lbl_count_record.Text = string.Format("Có {0} Hợp Đồng Lao Động đã hết hạn nhưng chưa ký mới.", m_ds.Tables[0].Rows.Count);
                }
            }
            else
            {
                if (m_i_form_mode == 1)
                {
                    m_us.FIllDataset_By_Hop_Dong_Da_Het_Han(m_ds, v_str_search);
                    m_lbl_count_record.Text = string.Format("Có {0} Hợp Đồng Lao Động còn hiệu lực.", m_ds.Tables[0].Rows.Count);
                }
                if (m_i_form_mode == 2)
                {
                    m_us.FIllDataset_By_Hop_Dong_Sap_Het_Han(m_ds, v_str_search);
                    m_lbl_count_record.Text = string.Format("Có {0} Hợp Đồng Lao Động sắp hết hạn (dưới 30 ngày).", m_ds.Tables[0].Rows.Count);
                }
                if (m_i_form_mode == 3)
                {
                    m_us.FillDataSet_Search_HDLD_da_het_han_nhung_chua_ky(m_ds, v_str_search);
                    m_lbl_count_record.Text = string.Format("Có {0} Hợp Đồng Lao Động đã hết hạn nhưng chưa ký mới.", m_ds.Tables[0].Rows.Count);
                }
            }

            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            if (int.Parse(m_cbo_nhom_theo_cot.SelectedValue.ToString()) > -1)
            {
                for (int v_i_cur_row = m_fg.Rows.Fixed; v_i_cur_row < m_fg.Rows.Count; v_i_cur_row++)
                {
                    m_fg[v_i_cur_row, (int)e_col_Number.COLS1]
                        = m_fg[v_i_cur_row, int.Parse(m_cbo_nhom_theo_cot.SelectedValue.ToString())];
                }
                m_fg.Sort(SortFlags.Ascending, (int)e_col_Number.COLS1);


                m_fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
                 , 0
                 , (int)e_col_Number.COLS1 // chỗ này là tên trường mà mình nhóm
                 , (int)e_col_Number.MA_HOP_DONG // chỗ này là tên trường mà mình Count
                 , "{0}"
                 );
            }
            else
            {
                m_fg.Cols[(int)e_col_Number.MA_NV].Visible = true;
            }
            m_fg.Redraw = true;
            m_fg.Focus();
        }
        private void grid2us_object(US_V_GD_HOP_DONG_LAO_DONG i_us
            , int i_grid_row)
        {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }


        private void us_object2grid(US_V_GD_HOP_DONG_LAO_DONG i_us
            , int i_grid_row)
        {
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }


       


        private void insert_v_gd_hop_dong_lao_dong()
        {
            //	f702_bao_cao_hdld_het_han_DE v_fDE = new  f702_bao_cao_hdld_het_han_DE();								
            //	v_fDE.display();
            load_data_2_grid();
        }

        private void update_v_gd_hop_dong_lao_dong()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            grid2us_object(m_us, m_fg.Row);
            //	f702_bao_cao_hdld_het_han_DE v_fDE = new f702_bao_cao_hdld_het_han_DE();
            //	v_fDE.display(m_us);
            load_data_2_grid();
        }

        private void delete_v_gd_hop_dong_lao_dong()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            US_V_GD_HOP_DONG_LAO_DONG v_us = new US_V_GD_HOP_DONG_LAO_DONG();
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

        private void view_v_gd_hop_dong_lao_dong()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            grid2us_object(m_us, m_fg.Row);
            //	f702_bao_cao_hdld_het_han_DE v_fDE = new f702_bao_cao_hdld_het_han_DE();			
            //	v_fDE.display(m_us);
        }

        private void set_define_events()
        {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
        }

        private void xuat_excel()
        {
            CExcelReport v_obj_excel_rpt = new CExcelReport("f701_bao_cao_hop_dong_lao_dong.xlsx", 8, 1);
            v_obj_excel_rpt.AddFindAndReplaceItem("<ngay_thang>", string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg, 1, m_fg.Cols.Count - 1, true);
        }

        private void auto_suggest_text()
        {
            US_V_GD_HOP_DONG_LAO_DONG v_us_v_gd_hop_dong = new US_V_GD_HOP_DONG_LAO_DONG();
            DS_V_GD_HOP_DONG_LAO_DONG v_ds_v_gd_hop_dong = new DS_V_GD_HOP_DONG_LAO_DONG();
            v_us_v_gd_hop_dong.FillDataset(v_ds_v_gd_hop_dong);
            var v_acsc_search = new AutoCompleteStringCollection();
            foreach (DataRow dr in v_ds_v_gd_hop_dong.V_GD_HOP_DONG_LAO_DONG)
            {
                v_acsc_search.Add(dr[V_GD_HOP_DONG_LAO_DONG.HO_DEM].ToString() + " " + dr[V_GD_HOP_DONG_LAO_DONG.TEN].ToString());
            }
            m_txt_tim_kiem.AutoCompleteCustomSource = v_acsc_search;
        }

        #endregion

        private void f702_bao_cao_hdld_het_han_Load(object sender, System.EventArgs e)
        {
            try
            {
                m_txt_tim_kiem.ForeColor = Color.Gray;
                set_initial_form_load();
                m_txt_tim_kiem.Focus();
                auto_suggest_text();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            try
            {
                load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                m_txt_tim_kiem.Text = "";
                m_txt_tim_kiem.ForeColor = Color.Black;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (m_txt_tim_kiem.Text == "")
                {
                    m_txt_tim_kiem.Text = M_STR_SUGGESTION;
                    m_txt_tim_kiem.ForeColor = Color.Gray;
                }

            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {
            try
            {
                xuat_excel();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_nhom_theo_cot_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                load_data_2_grid();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

