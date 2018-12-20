using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            List<double[]> prix = bdd_vol.SelectTarifs();
            Vol vol;

            foreach (string[] tab_vol in list_vols)
            {
                vol = new Vol(int.Parse(tab_vol[0]), trajets.Find(int.Parse(tab_vol[1])), tab_vol[2], tab_vol[3], avions.Find(int.Parse(tab_vol[4])), TarifsByVol(int.Parse(tab_vol[0]), prix));
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


        public void Nouveau(Vol vol, int idavion, int idtrajet)
        {
            vols.Add(vol);

            vol.Id = bdd_vol.InsertVol(vol.Depart.StringFormatDate(), vol.Arrive.StringFormatDate(), idavion, idtrajet);
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


        public List<Vol> Correspondance(Trajet trajet, bool horaire, DateTime date)
        {
            List<Vol> list_vols_trajets = VolsByTrajet(trajet.Aeroport_Str);
            List<Vol> list_vols = new List<Vol>();
            DateTime time_vol;

            foreach (Vol vol in list_vols_trajets)
            {
                if (!horaire)
                {
                    time_vol = DateTime.Parse(vol.Depart);
                }
                else
                {
                    time_vol = DateTime.Parse(vol.Arrive);
                }
                
                if ((date.AddMinutes(-30) < time_vol) && (date.AddMinutes(30) > time_vol))
                {
                    list_vols.Add(vol);
                }
            }
            return list_vols;
        }


        public List<Vol> VolsByTrajet(string trajet_str)
        {
            List<Vol> list_vols = new List<Vol>();
            foreach (Vol vol in vols)
            {
                if(vol.Trajet_Str == trajet_str)
                {
                    list_vols.Add(vol);
                }
            }
            return list_vols;
        }


        public List<double[]> TarifsByVol(int idvol, List<double[]> tarifs)
        {
             List<double[]> results = new List<double[]>();

            foreach (double[] tarif in tarifs)
            {
                if(tarif[1] == idvol)
                {
                    results.Add(new double[2] { tarif[0], tarif[2] });
                }
            }

            return results;
        }


        public void Supprimer(int id)
        {
            vols.Remove(Find(id));
            bdd_vol.Delete(id);
        }
    }
}