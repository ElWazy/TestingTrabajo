using System;
using TestingTrabajo.Models.Exceptions;

namespace TestingTrabajo.Models
{
    class Login
    {
        private User user = null;

        public Login(UserRepository userRepo, string username, string password)
        {
            user = userRepo.login(
                CleanString(username),
                CleanString(password)
            );

            if ( user == null)
            {
                throw new UserNotFoundException("User Not Found in " + userRepo.GetName());
            }
        }

        public User pushUser()
        {
            return user;
        }

        private string CleanString(string data)
        {
            string cleanData = data.Trim();

            if ( String.IsNullOrEmpty(cleanData) )
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
    }
}
