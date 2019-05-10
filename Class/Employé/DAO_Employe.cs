using System.Collections.Generic;

namespace WpfApp1.Class.ViewModel
{
    public class DAO_Employe
    {
        private DAL_Employe bdd_employe = new DAL_Employe();
        private List<Employe> employes = new List<Employe>();


        public DAO_Employe()
        {
            bdd_employe.SelectEmployes(employes);
        }


        public List<Employe> Employe
        {
            get { return employes; }
        }


        public void ChangeNom(Employe employe, string nom)
        {
            employe.Nom = nom;
            bdd_employe.UpdateEmploye(employe);
        }


        public void ChangePrenom(Employe employe, string prenom)
        {
            employe.Prenom = prenom;
            bdd_employe.UpdateEmploye(employe);
        }


        public void ChangePoste(Employe employe, string poste)
        {
            employe.Poste = poste;
            bdd_employe.UpdateEmploye(employe);
        }


        public bool EmployeExist(string mail)
        {
            
            if(Find(mail) == default(Employe))
            {
                return false;
            }

            return true;
        }


        public Employe Find(string mail)
        {
            for (int i = 0; i < employes.Count; i++)
            {
                if (employes[i].Mail == mail)
                {
                    return employes[i];
                }
            }

            return default(Employe);
        }


        public void AjouterEmploye(ref Employe employe, string mdp)
        {
            employes.Add(employe);
            employe.Id = bdd_employe.InsertEmploye(employe);
        }


        public bool VerifierConnexion(string mail, string mdp)
        {
            return bdd_employe.SelectMotDePasse(mail, mdp);
        }
    }
}
