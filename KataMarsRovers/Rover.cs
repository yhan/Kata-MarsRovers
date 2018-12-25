using System;

namespace KataMarsRovers
{
    public class Rover
    {
        private readonly Compass _compass;
        private Coordinate _coordinate;

        private string _orientation;

        public Rover(string initialization)
        {
            _coordinate = new Coordinate(initialization);

            //5 5 1 2 W
            _orientation = initialization.Split(" ")[4];

            _compass = new Compass().StartWith(_orientation);
        }

        public void Move(string instructions)
        {
            foreach (var instruction in instructions.ToCharArray())
            {
                if (instruction == 'L' || instruction == 'R')
                {
                    _orientation = _compass.Turns(instruction);
                }
                else if (instruction == 'M')
                {
                    _coordinate = _coordinate.MoveOneStepOnDirectionOf(_orientation);
                }
                else
                {
                    throw new ArgumentException($"Unknown instruction: {instruction}");
                }
            }
        }


        public string GetPositionAndOrientation()
        {
            return $"{_coordinate.XPosition} {_coordinate.YPosition} {_orientation}";
        }
    }
}