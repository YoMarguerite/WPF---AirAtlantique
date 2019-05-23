using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Classe;
using WpfApp1.Class.Tarif;

namespace WpfApp1.Class.TarifVol
{
    class TarifVol
    {
        private int id;
        private int vol;
        private int tarif;
        private float prix;

        public TarifVol(int _id, int _vol, int _tarif, float _prix)
        {
            id = _id;
            vol = _vol;
            tarif = _tarif;
            prix = _prix;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Vol
        {
            get { return vol; }
            set { vol = value; }
        }

        public int Tarif
        {
            get { return tarif; }
            set { tarif = value; }
        }

        public string StrTarif
        {
            get { return DAL_Tarif.GetTarif(tarif).Nom; }
        }

        public string Classe
        {
            get { return DAL_Classe.GetClasse(DAL_Tarif.GetTarif(tarif).Classe).Nom; }
        }

        public float Prix
        {
            get { return prix; }
            set { prix = value; }
        }
    }
}
