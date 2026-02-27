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
    public class ClsDotareBL
    {

       public static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

        public static int TrovaNumCattedreDiDiritto(long idCdc)
        {
            int cattedre = 0;
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT numcattedrediritto
                               FROM dotare
                               WHERE IDclassediconcorso = @IDclassediconcorso";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDclassediconcorso", idCdc);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                            if (dt.Rows.Count > 0 && dt.Rows[0]["numcattedrediritto"] != DBNull.Value)
                            {
                                cattedre = Convert.ToInt32(dt.Rows[0]["numcattedrediritto"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore. ", ex);
            }
            return cattedre;
        }

        public static int TrovaNumCattedreDiFatto(long idCdc)
        {
            int cattedre = 0;
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT numcattedrefatto
                               FROM dotare
                               WHERE IDclassediconcorso = @IDclassediconcorso";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDclassediconcorso", idCdc);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                            if (dt.Rows.Count > 0 && dt.Rows[0]["numcattedrefatto"] != DBNull.Value)
                            {
                                cattedre = Convert.ToInt32(dt.Rows[0]["numcattedrefatto"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore. ", ex);
            }
            return cattedre;
        }

        public static List<ClsDotareDL> CaricaDotare(long idAnnoScolastico)
        {
            List<ClsDotareDL> lista = new List<ClsDotareDL>();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT *
                               FROM dotare
                               WHERE IDannoscolastico = @idAnnoScolastico
                               ORDER BY IDannoScolastico";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnnoScolastico", idAnnoScolastico);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    ClsDotareDL dot = new ClsDotareDL();
                    dot.Id = Convert.ToInt64(row["ID"]);
                    dot.NumcattedreDiritto = Convert.ToInt32(row["numcattedrediritto"]);
                    dot.NumcattedreFatto = Convert.ToInt32(row["numcattedrefatto"]);
                    dot.IdAnnoscolastico = Convert.ToInt64(row["IDannoscolastico"]);
                    dot.IdClasseDiConcorso = Convert.ToInt64(row["IDclassediconcorso"]);
                    lista.Add(dot);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel caricamento DOTARE.", ex);
            }

            return lista;
        }

        public static void InserisciDotare(ClsDotareDL d, long idCdc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO dotare
                               (IDannoscolastico, IDclassediconcorso, numcattedrefatto, numcattedrediritto)
                               VALUES (@anno, @cdc, @fatto, @diritto)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@anno", 1);
                        cmd.Parameters.AddWithValue("@cdc", idCdc);
                        cmd.Parameters.AddWithValue("@fatto", d.NumcattedreFatto);
                        cmd.Parameters.AddWithValue("@diritto", d.NumcattedreDiritto);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void EliminaDotare(long idAnnoScolatisco,long idCdc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM dotare WHERE IDannoscolastico = @idAnnoScolatisco AND Idclassediconcorso = @idDipartimento";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnnoScolatisco", idAnnoScolatisco);
                        cmd.Parameters.AddWithValue("@idDipartimento", idCdc);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static List<ClsAnnoScolasticoDL> AnniScolasticiAssociati(long idDip)
        {
            List<ClsAnnoScolasticoDL> anni = new List<ClsAnnoScolasticoDL>();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT a.ID, a.DataInizio
                               FROM anniscolastici a
                               INNER JOIN dotare d ON a.ID = d.IDannoScolastico
                               WHERE d.IDdipartimento = @dip";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@dip", idDip);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    anni.Add(new ClsAnnoScolasticoDL
                    {
                        ID = Convert.ToInt64(row["ID"]),
                        DataInizio = Convert.ToDateTime(row["DataInizio"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return anni;
        }



        public static void AggiornaDotare(ClsDotareDL dot)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["cattedre"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string updateSql = @"
            UPDATE dotare
            SET numcattedrediritto = @cattedreDiritto,
                numcattedrefatto = @cattedreFatto
            WHERE IDclassediconcorso = @IDclasseDiConcorso;";

                using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDclasseDiConcorso", dot.IdClasseDiConcorso);
                    cmd.Parameters.AddWithValue("@cattedreDiritto", dot.NumcattedreDiritto);
                    cmd.Parameters.AddWithValue("@cattedreFatto", dot.NumcattedreFatto);

                    int righe = cmd.ExecuteNonQuery();
                    if (righe <= 0)
                        throw new DataException("Aggiornamento Dotare fallito");
                }
            }
        }


    }
}
