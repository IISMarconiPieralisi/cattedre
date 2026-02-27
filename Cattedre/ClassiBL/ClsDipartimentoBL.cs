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
   public static class ClsDipartimentoBL
   {

        public static List<ClsDipartimentoDL> CaricaDipartimenti()
         {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            DataTable ds = new DataTable();
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT ID, nome, IDutente FROM dipartimenti";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                        conn.Close();
                    }
                }
                    foreach (DataRow row in ds.Rows)
                    {
                        ClsDipartimentoDL dipartimento = new ClsDipartimentoDL();
                        dipartimento.ID = Convert.ToInt64(row["id"]);
                        dipartimento.Nome = row["nome"].ToString();
                        dipartimento.IDutente = (row["IDutente"]==DBNull.Value)? 0: Convert.ToInt64(row["IDutente"]);
                        dipartimenti.Add(dipartimento);
                    }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dipartimenti;
         }

        public static void InserisciDipartimento(ClsDipartimentoDL dip)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO dipartimenti (nome, IDutente) VALUES (@nome, @IDutente)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", dip.Nome);
                        if (dip.IDutente > 0)
                            cmd.Parameters.AddWithValue("@IDutente", dip.IDutente);
                        else
                            cmd.Parameters.AddWithValue("@IDutente", DBNull.Value);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte == 0)
                            throw new Exception("Inserimento non riuscito.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void EliminaDipartimento(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM dipartimenti WHERE id =@id ";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int righeCoinvolte = cmd.ExecuteNonQuery();

                        if (righeCoinvolte < 0)
                            throw new Exception("non è stato eliminato nessun record");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ModificaDipartimento(ClsDipartimentoDL dipartimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"UPDATE dipartimenti 
                           SET nome = @nome, 
                               IDutente = @IDutente 
                           WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", dipartimento.Nome);
                    cmd.Parameters.AddWithValue("@IDutente", dipartimento.IDutente);
                    cmd.Parameters.AddWithValue("id", dipartimento.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if (righeCoinvolte < 0)
                        throw new Exception("non è stato modificato nessun record");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool ModificaCoordinatoreDipartimento(ClsDipartimentoDL dipartimento, long IDutente)
        {
            if (dipartimento == null || dipartimento.ID <= 0)
                return false;

            string connectionString = ConfigurationManager
                .ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE dipartimenti
                           SET IDutente = @IDutente
                           WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);
                        cmd.Parameters.AddWithValue("@id", dipartimento.ID);

                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        return righeCoinvolte > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ClsDipartimentoDL UtenteCoordinaDipartimento(long IDutente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsDipartimentoDL dipartimento = null;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dipartimenti WHERE IDutente = @IDutente";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDutente", IDutente);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        dipartimento = new ClsDipartimentoDL();
                        dipartimento.ID = Convert.ToInt64(dr["id"]);
                        dipartimento.Nome = dr["nome"].ToString();
                        dipartimento.IDutente = dr.IsDBNull(dr.GetOrdinal("IDutente"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("IDutente"));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dipartimento;
        }
        public static ClsUtenteDL utenteCoordinaDiparimento(string NomeDipartimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            ClsUtenteDL utente = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = @"SELECT u.* 
                               FROM utenti u
                               JOIN dipartimenti d ON u.id = d.IDutente
                               WHERE d.nome = @NomeDipartimento";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@NomeDipartimento", NomeDipartimento);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            utente = new ClsUtenteDL();
                            utente.ID = Convert.ToInt64(dr["id"]);
                            utente.Cognome = dr["cognome"].ToString();
                            utente.Nome = dr["nome"].ToString();
                            utente.Email = dr["email"].ToString();
                            utente.TipoUtente = dr["tipoUtente"].ToString();
                            utente.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return utente;

        }
        public static void EliminaCoordinatoreDipartimento (long IDutente)
        {
            ClsDipartimentoDL dipartimentoCoordinato = UtenteCoordinaDipartimento(IDutente);
            if (dipartimentoCoordinato == null)
                return;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE dipartimenti
                           SET IDutente = NULL
                           WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", dipartimentoCoordinato.ID);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
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
