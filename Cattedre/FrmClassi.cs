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
        long IDindirizzo=0;
        int annoClasse = 0;
        long IDannoscolastico = 0;
        //inserisco il utenteLoggato a in questa pagina;
        ClsUtenteDL UtenteLoggato;
        public FrmClassi(ClsUtenteDL utenteLog)
        {
            InitializeComponent();
            UtenteLoggato = utenteLog;
        }

      

        private void CaricaListView()
        {
            classi = ClsClasseBL.CaricaClassi(IDindirizzo, IDannoscolastico,annoClasse);
            lvClassi.Items.Clear();
            foreach (ClsClasseDL classe in classi)
            {
                ListViewItem lvi = new ListViewItem(classe.ID.ToString());
                lvi.SubItems.Add(ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(classe.IDannoscolastico));
                lvi.SubItems.Add(classe.Sigla);
                lvi.SubItems.Add(ClsClasseBL.RilevaSiglaClasse(classe.ClasseArticolataCon));
                lvi.SubItems.Add(ClsUtenteBL.RilevaNomeUtente(classe.Idutente));
                lvi.SubItems.Add(ClsIndirizzoBL.RilevaNomeIndirizzo(classe.Idindirizzo));
                lvi.Tag = classe.ID;
                lvClassi.Items.Add(lvi);
            }
        }

        private void FrmClassi_Load(object sender, EventArgs e)
        {
            GestionePermessi();
            //popol combobox filtraggio Indirizzi
            cbIndirizzi.DataSource = _indirizzi;
            cbIndirizzi.DisplayMember = "Nome";
            cbIndirizzi.ValueMember = "ID";
            cbIndirizzi.SelectedIndex = -1;

            cbAnniScolastici.DataSource = _anniScolastici;
            cbAnniScolastici.DisplayMember = "Sigla";
            cbAnniScolastici.ValueMember = "ID";
            cbAnniScolastici.SelectedIndex = -1;
            IDannoscolastico = ClsAnnoScolasticoBL.TrovaIDannoscolastico();
            cbAnniScolastici.SelectedValue = IDannoscolastico;
            CaricaListView();
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
                    CaricaListView();
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
                        //controllo se è stato cambiato il dipartimento di quella classe
                        if(frmClasse._classe.Idindirizzo!=classeSelezionata.Idindirizzo)
                        {
                            //cancello i record di quella classe nelle assegnazioni
                            ClsAssegnareBL.EliminaAssegnazioneGenerica(frmClasse._classe.ID,"IDclasse");
                        }
                        CaricaListView();
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
                    CaricaListView();
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
                CaricaListView();

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
                bool ricercaPositiva = false;
                if (cbAnnoClasse.SelectedIndex!=-1)
                {
                    annoClasse = Convert.ToInt32(cbAnnoClasse.Text);
                    ricercaPositiva = true;
                }
                if(cbIndirizzi.SelectedIndex!=-1)
                {
                    IDindirizzo = Convert.ToInt32(cbIndirizzi.SelectedValue);
                    ricercaPositiva = true;

                }
                if (cbAnniScolastici.SelectedIndex != -1)
                {
                    IDannoscolastico = Convert.ToInt32(cbAnniScolastici.SelectedValue);
                    ricercaPositiva = true;
                }

                if (!ricercaPositiva)
                    throw new Exception("Inserire almeno un criterio di ricerca");
                CaricaListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nRiprovare!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btRipristina_Click(object sender, EventArgs e)
        {
            cbAnnoClasse.SelectedIndex = -1;
            cbIndirizzi.SelectedIndex = -1;
            cbAnniScolastici.SelectedIndex = -1;
            IDannoscolastico = 0;
            IDindirizzo = 0;
            annoClasse = 0;
            CaricaListView();


        }
        //private void GeneraFiltriAnnoScolastico()
        //{
        //    //tplAnniScolastici.ColumnCount = _anniScolastici.Count;
        //    //tplAnniScolastici.RowCount = 1;

        //    // Imposta le colonne con larghezza automatica
        //    //tplAnniScolastici.ColumnStyles.Clear();
        //    //for (int i = 0; i < _anniScolastici.Count; i++)
        //    //tplAnniScolastici.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        //    //cbAnniScolastici.DataSource = _anniScolastici;
        //    //cbAnniScolastici.DisplayMember = "Sigla";
        //    //cbAnniScolastici.ValueMember = "ID";
        //    //cbAnniScolastici.SelectedIndex = -1;
        //}
       
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
                cbAnniScolastici.Focus();
            }
        }
        #endregion
    
    }
}