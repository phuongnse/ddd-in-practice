using System;
using System.Collections.Generic;

namespace DDDInPractice.Logic
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        private SnackPile()
        {
        }

        public SnackPile(Snack snack, int quantity, decimal price)
        {
            if (quantity < 0 ||
                price < 0 ||
                price % 0.01m > 0)
                throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public SnackPile SubtractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Snack;
            yield return Quantity;
            yield return Price;
        }
    }
}