using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    // Utilizzata su FrmCredits
    class ClsPersona
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public HashSet<string> FormsFatte { get; set; }

        public ClsPersona(string cognome, string nome, IEnumerable<string> formsFatte)
        {
            Cognome = cognome;
            Nome = nome;
            FormsFatte = new HashSet<string>(formsFatte);
        }

    }
}
