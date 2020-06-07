using DDDInPractice.Logic;
using Xunit;
using static DDDInPractice.Logic.Money;

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