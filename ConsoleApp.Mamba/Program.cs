using Functional;
using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Logging;
using Infrastructure.Logging.Implementation;
using Infrastructure.Models;
using Infrastructure.Models.Errors;
using System;
using Utils;

namespace ConsoleApp.Mamba
{
    class Program
    {
        private static ILogger Logger { get; } = new Logger();

        static void Main(string[] args)
        {
            var message =

                ConfigReader.ReadCredentials()
                            .Map(credentials =>
                            {
                                var loginData = new LoginData("https://www.mamba.ru/login", credentials);
                                var dialogResult = ConsoleAppHelper.RunDialog();
                                var executor = new HandlersExecutor(Logger);

                                return executor.RunMambaHandler(dialogResult, loginData)
                                               .Map(handlerMessage => handlerMessage)
                                               .Reduce(error => error.Message, error => error is FileDoesNotContainInfo)
                                               .Reduce(error => error.Message, error => error is FileNotFound);
                            })
                            .Reduce(error => error.Message, error => error is FileDoesNotContainInfo)
                            .Reduce(error => error.Message, error => error is FileNotFound)
                            .Reduce(_ => "There was a problem with this application. Please contact support.");

            Console.WriteLine(message);
        }
    }
}
