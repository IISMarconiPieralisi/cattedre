using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsContrattoDL
    {
        #region ATTRIBUTI
        long _id;
        char _tipoContratto;
        int _monteOre;
        DateTime _dataInizioContratto;
        DateTime? _dataFineContratto;
        long  _idUtente;
        #endregion

        #region COSTRUTTORE
        public ClsContrattoDL()
        {

        }
        #endregion

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public int MonteOre { get => _monteOre; set => _monteOre = value; }

        public char TipoContratto
        {
            get
            {
                return _tipoContratto;
            }
            set
            {
                if (value == 'I' || value == 'D')
                    _tipoContratto = value;
                else
                    throw new Exception("Inserire un valore valido");
            }
        }

        public DateTime DataInizioContratto { get => _dataInizioContratto; set => _dataInizioContratto = value; }
        public DateTime? DataFineContratto { get => _dataFineContratto; set => _dataFineContratto = value; }
        public long  IDutente { get => _idUtente; set => _idUtente = value; }
        #endregion
    }
}
