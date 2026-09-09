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
using System.Threading;

namespace Cattedre
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btLogin;
           
        }

        public ClsUtenteDL UtenteLoggato { get; private set; }
        public Image FotoProfilo { get; private set; }
        // cache in memoria: email -> foto Google
        private static Dictionary<string, Image> _cachefoto = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //configurazione grafico in caso la password o utente non rispetta dei parametri
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

                if (ClsUtenteBL.Login(email, password) && (rbDBufficiale.Checked || rbDBprova.Checked))
                {
                    ClsUtenteDL utenteLoggato = null;
                    utenteLoggato = ClsUtenteBL.caricautenteByEmail(email);
                    //cancellazione token all'interno di utente
                    ClsUtenteBL.cancellaTokenUtente(utenteLoggato.ID);
                    //FrmHome frmHome = new FrmHome(utenteLoggato);
                    //frmHome.Show();
                    //this.Hide();
                    FotoProfilo = TrovaFotoProfiloByEmail(email);                
                    // se non l'ha trovata dal token, prova dalla cache
                    if (FotoProfilo == null && _cachefoto.ContainsKey(email))
                        FotoProfilo = _cachefoto[email];
                    UtenteLoggato = utenteLoggato;
                    Program.utenteLoggato = utenteLoggato;
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                    throw new Exception("Email o Password Erratti, \nRiprovare");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "errore", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
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
            try
            {
                if (rbDBprova.Checked || rbDBufficiale.Checked)
                    login();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nRiprovare!", "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Oauth2Service GetService(UserCredential credential)
        {
            try
            {
                if (credential == null)
                    throw new ArgumentNullException("credential");

                // Create Oauth2 API service.
                return new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "helpdesk-win"
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Get Oauth2 service failed.", ex);
            }
        }

        private void login()
        {
            try
            {
                string[] Scopes = { "email", "profile" }; // Informazioni richieste
                UserCredential credential;
                Oauth2Service service;
                credential = GetUserCredential("credentials-cattedre-win.json", "cattedre-win", Scopes);
                service = GetService(credential); // Recupero il servizio
                service.Userinfo.V2.Me.Get().Execute(); // Esecuzione della richiesta con apertura del browser

                //UserinfoResource userinfo = service.Userinfo; // Info ricevute

                if (credential != null)
                {
                    var oauthService = new Google.Apis.Oauth2.v2.Oauth2Service(
                        new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "OAuth 2.0 Sample",
                        });
                    var userinfo = service.Userinfo.Get().Execute();
                    if (userinfo.Email != null && ClsUtenteBL.LoginByemail(userinfo.Email))
                    {
                        ClsUtenteDL utenteLoggato = null;
                        //caricamento del utente prendendo l'email essendo univoca
                        utenteLoggato = ClsUtenteBL.caricautenteByEmail(userinfo.Email);
                        //caricamento del token
                        ClsUtenteBL.InserisciTokenUtente(userinfo.Id, utenteLoggato.ID);
                        //FrmHome frmHome = new FrmHome(utenteLoggato);
                        //frmHome.Show();
                        //this.Hide();
                        if (!string.IsNullOrEmpty(userinfo.Picture))
                        {
                            FotoProfilo = ScaricaFotoProfilo(userinfo.Picture);
                            if (!string.IsNullOrEmpty(userinfo.Picture))
                            {
                                FotoProfilo = ScaricaFotoProfilo(userinfo.Picture);
                                if (FotoProfilo != null)
                                    _cachefoto[userinfo.Email] = FotoProfilo; // salva in cache
                            }
                        }
                           
                        UtenteLoggato = utenteLoggato;
                        Program.utenteLoggato = utenteLoggato;
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                        throw new Exception("Utente, non trovato nel database");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("errore Nel login:\n " + ex.Message);
            }

        }

        private Image ScaricaFotoProfilo(string url)
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    byte[] data = client.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(data))
                        return Image.FromStream(ms);
                }
            }
            catch { return null; }
        }

        private Image TrovaFotoProfiloByEmail(string email)
        {
            try
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

                // se non esiste il token salvato non aprire il browser, restituisci null
                if (!Directory.Exists(credPath) || !Directory.EnumerateFiles(credPath).Any())
                    return null;

                string[] scopes = { "email", "profile" };
                var credential = GetUserCredential("credentials-cattedre-win.json", "cattedre-win", scopes);
                var service = GetService(credential);
                var userinfo = service.Userinfo.Get().Execute();

                if (userinfo.Email?.ToLower() == email.ToLower() && !string.IsNullOrEmpty(userinfo.Picture))
                    return ScaricaFotoProfilo(userinfo.Picture);
            }
            catch { }
            return null;
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
                var credezial = GetUserCredential(clientSecretJson, userName, scopes);

                return GetService(credezial);
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
                    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, scopes,
                                                                          userName,
                                                                          CancellationToken.None,
                                                                          new FileDataStore(credPath, true)).Result;

                    credential.GetAccessTokenForRequestAsync();
                    return credential;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Get user credentials failed.", ex);

            }
        }
        public static void logout()
        {
            string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials"); // Recupero il file dalla cartella documenti dove ho memorizzato l'utente loggato //, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            if (System.IO.Directory.Exists(credPath))
            {
                try
                {
                    Directory.Delete(credPath, true); // Cancello il file con le info dell'utente loggato
                }
                catch (Exception e)
                {
                    MessageBox.Show("The process failed: {0}", e.Message);
                }
            }
            else
                MessageBox.Show("La cartella {0} non esiste", credPath);
        }     

        private void FrmLogin_Load(object sender, EventArgs e)
        {
#if DEBUG
            pnlDebug.Visible = true;
#endif
            rbTest1.Checked = true;
            rbDBufficiale.Checked = true;
        }

        private void rbTest1_CheckedChanged(object sender, EventArgs e)
        {
#if DEBUG
            if (rbTest1.Checked == true)
            {
                tbNomeUtente.Text = "vittorio.alfieri@iismarconipieralisi.it";
                tbPassword.Text = "vitalf00!";
            }
            else if (rbTest2.Checked == true)
            {
                rbTest1.Checked = false;
                tbNomeUtente.Clear();
                tbPassword.Clear();
                tbNomeUtente.Text = "stefano.bartoloni@iismarconipieralisi.it";
                tbPassword.Text = "Bartoloni";
            }
            else
            {
                rbTest1.Checked = false;
                rbTest2.Checked = false;
                tbNomeUtente.Clear();
                tbPassword.Clear();
                tbNomeUtente.Text = "marcello.pigini@iismarconipieralisi.it";
                tbPassword.Text = "Pigini";
            }
#endif
        }



        private void rbDBufficiale_CheckedChanged(object sender, EventArgs e)
        {
            Program.connectionString = ConfigurationManager.ConnectionStrings["srvcattedre"].ConnectionString;
        }

        private void rbDBprova_CheckedChanged(object sender, EventArgs e)
        {
            Program.connectionString = ConfigurationManager.ConnectionStrings["locale"].ConnectionString;
        }
    }
    
}
