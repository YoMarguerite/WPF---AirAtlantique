using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class
{
    class DAL_Classe
    {
        private BDD bdd = new BDD();

        public void SelectClasses(List<Classe> classes)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from classe";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Classe classe = new Classe( reader.GetInt32(0) , reader.GetString(1));
                    classes.Add(classe);
                }
            }

            bdd.connection.Close();
        }
    }
}
