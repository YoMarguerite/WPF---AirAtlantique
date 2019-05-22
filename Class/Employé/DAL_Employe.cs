using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace WpfApp1.Class.Employe
{
    class DAL_Employe
    {
        private static BDD bdd = new BDD();
        

        public static Employe GetEmploye(string mail, string mdp)
        {
            bdd.OpenConnection();
            string query = "SELECT * FROM Employe WHERE mail = @mail;";
            MySqlCommand cmd = new MySqlCommand(query, bdd.GetConnection());
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Employe employe = null;
            if (reader.HasRows)
            {
                if (BCrypt.Net.BCrypt.Verify(mdp, reader.GetString(4)))
                {
                    employe = new Employe(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetBoolean(5), reader.GetString(6));
                }
            }
            reader.Close();
            bdd.CloseConnection();
            return employe;
        }
    }
}
