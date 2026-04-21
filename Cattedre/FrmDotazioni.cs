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
    public partial class FrmDotazioni : Form
    {
        List<ClsDotareDL> dots = new List<ClsDotareDL>();
        List<ClsClasseDiConcorsoDL> cdcs = new List<ClsClasseDiConcorsoDL>();
        public FrmDotazioni()
        {
            InitializeComponent();
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmDotazione frmDotazione = new FrmDotazione();
            DialogResult dr = frmDotazione.ShowDialog();

            if (frmDotazione._dot.IdClasseDiConcorso <= 0)
                dr = DialogResult.No;
            if (dr == DialogResult.OK)
            {
                ClsDotareBL.InserisciDotare(frmDotazione._dot);
                CaricaListView();
            }
        }

        private void CaricaListView()
        {
            dots = ClsDotareBL.CaricaDotare();
            cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
            lvDotazioni.Items.Clear();
            for (int i = 0; i < dots.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dots[i].Id.ToString());
                lvi.SubItems.Add(ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(dots[i].IdAnnoscolastico));
                lvi.SubItems.Add(ClsClasseDiConcorsoBL.TrovaCodiceDaID(dots[i].IdClasseDiConcorso));
                lvi.SubItems.Add(dots[i].NumcattedreFatto.ToString());
                lvi.SubItems.Add(dots[i].NumcattedreDiritto.ToString());

                lvi.Tag = cdcs[i].ID;
                lvDotazioni.Items.Add(lvi);
            }
        }

        private void FrmDotazioni_Load(object sender, EventArgs e)
        {
            CaricaListView();
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvDotazioni.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = Convert.ToInt32(lvDotazioni.SelectedIndices[0]);
                FrmDotazione frmDotazione = new FrmDotazione();
                frmDotazione._dot = dots[indiceDaModificare];
                DialogResult dr = frmDotazione.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsDotareBL.AggiornaDotare(frmDotazione._dot);
                    CaricaListView();
                }
            }
            else
                MessageBox.Show("Selezionare un elemento da modificare", "attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvDotazioni.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvDotazioni.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvDotazioni.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsDotareBL.EliminaDotare(idDaEliminare);
                }

                CaricaListView();
            }
        }
    }
}
