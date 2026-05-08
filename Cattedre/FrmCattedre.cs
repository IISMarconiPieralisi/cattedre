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
using System.Diagnostics;

namespace Cattedre
{
    public partial class FrmCattedre : Form
    {
        #region variabili globali
        #region liste & dizionari
        List<ClsClasseDL> classi = new List<ClsClasseDL>();
        List<ClsDipartimentoDL> dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
        List<ClsAnnoScolasticoDL> anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
        List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
        List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
        List<ClsDisciplinaDL> disciplinerilevate = new List<ClsDisciplinaDL>();
        List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
        List<ClsDisciplinaDL> disciplineUniche = new List<ClsDisciplinaDL>();
        List<ClsUtenteDL> docentiTeoriciUsati = new List<ClsUtenteDL>();
        List<ClsUtenteDL> docentiPraticiUsati = new List<ClsUtenteDL>();

        Dictionary<long, ucOreDoc> dictDocenti = new Dictionary<long, ucOreDoc>();

        List<(Control ctrl, int xOriginale)> _posizioniDiscipline = new List<(Control, int)>();
        List<(UcAssegnazioni ctrl, int xOriginale)> _posizioniAssegnazioni = new List<(UcAssegnazioni, int)>();
        #endregion
        //variabili globali
        ClsUtenteDL utenteLoggato;
        long IDdipartimento = 0;
        public long IDannoscolastico { get; set; } = 0;
        DataTable dtDocentiAssegnazioni;

        //location colonne header
        const int COL_DOCENTE = 6;
        const int COL_ORECATTEDRA = 105;
        const int COL_OREEFF = 208;
        const int COL_OREPOT = 284;

        //private ToolTip toolTipDiscipline;
        HScrollBar hScrollOrizzontale;
        #endregion
        #region Costruttore Load Show  complilamento form
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
            //pnlDipartimento.TabStop = true;
            //pnlDipartimento.TabIndex = 4;
            hScrollOrizzontale = new HScrollBar();
            hScrollOrizzontale.Height = 17;
            hScrollOrizzontale.Dock = DockStyle.Bottom; // si ancora in fondo a pnlCentrale
            hScrollOrizzontale.Scroll += HScrollOrizzontale_Scroll;
            pnlCentrale.Controls.Add(hScrollOrizzontale);

            pnlDiscipline.MouseWheel += PnlOrizzontale_MouseWheel;
            pnlDipartimento.MouseWheel += PnlOrizzontale_MouseWheel;

            pnlCentrale.Resize += (s, ev) => { if (dictDocenti.Count > 0) SincronizzaScroll(); };

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

