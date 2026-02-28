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


        private ClsUtenteDL utente;
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
            frm.WindowState = FormWindowState.Maximized; // Di default nelle proprietà deve essere a Normal!
            frm.Show();
        }
        private void FrmHomeUpdate_Load(object sender, EventArgs e)
        {
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
                //FrmLogin frmLogin = new FrmLogin();
                //if (ClsUtenteBL.TokenEsistente(utente.ID))
                //    FrmLogin.logout();
                //frmLogin.Show();
                //this.Close();
                if (ClsUtenteBL.TokenEsistente(utente.ID))
                    FrmLogin.logout();

                Application.Restart();
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
                MostraFormMDI(frmUtenti);
            }

        }

       



        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmCredits"] == null)
            {
                FrmCredits frmCredits = new FrmCredits();
                MostraFormMDI(frmCredits);
            }

        }

        //private void cONTRATTIToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmContratti frmContratti = new FrmContratti();
        //    frmContratti.Show();
        //}


    }
}
