<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.UserManagement.ModifyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <th>原密碼</th>
            <td>
                <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>

        </tr>
                <tr>
            <th>新密碼</th>
            <td>
                <asp:TextBox ID="txtNewPWD" runat="server"  TextMode="Password"></asp:TextBox>
            </td>

        </tr>
                <tr>
            <th>確認新密碼</th>
            <td>
                <asp:TextBox ID="txtReNewPWD" runat="server"  TextMode="Password"></asp:TextBox>
            </td>

        </tr>
    </table>
    <asp:Button ID="btnChange" runat="server" Text="確認變更" OnClick="btnChange_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="取消變更"  OnClick="btnCancel_Click"/>
    <asp:Label ID="lbMsg" runat="server" Visible="false" ForeColor="Red"></asp:Label>

</asp:Content>
