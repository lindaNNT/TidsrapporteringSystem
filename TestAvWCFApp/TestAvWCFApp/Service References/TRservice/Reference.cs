﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAvWCFApp.TRservice {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tidsrad", Namespace="http://schemas.datacontract.org/2004/07/TidsrapporteringsSystem")]
    [System.SerializableAttribute()]
    public partial class Tidsrad : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string activityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool adWageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string benamningField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int contractField;
        
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TRservice.ITidsrapporteringService")]
    public interface ITidsrapporteringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetLatestTidrad", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetLatestTidradResponse")]
        TestAvWCFApp.TRservice.Tidsrad GetLatestTidrad();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetUserResponse")]
        TestAvWCFApp.TRservice.User GetUser(string username, bool exist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/LogIn", ReplyAction="http://tempuri.org/ITidsrapporteringService/LogInResponse")]
        bool LogIn(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetTimeLineHistoryForLogOnUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetTimeLineHistoryForLogOnUserRespons" +
            "e")]
        TestAvWCFApp.TRservice.Tidsrad[] GetTimeLineHistoryForLogOnUser(TestAvWCFApp.TRservice.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetFlexForLogOnUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetFlexForLogOnUserResponse")]
        string GetFlexForLogOnUser(string username, string flexYearMonth);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetHolydayForLogOnUser", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetHolydayForLogOnUserResponse")]
        string GetHolydayForLogOnUser(TestAvWCFApp.TRservice.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/InsertNewTimeLine", ReplyAction="http://tempuri.org/ITidsrapporteringService/InsertNewTimeLineResponse")]
        void InsertNewTimeLine(TestAvWCFApp.TRservice.Tidsrad tidsrad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetLatestTimeLineInput", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetLatestTimeLineInputResponse")]
        TestAvWCFApp.TRservice.Tidsrad GetLatestTimeLineInput(TestAvWCFApp.TRservice.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/UpdateTimeLine", ReplyAction="http://tempuri.org/ITidsrapporteringService/UpdateTimeLineResponse")]
        void UpdateTimeLine(TestAvWCFApp.TRservice.Tidsrad tidsrad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/DeleteTimeLine", ReplyAction="http://tempuri.org/ITidsrapporteringService/DeleteTimeLineResponse")]
        void DeleteTimeLine(TestAvWCFApp.TRservice.Tidsrad tidsrad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITidsrapporteringService/GetAllProducts", ReplyAction="http://tempuri.org/ITidsrapporteringService/GetAllProductsResponse")]
        string[] GetAllProducts(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ITidsrapporteringServiceChannel : TestAvWCFApp.TRservice.ITidsrapporteringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class TidsrapporteringServiceClient : System.ServiceModel.ClientBase<TestAvWCFApp.TRservice.ITidsrapporteringService>, TestAvWCFApp.TRservice.ITidsrapporteringService {
        
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
        
        public TestAvWCFApp.TRservice.Tidsrad GetLatestTidrad() {
            return base.Channel.GetLatestTidrad();
        }
        
        public TestAvWCFApp.TRservice.User GetUser(string username, bool exist) {
            return base.Channel.GetUser(username, exist);
        }
        
        public bool LogIn(string username) {
            return base.Channel.LogIn(username);
        }
        
        public TestAvWCFApp.TRservice.Tidsrad[] GetTimeLineHistoryForLogOnUser(TestAvWCFApp.TRservice.User user) {
            return base.Channel.GetTimeLineHistoryForLogOnUser(user);
        }
        
        public string GetFlexForLogOnUser(string username, string flexYearMonth) {
            return base.Channel.GetFlexForLogOnUser(username, flexYearMonth);
        }
        
        public string GetHolydayForLogOnUser(TestAvWCFApp.TRservice.User user) {
            return base.Channel.GetHolydayForLogOnUser(user);
        }
        
        public void InsertNewTimeLine(TestAvWCFApp.TRservice.Tidsrad tidsrad) {
            base.Channel.InsertNewTimeLine(tidsrad);
        }
        
        public TestAvWCFApp.TRservice.Tidsrad GetLatestTimeLineInput(TestAvWCFApp.TRservice.User user) {
            return base.Channel.GetLatestTimeLineInput(user);
        }
        
        public void UpdateTimeLine(TestAvWCFApp.TRservice.Tidsrad tidsrad) {
            base.Channel.UpdateTimeLine(tidsrad);
        }
        
        public void DeleteTimeLine(TestAvWCFApp.TRservice.Tidsrad tidsrad) {
            base.Channel.DeleteTimeLine(tidsrad);
        }
        
        public string[] GetAllProducts(string username) {
            return base.Channel.GetAllProducts(username);
        }
    }
}
