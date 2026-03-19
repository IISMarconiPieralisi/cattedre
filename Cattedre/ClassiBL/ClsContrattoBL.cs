using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Cattedre
{
    public static class ClsContrattoBL
    {
        public static int _IDutente;
        public static List<long> IDutenti = new List<long>();
        static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;


        public static List<ClsContrattoDL> CaricaContratti()
        {
            IDutenti.Clear();

            MySqlConnection conn = new MySqlConnection(connectionString);
            DataTable ds = new DataTable();
            List<ClsContrattoDL> Contratti = new List<ClsContrattoDL>();
            try
            {
                conn.Open();
                string sql = "SELECT ID, IDutente, IDclasseDiConcorso, IDdisciplina, oreSpeciali FROM richiedere ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(ds);
                    }
                    conn.Close();
                }
                foreach (DataRow row in ds.Rows)
                {
                    ClsContrattoDL Contratto = new ClsContrattoDL();
                    Contratto.ID = Convert.ToInt64(row["ID"]);
                    Contratto.TipoContratto = Convert.ToChar(row["tipoContratto"]);
                    Contratto.MonteOre = Convert.ToInt32(row["monteOre"]);
                    Contratto.IDutente = Convert.ToInt64(row["IDutente"]);
                    Contratto.DataInizioContratto = Convert.ToDateTime(row["datainizio"]);
                    Contratto.DataFineContratto = Convert.ToDateTime(row["datafine"]);
                    _IDutente = Convert.ToInt32(row["IDutente"]);
                    Contratti.Add(Contratto);
                    IDutenti.Add(_IDutente);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Contratti;
        }

        public static void InserisciContratto(ClsContrattoDL contratto, long IDutente)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);

            IDutenti.Clear();

            try
            {
                conn.Open();
                string sql = "INSERT INTO contratti (tipoContratto, monteOre, datainizio, datafine, IDutente) " +
                    "VALUES (@tipoContratto, @monteOre, @datainizio, @datafine, @IDutente)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@tipoContratto", contratto.TipoContratto);
                    cmd.Parameters.AddWithValue("@monteOre", contratto.MonteOre);
                    cmd.Parameters.AddWithValue("@datainizio", contratto.DataInizioContratto);
                    if (contratto.TipoContratto == 'D')
                        cmd.Parameters.AddWithValue("@datafine", contratto.DataFineContratto);
                    else
                        cmd.Parameters.AddWithValue("@datafine", null);
                    cmd.Parameters.AddWithValue("@IDutente", IDutente);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
        }

        public static void ModificaContratto(ClsContrattoDL contratto, long IDutente)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            //se il contratto non esiste lo inserisco al posto di modificarlo
            if (cercaContratto(IDutente) == null)
            {
                InserisciContratto(contratto, IDutente);
                return;
            }
            try
            {
                conn.Open();
                string sql = @"UPDATE contratti 
                           SET tipoContratto = @tipoContratto, 
                               monteOre = @monteOre, 
                               datainizio = @datainizio, 
                               datafine = @datafine, 
                               IDutente = @IDutente
                           WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@tipoContratto", contratto.TipoContratto);
                    cmd.Parameters.AddWithValue("@monteOre", contratto.MonteOre);
                    cmd.Parameters.AddWithValue("@datainizio", contratto.DataInizioContratto);
                    if (contratto.TipoContratto == 'D')
                        cmd.Parameters.AddWithValue("@datafine", contratto.DataFineContratto);
                    else
                        cmd.Parameters.AddWithValue("@datafine", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDutente", IDutente);
                    cmd.Parameters.AddWithValue("@id", contratto.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

        }

        public static List<ClsContrattoDL> EliminaContratto(int id)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsContrattoDL> contratti = new List<ClsContrattoDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM contratti WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        contratti = CaricaContratti();
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return contratti;
        }
        public static ClsContrattoDL cercaContratto(long idUtente)
        {
            ClsContrattoDL contrattoTrovato = null;
            string sql = @"SELECT * FROM contratti WHERE IDutente = @IdUtente";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUtente", idUtente);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            contrattoTrovato = new ClsContrattoDL();
                            contrattoTrovato.ID = Convert.ToInt32(row["id"]);
                            contrattoTrovato.TipoContratto = Convert.ToChar(row["tipoContratto"]);
                            contrattoTrovato.MonteOre = Convert.ToInt32(row["monteOre"]);
                            contrattoTrovato.DataInizioContratto = Convert.ToDateTime(row["datainizio"]);
                            if (row["datafine"] != DBNull.Value)
                                contrattoTrovato.DataFineContratto = Convert.ToDateTime(row["datafine"]);
                            contrattoTrovato.IDutente = Convert.ToInt32(row["IDutente"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la ricerca del contratto: " + ex.Message);
            }
            return contrattoTrovato;
        }

        public static int RilevaOreContrattoDoc(long id)
        {
            int monteOre = -1;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT monteOre FROM contratti WHERE IDutente = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            monteOre = Convert.ToInt32(dt.Rows[0]["monteOre"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento delle ore contratto: " + ex.Message);
            }
            return monteOre;
        }
    }
}
