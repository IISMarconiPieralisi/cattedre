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
    public partial class FrmDipartimento : Form
    {
        public List<ClsUtenteDL> coordinatori = new List<ClsUtenteDL>();
        public ClsDipartimentoDL _dipartimento = new ClsDipartimentoDL();
        public int IDutente;
        int _indiceDaModificare;

        public FrmDipartimento(int indiceDaModificare)
        {
            InitializeComponent();
            _indiceDaModificare = indiceDaModificare;
        }

        private void btSalvaDipartimento_Click(object sender, EventArgs e)
        {
            _dipartimento.Nome = tbNomeDipartimento.Text;
            _dipartimento.NomeCoordinatore = cbCoordinatore.Text;

            if (string.IsNullOrEmpty(_dipartimento.Nome))
            {
                MessageBox.Show("Nome mancante");
                this.DialogResult = DialogResult.None;
            }
            else
                IDutente = Convert.ToInt32(ClsUtenteBL.RilevaIDutente(_dipartimento.NomeCoordinatore.Substring(0, _dipartimento.NomeCoordinatore.IndexOf(" ")),
                    _dipartimento.NomeCoordinatore.Substring(_dipartimento.NomeCoordinatore.IndexOf(" ") + 1)));
        }

        private void FrmDipartimento_Load(object sender, EventArgs e)
        {
            coordinatori = ClsUtenteBL.CaricaCoordinatoriDipartimenti();
            FrmDipartimenti frmDipartimenti = new FrmDipartimenti();

            cbCoordinatore.DataSource = coordinatori.Select(c => new { c.ID, NomeCompleto = c.Nome + " " + c.Cognome }).ToList();
            cbCoordinatore.DisplayMember = "NomeCompleto";
            cbCoordinatore.ValueMember = "ID";

            if (_dipartimento.Nome != null)
            {
                tbNomeDipartimento.Text = _dipartimento.Nome;

                IDutente = ClsDipartimentoBL.IDutenti[_indiceDaModificare];

                if (coordinatori.Any(c => c.ID == IDutente))
                    cbCoordinatore.Text = ClsUtenteBL.RilevaNomeUtente(IDutente);
                else
                {
                    cbCoordinatore.SelectedIndex = -1;
                }
            }
            else
            {
                cbCoordinatore.SelectedText = "";
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
