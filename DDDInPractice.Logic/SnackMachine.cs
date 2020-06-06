using System;
using System.Collections.Generic;
using System.Linq;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    public class SnackMachine : Entity
    {
        public virtual Money MoneyInside { get; protected set; }
        public virtual Money MoneyInTransaction { get; protected set; }
        public virtual IList<Slot> Slots { get; protected set; }

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = None;

            Slots = new List<Slot>
            {
                new Slot(this, 1, null, 0, 0),
                new Slot(this, 2, null, 0, 0),
                new Slot(this, 3, null, 0, 0)
            };
        }

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

        public virtual void BuySnack(int position)
        {
            var slotToLoad = Slots.Single(slot => slot.Position == position);
            slotToLoad.Quantity--;

            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }

        public virtual void LoadSnack(int position, Snack snack, int quantity, decimal price)
        {
            var slotToLoad = Slots.Single(slot => slot.Position == position);
            slotToLoad.Snack = snack;
            slotToLoad.Quantity = quantity;
            slotToLoad.Price = price;
        }
    }
}