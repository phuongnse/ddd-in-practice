using System;
using NHibernate.Proxy;
using Volo.Abp.Domain.Entities;

namespace DDDInPractice.Logic
{
    public abstract class Entity : IEntity<long>
    {
        public virtual object[] GetKeys()
        {
            return new object[] {Id};
        }

        public virtual long Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(this, other))
                return true;

            if (other is null)
                return false;

            if (GetRealType() != other.GetRealType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
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