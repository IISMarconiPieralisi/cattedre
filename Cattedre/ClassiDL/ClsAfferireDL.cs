using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
   public class ClsAfferireDL
    {
        #region attributi
        long _ID;
        long _idUtente;
        long _idDipartimento;
        #endregion
        #region costruttore
        public ClsAfferireDL(long idDipartimento)
        {
            IDdipartimento = idDipartimento;
        }
        public ClsAfferireDL(long idDipartimento, long idUtente)
        {
            IDdipartimento = idDipartimento;
            IDutente = idUtente;
        }
        #endregion
        #region proprietà
        public long IDutente 
        { 
            get => _idUtente; 
            set => _idUtente = value; 
        }
        public long IDdipartimento { get => _idDipartimento; set => _idDipartimento = value; }
        public long ID { get => _ID; set => _ID = value; }
        #endregion

    }
}
