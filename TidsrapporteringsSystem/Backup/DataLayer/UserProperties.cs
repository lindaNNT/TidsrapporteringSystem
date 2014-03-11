﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DataLayer
{

    /* Active Directory information about a user */
    public class UserProperties
    {
        #region Collection of active directory variables
        public const string OBJECTCLASS = "objectClass";
        public const string CONTAINERNAME = "cn";
        public const string LASTNAME = "sn";
        public const string COUNTRYNOTATION = "c";
        public const string CITY = "l";
        public const string STATE = "st";
        public const string TITLE = "title";
        public const string POSTALCODE = "postalCode";
        public const string PHYSICALDELIVERYOFFICENAME = "physicalDeliveryOfficeName";
        public const string FIRSTNAME = "givenName";
        public const string MIDDLENAME = "initials";
        public const string DISTINGUISHEDNAME = "distinguishedName";
        public const string INSTANCETYPE = "instanceType";
        public const string WHENCREATED = "whenCreated";
        public const string WHENCHANGED = "whenChanged";
        public const string DISPLAYNAME = "displayName";
        public const string USNCREATED = "uSNCreated";
        public const string MEMBEROF = "memberOf";
        public const string USNCHANGED = "uSNChanged";
        public const string COUNTRY = "co";
        public const string DEPARTMENT = "department";
        public const string COMPANY = "company";
        public const string PROXYADDRESSES = "proxyAddresses";
        public const string STREETADDRESS = "streetAddress";
        public const string DIRECTREPORTS = "directReports";
        public const string NAME = "name";
        public const string OBJECTGUID = "objectGUID";
        public const string USERACCOUNTCONTROL = "userAccountControl";
        public const string BADPWDCOUNT = "badPwdCount";
        public const string CODEPAGE = "codePage";
        public const string COUNTRYCODE = "countryCode";
        public const string BADPASSWORDTIME = "badPasswordTime";
        public const string LASTLOGOFF = "lastLogoff";
        public const string LASTLOGON = "lastLogon";
        public const string PWDLASTSET = "pwdLastSet";
        public const string PRIMARYGROUPID = "primaryGroupID";
        public const string OBJECTSID = "objectSid";
        public const string ADMINCOUNT = "adminCount";
        public const string ACCOUNTEXPIRES = "accountExpires";
        public const string LOGONCOUNT = "logonCount";
        public const string LOGINNAME = "sAMAccountName";
        public const string SAMACCOUNTTYPE = "sAMAccountType";
        public const string SHOWINADDRESSBOOK = "showInAddressBook";
        public const string LEGACYEXCHANGEDN = "legacyExchangeDN";
        public const string USERPRINCIPALNAME = "userPrincipalName";
        public const string EXTENSION = "ipPhone";
        public const string SERVICEPRINCIPALNAME = "servicePrincipalName";
        public const string OBJECTCATEGORY = "objectCategory";
        public const string DSCOREPROPAGATIONDATA = "dSCorePropagationData";
        public const string LASTLOGONTIMESTAMP = "lastLogonTimestamp";
        public const string EMAILADDRESS = "mail";
        public const string MANAGER = "manager";
        public const string MOBILE = "mobile";
        public const string PAGER = "pager";
        public const string FAX = "facsimileTelephoneNumber";
        public const string HOMEPHONE = "homePhone";
        public const string MSEXCHUSERACCOUNTCONTROL = "msExchUserAccountControl";
        public const string MDBUSEDEFAULTS = "mDBUseDefaults";
        public const string MSEXCHMAILBOXSECURITYDESCRIPTOR = "msExchMailboxSecurityDescriptor";
        public const string HOMEMDB = "homeMDB";
        public const string MSEXCHPOLICIESINCLUDED = "msExchPoliciesIncluded";
        public const string HOMEMTA = "homeMTA";
        public const string MSEXCHRECIPIENTTYPEDETAILS = "msExchRecipientTypeDetails";
        public const string MAILNICKNAME = "mailNickname";
        public const string MSEXCHHOMESERVERNAME = "msExchHomeServerName";
        public const string MSEXCHVERSION = "msExchVersion";
        public const string MSEXCHRECIPIENTDISPLAYTYPE = "msExchRecipientDisplayType";
        public const string MSEXCHMAILBOXGUID = "msExchMailboxGuid";
        public const string NTSECURITYDESCRIPTOR = "nTSecurityDescriptor";
        #endregion
    }
}