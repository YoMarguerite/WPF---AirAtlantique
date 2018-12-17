using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class
{
    class DAO_Trajet
    {
        private BDD bdd = new BDD();

        public void InsertTrajet(Trajet trajet)
        {
            try
            {
                // Ouverture de la connexion SQL
                bdd.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = bdd.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO trajet (Duree, Kilometre, depart, arrive) " +
                    "VALUES (@duree, @kilometre, @depart, @arrive); SELECT @@Identity as Id";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@trajet", trajet.Duree);
                cmd.Parameters.AddWithValue("@depart", trajet.Kilometre);
                cmd.Parameters.AddWithValue("@arrive", trajet.Depart);
                cmd.Parameters.AddWithValue("@modele", trajet.Arrivee);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                bdd.connection.Close();
            }
            catch
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
            }
        }

        public List<string[]> SelectTrajets()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_vol = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from trajet";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_vol = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4);
                    results.Add(str_vol.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;

        }

    }
}
