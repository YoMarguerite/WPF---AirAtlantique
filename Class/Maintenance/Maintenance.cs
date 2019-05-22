using System;
using WpfApp1.Class.Aeroport;
using WpfApp1.Class.Avion;

namespace WpfApp1.Class.Maintenance
{
    class Maintenance
    {
        private int id;
        private string avion;
        private DateTime date;
        private string aeroport;
        private string details;
        private int responsable;
        
        public Maintenance(int _id, int _avion, DateTime _date, int _aeroport, string _details, int _responsable)
        {
            this.id = _id;
            this.avion = DAL_Avion.GetAvion(_avion).Matricule;
            this.date = _date;
            this.aeroport = DAL_Aeroport.GetAeroport(_aeroport).Nom;
            this.details = _details;
            this.responsable = _responsable;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Avion
        {
            get { return avion; }
            set { avion = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Aeroport
        {
            get { return aeroport; }
            set { aeroport = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public int Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
    }
}
