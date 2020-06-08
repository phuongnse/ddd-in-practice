using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.SharedKernel;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Logic.Management
{
    public class HeadOffice : AggregateRoot
    {
        public HeadOffice()
        {
            Cash = None;
        }

        public virtual decimal Balance { get; protected set; }
        public virtual Money Cash { get; protected set; }

        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}