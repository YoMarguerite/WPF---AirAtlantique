using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Trajet
    {
        private DAO_Trajet bdd_trajet = new DAO_Trajet();
        private List<Trajet> trajets = new List<Trajet>();


        public CTRL_Trajet(CTRL_Aeroport aeroports)
        {
            List<string[]> list_trajets = bdd_trajet.SelectTrajets();
            Trajet trajet;

            foreach (string[] tab_trajet in list_trajets)
            {
                trajet = new Trajet(int.Parse(tab_trajet[0]), tab_trajet[1], float.Parse(tab_trajet[2]), aeroports.Find(int.Parse(tab_trajet[3])), aeroports.Find(int.Parse(tab_trajet[4])));
                trajets.Add(trajet);
            }
        }


        public List<Trajet> Trajets
        {
            get { return trajets; }
            set { trajets = value; }
        }


        public List<string> Trajets_Str
        {
            get {

                List<string> trajets_str = new List<string>();
                foreach (Trajet trajet in trajets)
                {
                    trajets_str.Add(trajet.Depart.AITA + " - " + trajet.Arrivee.AITA);
                }
                return trajets_str;

            }
        }


        public Trajet Find(int id)
        {
            for (int i = 0; i < trajets.Count; i++)
            {
                if (trajets[i].Id == id)
                {
                    return trajets[i];
                }
            }

            return default(Trajet);
        }


        public Trajet FindByStr(string str)
        {
            for (int i = 0; i < trajets.Count; i++)
            {
                if (str == trajets[i].Aeroport_Str)
                {
                    return trajets[i];
                }
            }

            return default(Trajet);
        }
    }
}