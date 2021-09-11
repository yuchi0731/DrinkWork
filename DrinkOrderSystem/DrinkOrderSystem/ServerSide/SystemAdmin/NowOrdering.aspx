<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="NowOrdering.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.NowOrdering" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>目前可跟團清單</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Panel ID="pnlbase" runat="server" style="background-color:ghostwhite" ScrollBars="Auto">
    <asp:GridView runat="server" ID="gvNoworderinglist"  AutoGenerateColumns="False" OnRowCommand="gvNoworderinglist_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="訂單編號" DataField="OrderNumber" />
            <asp:BoundField HeaderText="團主" DataField="Account" />
            <asp:BoundField HeaderText="訂購開始時間" DataField="OrderTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" />
            <asp:BoundField HeaderText="跟團截止時間" DataField="OrderEndTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" />
            <asp:BoundField HeaderText="指定送達時間" DataField="RequiredTime" DataFormatString="{0:yyyy-MM-dd-hh:mm}" />
            <asp:TemplateField HeaderText="目前訂單明細">
                <ItemTemplate>
    <a href="/ServerSide/SystemAdmin/WithGroup.aspx?ID=<%# Eval("OrderNumber") %>">確認</a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="跟團">
                <ItemTemplate>
                    <asp:Button ID="btnWithOrder" runat="server" Text="跟團" CommandArgument='<%#Eval("OrderNumber") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        </asp:Panel>

</asp:Content>
