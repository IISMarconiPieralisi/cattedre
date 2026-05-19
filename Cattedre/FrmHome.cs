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
    public partial class FrmHome : Form
    {
        #region dichiarazione form
        FrmCdCs frmCdcs;
        FrmIndirizzi frmIndirizzi;
        FrmDipartimenti frmDipartimenti;
        FrmDiscipline frmDiscipline;
        FrmClassi frmClassi;
        FrmUtenti frmUtenti;
        FrmAnniScolastici FrmAnniScolastici;
        FrmDotazioni frmDotazioni;
        FrmCredits frmCredits;
        #endregion

        //variabili globali
        private ClsUtenteDL utente;
        private int _menuFullWidth = 230; // larghezza normale
        private int _menuMinWidth = 2;  // larghezza minima
        private double _rapportoSplitter = -1; // -1 = non ancora calcolato
        private bool _splitterInAggiornamento = false;

        private readonly Dictionary<Button, (string icona, string testo)> _vociMenu= new Dictionary<Button, (string, string)>();

        public Action OnLogout { get; set; }
        public FrmHome(ClsUtenteDL utenteLoggato)
        {
            InitializeComponent();
            utente = utenteLoggato;
        }        
        private void FrmHomeUpdate_Load(object sender, EventArgs e)
        {
            RenderFotoTonda();
            if (utente.TipoUtente == "A")
            {
                menuStrip1.Enabled = true;
                //btVaiACattedre.Visible = false;
            }
            else if (utente.TipoUtente == "C")
            {
                menuStrip1.Visible = false;
                btDiscipline.Visible = true;
                btUtenti.Visible = true;
                btClassi.Visible = true;
                btVaiACattedre.Visible = true;
            }
            else if (utente.TipoUtente == "D")
            {
                menuStrip1.Visible = false;
                btVaiACattedre.Visible = false;
                btVaiACattedre2.Visible = false;
                btClassi.Visible = false;
                btDiscipline.Visible = false;
                btUtenti.Visible = true;
            }
            else
            {
                menuStrip1.Visible = false;
                btUtenti.Visible = false;
                btVaiACattedre.Visible = false;
            }
            lblNominativo.Text = utente.Nome.ToUpper() + " " + utente.Cognome.ToUpper();
            // AggiornaLabel(lblNominativo.Text, lblNominativo);
            lblEmail.Text = utente.Email;
            // AggiornaLabel(lblEmail.Text, lblEmail);
            InitSidebar();
            CentraControlli();
        }

        #region immagine profilo

        public void ImpostaFotoProfilo(Image foto)
        {
            _fotoProfilo = foto;
            pbFotoProfilo.Image = null; // non lasciare che la picturebox disegni da sola
            pbFotoProfilo.Invalidate();
        }

        private Image _fotoProfilo = null;

        private void RenderFotoTonda()
        {
            if (_fotoProfilo == null)
                return;

            // taglia fisicamente la forma del controllo a cerchio
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pbFotoProfilo.Width, pbFotoProfilo.Height);
            pbFotoProfilo.Region = new Region(path);

            pbFotoProfilo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (_fotoProfilo != null)
                    e.Graphics.DrawImage(_fotoProfilo, 0, 0, pbFotoProfilo.Width, pbFotoProfilo.Height);

                // bordo
                using (Pen pen = new Pen(Color.Gray, 2))
                    e.Graphics.DrawEllipse(pen, 1, 1, pbFotoProfilo.Width - 2, pbFotoProfilo.Height - 2);
            };
        }

        private void AggiornaLabel(string nuovoTesto, Label label1)  // per allargare la label non più verso destra ma verso sinistra
        {
            label1.Text = nuovoTesto;

            Size textSize = TextRenderer.MeasureText(nuovoTesto, label1.Font);

            label1.Width = textSize.Width;

            label1.Left = label1.Parent.Width - label1.Margin.Right - label1.Width;
        }
        #endregion
        #region gestione e formattazione menù strip
        private void MostraFormMDI(Form frm)
        {
            // 1. Controllo duplicati: Se il form è già visualizzato, non fare nulla
            if (splHome.Panel2.Controls.Count > 0)
            {
                if (splHome.Panel2.Controls[0].GetType() == frm.GetType())
                {
                    return; // Il form è già aperto, esci dalla funzione
                }
            }

            // 2. Pulizia sicura del pannello
            // Usiamo un ciclo inverso per evitare problemi di indice durante la rimozione
            for (int i = splHome.Panel2.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = splHome.Panel2.Controls[i];
                if (ctrl is Form oldForm)
                {
                    oldForm.Close();
                    oldForm.Dispose(); // Libera la memoria immediatamente
                }
            }
            splHome.Panel2.Controls.Clear();

            // 3. Configurazione del nuovo Form
            frm.TopLevel = false;


            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;

            frm.Dock = DockStyle.Fill;

            // 4. Visualizzazione
            splHome.Panel2.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
        }

        private void cDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["frmCdcs"] == null)
                frmCdcs = new FrmCdCs();
            MostraFormMDI(frmCdcs);
        }
        private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
        {

            menuStrip1.MenuDeactivate -= menuStrip1_MenuDeactivate;
            btVaiACattedre.Focus();
        }
        private void iNDIRIZZIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmIndirizzi"] == null)
                frmIndirizzi = new FrmIndirizzi();
            MostraFormMDI(frmIndirizzi);
        }

        private void dIPARTIMENTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmDipartimenti"] == null)
                frmDipartimenti = new FrmDipartimenti();
            MostraFormMDI(frmDipartimenti);
        }

        private void dISCIPLINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmDiscipline"] == null)
                frmDiscipline = new FrmDiscipline(utente);
            MostraFormMDI(frmDiscipline);
        }

        private void cLASSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmClassi"] == null)
                frmClassi = new FrmClassi(utente);
            MostraFormMDI(frmClassi);
        }

        private void uTENTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmUtenti"] == null)
            {
                frmUtenti = new FrmUtenti(utente);
            }
            MostraFormMDI(frmUtenti);

        }

        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmCredits"] == null)
            {
                frmCredits = new FrmCredits();
            }
            MostraFormMDI(frmCredits);

        }

        private void annoScolasticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmAnniScolastici"] == null)
                FrmAnniScolastici = new FrmAnniScolastici();
            MostraFormMDI(FrmAnniScolastici);
        }
        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (e.KeyCode == Keys.Escape || (e.KeyCode == Keys.Tab && e.Shift))
            {
                e.SuppressKeyPress = true;
                menuStrip1.MenuDeactivate += menuStrip1_MenuDeactivate;
                //menuStrip1.Enabled = true; // assicurati che sia attivo
                btVaiACattedre.Focus();
            }
        }
        private void cattedreAssegnateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmDotazioni"] == null)
                frmDotazioni = new FrmDotazioni();
            MostraFormMDI(frmDotazioni);
        }
        #endregion
        #region bottoni menù laterare
        private void btDiscipline_KeyDown(object sender, KeyEventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                menuStrip1.Focus();
                // Seleziona il primo item (CDC)
                menuStrip1.Items[0].Select();
            }
        }
        private void btVaiACattedre_Click(object sender, EventArgs e)
        {
            FrmCattedre frmCattedre = new FrmCattedre(utente);
            frmCattedre.Show();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsUtenteBL.TokenEsistente(utente.ID))
                    FrmLogin.logout();

                foreach (Form figlio in this.MdiChildren.ToList())
                    figlio.Close();

                OnLogout?.Invoke(); // segnala al Program che è un logout
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Errore Durante il logout, contattare un amministratore", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btVaiACattedre_MouseEnter(object sender, EventArgs e)
        {
            pnlDecCattedre.Visible = true;

        }

        private void btVaiACattedre_MouseLeave(object sender, EventArgs e)
        {
            pnlDecCattedre.Visible = false;

        }


        private void btUtenti_MouseEnter(object sender, EventArgs e)
        {
            pnlDecUtenti.Visible = true;

        }

        private void btUtenti_MouseLeave(object sender, EventArgs e)
        {
            pnlDecUtenti.Visible = false;

        }

        private void btClassi_MouseEnter(object sender, EventArgs e)
        {
            pnlDecClassi.Visible = true;

        }

        private void btClassi_MouseLeave(object sender, EventArgs e)
        {
            pnlDecClassi.Visible = false;

        }

        private void btDiscipline_MouseEnter(object sender, EventArgs e)
        {
            pnlDecDiscipline.Visible = true;

        }

        private void btDiscipline_MouseLeave(object sender, EventArgs e)
        {
            pnlDecDiscipline.Visible = false;

        }
        private void btCredits_Click(object sender, EventArgs e)
        {
            pnlBenvenuto.Visible = false;
            pnlCentrale.Visible = false;
            if (Application.OpenForms["FrmCredits"] == null)
                frmCredits = new FrmCredits();
            MostraFormMDI(frmCredits);
        }

        private void btCredits_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btCredits_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        private void CentraControlli()
        {
            if (pnlCentrale.ClientSize.Width <= 0 || pnlCentrale.ClientSize.Height <= 0)
                return;

            int cx = pnlCentrale.ClientSize.Width / 2;
            int startTop = pnlCentrale.ClientSize.Height / 2 - 80; // punto di partenza verticale

            // Ordine corretto dall'alto verso il basso:
            // 1. "Benvenuto" (label5)
            label5.Left = cx - label5.Width / 2;
            label5.Top = startTop;

            // 2. "Seleziona una sezione" (label3)
            label3.Left = cx - label3.Width / 2;
            label3.Top = label5.Bottom + 6;

            // 3. "Scegli una voce..." (label4)
            label4.Left = cx - label4.Width / 2;
            label4.Top = label3.Bottom + 6;

            // 4. Linea separatore (panel4)
            panel4.Left = cx - panel4.Width / 2;
            panel4.Top = label4.Bottom + 8;

            // 5. Bottone "Visualizza le cattedre"
            btVaiACattedre2.Left = cx - btVaiACattedre2.Width / 2;
            btVaiACattedre2.Top = panel4.Bottom + 14;
        }

        #endregion
        #region gestione barra laterale
        private void InitSidebar()
        {
            _vociMenu.Clear();
            if (btVaiACattedre.Visible) _vociMenu[btVaiACattedre] = ("⊞", "⊞  Cattedre");
            if (btUtenti.Visible) _vociMenu[btUtenti] = ("👤", "👤  Utenti");
            if (btClassi.Visible) _vociMenu[btClassi] = ("▦", "▦  Classi");
            if (btDiscipline.Visible) _vociMenu[btDiscipline] = ("≡", "≡  Discipline");
            if (btCredits.Visible) _vociMenu[btCredits] = ("★", "★  Credits");

            splHome.FixedPanel = FixedPanel.None;

            // Rapporto calcolato quando il form è completamente visibile
            this.Shown += (s, e) =>
            {
                if (splHome.Width > 0)
                    _rapportoSplitter = (double)splHome.SplitterDistance / splHome.Width;
            };

            this.SizeChanged += FrmHome_SizeChanged;
            AggiornaSidebar();
        }

        private void splHome_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_splitterInAggiornamento) return;

            if (splHome.Width > 0)
                _rapportoSplitter = (double)splHome.SplitterDistance / splHome.Width;

            AggiornaSidebar();
        }

        private void FrmHome_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            if (_rapportoSplitter < 0) return;
            if (splHome.Width <= 0) return;

            int nuova = (int)(splHome.Width * _rapportoSplitter);
            ImpostaDistanzaSicura(nuova);
            CentraControlli();
        }

       private void ImpostaDistanzaSicura(int distanza)
        {
            int min = splHome.Panel1MinSize + 1;

            // Il pannello destro deve essere almeno il 50% della larghezza totale
            int panel2MinCalcolato = (int)(splHome.Width * 0.50);
            int max = splHome.Width - panel2MinCalcolato - splHome.SplitterWidth - 1;

            // Protezione: se la finestra è troppo piccola blocca tutto
            if (max <= min) return;

            int valore = Math.Max(min, Math.Min(distanza, max));
            if (valore == splHome.SplitterDistance) return;

            _splitterInAggiornamento = true;
            try
            {
                splHome.SplitterDistance = valore;
            }
            catch (InvalidOperationException) { }
            finally
            {
                _splitterInAggiornamento = false;
            }

            AggiornaSidebar();
        }

        private void AggiornaSidebar()
        {
            bool compatto = splHome.SplitterDistance < (_menuFullWidth * 0.40);

            lblNominativo.Visible = !compatto;
            lblEmail.Visible = !compatto;
            btLogout.Visible = !compatto;
            pbFotoProfilo.Visible = !compatto;
            foreach (var kvp in _vociMenu)
            {
                Button b = kvp.Key;
                b.Text = compatto ? kvp.Value.icona : kvp.Value.testo;
                b.TextAlign = compatto
                    ? ContentAlignment.MiddleCenter
                    : ContentAlignment.MiddleLeft;
                b.Padding = compatto
                    ? new Padding(0)
                    : new Padding(10, 0, 0, 0);
            }
        }
        #endregion

        private void pnlDecDiscipline_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
