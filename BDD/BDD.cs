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
            string server = "localhost";
            string database = "airatlantique";
            string uid = "root";
            string password = "sohcahtoa";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
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
