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
        public List<ClsUtenteDL> coordinatori = ClsUtenteBL.CaricaCoordinatoriDipartimenti();
        public ClsDipartimentoDL _dipartimento;
        List<ClsDipartimentoDL> _dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
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
                    _dipartimento.IDutente =Convert.ToInt32( cbCoordinatore.SelectedValue);
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
            CaricaCoordinatoriDisponibili(_dipartimenti);

            if (_dipartimento!= null)
            {
                tbNomeDipartimento.Text = _dipartimento.Nome;
                if (coordinatori.Any(c => c.ID == _dipartimento.IDutente))
                    cbCoordinatore.SelectedValue = _dipartimento.IDutente;

            }

        }
        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CaricaCoordinatoriDisponibili(List<ClsDipartimentoDL> listaDipartimenti)
        {
            var tuttiCoordinatori = ClsUtenteBL.CaricaCoordinatoriDipartimenti();
            var idOccupati = new HashSet<long>(listaDipartimenti.Select(d => d.IDutente));
            var sorgenteDati = tuttiCoordinatori
                .Select(u => new { u.ID, NomeCompleto = u.Nome + " " + u.Cognome })
                .ToList();

            cbCoordinatore.DataSource = null;
            cbCoordinatore.DisplayMember = "NomeCompleto";
            cbCoordinatore.ValueMember = "ID";
            cbCoordinatore.DataSource = sorgenteDati;
            cbCoordinatore.SelectedIndex = -1;
            cbCoordinatore.Enabled = sorgenteDati.Count > 0;
        }

        private void cbCoordinatore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCoordinatore.SelectedValue == null) return;

            var idSelezionato = (long)cbCoordinatore.SelectedValue;
            var idOccupati = _dipartimenti.Select(d => d.IDutente).ToHashSet();

            if (idOccupati.Contains(idSelezionato))
            {
               DialogResult dr= MessageBox.Show("Il coordinatore selezionato è già assegnato a un dipartimento,\n Vuoi sostituirlo?","Coordinatore occupato",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(dr==DialogResult.No)
                    cbCoordinatore.SelectedIndex = -1;
            }
        }
        #region controlli enter
        private void tbNomeDipartimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbNomeDipartimento.Text.Length >= 2)
            {
                e.SuppressKeyPress = true;
                cbCoordinatore.Focus();
            }
        }

        private void cbCoordinatore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbCoordinatore.SelectedIndex == -1)
            {
                e.SuppressKeyPress = true;
                btSalvaDipartimento.Focus();
            }
        }
        #endregion

    }
}
