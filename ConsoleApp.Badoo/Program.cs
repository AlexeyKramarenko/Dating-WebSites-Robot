using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Models;
using System;
using System.IO;
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
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("There was a problem with this application. Please contact support.");
            }
        }
    }
}