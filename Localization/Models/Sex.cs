namespace Localization.Models
{
    public class Sex
    {
        public string StringEquivalent { get; }
        private Sex(string stringEquivalent)
        {
            StringEquivalent = stringEquivalent;
        }

        public static Sex Man { get; } = new Sex("Man");
        public static Sex Woman { get; } = new Sex("Woman");
    }
}
