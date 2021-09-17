<%@ Page Title="" Language="C#" MasterPageFile="~/ClientSide/ClientSide.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DrinkOrderSystem.ClientSide.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table>
        <tr>
            <th>帳號</th>
            <td><asp:TextBox runat="server" ID="txtAccount"></asp:TextBox></td>
        </tr>
                <tr>
            <th>密碼</th>
            <td><asp:TextBox runat="server" ID="txtPWD" TextMode="Password"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnLogin" class="btn btn-outline-primary" runat="server" Text="登入" OnClick="btnLogin_Click" />
    <%--<asp:Button ID="btnforget" runat="server" Text="忘記密碼" /><br />--%>
    <asp:Label ID="lbMsg" runat="server"  ForeColor="Red" Visible="false"></asp:Label>

</asp:Content>

