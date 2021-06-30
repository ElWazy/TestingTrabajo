using System;

namespace TestingTrabajo.Models
{
    class Profile
    {
        private string uuid;
        private string name;

        public Profile(string uuid, string name)
        {
            this.uuid = uuid;
            this.name = CleanString(name);
        }

        public string GetUuid()
        {
            return uuid;
        }

        public string GetName()
        {
            return name;
        }

        private string CleanString(string data)
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
            return "Profile {UUID: " + uuid + ", Name: " + name + "}";
        }
    }
}
