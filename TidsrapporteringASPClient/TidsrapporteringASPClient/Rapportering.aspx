<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapportering.aspx.cs" Inherits="TidsrapporteringASPClient.Rapportering" Title="Rapportering" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
    <h2>Rappotering sida</h2>
    <div class="container-fluid" >
    
       <%-- New insert--%>
        <div id="newRapport" class="col-xs-12 col-sm-12 col-md-8 col-lg-8" style="background-color:White">
        
           <%-- First row with preset settings, date, activity and articel setting. --%>
            <div id="dateAndActivity" class="row" style="background-color:white;">
                <div id="quickBox" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White; border-bottom:solid 1px black; ">
                    <div class:"container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                        
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-xs-6 col-sm-6 col-md-6" style="margin-top: 10px;">
                                    <asp:Button ID="btnSenaste" runat="server" class="btn btn-default" Text="Senaste"></asp:Button>
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6" style="margin-top: 10px;">
                                    <asp:Button ID="btnSjuk" runat="server" class="btn btn-warning" Text="Sjuk"></asp:Button>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Favoriter</label> 
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
                <div id="dateBox" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White; border-bottom:solid 1px black; ">
                    <div class:"container" style="height:165px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                    
                    <form class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="inputFrDt" class="col-sm-12 control-label" style="text-align:left">
                             &nbsp; &nbsp; Datum Från</label> 
                        <div class="col-sm-12">
                            <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10">
                                <input type="text" class="form-control" id="inputFrDt" placeholder="YYYYMMDD" required>
                            </div>
                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1">
                                <button type="button" class="btn btn-default btn-sm" runat="server">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </button>
                            </div>
                            </div>
                        </div>
                    <div class="form-group">
                        <label for="inputToDt" class="col-sm-12 control-label" style="text-align:left">
                            &nbsp; &nbsp; Datum Till</label> 
                        <div class="col-sm-12">
                            <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10">
                                <input type="text" class="form-control" id="inputToDt" placeholder="YYYYMMDD" required>
                            </div>
                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1">
                                <button type="button" class="btn btn-default btn-sm" runat="server">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </button>
                            </div>
                            </div>
                        </div>
                    </form>
                    
                    </div>
                </div>
                <div id="activityBox" class="col-xs-12 col-sm-4 col-md-3 col-md-offset-1 col-xs-pull    -2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White; border-bottom:solid 1px black;">
                    <div class:"container" style="height:165px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px; background-color:White">
                                    <label class="col-sm-5 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">
                                        Aktivitet
                                    </label> 
                                    <label class="col-sm-7 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1 control-label" style="text-align:left">
                                       &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Debit
                                    </label> 
                                </div>
                                <div class="col-sm-12">
                                    <asp:DropDownList ID="ddlAktivitet" runat="server" Height="36px" Width="140px"></asp:DropDownList> 
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="36px" Width="50px"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Art</label> 
                                </div>
                                <div class="col-sm-12">
                                    <asp:DropDownList ID="ddlArt" runat="server" Height="36px" Width="140px"></asp:DropDownList>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            
            <%-- Second row with Custom Nr, Order nr, and service setting. --%>
            <div id="custOrderAndService" class="row" style="background-color:white; margin-top:10px;">
                <div id="CustBox" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:100px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Kundnamn</label> 
                                </div>
                                <div class="col-sm-12">
                                    <asp:DropDownList ID="ddlKundNamn" runat="server" Height="36px" Width="150px"></asp:DropDownList>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div id="orderBox" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                    <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Order</label> 
                                </div>
                                <div class="col-sm-12">
                                    <asp:ListBox ID="lbOrder" runat="server" Width="180px" Height="100px"></asp:ListBox>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div id="serviceBox" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                    <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Service</label> 
                                </div>
                                <div class="col-sm-12">
                                    <asp:ListBox ID="lbService" runat="server" Width="190px" Height="100px"></asp:ListBox>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            
            <%-- Thired row with Time settings, Descr1 and 2 setting. --%>
            <div id="timeDescr" class="row" style="background-color:white; margin-top:10px;">
                <div id="timeBox" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-xs-6 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:white">
                                    <div class="span12">
                                        <label for="inputFrTid" class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left; font-size:13px">Tid Från</label> 
                                    </div>
                                    <div class="span12">
                                        <input type="text" class="form-control" id="inputFrTid" placeholder="HHMM" required>
                                    </div>
                                    <div class="span12">
                                        <label for="inputToTid" class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left; font-size:13px">Tid Till</label> 
                                    </div>
                                    <div class="span12">
                                        <input type="text" class="form-control" id="inputToTid" placeholder="HHMM" required>
                                    </div>
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1">
                                    <div class="span2">
                                        <label for="inputWT" class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left; font-size:13px">Arb. tid</label> 
                                    </div>
                                    <div class="span12">
                                        <input type="text" class="form-control" id="inputWT" placeholder="Arbetad tid" required>
                                    </div>
                                    <div class="span12">
                                        <label for="inputFT"  class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left; font-size:13px">Fakt. tid</label> 
                                    </div>
                                    <div class="span12">
                                        <input type="text" class="form-control" id="inputFT" placeholder="Fakturerad tid" required>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div id="descr1Box" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Benämning</label> 
                                </div>
                                <div class="col-sm-12">
                                    <textarea id="taBenamning" rows="2" cols="20" style="resize: none; width:180px; height:100px" ></textarea>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div id="descr2Box" class="col-xs-12 col-sm-4 col-md-4 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                        <form class="form-horizontal" role="form">
                            <div class="form-group">
                                <div class="col-sm-12" style="margin-top: 10px;">
                                    <label class="col-sm-12 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1 control-label" style="text-align:left">Intern text</label> 
                                </div>
                                <div class="col-sm-12">
                                    <textarea id="taIntern" rows="2" cols="20" style="resize: none; width:190px; height:100px" ></textarea>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            
            <%-- Fourth row with buttons setting. --%>
            <div id="buttonsContainer" class="row" style="background-color:white; margin-top:10px;">
                <div id="buttonsBox" class="col-xs-12 col-sm-4 col-md-4 col-sm-offset-8 col-xs-pull-2 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class:"container" style="height:50px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                    <asp:Button ID="Button1" runat="server" Text="Rensa" class="btn btn-default"></asp:Button>
                    <asp:Button ID="Button2" runat="server" Text="Rapportera" class="btn btn-success"></asp:Button>
                    </div>
                </div>
                
            </div>
            
        </div>
        
        <%--Calender and infobox on the right, hide on phone devices--%>
        <div id= "caldenterAndInfo" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-md-push-1 hidden-phone hidden-tablet" style="background-color:Purple">
            <div id="calenderRow" class="row ">
                    <div id="calendarBox" class="col-sm-10 col-md-10 col-sm-offset-1  hidden-phone hidden-tablet" style="background-color:Aqua">
                    <div style="height:200px;">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </div>
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
