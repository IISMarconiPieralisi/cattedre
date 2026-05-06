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
        //liste di appoggio
        List<ClsClasseDiConcorsoDL> cdcDocente = new List<ClsClasseDiConcorsoDL>();
        //valori globali
        int _idassegnare = 0;
        //variabili interne (senza costruttori)
        long IDutente = 0;
        long IDdisciplina = 0;
        FrmCattedre frmCattedre;
         long IDannoScolastico = 0;
        ClsClasseDiConcorsoDL cdcPotDocente = new ClsClasseDiConcorsoDL();
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
            if (this.Tag == null || cdcPotDocente == null || IDdisciplina == 0)
                return;

            int oreSpeciali = Convert.ToInt32(nudOrePot.Value);
            ClsAssegnareBL.SalvaOrePot(oreSpeciali, IDutente, IDannoScolastico, IDdisciplina);
        }

        public void Inizializza(long idAnnoScolastico)
        {
            if (this.Tag == null) return;

            IDutente = Convert.ToInt64(this.Tag); 

            if (CDCPotenziamento == null || CDCPotenziamento.Count == 0)
                return;
            IDannoScolastico = idAnnoScolastico;
            cdcDocente = ClsRichiedereBL.RilevaCDCDocente(IDutente);
            if (ClsUtenteBL.CaricaUtente(IDutente).TipoDocente=='T')
                cdcDocente = cdcDocente.Where(cdc => cdc.Livello.StartsWith("A")).ToList();
            else
                cdcDocente = cdcDocente.Where(cdc => cdc.Livello.StartsWith("B")).ToList();

            cdcPotDocente = cdcDocente
                .FirstOrDefault(cdcDoc => CDCPotenziamento.Any(cdcPot => cdcPot.ID == cdcDoc.ID));

            if (cdcPotDocente == null)  // docente senza CDC di potenziamento
            {
                nudOrePot.Enabled = false;
                return;
            }

            long trovato = ClsDisciplinaBL.TrovaIDPotenziamentoDipartimentoPerCDC(
                IDdipartimento, cdcPotDocente.ID);

            if (trovato > 0)  // controllo corretto: 0 = non trovato, -1 = errore
                IDdisciplina = trovato;
            else
                nudOrePot.Enabled = false;
        }
    }
}
