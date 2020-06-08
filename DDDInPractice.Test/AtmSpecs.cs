using DDDInPractice.Logic.Atms;
using FluentAssertions;
using Xunit;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Test
{
    public class AtmSpecs
    {
        [Fact]
        public void TakeMoney_ShouldApplyCommissionWithAtLeastOneCent()
        {
            var atm = new Atm();
            atm.LoadMoney(OneCent);

            atm.TakeMoney(0.01m);

            atm.MoneyCharged.Should().Be(0.02m);
        }

        [Fact]
        public void TakeMoney_ShouldExchangesMoneyWithCommission()
        {
            var atm = new Atm();
            atm.LoadMoney(OneDollar);

            atm.TakeMoney(1);

            atm.MoneyInside.Should().Be(None);
            atm.MoneyCharged.Should().Be(1.01m);
        }

        [Fact]
        public void TakeMoney_ShouldRoundedUpCommissionToTheNextCent()
        {
            var atm = new Atm();
            atm.LoadMoney(OneDollar + TenCent);

            atm.TakeMoney(1.1m);

            atm.MoneyCharged.Should().Be(1.12m);
        }
    }
}