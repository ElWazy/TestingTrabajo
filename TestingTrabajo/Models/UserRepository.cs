using System;

namespace TestingTrabajo.Models
{
    interface UserRepository
    {
        string GetName();
        User login(string username, string password);
    }
}
