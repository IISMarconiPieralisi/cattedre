using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsDotareDL
    {
        #region attributi
        long _id;
        long _idAnnoscolastico;
        long _idClasseDiConcorso;
        int _NumcattedreFatto;
        int _NumcattedreDiritto;
        #endregion
        #region costruttore
        public ClsDotareDL(long idClasseDiConcorso)
        {
            IdClasseDiConcorso = idClasseDiConcorso;
        }
        public ClsDotareDL(long idClasseDiConcorso, long idAnnoscolastico)
        {
            IdClasseDiConcorso = idClasseDiConcorso;
            IdAnnoscolastico = idAnnoscolastico;
        }
        public ClsDotareDL()
        {

        }


        #endregion
        #region proprietà
        public long IdAnnoscolastico { get => _idAnnoscolastico; set => _idAnnoscolastico = value; }
        public int NumcattedreDiritto { get => _NumcattedreDiritto; set => _NumcattedreDiritto = value; }
        public long IdClasseDiConcorso { get => _idClasseDiConcorso; set => _idClasseDiConcorso = value; }
        public long Id { get => _id; set => _id = value; }
        public int NumcattedreFatto { get => _NumcattedreFatto; set => _NumcattedreFatto = value; }
        #endregion
    }
}
