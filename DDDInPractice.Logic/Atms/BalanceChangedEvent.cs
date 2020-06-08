using DDDInPractice.Logic.Common;

namespace DDDInPractice.Logic.Atms
{
    public class BalanceChangedEvent : IDomainEvent
    {
        public BalanceChangedEvent(decimal delta)
        {
            Delta = delta;
        }

        public decimal Delta { get; }
    }
}