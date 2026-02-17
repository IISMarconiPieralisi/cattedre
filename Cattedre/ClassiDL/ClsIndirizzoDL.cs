using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsIndirizzoDL
    {
        #region ATTRIBUTI
        long _id;
        string _nome;
        #endregion

        #region COSTRUTTORE
        public ClsIndirizzoDL()
        {

        }
        #endregion

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        #endregion
    }
}
