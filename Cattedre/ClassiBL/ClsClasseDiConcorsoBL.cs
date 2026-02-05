using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Configuration;

namespace Cattedre
{
    public static class ClsClasseDiConcorsoBL
    {
        public static List<ClsClasseDiConcorsoDL> CaricaCdcs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM classidiconcorso";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                        cdc.ID = Convert.ToInt32(dr["id"]);
                        cdc.Livello = dr["livello"].ToString();
                        cdc.Nome = dr["nome"].ToString();
                        cdc.AbilitazioniRichieste = dr["abilitazioniRichieste"].ToString();
                        cdcs.Add(cdc);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            return cdcs;
        }

        public static List<ClsClasseDiConcorsoDL> InserisciCdc(ClsClasseDiConcorsoDL cdc)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();

            try
            {
                conn.Open();
                string sql = "INSERT INTO classidiconcorso (livello, nome, abilitazioniRichieste) " +
                    "VALUES (@livello, @nome, @abilitazioniRichieste)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        cdcs.Add(cdc);
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return cdcs;
        }

        public static List<ClsClasseDiConcorsoDL> ModificaCdc(ClsClasseDiConcorsoDL cdc, List<ClsClasseDiConcorsoDL> cdcs, int indice)
        {
            FrmCdC frmCdC = new FrmCdC();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"UPDATE classidiconcorso 
                           SET livello = @livello,
                               nome = @nome, 
                               abilitazioniRichieste = @abilitazioniRichieste 
                           WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@id", cdc.ID);
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        cdcs[indice] = cdc;
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return cdcs;
        }

        public static List<ClsClasseDiConcorsoDL> EliminaCdc(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM classidiconcorso WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        cdcs = CaricaCdcs();
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return cdcs;
        }
    }
}
