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
    public partial class UcClasse : UserControl
    {
        public UcClasse(ClsClasseDL clsClasseDL)
        {
            
            InitializeComponent();
            lblClasse.Text = clsClasseDL.Sigla;
            lblcoordinatore.Text = clsClasseDL.NomeCoordinatore;
        }
    }
}
