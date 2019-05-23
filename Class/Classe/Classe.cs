using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Classe
{
    class Classe
    {
        private int id;
        private string nom;


        public Classe(int _id, string _nom)
        {
            this.id = _id;
            this.nom = _nom;
        }


        public Classe() { }


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
    }
}
