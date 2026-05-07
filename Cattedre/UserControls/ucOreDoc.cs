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
        //varuabuku gobali
        public Dictionary<long, ucOreDoc> DictDocenti { get; set; }
        public Dictionary<long, List<ClsClasseDiConcorsoDL>> CacheCDC { get; set; }
        // Evento per notificare il chiamante (es. per AggiornaOreEffettive)
        public event EventHandler OrePotValide;

        // Sostituisce il lambda in CreaUcOreDoc
        private int valorePrec = 0;
        private bool isResetting = false;

        public void ImpostaValorePrec(int valore) => valorePrec = valore;
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

        public long IDdipartimento { get; set; }

        public List<ClsClasseDiConcorsoDL> CDCPotenziamento { get; set; }

        public ucOreDoc()
        {
            InitializeComponent();
        }

        private void nudOrePot_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Tag == null || cdcPotDocente == null || IDdisciplina == 0)
                    return;
                if (isResetting) return;

                // Validazione ore massime
                if (DictDocenti != null && CacheCDC != null)
                {
                    int oreMax = ClsDisciplinaBL.RilevaOrePotenziamentoDipartimentoPerCDC(
                        IDdipartimento, cdcPotDocente.ID);

                    long idDocenteCorrente = IDutente;

                    int orePotAltriDocenti = DictDocenti
                        .Where(kvp =>
                        {
                            if (kvp.Key == idDocenteCorrente) return false;
                            var cdcDocenteKvp = CacheCDC.ContainsKey(kvp.Key)
                                ? CacheCDC[kvp.Key]
                                : ClsRichiedereBL.RilevaCDCDocente(kvp.Key);
                            return cdcDocenteKvp.Any(c => c.ID == cdcPotDocente.ID);
                        })
                        .Sum(kvp => (int)kvp.Value.nudOrePot.Value);

                    int nuovoValore = (int)nudOrePot.Value;

                    if (orePotAltriDocenti + nuovoValore > oreMax)
                        throw new Exception("Superato il limite di ore di potenziamento consentite: " + oreMax);
                    
                    valorePrec = nuovoValore;
                    OrePotValide?.Invoke(this, EventArgs.Empty);
                }
                int oreSpeciali = Convert.ToInt32(nudOrePot.Value);
                ClsAssegnareBL.SalvaOrePot(oreSpeciali, IDutente, IDannoScolastico, IDdisciplina);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
