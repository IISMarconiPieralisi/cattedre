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
        private List<ClsAnnoScolasticoDL> _anniscolastici = new List<ClsAnnoScolasticoDL>();
        private FrmCattedre frmCattedre;
        public FrmCattedreUtente()
        {
            InitializeComponent();
        }

        private void CaricaListView(long idanno)
        {
            _assegnazioni = ClsAssegnareBL.PopolaAssegnazioniUtenteAnnoScolastico(_utente.ID, idanno);
            lvCattedreUtente.Items.Clear();

            // Calcolo ore effettive una volta sola, non per ogni riga
            long idDipartimento = ClsUtenteBL.TrovaIDdipartimento(_utente.ID);
            int oreEffettive = ClsAssegnareBL.CalcolaOreEffettiveDocente(_utente.ID, idDipartimento, idanno);

            foreach (ClsAssegnareDL ass in _assegnazioni)
            {
                ListViewItem lvi = new ListViewItem(ClsClasseBL.RilevaSiglaClasse(ass.IDClasse));
                lvi.SubItems.Add(ClsDisciplinaBL.RilevaDisciplina(ass.IDDisciplina).Nome);
                lvi.SubItems.Add(ass.OreSpeciali.ToString());
                lvi.SubItems.Add(oreEffettive.ToString()); // ore effettive totali del docente
                lvi.SubItems.Add((oreEffettive + ass.OreSpeciali).ToString());
                lvCattedreUtente.Items.Add(lvi);
            }
        }

        private void CaricaCB()
        {
            _anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
            for (int i = 0; i < _anniscolastici.Count; i++)
                cbAnniScolastici.Items.Add(_anniscolastici[i].Sigla);
        }

        private void FrmCattedreUtente_Load(object sender, EventArgs e)
        {
            CaricaCB();
        }

        private void cbAnniScolastici_SelectedIndexChanged(object sender, EventArgs e)
        {
            string anno = cbAnniScolastici.SelectedItem.ToString();
            CaricaListView(ClsAnnoScolasticoBL.RilevaIDanno(anno));
        }
    }
}
