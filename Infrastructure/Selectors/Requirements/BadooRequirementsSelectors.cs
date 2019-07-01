using Localization.Models;
using OpenQA.Selenium;
using System;

namespace Infrastructure.Selectors.Requirements
{
    public class BadooRequirementsSelectors
    {
        private readonly BadooLocalization _badooLocalization;
        public BadooRequirementsSelectors(BadooLocalization badooLocalization)
        {
            _badooLocalization = badooLocalization ??
                throw new ArgumentNullException(nameof(badooLocalization));
        }

        public By FreeRelationshipStatus { get => By.XPath($"//div[contains(string(), '{_badooLocalization.FreeRelationshipStatus}')]"); }
        public By KidsValue1 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.KidsValue1}')]"); }
        public By KidsValue2 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.KidsValue2}')]"); }
        public By SmokingValue1 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.SmokingValue1}')]"); }
        public By SmokingValue2 { get => By.XPath($"//div[contains(string(), '{_badooLocalization.SmokingValue2}')]"); }
    }
}
