using Infrastructure.Handlers;
using Infrastructure.Models;
using Infrastructure.Selectors.Navigation;
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

            var webDriver = WebDriverFactory.Create();

            HandlerBase handler = new MambaHandler(webDriver, new MambaNavigationSelectors());

            handler.Login(loginData);

            handler.SetLocalization();

            var requirements = handler.BuildProfileRequirements(dialogResult);

            handler.SetProfileRequirements(requirements);

            if (dialogResult.Search == Search.Encounters)
            {
                handler.SearchFromEncounters();
            }
            else
            {
                handler.SearchFromPeopleNearby();
            }
        }
    }
}
