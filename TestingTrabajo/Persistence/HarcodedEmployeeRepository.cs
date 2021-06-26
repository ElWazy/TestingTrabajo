using System;
using TestingTrabajo.Models;

namespace TestingTrabajo.Persistence
{
    class HarcodedEmployeeRepository : EmployeeRepository
    { 
        public string GetName()
        {
            return "Harcoded";
        }

        public Employee Login(string username, string password)
        {
            if (username.Equals("Master") && password.Equals("1324"))
            {
                return new Employee("1111-1111-1111-1111",
                                    "11222333-4",
                                    "Gumersindo",
                                    "Casanueva",
                                    "gurmendo@gmail.com",
                                    Employee.GeneratePassword("1324"),
                                    "1956-08-03",
                                    400000,
                                    "2222-2222-2222-2222");
            }

            return null;
        }
    }
}
