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

                if (dtpDataFine.Value.Year - dtpDataInizio.Value.Year != 1)
                    throw new Exception("le date di inizio e fine, non possono coprire un intervallo di due anni.");

                _annoScolastico.DataInizio = dtpDataInizio.Value;
                _annoScolastico.DataFine = dtpDataFine.Value;
                this.DialogResult = DialogResult.OK;
            }catch(Exception Ex)
            {
                MessageBox.Show($"Attenzione:\n{Ex.Message}\nRiprovare!","Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }

        private void FrmAnnoScolastico_Load(object sender, EventArgs e)
        {
            if (_annoScolastico != null)
            {
                mtbSigla.Text = _annoScolastico.Sigla;
                CaricamentoDataFine();
                dtpDataInizio.Value = _annoScolastico.DataInizio;
            }
            else
            {
                // Valori di default per un nuovo inserimento
                dtpDataFine.Value = DateTime.Today.AddYears(1);
                dtpDataInizio.Value = DateTime.Today;
                AggiornaSigla();
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDataFine_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDataInizio.Value.Year == dtpDataFine.Value.Year)
                {
                    dtpDataFine.Value = (dtpDataFine.Value).AddYears(1);
                    throw new Exception("l'anno della data di fine non può essere la stessa della data di inizio.");
                }
                else if (dtpDataFine.Value.Year < dtpDataInizio.Value.Year)
                {
                    dtpDataFine.Value = (dtpDataFine.Value).AddYears(1);
                    throw new Exception("l'anno della data di fine non può minore della data di inizio.");
                }
                else
                    AggiornaSigla();
            }catch(Exception ex)
            {
                MessageBox.Show($"Attenzione,{ex.Message}\nRiprovare!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void dtpDataInizio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtpDataInizio.Value.Year == dtpDataFine.Value.Year)
                {
                    dtpDataFine.Value = (dtpDataFine.Value).AddYears(1);
                    throw new Exception("l'anno della data di inizio non può essere la stessa della data di fine.");
                }
                else if (dtpDataInizio.Value.Year > dtpDataFine.Value.Year)
                {
                    dtpDataInizio.Value = (dtpDataInizio.Value).AddYears(-1);
                    throw new Exception("l'anno della data di inizio non può maggiore della data di fine.");
                }
                else
                    AggiornaSigla();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Attenzione,{ex.Message}\nRiprovare!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
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
        private void CaricamentoDataFine()
        {
            dtpDataInizio.Value = (_annoScolastico.DataFine).AddYears(-1);
            dtpDataFine.Value = _annoScolastico.DataFine;
        }
    }
}
