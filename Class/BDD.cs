using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class BDD
    {
        private MySqlConnection connection;

        // Constructeur
        public BDD()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=127.0.0.1; DATABASE=mydb; UID=root; PASSWORD=sohcahtoa";
            this.connection = new MySqlConnection(connectionString);
        }

        // Méthode pour ajouter un contact
        public void InsertAvion(Avion avion)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

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

                avion.setId( int.Parse( reader["Id"].ToString() ) );

                // Fermeture de la connexion
                this.connection.Close();
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
            this.connection.Open();
            string result = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

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
            return "vide";

        }

        public string SelectDetails()
        {
            this.connection.Open();
            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO AvionDetails (Avion, Motorisation, NombreAvions, Passagers, Premieres, Business, PremiumEco, Economy, Type) " +
                    "VALUES (@avion,@motor,@nbavions,@passagers,@premieres,@business,@premiumeco,@economy,@type);";


            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@avion", "Airbus A319-100");
            cmd.Parameters.AddWithValue("@motor", "CFM56 - 5A ou B");
            cmd.Parameters.AddWithValue("@nbavions", 41);
            cmd.Parameters.AddWithValue("@passagers", 138);
            cmd.Parameters.AddWithValue("@premieres", 0);
            cmd.Parameters.AddWithValue("@business", 26);
            cmd.Parameters.AddWithValue("@premiumeco", 36);
            cmd.Parameters.AddWithValue("@economy", 63);
            cmd.Parameters.AddWithValue("@type", "Long et moyen courrier");

            cmd.ExecuteNonQuery();

            // Requête SQL
            cmd.CommandText = "SELECT * from AvionDetails where idAvionDetails=2";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return reader.GetString(1);
                }
            }
            return "vide";

        }


        // ----------------------------------------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------------------------------------


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
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO clients (Nom, Prenom, Adresse, Mail,  Naissance, Fidelite, Password ) " +
                "VALUES (@nom, @prenom, @adresse, @mail, @naissance, @fidelite, @motdepasse); SELECT @@Identity";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
            cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
            cmd.Parameters.AddWithValue("@adresse", utilisateur.Adresse);
            cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
            cmd.Parameters.AddWithValue("@naissance", date);
            cmd.Parameters.AddWithValue("@fidelite", utilisateur.Fidelite);
            cmd.Parameters.AddWithValue("@motdepasse", sha256(MotDePasse));



            // Exécution de la commande SQL
            object reader = cmd.ExecuteScalar();
                
            // Fermeture de la connexion
            this.connection.Close();

            return int.Parse(reader.ToString());

        }


        public string SelectUtilisateur(string mail)
        {
            this.connection.Open();

            string result = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from clients where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetString(0)+";"+ reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) 
                        + ";" + reader.GetString(4) + ";" + reader.GetString(5) + ";" + reader.GetString(6);
                }
            }

            return result;
        }

        public bool SelectMail(string mail)
        {
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from clients where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            MySqlDataReader reader = cmd.ExecuteReader();

            this.connection.Close();

            if (reader.HasRows)
            {
                return true;
            }
            return false;

        }

        public bool SelectMotDePasse(string mail, string mdp)
        {
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT Password from Clients where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            object reader = cmd.ExecuteScalar();

            this.connection.Close();


            if ((reader.ToString()) == sha256(mdp))
            {
                return true;
            }

            return false;

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
