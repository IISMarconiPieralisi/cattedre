using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Cattedre
{
    static class Program
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["cattedre"].ConnectionString;
        //public static string connectionString = ConfigurationManager.ConnectionStrings["srvcattedre"].ConnectionString;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool logout = false;

            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() != DialogResult.OK)
                return;

            while (true)
            {
                FrmHome frmHome = new FrmHome(frmLogin.UtenteLoggato);
                if (frmLogin.FotoProfilo != null)
                    frmHome.ImpostaFotoProfilo(frmLogin.FotoProfilo);

                frmHome.OnLogout = () => logout = true; // segnale che è stato premuto logout
                Application.Run(frmHome);

                if (!logout)
                    break; // chiuso con la X -> esci dall'app

                logout = false;
                frmLogin = new FrmLogin();
                if (frmLogin.ShowDialog() != DialogResult.OK)
                    break; // ha chiuso il login -> esci dall'app
            }
        }
    }
}
