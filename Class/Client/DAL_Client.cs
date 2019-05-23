using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Client
{
    class DAL_Client
    {      
        private static BDD bdd = new BDD();


        public static ObservableCollection<Client> SelectClients()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            bdd.OpenConnection();
            string query = "SELECT * FROM client;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client(reader.GetInt32(0), reader.GetString(1),reader.GetBoolean(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                clients.Add(client);
            }
            reader.Close();
            bdd.CloseConnection();
            return clients;
        }

        public static List<string> SelectNomClients()
        {
            List<string> clients = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM client;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                clients.Add(client.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return clients;
        }

        public static Client GetClient(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM client WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Client client = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
            reader.Close();
            bdd.CloseConnection();
            return client;
        }

        public static void AjouterClient(string MailProperty, bool CiviliteProperty, int FideliteProperty, string UsernameProperty, string FirstnameProperty, string PasswordProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO client (mail, civilite, fidelite, user_name, first_name, password) VALUES (@mail, @civilite, @fidelite, @username, @firstname, @password)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@mail", MailProperty);
            cmd.Parameters.AddWithValue("@civilite", CiviliteProperty);
            cmd.Parameters.AddWithValue("@fidelite", FideliteProperty);
            cmd.Parameters.AddWithValue("@username", UsernameProperty);
            cmd.Parameters.AddWithValue("@firstname", FirstnameProperty);
            cmd.Parameters.AddWithValue("@password", PasswordProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierClient(int IdClientProperty, string MailProperty, bool CiviliteProperty, int FideliteProperty, string UsernameProperty, string FirstnameProperty, string PasswordProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `client` SET `mail` = @mail, `civilite` = @civilite, `fidelite` = @fidelite, `user_name` = @username, `first_name` = @firstname, `password` = @password WHERE `client`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@mail", MailProperty);
            cmd.Parameters.AddWithValue("@civilite", CiviliteProperty);
            cmd.Parameters.AddWithValue("@fidelite", FideliteProperty);
            cmd.Parameters.AddWithValue("@username", UsernameProperty);
            cmd.Parameters.AddWithValue("@firstname", FirstnameProperty);
            cmd.Parameters.AddWithValue("@password", PasswordProperty);
            cmd.Parameters.AddWithValue("@id", IdClientProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }


        public static void SupprimerClient(int idClient)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM client WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idClient);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}

