<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UpdateDetailInfo.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.UpdateDetailInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>修改訂單【<asp:Label ID="lbOrder" runat="server" ForeColor="Blue"></asp:Label>】單筆資料</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <asp:Label ID="lbSearch" runat="server" Text="查詢此店家商品"></asp:Label>
    <asp:Button ID="btnSearch" runat="server" Text="查詢" class="btn btn-outline-info" OnClick="btnSearch_Click" /><br />
    <asp:TextBox ID="txtSearch" runat="server" Visible="false" TextMode="MultiLine" Height="46px" Width="254px"></asp:TextBox><br />

    <asp:GridView ID="gvDetailInfo" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDetailInfo_RowCommand" Width="507px">
        <Columns>         
            <asp:TemplateField>
                <ItemTemplate>
                  <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbProductName" runat="server" Text="商品名稱"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server" Text='<%# Eval("ProductName") %>'>
                            </asp:TextBox>
                        </td>
                        </tr>
                     <tr>
                        <td>
                            <asp:Label ID="lbPrice" runat="server" Text="單價"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbunitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                        </tr>
                        <tr>
                        <td>
                            <asp:Label ID="lbQuantity" runat="server" Text="數量"></asp:Label>
                        </td>                            
                        <td>
                            <asp:DropDownList ID="dlQuantity" runat="server" Text='<%# Eval("Quantity") %>'>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </td>
</tr>
                        <tr>
                            <td>
                            <asp:Label ID="lbSuger" runat="server" Text="甜度"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dlChooseSugar" runat="server" Text='<%# Eval("Suger") %>'>
                            <asp:ListItem>無糖</asp:ListItem>
                            <asp:ListItem>微糖</asp:ListItem>
                            <asp:ListItem>半糖</asp:ListItem>
                            <asp:ListItem>少糖</asp:ListItem>
                            <asp:ListItem>全糖</asp:ListItem>
                            </asp:DropDownList>
                        </td>
</tr>
                        <tr>
                        <td>
                            <asp:Label ID="lbIce" runat="server" Text="冰塊"></asp:Label>
                        </td>                            
                        <td>
                            <asp:DropDownList ID="dlChooseIce" runat="server" Text='<%# Eval("Ice") %>'>
                            <asp:ListItem>去冰</asp:ListItem>
                            <asp:ListItem>微冰</asp:ListItem>
                            <asp:ListItem>少冰</asp:ListItem>
                            <asp:ListItem>正常冰</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                                              <tr>
                        <td>
                            <asp:Label ID="lbToppings" runat="server" Text="加料"></asp:Label>
                        </td>                            
                        <td>
                            <asp:DropDownList ID="dlChooseToppings" runat="server" Text='<%# Eval("Toppings") %>'>
                            <asp:ListItem>不加料</asp:ListItem>
                            <asp:ListItem>珍珠</asp:ListItem>
                            <asp:ListItem>寒天</asp:ListItem>
                            <asp:ListItem>椰果</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                      <tr>
                          <td>
                              <asp:Label ID="lbamounttitle" runat="server" Text="小計"></asp:Label>
                              【<asp:Label ID="lbAmount" runat="server" Text='<%# Eval("SubtotalAmount") %>' ></asp:Label>】元 <br />
                          </td>
                          <td>

                          </td>
                      </tr>
                         <tr>
                             <td>
                        <asp:Button ID="btnSave" runat="server" class="btn btn-outline-primary" Text="儲存資料" CommandName="btnSave" />
                             </td>
                          <td>
                               <asp:Button ID="btnCancel" runat="server" class="btn btn-outline-secondary" Text="取消變更" CommandName="btnCancel" />
                          </td>
                      </tr>
                </table>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
        
    </asp:GridView>
    <asp:Label ID="lbErroMsg" runat="server" Visible="false"></asp:Label>

</asp:Content>
