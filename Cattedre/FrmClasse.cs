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
    public partial class FrmClasse : Form
    {
        public ClsClasseDL _classe {get;set; }
        #region dichiarazione ListeElementi
        List<ClsIndirizzoDL> _indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
        List<ClsClasseDL> _classi = ClsClasseBL.CaricaClassi();
        List<ClsClasseDL> _classiArticolate = new List<ClsClasseDL>();
        List<ClsUtenteDL> _coordinatori = ClsUtenteBL.CaricaDocenti();
        List<ClsDipartimentoDL> _dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
        List<ClsAnnoScolasticoDL> _anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
        #endregion
        bool _modifica = false;
        long _oldCoordinatore = -1;
        long _newcordinatore = -1;
        public FrmClasse()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDAZIONE INPUT IMMEDIATA
                // Controlliamo i campi obbligatori prima di creare oggetti o fare query
                if (string.IsNullOrWhiteSpace(mtbSezione.Text))
                    throw new Exception("Inserire la sezione della classe.");

                if (cbAnnoScolastico.SelectedIndex == -1)
                    throw new Exception("Anno scolastico non selezionato.");

                if (cbIndirizzo.SelectedIndex == -1)
                    throw new Exception("Indirizzo non selezionato.");

                //inizializzo l'oggetto se non è modifica
                if (!_modifica)
                    _classe = new ClsClasseDL();

                // ASSEGNAZIONE VALORI BASE
                _classe.Anno = Convert.ToInt32(nudAnno.Value);
                _classe.Sezione = mtbSezione.Text.Trim().ToUpper(); 
                _classe.Sigla = _classe.Anno.ToString() + _classe.Sezione;
                //assegnazione valori chiavi esterne
                _classe.IDannoscolastico = Convert.ToInt64(cbAnnoScolastico.SelectedValue);
                _classe.Idindirizzo = Convert.ToInt64(cbIndirizzo.SelectedValue);

                //  GESTIONE COORDINATORE 
                if (!string.IsNullOrWhiteSpace(cbCoordinatore.Text))
                {
                    _classe.Idutente = Convert.ToInt64(cbCoordinatore.SelectedValue);
                }
                //gestione classe articolata
                if(cbClasseArticolataCon.SelectedIndex>-1)
                    _classe.ClasseArticolataCon =Convert.ToInt32(cbClasseArticolataCon.SelectedValue);

                //  gestisco i duplicati
                // Se stiamo modificando, l'ID esiste già quindi il controllo va saltato o gestito diversamente
                if (!_modifica)
                {
                    if (ClsClasseBL.RilevaIDclasse(_classe) >0)
                    {
                        throw new Exception("Attenzione: una classe con questi parametri è già presente nel database.");
                    }
                }
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un problema:\n{ex.Message}","Errore di validazione",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClasse_Load(object sender, EventArgs e)
        {
            //gestione fonte dati delle combobox per il popolamento
            cbCoordinatore.SelectedIndexChanged -= cbCoordinatore_SelectedIndexChanged;
            cbCoordinatore.DataSource = _coordinatori;
            cbCoordinatore.DisplayMember = "Email";
            cbCoordinatore.ValueMember = "ID";
            cbCoordinatore.SelectedIndex = -1;
            cbCoordinatore.SelectedIndexChanged += cbCoordinatore_SelectedIndexChanged;

            cbIndirizzo.DataSource = _indirizzi;
            cbIndirizzo.DisplayMember = "Nome";
            cbIndirizzo.ValueMember = "ID";
            cbIndirizzo.SelectedIndex = -1;
            cbAnnoScolastico.DataSource = _anniScolastici;
            cbAnnoScolastico.DisplayMember = "Sigla";
            cbAnnoScolastico.ValueMember = "ID";
            cbAnnoScolastico.SelectedIndex = -1;

            if (_classe != null && _classe.ID > 0)
            {
                _modifica = true;
                nudAnno.Value = _classe.Anno;
                mtbSezione.Text = _classe.Sezione;
                nudAnno_ValueChanged(null, null);
                //popolamento FK
                cbIndirizzo.SelectedValue = (_classe.Idindirizzo > 0) ? _classe.Idindirizzo : -1;
                //tolgo e rimuovo il selectedIndexChanged per non dare errori durante il popolamento
                cbCoordinatore.SelectedIndexChanged -= cbCoordinatore_SelectedIndexChanged;
                cbCoordinatore.SelectedValue = (_classe.Idutente > 0) ? _classe.Idutente : -1;
                cbCoordinatore.SelectedIndexChanged += cbCoordinatore_SelectedIndexChanged;
                _oldCoordinatore = _classe.Idutente;

                cbAnnoScolastico.SelectedValue = (_classe.IDannoscolastico>0) ? _classe.IDannoscolastico: -1;

                if (_classe.ClasseArticolataCon > 0)
                {
                    PopolaClassiArticolate(); // lo richiamo per sicurezza
                    cbClasseArticolataCon.SelectedValue = _classe.ClasseArticolataCon;
                }
                else
                    cbClasseArticolataCon.SelectedIndex = -1;
            }
            else
            {
                cbCoordinatore.SelectedIndex = -1;
                cbIndirizzo.SelectedIndex = -1;
                cbClasseArticolataCon.SelectedIndex = -1;
            }
        }
        private void nudAnno_ValueChanged(object sender, EventArgs e)
        {
            PopolaClassiArticolate();
            if (nudAnno.Value != 0 && cbAnnoScolastico.SelectedIndex != -1)
                cbClasseArticolataCon.Enabled = true;
            else
                cbClasseArticolataCon.Enabled = false;
        }

        private void PopolaClassiArticolate()
        {
            cbClasseArticolataCon.DataSource = null;
            cbClasseArticolataCon.Items.Clear();
            _classiArticolate.Clear();

            if (cbAnnoScolastico.SelectedIndex == -1) return;

            var annoScolastico = cbAnnoScolastico.SelectedItem as ClsAnnoScolasticoDL;
            long idAnnoSelezionato = annoScolastico.ID;
            int anno = (int)nudAnno.Value;

            foreach (ClsClasseDL classe in _classi)
            {
                if (classe.Anno == anno && classe.IDannoscolastico == idAnnoSelezionato)
                {
                    // Escludi la classe stessa in modalità modifica
                    if (_classe == null || _classe.ID != classe.ID)
                        _classiArticolate.Add(classe);
                }
            }

            // Aggiunge la classe attualmente articolata solo se non è già nella lista
            if (_classe != null && _classe.ID > 0 && _classe.ClasseArticolataCon > 0)
            {
                if (!_classiArticolate.Any(c => c.ID == _classe.ClasseArticolataCon))
                    _classiArticolate.Add(ClsClasseBL.CaricaClasse(_classe.ClasseArticolataCon));
            }

            cbClasseArticolataCon.DataSource = _classiArticolate;
            cbClasseArticolataCon.DisplayMember = "Sigla";
            cbClasseArticolataCon.ValueMember = "ID";
            cbClasseArticolataCon.SelectedIndex = -1;
        }


        private void cbCoordinatore_SelectedIndexChanged(object sender, EventArgs e)
        {
            var docente = cbCoordinatore.SelectedItem as ClsUtenteDL;
            // Usiamo SelectedValue e facciamo il cast a long
            if (cbCoordinatore.SelectedValue != null)
            {
                long selectedId = docente.ID; // Ora hai l'ID come long in modo sicuro
                if (cbAnnoScolastico.SelectedValue == null) return;
                long idAnnoAttuale = Convert.ToInt64(cbAnnoScolastico.SelectedValue);
                // Se non siamo in modifica e l'ID selezionato non è quello precedente
                if (!_modifica && _classi.Any(c => c.Idutente == selectedId && c.IDannoscolastico==Convert.ToInt32(cbAnnoScolastico.SelectedValue) &&  selectedId != 0))
                {
                    MessageBox.Show("Coordinatore già impegnato in una classe", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Disabilitiamo temporaneamente l'evento per evitare loop infiniti
                    cbCoordinatore.SelectedIndexChanged -= cbCoordinatore_SelectedIndexChanged;
                    cbCoordinatore.SelectedValue = _oldCoordinatore;
                    cbCoordinatore.SelectedIndexChanged += cbCoordinatore_SelectedIndexChanged;
                }
                else
                {
                    _newcordinatore = selectedId;
                }
            }
        }

        private void cbCoordinatore_DropDown(object sender, EventArgs e)
        {
            if (cbCoordinatore.SelectedValue != null)
            {
                _oldCoordinatore = Convert.ToInt64(cbCoordinatore.SelectedValue);
            }
        }

        private void cbCoordinatore_Format(object sender, ListControlConvertEventArgs e)
        {
            var coordinatore = (ClsUtenteDL)e.ListItem;
            e.Value = $"{coordinatore.Cognome} {coordinatore.Nome}";
        }

        private void cbAnnoScolastico_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopolaClassiArticolate();
            if (nudAnno.Value != 0 && cbAnnoScolastico.SelectedIndex != -1)
                cbClasseArticolataCon.Enabled = true;
            else
                cbClasseArticolataCon.Enabled = false;
        }

        private void nudAnno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                mtbSezione.Focus();
            }
        }

        private void mtbSezione_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && mtbSezione.Text.Length >= 2)
            {
                e.SuppressKeyPress = true;
                cbAnnoScolastico.Focus();
            }
        }

        private void cbAnnoScolastico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbAnnoScolastico.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;
                cbClasseArticolataCon.Focus();
            }
        }

        private void cbClasseArticolataCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbIndirizzo.Focus();
            }else if(e.KeyCode==Keys.Cancel || e.KeyCode==Keys.Escape)
            {
                e.SuppressKeyPress = true;
                cbClasseArticolataCon.SelectedIndex = -1;
            }
        }

        private void cbIndirizzo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbIndirizzo.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;
                cbCoordinatore.Focus();
            }
        }


        private void cbCoordinatore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbCoordinatore.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;
                btSalva.Focus();
            }
        }


    }
}
