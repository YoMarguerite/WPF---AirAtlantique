using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Avion
    {
        private BDD bdd = new BDD();

        public void InsertAvion(Avion avion)
        {
            try
            {
                // Ouverture de la connexion SQL
                bdd.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = bdd.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO avion (Matricule, Moteur, Kilometre, Modele, Type, Passager) " +
                    "VALUES (@matricule, @moteur, @kilometre, @modele, @type, @passager); SELECT @@Identity as Id";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@matricule", avion.Matricule);
                cmd.Parameters.AddWithValue("@moteur", avion.Moteur);
                cmd.Parameters.AddWithValue("@kilometre", avion.Kilometre);
                cmd.Parameters.AddWithValue("@modele", avion.Modele);
                cmd.Parameters.AddWithValue("@type", avion.Type);
                cmd.Parameters.AddWithValue("@passager", avion.Passager);

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

        public List<string[]> SelectAvions()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_avion = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from avion";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_avion = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4)
                        + ";" + reader.GetString(5) + ";" + reader.GetString(6);
                    results.Add(str_avion.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;

        }
        
    }
}
