using Utils;
using Infrastructure.Models;
using Infrastructure.Handlers;
using Infrastructure.Selectors.Navigation;
using System.Collections.Generic;
using Infrastructure.Selectors.Requirements;
using Infrastructure.Selectors.Localizations;
using System;

namespace ConsoleApp.Badoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"If you want make search from 'Encounters' press '1' button.{Environment.NewLine}If you want make search from 'People Nearby' press any other button.");

            #region User Input Data

            var answer = Console.ReadLine();

            var loginData = new LoginData(signInUrl: "https://badoo.com/signin/",
                                          email: "***",
                                          password: "***");

            var localization = new BadooLocalization();

            var selectors = new BadooConditionSelectors(localization);

            var singleConditions = new List<SingleCondition>
            {
                new SingleCondition(selectors.Location),
                new SingleCondition(selectors.RelationshipStatus)
            };

            var pairConditions = new List<PairCondition>
            {
                new PairCondition(selectors.ChildrenValue1, selectors.ChildrenValue2),
                new PairCondition(selectors.SmokingValue1, selectors.SmokingValue2),
            };

            var profileConditions = new ProfileConditions(singleConditions, pairConditions);

            #endregion

            var webDriver = WebDriverFactory.Create();

            var handler = new BadooHandler(webDriver, new BadooNavigationSelectors(), profileConditions);

            handler.Login(loginData);

            if (answer == "1")
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