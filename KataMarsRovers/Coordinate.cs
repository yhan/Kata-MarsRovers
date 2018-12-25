namespace KataMarsRovers
{
    public class Coordinate
    {
        //5 5 1 2 W
        public Coordinate(string coordinateAsString)
        {
            var split = coordinateAsString.Split(" ");
            this.XPosition = int.Parse(split[2]);
            this.YPosition = int.Parse(split[3]);
        }


        public int XPosition { get; private set; }

        public int YPosition { get; private set; }

        public Coordinate Change(int moveX, int moveY)
        {
            this.XPosition += moveX;
            this.YPosition += moveY;

            return this;
        }
    }
}