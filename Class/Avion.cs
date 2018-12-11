using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    class Avion
    {

//----------------- Variables ------------------
        private int id;
        private int NombreKM;
        private int Moyenne_kmj;
        private string pro_maintenance;
        private string der_maintenance;
        private bool disponible;
        private int idDetails;

        public Avion(int id, int nbkm, int moyenne, string pro, string der, bool dispo, int details)
        {
            setId(id);
            setNbKM(nbkm);
            setMoyenne_kmj(moyenne);
            setPro_maintenance(pro);
            setDer_maintenance(der);
            setDisponible(dispo);
            setDetails(details);
        }

        public Avion()
        {

        }


//------------------ ID ------------------------
        public int getId()
        {
            return id;
        }

        public void setId(int nb)
        {
            this.id = nb;
        }

// ----------------- NombreKM ---------------------
        public int getNbKM()
        {
            return NombreKM;
        }

        public void setNbKM(int nb)
        {
            this.NombreKM = nb;
        }

        public void addKM(int nb)
        {
            this.NombreKM += nb;
        }

//------------------ Moyenne Km/j ------------------
        public int getMoyenne_kmj()
        {
            return Moyenne_kmj;
        }

        public void setMoyenne_kmj(int id)
        {
            this.id = id;
        }

//------------------- Prochaine maintenance ------------
        public string getPro_maintenance()
        {
            return pro_maintenance;
        }

        public void setPro_maintenance(string date)
        {
            this.pro_maintenance = date;
        }

//------------------- Dernière maintenance ------------
        public string getDer_maintenance()
        {
            return der_maintenance;
        }

        public void setDer_maintenance(string date)
        {
            this.der_maintenance = date;
        }

//-------------------- Disponibilité de l'avion --------
        public bool getDisponible()
        {
            return disponible;
        }

        public void setDisponible(bool ok)
        {
            this.disponible = ok;
        }

//-------------------- Id Details -----------------------
        public int getDetails()
        {
            return idDetails;
        }

        public void setDetails(int id)
        {
            this.idDetails = id;
        }

    }
}
