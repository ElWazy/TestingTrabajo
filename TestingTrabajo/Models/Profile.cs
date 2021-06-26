using System;

namespace TestingTrabajo.Models
{
    class Profile
    {
        private string uuid;
        private string name;

        public Profile(string uuid, string name)
        {
            this.uuid = uuid;
            this.name = name;
        }
        
        public override string ToString()
        {
            return String.Format("Profile {UUID: %s, Name: %s}", uuid, name);
        }
    }
}
