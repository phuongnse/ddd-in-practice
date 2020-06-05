using System;
using DDDInPractice.Logic;
using FluentAssertions;
using Xunit;

namespace DDDInPractice.Test
{
    public class MoneySpecs
    {
        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -2, 0, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        [InlineData(0, 0, 0, 0, -5, 0)]
        [InlineData(0, 0, 0, 0, 0, -6)]
        public void CreateMoney_ShouldThrowAnException_WhenContainNegativeValues(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            Action action = () =>
            {
                var money = new Money(
                    oneCentCount,
                    tenCentCount,
                    quarterCentCount,
                    oneDollarCount,
                    fiveDollarCount,
                    twentyDollarCount);
            };

            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
        [InlineData(1, 2, 0, 0, 0, 0, 0.21)]
        [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
        [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
        [InlineData(11, 0, 0, 0, 0, 0, 0.11)]
        [InlineData(110, 0, 0, 0, 100, 0, 501.1)]
        public void CalculateAmount_ShouldProducesCorrectResult_WhenGivenValidValues(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            decimal expectedValue)
        {
            var money = new Money(
                oneCentCount,
                tenCentCount,
                quarterCentCount,
                oneDollarCount,
                fiveDollarCount,
                twentyDollarCount);

            money.Amount.Should().Be(expectedValue);
        }

        [Fact]
        public void CompareTwoMoney_ShouldBeEqual_WhenContainTheSameMoneyAmount()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void CompareTwoMoney_ShouldNotBeEqual_WhenContainDifferentMoneyAmount()
        {
            var oneDollar = new Money(0, 0, 0, 1, 0, 0);
            var oneHundredCent = new Money(100, 0, 0, 0, 0, 0);

            oneDollar.Should().NotBe(oneHundredCent);
            oneDollar.GetHashCode().Should().NotBe(oneHundredCent.GetHashCode());
        }

        [Fact]
        public void SubtractionOfTwoMoney_ShouldProducesCorrectResult_WhenGivenValidValues()
        {
            var money1 = new Money(10, 10, 10, 10, 10, 10);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var result = money1 - money2;

            result.OneCentCount.Should().Be(9);
            result.TenCentCount.Should().Be(8);
            result.QuarterCentCount.Should().Be(7);
            result.OneDollarCount.Should().Be(6);
            result.FiveDollarCount.Should().Be(5);
            result.TwentyDollarCount.Should().Be(4);
        }

        [Fact]
        public void SubtractionOfTwoMoney_ShouldThrowAnException_WhenGivenValuesMoreThanExists()
        {
            var money1 = new Money(0, 0, 0, 1, 0, 0);
            var money2 = new Money(1, 0, 0, 0, 0, 0);

            Action action = () =>
            {
                var result = money1 - money2;
            };

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void SumOfTwoMoney_ShouldProducesCorrectResult_WhenGivenValidValues()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var result = money1 + money2;

            result.OneCentCount.Should().Be(2);
            result.TenCentCount.Should().Be(4);
            result.QuarterCentCount.Should().Be(6);
            result.OneDollarCount.Should().Be(8);
            result.FiveDollarCount.Should().Be(10);
            result.TwentyDollarCount.Should().Be(12);
        }
    }
}