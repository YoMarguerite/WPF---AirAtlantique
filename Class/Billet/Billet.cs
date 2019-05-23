using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Classe;
using WpfApp1.Class.Tarif;
using WpfApp1.Class.TarifVol;
using WpfApp1.Class.Vol;

namespace WpfApp1.Class.Billet
{
    class Billet
    {
        private int id;
        private int client;

        private string classe;
        private string tarif;
        private float prix;

        private string trajet;
        private DateTime depart;
        private DateTime arrivee;

        private DateTime date;


        public Billet( int _id, int _client, int _vol, DateTime _date)
        {
            this.id = _id;
            this.client = _client;

            Tarif.Tarif t = DAL_Tarif.GetTarif(DAL_TarifVol.GetTarifVol(_vol).Tarif);
            this.classe = DAL_Classe.GetClasse(t.Classe).Nom;
            this.tarif = t.Nom;
            this.prix = DAL_TarifVol.GetTarifVol(_vol).Prix;

            Vol.Vol vol = DAL_Vol.GetVol(DAL_TarifVol.GetTarifVol(_vol).Vol);
            this.trajet = vol.StrTrajet;
            this.depart = vol.Depart;
            this.arrivee = vol.Arrivee;

            this.date = _date;
        }


        public Billet() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public int Client
        {
            get { return client; }
            set { client = value; }
        }
        
        public string Classe
        {
            get { return classe; }
            set { classe = value; }
        }

        public string Tarif
        {
            get { return tarif; }
            set { tarif = value; }
        }

        public float Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public string Trajet
        {
            get { return trajet; }
            set { trajet = value; }
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

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
