<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.ProductManagement.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
          <table>
        <tr>
            <th>飲料名稱</th>
            <td>
                <asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>單價
            </th>
            <td>
                <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
            </td>
            </tr>
        <tr>
            <th>參考圖片</th>
            <td>
                <asp:FileUpload ID="fdPictrue" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" /><asp:Button ID="btnClear" runat="server" Text="清除內容" OnClick="btnClear_Click" />
    <br />
    <asp:Label ID="lbMsg" runat="server"  ForeColor="Red" Visible="false"></asp:Label>

</asp:Content>
