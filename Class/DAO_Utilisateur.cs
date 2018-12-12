using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Utilisateur
    {
        private BDD bdd = new BDD();

        public int InsertUtilisateur(Utilisateur utilisateur, string MotDePasse)
        {

            DateTime date;

            if (utilisateur.Naissance != "")
            {
                date = DateTime.Parse(utilisateur.Naissance);
            }
            else
            {
                date = new DateTime();
            }


            // Ouverture de la connexion SQL
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO clients (Nom, Prenom, Adresse, Mail,  Naissance, Fidelite, MotDePasse, Civilite ) " +
                "VALUES (@nom, @prenom, @adresse, @mail, @naissance, @fidelite, @motdepasse, @civilite); SELECT @@Identity";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
            cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
            cmd.Parameters.AddWithValue("@adresse", utilisateur.Adresse);
            cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
            cmd.Parameters.AddWithValue("@naissance", date);
            cmd.Parameters.AddWithValue("@fidelite", utilisateur.Fidelite);
            cmd.Parameters.AddWithValue("@motdepasse", sha256(MotDePasse));
            cmd.Parameters.AddWithValue("@civilite", utilisateur.Civilite);


            // Exécution de la commande SQL
            object reader = cmd.ExecuteScalar();

            // Fermeture de la connexion
            bdd.connection.Close();

            return int.Parse(reader.ToString());

        }

        public string SelectUtilisateur(string mail)
        {
            bdd.connection.Open();

            string result = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from clients where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3)
                        + ";" + reader.GetString(4) + ";" + reader.GetString(5) + ";" + reader.GetString(6);
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
            cmd.CommandText = "SELECT * from clients where Mail=@mail";
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
            cmd.CommandText = "SELECT Password from Clients where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            object reader = cmd.ExecuteScalar();

            bdd.connection.Close();


            if ((reader.ToString()) == sha256(mdp))
            {
                return true;
            }

            return false;

        }

        public void UpdateUtilisateurNom(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE Clients SET Nom = @Str WHERE idClients=@Id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateUtilisateurPrenom(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE Clients SET Prenom = @Str WHERE idClients=@Id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateUtilisateurMail(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE Clients SET Mail = @Str WHERE idClients=@Id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public void UpdateUtilisateurAdresse(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE Clients SET Adresse = @Str WHERE idClients=@Id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }

        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}

