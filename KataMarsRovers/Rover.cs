using System;
using System.Collections.Generic;

namespace KataMarsRovers
{
    public class Rover
    {
        private Coordinate _coordinate;
        
        private string _orientation;
        private readonly Compass _compass;

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
                    GoForward(_coordinate, _orientation);
                }
                else
                {
                    throw new ArgumentException($"Unknown instruction: {instruction}");
                }
                
            }
        }

        private void GoForward(Coordinate coordinateBeforeForwarding, string orientation)
        {
            switch (orientation)
            {
                case "N":
                    _coordinate = coordinateBeforeForwarding.Change(0, 1);
                    break;
                case "S":
                    _coordinate = coordinateBeforeForwarding.Change(0, -1);
                    break;
                case "W":
                    _coordinate = coordinateBeforeForwarding.Change(-1, 0);
                    break;
                case "E":
                    _coordinate = coordinateBeforeForwarding.Change(1, 0);
                    break;
            }
        }


        public string GetPositionAndOrientation()
        {
            return $"{_coordinate.XPosition} {_coordinate.YPosition} {_orientation}";
        }

    }
}