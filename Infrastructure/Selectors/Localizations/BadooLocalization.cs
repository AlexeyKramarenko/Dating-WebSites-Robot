namespace Infrastructure.Selectors.Localizations
{
    public class BadooLocalization
    {
        public string RelationshipStatus { get; }
        public string KidsValue1 { get; }
        public string KidsValue2 { get; }
        public string SmokingValue1 { get; }
        public string SmokingValue2 { get; }

        public BadooLocalization(
                           string relationshipStatus,
                           string kidsValue1,
                           string kidsValue2,
                           string smokingValue1,
                           string smokingValue2)
        {
            RelationshipStatus = relationshipStatus;
            KidsValue1 = kidsValue1;
            KidsValue2 = kidsValue2;
            SmokingValue1 = smokingValue1;
            SmokingValue2 = smokingValue2;
        }
    }
}
