using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using System.Data;

public partial class SiteMaster : System.Web.UI.MasterPage
{

    #region Members
    US_HT_CHUC_NANG m_us_ht_chuc_nang = new US_HT_CHUC_NANG();
    DS_HT_CHUC_NANG m_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();
    string m_str_user_name = "";
    #endregion

    // Events
    protected bool isUser()
    {
        if (Context.User.Identity.Name.EndsWith("@topica.edu.vn"))
        {
            return true;
        }
        if (Context.User.Identity.Name.EndsWith("@gmail.com"))
        {
            return true;
        }
        if (Context.User.Identity.Name.Equals("dmt.20102514@gmail.com"))
        {
            return true;
        }
        if (Context.User.Identity.Name.Equals("bkindextestktt@gmail.com"))
        {
            return true;
        }
        if (Context.User.Identity.Name.Equals("bkindextestktv@gmail.com"))
        {
            return true;
        }
        if (Context.User.Identity.Name.Equals("bkindextestnd@gmail.com"))
        {
            return true;
        }
        if (Context.User.Identity.Name.Equals("bkindextestqt@gmail.com"))
        {
            return true;
        }
        if (Context.User.Identity.Name.Equals("minhtu.bkhn@gmail.com"))
        {
            return true;
        }
        return false;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            if (Session[SESSION.AccounLoginYN] != null) {
                if (Session[SESSION.AccounLoginYN].ToString().Equals("Y")) {
                    m_lhk_user_name.Text =  Session[SESSION.UserName].ToString();
                    //m_str_user_name = CIPConvert.ToStr(Session[SESSION.UserName]);
                    //if (Context.User.Identity.Name.Equals("dmt.20102514@gmail.com") || Context.User.Identity.Name.Equals("tund@topica.edu.vn"))
                    //    m_hpl_menu_tu_khoa.Visible = true;
                    
                    //else m_hpl_menu_tu_khoa.Visible = false;
                    if (!IsPostBack)
                    {
                        m_ds_ht_chuc_nang.Clear();
                        /*if (CIPConvert.ToDecimal(Session[SESSION.UserID]) == -1)
                        {
                            m_us_ht_chuc_nang.get_parent_table_by_id_user_group(ID_USER_GROUP.NHAN_DAN, m_ds_ht_chuc_nang);
                        }
                        else
                        {
                            m_us_ht_chuc_nang.get_parent_table(CIPConvert.ToDecimal(Session[SESSION.UserID]), m_ds_ht_chuc_nang);
                        }
                        */
                        // Lấy toàn bộ các menu cấp 1 được cấp quyền và được hiển thị
                        rptMainMenu.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID IS NULL AND HIEN_THI_YN='Y'", "VI_TRI");
                        rptMainMenu.DataBind();
                        
                    }
                }
                else {
                    Response.Redirect("/QuanLyNhanSu/Account/LoginGoogle.aspx");
                }
            }
            else {
                Response.Redirect("/QuanLyNhanSu/Account/LoginGoogle.aspx", false);
            }
        }
        catch (Exception v_e) {

            CSystemLog_301.ExceptionHandle(v_e);
        }
    }

    protected string whoLoggedIn()
    {
        return Context.User.Identity.Name;
    }

    protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            DS_HT_CHUC_NANG.HT_CHUC_NANGRow dtr_row = (DS_HT_CHUC_NANG.HT_CHUC_NANGRow)e.Item.DataItem;
            Repeater rptMenu_child = (Repeater)e.Item.FindControl("rpt_child_Menu");
            decimal v_dc_parent_id = CIPConvert.ToDecimal(dtr_row[0]);
            if (rptMenu_child != null)
            {
                // Cái này chứa những thằng con của menu cha, được cấp quyền và đc phép hiển thị
                rptMenu_child.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =" + v_dc_parent_id + " AND HIEN_THI_YN='Y'", " VI_TRI");
                rptMenu_child.DataBind();
            }
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void rptCategory_ItemDataBound_cap_ba(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            DS_HT_CHUC_NANG.HT_CHUC_NANGRow dtr_row = (DS_HT_CHUC_NANG.HT_CHUC_NANGRow)e.Item.DataItem;
            Repeater rptMenu_child = (Repeater)e.Item.FindControl("rpt_child_Menu_cap_ba");
            decimal v_dc_parent_id = CIPConvert.ToDecimal(dtr_row[0]);
            //m_us_ht_chuc_nang.get_child_menu(v_dc_parent_id, m_str_user_name, m_ds_ht_chuc_nang);
            if (rptMenu_child != null)
            {
                // Cái này chứa những thằng con của thằng cha 
                rptMenu_child.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =" + v_dc_parent_id + " AND HIEN_THI_YN='Y'", "VI_TRI");
                rptMenu_child.DataBind();
            }
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void rptCategory_ItemDataBound_cap_bon(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            DS_HT_CHUC_NANG.HT_CHUC_NANGRow dtr_row = (DS_HT_CHUC_NANG.HT_CHUC_NANGRow)e.Item.DataItem;
            Repeater rptMenu_child = (Repeater)e.Item.FindControl("rpt_child_Menu_cap_bon");
            decimal v_dc_parent_id = CIPConvert.ToDecimal(dtr_row[0]);
            //m_us_ht_chuc_nang.get_child_menu(v_dc_parent_id, m_str_user_name, m_ds_ht_chuc_nang);
            if (rptMenu_child != null)
            {
                // Cái này chứa những thằng con của thằng cha 
                rptMenu_child.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =" + v_dc_parent_id + " AND HIEN_THI_YN='Y'", "VI_TRI");
                rptMenu_child.DataBind();
            }
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }

}
