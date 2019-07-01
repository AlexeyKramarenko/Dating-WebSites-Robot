using Infrastructure;
using Infrastructure.Models;
using Utils;

namespace ConsoleApp.Badoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogResult = ConsoleAppHelper.RunDialog();

            var loginData = new LoginData(signInUrl: "https://badoo.com/signin/",
                                          email: "***",
                                          password: "***");

            var executor = new HandlersExecutor();

            executor.RunBadooHandler(dialogResult, loginData);
        }
    }
}