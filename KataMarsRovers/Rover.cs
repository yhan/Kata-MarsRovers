namespace KataMarsRovers
{
    using System.Collections.Generic;
    using System.Linq;

    public class Rover
    {
        private IList<string> _instructionOrientation;

        private Coordinate Coordinate;
        
        private List<string> _possibleOrientations = new List<string> {"N", "W","S","E"};

        protected internal string _orientation;

        public Rover(string initialization)
        {
            this.Coordinate = new Coordinate(initialization);

            this._orientation = initialization.Split(" ")[4];
        }

        public void Move(string instruction)
        {
            this._instructionOrientation = instruction.ToCharArray().Select(x => x.ToString()).ToList();
            this._orientation = this.GetOrientation();
        }

        public string GetPositionAndOrientation()
        {
            
            return $"{this.Coordinate.XPosition} {this.Coordinate.YPosition} {this._orientation}";
        }

        private string GetOrientation()
        {
            var orientation = string.Empty;

            var index = this._possibleOrientations.IndexOf(this._orientation);

            var count = this._instructionOrientation.Count;
            for (var orientationChanges = 0; orientationChanges < count; orientationChanges++)
            {
                if (this._instructionOrientation[orientationChanges] == "R")
                {
                    index--;
                    if (index == -1)
                    {
                        index = 3;
                    }
                }
                else
                {
                    index++;
                    if (index == this._possibleOrientations.Count)
                    {
                        index = 0;
                    }
                }

                orientation = this._possibleOrientations[index];
            }

            return orientation;
        }
    }
}