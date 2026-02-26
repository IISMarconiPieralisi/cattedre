using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsAssegnareDL
    {
        #region ATTRIBUTI
        long _id;
        DateTime dal, al;
        int oreSpeciali;
        long idClasse, idAnnoScolastico, idDisciplina, idUtente;
        #endregion

        #region COSTRUTTORE
        public ClsAssegnareDL()
        {

        }
        #endregion

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public DateTime Dal { get => dal; set => dal = value; }
        public DateTime Al { get => al; set => al = value; }
        public int OreSpeciali { get => oreSpeciali; set => oreSpeciali = value; }
        public long IDAnnoScolastico { get => idAnnoScolastico; set => idAnnoScolastico = value; }
        public long IDClasse { get => idClasse; set => idClasse = value; }
        public long IDDisciplina { get => idDisciplina; set => idDisciplina = value; }
        public long IDUtente { get => idUtente; set => idUtente = value; }
        #endregion
    }
}
