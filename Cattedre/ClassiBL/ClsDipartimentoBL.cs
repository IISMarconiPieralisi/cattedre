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
        static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
        #region crud
        public static List<ClsDipartimentoDL> CaricaDipartimenti()
         {
            
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
            try
            {
                CambiaCoordinatoreDipartimento(dip, dip.IDutente);
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
            
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                CambiaCoordinatoreDipartimento(dipartimento, dipartimento.IDutente);
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
        #endregion
        #region crud specifiche
        public static void CambiaCoordinatoreDipartimento(ClsDipartimentoDL dipartimento,long IDutente)
        {
            ClsDipartimentoDL dipartimentoCordinato = UtenteCoordinaDipartimento(IDutente);
            if (dipartimentoCordinato.ID != dipartimento.ID)
            {
                ModificaCoordinatoreDipartimento(dipartimentoCordinato, 0);
            }
        }



        public static bool ModificaCoordinatoreDipartimento(ClsDipartimentoDL dipartimento, long IDutente)
        {
            if (dipartimento.ID <= 0)
                return false;

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
                        cmd.Parameters.AddWithValue("@IDutente", IDutente <= 0 ? (object)DBNull.Value : IDutente);
                        cmd.Parameters.AddWithValue("@id", dipartimento.ID);

                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        return righeCoinvolte > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Errore database durante la modifica del coordinatore: {ex.Message}", ex);
            }
        }

        public static void EliminaCoordinatoreDipartimento(long IDutente)
        {
            ClsDipartimentoDL dipartimentoCoordinato = UtenteCoordinaDipartimento(IDutente);
            if (dipartimentoCoordinato == null)
                return;

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
        #endregion
        #region rilevamenti specifici

        public static ClsDipartimentoDL UtenteCoordinaDipartimento(long IDutente)
        {
            ClsDipartimentoDL dipartimento = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM dipartimenti WHERE IDutente = @IDutente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDutente", IDutente);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            dipartimento = new ClsDipartimentoDL();
                            dipartimento.ID = Convert.ToInt64(row["id"]);
                            dipartimento.Nome = row["nome"].ToString();
                            dipartimento.IDutente = row["IDutente"] != DBNull.Value ? Convert.ToInt64(row["IDutente"]) : 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento del dipartimento coordinato: " + ex.Message);
            }
            return dipartimento;
        }
        public static ClsUtenteDL utenteCoordinaDiparimento(string NomeDipartimento)
        {
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
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomeDipartimento", NomeDipartimento);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            utente = new ClsUtenteDL();
                            utente.ID = Convert.ToInt64(row["id"]);
                            utente.Cognome = row["cognome"].ToString();
                            utente.Nome = row["nome"].ToString();
                            utente.Email = row["email"].ToString();
                            utente.TipoUtente = row["tipoUtente"].ToString();
                            utente.TipoDocente = Convert.ToChar(row["tipoDocente"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento dell'utente coordinatore: " + ex.Message);
            }
            return utente;
        }

        //public static long RilevaIDdipartimento (string nome)
        //{

        //    long ID = 0;
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string sql = @"SELECT ID 
        //                     FROM dipartimenti 
        //                     WHERE nome=@nome";
        //            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@nome", nome);
        //                using (MySqlDataReader dr = cmd.ExecuteReader())
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        dr.Read();
        //                        ID = Convert.ToInt64(dr["ID"]);
        //                    }
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return ID;
        //}


        public static string RilevaNomeDipartimento(long id)
        {
            if (id == 0)
                return "-";

            string NomeDipartimento = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT d.nome FROM dipartimenti d WHERE d.ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                            NomeDipartimento = dt.Rows[0]["nome"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il rilevamento del nome del dipartimento: " + ex.Message);
            }
            return NomeDipartimento;
        }
        #endregion

    }
}
