<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="SendOrder.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.SendOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>送出表單</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <asp:Literal ID="ltMainUser" runat="server">團主：</asp:Literal>
    <asp:Label ID="lbMainUser" runat="server" ForeColor="Blue"></asp:Label>
        <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#3399FF" BorderStyle="None" BorderWidth="1px" CssClass="accordion-button collapsed">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="訂單編號" />
            <asp:BoundField DataField="OrderNumber" HeaderText="訂單名稱" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="訂購時間" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm:ss}" HeaderText="截止時間" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="需求時間" />
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
            <asp:BoundField DataField="TotalPrice" HeaderText="總金額" />

        </Columns>
    </asp:GridView>



    <asp:PlaceHolder ID="plDetail" runat="server" Visible="false">
    <asp:GridView ID="gvSend" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderNumber" HeaderText="訂單編號" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="訂購時間" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm:ss}" HeaderText="截止時間" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="需求時間" />
            <asp:BoundField DataField="ProductName" HeaderText="商品名稱" />
             <asp:BoundField DataField="Quantity" HeaderText="數量" />
             <asp:BoundField DataField="UnitPrice" HeaderText="單價" />
             <asp:BoundField DataField="Suger" HeaderText="甜度" />
             <asp:BoundField DataField="Ice" HeaderText="冰塊" />
             <asp:BoundField DataField="toppings" HeaderText="加料" />
            <asp:BoundField DataField="SubtotalAmount" HeaderText="小計" />
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
             <asp:BoundField DataField="OtherRequest" HeaderText="其他" />
        </Columns>

    </asp:GridView>
</asp:PlaceHolder><br />


    <asp:Button runat="server" ID="btnExportToExcel" Text="確定送出" /> <asp:Button runat="server" ID="btnCancel" Text="取消" />

</asp:Content>
