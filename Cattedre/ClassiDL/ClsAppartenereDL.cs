using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
   public class ClsAppartenereDL
    {
        #region attributi
        private long  _idindirizzo;
        private long _iddisciplina;
        #endregion
        #region costruttori
        public ClsAppartenereDL()
        {

        }

        public ClsAppartenereDL(long idindirizzo, long iddisciplina)
        {
            _idindirizzo = idindirizzo;
            _iddisciplina = iddisciplina;
        }
        public ClsAppartenereDL(long idindirizzo)
        {
            _idindirizzo = idindirizzo;
        }


        #endregion
        #region proprietà


        public long IDindirizzo
        {
            get => _idindirizzo;
            set
            {
                if (value > 0)
                    _idindirizzo = value;
                else
                    throw new Exception("la chiave all'interno di IDindirizzo non può essere 0");
            }
        }
        public long IDdisicplina
        {
            get => _iddisciplina;
            set
            {
                if (value > 0)
                    _iddisciplina = value;
                else
                    throw new Exception("la chiave all'interno di IDindirizzo non può essere 0");
            }
        }
        #endregion

    }
}
