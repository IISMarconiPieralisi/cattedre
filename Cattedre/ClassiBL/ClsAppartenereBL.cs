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
    public static class ClsAppartenereBL
    {
        public static List<ClsAppartenereDL> CaricaClassiAppartenere(long IDindirizzo)
        {
            List<ClsAppartenereDL> apparteneres = new List<ClsAppartenereDL>();
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = @"SELECT *
                          FROM appartenere 
                          WHERE IDindirizzo = @idindirizzo
                          ORDER BY IDindirizzo";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUtente", IDindirizzo);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        conn.Close();
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsAppartenereDL app = new ClsAppartenereDL();
                    app.IDdisicplina = Convert.ToInt32(row["IDdisciplina"]);
                    app.IDindirizzo = Convert.ToInt32(row["IDindirizzo"]);
                    apparteneres.Add(app);
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return apparteneres;
        }
        public static List<ClsAppartenereDL> CaricaClassiAppartenereByDisciplina(long IDdisciplina)
        {
            List<ClsAppartenereDL> apparteneres = new List<ClsAppartenereDL>();
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT *
                           FROM appartenere 
                           WHERE IDdisciplina = @IDdisciplina
                           ORDER BY IDindirizzo";

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
                    ClsAppartenereDL app = new ClsAppartenereDL();
                    app.IDdisicplina = Convert.ToInt32(row["IDdisciplina"]);
                    app.IDindirizzo = Convert.ToInt32(row["IDindirizzo"]);
                    apparteneres.Add(app);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return apparteneres;
        }

        public static void InserireAppartenere(ClsAppartenereDL appartenere)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = @"INSERT INTO appartenere (IDindirizzo, IDdisciplina) 
                                 VALUES (@IDindirizzo, @IDdisciplina)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDindirizzo", appartenere.IDindirizzo);
                        cmd.Parameters.AddWithValue("@IDdisciplina", appartenere.IDdisicplina);
                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte == 0)
                            throw new InvalidOperationException("No rows were inserted.");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"errore nella query: {ex.Message}", ex);
            }
        }


        public static List<ClsDisciplinaDL> disciplinaAppartenuta(long IDindirizzo)
        {
            List<ClsDisciplinaDL> disc = new List<ClsDisciplinaDL>();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            DataTable dt = new DataTable();


            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.Nome, d.oreTeoria, d.oreLaboratorio
                           FROM discipline d
                           INNER JOIN appartenere a ON d.ID = a.IDdisciplina
                           WHERE a.IDindirizzo = @IDindirizzo";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDindirizzo", IDindirizzo);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                    }
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    ClsDisciplinaDL disciplina = new ClsDisciplinaDL();
                    disciplina.ID = Convert.ToInt32(row["ID"]);
                    disciplina.Nome = row["Nome"].ToString();
                    disciplina.OreTeoria = Convert.ToInt32(row["oreTeoria"]);
                    disciplina.OreLaboratorio = Convert.ToInt32(row["oreLaboratorio"]);
                    disc.Add(disciplina);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return disc;

        }
        public static List<ClsIndirizzoDL> indirizziDellaDisciplina(long IDdisciplina)
        {
            List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT i.ID, i.Nome
                           FROM indirizzi i
                           INNER JOIN appartenere a ON i.ID = a.IDindirizzo
                           WHERE a.IDdisciplina = @IDdisciplina";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);

                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    ClsIndirizzoDL indirizzo = new ClsIndirizzoDL();
                    indirizzo.ID = Convert.ToInt32(row["ID"]);
                    indirizzo.Nome = row["Nome"].ToString();


                    indirizzi.Add(indirizzo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return indirizzi;
        }

        public static void EliminaAppartenenza(ClsAppartenereDL app)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"DELETE FROM appartenere 
                            WHERE IDdisciplina= @IDdisciplina AND IDindirizzo= @IDindirizzo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@IDdisciplina", app.IDdisicplina);
                    cmd.Parameters.AddWithValue("@IDindirizzo", app.IDindirizzo);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if (righeCoinvolte <= 0)
                        throw new InvalidOperationException("No rows were inserted.");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public static void ModificaAppartenenza(long idIndirizzo, List<ClsAppartenereDL> appartenenzaModifica)
        {
            //questo metodo prendo e cancello tutte le form  che trovo in cui è presente quello specifico utente
            //poi le andro a ricreare dopo
            //prendo tutte le afferenze del utente
            //metodo poco elegante ma il migliore per la  logica in cui è stata concepita la form
            List<ClsAppartenereDL> appartenenenzeUtente = CaricaClassiAppartenere(idIndirizzo);
            foreach (ClsAppartenereDL  app in appartenenenzeUtente)
            {
                //controllo se l'afferenza è presente  nella lista delle afferenze modificate
                if (!appartenenzaModifica.Any(a => a.IDdisicplina == app.IDdisicplina))
                    EliminaAppartenenza(app);
                //se non esiste, non cancello nulla e  mi limito successivamente a caricarla
            }
            //carico le afferenze create
            foreach (ClsAppartenereDL app in appartenenzaModifica)
            {
                app.IDindirizzo = idIndirizzo;
                if (!appartenenenzeUtente.Any(a => a.IDindirizzo == app.IDindirizzo))
                    InserireAppartenere(app);
            }

        }

    }
}
