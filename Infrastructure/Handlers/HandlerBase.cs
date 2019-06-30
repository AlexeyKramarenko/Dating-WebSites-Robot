using Infrastructure.Models;
using Infrastructure.Selectors;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Infrastructure.Handlers
{
    public abstract class HandlerBase
    {
        private readonly IWebDriver _webDriver;
        private readonly ILoginSelectors _loginSelectors;
        private readonly IJavaScriptExecutor jsExecutor;

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

        public abstract void SearchFromEncounters();
        public abstract void SearchFromPeopleNearby();
        public virtual void Login(LoginData loginData)
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

        #endregion

        #region Protected Methods

        protected abstract void OpenProfile();
        protected abstract void ClickLikeBtn();
        protected abstract void ClickDislikeBtn();

        protected void Click(By selector)
        {
            _webDriver.FindElement(selector)
                      .Click();
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

        protected virtual void CheckProfile(ProfileConditions profileConditions)
        {
            if (profileConditions == null)
            {
                throw new ArgumentNullException(nameof(profileConditions));
            }

            foreach (var condition in profileConditions.SingleConditions)
            {
                _webDriver.FindElement(condition.Value);
            }

            foreach (var condition in profileConditions.PairConditions)
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

        protected void WaitSeconds(int count)
        {
            Thread.Sleep(count * 1000);
        }

        #endregion
    }
}
