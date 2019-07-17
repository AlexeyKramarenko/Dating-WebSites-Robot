using Infrastructure.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Infrastructure.Files
{
    public static class ConfigReader
    {
        private const string FileName = "credentials.ini";

        private static string FileNotFoundMessage = $"'{FileName}' file should be placed where '.exe' file is situated.";

        private static string InvalidOperationMessage = $@"'{FileName}' file should contain your email and 
                                                           password of your dating website in such format:
                                                                       email=my_email@gmail.com;  
                                                                       password=my_passwd;";
        public static Credentials Credentials
        {
            get
            {
                string text;

                try
                {
                    text = File.ReadAllText(FileName);

                    if (string.IsNullOrEmpty(text))
                    {
                        throw new InvalidOperationException(InvalidOperationMessage);
                    }
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException(FileNotFoundMessage);
                }

                var email = Validate(text, "email=(.*?);");

                var password = Validate(text, "password=(.*?);");

                if (email.Success && password.Success)
                {
                    return new Credentials(email.Value, password.Value);
                }
                else
                {
                    throw new InvalidOperationException(InvalidOperationMessage);
                }
            }
        }

        #region Private Methods

        private static (bool Success, string Value) Validate(string text, string pattern)
        {
            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            string Value = null;

            if (match.Success)
            {
                Value = match.Groups[1].Value;
            }

            return (match.Success, Value);
        }

        #endregion
    }
}
