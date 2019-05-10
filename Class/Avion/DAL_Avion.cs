using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Avion
{
    class DAL_Avion
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Avion> SelectAvions()
        {
            ObservableCollection<Avion> avions = new ObservableCollection<Avion>();
            bdd.OpenConnection();
            string query = "SELECT * FROM avion;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Avion avion = new Avion(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6));
                avions.Add(avion);
            }
            reader.Close();
            bdd.CloseConnection();
            return avions;
        }

        public static List<string> SelectMatriculeAvions()
        {
            List<string> avions = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM avion;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Avion avion = new Avion(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6));
                avions.Add(avion.Matricule);
            }
            reader.Close();
            bdd.CloseConnection();
            return avions;
        }

        public static Avion GetAvion(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM avion WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Avion avion = new Avion(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6));
            reader.Close();
            bdd.CloseConnection();
            return avion;
        }

        public static Avion FindByMatricule(string matricule)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM avion WHERE matricule = @matricule;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@matricule", matricule);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Avion avion = new Avion(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6));
            reader.Close();
            bdd.CloseConnection();
            return avion;
        }

        public static void AjouterAvion(string MatriculeProperty, string MoteurProperty, float KilometreProperty, string ModeleProperty, string TypeProperty, int PassagerProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO avion (matricule, moteur, kilometre, modele, type, passager) VALUES (@matricule, @moteur, @kilometre, @modele, @type, @passager)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@matricule", MatriculeProperty);
            cmd.Parameters.AddWithValue("@moteur", MoteurProperty);
            cmd.Parameters.AddWithValue("@kilometre", KilometreProperty);
            cmd.Parameters.AddWithValue("@modele", ModeleProperty);
            cmd.Parameters.AddWithValue("@type", TypeProperty);
            cmd.Parameters.AddWithValue("@passager", PassagerProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierAvion(int IdAvionProperty, string MatriculeProperty, string MoteurProperty, float KilometreProperty, string ModeleProperty, string TypeProperty, int PassagerProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `avion` SET `matricule` = @matricule, `moteur` = @moteur, `kilometre` = @kilometre, `modele` = @modele, `type` = @type, `passager` = @passager WHERE `avion`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@matricule", MatriculeProperty);
            cmd.Parameters.AddWithValue("@moteur", MoteurProperty);
            cmd.Parameters.AddWithValue("@kilometre", KilometreProperty);
            cmd.Parameters.AddWithValue("@modele", ModeleProperty);
            cmd.Parameters.AddWithValue("@type", TypeProperty);
            cmd.Parameters.AddWithValue("@passager", PassagerProperty);
            cmd.Parameters.AddWithValue("@id", IdAvionProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }


        public static void SupprimerAvion(int idAvion)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM avion WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idAvion);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
