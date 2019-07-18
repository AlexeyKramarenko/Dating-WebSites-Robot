using Localization.Models;
using System;

namespace Infrastructure.Models
{
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

            Sex = sex ??
                throw new ArgumentNullException(nameof(sex));

            Search = search ??
                throw new ArgumentNullException(nameof(search));

            IsFree = isFree;
            DoesntHaveKids = doesntHaveKids;
            IsNonSmoker = isNonSmoker;
        }
    }
}
