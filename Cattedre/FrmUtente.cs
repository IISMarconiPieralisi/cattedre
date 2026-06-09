using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Cattedre
{
    public partial class FrmUtente : Form
    {
        #region passaggio dati
        public ClsUtenteDL _utente { get; set; } //variabile per passare i dati tra form,
        public ClsContrattoDL _contratto { get; set; } //se l'utente non ha un contratto non viene passato nulla
        public List <ClsAfferireDL> _afferenze { get; set; } //se l'utente non ha afferenze non viene passato nulla
        public ClsDipartimentoDL _dipartimento { get; set; }
        public List <ClsRichiedereDL> _richieste { get; set; } 
        #endregion
        #region variabili globali
        //creazione degli array che verranno popolati con le query
        List<ClsClasseDiConcorsoDL> cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
        List<ClsDipartimentoDL> dipartimenti = ClsDipartimentoBL.CaricaDipartimenti().OrderBy(d=>d.Nome).ToList();
        List<ClsDisciplinaDL> discipline = ClsDisciplinaBL.CaricaDiscipline();
        int _oldValuedipCoord=0;
        bool _bloccoEvdipCoord = false;
        string _imputEmail;
        string _colore = string.Empty;
        ClsUtenteDL _utenteLoggato;
        //tenuti fuori in modo tale che  all'occorrenza non si deve riaprire ogni volta una connessione al db
        #endregion
        public FrmUtente(ClsUtenteDL utenteloggato)
        {
            _utenteLoggato = utenteloggato;
            InitializeComponent();
        }
        
        #region Salva annulla e load
        private void BtSalva_Click(object sender, EventArgs e)
        {

            if (_utente == null)
                _utente = new ClsUtenteDL();

            try
            {
                if (_utente.ID == 0 && tbPassword.Text.Length <6)
                    throw new Exception("la password deve avere almeno 8 caratteri");
                //dati base utente
                _utente.Nome = tbNome.Text.Trim();
                _utente.Cognome = tbCognome.Text.Trim();
                _utente.Email = tbEmail.Text.Trim();
                _utente.Password =(tbPassword.Text== "********")?"": tbPassword.Text.Trim();
                _utente.TipoUtente = GetTipoUtente();
                _utente.Colore =_colore;

                bool isDocente = _utente.TipoUtente == "D" || _utente.TipoUtente == "C" || _utente.TipoUtente == "A";
                //inserimento controlli Docente
                if (isDocente)
                {
                        _utente.TipoDocente = rbTeorico.Checked ? 'T' :(rbLaboratorio.Checked)? 'L': throw new Exception("seleziona un tipo di docente");
                    // controlli classe di concorso e disciplina
                    if (clbCLasseDiConcorso.CheckedItems.Count == 0)
                        throw new Exception("Seleziona almeno una classe di concorso.");
                    if (clbDisciplina.CheckedItems.Count == 0)
                        throw new Exception("seleziona almeno una disciplina");


                        // ---- Contratto ----
                        if (nudMonteOre.Value <= 0 || (!rbDeterminato.Checked && !rbIndeterminato.Checked))
                        throw new Exception("Inserire un monte ore valido e selezionare il tipo di contratto.");
                    
                    //creazione  contratto se non esiste  (caso inserimento)
                    if(_contratto==null) 
                        _contratto = new ClsContrattoDL();

                    _contratto.MonteOre = (int)nudMonteOre.Value;
                    _contratto.DataInizioContratto = dtpDataInizio.Value;
                    _contratto.TipoContratto = rbDeterminato.Checked ? 'D' : 'I';
                    if (rbDeterminato.Checked)
                        _contratto.DataFineContratto = dtpDataFine.Value;
                    else
                        _contratto.DataFineContratto = null;

                    // controlli  afferenze dipartimentali
                    
                        _afferenze = new List<ClsAfferireDL>();

                    foreach (var item in clbDipartimento.CheckedItems)
                    {
                        ClsDipartimentoDL dip = dipartimenti
                            .Find(d => d.Nome == item.ToString());

                        if (dip != null)
                            _afferenze.Add(new ClsAfferireDL(dip.ID));
                    }
                    //controlli richiedere e inserimento

                    // gestione Classi di concorso
                        _richieste = new List<ClsRichiedereDL>();

                    foreach (var item in clbCLasseDiConcorso.CheckedItems)
                    {
                        string Livello = DividiClasseConcorso(item.ToString()).Trim();
                        ClsClasseDiConcorsoDL cdc = cdcs
                            .Find(d => d.Livello == Livello.ToString());

                        if (cdc != null)
                            _richieste.Add(new ClsRichiedereDL(cdc.ID));
                    }
                    //gestione Disciplina insegnata
                    foreach(var item in clbDisciplina.CheckedItems)
                    {
                        string Nome = string.Empty;
                        int Anno =0;
                        DividiDisciplina( item.ToString() ,out Nome, out Anno);
                        ClsDisciplinaDL disc = discipline
                            .Find(d => d.Nome == Nome && d.Anno==Anno);

                        if (disc != null)
                        {
                            ClsRichiedereDL richiedere = new ClsRichiedereDL();
                            richiedere.IDdisciplina = disc.ID;
                            _richieste.Add(richiedere);
                        }
                    }
                }
                
                //controlli CD e passaggio del  dipartimento differito
                if (_utente.TipoUtente == "C")
                {
                    // Deve coordinare un dipartimento
                    if (cbDipartimentoCoordinato.SelectedItem == null)
                        throw new Exception("Seleziona un dipartimento da coordinare.");
                    else                 // passo il dipartimento  coordinato all'esterno
                        _dipartimento = dipartimenti.Find(d => d.Nome == cbDipartimentoCoordinato.SelectedItem.ToString());

                }

                //controllo se il colore è libero
                foreach (var item in clbDipartimento.CheckedItems)
                {
                    string nomeDip = item.ToString();

                    long idDip = ClsDipartimentoBL.RilevaIDdipartimento(nomeDip);

                    //il bianco può essere riutilizzato
                    if (_utente.Colore != "255255255")
                    {
                        if (ClsUtenteBL.ColoreOccupatoInDipartimento(_utente.Colore, idDip, _utente.ID))
                            throw new Exception($"Colore occupato nel dipartimento: {nomeDip}");
                    }
                }
                
                // Se arrivi qui, tutto è valido
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmUtente_Load(object sender, EventArgs e)
        {
            InitializeControls();

            if (ModificaUtente())
            {
                LoadDatiUtente();
                LoadContratto();
                LoadAfferenze();
                LoadClassiDiConcorso();
                GestisciPermessi();
            }
            ConfiguraPannelloCDC();
            GestisciCoordinatoreDipartimento();
        }

        private void GestisciCoordinatoreDipartimento()
        {
            clbDipartimento.Enabled = true;
            if (!ClsUtenteDL.UtenteAdmin(_utenteLoggato))
            {
                ClsDipartimentoDL dip = ClsDipartimentoBL.UtenteCoordinaDipartimento(_utenteLoggato.ID);
                if (dip.ID > 0)
                {
                    int indexDipartimento = dipartimenti.FindIndex(d => d.ID == dip.ID);
                    if (indexDipartimento >= 0)
                    {
                        clbDipartimento.SetItemChecked(indexDipartimento, true);
                    }
                }
            }
        }

        private void GestisciPermessi()
        {
            if (ClsUtenteDL.UtenteAdmin(_utenteLoggato) || _utente.ID==_utenteLoggato.ID) return;
            //se è un coordinatore in modifica non permette la modifica della password
            tbNome.Enabled = false;
            tbCognome.Enabled = false;
            tbPassword.Enabled = false;
            cbAutoEmail.Enabled = false;
            tbEmail.Enabled = false;
            cbAutoPassword.Enabled = false;
            cbTipoUtente.Enabled = false;
            pnTipoDocente.Enabled = false;
            //colore può essere modificato
            //se trova un dipartimento lo im
           

        }

        #region Inizializzazione

        private void InitializeControls()
        {
            popolaClbClasseDiConcorso(cdcs);
            popolaDipartimenti(dipartimenti);
            cldColori.Color = Color.White;
            popolacbTipiUtente();
        }

        private void popolacbTipiUtente()
        {
            cbTipoUtente.Items.Clear();
            if(ClsUtenteDL.UtenteAdmin(_utenteLoggato))
            {
                cbTipoUtente.Items.Add("Preside");
                cbTipoUtente.Items.Add("Amministratore");
                cbTipoUtente.Items.Add("Coordinatore di dipartimento");
                cbTipoUtente.SelectedIndex = -1;
            }
            cbTipoUtente.Items.Add("Docente");
        }

        private bool ModificaUtente() => _utente != null && _utente.ID > 0;

        #endregion
        #region Caricamento Utente

        private void LoadDatiUtente()
        {
            tbNome.Text = _utente.Nome;
            tbCognome.Text = _utente.Cognome;
            tbEmail.Text = _utente.Email;
            tbPassword.Text = "********";

            tbPassword.Enter += tbPassword_Enter;
            tbPassword.Leave += tbPassword_Leave;

            cbTipoUtente.SelectedItem = GetNomeTipoUtente(_utente.TipoUtente);

            LoadTipoDocente();
            LoadDipartimentoCoordinato();
            LoadColoreUtente();
        }

        private void LoadTipoDocente()
        {
            switch (_utente.TipoDocente)
            {
                case 'T': rbTeorico.Checked = true; break;
                case 'L': rbLaboratorio.Checked = true; break;
            }
        }

        private void LoadDipartimentoCoordinato()
        {
            if (_utente.TipoUtente != "C") return;

            ClsDipartimentoDL dipCoordinato = ClsDipartimentoBL.UtenteCoordinaDipartimento(_utente.ID);
            if (dipCoordinato != null)
                loadDipartimentoCoordinato(dipCoordinato);
        }

        private void LoadColoreUtente()
        {
            if (string.IsNullOrEmpty(_utente.Colore)) return;

            _colore = _utente.Colore;
            Color colore = OttieniColore(_utente.Colore);
            cldColori.Color = colore;
            pnColore.BackColor = colore;
        }

        #endregion
        #region Caricamento Contratto

        private void LoadContratto()
        {
            if (_contratto == null) return;

            rbDeterminato.Checked = _contratto.TipoContratto == 'D';
            rbIndeterminato.Checked = _contratto.TipoContratto != 'D';

            nudMonteOre.Value = Convert.ToDecimal(_contratto.MonteOre);
            dtpDataInizio.Value = _contratto.DataInizioContratto;

            if (_contratto.DataFineContratto != null)
                dtpDataFine.Value = _contratto.DataFineContratto.Value;
            else
                dtpDataFine.Enabled = false;
        }

        #endregion
        #region Caricamento Afferenze e CDC

        private void LoadAfferenze()
        {
            if (_afferenze?.Count > 0)
                loadDipartimenti();
        }

        private void LoadClassiDiConcorso()
        {
            if (_richieste == null) return;

            clbCLasseDiConcorso.ItemCheck -= clbCLasseDiConcorso_ItemCheck;
            loadCDC();
            PopolaDisciplinePerCDC();
            clbCLasseDiConcorso.ItemCheck += clbCLasseDiConcorso_ItemCheck;
            LoadDisciplineUtente();
        }

        /// <summary>
        /// Il pannello CDC è attivo solo per Admin (A), Docente (D) e Coordinatore (C).
        /// </summary>
        private void ConfiguraPannelloCDC()
        {
            bool cdcAbilitata = _utente != null&& new[] { "A", "D", "C" }.Contains(_utente.TipoUtente);

            pnCDCeDisc.Enabled = cdcAbilitata;   // oppure .Enabled se vuoi tenerlo visibile
        }


        #endregion
        #endregion
        private void rbIndeterminato_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIndeterminato.Checked)
            {
                dtpDataFine.Enabled = false;
                //dtpDataFine.Value = DateTime.Now();
            }
            if (rbDeterminato.Checked)
            {
                dtpDataFine.Enabled = true;
            }
        }
        private void cbAutoEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoEmail.Checked)
            {
                _imputEmail = tbEmail.Text;
                if (!string.IsNullOrWhiteSpace(tbNome.Text) && !string.IsNullOrWhiteSpace(tbCognome.Text))
                {
                    string nomeSenzaSpazi = tbNome.Text.ToLower().Replace(" ", "");
                    string cognomeSenzaSpazi = tbCognome.Text.ToLower().Replace(" ", "");

                    string _Email = $"{nomeSenzaSpazi}.{cognomeSenzaSpazi}@iismarconipieralisi.it";
                    tbEmail.Enabled = false;
                    tbEmail.Text = _Email;
                }

            }
            else
            {
                tbEmail.Enabled = true;
                tbEmail.Text = _imputEmail;    
            }
            if(string.IsNullOrEmpty(tbNome.Text) && string.IsNullOrEmpty(tbCognome.Text))
            {
                MessageBox.Show("Per la mail automatica, compila i campi obbligatori ovvero: nome e cognome");
                cbAutoEmail.Checked=false; 
            }
        }
        #region gestioni tipi utente
        private String GetTipoUtente()
        {
            // P = Preside
            //A = Amministratore
            //D = Docente
            //CD = Cordinatore di dipartimento
            String tipoUtente = cbTipoUtente.SelectedItem.ToString();
            switch (tipoUtente)
            {
                case "Preside":
                    return "P";
                case "Amministratore":
                    return "A";
                case "Docente":
                    return "D";
                case "Coordinatore di dipartimento":
                    return "C";
                default:
                    return string.Empty;
            }
        }
        private void cbTipoUtente_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Admin = ClsUtenteDL.UtenteAdmin(_utenteLoggato);
            switch (cbTipoUtente.SelectedItem.ToString())
            {
                case "Docente":
                    pnCDCeDisc.Enabled = true;
                    pnDipartimento.Enabled = Admin;
                    PnContratto.Enabled = true;
                    lbDcoordinato.Visible = false;
                    cbDipartimentoCoordinato.Visible = false;
                    cbDipartimentoCoordinato.Text = string.Empty;
                    pnTipoDocente.Enabled = true;
                    break;

                case "Coordinatore di dipartimento":
                    pnCDCeDisc.Enabled = true;
                    pnDipartimento.Enabled = Admin;
                    PnContratto.Enabled = true;
                    lbDcoordinato.Visible = true;
                    cbDipartimentoCoordinato.Visible = true;
                    pnTipoDocente.Enabled = true;

                    break;
                case "Amministratore":
                    pnCDCeDisc.Visible = true;
                    pnDipartimento.Enabled = Admin;
                    PnContratto.Enabled = true;
                    lbDcoordinato.Visible = true;
                    cbDipartimentoCoordinato.Visible = true;
                    pnTipoDocente.Enabled = true;
                    break;
                default:
                    pnCDCeDisc.Enabled = false;
                    pnDipartimento.Enabled = false;
                    PnContratto.Enabled = false;
                    lbDcoordinato.Visible = false;
                    cbDipartimentoCoordinato.Visible = false;
                    cbDipartimentoCoordinato.Text = string.Empty;
                    pnTipoDocente.Enabled = false;
                    rbLaboratorio.Checked = false;
                    rbTeorico.Checked = false;
                    break;
            }
        } 
        //funzione per mostrare i panel e i comandi grafici in base al tipo di utente selezionato
        private string GetNomeTipoUtente(string sigla)
        {
            switch (sigla)
            {
                case "P":
                    return "Preside";
                case "A":
                    return "Amministratore";
                case "D":
                    return "Docente";
                case "C":
                    return "Coordinatore di dipartimento";
                default:
                    return string.Empty;
            }
        }
        #endregion
        #region controlli grafici dipartimenti

        private void cbDipartimentoCoordinato_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se non c'è nulla di selezionato, usciamo
            if (cbDipartimentoCoordinato.SelectedItem == null)
                return;

            string dipartimentoScelto = cbDipartimentoCoordinato.SelectedItem.ToString();

            // Cerchiamo l'indice di questo dipartimento nella CheckedListBox
            int index = clbDipartimento.Items.IndexOf(dipartimentoScelto);

            if (index >= 0)
            {
                // Se l'elemento esiste, forziamo la spunta (Checked = true)
                // Se è già spuntato non succede nulla, se non lo è viene attivato
                clbDipartimento.SetItemChecked(index, true);
            }

            //se viene selezionato  un  dipartimento faccio vedere, se è già coordinato chi lo coordina e una conferma di cambiarlo
            if (_bloccoEvdipCoord)
                return;
            ClsUtenteDL coord = ClsDipartimentoBL.utenteCoordinaDiparimento(dipartimentoScelto);
            if (coord != null && (_utente == null || coord.ID != _utente.ID))
            {
                DialogResult dr = MessageBox.Show($"Attualmente il dipartimento {dipartimentoScelto} viene coordinato da {coord.Cognome} {coord.Nome}; \nVuoi sostituirlo?", "Cambio Coordinatore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    _bloccoEvdipCoord = true;
                    cbDipartimentoCoordinato.SelectedIndex = _oldValuedipCoord;
                    _bloccoEvdipCoord = false;
                }
                else
                    _oldValuedipCoord = cbDipartimentoCoordinato.SelectedIndex;

            }
            else
                _oldValuedipCoord = cbDipartimentoCoordinato.SelectedIndex;
        }

        private void clbDipartimento_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 1. Verifichiamo se c'è un dipartimento coordinato selezionato nella ComboBox
            if (cbDipartimentoCoordinato.SelectedItem == null)
                return;

            string coordinato = cbDipartimentoCoordinato.SelectedItem.ToString();
            string itemCorrente = clbDipartimento.Items[e.Index].ToString();

            // 2. Controlliamo se l'utente sta cercando di DESELEZIONARE (NewValue == Unchecked)
            // proprio il dipartimento che coordina
            if (itemCorrente == coordinato && e.NewValue == CheckState.Unchecked)
            {
                MessageBox.Show($"L'utente è coordinatore del dipartimento {coordinato}, non può essere rimosso dai suoi dipartimenti!",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 3. ANNULLIAMO il cambiamento forzando il valore corrente
                e.NewValue = e.CurrentValue;
            }
        }

        //controllo se modifica  inserisco i dipartimenti che l'utente afferisce
        private void loadDipartimenti()
        {
            // Carico tutte le afferenze dell'utente
            List<ClsDipartimentoDL> dipartimentiUtente = ClsAfferireBL.dipartimentiAfferiti(_utente.ID);
            string DipCoordinato = string.Empty;
            if (dipartimentiUtente == null || dipartimentiUtente.Count == 0)
                return;
            //controllo se l'utente coordina qualche dipartimento
            if (_utente.TipoUtente == "C")
            {
                ClsDipartimentoDL dipcord = ClsDipartimentoBL.UtenteCoordinaDipartimento(_utente.ID);
                if (dipcord != null)
                {
                    DipCoordinato = dipcord.Nome;
                }
            }

            // Scorro gli item della CheckedListBox e imposto checked quelli afferenti
            for (int i = 0; i < clbDipartimento.Items.Count; i++)
            {
                string nomeItem = clbDipartimento.Items[i].ToString();
                bool afferente = dipartimentiUtente.Any(d => string.Equals(d.Nome, nomeItem, StringComparison.OrdinalIgnoreCase));
                if (afferente && !string.Equals(nomeItem, DipCoordinato, StringComparison.OrdinalIgnoreCase))
                    clbDipartimento.SetItemChecked(i, true);

            }

        }

        private void loadDipartimentoCoordinato (ClsDipartimentoDL dip)
        {
            //cerco se il dipartimento trovato che l'utente coordina esiste e lo seleziono
            for(int i=0; i<cbDipartimentoCoordinato.Items.Count; i++)
            {
                if (dip.Nome == cbDipartimentoCoordinato.Items[i].ToString())
                {
                    cbDipartimentoCoordinato.SelectedIndex = i;
                    return;
                }
            }
        }
        private void cbDipartimentoCoordinato_DropDown(object sender, EventArgs e)
        {
            _oldValuedipCoord = cbDipartimentoCoordinato.SelectedIndex;
        }
        private void popolaDipartimenti(List<ClsDipartimentoDL> dipartimenti)
        {
            cbDipartimentoCoordinato.Items.Clear();
            clbDipartimento.Items.Clear();
            foreach (ClsDipartimentoDL d in dipartimenti)
            {
                cbDipartimentoCoordinato.Items.Add(d.Nome);
                clbDipartimento.Items.Add(d.Nome);
            }

        }
        #endregion
        #region controllli grafici cds
        private void loadCDC()
        {
            // Carico tutte le CDC dell'utente
            List<ClsClasseDiConcorsoDL> cdcUtente =
                ClsRichiedereBL.RilevaCDCDocente(_utente.ID);

            if (cdcUtente == null || cdcUtente.Count == 0)
                return;

            // Creo l'elenco delle CDC dell'utente nel formato "Livello | Nome"
            HashSet<string> cdcUtenteScritta = new HashSet<string>(
                    cdcUtente.Select(c => CreaCDCAbbreviata(c)),
                    StringComparer.OrdinalIgnoreCase);


            // Scorro gli item della CheckedListBox
            for (int i = 0; i < clbCLasseDiConcorso.Items.Count; i++)
            {
                string nomeItem = clbCLasseDiConcorso.Items[i].ToString();

                if (cdcUtenteScritta.Contains(nomeItem))
                    clbCLasseDiConcorso.SetItemChecked(i, true);
            }
        }
        private string CreaCDCAbbreviata(ClsClasseDiConcorsoDL cdc)
        {
            string nome = cdc.Nome.Length > 30 ? cdc.Nome.Substring(0, 30) + "..." : cdc.Nome;
            return $"{cdc.Livello} | {nome}";
        }
        private void popolaClbClasseDiConcorso(List<ClsClasseDiConcorsoDL> cdcs)
        {
            clbCLasseDiConcorso.Items.Clear();
            foreach (ClsClasseDiConcorsoDL c in cdcs)
            {
                clbCLasseDiConcorso.Items.Add(CreaCDCAbbreviata(c));
            }
        }

        private void PopolaDisciplinePerCDC()
        {
            clbDisciplina.Items.Clear();
            // Se non ci sono elementi selezionati, disabilita e esci
            if (clbCLasseDiConcorso.CheckedItems.Count == 0)
            {
                clbDisciplina.Enabled = false;
                return;
            }
            clbDisciplina.Enabled = true;
            //creo una lista di disciplina di appoggio
            List<ClsDisciplinaDL> disc = new List<ClsDisciplinaDL>();
            foreach (var item in clbCLasseDiConcorso.CheckedItems)
            {
                string Livello = DividiClasseConcorso(item.ToString()).Trim();
                ClsClasseDiConcorsoDL cdc = cdcs.Find(d => d.Livello == Livello.ToString());

                if (cdc != null)
                {
                    List<ClsDisciplinaDL> discipline = ClsRichiedereBL.RilevaDiscipinaCDC(cdc.ID);
                    
                    foreach (var d in discipline)
                    {
                        if (!disc.Any(esistente => esistente.ID == d.ID))
                        {
                            disc.Add(d);
                        }
                    }
                }
            }
            if (disc.Count <= 0)
                return;
            foreach (var d in disc.OrderBy(d => d.Anno == 0).ThenBy(d => d.Nome).ThenBy(d => d.Anno))
                clbDisciplina.Items.Add(d.Anno > 0 ? $"{d.Nome} {d.Anno}°" : d.Nome);

        }
        private void LoadDisciplineUtente()
        {
            // Carico tutte le CDC dell'utente
            List<ClsDisciplinaDL> disciplineUtente =
                ClsRichiedereBL.RilevaDisciplineDocente(_utente.ID);

            if (disciplineUtente == null || disciplineUtente.Count == 0)
                return;

            // Creo l'elenco delle CDC dell'utente nel formato "Nome anno°"
            HashSet<string> disciplinaUtenteScritta = new HashSet<string>(
                disciplineUtente.Select(c => c.Anno != 0 ? $"{c.Nome} {c.Anno}°" : c.Nome),
                StringComparer.OrdinalIgnoreCase);

            // Scorro gli item della CheckedListBox
            for (int i = 0; i < clbDisciplina.Items.Count; i++)
            {
                string nomeItem = clbDisciplina.Items[i].ToString();
                if (disciplinaUtenteScritta.Contains(nomeItem))
                    clbDisciplina.SetItemChecked(i, true);
            }
        }

        private string DividiClasseConcorso(string item)
        {
            string[] vs = item.Split('|');
            return vs[0];
        }
        private void DividiDisciplina( string item,out string nome, out int anno)
        {
            anno = Convert.ToInt16(item.Substring(item.Length - 2, 1));
            nome = item.Substring(0, item.Length - 3);

        }
        private void cbSelezionaTutti_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSelezionaTutti.Checked)
            {
                for (int i = 0; i < clbDisciplina.Items.Count; i++)
                {
                    string nomeItem = clbDisciplina.Items[i].ToString();
                    if (nomeItem.Length >= 2 && nomeItem.Substring(nomeItem.Length-1,1)=="°")
                        clbDisciplina.SetItemChecked(i, true);
                }
            }
        }
        #endregion
        #region gestione colore utente
        private void btColore_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_colore) && _colore.Length == 9)
                cldColori.Color = OttieniColore(_colore);

            if (cldColori.ShowDialog() == DialogResult.OK)
            {
                Color colore = cldColori.Color;
                _colore = ScriviColore(colore);
                pnColore.BackColor = colore;
            }
        }

        public static Color OttieniColore(string rgb)
        {
            if (rgb.Length >= 9)
            {
                int r = int.Parse(rgb.Substring(0, 3));
                int g = int.Parse(rgb.Substring(3, 3));
                int b = int.Parse(rgb.Substring(6, 3));
                return Color.FromArgb(r, g, b);
            }
            else
                return Color.White;
        }

        public static string ScriviColore(Color colore)
        {
            return $"{colore.R:D3}{colore.G:D3}{colore.B:D3}";
        }

        private void clbCLasseDiConcorso_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Usiamo BeginInvoke solo per assicurarci che la lista sia aggiornata 
            // prima di leggere i CheckedItems. È il modo più affidabile.
            this.BeginInvoke(new Action(() => PopolaDisciplinePerCDC()));
        }
        #endregion
        #region gestione password grafica
        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "********")
                tbPassword.Text = "";
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text) && tbPassword.Text.Length <=2) 
                tbPassword.Text = "********";
        }
        #endregion
        #region navigazione con enter
        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbNome.Text.Length>2)
            {
                this.ActiveControl = tbCognome;

            }

        }

        private void tbCognome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbCognome.Text.Length > 2)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = tbEmail;
            }
        }

        private void cbAutoEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                cbAutoEmail.Checked = true;
                this.ActiveControl = tbPassword;
            }
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(tbEmail.Text)) this.ActiveControl = cbAutoEmail;
                else tbPassword.Focus();
            }
        }
        private void checkBoxAutoEmail_Enter(object sender, EventArgs e)
        {
            cbAutoEmail.ForeColor = Color.Blue;
        }

        private void checkBoxAutoEmail_Leave(object sender, EventArgs e)
        {
            cbAutoEmail.ForeColor = SystemColors.ControlText;
        }

        private void cbTipoUtente_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter &&cbTipoUtente.SelectedIndex!=-1)
            {
                if (GetTipoUtente() != "P")this.ActiveControl = rbTeorico;
                else this.ActiveControl = btSalva;
            }
        }

        private void rbTipoDocente(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (GetTipoUtente() == "P") this.ActiveControl = btSalva;
                else this.ActiveControl = btColore;
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbPassword.Text.Length > 2)
                this.ActiveControl = cbTipoUtente;
        }

        private void cbTipoUtente_Enter(object sender, EventArgs e)
        {
            // Quando l'utente clicca o si sposta sulla combo
            cbTipoUtente.FlatStyle = FlatStyle.Flat;
        }

        private void cbTipoUtente_Leave(object sender, EventArgs e)
        {
            // Quando l'utente cambia controllo
            cbTipoUtente.FlatStyle = FlatStyle.Standard;
            cbTipoUtente.ForeColor = SystemColors.ControlText; // Torna il colore standard
        }
        private long _lastTick = 0;

        private void clbDipartimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita il "Ding" di Windows

                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;

                if (elapsedMilliseconds < 500) // DOPPIO INVIO RAPIDO
                {
                    _lastTick = 0;
                    // Passa al prossimo controllo
                    if (GetTipoUtente()=="D") rbDeterminato.Focus();
                    else cbDipartimentoCoordinato.Focus();
                }else
                {
                    // Al primo colpo fa solo il check
                    int index = clbDipartimento.SelectedIndex;
                    if (index != -1)clbDipartimento.SetItemChecked(index, !clbDipartimento.GetItemChecked(index));
                }
                _lastTick = currentTick;
            }
        }

        private void cbDipartimentoCoordinato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 

                if (GetTipoUtente() == "A" || (GetTipoUtente() == "C" && cbDipartimentoCoordinato.SelectedIndex != -1))
                    rbDeterminato.Focus(); 
            }

        }
        private void clbCLasseDiConcorso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;

                if (elapsedMilliseconds < 800) // DOPPIO INVIO RAPIDO
                {
                    _lastTick = 0;
                    // Passa al prossimo controllo
                    if (clbDisciplina.Enabled == true) clbDisciplina.Focus();
                    else rbDeterminato.Focus();
                }
                else
                {
                    // Al primo colpo fa solo il check
                    int index = clbCLasseDiConcorso.SelectedIndex;
                    if (index != -1) clbCLasseDiConcorso.SetItemChecked(index, !clbCLasseDiConcorso.GetItemChecked(index));
                }
                _lastTick = currentTick;
            }
        }
        private void clbDisciplina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;

                if (elapsedMilliseconds < 800) // DOPPIO INVIO RAPIDO
                {
                    _lastTick = 0;
                    // Passa al prossimo controllo
                    clbDipartimento.Focus();
                }
                else
                {
                    // Al primo colpo fa solo il check
                    int index = clbDisciplina.SelectedIndex;
                    if (index != -1) clbDisciplina.SetItemChecked(index, !clbDisciplina.GetItemChecked(index));
                }
                _lastTick = currentTick;
            }
        }
        private void rbContratto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                nudMonteOre.Focus();
        }
        private void nudMonteOre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && nudMonteOre.Value>0)
            {
                e.SuppressKeyPress = true;
                dtpDataInizio.Focus();
            }
        }
        private void dtpDataInizio_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && dtpDataInizio.Value!=DateTime.Now)
            {
                if (dtpDataFine.Enabled == true) dtpDataFine.Focus();
                else btSalva.Focus();
            }
        }
        private void dtpDataFine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btSalva.Focus();
        }

        private void dtpDataFine_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataFine.Value <= dtpDataInizio.Value)
                dtpDataFine.Value = dtpDataInizio.Value.AddDays(1);
        }

        private void dtpDataInizio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataFine.Value <= dtpDataInizio.Value)
                dtpDataFine.Value = dtpDataInizio.Value.AddDays(1);
        }

        private void tbNomativi_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCognome.Text) && !string.IsNullOrEmpty(tbNome.Text))
            {
                cbAutoEmail.Enabled = true;
                cbAutoPassword.Enabled = true;
            }
            else
            {
                cbAutoPassword.Enabled = false;
                cbAutoEmail.Enabled = false;
            }
        }

        private void btColore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                clbCLasseDiConcorso.Focus();
        }
        private void cbAutoPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbAutoPassword.Checked)
            {
                tbPassword.Text = $"{ tbNome.Text.ToLower().Trim().Substring(0, 3)}{tbCognome.Text.ToLower().Trim().Substring(0, 3)}00!";
                tbPassword.Enabled = false;
            }
            else
            {
                tbPassword.Enabled = true;
            }
        }
    }
    #endregion

}
