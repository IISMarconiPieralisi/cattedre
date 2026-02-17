using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Configuration;

namespace Cattedre
{
   public static class ClsDipartimentoBL
   {
        public static int _IDutente;
        public static List<int> IDutenti = new List<int>();

        public static List<ClsDipartimentoDL> CaricaDipartimenti()
         {
            IDutenti.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dipartimenti";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsDipartimentoDL dipartimento = new ClsDipartimentoDL();
                        dipartimento.ID = Convert.ToInt64(dr["id"]);
                        dipartimento.Nome = dr["nome"].ToString();
                        _IDutente = dr.IsDBNull(dr.GetOrdinal("IDutente"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("IDutente"));
                        dipartimenti.Add(dipartimento);
                        IDutenti.Add(_IDutente);
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                string errore = ex.Message;
            }
            return dipartimenti;
         }

        public static List<ClsDipartimentoDL> InserisciDipartimento(ClsDipartimentoDL dip, int IDutente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();

            try
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM dipartimenti WHERE IDutente = @IDutente";
                using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@IDutente", IDutente);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        string sql = "INSERT INTO dipartimenti (nome, IDutente) VALUES (@nome, @IDutente)";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        {
                            cmd.Parameters.AddWithValue("@nome", dip.Nome);
                            cmd.Parameters.AddWithValue("@IDutente", IDutente);
                            int righeCoinvolte = cmd.ExecuteNonQuery();

                            if (righeCoinvolte > 0)
                            {
                                dipartimenti.Add(dip);
                                IDutenti.Add(IDutente);
                            }
                        }
                    }
                    else
                        throw new Exception("Questo utente è già coordinatore di un altro dipartimento.");
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return dipartimenti;
        }

        public static List<ClsDipartimentoDL> EliminaDipartimento(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM dipartimenti WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        dipartimenti = CaricaDipartimenti();
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return dipartimenti;
        }

        public static List<ClsDipartimentoDL> ModificaDipartimento(ClsDipartimentoDL dipartimento, int indice, long IDutente)
        {
            FrmDipartimento frmDipartimento = new FrmDipartimento(indice);
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();

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
                    cmd.Parameters.AddWithValue("@IDutente", IDutente);
                    cmd.Parameters.AddWithValue("id", dipartimento.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte > 0)
                    {
                        dipartimenti[indice] = frmDipartimento._dipartimento;
                        IDutenti[indice] = (int)IDutente;
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

            return dipartimenti;
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
                string errore = ex.Message;
                return false;
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
                        _IDutente = dr.IsDBNull(dr.GetOrdinal("IDutente"))
                                    ? 0
                                    : dr.GetInt32(dr.GetOrdinal("IDutente"));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }
            return dipartimento;
        }
        public static ClsUtenteDL utenteCoordinaDiparimento(string NomeDipartimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsUtenteDL utente = null;
            try
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
            catch (Exception ex)
            {
                string errore = ex.Message;
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
                throw new Exception("errore:" + ex);
            }

        }
    }
}
