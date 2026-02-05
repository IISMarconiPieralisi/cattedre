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
        FrmCdCs frmCdCs;
        FrmCdC frmCdC;
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
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MdiParent = this;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
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
                pbmp.Visible = false;

            }
            else
            {
                menuStrip1.Visible = false;
                btDiscipline.Visible = false;
                btUtenti.Visible = false;
                btClassi.Visible = false;
                pbmp.Visible = false;
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
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Close();
        }

        private void cDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmCdCs"] == null)
                frmCdCs = new FrmCdCs();
            MostraFormMDI(frmCdCs);
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
                frmDiscipline = new FrmDiscipline();
            MostraFormMDI(frmDiscipline);
        }

        private void cLASSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmClassi"] == null)
                frmClassi = new FrmClassi();
            MostraFormMDI(frmClassi);
        }

        private void uTENTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmUtenti"] == null)
                frmUtenti = new FrmUtenti();
            MostraFormMDI(frmUtenti);
        }

        private void cREDITSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCredits frmCredits = new FrmCredits();
            MostraFormMDI(frmCredits);
        }

        //private void cONTRATTIToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmContratti frmContratti = new FrmContratti();
        //    frmContratti.Show();
        //}


    }
}
