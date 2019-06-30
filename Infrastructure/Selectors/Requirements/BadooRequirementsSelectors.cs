using Infrastructure.Selectors.Localizations;
using OpenQA.Selenium;
using System;

namespace Infrastructure.Selectors.Requirements
{
    public class BadooConditionSelectors
    {
        private readonly BadooLocalization _badooLocalization;
        public BadooConditionSelectors(BadooLocalization badooLocalization)
        {
            _badooLocalization = badooLocalization ??
                throw new ArgumentNullException(nameof(badooLocalization));
        }

        public By RelationshipStatus { get => By.XPath($"//div[contains(string(), '{_badooLocalization.RelationshipStatus}')]"); }
        public By KidsValue1 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.KidsValue1}')]"); }
        public By KidsValue2 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.KidsValue2}')]"); }
        public By SmokingValue1 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.SmokingValue1}')]"); }
        public By SmokingValue2 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.SmokingValue2}')]"); }
    }
}
