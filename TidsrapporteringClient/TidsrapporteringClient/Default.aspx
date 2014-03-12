<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="TidsrapporteringClient.Default" Title="IT-Mästaren Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-signin" role="form">
    <div class="row">
    <h2 class="form-signin-heading">Logga in</h2>
    </div>
    
    <input type="text" class="form-control" placeholder="Email address" required autofocus>
    <input type="password" class="form-control" placeholder="Password" required>
    <label class="checkbox">
        <input type="checkbox" value="remember-me">
        Remember me
    </label>
    <button class="btn btn-lg btn-primary btn-block" type="submit">
        Sign in</button>
    </form>
</asp:Content>
