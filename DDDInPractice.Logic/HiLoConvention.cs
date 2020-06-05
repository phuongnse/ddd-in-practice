using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DDDInPractice.Logic
{
    public class HiLoConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(nameof(Entity.Id));
            instance.GeneratedBy.HiLo("[dbo].[Ids]", "NextHigh", "9", $"EntityName = '{instance.EntityType.Name}'");
        }
    }
}