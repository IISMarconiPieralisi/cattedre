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
        long _id;
        long _idUtente;
        long _idDisciplina;
        long _idClasseDiConcorso;
        int _oreSpeciali;
        #endregion

        #region costruttore
        public ClsRichiedereDL(long id, long idUtente, long idDisciplina, long idClasseDiConcorso, int orespeciali)
        {
            ID = id;
            IDutente = idUtente;
            IDdisciplina = idDisciplina;
            IDclassediconcorso = idClasseDiConcorso;
            OreSpeciali = orespeciali;
        }
        public ClsRichiedereDL()
        {
            IDutente = 0;
            IDdisciplina = 0;
            IDclassediconcorso = 0;
        }
        public ClsRichiedereDL(long idClasseDiConcorso)
        {
            IDclassediconcorso = idClasseDiConcorso;
        }
        public ClsRichiedereDL (long idclasseDiconcorso,long iddisciplina)
        {
            IDclassediconcorso = idclasseDiconcorso;
            IDdisciplina = iddisciplina;
            IDutente = 0;
        }
        #endregion

        #region proprietà
        public long ID { get => _id; set => _id = value; }

        public long IDutente{ get => _idUtente;  set => _idUtente = value; }

        public long IDdisciplina { get => _idDisciplina; set => _idDisciplina = value; }

        public long IDclassediconcorso { get => _idClasseDiConcorso; set => _idClasseDiConcorso = value; }

        public int OreSpeciali { get => _oreSpeciali; set => _oreSpeciali = value; }
        #endregion
    }
}
