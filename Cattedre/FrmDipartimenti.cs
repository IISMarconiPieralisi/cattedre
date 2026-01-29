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

        public int IDscelta;
        public FrmDipartimenti()
        {
            InitializeComponent();
        }

        public bool CoordinatoreGiaImpegnato(int nuovoID)
        {
            return ClsDipartimentoBL.IDutenti.Contains(nuovoID);
        }

        private void FrmDocenti_Load(object sender, EventArgs e)
        {
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
            CaricaListView(ClsDipartimentoBL.IDutenti);
        }

        private void CaricaListView(List<int> IDutenti)
        {
            lvDipartimenti.Items.Clear();

            int i = 0;
            foreach (ClsDipartimentoDL dipartimento in dipartimenti)
            {
                ListViewItem lvi = new ListViewItem(dipartimento.Nome);
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(IDutenti[i]));
                lvi.Tag = dipartimento.ID;
                lvDipartimenti.Items.Add(lvi);

                i++;
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmDipartimento frmDipartimento = new FrmDipartimento(0);
            DialogResult dr = frmDipartimento.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (CoordinatoreGiaImpegnato(frmDipartimento.IDutente))
                    MessageBox.Show("Coordinatore già impegnato in un dipartimento");
                ClsDipartimentoBL.InserisciDipartimento(frmDipartimento._dipartimento, frmDipartimento.IDutente);
                dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                CaricaListView(ClsDipartimentoBL.IDutenti);
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvDipartimenti.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvDipartimenti.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvDipartimenti.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsDipartimentoBL.EliminaDipartimento(idDaEliminare);
                    dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                }
                dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                CaricaListView(ClsDipartimentoBL.IDutenti);
            }
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvDipartimenti.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvDipartimenti.SelectedIndices[0];
                FrmDipartimento frmDipartimento = new FrmDipartimento(indiceDaModificare);
                frmDipartimento._dipartimento = dipartimenti[indiceDaModificare];
                DialogResult dr = frmDipartimento.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsDipartimentoBL.ModificaDipartimento(frmDipartimento._dipartimento, indiceDaModificare, frmDipartimento.IDutente);
                    if (CoordinatoreGiaImpegnato(frmDipartimento.IDutente))
                        MessageBox.Show("Coordinatore già impegnato in un dipartimento");
                    dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
                    CaricaListView(ClsDipartimentoBL.IDutenti);
                }
            }
        }
    }
}
