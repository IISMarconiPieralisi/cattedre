using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class ucOreDoc : UserControl
    {
        int _idassegnare = 0;
        string nome, cognome;

        public int IDassegnare
        {
            get
            {
                return _idassegnare;
            }
        }

        public ucOreDoc()
        {
            InitializeComponent();
        }

        private void nudOrePot_ValueChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
                return;

            int idUtente = Convert.ToInt32(this.Tag);
            int oreSpeciali = Convert.ToInt32(nudOrePot.Value);

            ClsAssegnareBL.SalvaOrePot(oreSpeciali, idUtente);
        }
    }
}
