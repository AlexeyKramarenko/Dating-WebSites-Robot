using OpenQA.Selenium;

namespace Infrastructure.Selectors
{
    public interface ILoginSelectors
    {
        By Email { get; }
        By Password { get; }
        By LoginBtn { get; }
    }
}
