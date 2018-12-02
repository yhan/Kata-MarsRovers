namespace KataMarsRovers
{
    public class Orientation
    {
        public string Name { get; }

        public Orientation(string name)
        {
            Name = name;
        }
        
        public Orientation Link(params Orientation[] orientations)
        {
            var current = this;

            foreach (var orientation in orientations)
            {
                current.Left = orientation;
                orientation.Right = current;

                current = orientation;
            }

            var last = orientations[2];
            this.Right = last;
            last.Left = this;

            return this;
        }

        public Orientation Left { get; set; }

        public Orientation Right { get; set; }
    }
}