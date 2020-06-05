using DDDInPractice.Logic;
using Xunit;

namespace DDDInPractice.Test
{
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init("Server=.;Database=DDDInPractice;Trusted_Connection=true");

            using var session = SessionFactory.OpenSession();
            const long id = 1;
            var snackMachine = session.Get<SnackMachine>(id);
        }
    }
}