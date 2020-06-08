using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.Management
{
    public class HeadOfficeMap : ClassMap<HeadOffice>
    {
        public HeadOfficeMap()
        {
            Id(headOffice => headOffice.Id);
            Map(headOffice => headOffice.Balance);

            Component(
                headOffice => headOffice.Cash,
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