<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OderMid.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OderMid" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style>
        .gd {
            clear: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>跟團介面</h1>
     <h2>訂單編號：<asp:Literal ID="ltOrderNumber" runat="server"></asp:Literal></h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <h2 class="gd">請選擇飲料品項</h2>
    <h2><asp:Label ID="lbSup" runat="server" ForeColor="Blue"></asp:Label></h2>

       <asp:GridView ID="gvChooseDrink" runat="server" AutoGenerateColumns="False" Height="89px" Width="694px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="auto-style1"  OnRowCommand="gvChooseDrink_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="產品名稱" DataField="ProductName" />
                <asp:BoundField HeaderText="價格" DataField="UnitPrice" />
                <asp:TemplateField HeaderText="數量">
                    <ItemTemplate>
                        <asp:DropDownList ID="dlQuantity" runat="server">
                            <asp:ListItem Value="0">請選擇杯數</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="選擇糖量">
                    <ItemTemplate>
                        <asp:DropDownList ID="dlChooseSugar" runat="server">
                            <asp:ListItem Value="0">請選擇糖量</asp:ListItem>
                            <asp:ListItem Value="1">無糖</asp:ListItem>
                            <asp:ListItem Value="2">微糖</asp:ListItem>
                            <asp:ListItem Value="3">半糖</asp:ListItem>
                            <asp:ListItem Value="4">少糖</asp:ListItem>
                            <asp:ListItem Value="5">全糖</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="選擇冰塊">
                    <ItemTemplate>
                        <asp:DropDownList ID="dlChooseIce" runat="server">
                            <asp:ListItem Value="0">請選擇冰塊</asp:ListItem>
                            <asp:ListItem Value="1">去冰</asp:ListItem>
                            <asp:ListItem Value="2">微冰</asp:ListItem>
                            <asp:ListItem Value="3">少冰</asp:ListItem>
                            <asp:ListItem Value="4">正常冰</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="加料區">
                    <ItemTemplate>
                        <asp:DropDownList ID="dlChooseToppings" runat="server">
                            <asp:ListItem Value="0">請選擇是否加料</asp:ListItem>
                            <asp:ListItem Value="1">不加料</asp:ListItem>
                            <asp:ListItem Value="2">珍珠</asp:ListItem>
                            <asp:ListItem Value="3">寒天</asp:ListItem>
                            <asp:ListItem Value="4">椰果</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="點選">
                    <ItemTemplate>
                        <asp:Button ID="btnChoose" runat="server" Text="選擇"  CommandArgument='<%#Eval("ProductName") %>' CommandName="ChooseDrink" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView >

            <uc1:ucPager runat="server" ID="ucPager" PageSize="10" Url="/ServerSide/SystemAdmin/OderMid.aspx"/>
        <br />             
        <asp:Label ID="lbErrorMsg" runat="server" Visible="false" ForeColor="Red"></asp:Label><br />
        <asp:TextBox ID="txtChooseDrinkList" runat="server" MaxLength="100" ReadOnly="True" Rows="10" Width="703px" Height="143px" TextMode="MultiLine"></asp:TextBox><br />

    <asp:Label ID="lbTotalAmount" runat="server" ></asp:Label><br />
    <asp:Button ID="btnSent" runat="server" Text="確認送出" OnClick="btnSent_Click" Visible="False" />
    <asp:Button ID="btnDelete" runat="server" Text="清除選單" OnClick="btnDelete_Click" Visible="False" /><br />



                <asp:Label ID="lbMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>


</asp:Content>
