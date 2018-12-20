using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Tarif
    {
        private BDD bdd = new BDD();

        public List<string[]> SelectTarifs()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_tarif = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from tarif";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_tarif = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2);
                    results.Add(str_tarif.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;
        }
    }
}
