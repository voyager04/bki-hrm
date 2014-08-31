using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;

using System.Collections.Generic;

//using ConnectionMan;

using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.ComponentModel;
using DotNetOpenAuth.Configuration;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPCommon;

public partial class Account_LoginGoogle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            OpenIdRelyingParty openidd = new OpenIdRelyingParty();
            IAuthenticationResponse response = openidd.GetResponse();

            if (response != null && response.Status == AuthenticationStatus.Authenticated && response.Provider.Uri == new Uri("https://www.google.com/accounts/o8/ud"))
            {
                FetchResponse fetch = response.GetExtension<FetchResponse>();
                string email = String.Empty;
                if (fetch != null)
                {
                    email = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email); //Fetching requested emailid
                    IP.Core.IPUserService.US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new IP.Core.IPUserService.US_HT_NGUOI_SU_DUNG();
                    DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
                    //string email = "dmt.20102514@gmail.com";
                    v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, "where ten_truy_cap = '" + email + "' and trang_thai=0 and built_in_yn='Y'");

                    if (v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Count == 0)
                    {
                        Session[SESSION.NHOM_PHAN_QUYEN] = ID_USER_GROUP.NHAN_DAN;
                        Session[SESSION.UserID] = -1;
                        Session[SESSION.UserName] = email;
                        Session[SESSION.AccounLoginYN] = "Y";
                        FormsAuthentication.RedirectFromLoginPage(email.Trim(), false);
                        Response.Redirect("~/ChucNang/F100_thong_tin_ca_nhan.aspx", false);
                    }
                    else
                    {
                        DataRow v_dr = v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0];
                        if (CIPConvert.ToDecimal(v_dr[7]) == ID_USER_GROUP.QUAN_LY)
                        {
                            Session[SESSION.NHOM_PHAN_QUYEN] = ID_USER_GROUP.QUAN_LY;
                            Session[SESSION.UserID] = v_dr[0];
                            Session[SESSION.UserName] = v_dr[2];
                        }
                        if (CIPConvert.ToDecimal(v_dr[7]) == ID_USER_GROUP.ADMIN)
                        {
                            Session[SESSION.NHOM_PHAN_QUYEN] = ID_USER_GROUP.ADMIN;
                            Session[SESSION.UserID] = v_dr[0];
                            Session[SESSION.UserName] = v_dr[2];
                        }

                        if (CIPConvert.ToDecimal(v_dr[7]) == ID_USER_GROUP.NHAN_DAN)
                        {
                            Session[SESSION.NHOM_PHAN_QUYEN] = ID_USER_GROUP.NHAN_DAN;
                            Session[SESSION.UserID] = -1;
                            Session[SESSION.UserName] = email;
                        }
                    }
                    Session[SESSION.AccounLoginYN] = "Y";
                    FormsAuthentication.RedirectFromLoginPage(email.Trim(), false);
                }

            }
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this,v_e);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (OpenIdRelyingParty openid = new OpenIdRelyingParty())
        {
            IAuthenticationRequest request = openid.CreateRequest("https://www.google.com/accounts/o8/id");
            FetchRequest fetch = new FetchRequest();
            fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
            //            fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email); // Request for email id 
            request.AddExtension(fetch); // Adding in request obj
            request.RedirectToProvider();
        }
    }
}