using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestAvWCFApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string anv = tb1.Text;
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();
            if (svar)
            {
                TRservice.User _user = host.GetUser(anv, svar);
                lbl2.Text = "Användarnamn: " + _user.UserName;
                lbl3.Text = "Lösenord: " + _user.Password;
                lbl4.Text = "Real name: " + _user.RealName;
                lbl5.Text = "Grupp: " + _user.Group;
            }
            else
            {
                lbl2.Text = "error";
            }

            if (svar)
            {
                List<string> prod = new List<string>();
                prod = host.GetAllProducts(anv).ToList();
                if (prod.Count > 0)
                {
                    foreach (string product in prod)
                    {
                        rt1.Text += product + "\n";
                    }
                }
                else
                {
                    rt1.Text = "finns inget.";
                }
            }

            if (svar)
            {
                string flex = host.GetFlexForLogOnUser(anv, tb2.Text);
                lbl6.Text = "Flex: " + flex;
            }
            
        }
    }
}
