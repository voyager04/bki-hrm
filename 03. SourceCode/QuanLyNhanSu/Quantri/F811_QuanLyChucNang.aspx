<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F811_QuanLyChucNang.aspx.cs" Inherits="Quantri_F811_QuanLyChucNang" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Quản lý các chức năng của hệ thống" />
                        &nbsp;<span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 20%;"></td>
                    <td align="right" style="width: 15%;">
                        <asp:Label ID="lbl_content" CssClass="cssManField" runat="server" Text="Tên chức năng" />
                    </td>
                    <td style="width: 45%;">
                        <asp:TextBox ID="m_txt_ten_chuc_nang" CssClass="cssTextBox" CausesValidation="false"
                            runat="server" Width="90%" />
                    </td>
                    <td style="width: 20%;"></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_loai_hop_dong" CssClass="cssManField" runat="server" Text="URL của chức năng"
                            AccessKey="L" />
                    </td>
                    <td align="left">
                        <asp:TextBox ID="m_txt_url_form" Width="90%" runat="server" CssClass="cssTextBox">
                        </asp:TextBox>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_ma_don_vi_tinh" CssClass="cssManField" runat="server" Text="Chức năng cha" />
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="m_cbo_chuc_nang_cha" runat="server" Width="91%" OnSelectedIndexChanged="m_cbo_chuc_nang_cha_SelectedIndexChanged"
                            AutoPostBack="true" CssClass="cssDorpdownlist">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_ma_don_vi_tinh0" CssClass="cssManField" runat="server" Text="Vị trí" />
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="m_cbo_vi_tri" runat="server" Width="20%"
                            AutoPostBack="true" CssClass="cssDorpdownlist">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_ma_tan_xuat1" CssClass="cssManField" runat="server" Text="Được sử dụng YN?" />
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="m_rdl_su_dung_yn" runat="server" RepeatDirection="Horizontal"
                            Width="117px">
                            <asp:ListItem Value="Y" Selected="True" style="color: blue">Có</asp:ListItem>
                            <asp:ListItem Value="N" style="color: blue">Không</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_ma_tan_xuat0" CssClass="cssManField" runat="server" Text="Được hiển thị YN?" />
                    </td>
                    <td valign="top" colspan="2">&nbsp;
                <asp:RadioButtonList ID="m_rdl_hien_thi_yn" runat="server" RepeatDirection="Horizontal"
                    Width="117px">
                    <asp:ListItem Value="Y" Selected="True" style="color: blue">Có</asp:ListItem>
                    <asp:ListItem Value="N" style="color: blue">Không</asp:ListItem>
                </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;
                    </td>
                    <td valign="top" colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td colspan="2" align="left">
                        <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssGoogleButton" runat="server"
                            Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssGoogleButton" runat="server"
                    Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssGoogleButton" runat="server"
                    Text="Xóa trắng(r)" OnClick="btnCancel_Click" />
                        <asp:HiddenField ID="hdf_id" runat="server" Value="" />
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="server" CssClass="cssPageTitle" Text="Danh sách chức năng" />
                        &nbsp;<span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 20%">
                        <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
                    </td>
                    <td style="width: 15%"></td>
                    <td style="width: 45%"></td>
                    <td style="width: 20%"></td>
                </tr>
                <asp:Panel ID="m_pnl_chuc_nang_cha" runat="Server" Visible="false">
                    <tr>
                        <td></td>
                        <td align="right">
                            <asp:Label ID="lbl_ghi_chu0" CssClass="cssManField" runat="server" Text="Chức năng cấp 1" />
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_chuc_nang_cap_1" CssClass="cssDorpdownlist" runat="server"
                                Style="width: 91%" AutoPostBack="True" OnSelectedIndexChanged="m_cbo_chuc_nang_cap_1_SelectedIndexChanged" />
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td></td>
                    <td colspan="1" class="cssManField" align="right">
                        <span>Từ khoá:</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" Style="width: 90%" />
                    </td>
                    <td>
                        <asp:Button ID="m_cmd_tim_kiem" runat="Server" CssClass="cssGoogleButton"
                            Text="Tìm kiếm" OnClick="m_cmd_tim_kiem_Click" />
                    </td>
                </tr>

                <tr>
                    <td align="center" colspan="4" style="height: 450px; width: 90%" valign="top">&nbsp;
                <asp:GridView ID="m_grv_dm_chuc_nang_he_thong" runat="server" AutoGenerateColumns="false"
                    Width="99%" DataKeyNames="ID" AllowPaging="true" PagerStyle-HorizontalAlign="Center"
                    PageSize="20" CssClass="GridViewStyle" CellPadding="8" OnPageIndexChanging="m_grv_dm_chuc_nang_he_thong_PageIndexChanging"
                    OnRowDeleting="m_grv_dm_chuc_nang_he_thong_RowDeleting" OnSelectedIndexChanging="m_grv_dm_chuc_nang_he_thong_SelectedIndexChanging">
                    <PagerSettings Position="TopAndBottom" />
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="Xóa">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbt_delete" runat="server" CommandName="Delete" ToolTip="Xóa"
                                    OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbt_update" runat="server" CausesValidation="false" CommandName="Select"
                                    ToolTip="Sửa">
                     <img alt="Sửa" src="../Images/Button/edit.png" />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TEN_CHUC_NANG" HeaderText="Tên chức năng" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:TemplateField HeaderText="Tên chức năng cha">
                            <ItemTemplate>
                                <%# get_TEN_CHUC_NANG_PARENT(Eval("CHUC_NANG_PARENT_ID"))%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="URL_FORM" ItemStyle-HorizontalAlign="Left" HeaderText="URL của chức năng"></asp:BoundField>
                        <asp:BoundField DataField="VI_TRI" HeaderText="Vị trí" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:TemplateField HeaderText="Được sử dụng YN">
                            <ItemTemplate>
                                <%# mapping_yn(Eval("TRANG_THAI_YN"))%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Được hiển thị YN">
                            <ItemTemplate>
                                <%# mapping_yn(Eval("HIEN_THI_YN"))%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
