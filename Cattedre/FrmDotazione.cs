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
        public FrmDotazione()
        {
            InitializeComponent();
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cbAnnoScolastico.Text) && !string.IsNullOrWhiteSpace(cbCDC.Text))
                {
                    _dot.IdAnnoscolastico = ClsAnnoScolasticoBL.RilevaIDanno(cbAnnoScolastico.SelectedItem.ToString());
                    _dot.IdClasseDiConcorso = ClsClasseDiConcorsoBL.TrovaIDcdc(cbCDC.SelectedItem.ToString());
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
            FrmCdCs frmCdCs = new FrmCdCs();
            List<ClsAnnoScolasticoDL> _anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
            List<ClsClasseDiConcorsoDL> cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
            foreach (ClsAnnoScolasticoDL _as in _anniscolastici)
            {
                cbAnnoScolastico.Items.Add(_as.Sigla);
            }
            foreach (ClsClasseDiConcorsoDL _cdc in cdcs)
            {
                cbCDC.Items.Add(_cdc.Livello);
            }

            if (_dot != null)
            {
                cbAnnoScolastico.SelectedItem = ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(_dot.IdAnnoscolastico);
                cbCDC.Text = ClsClasseDiConcorsoBL.TrovaCodiceDaID(_dot.IdClasseDiConcorso);
                nudCattedreDiDiritto.Value = _dot.NumcattedreDiritto;
                nudCattedreDiFatto.Value = _dot.NumcattedreFatto;
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
