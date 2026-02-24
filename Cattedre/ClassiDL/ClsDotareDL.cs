using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    class ClsDotareDL
    {
        #region attributi
        long _idAnnoscolastico;
        long _idDipartimento;
        long _Numcattedrefatto;
        long _NumcattedreDiritto;
        #endregion
        #region costruttore
        public ClsDotareDL(long idDipartimento)
        {
            IDdipartimento = idDipartimento;
        }
        public ClsDotareDL(long idDipartimento, long idAnnoscolastico)
        {
            IDdipartimento = idDipartimento;
            IDannoscolastico = idAnnoscolastico;
        }

        public ClsDotareDL()
        {

        }


        #endregion
        #region proprietà
        public long IDannoscolastico { get => _idAnnoscolastico; set => _idAnnoscolastico = value; }
        public long IDdipartimento { get => _idDipartimento; set => _idDipartimento = value; }
        public long NumCattedreFatto { get => _Numcattedrefatto; set => _Numcattedrefatto = value; }
        public long NumCattedreDiritto { get => _NumcattedreDiritto; set => _NumcattedreDiritto = value; }
        #endregion
    }
}
