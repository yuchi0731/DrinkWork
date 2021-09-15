<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>歡迎回來！
        <asp:Literal ID="ltUser" runat="server"></asp:Literal>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table border="1">
        <tr>
            <th>帳號
            </th>
            <td>
                <asp:Literal ID="ltAccount" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>使用者等級
            </th>
            <td>
                <asp:Label ID="lbuserlevel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>即將到期訂單
            </th>
            <td>
                <asp:Literal ID="ltOrderNumber" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>


    <asp:Button ID="btnChangePWD" runat="server" Text="變更密碼" OnClick="btnChangePWD_Click" /><br />


</asp:Content>
