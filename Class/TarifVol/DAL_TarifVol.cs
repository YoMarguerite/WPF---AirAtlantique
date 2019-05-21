using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.TarifVol
{
    class DAL_TarifVol
    {
        private static BDD bdd = new BDD();


        public static ObservableCollection<TarifVol> SelectTarifVols()
        {
            ObservableCollection<TarifVol> TarifVols = new ObservableCollection<TarifVol>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Tarif_Vol;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TarifVol TarifVol = new TarifVol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3));
                TarifVols.Add(TarifVol);
            }
            reader.Close();
            bdd.CloseConnection();
            return TarifVols;
        }

        public static ObservableCollection<TarifVol> SelectTarifVolsByVol(int vol)
        {
            ObservableCollection<TarifVol> TarifVols = new ObservableCollection<TarifVol>();
            bdd.OpenConnection();
            string query = "SELECT * FROM Tarif_Vol Where vol_id = @vol;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@vol", vol);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TarifVol TarifVol = new TarifVol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3));
                TarifVols.Add(TarifVol);
            }
            reader.Close();
            bdd.CloseConnection();
            return TarifVols;
        }

        public static TarifVol GetTarifVol(int id)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM Tarif_Vol WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            TarifVol TarifVol = new TarifVol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3));
            reader.Close();
            bdd.CloseConnection();
            return TarifVol;
        }
        
        public static void AjouterTarifVol(int TarifProperty, int VolProperty, float PrixProperty)
        {
            bdd.OpenConnection();
            string query = "INSERT INTO Tarif_Vol (tarif_id, vol_id, prix) VALUES (@tarif, @vol, @prix)";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@tarif", TarifProperty);
            cmd.Parameters.AddWithValue("@vol", VolProperty);
            cmd.Parameters.AddWithValue("@prix", PrixProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }

        public static void ModifierTarifVol(int IdTarifVolProperty, int TarifProperty, int VolProperty, float PrixProperty)
        {
            bdd.OpenConnection();
            string query = "UPDATE `Tarif_Vol` SET `tarif_id` = @tarif, `vol_id` = @vol, `prix` = @prix WHERE `Tarif_Vol`.`id` = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@tarif", TarifProperty);
            cmd.Parameters.AddWithValue("@vol", VolProperty);
            cmd.Parameters.AddWithValue("@prix", PrixProperty);
            cmd.Parameters.AddWithValue("@id", IdTarifVolProperty);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }


        public static void SupprimerTarifVol(int idTarifVol)
        {
            bdd.OpenConnection();
            string query = "DELETE FROM Tarif_Vol WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@id", idTarifVol);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            bdd.CloseConnection();
        }
    }
}
