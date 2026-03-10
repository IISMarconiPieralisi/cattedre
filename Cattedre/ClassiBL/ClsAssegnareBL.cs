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
        public static void GeneraCattedreAnnoSuccessivo(int IDdipartimento, int IDannoCorrente, int IDannoSuccessivo)
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
                    ClsClasseBL.TrovaClasse(classe.Sezione, annoSuccessivoClasse, classe.Idindirizzo);

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

        public static void InserisciAssegnazione(
            long IDclasse,
            long IDannoscolastico,
            long IDdisciplina,
            long IDutente,
            int oreSpeciali,
            DateTime dal,
            DateTime al)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
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

        public static bool EsisteAssegnazione(long IDclasse, long IDanno, long IDdisciplina)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
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

        public static DataTable CaricaDocentiConAssegnazioni(int IDdipartimento, long IDannoScolastico)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT
                                u.ID AS IDutente,
                                u.nome,
                                u.cognome,
                                u.tipoDocente,
                                a.IDclasse,
                                a.IDdisciplina,
                                a.oreSpeciali,
                                a.IDannoscolastico

                            FROM utenti u

                            JOIN afferire af
                                ON af.IDutente = u.ID

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

        public static void UpdateCattedra(long IDclasse, long IDannoscolastico, long IDdisciplina, long IDutente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE assegnare 
                           SET IDutente = @IDutente 
                           WHERE IDclasse = @IDclasse 
                           AND IDdisciplina = @IDdisciplina 
                           AND IDannoscolastico = @IDannoscolastico";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@IDclasse", MySqlDbType.Int64).Value = IDclasse;
                        cmd.Parameters.Add("@IDannoscolastico", MySqlDbType.Int64).Value = IDannoscolastico;
                        cmd.Parameters.Add("@IDdisciplina", MySqlDbType.Int64).Value = IDdisciplina;
                        cmd.Parameters.Add("@IDutente", MySqlDbType.Int64).Value = IDutente;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante UpdateCattedra: " + ex.Message);
            }
        }

        //public static void CopiaDocentiAnnoSuccessivo(long nuovoAnno, long vecchioAnno)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

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
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

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
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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

        public static void SalvaOrePot(int oreSpeciali, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsAssegnareDL assegnare = null;
            try
            {
                conn.Open();
                string sql = @"UPDATE assegnare a
                                JOIN anniscolastici ans ON a.IDannoscolastico = ans.ID
                                SET a.oreSpeciali = @oreSpeciali
                                WHERE a.ID = @id
                                  AND CURDATE() BETWEEN ans.datainizio AND ans.datafine";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@oreSpeciali", oreSpeciali);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        assegnare = new ClsAssegnareDL();
                        assegnare.OreSpeciali = Convert.ToInt32(dr["oreSpeciali"]);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public static long RicavaIDutente(string nome, string cognome)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
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
    }
}
