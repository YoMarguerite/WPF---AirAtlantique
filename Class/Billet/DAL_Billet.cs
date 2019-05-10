using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Billet
{
    class DAL_Billet
    {
        private BDD bdd = new BDD();

        public void SelectBillets(List<Billet> billets)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from billet";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Billet billet = new Billet( reader.GetInt32(0) , reader.GetInt32(1) , reader.GetInt32(2) , reader.GetString(3));
                    billets.Add(billet);
                }
            }

            bdd.connection.Close();
        }
    }
}
