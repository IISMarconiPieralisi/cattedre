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

      

        private void CaricaListView(List<ClsClasseDL> classi)
        {
            lvClassi.Items.Clear();
            foreach (ClsClasseDL classe in classi)
            {
                ListViewItem lvi = new ListViewItem(classe.Sigla);
                lvi.SubItems.Add(classe.Anno.ToString());
                lvi.SubItems.Add(classe.Sezione);
                lvi.SubItems.Add(ClsClasseBL.RilevaSiglaClasse(classe.ClasseArticolataCon));
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(classe.Idutente));
                lvi.SubItems.Add(ClsIndirizzoBL.RilevaNomeIndirizzo(classe.Idindirizzo));
                lvi.Tag = classe.ID;
                lvClassi.Items.Add(lvi);
            }
        }

        private void FrmClassi_Load(object sender, EventArgs e)
        {
            classi = ClsClasseBL.CaricaClassi();
            CaricaListView(classi);

            //popolo combobox filtraggio
            foreach (ClsClasseDL classe in classi)
            {
                if (!cbAnnoClasse.Items.Contains(classe.Anno))
                    cbAnnoClasse.Items.Add(classe.Anno);
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            try
            {
                FrmClasse frmClasse = new FrmClasse();
                DialogResult dr = frmClasse.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsClasseBL.InserisciClasse(frmClasse._classe);
                    classi = ClsClasseBL.CaricaClassi();
                    CaricaListView(classi);
                }
            }catch(Exception ex)
            {
                 MessageBox.Show($"errore:{ex.Message}\n riprovare", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void brModifica_Click(object sender, EventArgs e)
        {
            if (lvClassi.SelectedIndices.Count == 1)
            {

                long idDaModificare = Convert.ToInt64(lvClassi.SelectedItems[0].Tag);
                ClsClasseDL classeSelezionata = classi.Find(p => p.ID == idDaModificare);
                FrmClasse frmClasse = new FrmClasse();
                frmClasse._classe = classeSelezionata;
                DialogResult dr = frmClasse.ShowDialog();
                try
                {
                    if (dr == DialogResult.OK)
                    {
                        ClsClasseBL.ModificaClasse(frmClasse._classe);
                        classi = ClsClasseBL.CaricaClassi();
                        CaricaListView(classi);
                    }
                }catch (Exception ex)
                {
                   MessageBox.Show($"errore:{ex.Message}\n riprovare", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                CaricaListView(classi);
            }
        }

        private void btCerca_Click(object sender, EventArgs e)
        {

            List<ClsClasseDL> classiFiltrate = ClsClasseBL.CaricaClassiFiltrate(Convert.ToInt32(cbAnnoClasse.Text));
            
            CaricaListView(classiFiltrate);
        }

        private void btRipristina_Click(object sender, EventArgs e)
        {
            classi = ClsClasseBL.CaricaClassi();
            CaricaListView(classi);
            cbAnnoClasse.Text = "";
        }
    }
}