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
    public static class ClsRichiedereBL
    {
        public static List<ClsClasseDiConcorsoDL> RilevaCDCDiscipina(long IDdisciplina)
        {
            List<ClsClasseDiConcorsoDL> CDCs = new List<ClsClasseDiConcorsoDL>();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.id,c.livello,c.nome,c.abilitazioniRichieste
                                    FROM classidiconcorso c
                                    INNER JOIN richiedere r ON c.ID = r.IDclasseDiConcorso
                                    WHERE r.ID = @IDdisciplina";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@IDdisciplina", MySqlDbType.Int64).Value = IDdisciplina;

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL
                                {
                                    ID = dr.GetInt32("id"),
                                    Livello = dr.GetString("livello"),
                                    Nome = dr.GetString("nome"),
                                    AbilitazioniRichieste = dr.GetString("abilitazioniRichieste")
                                };

                                CDCs.Add(cdc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
                throw;
            }

            return CDCs;
        }
        public static List<ClsClasseDiConcorsoDL> RilevaCDCDocente(long IDutente)
        {
            List<ClsClasseDiConcorsoDL> CDCs = new List<ClsClasseDiConcorsoDL>();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.id,c.livello,c.nome
                                    FROM classidiconcorso c
                                    JOIN richiedere r ON c.ID = r.IDclasseDiConcorso
                                    WHERE r.IDutente = @IdUtente";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@IdUtente", MySqlDbType.Int64).Value = IDutente;

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ClsClasseDiConcorsoDL cdc = new ClsClasseDiConcorsoDL();
                                cdc.ID =Convert.ToInt64(dr["id"]);
                                cdc.Livello =dr["livello"].ToString();
                                cdc.Nome = dr["nome"].ToString();
                                CDCs.Add(cdc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"errore nella query: {ex.Message}", ex);

            }

            return CDCs;
        }
        public static void InserisciRichiedere(ClsRichiedereDL Richiedere)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Richiedere (IDclasseDiConcorso, IDutente,IDdisciplina) " +
                                 "VALUES (@IDclasseDiConcorso, @IDutente, @IDdisciplina)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@IDclasseDiConcorso", Richiedere.IDclassediconcorso);

                        if(Richiedere.IDutente > 0)
                            cmd.Parameters.AddWithValue("@IDutente", Richiedere.IDutente);
                        else
                            cmd.Parameters.AddWithValue("@IDutente", DBNull.Value);
                        //controllo temporaneo  che  verrà rimosso successivamente
                        if (Richiedere.IDdisciplina > 0)
                            cmd.Parameters.AddWithValue("@IDdisciplina", Richiedere.IDdisciplina);
                        else
                            cmd.Parameters.AddWithValue("@IDdisciplina", DBNull.Value);

                        int righeCoinvolte = cmd.ExecuteNonQuery();
                        if (righeCoinvolte == 0)
                            throw new InvalidOperationException("No rows were inserted.");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"errore nella query: {ex.Message}", ex);
                }
            }
        }
        public static void EliminaRichiesta(ClsRichiedereDL ric)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"DELETE FROM afferire" +
                             " WHERE IDutente = @IDutente " +
                             " AND IDclasseDiConcorso=@IDclasseDiConcorso" +
                             " AND IDdisciplina=@IDdisciplina";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDutente", ric.IDutente);
                    cmd.Parameters.AddWithValue("@IDclasseDiConcorso", ric.IDclassediconcorso);
                    cmd.Parameters.AddWithValue("@IDdisciplina", ric.IDdisciplina);
                    int righeCoinvolte = cmd.ExecuteNonQuery();
                    if(righeCoinvolte<=0)
                    {
                        throw new InvalidOperationException("Nessuna riga è stata coinvolta, Errore Query");
                    }

                }
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
            }

        }
        public static List<ClsRichiedereDL> CaricaClassiRichiedere(long IDutente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataTable ds = new DataTable();
            List<ClsRichiedereDL> richiederes = new List<ClsRichiedereDL>();
            try
            {
                conn.Open();
                string sql = "SELECT ID, IDutente, IDclasseDiConcorso, IDdisciplina, oreSpeciali FROM richiedere ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataAdapter dr = new MySqlDataAdapter(cmd))
                    {
                        dr.Fill(ds);
                    }
                    conn.Close();
                }
                foreach (DataRow row in ds.Rows)
                {
                    ClsRichiedereDL richiedere = new ClsRichiedereDL();
                    richiedere.ID = Convert.ToInt64(row["ID"]);
                    richiedere.IDutente = Convert.ToInt64(row["IDutente"]);
                    richiedere.IDclassediconcorso = Convert.ToInt64(row["IDclasseDiConcorso"]);
                    richiedere.IDdisciplina = (row["IDdisciplina"] == DBNull.Value) ? 0 : Convert.ToInt64(row["IDdisciplina"]);
                    richiedere.OreSpeciali = Convert.ToInt32(row["OreSpeciali"]);
                    richiederes.Add(richiedere);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return richiederes;

        }
        public static List<ClsRichiedereDL> CaricaClassiRichiedereConDisciplina(long IDdisciplina)
        {
            List<ClsRichiedereDL> Richiederes = new List<ClsRichiedereDL>();
            string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT IDutente, IDclasseDiConcorso, IDdisciplina 
                                FROM richiedere
                                WHERE IDdisciplina=@IDdisciplina";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDdisciplina", IDdisciplina);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ClsRichiedereDL richiedere = new ClsRichiedereDL();

                                richiedere.IDutente = Convert.ToInt64(dr["IDutente"]);
                                richiedere.IDclassediconcorso = Convert.ToInt64(dr["IDclasseDiConcorso"]);
                                if (dr["IDdisciplina"] != DBNull.Value)
                                    richiedere.IDdisciplina = Convert.ToInt64(dr["IDdisciplina"]);

                                Richiederes.Add(richiedere);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("errore nella richiesta della query " + ex);

            }
            return Richiederes;
        }

        public static void ModificaRichiesta(long idUtente,long idDisciplina, List<ClsRichiedereDL> RichModifica) //se idutente è 0 allora uso iddisciplina e viceversa
        {
            //questo metodo prendo e cancello tutte le form  che trovo in cui è presente quello specifico utente
            //poi le andro a ricreare dopo
            //prendo tutte le afferenze del utente
            //metodo poco elegante ma il migliore per la  logica in cui è stata concepita la form
            List<ClsRichiedereDL> RichiesteUtente= new List<ClsRichiedereDL>();
            if(idUtente > 0 && idDisciplina>0)
                throw new Exception("Errore nei parametri passati al metodo ModificaRichiesta");
            else if (idUtente>0)
                RichiesteUtente = CaricaClassiRichiedere(idUtente);
            else if(idDisciplina>0)
                RichiesteUtente = CaricaClassiRichiedere(idUtente);
            //cancello le afferenze eliminate
            foreach (ClsRichiedereDL ric in RichiesteUtente)
                {
                    //controllo se l'afferenza è presente  nella lista delle afferenze modificate
                    bool esiste = RichModifica.Any(r => r.IDutente == ric.IDutente &&
                                                    r.IDclassediconcorso == ric.IDclassediconcorso &&
                                                    r.IDdisciplina == ric.IDdisciplina);
                    if (!esiste)
                        EliminaRichiesta(ric);

                    //se non esiste, non cancello nulla e  mi limito successivamente a caricarla
                }
            //carico le afferenze create
            foreach (ClsRichiedereDL ric in RichModifica)
            {
                ric.IDutente = idUtente;
                bool giaPresente = RichiesteUtente.Any(r =>r.IDutente == ric.IDutente &&
                                                       r.IDclassediconcorso == ric.IDclassediconcorso &&
                                                       r.IDdisciplina == ric.IDdisciplina);
                if(!giaPresente)
                    InserisciRichiedere(ric);
            }
        }
    }
}
