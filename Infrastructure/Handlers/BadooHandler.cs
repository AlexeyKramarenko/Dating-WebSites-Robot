using Infrastructure.Models;
using Infrastructure.Selectors.Navigation;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Handlers
{
    public class BadooHandler : HandlerBase
    {
        private readonly IWebDriver _webDriver;
        private readonly BadooNavigationSelectors _selectors;
        private readonly ProfileConditions _profileConditions;

        public BadooHandler(
                     IWebDriver webDriver,
                     BadooNavigationSelectors selectors,
                     ProfileConditions profileConditions) : base(webDriver, selectors)
        {
            _webDriver = webDriver ??
                throw new ArgumentNullException(nameof(webDriver));

            _selectors = selectors ??
                throw new ArgumentNullException(nameof(selectors));

            _profileConditions = profileConditions ??
                throw new ArgumentNullException(nameof(profileConditions));
        }

        #region Public Methods

        public override void SearchFromEncounters()
        {
            WaitSeconds(10);

            try
            {
                while (true)
                {
                    OpenProfile();

                    try
                    {
                        CheckProfile(_profileConditions);

                        ClickLikeBtn();
                    }
                    catch (NoSuchElementException)
                    {
                        ClickDislikeBtn();
                    }

                    WaitSeconds(1);
                }
            }
            catch (ElementClickInterceptedException)
            {
                try
                {
                    WaitSeconds(1);

                    ClosePopupWindow();
                }
                catch (NoSuchElementException)
                {
                    //Let program work further...
                }
            }
        }

        public override void SearchFromPeopleNearby()
        {
            WaitSeconds(5);

            var urls = GetUrlsFromPages(3);

            foreach (var url in urls)
            {
                GoToUrl(url);

                try
                {
                    WaitSeconds(2);

                    CheckProfile(_profileConditions);

                    WaitSeconds(2);

                    ClickLikeBtn();

                    WaitSeconds(3);

                    AddToFavourites();

                    WaitSeconds(3);
                }
                catch (NoSuchElementException)
                {
                    ClickDislikeBtn();

                    WaitSeconds(3);
                }
            }
        }

        #endregion

        #region Protected Methods

        protected override void ClickLikeBtn()
        {
            WaitSeconds(1);

            try
            {
                Click(_selectors.LikeBtn);
            }
            catch (NoSuchElementException)
            {
                WaitSeconds(2);

                Click(_selectors.LikeBtn);
            }

            try
            {
                WaitSeconds(1);

                Click(_selectors.CloseNotificationsLink);
            }
            catch (NoSuchElementException)
            {

            }
        }

        protected override void ClickDislikeBtn()
        {
            try
            {
                Click(_selectors.DislikeBtn);
            }
            catch (NoSuchElementException)
            {
                WaitSeconds(3);

                try
                {
                    Click(_selectors.DislikeBtn);
                }
                catch (NoSuchElementException)
                {
                    WaitSeconds(3);

                    Click(_selectors.DislikeBtn);
                }
            }
        }

        protected override void OpenProfile()
        {
            try
            {
                WaitSeconds(1);

                try
                {
                    Click(_selectors.UserNameLink);
                }
                catch (NoSuchElementException)
                {
                    WaitSeconds(10);

                    Click(_selectors.UserNameLink);
                }
            }
            catch (ElementNotInteractableException)
            {

            }
        }

        #endregion 

        #region Private Methods

        private void ClosePopupWindow()
        {
            Click(_selectors.ClosePopupLink);
        }

        private void AddToFavourites()
        {
            try
            {
                Click(_selectors.AddToFavouritesBtn);
            }
            catch (ElementNotInteractableException)
            {
                Click(_selectors.ProfileHeaderDropDownList);

                WaitSeconds(1);

                try
                {
                    JSClick(_selectors.AddToFavouritesClassName);
                }
                catch
                {
                    ClickDislikeBtn();

                    WaitSeconds(3);
                }
            }
        }

        private IEnumerable<string> GetUrlsFromPages(int pagesCount)
        {
            var hrefsFromRequestedPages = new List<string>();

            for (int i = 1; i <= pagesCount; i++)
            {
                GoToUrl($"https://badoo.com/search?filter=online&page={i}");

                WaitSeconds(6);

                var hrefsFromSinglePage = ExtractHrefsFromAnchors(_selectors.UserCardLink);

                hrefsFromRequestedPages.AddRange(hrefsFromSinglePage);
            }

            return hrefsFromRequestedPages.Distinct();
        }

        private IEnumerable<string> ExtractHrefsFromAnchors(By anchorSelector)
        {
            var hrefs = _webDriver.FindElements(anchorSelector)
                                  .Select(e => e.GetProperty("href"))
                                  .Select(link => link.Split('?')[0]);
            return hrefs;
        }

        #endregion
    }
}
