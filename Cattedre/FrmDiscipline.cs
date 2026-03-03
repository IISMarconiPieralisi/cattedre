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

        private ClsUtenteDL UtenteLoggato;
        public FrmDiscipline(ClsUtenteDL utenteLog)
        {
            InitializeComponent();
            UtenteLoggato = utenteLog;
        }

        private void CaricaListView(List<ClsDisciplinaDL> discipline)
        {
            lvDiscipline.Items.Clear();
            foreach (ClsDisciplinaDL disciplina in discipline)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(disciplina.Anno));
                lvi.SubItems.Add(disciplina.Nome);
                lvi.SubItems.Add(Convert.ToString(disciplina.OreLaboratorio));
                lvi.SubItems.Add(Convert.ToString(disciplina.OreTeoria));
                lvi.SubItems.Add(Convert.ToString(disciplina.DisciplinaSpeciale));
                lvi.SubItems.Add(ClsDisciplinaBL.RilevaNomeDipartimento(disciplina.IDdipartimento));
                lvi.SubItems.Add(CaricaGraficamenteIndirizzi(disciplina));
                lvi.Tag = disciplina.ID;
                lvDiscipline.Items.Add(lvi);
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
                try
                {
                    ClsDisciplinaBL.InserisciDisciplina(frmDisciplina._disciplina);
                    int ID=ClsDisciplinaBL.CercaIdDisciplina(frmDisciplina._disciplina);
                    foreach (var appartenere in frmDisciplina._Apparteneres)
                    {
                        appartenere.IDdisicplina = ID;
                        ClsAppartenereBL.InserireAppartenere(appartenere);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show($"Errore: {ex.Message} in riga {ex.Source} /n riprovare", "Errore");
                }
                discipline = ClsDisciplinaBL.CaricaDiscipline();
                CaricaListView(discipline);

            }
        }

        private void FrmDiscipline_Load(object sender, EventArgs e)
        {
            discipline = ClsDisciplinaBL.CaricaDiscipline();
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
            CaricaListView(discipline);
            GestionePermessi();

            //popolo combobox filtraggio per dipartimenti
            foreach (ClsDipartimentoDL dipartimento in dipartimenti)
            {
                if(!cbDipartimenti.Items.Contains(dipartimento.Nome))
                cbDipartimenti.Items.Add(dipartimento.Nome);
            }
        }
        private void GestionePermessi()
        {
            if (UtenteLoggato != null && !(UtenteLoggato.TipoUtente == "A" || UtenteLoggato.TipoUtente == "C"))
            {
                btElimina.Visible = false;
                btInserisci.Visible = false;
                btModifica.Visible = false;
                lvDiscipline.Width = this.ClientSize.Width - (lvDiscipline.Left * 2);

                lvDiscipline.Height = this.ClientSize.Height - lvDiscipline.Top - 50;
                lvDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
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
                    ClsDisciplinaBL.EliminaDisciplina(idDaEliminare);
                }
                discipline = ClsDisciplinaBL.CaricaDiscipline();
                CaricaListView(discipline);
            }
            else
                MessageBox.Show("Seleziona una disciplina da cancellare", "domanda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    try
                    {
                        ClsDisciplinaBL.ModificaDisciplina(frmDisciplina._disciplina);
                        ClsAppartenereBL.ModificaAppartenenze(frmDisciplina._disciplina.ID, frmDisciplina._Apparteneres);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Errore nella modifica {ex.Message} \nRiprovare!", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    discipline = ClsDisciplinaBL.CaricaDiscipline();
                    CaricaListView(discipline);

                }
            }
        }

        private void btCerca_Click(object sender, EventArgs e)
        {
            long iddipartimento = 0;
            int anno = 0;
            string nome = tbDisciplina.Text.Trim();
            try
            {
                if (cbDipartimenti.SelectedIndex >= 0)
                    iddipartimento = dipartimenti[cbDipartimenti.SelectedIndex].ID;

                if (rbAnno1.Checked) anno = 1;
                else if (rbAnno2.Checked) anno = 2;
                else if (rbAnno3.Checked) anno = 3;
                else if (rbAnno4.Checked) anno = 4;
                else if (rbAnno5.Checked) anno = 5;

                if (iddipartimento == 0 && anno == 0 && string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Inserisci almeno un criterio di ricerca.");

                List<ClsDisciplinaDL> disciplineFiltrate =
                    ClsDisciplinaBL.CaricaDiscipline(iddipartimento, anno, nome);

                if (disciplineFiltrate == null || disciplineFiltrate.Count == 0)
                    throw new Exception("Nessuna disciplina trovata.");

                CaricaListView(disciplineFiltrate);
                btPulisciCb.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
            discipline = ClsDisciplinaBL.CaricaDiscipline();
            CaricaListView(discipline);
            btPulisciCb.Enabled = false;

        }

        private void cbDipartimenti_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string CaricaGraficamenteIndirizzi(ClsDisciplinaDL disc)
        {
            var listaIndirizzi = ClsAppartenereBL.caricaIndirizziDisciplina(disc.ID).Select(i => i.Nome);
            return string.Join(", ", listaIndirizzi);
        }
    }
}