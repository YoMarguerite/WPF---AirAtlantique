using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Billet
    {
        private BDD bdd = new BDD();

        public List<int[]> SelectBillets()
        {
            bdd.connection.Open();
            List<int[]> results = new List<int[]>();
            int[] billet = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from billet";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    billet = new int[4] { int.Parse(reader.GetString(0)), int.Parse(reader.GetString(1)), int.Parse(reader.GetString(2)), int.Parse(reader.GetString(3)) };
                    results.Add(billet);
                }
            }

            bdd.connection.Close();

            return results;
        }
    }
}
