using System;

namespace Infrastructure.Models
{
    public class LoginData
    {
        public string SignInUrl { get; }
        public string Email { get; }
        public string Password { get; }

        public LoginData(
                    string signInUrl,
                    string email,
                    string password)
        {
            if (string.IsNullOrEmpty(signInUrl))
                throw new ArgumentException(nameof(signInUrl));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            SignInUrl = signInUrl;
            Email = email;
            Password = password;
        }
    }
}
