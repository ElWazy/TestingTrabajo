using System;
using TestingTrabajo.Models;
using MySqlConnector;

namespace TestingTrabajo.Persistence
{
    class MariaDBEmployeeRepository : EmployeeRepository
    {
        private MySqlConnection connection = null;

        public MariaDBEmployeeRepository(string url)
        {
            connection = new MySqlConnection(url);
        }

        public string GetName()
        {
            return "MariaDB";
        }

        /**
         * ToDo: Falta agregar en el sql que se valide que el 
         * usuario es un panolero (cuando hayan)
         */
        public Employee Login(string email, string passwd)
        {
            string sql = @"SELECT 
                            employee.uuid,
                            employee.rut,
                            employee.first_name,
                            employee.last_name,
                            employee.email,
                            employee.passwd,
                            employee.birth_date,
                            employee.salary,
                            employee.profile_id_fk
                        FROM employee
                        INNER JOIN profile ON employee.profile_id_fk = profile.uuid
                        WHERE employee.rut = @rut AND employee.passwd = @passwd AND profile.name = 'panolero'
                        LIMIT 1";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@rut", email);
            command.Parameters.AddWithValue("@passwd", passwd);
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            return new Employee(reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetInt32(7),
                            reader.GetString(8));
        }

        public void Register(Employee employee)
        {
            string sql = @"INSERT INTO employee VALUES 
                        (@uuid, 
                        @rut,
                        @first_name,
                        @last_name,
                        @email,
                        @passwd,
                        @birth_date,
                        @salary,
                        @profile_id_fk)";

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uuid", Employee.GenerateUUID());
            command.Parameters.AddWithValue("@rut", employee.GetRut());
            command.Parameters.AddWithValue("@first_name", employee.GetFirstName());
            command.Parameters.AddWithValue("@last_name", employee.GetLastName());
            command.Parameters.AddWithValue("@email", employee.GetEmail());
            command.Parameters.AddWithValue("@passwd", employee.GetPasswd());
            command.Parameters.AddWithValue("@birth_date", employee.GetBirthDate());
            command.Parameters.AddWithValue("@salary", employee.GetSalary());
            command.Parameters.AddWithValue("@profile_id_fk", employee.GetProfile());
            command.Prepare();

            command.ExecuteNonQuery();
        }
    }
}
