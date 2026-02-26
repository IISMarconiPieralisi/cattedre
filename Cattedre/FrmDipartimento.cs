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
        List<ClsDipartimentoDL> _dip = ClsDipartimentoBL.CaricaDipartimenti();
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
                MessageBox.Show($"Errore: \n{ex.Message}\nRiprovare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmDipartimento_Load(object sender, EventArgs e)
        {
            CaricaCoordinatoriDisponibili(_dip);

            if (_dipartimento!= null)
            {
                tbNomeDipartimento.Text = _dipartimento.Nome;
                if (coordinatori.Any(c => c.ID == _dipartimento.IDutente))
                    cbCoordinatore.Text = ClsUtenteBL.RilevaNomeUtente(_dipartimento.IDutente);

            }

        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CaricaCoordinatoriDisponibili(List<ClsDipartimentoDL> listaDipartimenti)
        {
            var tuttiCoordinatori = ClsUtenteBL.CaricaCoordinatoriDipartimenti();

            var idOccupati = listaDipartimenti.Select(d => d.IDutente).ToList();
            var sorgenteDati = tuttiCoordinatori.Where(u => !idOccupati.Contains(u.ID)).Select(u => new{u.ID,NomeCompleto = u.Nome + " "+ u.Cognome}).ToList();

            cbCoordinatore.DataSource = sorgenteDati;
            cbCoordinatore.DisplayMember = "NomeCompleto";
            cbCoordinatore.ValueMember = "ID";
            if (sorgenteDati.Count <= 0)
                cbCoordinatore.Enabled = false;

            cbCoordinatore.SelectedIndex = -1;
        }
    }
}
