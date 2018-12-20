using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Billet
    {
        private DAO_Billet bdd_billet = new DAO_Billet();
        private List<Billet> billets = new List<Billet>();


        public CTRL_Billet(CTRL_Classe classes, CTRL_Tarif tarifs, CTRL_Vol vols, CTRL_Client clients)
        {
            List<int[]> list_billets = bdd_billet.SelectBillets();
            Billet billet;
            
            
            foreach (int[] tab_billet in list_billets)
            {
                Vol vol = vols.Find(tab_billet[3]);
                List<Tarif> list_tarif = tarifs.TarifsCorrespond(vol);

                billet = new Billet( tab_billet[0], classes.ClassesCorrespond(list_tarif), list_tarif, vol, clients.Find(tab_billet[1]));
                billets.Add(billet);
            }
        }


        public List<Billet> Billets
        {
            get { return billets; }
        }


        public ObservableCollection<Billet> DataBillet
        {
            get {
                ObservableCollection<Billet> data = new ObservableCollection<Billet>();
                foreach (Billet billet in billets)
                {
                    data.Add(billet);
                }
                return data;
            }
        }


        public Billet Find(int id)
        {
            foreach (Billet billet in billets)
            {
                if (billet.Id == id)
                {
                    return billet;
                }
            }
            return default(Billet);
        }
    }
}
