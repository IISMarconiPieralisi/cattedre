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
    public static class ClsAssegnareBL
    {
        public static List<ClsUtenteDL> CercaDocentiDiRiferimento(int IDdipartimento, int IDclasse, int IDdisciplina)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            
            List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
            FrmDipartimenti frmDocenti = new FrmDipartimenti();
            DataTable ds = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT u.ID, u.email, u.cognome, u.nome, u.tipoDocente " +
                           "FROM utenti u " +
                            "JOIN assegnare a ON u.ID = a.IDutente " +
                           "JOIN afferire af ON u.ID = af.IDutente " +
                           "JOIN discipline d ON a.IDdisciplina = d.ID " +
                           "WHERE u.tipoUtente = 'D' " +
                           "OR u.tipoUtente = 'C' " +
                           "OR u.tipoUtente = 'A' " +
                             "AND a.IDclasse = @IDclasse " +
                             "AND af.IDdipartimento = @IDdipartimento " +
                             "AND a.IDdisciplina = @IDdisciplina ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                        conn.Close();
                    }
                }
                foreach (DataRow row in ds.Rows)
                {
                    ClsUtenteDL utente = new ClsUtenteDL();
                    utente.ID = Convert.ToInt64(row["ID"]);
                    utente.Email = row["email"].ToString();
                    //anche se la query non restituisce la password, la proprietà non la userà e non ha senso inizarlizzarla,  essendo un dato sensibile
                    utente.Cognome = row["cognome"].ToString();
                    utente.Nome = row["nome"].ToString();
                    utente.TipoDocente = row["tipoDocente"] != DBNull.Value ? Convert.ToChar(row["tipoDocente"]) : '\0';
                    docentiDipartimento.Add(utente);
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docentiDipartimento;
        }

        public static List<ClsUtenteDL> CercaDocentiPossibiliSostituti(int IDdipartimento, int IDclasseDiConcorso)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
            try
            {
                conn.Open();
                string sql = "SELECT u.ID, u.email,u.cognome, u.nome, u.tipoDocente " +
                       "FROM utenti u " +
                       "JOIN assegnare a ON u.ID = a.IDutente " +
                       "JOIN afferire af ON u.ID = af.IDutente " +
                       "JOIN richiedere r ON u.ID = r.IDutente " +
                       "WHERE u.tipoUtente = 'D' " +
                       "OR u.tipoUtente = 'C' " +
                       "OR u.tipoUtente = 'A' " +
                         "AND af.IDdipartimento = @IDdipartimento " +
                         "AND r.IDclassediconcorso = @IDclasseDiConcorso";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                cmd.Parameters.AddWithValue("@IDclasseDiConcorso", IDclasseDiConcorso);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsUtenteDL docenteDipartimento = new ClsUtenteDL();
                        docenteDipartimento.ID = Convert.ToInt64(dr["ID"]);
                        docenteDipartimento.Email = dr["email"].ToString();
                        docenteDipartimento.Cognome = dr["cognome"].ToString();
                        docenteDipartimento.Nome = dr["nome"].ToString();
                        docenteDipartimento.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
                        docentiDipartimento.Add(docenteDipartimento);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docentiDipartimento;
        }

        public static ClsUtenteDL MostraDocenteTeorico(int IDdipartimento, int IDclasse, int IDdisciplina)
        {
            ClsUtenteDL docente = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
            try
            {
                conn.Open();
                string sql = @"SELECT u.ID, u.email,u.cognome, u.nome, u.tipoDocente, u.tipoUtente
               FROM utenti u
               JOIN assegnare a ON u.ID = a.IDutente
               WHERE u.tipoDocente='T' AND (u.tipoUtente = 'D' OR u.tipoUtente = 'C' OR tipoUtente='A')
               AND a.IDclasse = @IDclasse Limit 1";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
                cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        docente = new ClsUtenteDL();
                        docente.ID = Convert.ToInt64(dr["id"]);
                        docente.Email = dr["email"].ToString();
                        docente.Nome = dr["nome"].ToString();
                        docente.Cognome = dr["cognome"].ToString();
                        docente.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
                        docente.TipoUtente = dr["tipoUtente"].ToString();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docente;
        }

        public static ClsUtenteDL MostraDocentePratico(int IDdipartimento, int IDclasse, int IDdisciplina)
        {
            ClsUtenteDL docente = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
            try
            {
                conn.Open();
                string sql = @"SELECT u.ID, u.email, u.password, u.cognome, u.nome, u.tipoDocente, u.tipoUtente
               FROM utenti u
               JOIN assegnare a ON u.ID = a.IDutente
               WHERE u.tipoDocente='L' AND (u.tipoUtente = 'D' OR u.tipoUtente = 'C' OR tipoUtente='A')
               AND a.IDclasse = @IDclasse 
               Limit 1";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                cmd.Parameters.AddWithValue("@IDclasse", IDclasse);
                cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        docente = new ClsUtenteDL();
                        docente.ID = Convert.ToInt64(dr["id"]);
                        docente.Email = dr["email"].ToString();
                        docente.Password = dr["password"].ToString();
                        docente.Nome = dr["nome"].ToString();
                        docente.Cognome = dr["cognome"].ToString();
                        docente.TipoDocente = Convert.ToChar(dr["tipoDocente"]);
                        docente.TipoUtente = dr["tipoUtente"].ToString();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docente;
        }
        public static int CaricaOrePotenziamentoDocente(int IDutente)
        {
            ClsAssegnareDL assegnare = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT a.oreSpeciali " +
                       "FROM assegnare a " +
                       "JOIN utenti u ON a.IDutente = u.ID " +
                       "JOIN afferire af ON u.ID = af.IDutente " +
                       "JOIN discipline d ON a.IDdisciplina = d.ID " +
                       "WHERE u.tipoUtente = 'D' " +
                       "OR u.tipoUtente = 'C' " +
                       "OR u.tipoUtente = 'A' " +
                       "AND u.ID = @IDutente " +
                       "AND d.nome LIKE 'Potenziamento%'";
                       //"AND af.IDdipartimento = @IDdipartimento ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDutente", IDutente);
                //cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        assegnare = new ClsAssegnareDL();
                        assegnare.OreSpeciali = Convert.ToInt32(dr["oreSpeciali"]);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return assegnare.OreSpeciali;
        }

        public static void SalvaOrePot(int oreSpeciali, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsAssegnareDL assegnare = null;
            try
            {
                conn.Open();
                string sql = "UPDATE assegnare SET oreSpeciali = @oreSpeciali WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@oreSpeciali", oreSpeciali);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        assegnare = new ClsAssegnareDL();
                        assegnare.OreSpeciali = Convert.ToInt32(dr["oreSpeciali"]);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static long RicavaIDutente(string nome, string cognome)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsUtenteDL docente = null;
            try
            {
                conn.Open();
                string sql = "SELECT ID FROM utenti WHERE nome = @nome AND cognome = @cognome";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cognome", cognome);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        docente = new ClsUtenteDL();
                        docente.ID = Convert.ToInt32(dr["ID"]);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docente.ID;
        }

        public static long RicavaIDassegnare(int oreSpeciali, long idUtente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsUtenteDL docente = null;
            try
            {
                conn.Open();
                string sql = "SELECT ID FROM assegnare WHERE oreSpeciali = @oreSpeciali AND idUtente = @idUtente AND oreSpeciali > 0";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idUtente", idUtente);
                cmd.Parameters.AddWithValue("@orespecili", oreSpeciali);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        docente = new ClsUtenteDL();
                        docente.ID = Convert.ToInt32(dr["ID"]);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docente.ID;
        }
    }
}
