namespace KataMarsRovers
{
    public class Coordinate
    {
        public string XPosition;

        public Coordinate(string coordinateAsString)
        {
            var split = coordinateAsString.Split(" ");
            this.XPosition = split[2];
            this.YPosition = split[3];
        }

        public string YPosition { get; set; }
    }
}