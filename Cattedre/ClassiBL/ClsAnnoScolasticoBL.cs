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
        public static List<ClsAnnoScolasticoDL> CaricaAnniScolastici()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM anniscolastici";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsAnnoScolasticoDL annoScolastico = new ClsAnnoScolasticoDL();
                        annoScolastico.ID = Convert.ToInt64(dr["id"]);
                        annoScolastico.Sigla = dr["sigla"].ToString();
                        annoScolastico.DataInizio = (DateTime)dr["datainizio"];
                        annoScolastico.DataFine = (DateTime)dr["datafine"];
                        anniScolastici.Add(annoScolastico);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            return anniScolastici;

            //conn.Open();
            //string sql = "SELECT * FROM anniscolastici";
            //DataAdapter, DataSet e DataTable su dispensa ADO.Net
            //MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            //Cache dati in memoria, oggetto disconnesso
            //DataSet ds = new DataSet("cattadre");
            //da.Fill(ds, "cattedre");

            // Scorro i Record del DataTable per creare la lista
            //DataTable dt = ds.Tables["anniscolastici"];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    // Potrei scrivere anche su una sola riga ma così è più leggibile
            //    ClsAnnoScolasticoDL _annoscolastico = new ClsAnnoScolasticoDL(
            //        (int)dt.Rows[i]["id"],
            //        dt.Rows[i]["sigla"].ToString(),
            //        dt.Rows[i]["datainizio"].ToString(),
            //        dt.Rows[i]["datafine"].ToString());
            //    anniScolastici.Add(_annoscolastico);
            //}
            //conn.Close();

            // TODO: QUI VIENE RICHIAMATO IL METODO PER POPOLARE LA LISTVIEW
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
                string errore = ex.Message;
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
