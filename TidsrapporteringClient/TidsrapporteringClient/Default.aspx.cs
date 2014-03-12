﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace TidsrapporteringClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            TidsrapportService.TidsrapporteringServiceClient host =
                new TidsrapportService.TidsrapporteringServiceClient();
            List<string> prodList = host.GetAllProducts().ToList();
            string svar = "";
            if (prodList.Count > 0)
            {
                svar = prodList[1]; 
            }
            else
            {
                svar = "finns inget i listan";
            }

            lblText.Text = svar;
        }
    }
}
