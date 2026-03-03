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
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string sql = "SELECT * FROM classidiconcorso";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(dt);
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                        ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                        cdc.ID = Convert.ToInt32(row["id"]);
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

        public static long InserisciCdc(ClsClasseDiConcorsoDL cdc)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 1) INSERT
                string insertSql = @"
            INSERT INTO classidiconcorso (nome, livello, abilitazioniRichieste)
            VALUES (@nome, @livello, @abilitazioniRichieste);";

                using (MySqlCommand cmd = new MySqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);

                    int righe = cmd.ExecuteNonQuery();
                    if (righe <= 0)
                        throw new DataException("Inserimento CDC fallito");
                }

                // 2) Recupero ID
                using (MySqlCommand idCmd = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                {
                    long newId = Convert.ToInt64(idCmd.ExecuteScalar());
                    cdc.ID = newId;
                    return newId;
                }
            }
        }

        public static void ModificaCdc(ClsClasseDiConcorsoDL cdc, int indice)
        {
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
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@id", cdc.ID);
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if (righeCoinvolte < 0)
                        throw new DataException("nessuna riga row");
                }
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
                    string sql = "DELETE FROM classidiconcorso WHERE ID = @id ";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id",id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte < 0)
                            throw new DataException("nessuna riga row");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<ClsClasseDiConcorsoDL> RicercaPerNome(string _ricerca)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            DataTable dt = new DataTable();
            _ricerca = $"%{_ricerca}%";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID,livello,nome,abilitazioniRichieste
                                 FROM classidiconcorso 
                                 WHERE nome LIKE @Ricerca";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ricerca", _ricerca);

                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                        conn.Close();
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                        cdc.ID = Convert.ToInt32(row["id"]);
                        cdc.Livello = row["livello"].ToString();
                        cdc.Nome = row["nome"].ToString();
                        cdc.AbilitazioniRichieste = row["abilitazioniRichieste"].ToString();
                        cdcs.Add(cdc);

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdcs;
        }

    }
}
