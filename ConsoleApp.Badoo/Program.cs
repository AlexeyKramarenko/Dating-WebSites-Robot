using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Models;
using System;
using Utils;

namespace ConsoleApp.Badoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogResult = ConsoleAppHelper.RunDialog();

            try
            {
                var loginData = new LoginData("https://badoo.com/signin/", ConfigReader.Credentials);

                var executor = new HandlersExecutor();

                executor.RunBadooHandler(dialogResult, loginData);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}