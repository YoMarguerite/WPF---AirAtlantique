using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Employe
    {
        private DAO_Employe bdd_employe = new DAO_Employe();
        private CTRL_Poste postes = new CTRL_Poste();
        private List<Employe> employes = new List<Employe>();


        public CTRL_Employe()
        {
            List<string[]> list_employes = bdd_employe.SelectEmployes();
            Employe employe;

            foreach (string[] tab_employe in list_employes)
            {
                employe = new Employe(int.Parse(tab_employe[0]), tab_employe[1], tab_employe[2], tab_employe[3], tab_employe[5].ToBoolean().CiviliteBool(), true, postes.Poste(int.Parse(tab_employe[6])-1).Nom);
                employes.Add(employe);
            }
        }


        public List<Employe> Employe
        {
            get { return employes; }
        }


        public CTRL_Poste Postes
        {
            get { return postes; }
        } 


        public void ChangeNom(ref Utilisateur employe, string str)
        {
            employe.Nom = str;
            bdd_employe.UpdateEmployeNom(employe.Id, str);
        }


        public void ChangePrenom(ref Utilisateur employe, string str)
        {
            employe.Prenom = str;
            bdd_employe.UpdateEmployePrenom(employe.Id, str);
        }


        public void ChangePoste(ref Employe employe, string str)
        {
            employe.Poste = str;
            bdd_employe.UpdateEmployePoste(employe.Id, postes.Find(str)+1);
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
            employe.Id = bdd_employe.InsertEmploye(employe, mdp, postes.Find(employe.Poste));
        }


        public bool VerifierConnexion(string mail, string mdp)
        {
            return bdd_employe.SelectMotDePasse(mail, mdp);
        }
    }
}
