<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historik.aspx.cs" Inherits="TidsrapporteringASPClient.LogedInPages.Historik" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" EnablePageMethods="true" runat="server">
        
    </asp:ToolkitScriptManager>--%> 
    <asp:TextBox ID="tbTest" runat="server"></asp:TextBox>
    <asp:Button ID="btnTest" runat="server" Text="Test" onclick="btnTest_Click" />
    <asp:Label ID="lblTest" runat="server" Text="Test"></asp:Label>
    
    <asp:TextBox ID="tbEx" runat="server" AutoPostBack="true" autocomplete="off" placeholder="ex"></asp:TextBox>
    <asp:AutoCompleteExtender
        ID="ACEtbEx" runat="server"
        BehaviorID="AutoCompleteExtenderBehaviour"
        Enabled="true"
        TargetControlID="tbEx"
        ServiceMethod="GetCompletionList" 
        ServicePath="AutoComplete.asmx"
        MinimumPrefixLength="0" 
        CompletionInterval="50"
        EnableCaching="true"
        CompletionSetCount="20" 
        CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
        DelimiterCharacters=";, :"
        ShowOnlyCurrentWordInCompletionListItem="true">
    </asp:AutoCompleteExtender>


    <asp:TextBox ID="tbOrder" placeholder="order" runat="server"></asp:TextBox>
    
    <div id="custCombo" style="width:200px; height:70px;"></div>
    <div id="OrderCombo" style="width:200px; height:70px;"></div>
    <div id="ServiceCombo" style="width:200px; height:70px;"></div>
    <script>
        var comboServ = new dhtmlXCombo("ServiceCombo", "ServiceCombo", 200);
        comboServ.enableFilteringMode("between");
        comboServ.attachEvent("onChange", onChangeFuncServ);
        
        var comboOrder = new dhtmlXCombo("OrderCombo", "OrderCombo", 200);
        comboOrder.enableFilteringMode("between");
        comboOrder.attachEvent("onChange", onChangeFuncOrder);
        
    
        var comboCust = new dhtmlXCombo("custCombo", "custCombo", 200);
        comboCust.loadXML("../../Repository/Customer.xml");
        comboCust.enableFilteringMode("between");
        comboCust.attachEvent("onChange", onChangeFuncCust);
        
        function onChangeFuncCust(){
            var custID = comboCust.getSelectedValue();
            var order = comboOrder.getSelectedText();
            var serv = comboServ.getSelectedText();
            if(order.length > 0)
            {
                comboOrder.setComboText("");
                comboOrder.setComboValue("");
                comboOrder.unSelectOption();
                comboOrder.clearAll();
            }
            if(serv.length > 0)
            {
                comboServ.setComboText("");
                comboServ.setComboValue("");
                comboServ.unSelectOption();
                comboServ.clearAll();
            }
            
            if(custID.length > 0)
            {
                $('#ctl00_hfCustID')[0].value = custID;
                PageMethods.createOrder(custID,onSucess, onError);
                function onSucess()
                {
                    comboOrder.loadXML("../../Repository/Order.xml");
                    comboCust.closeAll();
                }
                function onError() {
                    alert('Something wrong.');
                }
            }
        }
        
        function onChangeFuncOrder(){
            var order = comboOrder.getSelectedText();
            var serv = comboServ.getSelectedText();
            if(serv.length > 0)
            {
                comboServ.setComboText("");
                comboServ.setComboValue("");
                comboServ.unSelectOption();
                comboServ.clearAll();
            }
            if(order.length > 0)
            {
                var index = (order.indexOf("-"))-1;
                var orderID = order.substring(0, index );
                $('#ctl00_hfOrderID')[0].value = orderID;
                PageMethods.createService(orderID,onSucess, onError);
                function onSucess()
                {
                    comboServ.loadXML("../../Repository/TidsrapporteringService.xml");
                    comboOrder.closeAll();
                }
                function onError() {
                    alert('Something wrong.');
                }
            }
            else{
                alert("ngt fel");
            }
        }
        
        function onChangeFuncServ(){
            var servID = comboServ.getSelectedValue();
            if(servID.length > 0)
            {
                $('#ctl00_hfServiceID')[0].value = servID;
            }
        }
        
    </script>
</asp:Content>
