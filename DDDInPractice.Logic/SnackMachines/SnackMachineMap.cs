﻿using FluentNHibernate;
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
                    componentPart.Map(money => money.OneCentCount);
                    componentPart.Map(money => money.TenCentCount);
                    componentPart.Map(money => money.QuarterCentCount);
                    componentPart.Map(money => money.OneDollarCount);
                    componentPart.Map(money => money.FiveDollarCount);
                    componentPart.Map(money => money.TwentyDollarCount);
                });

            HasMany<Slot>(Reveal.Member<SnackMachine>("Slots")).Cascade.SaveUpdate().Not.LazyLoad();
        }
    }
}