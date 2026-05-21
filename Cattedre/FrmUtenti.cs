using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cattedre
{
    public partial class FrmUtenti : Form
    {
        #region dizionari filtri
        Dictionary<string, string> mappaUtenti = new Dictionary<string, string>()
                {
                    { "Preside", "'P'" },
                    { "Amministratore", "'A'" },
                    { "Docente", "'D'" },
                    { "Coordinatore", "'C'" }
                };

        Dictionary<string, string> mappaContratto = new Dictionary<string, string>()
                {
                    { "Determinato", "'D'" },
                    { "Indeterminato", "'I'" }
                };

        Dictionary<string, string> mappaTipoDocente = new Dictionary<string, string>()
                {
                    { "Laboratorio", "'L'" },
                    { "Teorico", "'T'" }
                };
        #endregion
        public List<ClsUtenteDL> _utenti = new List<ClsUtenteDL>();
        Dictionary<string, List<string>> filtri = new Dictionary<string, List<string>>();

        private ClsUtenteDL _utenteLoggato;        

        public FrmUtenti(ClsUtenteDL utenteLoggato = null)
        {
            InitializeComponent();
            _utenteLoggato = utenteLoggato;
        }
        private void FrmUtenti_Load(object sender, EventArgs e)
        {
            cbDipartimento.DataSource = ClsDipartimentoBL.CaricaDipartimenti();
            cbDipartimento.ValueMember = "ID";
            cbDipartimento.DisplayMember = "Nome";
            cbDipartimento.SelectedIndex = -1;
            GestisciPermessi();
            CaricaListView();
        }

        private void CaricaListView()
        {
            _utenti = ClsUtenteBL.CaricaUtenti(filtri);
            lvUtenti.Items.Clear();

            foreach (ClsUtenteDL utente in _utenti)
            {
                //prendo un metodo che cerca il contratto in base all'id utente
                ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(utente.ID);
                ListViewItem lvi = new ListViewItem(utente.ID.ToString());
                
                lvi.SubItems.Add(utente.Cognome);
                lvi.SubItems.Add(utente.Nome);
                lvi.SubItems.Add(utente.Email);
                string _tipoDocente = (utente.TipoDocente == 'T') ? " teorico" : (utente.TipoDocente == 'L') ? " pratico" : string.Empty;
                switch (utente.TipoUtente)
                {
                    case "P":
                        lvi.SubItems.Add("preside");
                        break;
                    case "A":
                        lvi.SubItems.Add("amministratore");
                        break;
                    case "D":
                        lvi.SubItems.Add($"docente{_tipoDocente}");
                        break;
                    case "C":
                        lvi.SubItems.Add($"docente{_tipoDocente} coordinatore dipartimento");
                        break;
                }
                if (contratto != null)
                {
                    switch (contratto.TipoContratto)
                    {
                        case 'D':
                            lvi.SubItems.Add("Determinato");
                            break;
                        case 'I':
                            lvi.SubItems.Add("Indeterminato");
                            break;
                        default:
                            lvi.SubItems.Add("-");
                            break;
                    }
                    lvi.SubItems.Add(contratto.MonteOre.ToString());
                    lvi.SubItems.Add(contratto.DataInizioContratto.ToString("dd/MM/yyyy"));
                    if (contratto.DataFineContratto != null)
                        lvi.SubItems.Add(contratto.DataFineContratto?.ToString("dd/MM/yyyy"));
                    else
                        lvi.SubItems.Add("-");
                }
                else
                {
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                }
                lvi.Tag = utente.ID;

                lvUtenti.Items.Add(lvi);

            }
            tbNumRecord.Text = _utenti.Count().ToString();

        }

        private async void btInserisci_Click(object sender, EventArgs e)
        {
            //controllo utente se ha i permessi necessari
            if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato)) return;
            FrmUtente frmUtente = new FrmUtente(_utenteLoggato);
            DialogResult dr = frmUtente.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    this.Cursor = Cursors.WaitCursor;

                    ClsUtenteBL.InserisciUtente(frmUtente._utente); //l'utente che mando non ha un ID che creo quando lo inzializzo nel server
                    ClsUtenteDL utente = ClsUtenteBL.caricautenteByEmail(frmUtente._utente.Email); //essendo che l'email è univoca riesco a risalire anche all'id del utente in questo modo
                    await Task.WhenAll(
                         Task.Run(() =>
                         {
                             if (frmUtente._afferenze != null && frmUtente._afferenze.Count > 0)
                             {
                                 foreach (ClsAfferireDL afferire in frmUtente._afferenze)
                                 {
                                     afferire.IDutente = utente.ID;
                                     ClsAfferireBL.InserisciAfferire(afferire);
                                 }

                             }
                         }),
                         Task.Run(() =>
                          {
                              if (frmUtente._richieste != null && frmUtente._richieste.Count > 0)
                              {
                                  foreach (ClsRichiedereDL richiedere in frmUtente._richieste)
                                  {
                                      richiedere.IDutente = utente.ID;
                                      ClsRichiedereBL.InserisciRichiedere(richiedere);
                                  }

                              }
                          }),
                         Task.Run(() =>
                         {
                             if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C" || frmUtente._utente.TipoUtente == "A")
                             {
                                 frmUtente._contratto.IDutente = utente.ID;
                                 ClsContrattoBL.InserisciContratto(frmUtente._contratto, utente.ID);
                                 if (frmUtente._utente.TipoUtente == "C")
                                 {
                                     //se è un coordinatore di dipartimento devo aggiornare la tabella dipartimenti
                                     ClsDipartimentoBL.ModificaCoordinatoreDipartimento(frmUtente._dipartimento, utente.ID);

                                 }
                             }
                         })
                    );
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show($"Errore durante il inserimento:{ex.Message}", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }finally
                {
                    this.Cursor = Cursors.Arrow;
                }
                CaricaListView();
            }
        }
        private async void btModifica_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {
                if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato)) return;

                int indiceDaModificare = lvUtenti.SelectedIndices[0];
                FrmUtente frmUtente = new FrmUtente(_utenteLoggato);
                frmUtente._utente = _utenti[indiceDaModificare];
                frmUtente._utente.ID = _utenti[indiceDaModificare].ID;

                // caricamento dati in background prima di aprire il form
                List<ClsRichiedereDL> richiestePrima = new List<ClsRichiedereDL>();
                await Task.Run(() =>
                {
                    List<ClsAfferireDL> afferire = ClsAfferireBL.CaricaClassiAfferire(_utenti[indiceDaModificare].ID);
                    if (afferire != null && afferire.Count > 0)
                        frmUtente._afferenze = afferire;

                    List<ClsRichiedereDL> richiedere = ClsRichiedereBL.CaricaClassiRichiedereUtente(_utenti[indiceDaModificare].ID);
                    if (richiedere != null && richiedere.Count > 0)
                        frmUtente._richieste = richiedere;

                    ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(_utenti[indiceDaModificare].ID);
                    if (contratto != null)
                        frmUtente._contratto = contratto;

                    richiestePrima = ClsRichiedereBL.CaricaClassiRichiedereUtente(_utenti[indiceDaModificare].ID)
                        ?? new List<ClsRichiedereDL>();
                });

                DialogResult dr = frmUtente.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // sequenziale — deve finire prima degli altri
                        await Task.Run(() => ClsUtenteBL.ModificaUtente(frmUtente._utente, frmUtente._utente.ID));

                        if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C" || frmUtente._utente.TipoUtente == "A")
                        {
                            await Task.WhenAll(
                                Task.Run(() => ClsAfferireBL.ModificaAfferenze(frmUtente._utente.ID, frmUtente._afferenze)),
                                Task.Run(() => ClsRichiedereBL.ModificaRichiestaUtente(frmUtente._utente.ID, frmUtente._richieste)),
                                Task.Run(() =>
                                {
                                    ClsContrattoBL.ModificaContratto(frmUtente._contratto, frmUtente._utente.ID);
                                    if (frmUtente._utente.TipoUtente == "C")
                                        ClsDipartimentoBL.ModificaCoordinatoreDipartimento(frmUtente._dipartimento, frmUtente._utente.ID);
                                }),
                                Task.Run(() =>
                                {
                                    List<ClsRichiedereDL> cdcRimosse = richiestePrima
                                        .Where(prima => prima.IDclassediconcorso > 0 &&
                                            !(frmUtente._richieste ?? new List<ClsRichiedereDL>())
                                            .Any(dopo => dopo.IDclassediconcorso == prima.IDclassediconcorso))
                                        .ToList();
                                    foreach (var cdc in cdcRimosse)
                                        ClsAssegnareBL.EliminaAssegnazioniDocente(frmUtente._utente.ID, cdc.IDclassediconcorso);
                                })
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore durante il salvataggio: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                    CaricaListView();
                }
            }
            else
                MessageBox.Show("non è stato selezionato nessun utente, riprovare.", "Modifica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {
                //controllo utente se ha i permessi necessari
                if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato)) return;

                int indiceDaEliminare = lvUtenti.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvUtenti.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsDipartimentoBL.EliminaCoordinatoreDipartimento(idDaEliminare);
                    ClsUtenteBL.EliminaUtente(idDaEliminare);
                    _utenti = ClsUtenteBL.CaricaUtenti();

                }
                CaricaListView();

            }
        }

        #region filtri

        private void btFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                filtri.Clear();
                btAnnullaFiltra.Enabled = true;

                bool parametroSelezionato = false;

                parametroSelezionato |= AggiungiFiltro(filtri, "tipoUtente", CaricaElementiSelezionati(gbTipiUtenti, typeof(CheckBox)), mappaUtenti);
                parametroSelezionato |= AggiungiFiltro(filtri, "tipoDocente", CaricaElementiSelezionati(gBtipoDocente, typeof(RadioButton)), mappaTipoDocente);

                string NomeCognome = (tbRicerca.Text != "cognome nome" && !string.IsNullOrWhiteSpace(tbRicerca.Text)) ? tbRicerca.Text.Trim() : string.Empty;
                if (NomeCognome != string.Empty)
                {
                    string NomeCognomeFiltrati = NomeCognome.Replace(" ", "").ToLower();
                    filtri.Add("CONCAT(cognome,nome)", new List<string> { NomeCognomeFiltrati });
                    parametroSelezionato = true;
                }
                if(cbDipartimento.SelectedIndex>-1)
                {
                    filtri.Add("IDdipartimento", new List<string> { cbDipartimento.SelectedValue.ToString() });
                    parametroSelezionato = true;
                }
                if (parametroSelezionato)
                    CaricaListView();
                else
                    throw new Exception("Seleziona un parametro per la ricerca.");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n riprova", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool AggiungiFiltro(Dictionary<string, List<string>> filtri, string chiave, IEnumerable<string> selezionati, Dictionary<string, string> mappa)
        {
            var valori = selezionati.Where(item => mappa.ContainsKey(item)).Select(item => mappa[item]).ToList();
            if (valori.Any())
            {
                filtri.Add(chiave, valori);
                return true;
            }
            return false;
        }
        private List<string> CaricaElementiSelezionati(GroupBox gb, Type tipoControllo)
        {
            List<string> parametri = new List<string>();

            foreach (Control control in gb.Controls)
            {
                // Verifica se il controllo è del tipo specificato
                if (control.GetType() == tipoControllo || control.GetType().IsSubclassOf(tipoControllo))
                {
                    // Per RadioButton e CheckBox hanno la proprietà Checked
                    if (control is RadioButton radio && radio.Checked)
                        parametri.Add(radio.Text);

                    else if (control is CheckBox check && check.Checked)
                        parametri.Add(check.Text);
                }
            }

            return parametri;
        }

        private void btAnnullaFiltra_Click(object sender, EventArgs e)
        {
            PulisciGroubBox(gBtipoDocente);
            //gestione tbricerca
            if (_utenteLoggato.TipoUtente != "C")
            {
                cbDipartimento.SelectedIndex = -1;
                PulisciGroubBox(gbTipiUtenti);
            }
            tbRicerca.Text = string.Empty;
            btAnnullaFiltra.Enabled = false;
            btFiltro_Click(null, null);
        }


        private void PulisciGroubBox(GroupBox gb)
        {
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    cb.Checked = false;  // deseleziona checkbox
                }
                else if (ctrl is RadioButton rb)
                {
                    rb.Checked = false;  // deseleziona radiobutton
                }
            }
        }

        private void tbRicerca_Enter(object sender, EventArgs e)
        {
            if (tbRicerca.Text == "cognome nome")
            {
                tbRicerca.Text = "";
                tbRicerca.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void tbRicerca_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRicerca.Text))
            {
                tbRicerca.Text = "cognome nome";
                tbRicerca.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void cbDocenteCordinatore_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDocente.Checked || cbCoordinatore.Checked)
                gBtipoDocente.Enabled = true;
            else
            {
                gBtipoDocente.Enabled = false;
                PulisciGroubBox(gBtipoDocente);
            }
        }


        #endregion
        #region permessi
        public void GestisciPermessi()
        {
            if (_utenteLoggato?.TipoUtente == "C")
            {
                long idDipartimento = ClsUtenteBL.TrovaIDdipartimento(_utenteLoggato.ID);
                if (idDipartimento > 0)
                    filtri["IDdipartimento"] = new List<string> { idDipartimento.ToString() };
                cbDipartimento.SelectedValue = idDipartimento; 
                cbDipartimento.Enabled = false;
                cbDocente.Checked=true;
                gbTipiUtenti.Enabled = false;
                btCattedreUtente.Enabled = false;
            }
        }
        #endregion
        #region mappattura tasti
        private void lvUtenti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lvUtenti.SelectedIndices.Count == 1)
            {
                e.SuppressKeyPress = true;
                btModifica_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete && lvUtenti.SelectedIndices.Count == 1)
            {
                e.SuppressKeyPress = true;
                btElimina_Click(null, null);
            }
        }
        private void tbRicerca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //se si preme enter simula il click del pulsante
            {
                btFiltro_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btAnnullaFiltra_Click(null, null);
                tbRicerca_Enter(null, null);
            }
        }
        private void GenericCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita il "beep"

                // Trasforma il 'sender' in una CheckBox ed esegue l'inversione
                if (sender is CheckBox cb)
                {
                    cb.Checked = !cb.Checked;

                }
            }
        }
        private void cbDipartimento_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita il "beep"
                tbRicerca.Focus();
            }
            if (_utenteLoggato.TipoUtente != "C" && e.KeyCode == Keys.Cancel || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                cbDipartimento.SelectedIndex = -1;

        }

        private void rbTipoDocente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbDipartimento.Focus();
        }

        #endregion

        private void btCattedreUtente_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvUtenti.SelectedIndices[0];
                FrmCattedreUtente frmCattedreUtente = new FrmCattedreUtente(_utenteLoggato);
                frmCattedreUtente._utente = _utenti[indiceDaModificare];
                frmCattedreUtente._utente.ID = _utenti[indiceDaModificare].ID; //mi assicuro che l'ID rimanga lo stesso

                DialogResult dr = frmCattedreUtente.ShowDialog();


            }
            else
                MessageBox.Show("non è stato selezionato nessun utente, riprovare.", "Modifica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

       
    }
}
