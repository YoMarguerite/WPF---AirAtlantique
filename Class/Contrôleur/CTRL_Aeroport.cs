using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Aeroport
    {
        private DAO_Aeroport bdd_aeroport = new DAO_Aeroport();
        private List<Aeroport> aeroports = new List<Aeroport>();


        public CTRL_Aeroport()
        {
            List<string[]> list_aeroports = bdd_aeroport.SelectAeroports();
            Aeroport aeroport;

            foreach (string[] tab_aeroport in list_aeroports)
            {
                aeroport = new Aeroport(int.Parse(tab_aeroport[0]), tab_aeroport[1], tab_aeroport[2], tab_aeroport[3], tab_aeroport[4]);
                aeroports.Add(aeroport);
            }
        }

        public List<Aeroport> Aeroport
        {
            get { return aeroports; }
            set { aeroports = value; }
        }

        public List<string> AITA
        {
            get {
                List<string> AITA = new List<string>();
                foreach (Aeroport aeroport in aeroports)
                {
                    AITA.Add(aeroport.AITA);
                }
                return AITA;
            }
        }

        public List<string> Nom
        {
            get
            {
                List<string> Nom = new List<string>();
                foreach (Aeroport aeroport in aeroports)
                {
                    Nom.Add(aeroport.Nom);
                }
                return Nom;
            }
        }

        public Aeroport Find(int id)
        {
            for (int i = 0; i < aeroports.Count; i++)
            {
                if (aeroports[i].Id == id)
                {
                    return aeroports[i];
                }
            }

            return default(Aeroport);
        }

        public Aeroport FindByAITA(string aita)
        {
            for (int i = 0; i < aeroports.Count; i++)
            {
                if (aeroports[i].AITA == aita)
                {
                    return aeroports[i];
                }
            }

            return default(Aeroport);
        }

        public Aeroport FindByNom(string nom)
        {
            for (int i = 0; i < aeroports.Count; i++)
            {
                if (aeroports[i].Nom == nom)
                {
                    return aeroports[i];
                }
            }

            return default(Aeroport);
        }

        public bool AeroportExist(string aita)
        {

            if (FindByAITA(aita) == default(Aeroport))
            {
                return false;
            }

            return true;
        }
    }
}
