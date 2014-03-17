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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region hämta alla kunder

            if (svar)
            {
                List<string> list = new List<string>();
                list = host.GetAllCust(anv).ToList();
                if (list.Count > 0)
                {
                    foreach (string obj in list)
                    {
                        lKundNr.Items.Add(obj);
                    }
                }
                else
                {
                    lKundNr.Items.Add("tom");
                }
            }
            #endregion
        }

        private void lKundNr_SelectedValueChanged(object sender, EventArgs e)
        {
            string custName = lKundNr.SelectedItem.ToString();
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region hämta alla kunder

            if (svar)
            {
                List<string> list = new List<string>();
                list = host.GetAllOrdNr(anv, custName).ToList();
                if (list.Count > 0)
                {
                    foreach (string obj in list)
                    {
                        lOrder.Items.Add(obj);
                    }
                }
                else
                {
                    lKundNr.Items.Add("tom");
                }
            }
            #endregion
        }
    }
}
