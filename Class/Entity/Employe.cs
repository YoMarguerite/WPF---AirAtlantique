using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    class Employe : Utilisateur
    {
        private string poste;
        
        public Employe() { }

        public Employe(int _id, string _nom, string _prenom, string _mail, string _civilite, bool _type,
            string _poste ) : base( _id, _nom, _prenom, _mail, _civilite, _type)
        {
            this.poste = _poste;
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

    }
}
