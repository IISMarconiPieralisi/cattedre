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
        public ClsClasseDL _classe = new ClsClasseDL();
        public List<ClsUtenteDL> coordinatori = new List<ClsUtenteDL>();
        public List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
        public List<ClsClasseDL> classiArticolateCon = new List<ClsClasseDL>();
        public long IDutente;
        public long IDindirizzo;
        public long IDclasseArticolataCon;
        int _indiceDaModificareCC;
        int _indiceDaModificareInd;
        int _indiceDaModificareClasseArticolataCon;

        public FrmClasse(int indiceDaModificareCC, int indiceDaModificareInd, int indiceDaModificareClasseArticolataCon)
        {
            InitializeComponent();
            _indiceDaModificareCC = indiceDaModificareCC;
            _indiceDaModificareInd = indiceDaModificareInd;
            _indiceDaModificareClasseArticolataCon = indiceDaModificareClasseArticolataCon;
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            _classe.Sigla = nudAnno.Value.ToString() + tbSezione.Text;
            _classe.Anno = Convert.ToInt32(nudAnno.Value);
            _classe.Sezione = tbSezione.Text;
            _classe.ClasseArticolataCon =Convert.ToInt32( cbClasseArticolataCon.Text.Trim());
            _classe.NomeCoordinatore = cbCoordinatore.Text;
            _classe.Indirizzo = cbIndirizzo.Text;

            if (string.IsNullOrEmpty(_classe.Sezione))
            {
                MessageBox.Show("Sezione mancante");
                this.DialogResult = DialogResult.None;
            }
            else
            {
                IDutente = ClsUtenteBL.RilevaIDutente(_classe.NomeCoordinatore.Substring(0, _classe.NomeCoordinatore.IndexOf(" ")),
                    _classe.NomeCoordinatore.Substring(_classe.NomeCoordinatore.IndexOf(" ") + 1));
                IDindirizzo = ClsIndirizzoBL.RilevaIDindirizzo(_classe.Indirizzo);
                IDclasseArticolataCon = ClsClasseBL.RilevaIDclasse( _classe.ClasseArticolataCon.ToString());
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClasse_Load(object sender, EventArgs e)
        {
            coordinatori = ClsUtenteBL.CaricaCoordinatoriClassi();
            indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
            classiArticolateCon = ClsClasseBL.CaricaClassi();

            cbCoordinatore.DataSource = coordinatori.Select(c => new { c.ID, NomeCompleto = c.Nome + " " + c.Cognome }).ToList();
            cbCoordinatore.DisplayMember = "NomeCompleto";
            cbCoordinatore.ValueMember = "ID";

            cbIndirizzo.DataSource = indirizzi.Select(i => new { i.ID, Nome = i.Nome }).ToList();
            cbIndirizzo.DisplayMember = "Nome";
            cbIndirizzo.ValueMember = "ID";

            cbClasseArticolataCon.DataSource = classiArticolateCon.Where(c => c.Anno == 1 && c.Sigla != _classe.Sigla).Select(c => new { c.ID, Sigla = c.Sigla }).ToList();
            cbClasseArticolataCon.DisplayMember = "Sigla";
            cbClasseArticolataCon.ValueMember = "ID";
            cbClasseArticolataCon.SelectedIndex = -1;

            if (_classe.Sigla != null)
            {
                nudAnno.Value = _classe.Anno;
                tbSezione.Text = _classe.Sezione;

                IDutente = ClsClasseBL.IDutenti[_indiceDaModificareCC];
                IDindirizzo = ClsClasseBL.IDindirizzi[_indiceDaModificareInd];
                IDclasseArticolataCon = ClsClasseBL.IDclassiArticolateCon[_indiceDaModificareClasseArticolataCon];

                cbCoordinatore.SelectedValue = IDutente;
                cbIndirizzo.SelectedValue = IDindirizzo;
                // Se l'ID esiste tra le classi filtrate, lo seleziona; altrimenti lascia vuoto
                if (classiArticolateCon.Any(c => c.ID == IDclasseArticolataCon))
                    cbClasseArticolataCon.SelectedValue = IDclasseArticolataCon;
                else
                    cbClasseArticolataCon.SelectedIndex = -1;
            }
            else
            {
                cbCoordinatore.SelectedText = "";
                cbIndirizzo.SelectedText = "";
                cbClasseArticolataCon.Text = "";
            }
        }

        private void nudAnno_ValueChanged(object sender, EventArgs e)
        {
            cbClasseArticolataCon.DataSource = classiArticolateCon.Where(c => c.Anno == nudAnno.Value && c.Sigla != _classe.Sigla).Select(c => new { c.ID, Sigla = c.Sigla }).ToList();
            cbClasseArticolataCon.DisplayMember = "Sigla";
            cbClasseArticolataCon.ValueMember = "ID";
            cbClasseArticolataCon.SelectedIndex = -1;
        }
    }
}
