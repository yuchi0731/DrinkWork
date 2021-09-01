<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserRecords.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UserRecords" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:GridView ID="gvUserDetail" runat="server" AutoGenerateColumns="False">
         <Columns>

            <asp:BoundField DataField="OrderNumber" HeaderText="訂單名稱" />
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
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
             <asp:BoundField DataField="OtherRequest" HeaderText="其他" />

        </Columns>
    </asp:GridView>
    <uc1:ucpager runat="server" id="ucPager"    PageSize="10"   Url="/ServerSide/SystemAdmin/UserRecords.aspx"/>
                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data in this Shop.
                        </p>
                    </asp:PlaceHolder>

</asp:Content>
