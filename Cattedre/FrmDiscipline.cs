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
        private ClsUtenteDL _utenteLoggato;
        long iddipartimento = 0;
        int anno = 0;
        string nome = string.Empty;
        public FrmDiscipline(ClsUtenteDL utenteLog)
        {
            InitializeComponent();
            _utenteLoggato = utenteLog;
        }
        private void FrmDiscipline_Load(object sender, EventArgs e)
        {
            GestionePermessi();
            //popolo combobox filtraggio per dipartimenti
            this.cbDipartimenti.SelectedIndexChanged -= new System.EventHandler(this.cbDipartimenti_SelectedIndexChanged);
            cbDipartimenti.DataSource = dipartimenti;
            cbDipartimenti.ValueMember = "ID";
            cbDipartimenti.DisplayMember = "Nome";
            if (dipartimenti.Count <= 1)
            {
                cbDipartimenti.SelectedIndex = 0;
                cbDipartimenti.Enabled = false;
            }
            else
                cbDipartimenti.SelectedIndex = -1;

            this.cbDipartimenti.SelectedIndexChanged += new System.EventHandler(this.cbDipartimenti_SelectedIndexChanged);
            CaricaListView();


        }
        #region CRUD
        private void CaricaListView()
        {
            discipline = ClsDisciplinaBL.CaricaDiscipline(iddipartimento, anno, nome);
            lvDiscipline.Items.Clear();
            foreach (ClsDisciplinaDL disciplina in discipline)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(disciplina.ID));
                lvi.SubItems.Add(disciplina.Anno <= 0 ? "-" : disciplina.Anno.ToString());
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
            tbNumRecord.Text = discipline.Count().ToString();
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato)) return;

            FrmDisciplina frmDisciplina = new FrmDisciplina(_utenteLoggato);
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
                        appartenere.IDdisciplina = ID;
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
                    //vigere
                    frmDisciplina._vigere.IDdisciplina = ID;
                    ClsVigereBL.InserisciVigere(frmDisciplina._vigere);

                    this.Cursor = Cursors.Arrow;

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show($"Errore: {ex.Message} in riga {ex.Source} /n riprovare", "Errore");
                }
                CaricaListView();
            }
        }
        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvDiscipline.SelectedIndices.Count == 1)
            {
                if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato)) return;

                int indiceDaModificare = lvDiscipline.SelectedIndices[0];
                FrmDisciplina frmDisciplina = new FrmDisciplina(_utenteLoggato);
                int idCercato = Convert.ToInt32(lvDiscipline.Items[indiceDaModificare].Tag);
                frmDisciplina._disciplina = discipline.FirstOrDefault(d => d.ID == idCercato);
                //carico una copia delle discipline appartenere attuale
                List<ClsAppartenereDL> appartenerePrima = ClsAppartenereBL.CaricaClassiAppartenereByDisciplina(idCercato);
                List<ClsRichiedereDL> richiederePrima = ClsRichiedereBL.CaricaClassiRichiedereConDisciplina(idCercato);
                frmDisciplina._vigere = ClsVigereBL.RilevaVigereDisciplina(idCercato);
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
                        //gestione vigere, se vigere esiste lo modifico altrimenti lo creo, fatto per le discipline già esistenti
                        if (frmDisciplina._vigere.IDdisciplina > 0)
                            ClsVigereBL.ModificaVigere(frmDisciplina._vigere);
                        else
                        {
                            frmDisciplina._vigere.IDdisciplina = idCercato;
                            ClsVigereBL.InserisciVigere(frmDisciplina._vigere);
                        }
                        //controllo la differenza fra le appartenenze attuali e quelle vecchie
                        //se c'è un INdirizzo in meno cancelllo da assegnare le assegnazioni con IDdisciplina attuale e IDindirizzo (eliminato) anche più di uno
                        List<ClsAppartenereDL> _indirizziRimossi = appartenerePrima.Where(prima => !frmDisciplina._apparteneres
                        .Any(dopo => dopo.IDindirizzo == prima.IDindirizzo)).ToList();

                        foreach (var app in _indirizziRimossi)
                            ClsAssegnareBL.EliminaAssegnazioneDiscIndirizzo(app.IDdisciplina, app.IDindirizzo);

                        //controllo la differenza fra le richiedere attuali e quelle vecchie
                        //se c'è un cdc in meno cancelllo da assegnare le assegnazioni con IDdisciplina attuale e IDdisciplina cancellando quelle con 
                        // (eliminato) anche più di uno
                        List<ClsRichiedereDL> _cdcRimosse = richiederePrima.Where(prima => !frmDisciplina._richiederes
                        .Any(dopo => dopo.IDclassediconcorso == prima.IDclassediconcorso)).ToList();

                        foreach (var ric in _cdcRimosse)
                            ClsAssegnareBL.EliminaAssegnazioneDiscConcorso(ric.IDdisciplina, ric.IDclassediconcorso);

                        this.Cursor = Cursors.Arrow;

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show($"Errore nella modifica {ex.Message} \nRiprovare!", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CaricaListView();
                }
            }
        }
        private void btElimina_Click(object sender, EventArgs e)
        {
            if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato)) return;
            if (lvDiscipline.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvDiscipline.SelectedIndices[0];
                int idTag = Convert.ToInt32(lvDiscipline.Items[indiceDaEliminare].Tag);
                long idDaEliminare = discipline.Where(d => d.ID == idTag).Select(d => d.ID).FirstOrDefault(); // Prendiamo il primo risultato (o 0 se non trovato)
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ClsDisciplinaBL.EliminaDisciplina(idDaEliminare);
                }
                CaricaListView();
            }
            else
                MessageBox.Show("Seleziona una disciplina da cancellare", "domanda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        #endregion
        private void GestionePermessi()
        {
            if (_utenteLoggato == null) return;

            if (!ClsUtenteDL.UtenteCRUD(_utenteLoggato))
            {
                btElimina.Visible = false;
                btInserisci.Visible = false;
                btModifica.Visible = false;
                lvDiscipline.Width = this.ClientSize.Width - (lvDiscipline.Left * 2);
                lvDiscipline.Height = this.ClientSize.Height - lvDiscipline.Top - 50;
                lvDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                if(ClsUtenteDL.UtenteDocente(_utenteLoggato))
                {
                     dipartimenti = ClsDipartimentoBL.DipartimentiDocenti(_utenteLoggato.ID);
                    if (dipartimenti.Count > 0)
                        iddipartimento = dipartimenti[0].ID;
                }
            }
            if (_utenteLoggato.TipoUtente == "C")
            {
                iddipartimento =ClsDipartimentoBL.UtenteCoordinaDipartimento(_utenteLoggato.ID).ID;
                if (iddipartimento > 0)
                {
                    cbDipartimenti.Enabled = false;
                    cbDipartimenti.SelectedValue = iddipartimento;
                }
            }
        }
        #region filtri
        private void btCerca_Click(object sender, EventArgs e)
        {
             iddipartimento = 0;
             anno = 0;
             nome = tbDisciplina.Text.Trim();
            try
            {
                if (cbDipartimenti.SelectedIndex >= 0)
                    iddipartimento =Convert.ToInt32( cbDipartimenti.SelectedValue);

                if (rbAnno1.Checked) anno = 1;
                else if (rbAnno2.Checked) anno = 2;
                else if (rbAnno3.Checked) anno = 3;
                else if (rbAnno4.Checked) anno = 4;
                else if (rbAnno5.Checked) anno = 5;

                if (iddipartimento == 0 && anno == 0 && string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Inserisci almeno un criterio di ricerca.");

                CaricaListView();
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
            tbDisciplina.Text = "";
            rbAnno1.Checked = false;
            rbAnno2.Checked = false;
            rbAnno3.Checked = false;
            rbAnno4.Checked = false;
            rbAnno5.Checked = false;
            if(ClsUtenteDL.UtenteAdmin(_utenteLoggato))
            {
                cbDipartimenti.SelectedItem = null;
                iddipartimento = 0;
            }
             anno = 0;
             nome = string.Empty;
            btPulisciCb.Enabled = false;
            CaricaListView();

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
        #endregion
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
            }else if (e.KeyCode == Keys.Back && ClsUtenteDL.UtenteAdmin(_utenteLoggato))
            {
                e.SuppressKeyPress = true;
                cbDipartimenti.SelectedIndex = -1;
            }
        }
        private void rbAnni_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                tbDisciplina.Focus(); 
            }
        }

        private void cbDipartimenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDipartimenti.SelectedIndex > -1)
                btCerca_Click(null, null);
        }
        #endregion

    }
}