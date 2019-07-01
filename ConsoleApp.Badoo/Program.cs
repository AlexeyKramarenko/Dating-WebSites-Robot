using Infrastructure.Handlers;
using Infrastructure.Models;
using Infrastructure.Selectors.Navigation;
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

            var webDriver = WebDriverFactory.Create();

            HandlerBase handler = new BadooHandler(webDriver, new BadooNavigationSelectors());

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