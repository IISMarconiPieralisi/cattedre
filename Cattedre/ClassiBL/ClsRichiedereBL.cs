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
    public static class ClsRichiedereBL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
        #region Rilevazioni
        public static List<ClsDisciplinaDL> RilevaDiscipinaCDC(long IDcdc)
        {
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.nome,d.anno
                                    FROM discipline d
                                    JOIN richiedere r ON d.ID = r.IDdisciplina
                           WHERE r.IDclasseDiConcorso = @IDclasseDiconcorso";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDclasseDiconcorso",IDcdc);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        ClsDisciplinaDL disc = new ClsDisciplinaDL();
                        disc.ID = Convert.ToInt64(row["id"]);
                        disc.Nome = row["nome"].ToString();
                        disc.Anno = Convert.ToInt16(row["anno"]);
                        discipline.Add(disc);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento delle CDC per disciplina: " + ex.Message);
            }
            return discipline;
        }
        public static List<ClsUtenteDL> RilevaUtentiCDC(long IDcdc)
        {
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.nome,d.cognome,d.TipoDocente,d.TipoUtente 
                                    FROM utenti d
                                    JOIN richiedere r ON d.ID = r.IDUtente
                           WHERE r.IDclasseDiConcorso = @IDclasseDiconcorso";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDclasseDiconcorso", IDcdc);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        ClsUtenteDL utente = new ClsUtenteDL();
                        utente.ID = Convert.ToInt64(row["ID"]);
                        utente.Cognome = row["cognome"].ToString();
                        utente.Nome = row["nome"].ToString();
                        utente.TipoUtente = row["tipoUtente"].ToString();
                        utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                        utenti.Add(utente);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento delle CDC per utente: " + ex.Message);
            }
            return utenti;
        }
        public static List<ClsClasseDiConcorsoDL> RilevaCDCDocente(long IDutente)
        {
            List<ClsClasseDiConcorsoDL> CDCs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT c.id, c.livello, c.nome, c.abilitazioniRichieste
                           FROM classidiconcorso c
                           JOIN richiedere r ON c.ID = r.IDclasseDiConcorso
                           WHERE r.IDutente = @IdUtente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@IdUtente", MySqlDbType.Int64).Value = IDutente;
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            CDCs.Add(new ClsClasseDiConcorsoDL
                            {
                                ID = Convert.ToInt64(row["id"]),
                                Livello = row["livello"].ToString(),
                                Nome = row["nome"].ToString(),
                                AbilitazioniRichieste = row["abilitazioniRichieste"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento delle CDC del docente: " + ex.Message);
            }
            return CDCs;
        }
        public static List<ClsDisciplinaDL> RilevaDisciplineDocente(long IDutente)
        {
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            DataTable ds = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT d.ID, d.nome,d.anno
                                    FROM discipline d
                                    JOIN richiedere r ON d.ID = r.IDdisciplina
                                    WHERE r.IDutente = @IdUtente";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUtente", IDutente);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                        conn.Close();
                    }
                    foreach (DataRow row in ds.Rows)
                    {
                        ClsDisciplinaDL disc = new ClsDisciplinaDL();
                        disc.ID = Convert.ToInt64(row["id"]);
                        disc.Nome = row["nome"].ToString();
                        disc.Anno =Convert.ToInt16(row["anno"]);
                        discipline.Add(disc);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"errore nella query: {ex.Message}", ex);

            }
            return discipline;
        }
        public static List<ClsClasseDiConcorsoDL> RilevaCDCDiscipina(long IDdisciplina)
        {
            List<ClsClasseDiConcorsoDL> CDCs = new List<ClsClasseDiConcorsoDL>();
            DataTable ds = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.id,c.livello,c.nome,c.abilitazioniRichieste
                                    FROM classidiconcorso c
                                    INNER JOIN richiedere r ON c.ID = r.IDclasseDiConcorso
                                    WHERE r.IDdisciplina = @IDdisciplina";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                    }

                }
                foreach (DataRow row in ds.Rows)
                {
                    ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL
                    {
                        ID = Convert.ToInt64(row["id"]),
                        Livello = row["livello"].ToString(),
                        Nome = row["nome"].ToString(),
                        AbilitazioniRichieste = row["abilitazioniRichieste"].ToString()
                    };
                    CDCs.Add(cdc);
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return CDCs;
        }
        #endregion
        #region crud
        public static void InserisciRichiedere(ClsRichiedereDL Richiedere)
        {
            

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Richiedere (IDclasseDiConcorso, IDutente,IDdisciplina) " +
                                 "VALUES (@IDclasseDiConcorso, @IDutente, @IDdisciplina)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (Richiedere.IDclassediconcorso > 0)
                            cmd.Parameters.AddWithValue("@IDclasseDiConcorso", Richiedere.IDclassediconcorso);
                        else
                            cmd.Parameters.AddWithValue("@IDclasseDiConcorso", DBNull.Value);

                        if(Richiedere.IDutente > 0)
                            cmd.Parameters.AddWithValue("@IDutente", Richiedere.IDutente);
                        else
                            cmd.Parameters.AddWithValue("@IDutente", DBNull.Value);

                        if (Richiedere.IDdisciplina > 0)
                            cmd.Parameters.AddWithValue("@IDdisciplina", Richiedere.IDdisciplina);
                        else
                            cmd.Parameters.AddWithValue("@IDdisciplina", DBNull.Value);

                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte == 0)
                            throw new InvalidOperationException("No rows were inserted.");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"errore nella query: {ex.Message}", ex);
                }
            }
        }
        public static void ModificaRichiestaUtente(long idUtente, List<ClsRichiedereDL> RichModifica)
        {
            if (RichModifica.Count <= 0) return;
            if (idUtente <= 0)
                throw new Exception("Errore: l'utente non può avere ID 0");

            List<ClsRichiedereDL> RichUtente = CaricaClassiRichiedereUtente(idUtente);

            // Elimina ciò che è nel DB ma NON è nella nuova lista
            foreach (ClsRichiedereDL ric in RichUtente)
            {
                bool ancoraPresente = RichModifica.Any(r => r.IDclassediconcorso == ric.IDclassediconcorso
                                                         && r.IDdisciplina == ric.IDdisciplina);
                if (!ancoraPresente)
                    EliminaRichiesta(ric.ID);
            }

            // Inserisce ciò che è nella nuova lista ma NON era nel DB
            foreach (ClsRichiedereDL ric in RichModifica)
            {
                ric.IDutente = idUtente;
                if (!RichUtente.Any(r => r.IDclassediconcorso == ric.IDclassediconcorso
                                      && r.IDdisciplina == ric.IDdisciplina))
                    InserisciRichiedere(ric);
            }
        }
        public static void ModificaRichiestaDisciplina(long idDisciplina, List<ClsRichiedereDL> RichModifica)
        {
            // 1. Controllo validità input
            if (RichModifica == null || RichModifica.Count <= 0) return;
            if (idDisciplina <= 0)
                throw new Exception("Errore: la disciplina non può avere ID 0");

            // 2. Carichiamo lo stato attuale dal DB filtrando per Disciplina
            List<ClsRichiedereDL> RichDisciplina = CaricaClassiRichiedereConDisciplina(idDisciplina);

            // 3. ELIMINAZIONE: Rimuoviamo i record presenti nel DB ma non più nella nuova lista
            foreach (ClsRichiedereDL ric in RichDisciplina)
            {
                bool ancoraPresente = RichModifica.Any(r => r.IDclassediconcorso == ric.IDclassediconcorso
                                                         && r.IDdisciplina == ric.IDdisciplina);
                if (!ancoraPresente)
                    EliminaRichiesta(ric.ID);
            }

            // 4. INSERIMENTO: Aggiungiamo i record nuovi
            foreach (ClsRichiedereDL ric in RichModifica)
            {
                bool esisteGia = RichDisciplina.Any(r => r.IDclassediconcorso == ric.IDclassediconcorso
                                                      && r.IDdisciplina == ric.IDdisciplina);
                if (!esisteGia)
                    InserisciRichiedere(ric);
            }
        }
        public static void EliminaRichiesta(long IDrichiedere)
        {
            
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"DELETE FROM Richiedere" +
                             " WHERE ID = @ID ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", IDrichiedere);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if(righeCoinvolte<=0)
                    {
                        throw new InvalidOperationException("Nessuna riga è stata coinvolta, Errore Query");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion
        #region Carica Richiedere
        public static List<ClsRichiedereDL> CaricaClassiRichiedereUtente(long IDutente)
        {
            
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataTable ds = new DataTable();
            List<ClsRichiedereDL> richiederes = new List<ClsRichiedereDL>();
            try
            {
                conn.Open();
                string sql = "SELECT ID, IDutente, IDclasseDiConcorso, IDdisciplina, oreSpeciali FROM richiedere WHERE IDutente=@IDutente";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDutente", IDutente);
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(ds);
                    }
                    conn.Close();
                }
                foreach (DataRow row in ds.Rows)
                {
                    ClsRichiedereDL richiedere = new ClsRichiedereDL();
                    richiedere.ID = Convert.ToInt64(row["ID"]);
                    richiedere.IDutente = IDutente;
                    richiedere.IDclassediconcorso =(row["IDclasseDiConcorso"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDclasseDiConcorso"]);
                    richiedere.IDdisciplina =(row["IDdisciplina"]==DBNull.Value) ?0: Convert.ToInt64(row["IDdisciplina"]);
                    richiedere.OreSpeciali = Convert.ToInt32(row["OreSpeciali"]);
                    richiederes.Add(richiedere);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return richiederes;

        }
        public static List<ClsRichiedereDL> CaricaClassiRichiedereConDisciplina(long IDdisciplina)
        {
            List<ClsRichiedereDL> Richiederes = new List<ClsRichiedereDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID,IDutente, IDclasseDiConcorso, IDdisciplina 
                           FROM richiedere
                           WHERE IDdisciplina = @IDdisciplina";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            ClsRichiedereDL richiedere = new ClsRichiedereDL();
                            richiedere.ID =Convert.ToInt32( row["ID"]);
                            richiedere.IDutente = (row["IDutente"] == DBNull.Value)?0: Convert.ToInt64(row["IDutente"]);
                            richiedere.IDclassediconcorso = (row["IDclasseDiConcorso"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDclasseDiConcorso"]);
                            richiedere.IDdisciplina = (row["IDdisciplina"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDdisciplina"]);
                            Richiederes.Add(richiedere);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il caricamento delle classi richiedere: " + ex.Message);
            }
            return Richiederes;
        }
        #endregion


    }

}
