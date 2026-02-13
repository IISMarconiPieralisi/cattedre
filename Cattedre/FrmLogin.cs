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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;

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

        private void btLoginGoogle_Click(object sender, EventArgs e)
        {

        }
        private void login()
        {
            string[] Scopes = { "email", "profile" }; // Informazioni richieste
            UserCredential credential;
            Oauth2Service service;
            credential = GetUserCredential("credentials.json", "cattedre-win", Scopes);
            service = GetService(credential); // Recupero il servizio
            service.Userinfo.V2.Me.Get().Execute(); // Esecuzione della richiesta con apertura del browser

            //UserinfoResource userinfo = service.Userinfo; // Info ricevute
            
            if(credential!=null)
            {
                var oauthService = new Google.Apis.Oauth2.v2.Oauth2Service(
                    new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "OAuth 2.0 Sample",
                    });
                var userinfo = service.Userinfo.Get().Execute();
                //login con userinfo.email e token
            }
        }

        private Oauth2Service GetOauth2Service(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    throw new ArgumentNullException("userName");
                if (string.IsNullOrWhiteSpace(clientSecretJson))
                    throw new ArgumentNullException("clientSecretJson");
                if (!File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file non esiste.");
                var credeziali = GetUserCredential(clientSecretJson, userName, scopes);

                return GetService(credeziali);
            }
            catch (Exception ex)
            {
                throw new Exception("Get user credentials failed.", ex);

            }
        }
        private UserCredential GetUserCredential(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    throw new ArgumentNullException("userName");
                if (string.IsNullOrWhiteSpace(clientSecretJson))
                    throw new ArgumentNullException("clientSecretJson");
                if (!File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file non esiste.");
                using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,scopes,
                                                                          userName,
                                                                          CancellationToken.None,
                                                                          new FileDataStore(credPath, true)).Result;

                    credential.GetAccessTokenForRequestAsync();
                    return credential;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Get user credentials failed.", ex);

            }
        }
        private void logout()
        {
            string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials"); // Recupero il file dalla cartella documenti dove ho memorizzato l'utente loggato //, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            if (System.IO.Directory.Exists(credPath))
            {
                try
                {
                    Directory.Delete(credPath, true); // Cancello il file con le info dell'utente loggato
                    MessageBox.Show("Logout effettuato");
                }
                catch (Exception e)
                {
                    MessageBox.Show("The process failed: {0}", e.Message);
                }
            }
            else
                MessageBox.Show("La cartella {0} non esiste", credPath);
        }
    }
}
