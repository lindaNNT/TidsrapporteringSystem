﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TidsrapportMVCClient.TidsrapporteringService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/TidsrapporteringsSystem")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GroupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LoginAttemptField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RealNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Group {
            get {
                return this.GroupField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupField, value) != true)) {
                    this.GroupField = value;
                    this.RaisePropertyChanged("Group");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LoginAttempt {
            get {
                return this.LoginAttemptField;
            }
            set {
                if ((this.LoginAttemptField.Equals(value) != true)) {
                    this.LoginAttemptField = value;
                    this.RaisePropertyChanged("LoginAttempt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RealName {
            get {
                return this.RealNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RealNameField, value) != true)) {
                    this.RealNameField = value;
                    this.RaisePropertyChanged("RealName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tidsrad", Namespace="http://schemas.datacontract.org/2004/07/TidsrapporteringsSystem")]
    [System.SerializableAttribute()]
    public partial class Tidsrad : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool activeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string activityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool adWageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int agrActNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int agrNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string benamningField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int contractField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string custNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int custNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool debitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool defaultActivityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float faktureradTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int frDtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int frTmField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string internTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ordNrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string prodNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string projectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string serviceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int toDtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int toTmField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool utlaggField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float workedTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool active {
            get {
                return this.activeField;
            }
            set {
                if ((this.activeField.Equals(value) != true)) {
                    this.activeField = value;
                    this.RaisePropertyChanged("active");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string activity {
            get {
                return this.activityField;
            }
            set {
                if ((object.ReferenceEquals(this.activityField, value) != true)) {
                    this.activityField = value;
                    this.RaisePropertyChanged("activity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool adWage {
            get {
                return this.adWageField;
            }
            set {
                if ((this.adWageField.Equals(value) != true)) {
                    this.adWageField = value;
                    this.RaisePropertyChanged("adWage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int agrActNo {
            get {
                return this.agrActNoField;
            }
            set {
                if ((this.agrActNoField.Equals(value) != true)) {
                    this.agrActNoField = value;
                    this.RaisePropertyChanged("agrActNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int agrNo {
            get {
                return this.agrNoField;
            }
            set {
                if ((this.agrNoField.Equals(value) != true)) {
                    this.agrNoField = value;
                    this.RaisePropertyChanged("agrNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string benamning {
            get {
                return this.benamningField;
            }
            set {
                if ((object.ReferenceEquals(this.benamningField, value) != true)) {
                    this.benamningField = value;
                    this.RaisePropertyChanged("benamning");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int contract {
            get {
                return this.contractField;
            }
            set {
                if ((this.contractField.Equals(value) != true)) {
                    this.contractField = value;
                    this.RaisePropertyChanged("contract");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string custName {
            get {
                return this.custNameField;
            }
            set {
                if ((object.ReferenceEquals(this.custNameField, value) != true)) {
                    this.custNameField = value;
                    this.RaisePropertyChanged("custName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int custNo {
            get {
                return this.custNoField;
            }
            set {
                if ((this.custNoField.Equals(value) != true)) {
                    this.custNoField = value;
                    this.RaisePropertyChanged("custNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool debit {
            get {
                return this.debitField;
            }
            set {
                if ((this.debitField.Equals(value) != true)) {
                    this.debitField = value;
                    this.RaisePropertyChanged("debit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool defaultActivity {
            get {
                return this.defaultActivityField;
            }
            set {
                if ((this.defaultActivityField.Equals(value) != true)) {
                    this.defaultActivityField = value;
                    this.RaisePropertyChanged("defaultActivity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float faktureradTime {
            get {
                return this.faktureradTimeField;
            }
            set {
                if ((this.faktureradTimeField.Equals(value) != true)) {
                    this.faktureradTimeField = value;
                    this.RaisePropertyChanged("faktureradTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int frDt {
            get {
                return this.frDtField;
            }
            set {
                if ((this.frDtField.Equals(value) != true)) {
                    this.frDtField = value;
                    this.RaisePropertyChanged("frDt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int frTm {
            get {
                return this.frTmField;
            }
            set {
                if ((this.frTmField.Equals(value) != true)) {
                    this.frTmField = value;
                    this.RaisePropertyChanged("frTm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string internText {
            get {
                return this.internTextField;
            }
            set {
                if ((object.ReferenceEquals(this.internTextField, value) != true)) {
                    this.internTextField = value;
                    this.RaisePropertyChanged("internText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ordNr {
            get {
                return this.ordNrField;
            }
            set {
                if ((this.ordNrField.Equals(value) != true)) {
                    this.ordNrField = value;
                    this.RaisePropertyChanged("ordNr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string prodNo {
            get {
                return this.prodNoField;
            }
            set {
                if ((object.ReferenceEquals(this.prodNoField, value) != true)) {
                    this.prodNoField = value;
                    this.RaisePropertyChanged("prodNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string project {
            get {
                return this.projectField;
            }
            set {
                if ((object.ReferenceEquals(this.projectField, value) != true)) {
                    this.projectField = value;
                    this.RaisePropertyChanged("project");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string service {
            get {
                return this.serviceField;
            }
            set {
                if ((object.ReferenceEquals(this.serviceField, value) != true)) {
                    this.serviceField = value;
                    this.RaisePropertyChanged("service");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int toDt {
            get {
                return this.toDtField;
            }
            set {
                if ((this.toDtField.Equals(value) != true)) {
                    this.toDtField = value;
                    this.RaisePropertyChanged("toDt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int toTm {
            get {
                return this.toTmField;
            }
            set {
                if ((this.toTmField.Equals(value) != true)) {
                    this.toTmField = value;
                    this.RaisePropertyChanged("toTm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool utlagg {
            get {
                return this.utlaggField;
            }
            set {
                if ((this.utlaggField.Equals(value) != true)) {
                    this.utlaggField = value;
                    this.RaisePropertyChanged("utlagg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float workedTime {
            get {
                return this.workedTimeField;
            }
            set {
                if ((this.workedTimeField.Equals(value) != true)) {
                    this.workedTimeField = value;
                    this.RaisePropertyChanged("workedTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DayStatus", Namespace="http://schemas.datacontract.org/2004/07/TidsrapporteringsSystem")]
    [System.SerializableAttribute()]
    public partial class DayStatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string colorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string color {
            get {
                return this.colorField;
            }
            set {
                if ((object.ReferenceEquals(this.colorField, value) != true)) {
                    this.colorField = value;
                    this.RaisePropertyChanged("color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string date {
            get {
                return this.dateField;
            }
            set {
                if ((object.ReferenceEquals(this.dateField, value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string status {
            get {
                return this.statusField;
            }
            set {
                if ((object.ReferenceEquals(this.statusField, value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/TidsrapporteringsSystem")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AvtalNamnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AvtalNrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FakturatypField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderNoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AvtalNamn {
            get {
                return this.AvtalNamnField;
            }
            set {
                if ((object.ReferenceEquals(this.AvtalNamnField, value) != true)) {
                    this.AvtalNamnField = value;
                    this.RaisePropertyChanged("AvtalNamn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AvtalNr {
            get {
                return this.AvtalNrField;
            }
            set {
                if ((this.AvtalNrField.Equals(value) != true)) {
                    this.AvtalNrField = value;
                    this.RaisePropertyChanged("AvtalNr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Fakturatyp {
            get {
                return this.FakturatypField;
            }
            set {
                if ((object.ReferenceEquals(this.FakturatypField, value) != true)) {
                    this.FakturatypField = value;
                    this.RaisePropertyChanged("Fakturatyp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderNo {
            get {
                return this.OrderNoField;
            }
            set {
                if ((this.OrderNoField.Equals(value) != true)) {
                    this.OrderNoField = value;
                    this.RaisePropertyChanged("OrderNo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TidsrapporteringService.ITidsrapporteringService")]
    public interface ITidsrapporteringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetUserResponse")]
        TidsrapportMVCClient.TidsrapporteringService.User GetUser(string username, bool exist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/LogIn", ReplyAction="http://tempuri.org/ITidsrapporteringService/LogInResponse")]
        bool LogIn(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetLastInsertedDay", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetLastInsertedDayResponse")]
        string GetLastInsertedDay(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetLastTimeLineInsertedForSpecificDat" +
            "e", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetLastTimeLineInsertedForSpecificDat" +
            "eResponse")]
        TidsrapportMVCClient.TidsrapporteringService.Tidsrad GetLastTimeLineInsertedForSpecificDate(string username, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllInsertedTimeLineOnOneDay", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllInsertedTimeLineOnOneDayRespons" +
            "e")]
        TidsrapportMVCClient.TidsrapporteringService.Tidsrad[] GetAllInsertedTimeLineOnOneDay(string username, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllInsertedDaysOfAMonth", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllInsertedDaysOfAMonthResponse")]
        TidsrapportMVCClient.TidsrapporteringService.DayStatus[] GetAllInsertedDaysOfAMonth(string username, string month);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetMonthFlexForLogOnUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetMonthFlexForLogOnUserResponse")]
        string GetMonthFlexForLogOnUser(string username, string flexYearMonth);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetTotalFlexForLogOnUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetTotalFlexForLogOnUserResponse")]
        string GetTotalFlexForLogOnUser(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetHolidayForLogOnUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetHolidayForLogOnUserResponse")]
        System.DateTime[] GetHolidayForLogOnUser(string username, string yearMonth);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/InsertNewTimeLine", ReplyAction="http://tempuri.org/ITidsrapporteringService/InsertNewTimeLineResponse")]
        string InsertNewTimeLine(TidsrapportMVCClient.TidsrapporteringService.Tidsrad tidsrad, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/UpdateTimeLine", ReplyAction="http://tempuri.org/ITidsrapporteringService/UpdateTimeLineResponse")]
        string UpdateTimeLine(TidsrapportMVCClient.TidsrapporteringService.Tidsrad tidsrad, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/DeleteTimeLine", ReplyAction="http://tempuri.org/ITidsrapporteringService/DeleteTimeLineResponse")]
        string DeleteTimeLine(TidsrapportMVCClient.TidsrapporteringService.Tidsrad tidsrad, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllProducts", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllProductsResponse")]
        string[] GetAllProducts(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllProductsByActivity", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllProductsByActivityResponse")]
        string[] GetAllProductsByActivity(string username, string activity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllCust", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllCustResponse")]
        string[] GetAllCust(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetCustNr", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetCustNrResponse")]
        int GetCustNr(string username, string custName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllOrdNr", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllOrdNrResponse")]
        TidsrapportMVCClient.TidsrapporteringService.Order[] GetAllOrdNr(string username, string custNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetContract", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetContractResponse")]
        int GetContract(string username, int OrderNr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllServiceByOrderNr", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllServiceByOrderNrResponse")]
        string[] GetAllServiceByOrderNr(string username, int orderNr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetActivitiesByDebit", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetActivitiesByDebitResponse")]
        string[] GetActivitiesByDebit(string username, bool debit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllProjects", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllProjectsResponse")]
        string[] GetAllProjects(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ITidsrapporteringServiceChannel : TidsrapportMVCClient.TidsrapporteringService.ITidsrapporteringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class TidsrapporteringServiceClient : System.ServiceModel.ClientBase<TidsrapportMVCClient.TidsrapporteringService.ITidsrapporteringService>, TidsrapportMVCClient.TidsrapporteringService.ITidsrapporteringService {
        
        public TidsrapporteringServiceClient() {
        }
        
        public TidsrapporteringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TidsrapporteringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TidsrapporteringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TidsrapporteringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TidsrapportMVCClient.TidsrapporteringService.User GetUser(string username, bool exist) {
            return base.Channel.GetUser(username, exist);
        }
        
        public bool LogIn(string username) {
            return base.Channel.LogIn(username);
        }
        
        public string GetLastInsertedDay(string username) {
            return base.Channel.GetLastInsertedDay(username);
        }
        
        public TidsrapportMVCClient.TidsrapporteringService.Tidsrad GetLastTimeLineInsertedForSpecificDate(string username, string date) {
            return base.Channel.GetLastTimeLineInsertedForSpecificDate(username, date);
        }
        
        public TidsrapportMVCClient.TidsrapporteringService.Tidsrad[] GetAllInsertedTimeLineOnOneDay(string username, string date) {
            return base.Channel.GetAllInsertedTimeLineOnOneDay(username, date);
        }
        
        public TidsrapportMVCClient.TidsrapporteringService.DayStatus[] GetAllInsertedDaysOfAMonth(string username, string month) {
            return base.Channel.GetAllInsertedDaysOfAMonth(username, month);
        }
        
        public string GetMonthFlexForLogOnUser(string username, string flexYearMonth) {
            return base.Channel.GetMonthFlexForLogOnUser(username, flexYearMonth);
        }
        
        public string GetTotalFlexForLogOnUser(string username) {
            return base.Channel.GetTotalFlexForLogOnUser(username);
        }
        
        public System.DateTime[] GetHolidayForLogOnUser(string username, string yearMonth) {
            return base.Channel.GetHolidayForLogOnUser(username, yearMonth);
        }
        
        public string InsertNewTimeLine(TidsrapportMVCClient.TidsrapporteringService.Tidsrad tidsrad, string username) {
            return base.Channel.InsertNewTimeLine(tidsrad, username);
        }
        
        public string UpdateTimeLine(TidsrapportMVCClient.TidsrapporteringService.Tidsrad tidsrad, string username) {
            return base.Channel.UpdateTimeLine(tidsrad, username);
        }
        
        public string DeleteTimeLine(TidsrapportMVCClient.TidsrapporteringService.Tidsrad tidsrad, string username) {
            return base.Channel.DeleteTimeLine(tidsrad, username);
        }
        
        public string[] GetAllProducts(string username) {
            return base.Channel.GetAllProducts(username);
        }
        
        public string[] GetAllProductsByActivity(string username, string activity) {
            return base.Channel.GetAllProductsByActivity(username, activity);
        }
        
        public string[] GetAllCust(string username) {
            return base.Channel.GetAllCust(username);
        }
        
        public int GetCustNr(string username, string custName) {
            return base.Channel.GetCustNr(username, custName);
        }
        
        public TidsrapportMVCClient.TidsrapporteringService.Order[] GetAllOrdNr(string username, string custNo) {
            return base.Channel.GetAllOrdNr(username, custNo);
        }
        
        public int GetContract(string username, int OrderNr) {
            return base.Channel.GetContract(username, OrderNr);
        }
        
        public string[] GetAllServiceByOrderNr(string username, int orderNr) {
            return base.Channel.GetAllServiceByOrderNr(username, orderNr);
        }
        
        public string[] GetActivitiesByDebit(string username, bool debit) {
            return base.Channel.GetActivitiesByDebit(username, debit);
        }
        
        public string[] GetAllProjects(string username) {
            return base.Channel.GetAllProjects(username);
        }
    }
}
