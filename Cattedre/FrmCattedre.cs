using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Configuration;

namespace Cattedre
{
    public partial class FrmCattedre : Form
    {
        List<ClsClasseDL> classi = new List<ClsClasseDL>();
        List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
        List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
        List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
        List<ClsDisciplinaDL> disciplinerilevate = new List<ClsDisciplinaDL>();
        List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
        List<ClsDisciplinaDL> disciplineUniche = new List<ClsDisciplinaDL>();
        List<ClsUtenteDL> docentiTeoriciUsati = new List<ClsUtenteDL>();
        List<ClsUtenteDL> docentiPraticiUsati = new List<ClsUtenteDL>();

        Dictionary<long, ucOreDoc> dictDocenti = new Dictionary<long, ucOreDoc>();

        ClsUtenteDL utenteLoggato;

        int riga = 0;
        int IDdipartimento = 0;

        DataTable dtDocentiAssegnazioni;

        public FrmCattedre(ClsUtenteDL utente)
        {
            InitializeComponent();
            utenteLoggato = utente;
        }

        private void FrmCattedre_Load(object sender, EventArgs e)
        {
            //pnlDipartimento.AutoScroll = true;
            //pnlDipartimento.HorizontalScroll.Enabled = true;
            //pnlDipartimento.VerticalScroll.Enabled = false;


            if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A" || utenteLoggato.TipoUtente == "C")
            {
                // Preside: può selezionare tutti i dipartimenti, ma non modificare le combobox
                LoadDipartimenti();
            }
            if (utenteLoggato.TipoUtente == "C")
            {
                // Coordinatore del dipartimento: carica direttamente il suo dipartimento

                //IDdipartimento = ClsUtenteBL.TrovaIDdipartimento(utenteLoggato.ID);

                //LoadClassi(IDdipartimento);
                //LoadDiscipline(IDdipartimento);
                //LoadAssegnazioni(IDdipartimento);
                //cbDipartimenti.Enabled = false;
            }
        }

        private async void FrmCattedre_Shown(object sender, EventArgs e)
        {
            if (utenteLoggato.TipoUtente == "C") //|| utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
            {
                this.Cursor = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    IDdipartimento = ClsUtenteBL.TrovaIDdipartimento(utenteLoggato.ID);
                    classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento);
                    discipline = ClsDisciplinaBL.CaricaDisciplineDipartimento(IDdipartimento);
                });

                LoadClassi(IDdipartimento);
                LoadDiscipline(IDdipartimento);
                LoadAssegnazioni(IDdipartimento);

