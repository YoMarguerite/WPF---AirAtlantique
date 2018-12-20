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


        public int InsertEmploye(Employe employe, string MotDePasse, int Poste)
        {

            // Ouverture de la connexion SQL
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO employe (Nom, Prenom, Mail, MotDePasse, Civilite, Poste ) " +
                "VALUES (@nom, @prenom, @mail, @motdepasse, @civilite, @poste); SELECT @@Identity";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@nom", employe.Nom);
            cmd.Parameters.AddWithValue("@prenom", employe.Prenom);
            cmd.Parameters.AddWithValue("@mail", employe.Mail);
            cmd.Parameters.AddWithValue("@motdepasse", Utilisateur.sha256(MotDePasse));
            cmd.Parameters.AddWithValue("@civilite", employe.Civilite.CiviliteToBoolean());
            cmd.Parameters.AddWithValue("@poste", Poste);


            // Exécution de la commande SQL
            object reader = cmd.ExecuteScalar();

            // Fermeture de la connexion
            bdd.connection.Close();

            return int.Parse(reader.ToString());
        }


        public List<string[]> SelectEmployes()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_employe = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from employe";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_employe = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4)
                        + ";" + reader.GetString(5) + ";" + reader.GetString(6);
                    results.Add(str_employe.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;
        }


        public bool SelectMotDePasse(string mail, string mdp)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT MotDePasse from employe where Mail=@mail";
            cmd.Parameters.AddWithValue("@mail", mail);

            object reader = cmd.ExecuteScalar();

            bdd.connection.Close();


            if ((reader.ToString()) == Utilisateur.sha256(mdp))
            {
                return true;
            }

            return false;

        }


        public void UpdateEmployeNom(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE employe SET Nom = @Str WHERE idemploye=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }


        public void UpdateEmployePrenom(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE employe SET Prenom = @Str WHERE idemploye=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }


        public void UpdateEmployePoste(int id, int poste)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE employe SET Poste = @poste WHERE idemploye=@id";
            cmd.Parameters.AddWithValue("@poste", poste);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }
    }
}
