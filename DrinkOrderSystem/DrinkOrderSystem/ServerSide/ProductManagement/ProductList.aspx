<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.ProductManagement.ProductList" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>商品清單</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <asp:Literal ID="ltSelect" runat="server">篩選</asp:Literal>
    <asp:DropDownList ID="ddSelect" runat="server" OnSelectedIndexChanged="ddSelect_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="non">未選擇</asp:ListItem>
        <asp:ListItem Value="SelectName">以商品名稱篩選</asp:ListItem>
        <asp:ListItem Value="SelectSup">以廠商篩選</asp:ListItem>
        <asp:ListItem Value="SelectCategoryName">以飲料種類篩選</asp:ListItem>
        <asp:ListItem Value="SortingName">以商品名稱排序</asp:ListItem>
        <asp:ListItem Value="SortingSup">以廠商排序</asp:ListItem>      
    </asp:DropDownList>

    <asp:TextBox ID="txtSelect" runat="server" Visible="false"></asp:TextBox>
    <asp:Button ID="btnSelect" runat="server" Text="篩選"  OnClick="btnSelect_Click" Visible="false"/>
    <asp:Button ID="btnClear" runat="server" Text="清除篩選" OnClick="btnClear_Click" />

    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProduct_RowCommand">
        <Columns>

            <asp:BoundField DataField="ProductID" HeaderText="商品ID" />

            <asp:BoundField DataField="ProductName" HeaderText="飲料名稱" />
            <asp:BoundField DataField="UnitPrice" HeaderText="單價" />
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
            <asp:BoundField DataField="CategoryName" HeaderText="飲料種類" />
            <asp:TemplateField HeaderText="參考圖片"></asp:TemplateField>

            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                      <a href="/ServerSide/ProductManagement/ModifyProduct.aspx?ProductID=<%# Eval("ProductID") %>">修改</a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="刪除">
                                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="刪除" CommandName="btndelete" CommandArgument='<%#Eval("ProductID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <uc1:ucPager runat="server" ID="ucPager"  PageSize="10"   Url="/ServerSide/ProductManagement/ProductList.aspx" />
    <asp:Button ID="btnAdd" runat="server" Text="新增商品" OnClick="btnAdd_Click" />
    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
        <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
    </asp:PlaceHolder>

</asp:Content>
