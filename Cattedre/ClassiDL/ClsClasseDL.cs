using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // Libreria per Regex

namespace Cattedre
{
    public class ClsClasseDL
    {
        #region ATTRIBUTI
        long _id, _idutente, _idindirizzo, _classeArticolataCon;
        string _sigla, _sezione;
        int _anno;
        #endregion

        #region COSTRUTTORI
        public ClsClasseDL()
        {

        }

        public ClsClasseDL(long id, string sigla, int anno, string sezione, int classearticolatacon, long idutente, long idindirizzo)
        {
            _id = id;
            _sigla = sigla;
            _anno = anno;
            _sezione = sezione;
            _classeArticolataCon = classearticolatacon;
            Idutente = idutente;
            Idindirizzo = idindirizzo;

        }
        #endregion

        #region PROPRIETA


        public long ID
        {
            get => _id;
            set => _id = value >= 0 ? value : throw new ArgumentException("L'ID non può essere negativo.");
        }

        public string Sigla
        {
            get => _sigla;
            set => _sigla = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("La sigla non può essere vuota.");
        }

        public string Sezione
        {
            get => _sezione;
            set => _sezione = (value?.Length > 0) ? value.ToUpper() : throw new ArgumentException("La sezione deve essere indicata.");
        }

        public long ClasseArticolataCon
        {
            get => _classeArticolataCon;
            // Se è 0 o -1, lo consideriamo come "nessuna articolazione" (NULL nel DB)
            set => _classeArticolataCon = value;
        }

        public int Anno
        {
            get => _anno;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException("L'anno scolastico deve essere compreso tra 1 e 5.");
                _anno = value;
            }
        }

        public long Idutente
        {
            get => _idutente;
            set => _idutente = value > 0 ? value : throw new ArgumentException("ID Utente non valido.");
        }

        public long Idindirizzo
        {
            get => _idindirizzo;
            set => _idindirizzo = value > 0 ? value : throw new ArgumentException("ID Indirizzo non valido.");
        }

        #endregion
    }
}