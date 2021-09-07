<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="ModifyUserInfo.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.UserManagement.ModifyUserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>修改使用者</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div id="divall" class="container-fluid">

            <asp:Literal ID="ltlInfo" runat="server">請在需更改的欄位上輸入，輸入完畢再按下存檔</asp:Literal>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>                         
        <table>
            <tr>
                <th>
                    <asp:Literal ID="ltlEID" runat="server">員工ID</asp:Literal></th>
                <td>
                   <asp:TextBox ID="txtEID" runat="server" Text='<%# Eval("EmployeeID") %>'>                     </asp:TextBox></td>
                
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlDID" runat="server">部門ID</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtDID" runat="server" ToolTip="請輸入整數" Text='<%# Eval("DepartmentID") %>' ></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlD" runat="server">部門名稱</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtD" runat="server" Text='<%# Eval("Department") %>' ></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlLName" runat="server">姓氏</asp:Literal></th>
                <td>

                    <asp:TextBox ID="txtLName" runat="server" Text='<%# Eval("LastName") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Literal ID="ltlFName" runat="server">名字</asp:Literal></th>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" Text='<%# Eval("FirstName") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <th><asp:Literal ID="ltlContact" runat="server">主要聯絡方式</asp:Literal></th>
                <td><asp:DropDownList ID="dpContact" runat="server" Text='<%# Eval("Contact") %>'>
            <asp:ListItem>Email</asp:ListItem>
            <asp:ListItem Value="ext">分機</asp:ListItem>
            <asp:ListItem Value="phone">電話</asp:ListItem>
        </asp:DropDownList><br /></td>
            </tr>
            <tr>
                <th> <asp:Literal ID="ltlEmail" runat="server" >Email</asp:Literal></th>
                <td> <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox></td>
            </tr>
             <tr>
                <th><asp:Literal ID="ltlext" runat="server">分機號碼</asp:Literal></th>
                <td><asp:TextBox ID="txtext" runat="server" ToolTip="請輸入4位分機號碼" Text='<%# Eval("ext") %>'></asp:TextBox></td>
            </tr>
             <tr>
                <th><asp:Literal ID="ltlPhone" runat="server">聯絡電話</asp:Literal></th>
                <td><asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" Text='<%# Eval("Phone") %>'></asp:TextBox></td>
            </tr>
             <tr>
                <th><asp:Literal ID="ltlRepS" runat="server">負責廠商</asp:Literal></th>
                <td><asp:TextBox ID="txtRepS" runat="server" Text='<%# Eval("ResponseSuppliers") %>'></asp:TextBox></td>
            </tr>
             <tr>
                <th><asp:Literal ID="ltlJobGrade" runat="server" >職等</asp:Literal></th>
                <td><asp:DropDownList ID="dpJobGrade" runat="server" Text='<%# Eval("JobGrade") %>'>
            <asp:ListItem Value="0">一般員工</asp:ListItem>
            <asp:ListItem Value="1">管理者</asp:ListItem>
            <asp:ListItem Value="2">高階管理者</asp:ListItem>
        </asp:DropDownList><br /></td>
            </tr>
             <tr>
                <th><asp:Literal ID="ltldec" runat="server">其他事項</asp:Literal></th>
                <td><asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" Height="100px" Width="150px" Text='<%# Eval("Description") %>'></asp:TextBox></td>
            </tr>

            <tr>
                <th>更改照片</th>               
                <td><asp:FileUpload ID="FilePhoto" runat="server" />上傳</td>                      
            </tr>

        </table>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>


        <br />

        

        
        
    </div>

    <asp:Button ID="btnUpdate" runat="server" Text="修改"  OnClick="btnUpdate_Click"/>
    <asp:Button ID="btnReset" runat="server" Text="重置"  OnClick="btnReset_Click"/><bt />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label><br />

</asp:Content>
