using System;

namespace Infrastructure.Models
{
    public class LoginData
    {
        public string SignInUrl { get; }
        public Credentials Credentials { get; }

        public LoginData(
                    string signInUrl,
                    Credentials credentials)
        {
            if (string.IsNullOrEmpty(signInUrl))
                throw new ArgumentException(nameof(signInUrl));

            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            SignInUrl = signInUrl;
            Credentials = credentials;
        }
    }
}
