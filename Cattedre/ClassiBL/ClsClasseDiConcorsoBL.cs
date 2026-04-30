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
    public static class ClsClasseDiConcorsoBL
    {
        #region CRUD
        public static List<ClsClasseDiConcorsoDL> CaricaCdcs(string livello="", string nome = "")
        {
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.connectionString);
                using (MySqlCommand cmd = CreaComandoRicerca(livello, nome, conn))
                {
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(dt);
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                        ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                        cdc.ID = Convert.ToInt32(row["id"]);
                        cdc.Livello = row["livello"].ToString();
                        cdc.Nome = row["nome"].ToString();
                        cdc.AbilitazioniRichieste = row["abilitazioniRichieste"].ToString();
                        cdcs.Add(cdc);
      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdcs;
        }

        public static long InserisciCdc(ClsClasseDiConcorsoDL cdc)
        {
            

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                // 1) INSERT
                string insertSql = @"
            INSERT INTO classidiconcorso (nome, livello, abilitazioniRichieste)
            VALUES (@nome, @livello, @abilitazioniRichieste);";

                using (MySqlCommand cmd = new MySqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);

                    int righe = cmd.ExecuteNonQuery();
                    if (righe <= 0)
                        throw new DataException("Inserimento CDC fallito");
                }

                // 2) Recupero ID
                using (MySqlCommand idCmd = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                {
                    long newId = Convert.ToInt64(idCmd.ExecuteScalar());
                    cdc.ID = newId;
                    return newId;
                }
            }
        }

        public static void ModificaCdc(ClsClasseDiConcorsoDL cdc, int indice)
        {
            
            MySqlConnection conn = new MySqlConnection(Program.connectionString);

            try
            {
                conn.Open();
                string sql = @"UPDATE classidiconcorso 
                           SET livello = @livello,
                               nome = @nome, 
                               abilitazioniRichieste = @abilitazioniRichieste 
                           WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@id", cdc.ID);
                    cmd.Parameters.AddWithValue("@livello", cdc.Livello);
                    cmd.Parameters.AddWithValue("@nome", cdc.Nome);
                    cmd.Parameters.AddWithValue("@abilitazioniRichieste", cdc.AbilitazioniRichieste);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if (righeCoinvolte < 0)
                        throw new DataException("nessuna riga row");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaCdc(int id)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM classidiconcorso WHERE ID = @id ";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id",id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte < 0)
                            throw new DataException("nessuna riga row");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Caricamenti specifici
        public static List<(ClsClasseDiConcorsoDL cdc, string nomeDisciplina)> CaricaCDCperDisciplina(long IDdipartimento)
        {
            DataTable dt = new DataTable();
            var risultato = new List<(ClsClasseDiConcorsoDL, string)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT  c.*, d.nome AS nomeDisciplina FROM classidiconcorso c
                         JOIN richiedere r ON c.ID = r.IDclassediconcorso
                         JOIN discipline d ON r.IDdisciplina = d.ID
                         JOIN gestire g ON d.ID = g.IDdisciplina
                         WHERE g.IDdipartimento = @IDdipartimento";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                            dr.Fill(dt);
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                    cdc.ID = Convert.ToInt32(row["id"]);
                    cdc.Livello = row["livello"].ToString();
                    cdc.Nome = row["nome"].ToString();
                    cdc.AbilitazioniRichieste = row["abilitazioniRichieste"].ToString();
                    string nomeDisciplina = row["nomeDisciplina"].ToString();
                    risultato.Add((cdc, nomeDisciplina));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return risultato;
        }

        public static string TrovaCodiceDaID(long id)
        {
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.connectionString);
                conn.Open();
                string sql = @"SELECT livello FROM classidiconcorso WHERE ID = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(dt);
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    cdc.Livello = row["livello"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdc.Livello;
        }

        public static long TrovaIDcdc(string codice)
        {
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.connectionString);
                conn.Open();
                string sql = @"SELECT ID FROM classidiconcorso WHERE livello = @codice";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@codice", codice);
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(dt);
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    cdc.ID = Convert.ToInt32(row["id"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdc.ID;
        }
        public static List<ClsClasseDiConcorsoDL> CaricaCDCperDipartimento(long IDdiparitimento)
        {
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.connectionString);
                conn.Open();
                string sql =@"SELECT DISTINCT c.ID, c.livello, c.nome, c.abilitazioniRichieste
                             FROM classidiconcorso c
                             JOIN richiedere r ON c.ID=r.IDclassediconcorso 
                             JOIN discipline d ON r.IDdisciplina = d.ID
                             JOIN gestire g ON d.ID= g.IDdisciplina
                             WHERE g.IDdipartimento =@IDdipartimento";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDdipartimento", IDdiparitimento);
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(dt);
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                    cdc.ID = Convert.ToInt32(row["id"]);
                    cdc.Livello = row["livello"].ToString();
                    cdc.Nome = row["nome"].ToString();
                    cdc.AbilitazioniRichieste = row["abilitazioniRichieste"].ToString();
                    cdcs.Add(cdc);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdcs;
        }
        public static List<ClsClasseDiConcorsoDL> RicercaPerNome(string _ricerca)
        {
            
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            DataTable dt = new DataTable();
            _ricerca = $"%{_ricerca}%";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID,livello,nome,abilitazioniRichieste
                                 FROM classidiconcorso 
                                 WHERE nome LIKE @Ricerca";
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
                        ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                        cdc.ID = Convert.ToInt32(row["id"]);
                        cdc.Livello = row["livello"].ToString();
                        cdc.Nome = row["nome"].ToString();
                        cdc.AbilitazioniRichieste = row["abilitazioniRichieste"].ToString();
                        cdcs.Add(cdc);

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cdcs;
        }
        #endregion
        #region valori specifici
        public static int ContCattedrePotenziamentoCDC(long IDcdc)
        {
                int cattedre = 0;
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    string sql = @"
                SELECT COUNT(DISTINCT r.IDdisciplina)
                FROM (
                    SELECT DISTINCT IDdisciplina, IDclasseDiConcorso
                    FROM richiedere
                ) r
                JOIN discipline d ON r.IDdisciplina = d.ID
                WHERE r.IDclasseDiConcorso = @IDcdc
                  AND d.disciplinaSpeciale LIKE '%pot%'";

                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDcdc", IDcdc);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            cattedre = Convert.ToInt32(result);
                    }
                }
                return cattedre;
        }
        #endregion
        #region filtri
        private static MySqlCommand CreaComandoRicerca(string livello, string nome, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string sql = "SELECT * FROM classidiconcorso";
            List<string> condizioni = new List<string>();

            if (!string.IsNullOrEmpty(livello))
            {
                condizioni.Add("livello LIKE @livello");
                cmd.Parameters.AddWithValue("@livello", $"%{livello}%");
            }
            if (!string.IsNullOrEmpty(nome))
            {
                condizioni.Add("nome LIKE @nome");
                cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
            }
            if (condizioni.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", condizioni);
            }

            sql += " ORDER BY livello";

            cmd.CommandText = sql;
            return cmd;
        }
        #endregion
        #region OreResidue
        /// <summary>
        /// Query 1 — ore totali previste dal piano studi per la classe di concorso
        /// (teorie + laboratorio in base al livello A/B)
        /// </summary>
        private static int OreTeoriaLaboratorio(ClsClasseDiConcorsoDL CdC, ClsAnnoScolasticoDL annoScolastico)
        {
            int ore = 0;
            string campoOre = CdC.Livello.Contains("A")
            ? "SUM(d.oreTeoria)"
            : "SUM(d.oreLaboratorio)";
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                string sql = $@"
                    SELECT {campoOre}
                    FROM (
                        SELECT DISTINCT IDdisciplina, IDclasseDiConcorso
                        FROM richiedere
                    ) r
                    JOIN discipline d ON r.IDdisciplina = d.ID
                    WHERE r.IDclasseDiConcorso = @IDcdc
                      AND (d.disciplinaSpeciale IS NULL OR d.disciplinaSpeciale = '')";

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDannoScolastico", annoScolastico.ID);
                    cmd.Parameters.AddWithValue("@IDcdc", CdC.ID);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        ore = Convert.ToInt32(result);
                }
            }
            return ore;
        }

        /// <summary>
        /// Query 2 — ore già assegnate ai docenti per la classe di concorso
        /// (distinte per tipo docente: T = teoria, L = laboratorio, altro = entrambe)
        /// </summary>
        private static int OreTotaleAssegnate(long IDCdC, long IDannoScolastico)
        {
            int ore = 0;
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                string sql = @"
                SELECT SUM(
                    CASE 
                        WHEN u.tipoDocente = 'T' THEN d.oreTeoria
                        WHEN u.tipoDocente = 'L' THEN d.oreLaboratorio
                        ELSE d.oreTeoria + d.oreLaboratorio
                    END
                )
                FROM utenti          u
                JOIN richiedere  r ON u.ID            = r.IDutente
                JOIN assegnare   a ON u.ID            = a.IDutente
                JOIN discipline  d ON a.IDdisciplina  = d.ID
                WHERE a.IDannoScolastico    = @IDannoScolastico
                  AND r.IDclasseDiConcorso  = @IDcdc";

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDannoScolastico", IDannoScolastico);
                    cmd.Parameters.AddWithValue("@IDcdc", IDCdC);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        ore = Convert.ToInt32(result);
                }
            }
            return ore;
        }

        /// <summary>
        /// Calcola le ore residue = ore previste - ore già assegnate
        /// </summary>
        public static int OreResidueCDC(ClsClasseDiConcorsoDL cdc,ClsAnnoScolasticoDL annoScolastico)
        {
            try
            {
                int oreTeoria = OreTeoriaLaboratorio(cdc, annoScolastico);
                int oreAssegnate = OreTotaleAssegnate(cdc.ID, annoScolastico.ID);
                return oreTeoria - oreAssegnate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
