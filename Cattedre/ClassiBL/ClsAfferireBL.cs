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
    public static class ClsAfferireBL
    {
        public static List<ClsAfferireDL> CaricaClassiAfferire(long idUtente)
        {
            List<ClsAfferireDL> afferireDLs = new List<ClsAfferireDL>();
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = @"SELECT *
                          FROM afferire 
                          WHERE IDutente = @IdUtente
                          ORDER BY IDdipartimento";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUtente", idUtente);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {

                            da.Fill(dt);
                        }
                        conn.Close();
                    }
                }
                foreach(DataRow row in dt.Rows)
                {
                     long idUtenteDB = Convert.ToInt64(row["IDutente"]);
                     long idDipartimento = Convert.ToInt64(row["IDdipartimento"]);

                     ClsAfferireDL afferire = new ClsAfferireDL(idDipartimento,idUtente);
                     afferire.ID = Convert.ToInt64(row["ID"]);
                     afferireDLs.Add(afferire);
                }
                        
                    
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nel caricamento afferenze per l'utente {idUtente}", ex);
            }
            return afferireDLs;
        }

        public static void InserisciAfferire(ClsAfferireDL afferire)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = @"INSERT INTO afferire (IDdipartimento, IDutente) 
                                 VALUES (@IDdipartimento, @IDutente)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdipartimento", afferire.IDdipartimento);
                        cmd.Parameters.AddWithValue("@IDutente", afferire.IDutente);
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
    

        public static List<ClsDipartimentoDL> dipartimentiAfferiti(long Idutente)
        {
            List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            DataTable dt = new DataTable();


            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT d.ID, d.Nome
                           FROM dipartimenti d
                           INNER JOIN afferire a ON d.ID = a.IDdipartimento
                           WHERE a.IDutente = @IDutente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDutente", Idutente);
                        using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                        {
                            dr.Fill(dt);
                        }
                    }
                    conn.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    ClsDipartimentoDL dip = new ClsDipartimentoDL();
                    dip.ID = Convert.ToInt64(row["ID"]);
                    dip.Nome = row["nome"].ToString();
                    dipartimenti.Add(dip);
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei dipartimenti afferiti", ex);
            }

            return dipartimenti;

        }

        public static void EliminaAfferenza(ClsAfferireDL aff)
        {
            long ID = aff.ID;
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"DELETE FROM afferire WHERE ID =@ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if(righeCoinvolte<=0)
                        throw new InvalidOperationException("No rows were inserted.");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

           
        }

        public static void ModificaAfferenze(long idUtente, List <ClsAfferireDL> afferenzeModifica)
        {
            //questo metodo prendo e cancello tutte le form  che trovo in cui è presente quello specifico utente
            //poi le andro a ricreare dopo
            //prendo tutte le afferenze del utente
            //metodo poco elegante ma il migliore per la  logica in cui è stata concepita la form
            List<ClsAfferireDL> afferenzeUtente = CaricaClassiAfferire(idUtente);
            foreach(ClsAfferireDL aff in afferenzeUtente)
            {
                //controllo se l'afferenza è presente  nella lista delle afferenze modificate
                if(!afferenzeModifica.Any(a => a.IDdipartimento == aff.IDdipartimento))
                     EliminaAfferenza(aff);
                //se non esiste, non cancello nulla e  mi limito successivamente a caricarla
            }
            //carico le afferenze create
            foreach (ClsAfferireDL aff in afferenzeModifica)
            {
                aff.IDutente = idUtente;
                if (!afferenzeUtente.Any(a => a.IDdipartimento == aff.IDdipartimento))
                InserisciAfferire(aff);
            }
            
        }

    }
}