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
using System.Data.SqlClient;
using System.Threading;
using System.Collections.Generic;

namespace DataLayer
{
    public class DBHandler : ConfigFile
    {
        private static Mutex mutex = new Mutex();
        private SqlConnection connection;
        private SqlCommand cmd;
        private string connectionString = string.Empty;   //To hold the database-connection
        private string username;

        public DBHandler(string username)
        {
            /* Sets the connection */
            connectionString = @"user id=" + dbUser + "; password=" + dbPass + "; server=" + dbServer + "; Trusted_Connection=false; database="
                                + dbName + "; connection timeout=10";
            connection = new SqlConnection(this.connectionString);

            this.username = username;
        }

        /* For the admin-panel */
        public DBHandler(string user, string pass, string server, string name)
        {
            /* Sets the connection */
            connectionString = @"user id=" + user + "; password=" + pass + "; server=" + server + "; Trusted_Connection=false; database="
                                + name + "; connection timeout=10";
            connection = new SqlConnection(this.connectionString);
        }

        /// <summary>
        /// Gets the real name of a user
        /// </summary>
        /// <param name="username">The user we want the name of</param>
        /// <returns>Returns a string with the name</returns>
        public string getRealName()
        {
            string name = string.Empty;

            // Set up a command
            string commandText = "Select nm From Actor " +
                                 "Where usr = @user";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        name = Convert.ToString(reader[0]).Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return name;
        }

        /// <summary>
        /// Checks if a user exists
        /// </summary>
        /// <returns>Returns true if user exists else false</returns>
        public bool existsUser()
        {
            // Set up a command
            string commandText = "Select empno From Actor " +
                                 "Where usr = @user";

            int value = selectIntValueWithUser(commandText);
            if (value != -1)    //User exists
                return true;
            else
                return false;
        }


        #region Get - Visma Column values

