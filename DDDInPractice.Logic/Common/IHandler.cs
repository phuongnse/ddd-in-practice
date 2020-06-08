namespace DDDInPractice.Logic.Common
{
    public interface IHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
        void Handle(TDomainEvent domainEvent);
    }
}