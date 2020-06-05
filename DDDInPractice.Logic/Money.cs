using System.Collections.Generic;

namespace DDDInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public Money
        (
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount
        )
        {
            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCentCount = quarterCentCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCentCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }

        public static Money operator +(Money left, Money right)
        {
            return new Money
            (
                left.OneCentCount + right.OneCentCount,
                left.TenCentCount + right.TenCentCount,
                left.QuarterCentCount + right.QuarterCentCount,
                left.OneDollarCount + right.OneDollarCount,
                left.FiveDollarCount + right.FiveDollarCount,
                left.TwentyDollarCount + right.TwentyDollarCount
            );
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return OneCentCount;
            yield return TenCentCount;
            yield return QuarterCentCount;
            yield return OneDollarCount;
            yield return FiveDollarCount;
            yield return TwentyDollarCount;
        }
    }
}