using Infrastructure.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Infrastructure.Files
{
    public static class ConfigReader
    {
        private const string FileName = "credentials.ini";

        public static Credentials Credentials
        {
            get
            {
                string text;

                var invalidOperException = new InvalidOperationException($@"'{FileName}' file should contain your email and password of your dating website in such format:

                                                                                                                      email=my_email@gmail.com;  
                                                                                                                      password=my_passwd;");
                try
                {
                    text = File.ReadAllText(FileName);

                    if (string.IsNullOrEmpty(text))
                    {
                        throw invalidOperException;
                    }
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException($"'{FileName}' file should be placed where '.exe' file is situated.");
                }

                const string email_pattern = @"email=(.*?);";

                const string password_pattern = @"password=(.*?);";

                var email_match = Regex.Match(text, email_pattern, RegexOptions.IgnoreCase);

                var password_match = Regex.Match(text, password_pattern, RegexOptions.IgnoreCase);

                if (email_match.Success && password_match.Success)
                {
                    var email = email_match.Groups[1].Value;
                    var password = password_match.Groups[1].Value;
                    return new Credentials(email, password);
                }
                else
                {
                    throw invalidOperException;
                }
            }
        }
    }
}
