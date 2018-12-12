using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Employe
    {
        private BDD bdd = new BDD();

        public int InsertEmploye(Employe employe, string MotDePasse)
        {

            DateTime date;

            if (employe.Naissance != "")
            {
                date = DateTime.Parse(employe.Naissance);
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
            cmd.CommandText = "INSERT INTO employe (Nom, Prenom, Matricule, Adresse, Mail,  Naissance, Fidelite, MotDePasse, Civilite ) " +
                "VALUES (@nom, @prenom, @adresse, @mail, @naissance, @fidelite, @motdepasse, @civilite); SELECT @@Identity";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@nom", employe.Nom);
            cmd.Parameters.AddWithValue("@prenom", employe.Prenom);
            cmd.Parameters.AddWithValue("@adresse", employe.Adresse);
            cmd.Parameters.AddWithValue("@mail", employe.Mail);
            cmd.Parameters.AddWithValue("@naissance", date);
            cmd.Parameters.AddWithValue("@fidelite", employe.Fidelite);
            cmd.Parameters.AddWithValue("@motdepasse", DAO_Utilisateur.sha256(MotDePasse));
            cmd.Parameters.AddWithValue("@civilite", employe.Civilite);


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


            if ((reader.ToString()) == DAO_Utilisateur.sha256(mdp))
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
    }
}
