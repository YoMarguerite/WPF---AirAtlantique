using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Entity
{
    class Tarif
    {
        private int id;
        private Classe classe;
        private string nom;


        public Tarif(int _id, Classe _classe, string _nom)
        {
            this.id = _id;
            this.classe = _classe;
            this.nom = _nom;
        }


        public Tarif() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public Classe Classe
        {
            get { return classe; }
            set { classe = value; }
        }


        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}
