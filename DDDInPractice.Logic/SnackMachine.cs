using System;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public SnackMachine(Guid id) : base(id)
        {
        }

        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }

        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            // MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            // MoneyInTransaction = 0;
        }
    }
}