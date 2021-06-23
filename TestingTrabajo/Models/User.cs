using System;

namespace TestingTrabajo.Models
{
    class User
    {
        private string uuid;
        private string name;

        public User(string uuid, string name)
        {
            this.uuid = uuid;
            this.name = name;
        }

        public override string ToString()
        {
            return String.Format("User {UUID: %s, Name: %s}", uuid, name);
        }
    }
}
