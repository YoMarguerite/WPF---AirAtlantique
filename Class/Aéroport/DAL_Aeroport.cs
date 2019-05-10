using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Aeroport
{
    class DAL_Aeroport
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Aeroport> SelectAeroports()
        {
            ObservableCollection<Aeroport> aeroports = new ObservableCollection<Aeroport>();
            bdd.OpenConnection();
            string query = "SELECT * FROM aeroport;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Aeroport aeroport = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                aeroports.Add(aeroport);
            }
            reader.Close();
            bdd.CloseConnection();
            return aeroports;
        }

        public static List<string> SelectNomAeroports()
        {
            List<string> aeroports = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM aeroport;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Aeroport aeroport = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                aeroports.Add(aeroport.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return aeroports;
        }

        public static Aeroport GetAeroport(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM aeroport WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Aeroport aeroport = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            bdd.CloseConnection();
            return aeroport;
        }

        public static Aeroport FindByName(string nom)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM aeroport WHERE nom = @nom;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Aeroport aeroport = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            bdd.CloseConnection();
            return aeroport;
        }

        public static void AjouterAeroport(string NomProperty, int VilleProperty, string AitaProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO aeroport (nom, aita, ville_id) VALUES (@nom, @aita, @ville)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@nom", NomProperty);
            cmd.Parameters.AddWithValue("@ville", VilleProperty);
            cmd.Parameters.AddWithValue("@aita", AitaProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierAeroport(int IdAeroportProperty, string NomProperty, int VilleProperty, string AitaProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `aeroport` SET `nom` = @nom, `aita` = @aita, `ville_id` = @ville WHERE `aeroport`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@nom", NomProperty);
            cmd.Parameters.AddWithValue("@aita", AitaProperty);
            cmd.Parameters.AddWithValue("@ville", VilleProperty);
            cmd.Parameters.AddWithValue("@id", IdAeroportProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }


        public static void SupprimerAeroport(int idAeroport)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM aeroport WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idAeroport);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