                this.Cursor = Cursors.Default;
            }
            if (utenteLoggato.TipoUtente == "C")
            {
                cbDipartimenti.SelectedIndex = IDdipartimento - 1;
                cbDipartimenti.Enabled = false;
            }
        }

        private void LoadOreDoc()
        {
            pnlOreDoc.Controls.Clear();
            dictDocenti.Clear();

            if (dtDocentiAssegnazioni == null || dtDocentiAssegnazioni.Rows.Count == 0)
                return;

            int y = 10;

            // prendo docenti distinti dal DataTable
            List<ClsUtenteDL> docenti = dtDocentiAssegnazioni.AsEnumerable()
                .Select(r => new ClsUtenteDL
                {
                    ID = Convert.ToInt64(r["IDutente"]),
                    Nome = r["nome"]?.ToString(),
                    Cognome = r["cognome"]?.ToString(),
                    TipoDocente = r["tipoDocente"] != DBNull.Value
                                    ? r["tipoDocente"].ToString()[0]
                                    : ' '
                })
                .GroupBy(d => d.ID)
                .Select(g => g.First())
                .OrderBy(d => d.TipoDocente) // prima teorici poi pratici
                .ThenBy(d => d.Cognome)
                .ToList();

            foreach (var doc in docenti)
            {
                ucOreDoc uc = new ucOreDoc();

                uc.lblDocente.Text = $"{doc.Nome} {doc.Cognome}";
                uc.lblOreDiCattedra.Text =
                    ClsContrattoBL.RilevaOreContrattoDoc(doc.ID).ToString();

                // ore potenziamento dalla QUERY UNICA
                int orePot = dtDocentiAssegnazioni.AsEnumerable()
                    .Where(r => r["IDutente"] != DBNull.Value &&
                                Convert.ToInt64(r["IDutente"]) == doc.ID)
                    .Sum(r =>
                    {
                        if (r["oreSpeciali"] == DBNull.Value)
                            return 0;

                        return Convert.ToInt32(r["oreSpeciali"]);
                    });

                uc.nudOrePot.Value = orePot;

                uc.lblOreEffettive.Text = "0";
                uc.lblOreTotali.Text = "0";

                uc.Tag = doc.ID;
                uc.Location = new Point(0, y);

                pnlOreDoc.Controls.Add(uc);
                dictDocenti[doc.ID] = uc;

                y += uc.Height + 5;

                // disabilita modifica per Preside o Admin
                if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
                {
                    uc.nudOrePot.Enabled = false;
                }

                // evento aggiornamento automatico
                uc.nudOrePot.ValueChanged += (s, e) => AggiornaOreEffettive();
            }

            AggiornaOreEffettive();
        }

        private void AggiornaOreEffettive()
        {
            if (dictDocenti.Count == 0)
                return;

            // reset
            foreach (var uc in dictDocenti.Values)
            {
                uc.lblOreEffettive.Text = "0";
                uc.lblOreTotali.Text = "0";
                uc.lblOreEffettive.ForeColor = Color.Black;
                uc.lblOreTotali.ForeColor = Color.Black;
            }

            // calcolo ore effettive
            foreach (UcAssegnazioni ucAss in pnlDipartimento.Controls.OfType<UcAssegnazioni>())
            {
                if (ucAss.cbDocentiTeorici.SelectedItem is ClsUtenteDL dt)
                {
                    if (dictDocenti.TryGetValue(dt.ID, out ucOreDoc ucDoc))
                    {
                        int ore = int.Parse(ucAss.lblOreTeoria.Text);
                        int attuali = int.Parse(ucDoc.lblOreEffettive.Text);
                        ucDoc.lblOreEffettive.Text = (attuali + ore).ToString();
                    }
                }

                if (ucAss.cbDocentiItip.SelectedItem is ClsUtenteDL dp)
                {
                    if (dictDocenti.TryGetValue(dp.ID, out ucOreDoc ucDoc))
                    {
                        int ore = int.Parse(ucAss.lblOreLaboratorio.Text);
                        int attuali = int.Parse(ucDoc.lblOreEffettive.Text);
                        ucDoc.lblOreEffettive.Text = (attuali + ore).ToString();
                    }
                }
            }

            // calcolo totali + controllo superamento
            foreach (var uc in dictDocenti.Values)
            {
                int eff = int.Parse(uc.lblOreEffettive.Text);
                int pot = int.Parse(uc.nudOrePot.Text);
                int cattedra = int.Parse(uc.lblOreDiCattedra.Text);

                int totale = eff + pot;
                uc.lblOreTotali.Text = totale.ToString();

                if (totale > cattedra)
                {
                    uc.lblOreEffettive.ForeColor = Color.Red;
                    uc.lblOreTotali.ForeColor = Color.Red;
                    uc.lblOreEffettive.Font = new Font(uc.lblOreEffettive.Font, FontStyle.Bold);
                    uc.lblOreTotali.Font = new Font(uc.lblOreTotali.Font, FontStyle.Bold);
                }
            }
        }

        private void LoadOreTotali(int riga, int oreTotali)
        {
            ucOreTotali ucOreTotali = new ucOreTotali();
            ucOreTotali.lblOreTotali.Text = oreTotali.ToString();
            int x = 0;
            int y;
            y = 72 + riga * 100;
           
            ucOreTotali.Location = new Point(x, y);
            pnlOre.Controls.Add(ucOreTotali);

            ucOreTotali.Refresh();
        }

        private void LoadDipartimenti()
        {
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();

            for (int i = 0; i < dipartimenti.Count; i++)
            {
                cbDipartimenti.Items.Add(dipartimenti[i].Nome);
            }
        }

        private void LoadAssegnazioni(int IDdipartimento)
        {
            pnlDipartimento.Controls
                .OfType<UcAssegnazioni>()
                .ToList()
                .ForEach(c => { pnlDipartimento.Controls.Remove(c); c.Dispose(); });

            pnlOre.Controls.Clear();
            docentiTeoriciUsati.Clear();
            docentiPraticiUsati.Clear();

            // QUERY UNICA x recuperare tutti i docenti del dipartimento
            dtDocentiAssegnazioni = ClsAssegnareBL
                .CaricaDocentiConAssegnazioni(IDdipartimento, 1);

            int oreTotaliGenerali = 0;

            for (int riga = 0; riga < classi.Count; riga++)
            {
                ClsClasseDL classe = classi[riga];
                int oreTotaliClasse = 0;

                for (int colonna = 0; colonna < disciplineUniche.Count; colonna++)
                {
                    ClsDisciplinaDL disciplinaTemplate = disciplineUniche[colonna];

                    ClsDisciplinaDL disciplina = discipline
                        .FirstOrDefault(d => d.Nome == disciplinaTemplate.Nome
                                          && d.Anno == classe.Anno);

                    if (disciplina == null)
                        continue;

                    // ricavo indirizzo della classe
                    long IDindirizzoClasse = ClsClasseBL.TrovaIndirizzoClasse(classe.ID);

                    // controllo appartenenza tra disciplina e indirizzo
                    bool appartiene = ClsAppartenereBL
                        .caricaIndirizziDisciplina(disciplina.ID)
                        .Any(i => i.ID == IDindirizzoClasse);

                    // se non appartiene non creo la UC
                    if (!appartiene)
                        continue;

                    UcAssegnazioni uc = new UcAssegnazioni();

                    // docenti teorici
                    List<ClsUtenteDL> teorici = dtDocentiAssegnazioni.AsEnumerable()
                        .Where(r => r["tipoDocente"].ToString() == "T")
                        .Select(r => new ClsUtenteDL
                        {
                            ID = Convert.ToInt64(r["IDutente"]),
                            Nome = r.Field<string>("nome"),
                            Cognome = r.Field<string>("cognome"),
                            TipoDocente = 'T'
                        })
                        .GroupBy(_x => _x.ID)
                        .Select(g => g.First())
                        .ToList();

                    // docenti pratici
                    List<ClsUtenteDL> pratici = dtDocentiAssegnazioni.AsEnumerable()
                        .Where(r => r["tipoDocente"].ToString() == "L")
                        .Select(r => new ClsUtenteDL
                        {
                            ID = Convert.ToInt64(r["IDutente"]),
                            Nome = r.Field<string>("nome"),
                            Cognome = r.Field<string>("cognome"),
                            TipoDocente = 'L'
                        })
                        .GroupBy(_x => _x.ID)
                        .Select(g => g.First())
                        .ToList();

                    uc.cbDocentiTeorici.DataSource = teorici;
                    uc.cbDocentiTeorici.DisplayMember = "Cognome";
                    uc.cbDocentiTeorici.ValueMember = "ID";

                    uc.cbDocentiItip.DataSource = pratici;
                    uc.cbDocentiItip.DisplayMember = "Cognome";
                    uc.cbDocentiItip.ValueMember = "ID";

                    // docente già assegnato (in memoria)
                    var assegnazione = dtDocentiAssegnazioni.AsEnumerable()
                        .FirstOrDefault(r =>
                            r["IDclasse"] != DBNull.Value &&
                            r["IDdisciplina"] != DBNull.Value &&
                            Convert.ToInt64(r["IDclasse"]) == classe.ID &&
                            Convert.ToInt64(r["IDdisciplina"]) == disciplina.ID
                        );

                    if (assegnazione != null)
                    {
                        long idDoc = Convert.ToInt64(assegnazione["IDutente"]);
                        string tipoString = assegnazione["tipoDocente"]?.ToString();
                        char tipo = string.IsNullOrEmpty(tipoString) ? ' ' : tipoString[0];

                        if (tipo == 'T')
                            uc.cbDocentiTeorici.SelectedValue = idDoc;
                        else if (tipo == 'L')
                            uc.cbDocentiItip.SelectedValue = idDoc;
                    }

                    // ore
                    uc.lblOreTeoria.Text = disciplina.OreTeoria.ToString();
                    uc.lblOreLaboratorio.Text = disciplina.OreLaboratorio.ToString();

                    oreTotaliClasse += disciplina.OreTeoria + disciplina.OreLaboratorio;

                    // eventi
                    uc.cbDocentiTeorici.SelectedIndexChanged += (s, e) =>
                    {
                        AggiornaOreEffettive();

                        if (uc.cbDocentiTeorici.SelectedValue != null)
                            ClsAssegnareBL.UpdateCattedra(
                                classe.ID,
                                1,
                                disciplina.ID,
                                Convert.ToInt64(uc.cbDocentiTeorici.SelectedValue));
                    };

                    uc.cbDocentiItip.SelectedIndexChanged += (s, e) =>
                    {
                        AggiornaOreEffettive();

                        if (uc.cbDocentiItip.SelectedValue != null)
                            ClsAssegnareBL.UpdateCattedra(
                                classe.ID,
                                1,
                                disciplina.ID,
                                Convert.ToInt64(uc.cbDocentiItip.SelectedValue));
                    };

                    int x = 10 + colonna * 225;
                    int y = 72 + riga * 100;
                    uc.Location = new Point(x, y);

                    pnlDipartimento.Controls.Add(uc);

                    //cambio dei diritti di modifica
                    if(utenteLoggato.TipoUtente=="A" || utenteLoggato.TipoUtente=="P")
                    {
                        uc.cbDocentiItip.Enabled = false;
                        uc.cbDocentiTeorici.Enabled = false;
                    }

                }

                oreTotaliGenerali += oreTotaliClasse;
            }

            LoadOreDoc();
            AggiornaOreEffettive();
        }

        private void LoadDiscipline(int IDdipartimento)
        {
            foreach (UcDisciplina uc in pnlDipartimento.Controls.OfType<UcDisciplina>().ToList())
            {
                pnlDipartimento.Controls.Remove(uc);
                uc.Dispose();
            }
            disciplineUniche.Clear();

            discipline = ClsDisciplinaBL.CaricaDisciplineDipartimento(IDdipartimento);

            // Rimuovo le discipline con lo stesso nome, mantengo solo la prima
            List<string> nomiUsati = new List<string>();            

            foreach (ClsDisciplinaDL d in discipline)
            {
                if (!nomiUsati.Contains(d.Nome))
                {
                    nomiUsati.Add(d.Nome);
                    disciplineUniche.Add(d);
                }
            }

            // Mostro le discipline uniche nel pnlDisciplina
            int x = 10;
            int y = 10;
            for (int i = 0; i < disciplineUniche.Count; i++)
            {
                UcDisciplina ucDisciplina = new UcDisciplina(disciplineUniche[i]);
                ucDisciplina.Location = new Point(x, y);
                pnlDipartimento.Controls.Add(ucDisciplina);

                //ucDisciplina.Refresh();

                x += ucDisciplina.Width + 10;
            }
            //UcOre ucOre = new UcOre();
            //ucOre.Location = new Point(0, 10);
            //pnlOre.Controls.Add(ucOre);

            //ucOre.Refresh();
        }
        private void LoadClassi(int IDdipartimento)
        {
            foreach (UcClasse uc in pnlClassi.Controls.OfType<UcClasse>().ToList())
            {
                pnlClassi.Controls.Remove(uc);
                uc.Dispose();
            }

            classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento);

            int x = 10;
            int y = 72;
            for (int i = 0; i < classi.Count; i++)
            {
                UcClasse ucClasse = new UcClasse(classi[i]);
                ucClasse.Location = new Point(x,y);
                pnlClassi.Controls.Add(ucClasse);

                ucClasse.Refresh();

                y += ucClasse.Height + 10;
            }
        }

        private void PulisciDipartimento()
        {
            // Svuoto pannelli
            //pnlDipartimento.Controls.Clear();
            //pnlClassi.Controls.Clear();
            pnlOre.Controls.Clear();
            pnlOreDoc.Controls.Clear();

            // Svuoto liste
            disciplineUniche.Clear();
            docentiTeoriciUsati.Clear();
            docentiPraticiUsati.Clear();
            classi.Clear();
            discipline.Clear();

            // Svuoto dizionario
            dictDocenti.Clear();
        }


        private void btSalva_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sei sicuro di voler salvare?", "SALVATAGGIO", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            
        }

        private async void btCaricaDipartimento_Click_1(object sender, EventArgs e)
        {
            //IDdipartimento = cbDipartimenti.SelectedIndex + 1;

            //LoadClassi(IDdipartimento);
            //LoadDiscipline(IDdipartimento);
            //LoadAssegnazioni(IDdipartimento);
            //pnlSceltaDipartimentoCattedre.Visible = false;

            try
            {
                if (cbDipartimenti.SelectedItem == null || utenteLoggato.TipoUtente == "A" || utenteLoggato.TipoUtente == "P")
                {
                    this.UseWaitCursor = true;
                    Application.DoEvents();


                    IDdipartimento = cbDipartimenti.SelectedIndex + 1;

                    PulisciDipartimento();

                    await Task.Run(() =>
                    {
                        classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento);
                        discipline = ClsDisciplinaBL.CaricaDisciplineDipartimento(IDdipartimento);
                    });

                    LoadClassi(IDdipartimento);
                    LoadDiscipline(IDdipartimento);
                    LoadAssegnazioni(IDdipartimento);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Errore:{ex.Message}. \nRiprovare!", "riprovare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }
    }
}
