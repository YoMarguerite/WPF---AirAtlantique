using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class
{
    class DAO_Vol
    {
        private BDD bdd = new BDD();


        public int InsertVol(string depart, string arrive, int idavion, int idtrajet)
        {
            // Ouverture de la connexion SQL
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO vol (trajet, depart, arrive, avion) " +
                "VALUES (@trajet, @depart, @arrive, @avion); SELECT @@Identity as Id";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@trajet", idtrajet);
            cmd.Parameters.AddWithValue("@depart", depart);
            cmd.Parameters.AddWithValue("@arrive", arrive);
            cmd.Parameters.AddWithValue("@avion", idavion);

            // Exécution de la commande SQL
            object reader = cmd.ExecuteScalar();

            // Fermeture de la connexion
            bdd.connection.Close();

            return int.Parse(reader.ToString());
        }


        public List<string[]> SelectVols()
        {
            bdd.connection.Open();
            List<string[]> results = new List<string[]>();
            string str_vol = null;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from vol";

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


        public List<double[]> SelectTarifs()
        {
            bdd.connection.Open();
            List<double[]> results = new List<double[]>();
            double[] tarif;

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * from vol_has_tarif";

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tarif = new double[3] { int.Parse(reader.GetString(0)), int.Parse(reader.GetString(1)), double.Parse(reader.GetString(2)) };
                    results.Add(tarif);
                }
            }

            bdd.connection.Close();

            return results;
        }


        public void UpdateVolTrajet(int id, int idtrajet)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET trajet = @Str WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@Str", idtrajet);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }


        public void UpdateVolDepart(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET depart = @Str WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }


        public void UpdateVolArrive(int id, string str)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET arrive = @Str WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@Str", str);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }


        public void UpdateVolAvion(int id, int idavion)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE vol SET avion = @avion WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@avion", idavion);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }


        public void Delete(int id)
        {
            bdd.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = bdd.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "DELETE FROM vol WHERE idvol=@id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            bdd.connection.Close();
        }
    }
}
