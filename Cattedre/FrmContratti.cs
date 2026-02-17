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
    public partial class FrmContratti : Form
    {
        public List<ClsContrattoDL> contratti = new List<ClsContrattoDL>();
        public int indiceDaModificare = 0;

        public FrmContratti()
        {
            InitializeComponent();
        }

        private string TipoContrattoStringato(char tc)
        {
            string tcs;

            if (tc == 'D')
                tcs = "determinato";
            else
                tcs = "indeterminato";

            return tcs;
        }

        private string DataFineContratto(DateTime? data)
        {
            if (!data.ToString().StartsWith("01/01/0001"))
                return data.ToString().Substring(0, 10);
            else
                return "-";
        }

        private void CaricaListView(List<ClsContrattoDL> contratti, List<long> IDutenti)
        {
            lvContratti.Items.Clear();

            int i = 0;
            foreach (ClsContrattoDL contratto in contratti)
            {
                ListViewItem lvi = new ListViewItem(TipoContrattoStringato(contratto.TipoContratto));
                lvi.SubItems.Add(Convert.ToString(contratto.MonteOre));
                lvi.SubItems.Add(Convert.ToString(contratto.DataInizioContratto.ToShortDateString()));
                lvi.SubItems.Add(Convert.ToString(DataFineContratto(contratto.DataFineContratto)));
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(IDutenti[i]));
                lvi.Tag = contratto.ID;
                lvContratti.Items.Add(lvi);

                i++;
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmContratto frmContratto = new FrmContratto(0);
            DialogResult dr = frmContratto.ShowDialog();

            if (frmContratto._contratto.TipoContratto.ToString() == string.Empty)
                dr = DialogResult.No;
            if (dr == DialogResult.OK)
            {
                ClsContrattoBL.InserisciContratto(frmContratto._contratto, frmContratto.IDutente);
                contratti = ClsContrattoBL.CaricaContratti();

                CaricaListView(contratti, ClsContrattoBL.IDutenti);
            }
        }

        private void FrmContratti_Load(object sender, EventArgs e)
        {
            contratti = ClsContrattoBL.CaricaContratti();

            CaricaListView(contratti, ClsContrattoBL.IDutenti);
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvContratti.SelectedIndices.Count == 1)
            {
                indiceDaModificare = lvContratti.SelectedIndices[0];
                FrmContratto frmContratto = new FrmContratto(indiceDaModificare);
                frmContratto._contratto = contratti[indiceDaModificare];
                DialogResult dr = frmContratto.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //ClsContrattoBL.ModificaContratto(frmContratto._contratto, contratti, indiceDaModificare, frmContratto.IDutente);
                    CaricaListView(contratti, ClsContrattoBL.IDutenti);
                }
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvContratti.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvContratti.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvContratti.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    contratti = ClsContrattoBL.EliminaContratto(idDaEliminare);
                }
                CaricaListView(contratti, ClsContrattoBL.IDutenti);
            }
        }

        //if (lvContratti.SelectedIndices.Count == 1)
        //{
        //  int indiceDaEliminare = lvContratti.SelectedIndices[0];
        //  int idDaEliminare = Convert.ToInt32(lvContratti.Items[indiceDaEliminare].Tag);
        //  DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
        //  if (dr == DialogResult.Yes)
        //  {
        //      contratti = ClsContrattoBL.EliminaDisciplina(idDaEliminare);
        //  }
        //  CaricaListView(discipline, ClsDisciplinaBL.IDdipartimenti);
    }
}
