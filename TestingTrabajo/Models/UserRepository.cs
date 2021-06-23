using System;

namespace TestingTrabajo.Models
{
    interface UserRepository
    {
        User login(string username, string password);
    }
}
