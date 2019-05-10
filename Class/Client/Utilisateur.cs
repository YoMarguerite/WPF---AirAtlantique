using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    public class Utilisateur
    {

        //----------------- Variables ------------------

        private int id;
        private string nom;
        private string prenom;
        private string mail;
        private string mdp;
        private string civilite;

        public Utilisateur(int _id, string _nom, string _prenom, string _mail, string _mdp, bool _civilite)
        {
            this.id = _id;
            this.nom = _nom;
            this.prenom = _prenom;
            this.mail = _mail;
            this.mdp = _mdp;
            this.civilite = BoolExtensions.CiviliteBool(_civilite);
        }

        public Utilisateur() { }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }

        public string Civilite {
            get { return civilite; }
            set { civilite = value; }
        }
    }
}
