using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Models;
using System;
using Utils;

namespace ConsoleApp.Mamba
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogResult = ConsoleAppHelper.RunDialog();

            try
            {
                var loginData = new LoginData("https://www.mamba.ru/login", ConfigReader.Credentials);

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
