using Infrastructure.Models;
using Infrastructure.Selectors;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Infrastructure.Handlers
{
    public abstract class HandlerBase
    {
        private readonly IWebDriver _webDriver;
        private readonly ILoginSelectors _loginSelectors;
        private readonly IJavaScriptExecutor jsExecutor;
        protected ProfileConditions ProfileConditions { get; private set; }

        protected HandlerBase(
                      IWebDriver webDriver,
                      ILoginSelectors loginSelectors)
        {
            _webDriver = webDriver ??
                throw new ArgumentNullException(nameof(webDriver));

            _loginSelectors = loginSelectors ??
                throw new ArgumentNullException(nameof(loginSelectors));

            jsExecutor = (IJavaScriptExecutor)_webDriver;
        }

        #region Public methods
        public abstract void SetLocalization();
        public abstract void SearchFromEncounters();
        public abstract void SearchFromPeopleNearby();
        public void Login(LoginData loginData)
        {
            GoToUrl(loginData.SignInUrl);

            WaitSeconds(3);

            _webDriver.FindElement(_loginSelectors.Email)
                      .SendKeys(loginData.Email);

            _webDriver.FindElement(_loginSelectors.Password)
                      .SendKeys(loginData.Password);

            _webDriver.FindElement(_loginSelectors.LoginBtn)
                      .Click();
        }

        public void SetProfileConditions(ProfileConditions profileConditions)
        {
            ProfileConditions = profileConditions ??
                throw new ArgumentNullException(nameof(profileConditions));
        }

        #endregion

        #region Protected Methods

        protected abstract void OpenProfile();
        protected abstract void ClickLikeBtn();
        protected abstract void ClickDislikeBtn();

        protected void Click(By selector, int withInterval = 3)
        {
            try
            {
                _webDriver.FindElement(selector)
                          .Click();
            }
            catch (NoSuchElementException)
            {
                WaitSeconds(withInterval);

                _webDriver.FindElement(selector)
                          .Click();
            }
            catch (WebDriverException)
            {

            }
        }

        protected void JSClick(string querySelector)
        {
            jsExecutor.ExecuteScript($"document.querySelector('{querySelector}').click();");
        }

        protected void GoToUrl(string url)
        {
            _webDriver.Navigate()
                      .GoToUrl(url);
        }

        protected void CheckProfile(ProfileConditions profileConditions)
        {
            if (profileConditions == null)
            {
                throw new ArgumentNullException(nameof(profileConditions));
            }

            foreach (var condition in profileConditions.OnlyConditions)
            {
                _webDriver.FindElement(condition.Value);
            }

            foreach (var condition in profileConditions.OrConditions)
            {
                try
                {
                    _webDriver.FindElement(condition.Value1);
                }
                catch (NoSuchElementException)
                {
                    _webDriver.FindElement(condition.Value2);
                }
            }
        }

        protected IEnumerable<string> ExtractHrefsFromAnchors(By anchorSelector)
        {
            var anchors = _webDriver.FindElements(anchorSelector);

            var hrefs = anchors.Select(e => e.GetAttribute("href"));

            return hrefs;
        }

        protected void WaitSeconds(int count)
        {
            Thread.Sleep(count * 1000);
        }

        #endregion
    }
}
