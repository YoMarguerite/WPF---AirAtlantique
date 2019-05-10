using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Vol
{
    class DAL_Vol
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Vol> SelectVols()
        {
            ObservableCollection<Vol> Vols = new ObservableCollection<Vol>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Vol;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vol Vol = new Vol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4));
                Vols.Add(Vol);
            }
            reader.Close();
            bdd.CloseConnection();
            return Vols;
        }

        public static Vol GetVol(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM Vol WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Vol Vol = new Vol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4));
            reader.Close();
            bdd.CloseConnection();
            return Vol;
        }

        public static void AjouterVol(int TrajetProperty, int AvionProperty, DateTime DepartProperty, DateTime ArriveeProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO Vol (trajet_id, avion_id, depart, arrivee) VALUES (@trajet, @avion, @depart, @arrivee)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@trajet", TrajetProperty);
            cmd.Parameters.AddWithValue("@avion", AvionProperty);
            cmd.Parameters.AddWithValue("@depart", DepartProperty);
            cmd.Parameters.AddWithValue("@arrivee", ArriveeProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierVol(int IdVolProperty, int TrajetProperty, int AvionProperty, DateTime DepartProperty, DateTime ArriveeProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `Vol` SET `trajet_id` = @trajet, `avion_id` = @avion, `depart` = @depart, `arrivee` = @arrivee WHERE `Vol`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@trajet", TrajetProperty);
            cmd.Parameters.AddWithValue("@avion", AvionProperty);
            cmd.Parameters.AddWithValue("@depart", DepartProperty);
            cmd.Parameters.AddWithValue("@arrivee", ArriveeProperty);
            cmd.Parameters.AddWithValue("@id", IdVolProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void SupprimerVol(int idVol)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM Vol WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idVol);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
