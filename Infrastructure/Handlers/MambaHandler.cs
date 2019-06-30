using Infrastructure.Selectors.Navigation;
using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Threading;

namespace Infrastructure.Handlers
{
    public class MambaHandler : HandlerBase
    {
        private readonly IWebDriver _webDriver;
        private readonly MambaNavigationSelectors _selectors;

        public MambaHandler(
                     IWebDriver webDriver,
                     MambaNavigationSelectors selectors) : base(webDriver, selectors)
        {
            _webDriver = webDriver ??
                throw new ArgumentNullException(nameof(webDriver));

            _selectors = selectors ??
                throw new ArgumentNullException(nameof(selectors));
        }

        #region Public Methods

        public override void SearchFromEncounters()
        {
            while (true)
            {
                WaitSeconds(3);

                OpenProfile();

                WaitSeconds(4);

                GoToJustOpenedTab();

                try
                {
                    WaitSeconds(3);

                    CheckProfile(ProfileConditions);

                    CloseJustOpenedTab();

                    WaitSeconds(3);

                    ClickLikeBtn();
                }
                catch
                {
                    CloseJustOpenedTab();

                    WaitSeconds(2);

                    ClickDislikeBtn();
                }
            }
        }

        public override void SearchFromPeopleNearby()
        {
            throw new NotImplementedException();
        }

        public override void SetLocalization()
        {
            WaitSeconds(7);

            if (_webDriver.Title.Contains("Сеть знакомств Мамба"))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            }

            WaitSeconds(3);
        }

        #endregion

        #region Protected Methods

        protected override void ClickLikeBtn()
        {
            WaitSeconds(1);

            Click(_selectors.LikeBtn);
        }

        protected override void ClickDislikeBtn()
        {
            try
            {
                Click(_selectors.DislikeBtnRus);
            }
            catch (NoSuchElementException)
            {
                Click(_selectors.DislikeBtnEng);
            }
        }

        protected override void OpenProfile()
        {
            try
            {
                WaitSeconds(1);

                Click(_selectors.UserNameLink, 10);
            }
            catch (ElementNotInteractableException)
            {

            }
        }

        #endregion

        #region Private Methods

        private void GoToJustOpenedTab()
        {
            var browserTabs = _webDriver.WindowHandles;

            _webDriver.SwitchTo()
                      .Window(browserTabs[1]);
        }

        private void CloseJustOpenedTab()
        {
            _webDriver.Close();

            _webDriver.SwitchTo()
                      .Window(_webDriver.WindowHandles[0]);
        }

        #endregion
    }
}
