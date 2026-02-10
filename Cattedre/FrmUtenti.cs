using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cattedre
{
    public partial class FrmUtenti : Form
    {
        public List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
        public List<ClsContrattoDL> contratti = new List<ClsContrattoDL>();

        public FrmUtenti()
        {
            InitializeComponent();
        }

        private void CaricaListView(List<ClsUtenteDL>u)
        {
            lvUtenti.Items.Clear();

            foreach (ClsUtenteDL utente in u)
            {
                //prendo un metodo che cerca il contratto in base all'id utente
                ClsContrattoDL contratto =ClsContrattoBL.cercaContratto(utente.ID);
                //per sicurezza lo aggiungo alla lista contratti
                if(contratto!=null)
                    contratti.Add(contratto);
                ListViewItem lvi = new ListViewItem(utente.Nome);

                lvi.SubItems.Add(utente.Cognome);
                lvi.SubItems.Add(utente.Email);
                switch (utente.TipoUtente)
                {
                    case "P":
                        lvi.SubItems.Add("preside");
                        break;
                    case "A":
                        lvi.SubItems.Add("amministratore");
                        break;
                    case "D":
                        lvi.SubItems.Add("docente");
                        break;
                    case "C":
                        lvi.SubItems.Add("coordinatore dipartimento");
                        break;
                }
                switch(utente.TipoDocente)
                {
                    case 'T':
                        lvi.SubItems.Add("teorico");
                        break;
                    case 'L':
                        lvi.SubItems.Add("pratico");
                        break;
                    default:
                        lvi.SubItems.Add("-");
                        break;
                }
                if (contratto !=null)
                {
                   switch(contratto.TipoContratto)
                    {
                        case 'D':
                            lvi.SubItems.Add("Determinato");
                            break;
                        case 'I':
                            lvi.SubItems.Add("Indeterminato");
                            break;
                        default:
                            lvi.SubItems.Add("-");
                            break;
                    }                    
                    lvi.SubItems.Add(contratto.MonteOre.ToString());
                    lvi.SubItems.Add(contratto.DataInizioContratto.ToString("dd/MM/yyyy"));
                    if (contratto.DataFineContratto != null)
                        lvi.SubItems.Add(contratto.DataFineContratto?.ToString("dd/MM/yyyy"));
                    else
                        lvi.SubItems.Add("-");
                }
                else
                {
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                }
                lvi.Tag = utente.ID;

                lvUtenti.Items.Add(lvi);

            }
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmUtente frmUtente = new FrmUtente();
            DialogResult dr = frmUtente.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClsUtenteBL.InserisciUtente(frmUtente._utente); //l'utente che mando non ha un ID che creo quando lo inzializzo nel server
                    ClsUtenteDL utente = ClsUtenteBL.caricautente(frmUtente._utente.Email); //essendo che l'email è univoca riesco a risalire anche all'id del utente in questo modo
                    if (frmUtente._afferenze != null && frmUtente._afferenze.Count > 0)
                    {
                        foreach (ClsAfferireDL afferire in frmUtente._afferenze)
                        {
                            afferire.IDutente = utente.ID;
                            ClsAfferireBL.InserisciAfferire(afferire);
                        }

                    }
                    if (frmUtente._richieste != null && frmUtente._richieste.Count > 0)
                    {
                        foreach (ClsRichiedereDL richiedere in frmUtente._richieste)
                        {
                            richiedere.IDutente = utente.ID;
                            ClsRichiedereBL.InserisciRichiedere(richiedere);
                        }

                    }

                    if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C")
                    {
                        frmUtente._contratto.IDutente = utente.ID;
                        ClsContrattoBL.InserisciContratto(frmUtente._contratto, utente.ID);
                        if (frmUtente._utente.TipoUtente == "C")
                        {
                            //se è un coordinatore di dipartimento devo aggiornare la tabella dipartimenti
                            ClsDipartimentoBL.ModificaCoordinatoreDipartimento(frmUtente._dipartimento, utente.ID);

                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Errore durante il inserimento:{ex.Message}", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                utenti = ClsUtenteBL.CaricaUtenti();
                CaricaListView(utenti);
            }
        }

        private void FrmUtenti_Load(object sender, EventArgs e)
        {
            utenti = ClsUtenteBL.CaricaUtenti();
            utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView(utenti);
        }

        private  void  btModifica_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {

                int indiceDaModificare = lvUtenti.SelectedIndices[0];
                FrmUtente frmUtente = new FrmUtente();
                //passo la classe afferirenza e il contratto solo se l'utente è un docente
                frmUtente._utente = utenti[indiceDaModificare];
                //creo un appoggio di utente che mi servirà in futuro
                //ClsUtenteBL u = frmUtente._utente;
                frmUtente._utente.ID = utenti[indiceDaModificare].ID; //mi assicuro che l'ID rimanga lo stesso

                List <ClsAfferireDL> afferire = ClsAfferireBL.CaricaClassiAfferire(utenti[indiceDaModificare].ID);
                if (afferire != null && afferire.Count > 0) //se non esiste restituirà null e quindi non restituirà la lista
                    frmUtente._afferenze = afferire;
                
                List<ClsRichiedereDL> richiedere = ClsRichiedereBL.CaricaClassiRichiedere(utenti[indiceDaModificare].ID);
                if (richiedere != null && richiedere.Count > 0)
                    frmUtente._richieste = richiedere;
                ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(utenti[indiceDaModificare].ID); //se non esiste restituirà null
                if (contratto != null)
                    frmUtente._contratto = contratto;
                

                DialogResult dr = frmUtente.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ClsUtenteBL.ModificaUtente(frmUtente._utente,frmUtente._utente.ID);

                        if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C")
                        {

                            //modifica contratto, afferenze e richieste
                            ClsAfferireBL.ModificaAfferenze(frmUtente._utente.ID, frmUtente._afferenze);
                            ClsRichiedereBL.ModificaRichiesta(frmUtente._utente.ID, 0, frmUtente._richieste);
                            ClsContrattoBL.ModificaContratto(frmUtente._contratto, frmUtente._utente.ID);
                            //controllo e inserimento coordinatore di dipartimento
                            if (frmUtente._utente.TipoUtente == "C")
                            {
                                //se è un coordinatore di dipartimento devo aggiornare la tabella dipartimenti
                                ClsDipartimentoBL.ModificaCoordinatoreDipartimento(frmUtente._dipartimento, frmUtente._utente.ID);
                            }

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Errore durante il salvataggio: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    utenti = ClsUtenteBL.CaricaUtenti();
                    CaricaListView(utenti);

                }
            }
            else
                MessageBox.Show("non è stato selezionato nessun utente, riprovare.", "Modifica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvUtenti.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvUtenti.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsDipartimentoBL.EliminaCoordinatoreDipartimento(idDaEliminare);
                    ClsUtenteBL.EliminaUtente(idDaEliminare);
                    utenti = ClsUtenteBL.CaricaUtenti();

                }
                utenti = ClsUtenteBL.CaricaUtenti();
                CaricaListView(utenti);
            }
        }
        #region filtri
        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TipoFiltro = cbFiltro.SelectedItem.ToString();
            tlpFiltri.Controls.Clear();
            tlpFiltri.RowStyles.Clear();
            tlpFiltri.RowCount = 1;

            switch (TipoFiltro)
            {
                case "Tipo Docente":
                    ConfiguraGriglia(2);
                    AggiungiControllo(new RadioButton { Name="rbTeorico", Text = "Teorico", AutoSize = true }, 0);
                    AggiungiControllo(new RadioButton { Name = "rbLaboratorio", Text = "Laboratorio", AutoSize = true  }, 1);
                    btFiltro.Enabled = true;
                    break;
                case "Tipo Contratto":
                    ConfiguraGriglia(2);
                    AggiungiControllo(new RadioButton { Name = "rbDeterminato", Text = "Determinato", AutoSize = true }, 0);
                    AggiungiControllo(new RadioButton { Name = "rbIndterminato", Text = "Indeterminato", AutoSize = true }, 1);
                    btFiltro.Enabled = true;
                    break;
                case "Tipo Utente":
                    ConfiguraGriglia(4); // Divido in 4 colonne
                    string[] labels = { "Amministratore", "Preside", "Coordinatore Dipartimento", "Docente" };
                    string[] value = {"A","P","C","D"};
                    for (int i = 0; i < labels.Length; i++)
                        AggiungiControllo(new CheckBox { Name=value[i],Text = labels[i], AutoSize = true }, i);
                    
                    btFiltro.Enabled = true;
                    break;
                 default:
                    utenti = ClsUtenteBL.CaricaUtenti();
                    CaricaListView(utenti);
                    break;
            }

        }
        private void btFiltro_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(cbFiltro.Text))//anche se non serve per sicurezza lo uso
            {
                btAnnullaRicerca.Enabled = true;
                List<string> _parametri=new List<string>();
                string cbSelezionato = cbFiltro.SelectedText;
                string _filtro = (cbSelezionato == "Tipo Utente")?"tipoUtente":
                                (cbSelezionato=="Tipo Contratto")?"tipoContratto":
                                (cbSelezionato=="Tipo Docente")?"tipoDocente":""; //in  questo modo me lo preparo come è scritto nel DB, per comodità
                switch(_filtro)
                {
                    case "tipoDocente":
                        var selezionato = tlpFiltri.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                        if (selezionato != null)
                            _parametri.Add((selezionato.Name == "Teorico") ? "T" : "L");
                        else
                            MessageBox.Show("Seleziona un parametro di ricerca,\n riprova", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "tipoUtente":
                        foreach(Control c in tlpFiltri.Controls)
                        {
                            if(c is CheckBox cb && cb.Checked)
                                _parametri.Add(cb.Name);
                        }
                        break;
                    case "tipoContratto":
                        var _tContratto = tlpFiltri.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                        if(_tContratto!=null)
                            _parametri.Add((_tContratto.Name == "Derminato") ? "D" : "I");
                        else
                            MessageBox.Show("Seleziona un parametro di ricerca,\n riprova", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                }
                utenti = ClsUtenteBL.FiltraUtenti(_parametri, _filtro);
                CaricaListView(utenti);

            }
        }
        private void ConfiguraGriglia(int numeroColonne)
        {
            tlpFiltri.ColumnCount = numeroColonne;
            float percentuale = 100f / numeroColonne;

            for (int i = 0; i < numeroColonne; i++)
                tlpFiltri.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentuale));
            
        }
        private void AggiungiControllo(Control control, int Colonna)
        {
            control.Anchor = AnchorStyles.None;
            tlpFiltri.Controls.Add(control, Colonna, 0);
        }

        #endregion

        private void btAnnullaRicerca_Click_1(object sender, EventArgs e)
        {
            btFiltro.Enabled = false;
            tlpFiltri.Controls.Clear();
            cbFiltro.SelectedIndex = 0;
            utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView(utenti);
        }
    }
}
