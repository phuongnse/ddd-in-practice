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
        public void BuildSnack_ShouldTransferMoneyInTransactionToMoneyInside()
        {
            var id = Guid.NewGuid();
            var snackMachine = new SnackMachine(id);
            snackMachine.InsertMoney(OneDollar);
            snackMachine.InsertMoney(OneDollar);

            snackMachine.BuySnack();

            snackMachine.MoneyInside.Amount.Should().Be(2);
            snackMachine.MoneyInTransaction.Should().Be(None);
        }

        [Fact]
        public void InsertMoney_ShouldThrowAnException_WhenReceivesMoreThanOneCoinOrNoteAtATime()
        {
            var id = Guid.NewGuid();
            var snackMachine = new SnackMachine(id);
            var twoCent = OneCent + OneCent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ReturnMoney_ShouldEmptiesMoneyInTransaction()
        {
            var id = Guid.NewGuid();
            var snackMachine = new SnackMachine(id);
            snackMachine.InsertMoney(OneDollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0);
        }
    }
}