using NFluent;
using NUnit.Framework;

namespace KataMarsRovers.Tests
{
    [TestFixture]
    public class MarsRoverShould
    {
        [Test]
        public void Can_change_orientation_three_times_toward_left()
        {
            var rover = new Rover("5 5 1 2 N");
            rover.Move("LLL");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 E");
        }

        [Test]
        public void Can_change_orientation_three_times_toward_left_and_intial_orientation_is_S()
        {
            var rover = new Rover("5 5 1 2 S");
            rover.Move("LLL");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 W");
        }

        [Test]
        public void Can_change_orientation_toward_left()
        {
            var rover = new Rover("5 5 1 2 N");
            rover.Move("L");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 W");
        }

        [Test]
        public void Can_change_orientation_twice_toward_left()
        {
            var rover = new Rover("5 5 1 2 N");
            rover.Move("LL");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 S");
        }

        [Test]
        public void Can_change_orientation_once_then_move_forward()
        {
            var rover = new Rover("5 5 1 2 N");
            rover.Move("RM");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("2 2 E");
        }

        [Test]
        public void Can_change_orientation_toward_left_initial_orientation_is_W()
        {
            var rover = new Rover("5 5 1 2 W");
            rover.Move("L");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 S");
        }

        [Test]
        public void Can_change_orientation_toward_right_initial_orientation_is_W()
        {
            var rover = new Rover("5 5 1 2 W");
            rover.Move("R");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 N");
        }

        [Test]
        public void Can_change_orientation_3_times_toward_right_initial_orientation_is_W()
        {
            var rover = new Rover("5 5 1 2 W");
            rover.Move("RRR");

            string positionAndOrientation = rover.GetPositionAndOrientation();
            Check.That(positionAndOrientation).IsEqualTo("1 2 S");
        }
    }
}