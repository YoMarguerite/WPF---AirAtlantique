using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class DAO_Tarif
    {
        private DAL_Tarif bdd_tarif = new DAL_Tarif();
        private List<Tarif> tarifs = new List<Tarif>();


        public DAO_Tarif(DAO_Classe classes)
        {
            List<string[]> list_tarifs = bdd_tarif.SelectTarifs();
            Tarif tarif;

            foreach (string[] tab_tarif in list_tarifs)
            {
                //tarif = new Tarif(int.Parse(tab_tarif[0]), classes.FindById(int.Parse(tab_tarif[1])), tab_tarif[2]);
                //tarifs.Add(tarif);
            }
        }


        public List<Tarif> Tarifs
        {
            get { return tarifs; }
        }


        public List<string> FindByClasse(int idClasse)
        {
            List<string> results = new List<string>();
            foreach (Tarif tarif in tarifs)
            {
                //if (tarif.Classe.Id == idClasse)
                //{
                //    results.Add(tarif.Nom);
                //}

            }
            return results;
        }


        public Tarif Find(int id)
        {
            foreach(Tarif tarif in tarifs)
            {
                if(tarif.Id == id)
                {
                    return tarif;
                }
            }
            return default(Tarif);
        }


        //public List<Tarif> TarifsCorrespond(Vol vol)
        //{
        //    List<Tarif> list_tarif = new List<Tarif>();
        //    foreach (double[] idTarif in vol.Tarifs)
        //    {
        //        list_tarif.Add(Find((int)idTarif[0]));
        //    }
        //    return list_tarif;
        //}
    }
}
