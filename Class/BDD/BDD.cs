using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class BDD
    {
        public MySqlConnection connection;

        // Constructeur
        public BDD()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=127.0.0.1; DATABASE=bdd; UID=root; PASSWORD=sohcahtoa";
            this.connection = new MySqlConnection(connectionString);
        }

        // Méthode pour ajouter un contact
        
    }
}
