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

            List<Profile> profiles = new List<Profile>();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Profile profile = new Profile(
                    reader.GetString(0),
                    reader.GetString(1)
                    );
                profiles.Add(profile);
            }
            connection.Close();

            return profiles;
        }

        public bool Save(Profile profile)
        {
            string sql = @"INSERT INTO profile VALUES (@uuid, @name)";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uuid", profile.GetUuid());
            command.Parameters.AddWithValue("@name", profile.GetName());
            command.Prepare();

            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}
