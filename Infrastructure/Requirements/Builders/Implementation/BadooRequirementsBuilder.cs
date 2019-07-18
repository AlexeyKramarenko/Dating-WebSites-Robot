using Infrastructure.Models;
using Infrastructure.Selectors.Requirements;

namespace Infrastructure.Requirements.Builders.Implementation
{
    public class BadooRequirementsBuilder : IRequirementsBuilder
    {
        public ProfileRequirements Result { get; } = new ProfileRequirements();

        private readonly BadooRequirementsSelectors _selectors;

        public BadooRequirementsBuilder(BadooRequirementsSelectors selectors)
        {
            _selectors = selectors;
        }

        public void IncludeFreeRelationshipStatus()
        {
            Result.OnlyConditions
                  .Add(new OnlyTypeCondition(_selectors.FreeRelationshipStatus));
        }

        public void IncludeAbsenceOfKids()
        {
            Result.OrConditions
                  .Add(new OrTypeCondition(_selectors.KidsValue1, _selectors.KidsValue2));
        }

        public void IncludeAbsenceOfSmoking()
        {
            Result.OrConditions
                  .Add(new OrTypeCondition(_selectors.SmokingValue1, _selectors.SmokingValue2));
        }
    }
}
