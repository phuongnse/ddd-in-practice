using System.Collections.Generic;
using System.Linq;

namespace DDDInPractice.Logic.Common
{
    public abstract class AggregateRoot : Entity
    {
        private readonly IList<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.ToList();

        protected virtual void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public virtual void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}