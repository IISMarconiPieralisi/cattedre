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


            if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
            {
                // Preside: può selezionare tutti i dipartimenti, ma non modificare le combobox
                LoadDipartimenti();
            }
            else if (utenteLoggato.TipoUtente == "C")
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
            if (utenteLoggato.TipoUtente == "C" || utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
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
        }

        private void LoadOreDoc()
        {
            pnlOreDoc.Controls.Clear();
            dictDocenti.Clear();

            int y = 10;

            //TEORICI
            foreach (ClsUtenteDL doc in docentiTeoriciUsati)
            {
                ucOreDoc uc = new ucOreDoc();
                uc.lblDocente.Text = $"{doc.Nome} {doc.Cognome}";
                uc.lblOreDiCattedra.Text = ClsContrattoBL.RilevaOreContrattoDoc(doc.ID).ToString();
                uc.nudOrePot.Text = ClsAssegnareBL.CaricaOrePotenziamentoDocente(Convert.ToInt32(doc.ID)).ToString();
                uc.lblOreEffettive.Text = "0";
                uc.lblOreTotali.Text = "0";

                uc.Tag = doc.ID;
                uc.Location = new Point(0, y);

                pnlOreDoc.Controls.Add(uc);
                dictDocenti[doc.ID] = uc;

                y += uc.Height + 5;

                if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
                {
                    uc.nudOrePot.Enabled = false;
                }
            }

            y += 15;

            //PRATICI
            foreach (ClsUtenteDL doc in docentiPraticiUsati)
            {
                ucOreDoc uc = new ucOreDoc();
                uc.lblDocente.Text = $"{doc.Nome} {doc.Cognome}";
                uc.lblOreDiCattedra.Text = ClsContrattoBL.RilevaOreContrattoDoc(doc.ID).ToString();
                uc.nudOrePot.Text = ClsAssegnareBL.CaricaOrePotenziamentoDocente(Convert.ToInt32(doc.ID)).ToString();
                uc.lblOreEffettive.Text = "0";
                uc.lblOreTotali.Text = "0";

                uc.Tag = doc.ID;
                uc.Location = new Point(0, y);

                pnlOreDoc.Controls.Add(uc);
                dictDocenti[doc.ID] = uc;

                y += uc.Height + 5;

                if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
                {
                    uc.nudOrePot.Enabled = false;
                }
            }

            AggiornaOreEffettive();
        }

        private void AggiornaOreEffettive()
        {
            // reset
            // Controls.OfType filtra i controlli del pannello restituendo solo ucOreDoc
            foreach (ucOreDoc uc in pnlOreDoc.Controls.OfType<ucOreDoc>())
            {
                uc.lblOreEffettive.Text = "0";
            }

            // ricalcolo
            foreach (UcAssegnazioni uc in pnlDipartimento.Controls.OfType<UcAssegnazioni>())
            {
                if (uc.cbDocentiTeorici.SelectedItem is ClsUtenteDL dt)
                {
                    foreach (ucOreDoc od in pnlOreDoc.Controls.OfType<ucOreDoc>())
                    {
                        if ((long)od.Tag == dt.ID)
                            od.lblOreEffettive.Text =
                                (int.Parse(od.lblOreEffettive.Text) +
                                 int.Parse(uc.lblOreTeoria.Text)).ToString();
                        if (Convert.ToInt32(od.lblOreTotali.Text) >= Convert.ToInt32(od.lblOreDiCattedra.Text))
                        {
                            od.lblOreEffettive.ForeColor = Color.Red;
                            od.lblOreTotali.ForeColor = Color.Red;
                        }
                    }
                }

                if (uc.cbDocentiItip.SelectedItem is ClsUtenteDL dp)
                {
                    foreach (ucOreDoc od in pnlOreDoc.Controls.OfType<ucOreDoc>())
                    {
                        if ((long)od.Tag == dp.ID)
                            od.lblOreEffettive.Text =
                                (int.Parse(od.lblOreEffettive.Text) +
                                 int.Parse(uc.lblOreLaboratorio.Text)).ToString();
                        if (Convert.ToInt32(od.lblOreTotali.Text) >= Convert.ToInt32(od.lblOreDiCattedra.Text))
                        {
                            od.lblOreEffettive.ForeColor = Color.Red;
                            od.lblOreEffettive.Font = new Font(od.lblOreEffettive.Font, FontStyle.Bold);

                            od.lblOreTotali.ForeColor = Color.Red;
                            od.lblOreTotali.Font = new Font(od.lblOreTotali.Font, FontStyle.Bold);
                        }
                    }
                }
            }

            // totali
            foreach (ucOreDoc uc in pnlOreDoc.Controls.OfType<ucOreDoc>())
            {
                int eff = int.Parse(uc.lblOreEffettive.Text);
                int pot = int.Parse(uc.nudOrePot.Text);

                uc.lblOreTotali.Text = (eff + pot).ToString();
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
            int oreDocenteTeorico = 0;
            int oreDocentePratico = 0;
            int oreTotaliXClasse = 0;
            int oreTotali = 0;

            int x = 0;
            int y = 0;

            int colonna = 0;

            ClsClasseDiConcorsoDL classeDiConcorso = new ClsClasseDiConcorsoDL();
            classeDiConcorso.ID = 1; // DA CAMBIARE

            for (riga = 0; riga < classi.Count; riga++)
            {
                oreTotaliXClasse = 0;
                ClsClasseDL classe = classi[riga];
                int annoClasse = classe.Anno; // serve per il confronto

                for (colonna = 0; colonna < disciplineUniche.Count; colonna++)
                {
                    string nomeDisciplina = disciplineUniche[colonna].Nome;

                    // Cerca la disciplina con questo nome e con anno uguale alla classe
                    ClsDisciplinaDL disciplinaGiusta = discipline
                        .FirstOrDefault(d => d.Nome == nomeDisciplina && d.Anno == annoClasse);

                    if (disciplinaGiusta != null)
                    {
                        UcAssegnazioni uc = new UcAssegnazioni();
                        List<ClsUtenteDL> docentiDiRiferimento = ClsAssegnareBL.CercaDocentiDiRiferimento(IDdipartimento, Convert.ToInt32(classe.ID), Convert.ToInt32(disciplinaGiusta.ID));
                        List<ClsUtenteDL> docentiPossibiliSostituti = ClsAssegnareBL.CercaDocentiPossibiliSostituti(IDdipartimento, Convert.ToInt32(classeDiConcorso.ID));
                        List<ClsUtenteDL> docenti = new List<ClsUtenteDL>();

                        if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
                        {
                            uc.cbDocentiTeorici.Enabled = false;
                            uc.cbDocentiItip.Enabled = false;
                            // nudOrePot.Enabled = false; -> fatto su LoadOreDoc()
                        }

                        foreach (ClsUtenteDL docente in docentiDiRiferimento)
                            docenti.Add(docente);

                        foreach (ClsUtenteDL docente in docentiPossibiliSostituti)
                        {
                            if (!docenti.Any(d => d.ID == docente.ID))
                                docenti.Add(docente);
                        }

                        List<ClsUtenteDL> teorici = new List<ClsUtenteDL>();
                        List<ClsUtenteDL> pratici = new List<ClsUtenteDL>();

                        foreach (ClsUtenteDL docente in docenti)
                        {
                            if (docente.TipoDocente == 'T')
                            {
                                teorici.Add(docente);
                            }
                            else if (docente.TipoDocente == 'L')
                            {
                                pratici.Add(docente);
                            }
                        }

                        foreach (ClsUtenteDL doc in teorici)
                            if (!docentiTeoriciUsati.Any(xx => xx.ID == doc.ID))
                                docentiTeoriciUsati.Add(doc);

                        foreach (ClsUtenteDL doc in pratici)
                            if (!docentiPraticiUsati.Any(xx => xx.ID == doc.ID))
                                docentiPraticiUsati.Add(doc);


                        if (teorici.Count > 0)
                        {
                            oreDocenteTeorico = disciplinaGiusta.OreTeoria + disciplinaGiusta.OreLaboratorio;
                            oreTotaliXClasse += oreDocenteTeorico;
                            uc.lblOreTeoria.Text = oreDocenteTeorico.ToString();
                        }

                        if (pratici.Count > 0)
                        {
                            oreDocentePratico = disciplinaGiusta.OreLaboratorio;
                            uc.lblOreLaboratorio.Text = oreDocentePratico.ToString();
                        }

                        uc.cbDocentiTeorici.DataSource = teorici;
                        uc.cbDocentiTeorici.DisplayMember = "cognome";
                        uc.cbDocentiTeorici.ValueMember = "ID";

                        uc.cbDocentiItip.DataSource = pratici;
                        uc.cbDocentiItip.DisplayMember = "cognome";
                        uc.cbDocentiItip.ValueMember = "ID";

                        ClsUtenteDL docenteTeorico = ClsAssegnareBL.MostraDocenteTeorico(IDdipartimento, Convert.ToInt32(classe.ID), Convert.ToInt32(disciplinaGiusta.ID));
                        ClsUtenteDL docentePratico = ClsAssegnareBL.MostraDocentePratico(IDdipartimento, Convert.ToInt32(classe.ID), Convert.ToInt32(disciplinaGiusta.ID));

                        if (docenteTeorico != null && teorici.Any(t => t.ID == docenteTeorico.ID))
                        {
                            uc.cbDocentiTeorici.SelectedValue = docenteTeorico.ID;
                        }
                        if (docentePratico != null && pratici.Any(p => p.ID == docentePratico.ID))
                        {
                            uc.cbDocentiItip.SelectedValue = docentePratico.ID;
                        }

                        uc.cbDocentiTeorici.SelectedIndexChanged += (s, e) => AggiornaOreEffettive();
                        uc.cbDocentiItip.SelectedIndexChanged += (s, e) => AggiornaOreEffettive();

                        

                        x = 10 + colonna * 225;
                        y = 72 + riga * 100;
                        uc.Location = new Point(x, y);

                        pnlDipartimento.Controls.Add(uc);

                        //uc.Refresh();
                    }                
                }
                UcOreTotalixClasse ucOreTotalixClasse = new UcOreTotalixClasse();
                ucOreTotalixClasse.lblOreTotalixClasse.Text = oreTotaliXClasse.ToString();

                x = 0;
                y = 72 + riga * 100;
                ucOreTotalixClasse.Location = new Point(x, y);
                pnlOre.Controls.Add(ucOreTotalixClasse);

                ucOreTotalixClasse.Refresh();

                oreTotali += oreTotaliXClasse;
            }

            LoadOreTotali(riga, oreTotali);
            LoadOreDoc();
        }

        private void LoadDiscipline(int IDdipartimento)
        {
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
            UcOre ucOre = new UcOre();
            ucOre.Location = new Point(0, 10);
            pnlOre.Controls.Add(ucOre);

            //ucOre.Refresh();
        }
        private void LoadClassi(int IDdipartimento)
        {
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
                this.UseWaitCursor = true;
                Application.DoEvents();

                IDdipartimento = cbDipartimenti.SelectedIndex + 1;

                await Task.Run(() =>
                {
                    classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento);
                    discipline = ClsDisciplinaBL.CaricaDisciplineDipartimento(IDdipartimento);
                });

                LoadClassi(IDdipartimento);
                LoadDiscipline(IDdipartimento);
                LoadAssegnazioni(IDdipartimento);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }
    }
}
