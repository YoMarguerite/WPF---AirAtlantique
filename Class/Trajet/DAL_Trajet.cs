using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Trajet
{
    class DAL_Trajet
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Trajet> SelectTrajets()
        {
            ObservableCollection<Trajet> trajets = new ObservableCollection<Trajet>();
            bdd.OpenConnection();
            string query = "SELECT * FROM trajet;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trajet trajet = new Trajet(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetString(5));
                trajets.Add(trajet);
            }
            reader.Close();
            bdd.CloseConnection();
            return trajets;
        }

        public static List<string> SelectStrTrajets()
        {
            List<string> trajets = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM trajet;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trajet trajet = new Trajet(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetString(5));
                trajets.Add(trajet.Depart + " - " + trajet.Arrivee);
            }
            reader.Close();
            bdd.CloseConnection();
            return trajets;
        }

        public static Trajet GetTrajet(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM trajet WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Trajet trajet = new Trajet(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetString(5));
            reader.Close();
            bdd.CloseConnection();
            return trajet;
        }

        public static Trajet FindByStrTrajet(string str)
        {
            ObservableCollection<Trajet> trajets = SelectTrajets();
            foreach (Trajet trajet in trajets)
            {
                if(str == trajet.Depart+" - " + trajet.Arrivee)
                {
                    return trajet;
                }
            }
            return null;
        }

        public static void AjouterTrajet(string DureeProperty, string RefProperty, float DistanceProperty, int DepartProperty, int ArriveeProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO trajet (duree, reference, distance, depart_id, arrivee_id) VALUES (@duree, @reference, @distance, @depart, @arrivee)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@duree", DureeProperty);
            cmd.Parameters.AddWithValue("@reference", RefProperty);
            cmd.Parameters.AddWithValue("@distance", DistanceProperty);
            cmd.Parameters.AddWithValue("@depart", DepartProperty);
            cmd.Parameters.AddWithValue("@arrivee", ArriveeProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierTrajet(int IdTrajetProperty, string DureeProperty, string RefProperty, float DistanceProperty, int DepartProperty, int ArriveeProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `trajet` SET `duree` = @duree, `reference` = @reference, `distance` = @distance, `depart_id` = @depart, `arrivee_id` = @arrivee WHERE `trajet`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@duree", DureeProperty);
            cmd.Parameters.AddWithValue("@reference", RefProperty);
            cmd.Parameters.AddWithValue("@distance", DistanceProperty);
            cmd.Parameters.AddWithValue("@depart", DepartProperty);
            cmd.Parameters.AddWithValue("@arrivee", ArriveeProperty);
            cmd.Parameters.AddWithValue("@id", IdTrajetProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }


        public static void SupprimerTrajet(int idTrajet)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM trajet WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idTrajet);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
