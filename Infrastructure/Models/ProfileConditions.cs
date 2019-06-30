using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class ProfileConditions
    {
        public IEnumerable<OnlyTypeCondition> OnlyConditions { get; }
        public IEnumerable<OrTypeCondition> OrConditions { get; }

        public ProfileConditions(
                IEnumerable<OnlyTypeCondition> singleConditions,
                IEnumerable<OrTypeCondition> pairConditions)
        {
            OnlyConditions = singleConditions ??
                throw new ArgumentNullException(nameof(singleConditions));

            OrConditions = pairConditions ??
                throw new ArgumentNullException(nameof(pairConditions));
        }
    }

    public class OnlyTypeCondition
    {
        public By Value { get; }

        public OnlyTypeCondition(By value)
        {
            Value = value
               ?? throw new ArgumentNullException(nameof(value));
        }
    }

    /// <summary>
    /// When any from two conditions is okay
    /// </summary>
    public class OrTypeCondition
    {
        public By Value1 { get; }
        public By Value2 { get; }

        public OrTypeCondition(By value1, By value2)
        {
            Value1 = value1
                ?? throw new ArgumentNullException(nameof(value1));

            Value2 = value2
                ?? throw new ArgumentNullException(nameof(value2));
        }
    }
}
