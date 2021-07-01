using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTrabajo.Models
{
    class Tool
    {

        private string uuid;
        private string name;
        private int category_id_fk;
        private int stock;
        private int real_stock;

        public string Uuid { set => uuid = value; }
        public string Name { get => name; set => name = value; }
        public int Category_id_fk { get => category_id_fk; set => category_id_fk = value; }
        public int Stock { set => stock = value; }
        public int Real_stock { set => real_stock = value; }

        public Tool(string uuid, string name, int category_id_fk, int stock, int real_stock)
        {
            this.uuid = ValidateUUID(uuid);
            this.name = name;
            this.category_id_fk = category_id_fk;
            this.stock = ValidateStock(stock);
            this.real_stock = ValidateRealStock(real_stock);
        }

        private string ValidateUUID(string uuid)
        {
            if (!uuid.Contains("-"))
            {
                throw new ArgumentException("Invalid uuid");
            }

            return uuid;
        }

        private int ValidateStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentException("Negative Stock!!");
            }

            return stock;
        }


        private int ValidateRealStock(int real_stock)
        {
            if (real_stock < 0)
            {
                throw new ArgumentException("Negative real_stock!!");
            }

            return real_stock;
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
            return "Tool {uuid: " + uuid 
                + ", name: " + name 
                + ", category_id_fk: " + category_id_fk 
                + ", stock: " + stock 
                + ", real_stock: " + real_stock 
                + "}";
        }
    }
}
