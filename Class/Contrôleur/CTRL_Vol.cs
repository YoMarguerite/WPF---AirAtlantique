using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Vol
    {
        private DAO_Vol bdd_vol = new DAO_Vol();
        private List<Vol> vols = new List<Vol>();


        public CTRL_Vol(CTRL_Trajet trajets, CTRL_Avion avions)
        {
            List<string[]> list_vols = bdd_vol.SelectVols();
            Vol vol;

            foreach (string[] tab_vol in list_vols)
            {
                vol = new Vol(int.Parse(tab_vol[0]), trajets.Find(int.Parse(tab_vol[1])), tab_vol[2], tab_vol[3], avions.Find(int.Parse(tab_vol[4])));
                vols.Add(vol);
            }
        }


        public List<Vol> Vol
        {
            get { return vols; }
        }


        public ObservableCollection<Vol> DataVols
        {
            get
            {
                ObservableCollection<Vol> datavol = new ObservableCollection<Vol>();

                foreach (Vol vol in vols)
                {
                    datavol.Add(vol);
                }

                return datavol;
            }
        }


        public void ChangeDepart(ref Vol vol, string str)
        {
            vol.Depart = str;
            bdd_vol.UpdateVolDepart(vol.Id, str.StringFormatDate());
        }


        public void ChangeArrive(ref Vol vol, string str)
        {
            vol.Arrive = str;
            bdd_vol.UpdateVolArrive(vol.Id, str.StringFormatDate());
        }


        public void ChangeTrajet(ref Vol vol, Trajet trajet)
        {
            vol.Trajet_Str = trajet.Aeroport_Str;
            bdd_vol.UpdateVolTrajet(vol.Id, trajet.Id);
        }


        public void ChangeAvion(ref Vol vol, Avion avion)
        {
            vol.Avion = avion.Matricule;
            bdd_vol.UpdateVolAvion(vol.Id, avion.Id);
        }


        public Vol Find(int id)
        {
            for (int i = 0; i < vols.Count; i++)
            {
                if (vols[i].Id == id)
                {
                    return vols[i];
                }
            }

            return default(Vol);
        }
    }
}