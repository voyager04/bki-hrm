using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using BKI_HRM.US;
using IP.Core.WinFormControls;
using System.Threading;
public partial class Quantri_F800_Users : System.Web.UI.Page
{
    #region Members
    US_HT_NGUOI_SU_DUNG m_us_user = new US_HT_NGUOI_SU_DUNG();
    DS_HT_NGUOI_SU_DUNG m_ds_user = new DS_HT_NGUOI_SU_DUNG();
    #endregion

    #region Data Structures
    public class LOAI_FORM
    {
        public const string THEM = "THEM";
        public const string SUA = "SUA";
        public const string XOA = "XOA";
    }
    #endregion

    #region Private Methods
    private string get_form_mode(HiddenField ip_hdf_form_mode)
    {
        if (ip_hdf_form_mode.Value.Equals("0"))
        {
            return LOAI_FORM.THEM;
        }
        if (ip_hdf_form_mode.Value.Equals("1"))
        {
            return LOAI_FORM.SUA;
        }
        if (ip_hdf_form_mode.Value.Equals("2"))
        {
            return LOAI_FORM.XOA;
        }
        return LOAI_FORM.THEM;
    }
    private void set_form_mode(string ip_loai_form)
    {
        if (ip_loai_form.Equals(LOAI_FORM.THEM))
        {
            m_hdf_form_mode.Value = "0";
        }
        if (ip_loai_form.Equals(LOAI_FORM.SUA))
        {
            m_hdf_form_mode.Value = "1";
        }
        if (ip_loai_form.Equals(LOAI_FORM.XOA))
        {
            m_hdf_form_mode.Value = "2";
        }
    }
    private void set_control_by_form_mode()
    {
        switch (get_form_mode(m_hdf_form_mode))
        {
            case LOAI_FORM.THEM:
                m_cmd_cap_nhat.Visible = false;
                m_cmd_tao_moi.Visible = true;
                m_txt_ten_dang_nhap.ReadOnly = false;
                break;
            case LOAI_FORM.SUA:
                m_cmd_cap_nhat.Visible = true;
                m_cmd_tao_moi.Visible = false;
                m_txt_ten_dang_nhap.ReadOnly = false;
                break;
            default:
                break;
        }
    }
    private void load_data_2_grid()
    {
        try
        {
            m_us_user.FillDataset(m_ds_user, " WHERE ID_USER_GROUP =" + CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue) + " order by ten_truy_cap");
            m_grv_dm_tu_dien.DataSource = m_ds_user.HT_NGUOI_SU_DUNG;
            //if (m_cbo_user_group.SelectedValue != "6")
            //{
            //    m_lbl_email_group.Visible = false;
            //    m_txt_email_group.Visible = false;
            //}
            //else
            //{
            //    m_lbl_email_group.Visible = true;
            //    m_txt_email_group.Visible = true;
            //    m_txt_email_group.Text = "";

            //    for (int i = 0; i < m_ds_user.HT_NGUOI_SU_DUNG.Count - 1; i++)
            //    {
            //        m_txt_email_group.Text += m_ds_user.HT_NGUOI_SU_DUNG.Rows[i][1].ToString() + ", ";
            //    }

            //    m_txt_email_group.Text += m_ds_user.HT_NGUOI_SU_DUNG.Rows[m_ds_user.HT_NGUOI_SU_DUNG.Count - 1][1].ToString();
            //}

            m_grv_dm_tu_dien.DataBind();
            if (!m_hdf_id_nguoi_su_dung.Value.Equals(""))
            {
                m_grv_dm_tu_dien.SelectedIndex = -1;
                for (int i = 0; i < m_grv_dm_tu_dien.Rows.Count; i++)
                    if (CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_nguoi_su_dung.Value)) m_grv_dm_tu_dien.SelectedIndex = i;
            }

        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_cbo_user_group()
    {
        try
        {
            decimal v_dc_id_phan_quyen = CIPConvert.ToDecimal(Session[SESSION.NHOM_PHAN_QUYEN]);
            US_HT_USER_GROUP v_us_user_group = new US_HT_USER_GROUP();
            DS_HT_USER_GROUP v_ds_user_group = new DS_HT_USER_GROUP();
            if (v_dc_id_phan_quyen == ID_USER_GROUP.ADMIN)
            {
                v_us_user_group.FillDataset(v_ds_user_group);
            }
            else
            {
                v_us_user_group.FillDataset(v_ds_user_group, "where id <> " + ID_USER_GROUP.ADMIN + " and id <> " + ID_USER_GROUP.NHAN_DAN);
            }
            m_cbo_user_group.DataSource = v_ds_user_group.HT_USER_GROUP;
            m_cbo_user_group.DataTextField = HT_USER_GROUP.USER_GROUP_NAME;
            m_cbo_user_group.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_user_group.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_cbo_user_group_grv()
    {
        try
        {
            decimal v_dc_id_phan_quyen = CIPConvert.ToDecimal(Session[SESSION.NHOM_PHAN_QUYEN]);
            US_HT_USER_GROUP v_us_user_group = new US_HT_USER_GROUP();
            DS_HT_USER_GROUP v_ds_user_group = new DS_HT_USER_GROUP();
            if (v_dc_id_phan_quyen == ID_USER_GROUP.ADMIN)
            {
                v_us_user_group.FillDataset(v_ds_user_group);
            }
            else
            {
                v_us_user_group.FillDataset(v_ds_user_group, "where id <> " + ID_USER_GROUP.ADMIN + " and id <> " + ID_USER_GROUP.NHAN_DAN);
            }
            m_cbo_user_group_on_grid.DataSource = v_ds_user_group.HT_USER_GROUP;
            m_cbo_user_group_on_grid.DataTextField = HT_USER_GROUP.USER_GROUP_NAME;
            m_cbo_user_group_on_grid.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_user_group_on_grid.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void delete_dm_tu_dien()
    {
        try
        {
            m_lbl_mess.Text = "";
            m_us_user.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_nguoi_su_dung.Value));
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công!";
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi!";
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private void load_update_user(int i_int_row_index)
    {
        try
        {
            decimal v_dc_id_dm_tu_dien = CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i_int_row_index].Value);
            US_HT_NGUOI_SU_DUNG v_us_dm_tu_dien = new US_HT_NGUOI_SU_DUNG(v_dc_id_dm_tu_dien);
            m_hdf_id_user_group.Value = CIPConvert.ToStr(v_dc_id_dm_tu_dien);
            us_object_2_form(v_us_dm_tu_dien);
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void clear_data()
    {
        try
        {
            m_grv_dm_tu_dien.SelectedIndex = -1;
            m_grv_dm_tu_dien.EditIndex = -1;
            m_txt_ten_dang_nhap.Text = "";
            //m_txt_mat_khau_go_lai.Text = "";
            //m_txt_mat_khau.Text = "";
            m_lbl_mess.Text = "";
            m_lbl_thong_bao.Text = "";
            m_txt_ho_va_ten.Text = "";
            m_hdf_form_mode.Value = "0";
            m_hdf_id_user_group.Value = "0";
            m_hdf_id_nguoi_su_dung.Value = "-1";
            m_chk_lock_yn.Checked = false;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private bool check_validate_is_ok()
    {
        if (this.m_cbo_user_group.SelectedItem == null)
        {
            //this.m_ctv_ma_tu_dien.IsValid = false;
            return false;
        }

        if (!m_txt_ten_dang_nhap.Text.EndsWith("@topica.edu.vn") && !Context.User.Identity.Name.Equals("dmt.20102514@gmail.com"))
        {
            m_lbl_mess.Text = "Đây không phải email của Topica!";
            m_txt_ten_dang_nhap.Focus();
            return false;
        }
        //if ((!CValidateTextBox.IsValid(m_txt_mat_khau, DataType.StringType, allowNull.NO)) && (get_form_mode(m_hdf_form_mode)==LOAI_FORM.THEM))
        //{
        //    this.m_ctv_ten_tu_ngan.IsValid = false;
        //    return false;
        //}
        //if ((!CValidateTextBox.IsValid(m_txt_mat_khau_go_lai, DataType.StringType, allowNull.NO)) && (get_form_mode(m_hdf_form_mode)==LOAI_FORM.THEM))
        //    this.m_ctv_mk_go_lai.IsValid = false;
        //    return false;
        //}
        if ((!check_ten_dang_nhap_is_ok()) && (get_form_mode(m_hdf_form_mode) == LOAI_FORM.THEM))
        {
            m_lbl_mess.Text = "Tên đăng nhập đã tồn tại, vui lòng nhập Tên đăng nhập khác!";
            return false;
        }
        if ((this.m_hdf_id_user_group.Value == "") && (get_form_mode(m_hdf_form_mode) == LOAI_FORM.SUA))
        {
            m_lbl_mess.Text = "Bạn phải chọn Người dùng cần cập nhật!"; return false;
        }
        return true;
    }
    private bool check_ten_dang_nhap_is_ok()
    {

        US_HT_NGUOI_SU_DUNG v_us_ht = new US_HT_NGUOI_SU_DUNG();
        if (v_us_ht.CheckByTenTruyCap(m_txt_ten_dang_nhap.Text.Trim())) return false;
        return true;

    }
    private void insert_user()
    {
        try
        {
            m_lbl_mess.Text = "";
            m_grv_dm_tu_dien.EditIndex = -1;
            set_form_mode(LOAI_FORM.THEM);
            if (Page.IsValid)
            {
                if (!check_validate_is_ok()) return;

                form_2_us_object();

                m_us_user.Insert();
                clear_data();
                m_lbl_mess.Text = "Đã tạo mới tài khoản thành công.";

                load_data_2_grid();
            }
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình thêm mới bản ghi.";
            throw v_e;
        }
    }
    private void update_user()
    {
        try
        {
            m_lbl_mess.Text = "";
            m_grv_dm_tu_dien.EditIndex = -1;
            set_form_mode(LOAI_FORM.SUA);
            if (Page.IsValid)
            {

                if (!check_validate_is_ok()) return;
                form_2_us_object();

                m_us_user.dcID = CIPConvert.ToDecimal(this.m_hdf_id_user_group.Value);
                m_us_user.Update();
                clear_data();
                m_lbl_mess.Text = "Đã cập nhật tài khoản thành công!";

                m_grv_dm_tu_dien.EditIndex = -1;
                m_grv_dm_tu_dien.SelectedIndex = -1;
                load_data_2_grid();
                set_control_by_form_mode();
            }
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình cập nhật bản ghi!";
            throw v_e;
        }
    }
    private void us_object_2_form(US_HT_NGUOI_SU_DUNG i_us_user)
    {
        m_cbo_user_group.SelectedValue = CIPConvert.ToStr(i_us_user.dcID_USER_GROUP);
        m_txt_ho_va_ten.Text = i_us_user.strTEN;
        m_txt_ten_dang_nhap.Text = i_us_user.strTEN_TRUY_CAP;
        m_hdf_pw.Value = i_us_user.strMAT_KHAU;

        if (i_us_user.strTRANG_THAI == "1") { m_chk_lock_yn.Checked = true; }
        else m_chk_lock_yn.Checked = false;
    }
    private void form_2_us_object()
    {
        m_us_user.dcID_USER_GROUP = CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue);
        m_us_user.strTEN_TRUY_CAP = m_txt_ten_dang_nhap.Text.TrimEnd();
        m_us_user.strTEN = m_txt_ho_va_ten.Text.TrimEnd();
        m_us_user.strNGUOI_TAO = Session[SESSION.UserName].ToString();
        if (m_chk_lock_yn.Checked) m_us_user.strTRANG_THAI = "1";
        else m_us_user.strTRANG_THAI = "0";
        //if (m_txt_mat_khau.Text.Length > 0) m_us_user.strMAT_KHAU = m_txt_mat_khau.Text.TrimEnd();
        //else m_us_user.strMAT_KHAU = m_hdf_pw.Value;
        m_us_user.strMAT_KHAU = "123456";
    }
    private decimal get_id_from_ma(string ip_str_ma)
    {
        US_CM_DM_LOAI_TD v_us_cm_loai_tu_dien = new US_CM_DM_LOAI_TD(ip_str_ma);
        return v_us_cm_loai_tu_dien.dcID;
    }
    #endregion

    #region events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Form.DefaultButton = m_cmd_tim_kiem.UniqueID;
            if (!this.IsPostBack)
            {
                if (!Person.check_user_have_menu())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'>alert('Bạn không có quyền sử dụng chức năng này!');window.location.replace('/DatPhongHop/')</script>");
                }
                m_txt_ten_dang_nhap.ReadOnly = false;
                load_cbo_user_group();
                load_cbo_user_group_grv();
                load_data_2_grid();
                set_form_mode(LOAI_FORM.THEM);
                set_control_by_form_mode();
            }

        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }

    }

    protected void m_cbo_loai_tu_dien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (m_cbo_user_group.SelectedValue != "6")
            //{
            //    m_lbl_email_group.Visible = false;
            //    m_txt_email_group.Visible = false;
            //}
            //else
            //{
            //    m_lbl_email_group.Visible = true;
            //    m_txt_email_group.Visible = true;
            //}
            m_grv_dm_tu_dien.SelectedIndex = -1;
            m_cbo_user_group_on_grid.SelectedValue = m_cbo_user_group.SelectedValue;
            load_data_2_grid();
            if (m_hdf_id_nguoi_su_dung.Value.Equals("")) return;
            for (int i = 0; i < m_grv_dm_tu_dien.Rows.Count; i++)
                if (CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_nguoi_su_dung.Value)) m_grv_dm_tu_dien.SelectedIndex = i;
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_loai_tu_dien_grv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_grv_dm_tu_dien.SelectedIndex = -1;
            m_cbo_user_group.SelectedValue = m_cbo_user_group_on_grid.SelectedValue;
            load_data_2_grid();
            if (m_hdf_id_nguoi_su_dung.Value.Equals("")) return;
            for (int i = 0; i < m_grv_dm_tu_dien.Rows.Count; i++)
                if (CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_nguoi_su_dung.Value)) m_grv_dm_tu_dien.SelectedIndex = i;
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            insert_user();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            clear_data();
            set_form_mode(LOAI_FORM.THEM);
            set_control_by_form_mode();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {

            update_user();

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            m_us_user.FillDataset(m_ds_user, " WHERE ID_USER_GROUP =" + CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue)
                + "and (ten_truy_cap like N'%" + m_txt_tu_khoa.Text.Trim() + "%' or ten like N'%" + m_txt_tu_khoa.Text.Trim() + "%')");
            m_grv_dm_tu_dien.DataSource = m_ds_user.HT_NGUOI_SU_DUNG;
            //if (m_cbo_user_group.SelectedValue != "6")
            //{
            //    m_lbl_email_group.Visible = false;
            //    m_txt_email_group.Visible = false;
            //}
            //else
            //{
            //    m_lbl_email_group.Visible = true;
            //    m_txt_email_group.Visible = true;
            //    m_txt_email_group.Text = "";

