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
        public List<ClsDipartimentoDL> dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();

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
                ListViewItem lvi = new ListViewItem(Convert.ToString(disciplina.ID));
                lvi.SubItems.Add(disciplina.Anno.ToString());
                lvi.SubItems.Add(disciplina.Nome);
                lvi.SubItems.Add(Convert.ToString(disciplina.OreLaboratorio));
                lvi.SubItems.Add(Convert.ToString(disciplina.OreTeoria));
                lvi.SubItems.Add((disciplina.DisciplinaSpeciale == string.Empty) ? "-" : disciplina.DisciplinaSpeciale);
                lvi.SubItems.Add(caricaGraficamenteDipartimenti(disciplina));
                lvi.SubItems.Add(CaricaGraficamenteIndirizzi(disciplina));
                if (disciplina.IDdisciplinaSuccessiva != 0)
                {
                    ClsDisciplinaDL discAssociata = ClsDisciplinaBL.RilevaDisciplina(disciplina.IDdisciplinaSuccessiva);
                    lvi.SubItems.Add($"{discAssociata.Nome } {discAssociata.Anno}°");
                }
                else
                    lvi.SubItems.Add("-");

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
                    this.Cursor = Cursors.WaitCursor;
                    ClsDisciplinaBL.InserisciDisciplina(frmDisciplina._disciplina);
                    int ID = ClsDisciplinaBL.CercaIdDisciplina(frmDisciplina._disciplina);
                    foreach (var appartenere in frmDisciplina._apparteneres)
                    {
                        appartenere.IDdisicplina = ID;
                        ClsAppartenereBL.InserireAppartenere(appartenere);
                    }
                    foreach (var gestire in frmDisciplina._gestires)
                    {
                        gestire.IDdisciplina = ID;
                        ClsGestireBL.InserireGestione(gestire);
                    }
                    foreach (var richiedere in frmDisciplina._richiederes)
                    {
                        richiedere.IDdisciplina = ID;
                        ClsRichiedereBL.InserisciRichiedere(richiedere);
                    }
                    this.Cursor = Cursors.Arrow;

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show($"Errore: {ex.Message} in riga {ex.Source} /n riprovare", "Errore");
                }
                discipline = ClsDisciplinaBL.CaricaDiscipline();
                CaricaListView(discipline);
            }
        }

        private void FrmDiscipline_Load(object sender, EventArgs e)
        {
            discipline = ClsDisciplinaBL.CaricaDiscipline();
            CaricaListView(discipline);
            GestionePermessi();

            //popolo combobox filtraggio per dipartimenti
            foreach (ClsDipartimentoDL dipartimento in dipartimenti)
            {
                if (!cbDipartimenti.Items.Contains(dipartimento.Nome))
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
                int idTag = Convert.ToInt32(lvDiscipline.Items[indiceDaEliminare].Tag);
                long idDaEliminare = discipline.Where(d => d.ID == idTag).Select(d => d.ID).FirstOrDefault(); // Prendiamo il primo risultato (o 0 se non trovato)
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
                int indiceDaModificare = lvDiscipline.SelectedIndices[0];
                FrmDisciplina frmDisciplina = new FrmDisciplina();
                int idCercato = Convert.ToInt32(lvDiscipline.Items[indiceDaModificare].Tag);
                // 2. Cerchiamo l'INTERO OGGETTO nella lista 'discipline'
                // Usiamo .FirstOrDefault() così se non lo trova restituisce null invece di crashare
                frmDisciplina._disciplina = discipline.FirstOrDefault(d => d.ID == idCercato);
                DialogResult dr = frmDisciplina.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        ClsDisciplinaBL.ModificaDisciplina(frmDisciplina._disciplina);
                        ClsAppartenereBL.ModificaAppartenenze(frmDisciplina._disciplina.ID, frmDisciplina._apparteneres);
                        ClsGestireBL.ModificaGestioni(frmDisciplina._disciplina.ID, frmDisciplina._gestires);
                        ClsRichiedereBL.ModificaRichiestaDisciplina(frmDisciplina._disciplina.ID, frmDisciplina._richiederes);
                        this.Cursor = Cursors.Arrow;

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Arrow;
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
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        string caricaGraficamenteDipartimenti(ClsDisciplinaDL disc)
        {
            List<string> listaIndirizzi = ClsGestireBL.DipartimentiDellaDisciplina(disc.ID).Select(i => i.Nome).ToList();
            if (listaIndirizzi.Count == 0) return "-";
            return string.Join(", ", listaIndirizzi);
        }
        #region controlli tastiera


        private void lvDiscipline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btModifica_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                btElimina_Click(null, null);
            }
        }
        #endregion

        private void tbDisciplina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbDisciplina.Text.Length > 2)
            {
                e.SuppressKeyPress = true;
                btCerca_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                tbDisciplina.Text = "";
                e.SuppressKeyPress = true;
                btPulisciCb_Click(null, null);
            }
        }

        private void cbDipartimenti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbDipartimenti.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;
                rbAnno1.Focus();
            }
        }
        private void rbAnni_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                tbDisciplina.Focus(); 
            }
        }
    }
}