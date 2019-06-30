using OpenQA.Selenium;

namespace Infrastructure.Selectors.Navigation
{
    public class MambaNavigationSelectors : ILoginSelectors
    {
        public By Email { get => By.Name("login"); }
        public By Password { get => By.Name("password"); }
        public By LoginBtn { get => By.ClassName("cEBqpC"); }
        public By LikeBtn { get => By.ClassName("photo-vote-ctrl-section__button"); }
        public By DislikeBtnRus { get => By.XPath($"//div[contains(string(), 'Дальше')]"); }
        public By DislikeBtnEng { get => By.XPath($"//div[contains(string(), 'Skip')]"); }

        public By UserNameLink { get => By.ClassName("photo-vote-wrapper"); }
        public By TitleBlock { get => By.ClassName("title-block"); }
    }
}
