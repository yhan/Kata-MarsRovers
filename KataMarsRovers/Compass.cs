using System.Collections.Generic;
using System.Linq;

namespace KataMarsRovers
{
    public class Compass
    {
        private Orientation _pointTo;
        public Orientation North { get; }
        public Orientation West { get; }
        public Orientation South { get; }
        public Orientation Est { get; }
        private readonly IDictionary<string, Orientation> _map;

        public Compass()
        {
            North = new Orientation("N");
            West = new Orientation("W");
            South = new Orientation("S");
            Est =  new Orientation("E");
            _map = new[] {North, West, South, Est}.ToDictionary(x => x.Name, x => x);
            Link(North, West, South, Est);
        }

        public Compass StartWith(string start)
        {
            _pointTo = _map[start];
            return this;
        }

        public string Turns(string turningInstructions)
        {
            foreach (var c in turningInstructions.ToCharArray())
            {
                string instruction = c.ToString();
                if (instruction == "L")
                {
                    _pointTo = _pointTo.Left;
                }
                else
                {
                    _pointTo = _pointTo.Right;
                }
            }

            return _pointTo.Name;
        }

        private static Orientation Link(Orientation start, params Orientation[] orientations)
        {
            var current = start;

            foreach (var orientation in orientations)
            {
                current.Left = orientation;
                orientation.Right = current;

                current = orientation;
            }

            var last = orientations[2];
            start.Right = last;
            last.Left = start;

            return start;
        }
    }
}