using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.SnackMachines
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