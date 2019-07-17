using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Logging;
using Infrastructure.Logging.Implementation;
using Infrastructure.Models;
using System;
using System.IO;
using Utils;

namespace ConsoleApp.Badoo
{
    class Program
    {
        private static ILogger Logger { get; } = new Logger();

        static void Main(string[] args)
        {
            var dialogResult = ConsoleAppHelper.RunDialog();

            try
            {
                var loginData = new LoginData("https://badoo.com/signin/", ConfigReader.Credentials);

                var executor = new HandlersExecutor(Logger);

                executor.RunBadooHandler(dialogResult, loginData);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);

                Console.WriteLine("There was a problem with this application. Please contact support.");
            }
        }
    }
}