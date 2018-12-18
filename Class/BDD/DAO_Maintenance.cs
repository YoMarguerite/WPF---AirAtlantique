using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class
{
    class DAO_Maintenance
    {
        private BDD bdd = new BDD();

        public void InsertMaintenance(Maintenance maintenance, Avion avion, Aeroport aeroport)
        {
            try
            {
                // Ouverture de la connexion SQL
                bdd.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = bdd.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO maintenance (date, details, idavion, idaeroport) " +
                    "VALUES (@date, @details, @avion, @aeroport); SELECT @@Identity as Id";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@date", maintenance.Date);
                cmd.Parameters.AddWithValue("@details", maintenance.Details);
                cmd.Parameters.AddWithValue("@avion", avion.Id);
                cmd.Parameters.AddWithValue("@aeroport", aeroport.Id);

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

        public List<string[]> SelectMaintenances()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_maintenance = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from maintenance";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_maintenance = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4);
                    results.Add(str_maintenance.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;

        }


        public void UpdateDate(int id, string date)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE maintenance SET Date = @Str WHERE idmaintenance=@id";
            cmd.Parameters.AddWithValue("@Str", date);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateDetails(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE maintenance SET Details = @Str WHERE idmaintenance=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateAvion(int id, int id_avion)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE maintenance SET idAvion = @Str WHERE idmaintenance=@id";
            cmd.Parameters.AddWithValue("@Str", id_avion);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateAeroport(int id, int idaeroport)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE maintenance SET idAeroport = @Str WHERE idmaintenance=@id";
            cmd.Parameters.AddWithValue("@Str", idaeroport);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void Delete(int id)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "DELETE FROM maintenance WHERE idmaintenance=@id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

    }
}
