﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using System.Data;
using IP.Core.WinFormControls;

public partial class Quantri_F811_QuanLyChucNang : System.Web.UI.Page
{

    #region Public Interfaces
    public string mapping_yn(object ip_obj_str_yn)
    {
        if (CIPConvert.ToStr(ip_obj_str_yn).Equals("Y")) return "Có";
        return "Không";
    }

    public string mapping_chuc_nang_parrent_by_id(object ip_dc_chuc_nang_parrent_id)
    {

        return "";
    }

    public string get_TEN_CHUC_NANG_PARENT(object ip_chuc_nang_parent_id)
    {
        if (ip_chuc_nang_parent_id.ToString().Equals("") | ip_chuc_nang_parent_id.ToString().Equals("0")) return "Không có";
        else
        {
            DS_HT_CHUC_NANG v_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();
            US_HT_CHUC_NANG v_us_ht_chuc_nang = new US_HT_CHUC_NANG(CIPConvert.ToDecimal(ip_chuc_nang_parent_id));
            return v_us_ht_chuc_nang.strTEN_CHUC_NANG;
        }
    }

    public void report_count_rows(Label ip_lbl, int ip_i_row_cout, string ip_str_default_message)
    {
        string ip_str_sum_row = "";
        ip_str_sum_row += ip_str_default_message + " (Có ";
        ip_str_sum_row += ip_i_row_cout + " bản ghi)";
        ip_lbl.Text = ip_str_sum_row;
    }
    #endregion

    #region Members
    US_HT_CHUC_NANG m_us_ht_chuc_nang = new US_HT_CHUC_NANG();
    DS_HT_CHUC_NANG m_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();
    DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Private Methods

