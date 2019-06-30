using Infrastructure.Selectors.Localizations;
using OpenQA.Selenium;

namespace Infrastructure.Selectors.Requirements
{
    public class MambaRequirementsSelectors
    {
        private readonly MambaLocalization _localization;

        public MambaRequirementsSelectors(MambaLocalization localization)
        {
            _localization = localization;
        }

        public By RelationshipStatusHeader { get => By.XPath($"//div[contains(string(), '{_localization.RelationshipStatusHeader}')]"); }
        public By RelationshipStatusValue { get => By.XPath($"//div[contains(string(), '{_localization.RelationshipStatusValue}')]"); }

        public By KidsHeader { get => By.XPath($"//div[contains(string(), '{_localization.KidsHeader}')]"); }
        public By KidsValue1 { get => By.XPath($"//div[contains(string(), '{_localization.KidsValue1}')]"); }
        public By KidsValue2 { get => By.XPath($"//div[contains(string(), '{_localization.KidsValue2}')]"); }
        public By SmokingHeader { get => By.XPath($"//div[contains(string(), '{_localization.SmokingHeader}')]"); }
        public By SmokingValue { get => By.XPath($"//div[contains(string(), '{_localization.SmokingValue}')]"); }
    }
}
