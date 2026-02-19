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
    class ClsDotareBL
    {

       public static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

        public static List<ClsDotareDL> CaricaDotare(long idDipartimento)
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
                               WHERE IDdipartimento = @dip
                               ORDER BY IDannoScolastico";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@dip", idDipartimento);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new ClsDotareDL
                    {
                        ID = Convert.ToInt64(row["ID"]),
                        IDannoScolastico = Convert.ToInt64(row["IDannoScolastico"]),
                        IDdipartimento = Convert.ToInt64(row["IDdipartimento"]),
                        NumCattedreFatto = Convert.ToInt64(row["NumCattedreFatto"]),
                        NumCattedreDiritto = Convert.ToInt64(row["NumCattedreDiritto"])
                    });
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
                        cmd.Parameters.AddWithValue("@anno", d.IDannoScolastico);
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


        public static void EliminaDotare(long idDotare)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM dotare WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idDotare);

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
                        DataInizio = Convert.ToDateTime(row["DataInizio"]) // ⬅ CAMPO AGGIORNATO
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore caricamento anni scolastici associati.", ex);
            }

            return anni;
        }



        public static void ModificaDotazioni(long idDipartimento, List<ClsDotareDL> nuove)
        {
            List<ClsDotareDL> vecchie = CaricaDotare(idDipartimento);

            // Elimina quelle rimosse
            foreach (var old in vecchie)
            {
                if (!nuove.Any(n => n.IDannoScolastico == old.IDannoScolastico))
                    EliminaDotare(old.ID);
            }

            // Aggiunge quelle nuove
            foreach (var n in nuove)
            {
                if (!vecchie.Any(v => v.IDannoScolastico == n.IDannoScolastico))
                    InserisciDotare(n);
            }
        }


    }
}
