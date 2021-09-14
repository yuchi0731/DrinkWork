<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="CreateNewUser.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.UserManagement.CreateNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        div {
            border: 2px solid Blue;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    新創使用者
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="divall" class="container-fluid">
        <table>
            <tr>
                <th>
                    <asp:Literal ID="ltlAccount" runat="server">帳號</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreateAccount" runat="server" CssClass="txtinput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlPWD" runat="server">密碼</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreatePWD" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlRePWD" runat="server">確認密碼</asp:Literal></th>
                <td>

                    <asp:TextBox ID="txtCreateRePWD" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlDID" runat="server">部門ID</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreateDID" runat="server" ToolTip="請輸入整數"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlD" runat="server">部門名稱</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreateD" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlLName" runat="server">姓氏</asp:Literal></th>
                <td>

                    <asp:TextBox ID="txtCreateLName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlFName" runat="server">名字</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreateFName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlContact" runat="server">主要聯絡方式</asp:Literal></th>
                <td>
                    <asp:DropDownList ID="dpCreateContact" runat="server">
                        <asp:ListItem Value="non">未選擇</asp:ListItem>
                        <asp:ListItem Value="ext">分機</asp:ListItem>
                        <asp:ListItem Value="phone">電話</asp:ListItem>
                        <asp:ListItem Value="email">Email</asp:ListItem>
                    </asp:DropDownList><br />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlEmail" runat="server">Email</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreateEmail" runat="server" TextMode="Email"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlext" runat="server">分機號碼</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreatext" runat="server" ToolTip="請輸入4位分機號碼"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlPhone" runat="server">聯絡電話</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreatePhone" runat="server" TextMode="Phone"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlRepS" runat="server">負責廠商</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreateRepS" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlJobGrade" runat="server">職等</asp:Literal></th>
                <td>
                    <asp:DropDownList ID="dpCreateJobGrade" runat="server">
                        <asp:ListItem Value="0">一般員工</asp:ListItem>
                        <asp:ListItem Value="1">管理者</asp:ListItem>
                        <asp:ListItem Value="2">高階管理者</asp:ListItem>
                    </asp:DropDownList><br />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltldec" runat="server">其他事項</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtCreatedesc" runat="server" TextMode="MultiLine" Height="100px" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <th>上傳照片
                </th>
                <td>
                    <asp:FileUpload ID="filePhoto" runat="server" />
                </td>
            </tr>
        </table>

        <br />





    </div>

    <asp:Button ID="btnCreate" runat="server" Text="建立" OnClick="btnCreate_Click" />
    <asp:Button ID="btnReset" runat="server" Text="清除內容" OnClick="btnReset_Click" /><br />
    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label><br />
    <asp:Label ID="lblMsg2" runat="server" Visible="false"></asp:Label>


</asp:Content>
