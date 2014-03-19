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
            lOrder.Items.Clear();
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
                List<TRservice.Order> list = new List<TRservice.Order>();
                list = host.GetAllOrdNr(anv, custName).ToList();
                if (list.Count > 0)
                {
                    foreach (var obj in list)
                    {
                        string text = obj.OrderNo + ", " + obj.AvtalNr + ", " + obj.AvtalNamn + ", " + obj.Fakturatyp;
                        lOrder.Items.Add(text);
                    }
                }
                else
                {
                    lKundNr.Items.Add("tom");
                }
            }
            #endregion
        }

        private void lOrder_SelectedValueChanged(object sender, EventArgs e)
        {
            lService.Items.Clear();
            string order = lOrder.SelectedItem.ToString();
            order = order.Substring(0, order.IndexOf(","));
            int orderNr = Convert.ToInt32(order);

            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region hämta contract nr

            if (svar)
            {
                int contract = host.GetContract(anv, orderNr);
                if (contract.ToString().Length > 0)
                {
                    lbl2.Text = contract.ToString();
                }
                else
                {
                    lbl2.Text = "tom";
                }
            }
            #endregion

            #region hämta alla service
            if (svar)
            {
                List<string> lista = host.GetAllServiceByOrderNr(anv, orderNr).ToList();
                if (lista.Count > 0)
                {
                    foreach (string service in lista)
                    {
                        lService.Items.Add(service);
                    }
                }
                else
                {
                    lService.Items.Add("tom");
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region getprojekt

            if (svar)
            {
                List<string> projectList = new List<string>();
                projectList = host.GetAllProjects(anv).ToList();
                if (projectList.Count > 0)
                {
                    foreach (string proj in projectList)
                    {
                        string projNamn = proj.Substring(0, proj.IndexOf("?"));
                        string projNr = proj.Substring(proj.IndexOf("?") + 2);
                        lProject.Items.Add(projNr + ", " + projNamn);
                    }
                }
                else
                {
                    lProject.Items.Add("tom");
                }
            }
            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lActivity.Items.Clear();
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region fyll aktivitetslista
            string val = cb1.SelectedItem.ToString();
            List<string> lista = new List<string>();
            if (val.Equals("Nej"))
            {
                tbFT.Text = "0";
                tbFT.Enabled = false;
                lista = host.GetActivitiesByDebit(anv, false).ToList();
            }
            else if (val.Equals("Ja"))
            {
                tbFT.Enabled = true;
                lista = host.GetActivitiesByDebit(anv, true).ToList();
            }
            if (lista.Count > 0)
            {
                foreach (var aktivitet in lista)
                {
                    lActivity.Items.Add(aktivitet);
                }
            }
            #endregion
        }

        private void lActivity_SelectedValueChanged(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion
            lProduct.Items.Clear();
            #region getprod
            string aktivitet = lActivity.SelectedItem.ToString();

            if (svar)
            {
                List<string> prod = new List<string>();
                prod = host.GetAllProductsByActivity(anv, aktivitet).ToList();
                if (prod.Count > 0)
                {
                    foreach (string product in prod)
                    {
                        string prodNr = product.Substring(0, product.IndexOf("?"));
                        string prodName = product.Substring(product.IndexOf("?") + 2);
                        lProduct.Items.Add(prodNr + ", " + prodName);
                    }
                }
                else
                {
                    lProduct.Items.Add("tom");
                }
            }
            #endregion
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region Insert
            if (svar)
            {
                TRservice.Tidsrad tidrad = new TestAvWCFApp.TRservice.Tidsrad();
                tidrad.custNo = host.GetCustNr(anv,lKundNr.SelectedItem.ToString());
                tidrad.ordNr = Convert.ToInt32(lOrder.SelectedItem.ToString().Substring(0, lOrder.SelectedItem.ToString().IndexOf(",")));
                tidrad.prodNo = lProduct.SelectedItem.ToString().Substring(0, lOrder.SelectedItem.ToString().IndexOf(",")-1);
                tidrad.debit = debitConvert(cb1.SelectedItem.ToString());
                tidrad.contract = Convert.ToInt32(lbl2.Text);
                tidrad.workedTime = Convert.ToInt32(tbWT.Text);
                tidrad.faktureradTime = Convert.ToInt32(tbFT.Text);
                tidrad.benamning = tbBe.Text;
                tidrad.internText = tbIn.Text;
                tidrad.frDt = Convert.ToInt32(tbFRDT.Text);
                tidrad.toDt = Convert.ToInt32(tbTODT.Text);
                tidrad.frTm = Convert.ToInt32(tbFRTM.Text);
                tidrad.toTm = Convert.ToInt32(tbTOTM.Text);
                tidrad.service = serviceCovert(lService.SelectedItem.ToString());
                tidrad.project = projectConvert(lProject.SelectedItem.ToString());
                tidrad.activity = lActivity.SelectedItem.ToString();
                string respond = host.InsertNewTimeLine(tidrad, anv);
                MessageBox.Show(respond);
            }

            #endregion
        }

        private bool debitConvert(string debit)
        {
            if (debit.Equals("Ja"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string serviceCovert(string service)
        {
            string nyStr = "";
            if (!service.Equals("tom") || !service.Equals(null) || !service.Equals(string.Empty))
            {
                nyStr = service.Substring(0, service.IndexOf("-") - 1);
            }
            return nyStr;
        }

        private string projectConvert(string proj)
        {
            string nyStr = "";
            if (!proj.Equals("tom") || ! proj.Equals(null) || !proj.Equals(string.Empty))
            {
                nyStr = proj.Substring(0, proj.IndexOf(","));
            }
            return nyStr;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string service = lService.SelectedItem.ToString();
            string proj = lProject.SelectedItem.ToString();
            if (!(!service.Equals("tom") || !service.Equals(null) || !service.Equals(string.Empty)))
            {
                label12.Text = service.Substring(0, service.IndexOf("-")-1);
            }
            label13.Text = lProduct.SelectedItem.ToString().Substring(0, lOrder.SelectedItem.ToString().IndexOf(",") - 1);
        }

    }
}
