using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    class Employe : Utilisateur
    {
        private string matricule;
        private string embauche;
        private string poste;
        private bool permis_piste;

        
        public Employe() { }

        public Employe(int _id, int _fidelite, string _nom, string _prenom, string _adresse, string _mail, string _naissance, bool _civilite, 
            string _matricule, string _embauche, string _poste, bool _permis_piste ) : base( _id, _fidelite, _nom, _prenom, _adresse, _mail, _naissance, _civilite)
        {
            this.matricule = _matricule;
            this.embauche = _embauche;
            this.poste = _poste;
            this.permis_piste = _permis_piste;
        }

        public string Matricule
        {
            get { return matricule; }
            set { matricule = value; }
        }

        public string Embauche
        {
            get { return embauche; }
            set { embauche = value; }
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public bool Permis_piste
        {
            get { return permis_piste; }
            set { permis_piste = value; }
        }

    }
}
