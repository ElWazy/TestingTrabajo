using System;
using TestingTrabajo.Models.Exceptions;

namespace TestingTrabajo.Models
{
    class Login
    {
        private Employee employee = null;

        public Login(EmployeeRepository employeeRepo, string email, string passwd)
        {
            employee = employeeRepo.Login(
                email,
                passwd
            );

            if ( employee == null)
            {
                throw new UserNotFoundException("User Not Found in " + employeeRepo.GetName());
            }
        }

        public Employee pushUser()
        {
            return employee;
        }

        
    }
}
