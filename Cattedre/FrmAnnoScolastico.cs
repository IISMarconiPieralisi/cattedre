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
        public ClsAnnoScolasticoDL _annoScolastico;

        public FrmAnnoScolastico()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (_annoScolastico == null)
                    _annoScolastico = new ClsAnnoScolasticoDL();
                _annoScolastico.Sigla = mtbSigla.Text;
                _annoScolastico.DataInizio = dtpDataInizio.Value;
                _annoScolastico.DataFine = dtpDataFine.Value;
                this.DialogResult = DialogResult.OK;
            }catch(Exception Ex)
            {
                MessageBox.Show($"Errore durante l'inserimento dei valori:\n{Ex.Message}\n Riprovare");
                this.DialogResult = DialogResult.None;
            }
        }

        private void FrmAnnoScolastico_Load(object sender, EventArgs e)
        {
            if (_annoScolastico != null)
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

        private void dtpDataFine_ValueChanged(object sender, EventArgs e)
        {
           
             if (dtpDataFine.Value > dtpDataInizio.Value)
            {
                MessageBox.Show("Attenzione, la data di fine non può essere precedente alla data di inizio.\nRiprovare!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataFine.Value = dtpDataInizio.Value;
            }
            else
            {
                AggiornaSigla();
            }
        }

        private void dtpDataInizio_ValueChanged(object sender, EventArgs e)
        {

            if (dtpDataFine.Value > dtpDataInizio.Value)
            {
                MessageBox.Show("Attenzione, la data di inizio non può essere successiva alla data di fine.\nRiprovare!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataInizio.Value = dtpDataFine.Value;
            }
            else
                AggiornaSigla();
        }

        private void AggiornaSigla()
        {
            string[] parts = mtbSigla.Text.Split('-');

            if (parts.Length >= 2)
            {
                string annoInizio = dtpDataInizio.Value.Year.ToString();
                string annoFine = dtpDataFine.Value.Year.ToString();

                // Prendi solo le ultime 2 cifre dell'anno
                string annoInizioShort = annoInizio.Substring(annoInizio.Length - 2);
                string annoFineShort = annoFine.Substring(annoFine.Length - 2);

                mtbSigla.Text = $"{annoInizioShort}-{annoFineShort}";
            }
        }
    }
}
