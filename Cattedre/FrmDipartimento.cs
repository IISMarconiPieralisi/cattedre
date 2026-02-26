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
        public ClsDipartimentoDL _dipartimento;

        public FrmDipartimento()
        {
            InitializeComponent();
        }

        private void btSalvaDipartimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dipartimento == null)
                    _dipartimento = new ClsDipartimentoDL();

                _dipartimento.Nome = tbNomeDipartimento.Text;
                if(cbCoordinatore.SelectedIndex!=-1)
                {
                    string[] parts = cbCoordinatore.Text.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    _dipartimento.IDutente = ClsUtenteBL.RilevaIDutente(parts[0], parts[1]);
                }
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                throw new Exception(ex.Message);
            }

        }

        private void FrmDipartimento_Load(object sender, EventArgs e)
        {
            coordinatori = ClsUtenteBL.CaricaCoordinatoriDipartimenti();
            cbCoordinatore.DataSource = coordinatori.Select(c => new { c.ID, NomeCompleto = c.Nome + " " + c.Cognome }).ToList();
            cbCoordinatore.DisplayMember = "NomeCompleto";
            cbCoordinatore.ValueMember = "ID";

            if (_dipartimento!= null)
            {
                tbNomeDipartimento.Text = _dipartimento.Nome;
                if (coordinatori.Any(c => c.ID == _dipartimento.IDutente))
                    cbCoordinatore.Text = ClsUtenteBL.RilevaNomeUtente(_dipartimento.IDutente);
                else
                    cbCoordinatore.SelectedIndex = -1;
            }
            else
                cbCoordinatore.SelectedIndex = -1;
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
