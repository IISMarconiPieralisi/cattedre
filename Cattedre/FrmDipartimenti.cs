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
    public partial class FrmDipartimenti : Form
    {
        public List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
        List<ClsUtenteDL> docentiDipartimento = new List<ClsUtenteDL>();
        List<ClsUtenteDL> _coordinatori = new List<ClsUtenteDL>();
        public FrmDipartimenti()
        {
            InitializeComponent();
        }



        private void CaricaListView()
        {
            lvDipartimenti.Items.Clear();

            foreach (ClsDipartimentoDL dipartimento in dipartimenti)
            {
                ListViewItem lvi = new ListViewItem(dipartimento.Nome);
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(dipartimento.IDutente));
                lvi.Tag = dipartimento.ID;
                lvDipartimenti.Items.Add(lvi);

            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmDipartimento frmDipartimento = new FrmDipartimento();
            DialogResult dr = frmDipartimento.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClsDipartimentoBL.InserisciDipartimento(frmDipartimento._dipartimento);
                }catch(Exception ex)
                {
                    MessageBox.Show($"Errore:\n{ex.Message}; \nRiprovare!","errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                CaricaListView();

            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvDipartimenti.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvDipartimenti.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvDipartimenti.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ClsDipartimentoBL.EliminaDipartimento(idDaEliminare);
                    dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                }
                dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                CaricaListView();
            }
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvDipartimenti.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvDipartimenti.SelectedIndices[0];
                FrmDipartimento frmDipartimento = new FrmDipartimento();
                frmDipartimento._dipartimento = dipartimenti[indiceDaModificare];
                DialogResult dr = frmDipartimento.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ClsDipartimentoBL.ModificaDipartimento(frmDipartimento._dipartimento);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore:\n{ex.Message}; \nRiprovare!", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                    CaricaListView();
                }
            }
        }

        private void FrmDipartimenti_Load(object sender, EventArgs e)
        {
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
            CaricaListView();
            _coordinatori = ClsUtenteBL.CaricaCoordinatoriDipartimenti();
        }
    }
}
