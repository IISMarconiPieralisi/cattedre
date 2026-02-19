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
        public List<ClsUtenteDL> coordinatori = new List<ClsUtenteDL>();
        public List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
        public List<ClsClasseDL> _classi = new List<ClsClasseDL>();

        bool _modifica = false;
        string _oldCoordinatore = "";
        string _newcordinatore = "";
        public FrmClasse()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modifica) 
                    _classe = new ClsClasseDL();
                //associamento dei valori all'interno di  _classe
                _classe.Sigla = nudAnno.Value.ToString() + tbSezione.Text;
                _classe.Anno = Convert.ToInt32(nudAnno.Value);
                _classe.Sezione = tbSezione.Text;
            if(!string.IsNullOrWhiteSpace( cbClasseArticolataCon.Text))
                _classe.ClasseArticolataCon = Convert.ToInt32(ClsClasseBL.RilevaIDclasse(cbClasseArticolataCon.Text));

                if (string.IsNullOrEmpty(_classe.Sezione))
                    throw new IndexOutOfRangeException("inserire riga mancante");
                else
                {
                    string[] parts = cbCoordinatore.Text.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    _classe.Idutente = ClsUtenteBL.RilevaIDutente(parts[0], parts[1]);
                    _classe.Idindirizzo = ClsIndirizzoBL.RilevaIDindirizzo(cbIndirizzo.Text);

                    //se non ci sono stati errori significa che è andato a buon fine
                    this.DialogResult = DialogResult.OK;
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show($"errore:{ex.Message}\n riprovare", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }

}

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClasse_Load(object sender, EventArgs e)
        {
            // 1. Caricamento dati dai Business Logic
            coordinatori = ClsUtenteBL.CaricaCoordinatoriClassi();
            indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
            _classi = ClsClasseBL.CaricaClassi();

            PopolaCoordinatori();
            PopolaIndirizzi();

            if (_classe != null && _classe.ID > 0)
            {
                _modifica = true;
                nudAnno.Value = _classe.Anno;
                tbSezione.Text = _classe.Sezione;
                if (_classe.Idutente > 0)
                    cbCoordinatore.SelectedItem = $"{coordinatori.Find(p => p.ID == _classe.Idutente).Nome} { coordinatori.Find(p => p.ID == _classe.Idutente).Cognome}"; ;

                if (_classe.Idindirizzo > 0)
                    cbIndirizzo.SelectedItem = indirizzi.Find(p => p.ID == _classe.Idindirizzo).Nome;

                nudAnno_ValueChanged(null, null);
                if (_classe.ClasseArticolataCon > 0)
                    cbClasseArticolataCon.SelectedItem = _classi.Find(p => p.ID == _classe.ClasseArticolataCon).Sigla;
                else
                    cbClasseArticolataCon.SelectedIndex = -1;
            }
            else
            {

                cbCoordinatore.SelectedIndex = -1;
                cbIndirizzo.SelectedIndex = -1;
                cbClasseArticolataCon.SelectedIndex = -1;
            }
            _modifica = false;
        }
        private void nudAnno_ValueChanged(object sender, EventArgs e)
        {
            PopolaClassiArticolate((int)nudAnno.Value);
        }
        public bool CoordinatoreGiaImpegnato(long nuovoID)
        {
            if (ClsUtenteBL.RilevaNomeUtente(nuovoID) != "-")
                return false;
            else
                return true;
        }
        private void PopolaCoordinatori()
        {
            cbCoordinatore.Items.Clear();
            foreach(ClsUtenteDL coordinatore in coordinatori)
                cbCoordinatore.Items.Add($"{coordinatore.Nome} {coordinatore.Cognome}");
        }
        private void PopolaIndirizzi()
        {
            cbIndirizzo.Items.Clear();
            foreach (ClsIndirizzoDL indirizzo in indirizzi)
                cbIndirizzo.Items.Add(indirizzo.Nome);
        }
        private  void PopolaClassiArticolate(int anno)
        {
            cbClasseArticolataCon.Items.Clear();
            foreach(ClsClasseDL classe in _classi)
            {
                if (anno == classe.Anno && classe.ID!=_classe.ID)
                    cbClasseArticolataCon.Items.Add(classe.Sigla);
            }
        }


        private void cbCoordinatore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!_modifica || CoordinatoreGiaImpegnato(_classe.Idutente))&& _newcordinatore!=cbCoordinatore.Text)
            {
                MessageBox.Show("Coordinatore già impegnato in una classe");
                cbCoordinatore.SelectedItem = _oldCoordinatore;
            }
            else
                _newcordinatore = cbCoordinatore.Text;
        }

        private void cbCoordinatore_DropDown(object sender, EventArgs e)
        {
            _oldCoordinatore = cbCoordinatore.Text;
        }
    }
}
