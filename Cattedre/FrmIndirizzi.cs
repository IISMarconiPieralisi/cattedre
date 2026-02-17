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
        public List<ClsIndirizzoDL> indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
        string parametroRicerca = string.Empty;
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
                popolatabella();
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
                int ID = Convert.ToInt32(lvIndirizzi.SelectedItems[0].Tag);
                FrmIndirizzo frmIndirizzo = new FrmIndirizzo();
                frmIndirizzo._indirizzo = indirizzi.Find(p => p.ID == ID);
                DialogResult dr = frmIndirizzo.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsIndirizzoBL.ModificaIndirizzo(frmIndirizzo._indirizzo);
                }
                popolatabella();
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
                }
                popolatabella();
            }
        }
        
        private void btCerca_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbRicerca.Text))
            {
                btAnnulla.Enabled = true;
                 parametroRicerca = tbRicerca.Text.Trim().ToLower();
                indirizzi = ClsIndirizzoBL.RicercaPerNome(parametroRicerca);
                CaricaListView(indirizzi);
            }
            else
                MessageBox.Show("Inserire Input valido per la ricerca","attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            btCerca.Enabled = false;
            btAnnulla.Enabled = false;
            parametroRicerca = string.Empty;
            tbRicerca.Text = string.Empty;
            popolatabella();
           
        }
        private void popolatabella()
        {
            if (!string.IsNullOrWhiteSpace(parametroRicerca))
                indirizzi = ClsIndirizzoBL.RicercaPerNome(parametroRicerca);
            else
                indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
            CaricaListView(indirizzi);


        }

        private void tbRicerca_TextChanged(object sender, EventArgs e)
        {
            if (tbRicerca.Text.Length<2 && parametroRicerca == string.Empty)
                btCerca.Enabled = false;
            else
                btCerca.Enabled = true;


        }
    }
}
