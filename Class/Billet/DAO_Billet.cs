using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Contrôleur;
using WpfApp1.Class.Entity;
using WpfApp1.Class.ViewModel;

namespace WpfApp1.Class.Billet
{
    class DAO_Billet
    {
        private DAL_Billet bdd_billet = new DAL_Billet();
        private List<Billet> billets = new List<Billet>();


        public DAO_Billet(DAO_Classe classes, DAO_Tarif tarifs)
        {
            bdd_billet.SelectBillets(billets);
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
