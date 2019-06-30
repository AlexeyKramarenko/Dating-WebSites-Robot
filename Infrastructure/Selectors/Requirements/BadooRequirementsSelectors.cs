using Infrastructure.Selectors.Localizations;
using OpenQA.Selenium;
using System;

namespace Infrastructure.Selectors.Requirements
{
    public class BadooConditionSelectors
    {
        private readonly BadooLocalization _localization;
        public BadooConditionSelectors(BadooLocalization localization)
        {
            _localization = localization ??
                throw new ArgumentNullException(nameof(localization));
        }

        public By Location { get => By.XPath($"//span[contains(string(), 'Київ')]"); }
        public By RelationshipStatus { get => By.XPath($"//div[contains(string(), 'Я вільна')]"); }
        public By ChildrenValue1 { get => By.XPath($"//div[contains(string(), 'Коли-небудь')]"); }
        public By ChildrenValue2 { get => By.XPath($"//div[contains(string(), 'Ні, ніколи')]"); }
        public By SmokingValue1 { get => By.XPath($"//div[contains(string(), 'Не палю')]"); }
        public By SmokingValue2 { get => By.XPath($"//div[contains(string(), 'Проти паління')]"); }
    }
}
