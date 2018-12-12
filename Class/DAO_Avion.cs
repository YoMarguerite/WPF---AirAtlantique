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
                cmd.CommandText = "INSERT INTO Avion (NombreKM, Moyenne_km/j, ProchaineMaintenance, DernièreMaintenance, Disponible, idAvionDetails) " +
                    "VALUES (@nb, @moyenne, @pro_maintenance, @der_maintenance, @disponible, @idDetails); SELECT @@Identity as Id";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@nb", avion.getNbKM());
                cmd.Parameters.AddWithValue("@moyenne", avion.getMoyenne_kmj());
                cmd.Parameters.AddWithValue("@pro_maintenance", avion.getPro_maintenance());
                cmd.Parameters.AddWithValue("@der_maintenance", avion.getDer_maintenance());
                cmd.Parameters.AddWithValue("@disponible", avion.getDisponible());
                cmd.Parameters.AddWithValue("@idDetails", avion.getDetails());

                // Exécution de la commande SQL
                MySqlDataReader reader = cmd.ExecuteReader();

                avion.setId(int.Parse(reader["Id"].ToString()));

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

        public string SelectAvions()
        {
            bdd.connection.Open();
            string result = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from Avion";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result += reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4);
                }
            }

            bdd.connection.Close();

            return "vide";

        }
        
    }
}
