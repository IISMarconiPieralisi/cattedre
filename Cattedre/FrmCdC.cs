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
    public partial class FrmCdC : Form
    {
        public ClsClasseDiConcorsoDL _cdc = new ClsClasseDiConcorsoDL();
        public ClsDotareDL _dot = new ClsDotareDL();

        public FrmCdC()
        {
            InitializeComponent();
        }

        private void btSava_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbLivello.Text) && !string.IsNullOrWhiteSpace(tbNome.Text) && !string.IsNullOrWhiteSpace(rtbAbilitazioni.Text))
                {
                    _cdc.Livello = tbLivello.Text;
                    _cdc.AbilitazioniRichieste = rtbAbilitazioni.Text;
                    _cdc.Nome = tbNome.Text;
                    _dot.NumcattedreDiritto = Convert.ToInt32(nudNumCattedreDiritto.Value);
                    _dot.NumcattedreFatto = Convert.ToInt32(nudNumCattedreFatto.Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    throw new Exception("Inserire tutti i valori richiesti");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\n riprovare!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbLivello.Focus();
            }
        }

        private void FrmCdC_Load(object sender, EventArgs e)
        {
            FrmCdCs frmCdCs = new FrmCdCs();

            if (_cdc.Nome != null)
            {
                tbNome.Text = _cdc.Nome;
                tbLivello.Text = _cdc.Livello;
                rtbAbilitazioni.Text = _cdc.AbilitazioniRichieste;
                nudNumCattedreDiritto.Value = _dot.NumcattedreDiritto;
                nudNumCattedreFatto.Value = _dot.NumcattedreFatto;
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
