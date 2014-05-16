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
using System.Collections.Generic;

namespace TidsrapporteringASPClient.Repository
{
    public class FavoritCRUD
    {
        private SqlConnection connection;
        private SqlCommand cmd;
        private string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|FavoritDB.mdf;Integrated Security=SSPI;User Instance=True;";

        public FavoritCRUD()
        {
            connection = new SqlConnection(this.connectionString);
        }

        private Favorit createFavorit(int favID, string favName, int actID, string debit,
                                        string aktiv, string art, string cust,
                                        string order, string service,
                                        string proj, string benamning,
                                        string internText, string memo, string milTal)
        {
            Favorit fav = new Favorit
            {
                FavoritID = favID,
                FavoritName = favName,
                ActAgrID = actID,
                Debit = debit,
                Activity = aktiv,
                Artical = art,
                CustomName = cust,
                Order = order,
                Service = service,
                Project = proj,
                Benamning = benamning,
                InternText = internText,
                Memo = memo,
                Miltal = milTal
            };
            return fav;
        }

        public string insertNewFavorit(Favorit favorit)
        {
            string response = "";

            try
            {
                connection.Open();
                string commandText = "INSERT INTO FavoritSettings " +
                                        " (FavoritName, ActAgrID, Debit, Aktivity, Articel, CustName, " +
                                        "OrderNo, Service, Project, Benamning, InternText, Memo, Miltal) " +
                                        "VALUES (@favName, @actId, @debit , @activ, @art, @cust, " +
                                        "@order, @service, @proj, @ben, @intern, @memo, @mil)";

                cmd = new SqlCommand(commandText, connection);

                #region parameters
                cmd.Parameters.Add("@favName", SqlDbType.VarChar).Value = favorit.FavoritName;
                cmd.Parameters.Add("@actId", SqlDbType.VarChar).Value = favorit.ActAgrID;
                cmd.Parameters.Add("@debit", SqlDbType.VarChar).Value = favorit.Debit;
                cmd.Parameters.Add("@activ", SqlDbType.VarChar).Value = favorit.Activity;
                cmd.Parameters.Add("@art", SqlDbType.VarChar).Value = favorit.Artical;
                cmd.Parameters.Add("@cust", SqlDbType.VarChar).Value = favorit.CustomName;
                cmd.Parameters.Add("@order", SqlDbType.VarChar).Value = favorit.Order;
                cmd.Parameters.Add("@service", SqlDbType.VarChar).Value = favorit.Service;
                cmd.Parameters.Add("@proj", SqlDbType.VarChar).Value = favorit.Project;
                cmd.Parameters.Add("@ben", SqlDbType.VarChar).Value = favorit.Benamning;
                cmd.Parameters.Add("@intern", SqlDbType.VarChar).Value = favorit.InternText;
                cmd.Parameters.Add("@memo", SqlDbType.VarChar).Value = favorit.Memo;
                cmd.Parameters.Add("@mil", SqlDbType.VarChar).Value = favorit.Miltal;
                #endregion

                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    response = "Insättning lyckades.";
                }
                else
                {
                    response = "Insättning misslyckades.";
                }
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public Favorit getFavoritByFavoritID(int favoID)
        {
            Favorit fav = new Favorit();

            string commandText = "Select * From FavoritSettings " +
                                 "Where FavoritID = @id";

            cmd = new SqlCommand(commandText, connection);
            connection.Open();

            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = favoID;
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fav = createFavorit(Convert.ToInt32(reader["FavoritID"]),
                                            Convert.ToString(reader["FavoritName"]),
                                            Convert.ToInt32(reader["ActAgrID"]),
                                            Convert.ToString(reader["Debit"]),
                                            Convert.ToString(reader["Aktivity"]),
                                            Convert.ToString(reader["Articel"]),
                                            Convert.ToString(reader["CustName"]),
                                            Convert.ToString(reader["OrderNo"]),
                                            Convert.ToString(reader["Service"]),
                                            Convert.ToString(reader["Project"]),
                                            Convert.ToString(reader["Benamning"]),
                                            Convert.ToString(reader["InternText"]),
                                            Convert.ToString(reader["Memo"]),
                                            Convert.ToString(reader["Miltal"]));
                    }
                    reader.Close();
                }
                return fav;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<Favorit> getFavoritByActID(int ActID)
        {
            List<Favorit> favList = new List<Favorit>();

            string commandText = "Select * From FavoritSettings " +
                                 "Where ActAgrID = @id";

            cmd = new SqlCommand(commandText, connection);
            connection.Open();

            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = ActID;
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Favorit fav = createFavorit(Convert.ToInt32(reader["FavoritID"]),
                                            Convert.ToString(reader["FavoritName"]),
                                            Convert.ToInt32(reader["ActAgrID"]),
                                            Convert.ToString(reader["Debit"]),
                                            Convert.ToString(reader["Aktivity"]),
                                            Convert.ToString(reader["Articel"]),
                                            Convert.ToString(reader["CustName"]),
                                            Convert.ToString(reader["OrderNo"]),
                                            Convert.ToString(reader["Service"]),
                                            Convert.ToString(reader["Project"]),
                                            Convert.ToString(reader["Benamning"]),
                                            Convert.ToString(reader["InternText"]),
                                            Convert.ToString(reader["Memo"]),
                                            Convert.ToString(reader["Miltal"]));
                        favList.Add(fav);
                    }
                    reader.Close();
                    connection.Close();
                }
                return favList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public string deleteFavorit(int favID)
        {
            string response = "";
            try
            {
                connection.Open();
                string commandText = "DELETE FROM FavoritSettings " +
                                        "WHERE (FavoritID = @favID)";

                cmd = new SqlCommand(commandText, connection);

                cmd.Parameters.Add("@favID", SqlDbType.VarChar).Value = favID;

                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    response = "Borttagning lyckades.";
                }
                else
                {
                    response = "Borttagning misslyckades.";
                }
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

    }
}
