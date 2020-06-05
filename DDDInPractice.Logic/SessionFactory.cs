using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

namespace DDDInPractice.Logic
{
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static void Init(string connectionString)
        {
            _sessionFactory = BuildSessionFactory(connectionString);
        }

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        private static ISessionFactory BuildSessionFactory(string connectionString)
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(mappingConfiguration => mappingConfiguration.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(ConventionBuilder.Property.When(
                        acceptanceCriteria => acceptanceCriteria.Expect(
                            propertyInspector => propertyInspector.Nullable,
                            Is.Not.Set),
                        propertyInstance => propertyInstance.Not.Nullable()))
                    .Conventions.Add<TableNameConvention>()
                    .Conventions.Add<HiLoConvention>())
                .BuildSessionFactory();
        }
    }
}