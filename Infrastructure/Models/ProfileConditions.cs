using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class ProfileConditions
    {
        public IEnumerable<SingleCondition> SingleConditions { get; }
        public IEnumerable<PairCondition> PairConditions { get; }

        public ProfileConditions(
                IEnumerable<SingleCondition> singleConditions,
                IEnumerable<PairCondition> pairConditions)
        {
            SingleConditions = singleConditions ??
                throw new ArgumentNullException(nameof(singleConditions));

            PairConditions = pairConditions ??
                throw new ArgumentNullException(nameof(pairConditions));
        }
    }

    public class SingleCondition
    {
        public By Value { get; }

        public SingleCondition(By value)
        {
            Value = value
               ?? throw new ArgumentNullException(nameof(value));
        }
    }

    /// <summary>
    /// When any from two conditions is okay
    /// </summary>
    public class PairCondition
    {
        public By Value1 { get; }
        public By Value2 { get; }

        public PairCondition(By value1, By value2)
        {
            Value1 = value1
                ?? throw new ArgumentNullException(nameof(value1));

            Value2 = value2
                ?? throw new ArgumentNullException(nameof(value2));
        }
    }
}
