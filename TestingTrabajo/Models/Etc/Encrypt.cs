﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace TestingTrabajo.Models.Etc
{
    class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = null;

            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) 
                sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}