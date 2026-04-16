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
    public static class ClsGestireBL
    {
        public static List<ClsDipartimentoDL> DipartimentiDellaDisciplina(long IDdisciplina)
        {
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.Nome 
                               FROM dipartimenti d
                               INNER JOIN gestire g ON d.ID = g.IDdipartimento
                               WHERE g.IDdisciplina = @IDdisciplina
                               ORDER BY d.Nome";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    // Assumendo che la tua classe ClsDipartimentoDL abbia ID e Nome
                    ClsDipartimentoDL dip = new ClsDipartimentoDL();
                    dip.ID = Convert.ToInt64(row["ID"]);
                    dip.Nome = row["Nome"].ToString();
                    dipartimenti.Add(dip);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dipartimenti;
        }
        public static List<ClsDisciplinaDL> DisciplineDelDipartimento(long IDdipartimento)
        {
            List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.nome, d.anno,d.oreteoria,orelaboratorio,disciplinaspeciale
                               FROM discipline d
                               INNER JOIN gestire g ON d.ID = g.IDdisciplina
                               WHERE g.IDdipartimento = @IDdipartimento
                               ORDER BY d.Nome";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", IDdipartimento);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    // Assumendo che la tua classe ClsDipartimentoDL abbia ID e Nome
                    ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                    disciplina.ID = Convert.ToInt32(row["id"]);
                    disciplina.Nome = row["nome"].ToString();
                    disciplina.Anno = Convert.ToInt32(row["anno"]);
                    disciplina.OreTeoria = Convert.ToInt32(row["oreteoria"]);
                    disciplina.OreLaboratorio = Convert.ToInt32(row["orelaboratorio"]);
                    disciplina.DisciplinaSpeciale = row["disciplinaspeciale"].ToString();
                    discipline.Add(disciplina);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return discipline;
        }
        public static List<ClsGestireDL> CaricaGestioneDisciplina(long IDdisciplina)
        {
            List<ClsGestireDL> gestioni = new List<ClsGestireDL>();
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM gestire WHERE IDdisciplina = @iddisciplina";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@iddisciplina", IDdisciplina);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    gestioni.Add(new ClsGestireDL(
                        Convert.ToInt64(row["IDdipartimento"]),
                        Convert.ToInt64(row["IDdisciplina"])
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nel caricamento gestioni per disciplina: {ex.Message}");
            }
            return gestioni;
        }

        public static void InserireGestione(ClsGestireDL gestione)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO gestire (IDdipartimento, IDdisciplina) VALUES (@IDdipartimento, @IDdisciplina)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", gestione.IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDdisciplina", gestione.IDdisciplina);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nell'inserimento: {ex.Message}");
            }
        }

        public static void EliminaGestione(ClsGestireDL gestione)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM gestire WHERE IDdipartimento = @IDdipartimento AND IDdisciplina = @IDdisciplina";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", gestione.IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDdisciplina", gestione.IDdisciplina);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nell'eliminazione: {ex.Message}");
            }
        }
      
        public static void ModificaGestioni(long idDisciplina, List<ClsGestireDL> gestioniModificate)
        {
            List<ClsGestireDL> gestioniAttuali = CaricaGestioneDisciplina(idDisciplina);

            foreach (ClsGestireDL attuale in gestioniAttuali)
            {
                // Verifico se il dipartimento attuale esiste ancora nella lista modificata
                if (!gestioniModificate.Any(m => m.IDdipartimento == attuale.IDdipartimento))
                {
                    // Imposto per sicurezza l'ID corretto prima di passare l'oggetto al metodo Elimina
                    attuale.IDdisciplina = idDisciplina;
                    EliminaGestione(attuale);
                }
            }

            foreach (ClsGestireDL nuova in gestioniModificate)
            {
                nuova.IDdisciplina = idDisciplina; // Forza la coerenza dell'ID disciplina
                if (!gestioniAttuali.Any(a => a.IDdipartimento == nuova.IDdipartimento))
                {
                    InserireGestione(nuova);
                }
            }
        }
    }
}
