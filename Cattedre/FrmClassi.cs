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
        //inserisco il utenteLoggato a in questapagina;
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
                ListViewItem lvi = new ListViewItem(classe.Sigla);
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
            classi = ClsClasseBL.CaricaClassi();
            CaricaListView(classi);
            GestionePermessi();
            //popolo combobox filtraggio
            foreach (ClsClasseDL classe in classi)
            {
                if (!cbAnnoClasse.Items.Contains(classe.Anno))
                    cbAnnoClasse.Items.Add(classe.Anno);
            }
            //popol combobox filtraggio Indirizzi
            foreach( var ind in _indirizzi)
                cbIndirizzi.Items.Add(ind.Nome);

        }
        private void GestionePermessi()
        {
            if (UtenteLoggato != null && !(UtenteLoggato.TipoUtente == "A" || UtenteLoggato.TipoUtente == "C"))
            {
                btElimina.Visible = false;
                btInserisci.Visible = false;
                brModifica.Visible = false;
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
                    classi = ClsClasseBL.CaricaClassi();
                }
                CaricaListView(classi);
            }
        }

        private void btCerca_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbIndirizzi.SelectedIndex == -1 && cbAnnoClasse.SelectedIndex == -1)
                    throw new Exception("Inserire almeno un criterio di ricerca");

                List <ClsClasseDL> classiFiltrate = ClsClasseBL.CaricaClassiFiltrate(Convert.ToInt32(cbAnnoClasse.Text), ClsIndirizzoBL.RilevaIDindirizzo(cbIndirizzi.Text));
                CaricaListView(classiFiltrate);
                btRipristina.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nRiprovare!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btRipristina_Click(object sender, EventArgs e)
        {
            btRipristina.Enabled = false;
            classi = ClsClasseBL.CaricaClassi();
            CaricaListView(classi);
            cbAnnoClasse.SelectedIndex=-1;
            cbIndirizzi.SelectedIndex = -1;
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
                        MessageBox.Show(Ex.Message + "\nRiprovare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if(NumeroClassiAggiunte>1)
                    MessageBox.Show($"Sono state aggiunte {NumeroClassiAggiunte} classi.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                classi = ClsClasseBL.CaricaClassi();
                CaricaListView(classi);
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
    }
}