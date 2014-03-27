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
using System.Net;
using System.Net.Mail;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Mail : ConfigFile
{
    public Mail()
    {
    }

    /// <summary>
    /// Sends a mail, about someone tried to login but failed a couple of times
    /// </summary>
    /// <param name="IPaddress">IP-address of the client who tried login but failed a couple of times</param>
    /// <param name="affectedUser">Sends a mail to the user that the 'unknown' tried to login to</param>
    /// <param name="webbName">Name of the webbsite</param>
    public void sendMail(string IPaddress, string affectedUser, string webbName)
    {
        if (!string.IsNullOrEmpty(mailText)) //Must have a msg to send
        {
            HtmlDocument doc = new HtmlDocument();

            string[] msgTxt = mailText.Split(new char[] {'#'}, 2, StringSplitOptions.None); //mailText from configFile
            string msgHead = msgTxt[0].Trim();
            string msgBody = msgTxt[1].Trim();

            string date = DateTime.Now.ToString();
            /* Replace the values %text% to theirs correct values */
            msgBody = Regex.Replace(msgBody, varIP, IPaddress, RegexOptions.IgnoreCase);    
            msgBody = Regex.Replace(msgBody, varWebNm, webbName, RegexOptions.IgnoreCase);
            msgBody = Regex.Replace(msgBody, varDate, date, RegexOptions.IgnoreCase);

            msgHead = Regex.Replace(msgHead, varIP, IPaddress, RegexOptions.IgnoreCase);
            msgHead = Regex.Replace(msgHead, varWebNm, webbName, RegexOptions.IgnoreCase);
            msgHead = Regex.Replace(msgHead, varDate, date, RegexOptions.IgnoreCase);


            //Creates a message
            MailMessage message = new MailMessage();

            try
            {
                message.From = new MailAddress(mailFrom);   //Send from

                message.To.Add(affectedUser); //Send to who
            }
            catch { message.Dispose(); return; }

            doc.LoadHtml(msgBody);  //Load the text
            int counter = 1;
            List<string> strList = new List<string>();

            //Get the img-tag if exists
            HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//img/@src");
            foreach (HtmlNode img in imgs)
            {
                /* Replace the img-src so I can send a embedded img */
                msgBody = msgBody.Replace(img.Attributes["src"].Value, "cid:" + "id" + counter.ToString());
                
                //Save some useful id
                strList.Add(img.Attributes["src"].Value);
                strList.Add("id" + counter.ToString());
                counter++;
            }

            /* Embeds image in the mail */
            AlternateView view = AlternateView.CreateAlternateViewFromString(msgBody, null, System.Net.Mime.MediaTypeNames.Text.Html);
            string strImageUrl = string.Empty;
            LinkedResource resource;
            string imgFilePath;

            try
            {
                for (int i = 0; i < strList.Count; i += 2)
                {
                    imgFilePath = new Uri(strList[i]).LocalPath;
                    strImageUrl = System.Web.HttpContext.Current.Server.MapPath("~/" + imgFilePath);  //Get the path to the image

                    //Links the img
                    resource = new LinkedResource(strImageUrl);
                    resource.ContentId = strList[i + 1]; //Attach to this id

                    /* Add it to the mail */
                    view.LinkedResources.Add(resource);
                    message.AlternateViews.Add(view);
                }
            }
            catch { }

            /* The message */
            message.IsBodyHtml = true;
            message.Subject = msgHead; //Mail subject
            //The content text for the mail
            message.Body = msgBody;

            SmtpClient smtp;
            try
            {
                smtp = new SmtpClient(mailServer, mailPort); //Creates a connection to this server and port
                smtp.EnableSsl = mailSSL;   //if the EnableSsl property is set to true, and the SMTP mail server does not advertise STARTTLS in the response to the EHLO                                                     command, then a call to the Send or SendAsync methods will throw an SmtpException
            }
            catch { message.Dispose(); return; }
            smtp.Timeout = 30000;

            //If there is credential, add them
            if (!string.IsNullOrEmpty(mailUser) && !string.IsNullOrEmpty(mailPass))
            {
                smtp.Credentials = new NetworkCredential(mailUser, mailPass);   //Adds the specified credentials
            }
            else
                smtp.UseDefaultCredentials = true;  //Use default credentials, if no credentials are set

            try
            {
                smtp.Send(message);   //Send the message
            }
            catch { }
            finally { message.Dispose(); } //Deletes the mail
        }
    }
}