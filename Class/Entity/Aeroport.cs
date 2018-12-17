using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Entity
{
    class Aeroport
    {
        private int id;
        private string nom;
        private string ville;
        private string pays;
        private string aita;

        public Aeroport(int _id, string _nom, string _ville, string _pays, string _aita)
        {
            this.id = _id;
            this.nom = _nom;
            this.ville = _ville;
            this.pays = _pays;
            this.aita = _aita;
        }

        public Aeroport() { }
        

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

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        public string Pays
        {
            get { return pays; }
            set { pays = value; }
        }

        public string AITA
        {
            get { return aita; }
            set { aita = value; }
        }
    }
}