        #region Primary Key
        public int getAgractno()
        {
            // Set up a command
            string commandText = "Select actno From Actor " +
                                 "Where usr = @user";

            return this.selectIntValueWithUser(commandText);
        }
        private int getAgrno()
        {
            int Agractno = getAgractno();

            int value = -1;

            // Set up a command
            string commandText = "Select max(Agrno) From Agr " +
                                 "Where Agractno = @Agractno";

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@Agractno", SqlDbType.Int).Value = Agractno;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        if (!string.IsNullOrEmpty(reader[0].ToString()))
                        {
                            value = Convert.ToInt32(reader[0]);
                            value += 1;
                        }
                        else
                            value = 1;
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        #endregion

        #region Ord
        private int getLiaactno(int orderNo)
        {
            // Set up a command
            string commandText = "Select liaactno From Ord " +
                                 "Where ordNo = @orderNo";

            return this.selectIntValueWithOrderNo(commandText, orderNo);
        }
        private int getCur(int orderNo)
        {
            // Set up a command
            string commandText = "Select cur From Ord " +
                                 "Where ordNo = @orderNo";

            return this.selectIntValueWithOrderNo(commandText, orderNo);
        }
        private int getExrt(int orderNo)
        {
            // Set up a command
            string commandText = "Select exrt From Ord " +
                                 "Where ordNo = @orderNo";

            return this.selectIntValueWithOrderNo(commandText, orderNo);
        }
        private int getInvocust(int orderNo)
        {
            // Set up a command
            string commandText = "Select invocust From Ord " +
                                 "Where ordNo = @orderNo";

            return this.selectIntValueWithOrderNo(commandText, orderNo);
        }
        private int getOrdlnno()
        {
            //First time is zero
            return 0;
        }
        #endregion

        #region Prod
        private int getUn(string prodNo)
        {
            // Set up a command
            string commandText = "Select stsaleun From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }
        private int getPrm1(string prodNo)
        {
            // Set up a command
            string commandText = "Select procmt From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }
        private int getPrm2(string prodNo)
        {
            // Set up a command
            string commandText = "Select excprint From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }
        private int getPrm3(string prodNo)
        {
            // Set up a command
            string commandText = "Select editpref From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }
        private int getPrm4(string prodNo)
        {
            // Set up a command
            string commandText = "Select edfmt From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }
        private int getPrm5(string prodNo)
        {
            // Set up a command
            string commandText = "Select expstr From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }   ////////////////////////////////KANSKE FEL
        private int getAgrproc(string prodNo)
        {
            // Set up a command
            string commandText = "Select agrproc From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectIntValueWithProdNo(commandText, prodNo);
        }
        private string getWagesrt(string prodNo)
        {
            // Set up a command
            string commandText = "Select wagesrt From Prod " +
                                 "Where ProdNo = @prodNo";

            return this.selectStringValueWithProdNo(commandText, prodNo);
        }
        #endregion

        #region Customer
        private int getCustno(string customerName)
        {
            int value = -1;

            // Set up a command
            string commandText = "Select custno From Actor " +
                                 "Where nm = @customer";

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = customerName;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int getActno(int custNo)
        {
            // Set up a command
            string commandText = "Select actno From Actor " +
                                 "Where CustNo = @custNo";

            return this.selectIntValueWithCustNo(commandText, custNo);
        }
        private int getLocale()
        {
            // Set up a command
            string commandText = "Select r1 From Actor " +
                                 "Where usr = @user";

            return this.selectIntValueWithUser(commandText);
        }
        private int getEmpno()
        {
            // Set up a command
            string commandText = "Select empno From Actor " +
                                 "Where usr = @user";

            return this.selectIntValueWithUser(commandText);
        }
        #endregion

        #region Prices

        #region Emp - Price
        private double getCstpr(string prodNo, bool debit)
        {
            double costPrice = 0;
            int empNo = this.getEmpno();
            //int debitCode = this.getDebitCode(debit);

            // Set up a command
            string commandText = "Select cstpr From Prdcmat " +
                                 "Where empno = @empno and prodno = @prodno and cstpr != 0 and custprgr = 0";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empno", SqlDbType.Int).Value = empNo;
            cmd.Parameters.Add("@prodno", SqlDbType.VarChar).Value = prodNo;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        costPrice = Convert.ToDouble(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }


            //if (costPrice == 0)
            //{
            //    commandText = "Select cstpr From Prdcmat " +
            //                  "Where prodno = @prodno and prodprgr = @prodprgr and cstpr != 0 and custprgr = 0";
            //    cmd = new SqlCommand(commandText, connection);

            //    /* Set the param */
            //    cmd.Parameters.Add("@prodno", SqlDbType.VarChar).Value = prodNo;
            //    cmd.Parameters.Add("@prodprgr", SqlDbType.Int).Value = debitCode;

            //    try
            //    {
            //        using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
            //        {
            //            while (reader.Read())   //Read the message and saves it
            //            {
            //                costPrice = Convert.ToDouble(reader[0]);
            //            }
            //            reader.Close(); //Message reader close
            //        }
            //    }
            //    catch { }            
            //}
            return costPrice;
        }
        private double getCcstpr(string prodNo, bool debit)
        {
            return this.getCstpr(prodNo, debit);
        }
        private double getCinccst(string prodNo, bool debit, double timeInHour)
        {
            double costPr = this.getCstpr(prodNo, debit);
            return timeInHour * costPr;
        }
        private double getInccst(string prodNo, bool debit, double timeInHour)
        {
            return this.getCinccst(prodNo, debit, timeInHour);
        }
        #endregion

        #region Customer - Price
        private double getPrice(int custNo, string prodNo, bool debit, int contract, double timeInHour)
        {
            DataTable customerDT = new DataTable();
            //int debitCode = this.getDebitCode(debit);
            double value = 0;
            double minDebit = getMinam(custNo, prodNo, debit);  //Gets the min debit for a customer

            string commandText = "Select salepr, CustNo, R5 From Prdcmat " +
                                 "Where prodno = @prodNo and salepr > 0  and empno = 0";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;
            //cmd.Parameters.Add("@prodprgr", SqlDbType.Int).Value = debitCode;

            try
            {
                /* Reads the result and puts it in a dataTable */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    customerDT.Load(reader);
                    reader.Close(); //Message reader close   
                }
            }
            catch { }

            double salePrice = 0;
            /* Must check for a specific customer and contract also, so i can determine the right price */
            DataRow[] results = customerDT.Select("CustNo = " + custNo.ToString() + " AND R5 = " + contract.ToString());
            if (results.Count() > 0)
            {
                //Price for the specific customer with a contract
                salePrice = Convert.ToDouble(results[0]["SalePr"]);

                return this.checkMinam(salePrice, timeInHour, minDebit);
            }

            results = customerDT.Select("CustNo = " + custNo.ToString());
            if (results.Count() > 0)
            {
                //Price for the specific customer
                salePrice = Convert.ToDouble(results[0]["SalePr"]);

                return this.checkMinam(salePrice, timeInHour, minDebit);
            }

            results = customerDT.Select("R5 = " + contract.ToString());
            if (results.Count() > 0)
            {
                //Price for the specific contract
                salePrice = Convert.ToDouble(results[0]["SalePr"]);

                return this.checkMinam(salePrice, timeInHour, minDebit);
            }

            results = customerDT.Select("CustNo = 0 AND R5 = 0");
            if (results.Count() > 0)
            {
                //The price is global, no specific customer or contract
                salePrice = Convert.ToDouble(results[0]["SalePr"]);

                return this.checkMinam(salePrice, timeInHour, minDebit);
            }
            return value;   //There's no price
        }
        private double getDpr(int custNo, string prodNo, bool debit, int contract, double timeInHour)
        {
            return this.getPrice(custNo, prodNo, debit, contract, timeInHour);
        }
        private double getAm(int custNo, string prodNo, bool debit, int contract, double timeInHour, bool calcWithDiscount)
        {
            double salePr = this.getPrice(custNo, prodNo, debit, contract, timeInHour); //Gets the sale price
            double sum = timeInHour * salePr;   //Calculates the price with the time
            double minDebit = getMinam(custNo, prodNo, debit);  //Gets the min debit for a customer

            if (minDebit > 0)   //If this customer has a min debit, check it out
            {
                if (sum < minDebit) //If the sum is less than the min debit, then set the sum to that
                    sum = minDebit;
            }

            if (calcWithDiscount)   //Calc the new sum, if there is a discount
            {
                double summaWithDiscount = sum * (this.getDc1p(prodNo, debit, this.getRightCustprgr("custprgr", custNo), custNo, contract) / 100);
                sum -= summaWithDiscount;
            }

            return sum;
        }
        private double getDam(int custNo, string prodNo, bool debit, int contract, double timeInHour)
        {
            return this.getAm(custNo, prodNo, debit, contract, timeInHour, false);
        }
        private double getMinam(int custNo, string prodNo, bool debit)
        {
            double value = 0;
            int debitCode = this.getDebitCode(debit);

            string commandText = "Select minam From Prdcmat " +
                          "Where custNo = @custNo and prodno = @prodNo and prodprgr = @prodprgr and salepr > 0  and empno = 0";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@custNo", SqlDbType.Int).Value = custNo;
            cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;
            cmd.Parameters.Add("@prodprgr", SqlDbType.Int).Value = debitCode;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            if (value == 0)
            {
                commandText = "Select minam From Prdcmat " +
                              "Where prodno = @prodNo and prodprgr = @prodprgr and salepr > 0  and empno = 0";
                cmd = new SqlCommand(commandText, connection);

                /* Set the param */
                cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;
                cmd.Parameters.Add("@prodprgr", SqlDbType.Int).Value = debitCode;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                    {
                        while (reader.Read())   //Read the message and saves it
                        {
                            value = Convert.ToInt32(reader[0]);
                        }
                        reader.Close(); //Message reader close
                    }
                }
                catch { }
            }
            return value;
        }
        private double getDc1p(string prodNo, bool debit, int custprgr, int custNo, int contract)
        {
            DataTable customerDT = new DataTable();
            int debitCode = this.getDebitCode(debit);
            double value = 0;

            string commandText = "Select saledcp, CustNo, R5 From Prdcmat " +
                                 "Where prodno = @prodNo and prodprgr = @prodprgr and custprgr = @custprgr and empno = 0";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;
            cmd.Parameters.Add("@prodprgr", SqlDbType.Int).Value = debitCode;
            cmd.Parameters.Add("@custprgr", SqlDbType.Int).Value = custprgr;

            try
            {
                /* Reads the result and puts it in a dataTable */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    customerDT.Load(reader);
                    reader.Close(); //Message reader close   
                }
            }
            catch { }

            /* Must check for a specific customer and contract also, so i can determine the right discount */
            DataRow[] results = customerDT.Select("CustNo = " + custNo.ToString() + " AND R5 = " + contract.ToString());
            if (results.Count() > 0)
            {
                //Price for the specific customer with a contract
                return Convert.ToDouble(results[0]["SaleDcP"]);
            }

            results = customerDT.Select("CustNo = " + custNo.ToString());
            if (results.Count() > 0)
            {
                //Price for the specific customer
                return Convert.ToDouble(results[0]["SaleDcP"]);
            }

            results = customerDT.Select("R5 = " + contract.ToString());
            if (results.Count() > 0)
            {
                //Price for the specific contract
                return Convert.ToDouble(results[0]["SaleDcP"]);
            }

            results = customerDT.Select("CustNo = 0 AND R5 = 0");
            if (results.Count() > 0)
            {
                //The discount is global, no specific customer or contract
                return Convert.ToDouble(results[0]["SaleDcP"]);
            }

            if (debit == false)
                value = 100;

            return value;   //There's no discount
        }
        private double checkMinam(double salePrice, double timeInHour, double minDebit)
        {
            if (timeInHour != 0)
            {
                if ((salePrice * timeInHour) < minDebit)
                    return (minDebit / timeInHour);
                else
                    return salePrice;
            }
            return 0;
        }
        #endregion

        #endregion


        private float getNoregdy(float workedTime)
        {
            return workedTime / 60;
        }
        private float getNoinvody(float faktureradTime)
        {
            return faktureradTime / 60;
        }

        private int getSrt()
        {
            int value = 0;
            int empNo = this.getEmpno();

            string commandText = "select max(srt) from agr " +
                                 "where empno = @empno";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empno", SqlDbType.VarChar).Value = empNo;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        if (!string.IsNullOrEmpty(reader[0].ToString()))
                        {
                            value = Convert.ToInt32(reader[0]);
                            value += 1;
                        }
                        else
                            value = 1;
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int getRefno()
        {
            int value = 0;

            string commandText = "select max(refno) from agr";
            cmd = new SqlCommand(commandText, connection);

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        if (!string.IsNullOrEmpty(reader[0].ToString()))
                        {
                            value = Convert.ToInt32(reader[0]);
                            value += 1;
                        }
                        else
                            value = 1;
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        private int getDupl()
        {
            return 0;
        }
        private int getDup2()
        {
            return 0;
        }
        private int getLckst()
        {
            return 0;
        }
        private int getChprc()
        {
            return 0;
        }

        private int getAcyrpr(int frdt)
        {
            return Convert.ToInt32(frdt.ToString().Substring(0, 6));
        }
        private int getCractno()
        {
            return this.getAgractno();
        }

        private string getCreusr()
        {
            return username;
        }
        private int getCredt()
        {
            return Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
        }
        private DateTime getCurrentTime()
        {
            return DateTime.Now;
        }
        private int getCretm(DateTime time)
        {
            return Convert.ToInt32(time.ToString("HHmm"));
        }

        /* First time - use CREATE not change */
        private int getChdt()
        {
            return getCredt();
        }
        private int getChtm(DateTime time)
        {
            return getCretm(time);
        }
        private int getChtmms(DateTime chTime)
        {
            return Convert.ToInt32(chTime.TimeOfDay.TotalMilliseconds);
        }
        private string getChusr()
        {
            return username;
        }

        #region Constants from the Config-File
        private int getDebitCode(bool debit)
        {
            if (debit)
                return debiteraCode;
            else
                return debitEjCode;
        }
        private int getAdwage1(bool adWage)
        {
            if (adWage)
                return adWTrue;
            else
                return adWFalse;
        }
        public int getInvo(bool utlagg)
        {
            if (utlagg)
                return invoUtl;
            else
                return invoReg;
        }
        private int getPri(bool defaultActivity)
        {
            if (defaultActivity)
                return nPriAct;
            else
                return oPriAct;
        }
        private int getCacset(int orderNo)
        {
            // Set up a command
            string commandText = "Select acset From Ord " +
                                 "Where ordNo = @orderNo";

            return this.selectIntValueWithOrderNo(commandText, orderNo);
            //if (defaultActivity)
            //    return nCacset;
            //else
            //    return oCacset;
        }
        private int getFin()
        {
            return fin;
        }

        private int getRightRInt(string currentR, int contract)
        {
            string rType = getRType(currentR);

            if (string.IsNullOrEmpty(rType))
                return 0;
            else
            {
                switch (rType)
                {
                    case "Locale":
                        return this.getLocale();
                    case "Contract":
                        return contract;
                }
            }
            return 0;
        }
        private string getRightRString(string currentR, string service, string project)
        {
            string rType = getRType(currentR);

            if (string.IsNullOrEmpty(rType))
                return string.Empty;
            else
            {
                switch (rType)
                {
                    case "Service":
                        return service;
                    case "Project":
                        return project;
                }
            }
            return string.Empty;
        }
        private int getRightProdprgr(string currentProdprgr, bool debit, bool utlagg, string activity)
        {
            string prodType = getProdPrType(currentProdprgr);

            if (string.IsNullOrEmpty(prodType))
                return -1;
            else
            {
                switch (prodType)
                {
                    case "Debit":
                        {
                            if (debit)
                                return 0;
                            else
                                return 1;
                        }
                    case "Utlagg":
                        {
                            if (utlagg)
                                return 1;
                            else
                                return 0;
                        }
                    case "Activity":
                        {
                            int value = -1;

                            // Set up a command
                            string commandText = "select txtno from Txt " +
                                                 "where txttp = @activityCode and lang = @lang and txt = @activity";
                            cmd = new SqlCommand(commandText, connection);

                            /* Set the param */
                            cmd.Parameters.Add("@activity", SqlDbType.VarChar).Value = activity;
                            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = lang;
                            cmd.Parameters.Add("@activityCode", SqlDbType.Int).Value = activityID;

                            try
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                                {
                                    while (reader.Read())   //Read the message and saves it
                                    {
                                        value = Convert.ToInt32(reader[0]);
                                    }
                                    reader.Close(); //Message reader close
                                }
                            }
                            catch { }
                            return value;
                        }
                    case "": //Empty
                        {   //Correct???
                            return 0;
                        }
                }
            }
            return -1;
        }
        private int getRightCustprgr(string currentCustprgr, int custNo)
        {
            string custType = getCustPrType(currentCustprgr);

            if (string.IsNullOrEmpty(custType))
                return 0;
            else
            {
                switch (custType)
                {
                    case "Price1":
                        {
                            // Set up a command
                            string commandText = "Select custprgr From Actor " +
                                                 "Where CustNo = @custNo";

                            return this.selectIntValueWithCustNo(commandText, custNo);
                        }
                    case "Price2":
                        {
                            // Set up a command
                            string commandText = "Select custprg2 From Actor " +
                                                 "Where CustNo = @custNo";

                            return this.selectIntValueWithCustNo(commandText, custNo);
                        }
                    case "Price3":
                        {
                            // Set up a command
                            string commandText = "Select custprg3 From Actor " +
                                                 "Where CustNo = @custNo";

                            return this.selectIntValueWithCustNo(commandText, custNo);
                        }
                }
            }
            return 0;
        }
        #endregion

        #region Select statments
        private int selectIntValueWithCustNo(string command, int custNo)
        {
            int value = -1;

            cmd = new SqlCommand(command, connection);

            /* Set the param */
            cmd.Parameters.Add("@custNo", SqlDbType.Int).Value = custNo;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private string selectStringValueWithProdNo(string command, string prodNo)
        {
            string value = string.Empty;

            cmd = new SqlCommand(command, connection);

            /* Set the param */
            cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToString(reader[0]).Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int selectIntValueWithProdNo(string command, string prodNo)
        {
            int value = -1;

            cmd = new SqlCommand(command, connection);

            /* Set the param */
            cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int selectIntValueWithOrderNo(string command, int orderNo)
        {
            int value = -1;

            cmd = new SqlCommand(command, connection);

            /* Set the param */
            cmd.Parameters.Add("@orderNo", SqlDbType.Int).Value = orderNo;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int selectIntValueWithUser(string command)
        {
            int value = -1;

            cmd = new SqlCommand(command, connection);

            /* Set the param */
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private SqlCommand selectQueryWithEmpNo(string selectCol)
        {
            int empNo = this.getEmpno();

            // Set up a command
            string commandText = "Select " + selectCol + " From Actor " +
                                 "Where empNo = @empNo";
            SqlCommand cmd2 = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd2.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;

            return cmd2;
        }
        #endregion

        #region Zero's - But knows maybe theirs value
        private string getExtid()
        {
            string value = string.Empty;
            cmd = selectQueryWithEmpNo("extid");

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToString(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private double getChext()
        {
            double value = -1;
            cmd = selectQueryWithEmpNo("chext");

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToDouble(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int getEmpprgr()
        {
            int value = -1;
            cmd = selectQueryWithEmpNo("empprgr");

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int getActtmzn()
        {
            int value = -1;
            cmd = selectQueryWithEmpNo("tmzn");

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        private int getTransgr(int orderNo)
        {
            // Set up a command
            string commandText = "Select transgr From Ord " +
                                 "Where ordNo = @orderNo";

            return this.selectIntValueWithOrderNo(commandText, orderNo);
        }
        #endregion

        #region Empty Columns
        #region Float Zero
        private float getDc1am()
        {
            return 0;
        }
        private float getDc1dam()
        {
            return 0;
        }
        #endregion

        #region Int Zero
        private int getDypri()
        {
            return 0;
        }
        private int getAdwage2()
        {
            return 0;
        }
        private int getGmt()
        {
            return 0;
        }
        private int getAgrtmzn()
        {
            return 0;
        }
        private int getTsbfryrpr()
        {
            return 0;
        }
        private int getTsbtoyrpr()
        {
            return 0;
        }
        private int getTsproc()
        {
            return 0;
        }
        private int getWgrunno()
        {
            return 0;
        }
        private int getRsp()
        {
            return 0;
        }
        private int getRsptp()
        {
            return 0;
        }
        private int getPriv()
        {
            return 0;
        }
        private int getRsvtm()
        {
            return 0;
        }
        private int getRsvtmun()
        {
            return 0;
        }
        private int getNtf()
        {
            return 0;
        }
        private int getNtftm()
        {
            return 0;
        }
        private int getNtftmun()
        {
            return 0;
        }
        private int getStrst()
        {
            return 0;
        }
        private int getChsm()
        {
            return 0;
        }
        private int getDt1()
        {
            return 0;
        }
        private int getDt2()
        {
            return 0;
        }
        private int getTm1()
        {
            return 0;
        }
        private int getTm2()
        {
            return 0;
        }
        private int getGr()
        {
            return 0;
        }
        private int getGr2()
        {
            return 0;
        }
        private int getGr3()
        {
            return 0;
        }
        private int getGr4()
        {
            return 0;
        }
        private int getGr5()
        {
            return 0;
        }
        private int getGr6()
        {
            return 0;
        }
        private int getGr7()
        {
            return 0;
        }
        private int getGr8()
        {
            return 0;
        }
        private int getGr9()
        {
            return 0;
        }
        private int getGr10()
        {
            return 0;
        }
        private int getGr11()
        {
            return 0;
        }
        private int getGr12()
        {
            return 0;
        }
        private int getExtproc()
        {
            return 0;
        }
        private int getMaagract()
        {
            return 0;
        }
        private int getMaagrno()
        {
            return 0;
        }
        private int getResno()
        {
            return 0;
        }
        private int getD1hr()
        {
            return 0;
        }
        private int getD2hr()
        {
            return 0;
        }
        private int getD3hr()
        {
            return 0;
        }
        private int getD4hr()
        {
            return 0;
        }
        private int getD5hr()
        {
            return 0;
        }
        private int getD6hr()
        {
            return 0;
        }
        private int getD7hr()
        {
            return 0;
        }
        private int getStcno()
        {
            return 0;
        }
        private int getWagertno()
        {
            return 0;
        }
        private int getDebdy()
        {
            return 0;
        }
        private int getPropno()
        {
            return 0;
        }
        private int getTsgrno()
        {
            return 0;
        }
        #endregion

        #region String Zero
        private string getTxt1()
        {
            return string.Empty;
        }
        private string getTxt2()
        {
            return string.Empty;
        }
        #endregion
        #endregion

        #endregion

        #region Update/Insert - DB info

        /// <summary>
        /// Update a timeline.
        /// </summary>
        /// <returns>string</returns>
        public string updateTimeLine( int custNo, int ordNo, bool utlagg, 
                                    string prodNo, bool debit, int contract, 
                                    float workedTime, float faktureradTime, 
                                    bool adWage, string descr, string descr2, 
                                    bool defaultActivity, int frDt, int toDt, 
                                    int frTm, int toTm, string service, 
                                    string project, string activity, int argNr)
        {

            string commandText = "UPDATE [F0001].[dbo].[agr] SET " +
                                    #region set parameters
                                     "FrDt = @FrDt, ToDt = @ToDt, FrTm = @FrTm, ToTm = @ToTm," +
                                     "NoReg = @NoReg, NoInvoAb = @NoInvoAb, Pri = @Pri, DyPri = @DyPri, " +
                                     "ProdNo = @ProdNo, ActNo = @ActNo, LiaActNo = @LiaActNo, " +
                                     "OrdNo = @OrdNo, Descr = @Descr, R1 = @R1, R2 = @R2, R3 = @R3, " +
                                     "R4 = @R4, R5 = @R5, R6 = @R6, RspTp = @RspTp, Priv = @Priv, " +
                                     "RsvTm = @RsvTm, RsvTmUn = @RsvTmUn, Ntf = @Ntf, NtfTm = @NtfTm, " +
                                     "NtfTmUn = @NtfTmUn, Fin = @Fin, FinDt = @FinDt, StrSt = @StrSt,  " +
                                     "Invo = @Invo, NoteNm = @NoteNm, Srt = @Srt, ChDt = @ChDt, " +
                                     "ChTm = @ChTm, ChUsr = @ChUsr, LckSt = @LckSt, ChPrc = @ChPrc, " +
                                     "ChSm = @ChSm, CrActNo = @CrActNo, Dt1 = @Dt1, Tm1 = @Tm1,  " +
                                     "Dt2 = @Dt2, Tm2= @Tm2, PropNo = @PropNo, Gr = @Gr, " +
                                     "Gr2 = @Gr2, Gr3 = @Gr3, Gr4 = @Gr4, Gr5 = @Gr5, Gr6 = @Gr6, " +
                                     "Gr7 = @Gr7, Gr8 = @Gr8, Gr9 = @Gr9, Gr10 = @Gr10, Gr11 = @Gr11, Gr12 = @Gr12, " +
                                     "Descr2 = @Descr2, ExtID = @ExtID, ExtProc = @ExtProc,  " +
                                     "ChExt = @ChExt, CustNo = @CustNo, InvoCust = @InvoCust, Txt1 = @Txt1, " +
                                     "Txt2 = @Txt2, TransGr = @TransGr, MaAgrAct = @MaAgrAct, MaAgrNo = @MaAgrNo, " +
                                     "ResNo = @ResNo, R7 = @R7, R8 = @R8, R9 = @R9, R10 = @R10, R11 = @R11, R12 = @R12, " +
                                     "RefNo = @RefNo, AcYrPr = @AcYrPr, CCstPr = @CCstPr, CIncCst = @CIncCst, " +
                                     "DPr = @DPr, DAm = @DAm, D1Hr = @D1Hr, D2Hr = @D2Hr, D3Hr = @D3Hr,  " +
                                     "D4Hr = @D4Hr, D5Hr = @D5Hr, D6Hr = @D6Hr, D7Hr = @D7Hr,  " +
                                     "OrdLnNo = @OrdLnNo, Price = @Price, Cur = @Cur, ExRt = @ExRt, " +
                                     "AgrProc = @AgrProc, CstPr = @CstPr, IncCst = @IncCst, WageSrt = @WageSrt, " +
                                     "ProdPrGr = @ProdPrGr, ProdPrG2 = @ProdPrG2, ProdPrG3 = @ProdPrG3, CustPrGr = @CustPrGr, " +
                                     "CustPrG2 = @CustPrG2, CustPrG3 = @CustPrG3, StcNo = @StcNo, Un = @Un, " +
                                     "PrM1 = @PrM1, PrM2 = @PrM2, PrM3 = @PrM3, PrM4 = @PrM4, PrM5 = @PrM5, " +
                                     "Dc1P = @Dc1P, Dupl = @Dupl, Dup2 = @Dup2, Am = @Am, WageRtNo = @WageRtNo, " +
                                     "EmpPrGr = @EmpPrGr, Dc1Am = @Dc1Am, Dc1DAm = @Dc1DAm, AdWage1 = @AdWage1, " +
                                     "AdWage2 = @AdWage2, GMT = @GMT, AgrTmZn = @AgrTmZn, ActTmZn = @ActTmZn, " +
                                     "CreUsr = @CreUsr, CreDt = @CreDt, CreTm = @CreTm, TSGrNo = @TSGrNo, " +
                                     "TSBFrYrPr = @TSBFrYrPr, TSBToYrPr = @TSBToYrPr, TSProc = @TSProc, " +
                                     "CAcSet = @CAcSet, WgRunNo = @WgRunNo, DebDy = @DebDy, " +
                                     "NoRegDy = @NoRegDy, NoInvoDy = @NoInvoDy, Rsp = @Rsp, " +
                                     "ChTmms = @ChTmms, ProdProcNo = @ProdProcNo " +

                                    #endregion
                                 "WHERE AgrActNo = @agrActNo AND AgrNo = @actNo AND EmpNo = @empNo";
            
            int creDate = this.getCredt();
            DateTime time = this.getCurrentTime();
            int creTime = this.getCretm(time);

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            #region Params
            //Row 1
            cmd.Parameters.Add("@AgrActNo", SqlDbType.Int).Value = this.getAgractno();
            cmd.Parameters.Add("@AgrNo", SqlDbType.Int).Value = argNr;
            cmd.Parameters.Add("@FrDt", SqlDbType.Int).Value = frDt;
            cmd.Parameters.Add("@ToDt", SqlDbType.Int).Value = toDt;
            cmd.Parameters.Add("@FrTm", SqlDbType.SmallInt).Value = frTm;
            cmd.Parameters.Add("@ToTm", SqlDbType.SmallInt).Value = toTm;
            cmd.Parameters.Add("@NoReg", SqlDbType.Decimal).Value = workedTime; //Minutes
            cmd.Parameters.Add("@NoInvoAb", SqlDbType.Decimal).Value = faktureradTime; //Minutes
            cmd.Parameters.Add("@Pri", SqlDbType.Int).Value = this.getPri(defaultActivity);
            cmd.Parameters.Add("@DyPri", SqlDbType.Int).Value = this.getDypri();
            cmd.Parameters.Add("@ProdNo", SqlDbType.VarChar).Value = prodNo;
            cmd.Parameters.Add("@ActNo", SqlDbType.Int).Value = this.getActno(custNo);
            cmd.Parameters.Add("@LiaActNo", SqlDbType.Int).Value = this.getLiaactno(ordNo);

            workedTime = this.getNoregdy(workedTime);
            faktureradTime = this.getNoregdy(faktureradTime);

            //Row 2
            cmd.Parameters.Add("@OrdNo", SqlDbType.Int).Value = ordNo;
            cmd.Parameters.Add("@Descr", SqlDbType.VarChar).Value = descr; //Benämning
            cmd.Parameters.Add("@R1", SqlDbType.Int).Value = this.getRightRInt("r1", contract);
            cmd.Parameters.Add("@R2", SqlDbType.Int).Value = this.getRightRInt("r2", contract);
            cmd.Parameters.Add("@R3", SqlDbType.Int).Value = this.getRightRInt("r3", contract);
            cmd.Parameters.Add("@R4", SqlDbType.Int).Value = this.getRightRInt("r4", contract);
            cmd.Parameters.Add("@R5", SqlDbType.Int).Value = this.getRightRInt("r5", contract);
            cmd.Parameters.Add("@R6", SqlDbType.Int).Value = this.getRightRInt("r6", contract);
            cmd.Parameters.Add("@RspTp", SqlDbType.Int).Value = this.getRsptp();
            cmd.Parameters.Add("@Priv", SqlDbType.TinyInt).Value = this.getPriv();
            cmd.Parameters.Add("@RsvTm", SqlDbType.SmallInt).Value = this.getRsvtm();
            cmd.Parameters.Add("@RsvTmUn", SqlDbType.TinyInt).Value = this.getRsvtmun();
            cmd.Parameters.Add("@Ntf", SqlDbType.TinyInt).Value = this.getNtf();
            cmd.Parameters.Add("@NtfTm", SqlDbType.Int).Value = this.getNtftm();
            cmd.Parameters.Add("@NtfTmUn", SqlDbType.TinyInt).Value = this.getNtftmun();
            cmd.Parameters.Add("@Fin", SqlDbType.TinyInt).Value = this.getFin();
            cmd.Parameters.Add("@FinDt", SqlDbType.Int).Value = toDt;

            //Row 3
            cmd.Parameters.Add("@StrSt", SqlDbType.TinyInt).Value = this.getStrst();
            cmd.Parameters.Add("@Invo", SqlDbType.Int).Value = this.getInvo(utlagg);//////////////////////////////////////
            cmd.Parameters.Add("@NoteNm", SqlDbType.VarChar).Value = string.Empty;/////////////////////////////////vet ej
            cmd.Parameters.Add("@Srt", SqlDbType.Int).Value = this.getSrt();
            cmd.Parameters.Add("@ChDt", SqlDbType.Int).Value = creDate;    // this.getChdt();
            cmd.Parameters.Add("@ChTm", SqlDbType.SmallInt).Value = creTime;   // this.getChtm();
            cmd.Parameters.Add("@ChUsr", SqlDbType.VarChar).Value = this.getChusr();
            cmd.Parameters.Add("@LckSt", SqlDbType.TinyInt).Value = this.getLckst();
            cmd.Parameters.Add("@ChPrc", SqlDbType.Int).Value = this.getChprc();
            cmd.Parameters.Add("@ChSm", SqlDbType.Int).Value = this.getChsm();
            cmd.Parameters.Add("@CrActNo", SqlDbType.Int).Value = this.getCractno();
            cmd.Parameters.Add("@Dt1", SqlDbType.Int).Value = this.getDt1();
            cmd.Parameters.Add("@Tm1", SqlDbType.SmallInt).Value = this.getTm1();
            cmd.Parameters.Add("@Dt2", SqlDbType.Int).Value = this.getDt2();
            cmd.Parameters.Add("@Tm2", SqlDbType.SmallInt).Value = this.getTm2();
            cmd.Parameters.Add("@PropNo", SqlDbType.Int).Value = this.getPropno();
            cmd.Parameters.Add("@Gr", SqlDbType.Int).Value = this.getGr();

            //Row 4
            cmd.Parameters.Add("@Gr2", SqlDbType.Int).Value = this.getGr2();
            cmd.Parameters.Add("@Gr3", SqlDbType.Int).Value = this.getGr3();
            cmd.Parameters.Add("@Gr4", SqlDbType.Int).Value = this.getGr4();
            cmd.Parameters.Add("@Gr5", SqlDbType.Int).Value = this.getGr5();
            cmd.Parameters.Add("@Gr6", SqlDbType.Int).Value = this.getGr6();
            cmd.Parameters.Add("@Gr7", SqlDbType.Int).Value = this.getGr7();
            cmd.Parameters.Add("@Gr8", SqlDbType.Int).Value = this.getGr8();
            cmd.Parameters.Add("@Gr9", SqlDbType.Int).Value = this.getGr9();
            cmd.Parameters.Add("@Gr10", SqlDbType.Int).Value = this.getGr10();
            cmd.Parameters.Add("@Gr11", SqlDbType.Int).Value = this.getGr11();
            cmd.Parameters.Add("@Gr12", SqlDbType.Int).Value = this.getGr12();
            cmd.Parameters.Add("@Descr2", SqlDbType.VarChar).Value = descr2;   //Intern text
            cmd.Parameters.Add("@ExtID", SqlDbType.VarChar).Value = this.getExtid();
            cmd.Parameters.Add("@ExtProc", SqlDbType.TinyInt).Value = this.getExtproc();
            cmd.Parameters.Add("@ChExt", SqlDbType.Decimal).Value = this.getChext();
            cmd.Parameters.Add("@CustNo", SqlDbType.Int).Value = custNo;
            cmd.Parameters.Add("@InvoCust", SqlDbType.Int).Value = this.getInvocust(ordNo);
            cmd.Parameters.Add("@Txt1", SqlDbType.VarChar).Value = this.getTxt1();

            //Row 5
            cmd.Parameters.Add("@Txt2", SqlDbType.VarChar).Value = this.getTxt2();
            cmd.Parameters.Add("@TransGr", SqlDbType.Int).Value = this.getTransgr(ordNo);
            cmd.Parameters.Add("@MaAgrAct", SqlDbType.Int).Value = this.getMaagract();
            cmd.Parameters.Add("@MaAgrNo", SqlDbType.Int).Value = this.getMaagrno();
            cmd.Parameters.Add("@ResNo", SqlDbType.Int).Value = this.getResno();
            cmd.Parameters.Add("@R7", SqlDbType.VarChar).Value = this.getRightRString("r7", service, project);
            cmd.Parameters.Add("@R8", SqlDbType.VarChar).Value = this.getRightRString("r8", service, project);
            cmd.Parameters.Add("@R9", SqlDbType.VarChar).Value = this.getRightRString("r9", service, project);
            cmd.Parameters.Add("@R10", SqlDbType.VarChar).Value = this.getRightRString("r10", service, project);
            cmd.Parameters.Add("@R11", SqlDbType.VarChar).Value = this.getRightRString("r11", service, project);
            cmd.Parameters.Add("@R12", SqlDbType.VarChar).Value = this.getRightRString("r12", service, project);
            cmd.Parameters.Add("@RefNo", SqlDbType.Int).Value = this.getRefno();
            cmd.Parameters.Add("@AcYrPr", SqlDbType.Int).Value = this.getAcyrpr(frDt);
            cmd.Parameters.Add("@CCstPr", SqlDbType.Decimal).Value = this.getCcstpr(prodNo, debit);
            cmd.Parameters.Add("@CIncCst", SqlDbType.Decimal).Value = this.getCinccst(prodNo, debit, workedTime);
            cmd.Parameters.Add("@DPr", SqlDbType.Decimal).Value = this.getDpr(custNo, prodNo, debit, contract, faktureradTime);
            cmd.Parameters.Add("@DAm", SqlDbType.Decimal).Value = this.getDam(custNo, prodNo, debit, contract, faktureradTime);

            //Row 6
            cmd.Parameters.Add("@D1Hr", SqlDbType.Int).Value = this.getD1hr();
            cmd.Parameters.Add("@D2Hr", SqlDbType.Int).Value = this.getD2hr();
            cmd.Parameters.Add("@D3Hr", SqlDbType.Int).Value = this.getD3hr();
            cmd.Parameters.Add("@D4Hr", SqlDbType.Int).Value = this.getD4hr();
            cmd.Parameters.Add("@D5Hr", SqlDbType.Int).Value = this.getD5hr();
            cmd.Parameters.Add("@D6Hr", SqlDbType.Int).Value = this.getD6hr();
            cmd.Parameters.Add("@D7Hr", SqlDbType.Int).Value = this.getD7hr();
            cmd.Parameters.Add("@OrdLnNo", SqlDbType.Int).Value = this.getOrdlnno();
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = this.getPrice(custNo, prodNo, debit, contract, faktureradTime);
            cmd.Parameters.Add("@Cur", SqlDbType.Int).Value = this.getCur(ordNo);
            cmd.Parameters.Add("@ExRt", SqlDbType.Decimal).Value = this.getExrt(ordNo);
            cmd.Parameters.Add("@AgrProc", SqlDbType.Int).Value = this.getAgrproc(prodNo);///////////////////////////////////////////
            cmd.Parameters.Add("@CstPr", SqlDbType.Decimal).Value = this.getCstpr(prodNo, debit);
            cmd.Parameters.Add("@IncCst", SqlDbType.Decimal).Value = this.getInccst(prodNo, debit, workedTime);
            cmd.Parameters.Add("@WageSrt", SqlDbType.VarChar).Value = this.getWagesrt(prodNo);
            cmd.Parameters.Add("@ProdPrGr", SqlDbType.Int).Value = this.getRightProdprgr("prodprgr", debit, utlagg, activity);

            //Row 7
            int custprgr = this.getRightCustprgr("custprgr", custNo);
            cmd.Parameters.Add("@ProdPrG2", SqlDbType.Int).Value = this.getRightProdprgr("prodprg2", debit, utlagg, activity);
            cmd.Parameters.Add("@ProdPrG3", SqlDbType.Int).Value = this.getRightProdprgr("prodprg3", debit, utlagg, activity);
            cmd.Parameters.Add("@CustPrGr", SqlDbType.Int).Value = custprgr;
            cmd.Parameters.Add("@CustPrG2", SqlDbType.Int).Value = this.getRightCustprgr("custprg2", custNo);
            cmd.Parameters.Add("@CustPrG3", SqlDbType.Int).Value = this.getRightCustprgr("custprg3", custNo);
            cmd.Parameters.Add("@StcNo", SqlDbType.Int).Value = this.getStcno();
            cmd.Parameters.Add("@EmpNo", SqlDbType.Int).Value = this.getEmpno();
            cmd.Parameters.Add("@Un", SqlDbType.Int).Value = this.getUn(prodNo);
            cmd.Parameters.Add("@PrM1", SqlDbType.Int).Value = this.getPrm1(prodNo);
            cmd.Parameters.Add("@PrM2", SqlDbType.Int).Value = this.getPrm2(prodNo);
            cmd.Parameters.Add("@PrM3", SqlDbType.Int).Value = this.getPrm3(prodNo);
            cmd.Parameters.Add("@PrM4", SqlDbType.Int).Value = this.getPrm4(prodNo);
            cmd.Parameters.Add("@PrM5", SqlDbType.Int).Value = this.getPrm5(prodNo);
            cmd.Parameters.Add("@Dc1P", SqlDbType.Decimal).Value = this.getDc1p(prodNo, debit, custprgr, custNo, contract);
            cmd.Parameters.Add("@Dupl", SqlDbType.Int).Value = this.getDupl();
            cmd.Parameters.Add("@Dup2", SqlDbType.Int).Value = this.getDup2();

            //Row 8
            cmd.Parameters.Add("@Am", SqlDbType.Decimal).Value = this.getAm(custNo, prodNo, debit, contract, faktureradTime, true);
            cmd.Parameters.Add("@WageRtNo", SqlDbType.Int).Value = this.getWagertno();
            cmd.Parameters.Add("@EmpPrGr", SqlDbType.Int).Value = this.getEmpprgr();
            cmd.Parameters.Add("@Dc1Am", SqlDbType.Decimal).Value = this.getDc1am();
            cmd.Parameters.Add("@Dc1DAm", SqlDbType.Decimal).Value = this.getDc1dam();
            cmd.Parameters.Add("@AdWage1", SqlDbType.Int).Value = this.getAdwage1(adWage);
            cmd.Parameters.Add("@AdWage2", SqlDbType.Int).Value = this.getAdwage2();
            cmd.Parameters.Add("@GMT", SqlDbType.SmallInt).Value = this.getGmt();
            cmd.Parameters.Add("@AgrTmZn", SqlDbType.Int).Value = this.getAgrtmzn();
            cmd.Parameters.Add("@ActTmZn", SqlDbType.Int).Value = this.getActtmzn();
            cmd.Parameters.Add("@CreUsr", SqlDbType.VarChar).Value = this.getCreusr();
            cmd.Parameters.Add("@CreDt", SqlDbType.Int).Value = creDate;
            cmd.Parameters.Add("@CreTm", SqlDbType.SmallInt).Value = creTime;
            cmd.Parameters.Add("@TSGrNo", SqlDbType.Int).Value = this.getTsgrno();

            //Row 9
            cmd.Parameters.Add("@TSBFrYrPr", SqlDbType.Int).Value = this.getTsbfryrpr();
            cmd.Parameters.Add("@TSBToYrPr", SqlDbType.Int).Value = this.getTsbtoyrpr();
            cmd.Parameters.Add("@TSProc", SqlDbType.Int).Value = this.getTsproc();
            cmd.Parameters.Add("@CAcSet", SqlDbType.Int).Value = this.getCacset(ordNo);
            cmd.Parameters.Add("@WgRunNo", SqlDbType.Int).Value = this.getWgrunno();
            cmd.Parameters.Add("@DebDy", SqlDbType.Int).Value = this.getDebdy();
            cmd.Parameters.Add("@NoRegDy", SqlDbType.Decimal).Value = workedTime;
            cmd.Parameters.Add("@NoInvoDy", SqlDbType.Decimal).Value = faktureradTime;
            cmd.Parameters.Add("@Rsp", SqlDbType.Int).Value = this.getRsp();
            cmd.Parameters.Add("@ChTmms", SqlDbType.Int).Value = this.getChtmms(time);
            cmd.Parameters.Add("@ProdProcNo", SqlDbType.Int).Value = 0;
            #endregion
            string respond = "";
            try
            {
                //Tries to run the command
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    respond = "Update Success";
                }
                else
                {
                    respond = "Update Fail";
                }
            }
            catch(Exception e)
            {
                respond = e.Message;
            }
            return respond;
        }


        public bool update(string txt)
        {
            //Tries to connect to database
            try { this.connection.Open(); }
            catch { }

            // Set up a command
            string commandText = "Update Actor " +
                                 "Set usr = @txt " +
                                 "Where usr = @user";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@txt", SqlDbType.VarChar).Value = "dk";
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = "rikwes";

            try
            {
                //Tries to run the command
                int rowEffected = cmd.ExecuteNonQuery();
                if (rowEffected > 0)
                    return true;
                else
                    return false;
            }
            catch { }
            finally
            {
                try { this.connection.Close(); }    //Datasbase connection close
                catch { }
            }
            return false;
        }



        public bool insert(int custNo, int ordNo, bool utlagg, string prodNo, bool debit, int contract, float workedTime,
                            float faktureradTime, bool adWage, string descr, string descr2, bool defaultActivity, int frDt, int toDt, int frTm, int toTm,
                            string service, string project, string activity)
        {
            // Wait until it is safe to enter
            mutex.WaitOne();

            try
            {
                int creDate = this.getCredt();
                DateTime time = this.getCurrentTime();
                int creTime = this.getCretm(time);

                // Set up a command
                //Agrproc??????
                //invo ??????? <- kanske klar
                string commandText = "INSERT INTO Agr " +
                                     "(AgrActNo, AgrNo, FrDt, ToDt, FrTm, ToTm, NoReg, NoInvoAb, Pri, DyPri, ProdNo, ActNo, LiaActNo, " +
                                     "OrdNo, Descr, R1, R2, R3, R4, R5, R6, RspTp, Priv, RsvTm, RsvTmUn, Ntf, NtfTm, NtfTmUn, Fin, FinDt, " +
                                     "StrSt, Invo, NoteNm, Srt, ChDt, ChTm, ChUsr, LckSt, ChPrc, ChSm, CrActNo, Dt1, Tm1, Dt2, Tm2, PropNo, Gr," +
                                     "Gr2, Gr3, Gr4, Gr5, Gr6, Gr7, Gr8, Gr9, Gr10, Gr11, Gr12, Descr2, ExtID, ExtProc, ChExt, CustNo, InvoCust, Txt1, " +
                                     "Txt2, TransGr, MaAgrAct, MaAgrNo, ResNo, R7, R8, R9, R10, R11, R12, RefNo, AcYrPr, CCstPr, CIncCst, DPr, DAm, " +
                                     "D1Hr, D2Hr, D3Hr, D4Hr, D5Hr, D6Hr, D7Hr, OrdLnNo, Price, Cur, ExRt, AgrProc, CstPr, IncCst, WageSrt, ProdPrGr, " +
                                     "ProdPrG2, ProdPrG3, CustPrGr, CustPrG2, CustPrG3, StcNo, EmpNo, Un, PrM1, PrM2, PrM3, PrM4, PrM5, Dc1P, Dupl, Dup2, " +
                                     "Am, WageRtNo, EmpPrGr, Dc1Am, Dc1DAm, AdWage1, AdWage2, GMT, AgrTmZn, ActTmZn, CreUsr, CreDt, CreTm, TSGrNo, " +
                                     "TSBFrYrPr, TSBToYrPr, TSProc, CAcSet, WgRunNo, DebDy, NoRegDy, NoInvoDy, Rsp, ChTmms, ProdProcNo)" +
                                     " " +
                                     "VALUES(@AgrActNo, @AgrNo, @FrDt, @ToDt, @FrTm, @ToTm, @NoReg, @NoInvoAb, @Pri, @DyPri, @ProdNo, @ActNo, @LiaActNo, " +
                                     "@OrdNo, @Descr, @R1, @R2, @R3, @R4, @R5, @R6, @RspTp, @Priv, @RsvTm, @RsvTmUn, @Ntf, @NtfTm, @NtfTmUn, @Fin, @FinDt, " +
                                     "@StrSt, @Invo, @NoteNm, @Srt, @ChDt, @ChTm, @ChUsr, @LckSt, @ChPrc, @ChSm, @CrActNo, @Dt1, @Tm1, @Dt2, @Tm2, @PropNo, @Gr," +
                                     "@Gr2, @Gr3, @Gr4, @Gr5, @Gr6, @Gr7, @Gr8, @Gr9, @Gr10, @Gr11, @Gr12, @Descr2, @ExtID, @ExtProc, @ChExt, @CustNo, @InvoCust, @Txt1, " +
                                     "@Txt2, @TransGr, @MaAgrAct, @MaAgrNo, @ResNo, @R7, @R8, @R9, @R10, @R11, @R12, @RefNo, @AcYrPr, @CCstPr, @CIncCst, @DPr, @DAm, " +
                                     "@D1Hr, @D2Hr, @D3Hr, @D4Hr, @D5Hr, @D6Hr, @D7Hr, @OrdLnNo, @Price, @Cur, @ExRt, @AgrProc, @CstPr, @IncCst, @WageSrt, @ProdPrGr, " +
                                     "@ProdPrG2, @ProdPrG3, @CustPrGr, @CustPrG2, @CustPrG3, @StcNo, @EmpNo, @Un, @PrM1, @PrM2, @PrM3, @PrM4, @PrM5, @Dc1P, @Dupl, @Dup2, " +
                                     "@Am, @WageRtNo, @EmpPrGr, @Dc1Am, @Dc1DAm, @AdWage1, @AdWage2, @GMT, @AgrTmZn, @ActTmZn, @CreUsr, @CreDt, @CreTm, @TSGrNo, " +
                                     "@TSBFrYrPr, @TSBToYrPr, @TSProc, @CAcSet, @WgRunNo, @DebDy, @NoRegDy, @NoInvoDy, @Rsp, @ChTmms, @ProdProcNo)";

                SqlCommand cmd2 = new SqlCommand(commandText, connection);

                //TODO
                //What happens when changing stuff?????
                //Delete stuff
                //How to know if something has been attest (ordlnno > 0)

                /* Set the param */
                #region Params
                //Row 1
                cmd2.Parameters.Add("@AgrActNo", SqlDbType.Int).Value = this.getAgractno();
                cmd2.Parameters.Add("@AgrNo", SqlDbType.Int).Value = this.getAgrno();
                cmd2.Parameters.Add("@FrDt", SqlDbType.Int).Value = frDt;
                cmd2.Parameters.Add("@ToDt", SqlDbType.Int).Value = toDt;
                cmd2.Parameters.Add("@FrTm", SqlDbType.SmallInt).Value = frTm;
                cmd2.Parameters.Add("@ToTm", SqlDbType.SmallInt).Value = toTm;
                cmd2.Parameters.Add("@NoReg", SqlDbType.Decimal).Value = workedTime; //Minutes
                cmd2.Parameters.Add("@NoInvoAb", SqlDbType.Decimal).Value = faktureradTime; //Minutes
                cmd2.Parameters.Add("@Pri", SqlDbType.Int).Value = this.getPri(defaultActivity);
                cmd2.Parameters.Add("@DyPri", SqlDbType.Int).Value = this.getDypri();
                cmd2.Parameters.Add("@ProdNo", SqlDbType.VarChar).Value = prodNo;
                cmd2.Parameters.Add("@ActNo", SqlDbType.Int).Value = this.getActno(custNo);
                cmd2.Parameters.Add("@LiaActNo", SqlDbType.Int).Value = this.getLiaactno(ordNo);

                workedTime = this.getNoregdy(workedTime);
                faktureradTime = this.getNoregdy(faktureradTime);

                //Row 2
                cmd2.Parameters.Add("@OrdNo", SqlDbType.Int).Value = ordNo;
                cmd2.Parameters.Add("@Descr", SqlDbType.VarChar).Value = descr; //Benämning
                cmd2.Parameters.Add("@R1", SqlDbType.Int).Value = this.getRightRInt("r1", contract);
                cmd2.Parameters.Add("@R2", SqlDbType.Int).Value = this.getRightRInt("r2", contract);
                cmd2.Parameters.Add("@R3", SqlDbType.Int).Value = this.getRightRInt("r3", contract);
                cmd2.Parameters.Add("@R4", SqlDbType.Int).Value = this.getRightRInt("r4", contract);
                cmd2.Parameters.Add("@R5", SqlDbType.Int).Value = this.getRightRInt("r5", contract);
                cmd2.Parameters.Add("@R6", SqlDbType.Int).Value = this.getRightRInt("r6", contract);
                cmd2.Parameters.Add("@RspTp", SqlDbType.Int).Value = this.getRsptp();
                cmd2.Parameters.Add("@Priv", SqlDbType.TinyInt).Value = this.getPriv();
                cmd2.Parameters.Add("@RsvTm", SqlDbType.SmallInt).Value = this.getRsvtm();
                cmd2.Parameters.Add("@RsvTmUn", SqlDbType.TinyInt).Value = this.getRsvtmun();
                cmd2.Parameters.Add("@Ntf", SqlDbType.TinyInt).Value = this.getNtf();
                cmd2.Parameters.Add("@NtfTm", SqlDbType.Int).Value = this.getNtftm();
                cmd2.Parameters.Add("@NtfTmUn", SqlDbType.TinyInt).Value = this.getNtftmun();
                cmd2.Parameters.Add("@Fin", SqlDbType.TinyInt).Value = this.getFin();
                cmd2.Parameters.Add("@FinDt", SqlDbType.Int).Value = toDt;

                //Row 3
                cmd2.Parameters.Add("@StrSt", SqlDbType.TinyInt).Value = this.getStrst();
                cmd2.Parameters.Add("@Invo", SqlDbType.Int).Value = this.getInvo(utlagg);//////////////////////////////////////
                cmd2.Parameters.Add("@NoteNm", SqlDbType.VarChar).Value = string.Empty;/////////////////////////////////vet ej
                cmd2.Parameters.Add("@Srt", SqlDbType.Int).Value = this.getSrt();
                cmd2.Parameters.Add("@ChDt", SqlDbType.Int).Value = creDate;    // this.getChdt();
                cmd2.Parameters.Add("@ChTm", SqlDbType.SmallInt).Value = creTime;   // this.getChtm();
                cmd2.Parameters.Add("@ChUsr", SqlDbType.VarChar).Value = this.getChusr();
                cmd2.Parameters.Add("@LckSt", SqlDbType.TinyInt).Value = this.getLckst();
                cmd2.Parameters.Add("@ChPrc", SqlDbType.Int).Value = this.getChprc();
                cmd2.Parameters.Add("@ChSm", SqlDbType.Int).Value = this.getChsm();
                cmd2.Parameters.Add("@CrActNo", SqlDbType.Int).Value = this.getCractno();
                cmd2.Parameters.Add("@Dt1", SqlDbType.Int).Value = this.getDt1();
                cmd2.Parameters.Add("@Tm1", SqlDbType.SmallInt).Value = this.getTm1();
                cmd2.Parameters.Add("@Dt2", SqlDbType.Int).Value = this.getDt2();
                cmd2.Parameters.Add("@Tm2", SqlDbType.SmallInt).Value = this.getTm2();
                cmd2.Parameters.Add("@PropNo", SqlDbType.Int).Value = this.getPropno();
                cmd2.Parameters.Add("@Gr", SqlDbType.Int).Value = this.getGr();

                //Row 4
                cmd2.Parameters.Add("@Gr2", SqlDbType.Int).Value = this.getGr2();
                cmd2.Parameters.Add("@Gr3", SqlDbType.Int).Value = this.getGr3();
                cmd2.Parameters.Add("@Gr4", SqlDbType.Int).Value = this.getGr4();
                cmd2.Parameters.Add("@Gr5", SqlDbType.Int).Value = this.getGr5();
                cmd2.Parameters.Add("@Gr6", SqlDbType.Int).Value = this.getGr6();
                cmd2.Parameters.Add("@Gr7", SqlDbType.Int).Value = this.getGr7();
                cmd2.Parameters.Add("@Gr8", SqlDbType.Int).Value = this.getGr8();
                cmd2.Parameters.Add("@Gr9", SqlDbType.Int).Value = this.getGr9();
                cmd2.Parameters.Add("@Gr10", SqlDbType.Int).Value = this.getGr10();
                cmd2.Parameters.Add("@Gr11", SqlDbType.Int).Value = this.getGr11();
                cmd2.Parameters.Add("@Gr12", SqlDbType.Int).Value = this.getGr12();
                cmd2.Parameters.Add("@Descr2", SqlDbType.VarChar).Value = descr2;   //Intern text
                cmd2.Parameters.Add("@ExtID", SqlDbType.VarChar).Value = this.getExtid();
                cmd2.Parameters.Add("@ExtProc", SqlDbType.TinyInt).Value = this.getExtproc();
                cmd2.Parameters.Add("@ChExt", SqlDbType.Decimal).Value = this.getChext();
                cmd2.Parameters.Add("@CustNo", SqlDbType.Int).Value = custNo;
                cmd2.Parameters.Add("@InvoCust", SqlDbType.Int).Value = this.getInvocust(ordNo);
                cmd2.Parameters.Add("@Txt1", SqlDbType.VarChar).Value = this.getTxt1();

                //Row 5
                cmd2.Parameters.Add("@Txt2", SqlDbType.VarChar).Value = this.getTxt2();
                cmd2.Parameters.Add("@TransGr", SqlDbType.Int).Value = this.getTransgr(ordNo);
                cmd2.Parameters.Add("@MaAgrAct", SqlDbType.Int).Value = this.getMaagract();
                cmd2.Parameters.Add("@MaAgrNo", SqlDbType.Int).Value = this.getMaagrno();
                cmd2.Parameters.Add("@ResNo", SqlDbType.Int).Value = this.getResno();
                cmd2.Parameters.Add("@R7", SqlDbType.VarChar).Value = this.getRightRString("r7", service, project);
                cmd2.Parameters.Add("@R8", SqlDbType.VarChar).Value = this.getRightRString("r8", service, project);
                cmd2.Parameters.Add("@R9", SqlDbType.VarChar).Value = this.getRightRString("r9", service, project);
                cmd2.Parameters.Add("@R10", SqlDbType.VarChar).Value = this.getRightRString("r10", service, project);
                cmd2.Parameters.Add("@R11", SqlDbType.VarChar).Value = this.getRightRString("r11", service, project);
                cmd2.Parameters.Add("@R12", SqlDbType.VarChar).Value = this.getRightRString("r12", service, project);
                cmd2.Parameters.Add("@RefNo", SqlDbType.Int).Value = this.getRefno();
                cmd2.Parameters.Add("@AcYrPr", SqlDbType.Int).Value = this.getAcyrpr(frDt);
                cmd2.Parameters.Add("@CCstPr", SqlDbType.Decimal).Value = this.getCcstpr(prodNo, debit);
                cmd2.Parameters.Add("@CIncCst", SqlDbType.Decimal).Value = this.getCinccst(prodNo, debit, workedTime);
                cmd2.Parameters.Add("@DPr", SqlDbType.Decimal).Value = this.getDpr(custNo, prodNo, debit, contract, faktureradTime);
                cmd2.Parameters.Add("@DAm", SqlDbType.Decimal).Value = this.getDam(custNo, prodNo, debit, contract, faktureradTime);

                //Row 6
                cmd2.Parameters.Add("@D1Hr", SqlDbType.Int).Value = this.getD1hr();
                cmd2.Parameters.Add("@D2Hr", SqlDbType.Int).Value = this.getD2hr();
                cmd2.Parameters.Add("@D3Hr", SqlDbType.Int).Value = this.getD3hr();
                cmd2.Parameters.Add("@D4Hr", SqlDbType.Int).Value = this.getD4hr();
                cmd2.Parameters.Add("@D5Hr", SqlDbType.Int).Value = this.getD5hr();
                cmd2.Parameters.Add("@D6Hr", SqlDbType.Int).Value = this.getD6hr();
                cmd2.Parameters.Add("@D7Hr", SqlDbType.Int).Value = this.getD7hr();
                cmd2.Parameters.Add("@OrdLnNo", SqlDbType.Int).Value = this.getOrdlnno();
                cmd2.Parameters.Add("@Price", SqlDbType.Decimal).Value = this.getPrice(custNo, prodNo, debit, contract, faktureradTime);
                cmd2.Parameters.Add("@Cur", SqlDbType.Int).Value = this.getCur(ordNo);
                cmd2.Parameters.Add("@ExRt", SqlDbType.Decimal).Value = this.getExrt(ordNo);
                cmd2.Parameters.Add("@AgrProc", SqlDbType.Int).Value = this.getAgrproc(prodNo);///////////////////////////////////////////
                cmd2.Parameters.Add("@CstPr", SqlDbType.Decimal).Value = this.getCstpr(prodNo, debit);
                cmd2.Parameters.Add("@IncCst", SqlDbType.Decimal).Value = this.getInccst(prodNo, debit, workedTime);
                cmd2.Parameters.Add("@WageSrt", SqlDbType.VarChar).Value = this.getWagesrt(prodNo);
                cmd2.Parameters.Add("@ProdPrGr", SqlDbType.Int).Value = this.getRightProdprgr("prodprgr", debit, utlagg, activity);

                //Row 7
                int custprgr = this.getRightCustprgr("custprgr", custNo);
                cmd2.Parameters.Add("@ProdPrG2", SqlDbType.Int).Value = this.getRightProdprgr("prodprg2", debit, utlagg, activity);
                cmd2.Parameters.Add("@ProdPrG3", SqlDbType.Int).Value = this.getRightProdprgr("prodprg3", debit, utlagg, activity);
                cmd2.Parameters.Add("@CustPrGr", SqlDbType.Int).Value = custprgr;
                cmd2.Parameters.Add("@CustPrG2", SqlDbType.Int).Value = this.getRightCustprgr("custprg2", custNo);
                cmd2.Parameters.Add("@CustPrG3", SqlDbType.Int).Value = this.getRightCustprgr("custprg3", custNo);
                cmd2.Parameters.Add("@StcNo", SqlDbType.Int).Value = this.getStcno();
                cmd2.Parameters.Add("@EmpNo", SqlDbType.Int).Value = this.getEmpno();
                cmd2.Parameters.Add("@Un", SqlDbType.Int).Value = this.getUn(prodNo);
                cmd2.Parameters.Add("@PrM1", SqlDbType.Int).Value = this.getPrm1(prodNo);
                cmd2.Parameters.Add("@PrM2", SqlDbType.Int).Value = this.getPrm2(prodNo);
                cmd2.Parameters.Add("@PrM3", SqlDbType.Int).Value = this.getPrm3(prodNo);
                cmd2.Parameters.Add("@PrM4", SqlDbType.Int).Value = this.getPrm4(prodNo);
                cmd2.Parameters.Add("@PrM5", SqlDbType.Int).Value = this.getPrm5(prodNo);
                cmd2.Parameters.Add("@Dc1P", SqlDbType.Decimal).Value = this.getDc1p(prodNo, debit, custprgr, custNo, contract);
                cmd2.Parameters.Add("@Dupl", SqlDbType.Int).Value = this.getDupl();
                cmd2.Parameters.Add("@Dup2", SqlDbType.Int).Value = this.getDup2();

                //Row 8
                cmd2.Parameters.Add("@Am", SqlDbType.Decimal).Value = this.getAm(custNo, prodNo, debit, contract, faktureradTime, true);
                cmd2.Parameters.Add("@WageRtNo", SqlDbType.Int).Value = this.getWagertno();
                cmd2.Parameters.Add("@EmpPrGr", SqlDbType.Int).Value = this.getEmpprgr();
                cmd2.Parameters.Add("@Dc1Am", SqlDbType.Decimal).Value = this.getDc1am();
                cmd2.Parameters.Add("@Dc1DAm", SqlDbType.Decimal).Value = this.getDc1dam();
                cmd2.Parameters.Add("@AdWage1", SqlDbType.Int).Value = this.getAdwage1(adWage);
                cmd2.Parameters.Add("@AdWage2", SqlDbType.Int).Value = this.getAdwage2();
                cmd2.Parameters.Add("@GMT", SqlDbType.SmallInt).Value = this.getGmt();
                cmd2.Parameters.Add("@AgrTmZn", SqlDbType.Int).Value = this.getAgrtmzn();
                cmd2.Parameters.Add("@ActTmZn", SqlDbType.Int).Value = this.getActtmzn();
                cmd2.Parameters.Add("@CreUsr", SqlDbType.VarChar).Value = this.getCreusr();
                cmd2.Parameters.Add("@CreDt", SqlDbType.Int).Value = creDate;
                cmd2.Parameters.Add("@CreTm", SqlDbType.SmallInt).Value = creTime;
                cmd2.Parameters.Add("@TSGrNo", SqlDbType.Int).Value = this.getTsgrno();

                //Row 9
                cmd2.Parameters.Add("@TSBFrYrPr", SqlDbType.Int).Value = this.getTsbfryrpr();
                cmd2.Parameters.Add("@TSBToYrPr", SqlDbType.Int).Value = this.getTsbtoyrpr();
                cmd2.Parameters.Add("@TSProc", SqlDbType.Int).Value = this.getTsproc();
                cmd2.Parameters.Add("@CAcSet", SqlDbType.Int).Value = this.getCacset(ordNo);
                cmd2.Parameters.Add("@WgRunNo", SqlDbType.Int).Value = this.getWgrunno();
                cmd2.Parameters.Add("@DebDy", SqlDbType.Int).Value = this.getDebdy();
                cmd2.Parameters.Add("@NoRegDy", SqlDbType.Decimal).Value = workedTime;
                cmd2.Parameters.Add("@NoInvoDy", SqlDbType.Decimal).Value = faktureradTime;
                cmd2.Parameters.Add("@Rsp", SqlDbType.Int).Value = this.getRsp();
                cmd2.Parameters.Add("@ChTmms", SqlDbType.Int).Value = this.getChtmms(time);
                cmd2.Parameters.Add("@ProdProcNo", SqlDbType.Int).Value = 0;
                #endregion

                try
                {
                    //Tries to run the command
                    int rowEffected = cmd2.ExecuteNonQuery();
                    if (rowEffected > 0)
                        return true;
                    else
                        return false;
                }
                catch { }
            }
            catch { }
            finally
            {
                // Release the Mutex
                mutex.ReleaseMutex();
            }
            return false;
        }

        #endregion

        #region Select/Get - DB info

        #region Activity
        /// <summary>
        /// Gets a list of the activities, with respect of the debit parameter
        /// </summary>
        /// <param name="debit">If you are going to debit the customer or not</param>
        /// <returns>Returns a list with the activities</returns>
        public List<string> getActivities(bool debit)
        {
            List<string> value = new List<string>();

            string[] valueArr;
            string name = string.Empty;
            string tempStr = string.Empty;
            /* Get the values from the configFile */
            if (debit)
            {
                tempStr = debiteraActivity;
                if (!string.IsNullOrEmpty(tempStr))
                    valueArr = tempStr.Split(',');
                else
                    return getAllActivities(activityID, lang);
            }
            else
            {
                tempStr = debitEjActivity;
                if (!string.IsNullOrEmpty(tempStr))
                    valueArr = tempStr.Split(',');
                else
                    return getAllActivities(activityID, lang);
            }

            if (string.IsNullOrEmpty(valueArr[0])) { return getAllActivities(activityID, lang); }

            foreach (string str in valueArr)
            {
                //Gets their name and adds them to the list
                name = this.getActivityName(Convert.ToInt32(str), activityID, lang);
                value.Add(name);
            }

            //value.Sort();
            return value;
        }

        /// <summary>
        /// Gets a list of all the activities available
        /// </summary>
        /// <param name="actID">activity code</param>
        /// <param name="lang">Language code</param>
        /// <returns>Returns a list with the activities</returns>
        public List<string> getAllActivities(int actID, int lang)
        {
            List<string> value = new List<string>();
            string commandText = "Select txt from txt " +
                                 "Where txttp = @txttp AND lang = @lang " +
                                 "Order by txt";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@txttp", SqlDbType.Int).Value = actID;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = lang;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets a list of all the activity codes
        /// </summary>
        /// <param name="lang">Language code</param> 
        /// <returns>Returns a list with the codes</returns>
        public List<string> getAllActivityCodes(int lang)
        {
            List<string> value = new List<string>();
            string commandText = "Select distinct txttp from txt " +
                                 "Where lang = @lang";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = lang;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the ID/number for a activity
        /// </summary>
        /// <param name="activity">Name of the activity</param> 
        /// <param name="actID">activity code</param>
        /// <param name="lang">Language code</param> 
        /// <returns>Returns a int with the ID/number</returns>
        public int getActivityID(string activity, int actID, int lang)
        {
            int value = -1;
            string commandText = "Select txtno from txt " +
                                 "Where txt = @activity and txttp = @txttp AND lang = @lang";
            cmd = new SqlCommand(commandText, connection);


            /* Set the param */
            cmd.Parameters.Add("@activity", SqlDbType.VarChar).Value = activity;
            cmd.Parameters.Add("@txttp", SqlDbType.Int).Value = actID;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = lang;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the name of the activity ID/number
        /// </summary>
        /// <param name="activityNo">ID/number of the activity</param> 
        /// <param name="actID">activity code</param>
        /// <param name="lang">Language code</param>  
        /// <returns>Returns a string with the name</returns>
        public string getActivityName(int activityNo, int actID, int lang)
        {
            string value = string.Empty;
            string commandText = "Select txt from txt " +
                                 "Where txtno = @activityNo and txttp = @txttp AND lang = @lang";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@activityNo", SqlDbType.Int).Value = activityNo;
            cmd.Parameters.Add("@txttp", SqlDbType.Int).Value = actID;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = lang;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        #endregion

        #region Prod
        /// <summary>
        /// Gets a list of all the prods available
        /// </summary>
        /// <returns>Returns a list with the prod info</returns>
        public List<string> getAllProd()
        {
            List<string> value = new List<string>();

            string commandText = "Select prodno + '??' + descr from prod " +
                                 "where wagesrt != ''";
            cmd = new SqlCommand(commandText, connection);

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Search after a prod
        /// </summary>
        /// <returns>Returns a list with the prod info</returns>
        public List<string> searchProdInfo(string searchText)
        {
            List<string> value = new List<string>();

            string commandText = "Select prodno + '??' + descr from prod " +
                                 "where wagesrt != '' AND (prodno Like '%'+@value+'%' OR descr Like '%'+@value+'%')";
            cmd = new SqlCommand(commandText, connection);

            cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = searchText;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets a list of the prods, for the chosen activity
        /// </summary>
        /// <param name="activity">Name of the activity</param>
        /// <returns>Returns a list with the prod info</returns>
        public List<string> getProdInfo(string activity)
        {
            //Gets the prod for the chosen activity from the configFile
            string[] prodCodeList = getProdCodeList(activity);

            if (prodCodeList.Count() != 0)  //If found something
            {
                List<string> list = new List<string>();
                foreach (string str in prodCodeList)
                {
                    //Add it to the list
                    list.Add(str + "??" + this.getProdDescr(str));
                }
                return list;
            }
            else    //Returns all the prod, if no specific activity is found in the configFile
                return this.getAllProd();
        }

        /// <summary>
        /// Gets the name of the prod number
        /// </summary>
        /// <param name="prodNo">The prod number you want the name off</param>
        /// <returns>Returns a string with the name</returns>
        public string getProdDescr(string prodNo)
        {
            string value = string.Empty;

            string commandText = "Select descr from prod " +
                                 "where prodno = @prodNo";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@prodNo", SqlDbType.VarChar).Value = prodNo;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the ID/number for a prod
        /// </summary>
        /// <param name="prod">Name/descr of the prod</param>
        /// <returns>Returns a string with the ID/number</returns>
        public string getProdID(string prod)
        {
            string value = string.Empty;
            string commandText = "Select prodno from prod " +
                                 "Where descr = @prod";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@prod", SqlDbType.VarChar).Value = prod;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }
        #endregion


        /// <summary>
        /// Gets the customer number from the customer name
        /// </summary>
        /// <param name="custNm">Name of the customer you want the customer number</param>
        /// <returns>Returns a int with the customer number</returns>
        public int getCustNo(string custNm)
        {
            int value = -1;
            string commandText = "select custno from Actor " +
                                 "where Nm = @custNm and custno > 0";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@custNm", SqlDbType.VarChar).Value = custNm;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the customer name from the customer number
        /// </summary>
        /// <param name="custNr">Number of the customer you want the customer name</param>
        /// <returns>Returns a string with the customer name</returns>
        public string getCustNm(int custNr)
        {
            string value = string.Empty;
            string commandText = "select Nm from Actor " +
                                 "where custNo = @custNr";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@custNr", SqlDbType.Int).Value = custNr;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the contract from the order number
        /// </summary>
        /// <param name="ordNo">The order number you want the contract from</param>
        /// <returns>Returns a int with contract</returns>
        public int getContract(int ordNo)
        {
            int value = -1;
            string commandText = "select r5 from Ord " +
                                 "where ordno = @ordNo";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@ordNo", SqlDbType.Int).Value = ordNo;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }


        /// <summary>
        /// Gets a list of the orders info
        /// </summary>
        /// <param name="custNr">The customer number to look after his orders</param>
        /// <returns>Returns a list with the order info</returns>
        public List<string> getOrderInfo(int custNr, int lang, int orderFakturaCode)
        {
            List<string> value = new List<string>();

            string commandText = "Select ordno[Order], r5.nm[Avtal.Namn], ord.r5[Avtal], txt.txt[Fakturatyp] from ord " +
                                 "Inner Join r5 " +
                                 "On ord.r5 = r5.rno " +
                                 "Inner Join txt " +
                                 "On ord.gr = txt.txtNo " +
                                 "Where ord.custno = @custNr AND r5 > 0 AND ordpref > 0 AND TxtTp = @orderFakturaCode AND r5.nm != '' AND txt.lang = @lang " +
                                 "UNION " +
                                 "Select ordno, ord.inf, ord.r5, txt.txt  from ord " +
                                 "Inner Join txt " +
                                 "On ord.gr = txt.txtNo " +
                                 "Where ord.custno = @custNr AND ordpref > 0 AND r5 = 0 AND TxtTp = @orderFakturaCode AND ord.inf != '' AND txt.lang = @lang " +
                                 "order by [Fakturatyp], [Avtal.Namn]";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@custNr", SqlDbType.Int).Value = custNr;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = lang;
            cmd.Parameters.Add("@orderFakturaCode", SqlDbType.Int).Value = orderFakturaCode;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim() + "$" +
                                    reader[1].ToString().Trim() + "#" +
                                    reader[2].ToString().Trim() + "~" +
                                    reader[3].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            /* Checks this customer if it has intern order */
            string str = this.checkInternOrder(custNr);
            if (!string.IsNullOrEmpty(str))
                value.Add(str + " - Intern order");

            return value;
        }

        /// <summary>
        /// Checks if it will add also intern order
        /// </summary>
        /// <param name="custNr">Customer number</param>
        /// <returns>Returns a string with value if found intern order else nothing</returns>
        private string checkInternOrder(int custNr)
        {
            string custNm = this.getCustNm(custNr); //Gets the name
            string[] strArr = this.getInterOrder(); //Gets intern info from configFile

            if (strArr[0] != null && strArr[1] != null)
            {
                if (custNm.Equals(strArr[0].Trim()))    //If found same name
                    return strArr[1].Trim();    //Send back the order
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets a list with all the customers names
        /// </summary>
        /// <returns>Returns a list with all the names</returns>
        public List<string> getAllCustomersNm()
        {
            List<string> value = new List<string>();

            string commandText = "Select nm From Actor " +
                                 "Where custno > 0 AND " +
                                 "nm not like '%***%' AND " +
                                 "nm not like '%anv ej%' AND " +
                                 "nm not like '%anvand ej%' AND " +
                                 "nm not like '%använd ej%' " +
                                 "Order by nm";
            cmd = new SqlCommand(commandText, connection);

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the the intern info (customerName, order number)
        /// </summary>
        /// <returns>Returns a string array with the values</returns>
        public string[] getInterOrder()
        {
            string str = internOrder;   //From configFile

            if (!string.IsNullOrEmpty(str))
                return str.Split(new string[] { internOrderDeli }, 2, StringSplitOptions.None);
            else
                return new string[2];   //Empty
        }


        /// <summary>
        /// Search after a customer or customer number
        /// </summary>
        /// <param name="searchText">The text you want to search for</param>
        /// <returns>Returns a list with the customers</returns>
        public List<string> searchAfterCustomer(string searchText)
        {
            List<string> customerList = new List<string>();

            // Set up a command
            string commandText = "Select CAST(custno as varchar(15) ) + " +
                                    "Case oldcno " +
                                        "When 0 Then '' " +
                                        "Else '//' + CAST(oldcno as varchar(15) ) END + ' - ' + " +
                                    "Case right(nm, 1) " +
                                        "When '/' Then left(nm, datalength(nm)-1) " +
                                        "Else nm END " +
                                "From actor " +
                                "Where Custno > 0 AND (custno Like '%'+@value+'%' OR nm Like '%'+@value+'%' OR oldcno Like '%'+@value+'%') AND " +
                                "(nm not like '%***%' AND " +
                                "nm not like '%anv ej%' AND " +
                                "nm not like '%anvand ej%' AND " +
                                "nm not like '%använd ej%')";

            cmd = new SqlCommand(commandText, connection);
            cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = searchText;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        customerList.Add(Convert.ToString(reader[0]).Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            return customerList;
        }

        /// <summary>
        /// Gets a list of the services for a order
        /// </summary>
        /// <param name="ordNo">The order number to get the services from</param>
        /// <returns>Returns a list with services</returns>
        public List<string> getServiceInfo(int ordNo)
        {
            List<string> value = new List<string>();

            string commandText = "Select distinct ordln.r8, '-', RIGHT(r8.nm, datalength(r8.nm)-3) As Name From ordln " +
                                 "Inner join r8 " +
                                 "On  ordln.r8 = r8.rno " +
                                 "Inner join Prod " +
                                 "On ordln.prodno = prod.prodno " +
                                 "Where ordln.ordno = @ordNo " +
                                 "Order by name";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@ordno", SqlDbType.Int).Value = ordNo;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim() + " " +
                                    reader[1].ToString().Trim() + " " +
                                    reader[2].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            return value;
        }

        /// <summary>
        /// Gets a list of all the services
        /// </summary>
        /// <returns>Returns a list with all the services</returns>
        public List<string> getAllServiceInfo()
        {
            List<string> value = new List<string>();

            string commandText = "Select rno, '-', RIGHT(nm, datalength(nm)-3) As Name from r8 " +
                                 "Order by Name";
            cmd = new SqlCommand(commandText, connection);

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim() + " " +
                                    reader[1].ToString().Trim() + " " +
                                    reader[2].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets a list of all the services
        /// </summary>
        /// <returns>Returns a list with all the services</returns>
        public List<string> searchService(string textValue)
        {
            List<string> value = new List<string>();

            string commandText = "Select rno + ' - ' + RIGHT(nm, datalength(nm)-3) As Name from r8 " +
                                 "Where rno like '%'+@textValue+'%' or nm like '%'+@textValue+'%' " +
                                 "Order by Name";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@textValue", SqlDbType.VarChar).Value = textValue;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets a list of the project info
        /// </summary>
        /// <returns>Returns a list with the project info</returns>
        public List<string> getProjectInfo()
        {
            List<string> value = new List<string>();

            string commandText = "Select nm + '??' + rno from r9 " +
                                 "Order by nm";
            cmd = new SqlCommand(commandText, connection);

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }


        public List<string> getAllLangNm()
        {
            List<string> value = new List<string>();

            string commandText = "select Nm from lang";
            cmd = new SqlCommand(commandText, connection);

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the code/ID from the lang name
        /// </summary>
        /// <param name="lang">The name of the language to get the code for</param>
        /// <returns>Returns a int with the value</returns>
        public int getLangCode(string lang)
        {
            int value = -1;

            string commandText = "select LangNo from lang " +
                                 "Where Nm = @lang";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@lang", SqlDbType.VarChar).Value = lang;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = Convert.ToInt32(reader[0]);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        /// <summary>
        /// Gets the name from the lang ID/code
        /// </summary>
        /// <param name="langCode">The code of the language to get the name for</param>
        /// <returns>Returns a string with the value</returns>
        public string getLangNm(int langCode)
        {
            string value = string.Empty;

            string commandText = "select Nm from lang " +
                                 "Where LangNo = @lang";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = langCode;

            try
            {
                /* Reads the result */
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }
            return value;
        }

        #endregion

        public string getMonthWorkTime(string currentMonthYear)
        {
            string timeHour = string.Empty;
            int empNo = this.getEmpno();
            int r1 = this.getLocale();

            // Set up a command
            string commandText = "Select sum(NoReg/60) from agr " +
                                 "Where ProdPrG3 != 14 and ProdPrG3 != 0 and EmpNo=@empNo and FrDt like @monthYear + '%' and ToDt like @monthYear + '%' and R1=@r1";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;
            cmd.Parameters.Add("@monthYear", SqlDbType.VarChar).Value = currentMonthYear;
            cmd.Parameters.Add("@r1", SqlDbType.Int).Value = r1;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        timeHour = Convert.ToString(reader[0]).Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            if (!string.IsNullOrEmpty(timeHour))
                timeHour = string.Format("{0:G29}", Math.Round(Convert.ToDecimal(timeHour), 2));
            return timeHour;
        }
        public string getMonthFaktTime(string currentMonthYear)
        {
            string timeHour = string.Empty;
            int empNo = this.getEmpno();
            int r1 = this.getLocale();

            string[] internOrderArr = internOrder.Split(new string[] { internOrderDeli }, 2, StringSplitOptions.None);
            int custNo = this.getCustno(internOrderArr[0].Trim());

            // Set up a command
            string commandText = "Select sum(NoInvoAb/60) from agr " +
                                 "Where ProdPrG3 != 14 and ProdPrG3 != 0 and ProdPrGr=@debitera and CustNo<>@custNo and EmpNo=@empNo and FrDt like @monthYear + '%' and ToDt like @monthYear + '%' and R1=@r1";
            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@debitera", SqlDbType.Int).Value = debiteraCode;
            cmd.Parameters.Add("@custNo", SqlDbType.Int).Value = custNo;
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;
            cmd.Parameters.Add("@monthYear", SqlDbType.VarChar).Value = currentMonthYear;
            cmd.Parameters.Add("@r1", SqlDbType.Int).Value = r1;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        timeHour = Convert.ToString(reader[0]).Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            if (!string.IsNullOrEmpty(timeHour))
                timeHour = string.Format("{0:G29}", Math.Round(Convert.ToDecimal(timeHour), 2));
            return timeHour;
        }

        public double howMuchWorkThisDay(string date, bool fakt)
        {
            string timeHour = string.Empty;
            int empNo = this.getEmpno();
            int r1 = this.getLocale();

            // Set up a command
            string commandText = string.Empty;
            if (fakt)
            {
                commandText = "Select sum(NoInvoAb/60) from agr " +
                              "Where ProdPrG3 != 14 and ProdPrG3 != 0 and EmpNo=@empNo and FrDt=@date and R1=@r1";
            }
            else
            {
                commandText = "Select sum(NoReg/60) from agr " +
                              "Where ProdPrG3 != 14 and ProdPrG3 != 0 and EmpNo=@empNo and FrDt=@date and R1=@r1";
            }


            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@r1", SqlDbType.Int).Value = r1;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        timeHour = Convert.ToString(reader[0]).Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            if (string.IsNullOrEmpty(timeHour)) { timeHour = "0"; }
            else
            {
                double time = Convert.ToDouble(timeHour);
                if (!string.IsNullOrEmpty(timeHour))
                    timeHour = string.Format("{0:G29}", Math.Round(time, 2));
            }

            return Convert.ToDouble(timeHour);
        }

        public DataTable howMuchWork(string date, bool fakt)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("A", typeof(string));
            dt.Columns.Add("B", typeof(string));

            string timeHour = string.Empty;
            int empNo = this.getEmpno();
            int r1 = this.getLocale();

            // Set up a command
            string commandText = string.Empty;
            if (fakt)
            {
                commandText = "Select FrDt, sum(NoInvoAb/60) from agr " +
                              "Where ProdPrG3 != 14 and ProdPrG3 != 0 and EmpNo=@empNo and FrDt like @date + '%' and R1=@r1 " +
                              "Group By FrDt";
            }
            else
            {
                commandText = "Select FrDt, sum(NoReg/60) from agr " +
                              "Where ProdPrG3 != 14 and ProdPrG3 != 0 and EmpNo=@empNo and FrDt like @date + '%' and R1=@r1 " +
                              "Group By FrDt";
            }


            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@r1", SqlDbType.Int).Value = r1;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        timeHour = Convert.ToString(reader[1]).Trim();

                        if (string.IsNullOrEmpty(timeHour)) { timeHour = "0"; }
                        else
                        {
                            double time = Convert.ToDouble(timeHour);
                            if (!string.IsNullOrEmpty(timeHour))
                                timeHour = string.Format("{0:G29}", Math.Round(time, 2));
                        }

                        dt.Rows.Add(Convert.ToString(reader[0]).Trim(), timeHour);
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            if (string.IsNullOrEmpty(timeHour)) { dt.Rows.Add(0, 0); }

            return dt;
        }

        public DataTable getInfoRow(string date)
        {
            DataTable customerDT = new DataTable();
            int empNo = this.getEmpno();
            int r1 = this.getLocale();

            // Set up a command
            string commandText = "Select agr.AgrNo[AgrNo], agr.AgrActNo[AgrActNo], agr.EmpNo[EmpNo], agr.FrDt[Datum från], agr.ToDt[Datum till], agr.FrTm[Från tid], agr.ToTm[Till tid], Nm[Kundnamn], Cast(OrdNo AS varchar)[Order], agr.r8[Service], agr.r9[Projekt], " +
                             "Round(Cast((NoReg/60) AS float),2)[Arbetad(H)], Round(Cast((NoInvoAb/60) AS float),2)[Debitera(H)], " +
                             "txt[Aktivitet], p.Descr[Art], agr.r5[KontraktNr], agr.Invo[DefaultActivity], " +
                             "agr.descr[Benämning], descr2[Intern text] from agr " +
                             "Inner join txt t " +
                             "On prodprg3 = txtno " +
                             "Inner join prod p " +
                             "On agr.prodNo = p.prodNo " +
                             "Inner join actor a " +
                             "On agr.custNo = a.custNo " +
                             "Where agr.EmpNo=@empNo and agr.FrDt=@date and agr.R1=@r1 and txttp = @txttp AND t.lang = @lang and a.custno > 0";
            cmd = new SqlCommand(commandText, connection);


            /* Set the param */
            cmd.Parameters.Add("@empNo", SqlDbType.VarChar).Value = empNo;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@r1", SqlDbType.VarChar).Value = r1;
            cmd.Parameters.Add("@txttp", SqlDbType.VarChar).Value = activityID;
            cmd.Parameters.Add("@lang", SqlDbType.VarChar).Value = lang;

            try
            {
                /* Reads the result and puts it in a dataTable */
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                customerDT.Load(sqlDataReader);

                sqlDataReader.Close(); //Message reader close
            }
            catch { }
            return customerDT;
        }

        public string getTotFlexForEmp()
        {
            string value = string.Empty;
            int empNo = this.getEmpno();

            // Set up a command
            string commandText = "Select Case Inf4 when '' then '0' else Round(Cast((inf4) AS float),2) end from Actor " +
                                 "Where empno = @empNo";

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            return value;
        }

        public string getFlexMonth(string yearMonth)
        {
            string value = "0";
            int empNo = this.getEmpno();

            // Set up a command
            string commandText = "Select Round(Cast(sum(val1) AS float),2) from freeinf1 " +
                                 "Where Emp = @empNo and dt1 like @date + '%'";

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = yearMonth;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        value = reader[0].ToString().Trim();
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            return value;
        }

        public List<string> getHolidays(string yearMonth)
        {
            List<string> list = new List<string>();
            int empNo = this.getEmpno();

            // Set up a command
            string commandText = "Select FrDt from HOL " +
                                 "Where FrDt like @yearMonth + '%'";

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@yearMonth", SqlDbType.VarChar).Value = yearMonth;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())  //Tries to read the row from the specified parameters above
                {
                    while (reader.Read())   //Read the message and saves it
                    {
                        list.Add(reader[0].ToString().Trim());
                    }
                    reader.Close(); //Message reader close
                }
            }
            catch { }

            return list;
        }

        public bool deleteAgrRow(int agrActNo, int actNo)
        {
            bool removed = false;
            int empNo = this.getEmpno();

            // Set up a command
            string commandText = "Delete agr " +
                                 "Where AgrActNo = @agrActNo and AgrNo = @actNo and EmpNo = @empNo";

            cmd = new SqlCommand(commandText, connection);

            /* Set the param */
            cmd.Parameters.Add("@agrActNo", SqlDbType.Int).Value = agrActNo;
            cmd.Parameters.Add("@actNo", SqlDbType.Int).Value = actNo;
            cmd.Parameters.Add("@empNo", SqlDbType.Int).Value = empNo;

            try
            {
                //Tries to run the command
                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                    removed = true;
                else
                    removed = false;
            }
            catch { removed = false; }

            return removed;
        }

        #region Open & Close - DB Connection
        public bool openDBCon()
        {
            //Tries to connect to database
            try { this.connection.Open(); }
            catch { return false; }

            return true;
        }
        public bool closeDBCon()
        {
            //Datasbase connection close
            try { this.connection.Close(); }
            catch { return false; }

            return true;
        }
        #endregion


        //private int getR2()
        //{
        //    return 0;
        //}
        //private int getR3()
        //{
        //    return 0;
        //}
        //private int getR4()
        //{
        //    return 0;
        //}
        //private int getR6()
        //{
        //    return 0;
        //}
        //private string getR7()
        //{
        //    return string.Empty;
        //}
        //private string getR10()
        //{
        //    return string.Empty;
        //}
        //private string getR11()
        //{
        //    return string.Empty;
        //}
        //private string getR12()
        //{
        //    return string.Empty;
        //}
    }
}
