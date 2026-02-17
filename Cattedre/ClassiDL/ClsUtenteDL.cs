using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cattedre
{
    public class ClsUtenteDL
    {
        #region ATTRIBUTI
        long _id;
        string _email, _cognome, _nome;
        string _password;
        string _colore;
        string _tipoUtente;
        char _tipoDocente;
        #endregion

        #region COSTRUTTORE
        public ClsUtenteDL( string email, string password, string cognome,  string nome, string tipoUtente, char tipoDocente)
        {
            ID = GeneraID();
            Email = email;
            Password = password;
            Cognome = cognome;
            Nome = nome;
            TipoUtente = tipoUtente;
            TipoDocente = tipoDocente;
        }
        public ClsUtenteDL()
        {

        }
        #endregion

        #region PROPRIETA
        public long ID { get => _id; set => _id = value; }
        public string Email 
        { 
            get => _email;
            set 
            {
                if (!string.IsNullOrEmpty(value) && value.Contains("@") && value.Contains("."))
                    _email = value;
                else
                    throw new Exception("Inserire una Email Valida");
            }
        }
        public string Password 
        {
            get => _password;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _password = value;
                else
                    throw new Exception("Inserire una Password Valida");

            }
        }
        public string Cognome 
        {
            get => _cognome;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _cognome = value;
                else
                    throw new Exception("Inserire un Cognome Valido");
            }
        }
        public string Nome 
        {
            get => _nome; 
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                    _nome = value;
                else
                    throw new Exception("Inserire un Nome Valido");
            }
        }
        public string TipoUtente 
        {
            get => _tipoUtente; 
            set => _tipoUtente = value; 
        }
        public char TipoDocente { get => _tipoDocente; set => _tipoDocente = value; }
        public string Colore { get => _colore; set => _colore = value; }

        //public char TipoUtente
        //{
        //    get
        //    {
        //        return _tipoUtente;
        //    }
        //    set
        //    {
        //        if (_tipoUtente == 'D' || _tipoUtente == 'P' || _tipoUtente == 'A' || _tipoUtente == 'C')
        //            _tipoUtente = value;
        //        else
        //            throw new Exception("Seleziona un tipo di utente valido");

        //    }
        //}

        //public char TipoDocente
        //{
        //    get
        //    {
        //        return _tipoDocente;
        //    }
        //    set
        //    {
        //        if (_tipoDocente == 'T' || _tipoUtente == 'L')
        //            _tipoDocente = value;
        //        else
        //            throw new Exception("Seleziona un tipo di docente valido");
        //    }
        //}

        //public string Password
        //{
        //    get => _password; 
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value) && VerificaPassword(value))
        //            Password = value;
        //        else
        //            throw new Exception("Inserire una Password Valida");
        //    }
        //}

        private bool VerificaPassword(string Password)
        {
            string[] Simboli = { "+", "-", " *", "/", "%", "=", "<", ">", ".", ",", ";","@","!","?","_","#" };
            string[] Numeri = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (Simboli.Any(p => Password.Contains(p)) && Numeri.Any(p => Password.Contains(p)) && Password.Length >= 8 && Password.Any(char.IsLower))
            {
                return true;
            }
            else
                return false;
        }
         private int GeneraID()
        {
            string guid = Guid.NewGuid().ToString("N");
            string IdString = new string(guid.Where(c => c >= '0' && c <= '9').ToArray());
            if (IdString.Length < 8) //se l'id risulta minore di 8 faccio ricorsivamente il codice finche non ottengo un codice valido
                return GeneraID();
            else
                return int.Parse(IdString.Substring(0, 8));
        }
        #endregion

    }
}
