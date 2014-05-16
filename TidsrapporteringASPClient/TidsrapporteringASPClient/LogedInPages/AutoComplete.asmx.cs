using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using TidsrapporteringASPClient.Repository;

namespace TidsrapporteringASPClient.LogedInPages
{
    

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    [System.Web.Script.Services.ScriptService()]
    public class AutoComplete : System.Web.Services.WebService
    {
        public SharedMethods SM = new SharedMethods();

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string createOrder()
        {
            return "Hello";
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public string[] GetCompletionList(string prefixText, int count)
        {
            try
            {
                IList<string> nylist = SM.getCust("linda");
                if (count == 0)
                {
                    var result = nylist.ToArray();
                    return result;
                }
                else
                {
                    var result = from el in nylist.AsEnumerable()
                                where el.ToUpper().Contains(prefixText.ToUpper())
                                select el;
                    return result.Take(count).ToArray();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<string> GetList()
        {
            IList<string> _nylist = new List<string>();
            if (_nylist == null || _nylist.Count == 0)
            {
                IList<Favorit> list = SM.fillFavorit();
                foreach (Favorit el in list)
                {
                    _nylist.Add(el.FavoritName);
                }
            }
            return _nylist;
        }
    }
}
