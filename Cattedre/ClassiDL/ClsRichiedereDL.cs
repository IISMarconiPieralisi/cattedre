using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
     public class ClsRichiedereDL
    {
        #region attributi
        long _idUtente;
        long _idDisciplina;
        long _idClasseDiConcorso;
        #endregion

        #region costruttore
        public ClsRichiedereDL(long idUtente, long idDisciplina, long idClasseDiConcorso)
        {
            IDutente = idUtente;
            IDdisciplina = idDisciplina;
            IDclassediconcorso = idClasseDiConcorso;
        }
        public ClsRichiedereDL()
        {

        }
        public ClsRichiedereDL(long idClasseDiConcorso)
        {
            IDclassediconcorso = idClasseDiConcorso;
        }
        #endregion

        #region proprietà
        public long IDutente{ get => _idUtente;  set => _idUtente = value; }

        public long IDdisciplina { get => _idDisciplina; set => _idDisciplina = value; }

        public long IDclassediconcorso { get => _idClasseDiConcorso; set => _idClasseDiConcorso = value; }
        #endregion
    }
}
