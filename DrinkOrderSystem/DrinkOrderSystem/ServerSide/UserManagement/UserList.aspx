<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.UserManagement.UserList" %>

<%@ Register Src="~/ServerSide/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>所有使用者資料</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:GridView ID="gvUserlist" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvUserlist_RowDataBound1">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="員工編號" />
            <asp:BoundField DataField="DepartmentID" HeaderText="部門代號" />
            <asp:BoundField DataField="Department" HeaderText="部門" />
            <asp:BoundField DataField="LastName" HeaderText="姓氏" />
            <asp:BoundField DataField="FirstName" HeaderText="名字" />
            <asp:BoundField DataField="Contact" HeaderText="聯絡方式" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ext" HeaderText="分機號碼" />
            <asp:BoundField DataField="Phone" HeaderText="聯絡電話" />

            <asp:TemplateField HeaderText="職等">
                <ItemTemplate>  
                    <asp:Label runat="server" ID="lbluserlevel" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                
            <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立時間" />
                
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                      <a href="/ServerSide/UserManagement/ModifyUserInfo.aspx?ID=<%# Eval("EmployeeID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
</asp:GridView>

    <uc1:ucpager runat="server" id="ucPager" PageSize="10"  Url="/ServerSide/UserManagement/UserList.aspx"/>
    <br />
    <asp:Literal ID="ltlMsg" runat="server">關鍵字搜尋</asp:Literal><asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
    <asp:Button ID="btnKeyword" runat="server" Text="搜尋"  OnClick="btnKeyword_Click"/>
        <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data.
                        </p>
                    </asp:PlaceHolder>
</asp:Content>
