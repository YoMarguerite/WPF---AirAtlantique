using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Maintenance
{
    class DAL_Maintenance
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Maintenance> SelectMaintenances()
        {
            ObservableCollection<Maintenance> Maintenances = new ObservableCollection<Maintenance>();
            bdd.OpenConnection();
            string query = "SELECT * FROM maintenance;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Maintenance Maintenance = new Maintenance(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                Maintenances.Add(Maintenance);
            }
            reader.Close();
            bdd.CloseConnection();
            return Maintenances;
        }

        public static ObservableCollection<Maintenance> SelectMaintenancesByEmploye(int employe)
        {
            ObservableCollection<Maintenance> Maintenances = new ObservableCollection<Maintenance>();
            bdd.OpenConnection();
            string query = "SELECT * FROM maintenance where responsable_id = @employe;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@employe", employe);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Maintenance Maintenance = new Maintenance(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                Maintenances.Add(Maintenance);
            }
            reader.Close();
            bdd.CloseConnection();
            return Maintenances;
        }

        public static Maintenance GetMaintenance(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM maintenance WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Maintenance Maintenance = new Maintenance(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
            reader.Close();
            bdd.CloseConnection();
            return Maintenance;
        }

        public static void AjouterMaintenance(int AvionProperty, DateTime DateProperty, int AeroportProperty, string DetailsProperty, int ResponsableProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO maintenance (avion_id, date, aeroport_id, details, responsable_id) VALUES (@avion, @date, @aeroport, @details, @responsable)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@avion", AvionProperty);
            cmd.Parameters.AddWithValue("@date", DateProperty);
            cmd.Parameters.AddWithValue("@aeroport", AeroportProperty);
            cmd.Parameters.AddWithValue("@details", DetailsProperty);
            cmd.Parameters.AddWithValue("@responsable", ResponsableProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierMaintenance(int IdMaintenanceProperty, int AvionProperty, DateTime DateProperty, int AeroportProperty, string DetailsProperty, int ResponsableProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `maintenance` SET `avion_id` = @avion, `date` = @date, `aeroport_id` = @aeroport, `details` = @details, `responsable_id` = @responsable WHERE `maintenance`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@avion", AvionProperty);
            cmd.Parameters.AddWithValue("@date", DateProperty);
            cmd.Parameters.AddWithValue("@aeroport", AeroportProperty);
            cmd.Parameters.AddWithValue("@details", DetailsProperty);
            cmd.Parameters.AddWithValue("@responsable", ResponsableProperty);
            cmd.Parameters.AddWithValue("@id", IdMaintenanceProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void SupprimerMaintenance(int idMaintenance)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM maintenance WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idMaintenance);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
