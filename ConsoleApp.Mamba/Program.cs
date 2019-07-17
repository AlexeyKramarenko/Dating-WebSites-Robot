using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Logging;
using Infrastructure.Logging.Implementation;
using Infrastructure.Models;
using System;
using System.IO;
using Utils;

namespace ConsoleApp.Mamba
{
    class Program
    {
        private static ILogger Logger { get; } = new Logger();

        static void Main(string[] args)
        {
            var dialogResult = ConsoleAppHelper.RunDialog();

            try
            {
                var loginData = new LoginData("https://www.mamba.ru/login", ConfigReader.Credentials);

                var executor = new HandlersExecutor(Logger);

                executor.RunBadooHandler(dialogResult, loginData);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);

                Console.WriteLine("There was a problem with this application. Please contact support.");
            }
        }
    }
}
