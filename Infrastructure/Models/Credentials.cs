using System;

namespace Infrastructure.Models
{
    public class Credentials
    {
        public string Email { get; }
        public string Password { get; }

        public Credentials(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            Email = email;
            Password = password;
        }
    };
}
