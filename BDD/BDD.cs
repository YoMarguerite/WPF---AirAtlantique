using System;
using System.Configuration;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class BDD
    {
        public MySqlConnection connection;

        // Constructeur
        public BDD()
        {
            this.InitConnection();
        }


        //Initialisation de la connexion à la base de données
        public void InitConnection()
        {
            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["prod"].ConnectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Getter de la connexion
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        //Ouvre la connexion à la base de données
        public bool OpenConnection()
        {
            try
            {
                this.connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Ferme la connexion à la base de données
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
