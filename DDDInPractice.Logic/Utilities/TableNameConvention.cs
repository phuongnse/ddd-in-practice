using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DDDInPractice.Logic.Utilities
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table($"[dbo].[{instance.EntityType.Name}]");
        }
    }
}