using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Poste
    {
        private DAO_Poste bdd_poste = new DAO_Poste();
        private List<Poste> postes = new List<Poste>();


        public CTRL_Poste()
        {
            List<string[]> list_postes = bdd_poste.SelectPoste();
            Poste poste;

            foreach (string[] tab_poste in list_postes)
            {
                poste = new Poste(tab_poste[1]);
                postes.Add(poste);
            }
        }


        public List<Poste> Postes
        {
            get { return postes; }
        }


        public List<string> Postes_Str
        {
            get {
                List<string> postes_str = new List<string>();
                foreach (Poste poste in postes)
                {
                    postes_str.Add(poste.Nom);
                }
                return postes_str;
            }
        }


        public Poste Poste(int index)
        {
            return postes[index];
        }


        public int Find(string nom)
        {
            for (int i = 0; i < postes.Count; i++)
            {
                if (postes[i].Nom == nom)
                {
                    return i;
                }
            }

            return 7;
        }
    }
}
