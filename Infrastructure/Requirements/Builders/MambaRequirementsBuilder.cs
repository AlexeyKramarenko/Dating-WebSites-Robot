using Infrastructure.Models;
using Infrastructure.Selectors.Requirements;

namespace Infrastructure.Requirements.Builders
{
    public class MambaRequirementsBuilder : IRequirementsBuilder
    {
        public ProfileRequirements Result { get; } = new ProfileRequirements();

        private readonly MambaRequirementsSelectors _selectors;

        public MambaRequirementsBuilder(MambaRequirementsSelectors selectors)
        {
            _selectors = selectors;
        }

        public void IncludeFreeRelationshipStatus()
        {
            Result.OnlyConditions
                  .Add(new OnlyTypeCondition(_selectors.RelationshipStatusHeader));
        }

        public void IncludeAbsenceOfKids()
        {
            Result.OnlyConditions
                  .Add(new OnlyTypeCondition(_selectors.KidsHeader));

            Result.OrConditions
                  .Add(new OrTypeCondition(_selectors.KidsValue1, _selectors.KidsValue2));
        }

        public void IncludeAbsenceOfSmoking()
        {
            Result.AndConditions
                  .Add(new AndTypeCondition(_selectors.SmokingHeader, _selectors.SmokingValue));
        }
    }
}
