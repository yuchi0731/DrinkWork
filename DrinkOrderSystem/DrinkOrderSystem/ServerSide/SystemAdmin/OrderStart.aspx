<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OrderStart.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OrderStart" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>開團介面</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>

    <asp:Button ID="Button2" runat="server" Text="Button"  OnClick="Button2_Click"/>

    <asp:Label ID="lbtotaldrinkcount" runat="server" Text="共幾筆"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


    <asp:GridView ID="gvdrinklist" runat="server" AutoGenerateColumns="False"   OnRowCommand="gvdrinklist_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="飲料名稱" />
            <asp:BoundField DataField="UnitPrice" HeaderText="金額" />

            <asp:TemplateField HeaderText="Choose">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">無糖</asp:ListItem>
                        <asp:ListItem Value="2">微糖</asp:ListItem>
                        <asp:ListItem Value="3">全糖</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="選取">
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" Text="選取" CommandArgument='<%# Eval("ProductName")%>' />
                </ItemTemplate>
            </asp:TemplateField>



        </Columns>
</asp:GridView>

    <uc1:ucPager runat="server" ID="ucPager" PageSize="10"  Url="/ServerSide/SystemAdmin/OrderStart.aspx"/>

    
    <asp:TextBox ID="txtAll" runat="server"></asp:TextBox>

        <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data in this Shop.
                        </p>
                    </asp:PlaceHolder>

</asp:Content>
