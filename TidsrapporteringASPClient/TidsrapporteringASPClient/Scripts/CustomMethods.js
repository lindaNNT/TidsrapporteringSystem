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
        //document.getElementById("<%=hfCustID.ClientID%>").value  = custID;
         //$('#ctl00_MainContent_hfCustID')[0].value = custID;
            
            document.getElementById("ctl00_MainContent_hfCustID").value  = custID;
            alert(document.getElementById("ctl00_MainContent_hfCustID").value);
            
        PageMethods.createOrder(custID,onSucess, onError);
        function onSucess()
        {
            comboOrder.loadXML("../../Repository/Order.xml");
            comboCust.closeAll();
            
        }
        function onError() {
            alert('Något fel uppstod.');
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
        document.getElementById("<%=hfOrder.ClientID%>").value  = orderID;
        PageMethods.createService(orderID,onSucess, onError);
        function onSucess()
        {
            comboServ.loadXML("../../Repository/TidsrapporteringService.xml");
            comboOrder.closeAll();
        }
        function onError() {
            alert('Något fel uppstod.');
        }
    }
    else{
        alert("Något fel uppstod");
    }
}

function onChangeFuncServ(){
    var servID = comboServ.getSelectedValue();
    if(servID.length > 0)
    {
        document.getElementById("<%=hfServiceID.ClientID%>").value = servID;
    }
}


//function insertToCombo(serv)
//{
//    var comboServ = new dhtmlXCombo("ServiceCombo", "ServiceCombo", 200);
//    comboServ.enableFilteringMode("between");
//    comboServ.attachEvent("onChange", onChangeFuncServ);

//    var comboOrder = new dhtmlXCombo("OrderCombo", "OrderCombo", 200);
//    comboOrder.enableFilteringMode("between");
//    comboOrder.attachEvent("onChange", onChangeFuncOrder);


//    var comboCust = new dhtmlXCombo("custCombo", "custCombo", 200);
//    comboCust.enableFilteringMode("between");
//    comboCust.loadXML("../../Repository/Customer.xml");
//    comboCust.attachEvent("onChange", onChangeFuncCust);
//    
//    
//    
//    var custID = '<%: Session["custID"].ToString() %>';
//    alert(custID);
////    var custID = $('#ctl00_MainContent_hfCustID')[0].value;
//    var custName = $('<textarea />').html($('#ctl00_hfCustName')[0].value).text();
//    
//    comboCust.setComboText(custID + " - " + custName);
//    comboOrder.clearAll();
//    onChangeFuncCust();
//    var orderID = $('#ctl00_MainContent_hfOrderID')[0].value;
//    var orderIndex = comboOrder.getIndexByValue(orderID);
//    
//    comboOrder.selectOption(orderIndex,false,false);
//    comboOrder.setComboValue(orderID);
//    onChangeFuncOrder();
//    alert(comboOrder.getSelectedValue());
//    
//    
//    
//    
//    
//    function onChangeFuncCust(){
//    var custID = $('#ctl00_MainContent_hfCustID')[0].value;
//    var order = comboOrder.getSelectedText();
//    var serv = comboServ.getSelectedText();
//    if(order.length > 0)
//    {
//        comboOrder.setComboText("");
//        comboOrder.setComboValue("");
//        comboOrder.unSelectOption();
//        comboOrder.clearAll();
//    }
//    if(serv.length > 0)
//    {
//        comboServ.setComboText("");
//        comboServ.setComboValue("");
//        comboServ.unSelectOption();
//        comboServ.clearAll();
//    }
//    
//    if(custID.length > 0)
//    {
//        $('#ctl00_MainContent_hfCustID')[0].value = custID;
//        PageMethods.createOrder(custID,onSucess, onError);
//        function onSucess()
//        {
//            comboOrder.loadXML("../../Repository/Order.xml");
//            comboCust.closeAll();
//            
//        }
//        function onError() {
//            alert('Något fel uppstod kund.');
//        }
//    }
//}

//function onChangeFuncOrder(){
//    var order = comboOrder.getSelectedText();
//    var serv = comboServ.getSelectedText();
//    if(serv.length > 0)
//    {
//        comboServ.setComboText("");
//        comboServ.setComboValue("");
//        comboServ.unSelectOption();
//        comboServ.clearAll();
//    }
//    if(order.length > 0)
//    {
//        var index = (order.indexOf("-"))-1;
//        var orderID = order.substring(0, index );
//        $('#ctl00_MainContent_hfOrderID')[0].value = orderID;
//        PageMethods.createService(orderID,onSucess, onError);
//        function onSucess()
//        {
//            comboServ.loadXML("../../Repository/TidsrapporteringService.xml");
//            comboOrder.closeAll();
//        }
//        function onError() {
//            alert('Något fel uppstod order.');
//        }
//    }
//}

//function onChangeFuncServ(){
//    var servID = comboServ.getSelectedValue();
//    if(servID.length > 0)
//    {
//        $('#ctl00_MainContent_hfServiceID')[0].value = servID;
//        alert(servID);
//    }
//}
//}
                                        