<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historik.aspx.cs" Inherits="TidsrapporteringASPClient.LogedInPages.Historik" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="tbTest" runat="server"></asp:TextBox>
    <asp:Button ID="btnTest" runat="server" Text="Test" onclick="btnTest_Click" />
    <asp:Label ID="lblTest" runat="server" Text="Test"></asp:Label>
</asp:Content>
