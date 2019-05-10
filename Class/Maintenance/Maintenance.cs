using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Class.Entity
{
    class Maintenance
    {
        private int id;
        private string date;
        private string details;
        private int avion;
        private int aeroport;
        private int responsable;

        public Maintenance(int _id, string _date, string _details, int _avion, int _aeroport, int _responsable)
        {
            this.id = _id;
            this.date = _date;
            this.details = _details;
            this.avion = _avion;
            this.aeroport = _aeroport;
            this.responsable = _responsable;
        }

        public Maintenance() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public int Avion
        {
            get { return avion; }
            set { avion = value; }
        }

        public int Aeroport
        {
            get { return aeroport; }
            set { aeroport = value; }
        }

        public int Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
    }
}
