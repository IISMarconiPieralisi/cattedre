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
    public partial class FrmUtenti : Form
    {
        public List<ClsUtenteDL> utenti = new List<ClsUtenteDL>();
        public List<ClsContrattoDL> contratti = new List<ClsContrattoDL>();

        public FrmUtenti()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            lvUtenti.Items.Clear();

            foreach (ClsUtenteDL utente in utenti)
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
                ClsUtenteBL.InserisciUtente(frmUtente._utente); //l'utente che mando non ha un ID che creo quando lo inzializzo nel server
                ClsUtenteDL utente = ClsUtenteBL.caricautente(frmUtente._utente.Email); //essendo che l'email è univoca riesco a risalire anche all'id del utente in questo modo
                if(frmUtente._afferenze!=null && frmUtente._afferenze.Count>0)
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

                if (frmUtente._utente.TipoUtente=="D" || frmUtente._utente.TipoUtente == "C")
                {
                    frmUtente._contratto.IDutente = utente.ID;
                    ClsContrattoBL.InserisciContratto(frmUtente._contratto, utente.ID);
                    if(frmUtente._utente.TipoUtente == "C")
                    {
                        //se è un coordinatore di dipartimento devo aggiornare la tabella dipartimenti
                        ClsDipartimentoBL.ModificaCoordinatoreDipartimento(frmUtente._dipartimento, utente.ID);

                    }
                }
                    
                utenti = ClsUtenteBL.CaricaUtenti();
                CaricaListView();
            }
        }

        private void FrmUtenti_Load(object sender, EventArgs e)
        {
            utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView();
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {

                int indiceDaModificare = lvUtenti.SelectedIndices[0];
                FrmUtente frmUtente = new FrmUtente();
                //passo la classe afferirenza e il contratto solo se l'utente è un docente
                frmUtente._utente = utenti[indiceDaModificare];
                //creo un appoggio di utente che mi servirà in futuro
                //ClsUtenteBL u = frmUtente._utente;
                frmUtente._utente.ID = (long)lvUtenti.SelectedItems[0].Tag;

                List<ClsAfferireDL> afferire = ClsAfferireBL.CaricaClassiAfferire(utenti[indiceDaModificare].ID);
                if (afferire != null && afferire.Count > 0) //se non esiste restituirà null e quindi non restituirà la lista
                {
                    frmUtente._afferenze = afferire;
                }
                List<ClsRichiedereDL> richiedere = ClsRichiedereBL.CaricaClassiRichiedere(utenti[indiceDaModificare].ID);
                if (richiedere != null && richiedere.Count > 0)
                    frmUtente._richieste = richiedere;
                ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(utenti[indiceDaModificare].ID); //se non esiste restituirà null
                if (contratto != null)
                {
                    frmUtente._contratto = contratto;
                }

                DialogResult dr = frmUtente.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsUtenteBL.ModificaUtente(frmUtente._utente, indiceDaModificare); //l'utente che mando ha un ID già esistente
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
                    CaricaListView();

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
                CaricaListView();
            }
        }
        #region filtri
        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TipoFiltro = cbFiltro.SelectedItem.ToString();
            switch (TipoFiltro)
            {
                case "Tipo Docente":
                    pnfiltri.Controls.Clear();
                    //creo gli elmenti grafici da codice cioè due radiobutton all'interno del panel pnfiltri
                    RadioButton rbTeorico = new RadioButton
                    {
                        Text = "Teorico",
                        Location = new Point(10, 5),
                        AutoSize = true
                    };
                    RadioButton rbLaboratorio = new RadioButton
                    {
                        Text = "Laboratorio",
                        Location = new Point(10, 35),
                        AutoSize = true
                    };
                    btFiltro.Enabled = true;
                    pnfiltri.Controls.Add(rbTeorico);
                    pnfiltri.Controls.Add(rbLaboratorio);
                    break;
                case "Tipo Contratto":
                    pnfiltri.Controls.Clear();
                    break;
                case "Tipo Utente":
                    pnfiltri.Controls.Clear();
                    CheckBox cbAmministratiore = new CheckBox
                    {
                        Text = "Amministratore",
                        Location = new Point(10, 5),
                        AutoSize =true
                    };
                    break;
                 default:
                    pnfiltri.Controls.Clear();
                    btFiltro.Enabled = false;
                    utenti = ClsUtenteBL.CaricaUtenti();
                    CaricaListView();
                    break;
            }

        }
        #endregion
    }
}
