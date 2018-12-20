﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class
{
    class DAO_Avion
    {
        private BDD bdd = new BDD();

        public List<string[]> SelectAvions()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_avion = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from avion";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str_avion = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2) + ";" + reader.GetString(3) + ";" + reader.GetString(4)
                        + ";" + reader.GetString(5) + ";" + reader.GetString(6);
                    results.Add(str_avion.Split(';'));
                }
            }

            bdd.connection.Close();

            return results;

        }
    }
}