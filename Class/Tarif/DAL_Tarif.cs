using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Class.Classe;

namespace WpfApp1.Class.Tarif
{
    class DAL_Tarif
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Tarif> SelectTarifs()
        {
            ObservableCollection<Tarif> Tarifs = new ObservableCollection<Tarif>();
            bdd.OpenConnection();
            string query = "SELECT * FROM tarif;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tarif Tarif = new Tarif(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                Tarifs.Add(Tarif);
            }
            reader.Close();
            bdd.CloseConnection();
            return Tarifs;
        }

        public static List<string> SelectNomTarifs()
        {
            List<string> Tarifs = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM tarif;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tarif Tarif = new Tarif(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                Tarifs.Add(Tarif.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return Tarifs;
        }

        public static List<string> SelectNomTarifsWithClasse()
        {
            List<string> Tarifs = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM tarif;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tarif Tarif = new Tarif(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                Tarifs.Add(DAL_Classe.GetClasse(Tarif.Classe) + " - " + Tarif.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return Tarifs;
        }

        public static List<string> SelectNomTarifsByClasse(int classe)
        {
            List<string> Tarifs = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM tarif Where classe_id = @classe;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@classe", classe);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tarif Tarif = new Tarif(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                Tarifs.Add(Tarif.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return Tarifs;
        }

        public static Tarif GetTarif(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM tarif WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Tarif Tarif = new Tarif(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
            reader.Close();
            bdd.CloseConnection();
            return Tarif;
        }

        public static Tarif FindByNameAndClasse(int classe, string nom)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM tarif WHERE classe_id = @classe and tarif = @nom;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@classe", classe);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Tarif Tarif = new Tarif(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
            reader.Close();
            bdd.CloseConnection();
            return Tarif;
        }
    }
}
