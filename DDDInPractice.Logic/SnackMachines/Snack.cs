﻿using DDDInPractice.Logic.Common;

namespace DDDInPractice.Logic.SnackMachines
{
    public class Snack : AggregateRoot
    {
        public static readonly Snack None = new Snack(0, "None");
        public static readonly Snack Soda = new Snack(1, "Soda");
        public static readonly Snack Chocolate = new Snack(2, "Chocolate");
        public static readonly Snack Gum = new Snack(3, "Gum");

        protected Snack()
        {
        }

        private Snack(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual string Name { get; }
    }
}