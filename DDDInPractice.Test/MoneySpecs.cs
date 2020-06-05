using DDDInPractice.Logic;
using FluentAssertions;
using Xunit;

namespace DDDInPractice.Test
{
    public class MoneySpecs
    {
        [Fact]
        public void SumOfTwoMoney_WhenGivenValidValues_ShouldProducesCorrectResult()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var sum = money1 + money2;

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCentCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }
    }
}