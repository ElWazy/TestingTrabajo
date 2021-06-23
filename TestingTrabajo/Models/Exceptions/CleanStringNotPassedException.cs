using System;

namespace TestingTrabajo.Models
{
    class CleanStringNotPassedException : Exception
    {
        public CleanStringNotPassedException(string message) : base(message)
        {
        }
    }
}
