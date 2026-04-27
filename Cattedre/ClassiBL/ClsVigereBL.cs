using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;


namespace Cattedre
{
    public static class ClsVigereBL
    {
        #region rilevamento vigere da disciplina
       public static ClsVigereDL RilevaVigereDisciplina(long IDdisciplina)
        {
            ClsVigereDL vigere = new ClsVigereDL();
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM vigere WHERE IDdisciplina=@IDdisciplina LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    vigere.IDdisciplina = IDdisciplina;
                    vigere.IDannoInizio = Convert.ToInt32(row["IDannoinizio"]);
                    vigere.IDannoFine =(row["IDannofine"]==DBNull.Value)?0: Convert.ToInt32(row["IDannofine"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return vigere;
        }
        #endregion
        #region Rileva vigere da anno
        public static List<ClsDisciplinaDL> RilevaDisciplineAnnoScolastico (long IDannoScolastico)
        {
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.nome,d.anno, d.oreteoria, d.orelaboratorio, d.disciplinaspeciale, d.IDdisciplinaSuccessiva 
                                   FROM vigere v
                                   JOIN disciplina d ON v.IDdisciplina = d.ID
                                   JOIN annoscolastico aInizio ON v.IDannoInizio = aInizio.ID
                                   JOIN annoscolastico aFine   ON v.IDannoFine   = aFine.ID
                                   JOIN annoscolastico aTarget ON aTarget.ID = @IDannoScolastico
                                   WHERE aTarget.dataInizio >= aInizio.dataInizio
                                     AND aTarget.dataFine   <= aFine.dataFine";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
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
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return discipline;
        }
        #endregion
        #region crud
        public static List<ClsVigereDL> CaricaVigere()
        {
            List< ClsVigereDL> vigeres = new List<ClsVigereDL>();
            MySqlConnection conn = new MySqlConnection(Program.connectionString);
            DataTable ds = new DataTable();
            List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
            try
            {
                conn.Open();
                string sql = "SELECT IDdisciplina, IDannoinizio, IDannofine FROM vigere ";

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
                    ClsVigereDL vigere = new ClsVigereDL();
                    vigere.IDdisciplina = Convert.ToInt32(row["IDdisciplina"]);
                    vigere.IDannoInizio = Convert.ToInt32(row["IDannoinizio"]);
                    vigere.IDannoFine = (row["IDannofine"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDannofine"]);
                    vigeres.Add(vigere);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return vigeres;
        }
        public static void InserisciVigere(ClsVigereDL vigere)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO utenti (IDdisciplina, IDannoinizio, IDannofine)
                                 VALUES (@IDdisciplina, @IDannoinizio, @IDannofine)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", vigere.IDdisciplina);
                        cmd.Parameters.AddWithValue("@IDannoinizio", vigere.IDannoInizio);
                        if (vigere.IDannoFine <= 0) cmd.Parameters.AddWithValue("@IDannofine", DBNull.Value);
                        else cmd.Parameters.AddWithValue("@IDannofine", vigere.IDannoFine);
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
        public static void ModificaVigere(ClsVigereDL vigere)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE vigere 
                           SET IDdataInizio = @IDdataInizio, 
                               IDannofine = @IDannofine, 
                           WHERE IDdisciplina = @IDdisciplina";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDannoinizio", vigere.IDannoInizio);
                        if (vigere.IDannoFine <= 0) cmd.Parameters.AddWithValue("@IDannofine", DBNull.Value);
                        else cmd.Parameters.AddWithValue("@IDannofine", vigere.IDannoFine);
                        cmd.Parameters.AddWithValue("@IDdisciplina", vigere.IDdisciplina);

                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new InvalidOperationException("No rows were inserted.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void EliminaVigere(long IDdisciplina)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"DELETE FROM vigere WHERE IDdisciplina = @IDdisciplina";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
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

    }
}
