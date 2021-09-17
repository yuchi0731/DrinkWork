<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OrderRecords.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OrderRecords" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>歷史訂購紀錄</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <table>
        <tr>
            <th>篩選方式</th>
            <td>
                <asp:DropDownList ID="ddSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddSelect_SelectedIndexChanged">
                    <asp:ListItem Value="non">未選擇</asp:ListItem>
                    <asp:ListItem Value="account">訂購人</asp:ListItem>
                    <asp:ListItem Value="orderNumber">訂單編號</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtSelect" runat="server" Visible="false" Width="147px"></asp:TextBox>
                <asp:Button ID="btnSelect" runat="server" Text="篩選" OnClick="btnSelect_Click"  Visible="false" class="btn btn-primary"/><asp:Label ID="lbSelect" runat="server" ForeColor="Red"></asp:Label>
        <asp:Button ID="btnSortingN" runat="server" Text="以需求時間近至遠排序" OnClick="btnSortingN_Click" class="btn btn-outline-info"/>
        <asp:Button ID="btnSortingF" runat="server" Text="以需求時間遠至近排序" OnClick="btnSortingF_Click" class="btn btn-outline-info" />
                <asp:Button ID="btnClearSelect" runat="server" Text="還原清單" OnClick="btnClearSelect_Click" class="btn btn-warning" />
            </td>
        </tr>
    </table>


    <asp:GridView ID="gvdrinklist" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#3399FF" BorderStyle="None" BorderWidth="1px" CssClass="accordion-button collapsed" style="left: -24px; top: 0px; width: 110%">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="訂單編號" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="OrderNumber" HeaderText="訂單名稱"  ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Account" HeaderText="訂購人" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="訂購時間" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm:ss}" HeaderText="截止時間" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="需求時間" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="SupplierName" HeaderText="廠商" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="TotalPrice" HeaderText="總金額" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="TotalCups" HeaderText="總杯數" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="訂單細項" ItemStyle-HorizontalAlign="Center" >
                                     <ItemTemplate>
                                    <a href="/ServerSide/SystemAdmin/OrderDetailInfo.aspx?OrderNumber=<%# Eval("OrderNumber") %>">明細</a>
                                </ItemTemplate>
            </asp:TemplateField>

          <asp:TemplateField HeaderText="結帳" ItemStyle-HorizontalAlign="Center">
                                     <ItemTemplate>
                                    <a href="/ServerSide/SystemAdmin/SendOrder.aspx?OrderNumber=<%# Eval("OrderNumber") %>">結帳</a>
                                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Established" HeaderText="成立狀況" ItemStyle-HorizontalAlign="Center" />
        </Columns>

    </asp:GridView>

    <uc1:ucPager runat="server" ID="ucPager"  PageSize="10" Url="/ServerSide/SystemAdmin/OrderRecords.aspx" />

            <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                        </p>
                    </asp:PlaceHolder>

</asp:Content>
