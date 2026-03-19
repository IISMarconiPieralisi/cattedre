using MySqlConnector;
using System;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;

namespace Cattedre
{
    public static class ClsUtenteBL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

        #region rilevamento by Parametes
        public static long RilevaIDutente(string nome, string cognome)
        {
            long IDutente = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID FROM utenti WHERE nome = @nome AND cognome = @cognome LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cognome", cognome);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            IDutente = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero ID utente: " + ex.Message);
            }
            return IDutente;
        }

        public static string RilevaNomeUtente(long id)
        {
            string risultato = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT u.nome, u.cognome FROM utenti u WHERE u.ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            string nome = row["nome"] != DBNull.Value ? row["nome"].ToString() : "";
                            string cognome = row["cognome"] != DBNull.Value ? row["cognome"].ToString() : "";
                            risultato = $"{nome} {cognome}".Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella query: " + ex.Message);
            }
            return !string.IsNullOrEmpty(risultato) ? risultato : "-";
        }

        public static int TrovaIDdipartimento(long IDutente)
        {
            int risultato = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT IDdipartimento FROM afferire WHERE IDutente = @IDutente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            risultato = Convert.ToInt32(dt.Rows[0]["IDdipartimento"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento del dipartimento: " + ex.Message);
            }
            return risultato;
        }

        public static bool TokenEsistente(long IDutente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT token FROM utenti WHERE ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", IDutente);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt.Rows.Count > 0 && dt.Rows[0]["token"] != DBNull.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella query: " + ex.Message);
            }
            return false;
        }

        #endregion
        #region caricamente by utentispecifici
        public static List<ClsUtenteDL> CaricaCoordinatoriDipartimenti()
        {
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID, email, cognome, nome, tipoUtente, tipoDocente FROM utenti u WHERE u.tipoUtente = 'C'";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            ClsUtenteDL utente = new ClsUtenteDL();
                            utente.ID = Convert.ToInt64(row["ID"]);
                            utente.Email = row["email"].ToString();
                            utente.Cognome = row["cognome"].ToString();
                            utente.Nome = row["nome"].ToString();
                            utente.TipoUtente = row["tipoUtente"].ToString();
                            utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                            utenti.Add(utente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il caricamento dei coordinatori: " + ex.Message);
            }
            return utenti;
        }

        public static List<ClsUtenteDL> CaricaCoordinatoriClassi()
        {
            

            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID,email,cognome,nome,tipoUtente,colore,tipoDocente FROM utenti  WHERE tipoUtente ='D' OR tipoUtente='C'";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        ClsUtenteDL utente = new ClsUtenteDL();
                        utente.ID = Convert.ToInt64(row["ID"]);
                        utente.Email = row["email"].ToString();
                        //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
                        utente.Cognome = row["cognome"].ToString();
                        utente.Nome = row["nome"].ToString();
                        utente.TipoUtente = row["tipoUtente"].ToString();
                        utente.Colore = row["colore"].ToString();
                        utente.TipoDocente = row["tipoDocente"] == null ? Convert.ToChar(row["tipoDocente"]) : '\0';
                        utenti.Add(utente);
                    }
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return utenti;
        }
        public static ClsUtenteDL caricautenteByEmail(string _email)
        {
            ClsUtenteDL utente = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID, email, cognome, nome, tipoUtente, tipoDocente FROM utenti WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", _email);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            utente = new ClsUtenteDL();
                            utente.ID = Convert.ToInt64(row["ID"]);
                            utente.Email = row["email"].ToString();
                            utente.Cognome = row["cognome"].ToString();
                            utente.Nome = row["nome"].ToString();
                            utente.TipoUtente = row["tipoUtente"].ToString();
                            utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il caricamento dell'utente: " + ex.Message);
            }
            return utente;
        }
        #endregion
        #region OperazioniCRUD

        public static List<ClsUtenteDL> CaricaUtenti()
        {
            
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataTable ds = new DataTable();
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            try
            {
                conn.Open();
                string sql = "SELECT ID, nome, cognome, email, password, tipoutente, tipodocente, colore FROM utenti ";

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
                    ClsUtenteDL utente = new ClsUtenteDL();
                    utente.ID = Convert.ToInt64(row["ID"]);
                    utente.Email = row["email"].ToString();
                    //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
                    utente.Cognome = row["cognome"].ToString();
                    utente.Nome = row["nome"].ToString();
                    utente.TipoUtente = row["tipoUtente"].ToString();
                    //utente.Colore = row["colore"].ToString();
                    utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                    utenti.Add(utente);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return utenti;
        }
        public static void InserisciUtente(ClsUtenteDL utente)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO utenti (nome, cognome, email, password, tipoutente, tipodocente, colore)
                                 VALUES (@nome, @cognome, @email, @password, @tipoUtente, @tipoDocente,@colore)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", utente.Nome);
                        cmd.Parameters.AddWithValue("@cognome", utente.Cognome);
                        cmd.Parameters.AddWithValue("@email", utente.Email);
                        cmd.Parameters.AddWithValue("@password", utente.Password);
                        cmd.Parameters.AddWithValue("@tipoUtente", utente.TipoUtente);
                        cmd.Parameters.AddWithValue("@tipoDocente", utente.TipoDocente);
                        cmd.Parameters.AddWithValue("@colore", utente.Colore);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("errore nel inserimento dei dati");

                    }
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificaUtente(ClsUtenteDL utente, long IDutente)
        {
            

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE utenti 
                           SET nome = @nome, 
                               cognome = @cognome, 
                               email = @email, 
                               password = @password, 
                               tipoUtente = @tipoUtente,
                               tipoDocente = @tipoDocente,
                               colore=@colore
                           WHERE id = @IDutente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", utente.Nome);
                        cmd.Parameters.AddWithValue("@cognome", utente.Cognome);
                        cmd.Parameters.AddWithValue("@email", utente.Email);
                        cmd.Parameters.AddWithValue("@password", utente.Password);
                        cmd.Parameters.AddWithValue("@tipoUtente", utente.TipoUtente);
                        cmd.Parameters.AddWithValue("@tipoDocente", utente.TipoDocente);
                        cmd.Parameters.AddWithValue("@colore", utente.Colore);
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);

                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("No rows were inserted.");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaUtente(long IDutente)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"DELETE FROM utenti WHERE id = @IDutente";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    {
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("No rows were inserted.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("errore nella query" + ex);
            }
        }
        #endregion
        #region Operazioni Crud specifiche
        public static void InserisciTokenUtente(string token, long Idutente)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE utenti 
                                SET Token=@token
                                 WHERE ID=@id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@token", token);
                        cmd.Parameters.AddWithValue("@id", Idutente);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("errore nel inserimento del token nel utente: ID= " + Idutente.ToString());

                    }
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void cancellaTokenUtente(long Idutente)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE utenti 
                                SET Token=@token
                                 WHERE ID=@id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@token", DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", Idutente);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("errore nel inserimento del token nel utente: ID= " + Idutente.ToString());

                    }
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Login e logout
        public static bool Login(string email, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(ID) as num_utenti FROM utenti WHERE email = @email AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            return Convert.ToInt32(dt.Rows[0]["num_utenti"]) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il login: " + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// metodo per la login con Gsuite, non usa password perchè, non viene usata
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool LoginByemail(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(ID) as num_utenti FROM utenti WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            return Convert.ToInt32(dt.Rows[0]["num_utenti"]) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il login per email: " + ex.Message);
            }
            return false;
        }
        public static bool Logout()
        {
            return false;
        }

        #endregion
        #region filtri
        public static List<ClsUtenteDL> FiltraUtenti(Dictionary<string, List<string>> Filtri)
        {
            

            DataTable ds = new DataTable();
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = CreaComandoRicerca(Filtri, conn))
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
                    ClsUtenteDL utente = new ClsUtenteDL();
                    utente.ID = Convert.ToInt64(row["ID"]);
                    utente.Email = row["email"].ToString();
                    //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
                    utente.Cognome = row["cognome"].ToString();
                    utente.Nome = row["nome"].ToString();
                    utente.TipoUtente = row["tipoUtente"].ToString();
                    //utente.Colore = row["colore"].ToString();
                    utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                    utenti.Add(utente);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return utenti;
        }
        public static MySqlCommand CreaComandoRicerca(Dictionary<string, List<string>> filtri, MySqlConnection conn)
        {
            string sql = "SELECT u.ID, u.nome, u.cognome, email, password, tipoutente, tipodocente, colore FROM utenti u JOIN contratti c ON u.ID=c.IDutente";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            List<string> condizioni = new List<string>();
            int paramIndex = 0;
            foreach (var filtro in filtri)
            {
                string colonna = filtro.Key;
                List<string> valori = filtro.Value;

                if (valori == null || valori.Count == 0)
                    continue;

                List<string> orConditions = new List<string>();

                foreach (var valore in valori)
                {
                    string paramName = "@p" + paramIndex;
                    orConditions.Add($"{colonna} = {paramName}");
                    cmd.Parameters.AddWithValue(paramName, valore);
                    paramIndex++;
                }

                // Combina valori dello stesso filtro con OR
                condizioni.Add("(" + string.Join(" OR ", orConditions) + ")");
            }

            if (condizioni.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", condizioni);
            }

            cmd.CommandText = sql;
            return cmd;
        }
        #endregion
        #region ricerca
        public static List<ClsUtenteDL> RicercaPerNomeCognome(string _ricerca)
        {
            
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            DataTable dt = new DataTable();
            _ricerca = $"%{_ricerca}%";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID,nome, cognome, email, password, tipoutente, tipodocente, colore
                                 FROM utenti
                                 WHERE CONCAT(cognome,nome) LIKE @Ricerca";
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
                        ClsUtenteDL utente = new ClsUtenteDL();
                        utente.ID = Convert.ToInt64(row["ID"]);
                        utente.Email = row["email"].ToString();
                        //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
                        utente.Cognome = row["cognome"].ToString();
                        utente.Nome = row["nome"].ToString();
                        utente.TipoUtente = row["tipoUtente"].ToString();
                        utente.Colore = row["colore"].ToString();
                        utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                        utenti.Add(utente);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return utenti;
        }
        #endregion

    }
}

  
