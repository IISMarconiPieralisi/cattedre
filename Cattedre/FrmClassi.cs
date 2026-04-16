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
        List<ClsIndirizzoDL> _indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
        List<ClsAnnoScolasticoDL> _anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
        Dictionary<string, List<string>> Filtri = new Dictionary<string, List<string>>();
        //inserisco il utenteLoggato a in questa pagina;
        ClsUtenteDL UtenteLoggato;
        public FrmClassi(ClsUtenteDL utenteLog)
        {
            InitializeComponent();
            UtenteLoggato = utenteLog;
        }

      

        private void CaricaListView(List<ClsClasseDL> classi)
        {
            lvClassi.Items.Clear();
            foreach (ClsClasseDL classe in classi)
            {
                ListViewItem lvi = new ListViewItem(classe.ID.ToString());
                lvi.SubItems.Add(classe.Sigla);
                lvi.SubItems.Add(classe.Anno.ToString());
                lvi.SubItems.Add(classe.Sezione);
                lvi.SubItems.Add(ClsClasseBL.RilevaSiglaClasse(classe.ClasseArticolataCon));
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(classe.Idutente));
                lvi.SubItems.Add(ClsIndirizzoBL.RilevaNomeIndirizzo(classe.Idindirizzo));
                lvi.SubItems.Add(ClsDipartimentoBL.RilevaNomeDipartimento(classe.IDdipartimento));
                lvi.SubItems.Add(ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(classe.IDannoscolastico));
                lvi.Tag = classe.ID;
                lvClassi.Items.Add(lvi);
            }
        }

        private void FrmClassi_Load(object sender, EventArgs e)
        {
            GestisciListview();

            GestionePermessi();
            //popolo combobox filtraggio
            foreach (ClsClasseDL classe in classi)
            {
                if (!cbAnnoClasse.Items.Contains(classe.Anno))
                    cbAnnoClasse.Items.Add(classe.Anno);
            }
            //popol combobox filtraggio Indirizzi
            cbIndirizzi.DataSource = _indirizzi;
            cbIndirizzi.DisplayMember = "Nome";
            cbIndirizzi.ValueMember = "ID";
            cbIndirizzi.SelectedIndex = -1;            
            //popolamento filtri
            GeneraFiltriAnnoScolastico();
        }
        private void GestionePermessi()
        {
            if (UtenteLoggato != null && !(UtenteLoggato.TipoUtente == "A" || UtenteLoggato.TipoUtente == "C"))
            {
                btElimina.Visible = false;
                btInserisci.Visible = false;
                brModifica.Visible = false;
                btClasseSuccessiva.Visible = false;
                btElimina.Anchor = AnchorStyles.None;
                btInserisci.Anchor = AnchorStyles.None;
                brModifica.Anchor = AnchorStyles.None;
                lvClassi.Width = this.ClientSize.Width - (lvClassi.Left * 2);
                lvClassi.Height = this.ClientSize.Height - lvClassi.Top - 50;
                lvClassi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
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
                    GestisciListview();
                }
            }
            catch(Exception ex)
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
                        GestisciListview();
                    }
                }
                catch (Exception ex)
                {
                   MessageBox.Show($"errore:\n{ex.Message}\nRiprovare!", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    GestisciListview();
                }
            }
        }
        #region  gestione classe successivo
        private void btClasseSuccessiva_Click(object sender, EventArgs e)
        {
           if(lvClassi.SelectedItems.Count>=1)
           {
                int NumeroClassiAggiunte = 0;
                //carico tutti le classi che sono stati selezionati all'interno di una lista
                foreach(ListViewItem sel in lvClassi.SelectedItems)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        ClsClasseDL _classeSelezionata = classi.Where(p => p.ID == Convert.ToInt32(sel.Tag)).FirstOrDefault();
                        if (_classeSelezionata.Anno >= 5)
                            throw new Exception($" non è possibile ottenere la classe successiva rispetto {_classeSelezionata.Sigla} " +
                                                $"del Anno scolastico {ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(_classeSelezionata.IDannoscolastico)} poichè è un quinto.");
                        if(ClsAnnoScolasticoBL.RilevaIDAnnoSuccessivo(_classeSelezionata.IDannoscolastico) <= 0)
                            throw new Exception($" non è possibile ottenere la classe successiva rispetto {_classeSelezionata.Sigla} " +
                                                $"del Anno scolastico {ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(_classeSelezionata.IDannoscolastico)} poichè non è stato ancora censito l'anno scolastico succesivo.");
                        ClsClasseDL nuovaClasse = classeSuccessiva(_classeSelezionata);
                        if(ClsClasseBL.RilevaIDclasse(nuovaClasse)>0) //se esiste significa che una classe estremamente simile esiste
                            throw new Exception($"La classe {nuovaClasse.Sigla} per l'anno {ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(nuovaClasse.IDannoscolastico)} è già esistente.");
                        //carico la nuova classe
                        ClsClasseBL.InserisciClasse(nuovaClasse);
                        NumeroClassiAggiunte++;
                    }
                    catch (Exception Ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(Ex.Message + "\nRiprovare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                Cursor.Current = Cursors.Default;
                if (NumeroClassiAggiunte>1)
                    MessageBox.Show($"Sono state aggiunte {NumeroClassiAggiunte} classi.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GestisciListview();

            }
            else
           {
                MessageBox.Show("Classe non selezionata", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
        }
        private ClsClasseDL classeSuccessiva(ClsClasseDL classe)
        {
            classe.IDannoscolastico = ClsAnnoScolasticoBL.RilevaIDAnnoSuccessivo(classe.IDannoscolastico);
            classe.Anno += 1;
            classe.Sigla =$"{classe.Anno}{classe.Sezione}";
            //metto classe articolata a 0, per sicurezza e per non dovere gestire questa cosa così complessa
            classe.ClasseArticolataCon = 0;
            return classe;
        }
        #endregion
        #region filtri
        private void btCerca_Click(object sender, EventArgs e)
        {
            try
            {
                Filtri = new Dictionary<string, List<string>>();
                if (cbAnnoClasse.SelectedIndex!=-1)
                {
                    Filtri.Add("anno",new List<string> { $"'{cbAnnoClasse.Text}'" });
                }
                if(cbIndirizzi.SelectedIndex!=-1)
                {
                    Filtri.Add("IDindirizzo", new List<string> { $"'{cbIndirizzi.SelectedValue}'" });
                }
                ControlloSelezionatiAnniScolastici(Filtri);

                if (Filtri.Count<=0)
                    throw new Exception("Inserire almeno un criterio di ricerca");

                GestisciListview();
                btRipristina.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nRiprovare!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btRipristina_Click(object sender, EventArgs e)
        {
            btRipristina.Enabled = false;
            cbAnnoClasse.SelectedIndex = -1;
            cbIndirizzi.SelectedIndex = -1;
            Filtri.Clear();
            DeselezionaCheckBox(tplAnniScolastici);
            GestisciListview();


        }
        private void GeneraFiltriAnnoScolastico()
        {
            tplAnniScolastici.ColumnCount = _anniScolastici.Count;
            tplAnniScolastici.RowCount = 1;

            // Imposta le colonne con larghezza automatica
            tplAnniScolastici.ColumnStyles.Clear();
            for (int i = 0; i < _anniScolastici.Count; i++)
                tplAnniScolastici.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            int sezione = 0;
            foreach (var anno in _anniScolastici)
            {
                CheckBox cb = new CheckBox();
                cb.Name = $"{anno.ID}";
                cb.Text = anno.Sigla;
                cb.Dock = DockStyle.Fill;
                cb.KeyDown += CheckBoxAnno_KeyDown;
                tplAnniScolastici.Controls.Add(cb, sezione, 0);
                sezione++;
            }
        }
        private void ControlloSelezionatiAnniScolastici(Dictionary<string, List<string>> filtri)
        {
            if(tplAnniScolastici.Controls.OfType<CheckBox>().Any(cb=>cb.Checked))
            {
                var selezionati = tplAnniScolastici.Controls.OfType<CheckBox>().Where(cb => cb.Checked).Select(cb => cb.Name).ToList();

                if (!selezionati.Any()) return;

                filtri.Add ( "IDannoScolastico", selezionati);
            }
        }
        private void DeselezionaCheckBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is CheckBox cb)
                    cb.Checked = false;
            }
        }
        #endregion
        #region  gestioni shortcut
        private void lvClassi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                brModifica_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                btElimina_Click(null, null);
            }
        }

        private void cbAnnoClasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbAnnoClasse.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;
                cbIndirizzi.Focus();
            }
        }

        private void cbIndirizzi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbIndirizzi.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;
                tplAnniScolastici.Controls.OfType<CheckBox>().FirstOrDefault()?.Focus();
            }
        }

        private DateTime _ultimoClickCheckBox = DateTime.MinValue;
        private object _ultimoControlloClick = null;

        private void CheckBoxAnno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (sender is CheckBox cb)
                {
                    DateTime now = DateTime.Now;
                    TimeSpan intervallo = now - _ultimoClickCheckBox;

                    // Se è lo stesso controllo e il tempo è inferiore a 800ms (come in FrmUtente)
                    if (_ultimoControlloClick == sender && intervallo.TotalMilliseconds < 800)
                    {
                        // Doppio click rapido -> passa a btCerca
                        _ultimoControlloClick = null;
                        _ultimoClickCheckBox = DateTime.MinValue;
                        btCerca.Focus();
                    }
                    else
                    {
                        // Click singolo -> cambia lo stato della checkbox
                        cb.Checked = !cb.Checked;
                        _ultimoControlloClick = sender;
                        _ultimoClickCheckBox = now;
                    }
                }
            }
            else
            {
                // Reset se premi altro tasto
                _ultimoControlloClick = null;
                _ultimoClickCheckBox = DateTime.MinValue;
            }

        }
        #endregion
        #region gestione Anni
        private void GestisciListview()
        {
            if(Filtri.Count>0)classi = ClsClasseBL.CaricaClassiFiltrate(Filtri);
            else classi = ClsClasseBL.CaricaClassi();
            if (!Filtri.ContainsKey("IDannoScolastico"))
            {
                long IDannoCorrente = ClsAnnoScolasticoBL.TrovaIDannoscolastico();
                 classi = classi
                    .Where(c => c.IDannoscolastico == IDannoCorrente)
                    .OrderBy(c => c.Anno)
                    .ThenBy(c => c.Sezione)
                    .ToList();
            }
            CaricaListView(classi);
        }
        #endregion
    
    }
}