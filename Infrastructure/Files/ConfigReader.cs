using Infrastructure.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Functional;
using Infrastructure.Models.Errors;

namespace Infrastructure.Files
{
    public static class ConfigReader
    {
        private const string FileName = "credentials.ini";

        public static Either<Error, Credentials> ReadCredentials()
        {
            string text;

            try
            {
                text = File.ReadAllText(FileName);

                if (string.IsNullOrEmpty(text))
                {
                    return new FileDoesNotContainInfo(FileName);
                }
            }
            catch (FileNotFoundException)
            {
                return new FileNotFound(FileName);
            }

            var email = Validate(text, "email=(.*?);");

            var password = Validate(text, "password=(.*?);");

            if (email.Success && password.Success)
            {
                new Credentials(email.Result, password.Result);
            }

            return new FileDoesNotContainInfo(FileName);
        }

        #region Private Methods

        private static OperationResult Validate(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException(nameof(text));

            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException(nameof(pattern));

            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return OperationResult.Created(match.Groups[1].Value);
            }

            return OperationResult.Fail();
        }

        #endregion
    }
}
