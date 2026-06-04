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
    public static class ClsAnnoScolasticoBL
    {
        public static long TrovaIDannoscolastico()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID FROM anniscolastici 
                           WHERE CURDATE() BETWEEN datainizio AND datafine 
                           LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        conn.Close();
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        return Convert.ToInt64(row["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;
        }

        public static ClsAnnoScolasticoDL TrovaAnnoSuccessivo(long IDanno)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM anniscolastici
                                WHERE YEAR(datainizio) = (
                                SELECT YEAR(datainizio) FROM anniscolastici WHERE ID = @IDanno
                                ) +1
                                AND YEAR(datafine) = (
                                SELECT YEAR(datafine) FROM anniscolastici WHERE ID = @IDanno
                                ) +1
                                LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDanno", IDanno);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                DataRow row = dt.Rows[0];
                                return new ClsAnnoScolasticoDL
                                {
                                    ID = Convert.ToInt64(row["ID"]),
                                    DataInizio = Convert.ToDateTime(row["datainizio"]),
                                    DataFine = Convert.ToDateTime(row["datafine"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public static ClsAnnoScolasticoDL CercaAnnoScolastico(long ID)
        {
            ClsAnnoScolasticoDL anno = new ClsAnnoScolasticoDL();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM anniscolastici
                                   WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        conn.Close();
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        anno.ID = Convert.ToInt64(row["ID"]);
                        anno.Sigla = row["sigla"].ToString();
                        anno.DataInizio = Convert.ToDateTime(row["datainizio"]);
                        anno.DataFine = Convert.ToDateTime(row["datafine"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return anno;
        }
        //public static ClsAnnoScolasticoDL CercaAnnoScolastico(long  sigla)
        //{
        //    ClsAnnoScolasticoDL anno = new ClsAnnoScolasticoDL();
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
        //        {
        //            conn.Open();
        //            string sql = @"SELECT * FROM anniscolastici
        //                           WHERE sigla = @sigla";
        //            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@sigla", sigla);

        //                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
        //                {
        //                    da.Fill(dt);
        //                }
        //                conn.Close();
        //            }
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                anno.ID = Convert.ToInt64(row["ID"]);
        //                anno.Sigla = row["sigla"].ToString();
        //                anno.DataInizio = Convert.ToDateTime(row["datainizio"]);
        //                anno.DataFine = Convert.ToDateTime(row["datafine"]);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return anno;
        //}
        public static List<ClsAnnoScolasticoDL> CaricaAnniScolastici()
        {
            List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT id,sigla,datainizio,datafine FROM anniscolastici ORDER BY sigla DESC";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
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
                    ClsAnnoScolasticoDL _annoscolastico = new ClsAnnoScolasticoDL();
                    _annoscolastico.ID = Convert.ToInt64(row["id"]);
                    _annoscolastico.Sigla = row["sigla"].ToString();
                    _annoscolastico.DataInizio = Convert.ToDateTime(row["datainizio"]);
                    _annoscolastico.DataFine = Convert.ToDateTime(row["datafine"]);
                    anniScolastici.Add(_annoscolastico);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return anniScolastici;
        }
        public static long RilevaIDAnnoSuccessivo(long IDannoScolastico)
        {
            if (IDannoScolastico <= 0) return 0;

            long IDanno = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID FROM anniscolastici 
                    WHERE datainizio > (
                        SELECT datainizio FROM anniscolastici WHERE ID = @ID
                    )
                    ORDER BY datainizio ASC
                    LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", IDannoScolastico);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            IDanno = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento dell'anno scolastico successivo: " + ex.Message);
            }
            return IDanno;
        }

        public static long RilevaIDanno(string sigla)
        {
            long IDanno = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID FROM anniscolastici 
                          WHERE sigla = @sigla";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", sigla);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            IDanno = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento dell'anno scolastico: " + ex.Message);
            }
            return IDanno;
        }

        public static string RilevaSiglaAnnoScolastico(long ID)
        {
            string Sigla = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT sigla FROM anniscolastici WHERE id=@ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            Sigla = dt.Rows[0]["sigla"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento della sigla: " + ex.Message);
            }
            return Sigla;
        }

        public static void InserisciAnnoScolastico(ClsAnnoScolasticoDL anno)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO anniscolastici (sigla, datainizio, datafine) VALUES (@sigla, @datainizio, @datafine)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", anno.Sigla);
                        cmd.Parameters.AddWithValue("@datainizio", anno.DataInizio);
                        cmd.Parameters.AddWithValue("@datafine", anno.DataFine);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new EvaluateException("Errore durante l'inserimento.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'inserimento dell'anno scolastico: " + ex.Message);
            }
        }

        public static void ModificaAnnoScolastico(ClsAnnoScolasticoDL anno)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE anniscolastici 
                           SET sigla      = @sigla, 
                               datainizio = @datainizio, 
                               datafine   = @datafine 
                           WHERE id = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", anno.Sigla);
                        cmd.Parameters.AddWithValue("@datainizio", anno.DataInizio);
                        cmd.Parameters.AddWithValue("@datafine", anno.DataFine);
                        cmd.Parameters.AddWithValue("@ID", anno.ID);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new EvaluateException("Errore durante la modifica.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la modifica dell'anno scolastico: " + ex.Message);
            }
        }

        public static void EliminaAnnoScolastico(long id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM anniscolastici WHERE id = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new EvaluateException("Errore durante l'eliminazione.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'eliminazione dell'anno scolastico: " + ex.Message);
            }
        }
    }
}
