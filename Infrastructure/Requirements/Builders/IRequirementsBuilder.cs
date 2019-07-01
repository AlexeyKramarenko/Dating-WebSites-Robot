using Infrastructure.Models;

namespace Infrastructure.Requirements
{
    public interface IRequirementsBuilder
    {
        void IncludeFreeRelationshipStatus();
        void IncludeAbsenceOfKids();
        void IncludeAbsenceOfSmoking();
        ProfileRequirements Result { get; }
    }
}
