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
        long _id, _idutente, _idindirizzo;
        string _sigla, _sezione,  _nomeCoordinatore, _indirizzo;
        int _anno, _classeArticolataCon;
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
            _idutente = idutente;
            _idindirizzo = idindirizzo;

        }
        #endregion

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }

        public string Sigla { get => _sigla; set => _sigla = value; }

        public string Sezione { get => _sezione; set => _sezione = value; }

        public string ClasseArticolataCon { get => _classeArticolataCon; set => _classeArticolataCon = value; }

        public int Anno { get => _anno; set => _anno = value; }

        public string NomeCoordinatore { get => _nomeCoordinatore; set => _nomeCoordinatore = value; }
        public string Indirizzo { get => _indirizzo; set => _indirizzo = value; }

        #endregion
    }
}