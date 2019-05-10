using System;
using WpfApp1.Class.Avion;
using WpfApp1.Class.Trajet;

namespace WpfApp1.Class.Vol
{
    class Vol
    {
        private int id;
        private int trajet;
        private string strtrajet;
        private DateTime depart;
        private DateTime arrivee;
        private string avion;


        public Vol(int _id, int _trajet, int _avion, DateTime _depart, DateTime _arrivee)
        {
            this.id = _id;
            this.trajet = _trajet;
            this.strtrajet = DAL_Trajet.GetTrajet(_trajet).Depart + " - " + DAL_Trajet.GetTrajet(_trajet).Arrivee;
            this.depart = _depart;
            this.arrivee = _arrivee;
            this.avion = DAL_Avion.GetAvion(_avion).Matricule;
        }


        public Vol() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public int Trajet
        {
            get { return trajet; }
            set { trajet = value; }
        }

        public string StrTrajet
        {
            get { return strtrajet; }
            set { strtrajet = value; }
        }


        public DateTime Depart
        {
            get { return depart; }
            set { depart = value; }
        }


        public DateTime Arrivee
        {
            get { return arrivee; }
            set { arrivee = value; }
        }


        public string Avion
        {
            get { return avion; }
            set { avion = value; }
        }    
    }
}
