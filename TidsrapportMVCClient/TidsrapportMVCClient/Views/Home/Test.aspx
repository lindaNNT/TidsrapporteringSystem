<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TidsrapportMVCClient.TidsrapporteringService.Tidsrad>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Test</h2>
<ul>
<% foreach (TidsrapportMVCClient.TidsrapporteringService.Tidsrad tid in ViewData.Model)  {   %>
    <li>Kund nr: <%= tid.custName %>  Order nr: <%= tid.ordNr %>|<%=Html.ActionLink("Edit", "Edit", new { id=tid.agrNo }) %> </li>
<% } %>

<%--
    <fieldset>
        <legend>Fields</legend>
        <p>
            active:
            <%= Html.Encode(Model.active) %>
        </p>
        <p>
            activity:
            <%= Html.Encode(Model.activity) %>
        </p>
        <p>
            adWage:
            <%= Html.Encode(Model.adWage) %>
        </p>
        <p>
            agrActNo:
            <%= Html.Encode(Model.agrActNo) %>
        </p>
        <p>
            agrNo:
            <%= Html.Encode(Model.agrNo) %>
        </p>
        <p>
            benamning:
            <%= Html.Encode(Model.benamning) %>
        </p>
        <p>
            contract:
            <%= Html.Encode(Model.contract) %>
        </p>
        <p>
            custName:
            <%= Html.Encode(Model.custName) %>
        </p>
        <p>
            custNo:
            <%= Html.Encode(Model.custNo) %>
        </p>
        <p>
            debit:
            <%= Html.Encode(Model.debit) %>
        </p>
        <p>
            defaultActivity:
            <%= Html.Encode(Model.defaultActivity) %>
        </p>
        <p>
            faktureradTime:
            <%= Html.Encode(Model.faktureradTime) %>
        </p>
        <p>
            frDt:
            <%= Html.Encode(Model.frDt) %>
        </p>
        <p>
            frTm:
            <%= Html.Encode(Model.frTm) %>
        </p>
        <p>
            internText:
            <%= Html.Encode(Model.internText) %>
        </p>
        <p>
            ordNr:
            <%= Html.Encode(Model.ordNr) %>
        </p>
        <p>
            prodNo:
            <%= Html.Encode(Model.prodNo) %>
        </p>
        <p>
            project:
            <%= Html.Encode(Model.project) %>
        </p>
        <p>
            service:
            <%= Html.Encode(Model.service) %>
        </p>
        <p>
            toDt:
            <%= Html.Encode(Model.toDt) %>
        </p>
        <p>
            toTm:
            <%= Html.Encode(Model.toTm) %>
        </p>
        <p>
            utlagg:
            <%= Html.Encode(Model.utlagg) %>
        </p>
        <p>
            workedTime:
            <%= Html.Encode(Model.workedTime) %>
        </p>
    </fieldset>--%>
    <p>
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

