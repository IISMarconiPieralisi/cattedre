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
    public static class ClsClasseBL
    {
        public static string RilevaSiglaClasse(long id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            string _sigla = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT sigla " +
                                 "FROM classi " +
                                 "WHERE ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                _sigla = dr["sigla"].ToString();
                            }
                            conn.Close();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _sigla;
        }

        public static long RilevaIDclasse(string sigla)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            long _ID=0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = @"SELECT ID 
                                 FROM classi 
                                 WHERE sigla = @sigla";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", sigla);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                _ID = Convert.ToInt64(dr["ID"]);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _ID;
        }

        public static List<ClsClasseDL> CaricaClassiDipartimento(int IDdipartimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    //string sql = "SELECT id,sigla,anno,sezione,classeArticolataCon, IDutente, IDindirizzo FROM classi";
                    string sql = "SELECT * FROM classi " +
                                    "JOIN utenti ON utenti.ID = classi.IDutente " +
                                    "JOIN afferire ON afferire.IDutente = utenti.ID " +
                                    "WHERE afferire.IDdipartimento = @IDdipartimento";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Iddipartimento", IDdipartimento);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    conn.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    ClsClasseDL _classe = new ClsClasseDL();
                    _classe.ID= Convert.ToInt64(row["id"]);
                    _classe.Sigla=row["sigla"].ToString();
                    _classe.Anno = Convert.ToInt32(row["anno"]);
                    _classe.Sezione = row["sezione"].ToString();
                    _classe.ClasseArticolataCon = (row["classeArticolataCon"] == DBNull.Value) ? 0 : Convert.ToInt32(row["classeArticolataCon"]);
                    _classe.Idutente = (row["IDutente"]== DBNull.Value) ? 0 : Convert.ToInt64(row["IDutente"]);
                    _classe.Idindirizzo=Convert.ToInt64(row["IDindirizzo"]);
                    classi.Add(_classe);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return classi;
        }

        public static List<ClsClasseDL> CaricaClassi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable ds = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM classi " +
                                 "ORDER BY anno";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {

                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                        conn.Close();
                    }
                }
                    foreach (DataRow row in ds.Rows)
                    {
                        ClsClasseDL classe = new ClsClasseDL();
                        classe.ID = Convert.ToInt64(row["ID"]);
                        classe.Sigla = row["sigla"].ToString();
                        classe.Anno = Convert.ToInt32(row["anno"]);
                        classe.Sezione = row["sezione"].ToString();
                        classe.ClasseArticolataCon = (row["classeArticolataCon"] == DBNull.Value) ? 0 : Convert.ToInt32(row["classeArticolataCon"]);
                        classe.Idutente = (row["IDutente"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDutente"]);
                        classe.Idindirizzo = Convert.ToInt64(row["IDindirizzo"]);
                        classi.Add(classe);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return classi;
        }

        public static List<ClsClasseDL> CaricaClassiFiltrate(int anno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable ds = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM classi " +
                                 "WHERE anno = @anno"+
                                 " ORDER BY anno";

                    using(MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@anno", anno);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                        conn.Close();
                    }
                }
                foreach (DataRow row in ds.Rows)
                {
                    ClsClasseDL classe = new ClsClasseDL();
                    classe.ID = Convert.ToInt64(row["ID"]);
                    classe.Sigla = row["sigla"].ToString();
                    classe.Anno = Convert.ToInt32(row["anno"]);
                    classe.Sezione = row["sezione"].ToString();
                    classe.ClasseArticolataCon = (row["classeArticolataCon"] == DBNull.Value) ? 0 : Convert.ToInt32(row["classeArticolataCon"]);
                    classe.Idutente = (row["IDutente"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDutente"]);
                    classe.Idindirizzo = Convert.ToInt64(row["IDindirizzo"]);
                    classi.Add(classe);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return classi;
        
        }

        public static void InserisciClasse(ClsClasseDL classe)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO classi (sigla, anno, sezione, classeArticolataCon, IDutente, IDindirizzo) 
                           VALUES (@sigla, @anno, @sezione, @classeArticolataCon, @IDutente, @IDindirizzo)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Parametri calcolati o passati
                        cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                        cmd.Parameters.AddWithValue("@anno", classe.Anno);
                        cmd.Parameters.AddWithValue("@sezione", classe.Sezione);

                        // Gestione del valore NULL per la classe articolata
                        cmd.Parameters.AddWithValue("@classeArticolataCon", classe.ClasseArticolataCon > 0 ? (object)classe.ClasseArticolataCon : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDutente", classe.Idutente > 0 ? (object)classe.Idutente : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDindirizzo", classe.Idindirizzo);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("Errore nell'inserimento della classe: nessuna riga interessata.");
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificaClasse(ClsClasseDL classe)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE classi 
                           SET sigla = @sigla, 
                               anno = @anno, 
                               sezione = @sezione, 
                               classeArticolataCon = @classeArticolataCon,
                               IDutente = @IDutente,
                               IDindirizzo = @IDindirizzo 
                           WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                        cmd.Parameters.AddWithValue("@anno", classe.Anno);
                        cmd.Parameters.AddWithValue("@sezione", classe.Sezione);
                        cmd.Parameters.AddWithValue("@classeArticolataCon",classe.ClasseArticolataCon > 0 ? (object)classe.ClasseArticolataCon : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDutente", classe.Idutente);
                        cmd.Parameters.AddWithValue("@IDindirizzo", classe.Idindirizzo);
                        cmd.Parameters.AddWithValue("@id", classe.ID);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("Nessuna classe trovata con l'ID specificato. Modifica fallita.");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaClasse(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM classi WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("Impossibile eliminare la classe: ID non trovato.");
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
