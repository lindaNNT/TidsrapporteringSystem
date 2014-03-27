<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="TidsrapporteringASPClient._Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 55px;">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-10">
             <asp:Login ID="Login" runat="server" OnAuthenticate="btnLogin_OnClick">
             
             <LayoutTemplate>
                <section id="loginForm">
                    <div class="form-horizontal">
                        <h4>Logga in här</h4>
                        <hr />
                          <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                          </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-3 control-label">Användarnamn</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="text-danger" ErrorMessage="Måste fylla i användarnamn." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-3 control-label">Lösenord</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Måste fylla i lösenord." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Kom ihåg mig?</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_OnClick" Text="Logga in" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                    <p>
                        <asp:HyperLink runat="server" ID="RegisterHyperLink" EnableViewState="false">Register</asp:HyperLink>
                        if you don't have a local account.
                    </p>
                </section>
                </LayoutTemplate>
                </asp:Login>
            </div>     
        </div>
    </div>
</asp:Content>
