using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    static class Program
    {
        public static List<ClsClasseDL> classi = new List<ClsClasseDL>();
        public static List<ClsClasseDL> Coordinatori = new List<ClsClasseDL>();
        public static List<ClsDipartimentoDL> dipartimenti = new List<ClsDipartimentoDL>();
        public static List<ClsDisciplinaDL> discipline = new List<ClsDisciplinaDL>();

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

           
        }
    }
}
