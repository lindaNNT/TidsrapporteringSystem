<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapportering.aspx.cs"
    Inherits="TidsrapporteringASPClient.Rapportering" Title="Rapportering" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Update Panel--%>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlDebit" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlAktivitet" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlKundNamn" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOrder" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlFavo" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnSenasteInsattning" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gwRapport" EventName="RowCommand" />
        </Triggers>
        <ContentTemplate>
            <div id="basContainer" runat="server" class="container">
              
            <asp:Label ID="pageRapporteringTitel" CssClass="h2" runat="server" />
                <div id = "newInsertInfoBox" class="container-fluid" runat="server" style=" font-family:Arial " >    
                   
                    <%--New inserts--%>
                    <div id="newRapport" runat="server" class="col-xs-12 col-sm-8 col-md-6 col-lg-6" style="background-color:White">
                    
                    <%--ScriptManager--%>
                    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </ajax:ToolkitScriptManager>
                    
                       <%-- First row with date setting. --%>
                        <div id="dateAndActivity"  runat="server" class="row" style="background-color:white;">
                           
                           <%--Box with buttons that have shortcut settings.--%>
                            <div id="quickBox"  runat="server" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White;">
                                <div ID="quickBoxCon" runat="server" class="container" style="height:150px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                                    <br />
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSenaste" 
                                                    runat="server" 
                                                    CausesValidation="False" 
                                                    class="btn btn-default"
                                                    onclick="btnSenaste_Click" Text="Senaste"></asp:Button>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnSjuk" runat="server" 
                                                    CausesValidation="False" 
                                                    class="btn btn-warning" Text="Sjuk" 
                                                    onclick="btnSjuk_Click">
                                                </asp:Button>
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
                                                    Font-Size="11px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlFavo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table> <%-- table ends--%>
                                </div> <%-- quickBoxCon ends--%>
                            </div> <%-- quickBox ends--%>
                            
                            <%--Box with date settings.--%>
                            <div id="dateBox" runat="server" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:white;">
                                <div ID="dateBoxCon" class="container" runat="server" style="height:140px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                                    <label for="inputFrDt" class="control-label " style="text-align:left">
                                        &nbsp; &nbsp; Datum Från</label> 
                                    <div ID="FrDateInput" class="col-sm-12" style="background-color:white">
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
                                                        PopupButtonID="btnCalDtFr" >
                                                    </ajax:CalendarExtender>
                                                </td>
                                                <td>
                                                    <button type="button" id="btnCalDtFr" 
                                                        class="btn btn-default btn-sm" runat="server">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </button>
                                                </td>
                                            </tr>
                                        </table> <%-- table ends--%>
                                    </div> <%-- FrDateInput ends--%>
                                    <br />
                                    <label for="inputToDt" class="control-label " style="text-align:left; margin-top:10px;">
                                        &nbsp; &nbsp; Datum Till</label> 
                                    <div ID="ToDateInput" class="col-sm-12" style="background-color:white">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox class="form-control" 
                                                        id="inputToDt" runat="server"  
                                                        style="font-size:12px; width:140px; height:30px" 
                                                        placeholder="YYYYMMDD" required />
                                                    <ajax:CalendarExtender 
                                                        ID="CalendarExtenderToDt" 
                                                        runat="server"
                                                        TargetControlID="inputToDt"
                                                        Format="yyyyMMdd"
                                                        PopupButtonID="btnCalDtTo" >
                                                    </ajax:CalendarExtender>
                                                </td>
                                                <td>
                                                    <button type="button" id="btnCalDtTo" class="btn btn-default btn-sm" runat="server">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </button>
                                                </td>
                                            </tr>
                                        </table> <%-- table ends--%>
                                    </div> <%-- ToDateInput ends--%>
                                </div> <%-- dateBoxCon ends--%>
                            </div> <%-- dateBox ends--%>
                        </div> <%-- dateAndActivity ends--%>
                        
                        <%-- Second row with activity, art, debit and time setting. --%>
                        <div id="activityTime" class="row" style="background-color:white; margin-top:10px;">
                            
                            <%--Box where the user can choose activity, debit and articel.--%>
                            <div id="activityBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" 
                                style="background-color:white; ">
                                <div class="container" style="height:140px; width:200px; background-color:white; margin-left:auto; margin-right:auto; margin-top:-10px;" >
                                    <div ID="DebitActivityArtBox" >
                                        <table>
                                            <tr>
                                                <td><p><b>Debitera &nbsp;</b></p></td>
                                                <td>
                                                    <div ID="ComboDebit" class="comboBoxInsideModalPopup">
                                                        <ajax:ComboBox ID="ddlDebit" runat="server" EnableViewState="true" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlDebit_SelectedIndexChanged" 
                                                            Height="25px" Font-Size="11px" Width="50px" 
                                                            DropDownStyle="DropDownList" 
                                                            AutoCompleteMode="SuggestAppend"
                                                            CaseSensitive="false"
                                                            RenderMode="Inline"
                                                            ItemInsertLocation="Append"
                                                            ListItemHoverCssClass="ComboBoxListItemHover">
                                                            <asp:ListItem Value="False" Text="Nej" Selected="True">Nej</asp:ListItem>
                                                            <asp:ListItem Value="True" Text="Ja">Ja</asp:ListItem>
                                                        </ajax:ComboBox>
                                                    </div> <%--ComBoDebit ends--%>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td> 
                                                    <label class="control-label" style="text-align: left;">
                                                        Aktivitet <br /> <br />
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div ID="ComboAktivitet" class="comboBoxInsideModalPopup" style="margin-top:45px;">
                                                        <ajax:ComboBox ID="ddlAktivitet" runat="server" Height="25px" 
                                                            Font-Size="11px" Width="170px" AutoPostBack="true" 
                                                            OnSelectedIndexChanged="ddlAktivitet_SelectedIndexChanged"
                                                            DropDownStyle="DropDownList" 
                                                            AutoCompleteMode="SuggestAppend"
                                                            CaseSensitive="false"
                                                            RenderMode="Inline"
                                                            ItemInsertLocation="Append"
                                                            ListItemHoverCssClass="ComboBoxListItemHover">
                                                        </ajax:ComboBox>
                                                    </div> <%--ComboAktivitet ends--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="control-label" style="text-align: left;">
                                                        Artikel
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div ID="ComboArt" class="artInsideModalPopup" style="margin-top:90px;">
                                                        <ajax:ComboBox ID="ddlArt" runat="server" Height="25px" 
                                                            Font-Size="10px" Width="170px" AutoPostBack="True"
                                                            DropDownStyle="DropDownList" 
                                                            AutoCompleteMode="SuggestAppend"
                                                            CaseSensitive="false"
                                                            RenderMode="Inline"
                                                            ItemInsertLocation="Append"
                                                            ListItemHoverCssClass="ComboBoxListItemHover">
                                                        </ajax:ComboBox>
                                                    </div> <%--ComboArt ends--%>
                                                </td>
                                            </tr>
                                        </table><%--table ends--%>
                                    </div> <%-- DebitActivityArtBox ends--%>
                                </div> <%-- container ends--%>
                            </div> <%-- activityBox ends--%>
                            
                            <%--Boxes for timeinput.--%>
                            <div id="timeBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:white">
                                <div ID="TimeWTFTbox" class="container" style="height:140px; width:220px; background-color:white; margin-left:auto; margin-right:auto;" >
                                    <div ID="TimeLabelInput" class="col-xs-12 col-sm-12 col-md-12">
                                        <div id="timeLabel" class="span12">
                                            <label for="inputFrTid" class="control-label" style="text-align:left;">
                                                Tid (HHMM)</label> 
                                        </div> <%-- timeLabel ends--%>
                                        <div id="TimeInput" class="span12">
                                            <table ID="tbTime">
                                                <tr ID="tbRow">
                                                    <td ID="tbfrtid"> 
                                                        <input type="text" class="form-control" 
                                                            onkeyup="return Calculate();" 
                                                            onblur="return Calculate();"
                                                            runat="server" style="font-size:12px; 
                                                            height:30px;" id="inputFrTid"
                                                            ValidationGroup="INSERT"
                                                            placeholder="Från" required="required" />
                                                    </td>
                                                        
                                                    <td><b>&nbsp;-&nbsp;</b></td>
                                                        
                                                <td>
                                                    <input type="text" class="form-control"  
                                                        onkeyup="return Calculate();"
                                                        onblur="return Calculate();"
                                                        ValidationGroup="INSERT"
                                                        runat="server" style="font-size:12px; 
                                                        height:30px;" id="inputToTid" 
                                                        placeholder="Till" required="required" />
                                                </td>
                                            </tr>
                                            </table> <%-- table ends--%>
                                            
                                            <%--JavaScript function for time calulation--%>
                                            <script type="text/javascript">
                                function Calculate() {

                                    // total
                                    var total = 0;

                                    var frTimeTableRow = $('#ctl00_MainContent_inputFrTid'); //Find the input-controll
                                    var toTimeTableRow = $('#ctl00_MainContent_inputToTid');
            
                                    var frTime = frTimeTableRow[0].value; // Get the value (string)
                                    var toTime = toTimeTableRow[0].value;
                                    var inputFr = parseInt(frTime); // convert to int.
                                    var inputTo = parseInt(toTime);

                                    var inputFrHour = parseInt(frTime.substring(0, 2)); // Extract  hours
                                    var inputFrMin = frTime.substring(2); // Extract minuts

                                    var inputToHour = parseInt(toTime.substring(0, 2));
                                    var inputToMin = toTime.substring(2);

                                    if (frTime.length != 0 || toTime.length != 0) { //Verify that the strings is not empty.
                                        if (!isNaN(inputFr) && !isNaN(inputTo)) // Look if its null or invalid number.
                                        {
                                            if (frTime.length == 4 && toTime.length == 4) // Actived if there is 4 char.
                                            {
                                                var hour = 0;
                                                var totalMin = 0;
                                                if (inputFrHour < inputToHour && inputFrHour <= 24 && inputToHour <= 24) // See if toHour is bigger than frHour
                                                {
                                                    hour = inputToHour - inputFrHour;
                                                }
                                                if (inputFrMin != "00" || inputToMin != "00") // See if min is "00"
                                                {
                                                    var frMin = 60 - parseInt(inputFrMin);
                                                    totalMin = ((frMin + parseInt(inputToMin)) / 60) - 1;
                                                }
                                                total = hour + totalMin;
                                                total = total.toFixed(2);
                                                   $('#ctl00_MainContent_inputWT').val(total.toString());
//                                                document.getElementById('<%=inputWT%>').value = total.toString();
                                            }
                                        }
                                    }
                                }
                            </script>
                                            
                                        </div> <%-- TimeInput ends--%>
                                    </div> <%-- TimeLabelInput ends--%>
                                    <div id="WT&FTbox" class="col-xs-12 col-sm-12 col-md-12">
                                        <div id="WT&FTlabel" class="span2">
                                            <label for="inputWT" class="control-label" 
                                                style="text-align:left; font-size:13px; 
                                                margin-top:20px;">
                                                Arbetad & fakturerad tid</label> 
                                        </div> <%-- WT&FTlabel ends--%>
                                        <div id="WT&FTinputBox" class="span12">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="text" ValidationGroup="INSERT"
                                                            class="form-control" runat="server" 
                                                            style="font-size:12px; height:30px" 
                                                            id="inputWT" ClientID="inputWT"
                                                            placeholder="Arbet." required="required" />
                                                     </td>
                                                    
                                                    <td>&nbsp;&nbsp;&nbsp;</td>
                                                    
                                                    <td><input type="text" ValidationGroup="INSERT"
                                                        class="form-control" runat="server" 
                                                        style="font-size:12px; height:30px" id="inputFT" 
                                                        placeholder="Faktur." required="required" />
                                                    </td>
                                                </tr>
                                            </table> <%-- table ends--%>
                                        </div> <%-- WT&FTinputBox ends--%>
                                    </div> <%-- WT&FTbox ends--%>
                                </div> <%-- TimeWTFTbox ends--%>
                            </div> <%-- timeBox ends--%>
                        </div> <%-- activityTime ends--%>
                        
                        <%-- Thired row with custumer, order, service and projects settings setting. --%>
                        <div id="CustOrdServProj" class="row" style="background-color:white; margin-top:10px;">
                            
                            <%--Boxes where user can choose customer and order.--%>
                            <div id="CustOrderBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                                <div class="container" style="height:120px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                                    
                                    <table>
                                        <tr>
                                            <td>
                                                <b>Kundnamn</b> <br /> <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div ID="ComboCust" class="custBoxInsideModalPopup" style="margin-top:25px;">
                                                    <ajax:ComboBox ID="ddlKundNamn" runat="server" AutoPostBack="true" 
                                                        Height="25px" Font-Size="11px" Width="170px" 
                                                        OnSelectedIndexChanged="ddlKundNamn_SelectedIndexChanged"
                                                        DropDownStyle="DropDownList" 
                                                        AutoCompleteMode="SuggestAppend"
                                                        CaseSensitive="false"
                                                        RenderMode="Inline"
                                                        ItemInsertLocation="Append"
                                                        ListItemHoverCssClass="ComboBoxListItemHover">
                                                    </ajax:ComboBox>
                                                </div> <%--ComboCust ends--%>
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
                                                <div ID="ComboOrder" class="comboBoxInsideModalPopup" style="margin-top:85px;">
                                                    <ajax:ComboBox ID="ddlOrder" runat="server" AutoPostBack="true" 
                                                        Height="25px" Font-Size="11px" Width="170px"
                                                        OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged"
                                                        DropDownStyle="DropDownList" 
                                                        AutoCompleteMode="SuggestAppend"
                                                        CaseSensitive="false"
                                                        RenderMode="Inline"
                                                        ItemInsertLocation="Append"
                                                        ListItemHoverCssClass="ComboBoxListItemHover">
                                                    </ajax:ComboBox>
                                                </div> <%--ComboOrder ends--%>
                                            </td>
                                        </tr>
                                    </table> <%-- table ends--%>
                                </div> <%-- container ends--%>
                            </div> <%-- CustOrderBox ends--%>
                            
                            <%--Boxes where user can choose service and projects.--%>
                            <div id="serviceProjBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                                <div class="container" style="height:120px; width:200px; background-color:white; margin-left:auto; margin-right:auto;" >
                                    <table>
                                        <tr>
                                            <td>
                                                <b>Service</b><br /> <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div ID="ComboService" class="comboBoxInsideModalPopup" style="margin-top:25px;">
                                                    <ajax:ComboBox ID="ddlService"  AutoPostBack="true"  runat="server" 
                                                        Height="25px" Font-Size="11px" Width="170px"
                                                        DropDownStyle="DropDownList" 
                                                        AutoCompleteMode="SuggestAppend"
                                                        CaseSensitive="false"
                                                        RenderMode="Inline"
                                                        ItemInsertLocation="Append"
                                                        ListItemHoverCssClass="ComboBoxListItemHover">
                                                    </ajax:ComboBox>
                                                </div> <%--ComboService ends--%>
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
                                                <div ID="ComboProj" class="custBoxInsideModalPopup" style="margin-top:85px;">
                                                    <ajax:ComboBox ID="ddlProj"  AutoPostBack="true" runat="server" 
                                                        Height="25px" Font-Size="11px" Width="170px"
                                                        DropDownStyle="DropDownList" 
                                                        AutoCompleteMode="SuggestAppend"
                                                        CaseSensitive="false"
                                                        RenderMode="Inline"
                                                        ItemInsertLocation="Append"
                                                        ListItemHoverCssClass="ComboBoxListItemHover">
                                                    </ajax:ComboBox>
                                                </div> <%--ComboProj ends--%>
                                            </td>
                                        </tr>
                                    </table> <%-- table ends--%>
                                </div> <%-- container ends--%>
                            </div> <%-- serviceProjBox ends--%>
                        </div> <%-- CustOrdServProj ends--%>
                        
                        <%-- Fourth row with descr 1 and 2 setting. --%>
                        <div id = "Descr1&2" class="row">
                            <%--Boxes where user can write in benämning-text.--%>
                            <div id="descr1Box" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                                <div class="container" style="height:120px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                                   <table>
                                        <tr>
                                            <td>
                                                <b>Benämning</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <textarea id="taBenamning" 
                                                    runat="server" 
                                                    rows="2" cols="20" 
                                                    style="resize: none; width:190px; height:80px; Font-Size:11px" 
                                                    placeholder="Max 60 tecken"
                                                    ></textarea>
                                            </td>
                                        </tr>
                                    </table> <%-- table ends--%>
                                </div> <%-- container ends--%>
                            </div> <%-- descr1Box ends--%>
                           
                            <%--Boxes where user can write in intern-text.--%>
                            <div id="descr2Box" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" style="background-color:White">
                                <div class="container" style="height:120px; width:200px; background-color:White; margin-left:auto; margin-right:auto;" >
                                    <table>
                                        <tr>
                                            <td>
                                                <b>Intern Text</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <textarea id="taIntern" 
                                                    runat="server" rows="2" 
                                                    cols="20" 
                                                    style="resize: none; width:190px; height:80px; Font-Size:11px" 
                                                    placeholder="Max 80 tecken"></textarea>
                                            </td>
                                        </tr>
                                    </table> <%-- table ends--%>
                                </div> <%-- container ends--%>
                            </div> <%-- descr2Box ends--%>
                        </div> <%--Descr1&2 ends--%>
                        
                        <ajax:Accordion 
                        ID="AccordionNewTimeLine" 
                        runat=server
                        SelectedIndex="-1"
                        HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected"
                        ContentCssClass="accordionContent"
                        AutoSize="None"
                        FadeTransitions="true"
                        TransitionDuration="150"
                        FramesPerSecond="40"
                        RequireOpenedPane="false"
                        SuppressHeaderPostbacks="true">
                        <Panes>
                            <ajax:AccordionPane runat="server">
                                <Header>
                                    <asp:Button runat="server"  class="btn btn-info btn-sm" Text="Ange Memo & Miltal"></asp:Button> 
                                </Header>
                                <Content>
                                <%-- Extra row with Memo and miltal setting. --%>
                                     <div id = "Memo&Miltal" class="row" style="height:130px; width:500px; background-color=White
                                                ; border-top: solid 2px black ; border-bottom: solid 1px black" >
                                <%--Boxes where user can write in Memo-text.--%>
                                <div id="memoBox" class="col-xs-12 col-sm-6 col-md-6" style="background-color:White">
                                    <div class="container" style="height:110px; width:185px; background-color:White; margin-left:auto; margin-right:auto;" >
                                       <table>
                                            <tr>
                                                <td>
                                                    <b>Memo</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <textarea id="taMemo" 
                                                        runat="server" 
                                                        rows="2" cols="20" 
                                                        style="resize: none; width:170px; height:80px; Font-Size:11px" 
                                                        placeholder="Max 60 tecken"
                                                        ></textarea>
                                                </td>
                                            </tr>
                                        </table> <%-- table ends--%>
                                    </div> <%-- container ends--%>
                                </div> <%-- memoBox ends--%>
                               
                                <%--Boxes where user can write in Miltal-text.--%>
                                <div id="milBox" class="col-xs-12 col-sm-6 col-md-6" style="background-color:White">
                                    <div class="container" style="height:110px; width:185px; background-color:White; margin-left:auto; margin-right:auto;" >
                                        <table>
                                            <tr>
                                                <td>
                                                    <b>Miltal</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <textarea id="taMil" 
                                                        runat="server" rows="2" 
                                                        cols="20" 
                                                        style="resize: none; width:170px; height:80px; Font-Size:11px" 
                                                        placeholder="Miltal"></textarea>
                                                </td>
                                            </tr>
                                        </table> <%-- table ends--%>
                                    </div> <%-- container ends--%>
                                </div> <%-- milBox ends--%>
                            </div> <%--Memo&Miltal ends--%>
                                </Content>
                            </ajax:AccordionPane>
                        </Panes>
                    </ajax:Accordion>
                        
                        <%-- Fifth row with buttons setting. --%>
                        <div id="buttonsContainer" class="row" style="background-color:white; margin-top:10px;">
                            <div id="ValidationBox" class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" 
                                style="background-color:White">
                                <div class="container" style="height:150px; width:250px; background-color:White; margin-left:auto; margin-right:auto;" >
                                                                                <%--Date from validation--%>
                                    <asp:RequiredFieldValidator 
                                        ValidationGroup="INSERT"
                                        id="RFVfrDate"
                                        runat="server" 
                                        EnableClientScript="true"
                                        ErrorMessage="Datum från krävs."
                                        ControlToValidate="inputFrDt"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVfrDate"
                                        EnableClientScript="true"
                                        ErrorMessage="Datum från måste vara nummer mellan 0-9 och exakt 8 siffror(YYYYMMDD)"
                                        ControlToValidate="inputFrDt"
                                        ValidationExpression="\d{8}"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVfrDateValidation"
                                        EnableClientScript="true"
                                        ErrorMessage="Datum från har angets fel, ska vara (YYYYMMDD)"
                                        ControlToValidate="inputFrDt"
                                        ValidationExpression="^(((\d{4})(0[13578]|10|12)(0[1-9]|[12][0-9]|3[01]))|((\d{4})(0[469]|11)([0][1-9]|[12][0-9]|30))|((\d{4})(02)(0[1-9]|1[0-9]|2[0-8]))|(([02468][048]00)(02)(29))|(([13579][26]00) (02)(29))|(([0-9][0-9][0][48])(02)(29))|(([0-9][0-9][2468][048])(02)(29))|(([0-9][0-9][13579][26])(02)(29))|(00000000)|(88888888)|(99999999))?$"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Date to validation--%>
                                    <asp:RequiredFieldValidator 
                                        ValidationGroup="INSERT"
                                        id="RFVtoDate"
                                        runat="server" 
                                        EnableClientScript="true"
                                        ErrorMessage="Datum till krävs."
                                        ControlToValidate="inputToDt"
                                        Text=""
                                        ForeColor="Red" 
                                        SetFocusOnError="true"
                                        Display="None">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVtoDate"
                                        EnableClientScript="true"
                                        ErrorMessage="Datum till måste vara nummer mellan 0-9 och exakt 8 siffror(YYYYMMDD)"
                                        ControlToValidate="inputToDt"
                                        ValidationExpression="\d{8}"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVtoDateValidation"
                                        EnableClientScript="true"
                                        ErrorMessage="Datum till har angets fel, ska vara (YYYYMMDD)"
                                        ControlToValidate="inputToDt"
                                        ValidationExpression="^(((\d{4})(0[13578]|10|12)(0[1-9]|[12][0-9]|3[01]))|((\d{4})(0[469]|11)([0][1-9]|[12][0-9]|30))|((\d{4})(02)(0[1-9]|1[0-9]|2[0-8]))|(([02468][048]00)(02)(29))|(([13579][26]00) (02)(29))|(([0-9][0-9][0][48])(02)(29))|(([0-9][0-9][2468][048])(02)(29))|(([0-9][0-9][13579][26])(02)(29))|(00000000)|(88888888)|(99999999))?$"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Time from validation--%>
                                    <asp:RequiredFieldValidator 
                                        ValidationGroup="INSERT"
                                        id="RFVfrTime"
                                        runat="server" 
                                        EnableClientScript="true"
                                        ErrorMessage="Tid från krävs."
                                        ControlToValidate="inputFrTid"
                                        Text=""
                                        ForeColor="Red" 
                                        SetFocusOnError="true"
                                        Display="None">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVfrTime"
                                        EnableClientScript="true"
                                        ErrorMessage="Tid från måste anges i nummer mellan 0-9 och exakt 4 siffror(HHMM)"
                                        ControlToValidate="inputFrTid"
                                        ValidationExpression="^(20|21|22|23|24|[0-1]\d)[0-5]\d$"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Time to validation--%>
                                    <asp:RequiredFieldValidator 
                                        ValidationGroup="INSERT"
                                        id="RFVtoTime"
                                        runat="server" 
                                        EnableClientScript="true"
                                        ErrorMessage="Tid till krävs."
                                        ControlToValidate="inputToTid"
                                        Text=""
                                        ForeColor="Red" 
                                        SetFocusOnError="true"
                                        Display="None">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVtoTime"
                                        EnableClientScript="true"
                                        ErrorMessage="Tid till måste anges i nummer mellan 0-9 och exakt 4 siffror(HHMM)"
                                        ControlToValidate="inputToTid"
                                        ValidationExpression="^(20|21|22|23|24|[0-1]\d)[0-5]\d$"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Worked time validation--%>
                                    <asp:RequiredFieldValidator 
                                        ValidationGroup="INSERT"
                                        id="RFVwt"
                                        runat="server" 
                                        EnableClientScript="true"
                                        ErrorMessage="Arbetad tid krävs."
                                        ControlToValidate="inputWT"
                                        Text=""
                                        ForeColor="Red" 
                                        SetFocusOnError="true"
                                        Display="None">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVwt"
                                        EnableClientScript="true"
                                        ErrorMessage="Arbetad tid anges i siffror"
                                        ControlToValidate="inputWT"
                                        ValidationExpression="^(\d|,)*\.?\d*$"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Fakturerad tid validation--%>
                                    <asp:RequiredFieldValidator                
                                        ValidationGroup="INSERT"
                                        id="RFVft"
                                        runat="server" 
                                        EnableClientScript="true"
                                        ErrorMessage="Fakturerad tid krävs."
                                        ControlToValidate="inputFT"
                                        Text=""
                                        ForeColor="Red" 
                                        SetFocusOnError="true"
                                        Display="None">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVft"
                                        EnableClientScript="true"
                                        ErrorMessage="Fakturerad tid anges i siffror"
                                        ControlToValidate="inputFT"
                                        ValidationExpression="^(\d|,)*\.?\d*$"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Benämning validation--%>   
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVbenamning"
                                        EnableClientScript="true"
                                        ErrorMessage="Benämning text får endast vara mellan 0-60 tecken."
                                        ControlToValidate="taBenamning"
                                        ValidationExpression="\d{0,60}"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Intern Text validation--%>   
                                    <asp:RegularExpressionValidator 
                                        runat="server"
                                        ValidationGroup="INSERT"
                                        id="REVintern"
                                        EnableClientScript="true"
                                        ErrorMessage="Intern text text får endast vara mellan 0-80 tecken."
                                        ControlToValidate="taIntern"
                                        ValidationExpression="\d{0,80}"
                                        Text=""
                                        ForeColor="Red"
                                        SetFocusOnError="true" 
                                        Display="None">
                                    </asp:RegularExpressionValidator>
                                    
                                                                                <%--Validation summary--%>
                                    <asp:ValidationSummary ValidationGroup="INSERT" ID="VSInput" runat="server" 
                                        Font-Size="Small"></asp:ValidationSummary>
                                </div> <%--container ends--%>
                            </div> <%-- ValidationBox ends--%>
                            
                            <div id="buttonsBox" 
                                class="col-xs-12 col-sm-6 col-md-6 col-xs-pull-1 col-sm-pull-1 col-md-pull-1 col-lg-pull-1" 
                                style="background-color:White">
                                <div class="container" style="height:50px; width:200px; 
                                    background-color:White; margin-left:auto; margin-right:auto;" >
                                    <asp:Button ID="btnRensa" runat="server" Text="Rensa" class="btn btn-default" 
                                            onclick="btnRensa_Click">
                                    </asp:Button>
                                    
                                    <asp:Button ID="btnRapportera" ValidationGroup="INSERT" runat="server" Text="Rapportera" 
                                            OnClientClick="return confirm('Vill du spara detta?')" 
                                            class="btn btn-success" onclick="btnRapportera_Click">
                                    </asp:Button>
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSparaFavorit" 
                                            runat="server" 
                                            Text="Spara till Favoriter"
                                            class="btn btn-info" 
                                            width="170px"
                                            onclick="btnSparaFavorit_Click">
                                    </asp:Button>
                                    <br />
                                    <br />
                                    <asp:Button ID="btnTaBortFavorit" 
                                            runat="server" 
                                            Text="Radera Favorit"
                                            class="btn btn-default btn-sm" 
                                            OnClientClick="return confirm('Vill du ta bort detta?')" 
                                            onclick="btnTaBort_Click">
                                    </asp:Button>
                                    <asp:Panel runat="server" ID="panelFavorit" CssClass="favoritPopUp">
                                        <div ID="favoBoxInfo" class="row">
                                            <div ID="favoInfo" class="col-md-12">
                                                <b>Debitera: </b>
                                                <asp:Label id="lblFavoDebit" runat="server" Text="Tom"></asp:Label>
                                                <br />
                                                <b>Aktivitet: </b>
                                                <asp:Label id="lblFavoActivity" runat="server" Text="Tom"></asp:Label>
                                                <br />
                                                <b>Artikel: </b>
                                                <asp:Label id="lblFavoArt"  runat="server" Text="Tom"></asp:Label>
                                                <asp:HiddenField ID="hfArticel" runat="server"></asp:HiddenField>
                                                <br />
                                                <b>Kundnamn: </b>
                                                <asp:Label  id="lblFavoCust" runat="server" Text="Tom"></asp:Label>
                                                <br />
                                                <b>Order: </b>
                                                <asp:Label id="lblFavoOrder" runat="server" Text="Tom"></asp:Label>
                                                <asp:HiddenField ID="hfOrder" runat="server"></asp:HiddenField>
                                                <br />
                                                <b>Service: </b>
                                                <asp:Label id="lblFavoService" runat="server" Text="Tom"></asp:Label>
                                                <asp:HiddenField ID="hfService" runat="server"></asp:HiddenField>
                                                <br />
                                                <b>Projekt: </b>
                                                <asp:Label id="lblFavoProj" runat="server" Text="Tom"></asp:Label>
                                                <asp:HiddenField ID="hfProj" runat="server"></asp:HiddenField>
                                                <br />
                                                <b>Benämning: </b>
                                                <asp:Label id="lblFavoBen" runat="server" Text="Tom"></asp:Label>
                                                <br />
                                                <b>Intern text: </b>
                                                <asp:Label id="lblFavoIntern" runat="server" Text="Tom"></asp:Label>
                                                <br />
                                                <b>Memo: </b>
                                                <asp:Label id="lblFavoMemo" runat="server" Text="Tom"></asp:Label>
                                                <br />
                                            </div>
                                        </div>
                                        
                                        <div ID="favoBoxInput" class="row" style="height:60px">
                                            <div ID="favoBox" class="col-md-12" style="margin-left:44%">
                                                <asp:Label ID="lblFavoName" runat="server" 
                                                    Font-Bold="True" Text="Ange favoritnamn">
                                                </asp:Label>
                                                <br />
                                                <asp:TextBox ID="tbFavoName" runat="server" placeholder="Favoritnamn">
                                                </asp:TextBox>
                                            </div>                                            
                                        </div>
                                        
                                        <div ID="favoConfirm" class="row">
                                            <div ID="favobtn" class="col-md-12" style="margin-left:47%">
                                                <asp:Button ID="btnFavoCancel" class="btn btn-warning" runat="server" Text="Avbryt">
                                                </asp:Button>
                                                <asp:Button ID="btnFavoSubmit" 
                                                    class="btn btn-success" 
                                                    runat="server" Text="Spara" 
                                                    OnClientClick="return confirm('Vill du spara inställningarna?')"
                                                    onclick="btnFavoSubmit_Click">
                                                </asp:Button>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:HiddenField ID="hfPopUpFavo" runat="server"></asp:HiddenField>
                                    <ajax:ModalPopupExtender ID="mpeFavo" runat="server"
                                        TargetControlID="hfPopUpFavo"
                                        PopupControlID="panelFavorit"
                                        BackgroundCssClass="modalBackground" 
                                        DropShadow="true" 
                                        CancelControlID="btnFavoCancel">
                                     </ajax:ModalPopupExtender>       
                                </div> <%--container ends--%>
                            </div> <%--buttonsBox ends--%>
                        </div> <%--buttonsContainer ends--%>
                    
                    </div> <%--newRapport ends--%>
                   
                    <%--Calender and gridview of timelines--%>
                    <div id= "calenderFlexAndInfo" class="col-xs-12 col-sm-4 col-md-6 hidden-xs" style="background-color:white; margin-top:-50px;">
                        <%--Box where user can see flex and holidays--%>
                        <div id="flexRow" class="row">
                            <div id="flexBox" class="col-sm-12 col-md-12 hidden-xs">
                                <div ID="flexTable" style="height:50px;">
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
                                    </table> <%-- table ends--%>
                                </div> <%-- flexTable ends--%>
                            </div> <%-- flexBox ends--%>
                        </div> <%-- flexRow ends--%>
                        
                        <%--A row with calendar--%>
                        <div id="calenderRow" class="row ">
                            <div id="calendarBox" class="col-sm-12 col-md-5 hidden-xs" style="height:200px;">
                                <asp:Calendar ID="Calender" runat="server" Height="180px" Width="225px" 
                                    BackColor="White" BorderColor="#999999" DayNameFormat="Shortest" 
                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                                    SelectionMode="DayWeekMonth" 
                                    OnSelectionChanged="Calender_SelectionChanged" CellPadding="4" 
                                    ondayrender="Calender_DayRender" 
                                    onvisiblemonthchanged="Calender_VisibleMonthChanged" NextPrevFormat="ShortMonth">
                                    
                                    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#CCCC99" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
                                </asp:Calendar>
                            </div> <%-- calendarBox ends--%>
                            <div id="fastKeyBox" class="col-sm-12 col-md-7 col-md-push-1 hidden-xs" width="220px">
                                <table style="width:220px" >
                                    <tr>
                                        <td style="padding-left:10px; width:80px;">
                                            <asp:TextBox ID="tbAr" class="form-control" runat="server" 
                                                style="font-size:12px; width:55px; 
                                                height:25px;" placeholder="YYYY"></asp:TextBox>
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
                                                onclick="btnSeMan_Click" CausesValidation="false" width="40px" >
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
                                </table> <%-- table ends--%>
                            </div> <%-- fastKeyBox ends--%>
                        </div> <%-- calenderRow ends--%>
                        
                        <%--Gridview--%>
                        <div id="infoRow" class="row">
                            <div id="infoBox" class="col-sm-12 col-md-12  hidden-xs">
                                <div id="gridviewBox">
                                   <asp:GridView ID="gwRapport" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                        CellPadding="3" ForeColor="Black" AllowPaging="True"
                                        GridLines="Vertical" OnRowCommand="gwRapport_RowCommand"
                                        OnPageIndexChanging="gwRapport_PageIndexChanging" PageSize="8" 
                                        Font-Bold="False">
                                        
                                        <%--Gridview if empty--%>
                                        <EmptyDataTemplate>
                                            <asp:Label runat="server">Det finns inga insatta tidsrader. </asp:Label> 
                                        </EmptyDataTemplate>
                                        
                                       <Columns>
                                          <%--Gridview BoundFields: agrNo, AgrActNo and contract--%>
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
                                        
                                        <%--Gridview BoundField: Dates, Times, Customer and Order--%>
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
                                            
                                        <%--Gridview TemplateField: buttons--%>
                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                                            <ItemTemplate>
                                                <%--Gridview: Editbutton--%>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" class="btn btn-primary btn-xs" 
                                                    CommandName="EditRow" 
                                                    CausesValidation="false"
                                                    ToolTip="Redigera tidsrad">
                                                    <i class="glyphicon glyphicon-pencil"></i>
                                                 </asp:LinkButton>
                                                 
                                                 <%--Gridview: Contractbutton--%>
                                                 <asp:LinkButton ID="lbtnInfo" runat="server" class="btn btn-default btn-xs" 
                                                    CommandName="InfoRow" 
                                                    CausesValidation="false"
                                                    ToolTip="Läs mer">
                                                    <i class="glyphicon glyphicon-list-alt"></i>
                                                 </asp:LinkButton>
                                                 <asp:UpdatePanel ID="UpdatePanelPopUp" runat="server">
                                                    <Triggers>
                                                        
                                                    </Triggers>
                                                    <ContentTemplate>
                                                         <asp:Panel ID="infoPopUp" CssClass="popup"  runat="server">
                                                            <div ID="AgrNoPopUpDiv" class="row">
                                                                <div ID="AgrNoPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_AgrNoPopUp" runat="server"><b>AgrNo:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="AgrNoPopUp" runat="server"></asp:Label>
                                                                </div> <%--AgrNoPopUpInfo ends--%>
                                                            </div> <%--AgrNoPopUpDiv ends--%>
                                                            
                                                            <div ID="DatePopUpDiv" class="row">       
                                                                <div ID="DatePopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_DatePopUp" runat="server"><b>Datum:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="DatePopUp" runat="server"></asp:Label>
                                                                </div> <%--DatePopUpInfo ends--%>
                                                            </div> <%--DatePopUpDiv ends--%>
                                                            
                                                            <div class="row">      
                                                                <div style="height:10px" class="col-md-12"></div> <%--spaceDiv--%>
                                                            </div> <%--spaceRow--%>
                                                            
                                                            <div ID="ActPopUpDiv" class="row">    
                                                                <div ID="ActivityPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_ActivityPopUp" runat="server"><b>Aktivitet:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="ActivityPopUp" runat="server"></asp:Label>
                                                                </div> <%--ActivityPopUpInfo ends--%>
                                                            </div> <%--ActPopUpDiv ends--%>
                                                            
                                                            <div ID="ArtPopUpDiv" class="row">        
                                                                <div ID="ArtPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_ArtPopUp" runat="server"><b>Artikel:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="ArtPopUp" runat="server"></asp:Label>
                                                                </div> <%--ArtPopUpInfo ends--%>
                                                            </div> <%--ArtPopUpDiv ends--%>
                                                           
                                                            <div class="row">     
                                                                <div style="height:10px" class="col-md-12"></div> <%--spaceDiv--%>
                                                            </div> <%--spaceRiw--%>
                                                           
                                                            <div ID="DebitPopUpDiv" class="row">     
                                                                <div ID="DebitPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_DebitPopUp" runat="server"><b>Debit:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="DebitPopUp" runat="server"></asp:Label>
                                                                </div> <%--DebitPopUpInfo ends--%>
                                                            </div> <%--DebitPopUpDiv ends--%>
                                                            
                                                            <div ID="TimePopUpDiv" class="row">      
                                                                <div ID="TimePopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_TimePopUp" runat="server"><b>Tid:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="TimePopUp" runat="server"></asp:Label>
                                                                </div> <%--TimePopUpInfo ends--%>
                                                            </div> <%--TimePopUpDiv ends--%>
                                                           
                                                            <div ID="WTPopUpDiv" class="row">       
                                                                <div ID="WTPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_WTPopUp" runat="server"><b>Arbeted tid:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="WTPopUp" runat="server"></asp:Label>
                                                                </div> <%--WTPopUpInfo ends--%>
                                                            </div> <%--WTPopUpDiv ends--%>
                                                           
                                                            <div ID="FTPopUpDiv" class="row">     
                                                                <div ID="FTPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_FTPopUp" runat="server"><b>Fakturerad tid:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="FTPopUp" runat="server"></asp:Label>
                                                                </div> <%--FTPopUpInfo ends--%>
                                                            </div> <%--FTPopUpDiv--%>
                                                           
                                                            <div class="row">     
                                                                <div style="height:10px" class="col-md-12"></div> <%--spaceDiv--%>
                                                            </div> <%--spaceRow--%>
                                                           
                                                            <div ID="CustPopUpDiv" class="row">     
                                                                <div ID="CustPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_CustPopUp" runat="server"><b>Kundnamn:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="CustPopUp" runat="server"></asp:Label>
                                                                </div> <%--CustPopUpInfo ends--%>
                                                            </div> <%--CustPopUpDiv ends--%>
                                                           
                                                            <div ID="OrderPopUpDiv" class="row">     
                                                                <div ID="OrderPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_OrderPopUp" runat="server"><b>Order:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="OrderPopUp" runat="server"></asp:Label>
                                                                </div> <%--OrderPopUpInfo ends--%>
                                                            </div> <%--OrderPopUpDiv ends--%>
                                                           
                                                            <div ID="ContractPopUpDiv" class="row">     
                                                                <div ID="ContractPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_ContractPopUp" runat="server"><b>Kontrakt Nr:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="ContractPopUp" runat="server"></asp:Label>
                                                                </div> <%--ContractPopUpInfo ends--%>
                                                            </div> <%--ContractPopUpDiv ends--%>
                                                           
                                                            <div ID="ServicePopUpDiv" class="row">     
                                                                <div ID="ServicePopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_ServicePopUp" runat="server"><b>Service: &nbsp;</b></asp:Label>
                                                                    <asp:Label ID="ServicePopUp" runat="server"></asp:Label>
                                                                </div> <%--ServicePopUpInfo ends--%>
                                                            </div> <%--ServicePopUpDiv ends--%>
                                                           
                                                            <div class="row">     
                                                                <div style="height:10px" class="col-md-12"></div> <%--spaceDiv--%>
                                                            </div> <%--spaceRow--%>
                                                           
                                                            <div ID="ProjPopUpDiv" class="row">     
                                                                <div ID="ProjPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_ProjPopUp" runat="server"><b>Projekt:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="ProjPopUp" runat="server"></asp:Label>
                                                                </div> <%--ProjPopUpInfo ends--%>
                                                            </div> <%--ProjPopUpDiv ends--%>
                                                           
                                                            <div class="row">     
                                                                <div style="height:10px" class="col-md-12"></div> <%--spaceDiv--%>
                                                            </div> <%--spaceRow--%>
                                                           
                                                            <div ID="BenamningPopUpDiv" class="row">     
                                                                <div ID="BenamningPopUpInfo" class="col-md-12">
                                                                    <asp:Label ID="_BenamningPopUp" runat="server"><b>Benämning:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="BenamningPopUp" runat="server"></asp:Label>
                                                                </div> <%--BenamningPopUpInfo ends--%>
                                                            </div> <%--BenamningPopUpDiv ends--%>
                                                           
                                                            <div class="row">     
                                                                <div style="height:10px" class="col-md-12"></div> <%--spaceDiv--%>
                                                            </div> <%--spaceRow--%>
                                                           
                                                            <div ID="InternTextPopUpDiv" class="row"> 
                                                                <div ID="InternTextPopUpInfo" class="col-md-8" style="text-align:left">
                                                                    <asp:Label ID="_InternTextPopUp" runat="server"><b>Intern Text:&nbsp;</b></asp:Label>
                                                                    <asp:Label ID="InternTextPopUp" runat="server"></asp:Label>
                                                                </div> <%--InternTextPopUpInfo ends--%>
                                                            </div> <%--InternTextPopUpDiv ends--%>
                                                                
                                                            <div ID="btnPopUpRow" class="row">
                                                                <div ID="btnPopUpDiv" class="col-md-12" style="margin-left:40%">
                                                                    <asp:Button ID="btnCancelPopUp" class="btn btn-default" runat="server" Text="Stäng"></asp:Button>
                                                                </div> <%--btnPopUpDiv--%>
                                                            </div> <%--btnPopUpRow ends--%></asp:Panel>
                                                         
                                                         <asp:HiddenField ID="hfPopUp" runat="server" ></asp:HiddenField>
                                                         
                                                         <ajax:ModalPopupExtender ID="ModalPopupExtenderInfo" runat="server"
                                                            TargetControlID="hfPopUp"
                                                            PopupControlID="infoPopUp"
                                                            BackgroundCssClass="modalBackground" 
                                                            DropShadow="true" 
                                                            CancelControlID="btnCancelPopUp">
                                                         </ajax:ModalPopupExtender>
                                                    </ContentTemplate>
                                                 </asp:UpdatePanel>
                                                 <%--Gridview: Copybutton--%>
                                                 <asp:LinkButton ID="lbtnCopy" runat="server" class="btn btn-warning btn-xs" 
                                                    CommandName="CopyRow" 
                                                    CausesValidation="false"
                                                    ToolTip="Kopiera rad till rapportering">
                                                    <i class="glyphicon glyphicon-export"></i>
                                                 </asp:LinkButton>
                                                    
                                                <%--Gridview: Deletebutton--%>
                                                <asp:LinkButton ID="lbtnDelete" class="btn btn-danger btn-xs" runat="server"
                                                    CommandName="DeleteRow" CommandArgument='<%# Eval("AgrNo") %>'
                                                    CausesValidation="false"
                                                    ToolTip="Ta bort tidsraden"
                                                    OnClientClick ="return confirm('Är du säker att du vill ha bort tidsraden?');">
                                                    <i class="glyphicon glyphicon-trash"></i>
                                                </asp:LinkButton>
                                                
                                                
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle Width="60px" />
                                          </asp:TemplateField>
                                    </Columns>
                                    
                                       <FooterStyle BackColor="#FF9933" BorderColor="#FF9900" />
                                       <PagerStyle BackColor="#FFBC79" ForeColor="Black" HorizontalAlign="Center"  />
                                       <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                       <AlternatingRowStyle BackColor="Silver" />
                                   </asp:GridView> 
                                </div> <%-- gridviewBox ends--%>
                                
                                <%--Labels for testing, Delete before deploy!!!!!!!!!!!!--%>
                                <asp:Label ID="lblAgrNo" runat="server" Text="Agr No: "></asp:Label>
                                <asp:Label ID="lblAct" runat="server" Text="Act No: "></asp:Label>
                                <asp:Label ID="lblCon" runat="server" Text="Contract: "></asp:Label>
                                
                                <%--ObjectDataSource for Gridview--%>
                                <asp:ObjectDataSource ID="ObjectDataSourceIdag" runat="server" 
                                        SelectMethod="getTodaysInserts" 
                                        TypeName="TidsrapporteringASPClient.Rapportering">
                                </asp:ObjectDataSource>
                            </div> <%-- infoBox ends--%>
                        </div> <%-- infoRow ends--%>
                    </div> <%-- calenderFlexAndInfo ends--%>
                    
                </div> <%--newInsertInfoBox ends--%>
            </div> <%--basContainer ends--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
