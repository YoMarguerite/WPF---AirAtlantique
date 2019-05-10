using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Avion
{
    class Avion
    {

        //----------------- Variables ------------------
        private int id;
        private string matricule;
        private string moteur;
        private float kilometre;
        private string modele;
        private string type;
        private int passager;


        public Avion(int _id, string _matricule, string _moteur, float _kilometre, string _modele, string _type, int _passager)
        {
            this.id = _id;
            this.matricule = _matricule;
            this.moteur = _moteur;
            this.kilometre = _kilometre;
            this.modele = _modele;
            this.type = _type;
            this.passager = _passager;
        }

        public Avion() {  }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Matricule
        {
            get { return matricule; }
            set { matricule = value; }
        }


        public string Moteur
        {
            get { return moteur; }
            set { moteur = value; }
        }


        public float Kilometre
        {
            get { return kilometre; }
            set { kilometre = value; }
        }


        public string Modele
        {
            get { return modele; }
            set { modele = value; }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public int Passager
        {
            get { return passager; }
            set { passager = value; }
        }


    }
}
