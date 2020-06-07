using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic
{
    public class SnackMap : ClassMap<Snack>
    {
        public SnackMap()
        {
            Id(snack => snack.Id);
            Map(snack => snack.Name);
        }
    }
}