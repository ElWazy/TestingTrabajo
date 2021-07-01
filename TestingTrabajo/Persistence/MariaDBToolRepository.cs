﻿using System;
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
            throw new NotImplementedException();
        }

        public Tool GetByUUID(string uuid)
        {
            throw new NotImplementedException();
        }

        public Tool GetByName(string name)
        {
            throw new NotImplementedException();
        }


        public void Add(Tool tool)
        {
            throw new NotImplementedException();
        }

        public void Update(Tool tool)
        {
            throw new NotImplementedException();
        }
    }
}
