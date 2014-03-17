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

            //if (svar)
            //{
            //    rt1.Text = "";
            //    List<string> prod = new List<string>();
            //    prod = host.GetAllProducts(anv).ToList();
            //    if (prod.Count > 0)
            //    {
            //        foreach (string product in prod)
            //        {
            //            rt1.Text += product + "\n";
            //        }
            //    }
            //    else
            //    {
            //        rt1.Text = "finns inget.";
            //    }
            //}
            #endregion

            #region flex för en månad
            //Test av flextimmar
            //if (svar)
            //{
            //    string flex = host.GetMonthFlexForLogOnUser(anv, tb2.Text);
            //    lbl6.Text = "Flex: " + flex;
            //}
            #endregion

            #region Totalflex
            //Test av total flextimmar
            //if (svar)
            //{
            //    string totFlex = host.GetTotalFlexForLogOnUser(anv);
            //    lbl6.Text += " Totalflex: " + totFlex;
            //}
            #endregion

            #region hämta semesterdagar
            //Test ac semesterdagar
            //if (svar)
            //{
            //    List<DateTime> datumlista = new List<DateTime>();
            //    datumlista = host.GetHolidayForLogOnUser(anv, tb2.Text).ToList();
            //    if (datumlista.Count > 0)
            //    {
            //        mc1.BoldedDates = datumlista.ToArray();
            //    }
            //    else
            //    {
            //        lbl7.Text = "finns inget.";
            //    }
            //}
            #endregion

            #region hämta senaste dagen man gjorde en insättning.

            //if (svar)
            //{
            //    string senasteDatum = host.GetLastInsertedDay(anv);
            //    lbl9.Text = " Senaste Datum: " + senasteDatum;
            //}

            #endregion

            #region hämta den senaste tidraden på ett viss datum.
            // Test av semesterdagar
            //if (svar)
            //{
            //    TRservice.Tidsrad tidsrad = host.GetLastTimeLineInsertedForSpecificDate(anv, tb2.Text);
            //    if (!tidsrad.Equals(null) || !tidsrad.Equals(String.Empty))
            //    {
            //        string text = "Kundnamn: " + tidsrad.custName +
            //                        "\nOrder: " + tidsrad.ordNr +
            //                        "\nArbeted tid: " + tidsrad.workedTime +
            //                        "\nDebiterad tid: " + tidsrad.faktureradTime +
            //                        "\nArtikel: " + tidsrad.prodNo +
            //                        "\nBenämning: " + tidsrad.benamning +
            //                        "\nIntern text: " + tidsrad.internText +
            //                        "\nDatum från: " + tidsrad.frDt +
            //                        "\nDatum till: " + tidsrad.toDt +
            //                        "\nTid Från: " + tidsrad.frTm + 
            //                        "\nTid Till: " + tidsrad.toTm + 
            //                        "\nKontrakt: " + tidsrad.contract +
            //                        "\nService: " + tidsrad.service + 
            //                        "\nDebit: " + tidsrad.debit + 
            //                        "\nAktivitet: " + tidsrad.activity + 
            //                        "\nProdukt nr: " + tidsrad.activity + 
            //                        "\nProjekt: " + tidsrad.project + 
            //                        "\nDefault activity: " + tidsrad.defaultActivity
            //                        ;
            //        lbl8.Text = text;
            //    }
            //    else
            //    {
            //        lbl8.Text = "finns inget.";
            //    }
            //}
            #endregion

            #region hämta alla tidsrader från en dag.
            //if (svar)
            //{
            //    List<TRservice.Tidsrad> tidsradLista = host.GetAllInsertedTimeLineOnOneDay(anv, tb2.Text).ToList();
            //    if (!tidsradLista.Equals(null) || !tidsradLista.Equals(String.Empty))
            //    {
            //        string text = "";
            //        foreach (TRservice.Tidsrad tidsrad in tidsradLista)
            //        {
            //            text += "Kundnamn: " + tidsrad.custName +
            //                            "\nOrder: " + tidsrad.ordNr +
            //                            "\nArbeted tid: " + tidsrad.workedTime +
            //                            "\nDebiterad tid: " + tidsrad.faktureradTime +
            //                            "\nArtikel: " + tidsrad.prodNo +
            //                            "\nBenämning: " + tidsrad.benamning +
            //                            "\nIntern text: " + tidsrad.internText +
            //                            "\nDatum från: " + tidsrad.frDt +
            //                            "\nDatum till: " + tidsrad.toDt +
            //                            "\nTid Från: " + tidsrad.frTm +
            //                            "\nTid Till: " + tidsrad.toTm +
            //                            "\nKontrakt: " + tidsrad.contract +
            //                            "\nService: " + tidsrad.service +
            //                            "\nDebit: " + tidsrad.debit +
            //                            "\nAktivitet: " + tidsrad.activity +
            //                            "\nProdukt nr: " + tidsrad.activity +
            //                            "\nProjekt: " + tidsrad.project +
            //                            "\nDefault activity: " + tidsrad.defaultActivity + "\n\n"
            //                            ;
            //        }

            //        rt1.Text = text;
            //    }
            //    else
            //    {
            //        lbl8.Text = "finns inget.";
            //    }
            #endregion

            #region hämta alla dagar med ngt inlagd
            //if (svar)
            //{
            //    rt1.Text = "";
            //    IEnumerable<TRservice.DayStatus> list = host.GetAllInsertedDaysOfAMonth(anv, tb2.Text);
            //    if (!list.Equals(null) || !list.Equals(String.Empty))
            //    {
            //        string text = "";
            //        foreach (var obj in list)
            //        {
            //            text += obj.date + "\n" + obj.status + "\n" + obj.color + "\n\n"; 
            //        }

            //        rt1.Text = text;
            //    }
            //    else
            //    {
            //        lbl8.Text = "finns inget.";
            //    }
            //}
            #endregion

            #region Insättning
            if (svar)
            {
                TRservice.Tidsrad tidsrad = new TRservice.Tidsrad();
                tidsrad.activity = "test";
                tidsrad.benamning = "test inlägg";
                tidsrad.contract = 1;
                tidsrad.custNo = 1;
                tidsrad.debit = false;
                tidsrad.faktureradTime = 0;
                tidsrad.frDt = 20140317;
                tidsrad.toDt = 20140317;
                tidsrad.frTm = 1200;
                tidsrad.toTm = 1300;
                tidsrad.workedTime = 1;
                tidsrad.service = "";
                tidsrad.project = "";
                tidsrad.prodNo = "1";
                tidsrad.internText = "test";
                tidsrad.ordNr = 1;
                string respond = host.InsertNewTimeLine(tidsrad, anv);
                lbl9.Text = respond;
            }

            #endregion
        }
   #endregion

        private void btnInsatt_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Visible = true;
        }


        #region Privata metoder

        #region extract date

        #endregion

        #endregion
    }
}
