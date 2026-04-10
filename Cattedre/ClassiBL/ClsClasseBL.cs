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
        static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

        public static ClsClasseDL CaricaClasse(long id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM classi WHERE ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            return new ClsClasseDL
                            {
                                ID = Convert.ToInt64(row["ID"]),
                                Sezione = row["sezione"].ToString(),
                                Anno = Convert.ToInt32(row["anno"]),
                                Idindirizzo = Convert.ToInt64(row["IDindirizzo"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il caricamento della classe: " + ex.Message);
            }
            return null;
        }

        public static ClsClasseDL TrovaClasse(string sezione, int anno, long IDindirizzo, long IDannoscolastico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM classi
                   WHERE sezione = @sezione
                   AND anno = @anno
                   AND IDindirizzo = @IDindirizzo
                   AND IDannoscolastico = @IDannoscolastico";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sezione", sezione);
                        cmd.Parameters.AddWithValue("@anno", anno);
                        cmd.Parameters.AddWithValue("@IDindirizzo", IDindirizzo);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", IDannoscolastico);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            return new ClsClasseDL
                            {
                                ID = Convert.ToInt64(row["ID"]),
                                Sezione = row["sezione"].ToString(),
                                Anno = Convert.ToInt32(row["anno"]),
                                Idindirizzo = Convert.ToInt64(row["IDindirizzo"]),
                                IDannoscolastico = Convert.ToInt64(row["IDannoscolastico"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la ricerca della classe: " + ex.Message);
            }
            return null;
        }

        public static long TrovaIndirizzoClasse(long IDclasse)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT IDindirizzo FROM classi WHERE ID = @IDclasse LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            return Convert.ToInt64(dt.Rows[0]["IDindirizzo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la ricerca dell'indirizzo della classe: " + ex.Message);
            }
            return 0;
        }

        public static string RilevaSiglaClasse(long id)
        {
            string _sigla = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT sigla FROM classi WHERE ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            _sigla = dt.Rows[0]["sigla"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento della sigla della classe: " + ex.Message);
            }
            return _sigla;
        }

        public static long RilevaIDclasse(string sigla)
        {
            long _ID = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID FROM classi WHERE sigla = @sigla";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", sigla);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            _ID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento dell'ID della classe: " + ex.Message);
            }
            return _ID;
        }


        #region popolamenti Specifici
        public static List<ClsClasseDL> CaricaClassiDipartimento(long IDdipartimento, long IDannoscolastico)
        {
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM classi " +
                                 "WHERE classi.IDdipartimento = @IDdipartimento " +
                                 "AND classi.IDannoscolastico = @IDannoscolastico " +
                                 "ORDER BY classi.anno, classi.sezione";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", IDannoscolastico);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsClasseDL _classe = new ClsClasseDL();
                    _classe.ID = Convert.ToInt64(row["id"]);
                    _classe.Sigla = row["sigla"].ToString();
                    _classe.Anno = Convert.ToInt32(row["anno"]);
                    _classe.Sezione = row["sezione"].ToString();
                    _classe.ClasseArticolataCon = (row["classeArticolataCon"] == DBNull.Value) ? 0 : Convert.ToInt32(row["classeArticolataCon"]);
                    _classe.Idutente = (row["IDutente"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDutente"]);
                    _classe.Idindirizzo = Convert.ToInt64(row["IDindirizzo"]);
                    _classe.IDannoscolastico = (row["IDannoscolastico"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDannoscolastico"]);
                    _classe.IDdipartimento = (row["IDdipartimento"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDdipartimento"]);
                    classi.Add(_classe);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return classi;
        }
        public static List<ClsClasseDL> CaricaClassiFiltrate(Dictionary <string,List<string>> Filtri)
        {
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable ds = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = CreaQueryFiltri(conn, Filtri))
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
                    classe.IDannoscolastico = (row["IDannoscolastico"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDannoscolastico"]);
                    classe.IDdipartimento = (row["IDdipartimento"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDdipartimento"]);
                    classi.Add(classe);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return classi;
        }
        private static MySqlCommand CreaQueryFiltri(MySqlConnection conn, Dictionary<string, List<string>> Filtri)
        {
            try
            {
                if (Filtri.Count <= 0)
                    throw new Exception("non è stato inserito nessun parametro in cui filtrare,riprovare");
                string sql = "SELECT * FROM classi WHERE ";
                MySqlCommand cmd = new MySqlCommand("", conn);
                List<string> condizioni = new List<string>();
                foreach (var filtro in Filtri)
                {
                    string Parametro = filtro.Key;
                    List<string> valori = filtro.Value;
                    if (valori == null || valori.Count == 0)
                        continue;
                    List<string> valoriRicerca = new List<string>();
                    foreach(string valore in valori)
                        valoriRicerca.Add($"{Parametro} = {valore}");

                    // Combina valori dello stesso filtro con OR
                    condizioni.Add("(" + string.Join(" OR ", valoriRicerca) + ")");
                }
                if (condizioni.Count > 0)
                {
                    sql += string.Join(" AND ", condizioni);
                }
                sql += " ORDER BY anno ASC";
                cmd.CommandText = sql;
                return cmd;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion
        #region Operazioni Crud
        public static List<ClsClasseDL> CaricaClassi()
        {
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
                    classe.IDannoscolastico = (row["IDannoscolastico"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDannoscolastico"]);
                    classe.IDdipartimento = (row["IDdipartimento"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDdipartimento"]);
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
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO classi (sigla, anno, sezione, classeArticolataCon, IDutente, IDindirizzo,IDdipartimento,IDannoscolastico) 
                       VALUES (@sigla, @anno, @sezione, @classeArticolataCon, @IDutente, @IDindirizzo,@IDdipartimento,@IDannoscolastico)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                        cmd.Parameters.AddWithValue("@anno", classe.Anno);
                        cmd.Parameters.AddWithValue("@sezione", classe.Sezione);
                        cmd.Parameters.AddWithValue("@IDindirizzo", classe.Idindirizzo);
                        cmd.Parameters.AddWithValue("@classeArticolataCon", classe.ClasseArticolataCon > 0 ? (object)classe.ClasseArticolataCon : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDutente", classe.Idutente > 0 ? (object)classe.Idutente : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDdipartimento", classe.IDdipartimento > 0 ? (object)classe.IDdipartimento : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", classe.IDannoscolastico > 0 ? (object)classe.IDannoscolastico : DBNull.Value);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("Errore nell'inserimento della classe: nessuna riga interessata.");
                    }
                    conn.Close();
                    ControllaClassiArticolate(classe);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificaClasse(ClsClasseDL classe)
        {
            try
            {
                long idVecchiaCompagnaA = ClasseArticolataConQuale(classe.ID);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE classi 
                       SET sigla = @sigla, 
                           anno = @anno, 
                           sezione = @sezione, 
                           classeArticolataCon = @classeArticolataCon,
                           IDutente = @IDutente,
                           IDindirizzo = @IDindirizzo,
                           IDdipartimento = @IDdipartimento,
                           IDannoscolastico = @IDannoscolastico
                       WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                        cmd.Parameters.AddWithValue("@anno", classe.Anno);
                        cmd.Parameters.AddWithValue("@sezione", classe.Sezione);
                        cmd.Parameters.AddWithValue("@IDindirizzo", classe.Idindirizzo);
                        cmd.Parameters.AddWithValue("@classeArticolataCon", classe.ClasseArticolataCon > 0 ? (object)classe.ClasseArticolataCon : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDutente", classe.Idutente > 0 ? (object)classe.Idutente : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDdipartimento", classe.IDdipartimento > 0 ? (object)classe.IDdipartimento : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", classe.IDannoscolastico > 0 ? (object)classe.IDannoscolastico : DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", classe.ID);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("Nessuna classe trovata con l'ID specificato. Modifica fallita.");
                    }
                    conn.Close();

                    ControllaClassiArticolate(classe,idVecchiaCompagnaA);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaClasse(long id)
        {
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
                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region gestioni classiArticolate
        public static void ControllaClassiArticolate(ClsClasseDL classe, long idVecchiaCompagnaA = -1)
        {
            classe.ID = RilevaIDclasse(classe);

            // Usa il valore passato, oppure leggilo (per InsertClasse non serve)
            if (idVecchiaCompagnaA == -1)
                idVecchiaCompagnaA = ClasseArticolataConQuale(classe.ID);

            if (classe.ClasseArticolataCon > 0)
            {
                if (idVecchiaCompagnaA > 0 && idVecchiaCompagnaA != classe.ClasseArticolataCon)
                    ModificaClasseArticolata(idVecchiaCompagnaA, -1);

                long idVecchiaCompagnaC = ClasseArticolataConQuale(classe.ClasseArticolataCon);
                if (idVecchiaCompagnaC > 0 && idVecchiaCompagnaC != classe.ID)
                    ModificaClasseArticolata(idVecchiaCompagnaC, -1);

                ModificaClasseArticolata(classe.ID, classe.ClasseArticolataCon);
                ModificaClasseArticolata(classe.ClasseArticolataCon, classe.ID);
            }
            else
            {
                if (idVecchiaCompagnaA > 0)
                    ModificaClasseArticolata(idVecchiaCompagnaA, -1);
                ModificaClasseArticolata(classe.ID, -1);
            }
        }

        public static long RilevaIDclasse(ClsClasseDL classe)
        {
            long IDclasse = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID FROM classi 
                          WHERE anno = @anno 
                          AND sigla = @sigla 
                          AND sezione = @sezione 
                          AND IDannoscolastico = @IDannoscolastico 
                          AND IDindirizzo = @IDindirizzo 
                          AND IDdipartimento = @IDdipartimento";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@anno", classe.Anno);
                        cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                        cmd.Parameters.AddWithValue("@sezione", classe.Sezione);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", classe.IDannoscolastico > 0 ? (object)classe.IDannoscolastico : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDindirizzo", classe.Idindirizzo > 0 ? (object)classe.Idindirizzo : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDdipartimento", classe.IDdipartimento > 0 ? (object)classe.IDdipartimento : DBNull.Value);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            IDclasse = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel rilevare l'ID della classe: " + ex.Message);
            }
            return IDclasse;
        }

        public static long ClasseArticolataConQuale(long idClasse)
        {
            long classeArticolataCon = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT classeArticolataCon 
                          FROM classi 
                          WHERE ID = @idClasse";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idClasse", idClasse);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0 && dt.Rows[0]["classeArticolataCon"] != DBNull.Value)
                            classeArticolataCon = Convert.ToInt64(dt.Rows[0]["classeArticolataCon"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella verifica della classe articolata: " + ex.Message);
            }
            return classeArticolataCon;
        }
        private static void ModificaClasseArticolata(long IDClasse, long IDclasseDaArticolare)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE classi 
                           SET classeArticolataCon = @classeArticolataCon 
                           WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@classeArticolataCon", (IDclasseDaArticolare <= 0) ? (object)DBNull.Value : IDclasseDaArticolare);
                        cmd.Parameters.AddWithValue("@id", IDClasse);

                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("Nessuna classe trovata con l'ID specificato.");
                    }
                } 
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel database: " + ex.Message);
            }
        }
        #endregion
    }
}