            //    for (int i = 0; i < m_ds_user.HT_NGUOI_SU_DUNG.Count - 1; i++)
            //    {
            //        m_txt_email_group.Text += m_ds_user.HT_NGUOI_SU_DUNG.Rows[i][1].ToString() + ", ";
            //    }

            //    m_txt_email_group.Text += m_ds_user.HT_NGUOI_SU_DUNG.Rows[m_ds_user.HT_NGUOI_SU_DUNG.Count - 1][1].ToString();
            //}

            m_grv_dm_tu_dien.DataBind();
            if (!m_hdf_id_nguoi_su_dung.Value.Equals(""))
            {
                m_grv_dm_tu_dien.SelectedIndex = -1;
                for (int i = 0; i < m_grv_dm_tu_dien.Rows.Count; i++)
                    if (CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_nguoi_su_dung.Value)) m_grv_dm_tu_dien.SelectedIndex = i;
            }

        }

        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_tu_dien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            load_data_2_grid();
            m_grv_dm_tu_dien.SelectedIndex = -1;
            m_grv_dm_tu_dien.PageIndex = e.NewPageIndex;
            m_grv_dm_tu_dien.DataBind();
            if (m_hdf_id_nguoi_su_dung.Value.Equals("")) return;
            for (int i = 0; i < m_grv_dm_tu_dien.Rows.Count; i++)
                if (CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_nguoi_su_dung.Value)) m_grv_dm_tu_dien.SelectedIndex = i;

        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_tu_dien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            set_form_mode(LOAI_FORM.XOA);
            m_hdf_id_nguoi_su_dung.Value = CIPConvert.ToStr(m_grv_dm_tu_dien.DataKeys[e.RowIndex].Value);
            delete_dm_tu_dien();
            clear_data();
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_tu_dien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            set_form_mode(LOAI_FORM.SUA);
            m_hdf_id_nguoi_su_dung.Value = CIPConvert.ToStr(m_grv_dm_tu_dien.DataKeys[e.NewSelectedIndex].Value);
            load_update_user(e.NewSelectedIndex);
            set_control_by_form_mode();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion


}