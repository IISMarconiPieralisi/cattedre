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
    public partial class FrmContratto : Form
    {
        List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
        public ClsContrattoDL _contratto = new ClsContrattoDL();
        public long IDutente;
        int _indiceDaModificare;

        public FrmContratto(int indiceDaModificare)
        {
            InitializeComponent();
            _indiceDaModificare = indiceDaModificare;
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            if (rbDeterminato.Checked)
                _contratto.TipoContratto = 'D';
            else
                _contratto.TipoContratto = 'I';
            _contratto.MonteOre = Convert.ToInt32(nudMonteOre.Value);
            _contratto.DataInizioContratto = dtpDataInizio.Value;
            if (_contratto.TipoContratto == 'D')
                _contratto.DataFineContratto = dtpDataFine.Value;
            else
                _contratto.DataFineContratto = null;

            if (_contratto.MonteOre <= 0)
            {
                MessageBox.Show("monte ore mancante");
                this.DialogResult = DialogResult.None;
            }
            else
                IDutente = Convert.ToInt32(cbUtente.SelectedValue);
        }

        private void FrmContratto_Load(object sender, EventArgs e)
        {
            FrmContratti frmContratti = new FrmContratti();
            utenti = ClsUtenteBL.CaricaUtenti();

            cbUtente.DataSource = utenti.Select(u => new { u.ID, NomeCompleto = u.Nome + " " + u.Cognome }).ToList();
            cbUtente.DisplayMember = "NomeCompleto";
            cbUtente.ValueMember = "ID";

            if (_contratto.MonteOre > 0)
            {
                if (_contratto.TipoContratto == 'D')
                    rbDeterminato.Checked = true;
                else
                    rbIndeterminato.Checked = true;
                nudMonteOre.Value = Convert.ToDecimal(_contratto.MonteOre);
                dtpDataInizio.Value = _contratto.DataInizioContratto;
                if (!_contratto.DataFineContratto.ToString().StartsWith("01/01/0001"))
                    dtpDataFine.Value = _contratto.DataFineContratto.Value;
                else
                    dtpDataFine.Enabled = false;
            }

            IDutente = ClsContrattoBL.IDutenti[_indiceDaModificare];

            cbUtente.SelectedIndex =(int) IDutente - 1;
        }

        private void rbIndeterminato_CheckedChanged(object sender, EventArgs e)
        {
            dtpDataFine.Enabled = false;
        }

        private void rbDeterminato_CheckedChanged(object sender, EventArgs e)
        {
            dtpDataFine.Enabled = true;
        }
    }
}
