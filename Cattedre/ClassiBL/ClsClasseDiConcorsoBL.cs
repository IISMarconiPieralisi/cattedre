using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Configuration;
using System.Data;

namespace Cattedre
{
    public static class ClsClasseDiConcorsoBL
    {
        public static List<ClsClasseDiConcorsoDL> CaricaCdcs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM classidiconcorso";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    conn.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                    cdc.ID = Convert.ToInt32(row["ID"]);
                    cdc.Livello = row["livello"].ToString();
                    cdc.Nome = row["nome"].ToString();
                    cdc.AbilitazioniRichieste = row["abilitazioniRichieste"].ToString();
                    cdcs.Add(cdc);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdcs;
        }

        public static void InserisciCdc(ClsClasseDiConcorsoDL cdc)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();

            try
            {
                conn.Open();
                string sql = "INSERT INTO classidiconcorso (livello, nome, abilitazioniRichieste) " +
                    "VALUES (@livello, @nome, @abilitazioniRichieste)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if (righeCoinvolte < 0)
                        throw new Exception("non è inserito nessun valore, riprovare");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ModificaCdc(ClsClasseDiConcorsoDL cdc, int indice)
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
                           WHERE ID = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cdc.ID);
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                        throw new Exception("non è modificato nessun valore, riprovare");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaCdc(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"DELETE FROM classidiconcorso WHERE ID =@id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id",id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte < 0)
                            throw new Exception("non è eliminato nessun valore, riprovare");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
