﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapportering.aspx.cs" Inherits="TidsrapporteringASPClient.Rapportering" Title="Rapportering" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <h2>Rappotering sida</h2>
    <div class="container-fluid" style=" font-family:Arial " >
    
       <%-- New insert--%>
        <div id="newRapport" class="col-xs-12 col-sm-8 col-md-6 col-lg-6" style="background-color:White">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <%-- First row with preset settings and date setting. --%>
            <div id="dateAndActivity" class="row" style="background-color:white;">
               
                <div id="quickBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White;">
                    <div class="container" style="height:150px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSenaste" runat="server" class="btn btn-default" Text="Senaste"></asp:Button>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSjuk" runat="server" class="btn btn-warning" Text="Sjuk"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                    <td colspan="3">
                                        <b>Favoriter</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlFavo" runat="server" Width="160px" Height="25px" 
                                            Font-Size="11px" AutoPostBack="True">
                                            <asp:ListItem Text="Favvo 1"></asp:ListItem>
                                            <asp:ListItem Text="Favvo 2"></asp:ListItem>
                                            <asp:ListItem Text="Favvo 3"></asp:ListItem>
                                            <asp:ListItem Text="Favvo 4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                        </table>
                    </div>
                </div>
                <div id="dateBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:white;">
                    <div class="container" style="height:165px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                            <label for="inputFrDt" class="control-label " style="text-align:left">
                                            &nbsp; &nbsp; Datum Från</label> 
                            <div class="col-sm-12" style="background-color:white">
                                <table>
                                    <tr>
                                        <td>
                                            <input type="text" class="form-control" id="inputFrDt" style="font-size:12px; width:140px; height:30px" placeholder="YYYYMMDD" required>
                                        </td>
                                        <td>
                                            <button type="button" id="btnCalDtFr" class="btn btn-default btn-sm" runat="server">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </button>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                                <br />
                                    <label for="inputToDt" class="control-label " style="text-align:left; margin-top:10px;">
                                            &nbsp; &nbsp; Datum Till</label> 
                            <div class="col-sm-12" style="background-color:white">
                                <table>
                                    <tr>
                                        <td>
                                            <input type="text" class="form-control" id="inputToDt" style="font-size:12px; width:140px; height:30px" placeholder="YYYYMMDD" required>
                                        </td>
                                        <td>
                                            <button type="button" id="btnCalDtTo" class="btn btn-default btn-sm" runat="server">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </button>
                                        </td>
                                    </tr>
                                </table>
                                    
                                
                                </div>
                            </div>
                    
                </div>
                
            </div>
            
            <%-- Second row with activity, art, debit and time setting. --%>
            <div id="activityTime" class="row" style="background-color:white; margin-top:10px;">
                <div id="activityBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:white;">
                    <div class="container" style="height:165px; width:200px; background-color:white; margin-left:auto; margin-right:auto; margin-top:-10px;" >
                                <div >
                                    <asp:UpdatePanel ID="UpdatePanelActivity" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td><p><b>Debitera &nbsp;</b></p></td>
                                                    <td><asp:DropDownList ID="ddlDebit" runat="server" EnableViewState="true" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlDebit_SelectedIndexChanged" Height="25px" Font-Size="11px" Width="50px" ValidateRequestMode="Disabled" ViewStateMode="Enabled">
                                                                <asp:ListItem Value="false" Text="Nej">Nej</asp:ListItem>
                                                                <asp:ListItem Value="true" Text="Ja">Ja</asp:ListItem>
                                                            </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <label class="control-label" style="text-align: left; margin-top:5px;">
                                                Aktivitet
                                            </label>
                                            <asp:DropDownList ID="ddlAktivitet" runat="server" Height="25px" 
                                                Font-Size="11px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlAktivitet_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <label class="control-label" style="text-align: left">
                                                Art</label>
                                                <asp:DropDownList ID="ddlArt" runat="server" Height="25px" Font-Size="11px"
                                                    Width="180px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlDebit" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlAktivitet" EventName="SelectedIndexChanged" />
                                        </Triggers>

                                    </asp:UpdatePanel>
                                </div>
                        
                        </div>
                </div>
                <div id="timeBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:white">
                    <div class="container" style="height:150px; width:220px; background-color:white; margin-left:auto; margin-right:auto;" >
                                <div class="col-xs-12 col-sm-12 col-md-12">
                                    <div class="span12">
                                        <label for="inputFrTid" class="control-label" style="text-align:left;">
                                        Tid (HHMM)</label> 
                                    </div>
                                    <div class="span12">
                                        <table>
                                            <tr>
                                                <td> <input type="text" class="form-control" style="font-size:12px; height:30px;" id="inputFrTid" placeholder="Från" required></td>
                                                <td><b>&nbsp;-&nbsp;</b></td>
                                                <td><input type="text" class="form-control" style="font-size:12px; height:30px;" id="inputToTid" placeholder="Till" required></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-12">
                                    <div class="span2">
                                        <label for="inputWT" class="control-label" style="text-align:left; font-size:13px; margin-top:20px;">
                                        Arbetad & fakturerad tid</label> 
                                    </div>
                                    <div class="span12">
                                        <table>
                                            <tr>
                                                <td><input type="text" class="form-control" style="font-size:12px; height:30px" id="inputWT" placeholder="Arbet." required></td>
                                                <td>&nbsp;&nbsp;&nbsp;</td>
                                                <td><input type="text" class="form-control" style="font-size:12px; height:30px" id="inputFT" placeholder="Faktur." required></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                </div>
                
            </div>
            
            <%-- Thired row with custumer, order, service and projects settings setting. --%>
            <div id="CustOrdServProj" class="row" style="background-color:white; margin-top:10px;">
                <asp:UpdatePanel ID="UpdatePanelCust" runat="server">
                        <ContentTemplate>
                <div id="CustOrderBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class="container" style="height:170px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                        
                        <table>
                            <tr>
                                <td>
                                    <b>Kundnamn</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlKundNamn" runat="server" AutoPostBack="true" 
                                    Height="25px" Font-Size="11px" Width="190px" 
                                    OnSelectedIndexChanged="ddlKundNamn_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Order</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlOrder" runat="server" AutoPostBack="true" 
                                    Height="25px" Font-Size="11px" Width="190px"
                                    OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        
                    </div>
                </div>
                <div id="serviceProjBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class="container" style="height:170px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                        <table>
                            <tr>
                                <td>
                                    <b>Service</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlService"  AutoPostBack="true"  runat="server" Height="25px" Font-Size="11px" Width="190px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Projekt</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlProj"  AutoPostBack="true" runat="server" Height="25px" Font-Size="11px" Width="190px"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlKundNamn" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlOrder" EventName="SelectedIndexChanged" />
                        </Triggers>
                        </asp:UpdatePanel>
            </div>
            
            <%-- Fourth row with descr 1 and 2 setting. --%>
            <div id = "Descr1&2" class="row">
                <div id="descr1Box" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class="container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                       <table>
                            <tr>
                                <td>
                                    <b>Benämning</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="taBenamning" rows="2" cols="20" style="resize: none; width:190px; height:100px; Font-Size:11px" ></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="descr2Box" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class="container" style="height:150px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                        <table>
                            <tr>
                                <td>
                                    <b>Intern Text</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="taIntern" rows="2" cols="20" style="resize: none; width:190px; height:100px; Font-Size:11px" ></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            
            <%-- Fifth row with buttons setting. --%>
            <div id="buttonsContainer" class="row" style="background-color:white; margin-top:10px;">
                <div id="buttonsBox" class="col-xs-12 col-sm-4 col-md-4 col-sm-offset-7 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                    <div class="container" style="height:50px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                    <asp:Button ID="Button1" runat="server" Text="Rensa" class="btn btn-default"></asp:Button>
                    <asp:Button ID="Button2" runat="server" Text="Rapportera" class="btn btn-success"></asp:Button>
                    </div>
                </div>
                
            </div>
            
        </div>
        
        <%--Calender and infobox on the right, hide on phone devices--%>
        <div id= "calenderFlexAndInfo" class="col-xs-12 col-sm-4 col-md-6 hidden-xs" style="background-color:white">
            <div id="calenderRow" class="row ">
                <div id="flexBox" class="col-sm-12 col-md-6 hidden-xs" style="background-color:white; border:solid black 1px;">
                    <div style="height:200px;">
                    </div>
                </div>
                <div id="calendarBox" class="col-sm-12 col-md-6 hidden-xs" style="background-color:white; border:solid black 1px;">
                    <div style="height:200px;">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </div>
                </div>
            </div>
            <div id="infoRow" class="row">
                    <div id="infoBox" class="col-sm-12 col-md-12  hidden-xs" style="background-color:white; border:solid black 1px;">
                    <div style="height:200px;">
                    <asp:GridView ID="GridView" runat="server"></asp:GridView>
                    
                    </div>
                    </div>
            </div>
        </div>
    </div>

    </div>
</asp:Content>
