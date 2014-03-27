using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace TidsrapporteringASPClient
{
    public partial class _Default : System.Web.UI.Page
    {
        private LdapAuthentication ldap = new LdapAuthentication();
        private BaseClass baseC = new BaseClass("RegularUser");
        private ConfigFile cF = new ConfigFile();
        private Mail mail = new Mail();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].Equals(null) || Session["user"].Equals(string.Empty))
            {
                
            }
            else
            {
                Response.Redirect("~/LogedInPages/Rapportering.aspx");
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Login.CreateUserText = string.Empty;

            string _memberOf = cF.memberDefault;  //The group-name the user must be a memeber of
            bool isPersistent = true;   //Want always to create a persistent cookie
            string userData = string.Empty; //Store some useful data about the user

            string username = Login.UserName.Trim();
            string password = Login.Password.Trim();

            //Tries to connect to the AD
            string[] loginMsg = ldap.connectToAD(username, password, _memberOf);

            if (loginMsg[0].Equals("Correct"))   //A connection to the AD has been made
            {
                #region Logged in

                //Resets the sessions
                baseC.resetLoginAttempt();

                //Take only the path-string
                userData = loginMsg[1];

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, //Version
                  username,                 //Username
                  DateTime.Now,             //Created date
                  DateTime.Now.AddYears(cF.yearLifeOfTheCookie),  //Expire date
                  isPersistent,             //If the cookie will be persist
                  userData,                 //Useful data about the user
                  FormsAuthentication.FormsCookiePath); //Path to the cookie
                Session["user"] = username;
                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { Expires = ticket.Expiration });

                //Go to the page
                Response.Redirect("~/LogedInPages/Rapportering.aspx");

                #endregion
            }
            else
            {
                #region Failed

                //Something went wrong
                if (loginMsg[1].Contains("Logon failure: unknown user name or bad password."))
                {
                    Login.FailureText = cF.errorTextWrongUserPass;
                    
                    /* Gets the clients IP-address */
                    string ipaddress = baseC.getClientIP();
                    /* Gets the website name */
                    string webSiteName = baseC.getWebsiteName();

                    if (baseC.checkFailedLogin(username, cF.loginAttempt) == true)
                    {
                        //Send a mail about someone tried to login but failed
                        mail.sendMail(ipaddress, loginMsg[2], webSiteName);

                        //Removes the form
                        Login.Visible = false;

                        //Resets the sessions
                        baseC.resetLoginAttempt();

                        //Displays some pictures
                        //img1.Visible = true;
                        //img2.Visible = true;
                    }
                }
                else
                    Login.FailureText = loginMsg[1];

                //Focus the password-textbox
                Master.Page.ClientScript.RegisterStartupScript(this.GetType(), "FocusTextPass1", "focusTextBox('" + Login.FindControl("Password").ClientID + "');", true);


                #endregion
            }
        }
    }
}
