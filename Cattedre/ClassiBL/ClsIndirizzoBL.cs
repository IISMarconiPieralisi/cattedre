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
    public static class ClsIndirizzoBL
    {
        public static long RilevaIDindirizzo(string nome)
        {
            long ID = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID FROM indirizzi WHERE nome = @nome";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            ID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento dell'ID indirizzo: " + ex.Message);
            }
            return ID;
        }

        public static string RilevaNomeIndirizzo(long id)
        {
            string nome = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT nome FROM indirizzi WHERE ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0 && !string.IsNullOrWhiteSpace(dt.Rows[0]["nome"].ToString()))
                            nome = dt.Rows[0]["nome"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento del nome indirizzo: " + ex.Message);
            }
            return nome;
        }

        public static List<ClsIndirizzoDL> CaricaIndirizzi()
        {
            
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID,nome FROM indirizzi";
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
                   
                        ClsIndirizzoDL indirizzo = new ClsIndirizzoDL();
                        indirizzo.ID = Convert.ToInt64(row["id"]);
                        indirizzo.Nome = row["nome"].ToString();
                        indirizzi.Add(indirizzo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return indirizzi;
        }

        public static void InserisciIndirizzo(ClsIndirizzoDL indirizzo)
        {
            
            MySqlConnection conn = new MySqlConnection(Program.connectionString);
            try
            {
                conn.Open();
                string sql = "INSERT INTO indirizzi (nome) VALUES ( @nome )";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", indirizzo.Nome);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte <= 0)
                        throw new Exception("errore nel inserimento");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void ModificaIndirizzo(ClsIndirizzoDL indirizzo)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE indirizzi SET nome = @nome WHERE id = @id ";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", indirizzo.ID);
                        cmd.Parameters.AddWithValue("@nome", indirizzo.Nome);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new Exception("errore nel modifica");
                    }
                    conn.Close();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void EliminaIndirizzo(long id)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"DELETE FROM indirizzi WHERE ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte <= 0)
                            throw new Exception("errore nel cancellamento");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<ClsIndirizzoDL> RicercaPerNome(string _ricerca)
        {
            
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
            DataTable dt = new DataTable();
            _ricerca = $"%{_ricerca}%";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ID,nome
                                 FROM indirizzi 
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

                        ClsIndirizzoDL indirizzo = new ClsIndirizzoDL();
                        indirizzo.ID = Convert.ToInt64(row["id"]);
                        indirizzo.Nome = row["nome"].ToString();
                        indirizzi.Add(indirizzo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return indirizzi;
        }
    }
}