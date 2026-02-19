using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre.ClassiDL
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
            IdDipartimento = idDipartimento;
        }
        public ClsDotareDL(long idDipartimento, long idAnnoscolastico)
        {
            IdDipartimento = idDipartimento;
            IdAnnoscolastico = idAnnoscolastico;
        }


        #endregion
        #region proprietà
        public long IdAnnoscolastico { get => _idAnnoscolastico; set => _idAnnoscolastico = value; }
        public long IdDipartimento { get => _idDipartimento; set => _idDipartimento = value; }
        public long Numcattedrefatto { get => _Numcattedrefatto; set => _Numcattedrefatto = value; }
        public long NumcattedreDiritto { get => _NumcattedreDiritto; set => _NumcattedreDiritto = value; }
        #endregion
    }
}