    private void set_control_by_form_mode()
    {
        switch (m_e_form_mode)
        {
            case DataEntryFormMode.InsertDataState:
                m_cmd_cap_nhat.Visible = false;
                m_cmd_tao_moi.Visible = true;
                //m_cbo_vi_tri.Enabled = true;
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_cap_nhat.Visible = true;
                m_cmd_tao_moi.Visible = false;
                //m_cbo_vi_tri.Enabled = false;
                break;
            case DataEntryFormMode.ViewDataState:
                break;
            default:
                break;
        }
    }
    private void load_data_to_grid_by_tu_khoa()
    {
        DS_HT_CHUC_NANG v_ds = new DS_HT_CHUC_NANG();
        US_HT_CHUC_NANG v_us = new US_HT_CHUC_NANG();
        v_us.FillDatasetByTuKhoa(m_txt_tim_kiem.Text.Trim(), v_ds);
        m_grv_dm_chuc_nang_he_thong.DataSource = v_ds.HT_CHUC_NANG;
        report_count_rows(m_lbl_title, v_ds.HT_CHUC_NANG.Count, "Danh sách chức năng");
        m_grv_dm_chuc_nang_he_thong.DataBind();
    }
    private void load_data_2_grid(decimal ip_dc_id_parent)
    {
        m_us_ht_chuc_nang.load_all_data_by_root_parent_id(ip_dc_id_parent, m_ds_ht_chuc_nang);
        m_grv_dm_chuc_nang_he_thong.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG;
        report_count_rows(m_lbl_title, m_ds_ht_chuc_nang.HT_CHUC_NANG.Count, "Danh sách chức năng");
        m_grv_dm_chuc_nang_he_thong.DataBind();
    }
    private void load_data_2_cbo_parent()
    {
        US_HT_CHUC_NANG v_us_ht_chuc_nang = new US_HT_CHUC_NANG();
        DS_HT_CHUC_NANG v_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();

        //v_us_ht_chuc_nang.FillDataset(v_ds_ht_chuc_nang, " WHERE CHUC_NANG_PARENT_ID IS NULL ORDER BY ID");
        v_us_ht_chuc_nang.FillDataset(v_ds_ht_chuc_nang, "  ORDER BY ID");

        m_cbo_chuc_nang_cha.Items.Add(new ListItem("Không có", "0"));
        for (int v_i = 0; v_i < v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows.Count; v_i++)
        {
            m_cbo_chuc_nang_cha.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows[v_i][HT_CHUC_NANG.TEN_CHUC_NANG]), CIPConvert.ToStr(v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows[v_i][HT_CHUC_NANG.ID])));
        }
    }
    private void load_data_2_cbo_chuc_nang_search()
    {
        US_HT_CHUC_NANG v_us_ht_chuc_nang = new US_HT_CHUC_NANG();
        DS_HT_CHUC_NANG v_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();

        v_us_ht_chuc_nang.FillDataset(v_ds_ht_chuc_nang, " WHERE CHUC_NANG_PARENT_ID = 0 ORDER BY ID");

        m_cbo_chuc_nang_cap_1.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows.Count; v_i++)
        {
            m_cbo_chuc_nang_cap_1.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows[v_i][HT_CHUC_NANG.TEN_CHUC_NANG]), CIPConvert.ToStr(v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows[v_i][HT_CHUC_NANG.ID])));
        }

    }
    private void load_data_2_us_by_id(int ip_i_row_index)
    {
        decimal v_dc_chuc_nang_id = CIPConvert.ToDecimal(m_grv_dm_chuc_nang_he_thong.DataKeys[ip_i_row_index].Value);
        hdf_id.Value = CIPConvert.ToStr(v_dc_chuc_nang_id);
        m_us_ht_chuc_nang = new US_HT_CHUC_NANG(v_dc_chuc_nang_id);
        m_txt_ten_chuc_nang.Text = m_us_ht_chuc_nang.strTEN_CHUC_NANG;
        m_txt_url_form.Text = m_us_ht_chuc_nang.strURL_FORM;
        m_cbo_chuc_nang_cha.SelectedValue = CIPConvert.ToStr(m_us_ht_chuc_nang.dcCHUC_NANG_PARENT_ID);
        if (m_us_ht_chuc_nang.strTRANG_THAI_YN.Equals("Y")) m_rdl_su_dung_yn.Items[0].Selected = true;
        else m_rdl_su_dung_yn.Items[1].Selected = true;
        if (m_us_ht_chuc_nang.strHIEN_THI_YN.Equals("Y")) m_rdl_hien_thi_yn.Items[0].Selected = true;
        else m_rdl_hien_thi_yn.Items[1].Selected = true;
        m_cbo_vi_tri.SelectedValue = CIPConvert.ToStr(m_us_ht_chuc_nang.dcVI_TRI);
        m_cbo_vi_tri.Enabled = true;
    }
    private void load_data_2_cbo_vi_tri()
    {
        for (int v_i = 0; v_i < 15; v_i++)
        {
            m_cbo_vi_tri.Items.Add(new ListItem((v_i + 1).ToString(), (v_i + 1).ToString()));
        }
    }
    private void delete_dm_chuc_nang(int ip_i_row_index)
    {
        decimal v_dc_chuc_nang_id = CIPConvert.ToDecimal(m_grv_dm_chuc_nang_he_thong.DataKeys[ip_i_row_index].Value);
        m_us_ht_chuc_nang.DeleteByID(v_dc_chuc_nang_id);
    }
    private void reset_control()
    {
        m_lbl_mess.Text = "";
        m_lbl_thong_bao.Text = "";
        m_txt_ten_chuc_nang.Text = "";
        m_txt_url_form.Text = "";
        m_grv_dm_chuc_nang_he_thong.SelectedIndex = -1;
        m_cbo_chuc_nang_cap_1.SelectedIndex = 0;
        m_rdl_hien_thi_yn.Items[0].Selected = true;
        m_rdl_su_dung_yn.Items[0].Selected = true;
    }
    private void form_2_us_obj()
    {
        m_us_ht_chuc_nang.strTEN_CHUC_NANG = m_txt_ten_chuc_nang.Text.Trim();
        m_us_ht_chuc_nang.strURL_FORM = m_txt_url_form.Text.Trim();
        m_us_ht_chuc_nang.dcCHUC_NANG_PARENT_ID = CIPConvert.ToDecimal(m_cbo_chuc_nang_cha.SelectedValue);
        if (m_rdl_su_dung_yn.Items[0].Selected) m_us_ht_chuc_nang.strTRANG_THAI_YN = "Y";
        else m_us_ht_chuc_nang.strTRANG_THAI_YN = "N";
        if (m_rdl_hien_thi_yn.Items[0].Selected) m_us_ht_chuc_nang.strHIEN_THI_YN = "Y";
        else m_us_ht_chuc_nang.strHIEN_THI_YN = "N";
        m_us_ht_chuc_nang.dcVI_TRI = CIPConvert.ToDecimal(m_cbo_vi_tri.SelectedValue);
    }
    // Hàm này dựa vào parent id để lấy được vị trí lớn nhất mà chức năng con đang có
    private decimal get_max_vi_tri(decimal ip_dc_parent_chuc_nang_id)
    {
        US_HT_CHUC_NANG v_us_ht_chuc_nang = new US_HT_CHUC_NANG();
        DS_HT_CHUC_NANG v_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();
        v_us_ht_chuc_nang.load_chuc_nang_max_vi_tri_by_parent_id(ip_dc_parent_chuc_nang_id, v_ds_ht_chuc_nang);
        if (v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_ht_chuc_nang.HT_CHUC_NANG.Rows[0][HT_CHUC_NANG.VI_TRI]);
    }

    private bool check_validate_data_is_ok()
    {
        m_lbl_thong_bao.Text = "";
        if (m_txt_ten_chuc_nang.Text.Trim().Equals(""))
        {
            m_lbl_thong_bao.Text = "Bạn phải nhập Tên Chức Năng!";
            return false;
        }
        return true;
    }
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Form.DefaultButton = m_cmd_tim_kiem.UniqueID;
        if (!IsPostBack)
        {
            if (!Person.check_user_have_menu())
            {
                Response.Clear();
                Response.Redirect("/DatPhongHop/", false);
                return;
            }
            load_data_2_cbo_parent();
            load_data_2_cbo_chuc_nang_search();
            load_data_2_cbo_vi_tri();
            load_data_2_grid(CIPConvert.ToDecimal(m_cbo_chuc_nang_cap_1.SelectedValue));
            m_e_form_mode = DataEntryFormMode.InsertDataState;

            set_control_by_form_mode();
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if (!check_validate_data_is_ok()) return;
            m_lbl_mess.Text = "";
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            // thu thập dữ liệu
            form_2_us_obj();
            // Insert
            m_us_ht_chuc_nang.Insert();
            // hiển thị lại lên lưới
            load_data_2_grid(CIPConvert.ToDecimal(m_cbo_chuc_nang_cap_1.SelectedValue));
            // Reset lại control
            reset_control();
            m_lbl_mess.Text = "Thêm bản ghi thành công!";
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
            if (!check_validate_data_is_ok()) return;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_lbl_mess.Text = "";
            // thu thập dữ liệu
            form_2_us_obj();
            m_us_ht_chuc_nang.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            // Update
            m_us_ht_chuc_nang.Update();
            // hiển thị lại lên lưới
            load_data_2_grid(CIPConvert.ToDecimal(m_cbo_chuc_nang_cap_1.SelectedValue));
            // Reset lại control
            reset_control();
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            set_control_by_form_mode();

            m_lbl_mess.Text = "Cập nhật dữ liệu thành công!";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_chuc_nang_cap_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid(CIPConvert.ToDecimal(m_cbo_chuc_nang_cap_1.SelectedValue));
            if (m_cbo_chuc_nang_cap_1.SelectedValue.Equals("0"))
                m_cbo_chuc_nang_cha.SelectedIndex = 0;
            else m_cbo_chuc_nang_cha.SelectedValue = m_cbo_chuc_nang_cap_1.SelectedValue;
            decimal v_dc_max_vi_tri = get_max_vi_tri(CIPConvert.ToDecimal(m_cbo_chuc_nang_cha.SelectedValue));
            m_cbo_vi_tri.SelectedValue = CIPConvert.ToStr(v_dc_max_vi_tri + 1);
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
            reset_control();
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            set_control_by_form_mode();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_chuc_nang_he_thong_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            set_control_by_form_mode();
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_chuc_nang_he_thong_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_chuc_nang(e.RowIndex);
            load_data_2_grid(CIPConvert.ToDecimal(m_cbo_chuc_nang_cap_1.SelectedValue));
            m_lbl_mess.Text = "Xóa bản ghi thành công!";
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_chuc_nang_he_thong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_chuc_nang_he_thong.PageIndex = e.NewPageIndex;
            load_data_to_grid_by_tu_khoa();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_vi_tri_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            decimal v_dc_max_vi_tri = get_max_vi_tri(CIPConvert.ToDecimal(m_cbo_chuc_nang_cha.SelectedValue));
            m_cbo_vi_tri.SelectedValue = CIPConvert.ToStr(v_dc_max_vi_tri + 1);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_chuc_nang_cha_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            decimal v_dc_max_vi_tri = get_max_vi_tri(CIPConvert.ToDecimal(m_cbo_chuc_nang_cha.SelectedValue));
            m_cbo_vi_tri.SelectedValue = CIPConvert.ToStr(v_dc_max_vi_tri + 1);
            // Kiểm tra xem cbo menu cap 1 có chuc nang id đó ko?
            ListItemCollection v_list_items_collection = m_cbo_chuc_nang_cap_1.Items;
            for (int v_i = 0; v_i < v_list_items_collection.Count; v_i++)
            {
                if (v_list_items_collection[v_i].Value.Equals(m_cbo_chuc_nang_cha.SelectedValue))
                {
                    m_cbo_chuc_nang_cap_1.SelectedValue = m_cbo_chuc_nang_cha.SelectedValue;
                    break;
                }
            }
            if (!m_cbo_chuc_nang_cha.SelectedValue.Equals(m_cbo_chuc_nang_cap_1.SelectedValue))
                m_cbo_chuc_nang_cap_1.SelectedIndex = 0;
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
            //m_txt_tim_kiem.Focus();
            load_data_to_grid_by_tu_khoa();

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion

}