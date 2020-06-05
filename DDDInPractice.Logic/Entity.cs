using System;
using NHibernate.Proxy;
using Volo.Abp.Domain.Entities;

namespace DDDInPractice.Logic
{
    public abstract class Entity : Entity<Guid>
    {
        protected Entity()
        {
        }

        protected Entity(Guid id) : base(id)
        {
        }

        public override bool Equals(object obj)
        {
            return
                EntityEquals(obj) &&
                obj is Entity other &&
                GetRealType() == other.GetRealType() &&
                Id == other.Id;
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

        private Type GetRealType()
        {
            return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        }
    }
}