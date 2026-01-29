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
        public ClsDisciplinaDL _disciplina = new ClsDisciplinaDL();
        public int IDdipartimento;

        public FrmDisciplina()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            if (tbDisciplinaSpeciale.Text != "potenziamento" || tbDisciplinaSpeciale.Text != "")
            {
                _disciplina.Nome = tbNome.Text;
                if (ckbAnno1.Checked)
                    _disciplina.Anno = 1;
                else if (ckbAnno2.Checked)
                    _disciplina.Anno = 2;
                else if (ckbAnno3.Checked)
                    _disciplina.Anno = 3;
                else if (ckbAnno4.Checked)
                    _disciplina.Anno = 4;
                else if (ckbAnno5.Checked)
                    _disciplina.Anno = 5;
                else
                {
                    MessageBox.Show("Anno non valido");
                    this.DialogResult = DialogResult.None;
                }
                if ((ckbAnno1.Checked && ckbAnno2.Checked) || (ckbAnno1.Checked && ckbAnno3.Checked) || (ckbAnno1.Checked && ckbAnno4.Checked) ||
                    (ckbAnno1.Checked && ckbAnno5.Checked) ||
                    (ckbAnno2.Checked && ckbAnno3.Checked) || (ckbAnno2.Checked && ckbAnno4.Checked) || (ckbAnno2.Checked && ckbAnno5.Checked) ||
                    (ckbAnno3.Checked && ckbAnno4.Checked) || (ckbAnno3.Checked && ckbAnno5.Checked) ||
                    (ckbAnno4.Checked && ckbAnno5.Checked))
                {
                    MessageBox.Show("Anno non valido");
                    this.DialogResult = DialogResult.None;
                }
            }

            _disciplina.OreLaboratorio = (int)nudOreLab.Value;
            _disciplina.OreTeoria = (int)nudOreTeoria.Value;
            _disciplina.DisciplinaSpeciale = tbDisciplinaSpeciale.Text;


            if (string.IsNullOrEmpty(_disciplina.Nome))
            {
                MessageBox.Show("Nome mancante");
                this.DialogResult = DialogResult.None;
            }
            else
                IDdipartimento = Convert.ToInt32(cbDipartimentoAppartenente.SelectedValue);
        }

        private void FrmDisciplina_Load(object sender, EventArgs e)
        {
            FrmDiscipline frmDiscipline = new FrmDiscipline();
            dipartimenti = ClsDipartimentoBL.CaricaDipartimenti();

            cbDipartimentoAppartenente.DataSource = dipartimenti;
            cbDipartimentoAppartenente.DisplayMember = "Nome";
            cbDipartimentoAppartenente.ValueMember = "ID";

            if (_disciplina.Nome != null)
            {
                tbNome.Text = _disciplina.Nome;
                nudOreLab.Value = _disciplina.OreLaboratorio;
                nudOreTeoria.Value = _disciplina.OreTeoria;
                switch(_disciplina.Anno)
                {
                    case 1:
                        ckbAnno1.Checked = true;
                        break;
                    case 2:
                        ckbAnno2.Checked = true;
                        break;
                    case 3:
                        ckbAnno3.Checked = true;
                        break;
                    case 4:
                        ckbAnno4.Checked = true;
                        break;
                    case 5:
                        ckbAnno5.Checked = true;
                        break;
                }
                tbDisciplinaSpeciale.Text = _disciplina.DisciplinaSpeciale;

                IDdipartimento = ClsDisciplinaBL.IDdipartimenti[frmDiscipline.indiceDaModificare];

                cbDipartimentoAppartenente.SelectedIndex = IDdipartimento - 1;
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
