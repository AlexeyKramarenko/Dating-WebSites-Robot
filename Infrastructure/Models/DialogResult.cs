using Localization;

namespace Infrastructure.Models
{
    public enum Search
    {
        Encounters,
        PeopleNearby
    }

    public class DialogResult
    {
        public Sex Sex { get; }
        public bool IsFree { get; }
        public bool DoesntHaveKids { get; }
        public bool IsNonSmoker { get; }
        public Search Search { get; }

        public DialogResult(Sex sex,
                            bool isFree,
                            bool doesntHaveKids,
                            bool isNonSmoker,
                            Search search)
        {
            Sex = sex;
            IsFree = isFree;
            DoesntHaveKids = doesntHaveKids;
            IsNonSmoker = isNonSmoker;
            Search = search;
        }
    }
}
