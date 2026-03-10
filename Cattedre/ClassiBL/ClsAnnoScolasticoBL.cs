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
            ClsAnnoScolasticoDL anno = new ClsAnnoScolasticoDL();
            DataTable dt = new DataTable();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
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
                        anno.ID = Convert.ToInt64(row["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return anno.ID;
        }

        public static ClsAnnoScolasticoDL TrovaAnnoSuccessivo(long IDanno)
        {
            List<ClsAnnoScolasticoDL> anni = CaricaAnniScolastici();

            return anni
                .Where(a => a.ID > IDanno)
                .OrderBy(a => a.ID)
                .FirstOrDefault();
        }

        public static ClsAnnoScolasticoDL CercaAnnoScolastico(string sigla)
        {
            ClsAnnoScolasticoDL anno = new ClsAnnoScolasticoDL();
            DataTable dt = new DataTable();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM anniscolastici
                                   WHERE sigla = @sigla";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sigla", sigla);

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
        public static List<ClsAnnoScolasticoDL> CaricaAnniScolastici()
        {
            List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM anniscolastici";
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

        public static List<ClsAnnoScolasticoDL> InserisciAnnoScolastico(ClsAnnoScolasticoDL anno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();

            try
            {
                conn.Open();
                string sql = "INSERT INTO anniscolastici (sigla, datainizio, datafine) VALUES (@sigla, @datainizio, @datafine)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@sigla", anno.Sigla);
                    cmd.Parameters.AddWithValue("@datainizio", anno.DataInizio);
                    cmd.Parameters.AddWithValue("@datafine", anno.DataFine);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        anniScolastici.Add(anno);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return anniScolastici;
        }

        public static List<ClsAnnoScolasticoDL> ModificaAnnoScolastico(ClsAnnoScolasticoDL anno, int indice)
        {
            FrmAnnoScolastico frmAnnoScolastico = new FrmAnnoScolastico();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsAnnoScolasticoDL> anni = new List<ClsAnnoScolasticoDL>();

            try
            {
                conn.Open();
                string sql = @"UPDATE anniscolastici 
                           SET sigla = @sigla, 
                               datainizio = @datainizio, 
                               datafine = @datafine 
                           WHERE id = " + anno.ID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@sigla", anno.Sigla);
                    cmd.Parameters.AddWithValue("@datainizio", anno.DataInizio);
                    cmd.Parameters.AddWithValue("@datafine", anno.DataFine);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        anni[indice] = anno;
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return anni;
        }

        public static List<ClsAnnoScolasticoDL> EliminaAnnoScolastico(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsAnnoScolasticoDL> anni = new List<ClsAnnoScolasticoDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM anniscolastici WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        anni = CaricaAnniScolastici();
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return anni;
        }
    }
}
