namespace KataMarsRovers
{
    public class Rover
    {
        private readonly Coordinate _coordinate;
        
        private string _orientation;
        private readonly Compass _compass;

        public Rover(string initialization)
        {
            _coordinate = new Coordinate(initialization);

            _orientation = initialization.Split(" ")[4];

            _compass = new Compass().StartWith(_orientation);
        }

        public void Move(string instruction)
        {
            _orientation = _compass.Turns(instruction);
        }

        public string GetPositionAndOrientation()
        {
            return $"{_coordinate.XPosition} {_coordinate.YPosition} {_orientation}";
        }

    }
}