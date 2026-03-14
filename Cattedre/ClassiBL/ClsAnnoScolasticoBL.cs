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
       private static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

        public static List<ClsAnnoScolasticoDL> CaricaAnniScolastici()
        {
            List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
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
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID FROM anniscolastici 
                                  WHERE TIMESTAMPDIFF(YEAR,(
                                        SELECT datainizio FROM anniscolastici 
                                        WHERE ID=@ID),datainizio
                                  )=1 LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", IDannoScolastico);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                                IDanno = Convert.ToInt32(dr["ID"]);
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception("Errore durante il rilevamento di annoscolastico successivo:"+ex.Message);
            }
            return IDanno;
        }
        public static string RilevaSiglaAnnoScolastico(long ID)
        {
            string Sigla = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string sql = @"SELECT sigla FROM anniscolastici WHERE id=@ID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                            if (dr.Read())
                                Sigla = dr["sigla"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Sigla;
        }

        public static void InserisciAnnoScolastico(ClsAnnoScolasticoDL anno)
        {
            List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO anniscolastici (sigla, datainizio, datafine) VALUES (@sigla, @datainizio, @datafine)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    {
                        cmd.Parameters.AddWithValue("@sigla", anno.Sigla);
                        cmd.Parameters.AddWithValue("@datainizio", anno.DataInizio);
                        cmd.Parameters.AddWithValue("@datafine", anno.DataFine);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new EvaluateException("errore durante l'inserimento");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void ModificaAnnoScolastico(ClsAnnoScolasticoDL anno)
        {
            FrmAnnoScolastico frmAnnoScolastico = new FrmAnnoScolastico();
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"UPDATE anniscolastici 
                           SET sigla = @sigla, 
                               datainizio = @datainizio, 
                               datafine = @datafine 
                           WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@sigla", anno.Sigla);
                    cmd.Parameters.AddWithValue("@datainizio", anno.DataInizio);
                    cmd.Parameters.AddWithValue("@datafine", anno.DataFine);
                    cmd.Parameters.AddWithValue("@ID", anno.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if (righeCoinvolte <= 0)
                        throw new EvaluateException("errore durante la modifica");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminaAnnoScolastico(long id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM anniscolastici WHERE id =@ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new EvaluateException("errore durante la modifica");
                    }
                }  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
