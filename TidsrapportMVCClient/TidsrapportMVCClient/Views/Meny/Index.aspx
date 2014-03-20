<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <% Html.RenderPartial("Nav"); %>
    <h2>Rappotering sida</h2>
    <div class="container" style="margin-top:20px;" >
    
       <%-- New insert--%>
        <div id="newRapport" class="col-md-8">
        
           <%-- First row with preset settings, date, activity and articel setting. --%>
            <div id="dateAndActivity" class="row" style="background-color:red; ">
                <div id="quickBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Gray">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                <div id="dateBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Yellow">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                <div id="activityBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Blue">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
            </div>
            
            <%-- Second row with Custom Nr, Order nr, and service setting. --%>
            <div id="custOrderAndService" class="row" style="background-color:red; margin-top:10px;">
                <div id="CustBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Gray">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                <div id="orderBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Yellow">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                <div id="serviceBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Blue">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
            </div>
            
            <%-- Thired row with Time settings, Descr1 and 2 setting. --%>
            <div id="timeDescr" class="row" style="background-color:red; margin-top:10px;">
                <div id="timeBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Gray">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                <div id="descr1Box" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Yellow">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                <div id="descr2Box" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Blue">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
            </div>
            <%-- Fourth row with buttons setting. --%>
            <div id="buttonsContainer" class="row" style="background-color:red; margin-top:10px;">
                <div id="buttonsBox" class="col-xs-12 col-sm-4 col-md-4 col-sm-offset-8" style="background-color:Gray">
                    <div class:"container" style="height:150px; width:200px; background-color:Black; margin-left:auto; margin-right:auto;" ></div>
                </div>
                
            </div>
            
        </div>
        
        <%--Calender and infobox on the right--%>
        <div id= "caldenterAndInfo" class="col-md-4" style="background-color:Purple">
            <div id="calenderRow" class="row">
                    <div id="calendarBox" class="col-sm-10 col-md-10 col-sm-offset-1" style="background-color:Aqua">
                    <div style="height:200px;"></div>
                    </div>
            </div>
            <div id="infoRow" class="row">
                    <div id="infoBox" class="col-sm-10 col-md-10 col-sm-offset-1" style="background-color:Lime">
                    <div style="height:200px;"></div>
                    </div>
            </div>
        </div>
    </div>
    

</asp:Content>
