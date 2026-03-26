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
    public partial class FrmCdC : Form
    {
        public ClsClasseDiConcorsoDL _cdc = new ClsClasseDiConcorsoDL();
        public ClsDotareDL _dot = new ClsDotareDL();
        long _lastTick = 0;
        public FrmCdC()
        {
            InitializeComponent();
            cbAnnoScolastico.Focus();
        }

        private void btSava_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbLivello.Text) && !string.IsNullOrWhiteSpace(tbNome.Text) && !string.IsNullOrWhiteSpace(rtbAbilitazioni.Text))
                {
                    _cdc.Livello = tbLivello.Text;
                    _cdc.AbilitazioniRichieste = rtbAbilitazioni.Text;
                    _cdc.Nome = tbNome.Text;
                    _dot.NumcattedreDiritto = Convert.ToInt32(nudNumCattedreDiritto.Value);
                    _dot.NumcattedreFatto = Convert.ToInt32(nudNumCattedreFatto.Value);
                    _dot.IdAnnoscolastico = ClsAnnoScolasticoBL.RilevaIDanno(cbAnnoScolastico.SelectedItem.ToString());

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    throw new Exception("Inserire tutti i valori richiesti");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\n riprovare!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCdC_Load(object sender, EventArgs e)
        {
            cbAnnoScolastico.Focus();
            FrmCdCs frmCdCs = new FrmCdCs();
            List<ClsAnnoScolasticoDL> _anniscolastici = ClsAnnoScolasticoBL.CaricaAnniScolastici();
            foreach(ClsAnnoScolasticoDL _as in _anniscolastici)
            {
                cbAnnoScolastico.Items.Add(_as.Sigla);
            }

            if (_cdc.Nome != null)
            {
                cbAnnoScolastico.SelectedItem = ClsAnnoScolasticoBL.RilevaSiglaAnnoScolastico(_dot.IdAnnoscolastico);
                tbNome.Text = _cdc.Nome;
                tbLivello.Text = _cdc.Livello;
                rtbAbilitazioni.Text = _cdc.AbilitazioniRichieste;
                nudNumCattedreDiritto.Value = _dot.NumcattedreDiritto;
                nudNumCattedreFatto.Value = _dot.NumcattedreFatto;
            }
        }
        

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region navigazione 


        private void cbAnnoScolastico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbAnnoScolastico.SelectedIndex != -1)
                tbLivello.Focus();
        }

        private void tbLivello_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbLivello.Text.Length > 2)
                tbNome.Focus();
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbNome.Text.Length > 2)
                rtbAbilitazioni.Focus();
        }

        private void rtbAbilitazioni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita il "Ding" di Windows

                long currentTick = DateTime.Now.Ticks;
                long elapsedMilliseconds = (currentTick - _lastTick) / TimeSpan.TicksPerMillisecond;

                if (elapsedMilliseconds < 500) // DOPPIO INVIO RAPIDO
                    nudNumCattedreDiritto.Focus();
                _lastTick = currentTick;

            }
        }

        private void nudNumCattedreDiritto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && nudNumCattedreDiritto.Value > 0)
                nudNumCattedreFatto.Focus();
        }

        private void nudNumCattedreFatto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && nudNumCattedreFatto.Value > 0)
                btSava.Focus();
        }
        #endregion

    }
}
