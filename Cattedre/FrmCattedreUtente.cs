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
        ClsUtenteDL utenteLoggato;
        private List<ClsAssegnareDL> _assegnazioni = new List<ClsAssegnareDL>();
        private List<ClsAnnoScolasticoDL> _anniscolastici = new List<ClsAnnoScolasticoDL>();
        public FrmCattedreUtente(ClsUtenteDL utente)
        {
            InitializeComponent();
            utenteLoggato = utente;
        }

        private void CaricaListView(long idanno)
        {
            _assegnazioni = ClsAssegnareBL
                .PopolaAssegnazioniUtenteAnnoScolastico(_utente.ID, idanno)
                .OrderBy(a => ClsClasseBL.RilevaSiglaClasse(a.IDClasse))
                .ThenBy(a => ClsDisciplinaBL.RilevaDisciplina(a.IDDisciplina).Nome)
                .ToList();
            lvCattedreUtente.Items.Clear();

            // Calcolo ore effettive una volta sola, non per ogni riga
            long idDipartimento = ClsUtenteBL.TrovaIDdipartimento(_utente.ID);
            int oreEffettive = ClsAssegnareBL.CalcolaOreEffettiveDocente(_utente.ID, idDipartimento, idanno);

            foreach (ClsAssegnareDL ass in _assegnazioni)
            {
                ListViewItem lvi = new ListViewItem(ass.ID.ToString());
                lvi.SubItems.Add(ClsClasseBL.RilevaSiglaClasse(ass.IDClasse));
                lvi.SubItems.Add(ClsDisciplinaBL.RilevaDisciplina(ass.IDDisciplina).Nome);
                lvi.SubItems.Add(ass.OreSpeciali.ToString());
                lvi.SubItems.Add(oreEffettive.ToString()); // ore effettive totali del docente
                lvi.SubItems.Add((oreEffettive + ass.OreSpeciali).ToString());
                lvCattedreUtente.Items.Add(lvi);
            }
        }

        private void CaricaCB(out List<ClsAnnoScolasticoDL> anniscolastici)
        {
            anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();

            DateTime oggi = DateTime.Today;
            int annoInizio;
            if (oggi.Month >= 9)
                annoInizio = oggi.Year % 100;
            else
                annoInizio = (oggi.Year - 1) % 100;

            for (int i = 0; i < anniscolastici.Count; i++)
            {
                // Per utenti normali, mostra solo anni correnti e passati
                if (utenteLoggato.TipoUtente != "C" && utenteLoggato.TipoUtente != "A")
                {
                    // Estrai l'anno di inizio dalla sigla (es. "23-24" -> 23)
                    string sigla = anniscolastici[i].Sigla;
                    if (int.TryParse(sigla.Substring(0, 2), out int annoInizioSigla))
                    {
                        if (annoInizioSigla > annoInizio)
                            continue; // Salta gli anni futuri
                    }
                }
                cbAnniScolastici.Items.Add(anniscolastici[i].Sigla);
            }
        }

        private void FrmCattedreUtente_Load(object sender, EventArgs e)
        {
            if (utenteLoggato.TipoUtente != "C" && utenteLoggato.TipoUtente != "A")
                btElimina.Visible = false;

            CaricaCB(out _anniscolastici);

            DateTime oggi = DateTime.Today;
            int annoInizio;
            if (oggi.Month >= 9)
                annoInizio = oggi.Year % 100;
            else
                annoInizio = (oggi.Year - 1) % 100;
            int annoFine = annoInizio + 1;
            string sigla = $"{annoInizio:D2}-{annoFine:D2}";

            foreach (string item in cbAnniScolastici.Items)
            {
                if (item == sigla)
                {
                    cbAnniScolastici.SelectedItem = item;
                    break;
                }
            }
        }

        private void cbAnniScolastici_SelectedIndexChanged(object sender, EventArgs e)
        {
            string anno = cbAnniScolastici.SelectedItem.ToString();
            CaricaListView(ClsAnnoScolasticoBL.RilevaIDanno(anno));
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvCattedreUtente.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvCattedreUtente.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvCattedreUtente.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsAssegnareBL.EliminaAssegnazioneID(Convert.ToInt64(lvCattedreUtente.Items[indiceDaEliminare].SubItems[0].Text));
                    CaricaListView(ClsAnnoScolasticoBL.RilevaIDanno(cbAnniScolastici.SelectedItem.ToString()));
                }
            }
        }
    }
}
