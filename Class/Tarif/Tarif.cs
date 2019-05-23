namespace WpfApp1.Class.Tarif
{
    class Tarif
    {
        private int id;
        private int classe;
        private string nom;


        public Tarif(int _id, int _classe, string _nom)
        {
            this.id = _id;
            this.classe = _classe;
            this.nom = _nom;
        }


        public Tarif() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public int Classe
        {
            get { return classe; }
            set { classe = value; }
        }


        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}
