using Infrastructure.Handlers;
using Infrastructure.Models;
using Infrastructure.Selectors.Navigation;
using System;
using Utils;

namespace Infrastructure
{
    public class HandlersExecutor
    {
        public void RunBadooHandler(DialogResult dialogResult,
                                    LoginData loginData)
        {
            var webDriver = WebDriverFactory.Create();

            var handler = new BadooHandler(webDriver, new BadooNavigationSelectors());

            Run(handler, dialogResult, loginData);
        }

        public void RunMambaHandler(DialogResult dialogResult,
                                    LoginData loginData)
        {
            var webDriver = WebDriverFactory.Create();

            var handler = new MambaHandler(webDriver, new MambaNavigationSelectors());

            Run(handler, dialogResult, loginData);
        }

        #region Private Methods

        private void Run(HandlerBase handler,
                         DialogResult dialogResult,
                         LoginData loginData)
        {
            if (handler == null ||
                dialogResult == null ||
                loginData == null)
            {
                throw new ArgumentNullException();
            }

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

        #endregion
    }
}
