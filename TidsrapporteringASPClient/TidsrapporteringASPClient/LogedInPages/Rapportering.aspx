<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapportering.aspx.cs" Inherits="TidsrapporteringASPClient.Rapportering" Title="Rapportering" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
       <Triggers>
       <asp:AsyncPostBackTrigger ControlID="ddlDebit" EventName="SelectedIndexChanged" />
       <asp:AsyncPostBackTrigger ControlID="ddlAktivitet" EventName="SelectedIndexChanged" />
       <asp:AsyncPostBackTrigger ControlID="ddlKundNamn" EventName="SelectedIndexChanged" />
       <asp:AsyncPostBackTrigger ControlID="ddlOrder" EventName="SelectedIndexChanged" />
       <asp:AsyncPostBackTrigger ControlID="btnSenasteInsattning" EventName="Click" />
       <asp:AsyncPostBackTrigger ControlID="gwRapport" EventName="RowCommand" /> 
       </Triggers>
       <ContentTemplate>
    <div id="basContainer" runat="server" class="container">
      
    <asp:Label ID="pageRapporteringTitel" CssClass="h2" runat="server" />
    <div class="container-fluid" style=" font-family:Arial " >    
       
     
        <div id="newRapport" class="col-xs-12 col-sm-8 col-md-6 col-lg-6" style="background-color:White">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajax:ToolkitScriptManager>
           <%-- First row with preset settings and date setting. --%>
            <div id="dateAndActivity" class="row" style="background-color:white;">
               
                <div id="quickBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White;">
                    <div class="container" style="height:150px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSenaste" runat="server" CausesValidation="False" class="btn btn-default"
                                        onclick="btnSenaste_Click" Text="Senaste"></asp:Button>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSjuk" runat="server" CausesValidation="False" class="btn btn-warning" Text="Sjuk" 
                                        onclick="btnSjuk_Click"></asp:Button>
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
                                            <asp:TextBox class="form-control" 
                                            ID="inputFrDt" runat="server" 
                                            style="font-size:12px; width:140px; height:30px" 
                                            placeholder="YYYYMMDD" required />
                                            
                                                <ajax:CalendarExtender 
                                                ID="CalendarExtenderFrDt" 
                                                runat="server"
                                                TargetControlID="inputFrDt"
                                                Format="yyyyMMdd"
                                                PopupButtonID="btnCalDtFr"
                                                >
                                                </ajax:CalendarExtender>
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
                                            <input type="text" class="form-control" id="inputToDt" runat="server"  style="font-size:12px; width:140px; height:30px" placeholder="YYYYMMDD" required>
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
                                            <table>
                                                <tr>
                                                    <td><p><b>Debitera &nbsp;</b></p></td>
                                                    <td><asp:DropDownList ID="ddlDebit" runat="server" EnableViewState="true" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlDebit_SelectedIndexChanged" Height="25px" Font-Size="11px" Width="50px" ValidateRequestMode="Disabled" ViewStateMode="Enabled">
                                                                <asp:ListItem Value="False" Text="Nej">Nej</asp:ListItem>
                                                                <asp:ListItem Value="True" Text="Ja">Ja</asp:ListItem>
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
                                                <td> <input type="text" class="form-control" runat="server" style="font-size:12px; height:30px;" id="inputFrTid" placeholder="Från" required></td>
                                                <td><b>&nbsp;-&nbsp;</b></td>
                                                <td><input type="text" class="form-control" runat="server" style="font-size:12px; height:30px;" id="inputToTid" placeholder="Till" required></td>
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
                                                <td><input type="text" class="form-control" runat="server" style="font-size:12px; height:30px" id="inputWT" placeholder="Arbet." required></td>
                                                <td>&nbsp;&nbsp;&nbsp;</td>
                                                <td><input type="text" class="form-control" runat="server" style="font-size:12px; height:30px" id="inputFT" placeholder="Faktur." required></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                </div>
                
            </div>
            
            <%-- Thired row with custumer, order, service and projects settings setting. --%>
            <div id="CustOrdServProj" class="row" style="background-color:white; margin-top:10px;">
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
                                    <textarea id="taBenamning" runat="server" rows="2" cols="20" style="resize: none; width:190px; height:100px; Font-Size:11px" ></textarea>
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
                                    <textarea id="taIntern" runat="server" rows="2" cols="20" style="resize: none; width:190px; height:100px; Font-Size:11px" ></textarea>
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
                    <asp:Button ID="btnRensa" runat="server" Text="Rensa" class="btn btn-default" 
                            onclick="btnRensa_Click"></asp:Button>
                    <asp:Button ID="btnRapportera" runat="server" Text="Rapportera" 
                            OnClientClick="return confirm('Vill du skicka rapportern?')" class="btn btn-success" onclick="btnRapportera_Click"></asp:Button>
                    </div>
                </div>
                
            </div>
            
        </div>
       
        
        <%--Calender and infobox on the right, hide on phone devices--%>
        <div id= "calenderFlexAndInfo" class="col-xs-12 col-sm-4 col-md-6 hidden-xs" style="background-color:white; margin-top:-50px;">
            <div id="flexRow" class="row">
                <div id="flexBox" class="col-sm-12 col-md-12 hidden-xs">
                    <div style="height:50px;">
                    <br />
                        <table style="font-size:smaller">
                            <tr>
                                <td style="text-align:right;">
                                    <b>Semester:&nbsp;</b>
                                </td>
                                <td style="text-align:left;">
                                    <asp:Label ID="lblSemester" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="text-align:right;">
                                    <b> &nbsp;Månadsflex:&nbsp;</b>
                                </td>
                                <td style="text-align:left;">
                                    <asp:Label ID="lblFlex" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="text-align:right;">
                                    <b>&nbsp;Total flex:&nbsp;</b>
                                </td>
                                <td style="text-align:left;">
                                    <asp:Label ID="lblTotFlex" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div id="calenderRow" class="row ">
                <div id="calendarBox" class="col-sm-12 col-md-5 hidden-xs">
                    <div style="height:200px;">
                    <asp:Calendar ID="Calender" runat="server" Height="180px" Width="225px" 
                            BackColor="White" BorderColor="#999999" DayNameFormat="Shortest" 
                            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            SelectionMode="DayWeekMonth" 
                            OnSelectionChanged="Calender_SelectionChanged" CellPadding="4" 
                            ondayrender="Calender_DayRender" 
                            onvisiblemonthchanged="Calender_VisibleMonthChanged" NextPrevFormat="ShortMonth" 
                            >
                        <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#CCCC99" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
                        </asp:Calendar>
                    </div>
                </div>
                <div id="fastKeyBox" class="col-sm-12 col-md-7 col-md-push-1 hidden-xs" width="220px">
                <table style="width:220px" >
                           
                            <tr>
                                <td style="padding-left:10px; width:80px;">
                                    <asp:TextBox ID="tbAr" class="form-control" runat="server" 
                                        style="font-size:12px; width:55px; height:25px;" placeholder="YYYY" 
                                        ></asp:TextBox>
                                </td>
                                <td style="width:60px;margin-right:20px">
                                    <asp:DropDownList ID="ddlManad" CssClass="dropdown" style="font-size:12px; width:50px; height:25px;" runat="server">
                                        <asp:ListItem Value="01">Jan</asp:ListItem>
                                        <asp:ListItem Value="02">Feb</asp:ListItem>
                                        <asp:ListItem Value="03">Mars</asp:ListItem>
                                        <asp:ListItem Value="04">Apr</asp:ListItem>
                                        <asp:ListItem Value="05">Maj</asp:ListItem>
                                        <asp:ListItem Value="06">Juni</asp:ListItem>
                                        <asp:ListItem Value="07">Juli</asp:ListItem>
                                        <asp:ListItem Value="08">Aug</asp:ListItem>
                                        <asp:ListItem Value="09">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Okt</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                        
                                    </asp:DropDownList> &nbsp;
                                </td>
                                <td style="width: 70px;">
                                    <asp:LinkButton ID="btnSeMan" class="btn btn-default btn-sm" runat="server" Text="Se månad"
                                        onclick="btnSeMan_Click" CausesValidation="false" 
                                        width="40px" >
                                        <i class="glyphicon glyphicon-search"></i>
                                    </asp:LinkButton> &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                                </tr>
                                
                                <tr >
                                <td colspan="2">
                                    &nbsp;&nbsp;<asp:Button ID="btnSenasteInsattning" runat="server" class="btn btn-info btn-sm" Text="Senaste Insättning" 
                                        onclick="btnSenasteInsattning_Click" CausesValidation="false"></asp:Button>
                                        
                                </td>
                                <td colspan="2">
                                    <asp:UpdateProgress runat="server" id="uppInfo" AssociatedUpdatePanelID="updatePanel">
                                        <ProgressTemplate>
                                            &nbsp;&nbsp;<span class=" glyphicon glyphicon-repeat"></span>Laddar... 
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr style="height:20px;">
                                    <td>
                                        <asp:HiddenField ID="hfActor" runat="server"></asp:HiddenField>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hfRowNr" runat="server"></asp:HiddenField>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hfContract" runat="server"></asp:HiddenField>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hfView" runat="server"></asp:HiddenField>
                                    </td>
                                </tr>
                        </table>
                </div>
            </div>
            <div id="infoRow" class="row">
                    <div id="infoBox" class="col-sm-12 col-md-12  hidden-xs">
                    <div style="height:auto; ">
                   
                    <div id="gridviewBox">
                    
                       <asp:GridView ID="gwRapport" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                            CellPadding="3" ForeColor="Black" AllowPaging="True"
                            GridLines="Vertical" OnRowCommand="gwRapport_RowCommand"
                            OnPageIndexChanging="gwRapport_PageIndexChanging" PageSize="8">
                            <EmptyDataTemplate>
                                <asp:Label runat="server">Det finns inga insatta tidsrader. </asp:Label> 
                            </EmptyDataTemplate>
                            
                           <Columns>
                              
                            <asp:BoundField DataField="agrNo" HeaderText="AgrNo" SortExpression="agrNo" >
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" ></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="30px" font-size="11px" ></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="agrActNo" HeaderText="ActorNr" SortExpression="agrActNo" >
                                <HeaderStyle CssClass="DisplayNoneColum"></HeaderStyle>
                                <ItemStyle CssClass="DisplayNoneColum"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="contract" HeaderText="Avtal" SortExpression="contract" >
                                <HeaderStyle CssClass="DisplayNoneColum"></HeaderStyle>
                                <ItemStyle CssClass="DisplayNoneColum"></ItemStyle>
                            </asp:BoundField>
                            
                            
                            
                            <asp:BoundField DataField="frDt" HeaderText="Datum" 
                                SortExpression="frDt">
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" ></HeaderStyle>
                                <ItemStyle Width="55px" font-size="11px" CssClass="CellPaddingGW" ></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="frTm" HeaderText="Tid fr." 
                                SortExpression="frTm">
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" CssClass=" hidden-sm hidden-md" ></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="35px" font-size="11px" CssClass="hidden-sm hidden-md" ></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="toTm" HeaderText="Tid till" 
                                SortExpression="frTm">
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" CssClass=" hidden-sm hidden-md" ></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="35px" font-size="11px" CssClass="hidden-sm hidden-md" ></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="custName" HeaderText="Kundnamn" SortExpression="custName" >
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" ></HeaderStyle>
                                <ItemStyle Width="100px" font-size="11px" CssClass="CellPaddingGW" ></ItemStyle>
                               </asp:BoundField>
                            <asp:BoundField DataField="ordNr" HeaderText="ordNr" SortExpression="Ordernr">
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" ></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="40px" font-size="11px" ></ItemStyle>
                               </asp:BoundField>
                            <asp:BoundField DataField="activity" HeaderText="Aktivitet" SortExpression="activity">
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" ></HeaderStyle>
                                <ItemStyle Width="80px" font-size="11px" CssClass="CellPaddingGW" ></ItemStyle>
                               </asp:BoundField>
                            <asp:BoundField DataField="workedTime" HeaderText="Arb.tid" SortExpression="workedTime">
                                <HeaderStyle HorizontalAlign="Center" Font-size="12px" CssClass=" hidden-sm" ></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="40px" font-size="11px" CssClass=" hidden-sm" ></ItemStyle>
                               </asp:BoundField>
                            <asp:BoundField DataField="faktureradTime" HeaderText="Fakt.tid" SortExpression="faktureradTime">
                                    <HeaderStyle HorizontalAlign="Center" Font-size="12px" CssClass="hidden-sm hidden-md" ></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="40px" font-size="11px" CssClass="hidden-sm hidden-md"></ItemStyle>
                               </asp:BoundField>
                                
                                
                            
                            
                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                                
                                <ItemTemplate>
                                
                                <asp:LinkButton ID="lbtnEdit" runat="server" class="btn btn-primary btn-xs" 
                                    CommandName="EditRow" 
                                    CausesValidation="false"
                                    ToolTip="Redigera tidsrad">
                                    <i class="glyphicon glyphicon-pencil"></i>
                                 </asp:LinkButton>
                                 
                                 
                                 <asp:LinkButton ID="lbtnContract" runat="server" class="btn btn-default btn-xs" 
                                    CommandName="ContractRow" 
                                    CausesValidation="false"
                                    ToolTip="Läs kontrakt">
                                    <i class="glyphicon glyphicon-list-alt"></i>
                                 </asp:LinkButton>
                                 
                                 <asp:LinkButton ID="lbtnCopy" runat="server" class="btn btn-warning btn-xs" 
                                    CommandName="CopyRow" 
                                    CausesValidation="false"
                                    ToolTip="Kopiera rad till rapportering">
                                    <i class="glyphicon glyphicon-export"></i>
                                 </asp:LinkButton>
                                    
                                    <asp:LinkButton ID="lbtnDelete" class="btn btn-danger btn-xs" runat="server"
                                        CommandName="DeleteRow" CommandArgument='<%# Eval("AgrNo") %>'
                                        CausesValidation="false"
                                        ToolTip="Ta bort tidsraden"
                                        OnClientClick ="return confirm('Är du säker att du vill ha bort tidsraden?');">
                                        <i class="glyphicon glyphicon-trash"></i>
                                    </asp:LinkButton>
                                     
                                </ItemTemplate>
                              </asp:TemplateField>
                        </Columns>
                           <FooterStyle BackColor="#FF9933" BorderColor="#FF9900" />
                           <PagerStyle BackColor="#FFBC79" ForeColor="Black" HorizontalAlign="Center"  />
                           <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                           <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                           <AlternatingRowStyle BackColor="Silver" />
                       
                       
                       </asp:GridView> 
                       
                    </div>
                    <asp:Label ID="lblAgrNo" runat="server" Text="Agr No: "></asp:Label>
                    <asp:Label ID="lblAct" runat="server" Text="Act No: "></asp:Label>
                    <asp:Label ID="lblCon" runat="server" Text="Contract: "></asp:Label>
                    <asp:ObjectDataSource ID="ObjectDataSourceIdag" runat="server" 
                            SelectMethod="getTodaysInserts" 
                            TypeName="TidsrapporteringASPClient.Rapportering">
                    </asp:ObjectDataSource>
                    </div>
                    </div>
            </div>
        </div>
            
        
    </div>

    </div>
    </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
