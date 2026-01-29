using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btLogin;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            lblInserisciNomeUtente.Visible = false;
            lblInserisciPassword.Visible = false;
            tbNomeUtente.BackColor = Color.White;
            tbPassword.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(tbNomeUtente.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                if (string.IsNullOrWhiteSpace(tbNomeUtente.Text))
                {
                    lblInserisciNomeUtente.Visible = true;
                    tbNomeUtente.BackColor = Color.FromArgb(255, 192, 192);
                }

                if (string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    lblInserisciPassword.Visible = true;
                    tbPassword.BackColor = Color.FromArgb(255, 192, 192);
                }

                return;
            }

            string email = tbNomeUtente.Text.Trim();
            string password = tbPassword.Text.Trim();
            try
            {
                if (ClsUtenteBL.Login(email, password))
                {
                    ClsUtenteDL utenteLoggato = null;
                    utenteLoggato = ClsUtenteBL.caricautente(email);
                    FrmHome frmHome = new FrmHome(utenteLoggato);
                    frmHome.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Email o password errati!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il login: " + ex.Message);
                return;
            }

        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.White;
            lblInserisciPassword.Visible = false;
        }

        private void tbNomeUtente_Click(object sender, EventArgs e)
        {
            tbNomeUtente.BackColor = Color.White;
            lblInserisciNomeUtente.Visible = false;
        }
    }
}
