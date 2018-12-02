﻿using System.Collections.Generic;
using System.Linq;

namespace KataMarsRovers
{
    public class Compass
    {
        private Orientation _orientation;
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
            North.Link(West, South, Est);
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
    }
}