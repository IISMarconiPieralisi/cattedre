using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ClsUtenteDL utente = null;

            using (FrmLogin frmLogin = new FrmLogin())
            {
                var result = frmLogin.ShowDialog();

                if (result == DialogResult.OK)
                {
                    utente = frmLogin.UtenteLoggato;
                }
                else
                {
                    return; // chiude l'app
                }
            }

            Application.Run(new FrmHome(utente));


        }
    }
}
