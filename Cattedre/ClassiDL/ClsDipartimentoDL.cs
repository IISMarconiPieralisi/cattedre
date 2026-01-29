using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsDipartimentoDL
    {
        #region ATTRIBUTI
        long _id;
        string _nome, _nomeCoordinatore;
        long _idUtente;
        #endregion

        #region COSTRUTTORE
        public ClsDipartimentoDL(string nome)
        {
            Nome = nome;
        }
        public ClsDipartimentoDL(long id, string nome, long idUtente)
        {
            ID = id;
            Nome = nome;
            IDutente = idUtente;
        }

        public ClsDipartimentoDL()
        {

        }
        #endregion

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public long IDutente { get => _idUtente; set => _idUtente = value; }
        public string NomeCoordinatore { get => _nomeCoordinatore; set => _nomeCoordinatore = value; }
        #endregion
    }
}
