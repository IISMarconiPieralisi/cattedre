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
        List<ClsDotareDL> dots = new List<ClsDotareDL>();
        public int indiceDaModificare = 0;

        public FrmCdCs()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
            dots = ClsDotareBL.CaricaDotare(1);
            lvCdCs.Items.Clear();
            for(int i = 0; i < cdcs.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(cdcs[i].Livello);
                lvi.SubItems.Add(cdcs[i].Nome);
                lvi.SubItems.Add(cdcs[i].AbilitazioniRichieste);
                lvi.SubItems.Add(ClsDotareBL.TrovaNumCattedreDiDiritto(cdcs[i].ID).ToString());
                lvi.SubItems.Add(ClsDotareBL.TrovaNumCattedreDiFatto(cdcs[i].ID).ToString());
                lvi.Tag = cdcs[i].ID;
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
                long idCdc = ClsClasseDiConcorsoBL.InserisciCdc(frmCdC._cdc);
                ClsDotareBL.InserisciDotare(frmCdC._dot, idCdc);
                CaricaListView();
            }
        }

        private void FrmCdCs_Load(object sender, EventArgs e)
        {
            CaricaListView();
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvCdCs.SelectedIndices.Count == 1)
            {
                indiceDaModificare = Convert.ToInt32(lvCdCs.SelectedItems[0].Tag);
                FrmCdC frmCdC = new FrmCdC();
                frmCdC._cdc = cdcs.Find(p => p.ID == indiceDaModificare);
                frmCdC._dot = dots.Find(p => p.IdClasseDiConcorso == frmCdC._cdc.ID);
                DialogResult dr = frmCdC.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsClasseDiConcorsoBL.ModificaCdc(frmCdC._cdc, indiceDaModificare);
                    ClsDotareBL.AggiornaDotare(frmCdC._dot);
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
                {
                    ClsClasseDiConcorsoBL.EliminaCdc(idDaEliminare);
                    ClsDotareBL.EliminaDotare(1, idDaEliminare);
                }
                
                CaricaListView();
            }
        }
    }
}
