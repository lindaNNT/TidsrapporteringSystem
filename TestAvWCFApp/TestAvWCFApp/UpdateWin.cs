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
    public partial class UpdateWin : Form
    {
        public UpdateWin()
        {
            InitializeComponent();
        }

        private void UpdateWin_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);

            #endregion

            #region hämta den senaste tidraden på ett viss datum.
             
            if (svar)
            {
                TRservice.Tidsrad tidsrad = host.GetLastTimeLineInsertedForSpecificDate(anv, tbGet.Text);
                if (!tidsrad.Equals(null) || !tidsrad.Equals(String.Empty))
                {
                    tbAgrNo.Text = tidsrad.agrNo.ToString();
                    tbAgrActNo.Text = tidsrad.agrActNo.ToString();
                    tbFrDt.Text = tidsrad.frDt.ToString();
                    tbToDt.Text = tidsrad.toDt.ToString();
                    tbFrTM.Text = tidsrad.frTm.ToString();
                    tbToTM.Text = tidsrad.toTm.ToString();
                    tbKundNr.Text = tidsrad.custNo.ToString();
                    tbOrderNr.Text = tidsrad.ordNr.ToString();
                    tbutlagg.Text = tidsrad.utlagg.ToString();
                    tbProdNo.Text = tidsrad.prodNo;
                    tbDebit.Text = tidsrad.debit.ToString();
                    tbContract.Text = tidsrad.contract.ToString();
                    tbWT.Text = tidsrad.workedTime.ToString();
                    tbFT.Text = tidsrad.faktureradTime.ToString();
                    tbAdwage.Text = tidsrad.adWage.ToString();
                    tbBe.Text = tidsrad.benamning;
                    tbIntern.Text = tidsrad.internText;
                    tbDefault.Text = tidsrad.defaultActivity.ToString();
                    tbService.Text = tidsrad.service;
                    tbProje.Text = tidsrad.project;
                    tbActivity.Text = tidsrad.activity;
                }
                else
                {
                    MessageBox.Show("finns inget");
                }
            }
            #endregion
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);

            #endregion

            #region Update tidrad.

            if (svar)
            {
                TRservice.Tidsrad tid = new TestAvWCFApp.TRservice.Tidsrad();

                    tid.agrNo = Convert.ToInt32(tbAgrNo.Text);
                    tid.agrActNo = Convert.ToInt32(tbAgrActNo.Text);
                    tid.frDt = Convert.ToInt32(tbFrDt.Text);
                    tid.toDt = Convert.ToInt32(tbToDt.Text);
                    tid.frTm = Convert.ToInt32(tbFrTM.Text);
                    tid.toTm = Convert.ToInt32(tbToTM.Text);
                    tid.custNo = Convert.ToInt32(tbKundNr.Text);
                    tid.ordNr = Convert.ToInt32(tbOrderNr.Text);
                    tid.utlagg = Convert.ToBoolean(tbutlagg.Text);
                    tid.prodNo = tbProdNo.Text;
                    tid.debit = Convert.ToBoolean(tbDebit.Text);
                    tid.contract = Convert.ToInt32(tbContract.Text);
                    tid.workedTime = Convert.ToInt32(tbWT.Text);
                    tid.faktureradTime = Convert.ToInt32(tbFT.Text);
                    tid.adWage = Convert.ToBoolean(tbAdwage.Text);
                    tid.benamning = tbBe.Text;
                    tid.internText = tbIntern.Text;
                    tid.defaultActivity = Convert.ToBoolean(tbDefault.Text);
                    tid.service = tbService.Text;
                    tid.project = tbProje.Text;
                    tid.activity = tbActivity.Text;
                string respond = host.UpdateTimeLine(tid, anv);
                MessageBox.Show(respond);
                }
                else
                {
                    
                }
            }
            #endregion

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region logga in
            string anv = "linda";
            TRservice.TidsrapporteringServiceClient host = new TRservice.TidsrapporteringServiceClient();
            bool svar = host.LogIn(anv);

            #endregion

            #region Delete tidrad.

            if (svar)
            {
                TRservice.Tidsrad tid = new TestAvWCFApp.TRservice.Tidsrad();

                    tid.agrNo = Convert.ToInt32(tbAgrNo.Text);
                    tid.agrActNo = Convert.ToInt32(tbAgrActNo.Text);
                    tid.frDt = Convert.ToInt32(tbFrDt.Text);
                    tid.toDt = Convert.ToInt32(tbToDt.Text);
                    tid.frTm = Convert.ToInt32(tbFrTM.Text);
                    tid.toTm = Convert.ToInt32(tbToTM.Text);
                    tid.custNo = Convert.ToInt32(tbKundNr.Text);
                    tid.ordNr = Convert.ToInt32(tbOrderNr.Text);
                    tid.utlagg = Convert.ToBoolean(tbutlagg.Text);
                    tid.prodNo = tbProdNo.Text;
                    tid.debit = Convert.ToBoolean(tbDebit.Text);
                    tid.contract = Convert.ToInt32(tbContract.Text);
                    tid.workedTime = Convert.ToInt32(tbWT.Text);
                    tid.faktureradTime = Convert.ToInt32(tbFT.Text);
                    tid.adWage = Convert.ToBoolean(tbAdwage.Text);
                    tid.benamning = tbBe.Text;
                    tid.internText = tbIntern.Text;
                    tid.defaultActivity = Convert.ToBoolean(tbDefault.Text);
                    tid.service = tbService.Text;
                    tid.project = tbProje.Text;
                    tid.activity = tbActivity.Text;
                string respond = host.DeleteTimeLine(tid, anv);
                MessageBox.Show(respond);
                }
                else
                {
                    
                }
            #endregion
            }
        }
        

        
    }

