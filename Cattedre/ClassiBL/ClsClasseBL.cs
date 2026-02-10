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
    public static class ClsClasseBL
    {
        public static long _IDutente;
        public static long _IDindirizzo;
        public static long _IDclasseArticolataCon;
        public static List<long> IDutenti = new List<long>();
        public static List<long> IDindirizzi = new List<long>();
        public static List<long> IDclassiArticolateCon = new List<long>();

        public static string RilevaSiglaClasse(long id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsClasseDL classe = null;
            try
            {
                conn.Open();
                string sql = "SELECT sigla " +
                             "FROM classi " +
                             "WHERE ID = " + id;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    classe = new ClsClasseDL();
                    classe.Sigla = dr["sigla"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            if (classe != null)
                return classe.Sigla;
            else
                return "-";
        }

        public static long RilevaIDclasse(string sigla)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsClasseDL classe = null;
            try
            {
                conn.Open();
                string sql = "SELECT ID " +
                             "FROM classi " +
                             "WHERE sigla = '" + sigla + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    classe = new ClsClasseDL();
                    classe.ID = Convert.ToInt64(dr["ID"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            if (classe != null)
                return classe.ID;
            else
                return 0;
        }

        public static List<ClsClasseDL> CaricaClassiDipartimento(int IDdipartimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classi = new List<ClsClasseDL>();

            conn.Open();
            string sql = "SELECT * FROM classi";
            //DataAdapter, DataSet e DataTable su dispensa ADO.Net
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            //Cache dati in memoria, oggetto disconnesso
            DataSet ds = new DataSet("cattedre");
            da.Fill(ds, "cattedre");

            //Scorro i Record del DataTable per creare la lista
            DataTable dt = ds.Tables["classi"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Potrei scrivere anche su una sola riga ma così è più leggibile
                ClsClasseDL _classe = new ClsClasseDL(
                    (int)dt.Rows[i]["id"],
                    dt.Rows[i]["sigla"].ToString(),
                    (int)dt.Rows[i]["anno"],
                    dt.Rows[i]["sezione"].ToString(),
                    (int)dt.Rows[i]["classeArticolataCon"],
                    (int)dt.Rows[i]["IDutente"],
                    (int)dt.Rows[i]["IDindirizzo"]);
                classi.Add(_classe);
            }
            conn.Close();

            return classi;
        }

        public static List<ClsClasseDL> CaricaClassi()
        {
            IDutenti.Clear();
            IDindirizzi.Clear();
            IDclassiArticolateCon.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM classi " +
                             "ORDER BY anno";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsClasseDL classe = new ClsClasseDL();
                        classe.ID = Convert.ToInt64(dr["ID"]);
                        classe.Sigla = dr["sigla"].ToString();
                        classe.Anno = Convert.ToInt32(dr["anno"]);
                        classe.Sezione = dr["sezione"].ToString();
                        _IDclasseArticolataCon = dr.IsDBNull(dr.GetOrdinal("classeArticolataCon"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("classeArticolataCon"));
                        _IDutente = dr.IsDBNull(dr.GetOrdinal("IDutente"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("IDutente"));
                        _IDindirizzo = Convert.ToInt64(dr["IDindirizzo"]);

                        classi.Add(classe);
                        IDutenti.Add(_IDutente);
                        IDindirizzi.Add(_IDindirizzo);
                        IDclassiArticolateCon.Add(_IDclasseArticolataCon);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            return classi;
        }

        public static List<ClsClasseDL> CaricaClassiFiltrate(int anno)
        {
            IDutenti.Clear();
            IDindirizzi.Clear();
            IDclassiArticolateCon.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classi = new List<ClsClasseDL>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM classi " +
                             "WHERE anno = " + anno +
                             " ORDER BY anno";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsClasseDL classe = new ClsClasseDL();
                        classe.ID = Convert.ToInt64(dr["ID"]);
                        classe.Sigla = dr["sigla"].ToString();
                        classe.Anno = Convert.ToInt32(dr["anno"]);
                        classe.Sezione = dr["sezione"].ToString();
                        _IDclasseArticolataCon = dr.IsDBNull(dr.GetOrdinal("classeArticolataCon"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("classeArticolataCon"));
                        _IDutente = dr.IsDBNull(dr.GetOrdinal("IDutente"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("IDutente"));
                        _IDindirizzo = Convert.ToInt64(dr["IDindirizzo"]);

                        classi.Add(classe);
                        IDutenti.Add(_IDutente);
                        IDindirizzi.Add(_IDindirizzo);
                        IDclassiArticolateCon.Add(_IDclasseArticolataCon);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            return classi;
        }

        public static List<ClsClasseDL> InserisciClasse(ClsClasseDL classe, long IDutente, long IDindirizzo, long IDclasseArticolataCon)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classi = new List<ClsClasseDL>();

            try
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM classi WHERE IDutente = @IDutente AND IDindirizzo = @IDindirizzo AND classeArticolataCon = @classeArticolataCon";
                using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@IDutente", IDutente);
                    checkCmd.Parameters.AddWithValue("@IDindirizzo", IDindirizzo);
                    checkCmd.Parameters.AddWithValue("@classeArticolataCon", IDclasseArticolataCon);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        string sql = "";
                        if (classe.ClasseArticolataCon == "")
                        {
                           sql = "INSERT INTO classi (sigla, anno, sezione, classeArticolataCon, IDutente, IDindirizzo) VALUES (@sigla, @anno, @sezione, NULL, @IDutente, @IDindirizzo)";
                        }
                        else
                        {
                            sql = "INSERT INTO classi (sigla, anno, sezione, classeArticolataCon, IDutente, IDindirizzo) VALUES (@sigla, @anno, @sezione, @classeArticolataCon, @IDutente, @IDindirizzo)";
                        }
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        {
                            cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                            cmd.Parameters.AddWithValue("@anno", classe.Anno);
                            cmd.Parameters.AddWithValue("@sezione", classe.Sezione);
                            cmd.Parameters.AddWithValue("@classeArticolataCon", IDclasseArticolataCon);
                            cmd.Parameters.AddWithValue("@IDutente", IDutente);
                            cmd.Parameters.AddWithValue("@IDindirizzo", IDindirizzo);
                            int righeCoinvolte = cmd.ExecuteNonQuery();

                            if (righeCoinvolte > 0)
                            {
                                classi.Add(classe);
                                IDutenti.Add(IDutente);
                                IDindirizzi.Add(IDindirizzo);
                                IDclassiArticolateCon.Add(IDclasseArticolataCon);
                            }
                        }
                    }
                    else
                        throw new Exception("Questo utente è già coordinatore di un'altra classe.");
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return classi;
        }

        public static List<ClsClasseDL> ModificaClasse(ClsClasseDL classe, int indice, long IDutente, long IDindirizzo, long IDclasseArticolataCon)
        {
            FrmClasse frmClasse = new FrmClasse(indice, indice, indice);
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classi = new List<ClsClasseDL>();

            try
            {
                conn.Open();
                string sql = @"UPDATE classi 
                           SET sigla = @sigla, 
                               anno = @anno, 
                               sezione = @sezione, 
                               classeArticolataCon = @classeArticolataCon,
                               IDutente = @IDutente,
                               IDindirizzo = @IDindirizzo 
                           WHERE id = " + classe.ID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@sigla", classe.Anno.ToString() + classe.Sezione);
                    cmd.Parameters.AddWithValue("@anno", classe.Anno);
                    cmd.Parameters.AddWithValue("@sezione", classe.Sezione);
                    cmd.Parameters.AddWithValue("@classeArticolataCon", IDclasseArticolataCon);
                    cmd.Parameters.AddWithValue("@IDutente", IDutente);
                    cmd.Parameters.AddWithValue("@IDindirizzo", IDindirizzo);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        classi[indice] = frmClasse._classe;
                        IDutenti[indice] = IDutente;
                        IDindirizzi[indice] = IDindirizzo;
                        IDclassiArticolateCon[indice] = IDclasseArticolataCon;
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return classi;
        }

        public static List<ClsClasseDL> EliminaClasse(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classi = new List<ClsClasseDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM classi WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        classi = CaricaClassi();
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return classi;
        }
    }
}
