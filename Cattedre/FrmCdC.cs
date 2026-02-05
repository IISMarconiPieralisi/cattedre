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

        public FrmCdC()
        {
            InitializeComponent();
        }

        private void btSava_Click(object sender, EventArgs e)
        {
            try
            {
                _cdc.Livello = tbLivello.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbLivello.Focus();
            }
            _cdc.Nome = tbNome.Text;
            _cdc.AbilitazioniRichieste = rtbAbilitazioni.Text;
        }

        private void FrmCdC_Load(object sender, EventArgs e)
        {
            FrmCdCs frmCdCs = new FrmCdCs();

            if (_cdc.Nome != null)
            {
                tbNome.Text = _cdc.Nome;
                tbLivello.Text = _cdc.Livello;
                rtbAbilitazioni.Text = _cdc.AbilitazioniRichieste;
                label4.Text = "Modifica CDC";
            }
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
