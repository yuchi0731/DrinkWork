<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OrderRecords.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OrderRecords" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>歷史訂購紀錄</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvdrinklist" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="訂單號碼" />
            <asp:BoundField DataField="OrderNumber" HeaderText="訂單名稱" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="訂購時間" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm:ss}" HeaderText="截止時間" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="需求時間" />
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
            <asp:BoundField DataField="TotalPrice" HeaderText="總金額" />
            <asp:TemplateField HeaderText="訂單細項">
                                     <ItemTemplate>
                                    <a href="/ServerSide/SystemAdmin/OrderDetailInfo.aspx?ID=<%# Eval("OrderNumber") %>">Check</a>
                                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <uc1:ucPager runat="server" ID="ucPager"  PageSize="10" Url="/ServerSide/SystemAdmin/OrderRecords.aspx" />

            <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data in this Shop.
                        </p>
                    </asp:PlaceHolder>

</asp:Content>
