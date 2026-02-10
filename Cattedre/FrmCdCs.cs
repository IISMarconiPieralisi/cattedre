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
    public partial class FrmCdCs : Form
    {
        List<ClsClasseDiConcorsoDL> cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
        public int indiceDaModificare = 0;

        public FrmCdCs()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
            lvCdCs.Items.Clear();
            foreach (ClsClasseDiConcorsoDL cdc in cdcs)
            {
                ListViewItem lvi = new ListViewItem(cdc.Livello);
                lvi.SubItems.Add(cdc.Nome);
                lvi.SubItems.Add(cdc.AbilitazioniRichieste);
                lvi.Tag = cdc.ID;
                lvCdCs.Items.Add(lvi);
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmCdC frmCdC = new FrmCdC();
            DialogResult dr = frmCdC.ShowDialog();

            if (frmCdC._cdc.Nome == string.Empty)
                dr = DialogResult.No;
            if (dr == DialogResult.OK)
            {
                ClsClasseDiConcorsoBL.InserisciCdc(frmCdC._cdc);
                cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
                CaricaListView();
            }
        }

        private void FrmCdCs_Load(object sender, EventArgs e)
        {
            cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
            CaricaListView();
        }

        private void brModifica_Click(object sender, EventArgs e)
        {
            if (lvCdCs.SelectedIndices.Count == 1)
            {
                int ID =Convert.ToInt32(lvCdCs.SelectedItems[0].Tag);
                FrmCdC frmCdC = new FrmCdC();
                frmCdC._cdc = cdcs.Find(p=>p.ID== ID);
                DialogResult dr = frmCdC.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsClasseDiConcorsoBL.ModificaCdc(frmCdC._cdc, indiceDaModificare);
                    CaricaListView();
                }
            }
            else
                MessageBox.Show("Selezionare un elemento da modificare","attenzione",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvCdCs.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvCdCs.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvCdCs.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    ClsClasseDiConcorsoBL.EliminaCdc(idDaEliminare);
                
                CaricaListView();
            }
        }
    }
}
