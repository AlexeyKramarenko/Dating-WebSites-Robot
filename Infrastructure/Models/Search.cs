namespace Infrastructure.Models
{
    public class Search
    {
        public string LogInfo { get; }
        public string StringEquivalent { get; }
        private Search(string logInfo, string stringEquivalent)
        {
            LogInfo = logInfo;
            StringEquivalent = stringEquivalent;
        }

        public static Search Encounters { get; } = new Search("Search in Encounters.", "Encounters");
        public static Search PeopleNearby { get; } = new Search("Search in PeopleNearby.", "PeopleNearby");
    }
}
