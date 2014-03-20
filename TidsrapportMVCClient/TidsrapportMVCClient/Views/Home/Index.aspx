<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Första sida
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top:20px;" >
    <div class="row">
        <div class="col-xs-12 col-sm-8 col-md-7 col-lg-6 col-sm-offset-2 col-md-offset-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon-lock"></span> Logga in</div>
                <div class="panel-body">
                    <form class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="inputUsername" class="col-sm-4 control-label" style="text-align:right">
                            Användarnamn</label> 
                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="inputUsername" placeholder="Användarnamn" required>
                        </div>
                    </div>
                   
                    <div class="form-group" >
                        <label for="inputPassword" class="col-sm-4 control-label" style="text-align:right">
                            Lösenord</label>
                        <div class="col-sm-8">
                            <input type="password" class="form-control" id="inputPassword" placeholder="Lösenord" required >
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-9">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox"/>
                                    Kom ihåg mig
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group last">
                        <div class="col-sm-offset-3 col-sm-9">
                            <button type="submit" class="btn btn-success btn-sm">
                                Logga in</button>
                        </div>
                    </div>
                    </form>
                </div>
                <div class="panel-footer">
                    Inte Registrerad? <%= Html.ActionLink("Registrera", "Register", "Account")%> här</a></div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
