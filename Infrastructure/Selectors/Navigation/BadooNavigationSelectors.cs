using OpenQA.Selenium;

namespace Infrastructure.Selectors.Navigation
{
    public class BadooNavigationSelectors : ILoginSelectors
    {
        public readonly string AddToFavouritesClassName = "js-profile-header-favorite";

        public By Email { get => By.Name("email"); }
        public By Password { get => By.Name("password"); }
        public By LoginBtn { get => By.Name("post"); }
        public By LikeBtn { get => By.ClassName("js-profile-header-vote-yes"); }
        public By DislikeBtn { get => By.ClassName("js-profile-header-vote-no"); }

        public By UserNameLink { get => By.ClassName("js-profile-header-name"); }
        public By ClosePopupLink { get => By.ClassName("js-ovl-close"); }
        public By CloseNotificationsLink { get => By.ClassName("js-chrome-pushes-deny"); }
        public By OnlineBtn { get => By.XPath("//span[contains(string(), 'Онлайн')]"); }
        public By AddToFavouritesBtn { get => By.ClassName(AddToFavouritesClassName); }
        public By ProfileHeaderDropDownList { get => By.ClassName("js-profile-header-more"); }
        public By UserCardLink { get => By.ClassName("user-card__link"); }
        public By FeaturedPeople { get => By.ClassName("spotlight__title"); }
    }
}
