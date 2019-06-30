using Infrastructure.Handlers;
using Infrastructure.Models;
using Infrastructure.Selectors.Navigation;
using Infrastructure.Selectors.Requirements;
using Localization;
using System;
using System.Collections.Generic;
using Utils;

namespace ConsoleApp.Badoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"If you want make search from 'Encounters' press '1' button.{Environment.NewLine}If you want make search from 'People Nearby' press any other button.");

            var answer = Console.ReadLine();

            var loginData = new LoginData(signInUrl: "https://badoo.com/signin/",
                                          email: "***",
                                          password: "***");

            var webDriver = WebDriverFactory.Create();

            var handler = new BadooHandler(webDriver, new BadooNavigationSelectors());

            handler.Login(loginData);

            handler.SetLocalization();

            var profileConditions = GetProfileConditions(lookingFor: Sex.Woman);

            handler.SetProfileConditions(profileConditions);

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

        private static ProfileConditions GetProfileConditions(Sex lookingFor)
        {
            var localization = LocalizationHelper.GetBadooLocalization(lookingFor);

            var selectors = new BadooRequirementsSelectors(localization);

            var onlyConditions = new List<OnlyTypeCondition>
            {
                new OnlyTypeCondition(selectors.RelationshipStatus)
            };

            var orConditions = new List<OrTypeCondition>
            {
                new OrTypeCondition(selectors.KidsValue1, selectors.KidsValue2),
                new OrTypeCondition(selectors.SmokingValue1, selectors.SmokingValue2),
            };

            var andConditions = new List<AndTypeCondition>();

            return new ProfileConditions(onlyConditions, orConditions, andConditions);
        }

        #endregion
    }
}