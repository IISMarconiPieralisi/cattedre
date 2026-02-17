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
    public partial class FrmClassi : Form
    {
        public List<ClsClasseDL> classi = new List<ClsClasseDL>();
        List<ClsUtenteDL> _coordinatori = new List<ClsUtenteDL>();
        List<ClsIndirizzoDL> _indirizzi = new List<ClsIndirizzoDL>();

        public FrmClassi()
        {
            InitializeComponent();
        }

        public bool CoordinatoreGiaImpegnato(long nuovoID)
        {
            return ClsClasseBL.IDutenti.Contains(nuovoID);
        }

        private void CaricaListView(List<ClsClasseDL> classi, List<long> IDutenti, List<long> IDindirizzi, List<long> IDclassiArticolateCon)
        {
            lvClassi.Items.Clear();

            int i = 0;
            foreach (ClsClasseDL classe in classi)
            {
                ListViewItem lvi = new ListViewItem(classe.Sigla);
                lvi.SubItems.Add(classe.Anno.ToString());
                lvi.SubItems.Add(classe.Sezione);
                lvi.SubItems.Add(ClsClasseBL.RilevaSiglaClasse(IDclassiArticolateCon[i]));
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(IDutenti[i]));
                lvi.SubItems.Add(ClsIndirizzoBL.RilevaNomeIndirizzo(IDindirizzi[i]));

                lvi.Tag = classe.ID;
                lvClassi.Items.Add(lvi);

                i++;
            }
        }

        private void FrmClassi_Load(object sender, EventArgs e)
        {
            classi = ClsClasseBL.CaricaClassi();
            CaricaListView(classi, ClsClasseBL.IDutenti, ClsClasseBL.IDindirizzi, ClsClasseBL.IDclassiArticolateCon);

            //popolo combobox filtraggio
            foreach (ClsClasseDL classe in classi)
            {
                if (!cbAnnoClasse.Items.Contains(classe.Anno))
                    cbAnnoClasse.Items.Add(classe.Anno);
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmClasse frmClasse = new FrmClasse(0, 0, 0);
            DialogResult dr = frmClasse.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (CoordinatoreGiaImpegnato(frmClasse.IDutente))
                    MessageBox.Show("Coordinatore già impegnato in una classe");
                ClsClasseBL.InserisciClasse(frmClasse._classe, frmClasse.IDutente, frmClasse.IDindirizzo, frmClasse.IDclasseArticolataCon);
                classi = ClsClasseBL.CaricaClassi();
                CaricaListView(classi, ClsClasseBL.IDutenti, ClsClasseBL.IDindirizzi, ClsClasseBL.IDclassiArticolateCon);
            }
        }

        private void brModifica_Click(object sender, EventArgs e)
        {
            if (lvClassi.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = lvClassi.SelectedIndices[0];
                FrmClasse frmClasse = new FrmClasse(indiceDaModificare, indiceDaModificare, indiceDaModificare);
                frmClasse._classe = classi[indiceDaModificare];
                DialogResult dr = frmClasse.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsClasseBL.ModificaClasse(frmClasse._classe, indiceDaModificare, frmClasse.IDutente, frmClasse.IDindirizzo, frmClasse.IDclasseArticolataCon);
                    if (CoordinatoreGiaImpegnato(frmClasse.IDutente))
                        MessageBox.Show("Coordinatore già impegnato in un dipartimento");
                    classi = ClsClasseBL.CaricaClassi();
                    CaricaListView(classi, ClsClasseBL.IDutenti, ClsClasseBL.IDindirizzi, ClsClasseBL.IDclassiArticolateCon);
                }
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvClassi.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvClassi.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvClassi.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsClasseBL.EliminaClasse(idDaEliminare);
                    classi = ClsClasseBL.CaricaClassi();
                }
                CaricaListView(classi, ClsClasseBL.IDutenti, ClsClasseBL.IDindirizzi, ClsClasseBL.IDclassiArticolateCon);
            }
        }

        private void btCerca_Click(object sender, EventArgs e)
        {
            List<ClsClasseDL> classiFiltrate = ClsClasseBL.CaricaClassiFiltrate(Convert.ToInt32(cbAnnoClasse.Text));
            
            CaricaListView(classiFiltrate, ClsClasseBL.IDutenti, ClsClasseBL.IDindirizzi, ClsClasseBL.IDclassiArticolateCon);
        }

        private void btRipristina_Click(object sender, EventArgs e)
        {
            classi = ClsClasseBL.CaricaClassi();
            CaricaListView(classi, ClsClasseBL.IDutenti, ClsClasseBL.IDindirizzi, ClsClasseBL.IDclassiArticolateCon);
            cbAnnoClasse.Text = "";
        }
    }
}