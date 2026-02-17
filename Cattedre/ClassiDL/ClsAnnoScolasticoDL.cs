using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cattedre
{
    public class ClsAnnoScolasticoDL
    {
        #region ATTRIBUTI
        long _id;
        string _sigla;
        DateTime _dataInizio, _dataFine;
        #endregion

        #region COSTRUTTORE
        public ClsAnnoScolasticoDL()
        {

        }

        public ClsAnnoScolasticoDL(long id, string sigla, DateTime datainizio, DateTime datafine)
        {
            _id = id;
            _sigla = sigla;
            _dataInizio = datainizio;
            _dataFine = datafine;
        }
        #endregion        

        string formatoSigla = @"^\d{2}-\d{2}$";

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public string Sigla
        {
            
            get
            {
                return _sigla;
            }
            set
            {
                if (value.Length == 5 && Regex.IsMatch(value, formatoSigla))
                    _sigla = value;
                else
                    throw new Exception("Il formato deve essere nn-nn");
            }
        }
        public DateTime DataInizio { get => _dataInizio; set => _dataInizio = value; }
        public DateTime DataFine { get => _dataFine; set => _dataFine = value; }
        #endregion
    }
}
