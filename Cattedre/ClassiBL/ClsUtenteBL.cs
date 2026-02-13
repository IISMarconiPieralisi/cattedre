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

        public static long RilevaIDutente(string nome, string cognome)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            long IDutente = 0;
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID  FROM utenti 
                                    WHERE nome= @nome AND cognome = @cognome";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cognome", cognome);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if(dt.Rows.Count>0)
                                IDutente = Convert.ToInt64(dt.Rows[0]["ID"]);
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("errore nella query" + ex);
            }
            return IDutente == null ? IDutente : 0;
        }

        public static string RilevaNomeUtente(long id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            string risultato = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT u.nome, u.cognome 
                                 FROM utenti u  
                                 WHERE u.ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string nome = dr.IsDBNull(0) ? "" : dr.GetString(0);
                                string cognome = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                risultato = $"{nome} {cognome}".Trim();
                            }
                        }
                        conn.Close();
                    }
                    }

            }
            catch (Exception ex)
            {
                throw new Exception("errore nella query" + ex);
            }
            return !string.IsNullOrEmpty(risultato) ? risultato : "-";
        }

        public static List<ClsUtenteDL> CaricaCoordinatoriDipartimenti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            try
            {
                conn.Open();
                string sql = "SELECT ID,email,cognome,nome,tipoUtente,tipoUtente, tipoDocente FROM utenti u WHERE u.tipoUtente = 'C'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsUtenteDL utente = new ClsUtenteDL();
                        utente.ID = Convert.ToInt64(dr["ID"]);
                        utente.Email = dr["email"].ToString();
                        utente.Cognome = dr["cognome"].ToString();
                        utente.Nome = dr["nome"].ToString();
                        utente.TipoUtente = dr["tipoUtente"].ToString();
                        if (!dr.IsDBNull(dr.GetOrdinal("tipoDocente")))
                        {
                            utente.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
                        }
                        else
                        {
                            utente.TipoDocente = '\0'; // oppure un altro valore di default
                        }
                        utente.Colore = dr["colore"].ToString();
                        utenti.Add(utente);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("errore nella query" + ex);
            }
            return utenti;
        }

        public static List<ClsUtenteDL> CaricaCoordinatoriClassi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID,email,cognome,nome,tipoUtente,colore,tipoDocente FROM utenti u WHERE u.tipoUtente LIKE '%D'";

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
    

        public static List<ClsUtenteDL> CaricaUtenti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
                foreach(DataRow row  in ds.Rows)
                {
                    ClsUtenteDL utente = new ClsUtenteDL();
                    utente.ID = Convert.ToInt64(row["ID"]);
                    utente.Email = row["email"].ToString();
                    //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
                    utente.Cognome = row["cognome"].ToString();
                    utente.Nome = row["nome"].ToString();
                    utente.TipoUtente = row["tipoUtente"].ToString();
                    //utente.Colore = row["colore"].ToString();
                    utente.TipoDocente = row["tipoDocente"] != DBNull.Value? Convert.ToChar(row["tipoDocente"]): '\0';
                    utenti.Add(utente);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return utenti;
        }

        public static int TrovaIDdipartimento(long IDutente)
        {
            int risultato = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT IDdipartimento FROM afferire 
                        WHERE IDutente =@IDutente ";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                                risultato = Convert.ToInt32(dr["IDdipartimento"]);
                            
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return risultato;
        }
        #region Login
        public static bool Login(string email, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT COUNT(ID) as num_utenti FROM utenti " +
                             "WHERE email =@email AND password = @password";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                object result = cmd.ExecuteScalar();

                int UtentiLoggati = 0;
                if (result != null)
                    UtentiLoggati = Convert.ToInt32(result);
                
                conn.Close();
                if (UtentiLoggati == 1)
                   return true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("errore nella query" + ex.Message);
            }
            return false;
        }
        public static bool loginGoogle(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            int UtentiLoggati = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(ID) as num_utenti FROM utenti " +
                                 "WHERE email =@email";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        object result = cmd.ExecuteScalar();

                        
                        if (result != null)
                            UtentiLoggati = Convert.ToInt32(result);

                    }
                }
                if (UtentiLoggati == 1)
                    return true;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
    
        #endregion
        public static ClsUtenteDL caricautente(string _email)
        {
            ClsUtenteDL utente = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT ID,email,cognome,nome,tipoUtente,tipoUtente, tipoDocente  FROM utenti" +
                    " WHERE email =@email"; 

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", _email);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    utente = new ClsUtenteDL();

                    utente.ID = Convert.ToInt64(dr["ID"]);
                    utente.Email = dr["email"].ToString();
                    utente.Cognome = dr["cognome"].ToString();
                    utente.Nome = dr["nome"].ToString();
                    utente.TipoUtente = dr["tipoUtente"].ToString();
                    utente.TipoDocente=!dr.IsDBNull(dr.GetOrdinal("tipoDocente"))? Convert.ToChar(dr["tipoDocente"]): '\0';
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("errore nella query" + ex);
            }

            return utente;
        }


        public static bool Logout()
        {
            return false;
        }

        public static void InserisciUtente(ClsUtenteDL utente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
                throw new Exception("errore nella query" + ex);
            }

        }

        public static void ModificaUtente(ClsUtenteDL utente, long IDutente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

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
                throw new Exception("errore nella query" + ex.Message);
            }
        }

        public static void  EliminaUtente(long IDutente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
        public static List<ClsUtenteDL> FiltraUtenti(List<string> parametri,string Filtro)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
           
            DataTable ds = new DataTable();
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = CreaComandoRicerca(Filtro, parametri, conn))
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
                throw new Exception( ex.Message);
            }
            return utenti;
        }
        public static MySqlCommand CreaComandoRicerca(string Filtro, List<string>parametri, MySqlConnection conn)
        {
            string sql = "SELECT ID, nome, cognome, email, password, tipoutente, tipodocente, colore FROM utenti ";
            MySqlCommand cmd = new MySqlCommand("", conn);
            switch (Filtro)
            {
                case "tipoDocente":
                    sql += "WHERE tipoDocente = @tipoDocente";
                    cmd.Parameters.AddWithValue("@TipoDocente", parametri[0]);
                    break;
                case "tipoUtente":
                    List<string> orConditions = new List<string>();
                    for (int i = 0; i < parametri.Count; i++)
                    {
                        orConditions.Add($"tipoUtente = @param{i}");
                        cmd.Parameters.AddWithValue($"@param{i}", parametri[i]);
                    }
                    sql += "WHERE " + string.Join(" OR ", orConditions);
                    break;
                case "tipoContratto":
                    // Corretto FORM in FROM e aggiunto parametro
                    sql = "SELECT u.* FROM utenti u JOIN contratti c ON u.ID = c.IDutente WHERE c.tipoContratto = @param0";
                    cmd.Parameters.AddWithValue("@param0", parametri[0]);
                    break;
            }
            cmd.CommandText = sql;
            return cmd;
        }

        public static List <ClsUtenteDL> RicercaPerNomeCognome(string _ricerca)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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

    }

}
