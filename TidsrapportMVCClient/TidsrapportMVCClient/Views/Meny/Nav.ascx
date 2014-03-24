<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="UTF-8">
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap-theme.css.map" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.css.map" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/colorpicker.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/colorpicker.less" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap-theme.min.css">
    
    <script type="text/javascript" src="/Scripts/_references.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.intellisense.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.11.0.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.min.js"></script>
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.11.0.min.map"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate-vsdoc.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.unobtrusive.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr-2.6.2.js"></script>
    <script type="text/javascript" src="/Scripts/respond.min.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap-colorpicker.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>   
    <script type="text/javascript" src="http://twitter.github.io/bootstrap/assets/js/bootstrap-transition.js"></script>
    <script type="text/javascript" src="http://twitter.github.io/bootstrap/assets/js/bootstrap-collapse.js"></script>
    
    <script type="text/javascript" src="/Scripts/WebForms/DetailsView.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/Focus.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/GridView.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/Menu.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MenuStandards.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/SmartNav.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/TreeView.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/WebForms.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/WebParts.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/WebUIValidation.js"></script>
    
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxApplicationServices.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxComponentModel.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxCore.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxGlobalization.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxHistory.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxNetwork.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxSerialization.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxTimer.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxWebForms.js"></script>
    <script type="text/javascript" src="/Scripts/WebForms/MSAjax/MicrosoftAjaxWebServices.js"></script>
    
    
</head>
<body>
<form id="Form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <%--Scripts in Scripts-folder--%>
                <asp:ScriptReference Path="~/Scripts/_references.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-1.10.2.intellisense.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-1.10.2.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-1.10.2.min.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-1.10.2.min.map" />
                <asp:ScriptReference Path="~/Scripts/jquery.validate.js" />
                <asp:ScriptReference Path="~/Scripts/jquery.validate-vsdoc.js" />
                <asp:ScriptReference Path="~/Scripts/jquery.validate.min.js" />
                <asp:ScriptReference Path="~/Scripts/jquery.validate.unobtrusive.js" />
                <asp:ScriptReference Path="~/Scripts/jquery.validate.unobtrusive.min.js" />
                <asp:ScriptReference Path="~/Scripts/modernizr-2.6.2.js" />
                <asp:ScriptReference Path="~/Scripts/respond.js" />
                <asp:ScriptReference Path="~/Scripts/respond.min.js" />
                
                <%--Scripts in WebForms-folder--%>
                <asp:ScriptReference Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/Focus.js" />
                
                <%--Scripts in MSAjax-folder--%>
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjax.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxApplicationServices.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxComponentModel.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxCore.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxGlobalization.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxHistory.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxNetwork.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxSerialization.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxTimer.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxWebForms.js" />
                <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjaxWebServices.js" />
            </Scripts>
        </asp:ScriptManager>

<div class="navbar navbar-inverse">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#subBar">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
        </div>
        <div class="collapse navbar-collapse" id="subBar">
            <ul class="nav navbar-nav">
                <li><%= Html.ActionLink("Rapportering", "Index", "Meny")%></li>
                <li><%= Html.ActionLink("Historik", "Historik", "Meny")%></li>
                <li><%= Html.ActionLink("Översikt", "Oversikt", "Meny")%></li>
            </ul>
        </div>
    </div>
</div>
</form>
</body>
</html>
