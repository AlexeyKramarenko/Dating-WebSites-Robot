namespace Localization.Models
{
    public class BadooLocalization
    {
        public string FreeRelationshipStatus { get; }
        public string KidsValue1 { get; }
        public string KidsValue2 { get; }
        public string SmokingValue1 { get; }
        public string SmokingValue2 { get; }

        public BadooLocalization(
                           string freeRelationshipStatus,
                           string kidsValue1,
                           string kidsValue2,
                           string smokingValue1,
                           string smokingValue2)
        {
            FreeRelationshipStatus = freeRelationshipStatus;
            KidsValue1 = kidsValue1;
            KidsValue2 = kidsValue2;
            SmokingValue1 = smokingValue1;
            SmokingValue2 = smokingValue2;
        }
    }
}
