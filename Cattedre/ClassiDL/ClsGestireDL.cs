using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsGestireDL
    {
        #region attributi
        long _iddipartimento, _iddisciplina;

        public ClsGestireDL()
        {
        }
        public ClsGestireDL(long iddipartimento, long iddisciplina)
        {
            IDdipartimento = iddipartimento;
            IDdisciplina = iddisciplina;
        }
        #endregion
        #region costruttore

        #endregion
        #region proprietà
        public long IDdipartimento
        {
            get => _iddipartimento;
            set
            {
                if (value <= 0)
                    throw new Exception("non è stata trovato un dipartimento associato");
                _iddipartimento = value;
            }
        }
        public long IDdisciplina { get => _iddisciplina; set => _iddisciplina = value; }
        #endregion
    }
}
