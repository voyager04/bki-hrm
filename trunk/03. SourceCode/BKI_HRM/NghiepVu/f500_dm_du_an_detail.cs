using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;
//using BKI_HRM.US;
//using BKI_HRM.DS;
using IP.Core.IPData;
using IP.Core.IPUserService;
using BKI_HRM.DS.CDBNames;
using System.Collections;
using IP.Core.IPSystemAdmin;

namespace BKI_HRM.NghiepVu
{
    public partial class f500_dm_du_an_detail : Form
    {
        #region publicInterface

        public f500_dm_du_an_detail()
        {
            InitializeComponent();
            format_control();
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }

        public void display_for_update(DS.DS_DM_DU_AN i_ds)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            this.ShowDialog();
        }

        #endregion

        #region Member
        decimal m_dc_id_du_an;
        int m_dc_index_row;
        ITransferDataRow m_obj_trans;
        DataEntryFormMode m_e_form_mode;
        US.US_DM_DU_AN m_us_dm_du_an = new US.US_DM_DU_AN();
        US.US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US.US_DM_QUYET_DINH();
        DS.DS_V_DM_NHAN_SU_DU_AN m_ds_nsda = new DS.DS_V_DM_NHAN_SU_DU_AN();
        US.US_V_DM_NHAN_SU_DU_AN m_us_nsda = new US.US_V_DM_NHAN_SU_DU_AN();
        enum cm_dm_tu_dien
        {
            TRANG_THAI = 10,
            LOAI_DU_AN = 9,
            CO_CHE = 8,
            THANH_LAP_DU_AN = 679
        }
        private enum e_col_Number
        {
            MA_DU_AN = 1
                ,
            TEN_DU_AN = 2
                ,
            MA_NV = 4
                ,
            HO_DEM = 5
                ,
            TEN = 6
                ,
            MA_CV = 7
                ,
            TEN_CV = 8
                ,
            MA_DON_VI = 9
                ,
            TEN_DON_VI = 10
                ,
            VI_TRI = 11
                ,
            THOI_DIEM_TG = 12
                ,
            THOI_DIEM_KT = 13
                ,
            THOI_GIAN_TG = 14
                ,
            DANH_HIEU = 15
                ,
            MO_TA = 18
                ,
            TRANG_THAI_CV = 19
        }
        #endregion

