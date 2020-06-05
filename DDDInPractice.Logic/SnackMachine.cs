using System;
using System.Linq;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public SnackMachine(Guid id) : base(id)
        {
        }

        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = {OneCent, TenCent, QuarterCent, OneDollar, FiveDollar, TwentyDollar};

            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}