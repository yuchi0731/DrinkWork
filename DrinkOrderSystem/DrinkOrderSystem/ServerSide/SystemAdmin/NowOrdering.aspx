<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="NowOrdering.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.NowOrdering" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>目前可跟團清單</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Panel ID="pnlbase" runat="server" style="background-color:ghostwhite" ScrollBars="Auto">
                <table>
        <tr>
            <th>篩選方式</th>
            <td>
                <asp:DropDownList ID="ddSelect" runat="server" OnSelectedIndexChanged="ddSelect_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="non">未選擇</asp:ListItem>
                    <asp:ListItem Value="account">團主</asp:ListItem>
                    <asp:ListItem Value="orderNumber">訂單編號</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtSelect" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnSelect" runat="server" Text="篩選" OnClick="btnSelect_Click" Visible="false" /><asp:Label ID="lbSelect" runat="server" ForeColor="Red"></asp:Label>
        <asp:Button ID="btnSortingN" runat="server" Text="以需求時間近至遠排序" OnClick="btnSortingN_Click" />
        <asp:Button ID="btnSortingF" runat="server" Text="以需求時間遠至近排序" OnClick="btnSortingF_Click" />
<asp:Button ID="btnClearSelect" runat="server" Text="還原清單" OnClick="btnClearSelect_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView runat="server" ID="gvNoworderinglist"  AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="訂單編號" DataField="OrderNumber" />
            <asp:BoundField HeaderText="團主" DataField="Account" />
            <asp:BoundField HeaderText="訂購開始時間" DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" />
            <asp:BoundField HeaderText="跟團截止時間" DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" />
            <asp:BoundField HeaderText="指定送達時間" DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" />
            <asp:TemplateField HeaderText="目前訂單明細">
                <ItemTemplate>
    <a href="/ServerSide/SystemAdmin/OrderDetailInfo.aspx?OrderNumber=<%# Eval("OrderNumber") %>">確認</a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="跟團">
                <ItemTemplate>
                    <a href="/ServerSide/SystemAdmin/OderMid.aspx?OrderNumber=<%# Eval("OrderNumber") %>">跟團</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Established" HeaderText="訂單成立狀況" />
        </Columns>
    </asp:GridView>

        <uc1:ucPager runat="server" ID="ucPager"  PageSize="10" Url="/ServerSide/SystemAdmin/NowOrdering.aspx"  />

        </asp:Panel>
                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
            <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                    </asp:PlaceHolder>
</asp:Content>
