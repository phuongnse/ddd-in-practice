using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.SharedKernel;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Logic.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal CommissionRate = 0.01m;

        public Atm()
        {
            MoneyInside = None;
            MoneyCharged = 0;
        }

        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyCharged { get; protected set; }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        public virtual void TakeMoney(decimal amount)
        {
            MoneyInside -= MoneyInside.Allocate(amount);
            MoneyCharged += CalculateAmountWithCommission(amount);
        }

        private static decimal CalculateAmountWithCommission(decimal amount)
        {
            var commission = amount * CommissionRate;
            var lessThanOneCent = commission % 0.01m;

            if (lessThanOneCent > 0)
                commission = commission - lessThanOneCent + 0.01m;

            return amount + commission;
        }
    }
}