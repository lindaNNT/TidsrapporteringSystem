<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapportering.aspx.cs" Inherits="TidsrapporteringASPClient.Rapportering" Title="Rapportering" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
    <h2>Rappotering sida</h2>
    <div class="container-fluid" >
    
       <%-- New insert--%>
        <div id="newRapport" class="col-xs-12 col-sm-12 col-md-8 col-lg-8" style="background-color:White">
        
           <%-- First row with preset settings, date, activity and articel setting. --%>
            <div id="dateAndActivity" class="row" style="background-color:red; ">
                <div id="quickBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Gray">
                    <div class:"container" style="height:150px; width:200px; background-color:Blue; margin-left:auto; margin-right:auto;" >
                        
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-6" style="margin-top: 10px;">
                                    <asp:Button ID="btnSenaste" runat="server" class="btn btn-default" Text="Senaste"></asp:Button>
                                </div>
                                <div class="col-sm-6" style="margin-top: 10px;">
                                    <asp:Button ID="btnSjuk" runat="server" class="btn btn-warning" Text="Sjuk"></asp:Button>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <asp:Label ID="lblFavo" runat="server" Text="Favoriter"></asp:Label>
                                </div>
                                <div class="col-sm-12">
                                    <asp:DropDownList ID="ddlFavo" runat="server" Height="36px" Width="150px"></asp:DropDownList>
                                    <%--<button typ="button" ID="Button3" runat="server" Text="Favoriter" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                       Favoriter <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#">Action</a></li>
                                        <li><a href="#">Another action</a></li>
                                        <li><a href="#">Something else here</a></li>
                                        <li class="divider"></li>
                                        <li><a href="#">Separated link</a></li>
                                    </ul>--%>
                                </div>
                            </div>
                        </form>
                    
                    </div>
                </div>
                <div id="dateBox" class="col-xs-12 col-sm-4 col-md-4" style="background-color:Yellow">
                    <div class:"container" style="height:150px; width:200px; background-color:Blue; margin-left:auto; margin-right:auto;" >
                    
                    <form class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="inputFrDt" class="col-sm-12 control-label" style="text-align:left">
                            Datum Från</label> 
                        <div class="col-sm-12">
                            <input type="text" class="form-control" id="inputFrDt" placeholder="YYYYMMDD" required>
                            <button type="button" class="btn btn-default btn-xs" runat="server">
                            <span class="glyphicon glyphicon-calendar"></span>
                            </button>
                            </div>
                        </div>
                    <div class="form-group">
                        <label for="inputToDt" class="col-sm-12 control-label" style="text-align:left">
                            Datum Till</label> 
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="inputToDt" placeholder="YYYYMMDD" required>
                        </div>
                    </div>
                    </form>
                    
                    </div>
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
        
        <%--Calender and infobox on the right, hide on phone devices--%>
        <div id= "caldenterAndInfo" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 hidden-phone hidden-tablet" style="background-color:Purple">
            <div id="calenderRow" class="row ">
                    <div id="calendarBox" class="col-sm-10 col-md-10 col-sm-offset-1  hidden-phone hidden-tablet" style="background-color:Aqua">
                    <div style="height:200px;"></div>
                    </div>
            </div>
            <div id="infoRow" class="row">
                    <div id="infoBox" class="col-sm-10 col-md-10 col-sm-offset-1  hidden-phone hidden-tablet" style="background-color:Lime">
                    <div style="height:200px;"></div>
                    </div>
            </div>
        </div>
    </div>

    </div>
</asp:Content>
