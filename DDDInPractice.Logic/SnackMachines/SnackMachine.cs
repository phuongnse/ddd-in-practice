using System;
using System.Collections.Generic;
using System.Linq;
using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.SharedKernel;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Logic.SnackMachines
{
    public class SnackMachine : AggregateRoot
    {
        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = 0;

            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyInTransaction { get; protected set; }
        protected virtual IList<Slot> Slots { get; set; }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = {OneCent, TenCent, QuarterCent, OneDollar, FiveDollar, TwentyDollar};

            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInside += money;
            MoneyInTransaction += money.Amount;
        }

        public virtual void ReturnMoney()
        {
            MoneyInside -= MoneyInside.Allocate(MoneyInTransaction);
            MoneyInTransaction = 0;
        }

        public virtual void BuySnack(int position)
        {
            var slot = GetSlot(position);

            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();

            var change = MoneyInTransaction - slot.SnackPile.Price;
            var allocate = MoneyInside.Allocate(change);

            if (allocate.Amount < change)
                throw new InvalidOperationException();

            slot.SnackPile = slot.SnackPile.SubtractOne();

            MoneyInside -= allocate;
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnack(int position, SnackPile snackPile)
        {
            GetSlot(position).SnackPile = snackPile;
        }

        public virtual SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(slot => slot.Position == position);
        }
    }
}