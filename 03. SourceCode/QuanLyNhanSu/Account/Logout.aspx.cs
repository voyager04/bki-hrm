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

using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using BKI_HRM.US;

public partial class Account_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session[SESSION.AccounLoginYN] = "";
        Session[SESSION.UserName] = "";
        Session[SESSION.UserID] = "";
        Session.Abandon();
        Response.Cookies.Remove("UserName");
        Response.Cookies.Remove("PassWord");
        Response.Cookies["UserName"].Expires = DateTime.Now.AddMonths(-1);
        Response.Cookies["PassWord"].Expires = DateTime.Now.AddMonths(-1);
        Session[SESSION.AccounLoginYN] = "N";
        Session[SESSION.UserName] = "";
        FormsAuthentication.SignOut();
        Response.Redirect("http://accounts.google.com/logout");
    }
}