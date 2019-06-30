using OpenQA.Selenium;
using Infrastructure.Selectors.Localizations;

namespace Infrastructure.Selectors.Navigation
{
    public class MambaNavigationSelectors : ILoginSelectors
    {
        private readonly MambaLocalization _localization;

        public MambaNavigationSelectors(MambaLocalization localization)
        {
            _localization = localization;
        }

        public By Email { get => By.Name("login"); }
        public By Password { get => By.Name("password"); }
        public By LoginBtn { get => By.ClassName("cEBqpC"); }
        public By YesBtn { get => By.ClassName("photo-vote-ctrl-section__button"); }
        public By NoBtn { get => By.XPath("//span[contains(string(), 'Дальше')]"); }

        public By UserNameLink { get => By.ClassName("photo-vote-wrapper"); }
    }
}