        #region privateMethod
        private void format_control()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_grv_nhan_su);
            CGridUtils.AddSave_Excel_Handlers(m_grv_nhan_su);
            CGridUtils.AddSearch_Handlers(m_grv_nhan_su);
            m_grv_nhan_su.Tree.Column = (int)e_col_Number.HO_DEM;
            m_grv_nhan_su.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
        }

        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_NHAN_SU_DU_AN.VI_TRI, e_col_Number.VI_TRI);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_NV, e_col_Number.MA_NV);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_DU_AN, e_col_Number.MA_DU_AN);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.DANH_HIEU, e_col_Number.DANH_HIEU);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.MO_TA, e_col_Number.MO_TA);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_KT, e_col_Number.THOI_DIEM_KT);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN, e_col_Number.TEN);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_TG, e_col_Number.THOI_DIEM_TG);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.HO_DEM, e_col_Number.HO_DEM);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN_DU_AN, e_col_Number.TEN_DU_AN);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_GIAN_TG, e_col_Number.THOI_GIAN_TG);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_nsda.V_DM_NHAN_SU_DU_AN.NewRow());
            return v_obj_trans;
        }

        private void load_data_2_grv_nhan_su(decimal i_dc_id_da)
        {
            m_obj_trans = get_trans_object(m_grv_nhan_su);
            m_ds_nsda = new DS.DS_V_DM_NHAN_SU_DU_AN();
            m_us_nsda.FillDatasetByIdDuAn(m_ds_nsda, i_dc_id_da);
            m_grv_nhan_su.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds_nsda, m_grv_nhan_su, m_obj_trans);
            m_grv_nhan_su.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
             , 0
             , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình nhóm
             , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình Count
             , "{0}"
             );
            m_grv_nhan_su.Redraw = true;
        }

        public void form_2_us_object()
        {
            m_us_dm_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us_dm_quyet_dinh.dcID_LOAI_QD = (int)cm_dm_tu_dien.THANH_LAP_DU_AN;

            //----------------------------------------------------------------------------------
            m_us_dm_du_an.dcID_CO_CHE = CIPConvert.ToDecimal(m_cbo_co_che.SelectedValue);
            m_us_dm_du_an.dcID_LOAI_DU_AN = CIPConvert.ToDecimal(m_cbo_loai_du_an.SelectedValue);
            m_us_dm_du_an.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
            m_us_dm_du_an.dcID_QUYET_DINH = m_us_dm_quyet_dinh.dcID;
            m_us_dm_du_an.strMA_DU_AN = m_txt_ma_du_an.Text;
            m_us_dm_du_an.strNOI_DUNG = m_txt_noi_dung.Text;
            m_us_dm_du_an.strTEN_DU_AN = m_txt_ten_du_an.Text;

            m_us_dm_du_an.datNGAY_BAT_DAU = m_dat_ngay_bd.Value;
            if (m_dat_ngay_kt.Checked)
            {
                m_us_dm_du_an.datNGAY_KET_THUC = m_dat_ngay_kt.Value;
            }
            else
            {
                m_us_dm_du_an.SetNGAY_KET_THUCNull();
            }
        }

        private bool check_data_is_ok()
        {
            if (!m_dat_ngay_bd.Checked)
            {
                MessageBox.Show("Phải có ngày bắt đầu dự án");
                return false;
            }
            if (m_dat_ngay_kt.Checked)
            {
                if (m_dat_ngay_bd.Value.Date > m_dat_ngay_kt.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu dự án phải trước ngày kết thúc dự án");
                    return false;
                }
            }
            if (m_txt_ma_du_an.Text == "")
            {
                MessageBox.Show("Phải có mã dự án");
                return false;
            }
            if (m_txt_ma_quyet_dinh.Text == "")
            {
                MessageBox.Show("Phải có mã quyết định");
                return false;
            }
            if (m_txt_ten_du_an.Text == "")
            {
                MessageBox.Show("Phải có tên dự án");
                return false;
            }
            return true;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
            {
                return;
            }
            form_2_us_object();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_us_dm_quyet_dinh.Insert();
                    DS.DS_DM_QUYET_DINH v_ds_dm_qd = new DS.DS_DM_QUYET_DINH();
                    m_us_dm_quyet_dinh.FillDataset_By_Ma_qd(v_ds_dm_qd, m_txt_ma_quyet_dinh.Text);
                    DataRow v_dr = v_ds_dm_qd.Tables[0].Rows[0];
                    m_us_dm_du_an.dcID_QUYET_DINH = (decimal)v_dr["ID"];
                    m_us_dm_du_an.Insert();
                    m_dc_id_du_an = m_us_dm_du_an.dcID;
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_us_dm_quyet_dinh.Update();
                    m_us_dm_du_an.Update();
                    break;
            }
            if (m_us_dm_du_an.datNGAY_KET_THUC != null)
            {
                DateTime v_dat = m_us_dm_du_an.datNGAY_KET_THUC;
                cap_nhat_ngay_ket_thuc_cho_thanh_vien(m_us_dm_du_an.dcID, v_dat);
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            //this.Close();
        }

        private void cap_nhat_ngay_ket_thuc_cho_thanh_vien(decimal i_dc_id, DateTime i_dat)
        {
            US.US_GD_CHI_TIET_DU_AN v_us = new US.US_GD_CHI_TIET_DU_AN();
            DS.DS_GD_CHI_TIET_DU_AN v_ds = new DS.DS_GD_CHI_TIET_DU_AN();
            v_us.FillDatasetByIDDuAn(v_ds, i_dc_id);
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                DataRow v_dr = v_ds.Tables[0].Rows[i];
                v_us = new US.US_GD_CHI_TIET_DU_AN(CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.ID]));
                v_us.datTHOI_DIEM_KT = i_dat;
                v_us.Update();
            }
        }

        #endregion

        #region eventHandle
        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            try
            {
                save_data();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                m_txt_ma_du_an.Text = "";
                m_txt_ma_quyet_dinh.Text = "";
                m_txt_noi_dung.Text = "";
                m_txt_ten_du_an.Text = "";
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {

        }

        private void f500_dm_du_an_detail_Load(object sender, EventArgs e)
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.CO_CHE, WinFormControls.eTAT_CA.YES, m_cbo_co_che);
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DU_AN, WinFormControls.eTAT_CA.NO, m_cbo_trang_thai);
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_DU_AN, WinFormControls.eTAT_CA.NO, m_cbo_loai_du_an);
        }

        private void m_grv_nhan_su_Click(object sender, EventArgs e)
        {
            m_dc_index_row = m_grv_nhan_su.Row;
        }

        private void m_grv_nhan_su_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
                    delete_nhan_su_du_an();
                    break;
                case Keys.F3:
                    //DataRow v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row].UserData;
                    string v_str_ma_du_an = m_txt_ma_du_an.Text; //v_dr["MA_DU_AN"].ToString();
                    F500_gd_chi_tiet_du_an_de v_fDE = new F500_gd_chi_tiet_du_an_de();
                    v_fDE.display_for_insert(v_str_ma_du_an);
                    load_data_2_grv_nhan_su(m_dc_id_du_an);
                    break;
                case Keys.F4:
                    v_fDE = new F500_gd_chi_tiet_du_an_de();
                    DataRow v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row].UserData;
                    decimal v_dc_id_chi_tiet_du_an = (decimal)v_dr["ID"];
                    v_fDE.display_for_update(v_dc_id_chi_tiet_du_an, null);
                    load_data_2_grv_nhan_su(m_dc_id_du_an);
                    break;
            }
        }

        private void delete_nhan_su_du_an()
        {
            try
            {
                DataRow v_dr;
                m_obj_trans = get_trans_object(m_grv_nhan_su);
                US.US_GD_CHI_TIET_DU_AN v_us = new US.US_GD_CHI_TIET_DU_AN();
                DS.DS_GD_CHI_TIET_DU_AN v_ds = new DS.DS_GD_CHI_TIET_DU_AN();
                v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row].UserData;
                m_obj_trans.GridRow2DataRow(m_dc_index_row, v_dr);
                decimal v_dc_id_ns = (decimal)v_dr["ID_NHAN_SU"];
                v_us.FillDatasetByIDNS(v_ds, v_dc_id_ns);
                v_dr = v_ds.Tables[0].Rows[0];
                v_us.DataRow2Me(v_dr);
                v_us.Delete();
                m_grv_nhan_su.Rows.Remove(m_dc_index_row);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}
