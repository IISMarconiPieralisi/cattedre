using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
     public class ClsVigereDL
    {
        #region ATTRIBUTI
        long _iddisciplina;
        long _idannoinizio, _idannofine;
        #endregion

        #region COSTRUTTORE
        public ClsVigereDL()
        {

        }

        public ClsVigereDL(long iddisciplina, long idannoinizio, long idannofine)
        {
            IDdisciplina = iddisciplina;
            IDannoInizio = idannoinizio;
            IDannoFine = idannofine;
        }


        #endregion
        #region PROPRIETA    
        public long IDdisciplina
        {
            get => _iddisciplina;
            set
            {
                if (value <= 0)
                    throw new Exception("IDdisciplina di Vigere non può essere minore uguale a 0");
                _iddisciplina = value;
            }
        }

        public long IDannoInizio
        {
            get => _idannoinizio;
            set
            {
                if (value <= 0)
                    throw new Exception("IDannoInizio di Vigere non può essere minore uguale a 0");
                _idannoinizio = value;
            }
        }

        public long IDannoFine { get => _idannofine; set => _idannofine = value; }
        #endregion
    }
}
