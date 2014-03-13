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

            #region flex
            //Test av flextimmar
            if (svar)
            {
                string flex = host.GetFlexForLogOnUser(anv, tb2.Text);
                lbl6.Text = "Flex: " + flex;
            }
            #endregion

            #region hämta semesterdagar
            //Test ac semesterdagar
            if (svar)
            {
                List<string> holidayList = new List<string>();
                holidayList = host.GetHolidayForLogOnUser(anv, tb2.Text).ToList();
                List<DateTime> datumlista = new List<DateTime>();
                if (holidayList.Count > 0)
                {
                    lbl7.Text = "Semester: ";
                    foreach (string holiday in holidayList)
                    {
                        lbl7.Text += holiday + " " + extractDay(holiday) + "\n";
                        DateTime datetime = new DateTime((extractYear(holiday)), (extractMonth(holiday)), (extractDay(holiday)), 0, 0, 0, 0);
                        datumlista.Add(datetime);
                    }
                    mc1.BoldedDates = datumlista.ToArray();
                }
                else
                {
                    lbl7.Text = "finns inget.";
                }
            }
            #endregion
        }
#endregion

        #region Privata metoder

        #region extract date
        private int extractYear(string date)
        {
            string year = date.Substring(0, 4);
            return Convert.ToInt32(year);
        }

        private int extractMonth(string date)
        {
            string month = date.Substring(4, 2);
            if (month.Contains("0"))
            {
                month = month.Substring(1, 1);
            }
            int result = Convert.ToInt32(month);
            return result;
        }

        private int extractDay(string date)
        {
            string day = date.Substring(6, 2);
            if (day.Contains("0"))
            {
                day = day.Substring(1, 1);
            }
            int result = Convert.ToInt32(day);
            return result;
        }
        #endregion
#endregion
    }
}