            LoadAnniScolastici();
        }
        private void FrmCattedre_Shown(object sender, EventArgs e)
        {
            if (utenteLoggato.TipoUtente == "C" || utenteLoggato.TipoUtente == "D") //|| utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
            {
                PopolaControlliGrafici();
                cbDipartimenti.Enabled = false;
            }
            if (utenteLoggato.TipoUtente == "A")
                btGeneraASsucc.Enabled = false;
        }
        private async void PopolaControlliGrafici()
        {
            List<long> indirizziTrovati = new List<long>();
            this.Cursor = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                discipline = ClsDisciplinaBL.CaricaDisciplineAnnoScolasticoDipartimento(
                IDannoscolastico, IDdipartimento, out indirizziTrovati);
                classi = ClsClasseBL.CaricaClassiIndirizzo(indirizziTrovati, IDannoscolastico);

                // Aggiungi le classi di altri indirizzi che fanno discipline di questo dipartimento
                List<ClsClasseDL> classiEsterne = ClsClasseBL
                    .CaricaClassiEsterneCheFannoDisciplineDipartimento(IDdipartimento, IDannoscolastico);

                foreach (var classe in classiEsterne)
                {
                    if (!classi.Any(c => c.ID == classe.ID))
                        classi.Add(classe);
                }

                classi = classi.OrderBy(c => c.Sigla).ToList();
            });

            LoadDiscipline(IDdipartimento);
            LoadClassi(indirizziTrovati, IDannoscolastico);
            LoadAssegnazioni(IDdipartimento, IDannoscolastico, out dtDocentiAssegnazioni);
            LoadInfoNumCattedre(IDdipartimento, dtDocentiAssegnazioni);
            SincronizzaScrollDopoLayout();

            this.Cursor = Cursors.Default;
        }
        #endregion
        #region gestione Ore Potenziamento e effettive
        private void ControllaOrePotenzamentoTotali()
        {
            List<ClsClasseDiConcorsoDL> cdcPotTutte = ClsClasseDiConcorsoBL
                .CaricaCDCperDisciplina(IDdipartimento)
                .Where(x => x.nomeDisciplina.Contains("otenziamento"))
                .Select(x => x.cdc)
                .GroupBy(c => c.ID)
                .Select(g => g.First())
                .ToList();

            foreach (var cdcPot in cdcPotTutte)
            {
                int oreMax = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimentoPerCDC(
                    IDdipartimento, cdcPot.ID);

                int orePotTotali = dictDocenti
                    .Where(kvp =>
                    {
                        var cdcDoc = ClsRichiedereBL.RilevaCDCDocente(kvp.Key);
                        return cdcDoc.Any(c => c.ID == cdcPot.ID);
                    })
                    .Sum(kvp => (int)kvp.Value.nudOrePot.Value);

                if (orePotTotali > oreMax)
                {
                    MessageBox.Show(
                        $"Superato il limite ore potenziamento per CDC {cdcPot.Livello}: {oreMax}",
                        "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                uc.lblDocente.ForeColor = Color.Black;
                uc.lblOreEffettive.ForeColor = Color.Black;
                uc.lblOreTotali.ForeColor = Color.Black;

                uc.lblDocente.Font = new Font(uc.lblDocente.Font, FontStyle.Regular);
                uc.lblOreEffettive.Font = new Font(uc.lblOreEffettive.Font, FontStyle.Regular);
                uc.lblOreTotali.Font = new Font(uc.lblOreTotali.Font, FontStyle.Regular);
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
                int pot = (int)uc.nudOrePot.Value;
                int cattedra = int.Parse(uc.lblOreDiCattedra.Text);

                int totale = eff + pot;
                uc.lblOreTotali.Text = totale.ToString();

                if (totale > cattedra)
                {
                    uc.lblDocente.ForeColor = Color.Orange;
                    uc.lblOreEffettive.ForeColor = Color.Orange;
                    uc.lblOreTotali.ForeColor = Color.Orange;

                    uc.lblDocente.Font = new Font(uc.lblDocente.Font, FontStyle.Bold);
                    uc.lblOreEffettive.Font = new Font(uc.lblOreEffettive.Font, FontStyle.Bold);
                    uc.lblOreTotali.Font = new Font(uc.lblOreTotali.Font, FontStyle.Bold);
                }
                else if (totale < cattedra)
                {
                    uc.lblDocente.ForeColor = Color.Red;
                    uc.lblOreEffettive.ForeColor = Color.Red;
                    uc.lblOreTotali.ForeColor = Color.Red;

                    uc.lblDocente.Font = new Font(uc.lblDocente.Font, FontStyle.Bold);
                    uc.lblOreEffettive.Font = new Font(uc.lblOreEffettive.Font, FontStyle.Bold);
                    uc.lblOreTotali.Font = new Font(uc.lblOreTotali.Font, FontStyle.Bold);
                }
            }
            Label lblTotTeo = pnlOreDoc.Controls.Find("lblTotaleTeorici", false).FirstOrDefault() as Label;
            Label lblTotPra = pnlOreDoc.Controls.Find("lblTotalePratici", false).FirstOrDefault() as Label;
            Label lblTotPotTeo = pnlOreDoc.Controls.Find("lblTotalePotTeorici", false).FirstOrDefault() as Label;
            Label lblTotPotPra = pnlOreDoc.Controls.Find("lblTotalePotPratici", false).FirstOrDefault() as Label;

            if (lblTotTeo != null || lblTotPra != null)
            {
                int totTeorici = 0, totPratici = 0;
                int totPotTeorici = 0, totPotPratici = 0;
                int oreMaxTeorici = 0, oreMaxPratici = 0;

                foreach (var kvp in dictDocenti)
                {
                    var cdcs = ClsRichiedereBL.RilevaCDCDocente(kvp.Key);
                    bool richiedeLaurea = cdcs.Any(c => c.AbilitazioniRichieste != null &&
                                                        c.AbilitazioniRichieste.ToLower().Contains("laurea"));
                    int tot = int.Parse(kvp.Value.lblOreTotali.Text);
                    int pot = (int)kvp.Value.nudOrePot.Value;

                    if (richiedeLaurea)
                    {
                        totTeorici += tot;
                        totPotTeorici += pot;

                        // calcola oreMax solo una volta (prendo la CDC di potenziamento del docente)
                        if (oreMaxTeorici == 0)
                        {
                            List<ClsClasseDiConcorsoDL> cdcPot = ClsClasseDiConcorsoBL
                                .CaricaCDCperDisciplina(IDdipartimento)
                                .Where(x => x.nomeDisciplina.Contains("otenziamento"))
                                .Select(x => x.cdc)
                                .ToList();

                            ClsClasseDiConcorsoDL cdcPotDocente = cdcs
                                .FirstOrDefault(c => cdcPot.Any(p => p.ID == c.ID));

                            if (cdcPotDocente != null)
                                oreMaxTeorici = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimentoPerCDC(
                                    IDdipartimento, cdcPotDocente.ID);
                        }
                    }
                    else
                    {
                        totPratici += tot;
                        totPotPratici += pot;

                        if (oreMaxPratici == 0)
                        {
                            List<ClsClasseDiConcorsoDL> cdcPot = ClsClasseDiConcorsoBL
                                .CaricaCDCperDisciplina(IDdipartimento)
                                .Where(x => x.nomeDisciplina.Contains("otenziamento"))
                                .Select(x => x.cdc)
                                .ToList();

                            ClsClasseDiConcorsoDL cdcPotDocente = cdcs
                                .FirstOrDefault(c => cdcPot.Any(p => p.ID == c.ID));

                            if (cdcPotDocente != null)
                                oreMaxPratici = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimentoPerCDC(
                                    IDdipartimento, cdcPotDocente.ID);
                        }
                    }
                }

                if (lblTotTeo != null) lblTotTeo.Text = $"{totTeorici}";
                if (lblTotPra != null) lblTotPra.Text = $"{totPratici}";

                if (lblTotPotTeo != null)
                    lblTotPotTeo.Text = oreMaxTeorici > 0 ? $"{totPotTeorici}/{oreMaxTeorici}" : $"{totPotTeorici}";
                if (lblTotPotPra != null)
                    lblTotPotPra.Text = oreMaxPratici > 0 ? $"{totPotPratici}/{oreMaxPratici}" : $"{totPotPratici}";
            }
        }
        #endregion
        #region SelectedIndex Selettori grafici
        private void cbDipartimenti_Format(object sender, ListControlConvertEventArgs e)
        {
            var Dipartimento = (ClsDipartimentoDL)e.ListItem;

            const int maxLength = 15;
            string nome = Dipartimento.Nome;

            if (nome.Length > maxLength)
                nome = nome.Substring(0, maxLength) + ".";

            e.Value = nome;
        }

        private void cbAnniScolastici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnniScolastici.SelectedValue == null) return;
            if (cbAnniScolastici.SelectedIndex < 0) return;

            if (cbAnniScolastici.SelectedIndex > -1)
                IDannoscolastico = Convert.ToInt32(cbAnniScolastici.SelectedValue);
            PopolaControlliGrafici();
        }
        private void btCaricaDipartimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbDipartimenti.SelectedValue == null) return;
                if (cbDipartimenti.SelectedIndex < 0) return;

                Application.DoEvents();
                IDdipartimento = Convert.ToInt32(cbDipartimenti.SelectedValue);
                PulisciDipartimento();
                PopolaControlliGrafici();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore:{ex.Message}. \nRiprovare!", "Riprovare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region load e SelectedIndex Selettori Dipartimento & Anni


        private void LoadDipartimenti()
        {
            this.cbDipartimenti.SelectedIndexChanged -= new System.EventHandler(this.btCaricaDipartimento_SelectedIndexChanged);
            cbDipartimenti.DataSource = dipartimenti;
            cbDipartimenti.DisplayMember = "Nome";
            cbDipartimenti.ValueMember = "ID";

            ClsDipartimentoDL dipartimento =ClsDipartimentoBL.UtenteCoordinaDipartimento(utenteLoggato.ID);
            if (dipartimento!=null && dipartimento.ID>0)
            {
                IDdipartimento = dipartimento.ID;
                cbDipartimenti.SelectedValue = IDdipartimento;

            }
            else
                cbDipartimenti.SelectedIndex = -1;

            this.cbDipartimenti.SelectedIndexChanged += new System.EventHandler(this.btCaricaDipartimento_SelectedIndexChanged);

        }

        private void LoadAnniScolastici()
        {
            this.cbAnniScolastici.SelectedIndexChanged -= new System.EventHandler(this.cbAnniScolastici_SelectedIndexChanged);

            cbAnniScolastici.DataSource = anniscolastici;
            cbAnniScolastici.DisplayMember = "Sigla";
            cbAnniScolastici.ValueMember = "ID";
            IDannoscolastico = ClsAnnoScolasticoBL.TrovaIDannoscolastico();
            if (IDannoscolastico >= 0)
                cbAnniScolastici.SelectedValue = IDannoscolastico;
            else
                cbAnniScolastici.SelectedIndex = -1;

            this.cbAnniScolastici.SelectedIndexChanged += new System.EventHandler(this.cbAnniScolastici_SelectedIndexChanged);

        }
        #endregion
        #region load Controlli grafici
        private void LoadInfoNumCattedre(long idDip, DataTable docenti)
        {
            //pnlInfoNumCattedre.Controls.Clear();
            //int y = 10;

            //Label lblPrinc = new Label();
            //lblPrinc.AutoSize = true;
            //lblPrinc.Location = new Point(10, y);
            //lblPrinc.Text = "INFO NUM CATTEDRE X CDC";
            //lblPrinc.Font = new Font(lblPrinc.Font, FontStyle.Bold);
            //pnlInfoNumCattedre.Controls.Add(lblPrinc);

            //y = 50;
            //int numDocentiEstratti = docenti.AsEnumerable()
            //    .Select(r => Convert.ToInt64(r["IDutente"]))
            //    .Distinct()
            //    .Count();

            //Label lblNumProfEstratti = new Label();
            //lblNumProfEstratti.AutoSize = true;
            //lblNumProfEstratti.Location = new Point(10, y);
            //lblNumProfEstratti.Text = "Num Docenti Assegnati: " + numDocentiEstratti;
            //lblNumProfEstratti.Font = new Font(lblNumProfEstratti.Font.FontFamily, 10f, lblNumProfEstratti.Font.Style);
            //pnlInfoNumCattedre.Controls.Add(lblNumProfEstratti);

            //y = 100;
            //List<ClsDisciplinaDL> discipline = ClsDisciplinaBL
            //    .CaricaDisciplineDipartimento(Convert.ToInt32(idDip));

            //List<ClsClasseDiConcorsoDL> cdcUniche = discipline
            //    .SelectMany(d => ClsRichiedereBL.RilevaCDCDiscipina(d.ID))
            //    .GroupBy(c => c.ID)
            //    .Select(g => g.First())
            //    .OrderBy(c => c.Livello)
            //    .ToList();

            //foreach (ClsClasseDiConcorsoDL cdc in cdcUniche)
            //{
            //    int numCattedreDiritto = ClsDotareBL.TrovaNumCattedreDiDiritto(cdc.ID, ClsAnnoScolasticoBL.RilevaIDanno(annoscolasticoselezionato));
            //    int numCattedreFatto = ClsDotareBL.TrovaNumCattedreDiFatto(cdc.ID, ClsAnnoScolasticoBL.RilevaIDanno(annoscolasticoselezionato));

            //    // Riga 1: "Livello → Num Cattedre di Fatto: X"
            //    Label lbl = new Label();
            //    lbl.AutoSize = true;
            //    lbl.Location = new Point(10, y);
            //    lbl.Text = $"{cdc.Livello} → Num Cattedre di Fatto: {numCattedreFatto}";
            //    pnlInfoNumCattedre.Controls.Add(lbl);
            //    y += 20;

            //    // Riga 2
            //    Label lblInfo = new Label();
            //    lblInfo.AutoSize = true;
            //    lblInfo.Location = new Point(10, y);
            //    if (numDocentiEstratti == numCattedreFatto)
            //    {
            //        lblInfo.Text = "CATTEDRE COPERTE";
            //        lblInfo.ForeColor = Color.Green;
            //    }
            //    else if (numDocentiEstratti < numCattedreFatto)
            //    {
            //        lblInfo.Text = "CATTEDRE SCOPERTE";
            //        lblInfo.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        lblInfo.Text = "CATTEDRE SOVRAFFOLLATE";
            //        lblInfo.ForeColor = Color.Red;
            //    }
            //    pnlInfoNumCattedre.Controls.Add(lblInfo);
            //    y += 25;

            //    // Riga 3: "Num Cattedre di Diritto: X"
            //    Label lblNumCattedreDiritto = new Label();
            //    lblNumCattedreDiritto.AutoSize = true;
            //    lblNumCattedreDiritto.Location = new Point(10, y);
            //    lblNumCattedreDiritto.Text = $"Num Cattedre di Diritto: {numCattedreDiritto}";
            //    pnlInfoNumCattedre.Controls.Add(lblNumCattedreDiritto);
            //    y += 40;  // ampio spazio prima del blocco CDC successivo
            //}
        }
        
        private void LoadAssegnazioni(long IDdipartimento, long IDannoscolastico, out DataTable docenti)
        {
            pnlDipartimento.Controls
                .OfType<UcAssegnazioni>()
                .ToList()
                .ForEach(c => { pnlDipartimento.Controls.Remove(c); c.Dispose(); });

            //pnlInfoNumCattedre.Controls.Clear();
            docentiTeoriciUsati.Clear();
            docentiPraticiUsati.Clear();

            // QUERY UNICA x recuperare tutti i docenti del dipartimento
            docenti = ClsAssegnareBL
                .CaricaDocentiConAssegnazioni(IDdipartimento, IDannoscolastico);

            // Aggiunti i docenti esterni già assegnati
            DataTable esterniAssegnati = ClsAssegnareBL.CaricaDocentiEsterniAssegnati(IDdipartimento, IDannoscolastico);
            foreach (DataRow row in esterniAssegnati.Rows)
                docenti.ImportRow(row);

            //int tabIndex = 5;
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
                    uc.DocentiData = docenti;

                    List<ClsUtenteDL> teorici = new List<ClsUtenteDL>();
                    teorici.Add(new ClsUtenteDL { ID = 0, Cognome = "", Nome = "", Colore = "" });
                    teorici.AddRange(docenti.AsEnumerable()
                    .Where(r => r["tipoDocente"].ToString() == "T"
                             && Convert.ToInt32(r["isInterno"]) == 1)
                    .Select(r => new ClsUtenteDL
                    {
                        ID = Convert.ToInt64(r["IDutente"]),
                        Nome = r.Field<string>("nome"),
                        Cognome = r.Field<string>("cognome"),
                        TipoDocente = 'T',
                        Colore = r["colore"] == DBNull.Value ? "" : r["colore"].ToString()
                    })
                    .GroupBy(_x => _x.ID)
                    .Select(g => g.First())
                    .ToList());

                    // docenti pratici
                    List<ClsUtenteDL> pratici = new List<ClsUtenteDL>();
                    pratici.Add(new ClsUtenteDL { ID = 0, Cognome = "", Nome = "", Colore = "" }); // item vuoto
                    pratici.AddRange(docenti.AsEnumerable()
                    .Where(r => r["tipoDocente"].ToString() == "L"
                             && Convert.ToInt32(r["isInterno"]) == 1)
                    .Select(r => new ClsUtenteDL
                    {
                        ID = Convert.ToInt64(r["IDutente"]),
                        Nome = r.Field<string>("nome"),
                        Cognome = r.Field<string>("cognome"),
                        TipoDocente = 'L',
                        Colore = r["colore"] == DBNull.Value ? "" : r["colore"].ToString()
                    })
                    .GroupBy(_x => _x.ID)
                    .Select(g => g.First())
                    .ToList());

                    // Docenti esterni abilitati per questa disciplina specifica
                    List<ClsUtenteDL> utentiEsterni = ClsRichiedereBL.RilevaUtentiDisciplina(disciplina.ID);

                    foreach (var esterno in utentiEsterni)
                    {
                        // Evita duplicati (potrebbe già essere nel dipartimento)
                        if (esterno.TipoDocente == 'T' && !teorici.Any(d => d.ID == esterno.ID))
                            teorici.Add(esterno);
                        else if (esterno.TipoDocente == 'L' && !pratici.Any(d => d.ID == esterno.ID))
                            pratici.Add(esterno);
                    }

                    uc.cbDocentiTeorici.DataSource = teorici;
                    uc.cbDocentiTeorici.DisplayMember = "DisplayText";
                    uc.cbDocentiTeorici.ValueMember = "ID";

                    uc.cbDocentiItip.DataSource = pratici;
                    uc.cbDocentiItip.DisplayMember = "DisplayText";
                    uc.cbDocentiItip.ValueMember = "ID";

                    uc.ImpostaColoriCombo(uc.cbDocentiTeorici);
                    uc.ImpostaColoriCombo(uc.cbDocentiItip);

                    if (disciplina.OreLaboratorio == 0)
                    {
                        uc.cbDocentiItip.Visible = false;
                        uc.label2.Visible = false;
                        uc.label4.Visible = false;
                        uc.lblOreLaboratorio.Visible = false;
                        uc.cbDocentiItip.SelectedIndex = 0;
                    }
                    else
                    {
                        uc.cbDocentiItip.Enabled = true;
                    }

                    // docente già assegnato (in memoria)
                    var assegnazioni = docenti.AsEnumerable()
                    .Where(r =>
                        r["IDclasse"] != DBNull.Value &&
                        r["IDdisciplina"] != DBNull.Value &&
                        Convert.ToInt64(r["IDclasse"]) == classe.ID &&
                        Convert.ToInt64(r["IDdisciplina"]) == disciplina.ID
                    ).ToList();

                    if (assegnazioni.Any())
                    {
                        foreach (var assegnazione in assegnazioni)
                        {
                            long idDoc = Convert.ToInt64(assegnazione["IDutente"]);
                            string tipoString = assegnazione["tipoDocente"]?.ToString();
                            char tipo = string.IsNullOrEmpty(tipoString) ? ' ' : tipoString[0];

                            if (tipo == 'T')
                                uc.cbDocentiTeorici.SelectedValue = idDoc;
                            else if (tipo == 'L')
                                uc.cbDocentiItip.SelectedValue = idDoc;
                        }
                    }
                    else
                    {
                        uc.cbDocentiTeorici.SelectedIndex = 0;
                        uc.cbDocentiItip.SelectedIndex = 0;
                    }

                    // ore
                    uc.lblOreTeoria.Text = disciplina.OreTeoria.ToString();
                    uc.lblOreLaboratorio.Text = disciplina.OreLaboratorio.ToString();

                    oreTotaliClasse += disciplina.OreTeoria + disciplina.OreLaboratorio;

                    // eventi
                    uc.cbDocentiTeorici.SelectedIndexChanged += (s, e) =>
                    {
                        AggiornaOreEffettive();
                        if (uc.cbDocentiTeorici.SelectedItem is ClsUtenteDL u)
                            ClsAssegnareBL.SalvaCattedra(classe.ID, IDannoscolastico, disciplina.ID, u.ID, 'T');
                    };

                    uc.cbDocentiItip.SelectedIndexChanged += (s, e) =>
                    {
                        AggiornaOreEffettive();
                        if (uc.cbDocentiItip.SelectedItem is ClsUtenteDL u)
                            ClsAssegnareBL.SalvaCattedra(classe.ID, IDannoscolastico, disciplina.ID, u.ID, 'L');
                    };

                    UcDisciplina ucDisciplinaRif = pnlDiscipline.Controls
                    .OfType<UcDisciplina>()
                    .ElementAtOrDefault(colonna);

                    UcClasse ucClasseRif = pnlClassi.Controls
                    .OfType<UcClasse>()
                    .ElementAtOrDefault(riga);

                    int x, y;
                    if (ucDisciplinaRif != null)
                    {
                        x = ucDisciplinaRif.Left + (ucDisciplinaRif.Width - uc.Width) / 2;
                    }
                    else
                    {
                        x = 20 + colonna * 170; // fallback
                    }

                    if (ucClasseRif != null)
                    {
                        int offsetVerticale = pnlClassi.Top - pnlDipartimento.Top;
                        y = ucClasseRif.Top + (ucClasseRif.Height - uc.Height) / 2 + offsetVerticale;
                    }
                    else
                    {
                        y = 10 + riga * 100; // fallback
                    }

                    uc.Location = new Point(x, y);

                    //NON FUNZIONA IL TAB
                    //uc.TabStop = true;
                    //uc.cbDocentiTeorici.TabStop = true;
                    //uc.cbDocentiItip.TabStop = true;
                    //uc.cbDocentiTeorici.TabIndex = tabIndex++;
                    //uc.cbDocentiItip.TabIndex = tabIndex++;
                    CollegaScrollComboBox(uc);
                    pnlDipartimento.Controls.Add(uc);
                    pnlDipartimento.Refresh();

                    if (utenteLoggato.TipoUtente == "A" || utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "D")
                    {
                        uc.cbDocentiItip.Enabled = false;
                        uc.cbDocentiTeorici.Enabled = false;
                    }
                }

                oreTotaliGenerali += oreTotaliClasse;
            }

            LoadOreDoc(IDannoscolastico);
            AggiornaOreEffettive();
        }

        private void LoadDiscipline(long IDdipartimento)
        {
            foreach (UcDisciplina uc in pnlDiscipline.Controls.OfType<UcDisciplina>().ToList())
            {
                pnlDiscipline.Controls.Remove(uc);
                uc.Dispose();
            }
            disciplineUniche.Clear();

            // discipline è già popolata dal Task.Run, NON richiamare il BL

            List<string> nomiUsati = new List<string>();
            foreach (ClsDisciplinaDL d in discipline)
            {
                if (!nomiUsati.Contains(d.Nome))
                {
                    nomiUsati.Add(d.Nome);
                    disciplineUniche.Add(d);
                }
            }

            int x = 10;
            int y = 7;
            ToolTip toolTipDiscipline = new ToolTip();
            toolTipDiscipline.ShowAlways = true;

            for (int i = 0; i < disciplineUniche.Count; i++)
            {
                string nomeCompleto = disciplineUniche[i].Nome;
                string nomeTagliato = nomeCompleto?.Length > 15 ? nomeCompleto.Substring(0, 15) + "." : nomeCompleto;
                ClsDisciplinaDL disciplinaDaMostrare = new ClsDisciplinaDL(disciplineUniche[i], nomeTagliato);

                UcDisciplina ucDisciplina = new UcDisciplina(disciplinaDaMostrare, nomeCompleto);
                ucDisciplina.Location = new Point(x, y);
                pnlDiscipline.Controls.Add(ucDisciplina);

                x += ucDisciplina.Width + 10;
            }
        }
        private void LoadClassi(List<long> IDindirizzi, long IDannoscolastico)
        {
            foreach (UcClasse uc in pnlClassi.Controls.OfType<UcClasse>().ToList())
            {
                pnlClassi.Controls.Remove(uc);
                uc.Dispose();
            }

            // classi è già popolata dal Task.Run, NON richiamare il BL

            int x = 10;
            int y = 10;
            for (int i = 0; i < classi.Count; i++)
            {
                UcClasse ucClasse = new UcClasse(classi[i]);
                ucClasse.Location = new Point(x, y);
                pnlClassi.Controls.Add(ucClasse);
                ucClasse.Refresh();
                y += ucClasse.Height + 10;
            }
        }
        private Panel LoadPanelHeaderCDC(ClsClasseDiConcorsoDL cdc, long IDannoscolastico)
        {
            int numCattedreDiFatto = ClsDotareBL.TrovaNumCattedreDiFatto(cdc.ID, IDannoscolastico);
            int numCattedreDiDiritto = ClsDotareBL.TrovaNumCattedreDiDiritto(cdc.ID, IDannoscolastico);

            int numDocentiAssegnati = dtDocentiAssegnazioni.AsEnumerable()
                .Where(r => r["IDutente"] != DBNull.Value)
                .Select(r => Convert.ToInt64(r["IDutente"]))
                .Distinct()
                .Count(id => ClsRichiedereBL.RilevaCDCDocente(id).Any(c => c.ID == cdc.ID));

            string statoTesto;
            Color statoColore;

            if (numDocentiAssegnati == numCattedreDiFatto)
            {
                statoTesto = "COPERTE";
                statoColore = Color.Green;
            }
            else if (numDocentiAssegnati < numCattedreDiFatto)
            {
                statoTesto = "SCOPERTE";
                statoColore = Color.Red;
            }
            else
            {
                statoTesto = "SOVRAFFOLLATE";
                statoColore = Color.OrangeRed;
            }

            int offsetSinistro = 0;

            Panel pnl = new Panel
            {
                Height = 26,
                Width = pnlOreDoc.ClientSize.Width - 2,
                BackColor = Color.FromArgb(230, 235, 245), // sfondo leggermente azzurrino per distinguerlo
                BorderStyle = BorderStyle.None               // gestiamo il bordo con Paint
            };

            // Bordo personalizzato: linea sopra e sotto più marcata
            pnl.Paint += (s, e) =>
            {
                using (Pen penBordo = new Pen(Color.SteelBlue, 2))
                {
                    e.Graphics.DrawLine(penBordo, 0, 0, pnl.Width, 0);                        // bordo superiore
                    e.Graphics.DrawLine(penBordo, 0, pnl.Height - 1, pnl.Width, pnl.Height - 1); // bordo inferiore
                }
                using (Pen penLato = new Pen(Color.SteelBlue, 3))
                {
                    e.Graphics.DrawLine(penLato, 0, 0, 0, pnl.Height); // bordo sinistro più spesso (accento)
                }
            };

            Label lblCDC = new Label
            {
                Text = cdc.Livello,
                Font = new Font(Font, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                AutoSize = false,
                Width = 75,
                Height = 22,
                Location = new Point(COL_DOCENTE, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblFatto = new Label
            {
                Text = $"Fatto: {numCattedreDiFatto}",
                AutoSize = false,
                Width = 65,
                Height = 22,
                Location = new Point(COL_ORECATTEDRA + 25, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblDiritto = new Label
            {
                Text = $"Diritto: {numCattedreDiDiritto}",
                AutoSize = false,
                Width = 75,
                Height = 22,
                Location = new Point(COL_OREEFF, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblStato = new Label
            {
                Text = statoTesto,
                ForeColor = statoColore,
                Font = new Font(Font, FontStyle.Bold),
                AutoSize = false,
                Width = 110,
                Height = 22,
                Location = new Point(COL_OREPOT, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnl.Controls.AddRange(new Control[] { lblCDC, lblFatto, lblDiritto, lblStato });

            // Applica l'offset nel chiamante: in LoadOreDoc usa new Point(offsetSinistro, y)
            pnl.Tag = offsetSinistro;

            return pnl;
        }

        private void LoadOreDoc(long IDannoscolastico)
        {
            // Rimuove solo i controlli dinamici (ucOreDoc e label totali),
            // lasciando intatte le label header del designer
            if (utenteLoggato.TipoUtente == "C" || utenteLoggato.TipoUtente == "A" || utenteLoggato.TipoUtente == "P")
            {
                var daRimuovere = pnlOreDoc.Controls
                .Cast<Control>()
                .Where(c => c.Tag?.ToString() != "header")
                .ToList();

                foreach (var c in daRimuovere)
                {
                    pnlOreDoc.Controls.Remove(c);
                    c.Dispose();
                }
            }
            dictDocenti.Clear();

            if (dtDocentiAssegnazioni == null || dtDocentiAssegnazioni.Rows.Count == 0)
                return;

            int y = 45;

            // Recupero docenti distinti dal DataTable
            List<ClsUtenteDL> docenti = dtDocentiAssegnazioni.AsEnumerable()
                .Where(r =>
                    r["isInterno"] != DBNull.Value &&
                    Convert.ToInt32(r["isInterno"]) == 1)
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
                .OrderBy(d =>
                {
                    var cdcs = ClsRichiedereBL.RilevaCDCDocente(d.ID);
                    return cdcs.Any(c => c.AbilitazioniRichieste != null &&
                                         c.AbilitazioniRichieste.ToLower().Contains("laurea")) ? 0 : 1;
                })
                .ThenBy(d => d.TipoDocente)
                .ThenBy(d => d.Cognome)
                .ToList();

            // Cache CDC per evitare query ripetute
            Dictionary<long, List<ClsClasseDiConcorsoDL>> cacheCDC = new Dictionary<long, List<ClsClasseDiConcorsoDL>>();
            foreach (var doc in docenti)
            {
                cacheCDC[doc.ID] = ClsRichiedereBL.RilevaCDCDocente(doc.ID);
            }

            // Suddivido in teorici e pratici
            List<ClsUtenteDL> docentiTeorici = docenti
                .Where(d =>
                {
                    var cdcs = cacheCDC[d.ID];
                    return cdcs.Any(c => c.AbilitazioniRichieste != null &&
                                         c.AbilitazioniRichieste.ToLower().Contains("laurea"));
                })
                .OrderBy(d => d.Cognome)
                .ToList();

            List<ClsUtenteDL> docentiPratici = docenti
                .Where(d =>
                {
                    var cdcs = cacheCDC[d.ID];
                    return !cdcs.Any(c => c.AbilitazioniRichieste != null &&
                                          c.AbilitazioniRichieste.ToLower().Contains("laurea"));
                })
                .OrderBy(d => d.Cognome)
                .ToList();

            Label lblTotaleTeorici = null;
            Label lblTotalePratici = null;

            // BLOCCO TEORICI
            if (docentiTeorici.Any())
            {
                // Ricavo la CDC del primo teorico per l'header
                var cdcTeorici = cacheCDC[docentiTeorici.First().ID].FirstOrDefault();

                if (cdcTeorici != null)
                {
                    Panel headerTeorici = LoadPanelHeaderCDC(cdcTeorici, IDannoscolastico);
                    int offset = headerTeorici.Tag is int o ? o : 0;
                    headerTeorici.Location = new Point(0, y);
                    pnlOreDoc.Controls.Add(headerTeorici);
                    y += headerTeorici.Height + 4;
                }
                else
                {
                    // Fallback: label semplice
                    Label lblFallback = new Label
                    {
                        AutoSize = true,
                        Font = new Font(Font, FontStyle.Bold),
                        Text = "Teorici",
                        Location = new Point(8, y)
                    };
                    pnlOreDoc.Controls.Add(lblFallback);
                    y += lblFallback.Height + 4;
                }

                foreach (var doc in docentiTeorici)
                {
                    ucOreDoc uc = CreaUcOreDoc(doc, IDannoscolastico, cacheCDC);
                    uc.Location = new Point(0, y);
                    pnlOreDoc.Controls.Add(uc);
                    dictDocenti[doc.ID] = uc;
                    y += uc.Height + 2;
                }

                lblTotaleTeorici = new Label();
                lblTotaleTeorici.AutoSize = true;
                lblTotaleTeorici.Font = new Font(lblTotaleTeorici.Font, FontStyle.Bold);
                lblTotaleTeorici.Text = "0";
                lblTotaleTeorici.Name = "lblTotaleTeorici";
                lblTotaleTeorici.Location = new Point(367, y + 5);
                pnlOreDoc.Controls.Add(lblTotaleTeorici);


                Label lblTotPotTeorici = new Label();
                lblTotPotTeorici.AutoSize = false;
                lblTotPotTeorici.Width = 60;
                lblTotPotTeorici.Font = new Font(lblTotPotTeorici.Font, FontStyle.Bold);
                lblTotPotTeorici.Text = "0";
                lblTotPotTeorici.Name = "lblTotalePotTeorici";
                lblTotPotTeorici.TextAlign = ContentAlignment.MiddleCenter;
                lblTotPotTeorici.Location = new Point(COL_OREPOT, y);
                pnlOreDoc.Controls.Add(lblTotPotTeorici);

                Label lblTotLabelTeorici = new Label();
                lblTotLabelTeorici.AutoSize = true;
                lblTotLabelTeorici.Font = new Font(lblTotLabelTeorici.Font, FontStyle.Bold);
                lblTotLabelTeorici.Text = "Totale:";
                lblTotLabelTeorici.Location = new Point(213, y + 5);
                pnlOreDoc.Controls.Add(lblTotLabelTeorici);

                y += lblTotaleTeorici.Height + 15;
            }

            // BLOCCO PRATICI
            if (docentiPratici.Any())
            {
                y += 10; // spazio extra tra i due gruppi

                var cdcPratici = cacheCDC[docentiPratici.First().ID].FirstOrDefault();

                if (cdcPratici != null)
                {
                    Panel headerTeorici = LoadPanelHeaderCDC(cdcPratici, IDannoscolastico);
                    int offset = headerTeorici.Tag is int o ? o : 0;
                    headerTeorici.Location = new Point(0, y);
                    pnlOreDoc.Controls.Add(headerTeorici);
                    y += headerTeorici.Height + 4;
                }
                else
                {
                    Label lblFallback = new Label
                    {
                        AutoSize = true,
                        Font = new Font(Font, FontStyle.Bold),
                        Text = "Pratici",
                        Location = new Point(300, y)
                    };
                    pnlOreDoc.Controls.Add(lblFallback);
                    y += lblFallback.Height + 4;
                }

                foreach (var doc in docentiPratici)
                {
                    ucOreDoc uc = CreaUcOreDoc(doc, IDannoscolastico, cacheCDC);
                    uc.Location = new Point(0, y);
                    pnlOreDoc.Controls.Add(uc);
                    dictDocenti[doc.ID] = uc;
                    y += uc.Height + 2;
                }

                lblTotalePratici = new Label();
                lblTotalePratici.AutoSize = true;
                lblTotalePratici.Font = new Font(lblTotalePratici.Font, FontStyle.Bold);
                lblTotalePratici.Text = "0";
                lblTotalePratici.Name = "lblTotalePratici";
                lblTotalePratici.Location = new Point(367, y + 5);
                pnlOreDoc.Controls.Add(lblTotalePratici);

                Label lblTotPotPratici = new Label();
                lblTotPotPratici.AutoSize = false;
                lblTotPotPratici.Width = 60;
                lblTotPotPratici.Font = new Font(lblTotPotPratici.Font, FontStyle.Bold);
                lblTotPotPratici.Text = "0";
                lblTotPotPratici.Name = "lblTotalePotPratici";
                lblTotPotPratici.TextAlign = ContentAlignment.MiddleCenter;
                lblTotPotPratici.Location = new Point(COL_OREPOT, y);
                pnlOreDoc.Controls.Add(lblTotPotPratici);

                Label lblTotLabelPratici = new Label();
                lblTotLabelPratici.AutoSize = true;
                lblTotLabelPratici.Font = new Font(lblTotLabelPratici.Font, FontStyle.Bold);
                lblTotLabelPratici.Text = "Totale:";
                lblTotLabelPratici.Location = new Point(213, y + 5);
                pnlOreDoc.Controls.Add(lblTotLabelPratici);
            }

            AggiornaOreEffettive();
            ControllaOrePotenzamentoTotali();
        }

        // ── METODO HELPER: crea e configura un ucOreDoc per un docente ──
        private ucOreDoc CreaUcOreDoc(ClsUtenteDL doc, long IDannoscolastico, Dictionary<long, List<ClsClasseDiConcorsoDL>> cacheCDC)
        {
            ucOreDoc uc = new ucOreDoc();
            try
            {
                uc.lblDocente.Text = doc.DisplayText;
                uc.lblOreDiCattedra.Text = ClsContrattoBL.RilevaOreContrattoDoc(doc.ID).ToString();
                int orePot = ClsAssegnareBL.RilevaOrePotDocente(doc.ID, IDannoscolastico);
                List<ClsClasseDiConcorsoDL> cdcPotenziamento = ClsClasseDiConcorsoBL.RilevaIDCDCPotenziamentoDipartimento(IDdipartimento);
                uc.CDCPotenziamento = cdcPotenziamento;
                uc.nudOrePot.Value = orePot;
                uc.lblOreEffettive.Text = "0";
                uc.lblOreTotali.Text = "0";
                uc.Tag = doc.ID;
                uc.IDdipartimento = IDdipartimento;
                uc.Inizializza(IDannoscolastico);

                List<ClsClasseDiConcorsoDL> cdcDocente = cacheCDC[doc.ID];

                bool docenteAbilitatoAlPotenziamento = cdcDocente.Any(cdcDoc =>cdcPotenziamento.Any(cdcPot => cdcPot.ID == cdcDoc.ID));

                if (docenteAbilitatoAlPotenziamento)
                {
                    ClsClasseDiConcorsoDL cdcPotDocente = cdcDocente
                        .FirstOrDefault(cdcDoc => cdcPotenziamento.Any(cdcPot => cdcPot.ID == cdcDoc.ID));

                    if (cdcPotDocente != null)
                    {
                        int oreMaxNud = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimentoPerCDC(
                            IDdipartimento, cdcPotDocente.ID);
                        uc.nudOrePot.Maximum = oreMaxNud;
                    }
                }

                // Disabilita modifica per Preside o Admin
                if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A" || !docenteAbilitatoAlPotenziamento)
                    uc.nudOrePot.Enabled = false;

                // Evento aggiornamento ore potenziamento
                uc.DictDocenti = dictDocenti;
                uc.CacheCDC = cacheCDC;
                uc.ImpostaValorePrec(orePot);
                uc.OrePotValide += (s, e) => AggiornaOreEffettive();
            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}. \nRiprovare!", "Riprovare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return uc;
        }

        #endregion
        #region Gestione Scroll
        private void SincronizzaScrollDopoLayout()
        {
            EventHandler handler = null;
            handler = (s, ev) =>
            {
                Application.Idle -= handler; // esegui una volta sola
                SalvaPosizioniOriginali();
                SincronizzaScroll();
            };
            Application.Idle += handler;
        }
        private void SalvaPosizioniOriginali()
        {
            _posizioniDiscipline = pnlDiscipline.Controls
                .Cast<Control>()
                .Select(c => (c, c.Left))
                .ToList();

            _posizioniAssegnazioni = pnlDipartimento.Controls
                .OfType<UcAssegnazioni>()
                .Select(c => (c, c.Left))
                .ToList();
        }
        private void CollegaScrollComboBox(UcAssegnazioni uc)
        {
            foreach (Control ctrl in uc.Controls)
            {
                if (ctrl is ComboBox cb)
                {
                    cb.MouseWheel += (s, e) =>
                    {
                        ((HandledMouseEventArgs)e).Handled = true;

                        if (ModifierKeys == Keys.Shift && hScrollOrizzontale.Enabled)
                        {
                            // Scroll orizzontale
                            int nuovoValore = hScrollOrizzontale.Value - e.Delta / 3;
                            nuovoValore = Math.Max(hScrollOrizzontale.Minimum,
                                          Math.Min(nuovoValore, hScrollOrizzontale.Maximum - hScrollOrizzontale.LargeChange + 1));
                            hScrollOrizzontale.Value = nuovoValore;
                            HScrollOrizzontale_Scroll(hScrollOrizzontale,
                                new ScrollEventArgs(ScrollEventType.ThumbPosition, nuovoValore));
                        }
                        else
                        {
                            // Scroll verticale
                            int delta = -e.Delta;
                            int nuovoScroll = pnlCentrale.VerticalScroll.Value + delta;
                            nuovoScroll = Math.Max(pnlCentrale.VerticalScroll.Minimum,
                                          Math.Min(nuovoScroll, pnlCentrale.VerticalScroll.Maximum));
                            pnlCentrale.VerticalScroll.Value = nuovoScroll;
                            pnlCentrale.PerformLayout();
                        }
                    };
                }
            }
        }
        private void HScrollOrizzontale_Scroll(object sender, ScrollEventArgs e)
        {
            int offset = e.NewValue;

            foreach (var (ctrl, xOrig) in _posizioniDiscipline)
                ctrl.Left = xOrig - offset;

            foreach (var (ctrl, xOrig) in _posizioniAssegnazioni)
                ctrl.Left = xOrig - offset;
        }
        private void PnlOrizzontale_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Shift && hScrollOrizzontale.Enabled)
            {
                // blocca lo scroll verticale
                ((HandledMouseEventArgs)e).Handled = true;

                int nuovoValore = hScrollOrizzontale.Value - e.Delta / 3;
                nuovoValore = Math.Max(hScrollOrizzontale.Minimum,
                              Math.Min(nuovoValore, hScrollOrizzontale.Maximum - hScrollOrizzontale.LargeChange + 1));
                hScrollOrizzontale.Value = nuovoValore;
                HScrollOrizzontale_Scroll(hScrollOrizzontale,
                    new ScrollEventArgs(ScrollEventType.ThumbPosition, nuovoValore));
            }
        }
        private void SincronizzaScroll()
        {
            int altezzaTotale = classi.Count * 100 + 80;

            pnlClassi.Height = altezzaTotale;
            pnlDipartimento.Height = altezzaTotale;

            pnlCentrale.AutoScroll = true;
            pnlCentrale.AutoScrollMinSize = new Size(0, altezzaTotale + 30);

            pnlDipartimento.AutoScroll = false;
            pnlDiscipline.AutoScroll = false;

            // Reset posizione orizzontale
            pnlDiscipline.Left = 0;
            pnlDipartimento.Left = 0;

            // Calcola larghezza contenuto partendo da x=10 (padding iniziale) + margine finale generoso
            int larghezzaContenuto = 10; // padding iniziale (da LoadDiscipline: int x = 10)
            foreach (UcDisciplina u in pnlDiscipline.Controls.OfType<UcDisciplina>())
                larghezzaContenuto += u.Width + 10;
            larghezzaContenuto += 75; // margine finale extra

            // Larghezza visibile
            int larghezzaVisibile = pnlDiscipline.ClientSize.Width;

            if (larghezzaContenuto > larghezzaVisibile)
            {
                int scrollRange = larghezzaContenuto - larghezzaVisibile;

                hScrollOrizzontale.Minimum = 0;
                hScrollOrizzontale.LargeChange = Math.Max(1, larghezzaVisibile / 3);
                hScrollOrizzontale.Maximum = scrollRange + hScrollOrizzontale.LargeChange - 1;
                hScrollOrizzontale.SmallChange = 20;
                hScrollOrizzontale.Enabled = true;
                hScrollOrizzontale.Value = Math.Max(
                    hScrollOrizzontale.Minimum,
                    Math.Min(hScrollOrizzontale.Value, scrollRange));
            }
            else
            {
                hScrollOrizzontale.Enabled = false;
                hScrollOrizzontale.Value = 0;

                foreach (var (ctrl, xOrig) in _posizioniDiscipline)
                    ctrl.Left = xOrig;
                foreach (var (ctrl, xOrig) in _posizioniAssegnazioni)
                    ctrl.Left = xOrig;
            }

            HScrollOrizzontale_Scroll(hScrollOrizzontale,
                new ScrollEventArgs(ScrollEventType.ThumbPosition, hScrollOrizzontale.Value));
        }
        private void PulisciDipartimento()
        {
            var daRimuovere = pnlOreDoc.Controls
                .Cast<Control>()
                .Where(c => c.Tag?.ToString() != "header")
                .ToList();

            // Prima rimuovi TUTTI dal pannello
            foreach (var c in daRimuovere)
                pnlOreDoc.Controls.Remove(c);

            // Poi fai Dispose separatamente
            foreach (var c in daRimuovere)
                c.Dispose();

            // Reset delle collezioni
            disciplineUniche.Clear();
            docentiTeoriciUsati.Clear();
            docentiPraticiUsati.Clear();
            classi.Clear();
            discipline.Clear();
            dictDocenti.Clear();
        }
        #endregion
        #region BtGenera Anno successivo & generaFileWord
        private void btGeneraASsucc_Click(object sender, EventArgs e)
        {
            try
            {
                ClsAnnoScolasticoDL annoSuccessivo = ClsAnnoScolasticoBL.TrovaAnnoSuccessivo(IDannoscolastico);

                if (annoSuccessivo == null)
                   throw new Exception("Anno successivo non trovato");

                // Prima carica le discipline per ricavare gli indirizzi
                List<ClsDisciplinaDL> disciplineSuccessivo = ClsDisciplinaBL
                    .CaricaDisciplineAnnoScolasticoDipartimento(annoSuccessivo.ID, IDdipartimento, out List<long> indirizziTrovati);

                // Poi carica le classi per indirizzo
                List<ClsClasseDL> classiAnnoSuccessivo = ClsClasseBL.CaricaClassiIndirizzo(indirizziTrovati, annoSuccessivo.ID);

                if (classiAnnoSuccessivo == null || classiAnnoSuccessivo.Count == 0)
                    throw new Exception("Non esistono classi per l'anno scolastico successivo");

                bool esistonoAssegnazioniAnnoSuccessivo = ClsAssegnareBL.EsistonoAssegnazioniAnnoSuccessivo(annoSuccessivo.ID);

                if (utenteLoggato.TipoUtente == "C" && !esistonoAssegnazioniAnnoSuccessivo)
                {
                    DialogResult dr = MessageBox.Show(
                        "Vuoi generare le cattedre per l'anno successivo?",
                        "Generazione",
                        MessageBoxButtons.YesNo);

                    if (dr != DialogResult.Yes)
                        return;

                    if (IDannoscolastico == annoSuccessivo.ID)
                       throw new Exception("Anno non valido"); 
                    

                    ClsAssegnareBL.GeneraCattedreAnnoSuccessivo(IDdipartimento, IDannoscolastico, annoSuccessivo.ID);
                    //messaggio di sucesso
                    MessageBox.Show("Cattedre generate con successo", "GENERAZIONE RIUSCITA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Cattedre per anno successivo già generate"); //eccezione attenzione
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+".", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }


        private void btGeneraWord_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath=string.Empty;
                //controlli iniziali di errori
                if (IDannoscolastico <= 0) throw new Exception("Selezionare un Anno scolastico valido");
                if(IDdipartimento<=0) throw new Exception("Selezionare un dipartimento valido");

                //creazione oggetti IDannoscolastico e dipartimento dai loro ID
                ClsAnnoScolasticoDL anno=ClsAnnoScolasticoBL.CercaAnnoScolastico(IDannoscolastico);
                ClsDipartimentoDL dipartimento = ClsDipartimentoBL.CaricaDipartimento(IDdipartimento);

                //gestione percorso file
                filePath = ClsGenerazioneWord.GestisciPercorsoFile(anno,dipartimento);
                if (string.IsNullOrEmpty(filePath)) throw new Exception("Seleziona un percorso file per la creazione del .docx");

                //metodo del effettiva creazione del file
                ClsGenerazioneWord.PreparazioneCreazioneFile(anno,dipartimento,filePath);

                //finistra di successo e richiesta di apertura del file
                DialogResult dg = MessageBox.Show("File creato con successo, vuoi Aprirlo?", "successo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg==DialogResult.Yes)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true 
                    };
                    Process.Start(startInfo);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Errore durante la compilazione del File: \n{ex.Message}\nRiprovare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion
    }
}
