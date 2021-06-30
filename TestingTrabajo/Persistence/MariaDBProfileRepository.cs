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
            string sql = @"SELECT uuid, name FROM profile 
                        ORDER BY name ASC";

            List<Profile> employees = null;
            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            employees = new List<Profile>();
            while (reader.Read())
            {
                employees.Add(
                    new Profile(
                        reader.GetString(1), reader.GetString(2)
                        )
                    );
            }

            return employees;
        }
    }
}
