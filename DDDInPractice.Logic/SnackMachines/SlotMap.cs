using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.SnackMachines
{
    public class SlotMap : ClassMap<Slot>
    {
        public SlotMap()
        {
            Id(slot => slot.Id);
            References(slot => slot.SnackMachine);
            Map(slot => slot.Position);

            Component(
                slot => slot.SnackPile,
                componentPart =>
                {
                    componentPart.References(snackPile => snackPile.Snack);
                    componentPart.Map(snackPile => snackPile.Quantity);
                    componentPart.Map(snackPile => snackPile.Price);
                });
        }
    }
}