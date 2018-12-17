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
        private string nom;
        private string prenom;
        private string mail;
        private string civilite;
        private bool type;

        public Utilisateur(int _id, string _nom, string _prenom, string _mail, string _civilite, bool _type)
        {
            this.id = _id;
            this.nom = _nom;
            this.prenom = _prenom;
            this.mail = _mail;
            this.civilite = _civilite;
            this.type = _type;
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

        public string Civilite {
            get { return civilite; }
            set { civilite = value; }
        }

        public bool Type
        {
            get { return type; }
            set { type = value; }
        }

        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}
