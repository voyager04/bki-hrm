﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginGoogle.aspx.cs" Inherits="Account_LoginGoogle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="login" runat="server"  onclick="Button1_Click" style="display: none" Text="Login with Google ID" />
        </div>
    </form>
</body>
    <script language="javascript" type="text/javascript">
        document.getElementById('login').click();
    </script>
</html>
