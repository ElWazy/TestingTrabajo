using System;
using TestingTrabajo.Models.Etc;

namespace TestingTrabajo.Models
{
    /**
     * Se esta agrandando mucho esta clase.
     * ToDo: Puede ser una excusa perfecta para usar
     * Value Objects.
     */
    class Employee
    {
        private string uuid;
        private string rut;
        private string firstName;
        private string lastName;
        private string email;
        private string passwd;
        private string date;
        private int salary;
        private string profile_id_fk;

        public Employee(string uuid,
                    string rut,
                    string firstName,
                    string lastName,
                    string email,
                    string passwd,
                    string date,
                    int salary,
                    string profile_id_fk)
        {
            this.uuid = ValidateUUID(uuid);
            this.rut = ValidateRut(rut);
            this.firstName = CleanString(firstName);
            this.lastName = CleanString(lastName);
            this.email = ValidateEmail(email);
            this.passwd = passwd;
            this.date = ValidateDate(date);
            this.salary = ValidateSalary(salary);
            this.profile_id_fk = profile_id_fk;
        }   

        private string ValidateUUID(string uuid)
        {
            if (!uuid.Contains("-"))
            {
                throw new ArgumentException("Invalid uuid");
            }

            return uuid;
        }

        private string ValidateRut(string rut)
        {
            return rut;
        }

        private string ValidateEmail(string email)
        {
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Invalid Email");
            }

            return email;
        }

        /**
         * ToDo: Aprender a usar un String formatter para 
         * validar que la fecha sea yyyy-mm-dd
         */
        private string ValidateDate(string date)
        {
            return date;
        }

        /**
         * ToDo: Crear Excepcion custom para el salary
         */
        private int ValidateSalary(int salary)
        {
            if (salary < 0)
            {
                throw new ArgumentException("Negative Salary!!");
            }

            return salary;
        }

        /**
         * ToDo: Se puede hacer iterable con una lista, para que procese varios datos de
         * una y no tener que estar llamando 1x1 los string del constructor
         */
        public string CleanString(string data)
        {
            string cleanData = data.Trim();

            if (String.IsNullOrEmpty(cleanData))
            {
                throw new CleanStringNotPassedException("Data is null or empty");
            }

            foreach (char letter in cleanData)
            {
                if (!Char.IsLetterOrDigit(letter))
                {
                    throw new CleanStringNotPassedException("Data contains not valid character");
                }
            }

            return cleanData;
        }

        public string GetRut()
        {
            return rut;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetPasswd()
        {
            return passwd;
        }

        public string GetBirthDate()
        {
            return date;
        }

        public int GetSalary()
        {
            return salary;
        }

        public string GetProfile()
        {
            return profile_id_fk;
        }

        public static string GenerateUUID()
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }

        public static string GeneratePassword(string passwd)
        {
            return Encrypt.GetSHA256(passwd);
        }

        public override string ToString()
        {
            return String.Format("User {UUID: %s, Name: %s}");
        }
    }
}
