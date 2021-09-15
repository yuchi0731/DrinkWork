<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OrderDetailInfo.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OrderDetailInfo" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>訂單編號：<asp:Label ID="lbNumber" runat="server" ForeColor="Blue"></asp:Label></h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <th>篩選方式</th>
            <td>
                <asp:DropDownList ID="ddSelect" runat="server">
                    <asp:ListItem Value="non">未選擇</asp:ListItem>
                    <asp:ListItem Value="account">訂購人</asp:ListItem>
                    <asp:ListItem Value="productName">商品名稱</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtSelect" runat="server"></asp:TextBox>
                <asp:Button ID="btnSelect" runat="server" Text="篩選"  OnClick="btnSelect_Click"/>
          <asp:Button ID="btnClearSelect" runat="server" Text="取消"  OnClick="btnClearSelect_Click"/>

            </td>
        </tr>
    </table>
    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False">
         <Columns>

            <asp:BoundField DataField="OrderNumber" HeaderText="訂單名稱" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" HeaderText="訂購時間" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" HeaderText="截止時間" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" HeaderText="需求時間" />
            <asp:BoundField DataField="ProductName" HeaderText="商品名稱" />

             <asp:BoundField DataField="Quantity" HeaderText="數量" />
             <asp:BoundField DataField="UnitPrice" HeaderText="單價" />
             <asp:BoundField DataField="Suger" HeaderText="甜度" />
             <asp:BoundField DataField="Ice" HeaderText="冰塊" />
             <asp:BoundField DataField="toppings" HeaderText="加料" />
             <asp:BoundField DataField="SubtotalAmount" HeaderText="小計" />
             <asp:BoundField DataField="SupplierName" HeaderText="廠商" />
             <asp:BoundField DataField="OtherRequest" HeaderText="其他" />

             <asp:BoundField DataField="Established" HeaderText="訂單成立狀況" />

        </Columns>
    </asp:GridView>
    <uc1:ucpager runat="server" id="ucPager" PageSize="10"  Url="/ServerSide/SystemAdmin/OrderDetailInfo.aspx" />
                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                        </p>
                    </asp:PlaceHolder>
</asp:Content>
