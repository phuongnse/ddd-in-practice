using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.SnackMachines
{
    public class SnackMachineMap : ClassMap<SnackMachine>
    {
        public SnackMachineMap()
        {
            Id(snackMachine => snackMachine.Id);

            Component(
                snackMachine => snackMachine.MoneyInside,
                componentPart =>
                {
                    componentPart.Map(x => x.OneCentCount);
                    componentPart.Map(x => x.TenCentCount);
                    componentPart.Map(x => x.QuarterCentCount);
                    componentPart.Map(x => x.OneDollarCount);
                    componentPart.Map(x => x.FiveDollarCount);
                    componentPart.Map(x => x.TwentyDollarCount);
                });

            HasMany<Slot>(Reveal.Member<SnackMachine>("Slots")).Cascade.SaveUpdate().Not.LazyLoad();
        }
    }
}