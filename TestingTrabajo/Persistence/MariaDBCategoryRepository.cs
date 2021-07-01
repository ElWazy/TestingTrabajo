using MySqlConnector;
using System;
using System.Collections.Generic;
using TestingTrabajo.Models;

namespace TestingTrabajo.Persistence
{
    class MariaDBCategoryRepository : CategoryRepository
    {
        private MySqlConnection connection = null;

        public MariaDBCategoryRepository(string url)
        {
            connection = new MySqlConnection(url);
        }

        public string GetName()
        {
            return "MariaDB";
        }
        
        public List<Category> GetAll()
        {
            string sql = @"SELECT uuid, name FROM category ORDER BY name ASC";

            connection.Open();

            List<Category> categories = new List<Category>();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category(
                    reader.GetString(0),
                    reader.GetString(1)
                    );
                categories.Add(category);
            }
            connection.Close();

            return categories;
        }

        public Category GetByName(string name)
        {
            string sql = @"SELECT uuid, name FROM category WHERE name = @name";

            connection.Open();

            Category category = null;

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                category = new Category(
                    reader.GetString(0),
                    reader.GetString(1)
                    );
            }
            connection.Close();

            return category;
        }

        public void Save(Category category)
        {
            string sql = @"INSERT INTO category VALUES (@uuid, @name)";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uuid", category.UUID);
            command.Parameters.AddWithValue("@name", category.Name);
            command.Prepare();

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Category category)
        {
            string sql = @"UPDATE category SET name = @name WHERE uuid = @uuid";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", category.Name);
            command.Parameters.AddWithValue("@uuid", category.UUID);
            command.Prepare();

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
