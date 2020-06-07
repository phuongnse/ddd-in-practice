using System;
using DDDInPractice.Logic;
using FluentAssertions;
using Xunit;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Test
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void BuildSnack_ShouldTradesInsertedMoneyForASnack()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 10, 1));
            snackMachine.InsertMoney(OneDollar);

            snackMachine.BuySnack(1);

            snackMachine.MoneyInside.Amount.Should().Be(1);
            snackMachine.MoneyInTransaction.Should().Be(0);
            snackMachine.GetSnackPile(1).Quantity.Should().Be(9);
        }

        [Fact]
        public void BuySnack_ShouldReturnChangeAfterPurchase()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 1, 0.5m));
            snackMachine.LoadMoney(TenCent * 10);
            snackMachine.InsertMoney(OneDollar);

            snackMachine.BuySnack(1);

            snackMachine.MoneyInside.Amount.Should().Be(1.5m);
            snackMachine.MoneyInTransaction.Should().Be(0);
        }

        [Fact]
        public void BuySnack_ShouldThrowAnException_WhenMoneyInsertedNotEnough()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 10, 2));
            snackMachine.InsertMoney(OneDollar);

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void BuySnack_ShouldThrowAnException_WhenNotEnoughChange()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 1, 0.5m));
            snackMachine.InsertMoney(OneDollar);

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void BuySnack_ShouldThrowAnException_WhenThereIsNoSnacks()
        {
            var snackMachine = new SnackMachine();

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void InsertMoney_ShouldThrowAnException_WhenReceivesMoreThanOneCoinOrNoteAtATime()
        {
            var snackMachine = new SnackMachine();
            var twoCent = OneCent + OneCent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ReturnMoney_ShouldEmptiesMoneyInTransaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(OneDollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Should().Be(0);
        }

        [Fact]
        public void ReturnMoney_ShouldTryToReturnHighestDenominationFirst()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadMoney(OneDollar);

            snackMachine.InsertMoney(QuarterCent);
            snackMachine.InsertMoney(QuarterCent);
            snackMachine.InsertMoney(QuarterCent);
            snackMachine.InsertMoney(QuarterCent);
            snackMachine.ReturnMoney();

            snackMachine.MoneyInside.QuarterCentCount.Should().Be(4);
            snackMachine.MoneyInside.OneDollarCount.Should().Be(0);
        }
    }
}