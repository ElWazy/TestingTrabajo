using System;
using MySqlConnector;
using System.Collections.Generic;
using TestingTrabajo.Models;

namespace TestingTrabajo.Persistence
{
    class MariaDBProfileRepository : ProfileRepository
    {
        private MySqlConnection connection = null;

        public MariaDBProfileRepository(string url)
        {
            connection = new MySqlConnection(url);
        }

        public List<Profile> GetAll()
        {
            string sql = @"SELECT uuid, name FROM profile";
            
            connection.Open();

            List<Profile> employees = null;

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            employees = new List<Profile>();
            while (reader.Read())
            {
                employees.Add(
                    new Profile(
                        reader.GetString(1), reader.GetString(2)
                        )
                    );
            }
            connection.Close();

            return employees;
        }

        public bool Save(Profile profile)
        {
            string sql = @"INSERT INTO profile VALUES (@uuid, @name)";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uuid", profile.GetUuid());
            command.Parameters.AddWithValue("@name", profile.GetName());
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();
            connection.Close();

            return true;
        }
    }
}
