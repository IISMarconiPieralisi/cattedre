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
    public partial class FrmAnniScolastici : Form
    {
        public List<ClsAnnoScolasticoDL> anniScolastici = new List<ClsAnnoScolasticoDL>();

        public FrmAnniScolastici()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            lvAnniScolastici.Items.Clear();

            foreach (ClsAnnoScolasticoDL annoScolastico in anniScolastici)
            {
                ListViewItem lvi = new ListViewItem(annoScolastico.Sigla);
                lvi.SubItems.Add(annoScolastico.DataInizio.ToShortDateString());
                lvi.SubItems.Add(annoScolastico.DataFine.ToShortDateString());
                lvi.Tag = annoScolastico.ID;
                lvAnniScolastici.Items.Add(lvi);
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmAnnoScolastico frmAnnoScolastico = new FrmAnnoScolastico();
            DialogResult dr = frmAnnoScolastico.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ClsAnnoScolasticoBL.InserisciAnnoScolastico(frmAnnoScolastico._annoScolastico);
                anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
                CaricaListView();
            }
        }

        private void FrmAnniScolastici_Load(object sender, EventArgs e)
        {
            anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
            CaricaListView();
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvAnniScolastici.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvAnniScolastici.SelectedIndices[0];
                FrmAnnoScolastico frmAnnoScolastico = new FrmAnnoScolastico();
                frmAnnoScolastico._annoScolastico = anniScolastici[indiceDaModificare];
                DialogResult dr = frmAnnoScolastico.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsAnnoScolasticoBL.ModificaAnnoScolastico(frmAnnoScolastico._annoScolastico, indiceDaModificare);
                    CaricaListView();
                }
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvAnniScolastici.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvAnniScolastici.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvAnniScolastici.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsAnnoScolasticoBL.EliminaAnnoScolastico(idDaEliminare);
                    anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
                }
                CaricaListView();
            }
        }
    }
}
