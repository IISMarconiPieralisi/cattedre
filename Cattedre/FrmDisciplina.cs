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

        public List<ClsAppartenereDL> _Apparteneres = new List<ClsAppartenereDL>();
        public ClsDisciplinaDL _disciplina;

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
                _disciplina.Nome = (tbNome.Text.Length >= 3) ? tbNome.Text.Trim() : throw new Exception("inserire Nome con almeno 3 caratteri");
                _disciplina.Anno = (rbPrimo.Checked) ? 1 : (rbSecondo.Checked) ? 2 : (rbTerzo.Checked) ? 3 : (rbQuarto.Checked) ? 4 : (rbQuinto.Checked) ? 5 : 0;
                if (_disciplina.Anno == 0 && tbDisciplinaSpeciale.Text.Trim() == string.Empty)
                {
                    throw new Exception("inserire un anno valido");
                }
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
            FrmDiscipline frmDiscipline = new FrmDiscipline();
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
    }
}
