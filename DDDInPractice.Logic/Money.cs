using System;
using System.Collections.Generic;

namespace DDDInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money OneCent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money QuarterCent = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money OneDollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            if (oneCentCount < 0 ||
                tenCentCount < 0 ||
                quarterCentCount < 0 ||
                oneDollarCount < 0 ||
                fiveDollarCount < 0 ||
                twentyDollarCount < 0)
                throw new InvalidOperationException();

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

        public decimal Amount =>
            OneCentCount * 0.01m +
            TenCentCount * 0.1m +
            QuarterCentCount * 0.25m +
            OneDollarCount +
            FiveDollarCount * 5 +
            TwentyDollarCount * 20;

        public static Money operator +(Money left, Money right)
        {
            return new Money(
                left.OneCentCount + right.OneCentCount,
                left.TenCentCount + right.TenCentCount,
                left.QuarterCentCount + right.QuarterCentCount,
                left.OneDollarCount + right.OneDollarCount,
                left.FiveDollarCount + right.FiveDollarCount,
                left.TwentyDollarCount + right.TwentyDollarCount);
        }

        public static Money operator -(Money left, Money right)
        {
            return new Money(
                left.OneCentCount - right.OneCentCount,
                left.TenCentCount - right.TenCentCount,
                left.QuarterCentCount - right.QuarterCentCount,
                left.OneDollarCount - right.OneDollarCount,
                left.FiveDollarCount - right.FiveDollarCount,
                left.TwentyDollarCount - right.TwentyDollarCount);
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

        public override string ToString()
        {
            return Amount < 1 ? $"¢{Amount * 100:0}" : $"${Amount:0.00}";
        }
    }
}