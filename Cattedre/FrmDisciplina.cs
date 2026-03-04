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
    public partial class FrmDisciplina : Form
    {
        List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
        List<ClsIndirizzoDL> indirizzi = ClsIndirizzoBL.CaricaIndirizzi();
        List<ClsDisciplinaDL> Discipline = ClsDisciplinaBL.CaricaDiscipline();
        public List<ClsAppartenereDL> _Apparteneres = new List<ClsAppartenereDL>();
        public ClsDisciplinaDL _disciplina;

        private long _dipartimento = 0;
        private int anno = 0;
        public FrmDisciplina()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (_disciplina.ID <= 0)
                    _disciplina = new ClsDisciplinaDL();
                _disciplina.Anno = anno;
                if (_disciplina.Anno == 0 && tbDisciplinaSpeciale.Text.Trim() == string.Empty)
                {
                    throw new Exception("inserire un anno valido");
                }

                //controllo se vedere se si inserisce una materia praticamente uguale
                if (_disciplina.ID <= 0)
                    if (Discipline.Any(p => p.Nome == tbNome.Text.Trim() && p.Anno == anno))
                        throw new Exception("Disciplina già presente in archivio per questo anno.");
                else
                    if (Discipline.Any(p => p.Nome == tbNome.Text.Trim()&& p.Anno == anno && p.ID != _disciplina.ID))
                        throw new Exception("Disciplina già presente in archivio per questo anno.");

                if (Discipline.Any(p =>_disciplina.ID>0 && p.ID != _disciplina.ID))
                //caricamento IDclasse collegata 
                _disciplina.IDdisciplinaSuccessiva = CercaDisciplina();

                _disciplina.Nome = (tbNome.Text.Length >= 3) ? tbNome.Text.Trim() : throw new Exception("inserire Nome con almeno 3 caratteri");

                _disciplina.OreLaboratorio = (int)nudOreLab.Value;
                _disciplina.OreTeoria = (int)nudOreTeoria.Value;
                if (tbDisciplinaSpeciale.Text != string.Empty && _disciplina.Anno == 0)
                    _disciplina.DisciplinaSpeciale = tbDisciplinaSpeciale.Text.Trim();
                else
                    _disciplina.IDdipartimento = Convert.ToInt32(cbDipartimentoAppartenente.SelectedValue);


                //gestione ClsAppartenere
                foreach (var item in clbIndirizzi.CheckedItems)
                {
                    ClsIndirizzoDL indirizzo = indirizzi.Find(d => d.Nome == item.ToString());
                    if (indirizzo != null)
                        _Apparteneres.Add(new ClsAppartenereDL(indirizzo.ID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il compilamento:\n{ex.Message} \nRiprovare!", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }


        private void FrmDisciplina_Load(object sender, EventArgs e)
        {


            controlloRadioBottom();
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();
            PopolaclbIndirizzi();
            cbDipartimentoAppartenente.DataSource = dipartimenti;
            cbDipartimentoAppartenente.DisplayMember = "Nome";
            cbDipartimentoAppartenente.ValueMember = "ID";

            if (_disciplina != null)
            {
                //carico le informazioni della disciplina
                tbNome.Text = _disciplina.Nome;
                nudOreLab.Value = _disciplina.OreLaboratorio;
                nudOreTeoria.Value = _disciplina.OreTeoria;
                CheckComboBoxs();
                RiempiCbDisciplinaSuccessiva(_disciplina.Anno,_disciplina.IDdipartimento,_disciplina.IDdisciplinaSuccessiva);
                cbDipartimentoAppartenente.SelectedValue = _disciplina.IDdipartimento;                
                //carico le informazioni del collegamento con indirizzi
                _Apparteneres = ClsAppartenereBL.CaricaClassiAppartenereByDisciplina(_disciplina.ID);
                LoadclbIndirizzi();
            }
            else
            {
                _disciplina = new ClsDisciplinaDL();
                cbDipartimentoAppartenente.SelectedIndex = -1;
            }

        }
        private void CheckComboBoxs()
        {
            switch (_disciplina.Anno)
            {
                case 1:
                    rbPrimo.Checked = true;
                    break;
                case 2:
                    rbSecondo.Checked = true;
                    break;
                case 3:
                    rbTerzo.Checked = true;
                    break;
                case 4:
                    rbQuarto.Checked = true;
                    break;
                case 5:
                    rbQuinto.Checked = true;
                    break;
                default:
                    tbDisciplinaSpeciale.Text = _disciplina.DisciplinaSpeciale;
                    break;
            }
        }
        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region gestione CLsAppartenere

        #endregion
        #region Indirizzi
        private void LoadclbIndirizzi()
        {
            List<ClsIndirizzoDL> indirizziAppartenuti =ClsAppartenereBL.indirizziDellaDisciplina(_disciplina.ID);

            if (indirizziAppartenuti.Count > 0)
            {
                for (int i = 0; i < clbIndirizzi.Items.Count; i++)
                {
                    string nomeItem = clbIndirizzi.Items[i].ToString();

                    bool afferente = indirizziAppartenuti.Any(d => string.Equals(d.Nome, nomeItem, StringComparison.OrdinalIgnoreCase));

                    clbIndirizzi.SetItemChecked(i, afferente); 
                }
                //quando ha fatto l'inserimento pulisce la lista per sicurezza
                _Apparteneres.Clear();
            }
        }

    
        private void PopolaclbIndirizzi()
        {
            clbIndirizzi.Items.Clear();
            foreach(var indirizzo in indirizzi)
            {
                clbIndirizzi.Items.Add(indirizzo.Nome);
            }
        }
        #endregion
        #region gestisci Disciplina successiva
        private void cbDipartimentoAppartenente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDipartimentoAppartenente.SelectedIndex != -1)
                _dipartimento = ClsDipartimentoBL.RilevaIDdipartimento(cbDipartimentoAppartenente.Text.Trim());
            ControlloCbDisciplinaSuccessiva();

        }
        private void ControlloCbDisciplinaSuccessiva()
        {
            if (_dipartimento != 0 && anno < 5 && anno != 0)
            {
                cbDisciplinaSucessiva.Enabled = true;
                popolaCbDisciplinaSuccessiva();
                cbDisciplinaSucessiva.SelectedIndex = -1;
            }
            else
            {
                cbDisciplinaSucessiva.Enabled = false;
                cbDisciplinaSucessiva.DataSource = null;
            }
        }
        private void popolaCbDisciplinaSuccessiva()
        {
            List<ClsDisciplinaDL> ListaDisciplineSelezionate = Discipline.Where(p => p.Anno == anno + 1 && p.IDdipartimento == _dipartimento && 
                    !Discipline.Any(d => d.IDdisciplinaSuccessiva == p.ID && d.ID != _disciplina.ID)).ToList();
            //non il massimo della pulizia ma non ho voglia di modificare tutto il codice per una piccola optimizzazione
                cbDisciplinaSucessiva.DataSource = ListaDisciplineSelezionate;
                cbDisciplinaSucessiva.DisplayMember = "Nome";
                cbDisciplinaSucessiva.ValueMember = "ID";
            
            
        }
        /// <summary>
        /// metodo che aggiunge un evento a ogni RadioBotom presente nel codice, in modo tale da prendere l'anno di quel oggetto
        /// </summary>
        private void controlloRadioBottom()
        {
            // Cicla solo i controlli dentro il tuo pannello specifico
            foreach (Control c in pnRB.Controls)
            {
                if (c is RadioButton rb)
                    // Collega l'evento Click
                    rb.Click += RadioButton_Pannello_Click;
            }
        }
        private void RadioButton_Pannello_Click(object sender, EventArgs e)
        {
            // 'sender' è esattamente il RadioButton che l'utente ha cliccato
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                anno = Convert.ToInt16(rb.Text.Replace('°', ' ').Trim());
                ControlloCbDisciplinaSuccessiva();


            }
        }
        private void RiempiCbDisciplinaSuccessiva(int _anno, long _dipartimento, long _IDdiscSuccessiva)
        {
            if(_anno < 5)
            {
                anno = _anno;
                this._dipartimento = _dipartimento;

                popolaCbDisciplinaSuccessiva();

                if (_IDdiscSuccessiva > 0)
                    cbDisciplinaSucessiva.SelectedValue = _IDdiscSuccessiva;
                else
                    cbDisciplinaSucessiva.SelectedIndex = -1;

                cbDisciplinaSucessiva.Enabled = true;
            }
        }
        private long CercaDisciplina()
        {
            long ID = 0;
            if (cbDisciplinaSucessiva.Enabled && cbDisciplinaSucessiva.SelectedIndex != -1)
            {
                var varDisciplina = Discipline.FirstOrDefault(p => p.Nome == cbDisciplinaSucessiva.Text&& p.Anno == anno + 1 && p.IDdipartimento == _dipartimento);

                if (varDisciplina != null)
                    ID = varDisciplina.ID;
            }

            return ID;
        }
        #endregion
    }
}
