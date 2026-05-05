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

        public int IDassegnare
        {
            get
            {
                return _idassegnare;
            }
        }

        public int IDdipartimento { get; set; }

        public List<ClsClasseDiConcorsoDL> CDCPotenziamento { get; set; }

        public ucOreDoc()
        {
            InitializeComponent();
        }

        private void nudOrePot_ValueChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
                return;

            int IDutente = Convert.ToInt32(this.Tag);
            FrmCattedre frmCattedre = (FrmCattedre)this.ParentForm;
            string siglaannoscolastico = frmCattedre.Annoscolasticoselezionato;
            ClsAnnoScolasticoDL annoCorrente = ClsAnnoScolasticoBL.CercaAnnoScolastico(siglaannoscolastico);
            int oreSpeciali = Convert.ToInt32(nudOrePot.Value);

            List<ClsClasseDiConcorsoDL> cdcDocente = ClsRichiedereBL.RilevaCDCDocente(IDutente);
            ClsClasseDiConcorsoDL cdcPotDocente = cdcDocente
                .FirstOrDefault(cdcDoc => CDCPotenziamento.Any(cdcPot => cdcPot.ID == cdcDoc.ID));

            if (cdcPotDocente == null)
                return;

            long IDdisciplina = ClsDisciplinaBL.TrovaIDPotenziamentoDipartimentoPerCDC(IDdipartimento, cdcPotDocente.ID);

            if (IDdisciplina == 0)
                return;

            ClsAssegnareBL.SalvaOrePot(oreSpeciali, IDutente, annoCorrente.ID, IDdisciplina);
        }
    }
}
