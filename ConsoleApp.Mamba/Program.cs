using Infrastructure;
using Infrastructure.Models;
using Utils;

namespace ConsoleApp.Mamba
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogResult = ConsoleAppHelper.RunDialog();

            var loginData = new LoginData(signInUrl: "https://www.mamba.ru/login",
                                          email: "***",
                                          password: "***");

            var executor = new HandlersExecutor();

            executor.RunMambaHandler(dialogResult, loginData);
        }
    }
}
