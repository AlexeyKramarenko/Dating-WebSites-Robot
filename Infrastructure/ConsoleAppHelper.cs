using Infrastructure.Models;
using Localization;
using System;
using System.Text.RegularExpressions;

namespace Utils
{
    public class ConsoleAppHelper
    {
        public static DialogResult RunDialog()
        {
            Console.WriteLine("Are you looking for women? (y/n)");

            var sex = Console.ReadKey()
                             .Key == ConsoleKey.Y ? Sex.Woman
                                                  : Sex.Man;

            Console.WriteLine(Environment.NewLine + "Should the person be free? (y/n)");

            var isFree = Console.ReadKey()
                                .Key == ConsoleKey.Y;

            Console.WriteLine(Environment.NewLine + "Should the person be without kids? (y/n)");

            var doesntHaveKids = Console.ReadKey()
                                        .Key == ConsoleKey.Y;

            Console.WriteLine(Environment.NewLine + "Is it important that the person should be non-smoker? (y/n)");

            var isNonSmoker = Console.ReadKey()
                                     .Key == ConsoleKey.Y;

            Console.WriteLine(Environment.NewLine + $"If you want to make search in 'Encounters' press 'Y' button.{Environment.NewLine}If you want to make search in 'People Nearby' press any other button.");

            var search = Console.ReadKey()
                                .Key == ConsoleKey.Y ? Search.Encounters
                                                     : Search.PeopleNearby;

            var message = $@"The program will look for {(isFree ? "free " : "")} 
                                                       {(isNonSmoker ? "non-smoking " : "")} 
                                                       {(sex == Sex.Man ? "men " : "women")} 
                                                       {(doesntHaveKids ? "without kids " : "")} 
                                   and will press 'Yes' button in their profiles and 'No' button for others."
                             .Replace(Environment.NewLine, "")
                             .Replace("  ", " ");

            string resultMessage = Regex.Replace(message, " {2,}", " ");

            Console.WriteLine(resultMessage);

            return new DialogResult(sex, isFree, doesntHaveKids, isNonSmoker, search);
        }
    }
}
