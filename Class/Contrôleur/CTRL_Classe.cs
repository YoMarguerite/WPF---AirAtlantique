using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Classe
    {
        private DAO_Classe bdd_classe = new DAO_Classe();
        private List<Classe> classes = new List<Classe>();


        public CTRL_Classe()
        {
            List<string[]> list_classes = bdd_classe.SelectClasses();
            Classe classe;

            foreach (string[] tab_class in list_classes)
            {
                classe = new Classe(int.Parse(tab_class[0]), tab_class[1]);
                classes.Add(classe);
            }
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
                if (!list_classe.Contains(tarif.Classe))
                {
                    list_classe.Add(tarif.Classe);
                }
            }
            return list_classe;
        }
    }
}
