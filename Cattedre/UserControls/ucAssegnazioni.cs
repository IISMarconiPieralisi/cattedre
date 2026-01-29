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
    public partial class UcAssegnazioni : UserControl
    {
        long _iddocth = 0;
        long _iddoclab = 0;

        static ClsUtenteDL docente = new ClsUtenteDL();
        public FrmCattedre frmCattedre = new FrmCattedre(docente);

        public long IDdocTh
        {
            get
            {
                return _iddocth;
            }
        }

        public long IDdocLab
        {
            get
            {
                return _iddoclab;
            }
        }

        public UcAssegnazioni(ClsDisciplinaDL clsDisciplinaDL, ClsClasseDL clsClasseDL, ClsUtenteDL docente)
        {
            InitializeComponent();
            
        }

        public UcAssegnazioni()
        {
            InitializeComponent();

        }

        private void cbDocentiTeorici_SelectedIndexChanged(object sender, EventArgs e)
        {
            _iddocth = cbDocentiTeorici.SelectedIndex;
        }

        private void cbDocentiItip_SelectedIndexChanged(object sender, EventArgs e)
        {
            _iddoclab = cbDocentiItip.SelectedIndex;
        }
    }
}
