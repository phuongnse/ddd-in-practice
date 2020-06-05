using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic
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
        }
    }
}