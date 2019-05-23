using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class DAO_Classe
    {
        private DAL_Classe bdd_classe = new DAL_Classe();
        private List<Classe> classes = new List<Classe>();


        public DAO_Classe()
        {
            bdd_classe.SelectClasses(classes);
        }


        public List<Classe> Classes
        {
            get { return classes; }
        }


        public List<string> Classes_Str
        {
            get
            {
                List<string> classes_str = new List<string>();
                foreach (Classe classe in classes)
                {
                    classes_str.Add(classe.Nom);
                }
                return classes_str;
            }
        }


        public Classe FindById(int id)
        {
            foreach (Classe classe in classes)
            {
                if(classe.Id == id)
                {
                    return classe;
                }
            }
            return default(Classe);
        }


        public List<Classe> ClassesCorrespond(List<Tarif> list_tarif)
        {
            List<Classe> list_classe = new List<Classe>();
            foreach (Tarif tarif in list_tarif)
            {
                //if (!list_classe.Contains(tarif.Classe))
                //{
                //    list_classe.Add(tarif.Classe);
                //}
            }
            return list_classe;
        }
    }
}
