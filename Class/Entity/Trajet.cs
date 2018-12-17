using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Entity
{
    class Trajet
    {
        private int id;
        private string duree;
        private float kilometre;
        private Aeroport depart;
        private Aeroport arrivee;
        private string aeroport_str;

        public Trajet(int _id, string _duree, float _kilometre, Aeroport _depart, Aeroport _arrivee)
        {
            this.id = _id;
            this.duree = _duree;
            this.kilometre = _kilometre;
            this.depart = _depart;
            this.arrivee = _arrivee;
            this.aeroport_str = depart.AITA + " - " + arrivee.AITA;
        }

        public Trajet() { }
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Duree
        {
            get { return duree; }
            set { duree = value; }
        }

        public float Kilometre
        {
            get { return kilometre; }
            set { kilometre = value; }
        }

        public Aeroport Depart
        {
            get { return depart; }
            set { depart = value; }
        }

        public Aeroport Arrivee
        {
            get { return arrivee; }
            set { arrivee = value; }
        }

        public string Aeroport_Str
        {
            get { return aeroport_str; }
        }
    }
}
