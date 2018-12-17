using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class
{
    class DAO_Vol
    {
        private BDD bdd = new BDD();

        public void InsertVol(Vol vol, Trajet trajet, Avion avion)
        {
            try
            {
                // Ouverture de la connexion SQL
                bdd.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = bdd.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO vol (trajet, depart, arrive, avion) " +
                    "VALUES (@trajet, @depart, @arrive, @avion); SELECT @@Identity as Id";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@trajet", trajet.Id);
                cmd.Parameters.AddWithValue("@depart", vol.Depart);
                cmd.Parameters.AddWithValue("@arrive", vol.Arrive);
                cmd.Parameters.AddWithValue("@modele", avion.Id);

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

        public List<string[]> SelectVols()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_vol = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from vol";

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


        public void UpdateVolTrajet(int id, int idtrajet)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET trajet = @Str WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@Str", idtrajet);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateVolDepart(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET depart = @Str WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateVolArrive(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET arrive = @Str WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateVolAvion(int id, int idavion)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET avion = @avion WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@avion", idavion);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

    }
}
