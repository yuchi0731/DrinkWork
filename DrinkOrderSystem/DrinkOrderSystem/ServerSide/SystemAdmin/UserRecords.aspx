<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserRecords.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UserRecords" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>個人訂購紀錄</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:DropDownList ID="ddselect" runat="server">
        <asp:ListItem Value="non">排序方式</asp:ListItem>
        <asp:ListItem Value="RecentTime">時間由新至舊</asp:ListItem>
        <asp:ListItem Value="OldestTime">時間由舊至新</asp:ListItem>
        <asp:ListItem Value="ProductName">商品</asp:ListItem>
     </asp:DropDownList>
    <asp:Button ID="btnSelect" runat="server" Text="排序"  OnClick="btnSelect_Click" />

     <asp:GridView ID="gvUserDetail" runat="server" AutoGenerateColumns="False">
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
    <uc1:ucpager runat="server" id="ucPager"  PageSize="10"   Url="/ServerSide/SystemAdmin/UserRecords.aspx"/><br />

                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                        </p>
                    </asp:PlaceHolder>

</asp:Content>
