using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.Atms
{
    public class AtmMap : ClassMap<Atm>
    {
        public AtmMap()
        {
            Id(atm => atm.Id);
            Map(atm => atm.MoneyCharged);

            Component(
                atm => atm.MoneyInside,
                componentPart =>
                {
                    componentPart.Map(money => money.OneCentCount);
                    componentPart.Map(money => money.TenCentCount);
                    componentPart.Map(money => money.QuarterCentCount);
                    componentPart.Map(money => money.OneDollarCount);
                    componentPart.Map(money => money.FiveDollarCount);
                    componentPart.Map(money => money.TwentyDollarCount);
                });
        }
    }
}