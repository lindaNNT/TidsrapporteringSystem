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
        #region startup
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion


    #region events
        private void btn1_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = tb1.Text;
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);
            lbl1.Text = svar.ToString();

            #endregion

            #region hämta användaruppgifter
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
            #endregion

            #region getprod
            //Test av getProd

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
            #endregion

            #region flex för en månad
            //Test av flextimmar
            if (svar)
            {
                string flex = host.GetMonthFlexForLogOnUser(anv, tb2.Text);
                lbl6.Text = "Flex: " + flex;
            }
            #endregion

            #region Totalflex
            //Test av total flextimmar
            if (svar)
            {
                string totFlex = host.GetTotalFlexForLogOnUser(anv);
                lbl6.Text += " Totalflex: " + totFlex;
            }
            #endregion

            #region hämta semesterdagar
            //Test ac semesterdagar
            if (svar)
            {
                List<DateTime> datumlista = new List<DateTime>();
                datumlista = host.GetHolidayForLogOnUser(anv, tb2.Text).ToList();
                if (datumlista.Count > 0)
                {
                    mc1.BoldedDates = datumlista.ToArray();
                }
                else
                {
                    lbl7.Text = "finns inget.";
                }
            }
            #endregion

            #region hämta tidrad på ett viss datum.
            //Test ac semesterdagar
            if (svar)
            {
                TRservice.Tidsrad tidsrad = host.GetLastTimeLineHistoryForSpecificDate(anv, tb2.Text);
                if (!tidsrad.Equals(null) || !tidsrad.Equals(String.Empty))
                {
                    string text = "Kundnamn: " + tidsrad.custName +
                                    "\nOrder: " + tidsrad.ordNr +
                                    "\nArbeted tid: " + tidsrad.workedTime +
                                    "\nDebiterad tid: " + tidsrad.faktureradTime +
                                    "\nArtikel: " + tidsrad.prodNo +
                                    "\nBenämning: " + tidsrad.benamning +
                                    "\nIntern text: " + tidsrad.internText +
                                    "\nDatum från: " + tidsrad.frDt +
                                    "\nDatum till: " + tidsrad.toDt +
                                    "\nTid Från: " + tidsrad.frTm + 
                                    "\nTid Till: " + tidsrad.toTm + 
                                    "\nKontrakt: " + tidsrad.contract +
                                    "\nService: " + tidsrad.service + 
                                    "\nDebit: " + tidsrad.debit + 
                                    "\nAktivitet: " + tidsrad.activity + 
                                    "\nProdukt nr: " + tidsrad.activity + 
                                    "\nProjekt: " + tidsrad.project + 
                                    "\nDefault activity: " + tidsrad.defaultActivity
                                    ;
                    lbl8.Text = text;
                }
                else
                {
                    lbl8.Text = "finns inget.";
                }
            }
            #endregion

        }
   #endregion

        #region Privata metoder

        #region extract date

        #endregion

        #endregion
    }
}
