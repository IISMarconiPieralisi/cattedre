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
    public partial class FrmDotazione : Form
    {
        public ClsDotareDL _dot = new ClsDotareDL();
        List<ClsAnnoScolasticoDL> _anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
        List<ClsClasseDiConcorsoDL> cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
        public FrmDotazione()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAnnoScolastico.SelectedIndex>=0 && cbCDC.SelectedIndex >= 0)
                {
                    _dot.IdAnnoscolastico =Convert.ToInt32( cbAnnoScolastico.SelectedValue);
                    _dot.IdClasseDiConcorso = Convert.ToInt32(cbCDC.SelectedValue);
                    _dot.NumcattedreFatto = Convert.ToInt32(nudCattedreDiFatto.Value);
                    _dot.NumcattedreDiritto = Convert.ToInt32(nudCattedreDiDiritto.Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    throw new Exception("Inserire tutti i valori richiesti");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n riprovare!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDotazione_Load(object sender, EventArgs e)
        {
            cbAnnoScolastico.Focus();

            // Binding DataSource per Anno Scolastico
            cbAnnoScolastico.DataSource = _anniscolastici;
            cbAnnoScolastico.DisplayMember = "Sigla";
            cbAnnoScolastico.ValueMember = "ID";
            cbAnnoScolastico.SelectedIndex = -1;

            // Binding DataSource per Classe di Concorso
            cbCDC.DataSource = cdcs;
            cbCDC.DisplayMember = "Livello";
            cbCDC.ValueMember = "ID";
            cbCDC.SelectedIndex = -1;

            if (_dot != null)
            {
                cbAnnoScolastico.SelectedValue = _dot.IdAnnoscolastico;
                cbCDC.SelectedValue = _dot.IdClasseDiConcorso;
                nudCattedreDiDiritto.Value = _dot.NumcattedreDiritto;
                nudCattedreDiFatto.Value = _dot.NumcattedreFatto;
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCDC_Format(object sender, ListControlConvertEventArgs e)
        {
            var cdc = (ClsClasseDiConcorsoDL)e.ListItem;

            const int maxLength = 27;
            string nome = cdc.Nome;

            if (nome.Length > maxLength)
                nome = nome.Substring(0, maxLength) + "..";

            e.Value = $"{cdc.Livello} | {nome}";
        }
    }
}
