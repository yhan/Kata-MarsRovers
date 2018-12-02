using NFluent;
using NUnit.Framework;

namespace KataMarsRovers.Tests
{
    [TestFixture]
    public class CompassShould
    {
        [Test]
        public void Returns_E_when_returns_Left_3_times_from_initial_orientations_N()
        {
            var compass = new Compass();

            string endWith = compass.StartWith("N").Turns("LLL");

            Check.That(endWith).IsEqualTo("E");
        }

        [Test]
        public void Returns_N_when_instruction_is_LLLRR()
        {
            var compass = new Compass();

            string endWith = compass.StartWith("E").Turns("LLLRR");

            Check.That(endWith).IsEqualTo("N");
        }
    }
}