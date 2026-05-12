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
    public partial class FrmCattedreUtente : Form
    {
        public ClsUtenteDL _utente;
        private List<ClsAssegnareDL> _assegnazioni = new List<ClsAssegnareDL>();
        public FrmCattedreUtente()
        {
            InitializeComponent();
        }

        private void CaricaListView()
        {
            _assegnazioni = ClsAssegnareBL.PopolaAssegnazioniUtenteAnnoScolastico(_utente.ID, 1);
            foreach(ClsAssegnareDL ass in _assegnazioni)
            {
                ListViewItem lvi = new ListViewItem(ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(ass.IDAnnoScolastico));

                lvi.SubItems.Add(ClsClasseBL.RilevaSiglaClasse(ass.IDClasse));
                lvi.SubItems.Add(ClsDisciplinaBL.RilevaDisciplina(ass.IDDisciplina).Nome);
                lvi.SubItems.Add(ass.OreSpeciali.ToString());

                lvCattedreUtente.Items.Add(lvi);
            }
        }

        private void FrmCattedreUtente_Load(object sender, EventArgs e)
        {
            CaricaListView();
        }
    }
}
