using System;

namespace TestingTrabajo.Models
{
    interface EmployeeRepository
    {
        string GetName();
        Employee Login(string email, string password);
        bool Register(Employee employee);
    }
}
