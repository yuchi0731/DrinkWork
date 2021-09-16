<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserRecords.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UserRecords" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>個人訂購紀錄</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:DropDownList ID="ddselect" runat="server" Visible="false">
        <asp:ListItem Value="non">排序方式</asp:ListItem>
        <asp:ListItem Value="RecentTime">時間由新至舊</asp:ListItem>
        <asp:ListItem Value="OldestTime">時間由舊至新</asp:ListItem>
        <asp:ListItem Value="ProductName">商品</asp:ListItem>
     </asp:DropDownList>
    <asp:Button ID="btnSelect" runat="server" Text="排序" class="btn btn-primary" OnClick="btnSelect_Click"  Visible="false"/>

     <asp:GridView ID="gvUserDetail" runat="server" AutoGenerateColumns="False" BackColor="#CCFFF1" BorderColor="White" BorderStyle="Dotted" CssClass="auto-style1" Width="1277px">
         <Columns>

            <asp:BoundField DataField="OrderNumber" HeaderText="訂單編號" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="訂購時間" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm:ss}" HeaderText="截止時間" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="送達時間" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="ProductName" HeaderText="商品名稱" ItemStyle-HorizontalAlign="Center"  />

             <asp:BoundField DataField="Quantity" HeaderText="數量" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="UnitPrice" HeaderText="單價" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="Suger" HeaderText="甜度" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="Ice" HeaderText="冰塊" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="toppings" HeaderText="加料" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="SubtotalAmount" HeaderText="小計" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="SupplierName" HeaderText="廠商" ItemStyle-HorizontalAlign="Center" />
             <asp:BoundField DataField="Established" HeaderText="訂單成立狀況" ItemStyle-HorizontalAlign="Center" />

        </Columns>
    </asp:GridView>

    <uc1:ucPager runat="server" ID="ucPager" PageSize="10" Url="ServerSide/SystemAdmin/UserRecords.aspx" Visible="false" /><br />

                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                        </p>
                    </asp:PlaceHolder>

</asp:Content>
