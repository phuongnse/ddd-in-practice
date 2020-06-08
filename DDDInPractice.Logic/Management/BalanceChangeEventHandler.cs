using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.Common;

namespace DDDInPractice.Logic.Management
{
    public class BalanceChangeEventHandler : IHandler<BalanceChangedEvent>
    {
        public void Handle(BalanceChangedEvent domainEvent)
        {
            var repository = new HeadOfficeRepository();
            var headOffice = repository.GetById(1);
            headOffice.ChangeBalance(domainEvent.Delta);
            repository.Save(headOffice);
        }
    }
}