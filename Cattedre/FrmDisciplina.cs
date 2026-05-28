using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class FrmDisciplina : Form
    {
        List<ClsDipartimentoDL> _dipartimenti= ClsDipartimentoBL.CaricaDipartimenti();
        List<ClsIndirizzoDL> _indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
        List<ClsDisciplinaDL> _discipline = ClsDisciplinaBL.CaricaDiscipline();
        List<ClsClasseDiConcorsoDL> _cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
        List<ClsAnnoScolasticoDL> _anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
        //variabili pubbliche
        public List<ClsAppartenereDL> _apparteneres = new List<ClsAppartenereDL>();
        public List<ClsRichiedereDL> _richiederes = new List<ClsRichiedereDL>();
        public List<ClsGestireDL> _gestires = new List<ClsGestireDL>();
        public ClsDisciplinaDL _disciplina;
        public ClsVigereDL _vigere= new ClsVigereDL();
        //variabili private (da non passare) usate internamente
        private int anno = 0;
        private long _lastDiscSp=0;
        private long _lastTick;
        ClsUtenteDL _utenteLoggato;
        public FrmDisciplina(ClsUtenteDL _utenteloggato)
        {
            InitializeComponent();
            _utenteLoggato = _utenteloggato;
        }
        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (_disciplina == null || _disciplina.ID <= 0)
                    _disciplina = new ClsDisciplinaDL();
                if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato))
                    throw new Exception("Non hai i permessi necessari per creare una disciplina");

                _disciplina.Anno = anno;
                if (_disciplina.Anno == 0 && !chbDisciplinaSpeciale.Checked)
                    throw new Exception("inserire un anno valido");
                if (_disciplina.ID > 0 && _gestires.Count == 0)
                    _gestires = ClsGestireBL.CaricaGestioneDisciplina(_disciplina.ID);
                if (_disciplina.ID > 0 && _richiederes.Count == 0)
                    _richiederes = ClsRichiedereBL.CaricaClassiRichiedereConDisciplina(_disciplina.ID);
                if (_gestires.Count <= 0)
                    throw new Exception("Selezionare un dipartimento il quale gestisce la disciplina.");

                if (cbAnnoInizio.SelectedIndex <= -1)
                    throw new Exception("Selezionare l'anno di inizio della disciplina.");

                if (_richiederes.Count <= 0)
                    throw new Exception("Selezionare almeno una classe di concorso a cui la disciplina è riferita.");
                // --- Caricamento ID Classe Collegata ---
                if (_discipline.Any(p => _disciplina.ID > 0 && p.ID != _disciplina.ID))
                    _disciplina.IDdisciplinaSuccessiva = CercaDisciplina();
                if (nudOreLab.Value <= 0 && nudOreTeoria.Value <= 0)
                    throw new Exception("Selezionare le ore relative alla disciplina.");
                // --- Assegnazione Proprietà Base ---
                _disciplina.Nome = (tbNome.Text.Length >= 1)? tbNome.Text.Trim(): throw new Exception("inserire Nome con almeno 1 carattere");

                _disciplina.OreLaboratorio = (int)nudOreLab.Value;
                _disciplina.OreTeoria = (int)nudOreTeoria.Value;
                if (chbDisciplinaSpeciale.Checked)
                {
                    if (string.IsNullOrEmpty(cbDisciplinaSpeciale.Text)) throw new Exception("Inserire la descrizione della disciplina speciale");
                    _disciplina.DisciplinaSpeciale = cbDisciplinaSpeciale.Text.Trim().ToLower();
                }
                //gestione classe vigere 
                _vigere.IDannoInizio = Convert.ToInt32(cbAnnoInizio.SelectedValue);
                _vigere.IDannoFine = cbAnnoFine.SelectedIndex==-1?0:Convert.ToInt32(cbAnnoFine.SelectedValue);
                //controllo doppioni
                if (_disciplina.ID <= 0)
                {
                    if (ClsDisciplinaBL.CercaIdDisciplina(_disciplina) > 0)
                        throw new Exception("Disciplina già presente per questo anno.");
                }
                else
                {
                    long IDdisciplinaTrovata = ClsDisciplinaBL.CercaIdDisciplina(_disciplina);
                    if (IDdisciplinaTrovata>=0 && IDdisciplinaTrovata != _disciplina.ID)
                        throw new Exception("Disciplina già presente per questo anno.");
                }

                //Gestione Liste Collegate (ClsAppartenere) -
                foreach (var item in clbIndirizzi.CheckedItems)
                {
                    ClsIndirizzoDL indirizzo = _indirizzi.Find(d => d.Nome == item.ToString());
                    if (indirizzo != null)
                        _apparteneres.Add(new ClsAppartenereDL(indirizzo.ID));
                    
                }
                //successo
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il compilamento:\n{ex.Message} \nRiprovare!","errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmDisciplina_Load(object sender, EventArgs e)
        {
            controlloRadioBottom();
            PopolaclbIndirizzi();
            PopolaClbDipartenti();
            PopolaclbCdcs();
            //popolamento anno di inizio
            cbAnnoInizio.DataSource = _anniScolastici;
            cbAnnoInizio.ValueMember = "ID";
            cbAnnoInizio.DisplayMember = "sigla";
            cbAnnoInizio.SelectedIndex = -1;
            this.cbAnnoInizio.SelectedIndexChanged += new System.EventHandler(this.cbAnnoInizio_SelectedIndexChanged);

            if (_disciplina != null)
            {
                //carico le informazioni della disciplina successiva
                anno = _disciplina.Anno;
                tbNome.Text = _disciplina.Nome;
                nudOreLab.Value = _disciplina.OreLaboratorio;
                nudOreTeoria.Value = _disciplina.OreTeoria;
                CheckComboBoxs();
                checkClbDipartenti();
                checkClbCdcs();
                RiempiCbDisciplinaSuccessiva(_disciplina.Anno,_disciplina.IDdisciplinaSuccessiva);
                //carico le informazioni del collegamento con indirizzi
                _apparteneres = ClsAppartenereBL.CaricaClassiAppartenereByDisciplina(_disciplina.ID);
                LoadclbIndirizzi();
                //caricamento anno scolastico inizio e fine
                if(_vigere.IDannoInizio>0) cbAnnoInizio.SelectedValue = _vigere.IDannoInizio;
                if (_vigere.IDannoFine > 0) cbAnnoFine.SelectedValue = _vigere.IDannoFine;

            }
            else
                _disciplina = new ClsDisciplinaDL();
            CambiaAnnoDisciplinaSuccessivaPotenziale();



        }
        #region gestione ClsGestire
        private void clbDipartimenti_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _gestires.Clear();
            long IDdis = (_disciplina.ID <= 0) ? 0 : _disciplina.ID;
            // Cicliamo tutti gli elementi attualmente "checkati" nella UI
            for (int i = 0; i < clbDipartimenti.Items.Count; i++)
            {
                bool isChecked;
                if (i == e.Index)
                    isChecked = (e.NewValue == CheckState.Checked);
                else
                    isChecked = clbDipartimenti.GetItemChecked(i);
                // Troviamo l'oggetto dipartimento corrispondente al nome spuntato

                if (isChecked)
                {
                    string nome = clbDipartimenti.Items[i].ToString();

                    ClsDipartimentoDL dip = _dipartimenti.Find(d => d.Nome == nome);
                    if (dip != null)
                    {
                        _gestires.Add(new ClsGestireDL(dip.ID, IDdis));
                    }
                }

            }
            ControlloCbDisciplinaSuccessiva();
        }

        void checkClbDipartenti()
        {
            List<ClsDipartimentoDL> dipartimentiGestiti = ClsGestireBL.DipartimentiDellaDisciplina(_disciplina.ID);
            if (dipartimentiGestiti.Count > 0)
            {

                for (int i = 0; i < clbDipartimenti.Items.Count; i++)
                {
                    string nomeItem = clbDipartimenti.Items[i].ToString();

                    bool gestire = dipartimentiGestiti.Any(d => string.Equals(d.Nome, nomeItem, StringComparison.OrdinalIgnoreCase));

                    clbDipartimenti.SetItemChecked(i, gestire);
                }
                //quando ha fatto l'inserimento pulisce la lista per sicurezza
                _gestires.Clear();

            }
        }
        void PopolaClbDipartenti()
        {
            clbDipartimenti.Items.Clear();
            foreach (var dip in _dipartimenti)
            {
                clbDipartimenti.Items.Add(dip.Nome);
            }
        }
        #endregion
        #region Indirizzi
        private void LoadclbIndirizzi()
        {
            List<ClsIndirizzoDL> indirizziAppartenuti =ClsAppartenereBL.indirizziDellaDisciplina(_disciplina.ID);

            if (indirizziAppartenuti.Count > 0)
            {
                for (int i = 0; i < clbIndirizzi.Items.Count; i++)
                {
                    string nomeItem = clbIndirizzi.Items[i].ToString();

                    bool afferente = indirizziAppartenuti.Any(d => string.Equals(d.Nome, nomeItem, StringComparison.OrdinalIgnoreCase));

                    clbIndirizzi.SetItemChecked(i, afferente); 
                }
                //quando ha fatto l'inserimento pulisce la lista per sicurezza
                _apparteneres.Clear();
            }
        }

    
        private void PopolaclbIndirizzi()
        {
            clbIndirizzi.Items.Clear();
            foreach(var indirizzo in _indirizzi)
            {
                clbIndirizzi.Items.Add(indirizzo.Nome);
            }
        }
        #endregion
        #region gestisci Disciplina successiva
        private void CambiaAnnoDisciplinaSuccessivaPotenziale()
        {
            cbAnnoSuccessivo.Items.Remove(anno.ToString() + "°");   
            if (anno >= 1 && anno <= 4)
            {
                cbAnnoSuccessivo.Enabled = true;
                cbAnnoSuccessivo.SelectedItem = (anno + 1).ToString() + "°";
            }
            else if (anno == 5)
                cbAnnoSuccessivo.Enabled = true;
            else
            {
                cbAnnoSuccessivo.Enabled = false;
            }
        }
        private void ControlloCbDisciplinaSuccessiva()
        {
            if (_gestires.Count != 0 && _richiederes.Count != 0 && anno != 0)
            {
                cbDisciplinaSucessiva.Enabled = true;
                popolaCbDisciplinaSuccessiva();
                cbDisciplinaSucessiva.SelectedIndex = -1;
            }
            else
            {
                cbDisciplinaSucessiva.Enabled = false;
                cbDisciplinaSucessiva.DataSource = null;
            }
        }
        private void popolaCbDisciplinaSuccessiva()
        {
            if (_gestires.Count == 0 || _richiederes.Count == 0 || anno == 0 || cbAnnoSuccessivo.SelectedIndex==-1)
            {
                cbDisciplinaSucessiva.DataSource = null;
                cbDisciplinaSucessiva.Enabled = false;
                return;
            }
            else
                cbDisciplinaSucessiva.Enabled = true;

            int annoSuccessivo = int.Parse(cbAnnoSuccessivo.SelectedItem.ToString().Replace("°", ""));

            var potenzialiSuccessive = _discipline.Where(p =>p.Anno == annoSuccessivo &&
            !_discipline.Any(d => d.IDdisciplinaSuccessiva == p.ID && d.ID != _disciplina.ID)
                ).ToList();
            List<ClsDisciplinaDL> ListaDisciplineFiltrate = new List<ClsDisciplinaDL>();
            // 2. Per ogni disciplina potenziale, controlliamo se appartiene a uno dei nostri dipartimenti
            foreach (var disc in potenzialiSuccessive)
            {
                // Chiediamo alla BL quali dipartimenti gestiscono questa specifica disciplina 'disc'
                List<ClsGestireDL> gestioniDisc = ClsGestireBL.CaricaGestioneDisciplina(disc.ID);
                // Se esiste un'intersezione tra i dipartimenti di 'disc' e i dipartimenti in '_gestires' 
                if (gestioniDisc.Any(gd => _gestires.Any(g => g.IDdipartimento == gd.IDdipartimento)) &&
                    gestioniDisc.Any(r => _richiederes.Any(ric => ric.IDclassediconcorso == ric.IDclassediconcorso)))
                {
                    ListaDisciplineFiltrate.Add(disc);
                }
            }
            // 3. Popolamento della ComboBox
            cbDisciplinaSucessiva.DataSource = null;
            cbDisciplinaSucessiva.DataSource = ListaDisciplineFiltrate;
            cbDisciplinaSucessiva.DisplayMember = "Nome";
            cbDisciplinaSucessiva.ValueMember = "ID";
            cbDisciplinaSucessiva.SelectedIndex = -1;

        }
        /// <summary>
                 /// metodo che aggiunge un evento a ogni RadioBotom presente nel codice, in modo tale da prendere l'anno di quel oggetto
                 /// </summary>
        private void controlloRadioBottom()
        {
            // Cicla solo i controlli dentro il tuo pannello specifico
            foreach (Control c in pnRB.Controls)
            {
                if (c is RadioButton rb)
                    // Collega l'evento Click
                    rb.Click += RadioButton_Pannello_Click;
            }
        }
        private void RadioButton_Pannello_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                anno = Convert.ToInt16(rb.Text.Replace('°', ' ').Trim());
                ControlloCbDisciplinaSuccessiva();
            }
        }
        private void RiempiCbDisciplinaSuccessiva(int _anno, long _IDdiscSuccessiva)
        {
            if (_anno <= 5 && _anno > 0)
            {
                this.anno = _anno;

                if (_disciplina != null && _disciplina.ID > 0 && (_gestires == null || _gestires.Count == 0))
                    _gestires = ClsGestireBL.CaricaGestioneDisciplina(_disciplina.ID);

                if (_disciplina != null && _disciplina.ID > 0 && (_richiederes == null || _richiederes.Count == 0))
                    _richiederes = ClsRichiedereBL.CaricaClassiRichiedereConDisciplina(_disciplina.ID);

                popolaCbDisciplinaSuccessiva();

                if (_IDdiscSuccessiva > 0)
                    cbDisciplinaSucessiva.SelectedValue = _IDdiscSuccessiva;
                else
                    cbDisciplinaSucessiva.SelectedIndex = -1;

                // non sovrascrivere Enabled: è già gestito da popolaCbDisciplinaSuccessiva
            }
            else
            {
                cbDisciplinaSucessiva.DataSource = null;
                cbDisciplinaSucessiva.Enabled = false;
            }
        }
        private long CercaDisciplina()
        {
            long ID = 0;

            // Controlliamo se la combo è abilitata e se c'è un elemento effettivamente selezionato
            if (cbDisciplinaSucessiva.Enabled && cbDisciplinaSucessiva.SelectedValue != null)
            {
                // Poiché abbiamo impostato ValueMember = "ID", SelectedValue ci restituisce l'ID
                ID = Convert.ToInt32(cbDisciplinaSucessiva.SelectedValue);
            }

            return ID;
        }
        private void cbAnnoSuccessivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnnoSuccessivo.SelectedIndex != -1)
            {
                popolaCbDisciplinaSuccessiva();
            }
        }
        #endregion
        #region gestione anno
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                if (rb == rbPrimo) anno = 1;
                else if (rb == rbSecondo) anno = 2;
                else if (rb == rbTerzo) anno = 3;
                else if (rb == rbQuarto) anno = 4;
                else if (rb == rbQuinto) anno = 5;
            }
            CambiaAnnoDisciplinaSuccessivaPotenziale();
        }
        private void CheckComboBoxs()
        {
            switch (_disciplina.Anno)
            {
                case 1:
                    rbPrimo.Checked = true;
                    break;
                case 2:
                    rbSecondo.Checked = true;
                    break;
                case 3:
                    rbTerzo.Checked = true;
                    break;
                case 4:
                    rbQuarto.Checked = true;
                    break;
                case 5:
                    rbQuinto.Checked = true;
                    break;
                default:
                    {
                        chbDisciplinaSpeciale.Checked=true;
                        cbDisciplinaSpeciale.Text = _disciplina.DisciplinaSpeciale;
                    }
                    break;
               
            }
        }
        #endregion
        #region gestisci richiedere
        private string CreaCDCAbbreviata(ClsClasseDiConcorsoDL cdc)
        {
            // Tronco il nome se è troppo lungo, come in FrmUtente
            string nome = cdc.Nome.Length > 30 ? cdc.Nome.Substring(0, 30) + "..." : cdc.Nome;
            return $"{cdc.Livello} | {nome}";
        }

        private void clbCdcs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _richiederes.Clear();
            long IDdis = (_disciplina.ID <= 0) ? 0 : _disciplina.ID;

            for (int i = 0; i < clbCdcs.Items.Count; i++)
            {
                bool isChecked;
                if (i == e.Index)
                    isChecked = (e.NewValue == CheckState.Checked);
                else
                    isChecked = clbCdcs.GetItemChecked(i);

                if (isChecked)
                {
                    string itemFormattato = clbCdcs.Items[i].ToString();
                    // Estraggo il Livello dalla stringa formattata "Livello | Nome"
                    string livello = DividiClasseConcorso(itemFormattato);

                    // Cerco la CDC usando il Livello (come in FrmUtente)
                    ClsClasseDiConcorsoDL cdc = _cdcs.Find(d => d.Livello == livello);
                    if (cdc != null)
                    {
                        _richiederes.Add(new ClsRichiedereDL(cdc.ID, IDdis));
                    }
                }
            }
            ControlloCbDisciplinaSuccessiva();
        }
        private string DividiClasseConcorso(string itemFormattato)
        {
            string[] vs = itemFormattato.Split('|');
            return vs[0].Trim(); // Restituisco la parte prima della barra, senza spazi
        }

        void PopolaclbCdcs()
        {
            clbCdcs.Items.Clear();

            // Ordino le CDC per Livello e poi per Nome in ordine crescente
            var cdcsOrdinati = _cdcs
                .OrderBy(cdc => cdc.Livello)
                .ThenBy(cdc => cdc.Nome)
                .ToList();

            foreach (var cdc in cdcsOrdinati)
            {
                clbCdcs.Items.Add(CreaCDCAbbreviata(cdc));
            }
        }
        void checkClbCdcs()
        {
            List<ClsClasseDiConcorsoDL> cdcsDisciplina = ClsRichiedereBL.RilevaCDCDiscipina(_disciplina.ID);
            if (cdcsDisciplina.Count > 0)
            {
                // Ordino le CDC per Livello e poi per Nome in ordine crescente
                var cdcsDisciplinaOrdinati = cdcsDisciplina
                .OrderBy(cdc => cdc.Livello)
                .ThenBy(cdc => cdc.Nome)
                .ToList();

                // Creo un HashSet con le stringhe formattate delle CDC della disciplina
                var cdcDisciplinaFormattate = new HashSet<string>(
                    cdcsDisciplinaOrdinati.Select(c => CreaCDCAbbreviata(c)),
                    StringComparer.OrdinalIgnoreCase
                );

                for (int i = 0; i < clbCdcs.Items.Count; i++)
                {
                    string nomeItemFormattato = clbCdcs.Items[i].ToString();
                    // Confronto con la stringa formattata
                    bool richiedere = cdcDisciplinaFormattate.Contains(nomeItemFormattato);
                    clbCdcs.SetItemChecked(i, richiedere);
                }
                _richiederes.Clear();
            }
        }
        #endregion
        #region tasto enter
        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && tbNome.Text.Length>=2)
            {
                e.SuppressKeyPress = true;
                nudOreTeoria.Focus();
            }
        }
        private void nudOreTeoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                nudOreLab.Focus();
            }
        }

        private void nudOreLab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbAnnoInizio.Focus();
            }
        }
        private void cbAnnoInizio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbAnnoInizio.SelectedIndex > -1)
            {
                e.SuppressKeyPress = true;
                cbAnnoFine.Focus();
            }
        }
        private void cbAnnoFine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Cancel || e.KeyCode == Keys.Delete || e.KeyCode== Keys.Back)
            {
                e.SuppressKeyPress = true;
                cbAnnoFine.SelectedIndex = -1;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                rbPrimo.Focus();
            }
        }

        private void rbAnno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                clbIndirizzi.Focus();
            }
        }

        private void cbDisciplinaSucessiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btSalva.Focus();
            }else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                cbDisciplinaSucessiva.SelectedIndex = -1;
            }

        }

        private void clbIndirizzi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;
                if (elapsedMilliseconds < 800) // DOPPIO INVIO RAPIDO
                {
                    // Passa al prossimo controllo
                    _lastTick = 0;
                    clbDipartimenti.Focus();
                }
                else
                {
                    // Al primo colpo fa solo il check
                    int index = clbIndirizzi.SelectedIndex;
                    if (index != -1) clbIndirizzi.SetItemChecked(index, !clbIndirizzi.GetItemChecked(index));
                }
                _lastTick = currentTick;
            }
        }

        private void clbDipartimenti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;
                if (elapsedMilliseconds < 800) // DOPPIO INVIO RAPIDO
                {
                    // Passa al prossimo controllo
                    _lastTick = 0;
                    clbCdcs.Focus();
                }
                else
                {
                    // Al primo colpo fa solo il check
                    int index = clbDipartimenti.SelectedIndex;
                    if (index != -1) clbDipartimenti.SetItemChecked(index, !clbDipartimenti.GetItemChecked(index));
                }
                _lastTick = currentTick;
            }
        }

        private void clbCdcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;
                if (elapsedMilliseconds < 800) // DOPPIO INVIO RAPIDO
                {
                    // Passa al prossimo controllo
                    _lastTick = 0;
                    if (chbDisciplinaSpeciale.Checked) cbDisciplinaSpeciale.Focus();
                    else cbDisciplinaSucessiva.Focus();
                }
                else
                {
                    // Al primo colpo fa solo il check - CORREZIONE: usare clbCdcs invece di clbDipartimenti
                    int index = clbCdcs.SelectedIndex;
                    if (index != -1) clbCdcs.SetItemChecked(index, !clbCdcs.GetItemChecked(index));
                }
                _lastTick = currentTick;
            }
        }

        private void cbDisciplinaSpeciale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbDisciplinaSpeciale.Text.Length >= 2)
                btSalva.Focus();
        }
        private void cbAnnoSuccessivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbDisciplinaSucessiva.Focus();
            }
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                cbAnnoSuccessivo.SelectedIndex = -1;
                popolaCbDisciplinaSuccessiva();
            }
        }
        #endregion
        #region gestione DisciplinaSpeciale
        private void chbDisciplinaSpeciale_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDisciplinaSpeciale.Checked)
            {
                pnRB.Enabled = false;
                cbDisciplinaSucessiva.Enabled = false;
                chbDisciplinaSpeciale.Enabled = true;
                cbDisciplinaSpeciale.Enabled = true;
            }else
            {
                pnRB.Enabled = true;
                chbDisciplinaSpeciale.Enabled = true;
                cbDisciplinaSpeciale.Enabled = false;
                cbDisciplinaSpeciale.SelectedIndex = -1;
            }

        }

        #endregion

        private void cbAnnoInizio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnnoInizio.SelectedIndex != -1)
            {
                cbAnnoFine.SelectedIndex = -1;
                ClsAnnoScolasticoDL anno = ClsAnnoScolasticoBL.CercaAnnoScolastico(Convert.ToInt32(cbAnnoInizio.SelectedValue));
                cbAnnoFine.DataSource = _anniScolastici
                        .Where(a => a.DataInizio.Year >= anno.DataFine.Year)
                        .Prepend(anno).OrderByDescending(a => a.Sigla).ToList();
                cbAnnoFine.ValueMember = "ID";
                cbAnnoFine.DisplayMember = "sigla";
                cbAnnoFine.Enabled = (cbAnnoFine.Items.Count > 0);
                cbAnnoFine.SelectedIndex = -1;

            }
            else
                cbAnnoFine.Enabled = false;
        }
    }
}
