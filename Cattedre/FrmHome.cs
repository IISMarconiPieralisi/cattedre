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
        private int _menuMinWidth = 50;

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
            else if(utente.TipoUtente =="C")
            {
                menuStrip1.Visible = false;
                btDiscipline.Visible = true;
                btUtenti.Visible = true;
                btClassi.Visible = true;
                btVaiACattedre.Visible = true;
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
                frmUtenti = new FrmUtenti();
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
        private void Panel3_Resize(object sender, EventArgs e)
        {
            CentraControlli();
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
        private void CentraControlli()
        {
            // 5,3,4 le label 
            // Esempio per una Label chiamata 'label1' dentro 'panel1'
            label5.Left = (pnlCentrale.ClientSize.Width - label5.Width) / 2;
            label5.Top = (pnlCentrale.ClientSize.Height - label5.Height) / 2;

            // Esempio per un Bottone 'button1' posizionato sotto la label
            btVaiACattedre2.Left = (pnlCentrale.ClientSize.Width - btVaiACattedre2.Width) / 2;
            btVaiACattedre2.Top = label4.Bottom + 10; // 10 pixel di margine sotto la label
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

            // Blocca il pannello sinistro durante il resize della form
            splHome.FixedPanel = FixedPanel.Panel1;
            splHome.SplitterMoved += new SplitterEventHandler(splHome_SplitterMoved);
            AggiornaSidebar();
        }
        private void splHome_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AggiornaSidebar();
        }
        private void AggiornaSidebar()
        {
            bool compatto = splHome.SplitterDistance <= _menuMinWidth + 10;

            lblNominativo.Visible = !compatto;
            lblEmail.Visible = !compatto;
            btLogout.Visible = !compatto;

            // Gestione pbFotoProfilo: compatto = solo cerchio in cima, espanso = foto grande originale
            if (compatto)
            {
                pbFotoProfilo.Size = new Size(38, 38);
                pbFotoProfilo.Location = new Point((splHome.Panel1.Width - 38) / 2, 8);

                if (_fotoProfilo != null)
                {
                    // Ha la foto — mostrala tonda piccola
                    pbFotoProfilo.Image = _fotoProfilo;
                    pbFotoProfilo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    // Nessuna foto — disegna cerchio con iniziali
                    Bitmap bmp = new Bitmap(38, 38);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.Clear(Color.Transparent);

                        // Cerchio sfondo
                        using (SolidBrush br = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
                            g.FillEllipse(br, 0, 0, 37, 37);

                        // Bordo
                        using (Pen pen = new Pen(Color.FromArgb(120, 255, 255, 255), 1.5f))
                            g.DrawEllipse(pen, 1, 1, 35, 35);

                        // Iniziali
                        string ini = GetIniziali();
                        using (Font f = new Font("Segoe UI", 13f, FontStyle.Bold))
                        using (SolidBrush tb = new SolidBrush(Color.White))
                        {
                            SizeF sz = g.MeasureString(ini, f);
                            g.DrawString(ini, f, tb,
                                (38 - sz.Width) / 2,
                                (38 - sz.Height) / 2);
                        }
                    }
                    pbFotoProfilo.Image = bmp;
                    pbFotoProfilo.SizeMode = PictureBoxSizeMode.Normal;
                }

                // Forma tonda
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, pbFotoProfilo.Width, pbFotoProfilo.Height);
                pbFotoProfilo.Region = new Region(gp);
            }
            else
            {
                // Ripristina dimensioni originali — adatta i valori alla tua UI
                pbFotoProfilo.Size = new Size(60, 60);  // ← metti la size originale
                pbFotoProfilo.Location = new Point(10, 10); // ← metti la location originale
                pbFotoProfilo.SizeMode = PictureBoxSizeMode.Zoom;

                // Ripristina forma tonda con dimensione originale
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, pbFotoProfilo.Width, pbFotoProfilo.Height);
                pbFotoProfilo.Region = new Region(gp);

                if (_fotoProfilo != null)
                    pbFotoProfilo.Image = _fotoProfilo;
            }

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

        private string GetIniziali()
        {
            string nome = utente.Nome ?? "";
            string cognome = utente.Cognome ?? "";
            string ini = "";
            if (nome.Length > 0) ini += nome[0];
            if (cognome.Length > 0) ini += cognome[0];
            return ini.ToUpper();
        }
    
        #endregion

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
    }
}
