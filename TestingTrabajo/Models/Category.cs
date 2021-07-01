using System;

namespace TestingTrabajo.Models
{
    class Category
    {
        private string uuid;
        private string name;

        public Category(string uuid, string name)
        {
            this.uuid = ValidateUUID(uuid);
            this.name = CleanString(name);
        }

        public string UUID
        {
            get { return uuid; }
        }

        public string Name
        {
            get { return name; }
        }

        private string ValidateUUID(string uuid)
        {
            if (!uuid.Contains("-"))
            {
                throw new ArgumentException("Invalid uuid");
            }

            return uuid;
        }

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
        
        public static string GenerateUUID()
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }

        public override string ToString()
        {
            return "Category {uuid: " + uuid 
                + ", name: " + name 
                + "}";
        }
    }
}
