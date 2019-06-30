namespace Infrastructure.Selectors.Localizations
{
    public class MambaLocalization
    {
        public string SmokingHeader { get; }
        public string SmokingValue { get; }

        public string RelationshipStatusHeader { get; }
        public string RelationshipStatusValue { get; }

        public string KidsHeader { get; }
        public string KidsValue1 { get; }
        public string KidsValue2 { get; }

        public MambaLocalization(
                        string smokingHeader,
                        string smokingValue,
                        string relationshipStatusHeader,
                        string relationshipStatusValue,
                        string kidsHeader,
                        string kidsValue1,
                        string kidsValue2)
        {
            SmokingHeader = smokingHeader;
            SmokingValue = smokingValue;
            RelationshipStatusHeader = relationshipStatusHeader;
            RelationshipStatusValue = relationshipStatusValue;
            KidsHeader = kidsHeader;
            KidsValue1 = kidsValue1;
            KidsValue2 = kidsValue2;
        }
    }
}
