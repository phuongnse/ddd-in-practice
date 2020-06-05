using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DDDInPractice.Logic
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table($"[dbo].[{instance.EntityType.Name}]");
        }
    }
}