using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Class.Entity
{
    class Vol
    {
        private int id;
        //private Trajet trajet;
        private string trajet_str;
        private string depart;
        private string arrivee;
        private string avion;
        private List<double[]> prix;


        public Vol(int _id, Trajet _trajet, string _depart, string _arrivee, Avion _avion, List<double[]> _prix)
        {
            this.id = _id;
            this.trajet_str = _trajet.Depart.AITA + " - " + _trajet.Arrivee.AITA;
            this.depart = _depart;
            this.arrivee = _arrivee;
            this.avion = _avion.Matricule;
            this.prix = _prix;
        }


        public Vol() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Trajet_Str
        {
            get { return trajet_str; }
            set { trajet_str = value; }
        }


        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }


        public string Arrive
        {
            get { return arrivee; }
            set { arrivee = value; }
        }


        public string Avion
        {
            get { return avion; }
            set { avion = value; }
        }        


        public List<double[]> Tarifs
        {
            get { return prix; }
        }
    }
}
