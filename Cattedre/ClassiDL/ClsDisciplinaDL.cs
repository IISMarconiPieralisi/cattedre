using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsDisciplinaDL
    {
        #region ATTRIBUTI
        int _id;
        string _nome, _disciplinaSpeciale;
        int _oreTeoria, _oreLaboratorio, _anno;
        #endregion

        #region COSTRUTTORE
        public ClsDisciplinaDL(string nome)
        {
            _nome = nome;
        }

        public ClsDisciplinaDL()
        {

        }
        #endregion

        #region PROPRIETA
        public int ID { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string DisciplinaSpeciale { get => _disciplinaSpeciale; set => _disciplinaSpeciale = value; }
        public int OreTeoria { get => _oreTeoria; set => _oreTeoria = value; }
        public int OreLaboratorio { get => _oreLaboratorio; set => _oreLaboratorio = value; }
        public int Anno { get => _anno; set => _anno = value; }
        #endregion
    }
}
