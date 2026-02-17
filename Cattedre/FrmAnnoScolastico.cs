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
    public partial class FrmAnnoScolastico : Form
    {
        public ClsAnnoScolasticoDL _annoScolastico = new ClsAnnoScolasticoDL();

        public FrmAnnoScolastico()
        {
            InitializeComponent();
        }

        public bool DataFineValida(DateTime dataInizio, DateTime dataFine)
        {
            bool dataFineValida = true;

            if (dataFine <= dataInizio)
                dataFineValida = false;

            return dataFineValida;
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            _annoScolastico.Sigla = mtbSigla.Text;
            _annoScolastico.DataInizio = dtpDataInizio.Value;
            _annoScolastico.DataFine = dtpDataFine.Value;

            if (string.IsNullOrEmpty(_annoScolastico.Sigla) ||
            !DataFineValida(_annoScolastico.DataInizio, _annoScolastico.DataFine))
            {
                MessageBox.Show("Data fine non valida o sigla mancante");
                this.DialogResult = DialogResult.None;
            }
        }

        private void FrmAnnoScolastico_Load(object sender, EventArgs e)
        {
            if (_annoScolastico.Sigla != null)
            {
                mtbSigla.Text = _annoScolastico.Sigla;
                dtpDataInizio.Value = _annoScolastico.DataInizio;
                dtpDataFine.Value = _annoScolastico.DataFine;
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
