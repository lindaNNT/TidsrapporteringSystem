<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TidsrapporteringClient.Default" Title="IT-Mästaren Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb" runat="server"></asp:TextBox>
    <asp:Button ID="btn" runat="server" Text="hämta namn" onclick="btn_Click" />
    <br />
    <asp:Label ID="lblText" runat="server"></asp:Label>
</asp:Content>
