<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F810_PhanQuyenUserGroup.aspx.cs" Inherits="Quantri_F810_PhanQuyenUserGroup" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="6">
                        <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Phân quyền cho nhóm người dùng" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%">
                        <asp:Label ID="Label4" CssClass="cssManField" runat="server" Text="Nhóm người dùng (Quyền)" />
                    </td>
                    <td style="width: 29%">
                        <asp:DropDownList ID="m_cbo_user_group" runat="server" Width="300px" CssClass="cssDorpdownlist"
                            AutoPostBack="true" OnSelectedIndexChanged="m_cbo_user_group_SelectedIndexChanged" />
                    </td>
                    <td style="width: 1%">&nbsp;
                    </td>
                    <td colspan="2" style="width: 49%">
                        <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                            Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" Height="22px" />
                    </td>
                    <td style="width: 1%">
                        <asp:CustomValidator ID="m_cvt_loai_tu_dien" runat="server" ControlToValidate="m_cbo_user_group"
                            ErrorMessage="Bạn phải chọn Nhóm người dùng" Display="Static" Text="*" />
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblFullName0" CssClass="cssManField" runat="server" Text="Chức năng phần mềm" />
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblFullName1" CssClass="cssManField" runat="server" Text="Chức năng của Nhóm người dùng" />
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        <asp:ListBox ID="m_lst_chuc_nang" runat="server" Width="100%" Height="300px" SelectionMode="Multiple"></asp:ListBox>
                    </td>
                    <td align="center">
                        <asp:ImageButton ID="m_cmd_right" runat="server" ImageUrl="~/Images/ListTran/right.gif"
                            OnClick="m_cmd_right_Click" />
                        <asp:ImageButton ID="m_cmd_right_all" runat="server" ImageUrl="~/Images/ListTran/rightAll.gif"
                            OnClick="m_cmd_right_all_Click" />
                        <br />
                        <br />
                        <asp:ImageButton ID="m_cmd_left" runat="server" ImageUrl="~/Images/ListTran/left.gif"
                            OnClick="m_cmd_left_Click" Style="height: 19px" />
                        <asp:ImageButton ID="m_cmd_left_all" runat="server" ImageUrl="~/Images/ListTran/leftAll.gif"
                            OnClick="m_cmd_left_all_Click" />
                    </td>
                    <td colspan="2">
                        <asp:ListBox ID="m_lst_chuc_nang_user" runat="server" Width="100%" Height="300px"
                            SelectionMode="Multiple"></asp:ListBox>
                    </td>

                    <td>&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
