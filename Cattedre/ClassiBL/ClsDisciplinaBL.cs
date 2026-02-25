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

        public static List<ClsDisciplinaDL> CaricaDisciplineDipartimento(int IDdipartimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            conn.Open();
            string sql = "SELECT * FROM discipline " +
                "WHERE IDdipartimento = @IDdipartimento";
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
                discipline.Add(_disciplina);
            }
            conn.Close();

            return discipline;
        }
        /// <summary>
        /// funzione al fine di prendere l'id di quella funzione, non avendo parametri univochi apparte l'id, controllo tutti i valori inseriti
        /// </summary>
        /// <returns></returns>


        public static List<ClsDisciplinaDL> CaricaDiscipline(long iddipartimento=0, int anno=0, string nome="") // parametri facoltativi: long dipartimento, int anno, string nome
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            IDdipartimenti.Clear();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM discipline WHERE 1=1  ";
                if (iddipartimento > 0)
                    sql += "AND IDdipartimento = "+ iddipartimento + "  ";
                if (anno > 0)
                    sql += "AND anno = " + anno + "  ";
                if (nome!="")
                    sql += "AND nome LIKE '%" + nome + "%' ";
                sql += "ORDER BY anno, nome ASC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                        disciplina.ID = Convert.ToInt32(dr["id"]);
                        disciplina.Nome = dr["nome"].ToString();
                        disciplina.Anno = Convert.ToInt32(dr["anno"]);
                        disciplina.OreTeoria = Convert.ToInt32(dr["oreteoria"]);
                        disciplina.OreLaboratorio = Convert.ToInt32(dr["orelaboratorio"]);
                        disciplina.DisciplinaSpeciale = dr["disciplinaspeciale"].ToString();
                        disciplina.IDdipartimento = Convert.ToInt32(dr["IDdipartimento"]);
                        discipline.Add(disciplina);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return discipline;
        }

        public static int MostraOreDocenteTeorico(long IDdocente)
        {
            int _oreDocenteTeorico = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio " +
                             "FROM assegnare a " +
                             "JOIN discipline d ON a.IDdisciplina = d.ID " +
                             "WHERE a.IDutente = " + IDdocente;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                        disciplina.ID = Convert.ToInt32(dr["ID"]);
                        disciplina.Nome = dr["nome"].ToString();
                        disciplina.OreTeoria = Convert.ToInt32(dr["oreteoria"]);
                        disciplina.OreLaboratorio = Convert.ToInt32(dr["orelaboratorio"]);

                        _oreDocenteTeorico = disciplina.OreTeoria;
                        _oreDocenteTeorico += disciplina.OreLaboratorio; // Il prof di teoria fa anche le ore di laboratorio
                    }                    
                }
                conn.Close();
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
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio " +
                             "FROM assegnare a " +
                             "JOIN discipline d ON a.IDdisciplina = d.ID " +
                             "WHERE a.IDutente = " + IDdocente;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                        disciplina.ID = Convert.ToInt32(dr["ID"]);
                        disciplina.Nome = dr["nome"].ToString();
                        disciplina.OreTeoria = Convert.ToInt32(dr["oreteoria"]);
                        disciplina.OreLaboratorio = Convert.ToInt32(dr["orelaboratorio"]);

                        _oreDocentePratico = disciplina.OreLaboratorio;
                    }                  
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _oreDocentePratico;
        }

        public static void InserisciDisciplina(ClsDisciplinaDL disciplina)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            try
            {
                conn.Open();
                string sql = "INSERT INTO discipline (nome, anno, oreLaboratorio, oreTeoria, disciplinaSpeciale, IDdipartimento) " +
                    "VALUES (@nome, @anno, @oreLaboratorio, @oreTeoria, @disciplinaSpeciale, @IDdipartimento)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                    cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                    cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                    cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                    cmd.Parameters.AddWithValue("@disciplinaSpeciale", disciplina.DisciplinaSpeciale);
                    cmd.Parameters.AddWithValue("@IDdipartimento", disciplina.IDdipartimento);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                    {
                        throw new Exception("non è stato inserito il record");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CercaIdDisciplina(ClsDisciplinaDL disciplina)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
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
                        cmd.Parameters.AddWithValue("@IDdipartimento",disciplina.IDdipartimento);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            return Convert.ToInt32(result);
                        else
                            throw new Exception("non è stato trovato Disciplina con i derminati parametri inseriti");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public static string RilevaNomeDipartimento(long id)
        {
            if (id == 0)
                return "-";
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            ClsDipartimentoDL dipartimento = null;
            try
            {
                conn.Open();
                string sql = "SELECT d.nome " +
                             "FROM dipartimenti d " +
                             "WHERE d.ID = " + id;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    dipartimento = new ClsDipartimentoDL();
                    dipartimento.Nome = dr["nome"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dipartimento.Nome;
        }

        public static void EliminaDisciplina(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

            try
            {
                conn.Open();
                string sql = "DELETE FROM discipline WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                    {
                        throw new Exception("non è stato inserito il record");
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
                               IDdipartimento = @IDdipartimento 
                           WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@nome", disciplina.Nome);
                    cmd.Parameters.AddWithValue("@anno", disciplina.Anno);
                    cmd.Parameters.AddWithValue("@oreLaboratorio", disciplina.OreLaboratorio);
                    cmd.Parameters.AddWithValue("@oreTeoria", disciplina.OreTeoria);
                    cmd.Parameters.AddWithValue("@disciplinaSpeciale", disciplina.DisciplinaSpeciale);
                    cmd.Parameters.AddWithValue("@IDdipartimento", disciplina.IDdipartimento);
                    cmd.Parameters.AddWithValue("@id", disciplina.ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();

                    if (righeCoinvolte < 0)
                    {
                        throw new Exception("non è stato inserito il record");
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
