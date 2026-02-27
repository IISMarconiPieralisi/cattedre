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

        public static List<ClsDotareDL> CaricaDotare(long idAnnoScolastico, long idCdc)
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
                               AND IDclassedicondorso = @idCdc
                               ORDER BY IDannoScolastico";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnnoScolastico", idAnnoScolastico);
                        cmd.Parameters.AddWithValue("@idCdc", idCdc);

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
                    dot.Numcattedrefatto = Convert.ToInt32(row["numcattedrefatto"]);
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

        public static void InserisciDotare(ClsDotareDL d)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO dotare
                               (IDannoScolastico, IDdipartimento, NumCattedreFatto, NumCattedreDiritto)
                               VALUES (@anno, @dip, @fatto, @diritto)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@anno", d.IDannoscolastico);
                        cmd.Parameters.AddWithValue("@dip", d.IDdipartimento);
                        cmd.Parameters.AddWithValue("@fatto", d.NumCattedreFatto);
                        cmd.Parameters.AddWithValue("@diritto", d.NumCattedreDiritto);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void EliminaDotare(long idAnnoScolatisco,long idDipartimento)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM dotare WHERE IDannoScolatisco = @idAnnoScolatisco AND IDdipartimento =@idDipartimento";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnnoScolatisco", idAnnoScolatisco);
                        cmd.Parameters.AddWithValue("@idDipartimento", idDipartimento);
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



        public static void ModificaDotazioni(long idDipartimento, List<ClsDotareDL> nuove)
        {
            try
            {
                List<ClsDotareDL> vecchie = CaricaDotare(idDipartimento);

                // Elimina quelle rimosse
                foreach (ClsDotareDL old in vecchie)
                {
                    if (!nuove.Any(n => n.IDannoscolastico == old.IDannoscolastico))
                        EliminaDotare(old.IDannoscolastico, old.IDdipartimento);
                }

                // Aggiunge quelle nuove
                foreach (ClsDotareDL n in nuove)
                {
                    if (!vecchie.Any(v => v.IDannoscolastico == n.IDannoscolastico))
                        InserisciDotare(n);
                }
            }catch(Exception  ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


    }
}
