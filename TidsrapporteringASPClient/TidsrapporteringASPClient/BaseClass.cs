using System;
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


public class BaseClass : System.Web.UI.Page
{
    private string IDname;

    public BaseClass(string value) 
    {
        this.IDname = value;
    }

    /// <summary>
    /// Register the first login attempt for a username
    /// </summary>
    /// <param name="username">Name of the user you eant to login with</param>
    public void firstLoginAttempt(string username)
    {
        Session["loginUser" + this.IDname] = username;
        Session["loginAttempt" + this.IDname] = 1;
    }

    /// <summary>
    /// Reset the session for the login for a username
    /// </summary>
    public void resetLoginAttempt()
    {
        Session["loginUser" + this.IDname] = null;
        Session["loginAttempt" + this.IDname] = null;
    }

    /// <summary>
    /// Gets the clients IP-address 
    /// </summary>
    /// <returns>Returns a string with the clients IP-address</returns>
    public string getClientIP()
    {
        string ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        return ipaddress;
    }

    /// <summary>
    /// Gets the name of the website
    /// </summary>
    /// <returns>Returns a string with the name</returns>
    public string getWebsiteName() 
    { 
        return HttpContext.Current.Request.ServerVariables["server_name"]; 
    }

    /// <summary>
    /// Saves and checks the user you failed to login with
    /// If you fails to login after a couples of tries, action will be taken
    /// </summary>
    /// <param name="username">Name of the user you failed to login with</param>
    /// <returns>Returns true if you failed to login after a couple of tries ELSE false</returns>
    public bool checkFailedLogin(string username, int loginAttemptsAllowed)
    {
        /* Checks the login attempts */
        if (Session["loginUser" + this.IDname] != null)   //If you have already tried to login
        {
            string affectedUser = (string)Session["loginUser" + this.IDname]; //Check after the user you tried to login with, the last time
            if (username.Equals(affectedUser))  //Current user you tries to login with, is it the same as the last time
            {
                int loginAttempt = (int)Session["loginAttempt" + this.IDname];    //See how many times you have tried to login with this user

                loginAttempt = loginAttempt + 1;    //Adds that it failed again
                Session["loginAttempt" + this.IDname] = loginAttempt; //Saves it also

                if (loginAttempt >= loginAttemptsAllowed)    //The value is from the configFile, and checks how many times you are allowed to fail with the login
                {
                    /* Failed to login with the user */
                    return true;
                }
            }
            else
            {
                /* First attempt to login with this user */
                this.firstLoginAttempt(username);
            }
        }
        else if (Session["loginUser" + this.IDname] == null && Session["loginAttempt" + this.IDname] == null)
        {
            /* First attempt to login with this user */
            this.firstLoginAttempt(username);
        }
        return false;
    }

    //public DBHandler connectToDB()
    //{
    //    Gets the cookie
    //    FormsAuthenticationTicket ticket = this.getTicket();

    //    return new DBHandler(ticket.Name);
    //}

    /// <summary>
    /// Gets the cookie
    /// </summary>
    /// <returns>Returns the ticket</returns>
    public FormsAuthenticationTicket getTicket()
    {
        try
        {
            var name = User.Identity;
            FormsIdentity id = new FormsIdentity(null);
            if (name.Name.Equals(string.Empty) || name.Name.Equals(null))
            {
                return null;
            }
            else
            {
                id = (FormsIdentity)User.Identity;
                if (User.Identity.Name.Equals(id.Ticket.Name)) //Is it the same user as from the encrypted cookie??
                {
                    return id.Ticket;
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        
    }

    /// <summary>
    /// Checks it it's a mobile or a PC
    /// </summary>
    /// <returns>Returns True if mobile else False</returns>
    public bool isMobileBrowser()
    {
        //GETS THE CURRENT USER CONTEXT
        HttpContext context = HttpContext.Current;

        //FIRST TRY BUILT IN ASP.NT CHECK
        if (context.Request.Browser.IsMobileDevice)
        {
            return true;
        }
        //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
        if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
        {
            return true;
        }
        //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
        if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
            context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
        {
            return true;
        }
        //AND FINALLY CHECK THE HTTP_USER_AGENT 
        //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            //Create a list of all mobile types
            string[] mobiles =
                new[]
                {
                    "midp", "j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", "ipod",
                    "240x320", "opwv", "chtml", "android",
                    "pda", "windows ce", "mmp/", "opera mobi",
                    "blackberry", "mib/", "symbian", "windows phone os",
                    "wireless", "nokia", "hand", "mobi", "iemobile",
                    "phone", "cdm", "up.b", "audio", "fennec",
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                    "NEC", "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", "ipad",
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };

            //Loop through each item in the list created above 
            //and check if the header contains that text
            foreach (string s in mobiles)
            {
                if (context.Request.ServerVariables["HTTP_USER_AGENT"].
                                                    ToLower().Contains(s.ToLower()))
                {
                    return true;
                }
            }
        }

        return false;
    }
}