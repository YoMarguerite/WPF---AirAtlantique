using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Ville
{
    class DAL_Ville
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Ville> SelectVilles()
        {
            ObservableCollection<Ville> villes = new ObservableCollection<Ville>();
            bdd.OpenConnection();
            string query = "SELECT * FROM ville;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ville ville = new Ville(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                villes.Add(ville);
            }
            reader.Close();
            bdd.CloseConnection();
            return villes;
        }

        public static List<string> SelectNomVilles()
        {
            List<string> villes = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM ville;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ville ville = new Ville(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                villes.Add(ville.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return villes;
        }

        public static Ville GetVille(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM ville WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Ville ville = new Ville(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            bdd.CloseConnection();
            return ville;
        }

        public static Ville FindByName(string nom)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM ville WHERE nom = @nom;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Ville ville = new Ville(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            bdd.CloseConnection();
            return ville;
        }
    }
}
