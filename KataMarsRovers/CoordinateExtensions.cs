using System;

namespace KataMarsRovers
{
    public static class CoordinateExtensions
    {
        public static Coordinate MoveOneStepOnDirectionOf(this Coordinate coordinateBeforeForwarding, string orientation)
        {
            switch (orientation)
            {
                case "N":
                    return coordinateBeforeForwarding.Change(0, 1);
                case "S":
                    return coordinateBeforeForwarding.Change(0, -1);
                case "W":
                    return coordinateBeforeForwarding.Change(-1, 0);
                case "E":
                    return coordinateBeforeForwarding.Change(1, 0);
            }

            throw new ArgumentException($"Invalid orientation: {orientation}");

        }
    }
}