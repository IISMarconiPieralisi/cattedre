using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Configuration;

namespace Cattedre
{
    public static class ClsIndirizzoBL
    {
        public static long RilevaIDindirizzo(string nome)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsIndirizzoDL indirizzo = null;
            try
            {
                conn.Open();
                string sql = "SELECT ID " +
                             "FROM indirizzi " +
                             "WHERE nome = '" + nome + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    indirizzo = new ClsIndirizzoDL();
                    indirizzo.ID = Convert.ToInt64(dr["ID"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            if (indirizzo != null)
                return indirizzo.ID;
            else
                return 0;
        }

        public static string RilevaNomeIndirizzo(long id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsIndirizzoDL indirizzo = null;
            try
            {
                conn.Open();
                string sql = "SELECT nome " +
                             "FROM indirizzi " +
                             "WHERE ID = " + id;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    indirizzo = new ClsIndirizzoDL();
                    indirizzo.Nome = dr["nome"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            if (indirizzo != null)
                return indirizzo.Nome;
            else
                return "-";
        }

        public static List<ClsIndirizzoDL> CaricaIndirizzi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM indirizzi";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsIndirizzoDL indirizzo = new ClsIndirizzoDL();
                        indirizzo.ID = Convert.ToInt64(dr["id"]);
                        indirizzo.Nome = dr["nome"].ToString();
                        indirizzi.Add(indirizzo);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            return indirizzi;
        }

        public static List<ClsIndirizzoDL> InserisciIndirizzo(ClsIndirizzoDL indirizzo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();

            try
            {
                conn.Open();
                string sql = "INSERT INTO indirizzi (nome) VALUES (@nome)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", indirizzo.Nome);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        indirizzi.Add(indirizzo);
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return indirizzi;
        }

        public static List<ClsIndirizzoDL> ModificaIndirizzo(ClsIndirizzoDL indirizzo, int indice)
        {
            FrmIndirizzo frmIndirizzo = new FrmIndirizzo();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();

            try
            {
                conn.Open();
                string sql = "UPDATE indirizzi SET nome = '" + indirizzo.Nome + "' WHERE id = " + indirizzo.ID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", indirizzo.Nome);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        indirizzi[indice] = frmIndirizzo._indirizzo;
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return indirizzi;
        }

        public static List<ClsIndirizzoDL> EliminaIndirizzo(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM indirizzi WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        indirizzi = CaricaIndirizzi();
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return indirizzi;
        }
    }
}