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
        public static List<ClsClasseDiConcorsoDL> CaricaCdcs()
        {

            
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.connectionString);
                conn.Open();
                string sql = "SELECT * FROM classidiconcorso";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
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
        #region ricerca/filtra
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
        public static List<ClsClasseDiConcorsoDL> CaricaCDCperDipartimento(long IDdiparitimento)
        {
            DataTable dt = new DataTable();
            List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.connectionString);
                conn.Open();
                string sql = @"SELECT DISTINCT * FROM classidiconcorso c
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
        public static int OreResidueCDC (long IDCdC,long IDannoScolastico)
        {
            int OreResidue = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    string sql = @"SELECT
                                   ( 
                                            SELECT
                                            CASE 
                                                WHEN cdc.livello LIKE 'A%' THEN SUM(d.oreTeoria + d.oreLaboratorio)
                                                WHEN cdc.livello LIKE 'B%' THEN SUM(d.oreLaboratorio)
                                            ELSE 0
                                            END                                            
                                            FROM classi c 
                                            JOIN indirizzi i ON c.IDindirizzo=i.ID
                                            JOIN appartenere a ON i.ID=a.IDindirizzo
                                            JOIN discipline d ON a.IDdisciplina = d.ID
                                            JOIN richiedere r ON r.IDdisciplina = a.IDdisciplina
                                            JOIN  classidiconcorso cdc ON  r.IDclasseDiConcorso=cdc.ID
                                            WHERE c.IDannoScolastico=@IDannoScolastico AND cdc.ID=@IDcdc
                                    )
                                    -
                                    ( 
                                            SELECT SUM(
                                                CASE 
                                                    WHEN u.tipoDocente = 'T'  THEN d.oreTeoria
                                                    WHEN u.tipoDocente = 'L' THEN d.oreLaboratorio
                                                ELSE d.oreTeoria + d.oreLaboratorio
                                                END 
                                                      )
                                            FROM utenti u
                                            JOIN richiedere r ON u.ID= r.IDutente
                                            JOIN assegnare  a ON u.ID = a.IDutente
                                            JOIN discipline  d ON a.IDdisciplina = d.ID
                                            WHERE a.IDannoScolastico = @IDannoScolastico AND r.IDclasseDiConcorso=@IDcdc
                                            )";
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDannoScolastico", IDannoScolastico);
                        cmd.Parameters.AddWithValue("@IDcdc", IDCdC);
                        DataTable dt = new DataTable();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            OreResidue = Convert.ToInt32(result);
                    }
               }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OreResidue;
        }

    }
}
