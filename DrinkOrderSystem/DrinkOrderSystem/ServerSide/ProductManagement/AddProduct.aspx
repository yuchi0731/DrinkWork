<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.ProductManagement.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>新增商品</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <table>
        <tr>
            <th>飲料名稱</th>
            <td>
                <asp:TextBox ID="txtNewProduct" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>現有廠商
            </th>
            <td>
                <asp:DropDownList ID="ddSupplier" runat="server">
                    <asp:ListItem Value="non">未選擇</asp:ListItem>
                    <asp:ListItem Value="Fiftylan">五十嵐</asp:ListItem>
                    <asp:ListItem Value="WhiteAlley">白巷子</asp:ListItem>
                    <asp:ListItem Value="MilkShop">迷客夏</asp:ListItem>
                </asp:DropDownList>
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
                <th>飲料種類
                </th>
                <td>
         <asp:DropDownList ID="ddCategory" runat="server">
                    <asp:ListItem Value="non">未選擇</asp:ListItem>
                    <asp:ListItem Value="Tea">茶類</asp:ListItem>
                    <asp:ListItem Value="MilkTea">奶茶</asp:ListItem>
                    <asp:ListItem Value="Juice">果汁</asp:ListItem>
             <asp:ListItem Value="Smoothie">冰沙</asp:ListItem>
             <asp:ListItem Value="Yakult">多多</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
        <tr>
            <th>參考圖片</th>
            <td>
                <asp:FileUpload ID="fdPictrue" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSave" runat="server" Text="新增" OnClick="btnSave_Click" /><asp:Button ID="btnClear" runat="server" Text="清除內容" OnClick="btnClear_Click" />
    <br />
    <asp:Label ID="lbMsg" runat="server"  ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>
