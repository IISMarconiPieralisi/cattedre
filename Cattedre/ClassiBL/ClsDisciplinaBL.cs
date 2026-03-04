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
    public static class ClsDisciplinaBL
    {
        public static int _IDdipartimento;
        public static List<int> IDdipartimenti = new List<int>();

        #region Operazioni CRUD
        public static List<ClsDisciplinaDL> CaricaDiscipline(long iddipartimento = 0, int anno = 0, string nome = "") // parametri facoltativi: long dipartimento, int anno, string nome
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            DataTable dt = new DataTable();
            IDdipartimenti.Clear();
            try
            {
                string sql = $"SELECT * FROM discipline WHERE 1=1 ";
                if (iddipartimento > 0)
                    sql += "AND IDdipartimento = " + iddipartimento + "  ";
                if (anno > 0)
                    sql += "AND anno = " + anno + "  ";
                if (nome != "")
                    sql += "AND nome LIKE '%" + nome + "%' ";
                sql += "ORDER BY anno, nome ASC";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
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
                        ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                        disciplina.ID = Convert.ToInt32(row["id"]);
                        disciplina.Nome = row["nome"].ToString();
                        disciplina.Anno = Convert.ToInt32(row["anno"]);
                        disciplina.OreTeoria = Convert.ToInt32(row["oreteoria"]);
                        disciplina.OreLaboratorio = Convert.ToInt32(row["orelaboratorio"]);
                        disciplina.DisciplinaSpeciale = row["disciplinaspeciale"].ToString();
                        disciplina.IDdipartimento = Convert.ToInt32(row["IDdipartimento"]);
                        disciplina.IDdisciplinaSuccessiva = (row["IDdisciplinaSuccessiva"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IDdisciplinaSuccessiva"]);
                        discipline.Add(disciplina);
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return discipline;
        }
        public static void InserisciDisciplina(ClsDisciplinaDL disciplina)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            try
            {

                conn.Open();
                string sql = "INSERT INTO discipline (nome, anno, oreLaboratorio, oreTeoria, disciplinaSpeciale, IDdipartimento,IDdisciplinaSuccessiva) " +
                    "VALUES (@nome, @anno, @oreLaboratorio, @oreTeoria, @disciplinaSpeciale, @IDdipartimento,@IDdisciplinaSuccessiva)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                    cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                    cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                    cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                    cmd.Parameters.AddWithValue("@disciplinaSpeciale", disciplina.DisciplinaSpeciale);
                    cmd.Parameters.AddWithValue("@IDdipartimento", disciplina.IDdipartimento);
                    if (disciplina.IDdisciplinaSuccessiva != 0)
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", disciplina.IDdisciplinaSuccessiva);
                    else
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", DBNull.Value);

                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                        throw new Exception("non è stato inserito nessuna disciplina");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void EliminaDisciplina(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM discipline WHERE id = @ID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
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
        public static void ModificaDisciplina(ClsDisciplinaDL disciplina)
        {
            FrmDisciplina frmDisciplina = new FrmDisciplina();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"UPDATE discipline 
                           SET nome = @nome, 
                               anno = @anno, 
                               oreLaboratorio = @oreLaboratorio, 
                               oreTeoria = @oreTeoria, 
                               disciplinaSpeciale = @disciplinaSpeciale, 
                               IDdipartimento = @IDdipartimento,
                               IDdisciplinaSuccessiva=@IDdisciplinaSuccessiva
                           WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                    cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                    cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                    cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                    cmd.Parameters.AddWithValue("@disciplinaSpeciale", disciplina.DisciplinaSpeciale);
                    cmd.Parameters.AddWithValue("@IDdipartimento", disciplina.IDdipartimento);
                    if (disciplina.IDdisciplinaSuccessiva != 0)
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", disciplina.IDdisciplinaSuccessiva);
                    else
                        cmd.Parameters.AddWithValue("@IDdisciplinaSuccessiva", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", disciplina.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                    {
                        throw new Exception("non è stato modificata nessuna disciplina");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        public static List<ClsDisciplinaDL> CaricaDisciplineDipartimento(int IDdipartimento)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            conn.Open();
            string sql = "SELECT * FROM discipline " +
                "WHERE IDdipartimento = @IDdipartimento " +
                "AND discipline.nome NOT LIKE '%Potenziamento%'";
            //DataAdapter, DataSet e DataTable su dispensa ADO.Net
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
            //Cache dati in memoria, oggetto disconnesso
            DataSet ds = new DataSet("cattedre");
            da.Fill(ds, "cattedre");

            //Scorro i Record del DataTable per creare la lista
            DataTable dt = ds.Tables["cattedre"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Potrei scrivere anche su una sola riga ma così è più leggibile
                ClsDisciplinaDL _disciplina = new ClsDisciplinaDL(
                    Convert.ToInt64(dt.Rows[i]["id"]),
                    dt.Rows[i]["nome"].ToString(),
                    Convert.ToInt32(dt.Rows[i]["anno"]),
                    Convert.ToInt32(dt.Rows[i]["oreLaboratorio"]),
                    Convert.ToInt32(dt.Rows[i]["oreTeoria"]),
                    dt.Rows[i]["disciplinaSpeciale"].ToString(),
                    Convert.ToInt32(dt.Rows[i]["IDdipartimento"]));
                _disciplina.IDdisciplinaSuccessiva = Convert.ToInt32(dt.Rows[i]["IDdisciplinaSuccessiva"]);
                discipline.Add(_disciplina);
            }
            conn.Close();

            return discipline;
        }
        public static int MostraOreDocenteTeorico(long IDdocente)
        {
            int _oreDocenteTeorico = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = "SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio " +
                                 "FROM assegnare a " +
                                 "JOIN discipline d ON a.IDdisciplina = d.ID " +
                                 "WHERE a.IDutente = @IDdocente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdocente", IDdocente);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                _oreDocenteTeorico = Convert.ToInt32(dr["oreteoria"]);
                                _oreDocenteTeorico += Convert.ToInt32(dr["orelaboratorio"]); // Il prof di teoria fa anche le ore di laboratorio
                            }
                        }
                    }

                }        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _oreDocenteTeorico;     
        }
        public static int MostraOreDocentePratico(long IDdocente)
        {
            int _oreDocentePratico = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio 
                                 FROM assegnare a 
                                 JOIN discipline d ON a.IDdisciplina = d.ID 
                                 WHERE a.IDutente = @idDocente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idDocente", IDdocente);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                    _oreDocentePratico = Convert.ToInt32(dr["orelaboratorio"]);
                            }
                        }
                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _oreDocentePratico;
        }
        public static ClsDisciplinaDL RilevaDisciplina(long ID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            ClsDisciplinaDL _disciplina=null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * 
                             FROM discipline 
                             WHERE ID =@ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                _disciplina = new ClsDisciplinaDL(
                                 Convert.ToInt64(dr["ID"]),
                                 dr["nome"].ToString(),
                                 Convert.ToInt32(dr["anno"]),
                                 Convert.ToInt32(dr["oreLaboratorio"]),
                                 Convert.ToInt32(dr["oreTeoria"]),
                                 dr["disciplinaSpeciale"].ToString(),
                                 Convert.ToInt32(dr["IDdipartimento"])
                                 );

                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _disciplina;
        }
        public static int CercaIdDisciplina(ClsDisciplinaDL disciplina)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT ID
                           FROM discipline 
                           WHERE nome = @nome 
                           AND anno = @anno 
                           AND IDdipartimento = @IDdipartimento";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                        cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                        cmd.Parameters.AddWithValue("@IDdipartimento", disciplina.IDdipartimento);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            return Convert.ToInt32(result);
                        else
                            throw new Exception("non è stato trovato Disciplina con i derminati parametri inseriti");
                    }
                }
            }
            catch (Exception ex)
            {
                    throw new Exception(ex.Message);
            }
        }
        public static string RilevaNomeDipartimento(long id)
        {
            if (id == 0)
                return "-";
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            string NomeDipartimento = "-";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.nome FROM dipartimenti d 
                                 WHERE d.ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            NomeDipartimento = dr["nome"].ToString();
                        }
                    }
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NomeDipartimento;
        }


    }
}
