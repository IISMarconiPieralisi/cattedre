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
        internal  static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
        #region ricerce specifiche
        public static ClsClasseDL CaricaClasseDaID(long idClasse)
        {
            ClsClasseDL classe = null;
            DataTable ds = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query filtrata per ID
                    string sql = "SELECT * FROM classi WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idClasse);

                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                    }
                }

                // Se abbiamo trovato una riga, mappiamo l'oggetto
                if (ds.Rows.Count > 0)
                {
                    DataRow row = ds.Rows[0];
                    classe = new ClsClasseDL
                    {
                        ID = Convert.ToInt64(row["ID"]),
                        Sigla = row["sigla"].ToString(),
                        Anno = Convert.ToInt32(row["anno"]),
                        Sezione = row["sezione"].ToString(),
                        // Gestione null per i campi opzionali
                        ClasseArticolataCon = (row["classeArticolataCon"] == DBNull.Value) ? 0 : Convert.ToInt32(row["classeArticolataCon"]),
                        Idutente = (row["IDutente"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDutente"]),
                        Idindirizzo = Convert.ToInt64(row["IDindirizzo"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return classe;
        }
        public static long TrovaIndirizzoClasse(long IDclasse)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT IDindirizzo 
                       FROM classi
                       WHERE ID = @IDclasse
                       LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
                    object res = cmd.ExecuteScalar();
                    return Convert.ToInt64(res);
                }
            }
        }

        public static string RilevaSiglaClasse(long id)
        {
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
            long _ID = 0;
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

        #endregion
        #region popolamenti Specifici
        public static List<ClsClasseDL> CaricaClassiDipartimento(int IDdipartimento)
        {
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
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
                    _classe.IDannoscolastico= (row["IDannoscolastico"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDannoscolastico"]);
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
        public static List<ClsClasseDL> CaricaClassiFiltrate(int anno = 0, long IDindirizzo = 0)
        {
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            DataTable ds = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = CreaQueryFiltri(conn, anno, IDindirizzo))
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
        private static MySqlCommand CreaQueryFiltri(MySqlConnection conn, int anno = 0, long IDindirizzo = 0)
        {
            try
            {
                if (anno <= 0 && IDindirizzo <= 0)
                    throw new Exception("non è stato inserito nessun parametro in cui filtrare,riprovare");
                string sql = "SELECT * FROM classi WHERE ";
                MySqlCommand cmd = new MySqlCommand("", conn);
                if (anno > 0)
                {
                    sql += "anno=@anno ";
                    cmd.Parameters.AddWithValue("@anno", anno);
                }
                if (IDindirizzo > 0)
                {
                    if (anno > 0)
                        sql += "AND ";
                    sql += "IDindirizzo=@IDindirizzo";
                    cmd.Parameters.AddWithValue("@IDindirizzo", IDindirizzo);
                }
                sql += ";";
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

                    ControllaClassiArticolate(classe);
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
        public static void ControllaClassiArticolate(ClsClasseDL classe)
        {
            if (classe.ClasseArticolataCon > 0)
            {
                // 1. Recuperiamo l'ID della classe corrente (se non l'abbiamo già)
                classe.ID = RilevaIDclasse(classe);

                // 2. Troviamo con chi era precedentemente articolata la classe target (B)
                // per "liberare" la vecchia compagna (C)
                long idVecchiaCompagnaTarget = ClasseArticolataConQuale(classe.ClasseArticolataCon);

                if (idVecchiaCompagnaTarget > 0 && idVecchiaCompagnaTarget != classe.ID)
                {
                    // Cancello il riferimento nella vecchia classe C, portandolo a -1 (o 0)
                    ModificaClasseArticolata(idVecchiaCompagnaTarget, -1);
                }

                // 3. Infine, aggiorno la classe target (B) affinché punti alla classe corrente (A)
                ModificaClasseArticolata(classe.ClasseArticolataCon, classe.ID);
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

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            IDclasse= Convert.ToInt32(result);
                      
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
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            classeArticolataCon = Convert.ToInt32(result);
                        

                    }
                    return classeArticolataCon;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella verifica della classe articolata: " + ex.Message);
            }
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
