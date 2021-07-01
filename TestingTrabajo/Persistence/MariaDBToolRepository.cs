using System;
using TestingTrabajo.Models;
using MySqlConnector;
using System.Collections.Generic;

namespace TestingTrabajo.Persistence
{
    class MariaDBToolRepository : ToolRepository
    {

        private MySqlConnection connection = null;

        public MariaDBToolRepository(string url)
        {
            connection = new MySqlConnection(url);
        }

        public string getName()
        {
            return "MariaDB";
        }

        public List<Tool> GetAll()
        {
            string sql = @"SELECT 
                        uuid, 
                        name,
                        category_id_fk,
                        stock,
                        real_stock
                        FROM tool";

            connection.Open();

            List<Tool> tools = new List<Tool>();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Tool tool = new Tool(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4)
                    );
                tools.Add(tool);
            }
            connection.Close();

            return tools;
        }

        public Tool GetByUUID(string uuid)
        {
            string sql = @"SELECT 
                        uuid, 
                        name,
                        category_id_fk,
                        stock,
                        real_stock
                        FROM tool
                        WHERE uuid = @uuid";

            connection.Open();

            Tool tool = null;

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uuid", uuid);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tool = new Tool(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4)
                    );
            }
            connection.Close();

            return tool;
        }

        public Tool GetByName(string name)
        {
            string sql = @"SELECT 
                        uuid, 
                        name,
                        category_id_fk,
                        stock,
                        real_stock
                        FROM tool
                        WHERE name = @name";

            connection.Open();

            Tool tool = null;

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tool = new Tool(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4)
                    );
            }
            connection.Close();

            return tool;
        }

        public void Add(Tool tool)
        {
            string sql = @"INSERT INTO tool VALUES (@uuid, @name, @category_id_fk, @stock, @real_stock)";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uuid", tool.Uuid);
            command.Parameters.AddWithValue("@name", tool.Name);
            command.Parameters.AddWithValue("@category_id_fk", tool.Category_id_fk);
            command.Parameters.AddWithValue("@stock", tool.Stock);
            command.Parameters.AddWithValue("@real_stock", tool.Real_stock);
            command.Prepare();

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Tool tool)
        {
            string sql = @"UPDATE tool SET name=@name, category_id_fk=@category_id_fk, stock=@stock, real_stock=@real_stock WHERE uuid=@uuid";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", tool.Name);
            command.Parameters.AddWithValue("@category_id_fk", tool.Category_id_fk);
            command.Parameters.AddWithValue("@stock", tool.Stock);
            command.Parameters.AddWithValue("@real_stock", tool.Real_stock);
            command.Parameters.AddWithValue("@uuid", tool.Uuid);
            command.Prepare();

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
