using System;
using Volo.Abp.Domain.Entities;

namespace DDDInPractice.Logic
{
    public abstract class Entity : Entity<Guid>
    {
        protected Entity(Guid id) : base(id)
        {
            Id = id;
        }

        public new Guid Id { get; }

        public override bool Equals(object obj)
        {
            return EntityEquals(obj) && obj is Entity<Guid> other && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}