using System;

namespace TestingTrabajo.Models
{
    interface EmployeeRepository
    {
        string GetName();
        Employee Login(string email, string password);
        void Register(Employee employee);
    }
}
