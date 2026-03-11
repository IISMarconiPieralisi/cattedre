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
        public List<ClsUtenteDL> _utenti = new List<ClsUtenteDL>();
        string _filtro = string.Empty;
        List<string> _parametri = new List<string>();
        List<string> _parametroRicerca = new List<string>();

        public FrmUtenti()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            lvUtenti.Items.Clear();

            foreach (ClsUtenteDL utente in _utenti)
            {
                //prendo un metodo che cerca il contratto in base all'id utente
                ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(utente.ID);
                ListViewItem lvi = new ListViewItem(utente.Nome);

                lvi.SubItems.Add(utente.Cognome);
                lvi.SubItems.Add(utente.Email);
                string _tipoDocente = (utente.TipoDocente == 'T') ? " teorico" : (utente.TipoDocente == 'L') ? " partico" : string.Empty;
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
                        lvi.SubItems.Add($" docente{_tipoDocente} coordinatore dipartimento");
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
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmUtente frmUtente = new FrmUtente();
            DialogResult dr = frmUtente.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClsUtenteBL.InserisciUtente(frmUtente._utente); //l'utente che mando non ha un ID che creo quando lo inzializzo nel server
                    ClsUtenteDL utente = ClsUtenteBL.caricautenteByEmail(frmUtente._utente.Email); //essendo che l'email è univoca riesco a risalire anche all'id del utente in questo modo
                    if (frmUtente._afferenze != null && frmUtente._afferenze.Count > 0)
                    {
                        foreach (ClsAfferireDL afferire in frmUtente._afferenze)
                        {
                            afferire.IDutente = utente.ID;
                            ClsAfferireBL.InserisciAfferire(afferire);
                        }

                    }
                    if (frmUtente._richieste != null && frmUtente._richieste.Count > 0)
                    {
                        foreach (ClsRichiedereDL richiedere in frmUtente._richieste)
                        {
                            richiedere.IDutente = utente.ID;
                            ClsRichiedereBL.InserisciRichiedere(richiedere);
                        }

                    }

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore durante il inserimento:{ex.Message}", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                gestisciListview();
            }
        }

        private void FrmUtenti_Load(object sender, EventArgs e)
        {
            _utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView();
        }
        private void gestisciListview()
        {
            if (!string.IsNullOrWhiteSpace(_filtro))
                _utenti = ClsUtenteBL.FiltraUtenti(_parametri, _filtro);
            else if (!string.IsNullOrEmpty(_parametroRicerca))
                _utenti = ClsUtenteBL.RicercaPerNomeCognome(_parametroRicerca);
            else
                _utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView();

        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {

                int indiceDaModificare = lvUtenti.SelectedIndices[0];
                FrmUtente frmUtente = new FrmUtente();
                //passo la classe afferirenza e il contratto solo se l'utente è un docente
                frmUtente._utente = _utenti[indiceDaModificare];
                //creo un appoggio di utente che mi servirà in futuro
                //ClsUtenteBL u = frmUtente._utente;
                frmUtente._utente.ID = _utenti[indiceDaModificare].ID; //mi assicuro che l'ID rimanga lo stesso

                List<ClsAfferireDL> afferire = ClsAfferireBL.CaricaClassiAfferire(_utenti[indiceDaModificare].ID);
                if (afferire != null && afferire.Count > 0) //se non esiste restituirà null e quindi non restituirà la lista
                    frmUtente._afferenze = afferire;

                List<ClsRichiedereDL> richiedere = ClsRichiedereBL.CaricaClassiRichiedere(_utenti[indiceDaModificare].ID);
                if (richiedere != null && richiedere.Count > 0)
                    frmUtente._richieste = richiedere;
                ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(_utenti[indiceDaModificare].ID); //se non esiste restituirà null
                if (contratto != null)
                    frmUtente._contratto = contratto;


                DialogResult dr = frmUtente.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ClsUtenteBL.ModificaUtente(frmUtente._utente, frmUtente._utente.ID);

                        if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C" || frmUtente._utente.TipoUtente == "A")
                        {

                            //modifica contratto, afferenze e richieste
                            ClsAfferireBL.ModificaAfferenze(frmUtente._utente.ID, frmUtente._afferenze);
                            ClsRichiedereBL.ModificaRichiesta(frmUtente._utente.ID, frmUtente._richieste);
                            ClsContrattoBL.ModificaContratto(frmUtente._contratto, frmUtente._utente.ID);
                            //controllo e inserimento coordinatore di dipartimento
                            if (frmUtente._utente.TipoUtente == "C")
                            {
                                //se è un coordinatore di dipartimento devo aggiornare la tabella dipartimenti
                                ClsDipartimentoBL.ModificaCoordinatoreDipartimento(frmUtente._dipartimento, frmUtente._utente.ID);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore durante il salvataggio: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    gestisciListview();


                }
            }
            else
                MessageBox.Show("non è stato selezionato nessun utente, riprovare.", "Modifica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvUtenti.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvUtenti.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsDipartimentoBL.EliminaCoordinatoreDipartimento(idDaEliminare);
                    ClsUtenteBL.EliminaUtente(idDaEliminare);
                    _utenti = ClsUtenteBL.CaricaUtenti();

                }
                gestisciListview();

            }
        }
        #region filtri

        private void btFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                btAnnullaFiltra.Enabled = true;

                bool parametroSelezionato = false;
                Dictionary<string, List<string>> filtri = new Dictionary<string, List<string>>();
                Dictionary<string, string> mappaUtenti = new Dictionary<string, string>()
                {
                    { "Preside", "P" },
                    { "Amministratore", "A" },
                    { "Docente", "D" },
                    { "Coordinatore", "C" }
                };

                Dictionary<string, string> mappaContratto = new Dictionary<string, string>()
                {
                    { "Determinato", "D" },
                    { "Indeterminato", "I" }
                };

                Dictionary<string, string> mappaTipoDocente = new Dictionary<string, string>()
                {
                    { "Laboratorio", "L" },
                    { "Teorico", "T" }
                };


                var tipiUtente = CaricaElementiSelezionati(gbTipiUtenti, typeof(CheckBox));

                if (tipiUtente.Any())
                {
                    List<string> valori = new List<string>();

                    foreach (string item in tipiUtente)
                    {
                        if (mappaUtenti.ContainsKey(item))
                            valori.Add(mappaUtenti[item]);
                    }

                    if (valori.Any())
                    {
                        filtri.Add("tipoUtente", valori);
                        parametroSelezionato = true;
                    }
                }
                var contratto = CaricaElementiSelezionati(gbContratto, typeof(RadioButton));
                if (contratto.Any())
                {
                    List<string> valori = new List<string>();
                    foreach (string item in contratto)
                    {
                        if (mappaContratto.ContainsKey(item))
                            valori.Add(mappaContratto[item]);
                    }
                    if (valori.Any())
                    {
                        filtri.Add("tipoContratto", valori);
                        parametroSelezionato = true;
                    }
                }
                var tipoDocente = CaricaElementiSelezionati(gBtipoDocente, typeof(RadioButton));
                if (tipoDocente.Any())
                {
                    List<string> valori = new List<string>();

                    foreach (string item in tipoDocente)
                    {
                        if (mappaTipoDocente.ContainsKey(item))
                            valori.Add(mappaTipoDocente[item]);
                    }

                    if (valori.Any())
                    {
                        filtri.Add("categoriaDocente", valori);
                        parametroSelezionato = true;
                    }
                }

                if (!parametroSelezionato)
                    throw new Exception("non è stato selezionato nessun parametro di ricerca");

                // passo i filtri al metodo che costruisce la query
                gestisciListview(filtri);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n riprova", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            btFiltro.Enabled = false;
            btAnnullaFiltra.Enabled = false;
            tlpFiltri.Controls.Clear();
            cbFiltro.SelectedIndex = 0;
            _filtro = string.Empty;
            _parametri = new List<string>();

            //ricamento della listview
            gestisciListview();
        }




        #endregion
        #region ricerca

        private void tbRicerca_TextChanged(object sender, EventArgs e)
        {
            if(tbRicerca.Text!="cognome nome" && tbRicerca.Text.Length>2)
            {
                btRicerca.Enabled = true;
            }else
            {
                btRicerca.Enabled = false;
            }
        }

        private void tbRicerca_Enter(object sender, EventArgs e)
        {
            if (tbRicerca.Text == "cognome nome")
            {
                tbRicerca.Text = "";
                tbRicerca.ForeColor = Color.Black;
            }
        }

        private void tbRicerca_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRicerca.Text))
            {
                tbRicerca.Text = "cognome nome";
                tbRicerca.ForeColor = Color.Gray;
            }
        }
        private void btRicerca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbRicerca.Text) && tbRicerca.Text != "cognome nome")
            {
                //cancello il filtra in modo che non mi dia problemi
                _filtro = string.Empty;
                btAnnullaRicerca.Enabled = true;
                _parametroRicerca = tbRicerca.Text.Replace(" ", "").ToLower();
                _utenti = ClsUtenteBL.RicercaPerNomeCognome(_parametroRicerca);
                CaricaListView();
            }
            else
                MessageBox.Show("Inserire Input valido per la ricerca", "attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btAnnullaRicerca_Click(object sender, EventArgs e)
        {
            btRicerca.Enabled = false;
            btAnnullaRicerca.Enabled = false;
            _parametroRicerca = string.Empty;
            tbRicerca.Text = string.Empty;
            gestisciListview();
        }
        #endregion
    }
}
