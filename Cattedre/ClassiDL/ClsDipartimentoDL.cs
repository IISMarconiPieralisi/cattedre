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
        string _nome;
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
        public long ID
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID deve essere maggiore di 0.");
                _id = value;
            }
        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome non può essere nullo o vuoto.");
                _nome = value.Trim();
            }
        }

        public long IDutente
        {
            get => _idUtente;
            set
            {
                if (value < 0)
                    throw new ArgumentException("IDutente non può essere negativo.");
                // può essere 0
                _idUtente = value;
            }
        }
        #endregion
    }
}
