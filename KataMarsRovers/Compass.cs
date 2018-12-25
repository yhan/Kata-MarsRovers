using System.Collections.Generic;
using System.Linq;

namespace KataMarsRovers
{
    public class Compass
    {
        private Orientation _orientation;
        public Orientation North { get; }
        public Orientation West { get; }
        public Orientation South { get; }
        public Orientation East { get; }
        private readonly IDictionary<string, Orientation> _map;

        public Compass()
        {
            North = new Orientation("N");
            West = new Orientation("W");
            South = new Orientation("S");
            East =  new Orientation("E");
            _map = new[] {North, West, South, East}.ToDictionary(x => x.Name, x => x);
            Link(North, West, South, East);
        }

        public Compass StartWith(string start)
        {
            _orientation = _map[start];
            return this;
        }

        public string Turns(string turningInstructions)
        {
            foreach (var c in turningInstructions.ToCharArray())
            {
                string instruction = c.ToString();
                if (instruction == "L")
                {
                    _orientation = _orientation.Left;
                }
                else
                {
                    _orientation = _orientation.Right;
                }
            }

            return _orientation.Name;
        }

        public string Turns(char turningInstruction)
        {
            if (turningInstruction == 'L')
            {
                _orientation = _orientation.Left;
            }
            else
            {
                _orientation = _orientation.Right;
            }

            return _orientation.Name;
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