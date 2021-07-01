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

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void Save(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
