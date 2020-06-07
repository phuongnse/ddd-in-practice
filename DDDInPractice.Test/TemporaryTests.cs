using DDDInPractice.Logic;
using DDDInPractice.Logic.SnackMachines;
using DDDInPractice.Logic.Utilities;
using Xunit;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Test
{
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init("Server=.;Database=DDDInPractice;Trusted_Connection=true");

            var snackMachineRepository = new SnackMachineRepository();
            var snackMachine = snackMachineRepository.GetById(1);
            snackMachine.InsertMoney(OneDollar);
            snackMachine.InsertMoney(OneDollar);
            snackMachine.InsertMoney(OneDollar);
            snackMachine.BuySnack(1);
            snackMachineRepository.Save(snackMachine);
        }
    }
}