using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAL_Employe
    {
        private BDD bdd = new BDD();


        public int InsertEmploye(Employe employe)
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
            cmd.Parameters.AddWithValue("@motdepasse", employe.Mdp);
            cmd.Parameters.AddWithValue("@civilite", employe.Civilite);
            cmd.Parameters.AddWithValue("@poste", employe.Poste);


            // Exécution de la commande SQL
            object reader = cmd.ExecuteScalar();

            // Fermeture de la connexion
            bdd.connection.Close();

            return int.Parse(reader.ToString());
        }


        public void SelectEmployes(List<Employe> employes)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from employe";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Employe employe = new Employe( reader.GetInt32(0) , reader.GetString(1) , reader.GetString(2) , reader.GetString(3) , reader.GetString(4) , reader.GetBoolean(5) , reader.GetInt32(6));
                    //employes.Add(employe);
                }
            }

            bdd.connection.Close();
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

            if(reader != null)
            {
                if (BCrypt.Net.BCrypt.Verify(reader.ToString(), mdp))
                {
                    return true;
                }
            }

            return false;

        }


        public void UpdateEmploye(Employe employe)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET Nom = @Nom, Prenom = @Prenom, Mail = @Mail, Civilite = @Civilite, Poste = @Poste WHERE idemploye = @Id";
            cmd.Parameters.AddWithValue("@Nom", employe.Nom);
            cmd.Parameters.AddWithValue("@Id", employe.Prenom);
            cmd.Parameters.AddWithValue("@Nom", employe.Mail);
            cmd.Parameters.AddWithValue("@Id", employe.Civilite);
            cmd.Parameters.AddWithValue("@Nom", employe.Poste);
            cmd.Parameters.AddWithValue("@Id", employe.Id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }
    }
}
