using System;

namespace TestingTrabajo.Models.Exceptions
{
    class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
