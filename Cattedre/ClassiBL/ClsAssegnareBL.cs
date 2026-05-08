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
    public static class ClsAssegnareBL
    {
        #region GestioneAnnoSuccessivo
        public static bool EsistonoAssegnazioniAnnoSuccessivo(long IDannosuccessivo)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string sql = @"SELECT COUNT(*)
                       FROM assegnare
                       WHERE IDannoscolastico = @IDannoscolastico";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IDannoscolastico", IDannosuccessivo);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        

        public static void GeneraCattedreAnnoSuccessivo(long IDdipartimento, long IDannoCorrente, long IDannoSuccessivo)
        {
            DataTable assegnazioni = CaricaDocentiConAssegnazioni(IDdipartimento, IDannoCorrente);

            foreach (DataRow r in assegnazioni.Rows)
            {
                if (r["IDclasse"] == DBNull.Value || r["IDdisciplina"] == DBNull.Value)
                    continue;

                long idClasse = Convert.ToInt64(r["IDclasse"]);
                long idDisciplina = Convert.ToInt64(r["IDdisciplina"]);
                long idDocente = Convert.ToInt64(r["IDutente"]);

                ClsClasseDL classe = ClsClasseBL.CaricaClasse(idClasse);
                ClsDisciplinaDL disciplina = ClsDisciplinaBL.CaricaDisciplina(idDisciplina);

                int annoClasse = classe.Anno;
                int annoSuccessivoClasse;

                if (annoClasse == 1) annoSuccessivoClasse = 2;
                else if (annoClasse == 2) annoSuccessivoClasse = 1;
                else if (annoClasse == 3) annoSuccessivoClasse = 4;
                else if (annoClasse == 4) annoSuccessivoClasse = 5;
                else annoSuccessivoClasse = 3;

                ClsClasseDL nuovaClasse =
                    ClsClasseBL.TrovaClasse(classe.Sezione, annoSuccessivoClasse, classe.Idindirizzo, IDannoSuccessivo);

                if (nuovaClasse == null)
                    continue;

                ClsDisciplinaDL nuovaDisciplina =
                    ClsDisciplinaBL.TrovaDisciplinaNomeAnno(disciplina.Nome, annoSuccessivoClasse);

                if (nuovaDisciplina == null)
                    continue;

                if (EsisteAssegnazione(nuovaClasse.ID, IDannoSuccessivo, nuovaDisciplina.ID))
                    continue;

                long idDoc = Convert.ToInt64(r["IDutente"]);
                int oreSpeciali = Convert.ToInt32(r["oreSpeciali"]);

                ClsAnnoScolasticoDL annoSucc =
                    ClsAnnoScolasticoBL.TrovaAnnoSuccessivo(IDannoCorrente);

                DateTime dal = annoSucc.DataInizio;
                DateTime al = annoSucc.DataFine;

                InserisciAssegnazione(
                    nuovaClasse.ID,
                    IDannoSuccessivo,
                    nuovaDisciplina.ID,
                    idDoc,
                    oreSpeciali,
                    dal,
                    al);
            }
        }
        #endregion
        #region Crud
        public static List<ClsAssegnareDL> PopolaAssegnazioni()
        {
            List<ClsAssegnareDL> ass = new List<ClsAssegnareDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM assegnare";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsAssegnareDL assegnare = new ClsAssegnareDL();
                    assegnare.ID = Convert.ToInt32(row["ID"]);
                    assegnare.OreSpeciali = Convert.ToInt32(row["oreSpeciali"]);
                    // Campi che permettono NULL nel DB 
                    assegnare.IDAnnoScolastico = (row["IDannoscolastico"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDannoscolastico"]);
                    assegnare.IDUtente = (row["IDutente"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDutente"]);
                    assegnare.IDDisciplina = (row["IDdisciplina"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDdisciplina"]);
                    assegnare.IDClasse = (row["IDclasse"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDclasse"]);
                    ass.Add(assegnare);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

                return ass;
        }
        public static void InserisciAssegnazione(long IDclasse,long IDannoscolastico, long IDdisciplina,long IDutente,
            int oreSpeciali,DateTime dal,DateTime al)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO assegnare
                       (IDclasse, IDannoscolastico, IDdisciplina, IDutente, oreSpeciali, dal, al)
                       VALUES
                       (@classe, @anno, @disciplina, @utente, @oreSpeciali, @dal, @al)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@classe", IDclasse);
                cmd.Parameters.AddWithValue("@anno", IDannoscolastico);
                cmd.Parameters.AddWithValue("@disciplina", IDdisciplina);
                cmd.Parameters.AddWithValue("@utente", IDutente);
                cmd.Parameters.AddWithValue("@oreSpeciali", oreSpeciali);
                cmd.Parameters.AddWithValue("@dal", dal);
                cmd.Parameters.AddWithValue("@al", al);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region GestioneAssegnazioni
        public static bool EsisteAssegnazione(long IDclasse, long IDanno, long IDdisciplina)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string sql = @"SELECT COUNT(*)
                       FROM assegnare
                       WHERE IDclasse = @IDclasse
                       AND IDannoscolastico = @IDanno
                       AND IDdisciplina = @IDdisciplina";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
                cmd.Parameters.AddWithValue("@IDanno", IDanno);
                cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
        // Query unica
        public static DataTable CaricaDocentiConAssegnazioni(long IDdipartimento, long IDannoScolastico)
        {

            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string sql = @"SELECT
                                u.ID AS IDutente,
                                u.nome,
                                u.cognome,
                                u.tipoDocente,
                                u.colore,
                                a.IDclasse,
                                a.IDdisciplina,
                                a.oreSpeciali,
                                a.IDannoscolastico,
                                c.tipoContratto,
                                1 AS isInterno

                            FROM utenti u

                            JOIN afferire af
                                ON af.IDutente = u.ID

                            LEFT JOIN contratti c
                                ON c.IDutente = u.ID

                            LEFT JOIN assegnare a
                                ON a.IDutente = u.ID
                                AND a.IDannoscolastico = @IDannoScolastico

                            LEFT JOIN anniscolastici ans
                                ON a.IDannoscolastico = ans.ID
                                AND CURDATE() BETWEEN ans.datainizio AND ans.datafine

                            WHERE af.IDdipartimento = @IDdipartimento
                                AND u.tipoUtente IN('D','C','A')

                            ORDER BY u.cognome, u.nome";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                    cmd.Parameters.AddWithValue("@IDannoScolastico", IDannoScolastico);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static DataTable CaricaDocentiEsterniAssegnati(long IDdipartimento, long IDannoScolastico)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string sql = @"SELECT
                    u.ID AS IDutente,
                    u.nome,
                    u.cognome,
                    u.tipoDocente,
                    u.colore,
                    a.IDclasse,
                    a.IDdisciplina,
                    a.oreSpeciali,
                    a.IDannoscolastico,
                    c.tipoContratto,
                    0 AS isInterno

                FROM utenti u
                JOIN assegnare a
                    ON a.IDutente = u.ID
                    AND a.IDannoscolastico = @IDannoScolastico
                JOIN richiedere r
                    ON r.IDutente = u.ID
                    AND r.IDdisciplina = a.IDdisciplina
                JOIN gestire g
                    ON g.IDdisciplina = a.IDdisciplina
                    AND g.IDdipartimento = @IDdipartimento
                LEFT JOIN contratti c
                    ON c.IDutente = u.ID
                WHERE u.tipoUtente IN ('D','C','A')
                AND NOT EXISTS (
                    SELECT 1 FROM afferire af
                    WHERE af.IDutente = u.ID
                    AND af.IDdipartimento = @IDdipartimento
                )";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                    cmd.Parameters.AddWithValue("@IDannoScolastico", IDannoScolastico);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            return dt;
        }
        #endregion
        #region Ore e cattedre
        public static void SalvaCattedra(long IDclasse, long IDannoscolastico, long IDdisciplina, long IDutente, char tipoDocente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();

                    // se IDutente è 0 (item vuoto) -> DELETE solo la riga del tipo specifico
                    if (IDutente == 0)
                    {
                        string sqlDelete = @"DELETE a FROM assegnare a
                                     JOIN utenti u ON u.ID = a.IDutente
                                     WHERE a.IDclasse = @IDclasse
                                       AND a.IDdisciplina = @IDdisciplina
                                       AND a.IDannoscolastico = @IDannoscolastico
                                       AND u.tipoDocente = @tipoDocente";

                        MySqlCommand cmdDelete = new MySqlCommand(sqlDelete, conn);
                        cmdDelete.Parameters.Add("@IDclasse", MySqlDbType.Int64).Value = IDclasse;
                        cmdDelete.Parameters.Add("@IDannoscolastico", MySqlDbType.Int64).Value = IDannoscolastico;
                        cmdDelete.Parameters.Add("@IDdisciplina", MySqlDbType.Int64).Value = IDdisciplina;
                        cmdDelete.Parameters.Add("@tipoDocente", MySqlDbType.VarChar).Value = tipoDocente.ToString();
                        cmdDelete.ExecuteNonQuery();
                        return;
                    }

                    // Cerca se esiste già una riga per questo TIPO di docente
                    string sqlSelect = @"SELECT a.ID FROM assegnare a
                                 JOIN utenti u ON u.ID = a.IDutente
                                 WHERE a.IDclasse = @IDclasse
                                   AND a.IDdisciplina = @IDdisciplina
                                   AND a.IDannoscolastico = @IDannoscolastico
                                   AND u.tipoDocente = @tipoDocente
                                 LIMIT 1";

                    MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn);
                    cmdSelect.Parameters.Add("@IDclasse", MySqlDbType.Int64).Value = IDclasse;
                    cmdSelect.Parameters.Add("@IDannoscolastico", MySqlDbType.Int64).Value = IDannoscolastico;
                    cmdSelect.Parameters.Add("@IDdisciplina", MySqlDbType.Int64).Value = IDdisciplina;
                    cmdSelect.Parameters.Add("@tipoDocente", MySqlDbType.VarChar).Value = tipoDocente.ToString();

                    object existing = cmdSelect.ExecuteScalar();

                    if (existing != null)
                    {
                        // Esiste già la riga per questo tipo -> UPDATE quella riga specifica tramite ID
                        long rigaID = Convert.ToInt64(existing);

                        string sqlUpdate = @"UPDATE assegnare 
                                     SET IDutente = @IDutente 
                                     WHERE ID = @ID";

                        MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn);
                        cmdUpdate.Parameters.Add("@IDutente", MySqlDbType.Int64).Value = IDutente;
                        cmdUpdate.Parameters.Add("@ID", MySqlDbType.Int64).Value = rigaID;
                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {

                        ClsAnnoScolasticoDL anno = ClsAnnoScolasticoBL.CercaAnnoScolastico(IDannoscolastico);

                        string sqlInsert = @"INSERT INTO assegnare 
                                     (IDclasse, IDannoscolastico, IDdisciplina, IDutente, oreSpeciali, dal, al)
                                     VALUES 
                                     (@IDclasse, @IDannoscolastico, @IDdisciplina, @IDutente, 0, @dal, @al)";

                        MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn);
                        cmdInsert.Parameters.Add("@IDclasse", MySqlDbType.Int64).Value = IDclasse;
                        cmdInsert.Parameters.Add("@IDannoscolastico", MySqlDbType.Int64).Value = IDannoscolastico;
                        cmdInsert.Parameters.Add("@IDdisciplina", MySqlDbType.Int64).Value = IDdisciplina;
                        cmdInsert.Parameters.Add("@IDutente", MySqlDbType.Int64).Value = IDutente;
                        cmdInsert.Parameters.AddWithValue("@dal", anno.DataInizio);
                        cmdInsert.Parameters.AddWithValue("@al", anno.DataFine);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante UpdateCattedra: " + ex.Message);
            }
        }

        public static void SalvaOrePot(int oreSpeciali, long IDutente, long IDannoscolastico, long IDdisciplina)
        {
            ClsAnnoScolasticoDL anno = ClsAnnoScolasticoBL.CercaAnnoScolastico(IDannoscolastico);
            DateTime dal = anno.DataInizio;
            DateTime al = anno.DataFine;

            MySqlConnection conn = new MySqlConnection(Program.connectionString);
            try
            {
                conn.Open();

                string sqlSelect = @"SELECT COUNT(*) FROM assegnare 
                             WHERE IDutente = @idutente 
                               AND IDannoscolastico = @idannoscolastico 
                               AND IDdisciplina = @iddisciplina
                               AND IDclasse IS NULL";

                MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn);
                cmdSelect.Parameters.AddWithValue("@idutente", IDutente);
                cmdSelect.Parameters.AddWithValue("@idannoscolastico", IDannoscolastico);
                cmdSelect.Parameters.AddWithValue("@iddisciplina", IDdisciplina);

                int count = Convert.ToInt32(cmdSelect.ExecuteScalar());

                string sqlSave;
                if (count > 0)
                {
                    if (oreSpeciali == 0) // se le ore di potenziamento di un prof diventano 0, tolgo la riga su assegnare (non interessa sapere quali prof hanno 0 ore)
                    {
                        sqlSave = @"DELETE FROM assegnare 
                            WHERE IDutente = @idutente 
                              AND IDannoscolastico = @idannoscolastico 
                              AND IDdisciplina = @iddisciplina
                              AND IDclasse IS NULL";
                    }
                    else
                    {
                        // Esiste e ore > 0 -> UPDATE
                        sqlSave = @"UPDATE assegnare 
                            SET oreSpeciali = @oreSpeciali,
                                dal = @dal,
                                al  = @al
                            WHERE IDutente = @idutente 
                              AND IDannoscolastico = @idannoscolastico 
                              AND IDdisciplina = @iddisciplina
                              AND IDclasse IS NULL";
                    }
                }
                else
                {
                    // Non esiste e ore = 0 -> non fa nulla
                    if (oreSpeciali == 0)
                    {
                        conn.Close();
                        return;
                    }

                    // Non esiste e ore > 0 -> INSERT
                    sqlSave = @"INSERT INTO assegnare 
                            (IDutente, IDannoscolastico, IDclasse, IDdisciplina, oreSpeciali, dal, al)
                        VALUES 
                            (@idutente, @idannoscolastico, NULL, @iddisciplina, @oreSpeciali, @dal, @al)";
                }

                MySqlCommand cmdSave = new MySqlCommand(sqlSave, conn);
                cmdSave.Parameters.AddWithValue("@oreSpeciali", oreSpeciali);
                cmdSave.Parameters.AddWithValue("@idutente", IDutente);
                cmdSave.Parameters.AddWithValue("@idannoscolastico", IDannoscolastico);
                cmdSave.Parameters.AddWithValue("@iddisciplina", IDdisciplina);
                cmdSave.Parameters.AddWithValue("@dal", dal);
                cmdSave.Parameters.AddWithValue("@al", al);
                cmdSave.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int RilevaOreDocenteInAltriDipartimenti(
    long IDdocente,
    long IDdipartimentoCorrente,
    long IDannoscolastico,
    List<ClsClasseDiConcorsoDL> cdcDocente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"
                SELECT DISTINCT d.ID, d.oreTeoria, d.oreLaboratorio
                FROM assegnare a
                JOIN discipline d ON d.ID = a.IDdisciplina
                JOIN gestire g ON g.IDdisciplina = d.ID
                WHERE a.IDutente = @IDdocente
                  AND a.IDannoscolastico = @IDannoscolastico
                  AND g.IDdipartimento <> @IDdipartimentoCorrente";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdocente", IDdocente);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", IDannoscolastico);
                        cmd.Parameters.AddWithValue("@IDdipartimentoCorrente", IDdipartimentoCorrente);

                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            da.Fill(dt);

                        int totale = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            long IDdisciplina = Convert.ToInt64(row["ID"]);

                            // Recupera le CDC richieste da questa disciplina
                            List<ClsClasseDiConcorsoDL> cdcDisciplina =
                                ClsClasseDiConcorsoBL.RilevaCDCDisciplina(IDdisciplina);

                            // Trova la CDC del docente che matcha questa disciplina
                            ClsClasseDiConcorsoDL cdcMatch = cdcDocente
                                .FirstOrDefault(cd => cdcDisciplina.Any(dd => dd.ID == cd.ID));

                            if (cdcMatch == null)
                                continue;

                            bool isTeoria = cdcMatch.AbilitazioniRichieste != null &&
                                            cdcMatch.AbilitazioniRichieste.ToLower().Contains("laurea");

                            totale += isTeoria
                                ? Convert.ToInt32(row["oreTeoria"])
                                : Convert.ToInt32(row["oreLaboratorio"]);
                        }
                        return totale;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero ore docente in altri dipartimenti: " + ex.Message);
            }
        }

        #endregion
        #region gestioneCombobox
        public static List<UcAssegnazioni.ProfessoreItem> FiltraDocentiPerComboBox(DataTable docenti, string tipoDocente)
        {
            var lista = new List<UcAssegnazioni.ProfessoreItem>();

            foreach (DataRow row in docenti.Rows)
            {
                if (row["tipoDocente"] == DBNull.Value) continue;
                if (row["tipoDocente"].ToString().Trim() != tipoDocente) continue;

                // evita duplicati
                int id = Convert.ToInt32(row["IDutente"]);
                if (lista.Any(p => p.ID == id)) continue;

                lista.Add(new UcAssegnazioni.ProfessoreItem
                {
                    ID = id,
                    NomeCompleto = row["cognome"] + " " + row["nome"],
                    Colore = UcAssegnazioni.ParseColoreDB(row["colore"] == DBNull.Value ? "" : row["colore"].ToString())
                });
            }

            return lista;
        }
        #endregion
        #region Popolamenti specifici
        public static List<ClsAssegnareDL> PopolaAssegnazioniAnnoScolasticoDipartimento(long IDdipartimento, long IDannoScolastico)
        {
            List<ClsAssegnareDL> ass = new List<ClsAssegnareDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();

                    string sql = "SELECT DISTINCT a.ID, a.oreSpeciali, a.IDannoscolastico, a.IDutente, a.IDdisciplina, a.IDclasse " +
                                 "FROM assegnare a " +
                                 "JOIN gestire g ON a.IDdisciplina = g.IDdisciplina " +
                                 "WHERE a.IDannoscolastico = @IDannoScolastico AND g.IDdipartimento = @IDdipartimento " +
                                 "AND (a.IDclasse IS NOT NULL OR (a.IDclasse IS NULL AND a.oreSpeciali > 0))";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDannoScolastico", IDannoScolastico);
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    ass.Add(new ClsAssegnareDL
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        OreSpeciali = Convert.ToInt32(row["oreSpeciali"]),
                        IDAnnoScolastico = row["IDannoscolastico"] == DBNull.Value ? 0 : Convert.ToInt32(row["IDannoscolastico"]),
                        IDUtente = row["IDutente"] == DBNull.Value ? 0 : Convert.ToInt32(row["IDutente"]),
                        IDDisciplina = row["IDdisciplina"] == DBNull.Value ? 0 : Convert.ToInt32(row["IDdisciplina"]),
                        IDClasse = row["IDclasse"] == DBNull.Value ? 0 : Convert.ToInt32(row["IDclasse"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ass;
        }
        public static int RilevaOrePotDocente(long IDutente, long IDannoScolastico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT IFNULL(SUM(oreSpeciali), 0) 
                                    FROM assegnare 
                                    WHERE IDutente = @IDutente 
                                    AND IDannoscolastico = @IDannoScolastico";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);
                        cmd.Parameters.AddWithValue("@IDannoscolastico", IDannoScolastico);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore ricerca potenziamento dipartimento per CDC: " + ex.Message);
            }
            return 0;
        }
        #endregion
        #region Codice vecchio
        //public static void CopiaDocentiAnnoSuccessivo(long nuovoAnno, long vecchioAnno)
        //{
        //    

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            string sql = @"INSERT INTO assegnare (dal, al, oreSpeciali, @nuovoAnno, IDutente, IDdisciplina, IDclasse)
        //                   SELECT dal, al, oreSpeciali, IDannoscolastico, IDutente, IDdisciplina, IDclasse
        //                   FROM assegnare
        //                   WHERE IDannoscolastico = @vecchioAnno";

        //            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.Add("@nuovoAnno", MySqlDbType.Int64).Value = nuovoAnno;
        //                cmd.Parameters.Add("@vecchioAnno", MySqlDbType.Int64).Value = vecchioAnno;

        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Errore durante CopiaDocentiAnnoSuccessivo: " + ex.Message);
        //    }
        //}

        //public static List<ClsUtenteDL> CercaDocentiDiRiferimento(int IDdipartimento, int IDclasse, int IDdisciplina)
        //{
        //    

        //    List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
        //    FrmDipartimenti frmDocenti = new FrmDipartimenti();
        //    DataTable ds = new DataTable();
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string sql = "SELECT DISTINCT u.ID, u.email, u.cognome, u.nome, u.tipoDocente " +
        //                   "FROM utenti u " +
        //                    "JOIN assegnare a ON u.ID = a.IDutente " +
        //                   "JOIN afferire af ON u.ID = af.IDutente " +
        //                   "JOIN discipline d ON a.IDdisciplina = d.ID " +
        //                   "WHERE u.tipoUtente = 'D' " +
        //                   "OR u.tipoUtente = 'C' " +
        //                   "OR u.tipoUtente = 'A' " +
        //                     "AND a.IDclasse = @IDclasse " +
        //                     "AND af.IDdipartimento = @IDdipartimento " +
        //                     "AND a.IDdisciplina = @IDdisciplina ";

        //            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
        //                cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
        //                cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
        //                using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
        //                {
        //                    dr.Fill(ds);
        //                }
        //                conn.Close();
        //            }
        //        }
        //        foreach (DataRow row in ds.Rows)
        //        {
        //            ClsUtenteDL utente = new ClsUtenteDL();
        //            utente.ID = Convert.ToInt64(row["ID"]);
        //            utente.Email = row["email"].ToString();
        //            //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
        //            utente.Cognome = row["cognome"].ToString();
        //            utente.Nome = row["nome"].ToString();
        //            utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
        //            docentiDipartimento.Add(utente);
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return docentiDipartimento;
        //}

        //public static List<ClsUtenteDL> CercaDocentiPossibiliSostituti(int IDdipartimento, int IDclasseDiConcorso)
        //{
        //    
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
        //    try
        //    {
        //        conn.Open();
        //        string sql = "SELECT u.ID, u.email,u.cognome, u.nome, u.tipoDocente " +
        //               "FROM utenti u " +
        //               "JOIN assegnare a ON u.ID = a.IDutente " +
        //               "JOIN afferire af ON u.ID = af.IDutente " +
        //               "JOIN richiedere r ON u.ID = r.IDutente " +
        //               "WHERE u.tipoUtente = 'D' " +
        //               "OR u.tipoUtente = 'C' " +
        //               "OR u.tipoUtente = 'A' " +
        //                 "AND af.IDdipartimento = @IDdipartimento " +
        //                 "AND r.IDclassediconcorso = @IDclasseDiConcorso";

        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
        //        cmd.Parameters.AddWithValue("@IDclasseDiConcorso", IDclasseDiConcorso);
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                ClsUtenteDL docenteDipartimento = new ClsUtenteDL();
        //                docenteDipartimento.ID = Convert.ToInt64(dr["ID"]);
        //                docenteDipartimento.Email = dr["email"].ToString();
        //                docenteDipartimento.Cognome = dr["cognome"].ToString();
        //                docenteDipartimento.Nome = dr["nome"].ToString();
        //                docenteDipartimento.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
        //                docentiDipartimento.Add(docenteDipartimento);
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return docentiDipartimento;
        //}

        //public static ClsUtenteDL MostraDocenteTeorico(int IDdipartimento, int IDclasse, int IDdisciplina)
        //{
        //    ClsUtenteDL docente = null;
        //    
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
        //    try
        //    {
        //        conn.Open();
        //        string sql = @"SELECT u.ID, u.email,u.cognome, u.nome, u.tipoDocente, u.tipoUtente
        //       FROM utenti u
        //       JOIN assegnare a ON u.ID = a.IDutente
        //       WHERE u.tipoDocente='T' AND (u.tipoUtente = 'D' OR u.tipoUtente = 'C' OR tipoUtente='A')
        //       AND a.IDclasse = @IDclasse Limit 1";

        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
        //        cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
        //        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
        //        MySqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                docente = new ClsUtenteDL();
        //                docente.ID = Convert.ToInt64(dr["id"]);
        //                docente.Email = dr["email"].ToString();
        //                docente.Nome = dr["nome"].ToString();
        //                docente.Cognome = dr["cognome"].ToString();
        //                docente.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
        //                docente.TipoUtente = dr["tipoUtente"].ToString();
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return docente;
        //}

        //public static ClsUtenteDL MostraDocentePratico(int IDdipartimento, int IDclasse, int IDdisciplina)
        //{
        //    ClsUtenteDL docente = null;
        //    
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
        //    try
        //    {
        //        conn.Open();
        //        string sql = @"SELECT u.ID, u.email, u.password, u.cognome, u.nome, u.tipoDocente, u.tipoUtente
        //       FROM utenti u
        //       JOIN assegnare a ON u.ID = a.IDutente
        //       WHERE u.tipoDocente='L' AND (u.tipoUtente = 'D' OR u.tipoUtente = 'C' OR tipoUtente='A')
        //       AND a.IDclasse = @IDclasse 
        //       Limit 1";

        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
        //        cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
        //        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
        //        MySqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                docente = new ClsUtenteDL();
        //                docente.ID = Convert.ToInt64(dr["id"]);
        //                docente.Email = dr["email"].ToString();
        //                docente.Password = dr["password"].ToString();
        //                docente.Nome = dr["nome"].ToString();
        //                docente.Cognome = dr["cognome"].ToString();
        //                docente.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
        //                docente.TipoUtente = dr["tipoUtente"].ToString();
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return docente;
        //}
        //public static int CaricaOrePotenziamentoDocente(int IDutente)
        //{
        //    ClsAssegnareDL assegnare = null;
        //    
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    try
        //    {
        //        conn.Open();
        //        string sql = "SELECT a.oreSpeciali " +
        //               "FROM assegnare a " +
        //               "JOIN utenti u ON a.IDutente = u.ID " +
        //               "JOIN afferire af ON u.ID = af.IDutente " +
        //               "JOIN discipline d ON a.IDdisciplina = d.ID " +
        //               "WHERE u.tipoUtente = 'D' " +
        //               "OR u.tipoUtente = 'C' " +
        //               "OR u.tipoUtente = 'A' " +
        //               "AND u.ID = @IDutente " +
        //               "AND d.nome LIKE 'Potenziamento%'";
        //               //"AND af.IDdipartimento = @IDdipartimento ";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@IDutente", IDutente);
        //        //cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                assegnare = new ClsAssegnareDL();
        //                assegnare.OreSpeciali = Convert.ToInt32(dr["oreSpeciali"]);
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return assegnare.OreSpeciali;
        //}



        //public static long RicavaIDutente(string nome, string cognome)
        //{
        //    
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    ClsUtenteDL docente = null;
        //    try
        //    {
        //        conn.Open();
        //        string sql = "SELECT ID FROM utenti WHERE nome = @nome AND cognome = @cognome";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@nome", nome);
        //        cmd.Parameters.AddWithValue("@cognome", cognome);
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                docente = new ClsUtenteDL();
        //                docente.ID = Convert.ToInt32(dr["ID"]);
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return docente.ID;
        //}

        //public static long RicavaIDassegnare(int oreSpeciali, long idUtente)
        //{
        //    
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    ClsUtenteDL docente = null;
        //    try
        //    {
        //        conn.Open();
        //        string sql = "SELECT ID FROM assegnare WHERE oreSpeciali = @oreSpeciali AND idUtente = @idUtente AND oreSpeciali > 0";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@idUtente", idUtente);
        //        cmd.Parameters.AddWithValue("@orespecili", oreSpeciali);
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                docente = new ClsUtenteDL();
        //                docente.ID = Convert.ToInt32(dr["ID"]);
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return docente.ID;
        //}
        #endregion
    }
}
