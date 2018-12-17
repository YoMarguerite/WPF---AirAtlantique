using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Client
    {
        private BDD bdd = new BDD();

        public int InsertClient(Client utilisateur, string MotDePasse)
        {

            // Ouverture de la connexion SQL
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO client (Nom, Prenom, Mail, MotDePasse, Civilite, Fidelite ) " +
                "VALUES (@nom, @prenom, @mail, @motdepasse, @civilite, @fidelite); SELECT @@Identity";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
            cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
            cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
            cmd.Parameters.AddWithValue("@motdepasse", Utilisateur.sha256(MotDePasse));
            cmd.Parameters.AddWithValue("@civilite", utilisateur.Civilite.CiviliteToBoolean());
            cmd.Parameters.AddWithValue("@fidelite", utilisateur.Fidelite);


            // Exécution de la commande SQL
            object reader = cmd.ExecuteScalar();

            // Fermeture de la connexion
            bdd.connection.Close();

            return int.Parse(reader.ToString());

        }

        public List<string[]> SelectClients()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_client = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from client";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_client = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4)
                        + ";" + reader.GetString(5) + ";" + reader.GetString(6);
                    results.Add(str_client.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;
        }

        public string SelectClient(string mail)
        {
            bdd.connection.Open();

            string result = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT Nom, Prenom, Mail, Civilite, Fidelite from client where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4);
                }
            }

            bdd.connection.Close();

            return result;
        }

        public bool SelectMail(string mail)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from client where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            MySqlDataReader reader = cmd.ExecuteReader();

            bdd.connection.Close();

            if (reader.HasRows)
            {
                return true;
            }
            return false;

        }

        public bool SelectMotDePasse(string mail, string mdp)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT MotDePasse from client where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            object reader = cmd.ExecuteScalar();

            bdd.connection.Close();

            if(reader != null)
            {
                if ((reader.ToString()) == Utilisateur.sha256(mdp))
                {
                    return true;
                }
            }
            
            return false;

        }

        public void UpdateClientNom(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET Nom = @Str WHERE idclient=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateClientPrenom(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET Prenom = @Str WHERE idclient=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateClientMail(int id, string str)
        {
            bdd.connection.Open();
            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET Mail = @Str WHERE idclient=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateClientCivilite(int id, bool civilite)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET Civilite = @Str WHERE idclient=@id";
            cmd.Parameters.AddWithValue("@Str", civilite);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateClientFidelite(int id, int fidelite)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET Fidelite = @Str WHERE idclient=@id";
            cmd.Parameters.AddWithValue("@Str", fidelite);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

    }
}

