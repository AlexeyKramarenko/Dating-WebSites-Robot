using Functional;
using Infrastructure.Handlers;
using Infrastructure.Handlers.Implementation;
using Infrastructure.Logging;
using Infrastructure.Models;
using Infrastructure.Models.Errors;
using Infrastructure.Selectors.Navigation.Implementation;
using System;
using Utils;

namespace Infrastructure
{
    public class HandlersExecutor
    {
        private readonly ILogger _logger;
        public HandlersExecutor(ILogger logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        public Either<Error, string> RunBadooHandler(
                                             DialogResult dialogResult,
                                             LoginData loginData)
        {
            var webDriver = WebDriverFactory.Create();

            var handler = new BadooHandler(webDriver, new BadooNavigationSelectors());

            Run(handler, dialogResult, loginData);

            return null;
        }

        public Either<Error, string> RunMambaHandler(
                                             DialogResult dialogResult,
                                             LoginData loginData)
        {
            var webDriver = WebDriverFactory.Create();

            var handler = new MambaHandler(webDriver, new MambaNavigationSelectors());

            Run(handler, dialogResult, loginData);

            return null;
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
                _logger.Log(Search.Encounters.LogInfo);

                handler.SearchFromEncounters();
            }
            else if (dialogResult.Search == Search.PeopleNearby)
            {
                _logger.Log(Search.PeopleNearby.LogInfo);

                handler.SearchFromPeopleNearby();
            }
        }

        #endregion
    }
}
