using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Entity
{
    class Poste
    {
        private string nom;

        public Poste(string _nom)
        {
            this.nom = _nom;
        }

        public Poste() { }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
