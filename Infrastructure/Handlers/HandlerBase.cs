using Infrastructure.Models;
using Infrastructure.Requirements;
using Infrastructure.Selectors;
using Localization;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Infrastructure.Handlers
{
    public abstract class HandlerBase
    {
        private ProfileRequirements _profileRequirements;
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

        public void SetProfileRequirements(ProfileRequirements requirements)
        {
            _profileRequirements = requirements ??
                throw new ArgumentNullException(nameof(requirements));
        }

        public ProfileRequirements BuildProfileRequirements(DialogResult dialogResult)
        {
            var requirementsBuilder = CreateRequirementsBuilder(dialogResult.Sex);

            if (dialogResult.IsFree)
            {
                requirementsBuilder.IncludeFreeRelationshipStatus();
            }

            if (dialogResult.DoesntHaveKids)
            {
                requirementsBuilder.IncludeAbsenceOfKids();
            }

            if (dialogResult.IsNonSmoker)
            {
                requirementsBuilder.IncludeAbsenceOfSmoking();
            }

            return requirementsBuilder.Result;
        }

        #endregion

        #region Protected Methods

        protected abstract void OpenProfile();
        protected abstract void ClickLikeBtn();
        protected abstract void ClickDislikeBtn();
        protected abstract IRequirementsBuilder CreateRequirementsBuilder(Sex sex);

        protected void Click(By selector, int withSecondsInterval = 3)
        {
            try
            {
                _webDriver.FindElement(selector)
                          .Click();
            }
            catch (NoSuchElementException)
            {
                WaitSeconds(withSecondsInterval);

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

        protected void CheckProfile()
        {
            if (_profileRequirements == null)
            {
                throw new ArgumentNullException(nameof(_profileRequirements));
            }

            foreach (var condition in _profileRequirements.OnlyConditions)
            {
                _webDriver.FindElement(condition.Value);
            }

            foreach (var condition in _profileRequirements.OrConditions)
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

            foreach (var condition in _profileRequirements.AndConditions)
            {
                _webDriver.FindElement(condition.Value1);

                _webDriver.FindElement(condition.Value2);
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
