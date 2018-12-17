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
        private string avion;
        private string aeroport;

        public Maintenance(int _id, string _date, string _details, Avion _avion, Aeroport _aeroport)
        {
            this.id = _id;
            this.date = _date;
            this.details = _details;
            this.avion = _avion.Matricule;
            this.aeroport = _aeroport.AITA;
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

        public string Avion
        {
            get { return avion; }
            set { avion = value; }
        }

        public string Aeroport
        {
            get { return aeroport; }
            set { aeroport = value; }
        }
    }
}
