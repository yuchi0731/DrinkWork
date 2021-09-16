<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>歡迎回來！
        <asp:Literal ID="ltUser" runat="server"></asp:Literal>
    </h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table border="1" style="-moz-animation-play-state"  class="table table-striped">
        <tr scope="col">
            <th>帳號
            </th>
            <td>
                <asp:Literal ID="ltAccount" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr scope="col">
            <th>使用者等級
            </th>
            <td>
                <asp:Label ID="lbuserlevel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr scope="col">
            <th class="auto-style2">即將到期訂單
            </th>
            <td class="auto-style2">
                <asp:Literal ID="ltOrderNumber" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
<asp:Button ID="btnChangePWD" runat="server" Text="變更密碼" OnClick="btnChangePWD_Click" class="btn btn-primary" /><br />
            </td>
        </tr>
    </table>


    


</asp:Content>
