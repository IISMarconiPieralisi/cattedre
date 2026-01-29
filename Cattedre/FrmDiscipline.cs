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
    public partial class FrmDiscipline : Form
    {
        public List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();
        public List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
        public int indiceDaModificare = 0;
        
        public FrmDiscipline()
        {
            InitializeComponent();
        }

        private void CaricaListView(List<ClsDisciplinaDL> discipline, List<int> IDdipartimenti)
        {
            lvDiscipline.Items.Clear();

            int i = 0;
            foreach (ClsDisciplinaDL disciplina in discipline)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(disciplina.Anno));
                lvi.SubItems.Add(disciplina.Nome);
                lvi.SubItems.Add(Convert.ToString(disciplina.OreLaboratorio));
                lvi.SubItems.Add(Convert.ToString(disciplina.OreTeoria));
                lvi.SubItems.Add(Convert.ToString(disciplina.DisciplinaSpeciale));
                lvi.SubItems.Add(ClsDisciplinaBL.RilevaNomeDipartimento(IDdipartimenti[i]));
                lvi.Tag = disciplina.ID;
                lvDiscipline.Items.Add(lvi);

                i++;
            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmDisciplina frmDisciplina = new FrmDisciplina();
            DialogResult dr = frmDisciplina.ShowDialog();

            if (frmDisciplina._disciplina.Nome == string.Empty)
                dr = DialogResult.No;
            if (dr == DialogResult.OK)
            {
                ClsDisciplinaBL.InserisciDisciplina(frmDisciplina._disciplina, frmDisciplina.IDdipartimento);
                discipline = ClsDisciplinaBL.CaricaDiscipline();
                CaricaListView(discipline, ClsDisciplinaBL.IDdipartimenti);
            }
        }

        private void FrmDiscipline_Load(object sender, EventArgs e)
        {
            discipline = ClsDisciplinaBL.CaricaDiscipline();
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
            CaricaListView(discipline, ClsDisciplinaBL.IDdipartimenti);

            //popolo combobox filtraggio per dipartimenti
            foreach(ClsDipartimentoDL dipartimento in dipartimenti)
            {
                if(!cbDipartimenti.Items.Contains(dipartimento.Nome))
                cbDipartimenti.Items.Add(dipartimento.Nome);
            }
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvDiscipline.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvDiscipline.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvDiscipline.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    discipline = ClsDisciplinaBL.EliminaDisciplina(idDaEliminare);
                }
                CaricaListView(discipline, ClsDisciplinaBL.IDdipartimenti);
            }
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvDiscipline.SelectedIndices.Count == 1)
            {
                indiceDaModificare = lvDiscipline.SelectedIndices[0];
                FrmDisciplina frmDisciplina = new FrmDisciplina();
                frmDisciplina._disciplina = discipline[indiceDaModificare];
                DialogResult dr = frmDisciplina.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsDisciplinaBL.ModificaDisciplina(frmDisciplina._disciplina, discipline, indiceDaModificare, frmDisciplina.IDdipartimento);
                    CaricaListView(discipline, ClsDisciplinaBL.IDdipartimenti);
                }
            }
        }

        private void btCerca_Click(object sender, EventArgs e)
        {
            List<ClsDisciplinaDL> disciplineFiltrate = new List<ClsDisciplinaDL>();
            int anno=0;
            long iddipartimento = (cbDipartimenti.SelectedIndex >= 0) ? dipartimenti[cbDipartimenti.SelectedIndex].ID : 0;
            string nome = tbDisciplina.Text;

            if (rbAnno1.Checked)
                anno = 1;
            else if (rbAnno2.Checked)
                anno = 2;
            else if (rbAnno3.Checked)
                anno = 3;
            else if (rbAnno4.Checked)
                anno = 4;
            else if (rbAnno5.Checked)
                anno = 5;

            disciplineFiltrate = ClsDisciplinaBL.CaricaDiscipline(iddipartimento, anno, nome);
            CaricaListView(disciplineFiltrate, ClsDisciplinaBL.IDdipartimenti);
        }

        private void btPulisciCb_Click(object sender, EventArgs e)
        {
            cbDipartimenti.Text = "";
            cbDipartimenti.SelectedText = "";
            cbDipartimenti.SelectedItem = null;
            tbDisciplina.Text = "";
            rbAnno1.Checked = false;
            rbAnno2.Checked = false;
            rbAnno3.Checked = false;
            rbAnno4.Checked = false;
            rbAnno5.Checked = false;
            lvDiscipline.Items.Clear();

        }

        private void cbDipartimenti_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}