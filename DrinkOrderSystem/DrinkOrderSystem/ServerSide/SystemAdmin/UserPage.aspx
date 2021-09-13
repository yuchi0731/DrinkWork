<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>歡迎回來！
        <asp:Literal ID="ltUser" runat="server"></asp:Literal>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <th>帳號
            </th>
            <td>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>等級
            </th>
            <td>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>最近使用之訂單
            </th>
            <td>
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>


    <asp:Button ID="btnChangePWD" runat="server" Text="變更密碼" OnClick="btnChangePWD_Click" /><br />


</asp:Content>
