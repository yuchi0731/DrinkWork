<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="SendOrder.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.SendOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>確認訂單</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <asp:Literal ID="ltMainUser" runat="server">團主：</asp:Literal>
    <asp:Label ID="lbMainUser" runat="server" ForeColor="Blue"></asp:Label>
        <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#3399FF" BorderStyle="None" BorderWidth="1px" CssClass="accordion-button collapsed" style="left: 0px; top: 0px; width: 107%">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="訂單編號" />
            <asp:BoundField DataField="OrderNumber" HeaderText="訂單名稱" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="訂購時間" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm:ss}" HeaderText="截止時間" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="需求時間" />
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
            <asp:BoundField DataField="TotalPrice" HeaderText="總金額" />
            <asp:BoundField DataField="TotalCups" HeaderText="總杯數" />
            <asp:BoundField DataField="Established" HeaderText="成立狀況" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnViewDetail" runat="server" Text="檢視明細" class="btn btn-info" OnClick="btnViewDetail_Click"/>
    <asp:Button ID="btnText" runat="server" Text="寫出.txt檔"  class="btn btn-info" OnClick="btnText_Click" Visible="false"/><br />



        <asp:TextBox ID="txtCheck" runat="server" ReadOnly="true" TextMode="MultiLine" Visible="false" Height="204px" Width="365px"></asp:TextBox>
    <br />


    <asp:Button runat="server" ID="btnExport" Text="送出訂購單並寄信" class="btn btn-primary" OnClick="btnExport_Click" Visible="false" /> <asp:Button runat="server" ID="btnCancel" Text="取消" OnClick="btnCancel_Click" Visible="false" class="btn btn-warning" />

    <asp:PlaceHolder ID="plNoData" runat="server" Visible="false">
        <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
    </asp:PlaceHolder>
        <br />    <br />    <br />    <br />    
</asp:Content>
