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
    public static class ClsDisciplinaBL
    {
        #region rilevamenti specifici
        public static ClsDisciplinaDL CaricaDisciplina(long id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM discipline WHERE ID = @id";
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
                            return new ClsDisciplinaDL
                            {
                                ID = Convert.ToInt64(row["ID"]),
                                Nome = row["nome"].ToString(),
                                Anno = Convert.ToInt32(row["anno"]),
                                OreTeoria = Convert.ToInt32(row["oreTeoria"]),
                                OreLaboratorio = Convert.ToInt32(row["oreLaboratorio"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il caricamento della disciplina: " + ex.Message);
            }
            return null;
        }

        public static ClsDisciplinaDL TrovaDisciplinaNomeAnno(string nome, int anno)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM discipline 
                           WHERE nome = @nome 
                           AND anno = @anno";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@anno", anno);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            return new ClsDisciplinaDL
                            {
                                ID = Convert.ToInt64(row["ID"]),
                                Nome = row["nome"].ToString(),
                                Anno = Convert.ToInt32(row["anno"]),
                                OreTeoria = Convert.ToInt32(row["oreTeoria"]),
                                OreLaboratorio = Convert.ToInt32(row["oreLaboratorio"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la ricerca della disciplina: " + ex.Message);
            }
            return null;
        }

        public static List<ClsDisciplinaDL> CaricaDisciplineAnnoScolasticoDipartimento(
    long IDannoScolastico, long IDdipartimento, out List<long> IDindirizziTrovati)
        {
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            Dictionary<long, int> conteggioIndirizzi = new Dictionary<long, int>();

            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.nome, d.anno, d.oreteoria, d.orelaboratorio, 
                                  d.disciplinaspeciale, d.IDdisciplinaSuccessiva,
                                  ap.IDindirizzo
                               FROM vigere v
                               JOIN discipline d ON v.IDdisciplina = d.ID
                               JOIN gestire g ON g.IDdisciplina = d.ID
                               JOIN appartenere ap ON ap.IDdisciplina = d.ID
                               JOIN anniscolastici aInizio ON v.IDannoscolasticoinizio = aInizio.ID
                               LEFT JOIN anniscolastici aFine ON v.IDannoscolasticofine = aFine.ID
                               JOIN anniscolastici aTarget ON aTarget.ID = @IDannoScolastico
                               WHERE g.IDdipartimento = @IDdipartimento
                               AND aTarget.dataInizio >= aInizio.dataInizio
                               AND aTarget.dataFine <= COALESCE(aFine.dataFine, (SELECT MAX(dataFine) FROM anniscolastici))
                               AND d.nome NOT LIKE '%otenziamento%'
                               ORDER BY d.anno";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDannoScolastico", IDannoScolastico);
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            da.Fill(dt);
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        long idDisciplina = Convert.ToInt32(row["ID"]);
                        long idIndirizzo = Convert.ToInt64(row["IDindirizzo"]);

                        // Conteggio indirizzo (per trovare il prevalente)
                        if (!conteggioIndirizzi.ContainsKey(idIndirizzo))
                            conteggioIndirizzi[idIndirizzo] = 0;
                        conteggioIndirizzi[idIndirizzo]++;

                        // Aggiungi disciplina solo se non già presente (righe duplicate per JOIN appartenere)
                        if (!discipline.Any(d => d.ID == idDisciplina))
                        {
                            ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                            disciplina.ID = Convert.ToInt32(row["ID"]);
                            disciplina.Nome = row["nome"].ToString();
                            disciplina.Anno = Convert.ToInt32(row["anno"]);
                            disciplina.OreTeoria = Convert.ToInt32(row["oreteoria"]);
                            disciplina.OreLaboratorio = Convert.ToInt32(row["orelaboratorio"]);
                            disciplina.DisciplinaSpeciale = row["disciplinaspeciale"].ToString();
                            disciplina.IDdisciplinaSuccessiva = (row["IDdisciplinaSuccessiva"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDdisciplinaSuccessiva"]);
                            discipline.Add(disciplina);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Ordina per frequenza decrescente → il primo è l'indirizzo prevalente
            IDindirizziTrovati = conteggioIndirizzi
                .OrderByDescending(kvp => kvp.Value)
                .Select(kvp => kvp.Key)
                .ToList();

            return discipline;
        }

        #endregion
        #region rilevamento parametri specifici

        public static int TrovaIDPotenziamentoDipartimentoPerCDC(int IDdipartimento, long IDcdc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID 
                           FROM discipline d
                           JOIN gestire g ON g.IDdisciplina = d.ID
                           JOIN richiedere r ON r.IDdisciplina = d.ID
                           WHERE g.IDdipartimento = @IDdipartimento
                           AND d.nome LIKE '%otenziamento%'
                           AND r.IDclassediconcorso = @IDcdc
                           LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDcdc", IDcdc);
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


        //public static int MostraOreDocenteTeorico(long IDdocente)
        //{
        //    int _oreDocenteTeorico = 0;


        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connectionString))
        //        {

        //            conn.Open();
        //            string sql = "SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio " +
        //                         "FROM assegnare a " +
        //                         "JOIN discipline d ON a.IDdisciplina = d.ID " +
        //                         "WHERE a.IDutente = @IDdocente";
        //            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@IDdocente", IDdocente);
        //                MySqlDataReader dr = cmd.ExecuteReader();
        //                if (dr.HasRows)
        //                {
        //                    if (dr.Read())
        //                    {
        //                        _oreDocenteTeorico = Convert.ToInt32(dr["oreteoria"]);
        //                        _oreDocenteTeorico += Convert.ToInt32(dr["orelaboratorio"]); // Il prof di teoria fa anche le ore di laboratorio
        //                    }
        //                }
        //            }

        //        }        
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return _oreDocenteTeorico;     
        //}

        //public static int MostraOreDocentePratico(long IDdocente)
        //{
        //    int _oreDocentePratico = 0;


        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string sql = @"SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio 
        //                         FROM assegnare a 
        //                         JOIN discipline d ON a.IDdisciplina = d.ID 
        //                         WHERE a.IDutente = @idDocente";
        //            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@idDocente", IDdocente);

        //                using (MySqlDataReader dr = cmd.ExecuteReader())
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        if (dr.Read())
        //                            _oreDocentePratico = Convert.ToInt32(dr["orelaboratorio"]);
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return _oreDocentePratico;
        //}
        public static ClsDisciplinaDL RilevaDisciplina(long ID)
        {
            ClsDisciplinaDL _disciplina = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM discipline WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            _disciplina = new ClsDisciplinaDL(
                                Convert.ToInt64(row["ID"]),
                                row["nome"].ToString(),
                                Convert.ToInt32(row["anno"]),
                                Convert.ToInt32(row["oreLaboratorio"]),
                                Convert.ToInt32(row["oreTeoria"]),
                                row["disciplinaSpeciale"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento della disciplina: " + ex.Message);
            }
            return _disciplina;
        }
        public static int CercaIdDisciplina(ClsDisciplinaDL disciplina)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID FROM discipline 
                   WHERE nome = @nome 
                   AND anno = @anno
                   AND oreLaboratorio = @oreLaboratorio
                   AND oreTeoria = @oreTeoria";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                        cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                        cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                        cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["ID"]) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la ricerca dell'ID disciplina: " + ex.Message);
            }
        }

        //public static string RilevaNomeDipartimento(long id)
        //{
        //    if (id == 0)
        //        return "-";
        //    string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
        //    MySqlConnection conn = new MySqlConnection(connectionString);
        //    ClsDipartimentoDL dipartimento = null;
        //    try
        //    {
        //        conn.Open();
        //        string sql = "SELECT d.nome " +
        //                     "FROM dipartimenti d " +
        //                     "WHERE d.ID = " + id;

        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            dipartimento = new ClsDipartimentoDL();
        //            dipartimento.Nome = dr["nome"].ToString();
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return dipartimento.Nome;
        //}

        public static int MostraOreDocentePratico(long IDdocente)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string sql = @"SELECT ID 
                       FROM discipline 
                       WHERE nome LIKE '%otenziamento%' 
                       LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return 0;
        }
        public static int RilevaOrePotenziamentoDipartimentoPerCDC(int IDdipartimento, long IDcdc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.* 
                   FROM discipline d
                   JOIN gestire g ON g.IDdisciplina = d.ID
                   JOIN richiedere r ON r.IDdisciplina = d.ID
                   WHERE g.IDdipartimento = @IDdipartimento
                   AND d.nome LIKE '%otenziamento%'
                   AND r.IDclassediconcorso = @IDcdc
                   LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDcdc", IDcdc);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return Convert.ToInt32(dt.Rows[0]["oreTeoria"]) +
                                   Convert.ToInt32(dt.Rows[0]["oreLaboratorio"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero ore potenziamento per CDC: " + ex.Message);
            }
            return 0;
        }

        #endregion
        #region Crud
        public static List<ClsDisciplinaDL> CaricaDiscipline(long iddipartimento=0, int anno=0, string nome="")
        {
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = CreaComandoRicerca(iddipartimento,anno,nome, conn))
                    {
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                        conn.Close();
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                    disciplina.ID = Convert.ToInt32(row["id"]);
                    disciplina.Nome = row["nome"].ToString();
                    disciplina.Anno = Convert.ToInt32(row["anno"]);
                    disciplina.OreTeoria = Convert.ToInt32(row["oreteoria"]);
                    disciplina.OreLaboratorio = Convert.ToInt32(row["orelaboratorio"]);
                    disciplina.DisciplinaSpeciale = row["disciplinaspeciale"].ToString();
                    disciplina.IDdisciplinaSuccessiva = (row["IDdisciplinaSuccessiva"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDdisciplinaSuccessiva"]);
                    discipline.Add(disciplina);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return discipline;
        }

        private static MySqlCommand CreaComandoRicerca(long iddipartimento, int anno, string nome, MySqlConnection conn)
        {
            string sql = @"SELECT DISTINCT d.id, d.nome, d.anno, d.oreteoria, d.orelaboratorio, 
                          d.disciplinaspeciale, d.IDdisciplinaSuccessiva 
                   FROM discipline d";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            List<string> condizioni = new List<string>();

            if (iddipartimento > 0)
            {
                sql += " JOIN gestire ON d.ID = gestire.IDdisciplina";
                condizioni.Add("gestire.IDdipartimento = @IDdipartimento");
                cmd.Parameters.AddWithValue("@IDdipartimento", iddipartimento);
            }

            if (anno > 0)
            {
                condizioni.Add("d.anno = @anno");
                cmd.Parameters.AddWithValue("@anno", anno);
            }

            if (!string.IsNullOrWhiteSpace(nome))
            {
                condizioni.Add("d.nome LIKE @nome");
                cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
            }

            if (condizioni.Count > 0)
                sql += " WHERE " + string.Join(" AND ", condizioni);

            sql += " ORDER BY d.anno ASC;";
            cmd.CommandText = sql;
            return cmd;
        }

        public static void InserisciDisciplina(ClsDisciplinaDL disciplina)
        {
            
            MySqlConnection conn = new MySqlConnection(Program.connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            try
            {

                conn.Open();
                string sql = "INSERT INTO discipline (nome, anno, oreLaboratorio, oreTeoria, disciplinaSpeciale,IDdisciplinaSuccessiva) " +
                    "VALUES (@nome, @anno, @oreLaboratorio, @oreTeoria, @disciplinaSpeciale,@IDdisciplinaSuccessiva)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                    cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                    cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                    cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                    cmd.Parameters.AddWithValue("@disciplinaSpeciale", disciplina.DisciplinaSpeciale);
                    if (disciplina.IDdisciplinaSuccessiva != 0)
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", disciplina.IDdisciplinaSuccessiva);
                    else
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", DBNull.Value);

                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                        throw new Exception("non è stato inserito nessuna disciplina");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaDisciplina(long id)
        {
            

            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM discipline WHERE id = @ID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte < 0)
                            throw new Exception("non è stato eliminato nessun record");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificaDisciplina(ClsDisciplinaDL disciplina)
        {
            FrmDisciplina frmDisciplina = new FrmDisciplina();
            MySqlConnection conn = new MySqlConnection(Program.connectionString);

            try
            {
                conn.Open();
                string sql = @"UPDATE discipline 
                           SET nome = @nome, 
                               anno = @anno, 
                               oreLaboratorio = @oreLaboratorio, 
                               oreTeoria = @oreTeoria, 
                               disciplinaSpeciale = @disciplinaSpeciale,
                               IDdisciplinaSuccessiva=@IDdisciplinaSuccessiva
                           WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                    cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                    cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                    cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                    cmd.Parameters.AddWithValue("@disciplinaSpeciale", disciplina.DisciplinaSpeciale);
                    if (disciplina.IDdisciplinaSuccessiva > 0)
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", disciplina.IDdisciplinaSuccessiva);
                    else
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", disciplina.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                    {
                        throw new Exception("non è stato inserito il record");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        
    }
}
