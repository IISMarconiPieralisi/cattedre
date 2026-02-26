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
        public List<ClsUtenteDL> _utenti = new List<ClsUtenteDL>();
        string _filtro = string.Empty;
        List<string> _parametri = new List<string>();
        string _parametroRicerca=string.Empty;

        public FrmUtenti()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            lvUtenti.Items.Clear();

            foreach (ClsUtenteDL utente in _utenti)
            {
                //prendo un metodo che cerca il contratto in base all'id utente
                ClsContrattoDL contratto =ClsContrattoBL.cercaContratto(utente.ID);
                ListViewItem lvi = new ListViewItem(utente.Nome);

                lvi.SubItems.Add(utente.Cognome);
                lvi.SubItems.Add(utente.Email);
                string _tipoDocente = (utente.TipoDocente == 'T') ? " teorico" : (utente.TipoDocente == 'L') ? " partico" : string.Empty;
                switch (utente.TipoUtente)
                {
                    case "P":
                        lvi.SubItems.Add("preside");
                        break;
                    case "A":
                        lvi.SubItems.Add("amministratore");
                        break;
                    case "D":
                        lvi.SubItems.Add($"docente{_tipoDocente}");
                        break;
                    case "C":
                        lvi.SubItems.Add($" docente{_tipoDocente} coordinatore dipartimento");
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
                    ClsUtenteDL utente = ClsUtenteBL.caricautenteByEmail(frmUtente._utente.Email); //essendo che l'email è univoca riesco a risalire anche all'id del utente in questo modo
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

                    if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C" || frmUtente._utente.TipoUtente == "A")
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
                gestisciListview();
            }
        }

        private void FrmUtenti_Load(object sender, EventArgs e)
        {
            _utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView();
        }
        private void gestisciListview()
        {
            if (!string.IsNullOrWhiteSpace(_filtro))
                _utenti = ClsUtenteBL.FiltraUtenti(_parametri, _filtro);
            else if (!string.IsNullOrEmpty(_parametroRicerca))
                _utenti = ClsUtenteBL.RicercaPerNomeCognome(_parametroRicerca);
            else
                _utenti = ClsUtenteBL.CaricaUtenti();
            CaricaListView();

        }

        private  void  btModifica_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedIndices.Count == 1)
            {

                int indiceDaModificare = lvUtenti.SelectedIndices[0];
                FrmUtente frmUtente = new FrmUtente();
                //passo la classe afferirenza e il contratto solo se l'utente è un docente
                frmUtente._utente = _utenti[indiceDaModificare];
                //creo un appoggio di utente che mi servirà in futuro
                //ClsUtenteBL u = frmUtente._utente;
                frmUtente._utente.ID = _utenti[indiceDaModificare].ID; //mi assicuro che l'ID rimanga lo stesso

                List <ClsAfferireDL> afferire = ClsAfferireBL.CaricaClassiAfferire(_utenti[indiceDaModificare].ID);
                if (afferire != null && afferire.Count > 0) //se non esiste restituirà null e quindi non restituirà la lista
                    frmUtente._afferenze = afferire;
                
                List<ClsRichiedereDL> richiedere = ClsRichiedereBL.CaricaClassiRichiedere(_utenti[indiceDaModificare].ID);
                if (richiedere != null && richiedere.Count > 0)
                    frmUtente._richieste = richiedere;
                ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(_utenti[indiceDaModificare].ID); //se non esiste restituirà null
                if (contratto != null)
                    frmUtente._contratto = contratto;
                

                DialogResult dr = frmUtente.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ClsUtenteBL.ModificaUtente(frmUtente._utente,frmUtente._utente.ID);

                        if (frmUtente._utente.TipoUtente == "D" || frmUtente._utente.TipoUtente == "C"|| frmUtente._utente.TipoUtente == "A")
                        {

                            //modifica contratto, afferenze e richieste
                            ClsAfferireBL.ModificaAfferenze(frmUtente._utente.ID, frmUtente._afferenze);
                            ClsRichiedereBL.ModificaRichiesta(frmUtente._utente.ID, frmUtente._richieste);
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
                    gestisciListview();


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
                    _utenti = ClsUtenteBL.CaricaUtenti();

                }
                gestisciListview();

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
                    _utenti = ClsUtenteBL.CaricaUtenti();
                    CaricaListView();
                    break;
            }

        }
        private void btFiltro_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(cbFiltro.Text))//anche se non serve per sicurezza lo uso
            {
                //cancello la ricerca in modo che non mi dia problemi
                _parametroRicerca = string.Empty;
                btAnnullaFiltra.Enabled = true;
                _parametri=new List<string>();
                string cbSelezionato = cbFiltro.Text;
                _filtro = (cbSelezionato == "Tipo Utente")?"tipoUtente":
                                (cbSelezionato=="Tipo Contratto")?"tipoContratto":
                                (cbSelezionato=="Tipo Docente")?"tipoDocente":""; //in  questo modo me lo preparo come è scritto nel DB, per comodità
                switch(_filtro)
                {
                    case "tipoDocente":
                        var selezionato = tlpFiltri.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                        if (selezionato != null)
                            _parametri.Add((selezionato.Name == "Teorico") ? "T" : "L");
                        else
                            throw new Exception("Seleziona un parametro di ricerca");
                        break;
                    case "tipoUtente":
                        foreach(Control c in tlpFiltri.Controls)
                        {
                            if(c is CheckBox cb && cb.Checked)
                                _parametri.Add(cb.Name);
                        }
                        if(_parametri.Count<=0)
                            throw new Exception("Seleziona un parametro di ricerca");
                        break;
                    case "tipoContratto":
                        var _tContratto = tlpFiltri.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                        if (_tContratto != null)
                            _parametri.Add((_tContratto.Name == "Derminato") ? "D" : "I");
                        else
                            throw new Exception("Seleziona un parametro di ricerca");
                        break;
                    default:
                        throw new Exception("Errore durante la selezione del filtro di ricerca");

                }
                gestisciListview();
                try
                {

                }catch(Exception ex)
                {
                    MessageBox.Show($"{ex.Message}\n riprova", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
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
        private void btAnnullaFiltra_Click(object sender, EventArgs e)
        {
            btFiltro.Enabled = false;
            btAnnullaFiltra.Enabled = false;
            tlpFiltri.Controls.Clear();
            cbFiltro.SelectedIndex = 0;
            _filtro = string.Empty;
            _parametri = new List<string>();

            //ricamento della listview
            gestisciListview();
        }




        #endregion
        #region ricerca

        private void tbRicerca_TextChanged(object sender, EventArgs e)
        {
            if(tbRicerca.Text!="cognome nome" && tbRicerca.Text.Length>2)
            {
                btRicerca.Enabled = true;
            }else
            {
                btRicerca.Enabled = false;
            }
        }

        private void tbRicerca_Enter(object sender, EventArgs e)
        {
            if (tbRicerca.Text == "cognome nome")
            {
                tbRicerca.Text = "";
                tbRicerca.ForeColor = Color.Black;
            }
        }

        private void tbRicerca_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRicerca.Text))
            {
                tbRicerca.Text = "cognome nome";
                tbRicerca.ForeColor = Color.Gray;
            }
        }
        #endregion

        private void btRicerca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbRicerca.Text) && tbRicerca.Text != "cognome nome")
            {
                //cancello il filtra in modo che non mi dia problemi
                _filtro=string.Empty;
                btAnnullaRicerca.Enabled = true;
                _parametroRicerca = tbRicerca.Text.Replace(" ", "").ToLower();
                _utenti = ClsUtenteBL.RicercaPerNomeCognome(_parametroRicerca);
                CaricaListView();
            }
            else
                MessageBox.Show("Inserire Input valido per la ricerca", "attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btAnnullaRicerca_Click(object sender, EventArgs e)
        {
            btRicerca.Enabled = false;
            btAnnullaRicerca.Enabled = false;
            _parametroRicerca = string.Empty;
            tbRicerca.Text = string.Empty;
            gestisciListview();
        }
    }
}
