﻿using System;
using System.Security.Cryptography;
using System.Text;


namespace Bookshop
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        public static bool VerifyPassword(string password, string hashedPass)
        {
            string hashedInput = HashPassword(password);
            return string.Equals(hashedInput, hashedPass);
        }
    }

}
