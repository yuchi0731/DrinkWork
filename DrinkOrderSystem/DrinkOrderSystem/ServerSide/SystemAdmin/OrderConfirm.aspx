<%@ Page Title="" Language="C#" MasterPageFile="~/ServerSide/ServerSide.Master" AutoEventWireup="true" CodeBehind="OrderConfirm.aspx.cs" Inherits="DrinkOrderSystem.ServerSide.SystemAdmin.OrderConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False"></asp:GridView>
</asp:Content>
