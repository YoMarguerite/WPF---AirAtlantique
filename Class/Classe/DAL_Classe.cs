using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Classe
{
    class DAL_Classe
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<Classe> SelectClasses()
        {
            ObservableCollection<Classe> Classes = new ObservableCollection<Classe>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Classe;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Classe Classe = new Classe(reader.GetInt32(0), reader.GetString(1));
                Classes.Add(Classe);
            }
            reader.Close();
            bdd.CloseConnection();
            return Classes;
        }

        public static List<string> SelectNomClasses()
        {
            List<string> Classes = new List<string>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Classe;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Classe Classe = new Classe(reader.GetInt32(0), reader.GetString(1));
                Classes.Add(Classe.Nom);
            }
            reader.Close();
            bdd.CloseConnection();
            return Classes;
        }

        public static Classe GetClasse(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM Classe WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Classe Classe = new Classe(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            bdd.CloseConnection();
            return Classe;
        }
        
        public static Classe FindByName(string nom)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM classe WHERE classe = @nom;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            Classe classe = null;
            if (reader.HasRows)
            {
                reader.Read();
                classe = new Classe(reader.GetInt32(0), reader.GetString(1));
                reader.Close();
            }
            bdd.CloseConnection();
            return classe;
        }
    }
}
