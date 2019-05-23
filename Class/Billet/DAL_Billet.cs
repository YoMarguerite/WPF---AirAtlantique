using System;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Billet
{
    class DAL_Billet
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Billet> SelectBillets()
        {
            ObservableCollection<Billet> Billets = new ObservableCollection<Billet>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Billet;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Billet Billet = new Billet(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3));
                Billets.Add(Billet);
            }
            reader.Close();
            bdd.CloseConnection();
            return Billets;
        }

        public static ObservableCollection<Billet> SelectBilletsByClient(int client)
        {
            ObservableCollection<Billet> billets = new ObservableCollection<Billet>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Billet Where user_id = @client;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@client", client);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Billet billet = new Billet(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3));
                billets.Add(billet);
            }
            reader.Close();
            bdd.CloseConnection();
            return billets;
        }

        public static Billet GetBillet(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM Billet WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Billet Billet = new Billet(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3));
            reader.Close();
            bdd.CloseConnection();
            return Billet;
        }

        public static void AjouterBillet(int ClientProperty, int VolProperty, DateTime DateProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO Billet (user_id, vol_id, date) VALUES (@client, @vol, @date)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@client", ClientProperty);
            cmd.Parameters.AddWithValue("@vol", VolProperty);
            cmd.Parameters.AddWithValue("@date", DateProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierBillet(int IdBilletProperty, int ClientProperty, int VolProperty, DateTime DateProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `Billet` SET `user_id` = @client, `vol_id` = @vol, `date` = @date WHERE `Billet`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@client", ClientProperty);
            cmd.Parameters.AddWithValue("@vol", VolProperty);
            cmd.Parameters.AddWithValue("@date", DateProperty);
            cmd.Parameters.AddWithValue("@id", IdBilletProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }


        public static void SupprimerBillet(int idBillet)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM Billet WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idBillet);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
