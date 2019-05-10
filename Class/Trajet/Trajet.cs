using WpfApp1.Class.Aeroport;

namespace WpfApp1.Class.Trajet
{
    class Trajet
    {
        private int id;
        private string duree;
        private string reference;
        private float distance;
        private string depart;
        private string arrivee;

        public Trajet(int _id, int _depart, int _arrivee, string _duree, float _distance, string _reference)
        {
            this.id = _id;
            this.duree = _duree;
            this.reference = _reference;
            this.distance = _distance;
            this.depart = DAL_Aeroport.GetAeroport(_depart).Nom;
            this.arrivee = DAL_Aeroport.GetAeroport(_arrivee).Nom;
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

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        public float Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }

        public string Arrivee
        {
            get { return arrivee; }
            set { arrivee = value; }
        }
    }
}
