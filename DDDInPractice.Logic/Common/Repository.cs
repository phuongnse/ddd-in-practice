using DDDInPractice.Logic.Utilities;

namespace DDDInPractice.Logic.Common
{
    public abstract class Repository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        public TAggregateRoot GetById(long id)
        {
            using var session = SessionFactory.OpenSession();
            return session.Get<TAggregateRoot>(id);
        }

        public void Save(TAggregateRoot aggregateRoot)
        {
            using var session = SessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            session.SaveOrUpdate(aggregateRoot);
            transaction.Commit();
        }
    }
}