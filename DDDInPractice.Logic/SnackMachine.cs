using System;
using System.Linq;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    public class SnackMachine : Entity
    {
        protected SnackMachine()
        {
        }

        public SnackMachine(Guid id) : base(id)
        {
        }

        public virtual Money MoneyInside { get; protected set; } = None;
        public virtual Money MoneyInTransaction { get; protected set; } = None;

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = {OneCent, TenCent, QuarterCent, OneDollar, FiveDollar, TwentyDollar};

            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public virtual void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}