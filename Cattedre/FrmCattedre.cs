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
        List<ClsClasseDL> classi = new List<ClsClasseDL>();
        List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
        List<ClsAnnoScolasticoDL> anniscolastici = new List<ClsAnnoScolasticoDL>();
        List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
        List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
        List<ClsDisciplinaDL> disciplinerilevate = new List<ClsDisciplinaDL>();
        List<ClsClasseDL> classirilevate = new List<ClsClasseDL>();
        List<ClsDisciplinaDL> disciplineUniche = new List<ClsDisciplinaDL>();
        List<ClsUtenteDL> docentiTeoriciUsati = new List<ClsUtenteDL>();
        List<ClsUtenteDL> docentiPraticiUsati = new List<ClsUtenteDL>();

        Dictionary<long, ucOreDoc> dictDocenti = new Dictionary<long, ucOreDoc>();

        ClsUtenteDL utenteLoggato;

        int IDdipartimento = 0;
        long IDannoscolastico = 0;
        string annoscolasticoselezionato = "";
        DataTable dtDocentiAssegnazioni;

        //private ToolTip toolTipDiscipline;

        public string Annoscolasticoselezionato { get => annoscolasticoselezionato; set => annoscolasticoselezionato = value; }

        public FrmCattedre(ClsUtenteDL utente)
        {
            InitializeComponent();
            utenteLoggato = utente;

            //toolTipDiscipline = new ToolTip();
        }

        private void FrmCattedre_Load(object sender, EventArgs e)
        {
            //pnlDipartimento.AutoScroll = true;
            //pnlDipartimento.HorizontalScroll.Enabled = true;
            //pnlDipartimento.VerticalScroll.Enabled = false;
            //pnlDipartimento.TabStop = true;
            //pnlDipartimento.TabIndex = 4;

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

        private async void FrmCattedre_Shown(object sender, EventArgs e)
        {
            if (utenteLoggato.TipoUtente == "C" || utenteLoggato.TipoUtente == "D") //|| utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A")
            {
                this.Cursor = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    IDdipartimento = ClsUtenteBL.TrovaIDdipartimento(utenteLoggato.ID);
                    IDannoscolastico = ClsAnnoScolasticoBL.TrovaIDannoscolastico();
                    classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento, IDannoscolastico);
                    discipline = ClsDisciplinaBL.CaricaDisciplineDipartimento(IDdipartimento);
                });

                LoadClassi(IDdipartimento, IDannoscolastico);
                LoadDiscipline(IDdipartimento);
                LoadAssegnazioni(IDdipartimento, IDannoscolastico, out dtDocentiAssegnazioni);
                LoadInfoNumCattedre(IDdipartimento, dtDocentiAssegnazioni);

                this.Cursor = Cursors.Default;
            }
            if (utenteLoggato.TipoUtente == "C" || utenteLoggato.TipoUtente == "D")
            {
                cbDipartimenti.SelectedIndex = IDdipartimento - 1;
                cbDipartimenti.Enabled = false;
            }
            if (utenteLoggato.TipoUtente == "A")
                btGeneraASsucc.Enabled = false;

            string _siglaAnnoScolasticoCorrente = ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(IDannoscolastico);
            cbAnniScolastici.SelectedItem = _siglaAnnoScolasticoCorrente.ToString();
        }

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

        private Panel CreaPanelHeaderCDC(ClsClasseDiConcorsoDL cdc, long IDannoscolastico)
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

            int offsetSinistro = 12; // ← indentazione verso destra

            Panel pnl = new Panel
            {
                Height = 26,
                Width = (pnlOreDoc.ClientSize.Width > offsetSinistro + 10
                                  ? pnlOreDoc.ClientSize.Width - offsetSinistro - 6
                                  : 330),
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
                Location = new Point(6, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblFatto = new Label
            {
                Text = $"Fatto: {numCattedreDiFatto}",
                AutoSize = false,
                Width = 65,
                Height = 22,
                Location = new Point(83, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblDiritto = new Label
            {
                Text = $"Diritto: {numCattedreDiDiritto}",
                AutoSize = false,
                Width = 75,
                Height = 22,
                Location = new Point(150, 2),
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
                Location = new Point(227, 2),
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnl.Controls.AddRange(new Control[] { lblCDC, lblFatto, lblDiritto, lblStato });

            // Applica l'offset nel chiamante: in LoadOreDoc usa new Point(offsetSinistro, y)
            pnl.Tag = offsetSinistro;

            return pnl;
        }

        private void LoadOreDoc(long IDannoscolastico)
        {
            pnlOreDoc.Controls.Clear();
            dictDocenti.Clear();

            if (dtDocentiAssegnazioni == null || dtDocentiAssegnazioni.Rows.Count == 0)
                return;

            int y = 45;

            // Recupero docenti distinti dal DataTable
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
                .ToList();

            List<ClsUtenteDL> docentiPratici = docenti
                .Where(d =>
                {
                    var cdcs = cacheCDC[d.ID];
                    return !cdcs.Any(c => c.AbilitazioniRichieste != null &&
                                          c.AbilitazioniRichieste.ToLower().Contains("laurea"));
                })
                .ToList();

            Label lblTotaleTeorici = null;
            Label lblTotalePratici = null;

            // ── BLOCCO TEORICI ──────────────────────────────────────────
            if (docentiTeorici.Any())
            {
                // Ricavo la CDC del primo teorico per l'header
                var cdcTeorici = cacheCDC[docentiTeorici.First().ID].FirstOrDefault();

                if (cdcTeorici != null)
                {
                    Panel headerTeorici = CreaPanelHeaderCDC(cdcTeorici, IDannoscolastico);
                    int offset = headerTeorici.Tag is int o ? o : 0;
                    headerTeorici.Location = new Point(offset, y);  // ← spostato a destra
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
                lblTotPotTeorici.AutoSize = true;
                lblTotPotTeorici.Font = new Font(lblTotPotTeorici.Font, FontStyle.Bold);
                lblTotPotTeorici.Text = "0";
                lblTotPotTeorici.Name = "lblTotalePotTeorici";
                lblTotPotTeorici.Location = new Point(305, y + 5);
                pnlOreDoc.Controls.Add(lblTotPotTeorici);

                Label lblTotLabelTeorici = new Label();
                lblTotLabelTeorici.AutoSize = true;
                lblTotLabelTeorici.Font = new Font(lblTotLabelTeorici.Font, FontStyle.Bold);
                lblTotLabelTeorici.Text = "Totale:";
                lblTotLabelTeorici.Location = new Point(213, y + 5);
                pnlOreDoc.Controls.Add(lblTotLabelTeorici);

                y += lblTotaleTeorici.Height + 15;
            }

            // ── BLOCCO PRATICI ──────────────────────────────────────────
            if (docentiPratici.Any())
            {
                y += 10; // spazio extra tra i due gruppi

                var cdcPratici = cacheCDC[docentiPratici.First().ID].FirstOrDefault();

                if (cdcPratici != null)
                {
                    Panel headerTeorici = CreaPanelHeaderCDC(cdcPratici, IDannoscolastico);
                    int offset = headerTeorici.Tag is int o ? o : 0;
                    headerTeorici.Location = new Point(offset, y);
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
                lblTotPotPratici.AutoSize = true;
                lblTotPotPratici.Font = new Font(lblTotPotPratici.Font, FontStyle.Bold);
                lblTotPotPratici.Text = "0";
                lblTotPotPratici.Name = "lblTotalePotPratici";
                lblTotPotPratici.Location = new Point(305, y + 5);
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

            uc.lblDocente.Text = $"{doc.Nome} {doc.Cognome}";
            uc.lblOreDiCattedra.Text = ClsContrattoBL.RilevaOreContrattoDoc(doc.ID).ToString();

            int orePot = dtDocentiAssegnazioni.AsEnumerable()
                .Where(r => r["IDutente"] != DBNull.Value &&
                            Convert.ToInt64(r["IDutente"]) == doc.ID &&
                            r["IDannoscolastico"] != DBNull.Value &&
                            Convert.ToInt64(r["IDannoscolastico"]) == IDannoscolastico)
                .Sum(r => r["oreSpeciali"] == DBNull.Value ? 0 : Convert.ToInt32(r["oreSpeciali"]));

            uc.nudOrePot.Value = orePot;
            uc.lblOreEffettive.Text = "0";
            uc.lblOreTotali.Text = "0";
            uc.Tag = doc.ID;
            uc.IDdipartimento = IDdipartimento;

            List<ClsClasseDiConcorsoDL> cdcPotenziamento = ClsClasseDiConcorsoBL
            .CaricaCDCperDisciplina(IDdipartimento)
            .Where(x => x.nomeDisciplina.Contains("otenziamento"))
            .Select(x => x.cdc)
            .ToList();
            uc.CDCPotenziamento = cdcPotenziamento;

            List<ClsClasseDiConcorsoDL> cdcDocente = cacheCDC[doc.ID];

            bool docenteAbilitatoAlPotenziamento = cdcDocente.Any(cdcDoc =>
            cdcPotenziamento.Any(cdcPot => cdcPot.ID == cdcDoc.ID)
            );

            // Disabilita modifica per Preside o Admin
            if (utenteLoggato.TipoUtente == "P" || utenteLoggato.TipoUtente == "A" || !docenteAbilitatoAlPotenziamento)
                uc.nudOrePot.Enabled = false;

            // Evento aggiornamento ore potenziamento
            int valorePrec = orePot;

            uc.nudOrePot.ValueChanged += (s, e) =>
            {
                int oreMax = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimento(IDdipartimento);
                int orePotTotaliInserite = dictDocenti.Values.Sum(u => (int)u.nudOrePot.Value);

                if (orePotTotaliInserite > oreMax)
                {
                    MessageBox.Show(
                        "Superato il limite di ore di potenziamento consentite: " + oreMax,
                        "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    uc.nudOrePot.Value = valorePrec; // ripristino
                }
                else
                {
                    valorePrec = (int)uc.nudOrePot.Value;
                    AggiornaOreEffettive();
                }
            };

            return uc;
        }

        private void ControllaOrePotenzamentoTotali()
        {
            int oreMax = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimento(IDdipartimento);

            int orePotTotaliInserite = dictDocenti.Values
                .Sum(uc => (int)uc.nudOrePot.Value);

            if (orePotTotaliInserite > oreMax)
            {
                MessageBox.Show("Superato il limite di ore di potenziamento consentite - " + oreMax, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }

                    else
                    {
                        totPratici += tot;
                        totPotPratici += pot;
                    }
                }

                if (lblTotTeo != null) lblTotTeo.Text = $"{totTeorici}";
                if (lblTotPra != null) lblTotPra.Text = $"{totPratici}";
                if (lblTotPotTeo != null) lblTotPotTeo.Text = $"{totPotTeorici}";
                if (lblTotPotPra != null) lblTotPotPra.Text = $"{totPotPratici}";
            }
        }

        //private void LoadOreTotali(int riga, int oreTotali)
        //{
        //    ucOreTotali ucOreTotali = new ucOreTotali();
        //    ucOreTotali.lblOreTotali.Text = oreTotali.ToString();
        //    int x = 0;
        //    int y;
        //    y = 72 + riga * 100;

        //    ucOreTotali.Location = new Point(x, y);
        //    //pnlInfoNumCattedre.Controls.Add(ucOreTotali);

        //    ucOreTotali.Refresh();
        //}

        private void LoadDipartimenti()
        {
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();

            for (int i = 0; i < dipartimenti.Count; i++)
            {
                cbDipartimenti.Items.Add(dipartimenti[i].Nome);
            }
        }

        private void LoadAnniScolastici()
        {
            anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();

            for (int i = 0; i < anniscolastici.Count; i++)
                cbAnniScolastici.Items.Add(anniscolastici[i].Sigla);
        }

        private void LoadAssegnazioni(int IDdipartimento, long IDannoscolastico, out DataTable docenti)
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

            int tabIndex = 5;
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
                        .Where(r => r["tipoDocente"].ToString() == "T")
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
                        .Where(r => r["tipoDocente"].ToString() == "L")
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


                    uc.cbDocentiTeorici.DataSource = teorici;
                    uc.cbDocentiTeorici.DisplayMember = "DisplayText";
                    uc.cbDocentiTeorici.ValueMember = "ID";

                    uc.cbDocentiItip.DataSource = pratici;
                    uc.cbDocentiItip.DisplayMember = "DisplayText";
                    uc.cbDocentiItip.ValueMember = "ID";

                    uc.ImpostaColoriCombo(uc.cbDocentiTeorici);
                    uc.ImpostaColoriCombo(uc.cbDocentiItip);

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

                    UcDisciplina ucDisciplinaRif = pnlDipartimento.Controls
                    .OfType<UcDisciplina>()
                    .ElementAtOrDefault(colonna);

                    int x, y;
                    if (ucDisciplinaRif != null)
                    {
                        // Centra la UcAssegnazioni rispetto alla UcDisciplina corrispondente
                        x = ucDisciplinaRif.Left + (ucDisciplinaRif.Width - uc.Width) / 2;
                    }
                    else
                    {
                        x = 20 + colonna * 170; // fallback
                    }
                    y = 72 + riga * 100;
                    uc.Location = new Point(x, y);

                    //NON FUNZIONA IL TAB
                    //uc.TabStop = true;
                    //uc.cbDocentiTeorici.TabStop = true;
                    //uc.cbDocentiItip.TabStop = true;
                    //uc.cbDocentiTeorici.TabIndex = tabIndex++;
                    //uc.cbDocentiItip.TabIndex = tabIndex++;
                    pnlDipartimento.Controls.Add(uc);

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

            // Discipline uniche nel pnlDisciplina
            int x = 10;
            int y = 10;

            ToolTip toolTipDiscipline = new ToolTip();
            toolTipDiscipline.ShowAlways = true;

            for (int i = 0; i < disciplineUniche.Count; i++)
            {
                string nomeCompleto = disciplineUniche[i].Nome;

                // nome tagliato
                string nomeTagliato = nomeCompleto?.Length > 15 ? nomeCompleto.Substring(0, 15) + "." : nomeCompleto;
                ClsDisciplinaDL disciplinaDaMostrare = new ClsDisciplinaDL(disciplineUniche[i], nomeTagliato);

                UcDisciplina ucDisciplina = new UcDisciplina(disciplinaDaMostrare, nomeCompleto);
                ucDisciplina.Location = new Point(x, y);
                pnlDipartimento.Controls.Add(ucDisciplina);

                x += ucDisciplina.Width + 10;
            }
            //UcOre ucOre = new UcOre();
            //ucOre.Location = new Point(0, 10);
            //pnlOre.Controls.Add(ucOre);

            //ucOre.Refresh();
        }
        private void LoadClassi(int IDdipartimento, long Idannoscolastico)
        {
            foreach (UcClasse uc in pnlClassi.Controls.OfType<UcClasse>().ToList())
            {
                pnlClassi.Controls.Remove(uc);
                uc.Dispose();
            }

            classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento, Idannoscolastico);

            int x = 10;
            int y = 72;
            for (int i = 0; i < classi.Count; i++)
            {
                UcClasse ucClasse = new UcClasse(classi[i]);
                ucClasse.Location = new Point(x, y);
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
            //pnlInfoNumCattedre.Controls.Clear();
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

        private async void btCaricaDipartimento_Click_1(object sender, EventArgs e) //evento SelectedIndexChanged di cbDipartimenti
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
                    //IDannoscolastico = cbAnniScolastici.SelectedIndex + 1;

                    PulisciDipartimento();

                    await Task.Run(() =>
                    {
                        IDannoscolastico = ClsAnnoScolasticoBL.TrovaIDannoscolastico();
                        classi = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento, IDannoscolastico);
                        discipline = ClsDisciplinaBL.CaricaDisciplineDipartimento(IDdipartimento);
                    });

                    LoadClassi(IDdipartimento, IDannoscolastico);
                    LoadDiscipline(IDdipartimento);
                    LoadAssegnazioni(IDdipartimento, IDannoscolastico, out dtDocentiAssegnazioni);
                    LoadInfoNumCattedre(IDdipartimento, dtDocentiAssegnazioni);

                    string _siglaAnnoScolasticoCorrente = ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(IDannoscolastico);
                    cbAnniScolastici.SelectedItem = _siglaAnnoScolasticoCorrente.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore:{ex.Message}. \nRiprovare!", "riprovare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void btGeneraASsucc_Click(object sender, EventArgs e)
        {
            string siglaAnno = cbAnniScolastici.SelectedItem.ToString();

            ClsAnnoScolasticoDL annoCorrente =
                ClsAnnoScolasticoBL.CercaAnnoScolastico(siglaAnno);

            ClsAnnoScolasticoDL annoSuccessivo =
                ClsAnnoScolasticoBL.TrovaAnnoSuccessivo(annoCorrente.ID);

            if (annoSuccessivo == null)
            {
                MessageBox.Show("Anno successivo non trovato", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ClsClasseDL> classiAnnoSuccessivo = ClsClasseBL.CaricaClassiDipartimento(IDdipartimento, annoSuccessivo.ID);
            if (classiAnnoSuccessivo == null || classiAnnoSuccessivo.Count == 0)
            {
                MessageBox.Show("Non esistono classi per l'anno scolastico successivo. Impossibile generare le cattedre.", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esistonoAssegnazioniAnnoSuccessivo = ClsAssegnareBL.EsistonoAssegnazioniAnnoSuccessivo(annoSuccessivo.ID);

            if (utenteLoggato.TipoUtente == "C" && !esistonoAssegnazioniAnnoSuccessivo)
            {
                DialogResult dr = MessageBox.Show(
                    "Vuoi generare le cattedre per l'anno successivo?",
                    "Generazione",
                    MessageBoxButtons.YesNo);

                if (dr != DialogResult.Yes)
                    return;

                if (annoCorrente.ID == annoSuccessivo.ID)
                {
                    MessageBox.Show("Anno non valido", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClsAssegnareBL.GeneraCattedreAnnoSuccessivo(
                    IDdipartimento,
                    (int)annoCorrente.ID,
                    (int)annoSuccessivo.ID);

                MessageBox.Show("Cattedre generate con successo", "GENERAZIONE RIUSCITA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cattedre per anno successivo già generate", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbAnniScolastici_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IDdipartimento = cbDipartimenti.SelectedIndex + 1;
            //IDannoscolastico = cbAnniScolastici.SelectedIndex + 1;

            Annoscolasticoselezionato = cbAnniScolastici.SelectedItem.ToString();
            ClsAnnoScolasticoDL annoscolastico = new ClsAnnoScolasticoDL();
            annoscolastico = ClsAnnoScolasticoBL.CercaAnnoScolastico(Annoscolasticoselezionato);
            LoadClassi(IDdipartimento, annoscolastico.ID);
            LoadAssegnazioni(IDdipartimento, annoscolastico.ID, out dtDocentiAssegnazioni);
            LoadInfoNumCattedre(IDdipartimento, dtDocentiAssegnazioni);
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
    }
}
