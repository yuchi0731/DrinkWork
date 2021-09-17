<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OrderStart.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OrderStart" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        #d1, #d2, #d3 {
            float: left;
            margin: 10px;
        }

        .gd {
            clear: left;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>開團介面</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h4 class="gd" id="gd1"><asp:Literal ID="ltChoosedShop" runat="server">請點圖片來選擇店家</asp:Literal></h4>
    <div id="d1">
  <asp:ImageButton ID="ImgbtnFiftylan" runat="server"  ImageUrl="../ImagesServer/Fiftylan.png" OnClick="ImgbtnFiftylan_Click" Width="100" />
        <asp:ImageButton ID="ImgbtnWhiteAlley" runat="server"  ImageUrl="../ImagesServer/WhiteAlley.jpg" OnClick="ImgbtnWhiteAlley_Click" Width="100" />
        <asp:ImageButton ID="ImgbtnMilkshop" runat="server"  ImageUrl="../ImagesServer/Milkshop.png" OnClick="ImgbtnMilkshop_Click" Width="100" />
    </div>

    <div id="gdlist">
        <h4 class="gd" id="gd2"><asp:Literal ID="ltDrinkTitle" runat="server" Visible="false" >請選擇飲料品項</asp:Literal></h4>
        <asp:GridView ID="gvChooseDrink" runat="server" AutoGenerateColumns="False" Height="89px" Width="864px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style1" OnRowCommand="gvChooseDrink_RowCommand" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="產品名稱" DataField="ProductName" />
                <asp:BoundField HeaderText="價格" DataField="UnitPrice" />
                <asp:TemplateField HeaderText="數量">
                    <ItemTemplate>
                        <asp:DropDownList ID="dlQuantity" runat="server" AutoPostBack="True">
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
                        <asp:DropDownList ID="dlChooseSugar" runat="server" AutoPostBack="True">
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
                        <asp:DropDownList ID="dlChooseIce" runat="server" AutoPostBack="True">
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
                        <asp:DropDownList ID="dlChooseToppings" runat="server" AutoPostBack="True">
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
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <uc1:ucPager runat="server" ID="ucPager" PageSize="10" Url="/ServerSide/SystemAdmin/OrderStart.aspx" Visible="false" />
    </div>
    
    <br />

    <div>
        <asp:Label ID="lbErrorMsg" runat="server" Visible="false" ForeColor="Red"></asp:Label><br />
        <asp:TextBox ID="txtChooseDrinkList" runat="server" MaxLength="100" ReadOnly="True" Rows="10" Width="749px" Height="136px" TextMode="MultiLine" Visible="False"></asp:TextBox><br />
        <asp:Label ID="lbTotalAmount" runat="server" Visible="False"></asp:Label>
    </div>


    <div>
        <table>
            <tr>
                <th>開團截止時間
                </th>
                <td>
                    <asp:TextBox ID="txtEndTime" runat="server" ReadOnly="false" TextMode="DateTimeLocal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>指定送達公司時間
                </th>
                <td>
                    <asp:TextBox ID="txtReqTime" runat="server" ReadOnly="false" TextMode="DateTimeLocal"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>


    <div>
        <asp:Button ID="btnSent" runat="server" Text="確認送出" OnClick="btnSent_Click" Visible="False" />
        <asp:Button ID="btnDelete" runat="server" Text="清除選單" OnClick="btnDelete_Click" Visible="False" />
        

    </div>

    <asp:Label ID="lbMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>
