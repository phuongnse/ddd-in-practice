using System.Linq;
using Volo.Abp.Domain.Values;

namespace DDDInPractice.Logic
{
    public abstract class ValueObject<TValueObject> : ValueObject where TValueObject : ValueObject<TValueObject>
    {
        public override bool Equals(object obj)
        {
            return ValueEquals(obj);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Sum(atomicValue => atomicValue.GetHashCode());
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }
    }
}