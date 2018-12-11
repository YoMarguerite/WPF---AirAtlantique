using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    class Utilisateur
    {

        //----------------- Variables ------------------
        private int id;
        private int fidelite;
        private string nom;
        private string prenom;
        private string adresse;
        private string mail;
        private string naissance;

        public Utilisateur(int _id, int _fidelite, string _nom, string _prenom, string _adresse, string _mail, string _naissance)
        {
            this.id = _id;
            this.fidelite = _fidelite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.adresse = _adresse;
            this.mail = _mail;
            this.naissance = _naissance;            
        }

        public Utilisateur() { }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Fidelite
        {
            get { return fidelite; }
            set { fidelite = value; }
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

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Naissance
        {
            get { return naissance; }
            set { naissance = value; }
        }
    }
}
