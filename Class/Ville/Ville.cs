using System.ComponentModel;


namespace WpfApp1.Class.Ville
{
    public class Ville : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string pays;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ville(int _id, string _nom, string _pays)
        {
            this.id = _id;
            this.nom = _nom;
            this.pays = _pays;
        }

        public Ville() { }

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

        public string Pays
        {
            get { return pays; }
            set { pays = value; }
        }
    }
}
