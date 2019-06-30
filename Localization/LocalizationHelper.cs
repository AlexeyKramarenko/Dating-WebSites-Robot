using Infrastructure.Selectors.Localizations;

namespace Localization
{
    public enum Sex
    {
        Man,
        Woman
    }

    public static class LocalizationHelper
    {
        public static BadooLocalization GetBadooLocalization(Sex lookingFor)
        {
            var relationShipStatus = Lang.Badoo.Relationship_I_m_single_boy;

            if (lookingFor == Sex.Woman)
            {
                relationShipStatus = Lang.Badoo.Relationship_I_m_single_girl;
            }

            return new BadooLocalization(
                             relationShipStatus,
                             Lang.Badoo.Kids_someday,
                             Lang.Badoo.Kids_no_never,
                             Lang.Badoo.Smoking_I_dont_like_it,
                             Lang.Badoo.Smoking_I_hate_smoking);
        }

        public static MambaLocalization GetMambaLocalization()
        {
            return new MambaLocalization(
                             Lang.Mamba.SmokingHeader,
                             Lang.Mamba.SmokingValue,
                             Lang.Mamba.RelationshipStatusHeader,
                             Lang.Mamba.RelationshipStatusValue,
                             Lang.Mamba.KidsHeader,
                             Lang.Mamba.KidsValue1,
                             Lang.Mamba.KidsValue2);
        }
    }
}
