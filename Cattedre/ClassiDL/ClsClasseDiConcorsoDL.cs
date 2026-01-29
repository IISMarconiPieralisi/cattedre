using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cattedre
{
    public class ClsClasseDiConcorsoDL
    {
        #region ATTRIBUTI
        long _id;
        string _livello, _nome, _abilitazioniRichieste;
        #endregion

        #region COSTRUTTORE
        public ClsClasseDiConcorsoDL()
        {

        }
        #endregion

        string formatoLivello = @"\d{2}$";

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }
        
        public string AbilitazioniRichieste { get => _abilitazioniRichieste; set => _abilitazioniRichieste = value; }
        public string Livello
        {
            get
            {
                return _livello;
            }
            set
            {
                //ultima condizione per verificare che il livello finisca con due numeri
                //if (value.StartsWith("A") && value.Length == 3 && Regex.IsMatch(value, formatoLivello))
                _livello = value;
                //else
                //    throw new Exception("Inserire un livello valido --> A(num)(num)");
            }
        }
        #endregion
    }

}
