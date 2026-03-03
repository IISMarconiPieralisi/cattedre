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
        public List<ClsAnnoScolasticoDL> anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();

        public FrmAnniScolastici()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
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
                try
                {
                    ClsAnnoScolasticoBL.InserisciAnnoScolastico(frmAnnoScolastico._annoScolastico);
                }catch(Exception ex)
                {
                    MessageBox.Show($"Errore:\n{ex.Message}\nRiprovare!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
                CaricaListView();
            }
        }

        private void FrmAnniScolastici_Load(object sender, EventArgs e)
        {
            CaricaListView();
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvAnniScolastici.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvAnniScolastici.SelectedIndices[0];
                long id = Convert.ToInt32(lvAnniScolastici.Items[indiceDaModificare].Tag);
                FrmAnnoScolastico frmAnnoScolastico = new FrmAnnoScolastico();
                frmAnnoScolastico._annoScolastico = anniScolastici.FirstOrDefault(p=>p.ID==id);
                DialogResult dr = frmAnnoScolastico.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ClsAnnoScolasticoBL.ModificaAnnoScolastico(frmAnnoScolastico._annoScolastico); 
                    }catch (Exception ex)
                    {
                        MessageBox.Show($"Errore:\n{ex.Message}\nRiprovare!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CaricaListView();
                }
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvAnniScolastici.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvAnniScolastici.SelectedIndices[0];
                long idDaEliminare = Convert.ToInt32(lvAnniScolastici.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsAnnoScolasticoBL.EliminaAnnoScolastico(idDaEliminare);
                }
                CaricaListView();
            }
        }
    }
}
