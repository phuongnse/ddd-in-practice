using DDDInPractice.Logic.Common;
using static DDDInPractice.Logic.SnackMachines.SnackPile;

namespace DDDInPractice.Logic.SnackMachines
{
    public class Slot : Entity
    {
        protected Slot()
        {
        }

        public Slot(SnackMachine snackMachine, int position)
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = Empty;
        }

        public virtual SnackMachine SnackMachine { get; protected set; }
        public virtual int Position { get; protected set; }
        public virtual SnackPile SnackPile { get; set; }
    }
}