using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Avion
    {
        private DAO_Avion bdd_avion = new DAO_Avion();
        private List<Avion> avions = new List<Avion>();


        public CTRL_Avion()
        {
            List<string[]> list_avions = bdd_avion.SelectAvions();
            Avion avion;

            foreach (string[] tab_avion in list_avions)
            {
                avion = new Avion(int.Parse(tab_avion[0]), tab_avion[1], tab_avion[2], float.Parse(tab_avion[3]), tab_avion[4], tab_avion[5], int.Parse(tab_avion[6]));
                avions.Add(avion);
            }
        }


        public List<Avion> Avion
        {
            get { return avions; }
            set { avions = value; }
        }


        public List<string> Matricule
        {
            get {
                List<string> matricules = new List<string>();
                foreach (Avion avion in avions)
                {
                    matricules.Add(avion.Matricule);
                }
                return matricules;
            }
        }


        public Avion Find(int id)
        {
            for(int i = 0; i<avions.Count; i++)
            {
                if(avions[i].Id == id)
                {
                    return avions[i];
                }
            }

            return default(Avion);
        }


        public Avion FindByMatricule(string matricule)
        {
            for (int i = 0; i < avions.Count; i++)
            {
                if (avions[i].Matricule == matricule)
                {
                    return avions[i];
                }
            }

            return default(Avion);
        }
    }
}
