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
        #region Crud
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
       

       private void CaricaListView()
        {
            dots = ClsDotareBL.CaricaDotare(Filtri);
            lvDotazioni.Items.Clear();
            foreach (ClsDotareDL dot in dots)
            {
                ListViewItem lvi = new ListViewItem(dot.Id.ToString());
                lvi.SubItems.Add(ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(dot.IdAnnoscolastico));
                lvi.SubItems.Add(ClsClasseDiConcorsoBL.TrovaCodiceDaID(dot.IdClasseDiConcorso));
                lvi.SubItems.Add(dot.NumcattedreFatto.ToString());
                lvi.SubItems.Add(dot.NumcattedreDiritto.ToString());
                lvi.Tag = dot.Id;
                lvDotazioni.Items.Add(lvi);
            }
        }
        #endregion
        private void FrmDotazioni_Load(object sender, EventArgs e)
        {
            //popolamento controlli filtri
            GeneraFiltriAnnoScolastico();
            PopolaCDC();
            CaricaListView();
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
        private void cbCDC_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ClsClasseDiConcorsoDL item)
            {
                string nome = item.Nome.Length > 27
                    ? item.Nome.Substring(0, 25) + ".."
                    : item.Nome;

                e.Value = $"{item.Livello} | {nome}";
            }
        }
        private void btPulisciCb_Click(object sender, EventArgs e)
        {
            cbCDC.SelectedIndex = -1;
            Filtri.Clear();
            CaricaListView();
            DeselezionaCheckBox(tplAnniScolastici);
        }
        #endregion
        #region controlli tastiera
        private void lvDotazioni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lvDotazioni.SelectedIndices.Count == 1)
            {
                e.SuppressKeyPress = true;
                btModifica_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete && lvDotazioni.SelectedIndices.Count == 1)
            {
                e.SuppressKeyPress = true;
                btElimina_Click(null, null);
            }
        }

        private void cbCDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCDC.SelectedIndex >= 0)
                btCerca_Click(null, null);
            else
                btPulisciCb_Click(null, null);
        }
        #endregion
    }
}
