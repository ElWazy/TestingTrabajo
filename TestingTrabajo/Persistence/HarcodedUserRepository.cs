using System;
using TestingTrabajo.Models;

namespace TestingTrabajo.Persistence
{
    class HarcodedUserRepository : UserRepository
    { 
        public string GetName()
        {
            return "Harcoded";
        }

        public User login(string username, string password)
        {
            if (username.Equals("Master") && password.Equals("1324"))
            {
                return new User("1111-1111-1111-1111", "Gumersindo Casanueva");
            }

            return null;
        }
    }
}
