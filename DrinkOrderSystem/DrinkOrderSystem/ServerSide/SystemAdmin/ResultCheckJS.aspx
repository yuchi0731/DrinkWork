<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="ResultCheckJS.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.ResultCheckJS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Button ID="btntxt" runat="server" Text="寫出.txt檔"  OnClick="btntxt_Click"/>
    <asp:Literal ID="ltResult" runat="server"></asp:Literal>
</asp:Content>
