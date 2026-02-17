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
    public partial class FrmIndirizzi : Form
    {
        public List<ClsIndirizzoDL> indirizzi = new List<ClsIndirizzoDL>();
        public FrmIndirizzi()
        {
            InitializeComponent();
        }

        private void CaricaListView(List<ClsIndirizzoDL> indirizzi)
        {
            lvIndirizzi.Items.Clear();

            foreach (ClsIndirizzoDL indirizzo in indirizzi)
            {
                ListViewItem lvi = new ListViewItem(indirizzo.Nome);
                lvi.Tag = indirizzo.ID;
                lvIndirizzi.Items.Add(lvi);
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmIndirizzo frmIndirizzo = new FrmIndirizzo();
            DialogResult dr = frmIndirizzo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ClsIndirizzoBL.InserisciIndirizzo(frmIndirizzo._indirizzo);
                indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
                CaricaListView(indirizzi);
            }
        }

        private void FrmIndirizzi_Load(object sender, EventArgs e)
        {
            indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
            CaricaListView(indirizzi);
        }

        private void brModifica_Click(object sender, EventArgs e)
        {
            if (lvIndirizzi.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvIndirizzi.SelectedIndices[0];
                FrmIndirizzo frmIndirizzo = new FrmIndirizzo();
                frmIndirizzo._indirizzo = indirizzi[indiceDaModificare];
                DialogResult dr = frmIndirizzo.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsIndirizzoBL.ModificaIndirizzo(frmIndirizzo._indirizzo, indiceDaModificare);
                    CaricaListView(indirizzi);
                }
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvIndirizzi.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvIndirizzi.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvIndirizzi.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsIndirizzoBL.EliminaIndirizzo(idDaEliminare);
                    indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
                }
                CaricaListView(indirizzi);
            }
        }

        private void btCerca_Click_1(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbRicerca.Text))
            {


            }
        }
    }
}
