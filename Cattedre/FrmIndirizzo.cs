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
    public partial class FrmIndirizzo : Form
    {
        public ClsIndirizzoDL _indirizzo = new ClsIndirizzoDL();
        public FrmIndirizzo()
        {
            InitializeComponent();
        }

        private void btSalvaIndirizzo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbNome.Text)&& tbNome.Text.Length>=3)
                    _indirizzo.Nome = tbNome.Text.Trim();
                else
                    throw new Exception("inserire un nome valido");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\n riprovare!","errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FrmIndirizzo_Load(object sender, EventArgs e)
        {
            if (_indirizzo.Nome != null)
                tbNome.Text = _indirizzo.Nome;
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
