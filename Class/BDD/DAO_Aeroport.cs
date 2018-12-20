using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class
{
    class DAO_Aeroport
    {
        private BDD bdd = new BDD();

        public List<string[]> SelectAeroports()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_vol = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from aeroport";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_vol = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4);
                    results.Add(str_vol.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;

        }
    }
}
