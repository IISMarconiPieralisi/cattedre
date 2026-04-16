using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class UcClasse : UserControl
    {
        public UcClasse(ClsClasseDL clsClasseDL)
        {           
            InitializeComponent();
            lblClasse.Text = clsClasseDL.Sigla;
            string nomeCompleto = ClsUtenteBL.RilevaNomeUtente(clsClasseDL.Idutente);
            lblcoordinatore.Text = AbbreviaNome(nomeCompleto);
        }

        private string AbbreviaNome(string nomeCompleto)
        {
            if (string.IsNullOrWhiteSpace(nomeCompleto))
                return "";

            string[] parti = nomeCompleto.Trim().Split(' ');

            if (parti.Length == 1)
                return parti[0];

            string cognome = parti[0];
            string nome = parti[1];
            string nomeCorto = nome.Length > 3 ? nome.Substring(0, 3) + "." : nome;

            return $"{cognome} {nomeCorto}";
        }
    }
}
