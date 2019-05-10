using System.ComponentModel;
using WpfApp1.Class.Ville;

namespace WpfApp1.Class.Aeroport
{
    public class Aeroport : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string ville;
        private string aita;

        public event PropertyChangedEventHandler PropertyChanged;

        public Aeroport(int _id, string _nom, string _aita, int _ville)
        {
            this.id = _id;
            this.nom = _nom;
            this.ville = DAL_Ville.GetVille(_ville).Nom;
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

        public string AITA
        {
            get { return aita; }
            set { aita = value; }
        }
    }
}
