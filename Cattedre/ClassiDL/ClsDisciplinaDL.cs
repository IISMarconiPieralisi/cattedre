using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsDisciplinaDL
    {
        #region ATTRIBUTI
        long _id;
        string _nome, _disciplinaSpeciale;
        int _oreTeoria, _oreLaboratorio, _anno;
        long _iddisciplinaSuccessiva;
        #endregion

        #region COSTRUTTORE
        public ClsDisciplinaDL(long id, string nome, int anno, int orelaboratorio, int oreteoria, string disciplinaspeciale)
        {
            _id = id;
            _nome = nome;
            _anno = anno;
            _oreLaboratorio = orelaboratorio;
            _oreTeoria = oreteoria;
            _disciplinaSpeciale = disciplinaspeciale;
        }

        public ClsDisciplinaDL()
        {

        }
        #endregion

        #region PROPRIETA
        public long ID
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID deve essere maggiore di zero.");
                _id = value;
            }
        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome non può essere vuoto.");
                _nome = value;
            }
        }

        public string DisciplinaSpeciale
        {
            get => _disciplinaSpeciale;
            set
            {
                _disciplinaSpeciale = value;
            }
        }

        public int OreTeoria
        {
            get => _oreTeoria;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ore Teoria non possono essere negative.");
                _oreTeoria = value;
            }
        }

        public int OreLaboratorio
        {
            get => _oreLaboratorio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ore Laboratorio non possono essere negative.");
                _oreLaboratorio = value;
            }
        }

        public int Anno
        {
            get => _anno;
            set
            {
                if (value > 5)
                    throw new ArgumentException("Anno deve essere maggiore di zero.");
                _anno = value;
            }
        }

        public long IDdisciplinaSuccessiva
        { get => _iddisciplinaSuccessiva; set => _iddisciplinaSuccessiva = value; }
        #endregion
    }
}
