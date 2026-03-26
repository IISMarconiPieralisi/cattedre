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
        FrmCdCs frmCdcs;
        FrmIndirizzi frmIndirizzi;
        FrmDipartimenti frmDipartimenti;
        FrmDiscipline frmDiscipline;
        FrmClassi frmClassi;
        FrmUtenti frmUtenti;
        FrmAnniScolastici FrmAnniScolastici;
        FrmCredits frmCredits;


        private ClsUtenteDL utente;

        public Action OnLogout { get; set; }
        public FrmHome(ClsUtenteDL utenteLoggato)
        {
            InitializeComponent();
            utente = utenteLoggato;
        }

        private void btVaiACattedre_Click(object sender, EventArgs e)
        {
            FrmCattedre frmCattedre = new FrmCattedre(utente);
            frmCattedre.Show();
        }
        private void MostraFormMDI(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent; // Su MDI non serve
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.WindowState = FormWindowState.Maximized;
            frm.Refresh();
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
        }

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
            catch (Exception ex)
            {
                MessageBox.Show("Errore Durante il logout, contattare un amministratore", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCdcs"] == null)
                frmCdcs = new FrmCdCs();
            MostraFormMDI(frmCdcs);
        }

        private void iNDIRIZZIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmIndirizzi"] == null)
                frmIndirizzi = new FrmIndirizzi();
            MostraFormMDI(frmIndirizzi);
        }

        private void dIPARTIMENTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmDipartimenti"] == null)
                frmDipartimenti = new FrmDipartimenti();
            MostraFormMDI(frmDipartimenti);
        }

        private void dISCIPLINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmDiscipline"] == null)
                frmDiscipline = new FrmDiscipline(utente);
            MostraFormMDI(frmDiscipline);
        }

        private void cLASSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmClassi"] == null)
                frmClassi = new FrmClassi(utente);
            MostraFormMDI(frmClassi);
        }

        private void uTENTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmUtenti"] == null)
            {
                frmUtenti = new FrmUtenti();
            }
            MostraFormMDI(frmUtenti);

        }

       



        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmCredits"] == null)
            {
                frmCredits = new FrmCredits();              
            }
            MostraFormMDI(frmCredits);

        }

        private void annoScolasticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmAnniScolastici"] == null)
                FrmAnniScolastici = new FrmAnniScolastici();
                MostraFormMDI(FrmAnniScolastici);
        }

        //private void cONTRATTIToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmContratti frmContratti = new FrmContratti();
        //    frmContratti.Show();
        //}


    }
}
