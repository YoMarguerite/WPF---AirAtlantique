using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    public class Employe : Utilisateur
    {
        private string poste;
        
        public Employe() { }

        public Employe(int _id, string _nom, string _prenom, string _mail, string _mdp, bool _civilite, string _poste ) : base( _id, _nom, _prenom, _mdp, _mail, _civilite)
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
