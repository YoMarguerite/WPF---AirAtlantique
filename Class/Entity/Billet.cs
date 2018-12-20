using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Entity
{
    class Billet
    {
        private int id;
        private List<Classe> list_class;
        private string class_str;
        private List<Tarif> list_tarif;
        private string tarif_str;
        private Vol vol;
        private Client client;


        public Billet( int _id, List<Classe> _classe, List<Tarif> _tarif,  Vol _vol, Client _client)
        {
            this.id = _id;
            this.list_class = _classe;
            this.list_tarif = _tarif;
            this.vol = _vol;
            this.client = _client;

            this.class_str = list_class[0].Nom;
            this.tarif_str = list_tarif[0].Nom;
        }


        public Billet() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public List<Tarif> Tarifs
        {
            get { return list_tarif; }
            set { list_tarif = value; }
        }


        public string Tarif_Str
        {
            get { return tarif_str; }
            set { tarif_str = value; }
        }


        public List<Classe> Classes
        {
            get { return list_class; }
            set { list_class = value; }
        }


        public string Classe_Str
        {
            get { return class_str; }
            set { class_str = value; }
        }


        public Vol Vol
        {
            get { return vol; }
            set { vol = value; }
        }


        public Client Client
        {
            get { return client; }
            set { client = value; }
        }


        public List<string> Prix(int idClasse)
        {
            List<string> prix = new List<string>();
            

            foreach (Tarif tarif in list_tarif)
            {
                if(tarif.Classe.Id == idClasse)
                {
                    foreach(double[] vol_prix in vol.Tarifs)
                    {
                        if((int)vol_prix[0] == tarif.Id)
                        {
                            prix.Add(tarif.Nom + " - " + vol_prix[1]);
                        }
                    }
                }
            }
            return prix;
        }
    }
}
