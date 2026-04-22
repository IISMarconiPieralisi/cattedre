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
    public partial class FrmDotazioni : Form
    {
        List<ClsDotareDL> dots = new List<ClsDotareDL>();
        List<ClsClasseDiConcorsoDL> cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
        List<ClsAnnoScolasticoDL> _anniScolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
        Dictionary<string, List<string>> Filtri = new Dictionary<string, List<string>>();
        public FrmDotazioni()
        {
            InitializeComponent();
        }

        private void btInserisci_Click(object sender, EventArgs e)
        {
            FrmDotazione frmDotazione = new FrmDotazione();
            DialogResult dr = frmDotazione.ShowDialog();

            if (frmDotazione._dot.IdClasseDiConcorso <= 0)
                dr = DialogResult.No;
            if (dr == DialogResult.OK)
            {
                ClsDotareBL.InserisciDotare(frmDotazione._dot);
                CaricaListView();
            }
        }

        private void CaricaListView()
        {
            dots = ClsDotareBL.CaricaDotare(Filtri);
            cdcs = ClsClasseDiConcorsoBL.CaricaCdcs();
            lvDotazioni.Items.Clear();
            for (int i = 0; i < dots.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dots[i].Id.ToString());
                lvi.SubItems.Add(ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(dots[i].IdAnnoscolastico));
                lvi.SubItems.Add(ClsClasseDiConcorsoBL.TrovaCodiceDaID(dots[i].IdClasseDiConcorso));
                lvi.SubItems.Add(dots[i].NumcattedreFatto.ToString());
                lvi.SubItems.Add(dots[i].NumcattedreDiritto.ToString());
                lvi.Tag = cdcs[i].ID;
                lvDotazioni.Items.Add(lvi);
            }
        }

        private void FrmDotazioni_Load(object sender, EventArgs e)
        {
            //popolamento controlli filtri
            GeneraFiltriAnnoScolastico();

            CaricaListView();
        }

        private void btModifica_Click(object sender, EventArgs e)
        {
            if (lvDotazioni.SelectedIndices.Count == 1)
            {
                int indiceDaModificare = Convert.ToInt32(lvDotazioni.SelectedIndices[0]);
                FrmDotazione frmDotazione = new FrmDotazione();
                frmDotazione._dot = dots[indiceDaModificare];
                DialogResult dr = frmDotazione.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ClsDotareBL.AggiornaDotare(frmDotazione._dot);
                    CaricaListView();
                }
            }
            else
                MessageBox.Show("Selezionare un elemento da modificare", "attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btElimina_Click(object sender, EventArgs e)
        {
            if (lvDotazioni.SelectedIndices.Count == 1)
            {
                int indiceDaEliminare = lvDotazioni.SelectedIndices[0];
                int idDaEliminare = Convert.ToInt32(lvDotazioni.Items[indiceDaEliminare].Tag);
                DialogResult dr = MessageBox.Show("Sei sicuro?", "CANCELLAZIONE", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ClsDotareBL.EliminaDotare(idDaEliminare);
                }

                CaricaListView();
            }
        }
        #region filtra
        private void GeneraFiltriAnnoScolastico()
        {
            tplAnniScolastici.ColumnCount = _anniScolastici.Count;
            tplAnniScolastici.RowCount = 1;

            // Imposta le colonne con larghezza automatica
            tplAnniScolastici.ColumnStyles.Clear();
            for (int i = 0; i < _anniScolastici.Count; i++)
                tplAnniScolastici.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            int sezione = 0;
            foreach (var anno in _anniScolastici)
            {
                CheckBox cb = new CheckBox();
                cb.Name = $"{anno.ID}";
                cb.Text = anno.Sigla;
                cb.Dock = DockStyle.Fill;
              //  cb.KeyDown += CheckBoxAnno_KeyDown;
                tplAnniScolastici.Controls.Add(cb, sezione, 0);
                sezione++;
            }
        }
        private void PopolaCDC()
        {
            if(cdcs.Count>0)
            {
                cbCDC.DataSource = cdcs;
                cbCDC.DisplayMember = "Nome";
                cbCDC.ValueMember = "ID";
                cbCDC.SelectedIndex = -1;
            }
        }
        private void btCerca_Click(object sender, EventArgs e)
        {
            try
            {
                Filtri = new Dictionary<string, List<string>>();

                if (cbCDC.SelectedIndex != -1)
                {
                    Filtri.Add("IDclassediconcorso", new List<string> { $"'{cbCDC.SelectedValue}'" });
                }
                ControlloSelezionatiAnniScolastici();

                if (Filtri.Count <= 0)
                    throw new Exception("Inserire almeno un criterio di ricerca");

                CaricaListView();
                btPulisciCb.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nRiprovare!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeselezionaCheckBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is CheckBox cb)
                    cb.Checked = false;
            }
        }

        private void ControlloSelezionatiAnniScolastici()
        {
            if (tplAnniScolastici.Controls.OfType<CheckBox>().Any(cb => cb.Checked))
            {
                var selezionati = tplAnniScolastici.Controls.OfType<CheckBox>().Where(cb => cb.Checked).Select(cb => cb.Name).ToList();

                if (!selezionati.Any()) return;

                Filtri.Add("IDannoScolastico", selezionati);
            }
        }
        #endregion


    }
}
