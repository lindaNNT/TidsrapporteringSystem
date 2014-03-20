<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="UTF-8">
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/_references.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.intellisense.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.min.map"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate-vsdoc.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.unobtrusive.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr-2.6.2.js"></script>
    <script type="text/javascript" src="/Scripts/respond.min.js"></script>
    
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

<div class="navbar navbar-inverse">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav nav-pills">
                <li><%= Html.ActionLink("Rapportering", "Index", "Meny")%></li>
                <li><%= Html.ActionLink("Historik", "Historik", "Meny")%></li>
                <li><%= Html.ActionLink("Översikt", "Oversikt", "Meny")%></li>
            </ul>
        </div>
    </div>
</div>
