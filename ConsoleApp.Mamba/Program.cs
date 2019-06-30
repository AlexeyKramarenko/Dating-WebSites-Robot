using Infrastructure.Handlers;
using Infrastructure.Models;
using Infrastructure.Selectors.Navigation;
using Infrastructure.Selectors.Requirements;
using Localization;
using System;
using System.Collections.Generic;
using Utils;

namespace ConsoleApp.Mamba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"If you want make search from 'Encounters' press '1' button.{Environment.NewLine}If you want make search from 'People Nearby' press any other button.");

            var answer = Console.ReadLine();

            var loginData = new LoginData(signInUrl: "https://www.mamba.ru/login",
                                          email: "***",
                                          password: "***");

            var webDriver = WebDriverFactory.Create();

            var handler = new MambaHandler(webDriver, new MambaNavigationSelectors());

            handler.Login(loginData);

            handler.SetLocalization();

            handler.SetProfileConditions(ProfileConditions);

            if (answer == "1")
            {
                handler.SearchFromEncounters();
            }
            else
            {
                handler.SearchFromPeopleNearby();
            }
        }

        #region Private Methods

        private static ProfileConditions ProfileConditions
        {
            get
            {
                var localization = LocalizationHelper.GetMambaLocalization();

                var selectors = new MambaRequirementsSelectors(localization);

                var onlyConditions = new List<OnlyTypeCondition>
                {
                    new OnlyTypeCondition(selectors.KidsHeader),
                    new OnlyTypeCondition(selectors.RelationshipStatusHeader)
                };

                var orConditions = new List<OrTypeCondition>
                {
                    new OrTypeCondition(selectors.KidsValue1, selectors.KidsValue2)
                };

                var andConditions = new List<AndTypeCondition>
                {
                    new AndTypeCondition(selectors.SmokingHeader, selectors.SmokingValue)
                };

                return new ProfileConditions(onlyConditions, orConditions, andConditions);
            }
        }

        #endregion
    }
}
