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
        List<ClsDipartimentoDL> dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
        int _oldValuedipCoord=0;
        bool _bloccoEvdipCoord = false;
        string _imputEmail;
        string _colore=string.Empty;
        //tenuti fuori in modo tale che  all'occorrenza non si deve riaprire ogni volta una connessione al db
        #endregion
        public FrmUtente()
        {
            InitializeComponent();
            cbTipoUtente.SelectionChangeCommitted += cbTipoUtente_SelectionChangeCommitted;
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            if (_utente == null)
                _utente = new ClsUtenteDL();

            try
            {
                //dati base utente
                _utente.Nome = tbNome.Text.Trim();
                _utente.Cognome = tbCognome.Text.Trim();
                _utente.Email = tbEmail.Text.Trim();
                _utente.Password = tbPassword.Text.Trim();
                _utente.TipoUtente = GetTipoUtente();
                _utente.Colore = _colore;

                bool isDocente = _utente.TipoUtente == "D" || _utente.TipoUtente == "C" || _utente.TipoUtente == "A";
               
                //inserimento controlli Docente
                if (isDocente)
                {
                    // Tipi docente (Teorico o Pratico)
                    if (ckbDocenteTeorico.Checked && ckbDocentePratico.Checked)
                        throw new Exception("Seleziona un solo tipo docente.");

                    if (!ckbDocenteTeorico.Checked && !ckbDocentePratico.Checked)
                        throw new Exception("Seleziona un tipo docente.");
                    else
                        _utente.TipoDocente = ckbDocenteTeorico.Checked ? 'T' : 'L';

                    //controllo colore
                    if (string.IsNullOrEmpty(_utente.Colore))
                        throw new Exception("Seleziona un colore al docente.");
                    

                    // controlli classe di concorso
                    if (clbCLasseDiConcorso.CheckedItems.Count == 0)
                        throw new Exception("Seleziona almeno una classe di concorso.");


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
                    if(_richieste==null)
                        _richieste = new List<ClsRichiedereDL>();
                    //controlli richiedere e inserimento
                    foreach (var item in clbCLasseDiConcorso.CheckedItems)
                    {
                        string Livello = DividiClasseConcorso(item.ToString()).Trim();
                        ClsClasseDiConcorsoDL cdc = cdcs
                            .Find(d => d.Livello == Livello.ToString());

                        if (cdc != null)
                            _richieste.Add(new ClsRichiedereDL(cdc.ID));
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

                // Se arrivi qui, tutto è valido
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }



        private void FrmUtente_Load(object sender, EventArgs e)
        {

            //funzione per prendere solo i nomi delle cdc e non l'oggetto intero
            popolaClbClasseDiConcorso(cdcs);
            //funzione per popolare sia i dipartimenti coordinati anche se non visibili sia quelli in cui partecipare
            //ancora non li filtro in base alla cdc selezionata funzione da fare
            popolaDipartimenti(dipartimenti);


            //controllo se l'utente passato ha dei dati da mostrare
            if (_utente!= null)
            {
                tbNome.Text = _utente.Nome;
                tbCognome.Text = _utente.Cognome;
                tbEmail.Text = _utente.Email;
                if(tbPassword!=null && _utente.ID==0)
                    tbPassword.Text = _utente.Password;
                cbTipoUtente.SelectedItem = GetNomeTipoUtente(_utente.TipoUtente);
                if (_utente.TipoDocente == 'T')
                    ckbDocenteTeorico.Checked = true;
                else if (_utente.TipoDocente == 'L')
                    ckbDocentePratico.Checked = true;
                if (_utente.TipoUtente == "C")
                {
                    ClsDipartimentoDL dipCoordinato = ClsDipartimentoBL.UtenteCoordinaDipartimento(_utente.ID);
                    if (dipCoordinato != null)
                    {
                        loadDipartimentoCoordinato(dipCoordinato);
                    }

                }
                if(!string.IsNullOrEmpty(_utente.Colore))
                {
                    Color coloreUC = OttieniColore(_utente.Colore);
                    cldColori.Color=(coloreUC);
                    pnColore.BackColor = coloreUC;
                }
            }
            //controllo se l'utente passato ha un contratto da mostrare
            if (_contratto != null)
            {
                //se il contratto è terminato seleziono il radiobutton corrispondente
                if (_contratto.TipoContratto == 'D')
                    rbDeterminato.Checked = true;
                else
                    rbIndeterminato.Checked = true;
                nudMonteOre.Value = Convert.ToDecimal(_contratto.MonteOre);
                dtpDataInizio.Value = _contratto.DataInizioContratto;

                //se la data di fine contratto non è valorizzata disabilito il controllo (se è indeterminato)
                if (_contratto.DataFineContratto!=null)
                    dtpDataFine.Value = _contratto.DataFineContratto.Value;
                else
                    dtpDataFine.Enabled = false;

            }
            //controllo afferanza
            if(_afferenze!=null && _afferenze.Count>0)
                loadDipartimenti();
            //inserimento classe di concorso
            if (_richieste != null)
                loadCDC();
        }

        private void cbTipoUtente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTipoUtente.SelectedItem.ToString() == "D"  ||
                cbTipoUtente.SelectedItem.ToString() == "C" ||
                cbTipoUtente.SelectedItem.ToString() == "A")
            {
                ckbDocenteTeorico.Enabled = true;
                ckbDocentePratico.Enabled = true;
            }
            //se l'utente selezionato è amministratore o preside non gli è possibile selezionare il tipo di docente

            if (cbTipoUtente.SelectedItem.ToString() == "P")
            {
                ckbDocentePratico.Enabled = false;
                ckbDocenteTeorico.Enabled = false;
            }
        }
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
                    string _Email = $"{tbNome.Text}.{tbCognome.Text}@iismarconipieralisi.it";
                    tbEmail.Enabled = false;
                    tbEmail.Text = _Email;

                }

            }
            else
            {
                tbEmail.Enabled = true;
                tbEmail.Text = _imputEmail;

            }
        }
        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
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
            switch (cbTipoUtente.SelectedItem.ToString())
            {
                case "Docente":
                    pnCDC.Visible = true;
                    pnDipartimento.Visible = true;
                    PnContratto.Enabled = true;
                    PnContratto.Visible = true;
                    lbDcoordinato.Visible = false;
                    cbDipartimentoCoordinato.Visible = false;
                    break;

                case "Coordinatore di dipartimento":
                    pnCDC.Visible = true;
                    pnDipartimento.Visible = true;
                    PnContratto.Enabled = true;
                    PnContratto.Visible = true;
                    lbDcoordinato.Visible = true;
                    cbDipartimentoCoordinato.Visible = true;

                    break;
                default:
                    pnCDC.Visible = false;
                    pnDipartimento.Visible = false;
                    PnContratto.Enabled = false;
                    lbDcoordinato.Visible = false;
                    cbDipartimentoCoordinato.Visible = false;
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

        #region metodi di popolamento con query esterne
        private void popolaClbClasseDiConcorso(List<ClsClasseDiConcorsoDL> cdcs)
        {
            clbCLasseDiConcorso.Items.Clear();
            
            foreach (ClsClasseDiConcorsoDL c in cdcs)
            {
                clbCLasseDiConcorso.Items.Add($"{c.Livello} | {c.Nome}");
            }
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
            if (coord != null && coord.ID != _utente.ID)
            {
                DialogResult dr = MessageBox.Show($"Attualmente il dipartimento {dipartimentoScelto} viene coordinato da {coord.Cognome} {coord.Nome}; \nVuoi sostituirlo?",
                           "Cambio Coordinatore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    cdcUtente.Select(c => $"{c.Livello} | {c.Nome}"),
                    StringComparer.OrdinalIgnoreCase);

            // Scorro gli item della CheckedListBox
            for (int i = 0; i < clbCLasseDiConcorso.Items.Count; i++)
            {
                string nomeItem = clbCLasseDiConcorso.Items[i].ToString();

                if (cdcUtenteScritta.Contains(nomeItem))
                    clbCLasseDiConcorso.SetItemChecked(i, true);
            }
        }

        private string DividiClasseConcorso(string item)
        {
            string[] vs = item.Split('|');
            return vs[0];
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

        public Color OttieniColore(string rgb)
        {
            int r = int.Parse(rgb.Substring(0, 3));
            int g = int.Parse(rgb.Substring(3, 3));
            int b = int.Parse(rgb.Substring(6, 3));
            return Color.FromArgb(r, g, b);
        }

        public static string ScriviColore(Color colore)
        {
            return $"{colore.R:D3}{colore.G:D3}{colore.B:D3}";
        }


    }

    #endregion

}
