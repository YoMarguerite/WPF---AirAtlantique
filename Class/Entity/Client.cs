using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    class Client : Utilisateur
    {
        private int fidelite;

        public Client(int _id, string _nom, string _prenom, string _mail, string _civilite, bool _type, int _fidelite) : base( _id, _nom, _prenom, _mail, _civilite, _type )
        {
            this.fidelite = _fidelite;
        }

        public Client() { }

        public int Fidelite
        {
            get { return fidelite; }
            set { fidelite = value; }
        }
    }
}
