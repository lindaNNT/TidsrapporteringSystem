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

namespace TidsrapporteringASPClient.Repository
{
    public class Favorit
    {
        public int FavoritID { get; set; }
        public string FavoritName { get; set; }
        public int ActAgrID { get; set; }
        public string Debit { get; set; }
        public string Activity { get; set; }
        public string Artical { get; set; }
        public string CustomName { get; set; }
        public string Order { get; set; }
        public string Service { get; set; }
        public string Project { get; set; }
        public string Benamning { get; set; }
        public string InternText { get; set; }
        public string  Memo { get; set; }
        public string Miltal { get; set; }
    }
}
