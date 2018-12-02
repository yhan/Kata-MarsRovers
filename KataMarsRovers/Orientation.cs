namespace KataMarsRovers
{
    public class Orientation
    {
        public string Name { get; }

        public Orientation(string name)
        {
            Name = name;
        }
        
        public Orientation Left { get; set; }

        public Orientation Right { get; set; }
    }
}