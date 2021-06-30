using System;
using TestingTrabajo.Models;
using MySqlConnector;

namespace TestingTrabajo.Persistence
{
    class MariaDBToolRepository : ToolRepository
    {

        private MySqlConnection connection = null;

        public MariaDBToolRepository(string url)
        {
            connection = new MySqlConnection(url);
        }




        public Tool AddTool(string uuid, string name, int category_id_fk, int stock, int real_stock)
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            throw new NotImplementedException();
        }

        public Tool UpdateTool(string uuid, string name, int category_id_fk, int stock, int real_stock)
        {
            throw new NotImplementedException();
        }
    }
}
